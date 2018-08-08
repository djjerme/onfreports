namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class WarehousePrintOrderHead
    {
        private string _actualShipMethod;
        private string _address_1;
        private string _address_2;
        private string _address_3;
        private string _barcodeId;
        private string _busPhone;
        private bool? _cd_FulFillmentFlag;
        private string _city;
        private string _company;
        private string _costCenter;
        private string _country;
        private string _cust_order_no;
        private string _customMessage;
        private string _demographics2_0;
        private string _demographics2_1;
        private string _demographics2_10;
        private string _demographics2_11;
        private string _demographics2_12;
        private string _demographics2_13;
        private string _demographics2_2;
        private string _demographics2_3;
        private string _demographics2_4;
        private string _demographics2_5;
        private string _demographics2_6;
        private string _demographics2_7;
        private string _demographics2_8;
        private string _demographics2_9;
        private string _externalOrderId;
        private string _homePhone;
        private DateTime? _needDate;
        private int? _orderFor;
        private string _orderforName;
        private int? _orderId;
        private string _orderReason;
        private int? _orderSuffix;
        private string _orderType;
        private DateTime? _orderWhen;
        private int? _personId;
        private string _pickBy;
        private DateTime? _pickDate;
        private WarehousePrintInvoiceLine[] _printInvoiceLines;
        private WarehousePrintOrderLine[] _printOrderLines;
        private string _requestedShipMethod;
        private decimal? _salesTax;
        private int? _sendtoAddress;
        private int? _sendtoPerson;
        private string _ship_labelComment;
        private string _shipAttnTo;
        private string _shipBy;
        private DateTime? _shipDate;
        private string _shipEmail;
        private string _shipName;
        private decimal? _shipping;
        private string _state;
        private string _status;
        private int? _storeId;
        private string _storeName;
        private bool? _thirdPartyShipperFlag;
        private string _thirdPartyShipperInfo;
        private string _trackingNo;
        private string _user_address_1;
        private string _user_address_2;
        private string _user_Address_3;
        private string _user_city;
        private string _user_company;
        private string _user_country;
        private string _user_state;
        private string _user_zip;
        private string _userEmail;
        private string _userName;
        private string _warehouseComment;
        private string _zip;

        public string ActualShipMethod
        {
            get
            {
                return this._actualShipMethod;
            }
            set
            {
                this._actualShipMethod = value;
            }
        }

        public string Address_1
        {
            get
            {
                return this._address_1;
            }
            set
            {
                this._address_1 = value;
            }
        }

        public string Address_2
        {
            get
            {
                return this._address_2;
            }
            set
            {
                this._address_2 = value;
            }
        }

        public string Address_3
        {
            get
            {
                return this._address_3;
            }
            set
            {
                this._address_3 = value;
            }
        }

        public string BarcodeId
        {
            get
            {
                return this._barcodeId;
            }
            set
            {
                this._barcodeId = value;
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

        public bool? CDFulFillmentFlag
        {
            get
            {
                return this._cd_FulFillmentFlag;
            }
            set
            {
                this._cd_FulFillmentFlag = value;
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

        public string CustomMessage
        {
            get
            {
                return this._customMessage;
            }
            set
            {
                this._customMessage = value;
            }
        }

        public string CustOrderNo
        {
            get
            {
                return this._cust_order_no;
            }
            set
            {
                this._cust_order_no = value;
            }
        }

        public string Demographics2_0
        {
            get
            {
                return this._demographics2_0;
            }
            set
            {
                this._demographics2_0 = value;
            }
        }

        public string Demographics2_1
        {
            get
            {
                return this._demographics2_1;
            }
            set
            {
                this._demographics2_1 = value;
            }
        }

        public string Demographics2_10
        {
            get
            {
                return this._demographics2_10;
            }
            set
            {
                this._demographics2_10 = value;
            }
        }

        public string Demographics2_11
        {
            get
            {
                return this._demographics2_11;
            }
            set
            {
                this._demographics2_11 = value;
            }
        }

        public string Demographics2_12
        {
            get
            {
                return this._demographics2_12;
            }
            set
            {
                this._demographics2_12 = value;
            }
        }

        public string Demographics2_13
        {
            get
            {
                return this._demographics2_13;
            }
            set
            {
                this._demographics2_13 = value;
            }
        }

        public string Demographics2_2
        {
            get
            {
                return this._demographics2_2;
            }
            set
            {
                this._demographics2_2 = value;
            }
        }

        public string Demographics2_3
        {
            get
            {
                return this._demographics2_3;
            }
            set
            {
                this._demographics2_3 = value;
            }
        }

        public string Demographics2_4
        {
            get
            {
                return this._demographics2_4;
            }
            set
            {
                this._demographics2_4 = value;
            }
        }

        public string Demographics2_5
        {
            get
            {
                return this._demographics2_5;
            }
            set
            {
                this._demographics2_5 = value;
            }
        }

        public string Demographics2_6
        {
            get
            {
                return this._demographics2_6;
            }
            set
            {
                this._demographics2_6 = value;
            }
        }

        public string Demographics2_7
        {
            get
            {
                return this._demographics2_7;
            }
            set
            {
                this._demographics2_7 = value;
            }
        }

        public string Demographics2_8
        {
            get
            {
                return this._demographics2_8;
            }
            set
            {
                this._demographics2_8 = value;
            }
        }

        public string Demographics2_9
        {
            get
            {
                return this._demographics2_9;
            }
            set
            {
                this._demographics2_9 = value;
            }
        }

        public string ExternalOrderId
        {
            get
            {
                return this._externalOrderId;
            }
            set
            {
                this._externalOrderId = value;
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

        public DateTime? NeedDate
        {
            get
            {
                return this._needDate;
            }
            set
            {
                this._needDate = value;
            }
        }

        public int? OrderFor
        {
            get
            {
                return this._orderFor;
            }
            set
            {
                this._orderFor = value;
            }
        }

        public string OrderforName
        {
            get
            {
                return this._orderforName;
            }
            set
            {
                this._orderforName = value;
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

        public string OrderReason
        {
            get
            {
                return this._orderReason;
            }
            set
            {
                this._orderReason = value;
            }
        }

        public int? OrderSuffix
        {
            get
            {
                return this._orderSuffix;
            }
            set
            {
                this._orderSuffix = value;
            }
        }

        public string OrderType
        {
            get
            {
                return this._orderType;
            }
            set
            {
                this._orderType = value;
            }
        }

        public DateTime? OrderWhen
        {
            get
            {
                return this._orderWhen;
            }
            set
            {
                this._orderWhen = value;
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

        public string PickBy
        {
            get
            {
                return this._pickBy;
            }
            set
            {
                this._pickBy = value;
            }
        }

        public DateTime? PickDate
        {
            get
            {
                return this._pickDate;
            }
            set
            {
                this._pickDate = value;
            }
        }

        public WarehousePrintInvoiceLine[] PrintInvoiceLines
        {
            get
            {
                return this._printInvoiceLines;
            }
            set
            {
                this._printInvoiceLines = value;
            }
        }

        public WarehousePrintOrderLine[] PrintOrderLines
        {
            get
            {
                return this._printOrderLines;
            }
            set
            {
                this._printOrderLines = value;
            }
        }

        public string RequestedShipMethod
        {
            get
            {
                return this._requestedShipMethod;
            }
            set
            {
                this._requestedShipMethod = value;
            }
        }

        public decimal? SalesTax
        {
            get
            {
                return this._salesTax;
            }
            set
            {
                this._salesTax = value;
            }
        }

        public int? SendtoAddress
        {
            get
            {
                return this._sendtoAddress;
            }
            set
            {
                this._sendtoAddress = value;
            }
        }

        public int? SendtoPerson
        {
            get
            {
                return this._sendtoPerson;
            }
            set
            {
                this._sendtoPerson = value;
            }
        }

        public string ShipAttnTo
        {
            get
            {
                return this._shipAttnTo;
            }
            set
            {
                this._shipAttnTo = value;
            }
        }

        public string ShipBy
        {
            get
            {
                return this._shipBy;
            }
            set
            {
                this._shipBy = value;
            }
        }

        public DateTime? ShipDate
        {
            get
            {
                return this._shipDate;
            }
            set
            {
                this._shipDate = value;
            }
        }

        public string ShipEmail
        {
            get
            {
                return this._shipEmail;
            }
            set
            {
                this._shipEmail = value;
            }
        }

        public string ShipLabelComment
        {
            get
            {
                return this._ship_labelComment;
            }
            set
            {
                this._ship_labelComment = value;
            }
        }

        public string ShipName
        {
            get
            {
                return this._shipName;
            }
            set
            {
                this._shipName = value;
            }
        }

        public decimal? Shipping
        {
            get
            {
                return this._shipping;
            }
            set
            {
                this._shipping = value;
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

        public string StoreName
        {
            get
            {
                return this._storeName;
            }
            set
            {
                this._storeName = value;
            }
        }

        public bool? ThirdPartyShipperFlag
        {
            get
            {
                return this._thirdPartyShipperFlag;
            }
            set
            {
                this._thirdPartyShipperFlag = value;
            }
        }

        public string ThirdPartyShipperInfo
        {
            get
            {
                return this._thirdPartyShipperInfo;
            }
            set
            {
                this._thirdPartyShipperInfo = value;
            }
        }

        public string TrackingNo
        {
            get
            {
                return this._trackingNo;
            }
            set
            {
                this._trackingNo = value;
            }
        }

        public string User_Address_1
        {
            get
            {
                return this._user_address_1;
            }
            set
            {
                this._user_address_1 = value;
            }
        }

        public string User_Address_2
        {
            get
            {
                return this._user_address_2;
            }
            set
            {
                this._user_address_2 = value;
            }
        }

        public string User_Address_3
        {
            get
            {
                return this._user_Address_3;
            }
            set
            {
                this._user_Address_3 = value;
            }
        }

        public string User_City
        {
            get
            {
                return this._user_city;
            }
            set
            {
                this._user_city = value;
            }
        }

        public string User_Company
        {
            get
            {
                return this._user_company;
            }
            set
            {
                this._user_company = value;
            }
        }

        public string User_Country
        {
            get
            {
                return this._user_country;
            }
            set
            {
                this._user_country = value;
            }
        }

        public string User_State
        {
            get
            {
                return this._user_state;
            }
            set
            {
                this._user_state = value;
            }
        }

        public string User_Zip
        {
            get
            {
                return this._user_zip;
            }
            set
            {
                this._user_zip = value;
            }
        }

        public string UserEmail
        {
            get
            {
                return this._userEmail;
            }
            set
            {
                this._userEmail = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
            }
        }

        public string WarehouseComment
        {
            get
            {
                return this._warehouseComment;
            }
            set
            {
                this._warehouseComment = value;
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

