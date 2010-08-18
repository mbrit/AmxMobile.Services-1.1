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
    /// Defines the base collection for entities of type <see cref="ApiKey"/>.
    /// </summary>
    [Serializable()]
    public abstract class ApiKeyCollectionBase : BootFX.Common.Entities.EntityCollection
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected ApiKeyCollectionBase() : 
                base(typeof(ApiKey))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected ApiKeyCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public ApiKey this[int index]
        {
            get
            {
                return ((ApiKey)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="ApiKey"/> instance to the collection.
        /// </summary>
        public int Add(ApiKey item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="ApiKey"/> instances to the collection.
        /// </summary>
        public void AddRange(ApiKey[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="ApiKey"/> instances to the collection.
        /// </summary>
        public void AddRange(ApiKeyCollection items)
        {
            base.AddRange(items);
        }
    }
}
