using System;
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
    [PageSecurity(false)]
    public partial class Logon : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // sub...
            this.buttonLogon.Click += new EventHandler(buttonLogon_Click);
        }

        void buttonLogon_Click(object sender, EventArgs e)
        {
            this.widgetFeedback.Reset();

            // get...
            FormChecker checker = new FormChecker(this);
            string username = checker.GetStringValue(new ControlReference(this.textUsername, "Username"), true);
            string password = checker.GetStringValue(new ControlReference(this.textPassword, "Password"), true);

            // not...
            if (!(checker.HasErrors))
            {
                // find...
                ApiKey key = ApiKey.GetByUsername(username);
                if (key != null)
                {
                    if (key.IsActive)
                    {
                        // password...
                        string hashed = EncryptionHelper.HashPasswordToBase64String(password, key.PasswordSalt);
                        if (hashed == key.PasswordHash)
                        {
                            // logon...
                            RememberUserFlags flags = RememberUserFlags.DoNotRememberUsers;
                            if(this.checkRemember.Checked)
                                flags = RememberUserFlags.UsernameAndPassword;
                            this.Logon(key, flags, new TimeSpan(90, 0, 0, 0));

                            // go...
                            this.Response.Redirect("~/default.aspx");
                        }
                        else
                            checker.AddError("The password is invalid.");
                    }
                    else
                        checker.AddError("The API account is not active.");
                }
                else
                    checker.AddError("The username is invalid.");
            }

            // show...
            if (checker.HasErrors)
                this.widgetFeedback.SetError(checker);
        }
    }
}
