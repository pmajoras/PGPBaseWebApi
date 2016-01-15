using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;
using PGP.Infrastructure.Framework.WebApi.ApiMessagesHandlers;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;

namespace PGP.Infrastructure.Framework.WebApi.ExceptionHandlers
{
    /// <summary>
    /// The Class responsable for the global exception handler of the API.
    /// </summary>
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private IApiMessageHandler m_apiMessageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
        /// </summary>
        /// <param name="apiMessageHandler">The API message handler.</param>
        public GlobalExceptionHandler(IApiMessageHandler apiMessageHandler)
        {
            m_apiMessageHandler = apiMessageHandler;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;
            var httpException = exception as HttpException;
            var httpStatusCode = HttpStatusCode.InternalServerError;

            if (httpException != null)
            {
                httpStatusCode = (HttpStatusCode)httpException.ErrorCode;
                return;
            }

            context.Result = ApiResultsHelper.CreateApiResultFromException(context.Request,
                  httpException,
                  m_apiMessageHandler.GetGenericErrorCode(),
                  m_apiMessageHandler.GetMessageFromCode(m_apiMessageHandler.GetGenericErrorCode()),
                  httpStatusCode);
        }
    }
}