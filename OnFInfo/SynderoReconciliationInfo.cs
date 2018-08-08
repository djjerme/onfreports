using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PBA.OnfInfo
{
    /// <summary>
    /// This class contains data elements associated with 
    /// the SynderoReconciliation Report. 
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = "PBA.OnfInfo")]
    public class SynderoReconciliationReportInfo
    {

        #region Member Variables
        private int? mStoreId;
        private DateTime? mImportDate;
        private DateTime? mWorkDate;
        private string mItemId;
        private string mConvertedItemId;
        private string mProductName;
        private int? mQtyImported;
        private int? mQtyShipped;
        private int? mQtyDropped;
        private int? mQtyUnresolved;

        #endregion

        #region Constructors
        public SynderoReconciliationReportInfo()
        {
        }

        public SynderoReconciliationReportInfo(int? storeid, DateTime? importdate, DateTime? workdate,
            string itemid, string converteditemid, string productname, int? qtyimported, int? qtyshipped, 
            int? qtydropped, int? qtyunresolved)
        {
            mStoreId = storeid;
            mImportDate = importdate;
            mWorkDate = workdate;
            mItemId = itemid;
            mConvertedItemId = converteditemid;
            mProductName = productname;
            mQtyImported = qtyimported;
            mQtyShipped = qtyshipped;
            mQtyDropped = qtydropped;
            mQtyUnresolved = qtyunresolved;
        }

        #endregion

        #region Properties
        [XmlElement(Namespace = "PBA.OnfInfo")]
        public int? StoreId
        {
            get { return mStoreId; }
            set { mStoreId = value; }
        }
        public DateTime? ImportDate
        {
            get { return mImportDate; }
            set { mImportDate = value; }
        }
        public DateTime? WorkDate
        {
            get { return mWorkDate; }
            set { mWorkDate = value; }
        }
        public string ItemId
        {
            get { return mItemId; }
            set { mItemId = value; }
        }
        public string ConvertedItemId
        {
            get { return mConvertedItemId; }
            set { mConvertedItemId = value; }
        }
        public string ProductName
        {
            get { return mProductName; }
            set { mProductName = value; }
        }
        public int? QtyImported
        {
            get { return mQtyImported; }
            set { mQtyImported = value; }
        }

        public int? QtyShipped
        {
            get { return mQtyShipped; }
            set { mQtyShipped = value; }
        }

        public int? QtyDropped
        {
            get { return mQtyDropped; }
            set { mQtyDropped = value; }
        }

        public int? QtyUnresolved
        {
            get { return mQtyUnresolved; }
            set { mQtyUnresolved = value; }
        }

        #endregion
    }
}
