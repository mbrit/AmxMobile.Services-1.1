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
    using BootFX.Common.Crypto;
    
    
    /// <summary>
    /// Defines the entity type for 'Users'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(UserItemCollection), "Users")]
    public class UserItem : UserItemBase
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public UserItem()
        {
        }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected UserItem(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
            base(info, context)
        {
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
