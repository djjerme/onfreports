namespace PBA.OnfInfo
{
    using System;
    using System.Collections.Generic;

    public class StoreItemInfo : PBA.OnfInfo.ItemInfo
    {
        private Dictionary<int, FulfillmentTypePricingInfo> _fulfillmentTypePricing = new Dictionary<int, FulfillmentTypePricingInfo>(2);
        private Previous30DayOrderQtyInfo _prev30DayOrderQty = null;
        private int _qtyAvailable;
        private UserTypeItemInfo _userTypeItem = null;

        public Dictionary<int, FulfillmentTypePricingInfo> FulfillmentTypePricing
        {
            get
            {
                return this._fulfillmentTypePricing;
            }
        }

        public Previous30DayOrderQtyInfo Prev30DayOrderQty
        {
            get
            {
                return this._prev30DayOrderQty;
            }
            set
            {
                this._prev30DayOrderQty = value;
            }
        }

        public int QtyAvailable
        {
            get
            {
                return this._qtyAvailable;
            }
            set
            {
                this._qtyAvailable = value;
            }
        }

        public UserTypeItemInfo UserTypeItem
        {
            get
            {
                return this._userTypeItem;
            }
            set
            {
                this._userTypeItem = value;
            }
        }
    }
}

