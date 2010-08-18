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
    /// Defines the base collection for entities of type <see cref="UserItem"/>.
    /// </summary>
    [Serializable()]
    public abstract class UserItemCollectionBase : BootFX.Common.Entities.EntityCollection
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected UserItemCollectionBase() : 
                base(typeof(UserItem))
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected UserItemCollectionBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the item with the given index.
        /// </summary>
        public UserItem this[int index]
        {
            get
            {
                return ((UserItem)(this.GetItem(index)));
            }
            set
            {
                this.SetItem(index, value);
            }
        }
        
        /// <summary>
        /// Adds a <see cref="UserItem"/> instance to the collection.
        /// </summary>
        public int Add(UserItem item)
        {
            return base.Add(item);
        }
        
        /// <summary>
        /// Adds a range of <see cref="UserItem"/> instances to the collection.
        /// </summary>
        public void AddRange(UserItem[] items)
        {
            base.AddRange(items);
        }
        
        /// <summary>
        /// Adds a range of <see cref="UserItem"/> instances to the collection.
        /// </summary>
        public void AddRange(UserItemCollection items)
        {
            base.AddRange(items);
        }
    }
}
