namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class CreditCardReportInfo
    {
        private string mCompany;
        private double? mDiscount;
        private string mFirstName;
        private string mLastName;
        private int? mOrderId;
        private int? mOrderSuffix;
        private DateTime? mOrderWhen;
        private double? mPaymentAmount;
        private string mQuoteId;
        private double? mSalesTax;
        private DateTime? mShipDate;
        private int? mStoreId;
        private string mStoreName;
        private string mTransactionId;

        public CreditCardReportInfo()
        {
        }

        public CreditCardReportInfo(int? storeid, int? orderid, int? ordersuffix, DateTime? orderwhen, DateTime? shipdate, string quoteid, string transactionid, double? paymentamount, double? salestax, double? discount, string firstname, string lastname, string company, string storename)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mOrderWhen = orderwhen;
            this.mShipDate = shipdate;
            this.mQuoteId = quoteid;
            this.mTransactionId = transactionid;
            this.mPaymentAmount = paymentamount;
            this.mSalesTax = salestax;
            this.mDiscount = discount;
            this.mFirstName = firstname;
            this.mLastName = lastname;
            this.mCompany = company;
            this.mStoreName = storename;
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

        public double? Discount
        {
            get
            {
                return this.mDiscount;
            }
            set
            {
                this.mDiscount = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.mFirstName;
            }
            set
            {
                this.mFirstName = value;
            }
        }

        public string FullName
        {
            get
            {
                string mFirstName = "";
                if (!string.IsNullOrEmpty(this.mFirstName))
                {
                    mFirstName = this.mFirstName;
                    if (!string.IsNullOrEmpty(this.mLastName))
                    {
                        mFirstName = mFirstName + " " + this.mLastName;
                    }
                    return mFirstName;
                }
                return this.mLastName;
            }
        }

        public string LastName
        {
            get
            {
                return this.mLastName;
            }
            set
            {
                this.mLastName = value;
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

        public double? PaymentAmount
        {
            get
            {
                return this.mPaymentAmount;
            }
            set
            {
                this.mPaymentAmount = value;
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
    }
}

