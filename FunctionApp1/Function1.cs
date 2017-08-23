using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "works")]HttpRequestMessage req)
        {
            req.GetRequestContext().IncludeErrorDetail = true;
            req.GetRequestContext().IsLocal = true;
            req.GetConfiguration().Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
            throw new Exception("unexpected exception");
        }
    }
}
