namespace PBA.OnfInfo
{
    using System;

    public class PrintShopRoleInfo
    {
        private string mDescription;
        private string mName;
        private int? mRoleId;

        public PrintShopRoleInfo()
        {
        }

        public PrintShopRoleInfo(int? roleid, string name, string description)
        {
            this.mRoleId = roleid;
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

        public int? RoleId
        {
            get
            {
                return this.mRoleId;
            }
            set
            {
                this.mRoleId = value;
            }
        }
    }
}

