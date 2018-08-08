namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class OrderShippedUpdateInfo
    {
        private string mActualShipMethod;
        private double? mActualShipping;
        private int? mCarrierId;
        private int? mNumberOfPackages;
        private string mOrderIdLong;
        private int? mOrderUpdated;
        private DateTime? mShipDate;
        private string mStatus;
        private int? mStatusCode;
        private string mTrackingNo;

        public OrderShippedUpdateInfo()
        {
            this.mOrderUpdated = 0;
        }

        public OrderShippedUpdateInfo(string orderidlong, DateTime shipdate, string trackingno, string status, double? actualshipping, string actualshipmethod, int? numberofpackages, int? carrierid, int? statuscode)
        {
            this.mOrderIdLong = orderidlong;
            this.mShipDate = new DateTime?(shipdate);
            this.mTrackingNo = trackingno;
            this.mStatus = status;
            this.mActualShipping = actualshipping;
            this.mActualShipMethod = actualshipmethod;
            this.mNumberOfPackages = numberofpackages;
            this.mCarrierId = carrierid;
            this.mStatusCode = statuscode;
            this.mOrderUpdated = 0;
        }

        public string ActualShipMethod
        {
            get
            {
                return this.mActualShipMethod;
            }
            set
            {
                this.mActualShipMethod = value;
            }
        }

        public double? ActualShipping
        {
            get
            {
                return this.mActualShipping;
            }
            set
            {
                this.mActualShipping = value;
            }
        }

        public int? CarrierId
        {
            get
            {
                return this.mCarrierId;
            }
            set
            {
                this.mCarrierId = value;
            }
        }

        public int? NumberOfPackages
        {
            get
            {
                return this.mNumberOfPackages;
            }
            set
            {
                this.mNumberOfPackages = value;
            }
        }

        public int OrderId
        {
            get
            {
                int num = 0;
                string[] strArray = this.mOrderIdLong.Split(new char[] { '-' });
                if (strArray.Length == 3)
                {
                    num = Convert.ToInt32(strArray[1]);
                }
                return num;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
        public string OrderIdLong
        {
            get
            {
                return this.mOrderIdLong;
            }
            set
            {
                this.mOrderIdLong = value;
            }
        }

        public int OrderSuffix
        {
            get
            {
                int num = 0;
                string[] strArray = this.mOrderIdLong.Split(new char[] { '-' });
                if (strArray.Length == 3)
                {
                    num = Convert.ToInt32(strArray[2]);
                }
                return num;
            }
        }

        public int? OrderUpdated
        {
            get
            {
                return this.mOrderUpdated;
            }
            set
            {
                this.mOrderUpdated = value;
            }
        }

        public DateTime? ShipDate
        {
            get
            {
                return this.mShipDate;
            }
            set
            {
                this.mShipDate = value;
            }
        }

        public string Status
        {
            get
            {
                return this.mStatus;
            }
            set
            {
                this.mStatus = value;
            }
        }

        public int? StatusCode
        {
            get
            {
                return this.mStatusCode;
            }
            set
            {
                this.mStatusCode = value;
            }
        }

        public int StoreId
        {
            get
            {
                int num = 0;
                string[] strArray = this.mOrderIdLong.Split(new char[] { '-' });
                if (strArray.Length == 3)
                {
                    num = Convert.ToInt32(strArray[0]);
                }
                return num;
            }
        }

        public string TrackingNo
        {
            get
            {
                return this.mTrackingNo;
            }
            set
            {
                this.mTrackingNo = value;
            }
        }
    }
}

