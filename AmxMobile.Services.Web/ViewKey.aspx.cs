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

namespace AmxMobile.Services.Web
{
    [PageSecurity(true)]
    public partial class ViewKey : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                throw new InvalidOperationException("'CurrentUser' is null.");
            this.labelKey.Text = this.CurrentUser.Key.ToString();
        }
    }
}
