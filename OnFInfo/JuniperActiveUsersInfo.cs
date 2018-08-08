namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class JuniperActiveUsersInfo
    {
        private AddressInfo _address = new AddressInfo();
        private string _department;
        private string _email;
        private string _firstname;
        private DateTime? _lastlogin;
        private string _lastname;
        private string _usertype;

        [XmlElement(Namespace="PBA.OnfInfo")]
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

        public string FirstName
        {
            get
            {
                return this._firstname;
            }
            set
            {
                this._firstname = value;
            }
        }

        public DateTime? LastLogin
        {
            get
            {
                return this._lastlogin;
            }
            set
            {
                this._lastlogin = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastname;
            }
            set
            {
                this._lastname = value;
            }
        }

        public string UserType
        {
            get
            {
                if (this._usertype == null)
                {
                    return "";
                }
                return this._usertype;
            }
            set
            {
                this._usertype = value;
            }
        }
    }
}

