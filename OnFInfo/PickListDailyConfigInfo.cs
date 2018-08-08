namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class PickListDailyConfigInfo
    {
        private int mDailyConfigID;
        private string mDailyConfigName;
        private int mDailyHourDelay;
        private int mDailyMinuteDelay;
        private DateTime mEndofBusiness;
        private int mFri;
        private int mMon;
        private int mSat;
        private DateTime mStartofBusiness;
        private int mSun;
        private int mThur;
        private int mTue;
        private int mWed;

        [XmlElement(Namespace="PBA.OnfInfo")]
        public int DailyConfigID
        {
            get
            {
                return this.mDailyConfigID;
            }
            set
            {
                this.mDailyConfigID = value;
            }
        }

        public string DailyConfigName
        {
            get
            {
                return this.mDailyConfigName;
            }
            set
            {
                this.mDailyConfigName = value;
            }
        }

        public int DailyHourDelay
        {
            get
            {
                return this.mDailyHourDelay;
            }
            set
            {
                this.mDailyHourDelay = value;
            }
        }

        public int DailyMinuteDelay
        {
            get
            {
                return this.mDailyMinuteDelay;
            }
            set
            {
                this.mDailyMinuteDelay = value;
            }
        }

        public DateTime EndofBusiness
        {
            get
            {
                return this.mEndofBusiness;
            }
            set
            {
                this.mEndofBusiness = value;
            }
        }

        public int Fri
        {
            get
            {
                return this.mFri;
            }
            set
            {
                this.mFri = value;
            }
        }

        public int Mon
        {
            get
            {
                return this.mMon;
            }
            set
            {
                this.mMon = value;
            }
        }

        public int Sat
        {
            get
            {
                return this.mSat;
            }
            set
            {
                this.mSat = value;
            }
        }

        public DateTime StartofBusiness
        {
            get
            {
                return this.mStartofBusiness;
            }
            set
            {
                this.mStartofBusiness = value;
            }
        }

        public int Sun
        {
            get
            {
                return this.mSun;
            }
            set
            {
                this.mSun = value;
            }
        }

        public int Thur
        {
            get
            {
                return this.mThur;
            }
            set
            {
                this.mThur = value;
            }
        }

        public int Tue
        {
            get
            {
                return this.mTue;
            }
            set
            {
                this.mTue = value;
            }
        }

        public int Wed
        {
            get
            {
                return this.mWed;
            }
            set
            {
                this.mWed = value;
            }
        }
    }
}

