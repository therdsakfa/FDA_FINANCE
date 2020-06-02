<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_PO_Detail_Table.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_PO_Detail_Table" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel2" runat="server" GroupingText="รายการจำนวนเงินที่ใช้">

    <table>
        
        <tr>
            <td>

                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None" width="100%" ShowFooter="true">
                    <MasterTableView>
                        <Columns>
                            
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GL_ID" HeaderText="GL_ID" DataField="GL_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DETAIL_ID" HeaderText="DETAIL_ID" DataField="DETAIL_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BUDGET_PLAN_ID" HeaderText="BUDGET_PLAN_ID" DataField="BUDGET_PLAN_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="proj_code" HeaderText="รหัสกิจกรรม/โครงการ" DataField="proj_code" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CUSTOMER_NAME" HeaderText="ชื่อผู้รับเงิน/เจ้าหนี้" DataField="CUSTOMER_NAME" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CUSTOMER_ID" HeaderText="CUSTOMER_ID" DataField="CUSTOMER_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GL_NAME" HeaderText="ค่าใช้จ่าย" DataField="GL_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="AMOUNT" HeaderText="จำนวนเงินผูกพัน" DataField="AMOUNT" DataFormatString="{0:###,###.##}" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="balance" HeaderText="จำนวนเงินที่เบิกได้" DataField="balance" DataFormatString="{0:###,###.##}" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="amount_key">
                                <ItemTemplate>
                                    <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="80px">
                                    </telerik:RadNumericTextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

            </td>
        </tr>
    </table>
</asp:Panel>