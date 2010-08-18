using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using BootFX.Common.Crypto;

namespace AmxMobile.Services.Web
{
    public partial class ApiRest : RestBasePage
    {
        private const string ResultKey = "Result";
        private const string MessageKey = "Message";
        private const string TokenKey = "Token";
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void PopulateResponse(ApiKey api, LogonToken token, string operation, XmlElement root)
        {
            if (api == null)
                throw new ArgumentNullException("api");
            if (root == null)
                throw new ArgumentNullException("root");
            if (operation == null)
                throw new ArgumentNullException("operation");
            if (operation.Length == 0)
                throw new ArgumentException("'operation' is zero-length.");

            // if...
            if (string.Compare(operation, "logon", true, Cultures.System) == 0)
                ProcessLogon(api, token, root);
            else if (string.Compare(operation, "logoff", true, Cultures.System) == 0)
                ProcessLogoff(api, token, root);
            else
                throw new NotSupportedException(string.Format("Cannot handle '{0}'.", operation));
        }

        private void ProcessLogon(ApiKey api, LogonToken token, XmlElement root)
        {
            if (api == null)
                throw new ArgumentNullException("api");
            if (root == null)
                throw new ArgumentNullException("root");

            // get the password...
            string password = this.Request.Params["password"];
            if (password == null)
                throw new InvalidOperationException("'password' is null.");
            if (password.Length == 0)
                throw new InvalidOperationException("'password' is zero-length.");

            // check...
            string hashed = EncryptionHelper.HashPasswordToBase64String(password, api.PasswordSalt);
            if (hashed == api.PasswordHash)
            {
                // create a new token...
                token = new LogonToken();
                token.ApiKey = api;
                token.GenerateToken();
                token.UpdateExpiry(false);

                // save...
                token.SaveChanges();

                // set...
                XmlHelper.AddElement(root, ResultKey, LogonResult.LogonOk);
                XmlHelper.AddElement(root, TokenKey, token.Token.ToString());
            }
            else
            {
                XmlHelper.AddElement(root, ResultKey, LogonResult.InvalidPassword);
                XmlHelper.AddElement(root, MessageKey, "The password is invalid.");
            }
        }

        private void ProcessLogoff(ApiKey api, LogonToken token, XmlElement root)
        {
            if (token != null)
            {
                token.MarkForDeletion();
                token.SaveChanges();
            }

            // return...
            XmlHelper.AddElement(root, ResultKey, LogoffResult.LogoffOk);
        }
    }
}
