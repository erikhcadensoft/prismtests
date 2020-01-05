using System;
namespace PrismTests.Interfaces
{
    public interface ISettings
    {
        string AppBuildConfig { get; }

        string AESKey { get; set; }

        string ApiUrl { get; set; }

        string AppToken { get; set; }

        DateTime TokenCreationDate { get; set; }

        DateTime TokenExpiryDate { get; set; }
    }
}
