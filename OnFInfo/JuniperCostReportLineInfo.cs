namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class JuniperCostReportLineInfo
    {
        private decimal? _cost;
        private string _itemid;
        private int _orderid;
        private int? _qty;
        private int? _qtyshipped;
        private decimal? _value;

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

        public string ItemId
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

        public int? Qty
        {
            get
            {
                return this._qty;
            }
            set
            {
                this._qty = value;
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
    }
}

