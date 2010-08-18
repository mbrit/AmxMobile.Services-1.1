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
    /// Defines the base entity type for 'ApiKeys'.
    /// </summary>
    [Serializable()]
    [Index("ApiKeys_Email", "ApiKeys_Email", true, "Email")]
    [Index("ApiKeys_Username", "ApiKeys_Username", true, "Username")]
    public abstract class ApiKeyBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected ApiKeyBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected ApiKeyBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'ApiKeyId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'ApiKeyId' column.
        /// </remarks>
        [EntityField("ApiKeyId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
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
        [EntityField("Username", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
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
        /// Gets or sets the value for 'Subscribe'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Subscribe' column.
        /// </remarks>
        [EntityField("Subscribe", System.Data.DbType.Boolean, BootFX.Common.Entities.EntityFieldFlags.Common)]
        [DatabaseDefault(BootFX.Common.Data.Schema.SqlDatabaseDefaultType.Primitive, 0)]
        public bool Subscribe
        {
            get
            {
                return ((bool)(this["Subscribe"]));
            }
            set
            {
                this["Subscribe"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'FirstName'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FirstName' column.
        /// </remarks>
        [EntityField("FirstName", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
        public string FirstName
        {
            get
            {
                return ((string)(this["FirstName"]));
            }
            set
            {
                this["FirstName"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'LastName'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'LastName' column.
        /// </remarks>
        [EntityField("LastName", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
        public string LastName
        {
            get
            {
                return ((string)(this["LastName"]));
            }
            set
            {
                this["LastName"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Company'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Company' column.
        /// </remarks>
        [EntityField("Company", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string Company
        {
            get
            {
                return ((string)(this["Company"]));
            }
            set
            {
                this["Company"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Address1'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Address1' column.
        /// </remarks>
        [EntityField("Address1", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string Address1
        {
            get
            {
                return ((string)(this["Address1"]));
            }
            set
            {
                this["Address1"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Address2'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Address2' column.
        /// </remarks>
        [EntityField("Address2", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string Address2
        {
            get
            {
                return ((string)(this["Address2"]));
            }
            set
            {
                this["Address2"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Address3'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Address3' column.
        /// </remarks>
        [EntityField("Address3", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string Address3
        {
            get
            {
                return ((string)(this["Address3"]));
            }
            set
            {
                this["Address3"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'City'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'City' column.
        /// </remarks>
        [EntityField("City", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string City
        {
            get
            {
                return ((string)(this["City"]));
            }
            set
            {
                this["City"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Region'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Region' column.
        /// </remarks>
        [EntityField("Region", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string Region
        {
            get
            {
                return ((string)(this["Region"]));
            }
            set
            {
                this["Region"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'PostalCode'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'PostalCode' column.
        /// </remarks>
        [EntityField("PostalCode", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 48)]
        public string PostalCode
        {
            get
            {
                return ((string)(this["PostalCode"]));
            }
            set
            {
                this["PostalCode"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'CountryId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'CountryId' column.
        /// </remarks>
        [EntityField("CountryId", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
        [DBNullEquivalent(0)]
        public int CountryId
        {
            get
            {
                return ((int)(this["CountryId"]));
            }
            set
            {
                this["CountryId"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Email'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Email' column.
        /// </remarks>
        [EntityField("Email", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
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
        /// Gets the link to 'Country'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FK_ApiKeys_Countries' constraint.
        /// </remarks>
        [EntityLinkToParent("Country", "FK_ApiKeys_Countries", typeof(Country), new string[] {
                "CountryId"})]
        public Country Country
        {
            get
            {
                return ((Country)(this.GetParent("Country")));
            }
            set
            {
                this.SetParent("Country", value);
            }
        }
        
        /// <summary>
        /// Creates an SqlFilter for an instance of 'ApiKey'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'ApiKey'.
        /// </summary>
        public static void SetProperties(int apiKeyId, string[] propertyNames, object[] propertyValues)
        {
            ApiKey entity = AmxMobile.Services.ApiKey.GetById(apiKeyId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="ApiKey"/> entities.
        /// </summary>
        public static ApiKeyCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(ApiKey));
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="ApiKey"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        public static ApiKey GetById(int apiKeyId)
        {
            return AmxMobile.Services.ApiKey.GetById(apiKeyId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="ApiKey"/> entity where the ID matches the given specification.
        /// </summary>
        public static ApiKey GetById(int apiKeyId, BootFX.Common.Data.SqlOperator apiKeyIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("ApiKeyId", apiKeyIdOperator, apiKeyId);
            return ((ApiKey)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="ApiKey"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        public static ApiKey GetById(int apiKeyId, BootFX.Common.OnNotFound onNotFound)
        {
            return AmxMobile.Services.ApiKey.GetById(apiKeyId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="ApiKey"/> entity where the ID matches the given specification.
        /// </summary>
        public static ApiKey GetById(int apiKeyId, BootFX.Common.Data.SqlOperator apiKeyIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("ApiKeyId", apiKeyIdOperator, apiKeyId);
            ApiKey results = ((ApiKey)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where Username is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>ApiKeys_Username</c>.
        /// </remarks>
        public static ApiKey GetByUsername(string username)
        {
            return AmxMobile.Services.ApiKey.GetByUsername(username, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where Username is equal to the given value.
        /// </summary>
        /// <remarks>
        /// Created for index <c>ApiKeys_Username</c>.
        /// </remarks>
        public static ApiKey GetByUsername(string username, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Username", BootFX.Common.Data.SqlOperator.EqualTo, username);
            ApiKey results = ((ApiKey)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where Email is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>ApiKeys_Email</c>.
        /// </remarks>
        public static ApiKey GetByEmail(string email)
        {
            return AmxMobile.Services.ApiKey.GetByEmail(email, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where Email is equal to the given value.
        /// </summary>
        /// <remarks>
        /// Created for index <c>ApiKeys_Email</c>.
        /// </remarks>
        public static ApiKey GetByEmail(string email, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Email", BootFX.Common.Data.SqlOperator.EqualTo, email);
            ApiKey results = ((ApiKey)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where PasswordSalt is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>PasswordSalt</c>
        /// </remarks>
        public static ApiKeyCollection GetByPasswordSalt(int passwordSalt)
        {
            return AmxMobile.Services.ApiKey.GetByPasswordSalt(passwordSalt, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where PasswordSalt matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordSalt</c>
        /// </remarks>
        public static ApiKeyCollection GetByPasswordSalt(int passwordSalt, BootFX.Common.Data.SqlOperator passwordSaltOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("PasswordSalt", passwordSaltOperator, passwordSalt);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where PasswordSalt matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordSalt</c>
        /// </remarks>
        public static ApiKeyCollection GetByPasswordSalt(int passwordSalt, BootFX.Common.Data.SqlOperator passwordSaltOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("PasswordSalt", passwordSaltOperator, passwordSalt);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where PasswordHash is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>PasswordHash</c>
        /// </remarks>
        public static ApiKeyCollection GetByPasswordHash(string passwordHash)
        {
            return AmxMobile.Services.ApiKey.GetByPasswordHash(passwordHash, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where PasswordHash matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordHash</c>
        /// </remarks>
        public static ApiKeyCollection GetByPasswordHash(string passwordHash, BootFX.Common.Data.SqlOperator passwordHashOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("PasswordHash", passwordHashOperator, passwordHash);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where PasswordHash matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PasswordHash</c>
        /// </remarks>
        public static ApiKeyCollection GetByPasswordHash(string passwordHash, BootFX.Common.Data.SqlOperator passwordHashOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("PasswordHash", passwordHashOperator, passwordHash);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where IsActive is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static ApiKeyCollection GetByIsActive(bool isActive)
        {
            return AmxMobile.Services.ApiKey.GetByIsActive(isActive, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where IsActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static ApiKeyCollection GetByIsActive(bool isActive, BootFX.Common.Data.SqlOperator isActiveOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("IsActive", isActiveOperator, isActive);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where IsActive matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>IsActive</c>
        /// </remarks>
        public static ApiKeyCollection GetByIsActive(bool isActive, BootFX.Common.Data.SqlOperator isActiveOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("IsActive", isActiveOperator, isActive);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Subscribe is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Subscribe</c>
        /// </remarks>
        public static ApiKeyCollection GetBySubscribe(bool subscribe)
        {
            return AmxMobile.Services.ApiKey.GetBySubscribe(subscribe, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Subscribe matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Subscribe</c>
        /// </remarks>
        public static ApiKeyCollection GetBySubscribe(bool subscribe, BootFX.Common.Data.SqlOperator subscribeOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Subscribe", subscribeOperator, subscribe);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Subscribe matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Subscribe</c>
        /// </remarks>
        public static ApiKeyCollection GetBySubscribe(bool subscribe, BootFX.Common.Data.SqlOperator subscribeOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Subscribe", subscribeOperator, subscribe);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where FirstName is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>FirstName</c>
        /// </remarks>
        public static ApiKeyCollection GetByFirstName(string firstName)
        {
            return AmxMobile.Services.ApiKey.GetByFirstName(firstName, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where FirstName matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>FirstName</c>
        /// </remarks>
        public static ApiKeyCollection GetByFirstName(string firstName, BootFX.Common.Data.SqlOperator firstNameOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("FirstName", firstNameOperator, firstName);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where FirstName matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>FirstName</c>
        /// </remarks>
        public static ApiKeyCollection GetByFirstName(string firstName, BootFX.Common.Data.SqlOperator firstNameOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("FirstName", firstNameOperator, firstName);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where LastName is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>LastName</c>
        /// </remarks>
        public static ApiKeyCollection GetByLastName(string lastName)
        {
            return AmxMobile.Services.ApiKey.GetByLastName(lastName, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where LastName matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastName</c>
        /// </remarks>
        public static ApiKeyCollection GetByLastName(string lastName, BootFX.Common.Data.SqlOperator lastNameOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("LastName", lastNameOperator, lastName);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where LastName matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>LastName</c>
        /// </remarks>
        public static ApiKeyCollection GetByLastName(string lastName, BootFX.Common.Data.SqlOperator lastNameOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("LastName", lastNameOperator, lastName);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Company is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Company</c>
        /// </remarks>
        public static ApiKeyCollection GetByCompany(string company)
        {
            return AmxMobile.Services.ApiKey.GetByCompany(company, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Company matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Company</c>
        /// </remarks>
        public static ApiKeyCollection GetByCompany(string company, BootFX.Common.Data.SqlOperator companyOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Company", companyOperator, company);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Company matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Company</c>
        /// </remarks>
        public static ApiKeyCollection GetByCompany(string company, BootFX.Common.Data.SqlOperator companyOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Company", companyOperator, company);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Address1 is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Address1</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress1(string address1)
        {
            return AmxMobile.Services.ApiKey.GetByAddress1(address1, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Address1 matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Address1</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress1(string address1, BootFX.Common.Data.SqlOperator address1Operator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Address1", address1Operator, address1);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Address1 matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Address1</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress1(string address1, BootFX.Common.Data.SqlOperator address1Operator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Address1", address1Operator, address1);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Address2 is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Address2</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress2(string address2)
        {
            return AmxMobile.Services.ApiKey.GetByAddress2(address2, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Address2 matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Address2</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress2(string address2, BootFX.Common.Data.SqlOperator address2Operator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Address2", address2Operator, address2);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Address2 matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Address2</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress2(string address2, BootFX.Common.Data.SqlOperator address2Operator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Address2", address2Operator, address2);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Address3 is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Address3</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress3(string address3)
        {
            return AmxMobile.Services.ApiKey.GetByAddress3(address3, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Address3 matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Address3</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress3(string address3, BootFX.Common.Data.SqlOperator address3Operator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Address3", address3Operator, address3);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Address3 matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Address3</c>
        /// </remarks>
        public static ApiKeyCollection GetByAddress3(string address3, BootFX.Common.Data.SqlOperator address3Operator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Address3", address3Operator, address3);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where City is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>City</c>
        /// </remarks>
        public static ApiKeyCollection GetByCity(string city)
        {
            return AmxMobile.Services.ApiKey.GetByCity(city, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where City matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>City</c>
        /// </remarks>
        public static ApiKeyCollection GetByCity(string city, BootFX.Common.Data.SqlOperator cityOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("City", cityOperator, city);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where City matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>City</c>
        /// </remarks>
        public static ApiKeyCollection GetByCity(string city, BootFX.Common.Data.SqlOperator cityOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("City", cityOperator, city);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Region is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Region</c>
        /// </remarks>
        public static ApiKeyCollection GetByRegion(string region)
        {
            return AmxMobile.Services.ApiKey.GetByRegion(region, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Region matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Region</c>
        /// </remarks>
        public static ApiKeyCollection GetByRegion(string region, BootFX.Common.Data.SqlOperator regionOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Region", regionOperator, region);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Region matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Region</c>
        /// </remarks>
        public static ApiKeyCollection GetByRegion(string region, BootFX.Common.Data.SqlOperator regionOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("Region", regionOperator, region);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where PostalCode is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>PostalCode</c>
        /// </remarks>
        public static ApiKeyCollection GetByPostalCode(string postalCode)
        {
            return AmxMobile.Services.ApiKey.GetByPostalCode(postalCode, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where PostalCode matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PostalCode</c>
        /// </remarks>
        public static ApiKeyCollection GetByPostalCode(string postalCode, BootFX.Common.Data.SqlOperator postalCodeOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("PostalCode", postalCodeOperator, postalCode);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where PostalCode matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>PostalCode</c>
        /// </remarks>
        public static ApiKeyCollection GetByPostalCode(string postalCode, BootFX.Common.Data.SqlOperator postalCodeOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("PostalCode", postalCodeOperator, postalCode);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where CountryId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - ApiKey
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>CountryId</c>
        /// </remarks>
        public static ApiKeyCollection GetByCountryId(int countryId)
        {
            return AmxMobile.Services.ApiKey.GetByCountryId(countryId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where CountryId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>CountryId</c>
        /// </remarks>
        public static ApiKeyCollection GetByCountryId(int countryId, BootFX.Common.Data.SqlOperator countryIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("CountryId", countryIdOperator, countryId);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where CountryId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>CountryId</c>
        /// </remarks>
        public static ApiKeyCollection GetByCountryId(int countryId, BootFX.Common.Data.SqlOperator countryIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("CountryId", countryIdOperator, countryId);
            ApiKeyCollection results = ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Get all of the child 'LogonToken' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>ApiKey</c>.  (Stub method.)
        /// </remarks>
        public LogonTokenCollection GetLogonTokenItems()
        {
            // defer...
            return ApiKey.GetLogonTokenItems(this.ApiKeyId);
        }
        
        /// <summary>
        /// Get all of the child 'UserItem' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>ApiKey</c>.  (Stub method.)
        /// </remarks>
        public UserItemCollection GetUserItemItems()
        {
            // defer...
            return ApiKey.GetUserItemItems(this.ApiKeyId);
        }
        
        /// <summary>
        /// Get all of the child 'LogonToken' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>ApiKey</c>.  (Concrete method.)
        /// </remarks>
        public static LogonTokenCollection GetLogonTokenItems(int apiKeyId)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(LogonToken));
            filter.Constraints.Add("ApiKeyId", BootFX.Common.Data.SqlOperator.EqualTo, apiKeyId);
            return ((LogonTokenCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Get all of the child 'UserItem' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>ApiKey</c>.  (Concrete method.)
        /// </remarks>
        public static UserItemCollection GetUserItemItems(int apiKeyId)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(UserItem));
            filter.Constraints.Add("ApiKeyId", BootFX.Common.Data.SqlOperator.EqualTo, apiKeyId);
            return ((UserItemCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Searches for <see cref="ApiKey"/> items with the given terms.
        /// </summary>
        public static ApiKeyCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(ApiKey), terms);
            return ((ApiKeyCollection)(searcher.ExecuteEntityCollection()));
        }
    }
}
