namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class HandlerInfo
    {
        private string mFullName;
        private string mHandlerId;
        private string mPassword;
        private int? mWhseId;

        public HandlerInfo()
        {
        }

        public HandlerInfo(int? whseid, string handlerid, string password, string fullname)
        {
            this.mWhseId = whseid;
            this.mHandlerId = handlerid;
            this.mPassword = password;
            this.mFullName = fullname;
        }

        public string FullName
        {
            get
            {
                return this.mFullName;
            }
            set
            {
                this.mFullName = value;
            }
        }

        public string HandlerId
        {
            get
            {
                return this.mHandlerId;
            }
            set
            {
                this.mHandlerId = value;
            }
        }

        public string Password
        {
            get
            {
                return this.mPassword;
            }
            set
            {
                this.mPassword = value;
            }
        }

        public int? WhseId
        {
            get
            {
                return this.mWhseId;
            }
            set
            {
                this.mWhseId = value;
            }
        }
    }
}

