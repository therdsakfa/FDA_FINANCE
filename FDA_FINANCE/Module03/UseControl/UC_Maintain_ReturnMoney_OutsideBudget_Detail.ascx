<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_OutsideBudget_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_OutsideBudget_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table style="border:1px solid black;">
<tr>
        <td align="right">ประเภทการจ่าย : </td>
        <td>
            <asp:RadioButtonList ID="rbl_MONEY_TYPE_DESCRIPTION" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">เงินสด</asp:ListItem>
                <asp:ListItem Value="2">เช็ค</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="right">วันที่คืนเงิน : </td>
        <td>
<%--          --%>  
            <asp:TextBox ID="txt_return_date" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td align="right">วันที่เอกสารส่งใช้หนี้ : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_DOC_DATE" runat="server"></telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_DOC_DATE" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
        <td align="right">
        เลขที่เอกสารส่งใช้หนี้ : 
        </td>
        <td>
        <asp:TextBox ID="txt_DOC_NUMBER" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">บ. เล่มที่ : </td>
        <td>
            <asp:TextBox ID="txt_DISBURSE_VOLUME" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
        <td align="right">บ. เลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_DISBURSE_NUMBER" runat="server"  class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">รายละเอียดการคืน : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_DESCRIPTION" runat="server" class="validate[required] text-input" TextMode="MultiLine" Width="250px" Height="70px"></asp:TextBox>
        </td>
        <td align="right">จำนวนเงินที่คืน : </td>
        <td>
            <telerik:RadNumericTextBox ID="txt_RETURN_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
        &nbsp;บาท</td>

    </tr>
    <tr>
        <td align="right">ชื่อผู้รับเงิน :</td>
        <td colspan="3">
            <asp:Label ID="lb_money_receiver" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
</table>