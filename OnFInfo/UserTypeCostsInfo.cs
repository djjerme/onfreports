namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class UserTypeCostsInfo : UserTypeItemInfo
    {
        private decimal? _invCost;
        private decimal? _mnfCost;

        public decimal? InvCost
        {
            get
            {
                return this._invCost;
            }
            set
            {
                this._invCost = value;
            }
        }

        public decimal? MnfCost
        {
            get
            {
                return this._mnfCost;
            }
            set
            {
                this._mnfCost = value;
            }
        }
    }
}

