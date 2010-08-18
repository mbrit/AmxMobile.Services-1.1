using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmxMobile.Services.Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(this.Page is ServicesBasePage))
                throw new NotSupportedException(string.Format("Cannot handle '{0}'.", this.Page));

            // set..
            if (this.Page.CurrentUser != null)
                this.panelNav.Visible = true;
            else
                this.panelNav.Visible = false;
            this.panelNoNav.Visible = !(this.panelNav.Visible);
        }

        private new ServicesBasePage Page
        {
            get
            {
                return (ServicesBasePage)base.Page;
            }
        }
    }
}
