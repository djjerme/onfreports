namespace PBA.OnfInfo
{
    using System;

    public class PricingUserTypePriceInfo
    {
        private bool? mActiveFlag;
        private double? mDefaultPrice;
        private string mItemId;
        private int? mProductId;
        private int? mRegionId;
        private string mRegionName;
        private int? mStoreId;
        private string mUserType;
        private double? mUserTypePrice;

        public PricingUserTypePriceInfo()
        {
        }

        public PricingUserTypePriceInfo(int? storeid, int? regionid, string regionname, string usertype, string itemid, int? productid, double? defaultprice, bool? activeflag, double? usertypeprice)
        {
            this.mStoreId = storeid;
            this.mRegionId = regionid;
            this.mRegionName = regionname;
            this.mUserType = usertype;
            this.mItemId = itemid;
            this.mProductId = productid;
            this.mDefaultPrice = defaultprice;
            this.mActiveFlag = activeflag;
            this.mUserTypePrice = usertypeprice;
        }

        public bool? ActiveFlag
        {
            get
            {
                return this.mActiveFlag;
            }
            set
            {
                this.mActiveFlag = value;
            }
        }

        public double? DefaultPrice
        {
            get
            {
                return this.mDefaultPrice;
            }
            set
            {
                this.mDefaultPrice = value;
            }
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

        public int? ProductId
        {
            get
            {
                return this.mProductId;
            }
            set
            {
                this.mProductId = value;
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

        public double? UserTypePrice
        {
            get
            {
                return this.mUserTypePrice;
            }
            set
            {
                this.mUserTypePrice = value;
            }
        }
    }
}

