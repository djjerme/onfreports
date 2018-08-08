namespace PBA.OnfInfo
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable]
    public class SearchInfo
    {
        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct TableNames
        {
            public static readonly string Item;
            public static readonly string Prev30DayOrderQty;
            public static readonly string Product;
            public static readonly string UserTypeItem;
            public static readonly string UserTypeProduct;
            static TableNames()
            {
                Item = "item";
                Prev30DayOrderQty = "prev30DayOrderQty";
                Product = "product";
                UserTypeItem = "userTypeItem";
                UserTypeProduct = "userTypeProduct";
            }
        }
    }
}

