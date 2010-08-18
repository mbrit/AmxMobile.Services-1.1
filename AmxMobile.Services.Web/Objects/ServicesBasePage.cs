using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Web;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using BootFX.Common.Authentication;

namespace AmxMobile.Services.Web
{
    public class ServicesBasePage : BasePage
    {
        public ServicesBasePage()
        {
            // setup...
            PageSecurityAttribute[] attrs = (PageSecurityAttribute[])this.GetType().GetCustomAttributes(typeof(PageSecurityAttribute), true);
            if (attrs == null)
                throw new InvalidOperationException("'attrs' is null.");
            if (attrs.Length == 0)
                throw new InvalidOperationException(string.Format("Page '{0}' does not have a security attribute.", this));

            // set...
            this.IsSecure = attrs[0].IsSecure;
        }

        protected override void OnLoadUser(IAppUserEventArgs e)
        {
            ApiKey key = ApiKey.GetById((int)e.Id[0]);
            if (key != null && key.IsActive)
                e.AppUser = key;
        }

        internal new ApiKey CurrentUser
        {
            get
            {
                return (ApiKey)base.CurrentUser;
            }
        }
    }
}
