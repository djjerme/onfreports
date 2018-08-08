namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class OrderProcessingEventInfo : Info
    {
        private string mDescription;
        private int? mId;
        private string mName;

        public OrderProcessingEventInfo() : base(false)
        {
        }

        public OrderProcessingEventInfo(int? Id, string Name, string Description, bool selected) : base(selected)
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

