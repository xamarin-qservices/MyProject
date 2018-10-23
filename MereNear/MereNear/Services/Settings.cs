using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Services
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion
        public static string MobileNumber
        {
            get
            {
                return AppSettings.GetValueOrDefault("MobileNumber", string.Empty);
            }
            set
            {
                AppSettings.AddOrUpdateValue("MobileNumber", value);
            }
        }

        public static string PersonName
        {
            get
            {
                return AppSettings.GetValueOrDefault("PersonName", string.Empty);
            }
            set
            {
                AppSettings.AddOrUpdateValue("PersonName", value);
            }
        }

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

    }
}

