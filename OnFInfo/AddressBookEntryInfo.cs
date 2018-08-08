namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class AddressBookEntryInfo
    {
        private AddressInfo _address;
        private int? _addressId;
        private bool _isExternal;
        private string _label;
        private PersonInfo _person;
        private int? _personId;

        public AddressBookEntryInfo()
        {
            this._isExternal = false;
            this._label = string.Empty;
            this._address = null;
            this._person = null;
        }

        public AddressBookEntryInfo(bool isExternal, string label, AddressInfo address, PersonInfo person)
        {
            this._isExternal = false;
            this._label = string.Empty;
            this._address = null;
            this._person = null;
            this._isExternal = isExternal;
            this._label = label;
            this._address = address;
            this._person = person;
            if ((address != null) && address.AddressId.HasValue)
            {
                this._addressId = new int?(address.AddressId.Value);
            }
            if ((person != null) && person.PersonId.HasValue)
            {
                this._personId = new int?(person.PersonId.Value);
            }
        }

        public AddressInfo Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
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

        public bool IsExternal
        {
            get
            {
                return this._isExternal;
            }
            set
            {
                this._isExternal = value;
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

        public PersonInfo Person
        {
            get
            {
                return this._person;
            }
            set
            {
                this._person = value;
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
    }
}

