using System;

namespace PBA.OnfInfo
{
    /// <summary>
    /// This class describes a row in Stamp_Field. It is used
    /// PDF stamping applications
    /// </summary>
    [Serializable]
    public class StampFieldDefinitionInfo : Object
    {
        public enum FieldTypes
        {
            None,
            Rectangle,
            Text,
            Image,
            Watermark,
            BackgroundImage
        } ;
        #region Private Members

        #endregion


        #region constructors
        public StampFieldDefinitionInfo()
        {
        }

        public StampFieldDefinitionInfo(int? storeid, string fieldname, int? fieldtype, int? numberoflines,
            int? linelength, string fontname, double? fontsize, double? imagewidth, double? imageheight,
            int? colordepth, int? backgroundcolor, int? foregroundcolor, double? scalingfactor, double? minimumimageresolution,
            string watermarktext)
        {
            StoreId = storeid;
            FieldName = fieldname;
            FieldType = fieldtype;
            NumberOfLines = numberoflines;
            LineLength = linelength;
            FontName = fontname;
            FontSize = fontsize;
            ImageWidth = imagewidth;
            ImageHeight = imageheight;
            ColorDepth = colordepth;
            BackgroundColor = backgroundcolor;
            ForegroundColor = foregroundcolor;
            ScalingFactor = scalingfactor;
            MinimumImageResolution = minimumimageresolution;
            WatermarkText = watermarktext;
        }

        #endregion

        #region properties

        public int? StoreId { get; set; }
        public string FieldName { get; set; }
        public int? FieldType { get; set; }
        public int? NumberOfLines { get; set; }
        public int? LineLength { get; set; }
        public string FontName { get; set; }
        public double? FontSize { get; set; }
        public double? ImageWidth { get; set; }
        public double? ImageHeight { get; set; }
        public int? ColorDepth { get; set; }
        public int? BackgroundColor { get; set; }
        public int? ForegroundColor { get; set; }
        public double? ScalingFactor { get; set; }
        public double? MinimumImageResolution { get; set; }
        public string WatermarkText { get; set; }
        public string BackgroundImage { get; set; }
        public double? Padding { get; set; }

        #endregion
    }
}