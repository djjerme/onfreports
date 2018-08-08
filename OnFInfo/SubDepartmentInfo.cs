namespace PBA.OnfInfo
{
    using System;
    using System.Text.RegularExpressions;

    [Serializable]
    public class SubDepartmentInfo
    {
        private bool? mActiveFlag;
        private int? mDeptId;
        private string mDescrip;
        private bool? mImageFlag;
        private string mItemPageView;
        private string mName;
        private int? mSqn;
        private int? mStoreId;
        private int? mSubDeptId;

        public SubDepartmentInfo()
        {
        }

        public SubDepartmentInfo(int? storeid, int? deptid, int? subdeptid, string name, string descrip, string itempageview, int? sqn, bool? activeflag, bool? imageflag)
        {
            this.mStoreId = storeid;
            this.mDeptId = deptid;
            this.mSubDeptId = subdeptid;
            this.mName = name;
            this.mDescrip = descrip;
            this.mItemPageView = itempageview;
            this.mSqn = sqn;
            this.mActiveFlag = activeflag;
            this.mImageFlag = imageflag;
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

        public string Descrip
        {
            get
            {
                return this.mDescrip;
            }
            set
            {
                this.mDescrip = value;
            }
        }

        public bool? ImageFlag
        {
            get
            {
                return this.mImageFlag;
            }
            set
            {
                this.mImageFlag = value;
            }
        }

        public string ItemPageView
        {
            get
            {
                return this.mItemPageView;
            }
            set
            {
                this.mItemPageView = value;
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

        public string NameDecoded
        {
            get
            {
                Regex regex = new Regex("<[^>]*>");
                return regex.Replace(this.mName, "");
            }
        }

        public int? Sqn
        {
            get
            {
                return this.mSqn;
            }
            set
            {
                this.mSqn = value;
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

        public enum SortColumn
        {
            Name,
            Sqn,
            SubDeptId
        }
    }
}

