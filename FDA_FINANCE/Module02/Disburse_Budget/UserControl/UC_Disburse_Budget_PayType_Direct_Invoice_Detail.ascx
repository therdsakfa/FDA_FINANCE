<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_PayType_Direct_Invoice_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_PayType_Direct_Invoice_Detail" %>

<table>
<tr>
        <td align="right">ใบแจ้งหนี้เลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_INVOICE_NUMBER" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ใบแจ้งหนี้ลงวันที่ : </td>
        <td>
            <asp:TextBox ID="txt_INVOICE_DATE" runat="server" Width="200px"></asp:TextBox>
        </td>
        </tr>
    <tr>
    <td align="right">วันที่ทำใบแจ้งหนี้ : </td>

    <td>
        <asp:TextBox ID="txt_INVOICES_DATE_SAVE" runat="server" Width="200px"></asp:TextBox>
    </td>
    </tr>

   <tr>
    <td align="right">รับใบหักภาษีแล้ว : </td>
        <td>
            <asp:CheckBox ID="cb_IS_RECEIVE_TAX" runat="server" />
        </td>
</tr>
<tr>
        <td align="right">ชื่อผู้มารับใบหักภาษี : </td>
     <td>
            <asp:TextBox ID="txt_RECEIVER_TAX_NAME" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
     <td align="right">
         วันที่มารับใบหักภาษี :
     </td>
        <td>
            <asp:TextBox ID="txt_RECEIVE_TAX_DATE" runat="server" Width="200px"></asp:TextBox>

        </td>
    </tr>
</table>
