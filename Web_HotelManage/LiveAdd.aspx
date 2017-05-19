<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LiveAdd.aspx.cs" Inherits="LiveAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />


    <script src="JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function clearNoNum(obj) {
            //先把非数字的都替换掉，除了数字和.
            obj.value = obj.value.replace(/[^\d.]/g, "");
            //必须保证第一个为数字而不是.
            obj.value = obj.value.replace(/^\./g, "");
            //保证只有出现一个.而没有多个.
            obj.value = obj.value.replace(/\.{2,}/g, ".");
            //保证.只出现一次，而不能出现两次以上
            obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
        }

        function check() {

         
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
            if (document.getElementById("txtIdCard").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtIdCard").focus();
                return false;
            }

            if (document.getElementById("txtTime").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtTime").focus();
                return false;
            }


            if (document.getElementById("txtTime").value < document.getElementById("txtGetDate").value) {
                alert("入住日期必须大于或等于当前日期！");
                document.getElementById("txtTime").focus();
                return false;
            }
            if (document.getElementById("txtDeposit").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtDeposit").focus();
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
            <th>
            入住编号：
            </th>
            <td style="text-align: left; ">
                <input id="txtNo" type="text"  runat="server" disabled="disabled" />
            </td>
           
        </tr>
        <tr>
            <th >
            客房：
            </th>
            <td style="text-align: left; ">
                <asp:DropDownList ID="ddlRt_Id" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlRt_Id_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlR_Id" runat="server">
                </asp:DropDownList>
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
            身份证：
            </th>
            <td style="text-align: left; ">
                <input id="txtIdCard" type="text"  runat="server"   /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            入住日期：
            </th>
            <td style="text-align: left; ">
                <input id="txtTime" type="text" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" /><input id="txtGetDate" type="text" runat="server"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" style="display:none;" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            入住定金：
            </th>
            <td style="text-align: left; ">
                <input id="txtDeposit" type="text"  runat="server"  onkeyup="clearNoNum(this)" /><span
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