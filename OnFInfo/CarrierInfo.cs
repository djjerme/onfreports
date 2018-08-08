namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class CarrierInfo
    {
        private string mCarrierCode;
        private int? mCarrierId;
        private double? mDomesticMultiplier;
        private double? mInternationalMultiplier;
        private string mName;

        public CarrierInfo()
        {
        }

        public CarrierInfo(int? carrierid, string carriercode, string name, double? domesticmultiplier, double? internationalmultiplier)
        {
            this.mCarrierCode = carriercode;
            this.mCarrierId = carrierid;
            this.mName = name;
            this.mDomesticMultiplier = domesticmultiplier;
            this.mInternationalMultiplier = internationalmultiplier;
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

        public double? DomesticMultiplier
        {
            get
            {
                return this.mDomesticMultiplier;
            }
            set
            {
                this.mDomesticMultiplier = value;
            }
        }

        public double? InternationalMultiplier
        {
            get
            {
                return this.mInternationalMultiplier;
            }
            set
            {
                this.mInternationalMultiplier = value;
            }
        }

        public string Name
        {
            get
            {
                return this.mName;
            }
            set
            {
                this.mName = value;
            }
        }
    }
}

