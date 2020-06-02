<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_DetailV3_Table.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_DetailV3_Table" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel2" runat="server" GroupingText="รายการค่าใช้จ่าย">
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td align="right">บัญชี :</td>
                <td>

                    <asp:DropDownList ID="ddl_acount" runat="server" class="ddl" DataTextField="MONEY_TYPE_DESCRIPTION" DataValueField="MONEY_TYPE_ID" Width="200px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td align="right">ผู้รับเงิน/เจ้าหนี้ :
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="CUSTOMER_ID" DataTextField="CUSTOMER_NAME" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>*
                            </td>
                        </tr>
                    </table>


                </td>
            </tr>

            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="lb_paylist" runat="server" Text="ค่าใช้จ่าย :"></asp:Label>
                </td>
                <td valign="top">
                    <asp:DropDownList ID="ddl_GL" runat="server" DataTextField="GL_NAME" DataValueField="IDA" Width="200px">
                    </asp:DropDownList>
                    *</td>
            </tr>
            <tr>
                <td align="right">จำนวนเงิน : </td>
                <td>
                    <telerik:RadNumericTextBox ID="rnt_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
                    </telerik:RadNumericTextBox>
                    &nbsp;บาท*</td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btn_add_bg" runat="server" Text="บันทึก" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table>
        
        <tr>
            <td>

                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None" width="100%" ShowFooter="true">
                    <MasterTableView>
                        <Columns>
                            
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DETAIL_ID" HeaderText="DETAIL_ID" DataField="DETAIL_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BUDGET_DISBURSE_BILL_ID" HeaderText="BUDGET_DISBURSE_BILL_ID" DataField="BUDGET_DISBURSE_BILL_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BUDGET_PLAN_ID" HeaderText="BUDGET_PLAN_ID" DataField="BUDGET_PLAN_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CUSTOMER_NAME" HeaderText="ชื่อผู้รับเงิน/เจ้าหนี้" DataField="CUSTOMER_NAME" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GL_NAME" HeaderText="ค่าใช้จ่าย" DataField="GL_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="AMOUNT" HeaderText="จำนวนเงิน" DataField="AMOUNT" DataFormatString="{0:###,###.##}" Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.##}" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del" >
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

            </td>
        </tr>
    </table>
</asp:Panel>