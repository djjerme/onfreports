using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfInfo;

namespace PBA.OnfDAL
{
    public class PersonStampImageData : DataAccess
    {
        public static int UpdatePersonStampImage(PersonStampImageInfo info)
        {
            ArrayList c = new ArrayList();

            const string l_Query = "UPDATE dbo.Person_Stamp_Image set "
                                   + "[image] = @Image, "
                                   + "approved = @Approved, "
                                   + "do_not_display = @DoNotDisplay "
                                   + "WHERE Store_id = @StoreId "
                                   + "   AND field_name = @FieldName "
                                   + "   AND person_id = @PersonId";

            SqlParameter l_Parm = new SqlParameter("@Image", SqlDbType.Image, info.Image.Length);
            l_Parm.Value = info.Image;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@StoreId", SqlDbType.Int);
            l_Parm.Value = info.StoreId;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@Approved", SqlDbType.Bit);
            l_Parm.Value = info.Approved;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@DoNotDisplay", SqlDbType.Bit);
            l_Parm.Value = info.DoNotDisplay;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldName", SqlDbType.VarChar);
            l_Parm.Value = info.FieldName;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@PersonId", SqlDbType.VarChar);
            l_Parm.Value = info.PersonId;
            c.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])c.ToArray(typeof(SqlParameter));

            int rc = Convert.ToInt32(SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, l_Query, l_Parms));
            return rc;
        }

        public static int AddPersonStampImage(PersonStampImageInfo info)
        {
            ArrayList c = new ArrayList();

            const string l_Query =
                "INSERT INTO dbo.Person_Stamp_Image (store_id, field_name, person_id, approved, do_not_display, [image]) "
                + "values (@StoreId, @FieldName, @PersonId, @Approved, @DoNotDisplay, @Image) ";

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int);
            l_Parm.Value = info.StoreId;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldName", SqlDbType.VarChar);
            l_Parm.Value = info.FieldName;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@PersonId", SqlDbType.Int);
            l_Parm.Value = info.PersonId;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@Approved", SqlDbType.Bit);
            l_Parm.Value = info.Approved;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@DoNotDisplay", SqlDbType.Bit);
            l_Parm.Value = info.DoNotDisplay;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@Image", SqlDbType.Image, info.Image.Length);
            l_Parm.Value = info.Image;
            c.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])c.ToArray(typeof(SqlParameter));

            int rc = Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query, l_Parms));
            return rc;
        }

        public static PersonStampImageInfo[] GetPersonStampImage(int? StoreId, int? PersonId)
        {
            ArrayList c = new ArrayList();

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int);
            l_Parm.Value = StoreId;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@PersonId", SqlDbType.VarChar);
            l_Parm.Value = PersonId;
            c.Add(l_Parm);

            const string sql = "SELECT * from Person_Stamp_Image "
                               + "WHERE store_id = @StoreId "
                               + "   AND Item_id = @ItemId ";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            while (d.Read())
            {
                PersonStampImageInfo al = new PersonStampImageInfo();
                AssignValues(d, al);

                c.Add(al);
            }

            d.Close();

            return (PersonStampImageInfo[])c.ToArray(typeof(PersonStampImageInfo));
        }

        public static PersonStampImageInfo GetPersonStampImage(int? StoreId, int? PersonId, string FieldName)
        {
            ArrayList p = new ArrayList();

            const string sql = "SELECT * from Person_Stamp_Image "
                               + "WHERE store_id = @StoreId "
                               + "   AND field_name = @FieldName "
                               + "   AND person_id = @PersonId ";

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int, 0);
            l_Parm.Value = StoreId;
            p.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldName", SqlDbType.VarChar);
            l_Parm.Value = FieldName;
            p.Add(l_Parm);

            l_Parm = new SqlParameter("@PersonId", SqlDbType.Int);
            l_Parm.Value = PersonId;
            p.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])p.ToArray(typeof(SqlParameter));

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, l_Parms);

            PersonStampImageInfo al = null;

            d.Read();

            if (d.HasRows)
            {
                al = new PersonStampImageInfo();
                AssignValues(d, al);
            }
            d.Close();

            return al;
        }

        private static void AssignValues(IDataRecord d, PersonStampImageInfo al)
        {
            al.StoreId = NCI(d["store_id"]);
            al.FieldName = NCS(d["field_name"]);
            al.PersonId = NCI(d["person_id"]);
            al.Approved = NCB(d["approved"]);
            al.DoNotDisplay = NCB(d["do_not_display"]);
            int col = d.GetOrdinal("image");

            if (col >= 0)
            {
                
                long sz = d.GetBytes(col, 0, null, 0, PersonStampImageInfo.MaxImageLength);
                al.Image = new byte[sz];
                d.GetBytes(col, 0, al.Image, 0, Convert.ToInt32(sz));
            }
        }

    }
}
