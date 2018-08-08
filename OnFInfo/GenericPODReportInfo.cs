using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PBA.OnfInfo
{
    [Serializable]
    [XmlRoot(Namespace = "PBA.OnfInfo")]
    public class GenericPODReportInfo
    {

        #region Member Variables
        private int _orderid;
        private DateTime? _dateordered;
        private DateTime? _shipdate;
        private string _usertype;
        private string _lastname;
        private string _firstname;
        private string _itemid;
        private int _storeid;
        private string _storename;
        private string _shiptostate;
        private string _shiptocountry;
        private int? _qtyordered;
        private int? _qtyshipped;
        private decimal? _inventoryCost;
        private decimal? _onfCostBase;
        private decimal? _onfCost;
        private decimal? _onfCostMultiplier;
        private string _printLocationId;
        private string _fulfillmentLocationId;
        private int? _pageCount;
        private string _department;
        private AddressInfo _address;
        private string _customerOrderNumber;
        private string _costcenter;

        #endregion

        #region Constructors
        public GenericPODReportInfo()
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

        public string Department
        {
            get { return _department; }
            set { _department = value; }
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

        public int StoreId
        {
            get { return _storeid; }
            set { _storeid = value; }
        }

        public string StoreName
        {
            get { return _storename; }
            set { _storename = value; }
        }

        public string ShipToState
        {
            get { return _shiptostate; }
            set { _shiptostate = value; }
        }

        public string ShipToCountry
        {
            get { return _shiptocountry; }
            set { _shiptocountry = value; }
        }

        public string CostCenter
        {
            get { return _costcenter; }
            set { _costcenter = value; }
        }

        public DateTime? DateOrdered
        {
            get { return _dateordered; }
            set { _dateordered = value; }
        }

        public DateTime? DateShipped
        {
            get { return _shipdate; }
            set { _shipdate = value; }
        }

        public string UserType
        {
            get
            {
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

        public decimal? InventoryCost
        {
            get { return _inventoryCost; }
            set { _inventoryCost = value; }
        }

        public decimal? InventoryCostTotal
        {
            get
            {
                int qty = 0;
                decimal val = 0m;

                if (QtyOrdered.HasValue)
                {
                    qty = QtyOrdered.Value;
                }

                if (InventoryCostTotal.HasValue) { val = InventoryCostTotal.Value; }
                return val * qty;
            }
        }

        public decimal? OnfCostBase
        {
            get { return _onfCostBase; }
            set { _onfCostBase = value; }
        }

        public decimal? OnfCost
        {
            get { return _onfCost; }
            set { _onfCost = value; }
        }

        public decimal? CostTotal
        {
            get
            {
                int qty = 0;
                decimal val = 0m;

                if (QtyOrdered.HasValue)
                {
                    qty = QtyOrdered.Value;
                }

                if (OnfCostBase.HasValue) { val = OnfCostBase.Value; }
                return val * qty;
            }
        }

        public decimal? OnfCostMultiplier
        {
            get { return _onfCostMultiplier; }
            set { _onfCostMultiplier = value; }
        }

        public int? PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }

        public string PrintLocationId
        {
            get { return _printLocationId; }
            set { _printLocationId = value; }
        }

        public string FulfillmentLocationId
        {
            get { return _fulfillmentLocationId; }
            set { _fulfillmentLocationId = value; }
        }

        public string CustomerOrderNumber
        {
            get { return _customerOrderNumber; }
            set { _customerOrderNumber = value; }
        }   

        #endregion
    }
}
