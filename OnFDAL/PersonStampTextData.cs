using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfInfo;

namespace PBA.OnfDAL
{
    public class PersonStampTextData : DataAccess
    {
        public static int UpdatePersonStampText(PersonStampTextInfo info)
        {
            ArrayList c = new ArrayList();

            const string l_Query = "UPDATE dbo.Person_Stamp_Text set "
                                   + "[text] = @Text, "
                                   + "do_not_display = @DoNotDisplay "
                                   + "WHERE Store_id = @StoreId "
                                   + "   AND field_name = @FieldName "
                                   + "   AND person_id = @PersonId";

            SqlParameter l_Parm = new SqlParameter("@Text", SqlDbType.VarChar);
            l_Parm.Value = info.Text;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@StoreId", SqlDbType.Int);
            l_Parm.Value = info.StoreId;
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

            int rc = Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query, l_Parms));
            return rc;
        }

        public static int AddPersonStampText(PersonStampTextInfo info)
        {
            ArrayList c = new ArrayList();

            const string l_Query =
                "INSERT INTO dbo.Person_Stamp_Text (store_id, field_name, person_id, do_not_display, [text]) "
                + "values (@StoreId, @FieldName, @PersonId, @DoNotDisplay, @Text) ";

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int);
            l_Parm.Value = info.StoreId;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldName", SqlDbType.VarChar);
            l_Parm.Value = info.FieldName;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@PersonId", SqlDbType.Int);
            l_Parm.Value = info.PersonId;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@DoNotDisplay", SqlDbType.Bit);
            l_Parm.Value = info.DoNotDisplay;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@Text", SqlDbType.VarChar);
            l_Parm.Value = info.Text;
            c.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])c.ToArray(typeof(SqlParameter));

            int rc = Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query, l_Parms));
            return rc;
        }

        public static PersonStampTextInfo[] GetPersonStampText(int? StoreId, int? PersonId)
        {
            ArrayList c = new ArrayList();

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int);
            l_Parm.Value = StoreId;
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@PersonId", SqlDbType.VarChar);
            l_Parm.Value = PersonId;
            c.Add(l_Parm);

            const string sql = "SELECT * from Person_Stamp_Text "
                               + "WHERE store_id = @StoreId "
                               + "   AND Item_id = @ItemId ";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            while (d.Read())
            {
                PersonStampTextInfo al = new PersonStampTextInfo();
                AssignValues(d, al);

                c.Add(al);
            }

            d.Close();

            return (PersonStampTextInfo[])c.ToArray(typeof(PersonStampTextInfo));
        }

        public static PersonStampTextInfo GetPersonStampText(int? StoreId, int? PersonId, string FieldName)
        {
            ArrayList p = new ArrayList();

            const string sql = "SELECT * from Person_Stamp_Text "
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

            PersonStampTextInfo al = null;

            d.Read();

            if (d.HasRows)
            {
                al = new PersonStampTextInfo();
                AssignValues(d, al);
            }
            d.Close();

            return al;
        }

        private static void AssignValues(SqlDataReader d, PersonStampTextInfo al)
        {
            al.StoreId = NCI(d["store_id"]);
            al.FieldName = NCS(d["field_name"]);
            al.DoNotDisplay = NCB(d["do_not_display"]);
            al.PersonId = NCI(d["person_id"]);
            al.Text = NCS(d["text"]);
        }

    }
}
