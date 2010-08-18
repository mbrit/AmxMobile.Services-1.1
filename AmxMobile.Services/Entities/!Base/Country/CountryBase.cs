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
    /// Defines the base entity type for 'Countries'.
    /// </summary>
    [Serializable()]
    [Index("Countries_Name", "Countries_Name", true, "Name")]
    public abstract class CountryBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected CountryBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected CountryBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'CountryId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'CountryId' column.
        /// </remarks>
        [EntityField("CountryId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
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
        /// Gets or sets the value for 'Name'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Name' column.
        /// </remarks>
        [EntityField("Name", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 64)]
        public string Name
        {
            get
            {
                return ((string)(this["Name"]));
            }
            set
            {
                this["Name"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'Ordinal'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Ordinal' column.
        /// </remarks>
        [EntityField("Ordinal", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
        public int Ordinal
        {
            get
            {
                return ((int)(this["Ordinal"]));
            }
            set
            {
                this["Ordinal"] = value;
            }
        }
        
        /// <summary>
        /// Creates an SqlFilter for an instance of 'Country'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(Country));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'Country'.
        /// </summary>
        public static void SetProperties(int countryId, string[] propertyNames, object[] propertyValues)
        {
            Country entity = AmxMobile.Services.Country.GetById(countryId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="Country"/> entities.
        /// </summary>
        public static CountryCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(Country));
            return ((CountryCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="Country"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Country
        /// </bootfx>
        public static Country GetById(int countryId)
        {
            return AmxMobile.Services.Country.GetById(countryId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="Country"/> entity where the ID matches the given specification.
        /// </summary>
        public static Country GetById(int countryId, BootFX.Common.Data.SqlOperator countryIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Country));
            filter.Constraints.Add("CountryId", countryIdOperator, countryId);
            return ((Country)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="Country"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Country
        /// </bootfx>
        public static Country GetById(int countryId, BootFX.Common.OnNotFound onNotFound)
        {
            return AmxMobile.Services.Country.GetById(countryId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="Country"/> entity where the ID matches the given specification.
        /// </summary>
        public static Country GetById(int countryId, BootFX.Common.Data.SqlOperator countryIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Country));
            filter.Constraints.Add("CountryId", countryIdOperator, countryId);
            Country results = ((Country)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets an entity where Name is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Country
        /// </bootfx>
        /// <remarks>
        /// Created for index <c>Countries_Name</c>.
        /// </remarks>
        public static Country GetByName(string name)
        {
            return AmxMobile.Services.Country.GetByName(name, BootFX.Common.OnNotFound.ReturnNull);
        }
        
        /// <summary>
        /// Gets an entity where Name is equal to the given value.
        /// </summary>
        /// <remarks>
        /// Created for index <c>Countries_Name</c>.
        /// </remarks>
        public static Country GetByName(string name, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Country));
            filter.Constraints.Add("Name", BootFX.Common.Data.SqlOperator.EqualTo, name);
            Country results = ((Country)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Ordinal is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Country
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Ordinal</c>
        /// </remarks>
        public static CountryCollection GetByOrdinal(int ordinal)
        {
            return AmxMobile.Services.Country.GetByOrdinal(ordinal, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Ordinal matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Ordinal</c>
        /// </remarks>
        public static CountryCollection GetByOrdinal(int ordinal, BootFX.Common.Data.SqlOperator ordinalOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Country));
            filter.Constraints.Add("Ordinal", ordinalOperator, ordinal);
            return ((CountryCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Ordinal matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Ordinal</c>
        /// </remarks>
        public static CountryCollection GetByOrdinal(int ordinal, BootFX.Common.Data.SqlOperator ordinalOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Country));
            filter.Constraints.Add("Ordinal", ordinalOperator, ordinal);
            CountryCollection results = ((CountryCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Get all of the child 'ApiKey' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>Country</c>.  (Stub method.)
        /// </remarks>
        public ApiKeyCollection GetApiKeyItems()
        {
            // defer...
            return Country.GetApiKeyItems(this.CountryId);
        }
        
        /// <summary>
        /// Get all of the child 'ApiKey' entities.
        /// </summary>
        /// <remarks>
        /// Created for link <c>Country</c>.  (Concrete method.)
        /// </remarks>
        public static ApiKeyCollection GetApiKeyItems(int countryId)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(ApiKey));
            filter.Constraints.Add("CountryId", BootFX.Common.Data.SqlOperator.EqualTo, countryId);
            return ((ApiKeyCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Searches for <see cref="Country"/> items with the given terms.
        /// </summary>
        public static CountryCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(Country), terms);
            return ((CountryCollection)(searcher.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Returns the value in the 'Name' property.
        /// </summary>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
