using System;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.AppCenter.Analytics;
//using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace PrismTests.Helpers
{
    public static class Logger
    {
        public static void TrackLoadTime(string eventName, TimeSpan? ts, Dictionary<string, string> additionalProperties = null)
        {
            try
            {
                string elapsedTime = $" | Time to Load: Hours: {ts?.Hours:00} Minutes:{ts?.Minutes:00} Seconds:{ts?.Seconds:00}.{ts?.Milliseconds / 10:00}";
                var key = additionalProperties.ElementAt(0).Key;
                additionalProperties[key] = string.Concat(additionalProperties[key], elapsedTime);
                LogEvent(eventName, "TrackLoadTime", additionalProperties);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public static void LogEvent(string eventName, string message, Dictionary<string, string> additionalProperties = null)
        {
            var properties = new Dictionary<string, string>
            {
                { "Device Type", Device.RuntimePlatform },
                { "Message", message }
            };

            if (additionalProperties != null)
            {
                var i = 0;
                foreach (var prop in additionalProperties)
                {
                    var key = additionalProperties.ElementAt(i).Key;
                    var val = additionalProperties.ElementAt(i).Value;
                    properties.Add(key, val);
                    i++;
                }
            }

            //Analytics.TrackEvent(eventName, properties);
        }

        public static void LogError(Exception exception)
        {
            var properties = new Dictionary<string, string>
            {
                { "Device Type", Device.RuntimePlatform },
                { "Message", exception.Message }
            };

            //Crashes.TrackError(exception, properties);
        }
    }
}
