namespace PBA.OnfInfo
{
    using System;

    public class NotificationLogInfo : Info
    {
        private string mDescription;
        private NotificationLogDetailInfo[] mDetails;
        private int? mNotificationEventTypeId;
        private string mNotificationEventTypeName;
        private string mResultDescription;
        private int? mSequence;
        private int? mStoreId;
        private DateTime? mTimestamp;

        public NotificationLogInfo()
        {
        }

        public NotificationLogInfo(int? storeid, int? sequence, DateTime? timestamp, int? notificationeventtypeid, string notificationeventtypename, string Description, string resultdescription, NotificationLogDetailInfo[] details, bool selected) : base(selected)
        {
            this.mStoreId = storeid;
            this.mSequence = sequence;
            this.mTimestamp = timestamp;
            this.mNotificationEventTypeId = notificationeventtypeid;
            this.mDescription = Description;
            this.mResultDescription = resultdescription;
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

        public NotificationLogDetailInfo[] Details
        {
            get
            {
                return this.mDetails;
            }
            set
            {
                this.mDetails = value;
            }
        }

        public int? NotificationEventTypeId
        {
            get
            {
                return this.mNotificationEventTypeId;
            }
            set
            {
                this.mNotificationEventTypeId = value;
            }
        }

        public string NotificationEventTypeName
        {
            get
            {
                return this.mNotificationEventTypeName;
            }
            set
            {
                this.mNotificationEventTypeName = value;
            }
        }

        public string ResultDescription
        {
            get
            {
                return this.mResultDescription;
            }
            set
            {
                this.mResultDescription = value;
            }
        }

        public int? Sequence
        {
            get
            {
                return this.mSequence;
            }
            set
            {
                this.mSequence = value;
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

        public DateTime? Timestamp
        {
            get
            {
                return this.mTimestamp;
            }
            set
            {
                this.mTimestamp = value;
            }
        }
    }
}

