<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_OutsideBudget_Amount_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_OutsideBudget_Amount_Detail" %>
<style type="text/css">
    .auto-style1 {
        text-align: right;
    }

    #tb_amount {
        font-size: 14px;
    }
</style>
รายละเอียด
<table width="100%"  id="tb_amount">
    <tr>
        <td align="right">ยอดยกมา : </td>
        <td width="130" class="auto-style1">
            <asp:Label ID="txt_Amount" runat="server" Text="0.00"></asp:Label>

            &nbsp;บาท</td>
        <td align="right">&nbsp;</td>
        <td>
            &nbsp;</td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td align="right"  >เงินรับ : </td>
        <td class="auto-style1"  >
            <asp:Label ID="txt_receive" runat="server" Text="0.00" ></asp:Label>
            &nbsp;บาท</td>
        <td align="right"  >ยอดเบิกก่อนอนุมัติ : </td>
        <td class="auto-style1"  >
            <asp:Label ID="txt_disburse_before_app" runat="server" Text="0.00"></asp:Label>
            &nbsp;บาท</td>
        <td align="right"  >ยอดเบิกหลังอนุมัติ : </td>
        <td class="auto-style1"  >
            <asp:Label ID="txt_disburse_app" runat="server" Text="0.00"></asp:Label>
            &nbsp;บาท</td>
    </tr>
    <tr>
        <td align="right">โอนเบิกแทน : </td>
        <td class="auto-style1">
            <asp:Label ID="TextBox5" runat="server" Text="0.00"></asp:Label>
            &nbsp;บาท</td>
        <td align="right">เงินคงเหลือก่อนอนุมัติ : </td>
        <td class="auto-style1">
            <asp:Label ID="txt_balance_before_app" runat="server" Text="0.00"></asp:Label>
            &nbsp;บาท</td>
        <td align="right">เงินคงเหลือหลังอนุมัติ : </td>
        <td class="auto-style1">
            <asp:Label ID="txt_balance_app" runat="server" Text="0.00"></asp:Label>
            &nbsp;บาท</td>
    </tr>
</table>