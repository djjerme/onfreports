namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class SalesTaxInfo
    {
        private string _certiTaxNexus;
        private string _certiTaxSerialNumber;
        private decimal? _orderTotal;
        private decimal? _salesTax;
        private decimal? _salesTaxRate;
        private string _state;
        private bool? _thirdPartyLookup;

        public SalesTaxInfo()
        {
        }

        public SalesTaxInfo(decimal? salesTaxRate, string state, bool? thirdPartyLookup, decimal? orderTotal, string certiTaxSerialNumber, string certiTaxNexus)
        {
            this._salesTaxRate = salesTaxRate;
            this._state = state;
            this._thirdPartyLookup = thirdPartyLookup;
            this._orderTotal = orderTotal;
            this._certiTaxSerialNumber = certiTaxSerialNumber;
            this._certiTaxNexus = certiTaxNexus;
        }

        public string certiTaxNexus
        {
            get
            {
                return this._certiTaxNexus;
            }
            set
            {
                this._certiTaxNexus = value;
            }
        }

        public string certiTaxSerialNumber
        {
            get
            {
                return this._certiTaxSerialNumber;
            }
            set
            {
                this._certiTaxSerialNumber = value;
            }
        }

        public decimal? OrderTotal
        {
            get
            {
                return this._orderTotal;
            }
            set
            {
                this._orderTotal = value;
            }
        }

        public decimal? SalesTax
        {
            get
            {
                return this._salesTax;
            }
            set
            {
                this._salesTax = value;
            }
        }

        public decimal? SalesTaxRate
        {
            get
            {
                return this._salesTax;
            }
            set
            {
                this._salesTax = value;
            }
        }

        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }

        public bool? ThirdPartyLookup
        {
            get
            {
                return this._thirdPartyLookup;
            }
            set
            {
                this._thirdPartyLookup = value;
            }
        }
    }
}

