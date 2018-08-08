namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class UserListMembersInfo
    {
        private int? _listId;
        private int? _memberId;
        private int? _personId;
        private int? _storeId;

        public UserListMembersInfo()
        {
        }

        public UserListMembersInfo(int? storeId, int? personId, int? listId, int? memberId)
        {
            this._storeId = storeId;
            this._personId = personId;
            this._listId = listId;
            this._memberId = memberId;
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

        public int? MemberId
        {
            get
            {
                return this._memberId;
            }
            set
            {
                this._memberId = value;
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

