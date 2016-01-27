using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGP.Api.Models.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginViewModel
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        #endregion
    }
}