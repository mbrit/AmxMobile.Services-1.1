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
    public partial class ViewUser : ServicesBasePage<UserItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Item == null)
                throw new InvalidOperationException("'Item' is null.");

            // new...
            if (!(this.IsPostBack))
            {
                if (this.IsNew)
                {
                    this.labelUser.Text = "[New]";
                    this.checkChangePassword.Checked = true;
                    this.checkChangePassword.Enabled = false;
                    this.RefreshPassword();
                    this.checkIsActive.Checked = true;
                    this.panelBookmarks.Visible = false;
                }
                else
                {
                    this.labelUser.Text = this.Item.Username;

                    // set...
                    this.textUsername.Text = this.Item.Username;
                    this.textEmail.Text = this.Item.Email;
                    this.checkIsActive.Checked = this.Item.IsActive;

                    // bookmarks...
                    this.panelBookmarks.Visible = true;
                    this.linkBookmarks.NavigateUrl = "~/viewbookmarks.aspx?id=" + this.Item.UserId.ToString();

                    // add...
                    if (!(string.IsNullOrEmpty(this.Request.Params["add"])))
                        this.widgetFeedback.SetInfo("The user has been added.");
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // sub...
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
            this.checkChangePassword.CheckedChanged += new EventHandler(checkChangePassword_CheckedChanged);
        }

        void checkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPassword();
        }

        private void RefreshPassword()
        {
            this.panelPassword.Visible = this.checkChangePassword.Checked;
        }

        void buttonSave_Click(object sender, EventArgs e)
        {
            this.widgetFeedback.Reset();

            // checker...
            FormChecker checker = new FormChecker();
            string username = checker.GetStringValue(new ControlReference(this.textUsername, "Username"), true);
            string email = checker.GetStringValue(new ControlReference(this.textEmail, "Email"), true);
            string password = null;
            string confirm = null;
            if(this.checkChangePassword.Checked)
            {
                password = checker.GetStringValue(new ControlReference(this.textPassword, "Password"), true);
                confirm = checker.GetStringValue(new ControlReference(this.textConfirm, "Confirm"), true);
            }

            // checker...
            if (!(checker.HasErrors))
            {
                if (password == confirm)
                {
                    // existing...
                    if (CurrentUser == null)
                        throw new InvalidOperationException("'CurrentUser' is null.");
                    UserItem existing = UserItem.GetByUsernameAndApiKeyId(username, this.CurrentUser.ApiKeyId);
                    if (existing != null && (this.IsNew || existing.UserId != this.Item.UserId))
                        checker.AddError(string.Format("A user with name '{0}' already exists.", username));
                    else
                    {
                        // by email...
                        UserItem byEmail = UserItem.GetByApiKeyIdAndEmail(this.CurrentUser.ApiKeyId, email);
                        if (byEmail != null && (this.IsNew || byEmail.UserId != this.Item.UserId))
                            checker.AddError(string.Format("The email address '{0}' is already assigned to another user.", email));
                        else
                        {
                            this.Item.ApiKey = this.CurrentUser;
                            this.Item.Username = username;
                            this.Item.Email = email;
                            this.Item.IsActive = true;

                            // password...
                            if (!(string.IsNullOrEmpty(password)))
                                this.Item.SetPassword(password, false);

                            // save...
                            bool wasNew = this.IsNew;
                            this.Item.SaveChanges();

                            // show...
                            if (wasNew)
                                this.Response.Redirect("~/viewuser.aspx?add=1&id=" + this.Item.UserId.ToString());
                            else
                                this.widgetFeedback.SetInfo("Your changes have been saved.");
                        }
                    }
                }
                else
                    checker.AddError("The passwords do not match.");
            }

            // show...
            if (checker.HasErrors)
                this.widgetFeedback.SetError(checker);
        }
    }
}
