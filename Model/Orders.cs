using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Orders
    {
        public Orders() { } //无参构造函数


        #region Model 
        private int _O_Id;
        private string _O_No;
        private string _O_Name;
        private string _O_Tel;
        private DateTime _O_Time;
        private DateTime _O_Budget;
        private int _Rt_Id;
        private int _U_Id;
        private string _O_State;

        /// <summary>
        /// 
        /// </summary>
        public int O_Id
        {
            set { _O_Id = value; }
            get { return _O_Id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string O_No
        {
            set { _O_No = value; }
            get { return _O_No; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string O_Name
        {
            set { _O_Name = value; }
            get { return _O_Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string O_Tel
        {
            set { _O_Tel = value; }
            get { return _O_Tel; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime O_Time
        {
            set { _O_Time = value; }
            get { return _O_Time; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime O_Budget
        {
            set { _O_Budget = value; }
            get { return _O_Budget; }
        }

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
        public int U_Id
        {
            set { _U_Id = value; }
            get { return _U_Id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string O_State
        {
            set { _O_State = value; }
            get { return _O_State; }
        }

        #endregion 
    }
}