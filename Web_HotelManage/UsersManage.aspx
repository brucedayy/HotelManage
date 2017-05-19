<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersManage.aspx.cs" Inherits="RoomManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
     <link href="css/Manage.css" rel="stylesheet" type="text/css" />

    <script src="JavaScript/Jquery.js" type="text/javascript"></script>
    <script src="JavaScript/Add.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
   <div class="Body_Title">用户管理</div>
    <div>
    
   <div style="line-height:30px; padding-left:10px;   text-align:left;  height:30px;">
<input id="Button1"type="button" value="新增" onclick='window.location="UsersAdd.aspx"' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="padding-left:180px;">所属角色：<asp:DropDownList ID="ddlType" runat="server">
                     <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>服务员</asp:ListItem>
                    <asp:ListItem>管理员</asp:ListItem>
                </asp:DropDownList> 账号：<input id="txtName" type="text" runat="server"/>姓名：<input id="txtRealName" type="text" runat="server" /><asp:Button
    ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /></span>
    </div>
        <asp:Repeater ID="RpNews" runat="server">
        <HeaderTemplate>
            <table  class="Admin_Table" >
                <thead>
                    <tr class="Admin_Table_Title">
                        <th >选择</th>
                        <th >所属角色</th>
                        <th >账号</th>
                        <th >密码</th>
                        <th >姓名</th>
                        <th >性别</th>
                        <th >详细操作</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("U_Id") %>' name="CheckMes" /></td>
                <td align="center"><%#Eval("U_Type")%></td>
                 <td align="center"><%#Eval("U_Name")%></td>
                 <td align="center"><%#Eval("U_Pwd")%></td>
                 <td align="center"><%#Eval("U_RealName")%></td>
                  <td align="center"><%#Eval("U_Sex")%></td>
                <td align="center">
                    <a href="UsersAdd.aspx?id=<%#Eval("U_Id") %>">修改</a> <asp:LinkButton ID="ibDel" runat="server"   Text="删除"
                                    CommandArgument='<%# Eval("U_Id") %>' 
               OnClientClick="return confirm('确定删除当前项?')" onclick="ibDel_ItemDeleting" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;<asp:Button ID="BtnAllDel" runat="server" Text="删除选中" onclick="BtnAllDel_Click" 
                 />
        </div>
        <div class="page_Right">
            <asp:Label runat="server" ID="PageMes"></asp:Label>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">首页</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">上一页</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">下一页</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">尾页</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/><!--当前页-->
    <asp:HiddenField ID="HPageSize" runat="server" Value=""/><!--共多少条-->
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/><!--总共多少页-->
    <asp:HiddenField ID="HCount" runat="server" Value="15"/><!--每页多少条-->
    </form>
</body>
</html>
