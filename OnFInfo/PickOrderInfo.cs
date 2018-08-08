namespace PBA.OnfInfo
{
    using System;
    using System.Text;

    [Serializable]
    public class PickOrderInfo
    {
        private string mActualShipMethod;
        private string mAddress1;
        private string mAddress2;
        private string mAddress3;
        private int? mAvailableLines;
        private bool? mBulkOrderParentFlag;
        private int? mBulkOrderParentId;
        private string mBusinessPhone;
        private bool? mCDFulfillmentFlag;
        private int? mCDQty;
        private string mCity;
        private string mCompany;
        private string mCountry;
        private string mDemographics3;
        private string mEmail;
        private string mExpedite;
        private double? mHandling;
        private string mHomePhone;
        private string mLabel;
        private int? mLineCount;
        private double? mMerchandiseTotal;
        private DateTime? mNeedDate;
        private int? mNotOnHandLineCount;
        private int? mOrderFor;
        private string mOrderForName;
        private int? mOrderId;
        private string mOrderReason;
        private int? mOrderSuffix;
        private string mOrderType;
        private DateTime? mOrderWhen;
        private int? mPersonId;
        private string mPickBy;
        private string mQuoteId;
        private string mRequestedShipMethod;
        private double? mSalesTax;
        private string mShipAttnTo;
        private string mShipBy;
        private DateTime? mShipDate;
        private string mShipLabelComment;
        private string mShipName;
        private double? mShipping;
        private bool? mStagedOrderFlag;
        private int? mStagingId;
        private string mState;
        private string mStatus;
        private int? mStoreId;
        private string mStoreName;
        private bool? mThirdPartyShipperFlag;
        private string mThirdPartyShipperInfo;
        private int? mTotalQtyOnHand;
        private int? mTotalQtyReserved;
        private string mTrackingNo;
        private string mTransactionId;
        private int? mUnavailableLineCount;
        private string mUserName;
        private string mWarehouseComment;
        private int? mWhseId;
        private string mZip;

        public PickOrderInfo()
        {
        }

        public PickOrderInfo(int? storeid, int? orderid, int? ordersuffix, string ordertype, string status, int? personid, int? orderfor, DateTime? orderwhen, string trackingno, DateTime? needdate, string quoteid, bool? bulkorderparentflag, int? bulkorderparentid, bool? cdfulfillmentflag, int? cdqty, string transactionid, bool? stagedorderflag, int? stagingid, string username, string orderforname, string expedite, int? whseid, string storename, int? totalqtyonhand, int? totalqtyreserved, int? linecount, int? notonhandlinecount, int? unavailablelinecount, int? availablelines)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mOrderType = ordertype;
            this.mStatus = status;
            this.mPersonId = personid;
            this.mOrderFor = orderfor;
            this.mOrderWhen = orderwhen;
            this.mTrackingNo = trackingno;
            this.mNeedDate = needdate;
            this.mQuoteId = quoteid;
            this.mBulkOrderParentFlag = bulkorderparentflag;
            this.mBulkOrderParentId = bulkorderparentid;
            this.mCDFulfillmentFlag = cdfulfillmentflag;
            this.mCDQty = cdqty;
            this.mTransactionId = transactionid;
            this.mStagedOrderFlag = stagedorderflag;
            this.mStagingId = stagingid;
            this.mUserName = username;
            this.mOrderForName = orderforname;
            this.mExpedite = expedite;
            this.mWhseId = whseid;
            this.mStoreName = storename;
            this.mTotalQtyOnHand = totalqtyonhand;
            this.mTotalQtyReserved = totalqtyreserved;
            this.mLineCount = linecount;
            this.mNotOnHandLineCount = notonhandlinecount;
            this.mUnavailableLineCount = unavailablelinecount;
            this.mAvailableLines = availablelines;
        }

        public PickOrderInfo(int? storeid, int? orderid, int? ordersuffix, string ordertype, string status, int? personid, int? orderfor, DateTime? orderwhen, string trackingno, DateTime? needdate, string quoteid, bool? bulkorderparentflag, int? bulkorderparentid, bool? cdfulfillmentflag, int? cdqty, string transactionid, bool? stagedorderflag, int? stagingid, string username, string orderforname, string expedite, int? whseid, string storename, int? totalqtyonhand, int? totalqtyreserved, int? linecount, int? notonhandlinecount, int? unavailablelinecount, int? availablelines, string shipname, string label, string company, string address1, string address2, string address3, string city, string state, string zip, string country, string businessphone, string homephone, string email, string pickby, DateTime? shipdate, string shipby, string requestedshipmethod, string actualshipmethod, string warehousecomment, string shiplabelcomment, string orderreason, double? salestax, double? handling, double? shipping, string demographics3, bool? thirdpartyshipperflag, string thirdpartyshipperinfo, string shipattnto, double? merchandisetotal)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mOrderType = ordertype;
            this.mStatus = status;
            this.mPersonId = personid;
            this.mOrderFor = orderfor;
            this.mOrderWhen = orderwhen;
            this.mTrackingNo = trackingno;
            this.mNeedDate = needdate;
            this.mQuoteId = quoteid;
            this.mBulkOrderParentFlag = bulkorderparentflag;
            this.mBulkOrderParentId = bulkorderparentid;
            this.mCDFulfillmentFlag = cdfulfillmentflag;
            this.mCDQty = cdqty;
            this.mTransactionId = transactionid;
            this.mStagedOrderFlag = stagedorderflag;
            this.mStagingId = stagingid;
            this.mUserName = username;
            this.mOrderForName = orderforname;
            this.mExpedite = expedite;
            this.mWhseId = whseid;
            this.mStoreName = storename;
            this.mTotalQtyOnHand = totalqtyonhand;
            this.mTotalQtyReserved = totalqtyreserved;
            this.mLineCount = linecount;
            this.mNotOnHandLineCount = notonhandlinecount;
            this.mUnavailableLineCount = unavailablelinecount;
            this.mAvailableLines = availablelines;
            this.mShipName = shipname;
            this.mLabel = label;
            this.mCompany = company;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mAddress3 = address3;
            this.mCity = city;
            this.mState = state;
            this.mZip = zip;
            this.mCountry = country;
            this.mBusinessPhone = businessphone;
            this.mHomePhone = homephone;
            this.mEmail = email;
            this.mPickBy = pickby;
            this.mShipDate = shipdate;
            this.mShipBy = shipby;
            this.mRequestedShipMethod = requestedshipmethod;
            this.mActualShipMethod = actualshipmethod;
            this.mWarehouseComment = warehousecomment;
            this.mShipLabelComment = shiplabelcomment;
            this.mOrderReason = orderreason;
            this.mSalesTax = salestax;
            this.mHandling = handling;
            this.mShipping = shipping;
            this.mDemographics3 = demographics3;
            this.mThirdPartyShipperFlag = thirdpartyshipperflag;
            this.mThirdPartyShipperInfo = thirdpartyshipperinfo;
            this.mShipAttnTo = shipattnto;
            this.mMerchandiseTotal = merchandisetotal;
        }

        public string ActualShipMethod
        {
            get
            {
                return this.mActualShipMethod;
            }
            set
            {
                this.mActualShipMethod = value;
            }
        }

        public string Address1
        {
            get
            {
                return this.mAddress1;
            }
            set
            {
                this.mAddress1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this.mAddress2;
            }
            set
            {
                this.mAddress2 = value;
            }
        }

        public string Address3
        {
            get
            {
                return this.mAddress3;
            }
            set
            {
                this.mAddress3 = value;
            }
        }

        public int? AvailableLines
        {
            get
            {
                return this.mAvailableLines;
            }
            set
            {
                this.mAvailableLines = value;
            }
        }

        public bool? BulkOrderParentFlag
        {
            get
            {
                return this.mBulkOrderParentFlag;
            }
            set
            {
                this.mBulkOrderParentFlag = value;
            }
        }

        public int? BulkOrderParentId
        {
            get
            {
                return this.mBulkOrderParentId;
            }
            set
            {
                this.mBulkOrderParentId = value;
            }
        }

        public string BusinessPhone
        {
            get
            {
                return this.mBusinessPhone;
            }
            set
            {
                this.mBusinessPhone = value;
            }
        }

        public string CCReferenceIdFormatted
        {
            get
            {
                string str = "";
                if ((this.mQuoteId != null) && (this.mQuoteId != ""))
                {
                    str = string.Format("{0}-{1}", this.mStoreId, this.mQuoteId);
                }
                return str;
            }
        }

        public bool? CDFulfillmentFlag
        {
            get
            {
                return this.mCDFulfillmentFlag;
            }
            set
            {
                this.mCDFulfillmentFlag = value;
            }
        }

        public int? CDQty
        {
            get
            {
                return this.mCDQty;
            }
            set
            {
                this.mCDQty = value;
            }
        }

        public string City
        {
            get
            {
                return this.mCity;
            }
            set
            {
                this.mCity = value;
            }
        }

        public string Company
        {
            get
            {
                return this.mCompany;
            }
            set
            {
                this.mCompany = value;
            }
        }

        public string Country
        {
            get
            {
                return this.mCountry;
            }
            set
            {
                this.mCountry = value;
            }
        }

        public string Demographics3
        {
            get
            {
                return this.mDemographics3;
            }
            set
            {
                this.mDemographics3 = value;
            }
        }

        public string Email
        {
            get
            {
                return this.mEmail;
            }
            set
            {
                this.mEmail = value;
            }
        }

        public string Expedite
        {
            get
            {
                return this.mExpedite;
            }
            set
            {
                this.mExpedite = value;
            }
        }

        public double? Handling
        {
            get
            {
                return this.mHandling;
            }
            set
            {
                this.mHandling = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return this.mHomePhone;
            }
            set
            {
                this.mHomePhone = value;
            }
        }

        public string Label
        {
            get
            {
                return this.mLabel;
            }
            set
            {
                this.mLabel = value;
            }
        }

        public int? LineCount
        {
            get
            {
                return this.mLineCount;
            }
            set
            {
                this.mLineCount = value;
            }
        }

        public double? MerchandiseTotal
        {
            get
            {
                return this.mMerchandiseTotal;
            }
            set
            {
                this.mMerchandiseTotal = value;
            }
        }

        public DateTime? NeedDate
        {
            get
            {
                return this.mNeedDate;
            }
            set
            {
                this.mNeedDate = value;
            }
        }

        public int? NotOnHandLineCount
        {
            get
            {
                return this.mNotOnHandLineCount;
            }
            set
            {
                this.mNotOnHandLineCount = value;
            }
        }

        public int? OrderFor
        {
            get
            {
                return this.mOrderFor;
            }
            set
            {
                this.mOrderFor = value;
            }
        }

        public string OrderForName
        {
            get
            {
                return this.mOrderForName;
            }
            set
            {
                this.mOrderForName = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return this.mOrderId;
            }
            set
            {
                this.mOrderId = value;
            }
        }

        public string OrderIdFormatted
        {
            get
            {
                return string.Format("{0}-{1}", this.mOrderId, this.mOrderSuffix);
            }
        }

        public string OrderReason
        {
            get
            {
                return this.mOrderReason;
            }
            set
            {
                this.mOrderReason = value;
            }
        }

        public int? OrderSuffix
        {
            get
            {
                return this.mOrderSuffix;
            }
            set
            {
                this.mOrderSuffix = value;
            }
        }

        public double? OrderTotal
        {
            get
            {
                double? nullable4;
                double? mMerchandiseTotal = this.mMerchandiseTotal;
                double? mSalesTax = this.mSalesTax;
                mMerchandiseTotal = (mMerchandiseTotal.HasValue & mSalesTax.HasValue) ? new double?(mMerchandiseTotal.GetValueOrDefault() + mSalesTax.GetValueOrDefault()) : ((double?) (nullable4 = null));
                mSalesTax = this.mHandling;
                return (((mMerchandiseTotal.HasValue & mSalesTax.HasValue) ? new double?(mMerchandiseTotal.GetValueOrDefault() + mSalesTax.GetValueOrDefault()) : ((double?) (nullable4 = null))) + this.mShipping);
            }
        }

        public string OrderType
        {
            get
            {
                return this.mOrderType;
            }
            set
            {
                this.mOrderType = value;
            }
        }

        public DateTime? OrderWhen
        {
            get
            {
                return this.mOrderWhen;
            }
            set
            {
                this.mOrderWhen = value;
            }
        }

        public int? PersonId
        {
            get
            {
                return this.mPersonId;
            }
            set
            {
                this.mPersonId = value;
            }
        }

        public string PickBy
        {
            get
            {
                return this.mPickBy;
            }
            set
            {
                this.mPickBy = value;
            }
        }

        public string QuoteId
        {
            get
            {
                return this.mQuoteId;
            }
            set
            {
                this.mQuoteId = value;
            }
        }

        public string RequestedShipMethod
        {
            get
            {
                return this.mRequestedShipMethod;
            }
            set
            {
                this.mRequestedShipMethod = value;
            }
        }

        public double? SalesTax
        {
            get
            {
                return this.mSalesTax;
            }
            set
            {
                this.mSalesTax = value;
            }
        }

        public string ShipAttnTo
        {
            get
            {
                return this.mShipAttnTo;
            }
            set
            {
                this.mShipAttnTo = value;
            }
        }

        public string ShipBy
        {
            get
            {
                return this.mShipBy;
            }
            set
            {
                this.mShipBy = value;
            }
        }

        public DateTime? ShipDate
        {
            get
            {
                return this.mShipDate;
            }
            set
            {
                this.mShipDate = value;
            }
        }

        public string ShipLabelComment
        {
            get
            {
                return this.mShipLabelComment;
            }
            set
            {
                this.mShipLabelComment = value;
            }
        }

        public string ShipName
        {
            get
            {
                return this.mShipName;
            }
            set
            {
                this.mShipName = value;
            }
        }

        public double? Shipping
        {
            get
            {
                return this.mShipping;
            }
            set
            {
                this.mShipping = value;
            }
        }

        public string ShipToHTMLFormatted
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this.mLabel);
                if (this.mLabel == "")
                {
                    builder.Append(this.mShipName);
                }
                else
                {
                    builder.Append("<br>c/o ");
                    builder.Append(this.mShipName);
                }
                if ((this.mCompany != "") && (this.mCompany != null))
                {
                    if (builder.Length > 0)
                    {
                        builder.Append("<br>");
                        builder.Append(this.mCompany);
                    }
                    else
                    {
                        builder.Append(this.mCompany);
                    }
                }
                if ((this.mAddress1 != "") && (this.mAddress1 != null))
                {
                    if (builder.Length > 0)
                    {
                        builder.Append("<br>");
                        builder.Append(this.mAddress1);
                    }
                    else
                    {
                        builder.Append(this.mAddress1);
                    }
                }
                if ((this.mAddress2 != "") && (this.mAddress2 != null))
                {
                    if (builder.Length > 0)
                    {
                        builder.Append("<br>");
                        builder.Append(this.mAddress2);
                    }
                    else
                    {
                        builder.Append(this.mAddress2);
                    }
                }
                if ((this.mAddress3 != "") && (this.mAddress3 != null))
                {
                    if (builder.Length > 0)
                    {
                        builder.Append("<br>");
                        builder.Append(this.mAddress3);
                    }
                    else
                    {
                        builder.Append(this.mAddress3);
                    }
                }
                if (builder.Length > 0)
                {
                    builder.Append("<br>");
                }
                builder.Append(this.mCity);
                builder.Append(",&nbsp;");
                builder.Append(this.mState);
                builder.Append("&nbsp;");
                builder.Append(this.mZip);
                builder.Append("<br>");
                builder.Append(this.mCountry);
                return builder.ToString().Replace(" ", "&nbsp;");
            }
        }

        public bool? StagedOrderFlag
        {
            get
            {
                return this.mStagedOrderFlag;
            }
            set
            {
                this.mStagedOrderFlag = value;
            }
        }

        public int? StagingId
        {
            get
            {
                return this.mStagingId;
            }
            set
            {
                this.mStagingId = value;
            }
        }

        public string State
        {
            get
            {
                return this.mState;
            }
            set
            {
                this.mState = value;
            }
        }

        public string Status
        {
            get
            {
                return this.mStatus;
            }
            set
            {
                this.mStatus = value;
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

        public string StoreName
        {
            get
            {
                return this.mStoreName;
            }
            set
            {
                this.mStoreName = value;
            }
        }

        public bool? ThirdPartyShipperFlag
        {
            get
            {
                return this.mThirdPartyShipperFlag;
            }
            set
            {
                this.mThirdPartyShipperFlag = value;
            }
        }

        public string ThirdPartyShipperInfo
        {
            get
            {
                return this.mThirdPartyShipperInfo;
            }
            set
            {
                this.mThirdPartyShipperInfo = value;
            }
        }

        public int? TotalQtyOnHand
        {
            get
            {
                return this.mTotalQtyOnHand;
            }
            set
            {
                this.mTotalQtyOnHand = value;
            }
        }

        public int? TotalQtyReserved
        {
            get
            {
                return this.mTotalQtyReserved;
            }
            set
            {
                this.mTotalQtyReserved = value;
            }
        }

        public string TrackingNo
        {
            get
            {
                return this.mTrackingNo;
            }
            set
            {
                this.mTrackingNo = value;
            }
        }

        public string TransactionId
        {
            get
            {
                return this.mTransactionId;
            }
            set
            {
                this.mTransactionId = value;
            }
        }

        public int? UnavailableLineCount
        {
            get
            {
                return this.mUnavailableLineCount;
            }
            set
            {
                this.mUnavailableLineCount = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.mUserName;
            }
            set
            {
                this.mUserName = value;
            }
        }

        public string WarehouseComment
        {
            get
            {
                return this.mWarehouseComment;
            }
            set
            {
                this.mWarehouseComment = value;
            }
        }

        public int? WhseId
        {
            get
            {
                return this.mWhseId;
            }
            set
            {
                this.mWhseId = value;
            }
        }

        public string Zip
        {
            get
            {
                return this.mZip;
            }
            set
            {
                this.mZip = value;
            }
        }
    }
}

