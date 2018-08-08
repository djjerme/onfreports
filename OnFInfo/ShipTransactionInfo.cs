namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class ShipTransactionInfo
    {
        private bool? mCancelFlag;
        private string mCancellationSource;
        private DateTime? mCancellationTime;
        private int? mCarrierId;
        private double? mInternalShippingCost;
        private int? mNumberOfPackages;
        private int? mOrderId;
        private int? mOrderSuffix;
        private double? mPublishedShippingCost;
        private int? mSequence;
        private string mShippingMethod;
        private int? mStoreId;
        private bool? mThirdPartyFlag;
        private string mTrackingNo;
        private string mTransactionSource;
        private DateTime? mTransactionTime;
        private int? mWeightInOz;

        public ShipTransactionInfo()
        {
        }

        public ShipTransactionInfo(int? storeid, int? orderid, int? ordersuffix, int? sequence, string trackingno, int? carrierid, string shippingmethod, DateTime? transactiontime, DateTime? cancellationtime, int? numberofpackages, int? weightinoz, double? publishedshippingcost, double? internalshippingcost, bool? thirdpartyflag, string transactionsource, string cancellationsource, bool? cancelflag)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mSequence = sequence;
            this.mTrackingNo = trackingno;
            this.mCarrierId = carrierid;
            this.mShippingMethod = shippingmethod;
            this.mTransactionTime = transactiontime;
            this.mNumberOfPackages = numberofpackages;
            this.mWeightInOz = weightinoz;
            this.mPublishedShippingCost = publishedshippingcost;
            this.mInternalShippingCost = internalshippingcost;
            this.mThirdPartyFlag = thirdpartyflag;
            this.mTransactionSource = transactionsource;
            this.mCancellationSource = cancellationsource;
            this.mCancelFlag = cancelflag;
        }

        public bool? CancelFlag
        {
            get
            {
                return this.mCancelFlag;
            }
            set
            {
                this.mCancelFlag = value;
            }
        }

        public string CancellationSource
        {
            get
            {
                return this.mCancellationSource;
            }
            set
            {
                this.mCancellationSource = value;
            }
        }

        public DateTime? CancellationTime
        {
            get
            {
                return this.mCancellationTime;
            }
            set
            {
                this.mCancellationTime = value;
            }
        }

        public int? CarrierId
        {
            get
            {
                return this.mCarrierId;
            }
            set
            {
                this.mCarrierId = value;
            }
        }

        public double? InternalShippingCost
        {
            get
            {
                return this.mInternalShippingCost;
            }
            set
            {
                this.mInternalShippingCost = value;
            }
        }

        public int? NumberOfPackages
        {
            get
            {
                return this.mNumberOfPackages;
            }
            set
            {
                this.mNumberOfPackages = value;
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

        public double? PublishedShippingCost
        {
            get
            {
                return this.mPublishedShippingCost;
            }
            set
            {
                this.mPublishedShippingCost = value;
            }
        }

        public int? Sequence
        {
            get
            {
                return this.mSequence;
            }
            set
            {
                this.mSequence = value;
            }
        }

        public string ShippingMethod
        {
            get
            {
                return this.mShippingMethod;
            }
            set
            {
                this.mShippingMethod = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
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

        public bool? ThirdPartyFlag
        {
            get
            {
                return this.mThirdPartyFlag;
            }
            set
            {
                this.mThirdPartyFlag = value;
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

        public string TransactionSource
        {
            get
            {
                return this.mTransactionSource;
            }
            set
            {
                this.mTransactionSource = value;
            }
        }

        public DateTime? TransactionTime
        {
            get
            {
                return this.mTransactionTime;
            }
            set
            {
                this.mTransactionTime = value;
            }
        }

        public int? WeightInOz
        {
            get
            {
                return this.mWeightInOz;
            }
            set
            {
                this.mWeightInOz = value;
            }
        }
    }
}

