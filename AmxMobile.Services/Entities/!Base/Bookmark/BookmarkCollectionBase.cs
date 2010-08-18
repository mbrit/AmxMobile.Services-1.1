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
    /// Defines the base collection for entities of type <see cref="Bookmark"/>.
    /// </summary>
    [Serializable()]
    public abstract class BookmarkCollectionBase : BootFX.Common.Entities.EntityCollection
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected BookmarkCollectionBase() : 
                base(typeof(Bookmark))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected BookmarkCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public Bookmark this[int index]
        {
            get
            {
                return ((Bookmark)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="Bookmark"/> instance to the collection.
        /// </summary>
        public int Add(Bookmark item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="Bookmark"/> instances to the collection.
        /// </summary>
        public void AddRange(Bookmark[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="Bookmark"/> instances to the collection.
        /// </summary>
        public void AddRange(BookmarkCollection items)
        {
            base.AddRange(items);
        }
    }
}
