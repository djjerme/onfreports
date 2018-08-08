namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class NotificationPluginInfo
    {
        private string mDescription;
        private string mName;

        public NotificationPluginInfo()
        {
        }

        public NotificationPluginInfo(string name, string description)
        {
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
    }
}

