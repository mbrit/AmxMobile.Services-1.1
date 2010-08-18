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
    [PageSecurity(false)]
    public partial class Error : ServicesBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Runtime.IsStarted)
                this.SmartErrorHandling = SmartErrorHandlingType.AlwaysOff;
        }
    }
}
