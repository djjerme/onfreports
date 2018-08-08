namespace PBA.OnfInfo
{
    using System;

    public class OrderExportStoreSettingsOverrideInfo
    {
        private int? mAggregateMaxCount;
        private DateTime? mDate;
        private bool? mNoRun;
        private int? mOrderLimitMechanism;
        private DateTime? mPostageDate;
        private int? mStoreId;

        public OrderExportStoreSettingsOverrideInfo()
        {
        }

        public OrderExportStoreSettingsOverrideInfo(int? storeid, DateTime? date, int? orderlimitmechanism, int? aggregatemaxcount, bool? norun, DateTime? postagedate)
        {
            this.mStoreId = storeid;
            this.mDate = date;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mAggregateMaxCount = aggregatemaxcount;
            this.mNoRun = norun;
            this.mPostageDate = postagedate;
        }

        public int? AggregateMaxCount
        {
            get
            {
                return this.mAggregateMaxCount;
            }
            set
            {
                this.mAggregateMaxCount = value;
            }
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

        public bool? NoRun
        {
            get
            {
                return this.mNoRun;
            }
            set
            {
                this.mNoRun = value;
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

        public DateTime? PostageDate
        {
            get
            {
                return this.mPostageDate;
            }
            set
            {
                this.mPostageDate = value;
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

