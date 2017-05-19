using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class OrdersBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddOrders(Orders OrdersModel)
        {
            return OrdersDAL.AddOrders(OrdersModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteOrders(int Id)
        {
            return OrdersDAL.DeleteOrders(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Orders> PageSelectOrders(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return OrdersDAL.PageSelectOrders(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateOrders(Orders OrdersModel)
        {
            return OrdersDAL.UpdateOrders(OrdersModel);
        }
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Orders> AllData(string NewWHere)
        {
            return OrdersDAL.AllData(NewWHere);
        }
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return OrdersDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Orders GetIdByOrders(int Id)
        {
            return OrdersDAL.GetIdByOrders(Id);
        }
    }
}