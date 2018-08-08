namespace PBA.OnfInfo
{
    using System;

    public class LanguageInfo
    {
        private string mLanguageCode;
        private string mName;
        private int? mStoreId;

        public LanguageInfo()
        {
        }

        public LanguageInfo(int? storeid, string languagecode, string Name)
        {
            this.mStoreId = storeid;
            this.mLanguageCode = languagecode;
            this.mName = Name;
        }

        public string LanguageCode
        {
            get
            {
                return this.mLanguageCode;
            }
            set
            {
                this.mLanguageCode = value;
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

