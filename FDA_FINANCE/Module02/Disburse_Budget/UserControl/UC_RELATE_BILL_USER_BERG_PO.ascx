<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_RELATE_BILL_USER_BERG_PO.ascx.vb" Inherits="FDA_FINANCE.UC_RELATE_BILL_USER_BERG_PO" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียด">
<table>
        <tr>
            <td align="right">ประเภทตัดงบประมาณ :&nbsp;</td>
            <td>
                <asp:Label ID="lb_type" runat="server" Text="-"></asp:Label>
                <%--<asp:RadioButtonList ID="rdl_type" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">เบิกจ่าย</asp:ListItem>
                    <asp:ListItem Value="2">เงินยืม</asp:ListItem>
                    <asp:ListItem Value="3">ก่อหนี้ผูกพัน (PO)</asp:ListItem>
                </asp:RadioButtonList>--%>
            </td>
        </tr>
     <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td><asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_DATE" runat="server"  ></asp:TextBox>

        </td>
    </tr>
    
       <tr>
        <td align="right" >รหัสกิจกรรม/โครงการ :</td>
        <td >
        
            <%--<asp:DropDownList ID="dd_BudgetAdjust" runat="server" class="ddl" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Width="200px" AutoPostBack="True">
            </asp:DropDownList>--%>
            <asp:Label ID="lb_bg_adjust" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    
        <tr>
        <td align="right">รายการ : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"   TextMode="MultiLine" Height="40px" Width="100%"> </asp:TextBox></td>
    </tr>
  
        
        <%--<tr>
        <td align="right" >วันที่ทำรายการ :</td>
        <td >
        
            <asp:TextBox ID="txt_dodate" runat="server"></asp:TextBox>
        
        </td>
    </tr>--%>
        
</table>
    </asp:Panel>
<asp:Panel ID="Panel2" runat="server" GroupingText="รายการจำนวนเงินที่ขอผูกพัน">
<table>
    <tr>
        <td>

            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" width="100%">
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="RowNumber" HeaderText="ลำดับ" UniqueName="RowNumber">
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
                        <telerik:GridBoundColumn Aggregate="Sum" DataField="AMOUNT" DataFormatString="{0:###,###.##}" FooterAggregateFormatString="รวม : {0:###,###.##}" HeaderStyle-HorizontalAlign="Right" HeaderText="จำนวนเงิน" UniqueName="AMOUNT">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </telerik:GridBoundColumn>
                        
                       <%--<telerik:GridBoundColumn Aggregate="Sum" DataField="balance" DataFormatString="{0:###,###.##}" FooterAggregateFormatString="รวม : {0:###,###.##}" HeaderStyle-HorizontalAlign="Right" HeaderText="จำนวนเงินคงเหลือ" UniqueName="balance">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </telerik:GridBoundColumn>--%>
                        <%--<telerik:GridTemplateColumn UniqueName="berg">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="rnt_berg" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
                                <asp:Label ID="Label7" runat="server" Text="บาท"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
    </asp:Panel>
<asp:Panel ID="Panel3" runat="server" GroupingText="งวด">
    <table width="100%">
        <%--<tr>
            <td>
                <table>
                    <td>จำนวนงวด</td>
                    <td>
                        <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server">

                    </telerik:RadNumericTextBox>
                    </td>
                    <td>
                        <asp:Button ID="btn_period" runat="server" Text="เพิ่มงวด" OnClientClick="return confirm('คุณต้องการเพิ่มข้อมูลหรือไม่');" />
                    </td>
                </table>
            </td>
        </tr>--%>
    <tr>
        <td>

            <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" width="100%">
                <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                                <Selecting AllowRowSelect="true"/>
                            </ClientSettings>
                <MasterTableView>
                    <Columns> 

                        <telerik:GridTemplateColumn UniqueName="bergSelect" HeaderText="เลือก" >
                            <ItemTemplate>
                                <telerik:GridCheckBoxColumnEditor ID="chkColumn" runat="server"  ></telerik:GridCheckBoxColumnEditor>
                            </ItemTemplate>  
                        </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn DataField="PERIOD_ID" HeaderText="งวดที่" UniqueName="PERIOD_ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
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
                        <telerik:GridBoundColumn Aggregate="Sum" DataField="AMOUNT" DataFormatString="{0:###,###.##}" FooterAggregateFormatString="รวม : {0:###,###.##}" HeaderStyle-HorizontalAlign="Right" HeaderText="จำนวนเงิน" UniqueName="AMOUNT">
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn  DataField="PERIOD_AMOUNT" DataFormatString="{0:###,###.##}"  HeaderText="จำนวนเงินแต่ละงวด" UniqueName="PERIOD_AMOUNT">
                        </telerik:GridBoundColumn>

                        
                 <%--       <telerik:GridTemplateColumn UniqueName="berg" HeaderText="จำนวนเงินแต่ละงวด">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="rnt_berg" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
                                <asp:Label ID="Label7" runat="server" Text="บาท"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
               <%--         <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="del" ConfirmText="คุณต้องการลบหรือไม่" Text="ลบ">

                        </telerik:GridButtonColumn>--%>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
</asp:Panel>
