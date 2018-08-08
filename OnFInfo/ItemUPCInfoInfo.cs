namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class ItemUPCInfoInfo : Info
    {
        private string mItemId;
        private string mProductName;
        private int? mStoreId;
        private string mStoreName;
        private string mUPCCode;
        private string mUpcDescription;
        private string mUPCText;

        public ItemUPCInfoInfo()
        {
        }

        public ItemUPCInfoInfo(int? storeid, string itemid, string upccode, string upctext, string upcdescription) : base(true)
        {
            this.mStoreId = storeid;
            this.mItemId = itemid;
            this.mUPCCode = upccode;
            this.mUPCText = upctext;
            this.mUpcDescription = upcdescription;
        }

        public ItemUPCInfoInfo(int? storeid, string itemid, string storename, string productname, string upccode, string upctext) : base(true)
        {
            this.mStoreId = storeid;
            this.mItemId = itemid;
            this.mStoreName = storename;
            this.mProductName = productname;
            this.mUPCCode = upccode;
            this.mUPCText = upctext;
        }

        public string ItemId
        {
            get
            {
                return this.mItemId;
            }
            set
            {
                this.mItemId = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.mProductName;
            }
            set
            {
                this.mProductName = value;
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

        public string StoreName
        {
            get
            {
                return this.mStoreName;
            }
            set
            {
                this.mStoreName = value;
            }
        }

        public string UPCCode
        {
            get
            {
                return this.mUPCCode;
            }
            set
            {
                this.mUPCCode = value;
            }
        }

        public string UpcDescription
        {
            get
            {
                return this.mUpcDescription;
            }
            set
            {
                this.mUpcDescription = value;
            }
        }

        public string UPCText
        {
            get
            {
                return this.mUPCText;
            }
            set
            {
                this.mUPCText = value;
            }
        }
    }
}

