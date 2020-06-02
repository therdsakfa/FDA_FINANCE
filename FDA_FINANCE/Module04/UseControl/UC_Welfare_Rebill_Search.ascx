<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Welfare_Rebill_Search.ascx.vb" Inherits="FDA_FINANCE.UC_Welfare_Rebill_Search" %>
<table>
    <tr>
        <td>เลขที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_SearchDocNumber" runat="server"></asp:TextBox>
        </td>
        <td>ชื่อ : </td>
        <td>
            <asp:TextBox ID="txt_SearchName" runat="server"></asp:TextBox>
        </td>
        <td>จำนวนเงิน : </td>
        <td>
            <asp:DropDownList ID="dl_HighOrLow" runat="server" AutoPostBack="True" Width="50px">
                <asp:ListItem Value="0">=</asp:ListItem>
                <asp:ListItem Value="1">&gt;</asp:ListItem>
                <asp:ListItem Value="2">&lt;</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:TextBox ID="txt_SearchAmount" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>