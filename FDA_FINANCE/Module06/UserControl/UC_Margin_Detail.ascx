<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Margin_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Margin_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>

    <tr>
        <td align="right">ประเภท :</td>
        <td>
            <asp:DropDownList ID="ddl_DO_TYPE" runat="server">
                <asp:ListItem Value="1">ฝาก</asp:ListItem>
                <asp:ListItem Value="2">ถอน</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="right">วันที่ : </td>
        <td>
            <asp:TextBox ID="txt_DO_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">รายละเอียด : </td>
        <td>
            <asp:TextBox ID="txt_DESCRIPITON" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_BUDGET_TYPE_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
            &nbsp; บาท
        </td>
    </tr>
</table>