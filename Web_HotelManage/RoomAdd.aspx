<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomAdd.aspx.cs" Inherits="RoomAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />

   

    <script language="javascript" type="text/javascript">
       

        function check() {

            if (document.getElementById("txtNo").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtNo").focus();
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
            客房类型：
            </th>
            <td style="text-align: left; ">
                <asp:DropDownList ID="ddlRt_Id" runat="server">
                </asp:DropDownList>
            </td>
           
        </tr>
        <tr>
            <th >
            房间号：
            </th>
            <td style="text-align: left; ">
                <input id="txtNo" type="text"  runat="server" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            房间电话：
            </th>
            <td style="text-align: left; ">
                <input id="txtTel" type="text"  runat="server"   />
            </td>
           
        </tr>
        <tr>
            <th >
            状态：
            </th>
            <td style="text-align: left; ">
 <asp:DropDownList ID="ddlState" runat="server">
     <asp:ListItem>空</asp:ListItem>
     <asp:ListItem>入住</asp:ListItem>
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