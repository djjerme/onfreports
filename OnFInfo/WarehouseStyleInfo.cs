namespace PBA.OnfInfo
{
    using System;

    public class WarehouseStyleInfo
    {
        private bool? _modified = false;
        private bool? _newStyle = false;
        private string _styleCSS = "";
        private int? _styleId = -1;
        private string _styleName = "";

        public bool? Modified
        {
            get
            {
                return this._modified;
            }
            set
            {
                this._modified = value;
            }
        }

        public bool? NewStyle
        {
            get
            {
                return this._newStyle;
            }
            set
            {
                this._newStyle = value;
            }
        }

        public string StyleCSS
        {
            get
            {
                return this._styleCSS;
            }
            set
            {
                this._styleCSS = value;
            }
        }

        public int? StyleId
        {
            get
            {
                return this._styleId;
            }
            set
            {
                this._styleId = value;
            }
        }

        public string StyleName
        {
            get
            {
                return this._styleName;
            }
            set
            {
                this._styleName = value;
            }
        }
    }
}

