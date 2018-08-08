namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class UserTypeInfo
    {
        private bool? mAddToCartFlag;
        private bool? mAdminFlag;
        private bool? mChooseCostCenterFlag;
        private bool? mGodFlag;
        private bool? mManagerFlag;
        private bool? mOnFulfillFlag;
        private bool? mOrderForFlag;
        private bool? mOrderOneFlag;
        private bool? mPaymentRequiredFlag;
        private bool? mPOPaymentOptionFlag;
        private bool? mReorderNotifyFlag;
        private bool? mReportMasterFlag;
        private bool? mSecurityFlag;
        private bool? mShowAvailableFlag;
        private bool? mShowPriceFlag;
        private bool? mSourceCodeAccessFlag;
        private int? mStoreId;
        private bool? mSuperAdminFlag;
        private string mUserType;
        private bool? mVirtualFulfillmentFlag;
        private bool? mWhseFlag;

        public UserTypeInfo()
        {
        }

        public UserTypeInfo(int? sid, string defaultUserType)
        {
            if (defaultUserType.ToLower() == "public")
            {
                this.StoreId = sid;
                this.UserType = "public";
                this.ShowPriceFlag = false;
                this.ShowAvailableFlag = false;
                this.PaymentRequiredFlag = false;
                this.AdminFlag = false;
                this.SuperAdminFlag = false;
                this.SecurityFlag = false;
                this.ManagerFlag = false;
                this.ReorderNotifyFlag = false;
                this.ChooseCostCenterFlag = false;
                this.OrderForFlag = false;
                this.OnFulfillFlag = false;
                this.GodFlag = false;
                this.WhseFlag = false;
                this.ReportMasterFlag = false;
                this.OrderOneFlag = false;
                this.POPaymentOptionFlag = false;
                this.SourceCodeAccessFlag = false;
                this.AddToCartFlag = false;
                this.VirtualFulfillmentFlag = false;
            }
        }

        public UserTypeInfo(int? storeid, string usertYpe, bool? showpriceflag, bool? showavailableflag, bool? paymentrequiredflag, bool? adminflag, bool? superadminflag, bool? securityflag, bool? managerflag, bool? reordernotifyflag, bool? choosecostcenterflag, bool? orderforflag, bool? onfulfillflag, bool? godflag, bool? whseflag, bool? reportmasterflag, bool? orderoneflag, bool? popaymentoptionflag, bool? sourcecodeaccessflag, bool? addtocartflag, bool? virtualfulfillmentflag)
        {
            this.mStoreId = storeid;
            this.mUserType = usertYpe;
            this.mShowPriceFlag = showpriceflag;
            this.mShowAvailableFlag = showavailableflag;
            this.mPaymentRequiredFlag = paymentrequiredflag;
            this.mAdminFlag = adminflag;
            this.mSuperAdminFlag = superadminflag;
            this.mSecurityFlag = securityflag;
            this.mManagerFlag = managerflag;
            this.mReorderNotifyFlag = reordernotifyflag;
            this.mChooseCostCenterFlag = choosecostcenterflag;
            this.mOrderForFlag = orderforflag;
            this.mOnFulfillFlag = onfulfillflag;
            this.mGodFlag = godflag;
            this.mWhseFlag = whseflag;
            this.mReportMasterFlag = reportmasterflag;
            this.mOrderOneFlag = orderoneflag;
            this.mPOPaymentOptionFlag = popaymentoptionflag;
            this.mSourceCodeAccessFlag = sourcecodeaccessflag;
            this.mAddToCartFlag = addtocartflag;
            this.mVirtualFulfillmentFlag = virtualfulfillmentflag;
        }

        public bool? AddToCartFlag
        {
            get
            {
                return this.mAddToCartFlag;
            }
            set
            {
                this.mAddToCartFlag = value;
            }
        }

        public bool? AdminFlag
        {
            get
            {
                return this.mAdminFlag;
            }
            set
            {
                this.mAdminFlag = value;
            }
        }

        public bool? ChooseCostCenterFlag
        {
            get
            {
                return this.mChooseCostCenterFlag;
            }
            set
            {
                this.mChooseCostCenterFlag = value;
            }
        }

        public bool? GodFlag
        {
            get
            {
                return this.mGodFlag;
            }
            set
            {
                this.mGodFlag = value;
            }
        }

        public bool? ManagerFlag
        {
            get
            {
                return this.mManagerFlag;
            }
            set
            {
                this.mManagerFlag = value;
            }
        }

        public bool? OnFulfillFlag
        {
            get
            {
                return this.mOnFulfillFlag;
            }
            set
            {
                this.mOnFulfillFlag = value;
            }
        }

        public bool? OrderForFlag
        {
            get
            {
                return this.mOrderForFlag;
            }
            set
            {
                this.mOrderForFlag = value;
            }
        }

        public bool? OrderOneFlag
        {
            get
            {
                return this.mOrderOneFlag;
            }
            set
            {
                this.mOrderOneFlag = value;
            }
        }

        public bool? PaymentRequiredFlag
        {
            get
            {
                return this.mPaymentRequiredFlag;
            }
            set
            {
                this.mPaymentRequiredFlag = value;
            }
        }

        public bool? POPaymentOptionFlag
        {
            get
            {
                return this.mPOPaymentOptionFlag;
            }
            set
            {
                this.mPOPaymentOptionFlag = value;
            }
        }

        public bool? ReorderNotifyFlag
        {
            get
            {
                return this.mReorderNotifyFlag;
            }
            set
            {
                this.mReorderNotifyFlag = value;
            }
        }

        public bool? ReportMasterFlag
        {
            get
            {
                return this.mReportMasterFlag;
            }
            set
            {
                this.mReportMasterFlag = value;
            }
        }

        public bool? SecurityFlag
        {
            get
            {
                return this.mSecurityFlag;
            }
            set
            {
                this.mSecurityFlag = value;
            }
        }

        public bool? ShowAvailableFlag
        {
            get
            {
                return this.mShowAvailableFlag;
            }
            set
            {
                this.mShowAvailableFlag = value;
            }
        }

        public bool? ShowPriceFlag
        {
            get
            {
                return this.mShowPriceFlag;
            }
            set
            {
                this.mShowPriceFlag = value;
            }
        }

        public bool? SourceCodeAccessFlag
        {
            get
            {
                return this.mSourceCodeAccessFlag;
            }
            set
            {
                this.mSourceCodeAccessFlag = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this.mStoreId;
            }
            set
            {
                this.mStoreId = value;
            }
        }

        public bool? SuperAdminFlag
        {
            get
            {
                return this.mSuperAdminFlag;
            }
            set
            {
                this.mSuperAdminFlag = value;
            }
        }

        public string UserType
        {
            get
            {
                return this.mUserType;
            }
            set
            {
                this.mUserType = value;
            }
        }

        public bool? VirtualFulfillmentFlag
        {
            get
            {
                return this.mVirtualFulfillmentFlag;
            }
            set
            {
                this.mVirtualFulfillmentFlag = value;
            }
        }

        public bool? WhseFlag
        {
            get
            {
                return this.mWhseFlag;
            }
            set
            {
                this.mWhseFlag = value;
            }
        }
    }
}

