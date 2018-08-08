namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class FulfillmentTypeInfo
    {
        private bool? _activeFlag;
        private int? _fulfillmentTypeId;
        private string _name;
        private int? _storeId;

        public FulfillmentTypeInfo()
        {
        }

        public FulfillmentTypeInfo(int? fulfillmentTypeId, int? storeId, string name, bool? activeFlag)
        {
            this._fulfillmentTypeId = fulfillmentTypeId;
            this._storeId = storeId;
            this._name = name;
            this._activeFlag = activeFlag;
        }

        public bool? ActiveFlag
        {
            get
            {
                return this._activeFlag;
            }
            set
            {
                this._activeFlag = value;
            }
        }

        public int? FulfillmentTypeId
        {
            get
            {
                return this._fulfillmentTypeId;
            }
            set
            {
                this._fulfillmentTypeId = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
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

