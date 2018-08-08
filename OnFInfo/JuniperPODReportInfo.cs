namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class JuniperPODReportInfo
    {
        private AddressInfo _address = new AddressInfo();
        private decimal? _cost;
        private DateTime? _dateordered;
        private string _department;
        private string _firstname;
        private string _itemid;
        private string _lastname;
        private int _orderid;
        private int? _qtyordered;
        private int? _qtyshipped;
        private DateTime? _shipdate;
        private string _usertype;
        private decimal? _value;

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

        public decimal? Cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                this._cost = value;
            }
        }

        public decimal? CostTotal
        {
            get
            {
                int num = 0;
                decimal num2 = 0M;
                if (this.QtyOrdered.HasValue)
                {
                    num = this.QtyOrdered.Value;
                }
                if (this.Cost.HasValue)
                {
                    num2 = this.Cost.Value;
                }
                return new decimal?(num2 * num);
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

        public DateTime? DateShipped
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

        public string ItemID
        {
            get
            {
                return this._itemid;
            }
            set
            {
                this._itemid = value;
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

        public int? QtyOrdered
        {
            get
            {
                return this._qtyordered;
            }
            set
            {
                this._qtyordered = value;
            }
        }

        public int? QtyShipped
        {
            get
            {
                return this._qtyshipped;
            }
            set
            {
                this._qtyshipped = value;
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

        public decimal? Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public decimal? ValueTotal
        {
            get
            {
                int num = 0;
                decimal num2 = 0M;
                if (this.QtyOrdered.HasValue)
                {
                    num = this.QtyOrdered.Value;
                }
                if (this.Value.HasValue)
                {
                    num2 = this.Value.Value;
                }
                return new decimal?(num2 * num);
            }
        }
    }
}

