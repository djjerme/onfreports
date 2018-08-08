namespace PBA.OnfInfo
{
    using System;

    public class NotificationStoreSettingsInfo
    {
        private bool? mActiveFlag;
        private string mAlertEmailAddress;
        private string mAlertEmailTemplate;
        private int? mDroppedOrderTime;
        private NotificationStoreSettingsExtensionInfo[] mExtensions;
        private NotificationDefinitionInfo[] mNotificationDefinitions;
        private DateTime? mNotificationStartDate;
        private string mPluginName;
        private string mResponseAddress;
        private string mResponseFilespec;
        private string mStoreFolder;
        private int? mStoreId;

        public NotificationStoreSettingsInfo()
        {
        }

        public NotificationStoreSettingsInfo(int? storeid, string storefolder, int? droppedordertime, string alertemailaddress, string responseaddress, string responsefilespec, string pluginname, string alertemailtemplate, DateTime? notificationstartdate, bool? activeflag)
        {
            this.mStoreId = storeid;
            this.mStoreFolder = storefolder;
            this.mDroppedOrderTime = droppedordertime;
            this.mAlertEmailAddress = alertemailaddress;
            this.mResponseAddress = responseaddress;
            this.mResponseFilespec = responsefilespec;
            this.mPluginName = pluginname;
            this.mAlertEmailAddress = alertemailaddress;
            this.mNotificationStartDate = notificationstartdate;
            this.mActiveFlag = activeflag;
        }

        public NotificationStoreSettingsInfo(int? storeid, string storefolder, int? droppedordertime, string alertemailaddress, string responseaddress, string responsefilespec, string pluginname, string alertemailtemplate, DateTime? notificationstartdate, bool? activeflag, NotificationDefinitionInfo[] definitions, NotificationStoreSettingsExtensionInfo[] extensions)
        {
            this.mStoreId = storeid;
            this.mStoreFolder = storefolder;
            this.mDroppedOrderTime = droppedordertime;
            this.mAlertEmailAddress = alertemailaddress;
            this.mResponseAddress = responseaddress;
            this.mResponseFilespec = responsefilespec;
            this.mPluginName = pluginname;
            this.mAlertEmailAddress = alertemailaddress;
            this.mNotificationStartDate = notificationstartdate;
            this.mActiveFlag = activeflag;
            this.mNotificationDefinitions = definitions;
            this.mExtensions = extensions;
        }

        public bool? ActiveFlag
        {
            get
            {
                return this.mActiveFlag;
            }
            set
            {
                this.mActiveFlag = value;
            }
        }

        public string AlertEmailAddress
        {
            get
            {
                return this.mAlertEmailAddress;
            }
            set
            {
                this.mAlertEmailAddress = value;
            }
        }

        public string AlertEmailTemplate
        {
            get
            {
                return this.mAlertEmailTemplate;
            }
            set
            {
                this.mAlertEmailTemplate = value;
            }
        }

        public int? DroppedOrderTime
        {
            get
            {
                return this.mDroppedOrderTime;
            }
            set
            {
                this.mDroppedOrderTime = value;
            }
        }

        public NotificationStoreSettingsExtensionInfo[] Extensions
        {
            get
            {
                return this.mExtensions;
            }
            set
            {
                this.mExtensions = value;
            }
        }

        public NotificationDefinitionInfo[] NotificationDefinitions
        {
            get
            {
                return this.mNotificationDefinitions;
            }
            set
            {
                this.mNotificationDefinitions = value;
            }
        }

        public DateTime? NotificationStartDate
        {
            get
            {
                return this.mNotificationStartDate;
            }
            set
            {
                this.mNotificationStartDate = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.mPluginName;
            }
            set
            {
                this.mPluginName = value;
            }
        }

        public string ResponseAddress
        {
            get
            {
                return this.mResponseAddress;
            }
            set
            {
                this.mResponseAddress = value;
            }
        }

        public string ResponseFilespec
        {
            get
            {
                return this.mResponseFilespec;
            }
            set
            {
                this.mResponseFilespec = value;
            }
        }

        public string StoreFolder
        {
            get
            {
                return this.mStoreFolder;
            }
            set
            {
                this.mStoreFolder = value;
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
    }
}

