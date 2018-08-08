namespace PBA.OnfInfo
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace="PBA.OnfInfo")]
    public class PickListPrinterConfigInfo
    {
        private bool mModified;
        private bool mNewPrinter;
        private bool mPrinterActive;
        private int mPrinterID;
        private string mPrinterName;
        private string mPrinterPath;

        public PickListPrinterConfigInfo()
        {
            this.mPrinterID = -1;
            this.mPrinterName = "None";
            this.mPrinterPath = "None";
            this.mPrinterActive = false;
            this.mNewPrinter = false;
            this.mModified = false;
        }

        public PickListPrinterConfigInfo(int printerid, string printername, string printerpath, bool printeractive)
        {
            this.mPrinterID = printerid;
            this.mPrinterName = printername;
            this.mPrinterPath = printerpath;
            this.mPrinterActive = printeractive;
            this.mNewPrinter = false;
            this.mModified = false;
        }

        public bool Modified
        {
            get
            {
                return this.mModified;
            }
            set
            {
                this.mModified = value;
            }
        }

        public bool NewPrinter
        {
            get
            {
                return this.mNewPrinter;
            }
            set
            {
                this.mNewPrinter = value;
            }
        }

        public bool PrinterActive
        {
            get
            {
                return this.mPrinterActive;
            }
            set
            {
                this.mPrinterActive = value;
            }
        }

        [XmlElement(Namespace="PBA.OnfInfo")]
        public int PrinterID
        {
            get
            {
                return this.mPrinterID;
            }
            set
            {
                this.mPrinterID = value;
            }
        }

        public string PrinterName
        {
            get
            {
                return this.mPrinterName;
            }
            set
            {
                this.mPrinterName = value;
            }
        }

        public string PrinterPath
        {
            get
            {
                return this.mPrinterPath;
            }
            set
            {
                this.mPrinterPath = value;
            }
        }
    }
}

