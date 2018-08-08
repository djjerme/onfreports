namespace PBA.OnfInfo
{
    using System;

    [CLSCompliant(true)]
    public class SibeliusOrderInfo : Info
    {
        private string mAddress1;
        private string mAddress2;
        private string mAddress3;
        private string mBatchNumber;
        private string mCity;
        private string mContactPerson;
        private string mCountry;
        private string mCustomerName;
        private string mCustomerNumber;
        private DateTime? mDocumentDate;
        private DateTime? mFulfillmentDate;
        private string mLocationCode;
        private string mSOPNumber;
        private string mSOPType;
        private string mState;
        private string mUserDefined2;
        private string mVoidStatus;
        private string mZipCode;

        public SibeliusOrderInfo() : base(false)
        {
        }

        public SibeliusOrderInfo(string sopnumber, string batchnumber, DateTime? fulfillmentdate, string customernumber, string locationcode, DateTime? documentdate, string soptype, string voidstatus, string customername, string contactperson, string address1, string address2, string address3, string city, string state, string zipcode, string country, string userdefined2) : base(false)
        {
            this.mSOPNumber = sopnumber;
            this.mBatchNumber = batchnumber;
            this.mFulfillmentDate = fulfillmentdate;
            this.mCustomerNumber = customernumber;
            this.mLocationCode = locationcode;
            this.mDocumentDate = documentdate;
            this.mSOPType = soptype;
            this.mVoidStatus = voidstatus;
            this.mCustomerName = customername;
            this.mContactPerson = contactperson;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mAddress3 = address3;
            this.mCity = city;
            this.mState = state;
            this.mZipCode = zipcode;
            this.mCountry = country;
            this.mUserDefined2 = userdefined2;
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

        public string Address3
        {
            get
            {
                return this.mAddress3;
            }
            set
            {
                this.mAddress3 = value;
            }
        }

        public string BatchNumber
        {
            get
            {
                return this.mBatchNumber;
            }
            set
            {
                this.mBatchNumber = value;
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

        public string ContactPerson
        {
            get
            {
                return this.mContactPerson;
            }
            set
            {
                this.mContactPerson = value;
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

        public string CustomerName
        {
            get
            {
                return this.mCustomerName;
            }
            set
            {
                this.mCustomerName = value;
            }
        }

        public string CustomerNumber
        {
            get
            {
                return this.mCustomerNumber;
            }
            set
            {
                this.mCustomerNumber = value;
            }
        }

        public DateTime? DocumentDate
        {
            get
            {
                return this.mDocumentDate;
            }
            set
            {
                this.mDocumentDate = value;
            }
        }

        public DateTime? FulfillmentDate
        {
            get
            {
                return this.mFulfillmentDate;
            }
            set
            {
                this.mFulfillmentDate = value;
            }
        }

        public string LocationCode
        {
            get
            {
                return this.mLocationCode;
            }
            set
            {
                this.mLocationCode = value;
            }
        }

        public string SOPNumber
        {
            get
            {
                return this.mSOPNumber;
            }
            set
            {
                this.mSOPNumber = value;
            }
        }

        public string SOPType
        {
            get
            {
                return this.mSOPType;
            }
            set
            {
                this.mSOPType = value;
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

        public string UserDefined2
        {
            get
            {
                return this.mUserDefined2;
            }
            set
            {
                this.mUserDefined2 = value;
            }
        }

        public string VoidStatus
        {
            get
            {
                return this.mVoidStatus;
            }
            set
            {
                this.mVoidStatus = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return this.mZipCode;
            }
            set
            {
                this.mZipCode = value;
            }
        }
    }
}

