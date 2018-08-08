namespace PBA.OnfInfo
{
    using System;

    public class WarehouseStoreTemplateInfo
    {
        private bool? _changed = false;
        private int? _storeId = -1;
        private WarehouseImageInfo[] _storeImages = null;
        private WarehouseStyleInfo[] _storeStyles = null;
        private WarehouseTemplateInfo[] _storeTemplates = null;

        public bool? Changed
        {
            get
            {
                return this._changed;
            }
            set
            {
                this._changed = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this._storeId;
            }
            set
            {
                this._storeId = value;
            }
        }

        public WarehouseImageInfo[] StoreImages
        {
            get
            {
                return this._storeImages;
            }
            set
            {
                this._storeImages = value;
            }
        }

        public WarehouseStyleInfo[] StoreStyles
        {
            get
            {
                return this._storeStyles;
            }
            set
            {
                this._storeStyles = value;
            }
        }

        public WarehouseTemplateInfo[] StoreTemplates
        {
            get
            {
                return this._storeTemplates;
            }
            set
            {
                this._storeTemplates = value;
            }
        }
    }
}

