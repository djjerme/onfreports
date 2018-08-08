namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class DeptProductInfo
    {
        private bool? mActiveFlag;
        private int? mDeptId;
        private string mDeptName;
        private int? mProductId;
        private int? mSequence;
        private int? mStoreId;
        private int? mSubDeptId;
        private string mSubDeptName;

        public DeptProductInfo()
        {
        }

        public DeptProductInfo(int? storeid, int? deptid, int? subdeptid, int? productid, int? sequence, bool? activeflag, string deptname, string subdeptname)
        {
            this.mStoreId = storeid;
            this.mDeptId = deptid;
            this.mSubDeptId = subdeptid;
            this.mProductId = productid;
            this.mSequence = sequence;
            this.mActiveFlag = activeflag;
            this.mDeptName = deptname;
            this.mSubDeptName = subdeptname;
        }

        public bool? ActiveFlag
        {
            get
            {
                return this.mActiveFlag;
            }
            set
            {
                this.mActiveFlag = value;
            }
        }

        public int? DeptId
        {
            get
            {
                return this.mDeptId;
            }
            set
            {
                this.mDeptId = value;
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

        public int? ProductId
        {
            get
            {
                return this.mProductId;
            }
            set
            {
                this.mProductId = value;
            }
        }

        public int? Sequence
        {
            get
            {
                return this.mSequence;
            }
            set
            {
                this.mSequence = value;
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

        public int? SubDeptId
        {
            get
            {
                return this.mSubDeptId;
            }
            set
            {
                this.mSubDeptId = value;
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
    }
}

