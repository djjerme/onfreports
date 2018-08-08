namespace PBA.OnfInfo
{
    using System;

    public class ObjectStatusInfo
    {
        private string mDescription;
        private string mName;
        private int? mObject;
        private int? mStatus;

        public ObjectStatusInfo()
        {
        }

        public ObjectStatusInfo(int? _object, int? id, string name, string description)
        {
            this.mObject = _object;
            this.mStatus = id;
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

        public int? Object
        {
            get
            {
                return this.mObject;
            }
            set
            {
                this.mObject = value;
            }
        }

        public int? Status
        {
            get
            {
                return this.mStatus;
            }
            set
            {
                this.mStatus = value;
            }
        }
    }
}

