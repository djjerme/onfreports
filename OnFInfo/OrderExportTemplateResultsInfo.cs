namespace PBA.OnfInfo
{
    using System;

    public class OrderExportTemplateResultsInfo : Info
    {
        private bool? mExcludeFromProcess;
        private bool? mExcludeFromProcessOverride;
        private int? mItemCount;
        private string mItemId;
        private int? mMaxCount;
        private int? mMaxCountOverride;
        private int? mOrderLimitMechanism;
        private int? mOrderLimitMechanismOverride;
        private bool? mOverride;
        private DateTime? mRunDatetime;
        private int? mStoreId;
        private int? mTemplateCount;
        private string mTemplateId;

        public OrderExportTemplateResultsInfo()
        {
        }

        public OrderExportTemplateResultsInfo(int? storeid, DateTime? rundatetime, string templateid, bool? _override, bool? excludefromprocess, int? orderlimitmechanism, int? maxcount, bool? excludefromprocessoverride, int? orderlimitmechanismoverride, int? maxcountoverride, int? templatecount, string itemid, int? itemcount) : base(false)
        {
            this.mStoreId = storeid;
            this.mRunDatetime = rundatetime;
            this.mTemplateId = templateid;
            this.mOverride = _override;
            this.mExcludeFromProcess = excludefromprocess;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mMaxCount = maxcount;
            this.mExcludeFromProcessOverride = excludefromprocessoverride;
            this.mOrderLimitMechanismOverride = orderlimitmechanismoverride;
            this.mMaxCountOverride = maxcountoverride;
            this.mTemplateCount = templatecount;
            this.mItemId = itemid;
            this.mItemCount = itemcount;
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

        public int? ItemCount
        {
            get
            {
                return this.mItemCount;
            }
            set
            {
                this.mItemCount = value;
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
                return null;
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

        public int? TemplateCount
        {
            get
            {
                return this.mTemplateCount;
            }
            set
            {
                this.mTemplateCount = value;
            }
        }

        public string TemplateId
        {
            get
            {
                return this.mTemplateId;
            }
            set
            {
                this.mTemplateId = value;
            }
        }
    }
}

