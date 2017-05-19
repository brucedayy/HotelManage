using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class RoomBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddRoom(Room RoomModel)
        {
            return RoomDAL.AddRoom(RoomModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteRoom(int Id)
        {
            return RoomDAL.DeleteRoom(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Room> PageSelectRoom(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return RoomDAL.PageSelectRoom(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateRoom(Room RoomModel)
        {
            return RoomDAL.UpdateRoom(RoomModel);
        }
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Room> AllData(string NewWHere)
        {
            return RoomDAL.AllData(NewWHere);
        }
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return RoomDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Room GetIdByRoom(int Id)
        {
            return RoomDAL.GetIdByRoom(Id);
        }
    }
}