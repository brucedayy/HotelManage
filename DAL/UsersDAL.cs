using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UsersDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddUsers(Users UsersModel)
        {
            string sql = string.Format("insert into  Users (U_Name,U_Pwd,U_RealName,U_Sex,U_Type )values('{0}','{1}','{2}','{3}','{4}')",UsersModel.U_Name,UsersModel.U_Pwd,UsersModel.U_RealName,UsersModel.U_Sex,UsersModel.U_Type);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateUsers(Users UsersModel)
        {
            string sql = string.Format(" UPDATE Users  set U_Name='{0}',U_Pwd='{1}',U_RealName='{2}',U_Sex='{3}',U_Type='{4}' where U_Id={5} ",UsersModel.U_Name,UsersModel.U_Pwd,UsersModel.U_RealName,UsersModel.U_Sex,UsersModel.U_Type  ,UsersModel.U_Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteUsers(int Id)
        {
            string sql = string.Format("delete from Users where U_Id={0}", Id);
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
                sql = "select count(*) from Users where 1=1 " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Users";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Users> PageSelectUsers(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Users> list = new List<Users>(); 
	    string sql = string.Format("SELECT top {0} * FROM Users where U_Id not in( select top {1} U_Id from Users where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Users GetIdByUsers(int Id)
        {
            string sql = string.Format("SELECT * FROM Users where U_Id={0} ",Id);
            Users UsersModel = new Users();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                UsersModel= GetMode(table);
            }
            return UsersModel;
        }

        /// <summary> 
        /// 根据用户名查询实体 
        ///</summary>
        public static Users GetNameByUsers(string name)
        {
            string sql = string.Format("SELECT * FROM Users  where U_Name collate Chinese_PRC_CS_AS_WS='{0}' ", name);
            Users UsersModel = new Users();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                UsersModel = GetMode(table);
            }
            return UsersModel;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Users> AllData(string NewWHere)
        {
            List<Users> list = new List<Users>();

             string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
               sql = "select * from Users where 1=1 "+NewWHere;
            }
            else
            {
               sql = "select * from Users";
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
        private static List<Users> GetList(DataTable table)
        {
            List<Users> list = new List<Users>();
            foreach (DataRow row in table.Rows)
            {
                Users UsersModel = new Users(); 
                UsersModel.U_Id = Convert.ToInt32(row["U_Id"]); 
                UsersModel.U_Name = Convert.ToString(row["U_Name"]); 
                UsersModel.U_Pwd = Convert.ToString(row["U_Pwd"]); 
                UsersModel.U_RealName = Convert.ToString(row["U_RealName"]); 
                UsersModel.U_Sex = Convert.ToString(row["U_Sex"]); 
                UsersModel.U_Type = Convert.ToString(row["U_Type"]); 
                list.Add(UsersModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Users GetMode(DataTable table)
        {
            Users UsersModel = new Users();
            foreach (DataRow row in table.Rows)
            {
                UsersModel.U_Id = Convert.ToInt32(row["U_Id"]); 
                UsersModel.U_Name = Convert.ToString(row["U_Name"]); 
                UsersModel.U_Pwd = Convert.ToString(row["U_Pwd"]); 
                UsersModel.U_RealName = Convert.ToString(row["U_RealName"]); 
                UsersModel.U_Sex = Convert.ToString(row["U_Sex"]); 
                UsersModel.U_Type = Convert.ToString(row["U_Type"]); 

            }
            return UsersModel;
        }
    }
}