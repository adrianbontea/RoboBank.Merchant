using Microsoft.ApplicationInsights;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace RoboBank.Merchant.Service.Custom
{
    //TODO: Extract this in a NuGet package and publish in an internal repository (reusable WebAPI-based infrastructure)
    public class AIGenericExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var telemetryClient = new TelemetryClient();
            telemetryClient.TrackException(actionExecutedContext.Exception);

            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception.Message);
        }
    }
}
