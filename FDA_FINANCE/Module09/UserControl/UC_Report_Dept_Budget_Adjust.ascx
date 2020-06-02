<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Report_Dept_Budget_Adjust.ascx.vb" Inherits="FDA_FINANCE.UC_Report_Dept_Budget_Adjust" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td>หน่วยงาน :</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true">

            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>
        <td>
            งบประมาณ : 
        </td>
        <td>
             <%--<telerik:RadComboBox ID="rcb_budget" Runat="server" Width="300px" Height="300px" 
                    EmptyMessage="เลือกงบประมาณ" AutoPostBack="true" AllowCustomText="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="" />
                        </Items>
                    <ItemTemplate>
                        <div id="div1" onclick="StopPropagation(event)">
                            <telerik:RadTreeView ID="rtv_budget_node" runat="server" 
                                 OnClientNodeClicking="OnClientNodeClickingHandler">
                             </telerik:RadTreeView>
                        </div>
                    </ItemTemplate>
                </telerik:RadComboBox>--%>

            <asp:DropDownList ID="dd_BudgetAdjust" runat="server" class="ddl" AutoPostBack="true" 
                    DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
                </asp:DropDownList>
            <asp:Label ID="Label1" runat="server"  style="display:none"></asp:Label>
        </td>
    </tr>
</table>