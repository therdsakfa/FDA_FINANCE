<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_PayType_Pass_Check_Number_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_PayType_Pass_Check_Number_Detail" %>
<asp:Panel ID="Panel1" runat="server" GroupingText ="บันทึกเลขที่เช็ค">
<table> 
<tr>
        <td align="right">เลขที่เช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>