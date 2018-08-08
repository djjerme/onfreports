namespace PBA.OnfInfo
{
    using System;

    public class NotificationDefinitionInfo : Info
    {
        private NotificationAddressInfo[] mAddresses;
        private string mEmailSubject;
        private string mFTPFilename;
        private int? mMaxOrders;
        private int? mSequence;
        private int? mStoreId;
        private string mTransmissionTemplate;
        private string mTransmissionType;
        private int? mTransmissionTypeId;

        public NotificationDefinitionInfo()
        {
        }

        public NotificationDefinitionInfo(int? storeid, int? sequence, int? transmissiontypeid, string transmissiontype, int maxorders, string transmissiontemplate, string ftpfilename, string emailsubject, NotificationAddressInfo[] addresses, bool selected) : base(selected)
        {
            this.mStoreId = storeid;
            this.mSequence = sequence;
            this.mTransmissionTypeId = transmissiontypeid;
            this.mTransmissionType = transmissiontype;
            this.mMaxOrders = new int?(maxorders);
            this.mTransmissionTemplate = transmissiontemplate;
            this.mFTPFilename = ftpfilename;
            this.mEmailSubject = emailsubject;
            this.mAddresses = addresses;
        }

        public NotificationAddressInfo[] Addresses
        {
            get
            {
                return this.mAddresses;
            }
            set
            {
                this.mAddresses = value;
            }
        }

        public string EmailSubject
        {
            get
            {
                return this.mEmailSubject;
            }
            set
            {
                this.mEmailSubject = value;
            }
        }

        public string FTPFilename
        {
            get
            {
                return this.mFTPFilename;
            }
            set
            {
                this.mFTPFilename = value;
            }
        }

        public int? MaxOrders
        {
            get
            {
                return this.mMaxOrders;
            }
            set
            {
                this.mMaxOrders = value;
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

        public string TransmissionTemplate
        {
            get
            {
                return this.mTransmissionTemplate;
            }
            set
            {
                this.mTransmissionTemplate = value;
            }
        }

        public string TransmissionType
        {
            get
            {
                return this.mTransmissionType;
            }
            set
            {
                this.mTransmissionType = value;
            }
        }

        public int? TransmissionTypeId
        {
            get
            {
                return this.mTransmissionTypeId;
            }
            set
            {
                this.mTransmissionTypeId = value;
            }
        }
    }
}

