<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm10.aspx.vb" Inherits="FDA_FINANCE.WebForm10" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="ค้นหาใบสั่ง" />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Image ID="Image1" runat="server" />
        <br />
        <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" />
        <asp:Button ID="Button2" runat="server" Text="GEN_IMAGE" />
        <asp:Button ID="Button5" runat="server" Text="Button" />
        <br />
        <br />
        <asp:Button ID="Button7" runat="server" Text="Button" />
        <br />
        <table>
            <tr>
                <td align="right">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btn_upload" runat="server" Text="อัพโหลด" />
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="Button" />
                    <asp:Button ID="Button6" runat="server" Text="test_runno" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
