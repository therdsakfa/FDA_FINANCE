<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Debtor_Change_List_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Debtor_Change_List_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width ="400">
    <tr>
        <td align="right">เลขที่ บฝ :</td>
        <td>
            <asp:TextBox ID="txt_BT_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">วันที่โอน :</td>
        <td>
            <asp:TextBox ID="txt_CHANGE_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">รายละเอียดการโอน :</td>
        <td>
            <asp:TextBox ID="txt_CHANGE_DESCRIPTION" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">รายละเอียดใบเบิก : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"   TextMode="MultiLine" Height="40px" Width="100%"> </asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server"    Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:RadNumericTextBox>
           &nbsp;บาท</td>
    </tr>
</table>