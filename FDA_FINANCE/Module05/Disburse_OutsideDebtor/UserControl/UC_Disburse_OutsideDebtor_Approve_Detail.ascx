<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_OutsideDebtor_Approve_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_OutsideDebtor_Approve_Detail" %>
<table>
    <tr>
         <td align="right" >
             <asp:Label ID="lb_pay_type" runat="server" Text="ประเภทการจ่าย :"></asp:Label>
         </td>
            <td>
                <asp:RadioButtonList ID="rd_express_type" runat="server" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">เงินสด</asp:ListItem>
                <asp:ListItem Value="2">เช็ค</asp:ListItem>
                </asp:RadioButtonList>
            </td>
    </tr>

</table>