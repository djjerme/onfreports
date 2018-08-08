namespace PBA.OnfInfo
{
    using System;

    public class OrderExportTemplateSettingsOverrideInfo
    {
        private DateTime? mDate;
        private bool? mExcludeFromProcess;
        private int? mMaxCount;
        private int? mOrderLimitMechanism;
        private int? mStoreId;
        private string mTemplateId;

        public OrderExportTemplateSettingsOverrideInfo()
        {
        }

        public OrderExportTemplateSettingsOverrideInfo(int? storeid, string templateid, DateTime? date, bool? excludefromprocess, int? orderlimitmechanism, int? maxcount)
        {
            this.mStoreId = storeid;
            this.mTemplateId = templateid;
            this.mDate = date;
            this.mExcludeFromProcess = excludefromprocess;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mMaxCount = maxcount;
        }

        public DateTime? Date
        {
            get
            {
                return this.mDate;
            }
            set
            {
                this.mDate = value;
            }
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

        public bool OverrideExists
        {
            get
            {
                return this.mStoreId.HasValue;
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

