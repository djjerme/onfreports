namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class CodeInfo
    {
        private string _class;
        private string _code;
        private string _description;
        private bool? _flag;
        private string _label;
        private string _longCode;
        private int? _num;
        private int? _sqn;
        private int? _storeId;

        public CodeInfo()
        {
        }

        public CodeInfo(int? storeId, string className, string code, string label, string description, string longCode, bool? flag, int? num, int? sqn)
        {
            this._storeId = storeId;
            this._class = className;
            this._code = code;
            this._label = label;
            this._description = description;
            this._longCode = longCode;
            this._flag = flag;
            this._num = num;
            this._sqn = sqn;
        }

        public string Class
        {
            get
            {
                return this._class;
            }
            set
            {
                this._class = value;
            }
        }

        public string Code
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

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public bool? Flag
        {
            get
            {
                return this._flag;
            }
            set
            {
                this._flag = value;
            }
        }

        public string Label
        {
            get
            {
                return this._label;
            }
            set
            {
                this._label = value;
            }
        }

        public string LongCode
        {
            get
            {
                return this._longCode;
            }
            set
            {
                this._longCode = value;
            }
        }

        public int? Num
        {
            get
            {
                return this._num;
            }
            set
            {
                this._num = value;
            }
        }

        public int? Sqn
        {
            get
            {
                return this._sqn;
            }
            set
            {
                this._sqn = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this._storeId;
            }
            set
            {
                this._storeId = value;
            }
        }

        public enum SortOrder
        {
            Code,
            Sqn
        }
    }
}

