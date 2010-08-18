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

namespace AmxMobile.Services.Web
{
    [PageSecurity(true)]
    public partial class ViewProfile : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                throw new InvalidOperationException("'CurrentUser' is null.");

            // set...
            if (!(this.IsPostBack))
                this.textEmail.Text = this.CurrentUser.Email;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // sub...
            this.buttonEmail.Click += new EventHandler(buttonEmail_Click);
            this.buttonPassword.Click += new EventHandler(buttonPassword_Click);
        }

        void buttonPassword_Click(object sender, EventArgs e)
        {
            this.widgetEmailFeedback.Reset();
            this.widgetPasswordFeedback.Reset();

            FormChecker checker = new FormChecker();
            string password = checker.GetStringValue(new ControlReference(this.textPassword, "Password"), true);
            string confirm = checker.GetStringValue(new ControlReference(this.textConfirm, "Confirm"), true);

            // check...
            if (!(checker.HasErrors))
            {
                // match?
                if (password == confirm)
                {
                    // set...
                    this.CurrentUser.SetPassword(password, true);

                    // show...
                    this.widgetPasswordFeedback.SetInfo("Your password has been changed.");
                }
                else
                    checker.AddError("The passwords do not match.");
            }

            // show...
            if (checker.HasErrors)
                this.widgetPasswordFeedback.SetError(checker);
        }

        void buttonEmail_Click(object sender, EventArgs e)
        {
            this.widgetEmailFeedback.Reset();
            this.widgetPasswordFeedback.Reset();

            FormChecker checker = new FormChecker();
            string email = checker.GetStringValue(new ControlReference(this.textEmail, "Email"), true);

            // check...
            if (!(checker.HasErrors))
            {
                // get...
                ApiKey existing = ApiKey.GetByEmail(email);
                if (existing == null)
                {
                    // set...
                    this.CurrentUser.Email = email;
                    this.CurrentUser.SaveChanges();

                    // show...
                    this.widgetEmailFeedback.SetInfo("The email address has been changed.");
                }
                else
                {
                    // us?
                    if(CurrentUser == null)
	                    throw new InvalidOperationException("'CurrentUser' is null.");
                    if (existing.ApiKeyId == this.CurrentUser.ApiKeyId)
                        checker.AddError("Please enter a new email address.");
                    else
                        checker.AddError("Another account is already using this email address.");
                }
            }

            // show...
            if (checker.HasErrors)
                this.widgetEmailFeedback.SetError(checker);
        }
    }
}
