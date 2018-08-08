namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class AddressInfo
    {
        private string _address1;
        private string _address2;
        private string _address3;
        private int? _addressId;
        private string _busPhone;
        private string _city;
        private string _company;
        private string _country;
        private string _faxPhone;
        private string _homePhone;
        private string _label;
        private int? _personId;
        private string _state;
        private int? _storeId;
        private string _title;
        private string _zip;

        public AddressInfo()
        {
        }

        public AddressInfo(int? storeId, int? personId, int? addressId, string label, string company, string title, string address1, string address2, string address3, string city, string state, string country, string zip, string busPhone, string homePhone, string faxPhone)
        {
            this._storeId = storeId;
            this._personId = personId;
            this._addressId = addressId;
            this._label = label;
            this._company = company;
            this._title = title;
            this._address1 = address1;
            this._address2 = address2;
            this._address3 = address3;
            this._city = city;
            this._state = state;
            this._country = country;
            this._zip = zip;
            this._busPhone = busPhone;
            this._homePhone = homePhone;
            this._faxPhone = faxPhone;
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

        public int? AddressId
        {
            get
            {
                return this._addressId;
            }
            set
            {
                this._addressId = value;
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

        public string Company
        {
            get
            {
                return this._company;
            }
            set
            {
                this._company = value;
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

        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
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

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public string Zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                this._zip = value;
            }
        }
    }
}

