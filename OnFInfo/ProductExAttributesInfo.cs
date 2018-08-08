namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class ProductExAttributesInfo
    {
        private string mContentSize;
        private string mContentURL;
        private string mIntranetURL;
        private string mPartnerCenterURL;
        private int? mProductId;
        private string mPublicURL;
        private int? mStoreId;

        public ProductExAttributesInfo()
        {
        }

        public ProductExAttributesInfo(int? storeid, int? productid, string contenturl, string contentsize, string publicurl)
        {
            this.mStoreId = storeid;
            this.mProductId = productid;
            this.mContentURL = contenturl;
            this.mContentSize = contentsize;
            this.mPublicURL = publicurl;
        }

        public ProductExAttributesInfo(int? storeid, int? productid, string contenturl, string contentsize, string publicurl, string partnercenterurl, string intraneturl)
        {
            this.mStoreId = storeid;
            this.mProductId = productid;
            this.mContentURL = contenturl;
            this.mContentSize = contentsize;
            this.mPublicURL = publicurl;
            this.mPartnerCenterURL = partnercenterurl;
            this.mIntranetURL = intraneturl;
        }

        public string ContentSize
        {
            get
            {
                return this.mContentSize;
            }
            set
            {
                this.mContentSize = value;
            }
        }

        public string ContentURL
        {
            get
            {
                return this.mContentURL;
            }
            set
            {
                this.mContentURL = value;
            }
        }

        public string IntranetURL
        {
            get
            {
                return this.mIntranetURL;
            }
            set
            {
                this.mIntranetURL = value;
            }
        }

        public string PartnerCenterURL
        {
            get
            {
                return this.mPartnerCenterURL;
            }
            set
            {
                this.mPartnerCenterURL = value;
            }
        }

        public int? ProductId
        {
            get
            {
                return this.mProductId;
            }
            set
            {
                this.mProductId = value;
            }
        }

        public string PublicURL
        {
            get
            {
                return this.mPublicURL;
            }
            set
            {
                this.mPublicURL = value;
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

