namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class JuniperActiveUserReportInfo
    {
        private int _count;
        private string _userType;

        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
        public string UserType
        {
            get
            {
                return this._userType;
            }
            set
            {
                this._userType = value;
            }
        }
    }
}

