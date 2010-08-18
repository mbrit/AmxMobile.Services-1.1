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
    /// Defines the base entity type for 'Bookmarks'.
    /// </summary>
    [Serializable()]
    public abstract class BookmarkBase : BootFX.Common.Entities.Entity
    {
        
        /// <summary>
        /// Constructor.
        /// </summary>
        protected BookmarkBase()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected BookmarkBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }
        
        /// <summary>
        /// Gets or sets the value for 'BookmarkId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'BookmarkId' column.
        /// </remarks>
        [EntityField("BookmarkId", System.Data.DbType.Int32, ((BootFX.Common.Entities.EntityFieldFlags.Key | BootFX.Common.Entities.EntityFieldFlags.Common) 
                    | BootFX.Common.Entities.EntityFieldFlags.AutoIncrement))]
        public int BookmarkId
        {
            get
            {
                return ((int)(this["BookmarkId"]));
            }
            set
            {
                this["BookmarkId"] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the value for 'UserId'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'UserId' column.
        /// </remarks>
        [EntityField("UserId", System.Data.DbType.Int32, BootFX.Common.Entities.EntityFieldFlags.Common)]
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
        /// Gets or sets the value for 'Url'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'Url' column.
        /// </remarks>
        [EntityField("Url", System.Data.DbType.String, BootFX.Common.Entities.EntityFieldFlags.Common, 256)]
        public string Url
        {
            get
            {
                return ((string)(this["Url"]));
            }
            set
            {
                this["Url"] = value;
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
        /// Gets the link to 'UserItem'.
        /// </summary>
        /// <remarks>
        /// This property maps to the 'FK_Bookmarks_Users' constraint.
        /// </remarks>
        [EntityLinkToParent("User", "FK_Bookmarks_Users", typeof(UserItem), new string[] {
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
        /// Creates an SqlFilter for an instance of 'Bookmark'.
        /// </summary>
        public static BootFX.Common.Data.SqlFilter CreateFilter()
        {
            return new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
        }
        
        /// <summary>
        /// Sets properties on an instance of 'Bookmark'.
        /// </summary>
        public static void SetProperties(int bookmarkId, string[] propertyNames, object[] propertyValues)
        {
            Bookmark entity = AmxMobile.Services.Bookmark.GetById(bookmarkId);
            entity.SetProperties(entity, propertyNames, propertyValues);
            entity.SaveChanges();
        }
        
        /// <summary>
        /// Get all <see cref="Bookmark"/> entities.
        /// </summary>
        public static BookmarkCollection GetAll()
        {
            BootFX.Common.Data.SqlFilter filter = BootFX.Common.Data.SqlFilter.CreateGetAllFilter(typeof(Bookmark));
            return ((BookmarkCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets the <see cref="Bookmark"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Bookmark
        /// </bootfx>
        public static Bookmark GetById(int bookmarkId)
        {
            return AmxMobile.Services.Bookmark.GetById(bookmarkId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets the <see cref="Bookmark"/> entity where the ID matches the given specification.
        /// </summary>
        public static Bookmark GetById(int bookmarkId, BootFX.Common.Data.SqlOperator bookmarkIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("BookmarkId", bookmarkIdOperator, bookmarkId);
            return ((Bookmark)(filter.ExecuteEntity()));
        }
        
        /// <summary>
        /// Gets the <see cref="Bookmark"/> entity with the given ID.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Bookmark
        /// </bootfx>
        public static Bookmark GetById(int bookmarkId, BootFX.Common.OnNotFound onNotFound)
        {
            return AmxMobile.Services.Bookmark.GetById(bookmarkId, BootFX.Common.Data.SqlOperator.EqualTo, onNotFound);
        }
        
        /// <summary>
        /// Gets the <see cref="Bookmark"/> entity where the ID matches the given specification.
        /// </summary>
        public static Bookmark GetById(int bookmarkId, BootFX.Common.Data.SqlOperator bookmarkIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("BookmarkId", bookmarkIdOperator, bookmarkId);
            Bookmark results = ((Bookmark)(filter.ExecuteEntity()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where UserId is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Bookmark
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>UserId</c>
        /// </remarks>
        public static BookmarkCollection GetByUserId(int userId)
        {
            return AmxMobile.Services.Bookmark.GetByUserId(userId, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where UserId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>UserId</c>
        /// </remarks>
        public static BookmarkCollection GetByUserId(int userId, BootFX.Common.Data.SqlOperator userIdOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("UserId", userIdOperator, userId);
            return ((BookmarkCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where UserId matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>UserId</c>
        /// </remarks>
        public static BookmarkCollection GetByUserId(int userId, BootFX.Common.Data.SqlOperator userIdOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("UserId", userIdOperator, userId);
            BookmarkCollection results = ((BookmarkCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Name is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Bookmark
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Name</c>
        /// </remarks>
        public static BookmarkCollection GetByName(string name)
        {
            return AmxMobile.Services.Bookmark.GetByName(name, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Name matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Name</c>
        /// </remarks>
        public static BookmarkCollection GetByName(string name, BootFX.Common.Data.SqlOperator nameOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("Name", nameOperator, name);
            return ((BookmarkCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Name matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Name</c>
        /// </remarks>
        public static BookmarkCollection GetByName(string name, BootFX.Common.Data.SqlOperator nameOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("Name", nameOperator, name);
            BookmarkCollection results = ((BookmarkCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Url is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Bookmark
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Url</c>
        /// </remarks>
        public static BookmarkCollection GetByUrl(string url)
        {
            return AmxMobile.Services.Bookmark.GetByUrl(url, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Url matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Url</c>
        /// </remarks>
        public static BookmarkCollection GetByUrl(string url, BootFX.Common.Data.SqlOperator urlOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("Url", urlOperator, url);
            return ((BookmarkCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Url matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Url</c>
        /// </remarks>
        public static BookmarkCollection GetByUrl(string url, BootFX.Common.Data.SqlOperator urlOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("Url", urlOperator, url);
            BookmarkCollection results = ((BookmarkCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Gets entities where Ordinal is equal to the given value.
        /// </summary>
        /// <bootfx>
        /// CreateEntityFilterEqualToMethod - Bookmark
        /// </bootfx>
        /// <remarks>
        /// Created for column <c>Ordinal</c>
        /// </remarks>
        public static BookmarkCollection GetByOrdinal(int ordinal)
        {
            return AmxMobile.Services.Bookmark.GetByOrdinal(ordinal, BootFX.Common.Data.SqlOperator.EqualTo);
        }
        
        /// <summary>
        /// Gets entities where Ordinal matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Ordinal</c>
        /// </remarks>
        public static BookmarkCollection GetByOrdinal(int ordinal, BootFX.Common.Data.SqlOperator ordinalOperator)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("Ordinal", ordinalOperator, ordinal);
            return ((BookmarkCollection)(filter.ExecuteEntityCollection()));
        }
        
        /// <summary>
        /// Gets entities where Ordinal matches the given specification.
        /// </summary>
        /// <remarks>
        /// Created for column <c>Ordinal</c>
        /// </remarks>
        public static BookmarkCollection GetByOrdinal(int ordinal, BootFX.Common.Data.SqlOperator ordinalOperator, BootFX.Common.OnNotFound onNotFound)
        {
            BootFX.Common.Data.SqlFilter filter = new BootFX.Common.Data.SqlFilter(typeof(Bookmark));
            filter.Constraints.Add("Ordinal", ordinalOperator, ordinal);
            BookmarkCollection results = ((BookmarkCollection)(filter.ExecuteEntityCollection()));
            return results;
        }
        
        /// <summary>
        /// Searches for <see cref="Bookmark"/> items with the given terms.
        /// </summary>
        public static BookmarkCollection Search(string terms)
        {
            BootFX.Common.Data.SqlSearcher searcher = new BootFX.Common.Data.SqlSearcher(typeof(Bookmark), terms);
            return ((BookmarkCollection)(searcher.ExecuteEntityCollection()));
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
