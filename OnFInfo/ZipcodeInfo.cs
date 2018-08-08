namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class ZipcodeInfo
    {
        private string _areacode;
        private string _city;
        private string _county;
        private string _fips;
        private string _state;
        private string _Zipcode;

        public ZipcodeInfo()
        {
        }

        public ZipcodeInfo(string state, string zipcode, string areacode, string fips, string county, string city)
        {
            this._state = state;
            this._Zipcode = zipcode;
            this._areacode = areacode;
            this._fips = fips;
            this._county = county;
            this._city = city;
        }

        public string Areacode
        {
            get
            {
                return this._areacode;
            }
            set
            {
                this._areacode = value;
            }
        }

        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }

        public string County
        {
            get
            {
                return this._county;
            }
            set
            {
                this._county = value;
            }
        }

        public string Fips
        {
            get
            {
                return this._fips;
            }
            set
            {
                this._fips = value;
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

        public string Zipcode
        {
            get
            {
                return this._Zipcode;
            }
            set
            {
                this._Zipcode = value;
            }
        }
    }
}

