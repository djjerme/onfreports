namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class StoreFramelessConfigInfo
    {
        private string _customPath;
        private string _headerLogo;
        private int? _id;
        private int? _productsPerPage;
        private int? _storeId;
        private string _themeName;

        public StoreFramelessConfigInfo()
        {
        }

        public StoreFramelessConfigInfo(int? id, int? storeId, string headerLogo, int? productsPerPage, string customPath, string themeName)
        {
            this.Id = id;
            this.StoreId = storeId;
            this.HeaderLogo = headerLogo;
            this.ProductsPerPage = productsPerPage;
            this.CustomPath = customPath;
            this.ThemeName = themeName;
        }

        public string CustomPath
        {
            get
            {
                return this._customPath;
            }
            set
            {
                this._customPath = value;
            }
        }

        public string HeaderLogo
        {
            get
            {
                return this._headerLogo;
            }
            set
            {
                this._headerLogo = value;
            }
        }

        public int? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public int? ProductsPerPage
        {
            get
            {
                return this._productsPerPage;
            }
            set
            {
                this._productsPerPage = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this._storeId;
            }
            set
            {
                this._storeId = value;
            }
        }

        public string ThemeName
        {
            get
            {
                return this._themeName;
            }
            set
            {
                this._themeName = value;
            }
        }
    }
}

