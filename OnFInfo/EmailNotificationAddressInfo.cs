namespace PBA.OnfInfo
{
    using System;

    public class EmailNotificationAddressInfo : Info
    {
        private string mAddressType;
        private string mComment;
        private string mEmailAddress;
        private string mEmailName;
        private string mMessageType;
        private int? mSequence;
        private int? mStoreId;
        private int? mStoreSubkey;

        public EmailNotificationAddressInfo()
        {
        }

        public EmailNotificationAddressInfo(int? storeid, int? storesubkey, string messagetype, string addresstype, int? sequence, string emailaddress, string emailname, string comment) : base(false)
        {
            this.mStoreId = storeid;
            this.mStoreSubkey = storesubkey;
            this.mMessageType = messagetype;
            this.mAddressType = addresstype;
            this.mSequence = sequence;
            this.mEmailAddress = emailaddress;
            this.mEmailName = emailname;
            this.mComment = comment;
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

        public string Comment
        {
            get
            {
                return this.mComment;
            }
            set
            {
                this.mComment = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.mEmailAddress;
            }
            set
            {
                this.mEmailAddress = value;
            }
        }

        public string EmailName
        {
            get
            {
                return this.mEmailName;
            }
            set
            {
                this.mEmailName = value;
            }
        }

        public string MessageType
        {
            get
            {
                return this.mMessageType;
            }
            set
            {
                this.mMessageType = value;
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

        public int? StoreSubkey
        {
            get
            {
                return this.mStoreSubkey;
            }
            set
            {
                this.mStoreSubkey = value;
            }
        }
    }
}

