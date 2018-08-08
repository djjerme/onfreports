namespace PBA.OnfInfo
{
    using System;

    [CLSCompliant(true)]
    public class NotificationOrderInfo : Info
    {
        private string mActualShipMethod;
        private int? mAddressId;
        private string mBillToAddress1;
        private string mBillToAddress2;
        private string mBillToAddress3;
        private string mBillToCity;
        private string mBillToCompany;
        private string mBillToCountry;
        private string mBillToEmail;
        private string mBillToName;
        private string mBillToPhone;
        private string mBillToState;
        private string mBillToZip;
        private int? mCarrierId;
        private DateTime? mClassDate;
        private string mCustOrderNo;
        private string mExpedite;
        private bool? mExternalOrderFlag;
        private string mExternalOrderId;
        private string mFirstName;
        private decimal? mgrandTotal;
        private decimal? mhandling;
        private string mLastName;
        private NotificationOrderLineInfo[] mLineInfo;
        private string mMiddleName;
        private DateTime? mNeedDate;
        private DateTime? mNotificationSent;
        private int? mOrderAgeInMinutes;
        private string mOrderedByAddress1;
        private string mOrderedByAddress2;
        private string mOrderedByAddress3;
        private string mOrderedByCity;
        private string mOrderedByCompany;
        private string mOrderedByCountry;
        private string mOrderedByEmail;
        private string mOrderedByName;
        private string mOrderedByPhone;
        private string mOrderedByState;
        private string mOrderedByZip;
        private int? mOrderId;
        private string mOrderStatus;
        private int? mOrderSuffix;
        private string mOrderType;
        private DateTime? mOrderWhen;
        private int? mPersonId;
        private string mPrintLocationId;
        private int? mPrintshopId;
        private string mRequestedShipMethod;
        private decimal? msalesTax;
        private string mShipAddress1;
        private string mShipAddress2;
        private string mShipAddress3;
        private string mShipCity;
        private string mShipCompany;
        private string mShipCountry;
        private DateTime? mShipDate;
        private DateTime? mShipDateEstimated;
        private string mShipEmail;
        private string mShipLabelComment;
        private string mShipName;
        private string mShipPhone;
        private decimal? mshipping;
        private DateTime? mShipProcessDate;
        private string mShipState;
        private string mShipZip;
        private int? mStoreId;
        private string mStoreName;
        private bool? mThirdPartyShipperFlag;
        private string mThirdPartyShipperInfo;
        private string mTrackingNo;
        private string mTrainingClassification;
        private string mTrainingType;
        private string mUserType;
        private string mWarehouseComment;

        public NotificationOrderInfo() : base(false)
        {
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

        public int? AddressId
        {
            get
            {
                return this.mAddressId;
            }
            set
            {
                this.mAddressId = value;
            }
        }

        public string BillToAddress1
        {
            get
            {
                return this.mBillToAddress1;
            }
            set
            {
                this.mBillToAddress1 = value;
            }
        }

        public string BillToAddress2
        {
            get
            {
                return this.mBillToAddress2;
            }
            set
            {
                this.mBillToAddress2 = value;
            }
        }

        public string BillToAddress3
        {
            get
            {
                return this.mBillToAddress3;
            }
            set
            {
                this.mBillToAddress3 = value;
            }
        }

        public string BillToCity
        {
            get
            {
                return this.mBillToCity;
            }
            set
            {
                this.mBillToCity = value;
            }
        }

        public string BillToCompany
        {
            get
            {
                return this.mBillToCompany;
            }
            set
            {
                this.mBillToCompany = value;
            }
        }

        public string BillToCountry
        {
            get
            {
                return this.mBillToCountry;
            }
            set
            {
                this.mBillToCountry = value;
            }
        }

        public string BillToEmail
        {
            get
            {
                return this.mBillToEmail;
            }
            set
            {
                this.mBillToEmail = value;
            }
        }

        public string BillToName
        {
            get
            {
                return this.mBillToName;
            }
            set
            {
                this.mBillToName = value;
            }
        }

        public string BillToPhone
        {
            get
            {
                return this.mBillToPhone;
            }
            set
            {
                this.mBillToPhone = value;
            }
        }

        public string BillToState
        {
            get
            {
                return this.mBillToState;
            }
            set
            {
                this.mBillToState = value;
            }
        }

        public string BillToZip
        {
            get
            {
                return this.mBillToZip;
            }
            set
            {
                this.mBillToZip = value;
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

        public DateTime? ClassDate
        {
            get
            {
                return this.mClassDate;
            }
            set
            {
                this.mClassDate = value;
            }
        }

        public string CustOrderNo
        {
            get
            {
                return this.mCustOrderNo;
            }
            set
            {
                this.mCustOrderNo = value;
            }
        }

        public string Expedite
        {
            get
            {
                return this.mExpedite;
            }
            set
            {
                this.mExpedite = value;
            }
        }

        public bool? ExternalOrderFlag
        {
            get
            {
                return this.mExternalOrderFlag;
            }
            set
            {
                this.mExternalOrderFlag = value;
            }
        }

        public string ExternalOrderId
        {
            get
            {
                return this.mExternalOrderId;
            }
            set
            {
                this.mExternalOrderId = value;
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

        public decimal? GrandTotal
        {
            get
            {
                return this.mgrandTotal;
            }
            set
            {
                this.mgrandTotal = value;
            }
        }

        public decimal? Handling
        {
            get
            {
                return this.mhandling;
            }
            set
            {
                this.mhandling = value;
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

        public NotificationOrderLineInfo[] LineInfo
        {
            get
            {
                return this.mLineInfo;
            }
            set
            {
                this.mLineInfo = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.mMiddleName;
            }
            set
            {
                this.mMiddleName = value;
            }
        }

        public DateTime? NeedDate
        {
            get
            {
                return this.mNeedDate;
            }
            set
            {
                this.mNeedDate = value;
            }
        }

        public DateTime? NotificationSent
        {
            get
            {
                return this.mNotificationSent;
            }
            set
            {
                this.mNotificationSent = value;
            }
        }

        public int? OrderAgeInMinutes
        {
            get
            {
                return this.mOrderAgeInMinutes;
            }
            set
            {
                this.mOrderAgeInMinutes = value;
            }
        }

        public string OrderedByAddress1
        {
            get
            {
                return this.mOrderedByAddress1;
            }
            set
            {
                this.mOrderedByAddress1 = value;
            }
        }

        public string OrderedByAddress2
        {
            get
            {
                return this.mOrderedByAddress2;
            }
            set
            {
                this.mOrderedByAddress2 = value;
            }
        }

        public string OrderedByAddress3
        {
            get
            {
                return this.mOrderedByAddress3;
            }
            set
            {
                this.mOrderedByAddress3 = value;
            }
        }

        public string OrderedByCity
        {
            get
            {
                return this.mOrderedByCity;
            }
            set
            {
                this.mOrderedByCity = value;
            }
        }

        public string OrderedByCompany
        {
            get
            {
                return this.mOrderedByCompany;
            }
            set
            {
                this.mOrderedByCompany = value;
            }
        }

        public string OrderedByCountry
        {
            get
            {
                return this.mOrderedByCountry;
            }
            set
            {
                this.mOrderedByCountry = value;
            }
        }

        public string OrderedByEmail
        {
            get
            {
                return this.mOrderedByEmail;
            }
            set
            {
                this.mOrderedByEmail = value;
            }
        }

        public string OrderedByName
        {
            get
            {
                return this.mOrderedByName;
            }
            set
            {
                this.mOrderedByName = value;
            }
        }

        public string OrderedByPhone
        {
            get
            {
                return this.mOrderedByPhone;
            }
            set
            {
                this.mOrderedByPhone = value;
            }
        }

        public string OrderedByState
        {
            get
            {
                return this.mOrderedByState;
            }
            set
            {
                this.mOrderedByState = value;
            }
        }

        public string OrderedByZip
        {
            get
            {
                return this.mOrderedByZip;
            }
            set
            {
                this.mOrderedByZip = value;
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

        public string OrderStatus
        {
            get
            {
                return this.mOrderStatus;
            }
            set
            {
                this.mOrderStatus = value;
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

        public int? PersonId
        {
            get
            {
                return this.mPersonId;
            }
            set
            {
                this.mPersonId = value;
            }
        }

        public string PrintLocationId
        {
            get
            {
                return this.mPrintLocationId;
            }
            set
            {
                this.mPrintLocationId = value;
            }
        }

        public int? PrintshopId
        {
            get
            {
                return this.mPrintshopId;
            }
            set
            {
                this.mPrintshopId = value;
            }
        }

        public string RequestedShipMethod
        {
            get
            {
                return this.mRequestedShipMethod;
            }
            set
            {
                this.mRequestedShipMethod = value;
            }
        }

        public decimal? SalesTax
        {
            get
            {
                return this.msalesTax;
            }
            set
            {
                this.msalesTax = value;
            }
        }

        public string ShipAddress1
        {
            get
            {
                return this.mShipAddress1;
            }
            set
            {
                this.mShipAddress1 = value;
            }
        }

        public string ShipAddress2
        {
            get
            {
                return this.mShipAddress2;
            }
            set
            {
                this.mShipAddress2 = value;
            }
        }

        public string ShipAddress3
        {
            get
            {
                return this.mShipAddress3;
            }
            set
            {
                this.mShipAddress3 = value;
            }
        }

        public string ShipCity
        {
            get
            {
                return this.mShipCity;
            }
            set
            {
                this.mShipCity = value;
            }
        }

        public string ShipCompany
        {
            get
            {
                return this.mShipCompany;
            }
            set
            {
                this.mShipCompany = value;
            }
        }

        public string ShipCountry
        {
            get
            {
                return this.mShipCountry;
            }
            set
            {
                this.mShipCountry = value;
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

        public DateTime? ShipDateEstimated
        {
            get
            {
                return this.mShipDateEstimated;
            }
            set
            {
                this.mShipDateEstimated = value;
            }
        }

        public string ShipEmail
        {
            get
            {
                return this.mShipEmail;
            }
            set
            {
                this.mShipEmail = value;
            }
        }

        public string ShipLabelComment
        {
            get
            {
                return this.mShipLabelComment;
            }
            set
            {
                this.mShipLabelComment = value;
            }
        }

        public string ShipName
        {
            get
            {
                return this.mShipName;
            }
            set
            {
                this.mShipName = value;
            }
        }

        public string ShipPhone
        {
            get
            {
                return this.mShipPhone;
            }
            set
            {
                this.mShipPhone = value;
            }
        }

        public decimal? Shipping
        {
            get
            {
                return this.mshipping;
            }
            set
            {
                this.mshipping = value;
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

        public string ShipState
        {
            get
            {
                return this.mShipState;
            }
            set
            {
                this.mShipState = value;
            }
        }

        public string ShipZip
        {
            get
            {
                return this.mShipZip;
            }
            set
            {
                this.mShipZip = value;
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

        public string TrainingClassification
        {
            get
            {
                return this.mTrainingClassification;
            }
            set
            {
                this.mTrainingClassification = value;
            }
        }

        public string TrainingType
        {
            get
            {
                return this.mTrainingType;
            }
            set
            {
                this.mTrainingType = value;
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

        public string WarehouseComment
        {
            get
            {
                return this.mWarehouseComment;
            }
            set
            {
                this.mWarehouseComment = value;
            }
        }
    }
}

