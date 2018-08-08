namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class OrderShippingDetailInfo
    {
        private DateTime? mNeedDate;
        private int? mOrderId;
        private int? mOrderSuffix;
        private DateTime? mOrderWhen;
        private DateTime? mPickDate;
        private string mRequestedShipMethod;
        private string mShipLabelComment;
        private int? mStoreId;
        private string mStoreName;
        private int? mUrgencyCode;

        public OrderShippingDetailInfo()
        {
        }

        public OrderShippingDetailInfo(int? storeid, int? orderid, int? ordersuffix, DateTime? orderwhen, DateTime? pickdate, DateTime? needdate, string requestedshipmethod, string shiplabelcomment, string storename, int? urgencycode)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mOrderWhen = orderwhen;
            this.mPickDate = pickdate;
            this.mNeedDate = needdate;
            this.mRequestedShipMethod = requestedshipmethod;
            this.mShipLabelComment = shiplabelcomment;
            this.mStoreName = storename;
            this.mUrgencyCode = urgencycode;
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

        public string OrderNumber
        {
            get
            {
                return string.Format("{0}-{1}-{2}", this.mStoreId, this.mOrderId, this.mOrderSuffix);
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

        public DateTime? PickDate
        {
            get
            {
                return this.mPickDate;
            }
            set
            {
                this.mPickDate = value;
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

        public int? UrgencyCode
        {
            get
            {
                return this.mUrgencyCode;
            }
            set
            {
                this.mUrgencyCode = value;
            }
        }
    }
}

