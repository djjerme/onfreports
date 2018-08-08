using System;
using System.Collections.Generic;
using System.Text;
using PBA.OnfDAL;

namespace PBA.OnfBLL
{
    public class Authentication
    {

        public static bool ValidateHandler(int storeID, string handler)
        {
            
            return DAL.ValidateHandler(storeID, handler);

        }

        public static bool ValidateHandler(int storeID, string handler, string password)
        {

            return DAL.ValidateHandler(storeID, handler, password);

        }

        /// <summary>
        /// Ths version of validate handler is intended for non-store specific access. 
        /// This would be used for a web service to handle username authentication over
        /// transport, where the client will be issuing webservice requests that may
        /// not be associated with a specific store. For a handler to be authenticated,
        /// it must have its whse_id set to zero. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="password"></param>
        /// <returns>true = validated</returns>
        public static bool ValidateHandler(string handler, string password)
        {
            return DAL.ValidateHandler(handler, password);
        }
    }
}
