<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_DepositMoney_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_Deposit_Money_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table style="border:1px solid black;">
    <tr>
        <td align="right">วันที่รับเงิน : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_DEPOSIT_DATE" runat="server"></telerik:RadDatePicker>--%>
            <asp:Label ID="rdp_RECEIVE_DATE" runat="server" Text="" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">บร. เล่มที่/เลขที่ : </td>
        <td>
            <%--<asp:TextBox ID="txt_RECEIPT_VOLUME" runat="server"></asp:TextBox>--%>
            <asp:Label ID="txt_RECEIPT_VOLUME" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">รายการย่อยนำเงินเข้า : </td>
        <td>
            <%--<asp:TextBox ID="txt_DEPOSIT_DESCRIPTION" runat="server"></asp:TextBox>--%>
            <asp:Label ID="txt_DEPOSIT_DESCRIPTION" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">ประเภทเงิน : </td>
        <td>
            <asp:RadioButtonList ID="rbl_MONEY_TYPE_DESCRIPTION" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Value="1" Selected="True">เงินสด</asp:ListItem>
                <asp:ListItem Value="2">เช็ค</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <%--<asp:TextBox ID="txt_DEPOSIT_AMOUNT" runat="server"></asp:TextBox>--%>
            <asp:Label ID="txt_DEPOSIT_AMOUNT" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">วันที่นำฝากเงิน : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_DEPOSIT_DATE" runat="server"></telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_DEPOSIT_DATE" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">รายละเอียด:</td>
        <td>
            <asp:TextBox ID="txt_Detail" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลข GF : </td>
        <td>
            <asp:TextBox ID="txt_GF_NUMBER" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
</table>