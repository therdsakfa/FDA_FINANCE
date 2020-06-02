<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Receive_List_Filter.ascx.vb" Inherits="FDA_FINANCE.UC_Receive_List_Filter" %>
<table>
    <tr>
        <td align="right">เลขหนังสือ :</td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">ชื่อ-นามสกุล :</td>
        <td>
            <asp:DropDownList ID="dl_User" runat="server" Width="200px"></asp:DropDownList>
        </td>
        <td align="right">
            เลขบย.:</td>
        <td>
            <asp:TextBox ID="txt_BILL_NUMBER" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td align="right">
            สถานะ</td>
        <td>
            <asp:RadioButtonList ID="rd_receive_type" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="">ทั้งหมด</asp:ListItem>
                <asp:ListItem Value="รับเรื่องแล้ว">รับเรื่องแล้ว</asp:ListItem>
                <asp:ListItem Selected="True" Value="ยังไม่ได้รับเรื่อง">ยังไม่ได้รับเรื่อง</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="right">จำนวนเงิน :</td>
        <td>
            <asp:DropDownList ID="dd_equal" runat="server">
                <asp:ListItem>=</asp:ListItem>
                <asp:ListItem>&gt;</asp:ListItem>
                <asp:ListItem>&lt;</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>

        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>