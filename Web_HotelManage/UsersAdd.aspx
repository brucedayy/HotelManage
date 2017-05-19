<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersAdd.aspx.cs" Inherits="RoomAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />

   

    <script language="javascript" type="text/javascript">
       

        function check() {

            if (document.getElementById("txtName").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtName").focus();
                return false;
            }
            if (document.getElementById("txtPwd").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtPwd").focus();
                return false;
            }
            
        }
        
        

        

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="div_All">
        <div class="Body_Title">
            <%=strNav%></div>
    </div>
    <table style="width: 100%">
        
        <tr>
            <th >
            所属角色：
            </th>
            <td style="text-align: left; ">
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem>服务员</asp:ListItem>
                    <asp:ListItem>管理员</asp:ListItem>
                </asp:DropDownList>
            </td>
           
        </tr>
        <tr>
            <th >
            账号：
            </th>
            <td style="text-align: left; ">
                <input id="txtName" type="text"  runat="server" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
         <tr>
            <th >
            密码：
            </th>
            <td style="text-align: left; ">
                <input id="txtPwd" type="text"  runat="server" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            姓名：
            </th>
            <td style="text-align: left; ">
                <input id="txtRealName" type="text"  runat="server"   />
            </td>
           
        </tr>
        <tr>
            <th >
            性别：
            </th>
            <td style="text-align: left; ">
 <asp:DropDownList ID="ddlSex" runat="server">
     <asp:ListItem>男</asp:ListItem>
     <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
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