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
    /// Defines the base collection for entities of type <see cref="Country"/>.
    /// </summary>
    [Serializable()]
    public abstract class CountryCollectionBase : BootFX.Common.Entities.EntityCollection
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected CountryCollectionBase() : 
                base(typeof(Country))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected CountryCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public Country this[int index]
        {
            get
            {
                return ((Country)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="Country"/> instance to the collection.
        /// </summary>
        public int Add(Country item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="Country"/> instances to the collection.
        /// </summary>
        public void AddRange(Country[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="Country"/> instances to the collection.
        /// </summary>
        public void AddRange(CountryCollection items)
        {
            base.AddRange(items);
        }
    }
}
