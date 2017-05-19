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

public partial class LiveAdd : System.Web.UI.Page
{
    public string strNav = "入住登记";
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
            BindType();
            txtNo.Value ="RZ"+ DateTime.Now.ToString("yyMMddHHmmss");
            txtGetDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            txtUserName.Value = users.U_Name.Trim();
            if (Request.QueryString["id"] != null)
            {
                Orders ord = OrdersBLL.GetIdByOrders(Convert.ToInt32(Request.QueryString["id"]));
                if (ord != null && ord.O_Id != 0)
                {
                    txtName.Value = ord.O_Name.Trim();
                    txtTel.Value = ord.O_Tel.Trim();
                    ddlRt_Id.SelectedValue = ord.Rt_Id.ToString().Trim();
                    
                    ddlR_Id.DataSource = RoomBLL.AllData(" and Rt_Id=" + ddlRt_Id.SelectedValue + " and R_State='空'");
                    ddlR_Id.DataTextField = "R_No";
                    ddlR_Id.DataValueField = "R_Id";
                    ddlR_Id.DataBind();

                    

                }
            }
            
        }
    }

    /// <summary>
    /// 绑定类型
    /// </summary>
    private void BindType()
    {
        ddlRt_Id.DataSource = RoomTypeBLL.AllData("");
        ddlRt_Id.DataTextField = "Rt_Name";
        ddlRt_Id.DataValueField = "Rt_Id";
        ddlRt_Id.DataBind();

        ddlR_Id.DataSource = RoomBLL.AllData(" and Rt_Id=" + ddlRt_Id.SelectedValue + " and R_State='空'");
        ddlR_Id.DataTextField = "R_No";
        ddlR_Id.DataValueField = "R_Id";
        ddlR_Id.DataBind(); 
    }






    /// <summary>
    /// 添加，修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (btnUpdate.Text == "添加")
        {

            Live model = new Live();
            model.L_Deposit = Convert.ToDecimal(txtDeposit.Value.Trim());
            model.L_IdCard = txtIdCard.Value.Trim();
            model.L_Name = txtName.Value.Trim();
            model.L_No = txtNo.Value.Trim();
            model.L_OutTime =Convert.ToDateTime("1900-01-01");
            model.L_Pay = 0;
            model.L_State = "未结算";
            model.L_Tel = txtTel.Value.Trim();
            model.L_Time = Convert.ToDateTime(txtTime.Value);
            model.L_Total = 0;
            model.R_Id = Convert.ToInt32( ddlR_Id.SelectedValue);
            model.U_Id = users.U_Id;
           
            if (LiveBLL.AddLive(model) > 0)
            {
                Room room = RoomBLL.GetIdByRoom(Convert.ToInt32(ddlR_Id.SelectedValue));
                room.R_State = "入住";
                RoomBLL.UpdateRoom(room);
                Orders ord = OrdersBLL.GetIdByOrders(Convert.ToInt32(Request.QueryString["id"]));
                ord.O_State = "已入住";
                OrdersBLL.UpdateOrders(ord);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('OrdersJoin.aspx');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
                return;
            }


        }
    }
    protected void ddlRt_Id_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlR_Id.DataSource = RoomBLL.AllData(" and Rt_Id=" + ddlRt_Id.SelectedValue + " and R_State='空'");
        ddlR_Id.DataTextField = "R_No";
        ddlR_Id.DataValueField = "R_Id";
        ddlR_Id.DataBind();
        if (ddlR_Id.Items.Count == 0)
        {
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }
       
    }
}
