<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_RELATE_BILL_DETAILV2_Table.ascx.vb" Inherits="FDA_FINANCE.UC_RELATE_BILL_DETAILV2_Table" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel2" runat="server" GroupingText="เรื่องจำนวนเงินที่ใช้">
<table >
    <tr>
        <td align="right" >รหัสกิจกรรม :</td>
        <td >
            <table width="100%">
                <tr>
                    <td style="width: 70%">
                        <asp:DropDownList ID="dd_BudgetAdjust" runat="server" class="ddl" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Width="500px" AutoPostBack="True">
                        </asp:DropDownList>
                  <%--      <asp:TextBox ID="txtBudgetAdjust" runat="server"  Width="330px"></asp:TextBox>
                      <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" />--%>
                         </td>
                    <td style="width: 30%">
                     * (พิมพ์ข้อความเพื่อค้นหา)
                        <%--<asp:Image ID="img_bg_balance" runat="server" ImageUrl="~/imgs/question.png"/>--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
  <tr>
      <td align="right" >แผนงาน :</td>
      <td ><asp:Label ID="lb_plan" runat="server" Text="-" ></asp:Label></td>
      
  </tr>
    <tr>
      <td align="right" >ผลผลิต :</td>
      <td ><asp:Label ID="lb_product" runat="server" Text="-"  ></asp:Label></td>
      
  </tr>
          <tr>
      <td align="right" >กิจกรรมหลัก :</td>
      <td ><asp:Label ID="lb_mainAct" runat="server" Text="-" ></asp:Label></td>
      
  </tr>
    <tr>
      <td align="right" >หมวดงบรายจ่าย :</td>
      <td ><asp:Label ID="lb_budget" runat="server" Text="-" ></asp:Label></td>
      
  </tr>

    <tr>
      <td align="right" >โครงการ :</td>
      <td ><asp:Label ID="lb_ProjectName" runat="server" Text="-" ></asp:Label></td>
      
  </tr>
      <tr>
      <td align="right" >รหัสโครงการ :</td>
      <td ><asp:Label ID="lb_ProjectCode" runat="server" Text="-" ></asp:Label></td>
      
  </tr>
        <tr>
      <td align="right" >จำนวนเงินงบประมาณ :</td>
      <td ><asp:Label ID="lb_amount" runat="server" Text="-" ></asp:Label></td>
      
  </tr>
      <tr>
      <td align="right" >จำนวนเงินคงเหลือ :</td>
      <td ><asp:Label ID="lb_balance" runat="server" Text="-" ></asp:Label></td>
      
  </tr>
<tr>
        <td align="right">ผู้รับเงิน/เจ้าหนี้ :
        </td>
        <td>
            <table width="100%">
                <tr>
                    <td style="width: 60%">
                        <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="CUSTOMER_ID" DataTextField="CUSTOMER_NAME" Width="400px">
            </asp:DropDownList>
                    </td>
                    <td style="width: 40%">
                       * (พิมพ์ข้อความเพื่อค้นหา)
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
                <table>
                    <tr>
                        <td>
<asp:DropDownList ID="ddl_GL" runat="server" DataTextField="GL_NAME" DataValueField="IDA" Width="400px">
                </asp:DropDownList>
                        </td>
                        <td>
                            *
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
    <tr>
        <td align="right">จำนวนเงินผูกพัน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:RadNumericTextBox>
            &nbsp;บาท*</td>
    </tr>
    <tr>
        <td align="right">&nbsp;</td>
        <td>
            <asp:Button ID="btn_add_bg" runat="server" Text="บันทึกข้อมูล" />
        </td>
    </tr>
</table>

    <table>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>

                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None" width="100%" ShowFooter="true">
                    <MasterTableView>
                        <Columns>
                            
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RELATE_DETAIL_ID" HeaderText="RELATE_DETAIL_ID" DataField="RELATE_DETAIL_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RELATE_ID" HeaderText="RELATE_ID" DataField="RELATE_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BUDGET_PLAN_ID" HeaderText="BUDGET_PLAN_ID" DataField="BUDGET_PLAN_ID" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="proj_code" HeaderText="รหัสกิจกรรม/โครงการ" DataField="proj_code" >
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
             <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>

    <asp:Panel ID="Panel3" runat="server" GroupingText="งวดเบิก">
    <table width="100%">
        <tr>
            <td>
                <table>
  <%--                  <td>จำนวนงวด</td>
                    <td>
                        <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server">

                    </telerik:RadNumericTextBox>
                    </td>--%>
                    <td>
                        <asp:Button ID="btn_period" runat="server" Text="เพิ่มงวด" OnClientClick="return confirm('คุณต้องการเพิ่มข้อมูลหรือไม่');" />
                    </td>
                </table>
            </td>
        </tr>
   
    <tr>
        <td>

            <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" width="100%">
                <MasterTableView>
                    <Columns>
                       <%-- <telerik:GridBoundColumn DataField="RowNumber" HeaderText="ลำดับ" UniqueName="RowNumber">
                        </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="PERIOD_ID" HeaderText="งวดที่" UniqueName="PERIOD_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RELATE_DETAIL_ID" Display="false" HeaderText="RELATE_DETAIL_ID" UniqueName="RELATE_DETAIL_ID">
                        </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="PERIOD_AMOUNT" Display="false" HeaderText="PERIOD_AMOUNT" UniqueName="PERIOD_AMOUNT">
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

                        <telerik:GridBoundColumn UniqueName="AMOUNT" HeaderText="จำนวนเงิน" DataField="AMOUNT" DataFormatString="{0:###,###.##}" Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.##}" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>

                        <telerik:GridTemplateColumn UniqueName="berg" HeaderText="จำนวนเงินแต่ละงวด">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="rnt_berg" DataField="PERIOD_AMOUNT"  runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
                                <asp:Label ID="Label7" runat="server" Text="บาท"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="del" ConfirmText="คุณต้องการลบหรือไม่" Text="ลบ" CommandName="del">

                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>

        <tr>
            <td>

                <asp:Button ID="btn_bill_save" runat="server" style="width: 132px" Text="บันทึกงวดเบิก" />
                <asp:Button ID="btn_Edit" runat="server" style="width: 132px;display:none;" Text="แก้ไข" />
            </td>
        </tr>
         <tr>
            <td>
                <br />    <br />
            </td>
        </tr>
</table>
</asp:Panel>
</asp:Panel>