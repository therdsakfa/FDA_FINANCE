<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Margin_Amount_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Margin_Amount_Detail" %>
รายละเอียดเงินทดรอง<table width="100%">
    <tr>
        <td align="right">จำนวนเงินทดรอง : </td>
        <td width="130">&nbsp;
            <asp:Label ID="txt_Amount" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
        <td align="right">งบประมาณสุทธิ : </td>
        <td>&nbsp;
             <asp:Label ID="Label1" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td align="right" >เพิ่ม/ลด : </td>
        <td >&nbsp;
             <asp:Label ID="Label2" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
        <td align="right">ยอดเบิกก่อนอนุมัติ : </td>
        <td >&nbsp;
             <asp:Label ID="txt_disburse_before_app" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
        <td align="right">ยอดเบิกหลังอนุมัติ : </td>
        <td >&nbsp;
            <asp:Label ID="txt_disburse_app" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
    </tr>
    <tr>
        <td align="right">โอนเบิกแทน : </td>
        <td>&nbsp;
            <asp:Label ID="TextBox5" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
        <td align="right">เงินคงเหลือก่อนอนุมัติ : </td>
        <td>&nbsp;

            <asp:Label ID="txt_balance_before_app" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
        <td align="right">เงินคงเหลือหลังอนุมัติ : </td>
        <td>&nbsp;
            <asp:Label ID="txt_balance_app" runat="server" Text="0.0"></asp:Label>
            &nbsp;บาท</td>
    </tr>
</table>