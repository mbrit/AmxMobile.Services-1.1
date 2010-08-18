using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using BootFX.Cms;

namespace AmxMobile.Services
{
    internal class CmsUserProvider : ICmsUserProvider
    {
        internal CmsUserProvider()
        {
        }

        public object GetCmsUserId(Page page)
        {
            return ServicesCmsUser.Id;
        }

        public string GetUserDisplayName(BootFX.Cms.CmsUser user)
        {
            return user.ToString();
        }
    
        public object  GetServiceUserId()
        {
            return GetCmsUserId(null);
        }
    }
}
