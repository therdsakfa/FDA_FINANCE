<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Customer_Add_Cer.ascx.vb" Inherits="FDA_FINANCE.UC_Customer_Add_Cer" %>
<%--<%@ Register Src="~/Module06/UserControl/UC_Customer_Add_CerCancel.ascx" TagName="UC_Customer_Add_CerCancel" TagPrefix="uc1" %>--%>
<%--<%@ Register Src="~/Module06/UserControl/UC_Customer_Add_Cer_Show.ascx" TagName="UC_Customer_Add_Cer_Show" TagPrefix="uc2" %>--%>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .auto-style1 {
        width: 754px;
    }
    .auto-style4 {
        width: 230px;
    }
    .auto-style10 {
        width: 138px;
    }
    .auto-style11 {
        width: 122px;
    }
    .auto-style12 {
        width: 173px;
    }
</style>
<table>
    <tr>
        <td class="auto-style1">
            <asp:Panel ID="Panel3" runat="server" GroupingText="ข้อมูลเลขที่สัญญา" Width="1026px" Height="104px">
                <table>
                <tr>
            <td align="right" class="auto-style10">เลขที่สัญญาจ้าง :</td>
            <td class="auto-style4">
                <asp:TextBox ID="txt_NumCer" runat="server"></asp:TextBox>
                <asp:Label ID="lb_cus_id" runat="server"></asp:Label>
            </td>
             <td align="right" class="auto-style11">
                 วันที่เริ่มสัญญา :
             </td>
                    <td class="auto-style12">
                  
                        
                        <asp:TextBox ID="txt_dateCer" runat="server"></asp:TextBox>
                    </td>
                    
        </tr>
                    <tr>
                        <td align="right" class="auto-style10">
                        วันที่สิ้นสุดสัญญา :
                    </td>
                    <td class="auto-style4">
                        
                        <asp:TextBox ID="txt_dateCerEnd" runat="server"></asp:TextBox>
                    </td>
            <td align="right" class="auto-style11">
                ชื่อหน่วยงาน :
            </td>
            <td class="auto-style12">
                <asp:DropDownList ID="dd_dept" runat="server" AutoPostBack="True" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" DataSourceID="sql_dept"></asp:DropDownList>
            </td>
                    </tr>
                        <tr>
                            <td style="text-align:right">งวดงาน :</td>
                            <td>
                                <asp:TextBox ID="txt_install" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                    
            </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="RadGrid1" runat="server"  Width="692px">
                <MasterTableView autogeneratecolumns="False" datakeynames="CUSTOMER_ID">
                    <Columns>
                        <telerik:GridBoundColumn DataField="CUSTOMER_ID " DataType="System.Int32" FilterControlAltText="Filter CUSTOMER_ID column" HeaderText="CUSTOMER_ID" ReadOnly="True" SortExpression="CUSTOMER_ID" UniqueName="CUSTOMER_ID" Display="false">
                        </telerik:GridBoundColumn>            
                        <telerik:GridBoundColumn DataField="FullName" FilterControlAltText="Filter FullName column" HeaderText="ชื่อเจ้าหนี้" SortExpression="FullName" UniqueName="FullName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CerNum" FilterControlAltText="Filter CerNum column" HeaderText="เลขที่สัญญา" SortExpression="CerNum" UniqueName="CerNum">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CDate" DataType="System.Int32" FilterControlAltText="Filter CDate column" HeaderText="วันที่เริ่มสัญญา" ReadOnly="True" SortExpression="CDate" UniqueName="CDate" Display="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CDateE" DataType="System.Int32" FilterControlAltText="Filter CDateE column" HeaderText="วันที่สิ้นสุดสัญญา" ReadOnly="True" SortExpression="CDateE" UniqueName="CDateE" Display="True">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="AT" DataType="System.Int32" FilterControlAltText="Filter AT column" HeaderText="สถานะ" ReadOnly="True" SortExpression="AT" UniqueName="AT" Display="True">
                        </telerik:GridBoundColumn>--%>
                        
                        <telerik:GridBoundColumn DataField="Cancel" FilterControlAltText="Filter Cancel column" HeaderText="เหตุผลที่ยกเลิกสัญญา" SortExpression="Cancel" UniqueName="Cancel">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CInstall" FilterControlAltText="Filter CInstall column" HeaderText="งวดงาน" SortExpression="CInstall" UniqueName="CInstall">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" ConfirmText="คุณต้องการยกเลิกสัญญาหรือไม่" Text="ยกเลิกสัญญา" CommandName="cancel">
                        </telerik:GridButtonColumn>
                       <%-- <telerik:GridButtonColumn ButtonType="LinkButton" ConfirmText="คุณต้องการลบหรือไม่" Text="ลบ" CommandName="del">
                        </telerik:GridButtonColumn>--%>
                    </Columns>
                </MasterTableView>
                <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true" >

                </ClientSettings>
            </telerik:RadGrid>
        
            <asp:Label ID="lb_Cer_cancel" runat="server" Text="เหตุผลที่ยกเลิกสัญญา :"></asp:Label>
        
            <asp:TextBox ID="txt_Cercancel" runat="server"></asp:TextBox>
            
        
            <asp:Button ID="bt_saveCancel" runat="server" Text="เหตุผลยกเลิกสัญญา" />
       <%--<uc2:UC_Customer_Add_Cer_Show ID="UC_Customer_Add_Cer_Show1" runat="server" />--%>

        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
        </td>
    </tr>
</table>

            
<asp:SqlDataSource ID="sql_dept" runat="server" ConnectionString="<%$ ConnectionStrings:DTAMConnectionString %>" SelectCommand="Select*
From MAS_DEPARTMENT d
Order By DEPARTMENT_ID asc">
            </asp:SqlDataSource>