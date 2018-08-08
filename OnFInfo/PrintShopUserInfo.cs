namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class PrintShopUserInfo
    {
        private bool? mActive;
        private string mEmail;
        private string mFirstName;
        private string mLastName;
        private string mLoginId;
        private string mMiddleName;
        private string mPassword;
        private string mPasswordHint;
        private PrintShopInfo[] mPrintShops;
        private int? mPrintShopUserId;

        public PrintShopUserInfo()
        {
        }

        public PrintShopUserInfo(int? printshopuserid, string loginid, string password, string passwordhint, string firstname, string middlename, string lastname, string email, bool? active)
        {
            this.mPrintShopUserId = printshopuserid;
            this.mLoginId = loginid;
            this.mPassword = password;
            this.mPasswordHint = passwordhint;
            this.mFirstName = firstname;
            this.mMiddleName = middlename;
            this.mLastName = lastname;
            this.mEmail = email;
            this.mActive = active;
        }

        public PrintShopUserInfo(int? printshopuserid, string loginid, string password, string passwordhint, string firstname, string middlename, string lastname, string email, bool? active, PrintShopInfo[] printshops)
        {
            this.mPrintShopUserId = printshopuserid;
            this.mLoginId = loginid;
            this.mPassword = password;
            this.mPasswordHint = passwordhint;
            this.mFirstName = firstname;
            this.mMiddleName = middlename;
            this.mLastName = lastname;
            this.mEmail = email;
            this.mActive = active;
            this.mPrintShops = printshops;
        }

        public bool? Active
        {
            get
            {
                return this.mActive;
            }
            set
            {
                this.mActive = value;
            }
        }

        public string Email
        {
            get
            {
                return this.mEmail;
            }
            set
            {
                this.mEmail = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.mFirstName;
            }
            set
            {
                this.mFirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.mLastName;
            }
            set
            {
                this.mLastName = value;
            }
        }

        public string LoginId
        {
            get
            {
                return this.mLoginId;
            }
            set
            {
                this.mLoginId = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.mMiddleName;
            }
            set
            {
                this.mMiddleName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.mPassword;
            }
            set
            {
                this.mPassword = value;
            }
        }

        public string PasswordHint
        {
            get
            {
                return this.mPasswordHint;
            }
            set
            {
                this.mPasswordHint = value;
            }
        }

        public PrintShopInfo[] PrintShops
        {
            get
            {
                return this.mPrintShops;
            }
            set
            {
                this.mPrintShops = value;
            }
        }

        public int? PrintShopUserId
        {
            get
            {
                return this.mPrintShopUserId;
            }
            set
            {
                this.mPrintShopUserId = value;
            }
        }
    }
}

