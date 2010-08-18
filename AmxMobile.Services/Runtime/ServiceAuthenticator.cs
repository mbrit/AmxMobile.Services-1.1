using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using BootFX.Common.Crypto;

namespace AmxMobile.Services
{
    public class ServiceAuthenticator : HttpContextAwareBase
    {
        internal const string ApiUsernameKey = "ApiUsername";
        internal const string ApiTokenKey = "ApiToken";

        /// <summary>
		/// Private field to hold singleton instance.
		/// </summary>
		private static ServiceAuthenticator _current = new ServiceAuthenticator();
				
		/// <summary>
		/// Private constructor.
		/// </summary>
		private ServiceAuthenticator()
		{
		}
						
		/// <summary>
		/// Gets the singleton instance of <see cref="ServiceAuthenticator">ServiceAuthenticator</see>.
		/// </summary>
        public static ServiceAuthenticator Current
		{
			get
			{
				if(_current == null)
					throw new ObjectDisposedException("ServiceAuthenticator");
				return _current;
			}
		}

        public string ApiUsername
        {
            get
            {
                string username = (string)this.Items[ApiUsernameKey];
                if (string.IsNullOrEmpty(username))
                {
                    // look in the headers
                    username = this.Request.Headers["x-amx-apiusername"];
                }

                // return...
                return username;
            }
            set
            {
                this.Items[ApiUsernameKey] = value;
            }
        }

        public string ApiToken
        {
            get
            {
                string token = (string)this.Items[ApiTokenKey];
                if (string.IsNullOrEmpty(token))
                {
                    // look in the headers...
                    token = this.Request.Headers["x-amx-token"];
                }

                // return...
                return token;
            }
            set
            {
                this.Items[ApiTokenKey] = value;
            }
        }

        /// <summary>
        /// Gets the API.
        /// </summary>
        /// <remarks>If we have a token of the form 'a-{username}', i.e. we're trying to log on the API, this returns the API
        /// with the given name.  If we have a token of the form 't-{username}', we'll validate the logon token that was created
        /// in the database.  In either case, we'll throw an exception if the account is inactive.</remarks>
        /// <returns></returns>
        public ApiKey GetApi(ref LogonToken token)
        {
            // reset...
            token = null;
            
            // do we have a full token?
            ApiKey api = null;
            string tokenString = this.ApiToken;
            if (!(string.IsNullOrEmpty(tokenString)))
            {
                token = LogonToken.GetByToken(tokenString);
                if (token == null)
                    throw new InvalidOperationException(string.Format("The token '{0}' is invalid.", tokenString));

                // update...
                token.UpdateExpiry(true);

                // set...
                api = token.ApiKey;
                if (api == null)
                    throw new InvalidOperationException("'api' is null.");
            }
            else
            {
                string username = this.ApiUsername;
                if (!(string.IsNullOrEmpty(username)))
                {
                    api = ApiKey.GetByUsername(username);
                    if(api == null)
                        throw new InvalidOperationException(string.Format("An API with username '{0}' was not found.", username));
                }
                else
                    throw new InvalidOperationException("Neither a logon token nor API key were provided in the request.  Ensure a token was provided in the URL.");
            }

            // check...
            if(!(api.IsActive))
                throw new InvalidOperationException(string.Format("The API account '{0}' is inactive.", api.Username));

            // return...
            return api;
        }

        /// <summary>
        /// Gets the user that the request relates to.
        /// </summary>
        /// <returns></returns>
        public UserItem GetUser()
        {
            // we need a full token to do this...
            string tokenString = this.ApiToken;
            if(string.IsNullOrEmpty(tokenString))
                throw new InvalidOperationException("A token was not provided.");

            // get...
            LogonToken token = LogonToken.GetByToken(tokenString);
            if (token == null)
                throw new InvalidOperationException(string.Format("The token '{0}' is invalid.", tokenString));

            // do we have a user?
            if(token.User == null)
                throw new InvalidOperationException(string.Format("The token '{0}' is not associated with a user. Call the Logon operation on the Users REST service before making this call.", token.Token));

            // active?
            if(!(token.User.IsActive))
                throw new InvalidOperationException(string.Format("The user '{0}' is not active.", token.User.Username));

            // return...
            return token.User;
        }
    }
}
