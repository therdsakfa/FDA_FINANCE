<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DepartmentHead.ascx.vb" Inherits="FDA_FINANCE.UC_DepartmentHead" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
<table width="900px">
<tr>
    
<td>
    <telerik:RadTreeView ID="RadTreeView1" runat="server">
    </telerik:RadTreeView>
</td>
<td>
        <table>
            <tr>
                <td align="right">
                    กระทรวง :
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    กรม :
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    กอง :
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    หน่วยงานย่อย :
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table width="100%">
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" 
                        AutoGenerateColumns="false" Width="100%">
                        <MasterTableView>
                            <Columns>
                            
                                <telerik:GridBoundColumn HeaderText="ลำดับ" >
                                <ItemStyle Width="10%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="รหัสพื้นที่">
                                <ItemStyle Width="30%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="รหัสศูนย์ต้นทุน">
                                <ItemStyle Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ชื่อย่อ">
                                <ItemStyle Width="20%" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        </telerik:RadGrid>
                </td>
            </tr>
        </table>

</td>
</tr>
</table>