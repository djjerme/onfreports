namespace PBA.OnfInfo
{
    using System;

    public class NotificationLogDetailInfo : Info
    {
        private string mDescription;
        private int? mNotificationLogSequence;
        private int? mOrderId;
        private int? mOrderProcessingEventId;
        private string mOrderProcessingEventName;
        private int? mOrderSuffix;
        private int? mSequence;
        private int? mStoreId;

        public NotificationLogDetailInfo()
        {
        }

        public NotificationLogDetailInfo(int? storeid, int? notificationlogdetailsequence, int? sequence, int? orderid, int? ordersuffix, int? orderprocessingeventid, string orderprocessingeventname, string description, bool selected) : base(selected)
        {
            this.mStoreId = storeid;
            this.mNotificationLogSequence = notificationlogdetailsequence;
            this.mSequence = sequence;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mOrderProcessingEventId = orderprocessingeventid;
            this.mOrderProcessingEventName = orderprocessingeventname;
            this.mDescription = description;
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

        public int? NotificationLogSequence
        {
            get
            {
                return this.mNotificationLogSequence;
            }
            set
            {
                this.mNotificationLogSequence = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return this.mOrderId;
            }
            set
            {
                this.mOrderId = value;
            }
        }

        public int? OrderProcessingEventId
        {
            get
            {
                return this.mOrderProcessingEventId;
            }
            set
            {
                this.mOrderProcessingEventId = value;
            }
        }

        public string OrderProcessingEventName
        {
            get
            {
                return this.mOrderProcessingEventName;
            }
            set
            {
                this.mOrderProcessingEventName = value;
            }
        }

        public int? OrderSuffix
        {
            get
            {
                return this.mOrderSuffix;
            }
            set
            {
                this.mOrderSuffix = value;
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
    }
}

