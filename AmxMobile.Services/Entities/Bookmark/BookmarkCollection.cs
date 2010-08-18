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
    /// Defines the collection for entities of type <see cref="Bookmark"/>.
    /// </summary>
    [Serializable()]
    public class BookmarkCollection : BookmarkCollectionBase
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public BookmarkCollection()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected BookmarkCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }

        public Bookmark GetByOrdinal(int ordinal)
        {
            foreach(Bookmark bookmark in this.InnerList)
            {
                if (bookmark.Ordinal == ordinal)
                    return bookmark;
            }

            // nope...
            return null;
        }

        public void SortByOrdinal()
        {
            this.Sort(new OrdinalComparer());
        }

        private class OrdinalComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Bookmark a = (Bookmark)x;
                Bookmark b = (Bookmark)y;
                
                // return...
                if (a.Ordinal < b.Ordinal)
                    return -1;
                else if (a.Ordinal > b.Ordinal)
                    return 1;
                else
                    return 0;
            }
        }
    }
}
