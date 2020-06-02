<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_deka_add3.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_deka_add3" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Panel ID="Panel3" runat="server" GroupingText="หมวดรายจ่ายย่อย งบประมาณ">
  <br />
      <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="rg_list" runat="server" AutoGenerateColumns="false" AllowMultiRowSelection="true" ShowFooter="true"  GridLines="None" Width="100%" Skin="Office2010Silver" CellSpacing="0">
                    <HeaderStyle Height="40px" />

                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                        <Columns>

                          <telerik:GridClientSelectColumn UniqueName="chkColumn" HeaderStyle-Width="7px" ></telerik:GridClientSelectColumn>

                            <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" HeaderStyle-Width="20px" DataField="IDA" Display="false">
                            </telerik:GridBoundColumn>
                              
                            <telerik:GridBoundColumn UniqueName="NameOfBudget" HeaderText="หมวดรายจ่ายย่อย" HeaderStyle-Width="650px" DataField="NameOfBudget" >
                            </telerik:GridBoundColumn>

         <%--                     <telerik:GridTemplateColumn UniqueName="" HeaderText="">
                                <ItemTemplate>
                                    <center>
                                          <telerik:RadComboBox ID="ddl_budget_name" runat="server" filter="Contains"></telerik:RadComboBox>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>

                     <%--       <telerik:GridTemplateColumn UniqueName="AMOUNT"  HeaderText="จำนวนเงินขอเบิก" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <center>
                                        <telerik:RadTextBox runat="server" DataFormatString="{0:###,###.00}" ItemStyle-HorizontalAlign="Right"  ID="AMOUNT" Width="70%" ></telerik:RadTextBox>

                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>


<%--                            <telerik:GridBoundColumn UniqueName="AMOUNT" HeaderText="จำนวนเงินขอเบิก" DataField="AMOUNT" DataFormatString="{0:###,###.00}" ItemStyle-HorizontalAlign="Right"
                                Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.00}" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="120px" FooterStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>--%>
                                     <telerik:GridBoundColumn UniqueName="sum_amount" HeaderText="จำนวนเงินขอเบิก" DataField="sum_amount" DataFormatString="{0:###,###.00}" ItemStyle-HorizontalAlign="Right"
                               HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="90px">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
               <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

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

<br />
