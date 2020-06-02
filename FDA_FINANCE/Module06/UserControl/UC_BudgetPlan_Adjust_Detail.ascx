<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BudgetPlan_Adjust_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_BudgetPlan_Adjust_Insert" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="จัดสรร">
<table>
    <tr>
<td align="right">
        จากโครงการ : 
    </td>
    <td>
        <asp:Label ID="lb_Project" runat="server" ></asp:Label>
    </td>

    </tr>
    <tr>
<td align="right">
        ชื่องบประมาณ : 
    </td>
    <td>
        <asp:Label ID="lbBudget" runat="server" ></asp:Label>
    </td>

    </tr>
<tr>
<td align="right">
        หน่วยงาน : 
    </td>
    <td>
        <%--<asp:Label ID="lb_Department" runat="server" ></asp:Label>--%>
        <asp:DropDownList ID="dd_Department" runat="server" AutoPostBack="true" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID">
                        </asp:DropDownList>
    </td>
</tr>

<tr>
    <td align="right">
        จำนวนเงินที่ได้รับการจัดสรร : 
    </td>
    <td>
        <telerik:RadNumericTextBox ID="rnt_BUDGET_AMOUNT" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
        </telerik:RadNumericTextBox>
    </td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" GroupingText="รับงวด">
    <table>
    <tr>
        <td>เลขที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server" Text="-"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>วันที่ออกหนังสือ : </td>
        <td>
            <asp:TextBox ID="txt_DOC_DATE" runat="server" Text="01/10/2558"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>วันที่ส่งออก : </td>
        <td>
            <asp:TextBox ID="txt_EXPORT_DATE" runat="server" Text="01/10/2558"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>รายละเอียด : </td>
        <td>
            <asp:TextBox ID="txt_DESCRIPTION" runat="server" Width="250px" Height="60px" Text="งวด 1"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>
