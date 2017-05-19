using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ConsumptionDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddConsumption(Consumption ConsumptionModel)
        {
            string sql = string.Format("insert into  Consumption (C_Name,C_Price,C_Time,L_Id,U_Id )values('{0}',{1},'{2}',{3},{4})",ConsumptionModel.C_Name,ConsumptionModel.C_Price,ConsumptionModel.C_Time,ConsumptionModel.L_Id,ConsumptionModel.U_Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateConsumption(Consumption ConsumptionModel)
        {
            string sql = string.Format(" UPDATE Consumption  set C_Name='{0}',C_Price={1},C_Time='{2}',L_Id={3},U_Id={4} where C_Id={5} ",ConsumptionModel.C_Name,ConsumptionModel.C_Price,ConsumptionModel.C_Time,ConsumptionModel.L_Id,ConsumptionModel.U_Id  ,ConsumptionModel.C_Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteConsumption(int Id)
        {
            string sql = string.Format("delete from Consumption where C_Id={0}", Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 消费累计
        /// </summary>
        /// <param name="L_Id"></param>
        /// <returns></returns>
        public static decimal ConsumptionSum(int L_Id)
        {
            string sql = "select sum(C_Price) as C_Price from Consumption where L_Id=" + L_Id;

            Consumption ConsumptionModel = new Consumption();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                ConsumptionModel = GetMode2(table);
            }
            return ConsumptionModel.C_Price;
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
                sql = "select count(*) from Consumption where 1=1 " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Consumption";

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
                sql = "select count(*) from Live INNER JOIN Consumption ON Live.L_Id = Consumption.L_Id where 1=1 " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Live INNER JOIN Consumption ON Live.L_Id = Consumption.L_Id";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Consumption> PageSelectConsumption(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Consumption> list = new List<Consumption>(); 
	    string sql = string.Format("SELECT top {0} * FROM Consumption where C_Id not in( select top {1} C_Id from Consumption where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static DataTable PageSelectConsumption2(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            string sql = string.Format("SELECT top {0} * FROM Live INNER JOIN Consumption ON Live.L_Id = Consumption.L_Id where C_Id not in( select top {1} C_Id from Live INNER JOIN Consumption ON Live.L_Id = Consumption.L_Id where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ", pageSize, pageSize * pageIndex, WhereSrc, PXzd, PXType);
            return DBHelper.GetDataSet(sql);
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Consumption GetIdByConsumption(int Id)
        {
            string sql = string.Format("SELECT * FROM Consumption where C_Id={0} ",Id);
            Consumption ConsumptionModel = new Consumption();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                ConsumptionModel= GetMode(table);
            }
            return ConsumptionModel;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Consumption> AllData(string NewWHere)
        {
            List<Consumption> list = new List<Consumption>();

             string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
               sql = "select * from Consumption where 1=1 "+NewWHere;
            }
            else
            {
               sql = "select * from Consumption";
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
        private static List<Consumption> GetList(DataTable table)
        {
            List<Consumption> list = new List<Consumption>();
            foreach (DataRow row in table.Rows)
            {
                Consumption ConsumptionModel = new Consumption(); 
                ConsumptionModel.C_Id = Convert.ToInt32(row["C_Id"]); 
                ConsumptionModel.C_Name = Convert.ToString(row["C_Name"]); 
                ConsumptionModel.C_Price = Convert.ToDecimal(row["C_Price"]); 
                ConsumptionModel.C_Time = Convert.ToDateTime(row["C_Time"]); 
                ConsumptionModel.L_Id = Convert.ToInt32(row["L_Id"]); 
                ConsumptionModel.U_Id = Convert.ToInt32(row["U_Id"]); 
                list.Add(ConsumptionModel);

            }
            return list;
        }

        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Consumption GetMode2(DataTable table)
        {
            Consumption ConsumptionModel = new Consumption();
            foreach (DataRow row in table.Rows)
            {
                if (!DBNull.Value.Equals(row["C_Price"]))
                {
                    ConsumptionModel.C_Price = Convert.ToDecimal(row["C_Price"]);
                }
                else
                {
                    ConsumptionModel.C_Price = 0;
                }

            }
            return ConsumptionModel;
        }

        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Consumption GetMode(DataTable table)
        {
            Consumption ConsumptionModel = new Consumption();
            foreach (DataRow row in table.Rows)
            {
                ConsumptionModel.C_Id = Convert.ToInt32(row["C_Id"]); 
                ConsumptionModel.C_Name = Convert.ToString(row["C_Name"]); 
                ConsumptionModel.C_Price = Convert.ToDecimal(row["C_Price"]); 
                ConsumptionModel.C_Time = Convert.ToDateTime(row["C_Time"]); 
                ConsumptionModel.L_Id = Convert.ToInt32(row["L_Id"]); 
                ConsumptionModel.U_Id = Convert.ToInt32(row["U_Id"]); 

            }
            return ConsumptionModel;
        }
    }
}