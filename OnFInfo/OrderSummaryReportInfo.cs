namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class OrderSummaryReportInfo
    {
        private DateTime? mBegSnapshot;
        private string mDeptName;
        private DateTime? mEndSnapshot;
        private string mItemId;
        private int? mPickQty;
        private string mProductName;
        private int? mQtyNotPickedDuring;
        private int? mQtyOrdered;
        private int? mQtyOrderedBefore;
        private string mSubDeptName;
        private DateTime? mTransDate;
        private string mUserType;

        public OrderSummaryReportInfo()
        {
        }

        public OrderSummaryReportInfo(string itemid, string productname, string deptname, string subdeptname, DateTime? transdate, DateTime? begsnapshot, DateTime? endSnapshot, string usertype, int? pickqty, int? qtyordered, int? qtyorderedbefore, int? qtynotpickedduring)
        {
            this.mItemId = itemid;
            this.mProductName = productname;
            this.mDeptName = deptname;
            this.mSubDeptName = subdeptname;
            this.mTransDate = transdate;
            this.mBegSnapshot = begsnapshot;
            this.mEndSnapshot = endSnapshot;
            this.mUserType = usertype;
            this.mPickQty = pickqty;
            this.mQtyOrdered = qtyordered;
            this.mQtyOrderedBefore = qtyorderedbefore;
            this.mQtyNotPickedDuring = qtynotpickedduring;
        }

        public DateTime? BegSnapshot
        {
            get
            {
                return this.mBegSnapshot;
            }
            set
            {
                this.mBegSnapshot = value;
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

        public DateTime? EndSnapshot
        {
            get
            {
                return this.mEndSnapshot;
            }
            set
            {
                this.mEndSnapshot = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
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

        public int? PickQty
        {
            get
            {
                return this.mPickQty;
            }
            set
            {
                this.mPickQty = value;
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

        public int? QtyNotPickedDuring
        {
            get
            {
                return this.mQtyNotPickedDuring;
            }
            set
            {
                this.mQtyNotPickedDuring = value;
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

        public int? QtyOrderedBefore
        {
            get
            {
                return this.mQtyOrderedBefore;
            }
            set
            {
                this.mQtyOrderedBefore = value;
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

        public DateTime? TransDate
        {
            get
            {
                return this.mTransDate;
            }
            set
            {
                this.mTransDate = value;
            }
        }

        public string UserType
        {
            get
            {
                return this.mUserType;
            }
            set
            {
                this.mUserType = value;
            }
        }
    }
}

