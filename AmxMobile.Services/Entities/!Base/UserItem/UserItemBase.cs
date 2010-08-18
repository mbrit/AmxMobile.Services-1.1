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
    
    
    /// <summary>
    /// Defines the base entity type for 'Users'.
    /// </summary>
    [Serializable()]
    [Index("Users_ApiEmail", "Users_ApiEmail", true, "ApiKeyId,Email")]
    [Index("Users_ApiKeyEmail", "Users_ApiKeyEmail", true, "ApiKeyId,Email")]
    [Index("Users_Username", "Users_Username", true, "Username,ApiKeyId")]
    public abstract class UserItemBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected UserItemBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected UserItemBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'UserId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'UserId' column.
        /// </remarks>
        [EntityField("UserId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
        [DBNullEquivalent(0)]
        public int UserId
        {
            get
            {
                return ((int)(this["UserId"]));
            }
            set
            {
                this["UserId"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'ApiKeyId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'ApiKeyId' column.
        /// </remarks>
        [EntityField("ApiKeyId", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
        [DBNullEquivalent(0)]
        public int ApiKeyId
        {
            get
            {
                return ((int)(this["ApiKeyId"]));
            }
            set
            {
                this["ApiKeyId"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Username'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Username' column.
        /// </remarks>
        [EntityField("Username", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 32)]
        public string Username
        {
            get
            {
                return ((string)(this["Username"]));
            }
            set
            {
                this["Username"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'PasswordSalt'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'PasswordSalt' column.
        /// </remarks>
        [EntityField("PasswordSalt", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public int PasswordSalt
        {
            get
            {
                return ((int)(this["PasswordSalt"]));
            }
            set
            {
                this["PasswordSalt"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'PasswordHash'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'PasswordHash' column.
        /// </remarks>
        [EntityField("PasswordHash", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
        public string PasswordHash
        {
            get
            {
                return ((string)(this["PasswordHash"]));
            }
            set
            {
                this["PasswordHash"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'IsActive'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'IsActive' column.
        /// </remarks>
        [EntityField("IsActive", System.Data.DbType.Boolean, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public bool IsActive
        {
            get
            {
                return ((bool)(this["IsActive"]));
            }
            set
            {
                this["IsActive"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Email'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Email' column.
        /// </remarks>
        [EntityField("Email", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string Email
        {
            get
            {
                return ((string)(this["Email"]));
            }
            set
            {
                this["Email"] = value;
            }
        }
        
        /// <summary>
        /// Gets the link to 'ApiKey'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FK_Users_ApiKeys' constraint.
        /// </remarks>
        [EntityLinkToParent("ApiKey", "FK_Users_ApiKeys", typeof(ApiKey), new string[] {
                "ApiKeyId"})]
        public ApiKey ApiKey
        {
            get
            {
                return ((ApiKey)(this.GetParent("ApiKey")));
            }
            set
            {
                this.SetParent("ApiKey", value);
            }
        }
        
        /// <summary>
        /// Gets the link to 'UserItem'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FK_Users_Users' constraint.
        /// </remarks>
        [EntityLinkToParent("User", "FK_Users_Users", typeof(UserItem), new string[] {
                "UserId"})]
        public UserItem User
        {
            get
            {
                return ((UserItem)(this.GetParent("User")));
            }
            set
            {
                this.SetParent("User", value);
            }
        }
        
        /// <summary>
        /// Creates an SqlFilter for an instance of 'UserItem'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(UserItem));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'UserItem'.
        /// </summary>
        public static void SetProperties(int userId, string[] propertyNames, object[] propertyValues)
        {
            UserItem entity = AmxMobile.Services.UserItem.GetById(userId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="UserItem"/> entities.
        /// </summary>
        public static UserItemCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(UserItem));
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="UserItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        public static UserItem GetById(int userId)
        {
            return AmxMobile.Services.UserItem.GetById(userId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="UserItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static UserItem GetById(int userId, BootFX.Common.Data.SqlOperator userIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("UserId", userIdOperator, userId);
            return ((UserItem)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="UserItem"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        public static UserItem GetById(int userId, BootFX.Common.OnNotFound onNotFound)
        {
            return AmxMobile.Services.UserItem.GetById(userId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="UserItem"/> entity where the ID matches the given specification.
        /// </summary>
        public static UserItem GetById(int userId, BootFX.Common.Data.SqlOperator userIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("UserId", userIdOperator, userId);
            UserItem results = ((UserItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where Username and ApiKeyId are equal to the given values.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>Users_Username</c>.
        /// </remarks>
        public static UserItem GetByUsernameAndApiKeyId(string username, int apiKeyId)
        {
            return AmxMobile.Services.UserItem.GetByUsernameAndApiKeyId(username, apiKeyId, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where Username and ApiKeyId are equal to the given values.
        /// </summary>
        /// <remarks>
        /// Created for index <c>Users_Username</c>.
        /// </remarks>
        public static UserItem GetByUsernameAndApiKeyId(string username, int apiKeyId, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("Username", BootFX.Common.Data.SqlOperator.EqualTo, username);
            filter.Constraints.Add("ApiKeyId", BootFX.Common.Data.SqlOperator.EqualTo, apiKeyId);
            UserItem results = ((UserItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where ApiKeyId and Email are equal to the given values.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>Users_ApiEmail</c>.
        /// </remarks>
        public static UserItem GetByApiKeyIdAndEmail(int apiKeyId, string email)
        {
            return AmxMobile.Services.UserItem.GetByApiKeyIdAndEmail(apiKeyId, email, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where ApiKeyId and Email are equal to the given values.
        /// </summary>
        /// <remarks>
        /// Created for index <c>Users_ApiEmail</c>.
        /// </remarks>
        public static UserItem GetByApiKeyIdAndEmail(int apiKeyId, string email, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("ApiKeyId", BootFX.Common.Data.SqlOperator.EqualTo, apiKeyId);
            filter.Constraints.Add("Email", BootFX.Common.Data.SqlOperator.EqualTo, email);
            UserItem results = ((UserItem)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where ApiKeyId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>ApiKeyId</c>
        /// </remarks>
        public static UserItemCollection GetByApiKeyId(int apiKeyId)
        {
            return AmxMobile.Services.UserItem.GetByApiKeyId(apiKeyId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where ApiKeyId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ApiKeyId</c>
        /// </remarks>
        public static UserItemCollection GetByApiKeyId(int apiKeyId, BootFX.Common.Data.SqlOperator apiKeyIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("ApiKeyId", apiKeyIdOperator, apiKeyId);
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where ApiKeyId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ApiKeyId</c>
        /// </remarks>
        public static UserItemCollection GetByApiKeyId(int apiKeyId, BootFX.Common.Data.SqlOperator apiKeyIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("ApiKeyId", apiKeyIdOperator, apiKeyId);
            UserItemCollection results = ((UserItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Username is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Username</c>
        /// </remarks>
        public static UserItemCollection GetByUsername(string username)
        {
            return AmxMobile.Services.UserItem.GetByUsername(username, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Username matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Username</c>
        /// </remarks>
        public static UserItemCollection GetByUsername(string username, BootFX.Common.Data.SqlOperator usernameOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("Username", usernameOperator, username);
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Username matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Username</c>
        /// </remarks>
        public static UserItemCollection GetByUsername(string username, BootFX.Common.Data.SqlOperator usernameOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("Username", usernameOperator, username);
            UserItemCollection results = ((UserItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where PasswordSalt is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>PasswordSalt</c>
        /// </remarks>
        public static UserItemCollection GetByPasswordSalt(int passwordSalt)
        {
            return AmxMobile.Services.UserItem.GetByPasswordSalt(passwordSalt, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where PasswordSalt matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordSalt</c>
        /// </remarks>
        public static UserItemCollection GetByPasswordSalt(int passwordSalt, BootFX.Common.Data.SqlOperator passwordSaltOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("PasswordSalt", passwordSaltOperator, passwordSalt);
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where PasswordSalt matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordSalt</c>
        /// </remarks>
        public static UserItemCollection GetByPasswordSalt(int passwordSalt, BootFX.Common.Data.SqlOperator passwordSaltOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("PasswordSalt", passwordSaltOperator, passwordSalt);
            UserItemCollection results = ((UserItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where PasswordHash is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>PasswordHash</c>
        /// </remarks>
        public static UserItemCollection GetByPasswordHash(string passwordHash)
        {
            return AmxMobile.Services.UserItem.GetByPasswordHash(passwordHash, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where PasswordHash matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordHash</c>
        /// </remarks>
        public static UserItemCollection GetByPasswordHash(string passwordHash, BootFX.Common.Data.SqlOperator passwordHashOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("PasswordHash", passwordHashOperator, passwordHash);
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where PasswordHash matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordHash</c>
        /// </remarks>
        public static UserItemCollection GetByPasswordHash(string passwordHash, BootFX.Common.Data.SqlOperator passwordHashOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("PasswordHash", passwordHashOperator, passwordHash);
            UserItemCollection results = ((UserItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where IsActive is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static UserItemCollection GetByIsActive(bool isActive)
        {
            return AmxMobile.Services.UserItem.GetByIsActive(isActive, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where IsActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static UserItemCollection GetByIsActive(bool isActive, BootFX.Common.Data.SqlOperator isActiveOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("IsActive", isActiveOperator, isActive);
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where IsActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static UserItemCollection GetByIsActive(bool isActive, BootFX.Common.Data.SqlOperator isActiveOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("IsActive", isActiveOperator, isActive);
            UserItemCollection results = ((UserItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Email is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - UserItem
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Email</c>
        /// </remarks>
        public static UserItemCollection GetByEmail(string email)
        {
            return AmxMobile.Services.UserItem.GetByEmail(email, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Email matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Email</c>
        /// </remarks>
        public static UserItemCollection GetByEmail(string email, BootFX.Common.Data.SqlOperator emailOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("Email", emailOperator, email);
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Email matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Email</c>
        /// </remarks>
        public static UserItemCollection GetByEmail(string email, BootFX.Common.Data.SqlOperator emailOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("Email", emailOperator, email);
            UserItemCollection results = ((UserItemCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Get all of the child 'Bookmark' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>User</c>.  (Stub method.)
        /// </remarks>
        public BookmarkCollection GetBookmarkItems()
        {
            // defer...
            return UserItem.GetBookmarkItems(this.UserId);
        }
        
        /// <summary>
        /// Get all of the child 'LogonToken' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>User</c>.  (Stub method.)
        /// </remarks>
        public LogonTokenCollection GetLogonTokenItems()
        {
            // defer...
            return UserItem.GetLogonTokenItems(this.UserId);
        }
        
        /// <summary>
        /// Get all of the child 'Bookmark' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>User</c>.  (Concrete method.)
        /// </remarks>
        public static BookmarkCollection GetBookmarkItems(int userId)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("UserId", BootFX.Common.Data.SqlOperator.EqualTo, userId);
            return ((BookmarkCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Get all of the child 'LogonToken' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>User</c>.  (Concrete method.)
        /// </remarks>
        public static LogonTokenCollection GetLogonTokenItems(int userId)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("UserId", BootFX.Common.Data.SqlOperator.EqualTo, userId);
            return ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Searches for <see cref="UserItem"/> items with the given terms.
        /// </summary>
        public static UserItemCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(UserItem), terms);
            return ((UserItemCollection)(searcher.ExecuteEntityCollection()));
        }
    }
}
