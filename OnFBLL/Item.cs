namespace PBA.OnfBLL
{
    using PBA.OnfDAL;
    using PBA.OnfInfo;
    using System;
    using System.Collections.Generic;

    public class Item
    {
        public static bool BelongsToSuperDept(ItemInfo item, string superDept)
        {
            DepartmentInfo[] deptsFromSuperDept = Department.GetDeptsFromSuperDept(item.StoreId, superDept);
            foreach (DepartmentInfo info in deptsFromSuperDept)
            {
                if (itemExists(item, info.DeptId.Value))
                {
                    return true;
                }
            }
            return false;
        }

        public static int CalcQtyAvailable(int? storeID, string itemID)
        {
            return ItemData.CalcQtyAvailable(storeID, itemID);
        }

        public static void DeleteItem(ItemInfo item)
        {
            ItemData.Delete(item);
        }

        public static void DeleteItem(int storeID, string itemID)
        {
            ItemData.Delete(new int?(storeID), itemID);
        }

        public static DateTime? GetEarliestInboundMaterialArrivalDate(int? storeID, string itemID)
        {
            return ItemData.GetEarliestInboundMaterialArrivalDate(storeID, itemID);
        }

        public static int? GetEarliestInboundMaterialArrivalQuantity(int? storeID, string itemID)
        {
            return new int?(ItemData.GetEarliestInboundMaterialArrivalQuantity(storeID, itemID));
        }

        public static ItemInfo[] GetItem(int storeID)
        {
            return ItemData.GetItem(storeID);
        }

        public static ItemInfo[] GetItem(int storeId, string[] itemIds)
        {
            return ItemData.GetItem(storeId, itemIds);
        }

        public static ItemInfo[] GetItem(int storeID, int productID)
        {
            return ItemData.GetItem(storeID, productID);
        }

        public static ItemInfo GetItem(int storeID, string itemID)
        {
            return ItemData.GetItem(storeID, itemID);
        }

        public static ItemInfo[] GetItem(int storeID, int deptid, int subdeptid)
        {
            return ItemData.GetItem(storeID, deptid, subdeptid);
        }

        public static ItemInfo[] GetItemAndDefault(int storeID, int deptid, int subdeptid)
        {
            return ItemData.GetItemAndDefault(storeID, deptid, subdeptid);
        }

        public static Dictionary<string, ItemInfo> GetItemIdsAndItems(int storeId, string[] itemIds)
        {
            return ItemData.GetItemIdsAndItems(storeId, itemIds);
        }

        public static bool itemExists(ItemInfo item, int deptid)
        {
            return DepartmentData.itemExists(item, deptid);
        }

        public static void SaveItem(ItemInfo item)
        {
            if (!item.ProductId.HasValue)
            {
                throw new Exception("Item must have a parent product: You attempted to save an item without a product id assigned.");
            }
            ItemData.SaveItem(item);
        }
    }
}

