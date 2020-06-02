<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_add.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_add" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียด">
   
</asp:Panel>--%>

<table width="80%">
    <tr>
        <td>
            <br /><br />
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 20%">ปีงบประมาณ :
        </td>
        <td style="width: 20%">
            <asp:TextBox ID="txt_year" runat="server" Height="30px" Width="80%" Enabled="false"></asp:TextBox>
        </td>

        <td style="width: 60%">เลขที่รับเรื่องเบิกเงิน งปม. :
                <asp:TextBox ID="txt_withdraw_bill" runat="server" Width="20%" Enabled="false" Height="30px"  CssClass="form-control"></asp:TextBox>   
        </td>
    </tr>

    <tr>
        <td align="right" style="width: 20%">วันที่รับ :</td>
        <td style="width: 20%">
            <asp:TextBox ID="txt_wd_date" runat="server" Height="30px" Width="80%"></asp:TextBox>
        </td>
    </tr>
</table>

<table width="80%">
      <tr>
        <td align="right" style="width: 20%">เรื่อง : </td>

        <td style="width: 80%">
            <asp:TextBox ID="txt_Descript" runat="server" Height="30px" Width="520px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
</table>

<table width="80%">
    <tr>
        <td align="right" style="width: 20%">เลขที่เอกสาร : </td>
        <td style="width: 20%">
            <asp:TextBox ID="txt_DocNumber" runat="server" Height="30px" Width="80%" Enabled="false"></asp:TextBox>
        </td>
        <td style="width: 15%">วันที่เอกสาร :          
        </td>
        <td style="width: 45%">
            <asp:TextBox ID="txt_DocDate" runat="server" Height="30px" Width="35%" Enabled="false"></asp:TextBox>
        </td>
    </tr>
</table>

<table width="80%">
      <tr>
        <td align="right" style="width: 20%">หมวดค่าใช้จ่าย : </td>

        <td style="width: 80%">
            <asp:TextBox ID="txt_bg_group" runat="server" Height="30px" Width="45%" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 20%">แผนงาน : </td>

        <td style="width: 80%">
            <asp:TextBox ID="txt_bg_plan" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 20%">ผลผลิต : </td>

        <td style="width: 80%">
            <asp:TextBox ID="txt_bg_product" runat="server" Height="30px" Width="90%" Enabled="false"> </asp:TextBox>
        </td>
    </tr>
      <tr>
        <td align="right" style="width: 20%">กิจกรรม : </td>

        <td style="width: 80%">
            <asp:TextBox ID="txt_bg_act" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
        </td>
    </tr>
      <tr>
        <td align="right" style="width: 20%">งาน/โครงการ : </td>

        <td style="width: 80%">
            <asp:TextBox ID="txt_bg_project" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
        </td>
    </tr>
</table>

<table width="80%">
    <tr>
        <td align="right" style="width: 20%">ประเภทการจ่าย : </td>
        <td style="width: 20%">
            <asp:DropDownList ID="dd_pay" runat="server" DataValueField="ID" DataTextField="BG_PayTypeName" Height="30px" Width="80%">
            </asp:DropDownList>
        </td>
        <td style="width: 15%">ประเภทการเบิก :          
        </td>
        <td style="width: 45%">
            <asp:DropDownList ID="dd_payW" runat="server" DataValueField="ID" DataTextField="BG_TypeMoneyW" Height="30px" Width="35%">
            </asp:DropDownList>
        </td>
    </tr>

</table>

<table width="80%">
    <tr>
        <td align="right" style="width: 20%">กองผู้เบิก : </td>
        <td style="width: 45%">
            <asp:TextBox ID="txt_Dept" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
        </td>
        <td style="width: 10%">จำนวนเงิน :          
        </td>
        <td style="width: 25%">
            <asp:TextBox ID="txt_amount" runat="server" Height="30px" Width="68%" Enabled="false"></asp:TextBox>
        </td>
    </tr>
</table>


<%--<asp:Panel ID="panel_2" runat="server" GroupingText="บันทึกเจ้าหนี้" Width="80%" Style="display: block">

    <table width="100%">
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

                            <telerik:GridTemplateColumn UniqueName="nMulct" HeaderText="ค่าปรับ" HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <center>
                                         <telerik:RadNumericTextBox ID="nMulct" runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" EnabledStyle-HorizontalAlign="Right" Width="100px">

                                    </telerik:RadNumericTextBox>
                           
                                         </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn UniqueName="nVat" HeaderText="ภาษี" HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <center>
                                         <telerik:RadNumericTextBox ID="nVat" runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" EnabledStyle-HorizontalAlign="Right" Width="100px">

                                    </telerik:RadNumericTextBox>
            
                                          </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn UniqueName="nInsurance" HeaderText="เงินประกันผลงาน" HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <center>
                                         <telerik:RadNumericTextBox ID="nInsurance" runat="server"  Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" EnabledStyle-HorizontalAlign="Right" Width="100px">

                                    </telerik:RadNumericTextBox>
                         
                                         </center>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn UniqueName="nAmountMoney" HeaderText="เงินสุทธิ" DataField="nAmountMoney" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###.00}"
                                Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.00}" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="100px" FooterStyle-HorizontalAlign="Right">
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
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
</asp:Panel>--%>
