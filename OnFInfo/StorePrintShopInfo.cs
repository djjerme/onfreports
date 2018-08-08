namespace PBA.OnfInfo
{
    using System;

    public class StorePrintShopInfo
    {
        private int? mPrintShopId;
        private int? mStoreId;
        private string mTranslationKey;

        public StorePrintShopInfo()
        {
        }

        public StorePrintShopInfo(int? storeid, string translationkey, int? printshopid)
        {
            this.mStoreId = storeid;
            this.mTranslationKey = translationkey;
            this.mPrintShopId = printshopid;
        }

        public int? PrintShopId
        {
            get
            {
                return this.mPrintShopId;
            }
            set
            {
                this.mPrintShopId = value;
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

        public string TranslationKey
        {
            get
            {
                return this.mTranslationKey;
            }
            set
            {
                this.mTranslationKey = value;
            }
        }
    }
}

