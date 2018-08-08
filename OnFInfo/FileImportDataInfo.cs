namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class FileImportDataInfo
    {
        private string mCustomerOrderNo;
        private int? mDataRowNo;
        private string mExternalId;
        private string mExternalOrderFlag;
        private string mFailureCode;
        private string mFailureReason;
        private int? mFileImportId;
        private int? mFileImportRowId;
        private string mFirstName;
        private DateTime? mInsertDate;
        private string mLastName;
        private string mLineItemId;
        private int? mLineItemNo;
        private int? mOrderId;
        private int? mOrderSuffix;
        private bool? mProcessedFlag;
        private string mStatus;
        private int? mStoreId;

        public FileImportDataInfo()
        {
        }

        public FileImportDataInfo(int? fileimportrowid, int? storeid, int? fileimportid, int? datarowno, string externalid, string customerorderno, string firstname, string lastname, int? lineitemno, string lineitemid, int? orderid, int? ordersuffix, string status, string failurecode, string failurereason, bool? processedflag, string externalorderflag, DateTime? insertdate)
        {
            this.mFileImportRowId = fileimportrowid;
            this.mStoreId = storeid;
            this.mFileImportId = fileimportid;
            this.mDataRowNo = datarowno;
            this.mExternalId = externalid;
            this.mCustomerOrderNo = customerorderno;
            this.mFirstName = firstname;
            this.mLastName = lastname;
            this.mLineItemNo = lineitemno;
            this.mLineItemId = lineitemid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mStatus = status;
            this.mFailureCode = failurecode;
            this.mFailureReason = failurereason;
            this.mProcessedFlag = processedflag;
            this.mExternalOrderFlag = externalorderflag;
            this.mInsertDate = insertdate;
        }

        public string CustomerOrderNo
        {
            get
            {
                return this.mCustomerOrderNo;
            }
            set
            {
                this.mCustomerOrderNo = value;
            }
        }

        public int? DataRowNo
        {
            get
            {
                return this.mDataRowNo;
            }
            set
            {
                this.mDataRowNo = value;
            }
        }

        public string ExternalId
        {
            get
            {
                return this.mExternalId;
            }
            set
            {
                this.mExternalId = value;
            }
        }

        public string ExternalOrderFlag
        {
            get
            {
                return this.mExternalOrderFlag;
            }
            set
            {
                this.mExternalOrderFlag = value;
            }
        }

        public string FailureCode
        {
            get
            {
                return this.mFailureCode;
            }
            set
            {
                this.mFailureCode = value;
            }
        }

        public string FailureReason
        {
            get
            {
                return this.mFailureReason;
            }
            set
            {
                this.mFailureReason = value;
            }
        }

        public int? FileImportId
        {
            get
            {
                return this.mFileImportId;
            }
            set
            {
                this.mFileImportId = value;
            }
        }

        public int? FileImportRowId
        {
            get
            {
                return this.mFileImportRowId;
            }
            set
            {
                this.mFileImportRowId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.mFirstName;
            }
            set
            {
                this.mFirstName = value;
            }
        }

        public DateTime? InsertDate
        {
            get
            {
                return this.mInsertDate;
            }
            set
            {
                this.mInsertDate = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.mLastName;
            }
            set
            {
                this.mLastName = value;
            }
        }

        public string LineItemId
        {
            get
            {
                return this.mLineItemId;
            }
            set
            {
                this.mLineItemId = value;
            }
        }

        public int? LineItemNo
        {
            get
            {
                return this.mLineItemNo;
            }
            set
            {
                this.mLineItemNo = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return this.mOrderId;
            }
            set
            {
                this.mOrderId = value;
            }
        }

        public int? OrderSuffix
        {
            get
            {
                return this.mOrderSuffix;
            }
            set
            {
                this.mOrderSuffix = value;
            }
        }

        public bool? ProcessedFlag
        {
            get
            {
                return this.mProcessedFlag;
            }
            set
            {
                this.mProcessedFlag = value;
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

        public int? StoreId
        {
            get
            {
                return this.mStoreId;
            }
            set
            {
                this.mStoreId = value;
            }
        }
    }
}

