using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmxMobile.Services.Web
{
    /// <summary>
    /// Defines an exception message.
    /// </summary>
    [Serializable()]
    public class ApiAuthenticationException : ApplicationException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        internal ApiAuthenticationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ApiAuthenticationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary> 
        /// Deserialization constructor.
        /// </summary> 
        protected ApiAuthenticationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary> 
        /// Provides data to serialization.
        /// </summary> 
        [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            // base...
            base.GetObjectData(info, context);

            // store other items in the serialization bucket...
        }
    }

}
