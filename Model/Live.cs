using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Live
    {
        public Live() { } //无参构造函数


        #region Model 
        private int _L_Id;
        private string _L_No;
        private string _L_Name;
        private string _L_IdCard;
        private string _L_Tel;
        private DateTime _L_Time;
        private DateTime _L_OutTime;
        private decimal _L_Deposit;
        private int _R_Id;
        private decimal _L_Pay;
        private decimal _L_Total;
        private string _L_State;
        private int _U_Id;

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
        public string L_No
        {
            set { _L_No = value; }
            get { return _L_No; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string L_Name
        {
            set { _L_Name = value; }
            get { return _L_Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string L_IdCard
        {
            set { _L_IdCard = value; }
            get { return _L_IdCard; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string L_Tel
        {
            set { _L_Tel = value; }
            get { return _L_Tel; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime L_Time
        {
            set { _L_Time = value; }
            get { return _L_Time; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime L_OutTime
        {
            set { _L_OutTime = value; }
            get { return _L_OutTime; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal L_Deposit
        {
            set { _L_Deposit = value; }
            get { return _L_Deposit; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int R_Id
        {
            set { _R_Id = value; }
            get { return _R_Id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal L_Pay
        {
            set { _L_Pay = value; }
            get { return _L_Pay; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal L_Total
        {
            set { _L_Total = value; }
            get { return _L_Total; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string L_State
        {
            set { _L_State = value; }
            get { return _L_State; }
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