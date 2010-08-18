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
    [PageSecurity(false)]
    public partial class Logoff : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Logoff();
            this.Response.Redirect("~/");
        }
    }
}
