using System.Configuration;
using Microsoft.ApplicationInsights.Extensibility;

namespace RoboBank.Merchant.Service
{
    public static class ApplicationInsightsConfig
    {
        public static void Configure()
        {
            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["ApplicationInsightsKey"];
        }
    }
}