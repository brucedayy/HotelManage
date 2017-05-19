<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>酒店管理系统</title>
</head>
<frameset rows="50,*"  frameborder="no" frameborder="1" framespacing="0">
	<frame src="Top.aspx" noresize="noresize" frameborder="NO" name="topFrame" scrolling="no" marginwidth="0" marginheight="0" target="tops" />
  <frameset cols="184,*"   id="frame">
	<frame src="<%=strLeftUrl%>" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="1" scrolling="auto" target="lefts" />
	<frame src="UpdatePwd.aspx" name="main" marginwidth="0" marginheight="0" frameborder="1" scrolling="auto" target="main" />
  </frameset>
  </frameset>
<noframes>
<body>
</body>
</html>
