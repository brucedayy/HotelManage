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
    public string strNav = "添加用户";
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
         
            if (Request.QueryString["id"] != null)
            {

                Users model = UsersBLL.GetIdByUsers(Convert.ToInt32(Request.QueryString["id"]));
                if (model != null && model.U_Id != 0)
                {
                    txtName.Value = model.U_Name.Trim();
                    txtPwd.Value = model.U_Pwd.Trim();
                    txtRealName.Value = model.U_RealName.Trim();
                    ddlType.SelectedValue = model.U_Type.Trim();
                    ddlSex.SelectedValue = model.U_Sex.Trim();
                }
                strNav = "修改用户";
                btnUpdate.Text = "修改";

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

            Users model = new Users();
            model.U_Name = txtName.Value.Trim();
            model.U_Pwd = txtPwd.Value.Trim();
            model.U_RealName = txtRealName.Value.Trim();
            model.U_Sex = ddlSex.SelectedValue;
            model.U_Type = ddlType.SelectedValue;

            if (!UsersBLL.IsTrue(model.U_Name))
            {
                if (UsersBLL.AddUsers(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('UsersManage.aspx');</script>");
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该账号已存在！');</script>");
                return;
            }


        }
        else
        {

            Users model = UsersBLL.GetIdByUsers(Convert.ToInt32(Request.QueryString["id"]));
            model.U_Name = txtName.Value.Trim();
            model.U_Pwd = txtPwd.Value.Trim();
            model.U_RealName = txtRealName.Value.Trim();
            model.U_Sex = ddlSex.SelectedValue;
            model.U_Type = ddlType.SelectedValue;

            if (!UsersBLL.IsTrue(model.U_Name, model.U_Id))
            {
                if (UsersBLL.UpdateUsers(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('UsersManage.aspx');</script>");
                    return;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
                    return;
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该账号已存在！');</script>");
                return;
            }

        }
    }
}
