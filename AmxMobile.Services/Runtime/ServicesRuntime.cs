using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using BootFX.Cms;

namespace AmxMobile.Services
{
    public sealed class ServicesRuntime
    {
        private const string CompanyName = "AMX Mobile";
        private const string ProductName = "Six Bookmarks Services";

        private ServicesRuntime()
        {
        }

        public static Version ProductVersion
        {
            get
            {
                return typeof(ServicesRuntime).Assembly.GetName().Version;
            }
        }

        public static void Start(string module)
        {
            Runtime.Start(CompanyName, ProductName, module, ProductVersion);

            // cms...
            CmsRuntime.Start();
            CmsRuntime.Current.UserProvider = new CmsUserProvider();
        }

        public static void CheckReferenceData()
        {
            Country.CheckReferenceData();
            EmailHelper.CheckReferenceData();
        }
    }
}
