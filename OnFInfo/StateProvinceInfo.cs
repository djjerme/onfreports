namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class StateProvinceInfo
    {
        private string[] _code;
        private string[] _name;

        public string[] Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        public string[] Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
    }
}

