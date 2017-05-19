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

public partial class OrdersAdd : System.Web.UI.Page
{
    public string strNav = "预订录入";
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
            txtNo.Value ="YD"+ DateTime.Now.ToString("yyMMddHHmmss");
            txtGetDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            txtUserName.Value = users.U_Name;
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
        ddlRt_Id.Items.Insert(0,new ListItem("==请选择==","0"));
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

            Orders model = new Orders();
            model.O_Budget =Convert.ToDateTime(txtBudget.Value);
            model.O_Name = txtName.Value.Trim();
            model.O_No = txtNo.Value.Trim();
            model.O_Time = DateTime.Now;
            model.O_Tel = txtTel.Value.Trim();
            model.U_Id = users.U_Id;
            model.Rt_Id = Convert.ToInt32(ddlRt_Id.SelectedValue);
            model.O_State = "未入住";
            if (OrdersBLL.AddOrders(model) > 0)
            {

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('OrdersManage.aspx');</script>");
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
        if (ddlRt_Id.SelectedValue != "0")
        {
            lblShow.Visible = true;
            List<Room> listCount = RoomBLL.AllData(" and Rt_Id =" + ddlRt_Id.SelectedValue + " and R_State='空'");
            if (listCount.Count != 0)
            {
                lblShow.Text = "仅剩" + +listCount.Count + "间空房";
                btnUpdate.Enabled = true;
            }
            else
            {
                lblShow.Text = "已无空房";
                btnUpdate.Enabled = false;
            }
        }
        else
        {
            btnUpdate.Enabled = true;
            lblShow.Visible = false;
        }
        
    }
}
