<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrdersAdd.aspx.cs" Inherits="OrdersAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />


    <script src="JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
       

        function check() {

            if (document.getElementById("ddlRt_Id").value == "0") {
                alert("请选择客房类型！");
                document.getElementById("ddlRt_Id").focus();
                return false;
            }
            if (document.getElementById("txtName").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtName").focus();
                return false;
            }
            if (document.getElementById("txtTel").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtTel").focus();
                return false;
            }
            if (document.getElementById("txtBudget").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtBudget").focus();
                return false;
            }


            if (document.getElementById("txtBudget").value < document.getElementById("txtGetDate").value) {
                alert("预入住日期必须大于或等于当前日期！");
                document.getElementById("txtBudget").focus();
                return false;
            }
            
        }
        
        

        

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="div_All">
        <div class="Body_Title">
            <%=strNav%></div>
    </div>
    <table style="width: 100%">
        <tr>
            <th >
            订单号：
            </th>
            <td style="text-align: left; ">
                <input id="txtNo" type="text"  runat="server" disabled="disabled" />
            </td>
           
        </tr>
        <tr>
            <th >
            客房类型：
            </th>
            <td style="text-align: left; ">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlRt_Id" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlRt_Id_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblShow" runat="server" ForeColor="Red" ></asp:Label>
            </ContentTemplate>
                </asp:UpdatePanel>
            </td>
           
        </tr>
        <tr>
            <th >
            客户姓名：
            </th>
            <td style="text-align: left; ">
                <input id="txtName" type="text"  runat="server" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            客户手机：
            </th>
            <td style="text-align: left; ">
                <input id="txtTel" type="text"  runat="server"   /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            预入住日期：
            </th>
            <td style="text-align: left; ">
                <input id="txtBudget" type="text" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" /><input id="txtGetDate" type="text" runat="server"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" style="display:none;" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        
        <tr>
            <th >
            操作人：
            </th>
            <td style="text-align: left; ">
 <input id="txtUserName" type="text"  runat="server" disabled="disabled" />
            </td>
           
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: left; ">
                <asp:Button ID="btnUpdate" runat="server" Text="添加" OnClientClick="return check()"
                    OnClick="btnUpdate_Click" />&nbsp;<input id="BtnBackProList" type="button" value="返回"
                        onclick='javascript:history.go(-1)' />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>