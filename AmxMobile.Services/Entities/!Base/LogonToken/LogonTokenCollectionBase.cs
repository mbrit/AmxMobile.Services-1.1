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
    /// Defines the base collection for entities of type <see cref="LogonToken"/>.
    /// </summary>
    [Serializable()]
    public abstract class LogonTokenCollectionBase : BootFX.Common.Entities.EntityCollection
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected LogonTokenCollectionBase() : 
                base(typeof(LogonToken))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected LogonTokenCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public LogonToken this[int index]
        {
            get
            {
                return ((LogonToken)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="LogonToken"/> instance to the collection.
        /// </summary>
        public int Add(LogonToken item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="LogonToken"/> instances to the collection.
        /// </summary>
        public void AddRange(LogonToken[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="LogonToken"/> instances to the collection.
        /// </summary>
        public void AddRange(LogonTokenCollection items)
        {
            base.AddRange(items);
        }
    }
}
