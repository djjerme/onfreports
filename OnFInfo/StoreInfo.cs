namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class StoreInfo
    {
        private bool? _activeFlag;
        private bool? _autogen;
        private bool? _backordercreation;
        private string _btnCheckout;
        private string _btnModify;
        private string _bundleLabel;
        private string _cartAlinkColor;
        private string _cartBg;
        private string _cartBgColor;
        private string _cartBorderColor;
        private string _cartFontColor;
        private string _cartLinkColor;
        private string _cartTableFontColor;
        private string _cartVlinkColor;
        private int? _cartWidth;
        private string _CertiTaxID;
        private string _CertiTaxNexus;
        private int? _commentprinterid;
        private int? _contactUsPerson;
        private string _costCenterLabel;
        private string _customerContactEmail;
        private bool? _deletedFlag;
        private string _deptLabel;
        private string _divisionCostCenterLabel;
        private string _emailOrderConfirmTemplate;
        private string _emailShipConfirmTemplate;
        private string _fontColor;
        private string _fontFace;
        private int? _fontSize;
        private string _homePage;
        private string _introMsg;
        private int? _itemGraphicWidth;
        private string _itemLabel;
        private string _itemNameLabel;
        private string _leadAdminEmail;
        private decimal? _lineHandlingFee;
        private string _linkColor;
        private string _loginMsgBottom;
        private string _loginPage;
        private string _logoAlign;
        private int? _maxWidth;
        private string _name;
        private int? _nocommentprinterid;
        private decimal? _orderCanadaShippingCharge;
        private string _orderConfirmMsg;
        private decimal? _orderInternationalShippingCharge;
        private decimal? _orderShippingCharge;
        private string _overCommitRule;
        private string _productLabel;
        private string _productSubtypeLabel;
        private string _productTypeLabel;
        private bool? _publicAccessFlag;
        private bool? _search;
        private string _startDept;
        private string _startPage;
        private string _status;
        private string _storeBg;
        private int? _storeId;
        private string _storePath;
        private string _subDeptLabel;
        private string _tdBgColor;
        private string _tdColor;
        private string _thBgColor;
        private string _thColor;
        private string _title;
        private string _topBgColor;
        private string _topBorderColor;
        private bool? _topDeptRefresh;
        private int? _topFrameHeight;
        private int? _topGraphicHeight;
        private int? _topGraphicWidth;
        private string _userDeptLabel;
        private bool? _userRegions;
        private string _userRegionsLabel;
        private string _vlinkColor;
        private int? _whseId;

        public StoreInfo()
        {
        }

        public StoreInfo(int? storeId, int? whseId, string name, string title, bool? publicAccessFlag, bool? activeFlag, string logoAlign, string cartBg, int? cartWidth, string storeBg, bool? search, string status, string storePath, string loginPage, string startPage, string homePage, string startDept, int? topFrameHeight, string topBgColor, string topBorderColor, int? topGraphicHeight, int? topGraphicWidth, bool? topDeptRefresh, string btnCheckout, string btnModify, string linkColor, string vlinkColor, string cartLinkColor, string cartVlinkColor, string cartAlinkColor, string cartFontColor, string cartTableFontColor, string cartBgColor, string cartBorderColor, string fontFace, int? fontSize, string fontColor, string tdBgColor, string tdColor, string thBgColor, string thColor, string deptLabel, string subDeptLabel, string overCommitRule, string introMsg, string loginMsgBottom, string itemLabel, string itemNameLabel, int? itemGraphicWidth, decimal? lineHandlingFee, decimal? orderShippingCharge, decimal? orderCanadaShippingCharge, decimal? orderInternationalShippingCharge, string orderConfirmMsg, int? maxWidth, string productTypeLabel, bool? userRegions, string userRegionsLabel, string costCenterLabel, string divisionCostCenterLabel, string userDeptLabel, string productLabel, string bundleLabel, string productSubtypeLabel, string customerContactEmail, string certiTaxID, string certiTaxNexus, string leadAdminEmail, int? contactUsPerson, string emailShipConfirmTemplate, string emailOrderConfirmTemplate, bool? deletedFlag, bool? backordercreation, bool? autogen, int? nocommentprinterid, int? commentprinterid)
        {
            this._storeId = storeId;
            this._whseId = whseId;
            this._name = name;
            this._title = title;
            this._publicAccessFlag = publicAccessFlag;
            this._activeFlag = activeFlag;
            this._logoAlign = logoAlign;
            this._cartBg = cartBg;
            this._cartWidth = cartWidth;
            this._storeBg = storeBg;
            this._search = search;
            this._status = status;
            this._storePath = storePath;
            this._loginPage = loginPage;
            this._startPage = startPage;
            this._homePage = homePage;
            this._startDept = startDept;
            this._topFrameHeight = topFrameHeight;
            this._topBgColor = topBgColor;
            this._topBorderColor = topBorderColor;
            this._topGraphicHeight = topGraphicHeight;
            this._topGraphicWidth = topGraphicWidth;
            this._topDeptRefresh = topDeptRefresh;
            this._btnCheckout = btnCheckout;
            this._btnModify = btnModify;
            this._linkColor = linkColor;
            this._vlinkColor = vlinkColor;
            this._cartLinkColor = cartLinkColor;
            this._cartVlinkColor = cartVlinkColor;
            this._cartAlinkColor = cartAlinkColor;
            this._cartFontColor = cartFontColor;
            this._cartTableFontColor = cartTableFontColor;
            this._cartBgColor = cartBgColor;
            this._cartBorderColor = cartBorderColor;
            this._fontFace = fontFace;
            this._fontSize = fontSize;
            this._fontColor = fontColor;
            this._tdBgColor = tdBgColor;
            this._tdColor = tdColor;
            this._thBgColor = thBgColor;
            this._thColor = thColor;
            this._deptLabel = deptLabel;
            this._subDeptLabel = subDeptLabel;
            this._overCommitRule = overCommitRule;
            this._introMsg = introMsg;
            this._loginMsgBottom = loginMsgBottom;
            this._itemLabel = itemLabel;
            this._itemNameLabel = itemNameLabel;
            this._itemGraphicWidth = itemGraphicWidth;
            this._lineHandlingFee = lineHandlingFee;
            this._orderShippingCharge = orderShippingCharge;
            this._orderCanadaShippingCharge = orderCanadaShippingCharge;
            this._orderInternationalShippingCharge = orderInternationalShippingCharge;
            this._orderConfirmMsg = orderConfirmMsg;
            this._maxWidth = maxWidth;
            this._productTypeLabel = productTypeLabel;
            this._userRegions = userRegions;
            this._userRegionsLabel = userRegionsLabel;
            this._costCenterLabel = costCenterLabel;
            this._divisionCostCenterLabel = divisionCostCenterLabel;
            this._userDeptLabel = userDeptLabel;
            this._productLabel = productLabel;
            this._bundleLabel = bundleLabel;
            this._productSubtypeLabel = productSubtypeLabel;
            this._customerContactEmail = customerContactEmail;
            this._CertiTaxID = certiTaxID;
            this._CertiTaxNexus = certiTaxNexus;
            this._leadAdminEmail = leadAdminEmail;
            this._contactUsPerson = contactUsPerson;
            this._emailShipConfirmTemplate = emailShipConfirmTemplate;
            this._emailOrderConfirmTemplate = emailOrderConfirmTemplate;
            this._deletedFlag = deletedFlag;
            this._backordercreation = backordercreation;
            this._autogen = autogen;
            this._nocommentprinterid = nocommentprinterid;
            this._commentprinterid = commentprinterid;
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

        public bool? AutoGen
        {
            get
            {
                return this._autogen;
            }
            set
            {
                this._autogen = value;
            }
        }

        public bool? BackorderCreation
        {
            get
            {
                return this._backordercreation;
            }
            set
            {
                this._backordercreation = value;
            }
        }

        public string BtnCheckout
        {
            get
            {
                return this._btnCheckout;
            }
            set
            {
                this._btnCheckout = value;
            }
        }

        public string BtnModify
        {
            get
            {
                return this._btnModify;
            }
            set
            {
                this._btnModify = value;
            }
        }

        public string BundleLabel
        {
            get
            {
                return this._bundleLabel;
            }
            set
            {
                this._bundleLabel = value;
            }
        }

        public string CartAlinkColor
        {
            get
            {
                return this._cartAlinkColor;
            }
            set
            {
                this._cartAlinkColor = value;
            }
        }

        public string CartBg
        {
            get
            {
                return this._cartBg;
            }
            set
            {
                this._cartBg = value;
            }
        }

        public string CartBgColor
        {
            get
            {
                return this._cartBgColor;
            }
            set
            {
                this._cartBgColor = value;
            }
        }

        public string CartBorderColor
        {
            get
            {
                return this._cartBorderColor;
            }
            set
            {
                this._cartBorderColor = value;
            }
        }

        public string CartFontColor
        {
            get
            {
                return this._cartFontColor;
            }
            set
            {
                this._cartFontColor = value;
            }
        }

        public string CartLinkColor
        {
            get
            {
                return this._cartLinkColor;
            }
            set
            {
                this._cartLinkColor = value;
            }
        }

        public string CartTableFontColor
        {
            get
            {
                return this._cartTableFontColor;
            }
            set
            {
                this._cartTableFontColor = value;
            }
        }

        public string CartVlinkColor
        {
            get
            {
                return this._cartVlinkColor;
            }
            set
            {
                this._cartVlinkColor = value;
            }
        }

        public int? CartWidth
        {
            get
            {
                return this._cartWidth;
            }
            set
            {
                this._cartWidth = value;
            }
        }

        public string CertiTaxID
        {
            get
            {
                return this._CertiTaxID;
            }
            set
            {
                this._CertiTaxID = value;
            }
        }

        public string CertiTaxNexus
        {
            get
            {
                return this._CertiTaxNexus;
            }
            set
            {
                this._CertiTaxNexus = value;
            }
        }

        public int? CommentPrinterID
        {
            get
            {
                return this._commentprinterid;
            }
            set
            {
                this._commentprinterid = value;
            }
        }

        public int? ContactUsPerson
        {
            get
            {
                return this._contactUsPerson;
            }
            set
            {
                this._contactUsPerson = value;
            }
        }

        public string CostCenterLabel
        {
            get
            {
                return this._costCenterLabel;
            }
            set
            {
                this._costCenterLabel = value;
            }
        }

        public string CustomerContactEmail
        {
            get
            {
                return this._customerContactEmail;
            }
            set
            {
                this._customerContactEmail = value;
            }
        }

        public bool? DeletedFlag
        {
            get
            {
                return this._deletedFlag;
            }
            set
            {
                this._deletedFlag = value;
            }
        }

        public string DeptLabel
        {
            get
            {
                return this._deptLabel;
            }
            set
            {
                this._deptLabel = value;
            }
        }

        public string DivisionCostCenterLabel
        {
            get
            {
                return this._divisionCostCenterLabel;
            }
            set
            {
                this._divisionCostCenterLabel = value;
            }
        }

        public string EmailOrderConfirmTemplate
        {
            get
            {
                return this._emailOrderConfirmTemplate;
            }
            set
            {
                this._emailOrderConfirmTemplate = value;
            }
        }

        public string EmailShipConfirmTemplate
        {
            get
            {
                return this._emailShipConfirmTemplate;
            }
            set
            {
                this._emailShipConfirmTemplate = value;
            }
        }

        public string FontColor
        {
            get
            {
                return this._fontColor;
            }
            set
            {
                this._fontColor = value;
            }
        }

        public string FontFace
        {
            get
            {
                return this._fontFace;
            }
            set
            {
                this._fontFace = value;
            }
        }

        public int? FontSize
        {
            get
            {
                return this._fontSize;
            }
            set
            {
                this._fontSize = value;
            }
        }

        public string HomePage
        {
            get
            {
                return this._homePage;
            }
            set
            {
                this._homePage = value;
            }
        }

        public string IntroMsg
        {
            get
            {
                return this._introMsg;
            }
            set
            {
                this._introMsg = value;
            }
        }

        public int? ItemGraphicWidth
        {
            get
            {
                return this._itemGraphicWidth;
            }
            set
            {
                this._itemGraphicWidth = value;
            }
        }

        public string ItemLabel
        {
            get
            {
                return this._itemLabel;
            }
            set
            {
                this._itemLabel = value;
            }
        }

        public string ItemNameLabel
        {
            get
            {
                return this._itemNameLabel;
            }
            set
            {
                this._itemNameLabel = value;
            }
        }

        public string LeadAdminEmail
        {
            get
            {
                return this._leadAdminEmail;
            }
            set
            {
                this._leadAdminEmail = value;
            }
        }

        public decimal? LineHandlingFee
        {
            get
            {
                return this._lineHandlingFee;
            }
            set
            {
                this._lineHandlingFee = value;
            }
        }

        public string LinkColor
        {
            get
            {
                return this._linkColor;
            }
            set
            {
                this._linkColor = value;
            }
        }

        public string LoginMsgBottom
        {
            get
            {
                return this._loginMsgBottom;
            }
            set
            {
                this._loginMsgBottom = value;
            }
        }

        public string LoginPage
        {
            get
            {
                return this._loginPage;
            }
            set
            {
                this._loginPage = value;
            }
        }

        public string LogoAlign
        {
            get
            {
                return this._logoAlign;
            }
            set
            {
                this._logoAlign = value;
            }
        }

        public int? MaxWidth
        {
            get
            {
                return this._maxWidth;
            }
            set
            {
                this._maxWidth = value;
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

        public int? NoCommentPrinterID
        {
            get
            {
                return this._nocommentprinterid;
            }
            set
            {
                this._nocommentprinterid = value;
            }
        }

        public decimal? OrderCanadaShippingCharge
        {
            get
            {
                return this._orderCanadaShippingCharge;
            }
            set
            {
                this._orderCanadaShippingCharge = value;
            }
        }

        public string OrderConfirmMsg
        {
            get
            {
                return this._orderConfirmMsg;
            }
            set
            {
                this._orderConfirmMsg = value;
            }
        }

        public decimal? OrderInternationalShippingCharge
        {
            get
            {
                return this._orderInternationalShippingCharge;
            }
            set
            {
                this._orderInternationalShippingCharge = value;
            }
        }

        public decimal? OrderShippingCharge
        {
            get
            {
                return this._orderShippingCharge;
            }
            set
            {
                this._orderShippingCharge = value;
            }
        }

        public string OverCommitRule
        {
            get
            {
                return this._overCommitRule;
            }
            set
            {
                this._overCommitRule = value;
            }
        }

        public string ProductLabel
        {
            get
            {
                return this._productLabel;
            }
            set
            {
                this._productLabel = value;
            }
        }

        public string ProductSubtypeLabel
        {
            get
            {
                return this._productSubtypeLabel;
            }
            set
            {
                this._productSubtypeLabel = value;
            }
        }

        public string ProductTypeLabel
        {
            get
            {
                return this._productTypeLabel;
            }
            set
            {
                this._productTypeLabel = value;
            }
        }

        public bool? PublicAccessFlag
        {
            get
            {
                return this._publicAccessFlag;
            }
            set
            {
                this._publicAccessFlag = value;
            }
        }

        public bool? Search
        {
            get
            {
                return this._search;
            }
            set
            {
                this._search = value;
            }
        }

        public string StartDept
        {
            get
            {
                return this._startDept;
            }
            set
            {
                this._startDept = value;
            }
        }

        public string StartPage
        {
            get
            {
                return this._startPage;
            }
            set
            {
                this._startPage = value;
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

        public string StoreBg
        {
            get
            {
                return this._storeBg;
            }
            set
            {
                this._storeBg = value;
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

        public string StorePath
        {
            get
            {
                return this._storePath;
            }
            set
            {
                this._storePath = value;
            }
        }

        public string SubDeptLabel
        {
            get
            {
                return this._subDeptLabel;
            }
            set
            {
                this._subDeptLabel = value;
            }
        }

        public string TdBgColor
        {
            get
            {
                return this._tdBgColor;
            }
            set
            {
                this._tdBgColor = value;
            }
        }

        public string TdColor
        {
            get
            {
                return this._tdColor;
            }
            set
            {
                this._tdColor = value;
            }
        }

        public string ThBgColor
        {
            get
            {
                return this._thBgColor;
            }
            set
            {
                this._thBgColor = value;
            }
        }

        public string ThColor
        {
            get
            {
                return this._thColor;
            }
            set
            {
                this._thColor = value;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public string TopBgColor
        {
            get
            {
                return this._topBgColor;
            }
            set
            {
                this._topBgColor = value;
            }
        }

        public string TopBorderColor
        {
            get
            {
                return this._topBorderColor;
            }
            set
            {
                this._topBorderColor = value;
            }
        }

        public bool? TopDeptRefresh
        {
            get
            {
                return this._topDeptRefresh;
            }
            set
            {
                this._topDeptRefresh = value;
            }
        }

        public int? TopFrameHeight
        {
            get
            {
                return this._topFrameHeight;
            }
            set
            {
                this._topFrameHeight = value;
            }
        }

        public int? TopGraphicHeight
        {
            get
            {
                return this._topGraphicHeight;
            }
            set
            {
                this._topGraphicHeight = value;
            }
        }

        public int? TopGraphicWidth
        {
            get
            {
                return this._topGraphicWidth;
            }
            set
            {
                this._topGraphicWidth = value;
            }
        }

        public string UserDeptLabel
        {
            get
            {
                return this._userDeptLabel;
            }
            set
            {
                this._userDeptLabel = value;
            }
        }

        public bool? UserRegions
        {
            get
            {
                return this._userRegions;
            }
            set
            {
                this._userRegions = value;
            }
        }

        public string UserRegionsLabel
        {
            get
            {
                return this._userRegionsLabel;
            }
            set
            {
                this._userRegionsLabel = value;
            }
        }

        public string VlinkColor
        {
            get
            {
                return this._vlinkColor;
            }
            set
            {
                this._vlinkColor = value;
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

