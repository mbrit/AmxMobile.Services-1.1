using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;

namespace AmxMobile.Services.Web
{
    public class ApiKeyValidator : UserNamePasswordValidator
    {
        public ApiKeyValidator()
        {
        }

        public override void Validate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
