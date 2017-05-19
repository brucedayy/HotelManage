<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LiveUpdate.aspx.cs" Inherits="LiveUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Manage.css" rel="stylesheet" type="text/css" />


    <script src="JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="JavaScript/Jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
     



        function Calculation() {
           

            if (document.getElementById("txtOutTime").value <= document.getElementById("txtTime").value) {
                alert("退房日期必须大于入住日期！");
                document.getElementById("txtOutTime").focus();
                return false;
            }
           
            var myDate = new Date();
            $.ajax({
                type: "GET",
                url: "Handler/GetDue.ashx?L_Id=" + $("#txtL_Id").val() + "&L_OutTime=" + $("#txtOutTime").val() + "&MyDate=" + myDate.getTime(),
                eache: false,
                success: function(msg) {
                    if (msg != "") {
                        $("#txtPay").val(msg);
                    }

                },
                complete: function(XMLHttpRequest, textStatus) {
                    //隐藏正在查询图片
                },
                error: function() {
                    //错误处理
                }
            });
        }

      

        function check() {

         
           
           

            if (document.getElementById("txtOutTime").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtOutTime").focus();
                return false;
            }


            if (document.getElementById("txtOutTime").value <= document.getElementById("txtTime").value) {
                alert("退房日期必须大于入住日期！");
                document.getElementById("txtOutTime").focus();
                return false;
            }
            if (document.getElementById("txtPay").value == "") {
                alert("带红色 * 号项不能为空！");
                document.getElementById("txtPay").focus();
                return false;
            }

            if (confirm('确定要结算该退房吗?结算后不可以恢复！')) {
                return true;
            }
            else {
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
            <th>
            入住日期：
            </th>
            <td style="text-align: left; ">
                <input id="txtTime" type="text" runat="server"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" disabled="disabled" />
            </td>
           
        </tr>
    
        <tr>
            <th >
            退房日期：
            </th>
            <td style="text-align: left; ">
                <input id="txtOutTime" type="text" runat="server" onchange="Calculation()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" /><span
                    style="color: Red;">*</span>
            </td>
           
        </tr>
        
        <tr>
            <th >
            欠付金额：
            </th>
            <td style="text-align: left; ">
                 <input id="txtPay" type="text"  runat="server"  readonly="readonly"    /><span
                    style="color: Red;">* 注为正数表示需欠付的金额，负数表示需退还的金额。</span>
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
                <asp:Button ID="btnUpdate" runat="server" Text="结算" OnClientClick="return check()"
 OnClick="btnUpdate_Click" />&nbsp;<input id="BtnBackProList" type="button" value="返回"
                        onclick='javascript:history.go(-1)' />
            </td>
        </tr>
    </table>
    <div style="display:none;">
        <input id="txtL_Id" runat="server" type="text" />
    </div>
    </form>
</body>
</html>