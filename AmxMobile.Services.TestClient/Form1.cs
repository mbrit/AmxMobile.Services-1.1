using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Desktop;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace AmxMobile.Services.TestClient
{
    public partial class Form1 : Form
    {
        private const string ApiUsernameKey = "apiusername";

        public Form1()
        {
            InitializeComponent();
        }

        private void linkApi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetApiLogonUrl();
        }

        private void SetApiLogonUrl()
        {
            SetUrl("apirest.aspx?operation=logon&password=APIPASSWORD");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetUrl("apirest.aspx?operation=logoff");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetUrl("usersrest.aspx?operation=logon&username=USERNAME&password=PASSWORD");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetUrl("bookmarks.svc/");
        }

        private void SetUrl(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (url.Length == 0)
                throw new ArgumentException("'url' is zero-length.");

            try
            {
                // if...
                string prefix = null;
                string baseUrl = this.Url;
                const string defaultPrefix = "http://services.multimobiledevelopment.com/services/";
                if (string.IsNullOrEmpty(url))
                    prefix = defaultPrefix;
                else
                {
                    // get...
                    int index = baseUrl.IndexOf("?");
                    if (index != -1)
                        baseUrl = baseUrl.Substring(0, index);
                    index = baseUrl.LastIndexOf("/");
                    if (index != -1)
                        prefix = baseUrl.Substring(0, index);
                    else
                        prefix = defaultPrefix;
                }

                // set...
                this.textUrl.Text = HttpHelper.CombineUrlParts(prefix, url);
            }
            catch (Exception ex)
            {
                Alert.ShowWarning(this, "An error occurred", ex);
            }
        }

        private string Url
        {
            get
            {
                return this.textUrl.Text.Trim();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            try
            {
                // set...
                this.SetApiLogonUrl();
            }
            catch (Exception ex)
            {
                Alert.ShowWarning(this, "An error occurred.", ex);
            }
        }

        private void buttonSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                string url = this.Url;
                if (string.IsNullOrEmpty(url))
                {
                    Alert.ShowWarning(this, "You must enter a URL.");
                    return;
                }

                // check...
                string lower = url.ToLower();
                if (!(lower.StartsWith("http://")) && !(lower.StartsWith("https://")))
                {
                    url = "http://" + url;
                    this.textUrl.Text = url;
                }

                // set...
                HttpDownloadSettings settings = new HttpDownloadSettings();
                settings.ExtraHeaders.Add("x-amx-apiusername", this.textApiUsername.Text.Trim());
                settings.ExtraHeaders.Add("x-amx-token", this.textToken.Text.Trim());
                XmlDocument doc = HttpHelper.DownloadToXmlDocument(url, settings);
                if (doc == null)
                    throw new InvalidOperationException("'doc' is null.");

                // show...
                this.ShowXml(doc);
            }
            catch (HttpDownloadException ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(ex.InnerWebException);
                builder.Append("\r\n-----------------------------\r\n");
                try
                {
                    string error = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    builder.Append(error);
                }
                catch
                {
                    builder.Append("(An error occurred whilst downloading error information)");
                }
                builder.Append("\r\n-----------------------------\r\n");
                builder.Append(ex);

                // show...
                this.ShowText(builder.ToString());
            }
            catch (Exception ex)
            {
                this.ShowText(ex.ToString());
            }
        }

        private void ShowXml(XmlDocument doc)
        {
            string temp = Runtime.Current.GetTempXmlFilePath();
            doc.Save(temp);

            // browse...
            this.browser.Navigate("file:" + temp);
        }

        private void ShowText(string buf)
        {
            string temp = Runtime.Current.GetTempTextFilePath();
            using (StreamWriter writer = new StreamWriter(temp))
                writer.Write(buf);

            // browse...
            this.browser.Navigate("file:" + temp);
        }
    }
}
