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
    /// Defines the entity type for 'Bookmarks'.
    /// </summary>
    [Serializable()]
    [Entity(typeof(BookmarkCollection), "Bookmarks")]
    [SortSpecification(new string[] {
            "Name"}, new BootFX.Common.Data.SortDirection[] {
            BootFX.Common.Data.SortDirection.Ascending})]
    public class Bookmark : BookmarkBase
    {
        public const int DefaultNumBookmarks = 6;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public Bookmark()
        {
        }
        
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        protected Bookmark(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context)
        {
        }

        protected override void OnBeforeSaveChangesInTransaction(BeforeSaveChangesEventArgs e)
        {
            base.OnBeforeSaveChangesInTransaction(e);

            // are we about to create a new item?  if so we need to dereference the user...
            if (e.WorkUnitType == WorkUnitType.Insert)
            {
                // do we have a user id?
                if (this.UserId == 0)
                {
                    // deref...
                    UserItem user = ServiceAuthenticator.Current.GetUser();
                    if (user == null)
                        throw new InvalidOperationException("A user was not available in the context.");

                    // set...
                    if (e.InsertWorkUnit == null)
                        throw new InvalidOperationException("'e.InsertWorkUnit' is null.");
                    e.InsertWorkUnit.SetFieldValue("userid", user.UserId);
                }
            }
        }
    }
}
