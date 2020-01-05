using System;
using System.Collections.Generic;
using System.Globalization;
using PrismTests.Interfaces;

namespace PrismTests.Models
{
    public class Settings : ISettings
    {
        /// <summary>
        /// The application settings dictionary.
        /// </summary>
        private readonly Dictionary<string, string> _appSettingsDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings" /> class.
        /// </summary>
        public Settings()
        {
#if DEBUG
            _appSettingsDictionary.Add("ApiUrlKey", "https://test.apiexample.com/PrismSampleApi");
#else
            _appSettingsDictionary.Add("ApiUrlKey", "https://apiexample.com/PrismSampleApi");
#endif
            _appSettingsDictionary.Add("AESKey", "Xn2r5u8x/A?D(G+K");
            _appSettingsDictionary.Add("AppTokenKey", string.Empty);
            _appSettingsDictionary.Add("TokenCreationKey", DateTime.Now.ToString(CultureInfo.InvariantCulture));
            _appSettingsDictionary.Add("TokenExpiryKey", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        #region Properties

#if DEBUG
        /// <summary>
        /// PTS Mobile Build type (DEBUG or RELEASE)
        /// </summary>
	    public string AppBuildConfig => "DEBUG";
#else
        /// <summary>
        /// PTS Mobile Build type (DEBUG or RELEASE)
        /// </summary>
        public string AppBuildConfig => "RELEASE";
#endif

        /// <summary>
        /// Gets or sets the aes key.
        /// </summary>
        /// <value>The aes key.</value>
        public string AESKey
        {
            get => (_appSettingsDictionary.ContainsKey("AESKey"))
                ? _appSettingsDictionary["AESKey"] : String.Empty;
            set => _appSettingsDictionary["AESKey"] = value;
        }

        /// <summary>
        /// Gets or sets the corp apps URL.
        /// </summary>
        /// <value>The corp apps URL.</value>
        public string ApiUrl
        {
            get => (_appSettingsDictionary.ContainsKey("ApiUrlKey"))
                ? _appSettingsDictionary["ApiUrlKey"] : String.Empty;
            set => _appSettingsDictionary["ApiUrlKey"] = value;
        }

        /// <summary>
        /// Gets or sets the application token.
        /// </summary>
        /// <value>The application token.</value>
        public string AppToken
        {
            get => (_appSettingsDictionary.ContainsKey("AppTokenKey"))
                ? _appSettingsDictionary["AppTokenKey"] : String.Empty;
            set => _appSettingsDictionary["AppTokenKey"] = value;
        }

        /// <summary>
        /// Gets or sets the token creation date.
        /// </summary>
        /// <value>The token creation date.</value>
        public DateTime TokenCreationDate
        {
            get => (_appSettingsDictionary.ContainsKey("TokenCreationKey"))
                ? Convert.ToDateTime(_appSettingsDictionary["TokenCreationKey"]) : DateTime.Now;
            set => _appSettingsDictionary["TokenCreationKey"] = value.ToString();
        }

        /// <summary>
        /// Gets or sets the token expiry date.
        /// </summary>
        /// <value>The token expiry date.</value>
        public DateTime TokenExpiryDate
        {
            get => (_appSettingsDictionary.ContainsKey("TokenExpiryKey"))
                ? Convert.ToDateTime(_appSettingsDictionary["TokenExpiryKey"]) : DateTime.Now;
            set => _appSettingsDictionary["TokenExpiryKey"] = value.ToString();
        }

        #endregion
    }
}
