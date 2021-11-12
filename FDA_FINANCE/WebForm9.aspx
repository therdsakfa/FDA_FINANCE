<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm9.aspx.vb" Inherits="FDA_FINANCE.WebForm9" %>

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
        <asp:Button ID="Button8" runat="server" Text="run ใบเสร็จ" />
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
        <asp:Button ID="Button5" runat="server" Text="Button" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Image ID="Image2" runat="server" />

    <table width="100%">
        <tr>
            <td align="right" width="30%">
                Ref01 หรือเลขใบสั่งชำระ
            </td>
            <td>
                <asp:TextBox ID="txt_ref01" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
                &nbsp; &nbsp;&nbsp;(ตัวอย่างการกรอกเลขใบสั่งชำระ 79555/60)</td>
        </tr>
        <tr>
            <td align="right">
                Ref02</td>
            <td>
                <asp:TextBox ID="txt_ref02" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
                &nbsp;<br />
                <asp:Button ID="Button6" runat="server" Text="ส่ง REF แก้ไขไม่มีชื่อผปก." />
                <asp:Button ID="Button7" runat="server" Text="ส่งข้อมูลเลขใบสั่ง แก้ไขไม่มีชื่อผปก." />
                <asp:Button ID="Button9" runat="server" Text="Button" />
            </td>
        </tr>
    </table>
    </div>

        1 สถานที่ผลิตยาแผนปัจจุบัน
2 สถานที่ผลิตยาแผนโบราณสำหรับสัตว์
3 สถานที่นำเข้ายาแผนปัจจุบัน
4 สถานที่นำเข้ายาแผนโบราณสำหรับสัตว์
5 สถานที่ขายส่งยาแผนปัจจุบัน ข.ย.4
6 สถานที่ขายยาแผนปัจจุบัน ข.ย.1
7 สถานที่ขายยาแผนปัจจุบันบรรจุเสร็จ ข.ย.2
8 สถานที่ขายยาแผนปัจจุบันบรรจุเสร็จสำหรับสัตว์ ข.ย.3
9 สถานที่ขายยาแผนโบราณสำหรับสัตว์
10 ร้านยาคุณภาพ

    </form>
</body>
</html>
