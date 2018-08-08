namespace PBA.OnfInfo
{
    using System;

    public class ExtendedFieldSelectionInfo
    {
        private int? mDisplaySequence;
        private string mFieldName;
        private string mSelection;
        private int? mStoreId;
        private string mTableName;

        public ExtendedFieldSelectionInfo()
        {
        }

        public ExtendedFieldSelectionInfo(int? storeid, string tablename, string fieldname, int? displaysequence, string selection)
        {
            this.mStoreId = storeid;
            this.mTableName = tablename;
            this.mFieldName = fieldname;
            this.mDisplaySequence = displaysequence;
            this.mSelection = selection;
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

        public string Selection
        {
            get
            {
                return this.mSelection;
            }
            set
            {
                this.mSelection = value;
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

