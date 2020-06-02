<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_deka_add.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_deka_add" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style1 {
        width: 270px;
    }
</style>
<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียด">
    <table>
        <tr>
            <td align="right">
                ปีงบประมาณ :
            </td>
            <td class="auto-style1">
                <asp:Label ID="bg_year" runat="server"></asp:Label>
            </td>
            
            <td align="right">
                ประเภทฏีกา :
            </td>
            <td>
                <asp:DropDownList ID="dd_typeDeka" runat="server">
                    <asp:ListItem Value="1">จ่ายผ่านส่วนราชการ</asp:ListItem>
                    <asp:ListItem Value="2">เงินยืมราชการ</asp:ListItem>
                    <asp:ListItem Value="3">จ่ายตรง</asp:ListItem>
                    <asp:ListItem Value="4">จ่ายผ่าน</asp:ListItem>
                    <asp:ListItem Value="5">งบกลาง</asp:ListItem>
                    <asp:ListItem Value="6">พตส.ไม่ทำเวช พรก.</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                เลขที่ฏีกา :
            </td>
            <td>
           
                <telerik:RadNumericTextBox ID="deka_bill" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100" >
             </telerik:RadNumericTextBox>  
               <telerik:RadNumericTextBox ID="fk_bill" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100" Visible="false" >
             </telerik:RadNumericTextBox>  
            </td>
        </tr>
        <tr>
            <td align="right">วันที่ทำฏีกา :</td>
            <td class="auto-style1">

                <asp:TextBox ID="txt_wd_date" runat="server"></asp:TextBox>
            </td>
            
        </tr>
     
    
        <tr>
        <td align="right">เรื่อง : </td>
        <td class="auto-style1"><asp:Label ID="txt_DESCRIPTION" runat="server"  Height="40px" Width="350px"> </asp:Label></td>
    </tr>
  
       <%-- <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td>
         
            <asp:Label ID="txt_DOC_NUMBER" runat="server"></asp:Label>
        </td>
            <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:Label ID="txt_DOC_DATE" runat="server"  ></asp:Label>

        </td>
    </tr>--%>
        <tr>
            <td align="right">
                หมวดค่าใช้จ่าย :
            </td>
            <td class="auto-style1">
                <asp:Label ID="bg_group" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                แผนงาน :
            </td>
            <td class="auto-style1">
                <asp:Label ID="bg_plan" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">งาน/โครงการ :</td>
            <td class="auto-style1">
                <asp:Label ID="bg_project" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">ประเภทการจ่าย :</td>
            <td class="auto-style1">
                <asp:DropDownList ID="dd_payS" runat="server">
                    <asp:ListItem Value="1">วางฏีกา</asp:ListItem>
                    <asp:ListItem Value="2">เบิกหักหลังส่ง</asp:ListItem>
                    <asp:ListItem Value="3">เงินทดรอง</asp:ListItem>
                    <asp:ListItem Value="4">วางฎีกา(บัญชี คบส)</asp:ListItem>
                    <asp:ListItem Value="5">วางฎีกา(คบ.)</asp:ListItem>
                    <asp:ListItem Value="6">,ส่งงานบัญชี</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                ประเภทเงินกัน :
            </td>
            <td>
                <asp:DropDownList id="dd_payW" runat="server">
                    <asp:ListItem Value="1">เบิกปกติ</asp:ListItem>
                    <asp:ListItem Value="2">ค้างจ่ายข้ามปี</asp:ListItem>
                    <asp:ListItem Value="3">เงินกันเบิกเหลื่อมปี</asp:ListItem>
                    <asp:ListItem Value="4">เงินกันขยายเวลา</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                ชื่อธนาคาร :
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="dd_bank" runat="server">
                    <asp:ListItem Value="1">ธนาคารกรุงไทย</asp:ListItem>
                    <asp:ListItem Value="2">ธนาคารกรุงเทพ</asp:ListItem>
                    <asp:ListItem Value="3">ธนาคารกสิกรไทย</asp:ListItem>
                    <asp:ListItem Value="4">ธนาคารทหารไทย</asp:ListItem>
                    <asp:ListItem Value="5">ธนาคารไทยพาณิชย์</asp:ListItem>
                    <asp:ListItem Value="6">ธนาคารกรุงศรีอยุธยา</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                ชื่อบัญชี :
            </td>
            <td>
                <asp:TextBox ID="txt_nameAccBank" runat="server" Width="215px"></asp:TextBox>
            </td>
            <td align="right">
                เลขที่บัญชี :
            </td>
            <td>
                <asp:TextBox ID="num_bank" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        
        <%--<tr>
        <td align="right" >วันที่ทำรายการ :</td>
        <td >
        
            <asp:TextBox ID="txt_dodate" runat="server"></asp:TextBox>
        
        </td>
    </tr>--%>
        <%--<tr>
                    <td align="right">
                        ประเภทเจ้าหนี้ :
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="dd_type_deb" runat="server">
                            <asp:ListItem Value="1">ข้าราชการ</asp:ListItem>
                            <asp:ListItem Value="2">นิติบุคุคล</asp:ListItem>
                            <asp:ListItem Value="3">บุคคลธรรมดา</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        จำนวนเงินขอเบิก :
                    </td>
                    <td class="auto-style1">
                            <telerik:RadNumericTextBox ID="rnt_amount" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100">
             </telerik:RadNumericTextBox>    
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ภาษีเงินได้บุคคลธรรมดา :
                    </td>
                    <td class="auto-style1">
                        <telerik:RadNumericTextBox ID="rnt_vat" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100">
             </telerik:RadNumericTextBox> 
                    </td>
                </tr>
        <tr>
            <td align="right">
                ภาษีเงินได้นิติบุคคล :
            </td>
                
            <td>
                
                <telerik:RadNumericTextBox ID="rnt_vat2" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100">
             </telerik:RadNumericTextBox>  
            </td>
        </tr>
        <tr>
            <td align="right">
                ค่าปรับ :
            </td>
            <td>
                <telerik:RadNumericTextBox ID="rnt_mulct" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100">
             </telerik:RadNumericTextBox>  
            </td>
        </tr>
        <tr>
            <td align="right">
                เงินขอรับ :
            </td>
            <td>
                <telerik:RadNumericTextBox ID="rnt_AmountIncome" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100">
             </telerik:RadNumericTextBox>
            </td>
        </tr>

                <tr>
                    <td>
                        
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="bt_save" runat="server"  Text="บันทึก"/>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
</table>
</asp:Panel>
<%--<asp:Panel ID="panel_2" runat="server" GroupingText="บันทึกเจ้าหนี้">
            
    <table>
        <tr>
            <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None" width="100%" ShowFooter="true">
                    <MasterTableView>
                        <Columns>
                            
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ID" HeaderText="ID" DataField="ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BudgetYear" HeaderText="ปีงบประมาณ" DataField="BudgetYear" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Type_NameMoney" HeaderText="แหล่งของเงิน" DataField="Type_NameMoney" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Type_payName" HeaderText="ประเภทการจ่าย" DataField="Type_payName" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Type_payName_withdraw" HeaderText="ประเภทเงินกัน" DataField="Type_payName_withdraw">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Amount" HeaderText="จำนวนเงิน" DataField="Amount" DataFormatString="{0:###,###.##}" Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.##}" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Vat" HeaderText="ภาษี" DataField="Vat" DataFormatString="{0:###,###.##}">
                                <ItemStyle Width="90px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del" >
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
        </asp:Panel>--%>