namespace PBA.OnfInfo
{
    using System;

    public class SpecialPricingInfo
    {
        private int? _group_id;
        private int? _price_type;
        private int? _range_end;
        private int? _range_start;
        private decimal? _rate;

        public int? GroupId
        {
            get
            {
                return this._group_id;
            }
            set
            {
                this._group_id = value;
            }
        }

        public int? PriceType
        {
            get
            {
                return this._price_type;
            }
            set
            {
                this._price_type = value;
            }
        }

        public int? RangeEnd
        {
            get
            {
                return this._range_end;
            }
            set
            {
                this._range_end = value;
            }
        }

        public int? RangeStart
        {
            get
            {
                return this._range_start;
            }
            set
            {
                this._range_start = value;
            }
        }

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
    }
}

