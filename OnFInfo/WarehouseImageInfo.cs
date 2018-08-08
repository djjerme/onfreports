namespace PBA.OnfInfo
{
    using System;

    public class WarehouseImageInfo
    {
        private bool? _modified = false;
        private bool? _newImage = false;
        private string _picFieldName = "";
        private int? _picId = -1;
        private byte[] _picImage = null;
        private string _picName = "";
        private string _templateType = "I";

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

        public bool? NewImage
        {
            get
            {
                return this._newImage;
            }
            set
            {
                this._newImage = value;
            }
        }

        public string PicFieldName
        {
            get
            {
                return this._picFieldName;
            }
            set
            {
                this._picFieldName = value;
            }
        }

        public int? PicId
        {
            get
            {
                return this._picId;
            }
            set
            {
                this._picId = value;
            }
        }

        public byte[] PicImage
        {
            get
            {
                return this._picImage;
            }
            set
            {
                this._picImage = value;
            }
        }

        public string PicName
        {
            get
            {
                return this._picName;
            }
            set
            {
                this._picName = value;
            }
        }

        public string TemplateType
        {
            get
            {
                return this._templateType;
            }
            set
            {
                this._templateType = value;
            }
        }
    }
}

