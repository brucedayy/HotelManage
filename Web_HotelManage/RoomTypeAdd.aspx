<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomTypeAdd.aspx.cs" Inherits="RoomTypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />

   

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
            if (document.getElementById("txtPrice").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtPrice").focus();
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
                <input id="txtName" type="text"  runat="server" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            标准价格：
            </th>
            <td style="text-align: left; ">
                <input id="txtPrice" type="text"  runat="server"  onkeyup="clearNoNum(this)" /><span
                    style="color: Red;">/天*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            备注：
            </th>
            <td style="text-align: left; ">
                <textarea id="txtNote" runat="server" style="width:300px; height:100px;"></textarea>
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