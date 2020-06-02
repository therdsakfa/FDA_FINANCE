<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Report_Dept_Budget_Adjust_Sub.ascx.vb" Inherits="FDA_FINANCE.UC_Report_Dept_Budget_Adjust_Sub" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td>ปีงบประมาณ :</td>
        <td><asp:DropDownList ID="dd_BudgetYear" runat="server" Width="100px" DataTextField="byear" DataValueField="byear" AutoPostBack="true">
        </asp:DropDownList>
         </td>
        <td>หน่วยงาน :</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true" Width="200px">

            </asp:DropDownList>
        </td>
        <td></td>
        <td>
            งบประมาณ : 
        </td>
        <td>
             <asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" class="ddl" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Font-Names="TH SarabunPSK" Font-Size="14" Width="200px">
             </asp:DropDownList>
            <asp:Label ID="Label1" runat="server"  style="display:none"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td >
            <asp:Label ID="lb_sub_bg" runat="server" Text="ประเภทงบย่อย :" style="display:none;"></asp:Label>
        </td>
        <td colspan="6">
            <asp:DropDownList ID="dd_sub_bg" runat="server" AutoPostBack="true" Font-Names="TH SarabunPSK" 
                 Font-Size="14" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" style="display:none;">
             </asp:DropDownList>
        </td>
    </tr>

</table>