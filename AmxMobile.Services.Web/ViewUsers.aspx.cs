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
    public partial class ViewUsers : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gridUsers.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // sub...
            this.gridUsers.ColumnsNeeded += new EventHandler(gridUsers_ColumnsNeeded);
            this.gridUsers.DataSourceNeeded += new EventHandler(gridUsers_DataSourceNeeded);
        }

        void gridUsers_DataSourceNeeded(object sender, EventArgs e)
        {
            if (CurrentUser == null)
                throw new InvalidOperationException("'CurrentUser' is null.");
            this.gridUsers.DataSource = this.CurrentUser.GetUserItemItems();
        }

        void gridUsers_ColumnsNeeded(object sender, EventArgs e)
        {
            AutoColumnSpecification username = new AutoColumnSpecification("Username", null, Unit.Empty, AutoColumnFlags.Normal);
            username.LinkTemplate = "~/viewuser.aspx?id={0}";
            this.gridUsers.Columns.Add(username);
            this.gridUsers.Columns.Add(new AutoColumnSpecification("IsActive", "Is active", Unit.Empty, AutoColumnFlags.Normal));
        }
    }
}
