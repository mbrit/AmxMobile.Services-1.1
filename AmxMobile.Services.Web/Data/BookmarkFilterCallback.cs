using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Data.Services;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace AmxMobile.Services.Web
{
    public class BookmarkFilterCallback : HttpContextAwareBase, ISqlFilterCallback
    {
        public BookmarkFilterCallback()
        {
        }

        public void PreExecute(SqlFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");

            // get...
            UserItem user = ServiceAuthenticator.Current.GetUser();
            if (user == null)
                throw new InvalidOperationException("'user' is null.");

            // mangle the query...
            filter.Constraints.Add("userid", user.UserId);
        }
    }
}
