<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Transfer_Share_Type_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Transfer_Share_Type_Detail" %>
<table>
<tr>
<td align="right">
ประเภทเบิกแทน :
</td>
<td>
    <asp:RadioButtonList ID="rd_type" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">เบิกแทน</asp:ListItem>
        <asp:ListItem Value="2">เบิกแทนผูกพัน</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>
<tr>
<td align="right">
จำนวนเงิน : 
</td>
<td>
    <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
&nbsp;บาท</td>
</tr>
</table>