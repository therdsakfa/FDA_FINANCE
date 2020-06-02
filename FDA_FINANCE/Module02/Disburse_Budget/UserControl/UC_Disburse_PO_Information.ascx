<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_PO_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_PO_Information" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียดผูกพันจัดซื้อจัดจ้าง" Width="100%">
    <table width="100%">
    <tr>
        <td align="right">
            <b>เลขที่หนังสือ :</b>
        </td>
        <td>
            &nbsp;<asp:Label ID="lb_DOC_NUMBER" runat="server" ></asp:Label>
        </td>
        <td align="right">
           <b> วันที่เลขที่หนังสือ :</b>
        </td>
        <td>
            &nbsp;<asp:Label ID="lb_DOC_DATE" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right"><b>รายละเอียด : </b></td>
        <td colspan="3">
            &nbsp;<asp:Label ID="lb_DESCRIPTION" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right"><b>จำนวนเงิน PO :</b></td>
        <td>
            &nbsp;<asp:Label ID="lb_AMOUNT" runat="server" ></asp:Label>
        &nbsp;บาท</td>
        <td align="right">จำนวนเงินคงเหลือของใบ PO :&nbsp;</td>
        <td>
            &nbsp;<asp:Label ID="lb_balance_amount" runat="server" ></asp:Label>
&nbsp;บาท</td>
    </tr>
</table>
</asp:Panel>

