<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Information" %>
รายละเอียดการคืนเงิน ลูกหนี้เงินยืม
<table style="border:1px solid black;">
    <tr>
        <td>ประเภทเงิน : </td>
        <td colspan="2">
            <asp:Label ID="lbl_MoneyType" runat="server" Text="ประเภทเงิน"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>จำนวนเงินที่ยืม : </td>
        <td>
            <asp:Label ID="lbl_MoneyBorrowAmount" runat="server" Text="0.00"></asp:Label>
        </td>
        <td> บาท</td>
    </tr>
    <tr>
        <td>จำนวนเงินที่คืน : </td>
        <td>
            <asp:Label ID="lbl_MoneyReturnAmount" runat="server" Text="0.00"></asp:Label>
        </td>
        <td> บาท</td>
    </tr>
    <tr>
        <td>จำนวนเงินคงเหลือที่ต้องคืน : </td>
        <td>
            <asp:Label ID="lbl_MoneyTotalAmount" runat="server" Text="0.00"></asp:Label>
        </td>
        <td> บาท</td>
    </tr>
</table>