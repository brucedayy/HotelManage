<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomSearch.aspx.cs" Inherits="RoomManage" %>

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
   <div class="Body_Title">房态查询</div>
    <div>
    
   <div style="line-height:30px; text-align:center; height:30px;">
   客房类型：<asp:DropDownList ID="ddlRt_Id" runat="server">
       </asp:DropDownList>
  状态：<asp:DropDownList ID="ddlState" runat="server">
           <asp:ListItem>全部</asp:ListItem>
           <asp:ListItem>空</asp:ListItem>
           <asp:ListItem>入住</asp:ListItem>
       </asp:DropDownList>房间号：<input id="txtNo" runat="server" type="text" />房间电话：<input id="txtTel" runat="server" type="text" />
       <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
    </div>
        <asp:Repeater ID="RpNews" runat="server">
        <HeaderTemplate>
            <table  class="Admin_Table" >
                <thead>
                    <tr class="Admin_Table_Title">
                       
                        <th >客房类型</th>
                        <th >房间号</th>
                       <th >房间电话</th>
                        <th >状态</th>
                       
                       
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                
                 <td align="center"><%#BLL.RoomTypeBLL.GetIdByRoomType(Convert.ToInt32( Eval("Rt_Id"))).Rt_Name%></td>
                 <td align="center"><%#Eval("R_No")%></td>
                 <td align="center"><%#Eval("R_Tel")%></td>
                 <td align="center"><%#Eval("R_State")%></td>
               
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
