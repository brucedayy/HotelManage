<%@ WebHandler Language="C#" Class="GetDue" %>

using System;
using System.Web;
using Model;
using BLL;

public class GetDue : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.QueryString["L_Id"] != null && context.Request.QueryString["L_OutTime"] != null)
       {
            int L_Id = Convert.ToInt32(context.Request.QueryString["L_Id"].ToString().Trim());
             DateTime L_OutTime = Convert.ToDateTime(context.Request.QueryString["L_OutTime"].ToString().Trim());
            Live live = LiveBLL.GetIdByLive(L_Id);
           

            TimeSpan ts = L_OutTime - live.L_Time;
            int iDays = ts.Days;
            RoomType rt = RoomTypeBLL.GetIdByRoomType(RoomBLL.GetIdByRoom(live.R_Id).Rt_Id);
            decimal decTotal = rt.Rt_Price * Convert.ToDecimal(iDays);//单价*天数
            decimal decConsumption = GetSum(L_Id);//消费总额
            decimal decPoor=0;
            
            if (live.L_Deposit > (decTotal + decConsumption))
            {
                decPoor = live.L_Deposit - (decTotal + decConsumption);
                decPoor = -decPoor;
            }
            else if (live.L_Deposit < (decTotal + decConsumption))
            {
                decPoor = (decTotal + decConsumption) - live.L_Deposit;
            }
            else
            {
                decPoor = 0;
            }
                context.Response.Write(decPoor.ToString());
            
       }
    }

    /// <summary>
    /// 消费累计
    /// </summary>
    /// <param name="L_Id"></param>
    /// <returns></returns>
    public decimal GetSum(object L_Id)
    {
        decimal price = 0;
        decimal i = ConsumptionBLL.ConsumptionSum(Convert.ToInt32(L_Id));
        if (i != 0)
        {
            price = i;
        }
        return price;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}