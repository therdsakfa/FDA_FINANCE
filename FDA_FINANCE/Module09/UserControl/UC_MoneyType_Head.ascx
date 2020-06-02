<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_MoneyType_Head.ascx.vb" Inherits="FDA_FINANCE.UC_MoneyType_Head" %>

<table>
    <tr>
        <td>
            ประเภทเงิน : 
        </td>
        <td>
            <asp:DropDownList ID="dd_money_type" runat="server" DataTextField="MONEY_TYPE_DESCRIPTION" DataValueField="MONEY_TYPE_ID"></asp:DropDownList>
        </td>
    </tr>

</table>