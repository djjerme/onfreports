using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using PBA.OnfDAL;
using PBA.OnfInfo;

namespace PBA.OnfList
{
    public class OrderShippingDetailList : CollectionBase, IBindingList
    {
        private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
        private ListChangedEventHandler onListChanged;

        public IList GetOrderShippingDetail()
        {
            IList l = (IList)this;

            OrderShippingDetailInfo[] definitions = OrderShippingDetailData.GetOrderShippingDetail();

            foreach (OrderShippingDetailInfo definition in definitions)
            {
                l.Add(definition);
            }
            OnListChanged(resetEvent);

            return l;
        }

        public static List<OrderShippingDetailInfo> GetOrderShippingDetailList()
        {
            List<OrderShippingDetailInfo> definitions = new List<OrderShippingDetailInfo>();

            OrderShippingDetailInfo[] OrderShippingDetailList =
                OrderShippingDetailData.GetOrderShippingDetail();

            foreach (OrderShippingDetailInfo definition in OrderShippingDetailList)
            {
                definitions.Add(definition);
            }

            return definitions;
        }

        public static List<OrderShippingDetailInfo> GetOrderShippingDetailList(
            int? storeid, DateTime? needstart, DateTime? needend, string requestedshipmethod)
        {
            List<OrderShippingDetailInfo> definitions = new List<OrderShippingDetailInfo>();

            OrderShippingDetailInfo[] OrderShippingDetailList =
                OrderShippingDetailData.GetOrderShippingDetail(storeid, needstart, needend, requestedshipmethod);

            foreach (OrderShippingDetailInfo definition in OrderShippingDetailList)
            {
                definitions.Add(definition);
            }

            return definitions;
        }

        public OrderShippingDetailInfo this[int index]
        {
            get
            {
                return (OrderShippingDetailInfo)(List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(OrderShippingDetailInfo value)
        {
            return List.Add(value);
        }

        public OrderShippingDetailInfo AddNew()
        {
            return (OrderShippingDetailInfo)((IBindingList)this).AddNew();
        }

        public void Remove(OrderShippingDetailInfo value)
        {
            List.Remove(value);
        }

        protected virtual void OnListChanged(ListChangedEventArgs ev)
        {
            if (onListChanged != null)
            {
                onListChanged(this, ev);
            }
        }


        protected override void OnClear()
        {
        }

        protected override void OnClearComplete()
        {
            OnListChanged(resetEvent);
        }

        protected override void OnInsertComplete(int index, object value)
        {
            OrderShippingDetailInfo c = (OrderShippingDetailInfo)value;
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            OrderShippingDetailInfo c = (OrderShippingDetailInfo)value;
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            if (oldValue != newValue)
            {
                OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
            }
        }

        // Called by ChargeType when it changes.
        internal void StoreChanged(OrderShippingDetailInfo info)
        {

            int index = List.IndexOf(info);

            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
        }

        // Implements IBindingList.
        bool IBindingList.AllowEdit
        {
            get { return true; }
        }

        bool IBindingList.AllowNew
        {
            get { return true; }
        }

        bool IBindingList.AllowRemove
        {
            get { return true; }
        }

        bool IBindingList.SupportsChangeNotification
        {
            get { return true; }
        }

        bool IBindingList.SupportsSearching
        {
            get { return false; }
        }

        bool IBindingList.SupportsSorting
        {
            get { return false; }
        }


        // Events.
        public event ListChangedEventHandler ListChanged
        {
            add
            {
                onListChanged += value;
            }
            remove
            {
                onListChanged -= value;
            }
        }

        // Methods.
        object IBindingList.AddNew()
        {
            OrderShippingDetailInfo c = new OrderShippingDetailInfo();
            List.Add(c);
            return c;
        }


        // Unsupported properties.
        bool IBindingList.IsSorted
        {
            get { throw new NotSupportedException(); }
        }

        ListSortDirection IBindingList.SortDirection
        {
            get { throw new NotSupportedException(); }
        }


        PropertyDescriptor IBindingList.SortProperty
        {
            get { throw new NotSupportedException(); }
        }


        // Unsupported Methods.
        void IBindingList.AddIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }

        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotSupportedException();
        }

        int IBindingList.Find(PropertyDescriptor property, object key)
        {
            throw new NotSupportedException();
        }

        void IBindingList.RemoveIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }

        void IBindingList.RemoveSort()
        {
            throw new NotSupportedException();
        }
    }
}
