namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class RegionInfo
    {
        private string mName;
        private int? mRegionId;
        private int? mStoreId;

        public RegionInfo()
        {
        }

        public RegionInfo(int? regionid, string name, int? storeid)
        {
            this.mRegionId = regionid;
            this.mName = name;
            this.mStoreId = storeid;
        }

        public string Name
        {
            get
            {
                return this.mName;
            }
            set
            {
                this.mName = value;
            }
        }

        public int? RegionId
        {
            get
            {
                return this.mRegionId;
            }
            set
            {
                this.mRegionId = value;
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
    }
}

