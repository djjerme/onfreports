namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class WarehouseStoreInfo
    {
        private bool? _autogen;
        private bool? _backOrderCreation;
        private bool? _changed;
        private int? _commentPrinterId;
        private int? _noCommentPrinterId;
        private int? _storeId;
        private string _title;
        private int? _whseId;

        public WarehouseStoreInfo()
        {
            this._storeId = -1;
            this._title = "";
            this._backOrderCreation = false;
            this._autogen = false;
            this._noCommentPrinterId = -1;
            this._commentPrinterId = -1;
            this._changed = false;
            this._whseId = -1;
        }

        public WarehouseStoreInfo(int? storeId, string title, bool? backordercreation, bool? autogen, int? nocommentprinterid, int? commentprinterid, bool? changed, int? WhseID)
        {
            this._storeId = storeId;
            this._whseId = WhseID;
            this._title = title;
            this._backOrderCreation = backordercreation;
            this._autogen = autogen;
            this._noCommentPrinterId = nocommentprinterid;
            this._commentPrinterId = commentprinterid;
            this._changed = changed;
        }

        public bool? AutoGen
        {
            get
            {
                return this._autogen;
            }
            set
            {
                this._autogen = value;
            }
        }

        public bool? BackorderCreation
        {
            get
            {
                return this._backOrderCreation;
            }
            set
            {
                this._backOrderCreation = value;
            }
        }

        public bool? Changed
        {
            get
            {
                return this._changed;
            }
            set
            {
                this._changed = value;
            }
        }

        public int? CommentPrinterID
        {
            get
            {
                return this._commentPrinterId;
            }
            set
            {
                this._commentPrinterId = value;
            }
        }

        public int? NoCommentPrinterID
        {
            get
            {
                return this._noCommentPrinterId;
            }
            set
            {
                this._noCommentPrinterId = value;
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

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public int? WhseId
        {
            get
            {
                return this._whseId;
            }
            set
            {
                this._whseId = value;
            }
        }
    }
}

