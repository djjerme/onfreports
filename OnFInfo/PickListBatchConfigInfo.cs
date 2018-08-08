namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class PickListBatchConfigInfo
    {
        private int mBatchConfigID;
        private string mBatchConfigName;
        private int mFri;
        private int mMon;
        private int mSat;
        private DateTime mStartBatchTime;
        private int mSun;
        private int mThur;
        private int mTue;
        private int mWed;

        [XmlElement(Namespace="PBA.OnfInfo")]
        public int BatchConfigID
        {
            get
            {
                return this.mBatchConfigID;
            }
            set
            {
                this.mBatchConfigID = value;
            }
        }

        public string BatchConfigName
        {
            get
            {
                return this.mBatchConfigName;
            }
            set
            {
                this.mBatchConfigName = value;
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

        public DateTime StartBatchTime
        {
            get
            {
                return this.mStartBatchTime;
            }
            set
            {
                this.mStartBatchTime = value;
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

