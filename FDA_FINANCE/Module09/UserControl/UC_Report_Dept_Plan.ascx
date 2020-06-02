<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Report_Dept_Plan.ascx.vb" Inherits="FDA_FINANCE.UC_Report_Dept_Plan" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td>หน่วยงาน :</td>
        <td>
            <asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true">

            </asp:DropDownList>
        </td>
        <td></td>
        <td>
            งบประมาณ : 
        </td>
        <td>
             <telerik:RadComboBox ID="rcb_budget" Runat="server" Width="300px" Height="300px" 
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
                </telerik:RadComboBox>
        </td>
    </tr>

</table>