<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budgetplan_Detail_Sub_BG.ascx.vb" Inherits="FDA_FINANCE.UC_Budgetplan_Detail_Sub_BG" %>
<table>
<tr>
<td align="right">
         
    ชื่อประเภทงบ :</td>
    <td>
        <asp:Label ID="lb_head_bg" runat="server" ></asp:Label>
    </td>
</tr>
<tr>
    <td align="right" valign="top">
        เลือกประเภทงบย่อย :</td>
    <td>
        <asp:CheckBoxList ID="cb_sub_bg" runat="server">
        </asp:CheckBoxList>
    </td>
</tr>

</table>