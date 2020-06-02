<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReceiveMoney_Detail_MoneyType.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReceiveMoney_Detail_MoneyType" %>
<table width="900px">
    <tr>
        <td align="right" style="width:10%">ประเภทเงิน : </td>
        <td style="width:15%">
            <%--<asp:TextBox ID="txt_MoneyType" runat="server"></asp:TextBox>--%>
            <asp:Label ID="lb_level1" runat="server" Text="" ></asp:Label>
        </td>
        <td align="right" style="width:10%">รายการประเภทเงิน : </td>
        <td style="width:15%">
            <%--<asp:TextBox ID="txt_MoneyType_List" runat="server"></asp:TextBox>--%>
            <asp:Label ID="lb_level2" runat="server" Text="" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" style="width:10%">รายการย่อย 1 : </td>
        <td style="width:15%">
            <%--<asp:TextBox ID="txt_List_1" runat="server"></asp:TextBox>--%>
            <asp:Label ID="lb_level3" runat="server" Text="" ></asp:Label>
        </td>
        <td align="right" style="width:10%">รายการย่อย 2 : </td>
        <td style="width:15%">
            <%--<asp:TextBox ID="txt_List_2" runat="server"></asp:TextBox>--%>
            <asp:Label ID="lb_level4" runat="server" Text="" ></asp:Label>
        </td>
    </tr>
</table>