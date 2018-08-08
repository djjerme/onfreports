namespace PBA.OnfInfo
{
    using System;

    public class PrintShopTransactionInfo
    {
        private string mComments;
        private DateTime? mDateCreated;
        private bool? mEmailSent;
        private string mItemId;
        private DateTime? mNeedDate;
        private int? mOrderId;
        private int? mOrderStatus;
        private string mOrderStatusName;
        private int? mOrderSuffix;
        private int? mOrderType;
        private string mOrderTypeName;
        private int? mPrintOrderId;
        private int? mPrintShopId;
        private string mProductName;
        private int? mQuantity;
        private int? mStoreId;
        private string mStoreName;

        public PrintShopTransactionInfo()
        {
        }

        public PrintShopTransactionInfo(int? printorderid, int? printshopid, int? ordertype, string ordertypename, int? storeid, int? orderid, int? ordersuffix, bool? emailsent, int? orderstatus, string orderstatusname, string itemid, DateTime? datecreated, int? quantity, string storename, string productname, DateTime? needdate, string comments)
        {
            this.mPrintOrderId = printorderid;
            this.mPrintShopId = printshopid;
            this.mOrderType = ordertype;
            this.mOrderTypeName = ordertypename;
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mEmailSent = emailsent;
            this.mOrderStatus = orderstatus;
            this.mOrderStatusName = orderstatusname;
            this.mItemId = itemid;
            this.mDateCreated = datecreated;
            this.mQuantity = quantity;
            this.mStoreName = storename;
            this.mProductName = productname;
            this.mNeedDate = needdate;
            this.mComments = comments;
        }

        public string Comments
        {
            get
            {
                return this.mComments;
            }
            set
            {
                this.mComments = value;
            }
        }

        public string CustomerOrderNumber
        {
            get
            {
                if (this.mOrderType == 2)
                {
                    return string.Format("{0}-{1}-{2}", this.mStoreId, this.mOrderId, this.mOrderSuffix);
                }
                return "";
            }
        }

        public DateTime? DateCreated
        {
            get
            {
                return this.mDateCreated;
            }
            set
            {
                this.mDateCreated = value;
            }
        }

        public bool? EmailSent
        {
            get
            {
                return this.mEmailSent;
            }
            set
            {
                this.mEmailSent = value;
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

        public int? OrderStatus
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

        public string OrderStatusName
        {
            get
            {
                return this.mOrderStatusName;
            }
            set
            {
                this.mOrderStatusName = value;
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

        public int? OrderType
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

        public string OrderTypeName
        {
            get
            {
                return this.mOrderTypeName;
            }
            set
            {
                this.mOrderTypeName = value;
            }
        }

        public int? PrintOrderId
        {
            get
            {
                return this.mPrintOrderId;
            }
            set
            {
                this.mPrintOrderId = value;
            }
        }

        public int? PrintShopId
        {
            get
            {
                return this.mPrintShopId;
            }
            set
            {
                this.mPrintShopId = value;
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
    }
}

