using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Web;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace AmxMobile.Services.Web
{
    [PageSecurity(true)]
    public partial class ViewBookmarks : ServicesBasePage<UserItem>
    {
        /// <summary>
        /// Private value to support the <see cref="Bookmarks">Bookmarks</see> property.
        /// </summary>
        private BookmarkCollection _bookmarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.labelUser.Text = this.Item.Username;

            // push...
            if (!(this.IsPostBack))
                this.PushData();
        }

        private List<Pair> GetPairs()
        {
            return new List<Pair>() { 
                new Pair(0, this.textName1, this.textUrl1), 
                new Pair(1, this.textName2, this.textUrl2), 
                new Pair(2, this.textName3, this.textUrl3), 
                new Pair(3, this.textName4, this.textUrl4), 
                new Pair(4, this.textName5, this.textUrl5), 
                new Pair(5, this.textName6, this.textUrl6) };
        }

        private void PushData()
        {
            if (Bookmarks == null)
                throw new InvalidOperationException("'Bookmarks' is null.");

            // walk...
            foreach (Pair pair in this.GetPairs())
                PushData(pair);
        }

        private void PushData(Pair pair)
        {
            if (pair == null)
                throw new ArgumentNullException("pair");

            // set...
            if (Bookmarks == null)
                throw new InvalidOperationException("'Bookmarks' is null.");
            Bookmark bookmark = this.Bookmarks.GetByOrdinal(pair.Ordinal);
            if (bookmark != null)
            {
                pair.Name.Text = bookmark.Name;
                pair.Url.Text = bookmark.Url;
            }
        }

        private BookmarkCollection Bookmarks
        {
            get
            {
                if (_bookmarks == null)
                {
                    _bookmarks = this.Item.GetBookmarkItems();
                    if (_bookmarks == null)
                        throw new InvalidOperationException("'_bookmarks' is null.");
                }
                return _bookmarks;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // save...
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
        }

        void buttonSave_Click(object sender, EventArgs e)
        {
            this.widgetFeedback.Reset();
            try
            {
                // walk...
                FormChecker checker = new FormChecker(this);
                foreach (Pair pair in this.GetPairs())
                    this.PullData(pair, checker);

                // errors...
                if (!(checker.HasErrors))
                {
                    // walk...
                    this.Bookmarks.SaveChanges();

                    // set...
                    this.widgetFeedback.SetInfo("Your changes have been saved.");
                }

                // showw...
                if (checker.HasErrors)
                    this.widgetFeedback.SetError(checker);
            }
            catch (Exception ex)
            {
                this.widgetFeedback.SetError(ex);
            }
        }

        private void PullData(Pair pair, FormChecker checker)
        {
            if (pair == null)
                throw new ArgumentNullException("pair");
            if (checker == null)
                throw new ArgumentNullException("checker");

            // get...
            string name = checker.GetStringValue(new ControlReference(pair.Name, "Name " + pair.DisplayOrdinal.ToString()), false);
            string url = checker.GetStringValue(new ControlReference(pair.Url, "URL " + pair.DisplayOrdinal.ToString()), false);

            // either?
            bool hasName = !(string.IsNullOrEmpty(name));
            bool hasUrl = !(string.IsNullOrEmpty(url));

            // both?
            if (hasName && hasUrl)
            {
                // get...
                Bookmark bookmark = this.Bookmarks.GetByOrdinal(pair.Ordinal);
                if (bookmark == null)
                {
                    bookmark = new Bookmark();
                    bookmark.Ordinal = pair.Ordinal;
                    bookmark.User = this.Item;

                    // add...
                    this.Bookmarks.Add(bookmark);
                }

                // set...
                bookmark.Name = name;
                bookmark.Url = url;
            }
            else
            {
                if (hasName || hasUrl)
                    checker.AddError(string.Format("Both a name and URL must be specified for bookmark {0}", pair.DisplayOrdinal));
            }
        }

        private class Pair
        {
            internal int Ordinal { get; private set; }
            internal TextBox Name { get; private set; }
            internal TextBox Url { get; private set; }

            internal Pair(int ordinal, TextBox name, TextBox url)
            {
                if (name == null)
                    throw new ArgumentNullException("name");
                if (url == null)
                    throw new ArgumentNullException("url");

                // set...
                this.Ordinal = ordinal;
                this.Name = name;
                this.Url = url;
            }

            internal int DisplayOrdinal
            {
                get
                {
                    return this.Ordinal + 1;
                }
            }
        }
    }
}
