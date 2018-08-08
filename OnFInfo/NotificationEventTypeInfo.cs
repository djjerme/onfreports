namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class NotificationEventTypeInfo : Info
    {
        private string mDescription;
        private int? mId;
        private string mName;

        public NotificationEventTypeInfo() : base(false)
        {
        }

        public NotificationEventTypeInfo(int? Id, string Name, string Description, bool selected) : base(selected)
        {
            this.mId = Id;
            this.mName = Name;
            this.mDescription = Description;
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

        public int? Id
        {
            get
            {
                return this.mId;
            }
            set
            {
                this.mId = value;
            }
        }

        public string Name
        {
            get
            {
                return this.mName;
            }
            set
            {
                this.mName = value;
            }
        }
    }
}

