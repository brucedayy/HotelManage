using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Consumption
    {
        public Consumption() { } //无参构造函数


        #region Model 
        private int _C_Id;
        private string _C_Name;
        private decimal _C_Price;
        private DateTime _C_Time;
        private int _L_Id;
        private int _U_Id;

        /// <summary>
        /// 
        /// </summary>
        public int C_Id
        {
            set { _C_Id = value; }
            get { return _C_Id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string C_Name
        {
            set { _C_Name = value; }
            get { return _C_Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal C_Price
        {
            set { _C_Price = value; }
            get { return _C_Price; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime C_Time
        {
            set { _C_Time = value; }
            get { return _C_Time; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int L_Id
        {
            set { _L_Id = value; }
            get { return _L_Id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int U_Id
        {
            set { _U_Id = value; }
            get { return _U_Id; }
        }

        #endregion 
    }
}