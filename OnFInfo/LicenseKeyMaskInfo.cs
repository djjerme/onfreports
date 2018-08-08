namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LicenseKeyMaskInfo : Info
    {
        private string mLicenseKeyMask;
        private string mLicenseKeyType;
        private int? mStoreId;

        public LicenseKeyMaskInfo()
        {
        }

        public LicenseKeyMaskInfo(int? storeid, string licensekeytype, string licensekeymask) : base(true)
        {
            this.mStoreId = storeid;
            this.mLicenseKeyType = licensekeytype;
            this.mLicenseKeyMask = licensekeymask;
        }

        public string LicenseKeyMask
        {
            get
            {
                return this.mLicenseKeyMask;
            }
            set
            {
                this.mLicenseKeyMask = value;
            }
        }

        public string LicenseKeyType
        {
            get
            {
                return this.mLicenseKeyType;
            }
            set
            {
                this.mLicenseKeyType = value;
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

