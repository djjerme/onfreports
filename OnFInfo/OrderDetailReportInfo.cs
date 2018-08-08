namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class OrderDetailReportInfo
    {
        private DateTime? mBegSnapshot;
        private string mCustOrderNo;
        private DateTime? mEndSnapshot;
        private string mExternalOrderId;
        private string mFirstName;
        private string mItemId;
        private string mLastName;
        private DateTime? mOrderWhen;
        private string mProductName;
        private int? mQtyNotShipped;
        private int? mQtyOrderedPrior;
        private int? mQtyPicked;
        private DateTime? mShipDate;
        private string mUserType;

        public OrderDetailReportInfo()
        {
        }

        public OrderDetailReportInfo(string externalorderid, string custorderno, DateTime? orderwhen, DateTime? shipdate, string firstname, string lastname, string usertype, string itemid, string productname, int? qtypicked, int? qtyorderprior, int? qtynotshipped, DateTime? begsnapshot, DateTime? endshapshot)
        {
            this.mExternalOrderId = externalorderid;
            this.mCustOrderNo = custorderno;
            this.mOrderWhen = orderwhen;
            this.mShipDate = shipdate;
            this.mFirstName = firstname;
            this.mLastName = lastname;
            this.mUserType = usertype;
            this.mItemId = itemid;
            this.mProductName = productname;
            this.mQtyPicked = qtypicked;
            this.mQtyOrderedPrior = qtyorderprior;
            this.mQtyNotShipped = qtynotshipped;
            this.mBegSnapshot = begsnapshot;
            this.mEndSnapshot = endshapshot;
        }

        public DateTime? BegSnapshot
        {
            get
            {
                return this.mBegSnapshot;
            }
            set
            {
                this.mBegSnapshot = value;
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

        public DateTime? EndSnapshot
        {
            get
            {
                return this.mEndSnapshot;
            }
            set
            {
                this.mEndSnapshot = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
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

        public int? QtyNotShipped
        {
            get
            {
                return this.mQtyNotShipped;
            }
            set
            {
                this.mQtyNotShipped = value;
            }
        }

        public int? QtyOrderedPrior
        {
            get
            {
                return this.mQtyOrderedPrior;
            }
            set
            {
                this.mQtyOrderedPrior = value;
            }
        }

        public int? QtyPicked
        {
            get
            {
                return this.mQtyPicked;
            }
            set
            {
                this.mQtyPicked = value;
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

