using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class LiveBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddLive(Live LiveModel)
        {
            return LiveDAL.AddLive(LiveModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteLive(int Id)
        {
            return LiveDAL.DeleteLive(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Live> PageSelectLive(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return LiveDAL.PageSelectLive(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        
        /// <summary>
        /// 分页 
        ///</summary> 
        public static DataTable PageSelectLive2(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return LiveDAL.PageSelectLive2(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateLive(Live LiveModel)
        {
            return LiveDAL.UpdateLive(LiveModel);
        }
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Live> AllData(string NewWHere)
        {
            return LiveDAL.AllData(NewWHere);
        }
        
        /// <summary>
        /// 总消费金额累计
        /// </summary>
        /// <param name="L_Id"></param>
        /// <returns></returns>
        public static decimal LiveSum(string strWhere)
        {
            return LiveDAL.LiveSum(strWhere);
        }
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return LiveDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber2(string NewWHere)
        {
            return LiveDAL.CountNumber2(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Live GetIdByLive(int Id)
        {
            return LiveDAL.GetIdByLive(Id);
        }
    }
}