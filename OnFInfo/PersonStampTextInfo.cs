using System;

namespace PBA.OnfInfo
{
    /// <summary>
    /// This class describes a row in Item_Field
    /// in PDF Stamping applications
    /// </summary>
    [Serializable]
    public class PersonStampTextInfo : Object
    {
        #region Private Members
        private int? mStoreId;              // Store
        private string mFieldName;          // Name of the field
        private int? mPersonId;             // Person
        private bool? mDoNotDisplay;        // Hidden by person
        private string mText;               // Formatted text
        #endregion


        #region constructors
        public PersonStampTextInfo()
        {
        }

        public PersonStampTextInfo(int? storeid, string fieldname, int? personid, bool?donotdisplay, string text)
        {
            mStoreId = storeid;
            mFieldName = fieldname;
            mPersonId = personid;
            mDoNotDisplay = donotdisplay;
            mText = text;
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

        public bool? DoNotDisplay
        {
            get { return mDoNotDisplay; }
            set { mDoNotDisplay = value; }
        }

        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        #endregion
    }
}