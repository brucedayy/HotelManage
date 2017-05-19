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

public partial class ConsumptionAdd : System.Web.UI.Page
{
    public string strNav = "消费登记";
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
                Live live = LiveBLL.GetIdByLive(Convert.ToInt32(Request.QueryString["id"]));
                if (live != null && live.L_Id != 0)
                {
                    txtNo.Value = live.L_No.Trim();
                    RpNews.DataSource = ConsumptionBLL.AllData(" and L_Id=" + live.L_Id + " order by C_Time desc");
                    RpNews.DataBind();
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
        if (btnUpdate.Text == "添加")
        {

            Consumption model = new Consumption();
            model.C_Name = txtName.Value.Trim();
            model.C_Price = Convert.ToDecimal(txtPrice.Value.Trim());
            model.C_Time = Convert.ToDateTime(txtTime.Value.Trim());
            Live live = LiveBLL.GetIdByLive(Convert.ToInt32(Request.QueryString["id"]));
            model.L_Id = live.L_Id;
            model.U_Id = users.U_Id;

            if (ConsumptionBLL.AddConsumption(model) > 0)
            {

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('ConsumptionAdd.aspx?id=" + Request.QueryString["id"] + "');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
                return;
            }


        }
    }

    //删除
    protected void ibDel_ItemDeleting(object sender, EventArgs e)
    {
        try
        {

            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            ConsumptionBLL.DeleteConsumption(Id);

            Response.Write("<script>alert('删除成功！');window.location.replace('ConsumptionAdd.aspx?id=" + Request.QueryString["id"] + "');</script>");
        }
        catch
        {
            Response.Write("<script>alert('删除失败！');</script>");
        }
    }
   
}
