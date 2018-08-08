namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class FreightReportInfo
    {
        private string mActualShipMethod;
        private double? mActualShipping;
        private string mAddress1;
        private string mAddress2;
        private string mAddress3;
        private bool? mBatchUpdate;
        private string mCarrierCode;
        private int? mCarrierId;
        private string mCity;
        private string mCountry;
        private double? mDomesticDiscount;
        private double? mDomesticMultiplier;
        private string mFirstName;
        private double? mInternalShippingCost;
        private bool? mInternational;
        private double? mInternationalDiscount;
        private double? mInternationalMultiplier;
        private string mLastName;
        private int? mLineCount;
        private int? mNumberOfPackages;
        private int? mOrderId;
        private string mOrderReason;
        private int? mOrderSuffix;
        private string mOrderType;
        private DateTime? mOrderWhen;
        private string mPaymentMethod;
        private string mProductFamily;
        private DateTime? mResolvedShipDate;
        private DateTime? mShipDate;
        private string mShipFirstName;
        private string mShipLastName;
        private DateTime? mShipProcessDate;
        private string mState;
        private int? mStoreId;
        private string mStoreName;
        private bool? mThirdPartyShipperFlag;
        private string mThirdPartyShipperInfo;
        private string mTrackingNo;
        private string mTransactionId;
        private int? mUnitCount;
        private string mUserType;
        private string mZip;

        public FreightReportInfo()
        {
        }

        public FreightReportInfo(int? storeid, int? orderid, int? ordersuffix, string ordertype, DateTime? orderwhen, DateTime? shipdate, DateTime? shipprocessdate, DateTime? resolvedshipdate, bool? batchupdate, string paymentmethod, string transactionid, double? actualshipping, double? internalshippingcost, int? numberofpackages, string orderreason, string usertype, string trackingno, string productfamily, string actualshipmethod, bool? thirdpartyshipperflag, string thirdpartyshipperinfo, int? carrierid, string carriercode, double? domesticmultiplier, double? internationalmultiplier, string firstname, string lastname, string shipfirstname, string shiplastname, string storename, string address1, string address2, string address3, string city, string state, string zip, string country, bool? international, int? linecount, int? unitcount, double? domesticdiscount, double? internationaldiscount)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mOrderType = ordertype;
            this.mOrderWhen = orderwhen;
            this.mShipDate = shipdate;
            this.mShipProcessDate = shipprocessdate;
            this.mResolvedShipDate = resolvedshipdate;
            this.mBatchUpdate = batchupdate;
            this.mPaymentMethod = paymentmethod;
            this.mTransactionId = transactionid;
            this.mActualShipping = actualshipping;
            this.mInternalShippingCost = internalshippingcost;
            this.mNumberOfPackages = numberofpackages;
            this.mOrderReason = orderreason;
            this.mUserType = usertype;
            this.mTrackingNo = trackingno;
            this.mProductFamily = productfamily;
            this.mActualShipMethod = actualshipmethod;
            this.mThirdPartyShipperFlag = thirdpartyshipperflag;
            this.mThirdPartyShipperInfo = thirdpartyshipperinfo;
            this.mCarrierId = carrierid;
            this.mCarrierCode = carriercode;
            this.mDomesticMultiplier = domesticmultiplier;
            this.mInternationalMultiplier = internationalmultiplier;
            this.mFirstName = firstname;
            this.mLastName = lastname;
            this.mShipFirstName = shipfirstname;
            this.mShipLastName = shiplastname;
            this.mStoreName = storename;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mAddress3 = address3;
            this.mCity = city;
            this.mState = state;
            this.mZip = zip;
            this.mCountry = country;
            this.mInternational = international;
            this.mLineCount = linecount;
            this.mUnitCount = unitcount;
            this.mDomesticDiscount = domesticdiscount;
            this.mInternationalDiscount = internationaldiscount;
        }

        public string ActualShipMethod
        {
            get
            {
                return this.mActualShipMethod;
            }
            set
            {
                this.mActualShipMethod = value;
            }
        }

        public double? ActualShipping
        {
            get
            {
                return this.mActualShipping;
            }
            set
            {
                this.mActualShipping = value;
            }
        }

        public string Address1
        {
            get
            {
                return this.mAddress1;
            }
            set
            {
                this.mAddress1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this.mAddress2;
            }
            set
            {
                this.mAddress2 = value;
            }
        }

        public string Address3
        {
            get
            {
                return this.mAddress3;
            }
            set
            {
                this.mAddress3 = value;
            }
        }

        public bool? BatchUpdate
        {
            get
            {
                return this.mBatchUpdate;
            }
            set
            {
                this.mBatchUpdate = value;
            }
        }

        public string CarrierCode
        {
            get
            {
                return this.mCarrierCode;
            }
            set
            {
                this.mCarrierCode = value;
            }
        }

        public int? CarrierId
        {
            get
            {
                return this.mCarrierId;
            }
            set
            {
                this.mCarrierId = value;
            }
        }

        public string City
        {
            get
            {
                return this.mCity;
            }
            set
            {
                this.mCity = value;
            }
        }

        public string Country
        {
            get
            {
                return this.mCountry;
            }
            set
            {
                this.mCountry = value;
            }
        }

        public double? DomesticDiscount
        {
            get
            {
                return this.mDomesticDiscount;
            }
            set
            {
                this.mDomesticDiscount = value;
            }
        }

        public double? DomesticMultiplier
        {
            get
            {
                return this.mDomesticMultiplier;
            }
            set
            {
                this.mDomesticMultiplier = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.mFirstName;
            }
            set
            {
                this.mFirstName = value;
            }
        }

        public double? InternalShippingCost
        {
            get
            {
                return this.mInternalShippingCost;
            }
            set
            {
                this.mInternalShippingCost = value;
            }
        }

        public bool? International
        {
            get
            {
                return this.mInternational;
            }
            set
            {
                this.mInternational = value;
            }
        }

        public double? InternationalDiscount
        {
            get
            {
                return this.mInternationalDiscount;
            }
            set
            {
                this.mInternationalDiscount = value;
            }
        }

        public double? InternationalMultiplier
        {
            get
            {
                return this.mInternationalMultiplier;
            }
            set
            {
                this.mInternationalMultiplier = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.mLastName;
            }
            set
            {
                this.mLastName = value;
            }
        }

        public int? LineCount
        {
            get
            {
                return this.mLineCount;
            }
            set
            {
                this.mLineCount = value;
            }
        }

        public int? NumberOfPackages
        {
            get
            {
                return this.mNumberOfPackages;
            }
            set
            {
                this.mNumberOfPackages = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return this.mOrderId;
            }
            set
            {
                this.mOrderId = value;
            }
        }

        public string OrderReason
        {
            get
            {
                return this.mOrderReason;
            }
            set
            {
                this.mOrderReason = value;
            }
        }

        public int? OrderSuffix
        {
            get
            {
                return this.mOrderSuffix;
            }
            set
            {
                this.mOrderSuffix = value;
            }
        }

        public string OrderType
        {
            get
            {
                return this.mOrderType;
            }
            set
            {
                this.mOrderType = value;
            }
        }

        public DateTime? OrderWhen
        {
            get
            {
                return this.mOrderWhen;
            }
            set
            {
                this.mOrderWhen = value;
            }
        }

        public string PaymentMethod
        {
            get
            {
                return this.mPaymentMethod;
            }
            set
            {
                this.mPaymentMethod = value;
            }
        }

        public string ProductFamily
        {
            get
            {
                return this.mProductFamily;
            }
            set
            {
                this.mProductFamily = value;
            }
        }

        public double? PublishedRate
        {
            get
            {
                double? internationalMultiplier;
                double? internalShippingCost;
                double? nullable5;
                double? mActualShipping = this.mActualShipping;
                if (this.mInternational.Value)
                {
                    if (this.mInternationalMultiplier.HasValue)
                    {
                        internationalMultiplier = this.InternationalMultiplier;
                        internalShippingCost = this.InternalShippingCost;
                        mActualShipping = (internationalMultiplier.HasValue & internalShippingCost.HasValue) ? new double?(internationalMultiplier.GetValueOrDefault() * internalShippingCost.GetValueOrDefault()) : ((double?) (nullable5 = null));
                    }
                    if (this.mInternationalDiscount.HasValue)
                    {
                        mActualShipping = ((100.0 - this.mInternationalDiscount) * mActualShipping) / 100.0;
                    }
                    return mActualShipping;
                }
                if (this.mDomesticMultiplier.HasValue)
                {
                    internationalMultiplier = this.DomesticMultiplier;
                    internalShippingCost = this.InternalShippingCost;
                    mActualShipping = (internationalMultiplier.HasValue & internalShippingCost.HasValue) ? new double?(internationalMultiplier.GetValueOrDefault() * internalShippingCost.GetValueOrDefault()) : ((double?) (nullable5 = null));
                }
                if (this.mDomesticDiscount.HasValue)
                {
                    mActualShipping = ((100.0 - this.mDomesticDiscount) * mActualShipping) / 100.0;
                }
                return mActualShipping;
            }
        }

        public DateTime? ResolvedShipDate
        {
            get
            {
                return this.mResolvedShipDate;
            }
            set
            {
                this.mResolvedShipDate = value;
            }
        }

        public DateTime? ShipDate
        {
            get
            {
                return this.mShipDate;
            }
            set
            {
                this.mShipDate = value;
            }
        }

        public string ShipFirstName
        {
            get
            {
                return this.mShipFirstName;
            }
            set
            {
                this.mShipFirstName = value;
            }
        }

        public string ShipLastName
        {
            get
            {
                return this.mShipLastName;
            }
            set
            {
                this.mShipLastName = value;
            }
        }

        public DateTime? ShipProcessDate
        {
            get
            {
                return this.mShipProcessDate;
            }
            set
            {
                this.mShipProcessDate = value;
            }
        }

        public string State
        {
            get
            {
                return this.mState;
            }
            set
            {
                this.mState = value;
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

        public bool? ThirdPartyShipperFlag
        {
            get
            {
                return this.mThirdPartyShipperFlag;
            }
            set
            {
                this.mThirdPartyShipperFlag = value;
            }
        }

        public string ThirdPartyShipperInfo
        {
            get
            {
                return this.mThirdPartyShipperInfo;
            }
            set
            {
                this.mThirdPartyShipperInfo = value;
            }
        }

        public string TrackingNo
        {
            get
            {
                return this.mTrackingNo;
            }
            set
            {
                this.mTrackingNo = value;
            }
        }

        public string TransactionId
        {
            get
            {
                return this.mTransactionId;
            }
            set
            {
                this.mTransactionId = value;
            }
        }

        public int? UnitCount
        {
            get
            {
                return this.mUnitCount;
            }
            set
            {
                this.mUnitCount = value;
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

        public string Zip
        {
            get
            {
                return this.mZip;
            }
            set
            {
                this.mZip = value;
            }
        }
    }
}

