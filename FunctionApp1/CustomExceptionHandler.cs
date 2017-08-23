using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace FunctionApp1
{
    public sealed class CustomExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ResponseMessageResult(context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "custom message string"));
        }
    }
}
