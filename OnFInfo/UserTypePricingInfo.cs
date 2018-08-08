namespace PBA.OnfInfo
{
    using System;

    public class UserTypePricingInfo
    {
        private bool? mAccessFlag;
        private bool? mActiveFlag;
        private bool? mAddToCartFlag;
        private int? mDefaultMaxOrderQty;
        private int? mDefaultMinOrderQty;
        private double? mDefaultPrice;
        private string mItemId;
        private int? mMaxOrderQty;
        private int? mMinOrderQty;
        private int? mProductId;
        private string mProductType;
        private int? mProductTypeCode;
        private int? mRegionId;
        private string mRegionName;
        private decimal? mSalePrice;
        private int? mStoreId;
        private string mUserType;
        private int? mUserTypeItemId;
        private decimal? mUserTypePrice;
        private int? mUserTypeProductId;

        public UserTypePricingInfo()
        {
        }

        public UserTypePricingInfo(int? storeid, string itemid, int? productid, double? defaultprice, int? defaultminorderqty, int? defaultmaxorderqty, int? minorderqty, int? maxorderqty, bool? activeflag, string regionname, int? regionid, string usertype, decimal? usertypeprice, int? usertypeitemid, decimal? saleprice, int? usertypeproductid, int? producttypecode, string producttype, bool? accessflag, bool? addtocartflag)
        {
            this.mStoreId = storeid;
            this.mItemId = itemid;
            this.mProductId = productid;
            this.mDefaultPrice = defaultprice;
            this.mDefaultMinOrderQty = defaultminorderqty;
            this.mDefaultMaxOrderQty = defaultmaxorderqty;
            this.mMinOrderQty = minorderqty;
            this.mMaxOrderQty = maxorderqty;
            this.mActiveFlag = activeflag;
            this.mRegionName = regionname;
            this.mRegionId = regionid;
            this.mUserType = usertype;
            this.mUserTypePrice = usertypeprice;
            this.mUserTypeItemId = usertypeitemid;
            this.mSalePrice = saleprice;
            this.mUserTypeProductId = usertypeproductid;
            this.mProductTypeCode = producttypecode;
            this.mProductType = producttype;
            this.mAccessFlag = accessflag;
            this.mAddToCartFlag = addtocartflag;
        }

        public bool? AccessFlag
        {
            get
            {
                return this.mAccessFlag;
            }
            set
            {
                this.mAccessFlag = value;
            }
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

        public bool? AddToCartFlag
        {
            get
            {
                return this.mAddToCartFlag;
            }
            set
            {
                this.mAddToCartFlag = value;
            }
        }

        public int? DefaultMaxOrderQty
        {
            get
            {
                return this.mDefaultMaxOrderQty;
            }
            set
            {
                this.mDefaultMaxOrderQty = value;
            }
        }

        public int? DefaultMinOrderQty
        {
            get
            {
                return this.mDefaultMinOrderQty;
            }
            set
            {
                this.mDefaultMinOrderQty = value;
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

        public int? MaxOrderQty
        {
            get
            {
                return this.mMaxOrderQty;
            }
            set
            {
                this.mMaxOrderQty = value;
            }
        }

        public int? MinOrderQty
        {
            get
            {
                return this.mMinOrderQty;
            }
            set
            {
                this.mMinOrderQty = value;
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

        public string ProductType
        {
            get
            {
                return this.mProductType;
            }
            set
            {
                this.mProductType = value;
            }
        }

        public int? ProductTypeCode
        {
            get
            {
                return this.mProductTypeCode;
            }
            set
            {
                this.mProductTypeCode = value;
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

        public decimal? SalePrice
        {
            get
            {
                return this.mSalePrice;
            }
            set
            {
                this.mSalePrice = value;
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

        public int? UserTypeItemId
        {
            get
            {
                return this.mUserTypeItemId;
            }
            set
            {
                this.mUserTypeItemId = value;
            }
        }

        public decimal? UserTypePrice
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

        public int? UserTypeProductId
        {
            get
            {
                return this.mUserTypeProductId;
            }
            set
            {
                this.mUserTypeProductId = value;
            }
        }
    }
}

