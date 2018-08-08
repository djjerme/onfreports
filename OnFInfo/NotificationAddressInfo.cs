namespace PBA.OnfInfo
{
    using System;

    public class NotificationAddressInfo : Info
    {
        private string mAddress;
        private string mAddressType;
        private int? mNotificationDefinitionSequence;
        private int? mSequence;
        private int? mStoreId;

        public NotificationAddressInfo()
        {
        }

        public NotificationAddressInfo(int? storeid, int? notificationaddresssequence, int? sequence, string address, string addresstype, bool selected) : base(selected)
        {
            this.mStoreId = storeid;
            this.mNotificationDefinitionSequence = notificationaddresssequence;
            this.mSequence = sequence;
            this.mAddress = address;
            this.mAddressType = addresstype;
        }

        public string Address
        {
            get
            {
                return this.mAddress;
            }
            set
            {
                this.mAddress = value;
            }
        }

        public string AddressType
        {
            get
            {
                return this.mAddressType;
            }
            set
            {
                this.mAddressType = value;
            }
        }

        public int? NotificationDefinitionSequence
        {
            get
            {
                return this.mNotificationDefinitionSequence;
            }
            set
            {
                this.mNotificationDefinitionSequence = value;
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

