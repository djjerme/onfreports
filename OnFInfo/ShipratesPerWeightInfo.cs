namespace PBA.OnfInfo
{
    using System;

    public class ShipratesPerWeightInfo
    {
        private decimal? _rate;
        private string _shipmethod;
        private decimal? _weight;

        public decimal? Rate
        {
            get
            {
                return this._rate;
            }
            set
            {
                this._rate = value;
            }
        }

        public string ShipMethod
        {
            get
            {
                return this._shipmethod;
            }
            set
            {
                this._shipmethod = value;
            }
        }

        public decimal? Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this._weight = value;
            }
        }
    }
}

