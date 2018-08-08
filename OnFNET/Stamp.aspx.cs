using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PBA.OnfInfo;
using PBA.OnfDAL;
using PBA.OnfBLL;

public partial class Stamp : System.Web.UI.Page
{
    private int mPersonId;
    private int mStoreId;
    private StampFieldDefinitionInfo[] mStampFields;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mPersonId = Convert.ToInt32(Request.QueryString["p"]);
        }
        catch (Exception)
        {
            LabelError.Text = "No Person Id entered";
        }

        try
        {
            mStoreId = Convert.ToInt32(Request.QueryString["s"]);
        }
        catch (Exception)
        {
            LabelError.Text = "No Store Id entered";
        }

        if (!IsPostBack)
        {
            mStampFields = StampFieldDefinitionData.GetStampField(mStoreId);
            DropDownListStampFields.DataSource = mStampFields;
            DropDownListStampFields.DataBind();
            DropDownListStampFields.SelectedIndex = 0;
            HiddenFieldFieldType.Value = mStampFields[0].FieldType.ToString();
        }
    }
    protected void DropDownListStampFields_SelectedIndexChanged(object sender, EventArgs e)
    {
        StampFieldDefinitionInfo stampfield = StampFieldDefinitionData.GetStampField(mStoreId,
                                                                                     DropDownListStampFields.
                                                                                         SelectedValue);
        HiddenFieldFieldType.Value = stampfield.FieldType.ToString();
        

        switch ((StampFieldDefinitionInfo.FieldTypes) stampfield.FieldType)
        {
            case StampFieldDefinitionInfo.FieldTypes.Text:
                TextBoxFieldText.Enabled = true;
                FileUploadImage.Enabled = false;
                PersonStampTextInfo textinfo = PersonStampTextData.GetPersonStampText(mStoreId, mPersonId,
                                                                                      stampfield.FieldName);
                if (textinfo == null)
                {
                    TextBoxFieldText.Text = "";
                }
                else
                {
                    TextBoxFieldText.Text = textinfo.Text;
                }
                break;
            case StampFieldDefinitionInfo.FieldTypes.Image:
                TextBoxFieldText.Enabled = false;
                FileUploadImage.Enabled = true;
                PersonStampImageInfo imageinfo = PersonStampImageData.GetPersonStampImage(mStoreId, mPersonId,
                                                                                      stampfield.FieldName);

                if (imageinfo == null)
                {
                    ImageLogo.Visible = false;
                }
                else
                {
                    ImageLogo.ImageUrl = string.Format("StampImage.ashx?s={0}&p={1}&fn={2}", mStoreId, mPersonId,
                                                       imageinfo.FieldName);
                    ImageLogo.Visible = true;
                }

                break;
        }

    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        StampFieldDefinitionInfo.FieldTypes ft =
            (StampFieldDefinitionInfo.FieldTypes) Convert.ToInt32(HiddenFieldFieldType.Value);

        switch (ft)
        {
            case StampFieldDefinitionInfo.FieldTypes.Text:
                PersonStampTextInfo textinfo = PersonStampTextData.GetPersonStampText(mStoreId, mPersonId,
                                                                                      DropDownListStampFields.
                                                                                          SelectedValue);
                if (textinfo == null)
                {
                    textinfo = new PersonStampTextInfo(mStoreId, DropDownListStampFields.SelectedValue, mPersonId, false,
                                                       TextBoxFieldText.Text);
                    PersonStampTextData.AddPersonStampText(textinfo);
                }
                else
                {
                    textinfo.Text = TextBoxFieldText.Text;
                    PersonStampTextData.UpdatePersonStampText(textinfo);
                }
                break;
            case StampFieldDefinitionInfo.FieldTypes.Image:
                StampFieldDefinitionInfo fielddef = StampFieldDefinitionData.GetStampField(mStoreId,
                                                                                           DropDownListStampFields.
                                                                                               SelectedValue);
                if (fielddef == null)
                {
                    LabelError.Text = "This shouldn't happen";
                    break;
                }

                if (string.IsNullOrEmpty(FileUploadImage.FileName))
                {
                    LabelError.Text = "Please select a file";
                    break;
                }

                if (!FileUploadImage.HasFile)
                {
                    LabelError.Text = "Please select a file";
                    break;
                }

                int filelen = FileUploadImage.FileBytes.Length;
                if (filelen > PersonStampImageInfo.MaxImageLength)
                {
                    LabelError.Text = "File too large";
                    break;
                }

                MemoryStream ms = new MemoryStream(FileUploadImage.FileBytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                if ((img.Size.Width > fielddef.ImageWidth) ||
                    (img.Size.Height > fielddef.ImageHeight))
                {
                    LabelError.Text = "Image size is too large";
                    break;
                }

                // Hard part: Determine color depth
                // Until I get a spec on image file format this is disabled
                // Note: The code below is roughly ported from the VB.Net code found here:
                // http://www.4guysfromrolla.com/webtech/code/imgsz.asp.html
                /*
                int Width = 0;
                int Height = 0;
                int Depth = 0;

                byte[] buf = FileUploadImage.FileBytes;

                string filetype = Encoding.Default.GetString(buf, 0, 3);
                if (filetype.StartsWith("BM"))
                {
                    filetype = "BMP";
                }
                switch (filetype.ToUpper())
                {
                    case "GIF":
                        Width = Convert.ToInt32(buf[6]);
                        Height = Convert.ToInt32(buf[8]);
                        Depth = 2 ^
                                    (((buf[10]) & 7) + 1);

                        break;
                    case "BMP":
                        Width = Convert.ToInt32(buf[18]);
                        Height = Convert.ToInt32(buf[22]);
                        Depth = 2 ^
                                    (((buf[28]) & 7) + 1);
                        break;
                    case "PNG":
                        Width = Convert.ToInt32(Encoding.Default.GetString(buf, 19, 2));
                        Height = Convert.ToInt32(Encoding.Default.GetString(buf, 23, 2));
                        Depth = Convert.ToInt32(buf[25]);
                        
                        break;
                    default:
                        break;
                }
                */

                PersonStampImageInfo imageinfo = PersonStampImageData.GetPersonStampImage(mStoreId, mPersonId,
                                                                            DropDownListStampFields.
                                                                                SelectedValue);
                if (imageinfo == null)
                {
                    imageinfo = new PersonStampImageInfo(mStoreId, DropDownListStampFields.SelectedValue, mPersonId, true, true,
                                                       FileUploadImage.FileBytes);
                    PersonStampImageData.AddPersonStampImage(imageinfo);
                }
                else
                {
                    imageinfo.Image = FileUploadImage.FileBytes;
                    PersonStampImageData.UpdatePersonStampImage(imageinfo);
                }
                break;
        }
    }
}
