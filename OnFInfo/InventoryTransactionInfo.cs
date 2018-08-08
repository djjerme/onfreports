namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class InventoryTransactionInfo : Info
    {
        private string mAction;
        private int? mQty;

        public InventoryTransactionInfo()
        {
        }

        public InventoryTransactionInfo(string action, int? qty) : base(false)
        {
            this.mAction = action;
            this.mQty = qty;
        }

        public string Action
        {
            get
            {
                return this.mAction;
            }
            set
            {
                this.mAction = value;
            }
        }

        public int? Qty
        {
            get
            {
                return this.mQty;
            }
            set
            {
                this.mQty = value;
            }
        }
    }
}

