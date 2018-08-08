namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class UserListInfo
    {
        private string _description;
        private int? _listId;
        private int? _personId;
        private int? _storeId;

        public UserListInfo()
        {
        }

        public UserListInfo(int? storeId, int? personId, int? listId, string description)
        {
            this._storeId = storeId;
            this._personId = personId;
            this._listId = listId;
            this._description = description;
        }

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public int? ListId
        {
            get
            {
                return this._listId;
            }
            set
            {
                this._listId = value;
            }
        }

        public int? PersonId
        {
            get
            {
                return this._personId;
            }
            set
            {
                this._personId = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this._storeId;
            }
            set
            {
                this._storeId = value;
            }
        }
    }
}

