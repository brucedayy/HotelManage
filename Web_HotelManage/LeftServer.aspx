<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftServer.aspx.cs" Inherits="LeftServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>主页左边</title>
    <style type="text/css">
        body
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #000;
            background-color: #EEF2FB;
            margin: 0px;
        }
        #container
        {
            width: 182px;
        }
        H1
        {
            font-size: 12px;
            margin: 0px;
            width: 182px;
            height: 30px;
            line-height: 30px;
            color: #000000;
            background-image: url(image/menu_bgs.gif);
            text-align: center;
        }
        .content
        {
            width: 182px;
        }
        .MM ul
        {
            list-style-type: none;
            margin: 0px;
            padding: 0px;
            display: block;
        }
        .MM li
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            list-style-type: none;
            display: block;
            text-decoration: none;
            height: 26px;
            width: 182px;
            padding-left: 0px;
        }
        .MM
        {
            width: 182px;
            margin: 0px;
            padding: 0px;
            left: 0px;
            top: 0px;
            right: 0px;
            bottom: 0px;
            clip: rect(0px,0px,0px,0px);
        }
        .MM a:link
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(image/menu_bg1.gif);
            background-repeat: no-repeat;
            height: 26px;
            width: 182px;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
            text-decoration: none;
        }
        .MM a:visited
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(image/menu_bg1.gif);
            background-repeat: no-repeat;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            height: 26px;
            width: 182px;
            text-decoration: none;
        }
        .MM a:active
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(image/menu_bg1.gif);
            background-repeat: no-repeat;
            height: 26px;
            width: 182px;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
            text-decoration: none;
        }
        .MM a:hover
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            font-weight: bold;
            color: #000000;
            background-repeat: no-repeat;
            text-align: center;
            display: block;
            margin: 0px;
            padding: 0px;
            height: 26px;
            width: 182px;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="280" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEF2FB">
        <tr>
            <td width="182" valign="top">
                <div id="container">
                    <h1>客房预订</h1>
                    <div class="content">
                        <ul class="MM">
                            
<li><a href="OrdersAdd.aspx" target="main">预订录入</a></li>
<li><a href="OrdersManage.aspx" target="main">预订取消</a></li>
     <li><a href="OrdersJoin.aspx" target="main">按预订单入住</a></li>                           
                        </ul>
                    </div>
                        <h1>前台查询</h1>
                    <div class="content">
                        <ul class="MM">
                            
<li><a href="RoomTypeSearch.aspx" target="main">房价一览</a></li>
  <li><a href="RoomSearch.aspx" target="main">房态查询</a></li>                              
                        </ul>
                    </div>
                       <h1>前台接待</h1>
                    <div class="content">
                        <ul class="MM">
                            
<li><a href="LiveAdd.aspx" target="main">入住登记</a></li>
  <li><a href="LiveSearch.aspx" target="main">入住查询</a></li>                              
                        </ul>
                    </div>
                       <h1>前台收银</h1>
                    <div class="content">
                        <ul class="MM">
                            
<li><a href="LiveManage.aspx" target="main">消费登记</a></li>
  <li><a href="LiveSettlement.aspx" target="main">结算退房</a></li>                              
                        </ul>
                    </div>
                       <h1>个人信息</h1>
                    <div class="content">
                        <ul class="MM">
                            
<li><a href="UsersUpdate.aspx" target="main">修改资料</a></li>
  <li><a href="UpdatePwd.aspx" target="main">修改密码</a></li>                              
                        </ul>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
