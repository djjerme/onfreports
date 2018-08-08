namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class SynderoReconciliationReportInfo
    {
        private string mConvertedItemId;
        private DateTime? mImportDate;
        private string mItemId;
        private string mProductName;
        private int? mQtyDropped;
        private int? mQtyImported;
        private int? mQtyShipped;
        private int? mQtyUnresolved;
        private int? mStoreId;
        private DateTime? mWorkDate;

        public SynderoReconciliationReportInfo()
        {
        }

        public SynderoReconciliationReportInfo(int? storeid, DateTime? importdate, DateTime? workdate, string itemid, string converteditemid, string productname, int? qtyimported, int? qtyshipped, int? qtydropped, int? qtyunresolved)
        {
            this.mStoreId = storeid;
            this.mImportDate = importdate;
            this.mWorkDate = workdate;
            this.mItemId = itemid;
            this.mConvertedItemId = converteditemid;
            this.mProductName = productname;
            this.mQtyImported = qtyimported;
            this.mQtyShipped = qtyshipped;
            this.mQtyDropped = qtydropped;
            this.mQtyUnresolved = qtyunresolved;
        }

        public string ConvertedItemId
        {
            get
            {
                return this.mConvertedItemId;
            }
            set
            {
                this.mConvertedItemId = value;
            }
        }

        public DateTime? ImportDate
        {
            get
            {
                return this.mImportDate;
            }
            set
            {
                this.mImportDate = value;
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

        public int? QtyDropped
        {
            get
            {
                return this.mQtyDropped;
            }
            set
            {
                this.mQtyDropped = value;
            }
        }

        public int? QtyImported
        {
            get
            {
                return this.mQtyImported;
            }
            set
            {
                this.mQtyImported = value;
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

        public int? QtyUnresolved
        {
            get
            {
                return this.mQtyUnresolved;
            }
            set
            {
                this.mQtyUnresolved = value;
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

        public DateTime? WorkDate
        {
            get
            {
                return this.mWorkDate;
            }
            set
            {
                this.mWorkDate = value;
            }
        }
    }
}

