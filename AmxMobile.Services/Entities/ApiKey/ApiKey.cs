namespace AmxMobile.Services
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Collections;
    using System.Collections.Specialized;
    using BootFX.Common;
    using BootFX.Common.Data;
    using BootFX.Common.Entities;
    using BootFX.Common.Entities.Attributes;
    using BootFX.Common.BusinessServices;
    using BootFX.Common.Authentication;
    using BootFX.Common.Crypto;
    
    
    /// <summary>
    /// Defines the entity type for 'ApiKeys'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(ApiKeyCollection), "ApiKeys")]
    public class ApiKey : ApiKeyBase, IAppUser2
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public ApiKey()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected ApiKey(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }

        public object[] GetId()
        {
            return new object[] { this.ApiKeyId };
        }

        [EntityProperty()]
        public string FullName
        {
            get
            {
                return string.Concat(this.FirstName, " ", this.LastName);
            }
        }

        public string ResetPassword()
        {
            string newPassword = Runtime.Current.SuggestUserPassword();
            if (newPassword == null)
                throw new InvalidOperationException("'newPassword' is null.");
            if (newPassword.Length == 0)
                throw new InvalidOperationException("'newPassword' is zero-length.");

            // set...
            this.PasswordSalt = EncryptionHelper.GetRandomSalt();
            this.PasswordHash = EncryptionHelper.HashPasswordToBase64String(newPassword, this.PasswordSalt);
            this.SaveChanges();

            // return...
            return newPassword;
        }

        public void SetPassword(string password, bool saveChanges)
        {
            this.PasswordSalt = EncryptionHelper.GetRandomSalt();
            this.PasswordHash = EncryptionHelper.HashPasswordToBase64String(password, this.PasswordSalt);

            // save...
            if (saveChanges)
                this.SaveChanges();
        }
    }
}
