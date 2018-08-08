namespace PBA.OnfInfo
{
    using System;

    public class OrderExportStoreResultsInfo : Info
    {
        private int? mAggregateMaxCount;
        private int? mAggregateMaxCountOverride;
        private OrderExportItemResultsInfo[] mItemResults;
        private bool? mNoRunOverride;
        private int? mOrderLimitMechanism;
        private int? mOrderLimitMechanismOverride;
        private int? mOrderType;
        private bool? mOverride;
        private DateTime? mPostageDate;
        private int? mResult;
        private string mResultText;
        private DateTime? mRunDate;
        private DateTime? mRunDatetime;
        private int? mRunType;
        private int? mStoreId;
        private int? mTotalOrdersExported;
        private int? mWeekday;
        private int? mWeekdayAsof;
        private bool? mWeekdayRun;

        public OrderExportStoreResultsInfo()
        {
        }

        public OrderExportStoreResultsInfo(int? storeid, DateTime? rundatetime, int? runtype, int? ordertype, bool? _override, int? weekday, int? weekdayasof, bool? weekdayrun, bool? norunoverride, DateTime? rundate, DateTime? postagedate, int? orderlimitmechanism, int? aggregatemaxcount, int? orderlimitmechanismoverride, int? aggregatemaxcountoverride, int? result, string resulttext, int? totalordersexported) : base(false)
        {
            this.mStoreId = storeid;
            this.mRunDatetime = rundatetime;
            this.mRunType = runtype;
            this.mOrderType = ordertype;
            this.mOverride = _override;
            this.mWeekday = weekday;
            this.mWeekdayAsof = weekdayasof;
            this.mWeekdayRun = weekdayrun;
            this.mNoRunOverride = norunoverride;
            this.mRunDate = rundate;
            this.mPostageDate = postagedate;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mAggregateMaxCount = aggregatemaxcount;
            this.mOrderLimitMechanismOverride = orderlimitmechanismoverride;
            this.mAggregateMaxCountOverride = aggregatemaxcountoverride;
            this.mResult = result;
            this.mResultText = resulttext;
            this.mTotalOrdersExported = totalordersexported;
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

        public int? AggregateMaxCountOverride
        {
            get
            {
                return this.mAggregateMaxCountOverride;
            }
            set
            {
                this.mAggregateMaxCountOverride = value;
            }
        }

        public OrderExportItemResultsInfo[] ItemResults
        {
            get
            {
                return this.mItemResults;
            }
            set
            {
                this.mItemResults = value;
            }
        }

        public bool? NoRunOverride
        {
            get
            {
                return this.mNoRunOverride;
            }
            set
            {
                this.mNoRunOverride = value;
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

        public int? OrderType
        {
            get
            {
                return this.mOrderType;
            }
            set
            {
                this.mOrderType = value;
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

        public int? Result
        {
            get
            {
                return this.mResult;
            }
            set
            {
                this.mResult = value;
            }
        }

        public string ResultText
        {
            get
            {
                return this.mResultText;
            }
            set
            {
                this.mResultText = value;
            }
        }

        public DateTime? RunDate
        {
            get
            {
                return this.mRunDate;
            }
            set
            {
                this.mRunDate = value;
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

        public int? RunType
        {
            get
            {
                return this.mRunType;
            }
            set
            {
                this.mRunType = value;
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

        public int? TotalOrdersExported
        {
            get
            {
                return this.mTotalOrdersExported;
            }
            set
            {
                this.mTotalOrdersExported = value;
            }
        }

        public int? Weekday
        {
            get
            {
                return this.mWeekday;
            }
            set
            {
                this.mWeekday = value;
            }
        }

        public int? WeekdayAsof
        {
            get
            {
                return this.mWeekdayAsof;
            }
            set
            {
                this.mWeekdayAsof = value;
            }
        }

        public bool? WeekdayRun
        {
            get
            {
                return this.mWeekdayRun;
            }
            set
            {
                this.mWeekdayRun = value;
            }
        }
    }
}

