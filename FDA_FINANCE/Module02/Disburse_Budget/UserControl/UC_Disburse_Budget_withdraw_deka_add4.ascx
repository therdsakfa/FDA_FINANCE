<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_deka_add4.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_deka_add4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Panel ID="Panel4" runat="server" GroupingText="รายละเอียดหลังฏีกา">
  <br />
    <table width="100%">
        
        <tr>
          <td align="right"> <asp:DropDownList ID="dd_budget" DataTextField="BUDGET_NAME" DataValueField="BUDGET_ID" runat="server" Height="35px" Width="30%"></asp:DropDownList> &nbsp; <asp:Button ID="btn_add" runat="server" Height="35px" Width="15%" Text="เพิ่มค่าใช้จ่าย" /></td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>

         <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="rg_list" runat="server" AutoGenerateColumns="false" GridLines="None" Width="100%" ShowFooter="true" Skin="Office2010Silver" CellSpacing="0">
                    <HeaderStyle Height="40px" />

                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="gd_IDA">
                        <Columns>

                            <telerik:GridBoundColumn UniqueName="gd_IDA" HeaderText="gd_IDA" HeaderStyle-Width="10px" DataField="gd_IDA" Display="false">
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="g_IDA" HeaderText="g_IDA" HeaderStyle-Width="10px" DataField="g_IDA" Display="false">
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="h_IDA" HeaderText="h_IDA" HeaderStyle-Width="10px" DataField="h_IDA" Display="false">
                            </telerik:GridBoundColumn>
                             <telerik:GridTemplateColumn UniqueName="PURCHASE" HeaderText="วิธีจัดซื้อ" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <center>
                                          <telerik:RadComboBox ID="ddl_how_buy" runat="server" filter="Contains" Width="90%"></telerik:RadComboBox>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                                

                             <telerik:GridBoundColumn UniqueName="BUDGET_NAME" HeaderText="ประเภท" HeaderStyle-Width="10px" DataField="BUDGET_NAME" >
                            </telerik:GridBoundColumn>

<%--                              <telerik:GridTemplateColumn UniqueName="BUDGET_NAME" HeaderText="ประเภท" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <center>
                                          <telerik:RadComboBox ID="ddl_budget_name" runat="server" filter="Contains" Width="120%"></telerik:RadComboBox>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>

                                  <telerik:GridTemplateColumn UniqueName="LIST_NAME" HeaderText="รายการ" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <center>
                                        <telerik:RadTextBox runat="server"  ItemStyle-HorizontalAlign="Right"  ID="LIST_NAME" Width="90%" ></telerik:RadTextBox>

                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn UniqueName="Amount" HeaderText="จำนวนเงินขอเบิก" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <center>
                                <%--        <telerik:RadTextBox runat="server"  ItemStyle-HorizontalAlign="Right"  ID="Amount" Width="70%" ></telerik:RadTextBox>--%>

                                         <telerik:RadNumericTextBox ID="Amount" runat="server"  Culture="th-TH" DbValueFactor="1"  Value="0" EnabledStyle-HorizontalAlign="Right" Width="70%" >

                                    </telerik:RadNumericTextBox>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>


                    <%--   <telerik:GridBoundColumn UniqueName="sum_amount" HeaderText="จำนวนเงิน" DataField="sum_amount" DataFormatString="{0:###,###.00}" ItemStyle-HorizontalAlign="Right"
                                Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.00}" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="90px" FooterStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>--%>

                        </Columns>
                    </MasterTableView>
           

                </telerik:RadGrid>
            </td>
        </tr>
    </table>

<%--    <table width="100%">
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:Button ID="btn_Save" runat="server" Height="35px" Width="13%" Text="บันทึก" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>--%>
    </asp:Panel>
