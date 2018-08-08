namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class JuniperOrderedItemsInfo
    {
        private int _itemcount;
        private string _itemid;
        private string _productname;
        private decimal _totalprice;
        private int _totalqty;

        public int ItemCount
        {
            get
            {
                return this._itemcount;
            }
            set
            {
                this._itemcount = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
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

        public string ProductName
        {
            get
            {
                return this._productname;
            }
            set
            {
                this._productname = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return this._totalprice;
            }
            set
            {
                this._totalprice = value;
            }
        }

        public int TotalQty
        {
            get
            {
                return this._totalqty;
            }
            set
            {
                this._totalqty = value;
            }
        }
    }
}

