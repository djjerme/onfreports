using System;
using System.Collections.Generic;
using System.Text;

namespace PBA.OnfInfo {

	[Serializable]
	public class ItemInfo : System.Object {
		#region private member vars
		private int? _storeId;
		private string _itemId;
		private int? _productId;
		private int? _sqn;
		private string _pickLoc;
		private decimal? _price;
		private decimal? _salePrice;
		private decimal? _shippingCharge;
		private int? _reorderPoint;
		private int? _reorderQty;
        private int? _pageCount;
        private int? _partStatus;
		private string _attribute1Value;
		private string _attribute2Value;
		private string _attribute3Value;
		private int? _qtyReserved;
		private bool? _useupFlag;
		private bool? _activeFlag;
		private string _itemContent;
		private string _defaultContent;
		private bool? _customContentFlag;
        private decimal? _onfCost;
		private decimal? _inventoryCost;
		private string _inventoryOwner;
		private string _contentOwner;
		private int? _qtyStaged;
		private bool? _printOnDemandFlag;
		private bool? _cdFulfillmentFlag;
		private bool? _cdOnlyFlag;
        private decimal? _weight;
        private bool? _podOverRideFlag;
        private string _revision;
        private DateTime? _revisionDate;
        private string _documentationUrl;
        private int? _licenseTerm;
        private int? _licenseSeatCount;
        private bool? _onSecureFlag;

		#endregion


		#region constructors
		public ItemInfo() {
			//Current design requires non-null values.
			this.UseupFlag = false;
			this.QtyReserved = 0;
		}


		public ItemInfo(
			int? storeId,
			string itemId,
			int? productId,
			int? sqn,
			string pickLoc,
			decimal? price,
			decimal? salePrice,
			decimal? shippingCharge,
			int? reorderPoint,
			int? reorderQty,
			string attribute1Value,
			string attribute2Value,
			string attribute3Value,
			int? qtyReserved,
			bool? useupFlag,
			bool? activeFlag,
			string itemContent,
			string defaultContent,
			bool? customContentFlag,
            decimal? onfCost,
			decimal? inventoryCost,
			string inventoryOwner,
			string contentOwner,
			int? qtyStaged,
			bool? printOnDemandFlag,
			bool? cdFulfillmentFlag,
			bool? cdOnlyFlag,
            decimal? weight,
            bool? podOverRideFlag,
            bool? onSecureFlag
		) {
			this._storeId = storeId;
			this._itemId = itemId;
			this._productId = productId;
			this._sqn = sqn;
			this._pickLoc = pickLoc;
			this._price = price;
			this._salePrice = salePrice;
			this._shippingCharge = shippingCharge;
			this._reorderPoint = reorderPoint;
			this._reorderQty = reorderQty;
			this._attribute1Value = attribute1Value;
			this._attribute2Value = attribute2Value;
			this._attribute3Value = attribute3Value;
			this._qtyReserved = qtyReserved;
			this._useupFlag = useupFlag;
			this._activeFlag = activeFlag;
			this._itemContent = itemContent;
			this._defaultContent = defaultContent;
			this._customContentFlag = customContentFlag;
            this._onfCost = onfCost;
			this._inventoryCost = inventoryCost;
			this._inventoryOwner = inventoryOwner;
			this._contentOwner = contentOwner;
			this._qtyStaged = qtyStaged;
			this._printOnDemandFlag = printOnDemandFlag;
			this._cdFulfillmentFlag = cdFulfillmentFlag;
			this._cdOnlyFlag = cdOnlyFlag;
            this._weight = weight;
            this._podOverRideFlag = podOverRideFlag;
            this._onSecureFlag = onSecureFlag;
		}

        public ItemInfo(
            int? storeId,
            string itemId,
            int? productId,
            int? sqn,
            string pickLoc,
            decimal? price,
            decimal? salePrice,
            decimal? shippingCharge,
            int? reorderPoint,
            int? reorderQty,
            string attribute1Value,
            string attribute2Value,
            string attribute3Value,
            int? qtyReserved,
            bool? useupFlag,
            bool? activeFlag,
            string itemContent,
            string defaultContent,
            bool? customContentFlag,
            decimal? onfCost,
            decimal? inventoryCost,
            string inventoryOwner,
            string contentOwner,
            int? qtyStaged,
            bool? printOnDemandFlag,
            bool? cdFulfillmentFlag,
            bool? cdOnlyFlag,
            decimal? weight,
            bool? podOverRideFlag,
            string revision,
            DateTime? revisionDate,
            string documentationURL,
            int? licenseTerm,
            int? licenseSeatCount,
            bool? onSecureFlag
        )
        {
            this._storeId = storeId;
            this._itemId = itemId;
            this._productId = productId;
            this._sqn = sqn;
            this._pickLoc = pickLoc;
            this._price = price;
            this._salePrice = salePrice;
            this._shippingCharge = shippingCharge;
            this._reorderPoint = reorderPoint;
            this._reorderQty = reorderQty;
            this._attribute1Value = attribute1Value;
            this._attribute2Value = attribute2Value;
            this._attribute3Value = attribute3Value;
            this._qtyReserved = qtyReserved;
            this._useupFlag = useupFlag;
            this._activeFlag = activeFlag;
            this._itemContent = itemContent;
            this._defaultContent = defaultContent;
            this._customContentFlag = customContentFlag;
            this._onfCost = onfCost;
            this._inventoryCost = inventoryCost;
            this._inventoryOwner = inventoryOwner;
            this._contentOwner = contentOwner;
            this._qtyStaged = qtyStaged;
            this._printOnDemandFlag = printOnDemandFlag;
            this._cdFulfillmentFlag = cdFulfillmentFlag;
            this._cdOnlyFlag = cdOnlyFlag;
            this._weight = weight;
            this._podOverRideFlag = podOverRideFlag;
            this._revision = revision;
            this._revisionDate = revisionDate;
            this._documentationUrl = documentationURL;
            this._licenseTerm = licenseTerm;
            this._licenseSeatCount = licenseSeatCount;
            this._onSecureFlag = onSecureFlag;
        }
        #endregion


