namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class InventorySnapshotInfo : Info
    {
        private DateTime? mBegDate;
        private int? mBegQty;
        private bool? mBegSnapshotExists;
        private string mDeptName;
        private DateTime? mEndDate;
        private int? mEndQty;
        private bool? mEndSnapshotExists;
        private string mItemId;
        private string mProductName;
        private int? mStoreId;
        private string mSubDeptName;
        private InventoryTransactionInfo[] mTransactions;

        public InventorySnapshotInfo()
        {
        }

        public InventorySnapshotInfo(int? storeid, string itemid, string productname, string deptname, string subdeptname, bool? begsnapshotexists, int? begqty, DateTime? begdate, bool? endshapshotexists, int? endqty, DateTime? enddate) : base(false)
        {
            this.mStoreId = storeid;
            this.mItemId = itemid;
            this.mProductName = productname;
            this.mDeptName = deptname;
            this.mSubDeptName = subdeptname;
            this.mBegSnapshotExists = begsnapshotexists;
            this.mBegQty = begqty;
            this.mBegDate = begdate;
            this.mEndSnapshotExists = endshapshotexists;
            this.mEndQty = endqty;
            this.mEndDate = enddate;
        }

        public DateTime? BegDate
        {
            get
            {
                return this.mBegDate;
            }
            set
            {
                this.mBegDate = value;
            }
        }

        public int? BegQty
        {
            get
            {
                return this.mBegQty;
            }
            set
            {
                this.mBegQty = value;
            }
        }

        public bool? BegSnapshotExists
        {
            get
            {
                return this.mBegSnapshotExists;
            }
            set
            {
                this.mBegSnapshotExists = value;
            }
        }

        public string DeptName
        {
            get
            {
                return this.mDeptName;
            }
            set
            {
                this.mDeptName = value;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return this.mEndDate;
            }
            set
            {
                this.mEndDate = value;
            }
        }

        public int? EndQty
        {
            get
            {
                return this.mEndQty;
            }
            set
            {
                this.mEndQty = value;
            }
        }

        public bool? EndSnapshotExists
        {
            get
            {
                return this.mEndSnapshotExists;
            }
            set
            {
                this.mEndSnapshotExists = value;
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

        public string SubDeptName
        {
            get
            {
                return this.mSubDeptName;
            }
            set
            {
                this.mSubDeptName = value;
            }
        }

        public InventoryTransactionInfo[] Transactions
        {
            get
            {
                return this.mTransactions;
            }
            set
            {
                this.mTransactions = value;
            }
        }
    }
}

