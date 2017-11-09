using System.Configuration;

namespace Settings {
    public static class SettingsManager {
        public static string GetSetting(string key) {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetSetting(string key, string value) {
            var configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove(key);
            configuration.AppSettings.Settings.Add(key, value);
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
