using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using PBA.OnfDAL;
using PBA.OnfInfo;

namespace PBA.OnfList
{
    public class CarrierList : CollectionBase, IBindingList
    {
        private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
        private ListChangedEventHandler onListChanged;

        public IList GetCarrier()
        {
            IList l = (IList)this;

            CarrierInfo[] Carriers = CarrierData.GetCarrier();

            foreach (CarrierInfo Carrier in Carriers)
            {
                l.Add(Carrier);
            }
            OnListChanged(resetEvent);

            return l;
        }

        public static List<CarrierInfo> GetCarrierList()
        {
            List<CarrierInfo> Carriers = new List<CarrierInfo>();

            CarrierInfo[] Carrierlist = CarrierData.GetCarrier();

            foreach (CarrierInfo Carrier in Carrierlist)
            {
                Carriers.Add(Carrier);
            }

            return Carriers;
        }

        public static List<CarrierInfo> GetCarriersOnly()
        {
            List<CarrierInfo> Carriers = new List<CarrierInfo>();

            CarrierInfo[] Carrierlist = CarrierData.GetCarriersOnly();

            foreach (CarrierInfo Carrier in Carrierlist)
            {
                Carriers.Add(Carrier);
            }

            return Carriers;
        }

        public static List<CarrierInfo> GetCarriersWithoutFreightRule(int? storeid)
        {
            List<CarrierInfo> Carriers = new List<CarrierInfo>();

            CarrierInfo[] Carrierlist = CarrierData.GetCarriersWithoutFreightRule(storeid);

            foreach (CarrierInfo Carrier in Carrierlist)
            {
                Carriers.Add(Carrier);
            }

            return Carriers;
        }

        public CarrierInfo this[int index]
        {
            get
            {
                return (CarrierInfo)(List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(CarrierInfo value)
        {
            return List.Add(value);
        }

        public CarrierInfo AddNew()
        {
            return (CarrierInfo)((IBindingList)this).AddNew();
        }

        public void Remove(CarrierInfo value)
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
            CarrierInfo c = (CarrierInfo)value;
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            CarrierInfo c = (CarrierInfo)value;
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
        internal void CarrierChanged(CarrierInfo info)
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
            CarrierInfo c = new CarrierInfo();
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
