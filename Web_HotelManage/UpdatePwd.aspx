<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePwd.aspx.cs" Inherits="UpdatePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />

   
         <script language="javascript" type="text/javascript">

             function check() {
                 var txtOldPwd = document.getElementById("txtOldPwd");
                 var txtNewPwd = document.getElementById("txtNewPwd");
                 var txtSureNewPwd = document.getElementById("txtSureNewPwd");
                 if (txtOldPwd.value == "") {

                     alert("带红色星项不能空！");
                     txtOldPwd.focus();
                     return false;
                 }
                 if (txtNewPwd.value == "") {

                     alert("带红色星项不能空！");
                     txtNewPwd.focus();
                     return false;
                 }
                 
                 if (txtSureNewPwd.value == "") {

                     alert("带红色星项不能空！");
                     txtSureNewPwd.focus();
                     return false;
                 }
                 if (txtNewPwd.value != txtSureNewPwd.value) {

                     alert("两次密码不一致！");
                     txtSureNewPwd.focus();
                     return false;
                 }
             }
    </script>

     

</head>
<body>
    <form id="form1" runat="server">
    <div class="div_All">
        <div class="Body_Title">
            修改密码</div>
    </div>
    <table style="width: 100%">
        
        <tr>
            <th style="width: 15%">
                 旧密码：
            </th>
            <td style="text-align: left; width: 85%">
                <input id="txtOldPwd"  runat="server" type="password" /><span  style="color:Red;">*</span>
            </td>
           
        </tr>
         <tr>
            <th>
                新密码：
            </th>
            <td style="text-align: left;">
               <input id="txtNewPwd" runat="server" type="password" /><span  style="color:Red;">*</span>
            </td>
        </tr>
        <tr>
            <th>
                确认新密码：
            </th>
            <td style="text-align: left;">
                <input id="txtSureNewPwd" runat="server" type="password" /><span  style="color:Red;">*</span>
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