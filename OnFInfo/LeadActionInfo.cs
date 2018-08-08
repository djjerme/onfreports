namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LeadActionInfo
    {
        private DateTime? _actionDate;
        private int? _leadActionId;
        private int? _leadId;
        private int? _leadStatusId;
        private string _notes;
        private int? _qty;
        private int? _recipientId;

        public LeadActionInfo()
        {
        }

        public LeadActionInfo(int? leadActionId, int? leadId, int? leadStatusId, string notes, int? qty, int? recipientId, DateTime? actionDate)
        {
            this._leadActionId = this.LeadActionId;
            this._leadId = this.LeadId;
            this._leadStatusId = this.LeadStatusId;
            this._notes = this.Notes;
            this._qty = this.Qty;
            this._recipientId = this.RecipientId;
            this._actionDate = this.ActionDate;
        }

        public DateTime? ActionDate
        {
            get
            {
                return this._actionDate;
            }
            set
            {
                this._actionDate = value;
            }
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

        public int? LeadStatusId
        {
            get
            {
                return this._leadStatusId;
            }
            set
            {
                this._leadStatusId = value;
            }
        }

        public string Notes
        {
            get
            {
                return this._notes;
            }
            set
            {
                this._notes = value;
            }
        }

        public int? Qty
        {
            get
            {
                return this._qty;
            }
            set
            {
                this._qty = value;
            }
        }

        public int? RecipientId
        {
            get
            {
                return this._recipientId;
            }
            set
            {
                this._recipientId = value;
            }
        }
    }
}

