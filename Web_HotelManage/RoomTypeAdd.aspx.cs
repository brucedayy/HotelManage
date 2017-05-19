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

public partial class RoomTypeAdd : System.Web.UI.Page
{
    public string strNav = "添加客房类型";
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

                RoomType model = RoomTypeBLL.GetIdByRoomType(Convert.ToInt32(Request.QueryString["id"]));
                if (model != null && model.Rt_Id != 0)
                {

                    txtName.Value = model.Rt_Name.Trim();
                    txtPrice.Value = model.Rt_Price.ToString().Trim();
                    txtNote.Value = model.Rt_Note.Trim();

                }
                strNav = "修改客房类型";
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

            RoomType model = new RoomType();
            model.Rt_Name = txtName.Value.Trim();
            model.Rt_Price = Convert.ToDecimal(txtPrice.Value.Trim());
            model.Rt_Note = txtNote.Value.Trim();

            if (RoomTypeBLL.AddRoomType(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('RoomTypeManage.aspx');</script>");
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

            RoomType model = RoomTypeBLL.GetIdByRoomType(Convert.ToInt32(Request.QueryString["id"]));
            model.Rt_Name = txtName.Value.Trim();
            model.Rt_Price = Convert.ToDecimal(txtPrice.Value.Trim());
            model.Rt_Note = txtNote.Value.Trim();


            if (RoomTypeBLL.UpdateRoomType(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('RoomTypeManage.aspx');</script>");
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
