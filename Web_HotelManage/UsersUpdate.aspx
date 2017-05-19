<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersUpdate.aspx.cs" Inherits="UsersUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />

   

    <script language="javascript" type="text/javascript">


        function check() {

            if (document.getElementById("txtRealName").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtRealName").focus();
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
            账号：
            </th>
            <td style="text-align: left; ">
                <input id="txtName" type="text"  runat="server"  disabled="disabled"/>
            </td>
           
        </tr>
        <tr>
            <th >
            姓名：
            </th>
            <td style="text-align: left; ">
                <input id="txtRealName" type="text"  runat="server" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            性别：
            </th>
            <td style="text-align: left; ">
                <asp:RadioButton ID="rdbMan" runat="server"  GroupName="aa" Text="男"/>&nbsp;<asp:RadioButton ID="rdbWoman" runat="server"  GroupName="aa" Text="女"/>
            </td>
           
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: left; ">
                <asp:Button ID="btnUpdate" runat="server" Text="修改" OnClientClick="return check()"
                    OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>