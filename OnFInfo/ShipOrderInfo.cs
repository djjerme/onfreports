namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class ShipOrderInfo
    {
        private string mAddress1;
        private string mAddress2;
        private string mAddress3;
        private string mBusPhone;
        private int? mCarrierId;
        private string mCellPhone;
        private string mCity;
        private string mCountry;
        private string mCustomerOrderNumber;
        private string mEmail;
        private string mExternalOrderId;
        private string mFirstName;
        private string mHomePhone;
        private string mLastName;
        private string mMiddleName;
        private DateTime? mNeedDate;
        private int? mOrderId;
        private ShipOrderLineInfo[] mOrderLines;
        private int? mOrderSuffix;
        private DateTime? mOrderWhen;
        private string mRequestedShipMethod;
        private string mShipAttnTo;
        private DateTime? mShipDate;
        private string mShipLabelComment;
        private DateTime? mShipProcessDate;
        private ShipTransactionInfo[] mShipTransactions;
        private string mState;
        private string mStatus;
        private int? mStoreId;
        private string mStoreName;
        private bool? mThirdPartyShipperFlag;
        private string mThirdPartyShipperInfo;
        private string mTrackingNo;
        private string mZip;

        public ShipOrderInfo()
        {
        }

        public ShipOrderInfo(int? storeid, int? orderid, int? ordersuffix, string storename, string status, DateTime? orderwhen, DateTime? needdate, string requestedshipmethod, string trackingno, string shiplabelcomment, bool? thirdpartyshipperflag, string thirdpartyshipperinfo, string shipattnto, int? carrierid, DateTime? shipprocessdate, DateTime? shipdate, string customerordernumber, string externalorderid, string firstname, string middlename, string lastname, string address1, string address2, string address3, string city, string state, string zip, string country, string homephone, string busphone, string cellphone, string email, ShipTransactionInfo[] shiptransactions, ShipOrderLineInfo[] orderlines)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mStoreName = storename;
            this.mStatus = status;
            this.mOrderWhen = orderwhen;
            this.mNeedDate = needdate;
            this.mRequestedShipMethod = requestedshipmethod;
            this.mTrackingNo = trackingno;
            this.mShipLabelComment = shiplabelcomment;
            this.mThirdPartyShipperFlag = thirdpartyshipperflag;
            this.mThirdPartyShipperInfo = thirdpartyshipperinfo;
            this.mShipAttnTo = shipattnto;
            this.mCarrierId = carrierid;
            this.mShipProcessDate = shipprocessdate;
            this.mShipDate = shipdate;
            this.mCustomerOrderNumber = customerordernumber;
            this.mExternalOrderId = externalorderid;
            this.mFirstName = firstname;
            this.mMiddleName = middlename;
            this.mLastName = lastname;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mAddress3 = address3;
            this.mCity = city;
            this.mState = state;
            this.mZip = zip;
            this.mCountry = country;
            this.mHomePhone = homephone;
            this.mBusPhone = busphone;
            this.mCellPhone = cellphone;
            this.mEmail = email;
            this.mShipTransactions = shiptransactions;
            this.mOrderLines = orderlines;
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

        public string BusPhone
        {
            get
            {
                return this.mBusPhone;
            }
            set
            {
                this.mBusPhone = value;
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

        public string CellPhone
        {
            get
            {
                return this.mCellPhone;
            }
            set
            {
                this.mCellPhone = value;
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

        public string CustomerOrderNumber
        {
            get
            {
                return this.mCustomerOrderNumber;
            }
            set
            {
                this.mCustomerOrderNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.mEmail;
            }
            set
            {
                this.mEmail = value;
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

        public string HomePhone
        {
            get
            {
                return this.mHomePhone;
            }
            set
            {
                this.mHomePhone = value;
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

        public ShipOrderLineInfo[] OrderLines
        {
            get
            {
                return this.mOrderLines;
            }
            set
            {
                this.mOrderLines = value;
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

        public string ShipAttnTo
        {
            get
            {
                return this.mShipAttnTo;
            }
            set
            {
                this.mShipAttnTo = value;
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

        public ShipTransactionInfo[] ShipTransactions
        {
            get
            {
                return this.mShipTransactions;
            }
            set
            {
                this.mShipTransactions = value;
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

        public string Status
        {
            get
            {
                return this.mStatus;
            }
            set
            {
                this.mStatus = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
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

