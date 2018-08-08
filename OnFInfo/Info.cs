namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class Info
    {
        private bool mSelected;

        public Info()
        {
        }

        public Info(bool selected)
        {
            this.mSelected = selected;
        }

        public void Select()
        {
            this.mSelected = true;
        }

        public void Unselect()
        {
            this.mSelected = false;
        }

        public bool Selected
        {
            get
            {
                return this.mSelected;
            }
            set
            {
                this.mSelected = value;
            }
        }
    }
}

