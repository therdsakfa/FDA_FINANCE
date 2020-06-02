<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_FIX_RECEIPT.aspx.vb" Inherits="FDA_FINANCE.FRM_FIX_RECEIPT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/jquery.blockUI.js"></script>


    <script type="text/javascript">
        $(function () {
            $('#<%= btn_send.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>ref01</td><td>
            <asp:TextBox ID="txt_ref01" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ref02</td><td>
            <asp:TextBox ID="txt_ref02" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td><td>
            <asp:Button ID="btn_send" runat="server" Text="ส่งค่า" OnClientClick="return confirm('ต้องการส่งค่าหรือไม่?');" />
<%--            <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return confirm('ต้องการส่งค่าหรือไม่?');" />--%>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
