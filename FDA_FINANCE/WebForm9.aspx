﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm9.aspx.vb" Inherits="FDA_FINANCE.WebForm9" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Button" />

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_read" runat="server" Text="READ" />
        <asp:Button ID="btn_test_ps" runat="server" Text="test_ps" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><asp:Image ID="Image1" runat="server" />
        <br />
        <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Height="236px" ResizeMode="Fit" Width="241px" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="btn_qr" runat="server" Text="GEN QR" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="re_update_status" />
        <asp:Button ID="btn_update_qr" runat="server" Text="UPDATE_QR" />
        <asp:Button ID="Button4" runat="server" Text="Button" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Image ID="Image2" runat="server" />
    </div>
    </form>
</body>
</html>