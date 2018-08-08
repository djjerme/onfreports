namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    public class ShipOrderLineInfo
    {
        private string mItemId;
        private int? mLineNo;
        private string mName;
        private int? mOrderId;
        private int? mOrderSuffix;
        private int? mQtyOrdered;
        private int? mQtyShipped;
        private int? mShipWeight;
        private string mShortDesc;
        private int? mStoreId;

        public ShipOrderLineInfo()
        {
        }

        public ShipOrderLineInfo(int? storeid, int? orderid, int? ordersuffix, int? lineno, string itemid, int? qtyordered, int? qtyshipped, string name, string shortdesc, int? shipweight)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mLineNo = lineno;
            this.mItemId = itemid;
            this.mQtyOrdered = qtyordered;
            this.mQtyShipped = qtyshipped;
            this.mName = name;
            this.mShortDesc = shortdesc;
            this.mShipWeight = shipweight;
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

        public int? LineNo
        {
            get
            {
                return this.mLineNo;
            }
            set
            {
                this.mLineNo = value;
            }
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

        public int? QtyOrdered
        {
            get
            {
                return this.mQtyOrdered;
            }
            set
            {
                this.mQtyOrdered = value;
            }
        }

        public int? QtyShipped
        {
            get
            {
                return this.mQtyShipped;
            }
            set
            {
                this.mQtyShipped = value;
            }
        }

        public int? ShipWeight
        {
            get
            {
                return this.mShipWeight;
            }
            set
            {
                this.mShipWeight = value;
            }
        }

        public string ShortDesc
        {
            get
            {
                return this.mShortDesc;
            }
            set
            {
                this.mShortDesc = value;
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
    }
}

