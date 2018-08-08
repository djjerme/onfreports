namespace PBA.OnfInfo
{
    using System;
    using System.Text.RegularExpressions;

    [Serializable]
    public class DepartmentInfo
    {
        private bool? mActiveFlag;
        private int? mDeptId;
        private string mDescrip;
        private bool? mImageFlag;
        private string mName;
        private int? mSqn;
        private int? mStoreId;
        private SubDepartmentInfo[] mSubDepartments;
        private string mTextColor;
        private bool? mThumbImageFlag;

        public DepartmentInfo()
        {
        }

        public DepartmentInfo(int? storeid, int? deptid, string name, string descrip, string textcolor, int? sqn, bool? activeflag, bool? imageflag, bool? thumbimageflag, SubDepartmentInfo[] subdepartments)
        {
            this.mStoreId = storeid;
            this.mDeptId = deptid;
            this.mName = name;
            this.mDescrip = descrip;
            this.mTextColor = textcolor;
            this.mSqn = sqn;
            this.mActiveFlag = activeflag;
            this.mImageFlag = imageflag;
            this.mThumbImageFlag = thumbimageflag;
            this.mSubDepartments = subdepartments;
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

        public SubDepartmentInfo[] SubDepartments
        {
            get
            {
                return this.mSubDepartments;
            }
            set
            {
                this.mSubDepartments = value;
            }
        }

        public string TextColor
        {
            get
            {
                return this.mTextColor;
            }
            set
            {
                this.mTextColor = value;
            }
        }

        public bool? ThumbImageFlag
        {
            get
            {
                return this.mThumbImageFlag;
            }
            set
            {
                this.mThumbImageFlag = value;
            }
        }

        public enum SortColumn
        {
            DeptId,
            Name,
            Sqn
        }
    }
}

