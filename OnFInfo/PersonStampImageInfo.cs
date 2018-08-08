using System;
using System.Net.Mime;

namespace PBA.OnfInfo
{
    /// <summary>
    /// This class describes a row in Item_Field
    /// in PDF Stamping applications
    /// </summary>
    [Serializable]
    public class PersonStampImageInfo : Object
    {
        public const int MaxImageLength = 10000000;

        #region Private Members
        private int? mStoreId;              // Store
        private string mFieldName;          // Name of the field
        private int? mPersonId;             // Person
        private bool? mApproved;            // Approved by OF
        private bool? mDoNotDisplay;        // Hidden by person
        private byte[] mImage;              // Binary image
        #endregion


        #region constructors
        public PersonStampImageInfo()
        {
        }

        public PersonStampImageInfo(int? storeid, string fieldname, int? personid, bool? approved, bool?donotdisplay, byte[] image)
        {
            mStoreId = storeid;
            mFieldName = fieldname;
            mPersonId = personid;
            mApproved = approved;
            mImage = new byte[MaxImageLength];
            mImage = image;
            mDoNotDisplay = donotdisplay;
        }

        #endregion


        #region properties
        public int? StoreId
        {
            get { return mStoreId; }
            set { mStoreId = value; }
        }

        public string FieldName
        {
            get { return mFieldName; }
            set { mFieldName = value; }
        }

        public int? PersonId
        {
            get { return mPersonId; }
            set { mPersonId = value; }
        }

        public bool? Approved
        {
            get { return mApproved; }
            set { mApproved = value; }
        }

        public bool? DoNotDisplay
        {
            get { return mDoNotDisplay; }
            set { mDoNotDisplay = value; }
        }

        public byte[] Image
        {
            get { return mImage; }
            set { mImage = value; }
        }

        #endregion
    }
}