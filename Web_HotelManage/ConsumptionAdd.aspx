<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsumptionAdd.aspx.cs" Inherits="ConsumptionAdd" %>

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

            if (document.getElementById("txtPrice").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtPrice").focus();
                return false;
            }
           

            if (document.getElementById("txtTime").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtTime").focus();
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
            消费项目：
            </th>
            <td style="text-align: left; ">
                <input id="txtName" type="text"  runat="server"   /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            消费金额：
            </th>
            <td style="text-align: left; ">
                <input id="txtPrice" type="text"  runat="server"  onkeyup="clearNoNum(this)" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        <tr>
            <th >
            消费时间：
            </th>
            <td style="text-align: left; ">
                <input id="txtTime" type="text" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" /><span
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
                        onclick='javascript:window.location.replace("LiveManage.aspx")' />
            </td>
        </tr>
    </table>
    <div class="Body_Title">消费记录</div>
    <asp:Repeater ID="RpNews" runat="server">
        <HeaderTemplate>
            <table  class="Admin_Table" >
                <thead>
                    <tr class="Admin_Table_Title">
                      
                        <th >入住编号</th>
                        <th >消费项目</th>
                        <th >消费金额</th>
                        
                       <th >消费时间</th>
                       <th >操作人</th>
                       
                        <th >详细操作</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                
                 
                 <td align="center"><%#BLL.LiveBLL.GetIdByLive(Convert.ToInt32( Eval("L_Id"))).L_No%></td>
                 <td align="center"><%#Eval("C_Name")%></td>
                 
                <td align="center"><%#Eval("C_Price")%></td>
                 
                    <td align="center"><%#Convert.ToDateTime(Eval("C_Time")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                 <td align="center"><%#BLL.UsersBLL.GetIdByUsers(Convert.ToInt32(Eval("U_Id"))).U_Name%></td>

                <td align="center"><asp:LinkButton ID="ibDel" runat="server"  Text="删除"
                                    CommandArgument='<%# Eval("C_Id") %>' 
               OnClientClick="return confirm('确定要删除该记录？')" onclick="ibDel_ItemDeleting" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>