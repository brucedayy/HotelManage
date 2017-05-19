using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RoomTypeDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddRoomType(RoomType RoomTypeModel)
        {
            string sql = string.Format("insert into  RoomType (Rt_Name,Rt_Price,Rt_Note )values('{0}',{1},'{2}')",RoomTypeModel.Rt_Name,RoomTypeModel.Rt_Price,RoomTypeModel.Rt_Note);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateRoomType(RoomType RoomTypeModel)
        {
            string sql = string.Format(" UPDATE RoomType  set Rt_Name='{0}',Rt_Price={1},Rt_Note='{2}' where Rt_Id={3} ",RoomTypeModel.Rt_Name,RoomTypeModel.Rt_Price,RoomTypeModel.Rt_Note  ,RoomTypeModel.Rt_Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteRoomType(int Id)
        {
            string sql = string.Format("delete from RoomType where Rt_Id={0}", Id);
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
                sql = "select count(*) from RoomType where 1=1 " + NewWHere;
            }
            else
            {
                sql = "select count(*) from RoomType";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<RoomType> PageSelectRoomType(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<RoomType> list = new List<RoomType>(); 
	    string sql = string.Format("SELECT top {0} * FROM RoomType where Rt_Id not in( select top {1} Rt_Id from RoomType where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static RoomType GetIdByRoomType(int Id)
        {
            string sql = string.Format("SELECT * FROM RoomType where Rt_Id={0} ",Id);
            RoomType RoomTypeModel = new RoomType();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                RoomTypeModel= GetMode(table);
            }
            return RoomTypeModel;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<RoomType> AllData(string NewWHere)
        {
            List<RoomType> list = new List<RoomType>();

             string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
               sql = "select * from RoomType where 1=1 "+NewWHere;
            }
            else
            {
               sql = "select * from RoomType";
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
        private static List<RoomType> GetList(DataTable table)
        {
            List<RoomType> list = new List<RoomType>();
            foreach (DataRow row in table.Rows)
            {
                RoomType RoomTypeModel = new RoomType(); 
                RoomTypeModel.Rt_Id = Convert.ToInt32(row["Rt_Id"]); 
                RoomTypeModel.Rt_Name = Convert.ToString(row["Rt_Name"]); 
                RoomTypeModel.Rt_Price = Convert.ToDecimal(row["Rt_Price"]); 
                RoomTypeModel.Rt_Note = Convert.ToString(row["Rt_Note"]); 
                list.Add(RoomTypeModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static RoomType GetMode(DataTable table)
        {
            RoomType RoomTypeModel = new RoomType();
            foreach (DataRow row in table.Rows)
            {
                RoomTypeModel.Rt_Id = Convert.ToInt32(row["Rt_Id"]); 
                RoomTypeModel.Rt_Name = Convert.ToString(row["Rt_Name"]); 
                RoomTypeModel.Rt_Price = Convert.ToDecimal(row["Rt_Price"]); 
                RoomTypeModel.Rt_Note = Convert.ToString(row["Rt_Note"]); 

            }
            return RoomTypeModel;
        }
    }
}