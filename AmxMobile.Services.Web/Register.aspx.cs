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
    public partial class Register : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {
                foreach (Country country in Country.GetAll())
                    this.listCountry.Items.Add(new ListItem(country.Name, country.CountryId.ToString()));
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // sub...
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
        }

        void buttonSave_Click(object sender, EventArgs e)
        {
            this.widgetFeedback.Reset();

            // get...
            FormChecker checker = new FormChecker();
            string username = checker.GetStringValue(new ControlReference(this.textUsername, "Username"), true);
            string password = checker.GetStringValue(new ControlReference(this.textPassword, "Password"), true);
            string confirm = checker.GetStringValue(new ControlReference(this.textConfirm, "Confirm"), true);
            string firstName = checker.GetStringValue(new ControlReference(this.textFirstName, "First name"), true);
            string lastName = checker.GetStringValue(new ControlReference(this.textLastName, "Last name"), true);
            string company = checker.GetStringValue(new ControlReference(this.textCompany, "Company"), true);
            string address1 = checker.GetStringValue(new ControlReference(this.textAddress1, "Address 1"), true);
            string address2 = checker.GetStringValue(new ControlReference(this.textAddress2, "Address 2"), false);
            string address3 = checker.GetStringValue(new ControlReference(this.textAddress3, "Address 3"), false);
            string city = checker.GetStringValue(new ControlReference(this.textCity, "City/town"), true);
            string region = checker.GetStringValue(new ControlReference(this.textRegion, "Region/county"), false);
            string postalCode = checker.GetStringValue(new ControlReference(this.textPostalCode, "Postal code/postcode"), true);
            Country country = (Country)checker.GetEntity(new ControlReference(this.listCountry, "Country"), typeof(Country), true);
            string email = checker.GetStringValue(new ControlReference(this.textEmail, "Email"), true);

            // not...
            if (!(checker.HasErrors))
            {
                // check...
                if (password == confirm)
                {
                    // find...
                    ApiKey existing = ApiKey.GetByUsername(username);
                    if (existing == null)
                    {
                        // check email...
                        ApiKey byUser = ApiKey.GetByEmail(email);
                        if(byUser == null)
                        {
                            // create...
                            ApiKey key = new ApiKey();
                            key.Username = username;
                            key.SetPassword(password, false);
                            key.FirstName = firstName;
                            key.LastName = lastName;
                            key.Company = company;
                            key.Address1 = address1;
                            key.Address2 = address2;
                            key.Address3 = address3;
                            key.City = city;
                            key.Region = region;
                            key.PostalCode = postalCode;
                            key.Country = country;
                            key.Email = email;
                            key.Subscribe = this.checkSubscribe.Checked;
                            key.IsActive = true;

                            // save...
                            key.SaveChanges();

                            // send...
                            EmailHelper.SendEmail(EmailKeys.NewRegistration, key);

                            // logon...
                            this.Logon(key, RememberUserFlags.DoNotRememberUsers, TimeSpan.MinValue);
                            
                            // redirect...
                            this.Response.Redirect("~/");
                        }
                        else
                            checker.AddError(string.Format("The email address '{0}' has already been used.", email));
                    }
                    else
                        checker.AddError(string.Format("The username '{0}' already exists.", username));
                }
                else
                    checker.AddError("Passwords do not match.");
            }

            // not...
            if (checker.HasErrors)
                this.widgetFeedback.SetError(checker);
        }
    }
}
