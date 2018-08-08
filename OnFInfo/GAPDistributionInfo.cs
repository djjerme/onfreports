namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class GAPDistributionInfo
    {
        private string mAddress1;
        private string mAddress2;
        private string mAdult;
        private string mAreaCode;
        private string mBra;
        private string mCity;
        private string mCountry;
        private string mDistCountry;
        private string mKid;
        private int? mKitCount;
        private string mMaternity;
        private string mMerchB;
        private string mMerchG;
        private string mMerchI;
        private string mMerchK;
        private string mPhone;
        private string mShipAddress1;
        private string mShipAddress2;
        private string mShipCity;
        private string mShipCountry;
        private string mShipState;
        private string mShipZip;
        private string mSize;
        private string mSpace;
        private string mState;
        private string mStoreName;
        private string mStoreNumber;
        private string mZip;

        public GAPDistributionInfo()
        {
        }

        public GAPDistributionInfo(string distcountry, string storenumber, int? kitcount, string storename, string areacode, string phone, string address1, string address2, string space, string city, string state, string zip, string country, string shipaddress1, string shipaddress2, string shipcity, string shipstate, string shipzip, string shipcountry, string size, string merchg, string merchk, string merchb, string merchi, string maternity, string adult, string kid, string bra)
        {
            this.mDistCountry = distcountry;
            this.mStoreNumber = storenumber;
            this.mKitCount = kitcount;
            this.mStoreName = storename;
            this.mAreaCode = areacode;
            this.mPhone = phone;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mSpace = space;
            this.mCity = city;
            this.mState = state;
            this.mZip = zip;
            this.mCountry = country;
            this.mShipAddress1 = shipaddress1;
            this.mShipAddress2 = shipaddress2;
            this.mShipCity = shipcity;
            this.mShipState = shipstate;
            this.mShipZip = shipzip;
            this.mShipCountry = shipcountry;
            this.mSize = size;
            this.mMerchB = merchb;
            this.mMerchG = merchg;
            this.mMerchI = merchi;
            this.mMerchK = merchk;
            this.mMaternity = maternity;
            this.mAdult = adult;
            this.mKid = kid;
            this.mBra = bra;
        }

        public string Address1
        {
            get
            {
                return this.mAddress1;
            }
            set
            {
                this.mAddress1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this.mAddress2;
            }
            set
            {
                this.mAddress2 = value;
            }
        }

        public string Adult
        {
            get
            {
                return this.mAdult;
            }
            set
            {
                this.mAdult = value;
            }
        }

        public string AreaCode
        {
            get
            {
                return this.mAreaCode;
            }
            set
            {
                this.mAreaCode = value;
            }
        }

        public string Bra
        {
            get
            {
                return this.mBra;
            }
            set
            {
                this.mBra = value;
            }
        }

        public string City
        {
            get
            {
                return this.mCity;
            }
            set
            {
                this.mCity = value;
            }
        }

        public string Country
        {
            get
            {
                return this.mCountry;
            }
            set
            {
                this.mCountry = value;
            }
        }

        public string DistCountry
        {
            get
            {
                return this.mDistCountry;
            }
            set
            {
                this.mDistCountry = value;
            }
        }

        public string Kid
        {
            get
            {
                return this.mKid;
            }
            set
            {
                this.mKid = value;
            }
        }

        public int? KitCount
        {
            get
            {
                return this.mKitCount;
            }
            set
            {
                this.mKitCount = value;
            }
        }

        public string Maternity
        {
            get
            {
                return this.mMaternity;
            }
            set
            {
                this.mMaternity = value;
            }
        }

        public string MerchB
        {
            get
            {
                return this.mMerchB;
            }
            set
            {
                this.mMerchB = value;
            }
        }

        public string MerchG
        {
            get
            {
                return this.mMerchG;
            }
            set
            {
                this.mMerchG = value;
            }
        }

        public string MerchI
        {
            get
            {
                return this.mMerchI;
            }
            set
            {
                this.mMerchI = value;
            }
        }

        public string MerchK
        {
            get
            {
                return this.mMerchK;
            }
            set
            {
                this.mMerchK = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.mPhone;
            }
            set
            {
                this.mPhone = value;
            }
        }

        public string ShipAddress1
        {
            get
            {
                return this.mShipAddress1;
            }
            set
            {
                this.mShipAddress1 = value;
            }
        }

        public string ShipAddress2
        {
            get
            {
                return this.mShipAddress2;
            }
            set
            {
                this.mShipAddress2 = value;
            }
        }

        public string ShipCity
        {
            get
            {
                return this.mShipCity;
            }
            set
            {
                this.mShipCity = value;
            }
        }

        public string ShipCountry
        {
            get
            {
                return this.mShipCountry;
            }
            set
            {
                this.mShipCountry = value;
            }
        }

        public string ShipState
        {
            get
            {
                return this.mShipState;
            }
            set
            {
                this.mShipState = value;
            }
        }

        public string ShipZip
        {
            get
            {
                return this.mShipZip;
            }
            set
            {
                this.mShipZip = value;
            }
        }

        public string Size
        {
            get
            {
                return this.mSize;
            }
            set
            {
                this.mSize = value;
            }
        }

        public string Space
        {
            get
            {
                return this.mSpace;
            }
            set
            {
                this.mSpace = value;
            }
        }

        public string State
        {
            get
            {
                return this.mState;
            }
            set
            {
                this.mState = value;
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

        public string StoreNumber
        {
            get
            {
                return this.mStoreNumber;
            }
            set
            {
                this.mStoreNumber = value;
            }
        }

        public string Zip
        {
            get
            {
                return this.mZip;
            }
            set
            {
                this.mZip = value;
            }
        }
    }
}

