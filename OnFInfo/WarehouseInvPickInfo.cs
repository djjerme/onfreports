namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class WarehouseInvPickInfo
    {
        private bool? _activePick;
        private string _itemId;
        private string _locationId;
        private int? _orderId;
        private int? _orderSuffix;
        private int? _qtyPick;
        private int? _storeId;
        private int? _whseId;

        public bool? ActivePick
        {
            get
            {
                return this._activePick;
            }
            set
            {
                this._activePick = value;
            }
        }

        public string ItemId
        {
            get
            {
                return this._itemId;
            }
            set
            {
                this._itemId = value;
            }
        }

        public string LocationId
        {
            get
            {
                return this._locationId;
            }
            set
            {
                this._locationId = value;
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

        public int? QtyPick
        {
            get
            {
                return this._qtyPick;
            }
            set
            {
                this._qtyPick = value;
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

