using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmxMobile.Services.Web
{
    public enum LogonResult
    {
        LogonOk = 0,
        InvalidUsername = 1,
        InvalidPassword = 2,
        AccountDisabled = 3
    }
}
