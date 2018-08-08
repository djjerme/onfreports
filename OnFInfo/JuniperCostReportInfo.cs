namespace PBA.OnfInfo
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class JuniperCostReportInfo
    {
        private AddressInfo _address = new AddressInfo();
        private DateTime? _dateordered;
        private string _department;
        private string _firstname;
        private string _lastname;
        private int _orderid;
        private List<JuniperCostReportLineInfo> _orderlines;
        private string _region;
        private DateTime? _shipdate;
        private string _status;
        private string _usertype;

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

        public DateTime? DateOrdered
        {
            get
            {
                return this._dateordered;
            }
            set
            {
                this._dateordered = value;
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

        [XmlElement(Namespace="PBA.OnfInfo")]
        public int OrderId
        {
            get
            {
                return this._orderid;
            }
            set
            {
                this._orderid = value;
            }
        }

        public List<JuniperCostReportLineInfo> OrderLines
        {
            get
            {
                return this._orderlines;
            }
            set
            {
                this._orderlines = value;
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

        public DateTime? ShipDate
        {
            get
            {
                return this._shipdate;
            }
            set
            {
                this._shipdate = value;
            }
        }

        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        public string UserType
        {
            get
            {
                return this._usertype;
            }
            set
            {
                this._usertype = value;
            }
        }
    }
}

