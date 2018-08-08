namespace PBA.OnfInfo
{
    using System;

    public class OrderExportItemResultsInfo : Info
    {
        private bool? mExcludeFromProcess;
        private bool? mExcludeFromProcessOverride;
        private string mItemId;
        private int? mMaxCount;
        private int? mMaxCountOverride;
        private int? mOrderLimitMechanism;
        private int? mOrderLimitMechanismOverride;
        private bool? mOverride;
        private int? mQtyAvailable;
        private int? mQtyExported;
        private DateTime? mRunDatetime;
        private int? mStoreId;

        public OrderExportItemResultsInfo()
        {
        }

        public OrderExportItemResultsInfo(int? storeid, DateTime? rundatetime, string itemid, bool? _override, bool? excludefromprocess, int? orderlimitmechanism, int? maxcount, bool? excludefromprocessoverride, int? orderlimitmechanismoverride, int? maxcountoverride, int? qtyavailable, int? qtyexported) : base(false)
        {
            this.mStoreId = storeid;
            this.mRunDatetime = rundatetime;
            this.mItemId = itemid;
            this.mOverride = _override;
            this.mExcludeFromProcess = excludefromprocess;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mMaxCount = maxcount;
            this.mExcludeFromProcessOverride = excludefromprocessoverride;
            this.mOrderLimitMechanismOverride = orderlimitmechanismoverride;
            this.mMaxCountOverride = maxcountoverride;
            this.mQtyAvailable = qtyavailable;
            this.mQtyExported = qtyexported;
        }

        public bool? ExcludeFromProcess
        {
            get
            {
                return this.mExcludeFromProcess;
            }
            set
            {
                this.mExcludeFromProcess = value;
            }
        }

        public bool? ExcludeFromProcessOverride
        {
            get
            {
                return this.mExcludeFromProcessOverride;
            }
            set
            {
                this.mExcludeFromProcessOverride = value;
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

        public int? MaxCount
        {
            get
            {
                return this.mMaxCount;
            }
            set
            {
                this.mMaxCount = value;
            }
        }

        public int? MaxCountOverride
        {
            get
            {
                return this.mMaxCountOverride;
            }
            set
            {
                this.mMaxCountOverride = value;
            }
        }

        public int? OrderLimitMechanism
        {
            get
            {
                return this.mOrderLimitMechanism;
            }
            set
            {
                this.mOrderLimitMechanism = value;
            }
        }

        public int? OrderLimitMechanismOverride
        {
            get
            {
                return this.mOrderLimitMechanismOverride;
            }
            set
            {
                this.mOrderLimitMechanismOverride = value;
            }
        }

        public bool? Override
        {
            get
            {
                return this.mOverride;
            }
            set
            {
                this.mOverride = value;
            }
        }

        public int? QtyAvailable
        {
            get
            {
                return this.mQtyAvailable;
            }
            set
            {
                this.mQtyAvailable = value;
            }
        }

        public int? QtyExported
        {
            get
            {
                return this.mQtyExported;
            }
            set
            {
                this.mQtyExported = value;
            }
        }

        public DateTime? RunDatetime
        {
            get
            {
                return this.mRunDatetime;
            }
            set
            {
                this.mRunDatetime = value;
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
    }
}

