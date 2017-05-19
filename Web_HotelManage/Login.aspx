<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>酒店管理系统</title>
    <link href="css/adminLogin.css" rel="stylesheet" type="text/css" />  
    <script>
        function check() {


            if (document.getElementById("txtUserName").value == "") {
                alert("账号不能为空！");
                document.getElementById("txtUserName").focus();
                return false;
            }

            if (document.getElementById("txtPwd").value == "") {
                alert("密码不能为空！");
                document.getElementById("txtPwd").focus();
                return false;
            }


          






        }
        
        
    </script>
</head>
<body >
    <div id="top">
    </div>
    <div id="login">
        <div id="login_box">
            <div class="title">
            </div>
            <div class="content">
                <div class="left">
                </div>
                <div class="main">
                    <form id="login_form" runat="server">
                    <div class="login_userid">
                        <span>账　号：</span>
                        <input  type="text" class="input" runat="server" id="txtUserName" style="width:160px;" />
                    </div>
                    <div class="login_password">
                        <span>密　码：</span>
                        <input  type="password" class="input" runat="server" id="txtPwd" style="width:160px;"/>
                    </div>
                    <div class="login_button">
                        <asp:Button ID="btnLogin" runat="server"  CssClass="submit"  OnClientClick="return check()" onclick="btnLogin_Click" 
                            />
                        <input type="reset" name="reset" id="reset" value=""  />
                    </div>
                    </form>
                    <div class="note">
                        酒店管理系统
                    </div>
                </div>
                <div class="right">
                </div>
            </div>
        </div>
    </div>
    <div id="foot"></div>
    
</body>
</html>
