namespace PBA.OnfInfo
{
    using System;

    public class PageWeightInfo
    {
        private int? _basePageCount;
        private decimal? _weight;
        private decimal? _weightInc;

        public int? basePageCount
        {
            get
            {
                return this._basePageCount;
            }
            set
            {
                this._basePageCount = value;
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

        public decimal? WeightInc
        {
            get
            {
                return this._weightInc;
            }
            set
            {
                this._weightInc = value;
            }
        }
    }
}

