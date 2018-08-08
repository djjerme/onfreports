namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class SuperDepartmentInfo
    {
        private DepartmentInfo[] _departments;
        private string _name;
        private int? _superDeptId;

        public SuperDepartmentInfo()
        {
        }

        public SuperDepartmentInfo(string name, DepartmentInfo[] departments)
        {
            this._name = name;
            this._departments = departments;
        }

        public DepartmentInfo[] Departments
        {
            get
            {
                return this._departments;
            }
            set
            {
                this._departments = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public int? SuperDeptId
        {
            get
            {
                return this._superDeptId;
            }
            set
            {
                this._superDeptId = value;
            }
        }
    }
}

