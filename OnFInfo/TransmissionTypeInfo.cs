namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class TransmissionTypeInfo
    {
        private string mDescription;
        private int? mId;
        private string mName;

        public TransmissionTypeInfo()
        {
        }

        public TransmissionTypeInfo(int? id, string name, string description)
        {
            this.mId = id;
            this.mName = name;
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

