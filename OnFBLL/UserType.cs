namespace PBA.OnfBLL
{
    using PBA.OnfDAL;
    using PBA.OnfInfo;
    using System;

    public class UserType
    {
        public static UserTypeInfo GetUserType(int? storeId, string userType)
        {
            return UserTypeData.GetUserType(storeId, userType);
        }

        public static UserTypeInfo[] GetUserTypes(int? storeId)
        {
            return UserTypeData.GetUserTypes(storeId);
        }

        public static UserTypeInfo[] GetUserTypesAndDefault(int? storeId)
        {
            return UserTypeData.GetUserTypesAndDefault(storeId);
        }

        public static UserTypeInfo[] GetUserTypesAndDefaultValue(int? storeId, string defaultValue)
        {
            return UserTypeData.GetUserTypesAndDefaultValue(storeId, defaultValue);
        }
    }
}

