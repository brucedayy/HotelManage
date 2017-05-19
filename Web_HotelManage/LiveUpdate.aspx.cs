using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Model;
using BLL;
using System.Collections.Generic;

public partial class LiveUpdate : System.Web.UI.Page
{
    public string strNav = "结算退房";
    public Users users = new Users();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Users"] != null)
        {
            users = (Users)Session["Users"];
        }
        else
        {
            users = null;
            Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
        }
        if (!IsPostBack)
        {

            txtUserName.Value = users.U_Name.Trim();
            if (Request.QueryString["id"] != null)
            {
                Live model = LiveBLL.GetIdByLive(Convert.ToInt32(Request.QueryString["id"]));
               
                txtTime.Value = model.L_Time.ToString("yyyy-MM-dd");
                if (model != null && model.L_Id != 0)
                {
                    txtNo.Value = model.L_No.Trim();
                    txtL_Id.Value = model.L_Id.ToString();
                }
            }
            
        }
    }

  






    /// <summary>
    /// 添加，修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (btnUpdate.Text == "结算")
        {

            Live model = LiveBLL.GetIdByLive(Convert.ToInt32(Request.QueryString["id"]));
            model.L_OutTime = Convert.ToDateTime(txtOutTime.Value.Trim());
            model.L_Pay = Convert.ToDecimal(txtPay.Value.Trim());
            model.L_State = "已结算";
            model.L_Total = model.L_Deposit + model.L_Pay;//总消费金额=入住定金+欠付金额
            model.U_Id = users.U_Id;
           
            if (LiveBLL.UpdateLive(model) > 0)
            {
                Room room = RoomBLL.GetIdByRoom(model.R_Id);
                room.R_State = "空";
                RoomBLL.UpdateRoom(room);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('结算成功！');window.location.replace('LiveSettlement.aspx');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('结算失败！');</script>");
                return;
            }


        }
    }
  
}
