namespace PBA.OnfBLL
{
    using PBA.OnfDAL;
    using PBA.OnfInfo;
    using System;

    public class Department
    {
        public static DepartmentInfo[] GetDepartments(int? storeId)
        {
            DepartmentInfo[] departments = null;
            if (storeId.HasValue)
            {
                departments = DepartmentData.GetDepartments(storeId);
            }
            return departments;
        }

        public static DepartmentInfo[] GetDepartmentsAndDefault(int? storeId)
        {
            DepartmentInfo[] departmentsAndDefault = null;
            if (storeId.HasValue)
            {
                departmentsAndDefault = DepartmentData.GetDepartmentsAndDefault(storeId, null);
            }
            return departmentsAndDefault;
        }

        public static DepartmentInfo[] GetDepartmentsAndDefault(int? storeId, int? superdeptid)
        {
            DepartmentInfo[] departmentsAndDefault = null;
            if (storeId.HasValue)
            {
                departmentsAndDefault = DepartmentData.GetDepartmentsAndDefault(storeId, superdeptid);
            }
            return departmentsAndDefault;
        }

        public static DepartmentInfo[] GetDepartmentsOnly(int? storeId)
        {
            DepartmentInfo[] departmentsOnly = null;
            if (storeId.HasValue)
            {
                departmentsOnly = DepartmentData.GetDepartmentsOnly(storeId);
            }
            return departmentsOnly;
        }

        public static string GetDeptName(int? storeId, int? deptId)
        {
            string deptName = string.Empty;
            if (storeId.HasValue && deptId.HasValue)
            {
                if (deptId == 0)
                {
                    return "All Products";
                }
                deptName = DepartmentData.GetDeptName(storeId, deptId);
            }
            return deptName;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType)
        {
            DepartmentInfo[] deptsForUserType = null;
            if (storeId.HasValue)
            {
                deptsForUserType = DepartmentData.GetDeptsForUserType(storeId, userType);
            }
            return deptsForUserType;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptSortCol);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptIds);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptIds, deptSortCol);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptSortCol, loadSubDepts);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptIds, deptSortCol, loadSubDepts);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptSortCol, loadSubDepts, subDeptSortCol);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptIds, deptSortCol, loadSubDepts, subDeptSortCol);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol, bool activeDeptOnly)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptSortCol, loadSubDepts, subDeptSortCol, activeDeptOnly);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol, bool activeDeptsOnly)
        {
            DepartmentInfo[] infoArray = null;
            if (storeId.HasValue)
            {
                infoArray = DepartmentData.GetDeptsForUserType(storeId, userType, deptIds, deptSortCol, loadSubDepts, subDeptSortCol, activeDeptsOnly);
            }
            return infoArray;
        }

        public static DepartmentInfo[] GetDeptsFromProduct(int? storeId, int productId)
        {
            DepartmentInfo[] deptsFromProduct = null;
            if (storeId.HasValue)
            {
                deptsFromProduct = DepartmentData.GetDeptsFromProduct(storeId, productId);
            }
            return deptsFromProduct;
        }

        public static DepartmentInfo[] GetDeptsFromSuperDept(int? storeId, string superDept)
        {
            DepartmentInfo[] deptsFromSuperDept = null;
            if (storeId.HasValue)
            {
                deptsFromSuperDept = DepartmentData.GetDeptsFromSuperDept(storeId, superDept);
            }
            return deptsFromSuperDept;
        }
    }
}

