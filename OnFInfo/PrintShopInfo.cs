namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class PrintShopInfo
    {
        private string mAddress1;
        private string mAddress2;
        private string mAddress3;
        private string mCity;
        private string mCountryCode;
        private string mName;
        private int? mNotificationType;
        private string mPostalCode;
        private int? mPrintShopId;
        private int? mShipBy;
        private string mStateProvince;
        private PrintShopRoleInfo[] mUserRoles;

        public PrintShopInfo()
        {
        }

        public PrintShopInfo(int? printshopid, string name, string address1, string address2, string address3, string city, string stateprovince, string countrycode, string postalcode, int? shipby, int? notificationtype)
        {
            this.mPrintShopId = printshopid;
            this.mName = name;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mAddress3 = address3;
            this.mCity = city;
            this.mStateProvince = stateprovince;
            this.mCountryCode = countrycode;
            this.mPostalCode = postalcode;
            this.mShipBy = shipby;
            this.mNotificationType = notificationtype;
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

        public string CountryCode
        {
            get
            {
                return this.mCountryCode;
            }
            set
            {
                this.mCountryCode = value;
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

        public int? NotificationType
        {
            get
            {
                return this.mNotificationType;
            }
            set
            {
                this.mNotificationType = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return this.mPostalCode;
            }
            set
            {
                this.mPostalCode = value;
            }
        }

        public int? PrintShopId
        {
            get
            {
                return this.mPrintShopId;
            }
            set
            {
                this.mPrintShopId = value;
            }
        }

        public int? ShipBy
        {
            get
            {
                return this.mShipBy;
            }
            set
            {
                this.mShipBy = value;
            }
        }

        public string StateProvince
        {
            get
            {
                return this.mStateProvince;
            }
            set
            {
                this.mStateProvince = value;
            }
        }

        public PrintShopRoleInfo[] UserRoles
        {
            get
            {
                return this.mUserRoles;
            }
            set
            {
                this.mUserRoles = value;
            }
        }
    }
}

