using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class OrdersDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddOrders(Orders OrdersModel)
        {
            string sql = string.Format("insert into  Orders (O_No,O_Name,O_Tel,O_Time,O_Budget,Rt_Id,U_Id,O_State )values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')", OrdersModel.O_No, OrdersModel.O_Name, OrdersModel.O_Tel, OrdersModel.O_Time, OrdersModel.O_Budget, OrdersModel.Rt_Id, OrdersModel.U_Id,OrdersModel.O_State);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateOrders(Orders OrdersModel)
        {
            string sql = string.Format(" UPDATE Orders  set O_No='{0}',O_Name='{1}',O_Tel='{2}',O_Time='{3}',O_Budget='{4}',Rt_Id={5},U_Id={6},O_State='{7}' where O_Id={8} ", OrdersModel.O_No, OrdersModel.O_Name, OrdersModel.O_Tel, OrdersModel.O_Time, OrdersModel.O_Budget, OrdersModel.Rt_Id, OrdersModel.U_Id, OrdersModel.O_State, OrdersModel.O_Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteOrders(int Id)
        {
            string sql = string.Format("delete from Orders where O_Id={0}", Id);
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
                sql = "select count(*) from Orders where 1=1 " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Orders";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Orders> PageSelectOrders(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Orders> list = new List<Orders>(); 
	    string sql = string.Format("SELECT top {0} * FROM Orders where O_Id not in( select top {1} O_Id from Orders where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Orders GetIdByOrders(int Id)
        {
            string sql = string.Format("SELECT * FROM Orders where O_Id={0} ",Id);
            Orders OrdersModel = new Orders();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                OrdersModel= GetMode(table);
            }
            return OrdersModel;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Orders> AllData(string NewWHere)
        {
            List<Orders> list = new List<Orders>();

             string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
               sql = "select * from Orders where 1=1 "+NewWHere;
            }
            else
            {
               sql = "select * from Orders";
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
        private static List<Orders> GetList(DataTable table)
        {
            List<Orders> list = new List<Orders>();
            foreach (DataRow row in table.Rows)
            {
                Orders OrdersModel = new Orders(); 
                OrdersModel.O_Id = Convert.ToInt32(row["O_Id"]); 
                OrdersModel.O_No = Convert.ToString(row["O_No"]); 
                OrdersModel.O_Name = Convert.ToString(row["O_Name"]); 
                OrdersModel.O_Tel = Convert.ToString(row["O_Tel"]); 
                OrdersModel.O_Time = Convert.ToDateTime(row["O_Time"]); 
                OrdersModel.O_Budget = Convert.ToDateTime(row["O_Budget"]); 
                OrdersModel.Rt_Id = Convert.ToInt32(row["Rt_Id"]); 
                OrdersModel.U_Id = Convert.ToInt32(row["U_Id"]);
                OrdersModel.O_State = Convert.ToString(row["O_State"]); 
                list.Add(OrdersModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Orders GetMode(DataTable table)
        {
            Orders OrdersModel = new Orders();
            foreach (DataRow row in table.Rows)
            {
                OrdersModel.O_Id = Convert.ToInt32(row["O_Id"]); 
                OrdersModel.O_No = Convert.ToString(row["O_No"]); 
                OrdersModel.O_Name = Convert.ToString(row["O_Name"]); 
                OrdersModel.O_Tel = Convert.ToString(row["O_Tel"]); 
                OrdersModel.O_Time = Convert.ToDateTime(row["O_Time"]); 
                OrdersModel.O_Budget = Convert.ToDateTime(row["O_Budget"]); 
                OrdersModel.Rt_Id = Convert.ToInt32(row["Rt_Id"]); 
                OrdersModel.U_Id = Convert.ToInt32(row["U_Id"]);
                OrdersModel.O_State = Convert.ToString(row["O_State"]); 

            }
            return OrdersModel;
        }
    }
}