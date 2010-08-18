namespace AmxMobile.Services
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Security.Cryptography;
    using System.Collections;
    using System.Collections.Specialized;
    using BootFX.Common;
    using BootFX.Common.Data;
    using BootFX.Common.Entities;
    using BootFX.Common.Entities.Attributes;
    using BootFX.Common.BusinessServices;
    
    
    /// <summary>
    /// Defines the entity type for 'LogonTokens'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(LogonTokenCollection), "LogonTokens")]
    public class LogonToken : LogonTokenBase
    {
        private const string ResultKey = "Result";
        private const string MessageKey = "Message";
        private const string TokenKey = "Token";
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public LogonToken()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected LogonToken(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }

        public void UpdateExpiry(bool saveChanges)
        {
            this.ExpiresUtc = DateTime.UtcNow.AddMinutes(30);
            
            // save?
            if (saveChanges)
                this.SaveChanges();
        }

        public void GenerateToken()
        {
            // get a random number...
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] bs = new byte[16];
            crypto.GetBytes(bs);

            // build...
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bs)
                builder.Append(b.ToString("x2"));

            // set...
            this.Token = builder.ToString();
        }
    }
}
