<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_deka_add2.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_deka_add2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="Panel2" runat="server" GroupingText="รับเรื่องเบิกเงินงบประมาณ">
    <br />
    <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="rg_list" runat="server" AutoGenerateColumns="false" AllowMultiRowSelection="true" GridLines="None" Width="100%"  ShowFooter="true" Skin="Office2010Silver" CellSpacing="0">
                    <HeaderStyle Height="40px" />

                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="BUDGET_DISBURSE_BILL_ID">
                        <Columns>
                             <telerik:GridClientSelectColumn UniqueName="chkColumn" HeaderStyle-Width="20px"></telerik:GridClientSelectColumn>

                            <telerik:GridBoundColumn UniqueName="BUDGET_DISBURSE_BILL_ID" HeaderText="BUDGET_DISBURSE_BILL_ID" HeaderStyle-Width="20px" DataField="BUDGET_DISBURSE_BILL_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" HeaderStyle-Width="20px" DataField="IDA" Display="false">
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn UniqueName="GFMIS_NUMBER" HeaderText="GFMIS_NUMBER" HeaderStyle-Width="20px" DataField="GFMIS_NUMBER" Display="false">
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn UniqueName="GFMIS_DATE" HeaderText="GFMIS_DATE" HeaderStyle-Width="20px" DataField="GFMIS_DATE" Display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn UniqueName="GFMIS_NUMBER" HeaderText="เลข GFMIS" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <center>
                                       <telerik:RadTextBox runat="server"  ItemStyle-HorizontalAlign="Right"  ID="GFMIS_NUMBER" Width="70%" ></telerik:RadTextBox>
                              
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        
                            <telerik:GridTemplateColumn UniqueName="GFMIS_DATE" HeaderText="วันที่ GFMIS" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <center>
                                        <%--<telerik:RadTextBox runat="server"  ItemStyle-HorizontalAlign="Right" ID="GFMIS_DATE" Width="70%"  ></telerik:RadTextBox>--%>
                                        <telerik:RadDatePicker ID="GFMIS_DATE" runat="server" Width="150px"></telerik:RadDatePicker>

                                             <%--<telerik:RadComboBox ID="GFMIS_DATE" runat="server" Width="70%"></telerik:RadComboBox>--%>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                                 <telerik:GridBoundColumn UniqueName="BILL_NUMBER" HeaderText="เลขรับเบิก" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="BILL_NUMBER" HeaderStyle-Width="50px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BILL_DATE" HeaderText="วันที่รับ" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="BILL_DATE" HeaderStyle-Width="80px" DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn UniqueName="DOC_NUMBER" HeaderText="เลขที่เอกสาร" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="DOC_NUMBER" HeaderStyle-Width="80px">
                            </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="DOC_DATE" HeaderText="วันที่เอกสาร" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="DOC_DATE" HeaderStyle-Width="80px" DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn UniqueName="DEPARTMENT_DESCRIPTION" HeaderText="กองผู้เบิก" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="DEPARTMENT_DESCRIPTION" HeaderStyle-Width="250px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับที่" DataField="RowNumber" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20px">
                            </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn UniqueName="BillRec" HeaderText="เลขที่จ่าย/ปี" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="BillRec" HeaderStyle-Width="50px">
                            </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn UniqueName="sum_amount" HeaderText="จำนวนเงิน" DataField="sum_amount" DataFormatString="{0:###,###.00}" ItemStyle-HorizontalAlign="Right"
                               HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="90px">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                          <%--  <telerik:GridBoundColumn UniqueName="sum_amount" HeaderText="จำนวนเงิน" DataField="sum_amount" DataFormatString="{0:###,###.00}" ItemStyle-HorizontalAlign="Right"
                                Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.00}" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="90px" FooterStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>--%>

                        </Columns>
                    </MasterTableView>
                     <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

                </telerik:RadGrid>
            </td>
        </tr>
    </table>

 <%--   <table width="100%">
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:Button ID="btn_CusSave" runat="server" Height="35px" Width="13%" Text="บันทึกเรื่องเบิก" />
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
