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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Users users = new Users();

        if (UsersBLL.GetUsersLogin(this.txtUserName.Value.Trim(), this.txtPwd.Value.Trim(), out users))
            {
                Session["Users"] = users;
                Response.Redirect("Index.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名或者密码错误！');</script>");
                return;
            }
        
    }
}
