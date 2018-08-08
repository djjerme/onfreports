namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LeadsInfo
    {
        private string _address1;
        private string _address2;
        private string _address3;
        private DateTime? _alertDate;
        private bool? _alertFlag;
        private string _appellation;
        private bool? _archiveFlag;
        private string _city;
        private string _companyName;
        private string _country;
        private DateTime? _dateProcessed;
        private string _demographic1;
        private string _demographic10;
        private string _demographic11;
        private string _demographic12;
        private string _demographic13;
        private string _demographic14;
        private string _demographic15;
        private string _demographic16;
        private string _demographic17;
        private string _demographic18;
        private string _demographic19;
        private string _demographic2;
        private string _demographic20;
        private string _demographic21;
        private string _demographic22;
        private string _demographic23;
        private string _demographic24;
        private string _demographic3;
        private string _demographic4;
        private string _demographic5;
        private string _demographic6;
        private string _demographic7;
        private string _demographic8;
        private string _demographic9;
        private string _email;
        private string _fax;
        private string _firstName;
        private string _fulfillmentItems;
        private string _jobTitle;
        private string _lastName;
        private int? _leadId;
        private int? _leadPublicationId;
        private string _leadPublicationName;
        private int? _orderId;
        private string _postalCode;
        private bool? _processedFlag;
        private string _sourceCode;
        private string _stateProvince;
        private int? _storeId;
        private DateTime? _systemInsertionDate;
        private string _systemOrigination;
        private string _telephone;

        public LeadsInfo()
        {
        }

        public LeadsInfo(int? leadId, int? storeId, int? orderId, string systemOrigination, DateTime? systemInsertionDate, string fulfillmentItems, string sourceCode, string leadPublicationName, int? leadPublicationId, string appellation, string firstName, string lastName, string jobTitle, string companyName, string address1, string address2, string address3, string city, string stateProvince, string postalCode, string country, string telephone, string email, string fax, string demographic1, string demographic2, string demographic3, string demographic4, string demographic5, string demographic6, string demographic7, string demographic8, string demographic9, string demographic10, string demographic11, string demographic12, string demographic13, string demographic14, string demographic15, string demographic16, string demographic17, string demographic18, string demographic19, string demographic20, string demographic21, string demographic22, string demographic23, string demographic24, bool? processedFlag, DateTime? dateProcessed, bool? alertFlag, DateTime? alertDate, bool? archiveFlag)
        {
            this._leadId = this.LeadId;
            this._storeId = this.StoreId;
            this._orderId = this.OrderId;
            this._systemOrigination = this.SystemOrigination;
            this._systemInsertionDate = this.SystemInsertionDate;
            this._fulfillmentItems = this.FulfillmentItems;
            this._sourceCode = this.SourceCode;
            this._leadPublicationName = this.LeadPublicationName;
            this._leadPublicationId = this.LeadPublicationId;
            this._appellation = this.Appellation;
            this._firstName = this.FirstName;
            this._lastName = this.LastName;
            this._jobTitle = this.JobTitle;
            this._companyName = this.CompanyName;
            this._address1 = this.Address1;
            this._address2 = this.Address2;
            this._address3 = this.Address3;
            this._city = this.City;
            this._stateProvince = this.StateProvince;
            this._postalCode = this.PostalCode;
            this._country = this.Country;
            this._telephone = this.Telephone;
            this._email = this.Email;
            this._fax = this.Fax;
            this._demographic1 = this.Demographic1;
            this._demographic2 = this.Demographic2;
            this._demographic3 = this.Demographic3;
            this._demographic4 = this.Demographic4;
            this._demographic5 = this.Demographic5;
            this._demographic6 = this.Demographic6;
            this._demographic7 = this.Demographic7;
            this._demographic8 = this.Demographic8;
            this._demographic9 = this.Demographic9;
            this._demographic10 = this.Demographic10;
            this._demographic11 = this.Demographic11;
            this._demographic12 = this.Demographic12;
            this._demographic13 = this.Demographic13;
            this._demographic14 = this.Demographic14;
            this._demographic15 = this.Demographic15;
            this._demographic16 = this.Demographic16;
            this._demographic17 = this.Demographic17;
            this._demographic18 = this.Demographic18;
            this._demographic19 = this.Demographic19;
            this._demographic20 = this.Demographic20;
            this._demographic21 = this.Demographic21;
            this._demographic22 = this.Demographic22;
            this._demographic23 = this.Demographic23;
            this._demographic24 = this.Demographic24;
            this._processedFlag = this.ProcessedFlag;
            this._dateProcessed = this.DateProcessed;
            this._alertFlag = this.AlertFlag;
            this._alertDate = this.AlertDate;
            this._archiveFlag = this.ArchiveFlag;
        }

        public string Address1
        {
            get
            {
                return this._address1;
            }
            set
            {
                this._address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this._address2;
            }
            set
            {
                this._address2 = value;
            }
        }

        public string Address3
        {
            get
            {
                return this._address3;
            }
            set
            {
                this._address3 = value;
            }
        }

        public DateTime? AlertDate
        {
            get
            {
                return this._alertDate;
            }
            set
            {
                this._alertDate = value;
            }
        }

        public bool? AlertFlag
        {
            get
            {
                return this._alertFlag;
            }
            set
            {
                this._alertFlag = value;
            }
        }

        public string Appellation
        {
            get
            {
                return this._appellation;
            }
            set
            {
                this._appellation = value;
            }
        }

        public bool? ArchiveFlag
        {
            get
            {
                return this._archiveFlag;
            }
            set
            {
                this._archiveFlag = value;
            }
        }

        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return this._companyName;
            }
            set
            {
                this._companyName = value;
            }
        }

        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }

        public DateTime? DateProcessed
        {
            get
            {
                return this._dateProcessed;
            }
            set
            {
                this._dateProcessed = value;
            }
        }

        public string Demographic1
        {
            get
            {
                return this._demographic1;
            }
            set
            {
                this._demographic1 = value;
            }
        }

        public string Demographic10
        {
            get
            {
                return this._demographic10;
            }
            set
            {
                this._demographic10 = value;
            }
        }

        public string Demographic11
        {
            get
            {
                return this._demographic11;
            }
            set
            {
                this._demographic11 = value;
            }
        }

        public string Demographic12
        {
            get
            {
                return this._demographic12;
            }
            set
            {
                this._demographic12 = value;
            }
        }

        public string Demographic13
        {
            get
            {
                return this._demographic13;
            }
            set
            {
                this._demographic13 = value;
            }
        }

        public string Demographic14
        {
            get
            {
                return this._demographic14;
            }
            set
            {
                this._demographic14 = value;
            }
        }

        public string Demographic15
        {
            get
            {
                return this._demographic15;
            }
            set
            {
                this._demographic15 = value;
            }
        }

        public string Demographic16
        {
            get
            {
                return this._demographic16;
            }
            set
            {
                this._demographic16 = value;
            }
        }

        public string Demographic17
        {
            get
            {
                return this._demographic17;
            }
            set
            {
                this._demographic17 = value;
            }
        }

        public string Demographic18
        {
            get
            {
                return this._demographic18;
            }
            set
            {
                this._demographic18 = value;
            }
        }

        public string Demographic19
        {
            get
            {
                return this._demographic19;
            }
            set
            {
                this._demographic19 = value;
            }
        }

        public string Demographic2
        {
            get
            {
                return this._demographic2;
            }
            set
            {
                this._demographic2 = value;
            }
        }

        public string Demographic20
        {
            get
            {
                return this._demographic20;
            }
            set
            {
                this._demographic20 = value;
            }
        }

        public string Demographic21
        {
            get
            {
                return this._demographic21;
            }
            set
            {
                this._demographic21 = value;
            }
        }

        public string Demographic22
        {
            get
            {
                return this._demographic22;
            }
            set
            {
                this._demographic22 = value;
            }
        }

        public string Demographic23
        {
            get
            {
                return this._demographic23;
            }
            set
            {
                this._demographic23 = value;
            }
        }

        public string Demographic24
        {
            get
            {
                return this._demographic24;
            }
            set
            {
                this._demographic24 = value;
            }
        }

        public string Demographic3
        {
            get
            {
                return this._demographic3;
            }
            set
            {
                this._demographic3 = value;
            }
        }

        public string Demographic4
        {
            get
            {
                return this._demographic4;
            }
            set
            {
                this._demographic4 = value;
            }
        }

        public string Demographic5
        {
            get
            {
                return this._demographic5;
            }
            set
            {
                this._demographic5 = value;
            }
        }

        public string Demographic6
        {
            get
            {
                return this._demographic6;
            }
            set
            {
                this._demographic6 = value;
            }
        }

        public string Demographic7
        {
            get
            {
                return this._demographic7;
            }
            set
            {
                this._demographic7 = value;
            }
        }

        public string Demographic8
        {
            get
            {
                return this._demographic8;
            }
            set
            {
                this._demographic8 = value;
            }
        }

        public string Demographic9
        {
            get
            {
                return this._demographic9;
            }
            set
            {
                this._demographic9 = value;
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

        public string Fax
        {
            get
            {
                return this._fax;
            }
            set
            {
                this._fax = value;
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

        public string FulfillmentItems
        {
            get
            {
                return this._fulfillmentItems;
            }
            set
            {
                this._fulfillmentItems = value;
            }
        }

        public string JobTitle
        {
            get
            {
                return this._jobTitle;
            }
            set
            {
                this._jobTitle = value;
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

        public int? LeadId
        {
            get
            {
                return this._leadId;
            }
            set
            {
                this._leadId = value;
            }
        }

        public int? LeadPublicationId
        {
            get
            {
                return this._leadPublicationId;
            }
            set
            {
                this._leadPublicationId = value;
            }
        }

        public string LeadPublicationName
        {
            get
            {
                return this._leadPublicationName;
            }
            set
            {
                this._leadPublicationName = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return this._orderId;
            }
            set
            {
                this._orderId = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return this._postalCode;
            }
            set
            {
                this._postalCode = value;
            }
        }

        public bool? ProcessedFlag
        {
            get
            {
                return this._processedFlag;
            }
            set
            {
                this._processedFlag = value;
            }
        }

        public string SourceCode
        {
            get
            {
                return this._sourceCode;
            }
            set
            {
                this._sourceCode = value;
            }
        }

        public string StateProvince
        {
            get
            {
                return this._stateProvince;
            }
            set
            {
                this._stateProvince = value;
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

        public DateTime? SystemInsertionDate
        {
            get
            {
                return this._systemInsertionDate;
            }
            set
            {
                this._systemInsertionDate = value;
            }
        }

        public string SystemOrigination
        {
            get
            {
                return this._systemOrigination;
            }
            set
            {
                this._systemOrigination = value;
            }
        }

        public string Telephone
        {
            get
            {
                return this._telephone;
            }
            set
            {
                this._telephone = value;
            }
        }
    }
}

