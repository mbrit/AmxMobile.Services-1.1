using System;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Email;
using BootFX.Common.Management;
using BootFX.Cms;

namespace AmxMobile.Services
{
    public class EmailHelper
    {
        internal static void CheckReferenceData()
        {
            Type type = typeof(EmailKeys);
            foreach (FieldInfo field in type.GetFields())
                CheckReferenceData((string)field.GetValue(null));
        }

        private static void CheckReferenceData(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name.Length == 0)
                throw new ArgumentException("'name' is zero-length.");

            // log...
            ILog log = LogSet.GetLog(typeof(EmailHelper));
            if (log.IsInfoEnabled)
                log.Info(string.Format("Checking email '{0}'...", name));

            // get...
            XmlDocument doc = ResourceHelper.GetXmlDocument(string.Format("AmxMobile.Services.Resources.{0}.xml", name));
            if (doc == null)
                throw new InvalidOperationException("'doc' is null.");

            // subject...
            XmlElement root = (XmlElement)doc.SelectSingleNode("Email");
            if (root == null)
                throw new InvalidOperationException("'root' is null.");
            string subject = XmlHelper.GetElementString(root, "Subject", OnNotFound.ThrowException);
            string html = XmlHelper.GetElementString(root, "Html", OnNotFound.ThrowException);

            // get...
            CmsContentItem item = CmsContentItem.GetByName(name);
            if (item == null)
            {
                // create...
                item = CmsContentItem.CreateItem(name, CmsContentType.Html, false, null);
                if (item == null)
                    throw new InvalidOperationException("'item' is null.");

                // set...
                CmsContentItemVersion version = item.GetPublishedVersion(true);
                if (version == null)
                    throw new InvalidOperationException("'version' is null.");

                // set...
                version.Title = subject;
                version.Content = html;
                version.SaveChanges();
            }
        }

        public static void SendEmail(string name, ApiKey key)
        {
            SendEmail(name, key, CollectionsUtil.CreateCaseInsensitiveHashtable());
        }

        public static void SendEmail(string name, ApiKey key, IDictionary values)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name.Length == 0)
                throw new ArgumentException("'name' is zero-length.");
            if (key == null)
                throw new ArgumentNullException("key");
            if (values == null)
                throw new ArgumentNullException("values");

            // set...
            CmsContentItem item = CmsContentItem.GetByName(name);
            if (item == null)
                throw new InvalidOperationException("'item' is null.");

            // get...
            values["key"] = key;
            MailMessage message = item.GetMailMessage(values);
            if (message == null)
                throw new InvalidOperationException("'message' is null.");

            // send...
            SmtpConnectionSettings settings = Settings.GetSmtpSettings();
            if (settings == null)
                throw new InvalidOperationException("'settings' is null.");
            ISmtpProvider provider = MailProviderFactory.GetSmtpProvider(settings);
            if (provider == null)
                throw new InvalidOperationException("'provider' is null.");

            // send...
            message.FromAsString = Settings.EmailFrom;
            message.ToAsString = key.Email;
            message.BccAsString = Settings.EmailBcc;
            provider.Send(message);
        }
    }
}
