<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrdersJoin.aspx.cs" Inherits="OrdersJoin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
     <link href="css/Manage.css" rel="stylesheet" type="text/css" />

    
</head>
<body>
    <form id="form1" runat="server">
   <div class="Body_Title">按预订单入住</div>
    <div>
    
   
        <asp:Repeater ID="RpNews" runat="server">
        <HeaderTemplate>
            <table  class="Admin_Table" >
                <thead>
                    <tr class="Admin_Table_Title">
                      
                        <th >订单号</th>
                        <th >客户姓名</th>
                        <th >客户手机</th>
                        
                       <th >预入住日期</th>
                       <th >客房类型</th>
                       <th >下单时间</th>
                        <th >详细操作</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                
                 
                 <td align="center"><%#Eval("O_No")%></td>
                 <td align="center"><%#Eval("O_Name")%></td>
                 <td align="center"><%#Eval("O_Tel")%></td>
                 <td align="center">
                 <%#Convert.ToDateTime(Eval("O_Budget")).ToString("yyyy-MM-dd")%>
                 </td>
                 <td align="center"><%#BLL.RoomTypeBLL.GetIdByRoomType(Convert.ToInt32( Eval("Rt_Id"))).Rt_Name%></td>
                <td align="center"><%#Convert.ToDateTime(Eval("O_Time")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                <td align="center"><a href="LiveAdd.aspx?id=<%#Eval("O_Id") %>">订单入住</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <div class="Body_Search">
        <div class="page_Left">
            
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
