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
    public partial class ViewContentItem : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.widgetViewContentItem.ContentItemIdAsString = this.Request.Params["id"];
        }
    }
}
