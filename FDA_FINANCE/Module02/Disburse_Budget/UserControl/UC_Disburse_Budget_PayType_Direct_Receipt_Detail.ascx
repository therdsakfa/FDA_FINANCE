<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_PayType_Direct_Receipt_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_PayType_Direct_Receipt_Detail" %>
<table width="100%">

 <tr>
     <td align="right"><asp:CheckBox ID="cbIS_NO_RECIPT" runat="server" Text="ไม่มีใบเสร็จ" AutoPostBack="true"/></td>
    <td align="right">เลขที่ใบเสร็จ : </td>
        <td>
            <asp:TextBox ID="txt_RECEIPT_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ใบเสร็จ  : </td>
        <td>
            <asp:TextBox ID="txt_RECEIPT_DATE" runat="server"></asp:TextBox>

        </td>
    </tr>
</table>
