<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Money_Type_Node.ascx.vb" Inherits="FDA_FINANCE.UC_Money_Type_Node" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table>
    <tr>
        <td>
            ประเภทเงิน : 
        </td>
        <td>
             <telerik:RadComboBox ID="rcb_money_type" Runat="server" Width="300px" Height="300px" 
                    EmptyMessage="เลือกประเภทเงิน"  AllowCustomText="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="" />
                        </Items>
                    <ItemTemplate>
                        <div id="div1" onclick="StopPropagation(event)">
                            <telerik:RadTreeView ID="rtv_money_type_node" runat="server" 
                                 OnClientNodeClicking="OnClientNodeClickingHandler">
                             </telerik:RadTreeView>
                        </div>
                    </ItemTemplate>
                </telerik:RadComboBox>
        </td>
    </tr>

</table>