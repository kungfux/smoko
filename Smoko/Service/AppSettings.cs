using System;
using System.Configuration;

namespace Smoko.Service
{
    internal static class AppSettings
    {
        private const string PORT_SETTING_NAME = "Port";
        private const string NAME_SETTING_NAME = "Name";
        private const string POPUP_DELAY_SETTING_NAME = "PopupDelay";

        private const int DEFAULT_PORT = 5432;
        private static readonly string DEFAULT_NAME = Environment.UserName;
        private const int DEFAULT_POPUP_DELAY = 5000;

        public static int GetPort()
        {
            if (!int.TryParse(ConfigurationManager.AppSettings[PORT_SETTING_NAME], out var port))
                port = DEFAULT_PORT;
            return port;
        }

        public static string GetName()
        {
            var name = ConfigurationManager.AppSettings[NAME_SETTING_NAME];
            return string.IsNullOrEmpty(name) ? DEFAULT_NAME : name;
        }

        public static int GetPopupDelay()
        {
            if (!int.TryParse(ConfigurationManager.AppSettings[POPUP_DELAY_SETTING_NAME], out var delay))
                delay = DEFAULT_POPUP_DELAY;
            return delay;
        }
    }
}
