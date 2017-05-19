using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class RoomTypeBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddRoomType(RoomType RoomTypeModel)
        {
            return RoomTypeDAL.AddRoomType(RoomTypeModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteRoomType(int Id)
        {
            return RoomTypeDAL.DeleteRoomType(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<RoomType> PageSelectRoomType(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return RoomTypeDAL.PageSelectRoomType(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateRoomType(RoomType RoomTypeModel)
        {
            return RoomTypeDAL.UpdateRoomType(RoomTypeModel);
        }
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<RoomType> AllData(string NewWHere)
        {
            return RoomTypeDAL.AllData(NewWHere);
        }
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return RoomTypeDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static RoomType GetIdByRoomType(int Id)
        {
            return RoomTypeDAL.GetIdByRoomType(Id);
        }
    }
}