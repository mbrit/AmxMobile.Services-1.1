using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Web;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace AmxMobile.Services.Web
{
    [PageSecurity(false)]
    public class RestBasePage : ServicesBasePage
    {
        private const string RootKey = "AmxResponse";
        private const string HasExceptionKey = "HasException";
        private const string ErrorKey = "Error";
        private const string OperationKey = "Operation";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // run...
            XmlDocument doc = new XmlDocument();
            try
            {
                // get the api...
                LogonToken token = null;
                ApiKey key = ServiceAuthenticator.Current.GetApi(ref token);
                if (key == null)
                    throw new InvalidOperationException("'key' is null.");

                // do we have a token?
                if(token != null)
                    token.UpdateExpiry(true);

                // what operation...
                string operation = this.Request.Params[OperationKey];
                if (string.IsNullOrEmpty(operation))
                    throw new InvalidOperationException("An operation was not specifed.");

                // create...
                doc = CreateResponseDocument(key, token, operation);
            }
            catch (Exception ex)
            {
                doc = CreateErrorDocument(ex);
            }

            // return...
            WebRuntime.Current.TransmitDocument(doc, MimeTypes.Xml, null, this.Response, TransmitDocumentFlags.Normal);
        }

        private XmlDocument CreateErrorDocument(Exception ex)
        {
            XmlDocument doc = new XmlDocument();

            // root...
            XmlElement root = doc.CreateElement(RootKey);
            doc.AppendChild(root);

            // set...
            XmlHelper.AddElement(root, ErrorKey, ex.ToString());
            XmlHelper.AddElement(root, HasExceptionKey, true);

            // return...
            return doc;
        }

        private XmlDocument CreateResponseDocument(ApiKey apiKey, LogonToken token, string operation)
        {
            if (apiKey == null)
                throw new ArgumentNullException("apiKey");
            if (operation == null)
                throw new ArgumentNullException("operation");
            if (operation.Length == 0)
                throw new ArgumentException("'operation' is zero-length.");

            // create...
            XmlDocument doc = new XmlDocument();

            // root...
            XmlElement root = doc.CreateElement(RootKey);
            doc.AppendChild(root);

            // defer...
            PopulateResponse(apiKey, token, operation, root);

            // ok...
            XmlHelper.AddElement(root, HasExceptionKey, false);

            // return...
            return doc;
        }

        protected virtual void PopulateResponse(ApiKey apiItem, LogonToken token, string operation, XmlElement root)
        {
            throw new NotImplementedException();
        }
    }
}
