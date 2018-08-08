namespace PBA.OnfInfo
{
    using System;

    public class UserTypeRegionInfo
    {
        private int? mRegionId;
        private string mRegionName;
        private int? mStoreId;
        private string mUserType;

        public UserTypeRegionInfo()
        {
        }

        public UserTypeRegionInfo(int? storeid, int? regionid, string regionname, string usertype)
        {
            this.mStoreId = storeid;
            this.mRegionId = regionid;
            this.mRegionName = regionname;
            this.mUserType = usertype;
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

        public string RegionName
        {
            get
            {
                return this.mRegionName;
            }
            set
            {
                this.mRegionName = value;
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

        public string UserType
        {
            get
            {
                return this.mUserType;
            }
            set
            {
                this.mUserType = value;
            }
        }
    }
}

