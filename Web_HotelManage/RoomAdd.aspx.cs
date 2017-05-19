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

public partial class RoomAdd : System.Web.UI.Page
{
    public string strNav = "添加客房";
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
            if (Request.QueryString["id"] != null)
            {

                Room model = RoomBLL.GetIdByRoom(Convert.ToInt32(Request.QueryString["id"]));
                if (model != null && model.Rt_Id != 0)
                {
                    txtNo.Value = model.R_No.Trim();
                    txtTel.Value = model.R_Tel.Trim();
                    ddlRt_Id.SelectedValue = model.Rt_Id.ToString();
                    ddlState.SelectedValue = model.R_State;

                }
                strNav = "修改客房";
                btnUpdate.Text = "修改";

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

            Room model = new Room();
            model.R_No = txtNo.Value.Trim();
            model.R_State =ddlState.SelectedValue;
            model.R_Tel = txtTel.Value.Trim();
            model.Rt_Id = Convert.ToInt32(ddlRt_Id.SelectedValue);
            if (RoomBLL.AddRoom(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('RoomManage.aspx');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
                return;
            }


        }
        else
        {

            Room model = RoomBLL.GetIdByRoom(Convert.ToInt32(Request.QueryString["id"]));
            model.R_No = txtNo.Value.Trim();
            model.R_State = ddlState.SelectedValue;
            model.R_Tel = txtTel.Value.Trim();
            model.Rt_Id = Convert.ToInt32(ddlRt_Id.SelectedValue);

            if (RoomBLL.UpdateRoom(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('RoomManage.aspx');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
                return;
            }

        }
    }
}
