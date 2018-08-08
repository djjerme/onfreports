using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfInfo;

namespace PBA.OnfDAL
{
    public class StampFieldDefinitionData : DataAccess
    {
        public static int UpdateStampField(StampFieldDefinitionInfo info)
        {
            ArrayList c = new ArrayList();

            const string l_Query = "UPDATE dbo.stamp_field_definition set "
                                   + "number_of_lines = @NumberOfLines, "
                                   + "line_length = @LineLength, "
                                   + "font_name = @FontName, "
                                   + "font_size = @FontSize, "
                                   + "image_width = @ImageWidth, "
                                   + "image_height = @ImageHeight, "
                                   + "image_color_depth = @ColorDepth, "
                                   + "scaling_factor = @ScalingFactor, "
                                   + "minimum_image_resolution = @MinimumImageResolution, "
                                   + "watermark_text = @WatermarkText, "
                                   + "background_image = @BackgroundImage, "
                                   + "padding = @Padding "
                                   + "WHERE Store_id = @StoreId "
                                   + "   AND field_name = @FieldName";

            SqlParameter l_Parm = new SqlParameter("@NumberOfLines", SqlDbType.Int) {Value = info.NumberOfLines};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@LineLength", SqlDbType.Int) {Value = info.LineLength};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FontName", SqlDbType.VarChar) {Value = info.FontName};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@LineLength", SqlDbType.Int) {Value = info.LineLength};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FontSize", SqlDbType.Float) {Value = info.FontSize};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ImageWidth", SqlDbType.Float) {Value = info.ImageWidth};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ImageHeight", SqlDbType.Float) {Value = info.ImageHeight};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ColorDepth", SqlDbType.Int) {Value = info.ColorDepth};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@StoreId", SqlDbType.Int) {Value = info.StoreId};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldName", SqlDbType.VarChar) {Value = info.FieldName};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ScalingFactor", SqlDbType.Float) {Value = info.ScalingFactor};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@MinimumImageResolution", SqlDbType.Float) {Value = info.MinimumImageResolution};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@WatermarkText", SqlDbType.VarChar) { Value = info.WatermarkText };
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@BackgroundImage", SqlDbType.VarChar) { Value = info.BackgroundImage };
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@Padding", SqlDbType.Float) { Value = info.Padding };
            c.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])c.ToArray(typeof(SqlParameter));

            int rc = Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query, l_Parms));
            return rc;
        }

        public static int AddStampField(StampFieldDefinitionInfo info)
        {
            ArrayList c = new ArrayList();

            const string l_Query =
                "INSERT INTO dbo.stamp_field_definition (store_id, field_name, field_type, number_of_lines, line_length, "
                + "   font_name, font_size, image_width, image_height, color_depth, scaling_factor, minimum_image_resolution, "
                + "   watermark_text, background_image, padding ) "
                + "values (@StoreId, @FieldName, @FieldType, @NumberOfLines, @LineLength, "
                + "   @FontName, @FontSize, @ImageWidth, @ImageHeight, @ColorDepth, @ScalingFactor, @MinimumImageResolution, "
                + "   @WatermarkText, @BackgroundImage, @Padding) ";

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int) {Value = info.StoreId};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldName", SqlDbType.VarChar) {Value = info.FieldName};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldType", SqlDbType.Int) {Value = info.FieldType};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@NumberOfLines", SqlDbType.Int) {Value = info.NumberOfLines};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@LineLength", SqlDbType.Int) {Value = info.LineLength};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FontName", SqlDbType.VarChar) {Value = info.FontName};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@LineLength", SqlDbType.Int) {Value = info.LineLength};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@FontSize", SqlDbType.Float) {Value = info.FontSize};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ImageWidth", SqlDbType.Float) {Value = info.ImageWidth};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ImageHeight", SqlDbType.Float) {Value = info.ImageHeight};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ColorDepth", SqlDbType.Int) {Value = info.ColorDepth};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@ScalingFactor", SqlDbType.Float) {Value = info.ScalingFactor};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@MinimumImageResolution", SqlDbType.Float) {Value = info.MinimumImageResolution};
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@WatermarkText", SqlDbType.VarChar) { Value = info.WatermarkText };
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@BackgroundImage", SqlDbType.VarChar) { Value = info.BackgroundImage };
            c.Add(l_Parm);

            l_Parm = new SqlParameter("@Padding", SqlDbType.Float) { Value = info.Padding };
            c.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])c.ToArray(typeof(SqlParameter));

            int rc = Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query, l_Parms));
            return rc;
        }

        public static StampFieldDefinitionInfo[] GetStampField()
        {
            ArrayList c = new ArrayList();

            const string sql = "select * from stamp_field_definition ";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            while (d.Read())
            {
                StampFieldDefinitionInfo al = new StampFieldDefinitionInfo();
                AssignValues(d, al);

                c.Add(al);
            }

            d.Close();

            return (StampFieldDefinitionInfo[])c.ToArray(typeof(StampFieldDefinitionInfo));
        }

        public static StampFieldDefinitionInfo[] GetStampField(int? StoreId)
        {
            ArrayList p = new ArrayList();
            ArrayList c = new ArrayList();

            const string sql = "select * from stamp_field_definition "
                               + "WHERE store_id = @StoreId "
                               + "ORDER BY field_type ";

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int, 0) {Value = StoreId};
            p.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])p.ToArray(typeof(SqlParameter));

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, l_Parms);

            while (d.Read())
            {
                StampFieldDefinitionInfo al = new StampFieldDefinitionInfo();
                AssignValues(d, al);

                c.Add(al);
            }

            d.Close();

            return (StampFieldDefinitionInfo[])c.ToArray(typeof(StampFieldDefinitionInfo));
        }

        public static StampFieldDefinitionInfo[] GetStampField(int? StoreId, int? FieldType)
        {
            ArrayList p = new ArrayList();
            ArrayList c = new ArrayList();

            const string sql = "select * from stamp_field_definition "
                               + "WHERE store_id = @StoreId "
                               + "   AND field_type = @FieldType "
                               + "ORDER BY field_type ";

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int, 0) {Value = StoreId};
            p.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldType", SqlDbType.Int, 0) {Value = FieldType};
            p.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])p.ToArray(typeof(SqlParameter));

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, l_Parms);

            while (d.Read())
            {
                StampFieldDefinitionInfo al = new StampFieldDefinitionInfo();
                AssignValues(d, al);

                c.Add(al);
            }

            d.Close();

            return (StampFieldDefinitionInfo[])c.ToArray(typeof(StampFieldDefinitionInfo));
        }

        public static StampFieldDefinitionInfo GetStampField(int? StoreId, string FieldName)
        {
            ArrayList p = new ArrayList();

            const string sql = "SELECT * from stamp_field_definition "
                               + "WHERE store_id = @StoreId "
                               + "   AND field_name = @FieldName ";

            SqlParameter l_Parm = new SqlParameter("@StoreId", SqlDbType.Int, 0) {Value = StoreId};
            p.Add(l_Parm);

            l_Parm = new SqlParameter("@FieldName", SqlDbType.VarChar) {Value = FieldName};
            p.Add(l_Parm);

            SqlParameter[] l_Parms = (SqlParameter[])p.ToArray(typeof(SqlParameter));

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, l_Parms);

            StampFieldDefinitionInfo al = new StampFieldDefinitionInfo();

            d.Read();

            if (d.HasRows)
            {
                AssignValues(d, al);
            }
            d.Close();

            return al;
        }

        private static void AssignValues(SqlDataReader d, StampFieldDefinitionInfo al)
        {
            al.StoreId = NCI(d["store_id"]);
            al.FieldName = NCS(d["field_name"]);
            al.FieldType = NCI(d["field_type"]);
            al.NumberOfLines = NCI(d["number_of_lines"]);
            al.LineLength = NCI(d["line_length"]);
            al.FontName = NCS(d["font_name"]);
            al.LineLength = NCI(d["line_length"]);
            al.FontSize = NCDbl(d["font_size"]);
            al.ImageWidth = NCDbl(d["image_width"]);
            al.ImageHeight = NCDbl(d["image_height"]);
            al.ColorDepth = NCI(d["color_depth"]);
            al.BackgroundColor = NCI(d["background_color"]);
            al.ForegroundColor = NCI(d["foreground_color"]);
            al.ScalingFactor = NCDbl(d["scaling_factor"]);
            al.MinimumImageResolution = NCDbl(d["minimum_image_resolution"]);
            al.WatermarkText = NCS(d["watermark_text"]);
            al.BackgroundImage = NCS(d["background_image"]);
            al.Padding = NCDbl(d["padding"]);
        }
    }
}
