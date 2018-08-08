namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class CountryInfo
    {
        private string mCapital;
        private string mCode;
        private int? mCountryId;
        private bool? mEmbargoFlag;
        private string mLongName;
        private string mName;

        public CountryInfo()
        {
        }

        public CountryInfo(int? countryid, string code, string name, string longname, string capital, bool? embargoflag)
        {
            this.mCountryId = countryid;
            this.mCode = code;
            this.mName = name;
            this.mLongName = longname;
            this.mCapital = capital;
            this.mEmbargoFlag = embargoflag;
        }

        public string Capital
        {
            get
            {
                return this.mCapital;
            }
            set
            {
                this.mCapital = value;
            }
        }

        public string Code
        {
            get
            {
                return this.mCode;
            }
            set
            {
                this.mCode = value;
            }
        }

        public int? CountryId
        {
            get
            {
                return this.mCountryId;
            }
            set
            {
                this.mCountryId = value;
            }
        }

        public bool? EmbargoFlag
        {
            get
            {
                return this.mEmbargoFlag;
            }
            set
            {
                this.mEmbargoFlag = value;
            }
        }

        public string LongName
        {
            get
            {
                return this.mLongName;
            }
            set
            {
                this.mLongName = value;
            }
        }

        public string Name
        {
            get
            {
                return this.mName;
            }
            set
            {
                this.mName = value;
            }
        }
    }
}

