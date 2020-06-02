<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Send_Mail_Receipt.aspx.vb" Inherits="FDA_FINANCE.Frm_Send_Mail_Receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>email :</td>
            <td><asp:TextBox ID="txt_mail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>ref01 :</td>
            <td>
                <asp:TextBox ID="txt_ref1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ref02</td>
            <td>
                <asp:TextBox ID="txt_ref2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_main" runat="server" Text="ส่ง Email" OnClientClick="return confirm('ต้องการส่ง Email ใช่หรือไม่?');" />
                <asp:Button ID="btn_mail" runat="server" Text="ส่ง Email2" OnClientClick="return confirm('ต้องการส่ง Email ใช่หรือไม่?');" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
