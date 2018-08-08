namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class PersonInfo
    {
        private bool? _activeFlag;
        private AddressInfo[] _addresses;
        private string _busPhone;
        private string _cellPhone;
        private string _costCenter;
        private DateTime? _currentLoginTime;
        private string _department;
        private string _email;
        private string _externalID;
        private string _faxPhone;
        private string _firstName;
        private string _homePhone;
        private int? _iTemp;
        private string _label;
        private DateTime? _lastLoginTime;
        private string _lastName;
        private string _loginId;
        private string _loginSource;
        private string _middleName;
        private string _namePrefix;
        private string _nameSuffix;
        private string _password;
        private int? _personId;
        private string _personType;
        private string _region;
        private int? _representative;
        private bool? _SentInviteFlag;
        private bool? _SiteTermsFlag;
        private int? _storeId;
        private string _storeRepresentativeName;
        private string _url;
        private string _userType;

        public PersonInfo()
        {
            this.SentInviteFlag = false;
        }

        public PersonInfo(int? storeId, int? personId, string namePrefix, string nameSuffix, string firstName, string middleName, string lastName, string busPhone, string homePhone, string cellPhone, string faxPhone, string email, string url, string userType, string loginId, string password, int? representative, string costCenter, string department, bool? activeFlag, string label, int? iTemp, string personType, string region, bool? sentInviteFlag, bool? siteTermsFlag, string externalID, DateTime? lastLoginTime, DateTime? currentLoginTime)
        {
            this._storeId = storeId;
            this._personId = personId;
            this._namePrefix = namePrefix;
            this._nameSuffix = nameSuffix;
            this._firstName = firstName;
            this._middleName = middleName;
            this._lastName = lastName;
            this._busPhone = busPhone;
            this._homePhone = homePhone;
            this._cellPhone = cellPhone;
            this._faxPhone = faxPhone;
            this._email = email;
            this._url = url;
            this._userType = userType;
            this._loginId = loginId;
            this._password = password;
            this._representative = representative;
            this._costCenter = costCenter;
            this._department = department;
            this._activeFlag = activeFlag;
            this._label = label;
            this._iTemp = iTemp;
            this._personType = personType;
            this._region = region;
            this._SentInviteFlag = sentInviteFlag;
            this._SiteTermsFlag = siteTermsFlag;
            this._externalID = externalID;
            this._lastLoginTime = lastLoginTime;
            this._currentLoginTime = currentLoginTime;
            this._loginSource = string.Empty;
        }

        public PersonInfo(int? storeId, int? personId, string namePrefix, string nameSuffix, string firstName, string middleName, string lastName, string busPhone, string homePhone, string cellPhone, string faxPhone, string email, string url, string userType, string loginId, string password, int? representative, string costCenter, string department, bool? activeFlag, string label, int? iTemp, string personType, string region, bool? sentInviteFlag, bool? siteTermsFlag, string externalID, DateTime? lastLoginTime, DateTime? currentLoginTime, string loginSource)
        {
            this._storeId = storeId;
            this._personId = personId;
            this._namePrefix = namePrefix;
            this._nameSuffix = nameSuffix;
            this._firstName = firstName;
            this._middleName = middleName;
            this._lastName = lastName;
            this._busPhone = busPhone;
            this._homePhone = homePhone;
            this._cellPhone = cellPhone;
            this._faxPhone = faxPhone;
            this._email = email;
            this._url = url;
            this._userType = userType;
            this._loginId = loginId;
            this._password = password;
            this._representative = representative;
            this._costCenter = costCenter;
            this._department = department;
            this._activeFlag = activeFlag;
            this._label = label;
            this._iTemp = iTemp;
            this._personType = personType;
            this._region = region;
            this._SentInviteFlag = sentInviteFlag;
            this._SiteTermsFlag = siteTermsFlag;
            this._externalID = externalID;
            this._lastLoginTime = lastLoginTime;
            this._currentLoginTime = currentLoginTime;
            this._loginSource = loginSource;
        }

        public PersonInfo(int? storeId, int? personId, string namePrefix, string nameSuffix, string firstName, string middleName, string lastName, string busPhone, string homePhone, string cellPhone, string faxPhone, string email, string url, string userType, string loginId, string password, int? representative, string costCenter, string department, bool? activeFlag, string label, int? iTemp, string personType, string region, bool? sentInviteFlag, bool? siteTermsFlag, string externalID, DateTime? lastLoginTime, DateTime? currentLoginTime, string loginSource, string storeRepresentativeName)
        {
            this._storeId = storeId;
            this._personId = personId;
            this._namePrefix = namePrefix;
            this._nameSuffix = nameSuffix;
            this._firstName = firstName;
            this._middleName = middleName;
            this._lastName = lastName;
            this._busPhone = busPhone;
            this._homePhone = homePhone;
            this._cellPhone = cellPhone;
            this._faxPhone = faxPhone;
            this._email = email;
            this._url = url;
            this._userType = userType;
            this._loginId = loginId;
            this._password = password;
            this._representative = representative;
            this._costCenter = costCenter;
            this._department = department;
            this._activeFlag = activeFlag;
            this._label = label;
            this._iTemp = iTemp;
            this._personType = personType;
            this._region = region;
            this._SentInviteFlag = sentInviteFlag;
            this._SiteTermsFlag = siteTermsFlag;
            this._externalID = externalID;
            this._lastLoginTime = lastLoginTime;
            this._currentLoginTime = currentLoginTime;
            this._loginSource = loginSource;
            this._storeRepresentativeName = storeRepresentativeName;
        }

        public bool? ActiveFlag
        {
            get
            {
                return this._activeFlag;
            }
            set
            {
                this._activeFlag = value;
            }
        }

        public AddressInfo[] Addresses
        {
            get
            {
                return this._addresses;
            }
            set
            {
                this._addresses = value;
            }
        }

        public string BusPhone
        {
            get
            {
                return this._busPhone;
            }
            set
            {
                this._busPhone = value;
            }
        }

        public string CellPhone
        {
            get
            {
                return this._cellPhone;
            }
            set
            {
                this._cellPhone = value;
            }
        }

        public string CostCenter
        {
            get
            {
                return this._costCenter;
            }
            set
            {
                this._costCenter = value;
            }
        }

        public DateTime? CurrentLoginTime
        {
            get
            {
                return this._currentLoginTime;
            }
            set
            {
                this._currentLoginTime = value;
            }
        }

        public string Department
        {
            get
            {
                return this._department;
            }
            set
            {
                this._department = value;
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public string ExternalID
        {
            get
            {
                return this._externalID;
            }
            set
            {
                this._externalID = value;
            }
        }

        public string FaxPhone
        {
            get
            {
                return this._faxPhone;
            }
            set
            {
                this._faxPhone = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                this._firstName = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return this._homePhone;
            }
            set
            {
                this._homePhone = value;
            }
        }

        public int? ITemp
        {
            get
            {
                return this._iTemp;
            }
            set
            {
                this._iTemp = value;
            }
        }

        public string Label
        {
            get
            {
                return this._label;
            }
            set
            {
                this._label = value;
            }
        }

        public DateTime? LastLoginTime
        {
            get
            {
                return this._lastLoginTime;
            }
            set
            {
                this._lastLoginTime = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                this._lastName = value;
            }
        }

        public string LoginId
        {
            get
            {
                return this._loginId;
            }
            set
            {
                this._loginId = value;
            }
        }

        public string LoginSource
        {
            get
            {
                return this._loginSource;
            }
            set
            {
                this._loginSource = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this._middleName;
            }
            set
            {
                this._middleName = value;
            }
        }

        public string NamePrefix
        {
            get
            {
                return this._namePrefix;
            }
            set
            {
                this._namePrefix = value;
            }
        }

        public string NameSuffix
        {
            get
            {
                return this._nameSuffix;
            }
            set
            {
                this._nameSuffix = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public int? PersonId
        {
            get
            {
                return this._personId;
            }
            set
            {
                this._personId = value;
            }
        }

        public string PersonType
        {
            get
            {
                return this._personType;
            }
            set
            {
                this._personType = value;
            }
        }

        public string Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }

        public int? Representative
        {
            get
            {
                return this._representative;
            }
            set
            {
                this._representative = value;
            }
        }

        public bool? SentInviteFlag
        {
            get
            {
                return this._SentInviteFlag;
            }
            set
            {
                this._SentInviteFlag = value;
            }
        }

        public bool? SiteTermsFlag
        {
            get
            {
                return this._SiteTermsFlag;
            }
            set
            {
                this._SiteTermsFlag = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this._storeId;
            }
            set
            {
                this._storeId = value;
            }
        }

        public string StoreRepresentativeName
        {
            get
            {
                return this._storeRepresentativeName;
            }
            set
            {
                this._storeRepresentativeName = value;
            }
        }

        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }
        }

        public string UserType
        {
            get
            {
                return this._userType;
            }
            set
            {
                this._userType = value;
            }
        }
    }
}

