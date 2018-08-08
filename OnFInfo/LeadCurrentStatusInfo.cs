namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LeadCurrentStatusInfo
    {
        private int? _leadActionId;
        private int? _leadCurrentStatusId;
        private int? _leadId;

        public LeadCurrentStatusInfo()
        {
        }

        public LeadCurrentStatusInfo(int? leadCurrentStatusId, int? leadId, int? leadActionId)
        {
            this._leadCurrentStatusId = this.LeadCurrentStatusId;
            this._leadId = this.LeadId;
            this._leadActionId = this.LeadActionId;
        }

        public int? LeadActionId
        {
            get
            {
                return this._leadActionId;
            }
            set
            {
                this._leadActionId = value;
            }
        }

        public int? LeadCurrentStatusId
        {
            get
            {
                return this._leadCurrentStatusId;
            }
            set
            {
                this._leadCurrentStatusId = value;
            }
        }

        public int? LeadId
        {
            get
            {
                return this._leadId;
            }
            set
            {
                this._leadId = value;
            }
        }
    }
}

