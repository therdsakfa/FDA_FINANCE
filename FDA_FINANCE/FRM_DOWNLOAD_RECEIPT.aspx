<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_DOWNLOAD_RECEIPT.aspx.vb" Inherits="FDA_FINANCE.FRM_DOWNLOAD_RECEIPT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Ref01 :</td>
                <td>
                    <asp:TextBox ID="txt_ref01" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ref02 :</td>
                <td>
                    <asp:TextBox ID="txt_ref02" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Download" />

    </form>
</body>
</html>
