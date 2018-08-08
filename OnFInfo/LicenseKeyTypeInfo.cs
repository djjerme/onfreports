namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LicenseKeyTypeInfo
    {
        private int? mAvailable;
        private string mDescription;
        private int? mReorderQty;
        private int? mRequested;
        private int? mStoreId;
        private string mType;
        private string mValue;

        public LicenseKeyTypeInfo()
        {
        }

        public LicenseKeyTypeInfo(string type)
        {
            this.mType = type;
        }

        public LicenseKeyTypeInfo(int? storeid, string type, string value, string description, int? reorderqty)
        {
            this.mStoreId = storeid;
            this.mType = type;
            this.mValue = value;
            this.mDescription = description;
            this.mReorderQty = reorderqty;
        }

        public LicenseKeyTypeInfo(int? storeid, string type, string value, string description, int? reorderqty, int? available, int? requested)
        {
            this.mStoreId = storeid;
            this.mType = type;
            this.mValue = value;
            this.mDescription = description;
            this.mReorderQty = reorderqty;
            this.mAvailable = available;
            this.mRequested = requested;
        }

        public int? Available
        {
            get
            {
                return this.mAvailable;
            }
            set
            {
                this.mAvailable = value;
            }
        }

        public string Description
        {
            get
            {
                return this.mDescription;
            }
            set
            {
                this.mDescription = value;
            }
        }

        public int? ReorderQty
        {
            get
            {
                return this.mReorderQty;
            }
            set
            {
                this.mReorderQty = value;
            }
        }

        public int? Requested
        {
            get
            {
                return this.mRequested;
            }
            set
            {
                this.mRequested = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this.mStoreId;
            }
            set
            {
                this.mStoreId = value;
            }
        }

        public string Type
        {
            get
            {
                return this.mType;
            }
            set
            {
                this.mType = value;
            }
        }

        public string Value
        {
            get
            {
                return this.mValue;
            }
            set
            {
                this.mValue = value;
            }
        }
    }
}

