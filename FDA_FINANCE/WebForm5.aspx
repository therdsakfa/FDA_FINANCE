<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm5.aspx.vb" Inherits="FDA_FINANCE.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>

        </asp:CheckBoxList>
        <asp:Button ID="Button1" runat="server" Text="Button" style="display:none;" />
        <asp:Button ID="Button2" runat="server" Text="Button" style="display:none;"/>
        <asp:Button ID="Button3" runat="server" Text="Button" /><asp:Button ID="Button4" runat="server" Text="Button" />
        <asp:Button ID="Button5" runat="server" Text="test confirm" OnClientClick="return confirm('ต้องการเซฟใหม');"/>
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Text="5555"></asp:TextBox>
    </form>
</body>
</html>
