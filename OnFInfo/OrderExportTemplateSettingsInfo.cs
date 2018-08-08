namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class OrderExportTemplateSettingsInfo : Info
    {
        private bool? mExcludeFromProcess;
        private string mLayoutFilename;
        private int? mMaxCount;
        private int? mOrderLimitMechanism;
        private int? mStoreId;
        private string mTemplateId;

        public OrderExportTemplateSettingsInfo()
        {
        }

        public OrderExportTemplateSettingsInfo(int? storeid, string templateid, bool? excludefromprocess, int? orderlimitmechanism, int? maxcount, string layoutfilename) : base(false)
        {
            this.mStoreId = storeid;
            this.mTemplateId = templateid;
            this.mExcludeFromProcess = excludefromprocess;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mMaxCount = maxcount;
            this.mLayoutFilename = layoutfilename;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || (base.GetType() != obj.GetType()))
            {
                return false;
            }
            OrderExportTemplateSettingsInfo info = (OrderExportTemplateSettingsInfo) obj;
            int? storeId = this.StoreId;
            int? orderLimitMechanism = info.StoreId;
            if (((storeId.GetValueOrDefault() == orderLimitMechanism.GetValueOrDefault()) && (storeId.HasValue == orderLimitMechanism.HasValue)) && (this.TemplateId == info.TemplateId))
            {
                storeId = this.OrderLimitMechanism;
                orderLimitMechanism = info.OrderLimitMechanism;
                if (((storeId.GetValueOrDefault() == orderLimitMechanism.GetValueOrDefault()) && (storeId.HasValue == orderLimitMechanism.HasValue)) && (this.ExcludeFromProcess == info.ExcludeFromProcess))
                {
                    storeId = this.MaxCount;
                    orderLimitMechanism = info.MaxCount;
                }
            }
            return (((storeId.GetValueOrDefault() == orderLimitMechanism.GetValueOrDefault()) && (storeId.HasValue == orderLimitMechanism.HasValue)) && (this.LayoutFilename == info.LayoutFilename));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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

        public string LayoutFilename
        {
            get
            {
                return this.mLayoutFilename;
            }
            set
            {
                this.mLayoutFilename = value;
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

        public bool SettingExists
        {
            get
            {
                return this.OrderLimitMechanism.HasValue;
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

