using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Users
    {
        public Users() { } //无参构造函数


        #region Model 
        private int _U_Id;
        private string _U_Name;
        private string _U_Pwd;
        private string _U_RealName;
        private string _U_Sex;
        private string _U_Type;

        /// <summary>
        /// 
        /// </summary>
        public int U_Id
        {
            set { _U_Id = value; }
            get { return _U_Id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string U_Name
        {
            set { _U_Name = value; }
            get { return _U_Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string U_Pwd
        {
            set { _U_Pwd = value; }
            get { return _U_Pwd; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string U_RealName
        {
            set { _U_RealName = value; }
            get { return _U_RealName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string U_Sex
        {
            set { _U_Sex = value; }
            get { return _U_Sex; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string U_Type
        {
            set { _U_Type = value; }
            get { return _U_Type; }
        }

        #endregion 
    }
}