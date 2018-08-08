using System;
using System.Collections.Generic;
using System.Text;
using PBA.OnfInfo;
using PBA.OnfDAL;

namespace PBA.OnfBLL
{
    /// <summary>
    /// Business object for store-specific order export settings
    /// </summary>
    public class InventorySnapshot
    {
        static public InventorySnapshotInfo[] GetInventorySnapshot(int storeID, DateTime startdate, DateTime enddate, bool archive)
        {
            InventorySnapshotInfo[] snapshot = InventorySnapshotData.GetInventorySnapshot(storeID, startdate, enddate, archive);
            return snapshot;
        }
    }
}
