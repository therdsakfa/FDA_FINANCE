<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_add_Part2.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_add_Part2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Panel ID="panel_2" runat="server" GroupingText="บันทึกเจ้าหนี้" Width="100%">

    <table width="100%">
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rg_list" runat="server" AutoGenerateColumns="false" GridLines="None" Width="100%" ShowFooter="true" Skin="Office2010Silver" CellSpacing="0">
                    <HeaderStyle Height="40px" />
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="DETAIL_ID">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="DETAIL_ID" HeaderText="DETAIL_ID" DataField="DETAIL_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="TAX_TYPE" HeaderText="TAX_TYPE" DataField="TAX_TYPE" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="PurchaseItemsId" HeaderText="PurchaseItemsId" DataField="PurchaseItemsId" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="nMulct" HeaderText="nMulct" DataField="nMulct" Display="false">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="nVat" HeaderText="nVat" DataField="nVat" Display="false">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="nInsurance" HeaderText="nInsurance" DataField="nInsurance" Display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CUSTOMER_TYPE" HeaderText="ประเภทเจ้าหนี้" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="CUSTOMER_TYPE" HeaderStyle-Width="150px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CUSTOMER_NAME" HeaderText="ชื่อเจ้าหนี้" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" DataField="CUSTOMER_NAME" HeaderStyle-Width="200px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="AMOUNT" HeaderText="จำนวนเงินขอเบิก" DataField="AMOUNT" DataFormatString="{0:###,###.00}" ItemStyle-HorizontalAlign="Right"
                                Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.00}" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="90px" FooterStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn UniqueName="txtMulct" HeaderText="ค่าปรับ" HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <center>
                                         <telerik:RadNumericTextBox ID="nMulct" runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" EnabledStyle-HorizontalAlign="Right" Width="100px">

                                    </telerik:RadNumericTextBox>
                                            <%--<telerik:RadTextBox runat="server"  ItemStyle-HorizontalAlign="Right"  ID="nMulct" Width="70%" DataFormatString="{0:###,###.00}"></telerik:RadTextBox>--%>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn UniqueName="txtVat" HeaderText="ภาษี" HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <center>
                                         <telerik:RadNumericTextBox ID="nVat" runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" EnabledStyle-HorizontalAlign="Right" Width="100px">

                                    </telerik:RadNumericTextBox>
                                            <%--<telerik:RadTextBox runat="server" ID="nVat"   ItemStyle-HorizontalAlign="Right"  Width="70%" DataFormatString="{0:###,###.00}"  ></telerik:RadTextBox>--%>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn UniqueName="txtInsurance" HeaderText="เงินประกันผลงาน" HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <center>
                                         <telerik:RadNumericTextBox ID="nInsurance" runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" EnabledStyle-HorizontalAlign="Right" Width="100px">

                                    </telerik:RadNumericTextBox>
                                            <%--<telerik:RadTextBox runat="server" ID="nInsurance"  ItemStyle-HorizontalAlign="Right"  Width="70%" DataFormatString="{0:###,###.00}"  ></telerik:RadTextBox>--%>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn UniqueName="nAmountMoney" HeaderText="เงินสุทธิ" DataField="nAmountMoney" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###.00}"
                                Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.00}" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="100px" FooterStyle-HorizontalAlign="Right">
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                             <telerik:GridTemplateColumn UniqueName="PurchaseItems" HeaderText="รายการซื้อ/จ้าง" HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <center>
                                          <telerik:RadComboBox ID="ddl_PurchaseItems" runat="server" filter="Contains"></telerik:RadComboBox>
                                    </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:Button ID="btn_CusSave" runat="server" Height="35px" Width="11%" Text="บันทึกเจ้าหนี้" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>

</asp:Panel>
