namespace PBA.OnfInfo
{
    using System;

    public class WarehouseTemplateInfo
    {
        private bool? _modified = false;
        private bool? _newTemplate = false;
        private string _templatehtml = "";
        private int? _templateId = -1;
        private string _templateName = "";
        private string _templateType = "";

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

        public bool? NewTemplate
        {
            get
            {
                return this._newTemplate;
            }
            set
            {
                this._newTemplate = value;
            }
        }

        public string Templatehtml
        {
            get
            {
                return this._templatehtml;
            }
            set
            {
                this._templatehtml = value;
            }
        }

        public int? TemplateId
        {
            get
            {
                return this._templateId;
            }
            set
            {
                this._templateId = value;
            }
        }

        public string TemplateName
        {
            get
            {
                return this._templateName;
            }
            set
            {
                this._templateName = value;
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

