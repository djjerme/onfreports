using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PBA.OnfInfo
{
    /// <summary>
    /// This class contains data elements associated with 
    /// the Juniper Cost Report. 
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = "PBA.OnfInfo")]
    public class JuniperPartReportInfo
    {

        #region Member Variables
        private int _orderid;
        private string _itemid;
        private string _productname;
        private DateTime? _dateordered;
        private string _usertype;
        private string _lastname;
        private string _firstname;
        private string _department;
        private int? _qtyordered;
        private int? _qtyshipped;
        private decimal? _value;
        private decimal? _cost;
        private AddressInfo _address;
        private string _contentOwner;

        #endregion

        #region Constructors
        public JuniperPartReportInfo()
        {
            _address = new AddressInfo();
        }

        #endregion

        #region Properties
        [XmlElement(Namespace = "PBA.OnfInfo")]
        public int OrderId
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        public AddressInfo Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string ItemID
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }

        public DateTime? DateOrdered
        {
            get { return _dateordered; }
            set { _dateordered = value; }
        }

        public string UserType
        {
            get {
                if (_usertype == null) { return ""; }
                return _usertype;
            }
            set { _usertype = value; }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public int? QtyOrdered
        {
            get { return _qtyordered; }
            set { _qtyordered = value; }
        }

        public int? QtyShipped
        {
            get { return _qtyshipped; }
            set { _qtyshipped = value; }
        }

        public decimal? Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public decimal? ValueTotal
        {
            get
            {
                int qty = 0;
                decimal val = 0m;

                if (QtyShipped.HasValue)
                {
                    qty = QtyShipped.Value;
                }
                else if (QtyOrdered.HasValue)
                {
                    qty = QtyOrdered.Value;
                }

                if (Value.HasValue) { val = Value.Value; }
                return val * qty;
            }
        }

        public decimal? Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public decimal? CostTotal
        {
            get
            {
                int qty = 0;
                decimal val = 0m;

                if (QtyShipped.HasValue)
                {
                    qty = QtyShipped.Value;
                }
                else if (QtyOrdered.HasValue)
                {
                    qty = QtyOrdered.Value;
                }

                if (Cost.HasValue) { val = Cost.Value; }
                return val * qty;
            }
        }

        public string ContentOwner
        {
            get { return _contentOwner; }
            set { _contentOwner = value; }
        }

        #endregion
    }
}
