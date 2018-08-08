namespace PBA.OnfInfo
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public class StoreProductList : CollectionBase
    {
        private const string CLASS_NAME = "PBA.OnfInfo.StoreProductList";
        private const string LIST_TYPE = "PBA.OnfInfo.StoreProductInfo";

        public int Add(StoreProductInfo value)
        {
            return base.List.Add(value);
        }

        public bool Contains(StoreProductInfo value)
        {
            return base.List.Contains(value);
        }

        public int IndexOf(StoreProductInfo value)
        {
            return base.List.IndexOf(value);
        }

        public void Insert(int index, StoreProductInfo value)
        {
            base.List.Insert(index, value);
        }

        protected override void OnValidate(object value)
        {
            if (!(value.GetType() == Type.GetType("PBA.OnfInfo.StoreProductInfo")))
            {
                throw new ArgumentException(string.Format("Value must be of type {0}.", "PBA.OnfInfo.StoreProductInfo"), "value");
            }
        }

        public void Remove(StoreProductInfo value)
        {
            base.List.Remove(value);
        }

        public void Sort(SortColumn sortOrder)
        {
            this.Sort(sortOrder, SortDirection.Ascending);
        }

        public void Sort(SortColumn sortOrder, SortDirection sortDirection)
        {
            IComparer comparer = new StoreProductSort(sortOrder, sortDirection);
            base.InnerList.Sort(comparer);
        }

        public override string ToString()
        {
            return string.Format("{0}:\n\tCount = {1}", "PBA.OnfInfo.StoreProductList", base.List.Count);
        }

        public StoreProductInfo this[int index]
        {
            get
            {
                return (StoreProductInfo) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }

        public enum SortColumn
        {
            FirstItemId,
            Name,
            ProductId,
            DateCreated,
            Sequence
        }

        public enum SortDirection
        {
            Ascending,
            Descending
        }

        private class StoreProductSort : IComparer
        {
            private StoreProductList.SortColumn _sortColumn;
            private StoreProductList.SortDirection _sortDirection;

            public StoreProductSort(StoreProductList.SortColumn sortOrder, StoreProductList.SortDirection sortDirection)
            {
                this._sortColumn = sortOrder;
                this._sortDirection = sortDirection;
            }

            public int Compare(object x, object y)
            {
                StoreProductInfo info = (StoreProductInfo) x;
                StoreProductInfo info2 = (StoreProductInfo) y;
                IComparable firstItemId = null;
                IComparable name = null;
                if ((info == null) || (info2 == null))
                {
                    return 0;
                }
                switch (this._sortColumn)
                {
                    case StoreProductList.SortColumn.FirstItemId:
                        firstItemId = info.FirstItemId;
                        name = info2.FirstItemId;
                        goto Label_0117;

                    case StoreProductList.SortColumn.Name:
                        firstItemId = info.Name;
                        name = info2.Name;
                        goto Label_0117;

                    case StoreProductList.SortColumn.ProductId:
                        firstItemId = (IComparable) info.ProductId;
                        name = (IComparable) info2.ProductId;
                        goto Label_0117;

                    case StoreProductList.SortColumn.DateCreated:
                        if (info.createdDate.HasValue)
                        {
                            firstItemId = (IComparable) info.createdDate;
                            break;
                        }
                        firstItemId = DateTime.MinValue;
                        break;

                    case StoreProductList.SortColumn.Sequence:
                        firstItemId = (IComparable) info.Sequence;
                        name = (IComparable) info2.Sequence;
                        goto Label_0117;

                    default:
                        goto Label_0117;
                }
                if (!info2.createdDate.HasValue)
                {
                    name = DateTime.MinValue;
                }
                else
                {
                    name = (IComparable) info2.createdDate;
                }
            Label_0117:
                if ((name == null) || (firstItemId == null))
                {
                    return 0;
                }
                if (this._sortDirection == StoreProductList.SortDirection.Ascending)
                {
                    return firstItemId.CompareTo(name);
                }
                return name.CompareTo(firstItemId);
            }
        }
    }
}

