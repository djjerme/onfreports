namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class SessionInfo
    {
        private string mPassword;
        private int? mPersonId;
        private int? mQuoteId;
        private int? mSessionId;
        private DateTime? mStartDt;
        private int? mStoreId;
        private bool? mThirdPartyShipperFlag;
        private string mThirdPartyShipperInfo;
        private string mUserType;

        public SessionInfo()
        {
        }

        public SessionInfo(int? sessionid, int? storeid, int? quoteid, int? personid, DateTime? startdt, string usertype, string password, bool? thirdpartyshipperflag, string thirdpartyshipperinfo)
        {
            this.mSessionId = sessionid;
            this.mStoreId = storeid;
            this.mQuoteId = quoteid;
            this.mPersonId = personid;
            this.mStartDt = startdt;
            this.mUserType = usertype;
            this.mPassword = password;
            this.mThirdPartyShipperFlag = thirdpartyshipperflag;
            this.mThirdPartyShipperInfo = thirdpartyshipperinfo;
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

        public int? PersonId
        {
            get
            {
                return this.mPersonId;
            }
            set
            {
                this.mPersonId = value;
            }
        }

        public int? QuoteId
        {
            get
            {
                return this.mQuoteId;
            }
            set
            {
                this.mQuoteId = value;
            }
        }

        public int? SessionId
        {
            get
            {
                return this.mSessionId;
            }
            set
            {
                this.mSessionId = value;
            }
        }

        public DateTime? StartDt
        {
            get
            {
                return this.mStartDt;
            }
            set
            {
                this.mStartDt = value;
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

        public bool? ThirdPartyShipperFlag
        {
            get
            {
                return this.mThirdPartyShipperFlag;
            }
            set
            {
                this.mThirdPartyShipperFlag = value;
            }
        }

        public string ThirdPartyShipperInfo
        {
            get
            {
                return this.mThirdPartyShipperInfo;
            }
            set
            {
                this.mThirdPartyShipperInfo = value;
            }
        }

        public string UserType
        {
            get
            {
                return this.mUserType;
            }
            set
            {
                this.mUserType = value;
            }
        }
    }
}

