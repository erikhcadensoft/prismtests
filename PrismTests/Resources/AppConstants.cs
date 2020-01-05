using System;
namespace PrismTests.Resources
{
    public class AppConstants
    {
        public static class AppSettings
        {
            internal const string AssemblyName = "PrismTests";
            internal const string ViewNamespace = "PrismTests.Views";
            internal const string LiteDbName = "LiteDb.db";
            public const string LiteDbConnStr = "filename={0}; mode=exclusive";

            //License key for App Center SDK for iOS.
            public const string LicenseKeyAppCenteriOS = "";
            internal const int TokenExpirationMinutes = 7200; //5 Days
        }

        public static class AppStrings
        {
            internal const string Replacement = "REPLACEMENT";
        }

        public static class Navigation
        {
            internal const string MasterTag = "MasterTagPage";
            internal const string Dashboard = "MenuPage/NavigationPage/DashboardPage";
        }
    }
}
