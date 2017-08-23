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
    public static class Function2
    {
        [FunctionName("Function2")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "fails")]HttpRequestMessage req, ExecutionContext context)
        {
            req.GetConfiguration().Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
            throw new Exception("unexpected exception");
        }
    }
}
