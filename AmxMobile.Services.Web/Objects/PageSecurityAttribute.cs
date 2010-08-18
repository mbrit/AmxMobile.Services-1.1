using System;
using System.Data;
using System.Configuration;
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
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PageSecurityAttribute : Attribute
    {
        internal bool IsSecure { get; private set; }

        public PageSecurityAttribute(bool isSecure)
        {
            this.IsSecure = isSecure;
        }
    }
}
