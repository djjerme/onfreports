namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class FreightRuleInfo
    {
        private string mCarrierCode;
        private int? mCarrierId;
        private double? mDomesticDiscount;
        private double? mInternationalDiscount;
        private int? mStoreId;
        private string mStoreName;

        public FreightRuleInfo()
        {
        }

        public FreightRuleInfo(int? storeid, int? carrierid, string storename, string carriercode, double? domesticdiscount, double? internationaldiscount)
        {
            this.mStoreId = storeid;
            this.mCarrierId = carrierid;
            this.mStoreName = storename;
            this.mCarrierCode = carriercode;
            this.mDomesticDiscount = domesticdiscount;
            this.mInternationalDiscount = internationaldiscount;
        }

        public string CarrierCode
        {
            get
            {
                return this.mCarrierCode;
            }
            set
            {
                this.mCarrierCode = value;
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

        public double? DomesticDiscount
        {
            get
            {
                return this.mDomesticDiscount;
            }
            set
            {
                this.mDomesticDiscount = value;
            }
        }

        public double? InternationalDiscount
        {
            get
            {
                return this.mInternationalDiscount;
            }
            set
            {
                this.mInternationalDiscount = value;
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
    }
}

