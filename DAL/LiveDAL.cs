using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class LiveDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddLive(Live LiveModel)
        {
            string sql = string.Format("insert into  Live (L_No,L_Name,L_IdCard,L_Tel,L_Time,L_OutTime,L_Deposit,R_Id,L_Pay,L_Total,L_State,U_Id )values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9},'{10}',{11})",LiveModel.L_No,LiveModel.L_Name,LiveModel.L_IdCard,LiveModel.L_Tel,LiveModel.L_Time,LiveModel.L_OutTime,LiveModel.L_Deposit,LiveModel.R_Id,LiveModel.L_Pay,LiveModel.L_Total,LiveModel.L_State,LiveModel.U_Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateLive(Live LiveModel)
        {
            string sql = string.Format(" UPDATE Live  set L_No='{0}',L_Name='{1}',L_IdCard='{2}',L_Tel='{3}',L_Time='{4}',L_OutTime='{5}',L_Deposit={6},R_Id={7},L_Pay={8},L_Total={9},L_State='{10}',U_Id={11} where L_Id={12} ",LiveModel.L_No,LiveModel.L_Name,LiveModel.L_IdCard,LiveModel.L_Tel,LiveModel.L_Time,LiveModel.L_OutTime,LiveModel.L_Deposit,LiveModel.R_Id,LiveModel.L_Pay,LiveModel.L_Total,LiveModel.L_State,LiveModel.U_Id  ,LiveModel.L_Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteLive(int Id)
        {
            string sql = string.Format("delete from Live where L_Id={0}", Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
                sql = "select count(*) from Live where 1=1 " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Live";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber2(string NewWHere)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
                sql = @"SELECT  count(*)
FROM       Room INNER JOIN Live ON Room.R_Id = Live.R_Id where 1=1 " + NewWHere;
            }
            else
            {
                sql = @"SELECT  count(*)
FROM       Room INNER JOIN Live ON Room.R_Id = Live.R_Id";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 总消费金额累计
        /// </summary>
        /// <param name="L_Id"></param>
        /// <returns></returns>
        public static decimal LiveSum(string strWhere)
        {
            string sql = "select sum(L_Total) as L_Total from Room INNER JOIN Live ON Room.R_Id = Live.R_Id where 1=1 ";

            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += strWhere;
            }

            Live LiveModel = new Live();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                LiveModel = GetMode2(table);
            }
            return LiveModel.L_Total;
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Live> PageSelectLive(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Live> list = new List<Live>(); 
	    string sql = string.Format("SELECT top {0} * FROM Live where L_Id not in( select top {1} L_Id from Live where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static DataTable  PageSelectLive2(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Live> list = new List<Live>();
            string sql = string.Format("SELECT top {0} * FROM Room INNER JOIN Live ON Room.R_Id = Live.R_Id where L_Id not in( select top {1} L_Id from Room INNER JOIN Live ON Room.R_Id = Live.R_Id where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ", pageSize, pageSize * pageIndex, WhereSrc, PXzd, PXType);
            return DBHelper.GetDataSet(sql);
        }


        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Live GetIdByLive(int Id)
        {
            string sql = string.Format("SELECT * FROM Live where L_Id={0} ",Id);
            Live LiveModel = new Live();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                LiveModel= GetMode(table);
            }
            return LiveModel;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Live> AllData(string NewWHere)
        {
            List<Live> list = new List<Live>();

             string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
               sql = "select * from Live where 1=1 "+NewWHere;
            }
            else
            {
               sql = "select * from Live";
            }
            using (DataTable table = DBHelper.GetDataSet(sql))
            {

                list = GetList(table);
            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static List<Live> GetList(DataTable table)
        {
            List<Live> list = new List<Live>();
            foreach (DataRow row in table.Rows)
            {
                Live LiveModel = new Live(); 
                LiveModel.L_Id = Convert.ToInt32(row["L_Id"]); 
                LiveModel.L_No = Convert.ToString(row["L_No"]); 
                LiveModel.L_Name = Convert.ToString(row["L_Name"]); 
                LiveModel.L_IdCard = Convert.ToString(row["L_IdCard"]); 
                LiveModel.L_Tel = Convert.ToString(row["L_Tel"]); 
                LiveModel.L_Time = Convert.ToDateTime(row["L_Time"]); 
                LiveModel.L_OutTime = Convert.ToDateTime(row["L_OutTime"]); 
                LiveModel.L_Deposit = Convert.ToDecimal(row["L_Deposit"]); 
                LiveModel.R_Id = Convert.ToInt32(row["R_Id"]); 
                LiveModel.L_Pay = Convert.ToDecimal(row["L_Pay"]); 
                LiveModel.L_Total = Convert.ToDecimal(row["L_Total"]); 
                LiveModel.L_State = Convert.ToString(row["L_State"]); 
                LiveModel.U_Id = Convert.ToInt32(row["U_Id"]); 
                list.Add(LiveModel);

            }
            return list;
        }

        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Live GetMode2(DataTable table)
        {
            Live LiveModel = new Live();
            foreach (DataRow row in table.Rows)
            {
                if (!DBNull.Value.Equals(row["L_Total"]))
                {
                    LiveModel.L_Total = Convert.ToDecimal(row["L_Total"]);
                }
                else
                {
                    LiveModel.L_Total = 0;
                }
              

            }
            return LiveModel;
        }


        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Live GetMode(DataTable table)
        {
            Live LiveModel = new Live();
            foreach (DataRow row in table.Rows)
            {
                LiveModel.L_Id = Convert.ToInt32(row["L_Id"]); 
                LiveModel.L_No = Convert.ToString(row["L_No"]); 
                LiveModel.L_Name = Convert.ToString(row["L_Name"]); 
                LiveModel.L_IdCard = Convert.ToString(row["L_IdCard"]); 
                LiveModel.L_Tel = Convert.ToString(row["L_Tel"]); 
                LiveModel.L_Time = Convert.ToDateTime(row["L_Time"]); 
                LiveModel.L_OutTime = Convert.ToDateTime(row["L_OutTime"]); 
                LiveModel.L_Deposit = Convert.ToDecimal(row["L_Deposit"]); 
                LiveModel.R_Id = Convert.ToInt32(row["R_Id"]); 
                LiveModel.L_Pay = Convert.ToDecimal(row["L_Pay"]); 
                LiveModel.L_Total = Convert.ToDecimal(row["L_Total"]); 
                LiveModel.L_State = Convert.ToString(row["L_State"]); 
                LiveModel.U_Id = Convert.ToInt32(row["U_Id"]); 

            }
            return LiveModel;
        }
    }
}