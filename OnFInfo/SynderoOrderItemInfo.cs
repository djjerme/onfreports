namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class SynderoOrderItemInfo
    {
        private string mCustom1;
        private string mCustom2;
        private string mCustom3;
        private string mItemDescription;
        private string mItemId;
        private int? mLineNo;
        private int? mOrderId;
        private int? mOrderSuffix;
        private int? mQuantity;
        private int? mShipWeight;
        private int? mStoreId;
        private double? mUnitPrice;

        public SynderoOrderItemInfo()
        {
        }

        public SynderoOrderItemInfo(int? storeid, int? orderid, int? ordersuffix, int? lineno, string itemid, string itemdescription, int? shipweight, int? quantity, double? unitprice, string custom1, string custom2, string custom3)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mLineNo = lineno;
            this.mItemId = itemid;
            this.mItemDescription = itemdescription;
            this.mShipWeight = shipweight;
            this.mQuantity = quantity;
            this.mUnitPrice = unitprice;
            this.mCustom1 = custom1;
            this.mCustom2 = custom2;
            this.mCustom3 = custom3;
        }

        public string Custom1
        {
            get
            {
                return this.mCustom1;
            }
            set
            {
                this.mCustom1 = value;
            }
        }

        public string Custom2
        {
            get
            {
                return this.mCustom2;
            }
            set
            {
                this.mCustom2 = value;
            }
        }

        public string Custom3
        {
            get
            {
                return this.mCustom3;
            }
            set
            {
                this.mCustom3 = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return this.mItemDescription;
            }
            set
            {
                this.mItemDescription = value;
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

        public int? Quantity
        {
            get
            {
                return this.mQuantity;
            }
            set
            {
                this.mQuantity = value;
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

        public double? UnitPrice
        {
            get
            {
                return this.mUnitPrice;
            }
            set
            {
                this.mUnitPrice = value;
            }
        }
    }
}

