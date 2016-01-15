using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using PGP.Api.Messages;
using PGP.Infrastructure.Framework.WebApi.ApiMessagesHandlers;
using PGP.Infrastructure.Framework.WebApi.Helpers;
using PGP.Infrastructure.Framework.WebApi.Models;

namespace PGP.Api.ApiMessageHandlers
{
    /// <summary>
    ///
    /// </summary>
    public class MessageHandler : IApiMessageHandler
    {
        #region Private Properties

        /// <summary>
        /// The m_api messages json path
        /// </summary>
        private string m_apiMessagesJsonPath;

        private Dictionary<int, string> m_errorList = new Dictionary<int, string>();

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandler"/> class.
        /// </summary>
        public MessageHandler()
        {
            LoadMessages();
        }

        #endregion Constructors

        #region Interface Methods

        /// <summary>
        /// Gets the error from code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public ErrorContent GetErrorFromCode(int code)
        {
            string errorMessage = string.Empty;
            if (m_errorList.TryGetValue(code, out errorMessage))
            {
                return new ErrorContent(errorMessage, code);
            }

            return null;
        }

        /// <summary>
        /// Gets the error from enum.
        /// </summary>
        /// <param name="enumCode">The enum code.</param>
        /// <returns></returns>
        public ErrorContent GetErrorFromEnum(Enum enumCode)
        {
            return GetErrorFromCode(Convert.ToInt32(enumCode));
        }

        /// <summary>
        /// Gets the generic error code.
        /// </summary>
        /// <returns></returns>
        public int GetGenericErrorCode()
        {
            return (int)ApiMessageCode.Error;
        }

        /// <summary>
        /// Gets the message from code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public string GetMessageFromCode(int code)
        {
            var errorContent = GetErrorFromCode(code);

            string message = string.Empty;
            if (errorContent != null)
            {
                message = errorContent.Message;
            }

            return message;
        }

        /// <summary>
        /// Gets the message from enum.
        /// </summary>
        /// <param name="enumCode">The enum code.</param>
        /// <returns></returns>
        public string GetMessageFromEnum(Enum enumCode)
        {
            var errorContent = GetErrorFromEnum(enumCode);

            string message = string.Empty;
            if (errorContent != null)
            {
                message = errorContent.Message;
            }

            return message;
        }

        #endregion Interface Methods

        #region Private Methods

        /// <summary>
        /// Loads the messages.
        /// </summary>
        /// <exception cref="System.Exception">Error on loading the messages to the message handler</exception>
        public void LoadMessages()
        {
            try
            {
                m_apiMessagesJsonPath = ConfigurationManager.AppSettings["ApiMessagesJson"];
                var jsonFile = File.ReadAllText(m_apiMessagesJsonPath);
                var messages = JsonConvert
                    .DeserializeObject<Dictionary<string, string>>(jsonFile, JsonHelper.SetDefaultJsonSerializerSettings(new JsonSerializerSettings()));

                m_errorList.Clear();
                foreach (var keyValue in messages)
                {
                    m_errorList.Add(int.Parse(keyValue.Key), keyValue.Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on loading the messages to the message handler", ex);
            }
        }

        #endregion Private Methods
    }
}