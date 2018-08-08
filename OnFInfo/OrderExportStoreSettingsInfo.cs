namespace PBA.OnfInfo
{
    using System;

    public class OrderExportStoreSettingsInfo : Info
    {
        private int? mAggregateMaxCount;
        private bool? mFridayRun;
        private int? mFridayRunAsof;
        private bool? mMondayRun;
        private int? mMondayRunAsof;
        private int? mOrderLimitMechanism;
        private bool? mSaturdayRun;
        private int? mSaturdayRunAsof;
        private int? mStoreId;
        private string mStoreName;
        private bool? mSundayRun;
        private int? mSundayRunAsof;
        private bool? mThursdayRun;
        private int? mThursdayRunAsof;
        private bool? mTuesdayRun;
        private int? mTuesdayRunAsof;
        private bool? mWednesdayRun;
        private int? mWednesdayRunAsof;

        public OrderExportStoreSettingsInfo()
        {
        }

        public OrderExportStoreSettingsInfo(int? storeid, string storename, int? orderlimitmechanism, int? aggregatemaxcount, bool? sundayrun, bool? mondayrun, bool? tuesdayrun, bool? wednesdayrun, bool? thursdayrun, bool? fridayrun, bool? saturdayrun, int? sundayrunasof, int? mondayrunasof, int? tuesdayrunasof, int? wednesdayrunasof, int? thursdayrunasof, int? fridayrunasof, int? saturdayrunasof) : base(false)
        {
            this.mStoreId = storeid;
            this.mStoreName = storename;
            this.mOrderLimitMechanism = orderlimitmechanism;
            this.mAggregateMaxCount = aggregatemaxcount;
            this.mSundayRun = sundayrun;
            this.mMondayRun = mondayrun;
            this.mTuesdayRun = tuesdayrun;
            this.mWednesdayRun = wednesdayrun;
            this.mThursdayRun = thursdayrun;
            this.mFridayRun = fridayrun;
            this.mSaturdayRun = saturdayrun;
            this.mSundayRunAsof = sundayrunasof;
            this.mMondayRunAsof = mondayrunasof;
            this.mTuesdayRunAsof = tuesdayrunasof;
            this.mWednesdayRunAsof = wednesdayrunasof;
            this.mThursdayRunAsof = thursdayrunasof;
            this.mFridayRunAsof = fridayrunasof;
            this.mSaturdayRunAsof = saturdayrunasof;
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

        public bool? FridayRun
        {
            get
            {
                return this.mFridayRun;
            }
            set
            {
                this.mFridayRun = value;
            }
        }

        public int? FridayRunAsof
        {
            get
            {
                return this.mFridayRunAsof;
            }
            set
            {
                this.mFridayRunAsof = value;
            }
        }

        public bool? MondayRun
        {
            get
            {
                return this.mMondayRun;
            }
            set
            {
                this.mMondayRun = value;
            }
        }

        public int? MondayRunAsof
        {
            get
            {
                return this.mMondayRunAsof;
            }
            set
            {
                this.mMondayRunAsof = value;
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

        public bool? SaturdayRun
        {
            get
            {
                return this.mSaturdayRun;
            }
            set
            {
                this.mSaturdayRun = value;
            }
        }

        public int? SaturdayRunAsof
        {
            get
            {
                return this.mSaturdayRunAsof;
            }
            set
            {
                this.mSaturdayRunAsof = value;
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

        public string StoreName
        {
            get
            {
                return this.mStoreName;
            }
            set
            {
                this.mStoreName = value;
            }
        }

        public bool? SundayRun
        {
            get
            {
                return this.mSundayRun;
            }
            set
            {
                this.mSundayRun = value;
            }
        }

        public int? SundayRunAsof
        {
            get
            {
                return this.mSundayRunAsof;
            }
            set
            {
                this.mSundayRunAsof = value;
            }
        }

        public bool? ThursdayRun
        {
            get
            {
                return this.mThursdayRun;
            }
            set
            {
                this.mThursdayRun = value;
            }
        }

        public int? ThursdayRunAsof
        {
            get
            {
                return this.mThursdayRunAsof;
            }
            set
            {
                this.mThursdayRunAsof = value;
            }
        }

        public bool? TuesdayRun
        {
            get
            {
                return this.mTuesdayRun;
            }
            set
            {
                this.mTuesdayRun = value;
            }
        }

        public int? TuesdayRunAsof
        {
            get
            {
                return this.mTuesdayRunAsof;
            }
            set
            {
                this.mTuesdayRunAsof = value;
            }
        }

        public bool? WednesdayRun
        {
            get
            {
                return this.mWednesdayRun;
            }
            set
            {
                this.mWednesdayRun = value;
            }
        }

        public int? WednesdayRunAsof
        {
            get
            {
                return this.mWednesdayRunAsof;
            }
            set
            {
                this.mWednesdayRunAsof = value;
            }
        }
    }
}

