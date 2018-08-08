namespace PBA.OnfInfo
{
    using System;

    public class ObjectTypeInfo
    {
        private string mDescription;
        private string mName;
        private int? mObject;
        private int? mType;

        public ObjectTypeInfo()
        {
        }

        public ObjectTypeInfo(int? _object, int? id, string name, string description)
        {
            this.mObject = _object;
            this.mType = id;
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

        public int? Type
        {
            get
            {
                return this.mType;
            }
            set
            {
                this.mType = value;
            }
        }
    }
}

