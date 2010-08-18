using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AmxMobile.Services.WebAdmin
{
    public partial class ViewContentItemVersion : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.widgetViewContentItemVersion.ContentItemVersionIdAsString = this.Request.Params["id"];
        }
    }
}
