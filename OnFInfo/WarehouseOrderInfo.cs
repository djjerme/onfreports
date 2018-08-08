namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class WarehouseOrderInfo
    {
        private string _actualShipMethod;
        private int? _available_lines;
        private bool? _bulkOrderParentFlag;
        private int? _bulkOrderParentId;
        private bool? _cdFulfillmentFlag;
        private int? _cdQty;
        private bool _goodOrder;
        private int? _line_count;
        private DateTime? _needDate;
        private int? _not_on_hand_line_count;
        private int? _orderFor;
        private string _orderforname;
        private int? _orderId;
        private OrderItemInfo[] _orderLine;
        private string _orderReason;
        private int? _orderSuffix;
        private string _orderType;
        private DateTime? _orderWhen;
        private int? _personId;
        private bool? _print_on_demand_flag;
        private string _quoteId;
        private string _requestedShipMethod;
        private string _shipLabelComment;
        private decimal? _shipping;
        private bool? _stagedOrderFlag;
        private int? _stagingId;
        private string _status;
        private int? _storeId;
        private string _storename;
        private int? _total_qty_reserved;
        private int? _totalqtyonhand;
        private string _trackingNo;
        private string _transactionId;
        private int? _unavailable_line_count;
        private string _username;
        private string _warehouseComment;
        private int? _whseId;

        public WarehouseOrderInfo()
        {
            this._goodOrder = false;
        }

        public WarehouseOrderInfo(int? storeId, int? orderId, int? orderSuffix, string orderType, string status, int? personId, int? orderFor, DateTime? orderWhen, string requestedShipMethod, string trackingNo, string warehouseComment, string shipLabelComment, decimal? shipping, DateTime? needDate, string quoteId, string actualShipMethod, bool? bulkOrderParentFlag, int? bulkOrderParentId, string orderReason, bool? cdFulfillmentFlag, int? cdQty, string transactionId, bool? stagedOrderFlag, int? stagingId, string orderforname, string username, int? whseId, string storename, int? totalqtyonhand, int? total_qty_reserved, int? line_count, int? not_on_hand_line_count, int? unavailable_line_count, int? available_lines)
        {
            this._goodOrder = false;
            this._storeId = storeId;
            this._orderId = orderId;
            this._orderSuffix = orderSuffix;
            this._orderType = orderType;
            this._status = status;
            this._personId = personId;
            this._orderFor = orderFor;
            this._orderWhen = orderWhen;
            this._requestedShipMethod = requestedShipMethod;
            this._trackingNo = trackingNo;
            this._warehouseComment = warehouseComment;
            this._shipLabelComment = shipLabelComment;
            this._shipping = shipping;
            this._needDate = needDate;
            this._quoteId = quoteId;
            this._actualShipMethod = actualShipMethod;
            this._bulkOrderParentFlag = bulkOrderParentFlag;
            this._bulkOrderParentId = bulkOrderParentId;
            this._orderReason = orderReason;
            this._cdFulfillmentFlag = cdFulfillmentFlag;
            this._cdQty = cdQty;
            this._transactionId = transactionId;
            this._stagedOrderFlag = stagedOrderFlag;
            this._stagingId = stagingId;
            this._orderforname = orderforname;
            this._username = username;
            this._whseId = whseId;
            this._storename = storename;
            this._totalqtyonhand = totalqtyonhand;
            this._total_qty_reserved = total_qty_reserved;
            this._line_count = line_count;
            this._not_on_hand_line_count = not_on_hand_line_count;
            this._unavailable_line_count = unavailable_line_count;
            this._available_lines = available_lines;
        }

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

        public int? AvailableLines
        {
            get
            {
                return this._available_lines;
            }
            set
            {
                this._available_lines = value;
            }
        }

        public bool? BulkOrderParentFlag
        {
            get
            {
                return this._bulkOrderParentFlag;
            }
            set
            {
                this._bulkOrderParentFlag = value;
            }
        }

        public int? BulkOrderParentId
        {
            get
            {
                return this._bulkOrderParentId;
            }
            set
            {
                this._bulkOrderParentId = value;
            }
        }

        public bool? CdFulfillmentFlag
        {
            get
            {
                return this._cdFulfillmentFlag;
            }
            set
            {
                this._cdFulfillmentFlag = value;
            }
        }

        public int? CdQty
        {
            get
            {
                return this._cdQty;
            }
            set
            {
                this._cdQty = value;
            }
        }

        public bool GoodOrder
        {
            get
            {
                return this._goodOrder;
            }
            set
            {
                this._goodOrder = value;
            }
        }

        public int? LineCount
        {
            get
            {
                return this._line_count;
            }
            set
            {
                this._line_count = value;
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

        public int? NotOnHandLineCount
        {
            get
            {
                return this._not_on_hand_line_count;
            }
            set
            {
                this._not_on_hand_line_count = value;
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

        public string Orderforname
        {
            get
            {
                return this._orderforname;
            }
            set
            {
                this._orderforname = value;
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

        public OrderItemInfo[] OrderLine
        {
            get
            {
                return this._orderLine;
            }
            set
            {
                this._orderLine = value;
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

        public bool? PrintOnDemandFlag
        {
            get
            {
                return this._print_on_demand_flag;
            }
            set
            {
                this._print_on_demand_flag = value;
            }
        }

        public string QuoteId
        {
            get
            {
                return this._quoteId;
            }
            set
            {
                this._quoteId = value;
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

        public string ShipLabelComment
        {
            get
            {
                return this._shipLabelComment;
            }
            set
            {
                this._shipLabelComment = value;
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

        public bool? StagedOrderFlag
        {
            get
            {
                return this._stagedOrderFlag;
            }
            set
            {
                this._stagedOrderFlag = value;
            }
        }

        public int? StagingId
        {
            get
            {
                return this._stagingId;
            }
            set
            {
                this._stagingId = value;
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

        public string Storename
        {
            get
            {
                return this._storename;
            }
            set
            {
                this._storename = value;
            }
        }

        public int? TotalQtyOnHand
        {
            get
            {
                return this._totalqtyonhand;
            }
            set
            {
                this._totalqtyonhand = value;
            }
        }

        public int? TotalQtyReserved
        {
            get
            {
                return this._total_qty_reserved;
            }
            set
            {
                this._total_qty_reserved = value;
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

        public string TransactionId
        {
            get
            {
                return this._transactionId;
            }
            set
            {
                this._transactionId = value;
            }
        }

        public int? UnavailableLineCount
        {
            get
            {
                return this._unavailable_line_count;
            }
            set
            {
                this._unavailable_line_count = value;
            }
        }

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
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

        public int? WhseId
        {
            get
            {
                return this._whseId;
            }
            set
            {
                this._whseId = value;
            }
        }
    }
}

