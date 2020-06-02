<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_PO_Detail_Table2.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_PO_Detail_Table2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel2" runat="server" GroupingText="รายการจำนวนเงินที่ใช้">

    <table>
    <%--    <tr>
            <td>
                <asp:DropDownList ID="ddl_period" runat="server" DataTextField="PERIOD" DataValueField="PERIOD_ID"></asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td>

                <telerik:RadGrid ID="RadGrid1" runat="server" AllowMultiRowSelection="True"  AutoGenerateColumns="false" GridLines="None" width="100%" ShowFooter="true">
                                      <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                                <Selecting AllowRowSelect="true"/>
                            </ClientSettings>

                      <MasterTableView>
                        <Columns>
                         <telerik:GridClientSelectColumn UniqueName="chkColumn" HeaderText="เลือก"/> 
                        <telerik:GridBoundColumn DataField="PERIOD_ID" HeaderText="งวดที่" UniqueName="PERIOD_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="IS_BERG" Display="false" HeaderText="IS_BERG" UniqueName="IS_BERG">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="PERIOD" Display="false" HeaderText="PERIOD" UniqueName="PERIOD">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RELATE_DETAIL_ID" Display="false" HeaderText="RELATE_DETAIL_ID" UniqueName="RELATE_DETAIL_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RELATE_ID" Display="false" HeaderText="RELATE_ID" UniqueName="RELATE_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BUDGET_PLAN_ID" Display="false" HeaderText="BUDGET_PLAN_ID" UniqueName="BUDGET_PLAN_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CUSTOMER_ID" Display="false" HeaderText="CUSTOMER_ID" UniqueName="CUSTOMER_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GL_ID" Display="false" HeaderText="GL_ID" UniqueName="GL_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="proj_code" HeaderText="รหัสกิจกรรม/โครงการ" UniqueName="proj_code">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CUSTOMER_NAME" HeaderText="ชื่อผู้รับเงิน/เจ้าหนี้" UniqueName="CUSTOMER_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GL_NAME" HeaderText="ค่าใช้จ่าย" UniqueName="GL_NAME">
                        </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="PERIOD_AMOUNT" HeaderText="จำนวนเงินประจำงวด" DataField="PERIOD_AMOUNT" DataFormatString="{0:###,###.##}" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                           
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

            </td>
        </tr>
    </table>
</asp:Panel>