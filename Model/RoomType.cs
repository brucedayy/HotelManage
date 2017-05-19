using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class RoomType
    {
        public RoomType() { } //无参构造函数


        #region Model 
        private int _Rt_Id;
        private string _Rt_Name;
        private decimal _Rt_Price;
        private string _Rt_Note;

        /// <summary>
        /// 
        /// </summary>
        public int Rt_Id
        {
            set { _Rt_Id = value; }
            get { return _Rt_Id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Rt_Name
        {
            set { _Rt_Name = value; }
            get { return _Rt_Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Rt_Price
        {
            set { _Rt_Price = value; }
            get { return _Rt_Price; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Rt_Note
        {
            set { _Rt_Note = value; }
            get { return _Rt_Note; }
        }

        #endregion 
    }
}