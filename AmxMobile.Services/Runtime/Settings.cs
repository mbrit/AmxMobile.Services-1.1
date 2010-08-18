using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Email;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace AmxMobile.Services
{
    [SharedSettingsContainer()]
    public sealed class Settings
    {
        [SharedSettingsItem("username")]
        public static string SmtpUsername
        {
            get
            {
                return Runtime.Current.SharedSettings.GetStringValue("SmtpUsername", "username", Cultures.System, OnNotFound.ReturnNull);
            }
        }

        [SharedSettingsItem("password")]
        public static string SmtpPassword
        {
            get
            {
                return Runtime.Current.SharedSettings.GetStringValue("SmtpPassword", "password", Cultures.System, OnNotFound.ReturnNull);
            }
        }

        [SharedSettingsItem("server")]
        public static string SmtpServer
        {
            get
            {
                return Runtime.Current.SharedSettings.GetStringValue("SmtpServer", "server", Cultures.System, OnNotFound.ReturnNull);
            }
        }

        [SharedSettingsItem("from")]
        public static string EmailFrom
        {
            get
            {
                return Runtime.Current.SharedSettings.GetStringValue("EmailFrom", "from", Cultures.System, OnNotFound.ReturnNull);
            }
        }

        [SharedSettingsItem("you")]
        public static string EmailBcc
        {
            get
            {
                return Runtime.Current.SharedSettings.GetStringValue("EmailBcc", "you", Cultures.System, OnNotFound.ReturnNull);
            }
        }

        internal static SmtpConnectionSettings GetSmtpSettings()
        {
            return new SmtpConnectionSettings(SmtpServer, SmtpUsername, SmtpPassword);
        }
    }
}
