namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class ItemLicenseKeyTypeInfo
    {
        private string mItemId;
        private int? mStoreId;
        private string mType;

        public ItemLicenseKeyTypeInfo()
        {
        }

        public ItemLicenseKeyTypeInfo(int storeid, string itemid, string type)
        {
            this.mStoreId = new int?(storeid);
            this.mItemId = itemid;
            this.mType = type;
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
    }
}

