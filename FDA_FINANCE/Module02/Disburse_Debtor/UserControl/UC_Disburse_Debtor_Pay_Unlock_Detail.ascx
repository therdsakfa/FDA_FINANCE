<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Pay_Unlock_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Pay_Unlock_Detail" %>
<asp:Panel ID="Panel3" runat="server" Width ="100%" GroupingText="บันทึกเลขปลดจ่าย">
<table>
       
    <tr>
        <td align="right">เลขปลดจ่าย : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_APPROVE_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่เลขปลดจ่าย : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_APPROVE_DATE" runat="server"></asp:TextBox>
        </td>
        <%--<td align="right">วันครบคืนคลัง : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_BUDGET_DATE" runat="server"></asp:TextBox>
        </td>--%>
    </tr>
    
    
</table>
</asp:Panel>