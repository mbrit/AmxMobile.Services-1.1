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
    using BootFX.Common.Data.Text;
    using BootFX.Common.Entities;
    using BootFX.Common.Entities.Attributes;
    using BootFX.Common.BusinessServices;
    
    
    /// <summary>
    /// Defines the entity type for 'Countries'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(CountryCollection), "Countries")]
    [SortSpecification(new string[] {
            "Ordinal", "Name"}, new BootFX.Common.Data.SortDirection[] {
            BootFX.Common.Data.SortDirection.Ascending, BootFX.Common.Data.SortDirection.Ascending})]
    public class Country : CountryBase
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public Country()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected Country(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }

        internal static void CheckReferenceData()
        {
            // csv...
            string data = ResourceHelper.GetString("AmxMobile.Services.Resources.Countries.csv");
            using (StringReader reader = new StringReader(data))
            {
                CsvDataReader csv = new CsvDataReader(reader, true);

                // txn...
                using (TransactionState txn = Database.StartTransaction())
                {
                    try
                    {
                        while (csv.Read())
                        {
                            // get...
                            string name = csv.GetString("Common Name");
                            if (name == null)
                                throw new InvalidOperationException("'name' is null.");
                            if (name.Length == 0)
                                throw new InvalidOperationException("'name' is zero-length.");

                            // get...
                            Country country = Country.GetByName(name);
                            if (country == null)
                            {
                                country = new Country();
                                country.Name = name;
                                if (string.Compare(name, "United Kingdom", true, Cultures.System) == 0)
                                    country.Ordinal = 1000;
                                if (string.Compare(name, "United States", true, Cultures.System) == 0)
                                    country.Ordinal = 1001;
                                else
                                    country.Ordinal = 9999;

                                // save...
                                country.SaveChanges();
                            }
                        }

                        // ok...
                        txn.Commit();
                    }
                    catch (Exception ex)
                    {
                        txn.Rollback(ex);
                        throw new InvalidOperationException("The operation failed", ex);
                    }
                }

            }
        }
    }
}
