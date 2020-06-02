<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Debtor_Rebill_Receipt_Detail" %>
<table width="400">
    <tr>
        <td align="right">
            เลข บฝ. :
        </td>
        <td>
            <asp:TextBox ID="txt_bt_number" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            วันที่โอน :
        </td>
        <td>
            <asp:TextBox ID="txt_Changedate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            
            รายละเอียดการโอน:
            
        </td>
        <td>
            <asp:TextBox ID="txt_CHANGE_DESCRIPTION" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>