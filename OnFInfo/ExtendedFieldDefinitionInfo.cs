namespace PBA.OnfInfo
{
    using System;

    public class ExtendedFieldDefinitionInfo
    {
        private string mCategory;
        private string mDescription;
        private int? mDisplaySequence;
        private string mFieldName;
        private string mFieldType;
        private string mLabel;
        private int? mLength;
        private bool? mRequired;
        private ExtendedFieldSelectionInfo[] mSelections;
        private string mShortLabel;
        private int? mStoreId;
        private string mTableName;

        public ExtendedFieldDefinitionInfo()
        {
        }

        public ExtendedFieldDefinitionInfo(int? storeid, string tablename, string fieldname, int? displaysequence, string fieldtype, int? length, bool? required, string category, string description, string label, string shortlabel)
        {
            this.mStoreId = storeid;
            this.mTableName = tablename;
            this.mFieldName = fieldname;
            this.mDisplaySequence = displaysequence;
            this.mFieldType = fieldtype;
            this.mLength = length;
            this.mRequired = required;
            this.mCategory = category;
            this.mDescription = description;
            this.mLabel = label;
            this.mShortLabel = shortlabel;
        }

        public ExtendedFieldDefinitionInfo(int? storeid, string tablename, string fieldname, int? displaysequence, string fieldtype, int? length, bool? required, string category, string description, string label, string shortlabel, ExtendedFieldSelectionInfo[] selections)
        {
            this.mStoreId = storeid;
            this.mTableName = tablename;
            this.mFieldName = fieldname;
            this.mDisplaySequence = displaysequence;
            this.mFieldType = fieldtype;
            this.mLength = length;
            this.mRequired = required;
            this.mCategory = category;
            this.mDescription = description;
            this.mLabel = label;
            this.mShortLabel = shortlabel;
            this.mSelections = selections;
        }

        public string Category
        {
            get
            {
                return this.mCategory;
            }
            set
            {
                this.mCategory = value;
            }
        }

        public string Description
        {
            get
            {
                return this.mDescription;
            }
            set
            {
                this.mDescription = value;
            }
        }

        public int? DisplaySequence
        {
            get
            {
                return this.mDisplaySequence;
            }
            set
            {
                this.mDisplaySequence = value;
            }
        }

        public string FieldName
        {
            get
            {
                return this.mFieldName;
            }
            set
            {
                this.mFieldName = value;
            }
        }

        public string FieldType
        {
            get
            {
                return this.mFieldType;
            }
            set
            {
                this.mFieldType = value;
            }
        }

        public string Label
        {
            get
            {
                return this.mLabel;
            }
            set
            {
                this.mLabel = value;
            }
        }

        public int? Length
        {
            get
            {
                return this.mLength;
            }
            set
            {
                this.mLength = value;
            }
        }

        public bool? Required
        {
            get
            {
                return this.mRequired;
            }
            set
            {
                this.mRequired = value;
            }
        }

        public ExtendedFieldSelectionInfo[] Selections
        {
            get
            {
                return this.mSelections;
            }
            set
            {
                this.mSelections = value;
            }
        }

        public string ShortLabel
        {
            get
            {
                return this.mShortLabel;
            }
            set
            {
                this.mShortLabel = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this.mStoreId;
            }
            set
            {
                this.mStoreId = value;
            }
        }

        public string TableName
        {
            get
            {
                return this.mTableName;
            }
            set
            {
                this.mTableName = value;
            }
        }
    }
}

