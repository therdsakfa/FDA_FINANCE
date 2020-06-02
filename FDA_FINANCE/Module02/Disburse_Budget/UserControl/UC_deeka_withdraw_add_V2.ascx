<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_deeka_withdraw_add_V2.ascx.vb" Inherits="FDA_FINANCE.UC_deeka_withdraw_add_V2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style1 {
        height: 26px;
    }
</style>
<table>
    <tr>
        <td>
            วันที่ทำฏีกา : 
        </td>
        <td>
                      <asp:TextBox ID="deeka_date" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            ชื่อผู้เบิก :
        </td>
        <td>
            <asp:DropDownList ID="dd_cus" AutoPostBack="true" DataTextField="CUSTOMER_NAME" DataValueField="CUSTOMER_ID" runat="server" Height="16px"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            รายการ
        </td>
        <td>
            <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" Width="300px" Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
             ประเภทเงิน :
        </td>
        <td>
            <asp:DropDownList ID="list_money" runat="server">
                <asp:ListItem Value="1">ค่าวัสดุ</asp:ListItem>
                <asp:ListItem Value="2">ค่าใช้สอย</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            ประจำเดือน :
        </td>
        <td>
            <asp:DropDownList id="dd_month" runat="server">
                <asp:ListItem Value="1">มกราคม</asp:ListItem>
                <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                <asp:ListItem Value="4">เมษายน</asp:ListItem>
                <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                <asp:ListItem Value="7">กรกฏาคม</asp:ListItem>
                <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                <asp:ListItem Value="9">กันยายน</asp:ListItem>
                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            งบประมาณปี พ.ศ. :
        </td>
        <td>
            <asp:DropDownList ID="dd_BudgetYear" runat="server" AutoPostBack="true" DataTextField="BUDGET_YEAR" DataValueField="BUDGET_YEAR">
                
                        </asp:DropDownList> 
                         
        </td>
    </tr>
    <tr>
        <td>
            หมวดรายจ่าย งปม. :
        </td>
        <td>
            <asp:DropDownList ID="ddl_GL" runat="server" DataTextField="GL_NAME" DataValueField="IDA" Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
    <%--<tr>
        <td>
            ประเภทการจ่าย : 
        </td>
        <td>
            <asp:DropDownList ID="dd_deeka_list_pay" runat="server">
                <asp:ListItem Value="1">วางฏีกา</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>--%>
    <tr>
        <td>
            เงินขอเบิก :
        </td>
        <td>
            <%--<asp:TextBox ID="deeka_amount" runat="server"></asp:TextBox> --%>
            <telerik:RadNumericTextBox ID="rnt_amount" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
             </telerik:RadNumericTextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            ภาษี :
        </td>
        <td class="auto-style1">
            <telerik:RadNumericTextBox ID="rnt_tax" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
             </telerik:RadNumericTextBox>
        </td>
    </tr>
</table>