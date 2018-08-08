namespace PBA.OnfInfo
{
    using System;

    public class ExtendedFieldValueInfo
    {
        private string mFieldName;
        private string mValue;

        public ExtendedFieldValueInfo()
        {
        }

        public ExtendedFieldValueInfo(string fieldname, string value)
        {
            this.mFieldName = fieldname;
            this.mValue = value;
        }

        public override string ToString()
        {
            return this.Value;
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

        public string Value
        {
            get
            {
                return this.mValue;
            }
            set
            {
                this.mValue = value;
            }
        }

        public bool ValueAsBool
        {
            get
            {
                return Convert.ToBoolean(this.mValue);
            }
        }

        public int ValueAsInt32
        {
            get
            {
                return Convert.ToInt32(this.mValue);
            }
        }
    }
}

