namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class WarehouseInvPickTransInfo
    {
        private DateTime? _dtLastTrans;
        private string _invTransItemId;
        private string _invTransLocId;
        private string _itemId;
        private string _locationId;
        private int? _pickQty;
        private int? _qtyOnhand;
        private bool? _status;
        private int? _storeId;
        private int? _whseId;

        public DateTime? DateLastTrans
        {
            get
            {
                return this._dtLastTrans;
            }
            set
            {
                this._dtLastTrans = value;
            }
        }

        public string InvTransItemId
        {
            get
            {
                return this._invTransItemId;
            }
            set
            {
                this._invTransItemId = value;
            }
        }

        public string InvTransLocId
        {
            get
            {
                return this._invTransLocId;
            }
            set
            {
                this._invTransLocId = value;
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

        public int? PickQty
        {
            get
            {
                return this._pickQty;
            }
            set
            {
                this._pickQty = value;
            }
        }

        public int? QtyOnhand
        {
            get
            {
                return this._qtyOnhand;
            }
            set
            {
                this._qtyOnhand = value;
            }
        }

        public bool? Status
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

