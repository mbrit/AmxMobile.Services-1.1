using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Web;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using System.Collections.Specialized;

namespace AmxMobile.Services.Web
{
    [PageSecurity(false)]
    public partial class Forgot : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // sub...
            this.buttonReset.Click += new EventHandler(buttonReset_Click);
        }

        void buttonReset_Click(object sender, EventArgs e)
        {
            this.widgetFeedback.Reset();

            // get...
            FormChecker checker = new FormChecker();
            string email = checker.GetStringValue(new ControlReference(this.textEmail, "Email"), true);

            // not...
            if(!(checker.HasErrors))
            {
                // find...
                ApiKey key = ApiKey.GetByEmail(email);
                if (key != null)
                {
                    // reset...
                    string password = key.ResetPassword();

                    // send...
                    IDictionary values = CollectionsUtil.CreateCaseInsensitiveHashtable();
                    values["password"] = password;
                    EmailHelper.SendEmail(EmailKeys.ForgotPassword, key, values);

                    // show...
                    this.widgetFeedback.SetInfo("Your new password has been sent.");
                }
                else
                    checker.AddError(string.Format("An account for email address '{0}' was not found.", email));
            }

            // show...
            if (checker.HasErrors)
                this.widgetFeedback.SetError(checker);
        }
    }
}
