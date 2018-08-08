namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class SynderoOrderInfo
    {
        private string mAddress1;
        private string mAddress2;
        private string mCity;
        private string mCustomerOrderNumber;
        private bool? mDuplicate;
        private string mEmail;
        private string mExternalOrderId;
        private bool? mFlexKit;
        private string mFullName;
        private double? mGrandTotal;
        private SynderoOrderItemInfo[] mInvoiceLines;
        private string mItemId;
        private string mLayout;
        private int? mOrderId;
        private string mOrderReason;
        private int? mOrderSuffix;
        private DateTime? mOrderWhen;
        private string mPhone;
        private DateTime? mPostageDate;
        private string mReferenceId;
        private double? mSalesTax;
        private double? mShippingAndHandling;
        private int? mShipWeight;
        private int? mSpecialHandlingCode;
        private string mState;
        private int? mStoreId;
        private string mTemplateId;
        private string mZip;

        public SynderoOrderInfo()
        {
            this.mDuplicate = false;
        }

        public SynderoOrderInfo(string referenceid, DateTime orderwhen, int? storeid, int? orderid, int? ordersuffix, string customerordernumber, string externalorderid, string fullname, string address1, string address2, string city, string state, string zip, int? shipweight, DateTime? postagedate, string itemid, string layout)
        {
            this.mReferenceId = referenceid;
            this.mOrderWhen = new DateTime?(orderwhen);
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mCustomerOrderNumber = customerordernumber;
            this.mExternalOrderId = externalorderid;
            this.mFullName = fullname;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mCity = city;
            this.mState = state;
            this.mZip = zip;
            this.mShipWeight = shipweight;
            this.mPostageDate = postagedate;
            this.mItemId = itemid;
            this.mLayout = layout;
            this.mDuplicate = false;
            this.mFlexKit = false;
        }

        public SynderoOrderInfo(string referenceid, DateTime orderwhen, int? storeid, int? orderid, int? ordersuffix, string customerordernumber, string externalorderid, string fullname, string address1, string address2, string city, string state, string zip, int? shipweight, DateTime? postagedate, string itemid, string layout, bool? flexkit, int? specialhandlingcode, string templateid, double? shippingandhandling, double? salestax, double? grandtotal, string phone, string email, string orderreason, SynderoOrderItemInfo[] invoicelines)
        {
            this.mReferenceId = referenceid;
            this.mOrderWhen = new DateTime?(orderwhen);
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mCustomerOrderNumber = customerordernumber;
            this.mExternalOrderId = externalorderid;
            this.mFullName = fullname;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mCity = city;
            this.mState = state;
            this.mZip = zip;
            this.mShipWeight = shipweight;
            this.mPostageDate = postagedate;
            this.mItemId = itemid;
            this.mLayout = layout;
            this.mDuplicate = false;
            this.mFlexKit = flexkit;
            this.mSpecialHandlingCode = specialhandlingcode;
            this.mTemplateId = templateid;
            this.mShippingAndHandling = shippingandhandling;
            this.mSalesTax = salestax;
            this.mGrandTotal = grandtotal;
            this.mInvoiceLines = invoicelines;
            this.mPhone = phone;
            this.mEmail = email;
            this.mOrderReason = orderreason;
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

        public string CustomerOrderNumber
        {
            get
            {
                return this.mCustomerOrderNumber;
            }
            set
            {
                this.mCustomerOrderNumber = value;
            }
        }

        public bool? Duplicate
        {
            get
            {
                return this.mDuplicate;
            }
            set
            {
                this.mDuplicate = value;
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

        public string ExternalOrderId
        {
            get
            {
                return this.mExternalOrderId;
            }
            set
            {
                this.mExternalOrderId = value;
            }
        }

        public bool? FlexKit
        {
            get
            {
                return this.mFlexKit;
            }
            set
            {
                this.mFlexKit = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.mFullName;
            }
            set
            {
                this.mFullName = value;
            }
        }

        public double? GrandTotal
        {
            get
            {
                return this.mGrandTotal;
            }
            set
            {
                this.mGrandTotal = value;
            }
        }

        public SynderoOrderItemInfo[] InvoiceLines
        {
            get
            {
                return this.mInvoiceLines;
            }
            set
            {
                this.mInvoiceLines = value;
            }
        }

        public string ItemId
        {
            get
            {
                return this.mItemId;
            }
            set
            {
                this.mItemId = value;
            }
        }

        public string Layout
        {
            get
            {
                return this.mLayout;
            }
            set
            {
                this.mLayout = value;
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

        public string Phone
        {
            get
            {
                return this.mPhone;
            }
            set
            {
                this.mPhone = value;
            }
        }

        public DateTime? PostageDate
        {
            get
            {
                return this.mPostageDate;
            }
            set
            {
                this.mPostageDate = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
        public string ReferenceId
        {
            get
            {
                return this.mReferenceId;
            }
            set
            {
                this.mReferenceId = value;
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

        public double? ShippingAndHandling
        {
            get
            {
                return this.mShippingAndHandling;
            }
            set
            {
                this.mShippingAndHandling = value;
            }
        }

        public int? ShipWeight
        {
            get
            {
                return this.mShipWeight;
            }
            set
            {
                this.mShipWeight = value;
            }
        }

        public int? SpecialHandlingCode
        {
            get
            {
                return this.mSpecialHandlingCode;
            }
            set
            {
                this.mSpecialHandlingCode = value;
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

        public string TemplateId
        {
            get
            {
                return this.mTemplateId;
            }
            set
            {
                this.mTemplateId = value;
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

