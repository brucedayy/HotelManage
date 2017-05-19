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

public partial class LiveManage : System.Web.UI.Page
{
    public string strWhere = "";
    public Users users = new Users();
    /// <summary>
    ///  加载绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            BindLoad();
            BindData("");
        }
    }

    /// <summary>
    /// 加载绑定
    /// </summary>
    public void BindLoad()
    {

        if (txtL_No.Value.Trim().Length != 0)
        {
            strWhere += " and L_No like '%"+txtL_No.Value.Trim()+"%'";
        }
        if (txtR_No.Value.Trim().Length != 0)
        {
            strWhere += " and R_No like '%" + txtR_No.Value.Trim() + "%'";
        }
        if (txtName.Value.Trim().Length != 0)
        {
            strWhere += " and L_Name like '%" + txtName.Value.Trim() + "%'";
        }
        if (txtTel.Value.Trim().Length != 0)
        {
            strWhere += " and L_Tel like '%" + txtTel.Value.Trim() + "%'";
        }
        if (txtIdCard.Value.Trim().Length != 0)
        {
            strWhere += " and L_IdCard like '%" + txtIdCard.Value.Trim() + "%'";
        }

        strWhere += " and L_State='未结算'";


        int DataCount = LiveBLL.CountNumber2(strWhere); //共多少条记录
        int hPageSize = (DataCount % Convert.ToInt32(HCount.Value)) != 0 ? DataCount / Convert.ToInt32(HCount.Value) + 1 : DataCount / Convert.ToInt32(HCount.Value);//共多少页
        HPageSize.Value = DataCount.ToString();
        HAllPage.Value = hPageSize.ToString();
        this.RpNews.DataSource = LiveBLL.PageSelectLive2(Convert.ToInt32(HCount.Value), Convert.ToInt32(HNowPage.Value), strWhere, "L_Time", "asc");
        this.RpNews.DataBind();
    }


    //首页
    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    //上一页
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    //下一页
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    //尾页
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
    //分页查找
    private void BindData(string strClass)
    {
        int nowPage = 1;

        switch (strClass)
        {
            case "next":
                nowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                nowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                nowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                nowPage = 1;
                break;
        }

        if (Convert.ToInt32(HAllPage.Value) <= 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (nowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (nowPage == Convert.ToInt32(HAllPage.Value))
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }


        if (txtL_No.Value.Trim().Length != 0)
        {
            strWhere += " and L_No like '%" + txtL_No.Value.Trim() + "%'";
        }
        if (txtR_No.Value.Trim().Length != 0)
        {
            strWhere += " and R_No like '%" + txtR_No.Value.Trim() + "%'";
        }
        if (txtName.Value.Trim().Length != 0)
        {
            strWhere += " and L_Name like '%" + txtName.Value.Trim() + "%'";
        }
        if (txtTel.Value.Trim().Length != 0)
        {
            strWhere += " and L_Tel like '%" + txtTel.Value.Trim() + "%'";
        }
        if (txtIdCard.Value.Trim().Length != 0)
        {
            strWhere += " and L_IdCard like '%" + txtIdCard.Value.Trim() + "%'";
        }

        strWhere += " and L_State='未结算'";

        this.RpNews.DataSource = LiveBLL.PageSelectLive2(Convert.ToInt32(HCount.Value), nowPage, strWhere, "L_Time", "asc");
        this.RpNews.DataBind();
        HNowPage.Value = nowPage.ToString();
        PageMes.Text = string.Format("每页{0}条 第{1}页/共{2}页 共{3}条", HCount.Value, nowPage.ToString(), HAllPage.Value, HPageSize.Value);

    }

    /// <summary>
    /// 消费累计
    /// </summary>
    /// <param name="L_Id"></param>
    /// <returns></returns>
    public string GetSum(object L_Id)
    {
        string price = "无";
       decimal i = ConsumptionBLL.ConsumptionSum(Convert.ToInt32(L_Id));
       if (i != 0)
       {
           price = i.ToString();
       }
       return price;
    }
    


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindLoad();
        BindData("");
    }
}
