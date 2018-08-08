namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class Previous30DayOrderQtyInfo
    {
        private string _itemId;
        private DateTime _oldestOrder;
        private int _previousQty;
        private int? _storeId;

        public Previous30DayOrderQtyInfo()
        {
            this._previousQty = 0;
            this._oldestOrder = DateTime.MinValue;
        }

        public Previous30DayOrderQtyInfo(int? storeId, string itemId, int previousQty, DateTime oldestOrder)
        {
            this._previousQty = 0;
            this._oldestOrder = DateTime.MinValue;
            this._storeId = storeId;
            this._itemId = itemId;
            this._oldestOrder = oldestOrder;
            this._previousQty = previousQty;
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

        public DateTime OldestOrder
        {
            get
            {
                return this._oldestOrder;
            }
            set
            {
                this._oldestOrder = value;
            }
        }

        public int PreviousQty
        {
            get
            {
                return this._previousQty;
            }
            set
            {
                this._previousQty = value;
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
    }
}

