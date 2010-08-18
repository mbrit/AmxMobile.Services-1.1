using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmxMobile.Services.Web
{
    internal enum AuthenticateMode
    {
        /// <summary>
        /// We're running in an authentication mode before we have logged in the API account.
        /// </summary>
        PreApi = 0,

        /// <summary>
        /// We're running in regular mode where we have authenticated an API request.
        /// </summary>
        Normal = 1
    }
}
