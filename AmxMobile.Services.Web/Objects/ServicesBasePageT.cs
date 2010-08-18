using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BootFX.Common;
using BootFX.Common.UI;
using BootFX.Common.UI.Web;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Entities;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace AmxMobile.Services.Web
{
    public class ServicesBasePage<T> : ServicesBasePage, IEntityType
        where T : Entity
    {
        /// <summary>
        /// Private value to support the <see cref="Item">Item</see> property.
        /// </summary>
        private T _item;

        public ServicesBasePage()
        {
        }

        /// <summary>
        /// Gets the Item value.
        /// </summary>
        internal T Item
        {
            get
            {
                if (_item == null)
                {
                    EntityType et = this.EntityType;
                    int id = ConversionHelper.ToInt32(this.Request.Params["id"], Cultures.System);
                    if (id != 0)
                    {
                        _item = (T)et.Persistence.GetById(new object[] { id }, OnNotFound.ThrowException);
                        if (_item == null)
                            throw new InvalidOperationException("'_item' is null.");
                    }
                    else
                        _item = (T)et.CreateInstance();
                }
                return _item;
            }
        }

        public EntityType EntityType
        {
            get
            {
                return EntityType.GetEntityType(typeof(T), OnNotFound.ThrowException);
            }
        }

        internal bool IsNew
        {
            get
            {
                if (Item == null)
                    throw new InvalidOperationException("'Item' is null.");
                return this.Item.IsNew();
            }
        }
    }
}
