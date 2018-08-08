namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class OrderExportItemSettingsInfo : Info
    {
        private bool? mExcludeFromProcess;
        private bool? mIsDefined;
        private string mItemId;
        private string mLayoutFilename;
        private int? mMaxCount;
        private int? mOrderLimitMechanism;
        private string mProductName;
        private int? mStoreId;

        public OrderExportItemSettingsInfo()
        {
        }

        public OrderExportItemSettingsInfo(int? storeid, string itemid, string productname, int? orderlimitmechanism, bool? excludefromprocess, int? maxcount, string layoutfilename, bool? isdefined) : base(false)
        {
            this.mStoreId = storeid;
            this.mItemId = itemid;
            this.mProductName = productname;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mExcludeFromProcess = excludefromprocess;
            this.mMaxCount = maxcount;
            this.mLayoutFilename = layoutfilename;
            this.mIsDefined = isdefined;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || (base.GetType() != obj.GetType()))
            {
                return false;
            }
            OrderExportItemSettingsInfo info = (OrderExportItemSettingsInfo) obj;
            int? storeId = this.StoreId;
            int? orderLimitMechanism = info.StoreId;
            if (((storeId.GetValueOrDefault() == orderLimitMechanism.GetValueOrDefault()) && (storeId.HasValue == orderLimitMechanism.HasValue)) && (this.ItemId == info.ItemId))
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

        public bool? IsDefined
        {
            get
            {
                return this.mIsDefined;
            }
            set
            {
                this.mIsDefined = value;
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
    }
}

