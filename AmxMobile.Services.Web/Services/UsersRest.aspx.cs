using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Web;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using BootFX.Common.Crypto;

namespace AmxMobile.Services.Web
{
    public partial class UsersRest : RestBasePage
    {
        private const string ResultKey = "Result";
        private const string MessageKey = "Message";
        private const string TokenKey = "Token";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void PopulateResponse(ApiKey api, LogonToken token, string operation, XmlElement root)
        {
            if(api == null)
	            throw new ArgumentNullException("api");
            if (operation == null)
                throw new ArgumentNullException("operation");
            if (root == null)
                throw new ArgumentNullException("foo");

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
            if (token == null)
                throw new ArgumentNullException("token");
            if (root == null)
                throw new ArgumentNullException("root");

            // reset...
            token.User = null;
            token.SaveChanges();

            // get...
            string username = this.Request.Params["username"];
            if (username == null)
                throw new InvalidOperationException("'username' is null.");
            if (username.Length == 0)
                throw new InvalidOperationException("'username' is zero-length.");
            string password = this.Request.Params["password"];
            if (password == null)
                throw new InvalidOperationException("'password' is null.");
            if (password.Length == 0)
                throw new InvalidOperationException("'password' is zero-length.");

            // find a user...
            UserItem user = UserItem.GetByUsernameAndApiKeyId(username, api.ApiKeyId);
            if (user != null)
            {
                // active?
                if (user.IsActive)
                {
                    // check...
                    string hash = EncryptionHelper.HashPasswordToBase64String(password, user.PasswordSalt);
                    if (user.PasswordHash == hash)
                    {
                        // save...
                        token.User = user;
                        token.SaveChanges();

                        // ok...
                        XmlHelper.AddElement(root, ResultKey, LogonResult.LogonOk);
                        XmlHelper.AddElement(root, TokenKey, token.Token);
                    }
                    else
                    {
                        XmlHelper.AddElement(root, ResultKey, LogonResult.InvalidPassword);
                        XmlHelper.AddElement(root, MessageKey, "The password is invalid.");
                    }
                }
                else
                {
                    XmlHelper.AddElement(root, ResultKey, LogonResult.AccountDisabled);
                    XmlHelper.AddElement(root, MessageKey, "The account is not active.");
                }
            }
            else
            {
                XmlHelper.AddElement(root, ResultKey, LogonResult.InvalidUsername);
                XmlHelper.AddElement(root, MessageKey, "The username is invalid.");
            }
        }

        /// <summary>
        /// Handles the logoff operation.
        /// </summary>
        /// <param name="api"></param>
        /// <param name="token"></param>
        /// <param name="root"></param>
        private void ProcessLogoff(ApiKey api, LogonToken token, XmlElement root)
        {
            if (token != null)
            {
                token.User = null;
                token.SaveChanges();
            }

            // send...
            XmlHelper.AddElement(root, ResultKey, LogoffResult.LogoffOk);
        }
    }
}
