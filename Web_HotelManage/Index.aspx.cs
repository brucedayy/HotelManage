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

public partial class Index : System.Web.UI.Page
{
    public Users users = new Users();
   public  string strLeftUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Users"] != null)
        {
            users = (Users)Session["Users"];
            if (users.U_Type == "服务员")
            {
                strLeftUrl = "LeftServer.aspx";
            }
            else if (users.U_Type == "管理员")
            {
                strLeftUrl = "LeftAdmin.aspx";
            }
        }
        else
        {
            users = null;
            Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
        }

    }
}