		#region public properties
		public int? StoreId {
			get {
				return _storeId;
			}
			set {
				_storeId = value;
			}
		}

		public string ItemId {
			get {
				return _itemId;
			}
			set {
				_itemId = value;
			}
		}

		public int? ProductId {
			get {
				return _productId;
			}
			set {
				_productId = value;
			}
		}

		public int? Sqn {
			get {
				return _sqn;
			}
			set {
				_sqn = value;
			}
		}

		public string PickLoc {
			get {
				return _pickLoc;
			}
			set {
				_pickLoc = value;
			}
		}

		public decimal? Price {
			get {
				return _price;
			}
			set {
				_price = value;
			}
		}

		public decimal? SalePrice {
			get {
				return _salePrice;
			}
			set {
				_salePrice = value;
			}
		}

		public decimal? ShippingCharge {
			get {
				return _shippingCharge;
			}
			set {
				_shippingCharge = value;
			}
		}

		public int? ReorderPoint {
			get {
				return _reorderPoint;
			}
			set {
				_reorderPoint = value;
			}
		}

		public int? ReorderQty {
			get {
				return _reorderQty;
			}
			set {
				_reorderQty = value;
			}
		}

        public int? PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
            }
        }

        public int? PartStatus
        {
            get
            {
                return _partStatus;
            }
            set
            {
                _partStatus = value;
            }
        }

		public string Attribute1Value {
			get {
				return _attribute1Value;
			}
			set {
				_attribute1Value = value;
			}
		}

		public string Attribute2Value {
			get {
				return _attribute2Value;
			}
			set {
				_attribute2Value = value;
			}
		}

		public string Attribute3Value {
			get {
				return _attribute3Value;
			}
			set {
				_attribute3Value = value;
			}
		}

		public int? QtyReserved {
			get {
				return _qtyReserved;
			}
			set {
				_qtyReserved = value;
			}
		}

		public bool? UseupFlag {
			get {
				return _useupFlag;
			}
			set {
				_useupFlag = value;
			}
		}

		public bool? ActiveFlag {
			get {
				return _activeFlag;
			}
			set {
				_activeFlag = value;
			}
		}

		public string ItemContent {
			get {
				return _itemContent;
			}
			set {
				_itemContent = value;
			}
		}

		public string DefaultContent {
			get {
				return _defaultContent;
			}
			set {
				_defaultContent = value;
			}
		}

		public bool? CustomContentFlag {
			get {
				return _customContentFlag;
			}
			set {
				_customContentFlag = value;
			}
		}

        public decimal? OnfCost
        {
            get
            {
                return _onfCost;
            }
            set
            {
                _onfCost = value;
            }
        }

		public decimal? InventoryCost {
			get {
				return _inventoryCost;
			}
			set {
				_inventoryCost = value;
			}
		}

		public string InventoryOwner {
			get {
				return _inventoryOwner;
			}
			set {
				_inventoryOwner = value;
			}
		}

		public string ContentOwner {
			get {
				return _contentOwner;
			}
			set {
				_contentOwner = value;
			}
		}

		public int? QtyStaged {
			get {
				return _qtyStaged;
			}
			set {
				_qtyStaged = value;
			}
		}

		public bool? PrintOnDemandFlag {
			get {
				return _printOnDemandFlag;
			}
			set {
				_printOnDemandFlag = value;
			}
		}

		public bool? CdFulfillmentFlag {
			get {
				return _cdFulfillmentFlag;
			}
			set {
				_cdFulfillmentFlag = value;
			}
		}

		public bool? CdOnlyFlag {
			get {
				return _cdOnlyFlag;
			}
			set {
				_cdOnlyFlag = value;
			}
		}

        public decimal? weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public bool? POD_OverrideFlag
        {
            get { return _podOverRideFlag; }
            set { _podOverRideFlag = value; }
        }

        public string Revision
        {
            get { return _revision; }
            set { _revision = value; }
        }

        public DateTime? RevisionDate
        {
            get { return _revisionDate; }
            set { _revisionDate = value; }
        }

        public string DocumentationURL
        {
            get { return _documentationUrl; }
            set { _documentationUrl = value; }
        }

        public int? LicenseTerm
        {
            get { return _licenseTerm; }
            set { _licenseTerm = value; }
        }

        public int? LicenseSeatCount
        {
            get { return _licenseSeatCount; }
            set { _licenseSeatCount = value; }
        }

        public bool? OnSecureFlag
        {
            get { return _onSecureFlag; }
            set { _onSecureFlag = value; }
        }

        #endregion
	}
}