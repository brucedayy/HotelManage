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

public partial class UsersUpdate : System.Web.UI.Page
{
    public string strNav = "修改资料";
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


            Users model = UsersBLL.GetIdByUsers(users.U_Id);
                if (model != null && model.U_Id != 0)
                {
                    txtName.Value = model.U_Name.Trim();
                    txtRealName.Value = model.U_RealName.Trim();
                    if (model.U_Sex == "男")
                    {
                        rdbMan.Checked = true;
                    }
                    else
                    {
                        rdbWoman.Checked = true;
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
        if (btnUpdate.Text == "修改")
        {

            Users model = UsersBLL.GetIdByUsers(users.U_Id);
            model.U_Name = txtName.Value.Trim();
            model.U_RealName = txtRealName.Value.Trim();
            if(rdbMan.Checked)
            {
                model.U_Sex = "男";
            }
            else
            {
                model.U_Sex = "女";
            }

            if (UsersBLL.UpdateUsers(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');location=location;</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
                return;
            }


        }
      
    }
}
