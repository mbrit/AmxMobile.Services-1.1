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
    /// Defines the base entity type for 'LogonTokens'.
    /// </summary>
    [Serializable()]
    [Index("LogonTokens_Token", "LogonTokens_Token", true, "Token")]
    public abstract class LogonTokenBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected LogonTokenBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected LogonTokenBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'LogonTokenId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'LogonTokenId' column.
        /// </remarks>
        [EntityField("LogonTokenId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
        public int LogonTokenId
        {
            get
            {
                return ((int)(this["LogonTokenId"]));
            }
            set
            {
                this["LogonTokenId"] = value;
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
        /// Gets or sets the value for 'ExpiresUtc'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'ExpiresUtc' column.
        /// </remarks>
        [EntityField("ExpiresUtc", System.Data.DbType.DateTime, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public System.DateTime ExpiresUtc
        {
            get
            {
                return ((System.DateTime)(this["ExpiresUtc"]));
            }
            set
            {
                this["ExpiresUtc"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'UserId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'UserId' column.
        /// </remarks>
        [EntityField("UserId", System.Data.DbType.Int32, (BootFX.Common.Entities.EntityFieldFlags.Nullable | BootFX.Common.Entities.EntityFieldFlags.Common))]
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
        /// Gets or sets the value for 'Token'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Token' column.
        /// </remarks>
        [EntityField("Token", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
        public string Token
        {
            get
            {
                return ((string)(this["Token"]));
            }
            set
            {
                this["Token"] = value;
            }
        }
        
        /// <summary>
        /// Gets the link to 'ApiKey'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FK_LogonTokens_ApiKeys' constraint.
        /// </remarks>
        [EntityLinkToParent("ApiKey", "FK_LogonTokens_ApiKeys", typeof(ApiKey), new string[] {
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
        /// This property maps to the 'FK_LogonTokens_Users' constraint.
        /// </remarks>
        [EntityLinkToParent("User", "FK_LogonTokens_Users", typeof(UserItem), new string[] {
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
        /// Creates an SqlFilter for an instance of 'LogonToken'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'LogonToken'.
        /// </summary>
        public static void SetProperties(int logonTokenId, string[] propertyNames, object[] propertyValues)
        {
            LogonToken entity = AmxMobile.Services.LogonToken.GetById(logonTokenId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="LogonToken"/> entities.
        /// </summary>
        public static LogonTokenCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(LogonToken));
            return ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="LogonToken"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - LogonToken
        /// </bootfx>
        public static LogonToken GetById(int logonTokenId)
        {
            return AmxMobile.Services.LogonToken.GetById(logonTokenId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="LogonToken"/> entity where the ID matches the given specification.
        /// </summary>
        public static LogonToken GetById(int logonTokenId, BootFX.Common.Data.SqlOperator logonTokenIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("LogonTokenId", logonTokenIdOperator, logonTokenId);
            return ((LogonToken)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="LogonToken"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - LogonToken
        /// </bootfx>
        public static LogonToken GetById(int logonTokenId, BootFX.Common.OnNotFound onNotFound)
        {
            return AmxMobile.Services.LogonToken.GetById(logonTokenId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="LogonToken"/> entity where the ID matches the given specification.
        /// </summary>
        public static LogonToken GetById(int logonTokenId, BootFX.Common.Data.SqlOperator logonTokenIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("LogonTokenId", logonTokenIdOperator, logonTokenId);
            LogonToken results = ((LogonToken)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where Token is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - LogonToken
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>LogonTokens_Token</c>.
        /// </remarks>
        public static LogonToken GetByToken(string token)
        {
            return AmxMobile.Services.LogonToken.GetByToken(token, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where Token is equal to the given value.
        /// </summary>
        /// <remarks>
        /// Created for index <c>LogonTokens_Token</c>.
        /// </remarks>
        public static LogonToken GetByToken(string token, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("Token", BootFX.Common.Data.SqlOperator.EqualTo, token);
            LogonToken results = ((LogonToken)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where ApiKeyId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - LogonToken
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>ApiKeyId</c>
        /// </remarks>
        public static LogonTokenCollection GetByApiKeyId(int apiKeyId)
        {
            return AmxMobile.Services.LogonToken.GetByApiKeyId(apiKeyId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where ApiKeyId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ApiKeyId</c>
        /// </remarks>
        public static LogonTokenCollection GetByApiKeyId(int apiKeyId, BootFX.Common.Data.SqlOperator apiKeyIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("ApiKeyId", apiKeyIdOperator, apiKeyId);
            return ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where ApiKeyId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ApiKeyId</c>
        /// </remarks>
        public static LogonTokenCollection GetByApiKeyId(int apiKeyId, BootFX.Common.Data.SqlOperator apiKeyIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("ApiKeyId", apiKeyIdOperator, apiKeyId);
            LogonTokenCollection results = ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where ExpiresUtc is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - LogonToken
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>ExpiresUtc</c>
        /// </remarks>
        public static LogonTokenCollection GetByExpiresUtc(System.DateTime expiresUtc)
        {
            return AmxMobile.Services.LogonToken.GetByExpiresUtc(expiresUtc, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where ExpiresUtc matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ExpiresUtc</c>
        /// </remarks>
        public static LogonTokenCollection GetByExpiresUtc(System.DateTime expiresUtc, BootFX.Common.Data.SqlOperator expiresUtcOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("ExpiresUtc", expiresUtcOperator, expiresUtc);
            return ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where ExpiresUtc matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>ExpiresUtc</c>
        /// </remarks>
        public static LogonTokenCollection GetByExpiresUtc(System.DateTime expiresUtc, BootFX.Common.Data.SqlOperator expiresUtcOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("ExpiresUtc", expiresUtcOperator, expiresUtc);
            LogonTokenCollection results = ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where UserId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - LogonToken
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>UserId</c>
        /// </remarks>
        public static LogonTokenCollection GetByUserId(int userId)
        {
            return AmxMobile.Services.LogonToken.GetByUserId(userId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where UserId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>UserId</c>
        /// </remarks>
        public static LogonTokenCollection GetByUserId(int userId, BootFX.Common.Data.SqlOperator userIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("UserId", userIdOperator, userId);
            return ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where UserId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>UserId</c>
        /// </remarks>
        public static LogonTokenCollection GetByUserId(int userId, BootFX.Common.Data.SqlOperator userIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("UserId", userIdOperator, userId);
            LogonTokenCollection results = ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Searches for <see cref="LogonToken"/> items with the given terms.
        /// </summary>
        public static LogonTokenCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(LogonToken), terms);
            return ((LogonTokenCollection)(searcher.ExecuteEntityCollection()));
        }
    }
}
