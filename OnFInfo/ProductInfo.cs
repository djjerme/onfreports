namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class ProductInfo
    {
        private bool? _activeFlag;
        private bool? _adminOnlyFlag;
        private bool? _allowBackOrder;
        private string _attribute1Label;
        private string _attribute2Label;
        private string _attribute3Label;
        private bool? _automatedPdfUpload;
        private bool? _automatedPptUpload;
        private bool? _automatedWordUpload;
        private bool? _ccReimbursement;
        private bool? _checkoutEventFlag;
        private DateTime? _createdDate;
        private DateTime? _expirationDate;
        private bool? _featuredFlag;
        private bool? _graphicFlag;
        private bool? _hiResFlag;
        private string _hiResImgExtension;
        private bool? _hiResOnlyFlag;
        private PBA.OnfInfo.ItemInfo[] _items;
        private int? _leadTime;
        private string _longDesc;
        private int? _maxOrderQty;
        private int? _minOrderQty;
        private bool? _moreInfoFlag;
        private bool? _multiItemFlag;
        private string _name;
        private DateTime? _newUntilDate;
        private bool? _pdfFlag;
        private bool? _pdfOnlyFlag;
        private bool? _pptFlag;
        private bool? _pptOnlyFlag;
        private int? _productId;
        private int? _productType;
        private string _reorderPtCcEmail;
        private bool? _saleFlag;
        private DateTime? _scheduledReleaseDate;
        private string _shortDesc;
        private int? _storeId;
        private int? _tempDept;
        private string _UOM;
        private DateTime? _updateUntilDate;
        private string _url;
        private string _urlLabel;
        private bool? _virtualFulfillment;
        private int? _virtualFulfillmentDuration;
        private string _virtualFulfillmentFilename;
        private string _virtualFulfillmentInfo;
        private bool? _wordFlag;
        private bool? _wordOnlyFlag;

        public ProductInfo()
        {
        }

        public ProductInfo(int? storeId, int? productId, string name, string shortDesc, string longDesc, bool? graphicFlag, bool? pdfFlag, bool? automatedPdfUpload, bool? multiItemFlag, string attribute1Label, string attribute2Label, string attribute3Label, bool? adminOnlyFlag, bool? saleFlag, DateTime? newUntilDate, DateTime? updateUntilDate, DateTime? createdDate, DateTime? scheduledReleaseDate, DateTime? expirationDate, bool? featuredFlag, bool? activeFlag, string UOM, int? minOrderQty, int? maxOrderQty, bool? allowBackOrder, int? leadTime, int? productType, string url, string urlLabel, string reorderPtCcEmail, bool? moreInfoFlag, bool? checkoutEventFlag, int? tempDept, bool? pdfOnlyFlag, string virtualFulfillmentFilename, bool? virtualFulfillment, string virtualFulfillmentInfo, int? virtualFulfillmentDuration, bool? pptFlag, bool? automatedPptUpload, bool? pptOnlyFlag, bool? wordFlag, bool? automatedWordUpload, bool? wordOnlyFlag, bool? hiResFlag, bool? hiResOnlyFlag, string hiResImgExtension)
        {
            this._storeId = storeId;
            this._productId = productId;
            this._name = name;
            this._shortDesc = shortDesc;
            this._longDesc = longDesc;
            this._graphicFlag = graphicFlag;
            this._pdfFlag = pdfFlag;
            this._automatedPdfUpload = automatedPdfUpload;
            this._multiItemFlag = multiItemFlag;
            this._attribute1Label = attribute1Label;
            this._attribute2Label = attribute2Label;
            this._attribute3Label = attribute3Label;
            this._adminOnlyFlag = adminOnlyFlag;
            this._saleFlag = saleFlag;
            this._newUntilDate = newUntilDate;
            this._updateUntilDate = updateUntilDate;
            this._createdDate = createdDate;
            this._scheduledReleaseDate = scheduledReleaseDate;
            this._expirationDate = expirationDate;
            this._featuredFlag = featuredFlag;
            this._activeFlag = activeFlag;
            this._UOM = UOM;
            this._minOrderQty = minOrderQty;
            this._maxOrderQty = maxOrderQty;
            this._allowBackOrder = allowBackOrder;
            this._leadTime = leadTime;
            this._productType = productType;
            this._url = url;
            this._urlLabel = urlLabel;
            this._reorderPtCcEmail = reorderPtCcEmail;
            this._moreInfoFlag = moreInfoFlag;
            this._checkoutEventFlag = checkoutEventFlag;
            this._tempDept = tempDept;
            this._pdfOnlyFlag = pdfOnlyFlag;
            this._virtualFulfillmentFilename = virtualFulfillmentFilename;
            this._virtualFulfillment = virtualFulfillment;
            this._virtualFulfillmentInfo = virtualFulfillmentInfo;
            this._virtualFulfillmentDuration = virtualFulfillmentDuration;
            this._pptFlag = pptFlag;
            this._automatedPptUpload = automatedPptUpload;
            this._pptOnlyFlag = pptOnlyFlag;
            this._wordFlag = wordFlag;
            this._automatedWordUpload = automatedWordUpload;
            this._wordOnlyFlag = wordOnlyFlag;
            this._hiResFlag = hiResFlag;
            this._hiResOnlyFlag = hiResOnlyFlag;
            this._hiResImgExtension = hiResImgExtension;
        }

        public bool? ActiveFlag
        {
            get
            {
                return this._activeFlag;
            }
            set
            {
                this._activeFlag = value;
            }
        }

        public bool? AdminOnlyFlag
        {
            get
            {
                return this._adminOnlyFlag;
            }
            set
            {
                this._adminOnlyFlag = value;
            }
        }

        public bool? AllowBackOrder
        {
            get
            {
                return this._allowBackOrder;
            }
            set
            {
                this._allowBackOrder = value;
            }
        }

        public string Attribute1Label
        {
            get
            {
                return this._attribute1Label;
            }
            set
            {
                this._attribute1Label = value;
            }
        }

        public string Attribute2Label
        {
            get
            {
                return this._attribute2Label;
            }
            set
            {
                this._attribute2Label = value;
            }
        }

        public string Attribute3Label
        {
            get
            {
                return this._attribute3Label;
            }
            set
            {
                this._attribute3Label = value;
            }
        }

        public bool? AutomatedPdfUpload
        {
            get
            {
                return this._automatedPdfUpload;
            }
            set
            {
                this._automatedPdfUpload = value;
            }
        }

        public bool? AutomatedPptUpload
        {
            get
            {
                return this._automatedPptUpload;
            }
            set
            {
                this._automatedPptUpload = value;
            }
        }

        public bool? AutomatedWordUpload
        {
            get
            {
                return this._automatedWordUpload;
            }
            set
            {
                this._automatedWordUpload = value;
            }
        }

        public bool? CCReimbursement
        {
            get
            {
                return this._ccReimbursement;
            }
            set
            {
                this._ccReimbursement = value;
            }
        }

        public bool? CheckoutEventFlag
        {
            get
            {
                return this._checkoutEventFlag;
            }
            set
            {
                this._checkoutEventFlag = value;
            }
        }

        public DateTime? createdDate
        {
            get
            {
                return this._createdDate;
            }
            set
            {
                this._createdDate = value;
            }
        }

        public DateTime? ExpirationDate
        {
            get
            {
                return this._expirationDate;
            }
            set
            {
                this._expirationDate = value;
            }
        }

        public bool? FeaturedFlag
        {
            get
            {
                return this._featuredFlag;
            }
            set
            {
                this._featuredFlag = value;
            }
        }

        public bool? GraphicFlag
        {
            get
            {
                return this._graphicFlag;
            }
            set
            {
                this._graphicFlag = value;
            }
        }

        public bool? HiResFlag
        {
            get
            {
                return this._hiResFlag;
            }
            set
            {
                this._hiResFlag = value;
            }
        }

        public string HiResImgExtension
        {
            get
            {
                return this._hiResImgExtension;
            }
            set
            {
                this._hiResImgExtension = value;
            }
        }

        public bool? HiResOnlyFlag
        {
            get
            {
                return this._hiResOnlyFlag;
            }
            set
            {
                this._hiResOnlyFlag = value;
            }
        }

        public PBA.OnfInfo.ItemInfo[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        public int? LeadTime
        {
            get
            {
                return this._leadTime;
            }
            set
            {
                this._leadTime = value;
            }
        }

        public string LongDesc
        {
            get
            {
                return this._longDesc;
            }
            set
            {
                this._longDesc = value;
            }
        }

        public int? MaxOrderQty
        {
            get
            {
                return this._maxOrderQty;
            }
            set
            {
                this._maxOrderQty = value;
            }
        }

        public int? MinOrderQty
        {
            get
            {
                return this._minOrderQty;
            }
            set
            {
                this._minOrderQty = value;
            }
        }

        public bool? MoreInfoFlag
        {
            get
            {
                return this._moreInfoFlag;
            }
            set
            {
                this._moreInfoFlag = value;
            }
        }

        public bool? MultiItemFlag
        {
            get
            {
                return this._multiItemFlag;
            }
            set
            {
                this._multiItemFlag = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public DateTime? NewUntilDate
        {
            get
            {
                return this._newUntilDate;
            }
            set
            {
                this._newUntilDate = value;
            }
        }

        public bool? PdfFlag
        {
            get
            {
                return this._pdfFlag;
            }
            set
            {
                this._pdfFlag = value;
            }
        }

        public bool? PdfOnlyFlag
        {
            get
            {
                return this._pdfOnlyFlag;
            }
            set
            {
                this._pdfOnlyFlag = value;
            }
        }

        public bool? PptFlag
        {
            get
            {
                return this._pptFlag;
            }
            set
            {
                this._pptFlag = value;
            }
        }

        public bool? PptOnlyFlag
        {
            get
            {
                return this._pptOnlyFlag;
            }
            set
            {
                this._pptOnlyFlag = value;
            }
        }

        public int? ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }

        public int? ProductType
        {
            get
            {
                return this._productType;
            }
            set
            {
                this._productType = value;
            }
        }

        public string ReorderPtCcEmail
        {
            get
            {
                return this._reorderPtCcEmail;
            }
            set
            {
                this._reorderPtCcEmail = value;
            }
        }

        public bool? SaleFlag
        {
            get
            {
                return this._saleFlag;
            }
            set
            {
                this._saleFlag = value;
            }
        }

        public DateTime? ScheduledReleaseDate
        {
            get
            {
                return this._scheduledReleaseDate;
            }
            set
            {
                this._scheduledReleaseDate = value;
            }
        }

        public string ShortDesc
        {
            get
            {
                return this._shortDesc;
            }
            set
            {
                this._shortDesc = value;
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

        public int? TempDept
        {
            get
            {
                return this._tempDept;
            }
            set
            {
                this._tempDept = value;
            }
        }

        public string UOM
        {
            get
            {
                return this._UOM;
            }
            set
            {
                this._UOM = value;
            }
        }

        public DateTime? UpdateUntilDate
        {
            get
            {
                return this._updateUntilDate;
            }
            set
            {
                this._updateUntilDate = value;
            }
        }

        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }
        }

        public string UrlLabel
        {
            get
            {
                return this._urlLabel;
            }
            set
            {
                this._urlLabel = value;
            }
        }

        public bool? VirtualFulfillment
        {
            get
            {
                return this._virtualFulfillment;
            }
            set
            {
                this._virtualFulfillment = value;
            }
        }

        public int? VirtualFulfillmentDuration
        {
            get
            {
                return this._virtualFulfillmentDuration;
            }
            set
            {
                this._virtualFulfillmentDuration = value;
            }
        }

        public string VirtualFulfillmentFilename
        {
            get
            {
                return this._virtualFulfillmentFilename;
            }
            set
            {
                this._virtualFulfillmentFilename = value;
            }
        }

        public string VirtualFulfillmentInfo
        {
            get
            {
                return this._virtualFulfillmentInfo;
            }
            set
            {
                this._virtualFulfillmentInfo = value;
            }
        }

        public bool? WordFlag
        {
            get
            {
                return this._wordFlag;
            }
            set
            {
                this._wordFlag = value;
            }
        }

        public bool? WordOnlyFlag
        {
            get
            {
                return this._wordOnlyFlag;
            }
            set
            {
                this._wordOnlyFlag = value;
            }
        }
    }
}

