<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_add.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_add" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียด">
    <table>
        <tr>
            <td align="right">
                ปีงบประมาณ :
            </td>
            <td>
                <asp:Label ID="bg_year" runat="server"></asp:Label>
            </td>
            <td align="right">
                เลขที่รับเรื่องเบิกเงิน งปม. :
            </td>
            <td>
                <telerik:RadNumericTextBox ID="withdraw_bill" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100" Enabled="false">
             </telerik:RadNumericTextBox>  
                <%--<asp:Label ID="withdraw_bill" runat="server"></asp:Label>--%>
            </td>
        </tr>
        <tr>
            <td align="right">วันที่รับเรื่อง :</td>
            <td>

                <asp:TextBox ID="txt_wd_date" runat="server"></asp:TextBox>
            </td>
            <td>
                แหล่งของเงิน :
            </td>
            <td>
                <asp:DropDownList ID="dd_typeMoney" runat="server">
                    <asp:ListItem Value="1">งบกลาง</asp:ListItem>
                    <asp:ListItem Value="2">งบประมาณ</asp:ListItem>
                    <asp:ListItem Value="3">นอกงบประมาณ</asp:ListItem>
                    <asp:ListItem Value="4">เงินโอนหน่วยงานภายนอก</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
     
    
        <tr>
        <td align="right">เรื่อง : </td>
        <td><asp:Label ID="txt_DESCRIPTION" runat="server"  Height="40px" Width="350px"> </asp:Label></td>
    </tr>
  
        <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td>
            <%--<asp:TextBox ID="txt_DOC_NUMBER" runat="server"  ></asp:TextBox>--%>
            <asp:Label ID="txt_DOC_NUMBER" runat="server"></asp:Label>
        </td>
            <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:Label ID="txt_DOC_DATE" runat="server"  ></asp:Label>

        </td>
    </tr>
        <tr>
            <td align="right">
                หมวดค่าใช้จ่าย :
            </td>
            <td>
                <asp:Label ID="bg_group" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                แผนงาน :
            </td>
            <td>
                <asp:Label ID="bg_plan" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">งาน/โครงการ :</td>
            <td>
                <asp:Label ID="bg_project" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">ประเภทการจ่าย :</td>
            <td>
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
                กองผู้เบิก :
            </td>
            <td>
                <asp:Label ID="lb_dep" runat="server"></asp:Label>
            </td>
         <%--   <td align="right">
                จำนวนเงินยอดเบิก :       
            </td>
            <td>
                <asp:Label ID="lb_Allamount" runat="server"></asp:Label>
            </td>--%>
        </tr>
        
        
        <%--<tr>
        <td align="right" >วันที่ทำรายการ :</td>
        <td >
        
            <asp:TextBox ID="txt_dodate" runat="server"></asp:TextBox>
        
        </td>
    </tr>--%>
        <tr>
                    <td align="right">
                        ประเภทเจ้าหนี้ :
                    </td>
                    <td>
                        <%--<asp:DropDownList ID="dd_type_deb" runat="server" DataTextField="Type_Name" DataValueField="ID" AutoPostBack="true">
                        </asp:DropDownList>--%>
                        <asp:DropDownList ID="dd_type_deb" runat="server">
                            <asp:ListItem Value="1">ข้าราชการ</asp:ListItem>
                            <asp:ListItem Value="2">นิติบุคุคล</asp:ListItem>
                            <asp:ListItem Value="3">บุคคลธรรมดา</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        จำนวนเงิน :
                    </td>
                    <td>
                            <telerik:RadNumericTextBox ID="rnt_amount" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100">
             </telerik:RadNumericTextBox>    
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ภาษี :
                    </td>
                    <td>
                        <telerik:RadNumericTextBox ID="rnt_vat" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="100">
             </telerik:RadNumericTextBox> 
                    </td>
                </tr>

                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:Button ID="bt_save" runat="server"  Text="บันทึก"/>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
</table>
</asp:Panel>
<asp:Panel ID="panel_2" runat="server" GroupingText="บันทึกเจ้าหนี้">
            
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
        </asp:Panel>
