using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Web;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace AmxMobile.Services.Web
{
    public class PageEngine : UrlRewriter
    {
        internal const string ApiUsername = "apiusername";
        internal const string ApiToken = "apitoken";

        /// <summary>
        /// Private value to support the <see cref="Regex">Regex</see> property.
        /// </summary>
        private Regex _regex = new Regex(@"(?<preamble>services/)(?<tokenType>[at]{1})-(?<token>\w+)/(?<path>.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public PageEngine()
        {
        }

        protected override bool ShouldRewriteUrl(UrlRewritingState state)
        {
            Match match = Regex.Match(state.UrlWithoutQuery);
            return match.Success;
        }

        protected override string GetRewrittenUrl(HttpApplication app, UrlRewritingState state)
        {
            // get it...
            Match match = Regex.Match(state.UrlWithoutQuery);
            if (!(match.Success))
                throw new InvalidOperationException(string.Format("The value '{0}' is invalid.", state.UrlWithoutQuery));
            
            // what sort of token do we have?
            string tokenType = match.Groups["tokenType"].Value.ToLower();
            if (tokenType == "a")
                ServiceAuthenticator.Current.ApiUsername = match.Groups["token"].Value;
            else if (tokenType == "t")
                ServiceAuthenticator.Current.ApiToken = match.Groups["token"].Value;

            // rewrite...
            string url = HttpHelper.CombineUrlParts("~/", match.Groups["preamble"].Value);
            url = HttpHelper.CombineUrlParts(url, match.Groups["path"].Value);

            // query?
            if (!(string.IsNullOrEmpty(state.QueryString)))
                url = url + "?" + state.QueryString;

            // return...
            return url;
        }

        /// <summary>
        /// Gets the Regex value.
        /// </summary>
        private Regex Regex
        {
            get
            {
                return _regex;
            }
        }
    }
}
