<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReceiveMoney_Detail_Money.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReceiveMoney_Detail_Money" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width="900px">
    <tr>
        <td align="right">ประเภทเงินที่รับ : </td>
        <td>
            <asp:RadioButtonList ID="rbl_RECEIVE_MONEY_TYPE" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">เงินสด</asp:ListItem>
                <asp:ListItem Value="2">เช็ค</asp:ListItem>
                <asp:ListItem Value="3">โอน</asp:ListItem>
                <asp:ListItem Value="4">ยกเลิก</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td align="right">ผู้นำส่งเงิน : </td>
        <td>
            <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="CUSTOMER_ID" DataTextField="CUSTOMER_NAME">
            </asp:DropDownList>

        </td>
       <%-- <td align="right">จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="txt_RECEIVE_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
        &nbsp;บาท</td>--%>
    </tr>
    <tr>
        <td align="right">หน่วยงาน :</td>
        <td>
            <asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID">

            </asp:DropDownList> 

        </td>
    </tr>
    <tr>
        <td align="right">รายการ : </td>
        <td>
            <asp:TextBox ID="txt_RECEIVE_MONEY_DESCRIPTION" runat="server" class="validate[required] text-input" TextMode="MultiLine" Width="250px" Height="70px"></asp:TextBox>
        </td>
       <%-- <td align="right">เงินที่รับ : </td>
        <td>
            <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px" AutoPostBack="true"></telerik:RadNumericTextBox>
        &nbsp;บาท</td>--%>
    </tr>
    <tr>
        <td align="right">ผู้รับเงิน : </td>
        <td>
            <asp:Label ID="lb_receiver" runat="server" Text="-"></asp:Label>
        </td>
        <%--<td align="right">เงินทอน : </td>
        <td>
            <telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
        &nbsp;บาท</td>--%>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน :</td>
        <td>
            <telerik:RadNumericTextBox ID="txt_RECEIVE_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
        &nbsp; บาท</td>
        <%--<td align="right">&nbsp;</td>
        <td>
            &nbsp;</td>--%>
    </tr>
</table>