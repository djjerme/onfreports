namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class StoreNameIDInfo
    {
        private int? mStoreId;
        private string mStoreName;
        private string mType;
        private string mValue;

        public StoreNameIDInfo()
        {
        }

        public StoreNameIDInfo(int storeid, string storename)
        {
            this.mStoreId = new int?(storeid);
            this.mStoreName = storename;
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
    }
}

