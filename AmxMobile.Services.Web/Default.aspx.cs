using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmxMobile.Services.Web
{
    [PageSecurity(false)]
    public partial class _Default : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CurrentUser != null)
                this.panelOptions.Visible = true;
            else
                this.panelOptions.Visible = false;
            this.panelAccounts.Visible = !(this.panelOptions.Visible);
        }
    }
}
