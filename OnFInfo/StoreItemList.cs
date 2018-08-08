namespace PBA.OnfInfo
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public class StoreItemList : CollectionBase
    {
        private const string CLASS_NAME = "PBA.OnfInfo.StoreItemList";
        private const string LIST_TYPE = "PBA.OnfInfo.StoreItemInfo";

        public int Add(StoreItemInfo value)
        {
            return base.List.Add(value);
        }

        public bool Contains(StoreItemInfo value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(StoreItemInfo value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, StoreItemInfo value)
        {
            base.List.Insert(index, value);
        }

        protected override void OnValidate(object value)
        {
            if (!(value.GetType() == Type.GetType("PBA.OnfInfo.StoreItemInfo")))
            {
                throw new ArgumentException(string.Format("Value must be of type {0}.", "PBA.OnfInfo.StoreItemInfo"), "value");
            }
        }

        public void Remove(StoreItemInfo value)
        {
            base.List.Remove(value);
        }

        public void Sort(SortColumn sortOrder)
        {
            this.Sort(sortOrder, SortDirection.Ascending);
        }

        public void Sort(SortColumn sortOrder, SortDirection sortDirection)
        {
            IComparer comparer = new StoreItemSort(sortOrder, sortDirection);
            base.InnerList.Sort(comparer);
        }

        public override string ToString()
        {
            return string.Format("{0}:\n\tCount = {1}", "PBA.OnfInfo.StoreItemList", base.List.Count);
        }

        public StoreItemInfo this[int index]
        {
            get
            {
                return (StoreItemInfo) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }

        public enum SortColumn
        {
            ItemId,
            QtyAvailable,
            Sequence
        }

        public enum SortDirection
        {
            Ascending,
            Descending
        }

        private class StoreItemSort : IComparer
        {
            private StoreItemList.SortColumn _sortColumn;
            private StoreItemList.SortDirection _sortDirection;

            public StoreItemSort(StoreItemList.SortColumn sortOrder, StoreItemList.SortDirection sortDirection)
            {
                this._sortColumn = sortOrder;
                this._sortDirection = sortDirection;
            }

            public int Compare(object x, object y)
            {
                StoreItemInfo info = (StoreItemInfo) x;
                StoreItemInfo info2 = (StoreItemInfo) y;
                IComparable itemId = null;
                IComparable qtyAvailable = null;
                switch (this._sortColumn)
                {
                    case StoreItemList.SortColumn.ItemId:
                        itemId = info.ItemId;
                        qtyAvailable = info2.ItemId;
                        break;

                    case StoreItemList.SortColumn.QtyAvailable:
                        itemId = info.QtyAvailable;
                        qtyAvailable = info2.QtyAvailable;
                        break;

                    case StoreItemList.SortColumn.Sequence:
                        itemId = (IComparable) info.Sqn;
                        qtyAvailable = (IComparable) info2.Sqn;
                        break;
                }
                if (this._sortDirection == StoreItemList.SortDirection.Ascending)
                {
                    return itemId.CompareTo(qtyAvailable);
                }
                return qtyAvailable.CompareTo(itemId);
            }
        }
    }
}

