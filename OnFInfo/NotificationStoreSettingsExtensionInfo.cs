namespace PBA.OnfInfo
{
    using System;

    public class NotificationStoreSettingsExtensionInfo
    {
        private DateTime? mDateTimeValue;
        private string mDescription;
        private string mExtensionName;
        private double? mFloatValue;
        private int? mIntValue;
        private int? mStoreId;
        private string mStringValue;

        public NotificationStoreSettingsExtensionInfo()
        {
        }

        public NotificationStoreSettingsExtensionInfo(int? storeid, string extensionname, string description, string stringvalue, int? intvalue, double? floatvalue, DateTime? datetimevalue)
        {
            this.mStoreId = storeid;
            this.mExtensionName = extensionname;
            this.mDescription = description;
            this.mStringValue = stringvalue;
            this.mIntValue = intvalue;
            this.mFloatValue = floatvalue;
            this.mDateTimeValue = datetimevalue;
        }

        public DateTime? DateTimeValue
        {
            get
            {
                return this.mDateTimeValue;
            }
            set
            {
                this.mDateTimeValue = value;
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

        public string ExtensionName
        {
            get
            {
                return this.mExtensionName;
            }
            set
            {
                this.mExtensionName = value;
            }
        }

        public double? FloatValue
        {
            get
            {
                return this.mFloatValue;
            }
            set
            {
                this.mFloatValue = value;
            }
        }

        public int? IntValue
        {
            get
            {
                return this.mIntValue;
            }
            set
            {
                this.mIntValue = value;
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

        public string StringValue
        {
            get
            {
                return this.mStringValue;
            }
            set
            {
                this.mStringValue = value;
            }
        }
    }
}

