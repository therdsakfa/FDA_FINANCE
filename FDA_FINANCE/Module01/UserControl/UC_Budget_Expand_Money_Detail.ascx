<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Expand_Money_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Expand_Money_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
<tr>
<td align="right">
จำนวนเงินขยายเงินกัน :
</td>
<td>
    <telerik:RadNumericTextBox ID="rnt_EXPAND_AMOUNT" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Type="Currency" Value="0" Width="160px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="฿n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
    </telerik:RadNumericTextBox>
&nbsp;บาท</td>
</tr>

<tr>
<td align="right">
    ขยายถึงวันที่ :
</td>
<td>
    <telerik:RadDatePicker ID="rdp_OVERLAP_EXPAND_DATE" runat="server">
    </telerik:RadDatePicker>
</td>
</tr>
<tr>
<td align="right">

    เงินขยายเงินกัน : </td>
<td>
    <asp:RadioButtonList ID="rd_IS_OVERLAP_EXPAND" runat="server" RepeatDirection="Horizontal" >
        <asp:ListItem Value="True">เงินขยาย</asp:ListItem>
        <asp:ListItem Value="False">ยกเลิก</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>
</table>