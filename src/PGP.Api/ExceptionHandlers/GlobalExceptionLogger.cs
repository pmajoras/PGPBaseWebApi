using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace PGP.Api.ExceptionHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            
            base.Log(context);
        }
    }
}