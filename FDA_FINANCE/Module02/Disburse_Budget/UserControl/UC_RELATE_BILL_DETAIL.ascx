<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_RELATE_BILL_DETAIL.ascx.vb" Inherits="FDA_FINANCE.UC_RELATE_BILL_DETAIL" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style1 {
        height: 26px;
    }
</style>
<asp:Panel ID="Panel3" runat="server" GroupingText="ข้อมูลงบประมาณ">
    <table>
        <tr>
            <td align="right">หน่วยงาน :</td>
            <td > &nbsp;
                <asp:Label ID="lb_dept" runat="server" ></asp:Label>
            </td>
           
        </tr>
        <tr>
            <td align="right">ชื่อโครงการ :</td>
            <td>&nbsp;
                <asp:Label ID="lb_project_name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">กิจกรรมหลักที่ :</td>
            <td>&nbsp;
                <asp:Label ID="lb_activity" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>&nbsp;
            <td align="right">จำนวนเงินที่ได้รับจัดสรร</td>
            <td>&nbsp;
                <asp:Label ID="lb_adjust_amount" runat="server" Text="0.00"></asp:Label>
                &nbsp;บาท</td>
        </tr>
        <tr>
             <td align="right">จำนวนเงินคงเหลือ :</td>
            <td >&nbsp;
                <asp:Label ID="lb_Amount" runat="server" Text="0.00"></asp:Label> &nbsp; บาท
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลเบิก">
    <table>
     <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td><asp:TextBox ID="txt_DOC_NUMBER" runat="server"  ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_DATE" runat="server"  ></asp:TextBox>

        </td>
    </tr>
    
        <tr>
            <td align="right">
                <asp:Label ID="lb_henchop" runat="server" Text="เลขที่บันทึกขอความเห็นชอบ"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_henchop" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">วันที่บันทึกขอความเห็นชอบ</td>
            <td>
                <asp:TextBox ID="txt_henchop_date" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style1">
                <asp:Label ID="lb_ko" runat="server" Text="เลขที่รายงานขอซื้อขอจ้าง"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txt_ko" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">วันที่รายงานขอซื้อขอจ้าง</td>
            <td>
                <asp:TextBox ID="txt_ko_date" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td align="right">เลขที่โครงการ</td>
        <td>
            <asp:TextBox ID="txt_PROJECT_NUMBER" runat="server"></asp:TextBox>
            </td>
    </tr>
        <tr>
        <td align="right">รายการ : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"   TextMode="MultiLine" Height="40px" Width="100%"> </asp:TextBox></td>
    </tr>
  <tr>
        <td align="right" >ผู้รับเงิน/ผู้รับจ้าง : </td>
        <td >
        
            <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="CUSTOMER_ID" DataTextField="CUSTOMER_NAME" AutoPostBack="true">
                
            </asp:DropDownList>
        
        </td>
    </tr>
  
<tr>
        <td align="right" valign="top"><asp:Label ID="lb_paylist" runat="server" Text="ค่าใช้จ่าย :" ></asp:Label>
        </td>
        <td valign="top">

           <telerik:RadComboBox ID="rcb_budget" Runat="server" Width="300px" Height="300px" 
                    EmptyMessage="เลือกงบประมาณ" AllowCustomText="true" ><Items><telerik:RadComboBoxItem Text="" /></Items><ItemTemplate><div id="div1" onclick="StopPropagation(event)"><telerik:RadTreeView ID="rtv_bg_plan" runat="server" 
                                 OnClientNodeClicking="OnClientNodeClickingHandler"></telerik:RadTreeView></div></ItemTemplate></telerik:RadComboBox>
            <asp:Label ID="lb_paylist_des" runat="server"></asp:Label>
             
        </td>
   </tr>
    
        <tr>
            <td align="right" valign="top">เลขที่สัญญา/ใบสั่งซื้อสั่งจ้าง :</td>
            <td valign="top">
                <asp:TextBox ID="txt_PO_CONTRACT_NUMBER" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">วันที่สัญญา/ใบสั่งซื้อสั่งจ้าง :</td>
            <td valign="top">
                <asp:TextBox ID="txt_PO_CONTRACT_DATE" runat="server"></asp:TextBox>
            </td>
        </tr>
    
       <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server"    Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
           &nbsp;บาท</td>
    </tr>
        
        <tr>
            
        <td align="right"> <asp:Label ID="lb_EGP" runat="server" Text="เลขคุมสัญญา(EGP)"></asp:Label>

        </td>
        <td>
            <table>
                <tr>
                    <td><asp:TextBox ID="txt_EGP" runat="server" MaxLength="12"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            
            
        </td>
    </tr>
        <tr>
            <td align="right">เลขที่ P/O จากระบบ GFMIS :</td>
            <td>
                <asp:TextBox ID="txt_PO_GFMIS_NUMBER" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">วันที่จากระบบ GFMIS :</td>
            <td>
                <asp:TextBox ID="txt_PO_GFMIS_DATE" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
        <td align="right" >วันที่ทำรายการ :</td>
        <td >
        
            <asp:TextBox ID="txt_dodate" runat="server"></asp:TextBox>
        
        </td>
    </tr>
        <tr>
            <td align="right">สถานที่ปฏิบัติราชการ :</td>
            <td>
                <asp:TextBox ID="txt_place" runat="server" Width="450px"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            <td align="right">วันที่เดินทาง :</td>
            <td>
                <asp:TextBox ID="txt_travel_date" runat="server"></asp:TextBox>
                &nbsp;ถึงวันที่
                <asp:TextBox ID="txt_travel_date_end" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">ประเภท :&nbsp;</td>
            <td>
                <asp:RadioButtonList ID="rdl_type" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">ใบสำคัญเงินงบประมาณ</asp:ListItem>
                    <asp:ListItem Value="2">รายการจัดซื้อจัดจ้าง</asp:ListItem>
                    <asp:ListItem Value="3">ลูกหนี้เงินงบประมาณ</asp:ListItem>
                    <asp:ListItem Value="4">ลูกหนี้เงินทดรอง</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
</table>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" GroupingText="ข้อมูลเบิก" style="display:none;">
    <table>
  <%--  <tr>
    <td align="right">
    งบประมาณ : 
    </td>
    <td>

        <asp:Label ID="lb_Budget_Plan1" runat="server" ></asp:Label>
    </td>
        
    </tr>--%>
     <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td>
            <asp:Label ID="lb_docnumber" runat="server" Text="-"></asp:Label>

        </td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:Label ID="lb_doc_date1" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="เลขที่บันทึกขอความเห็นชอบ"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lb_henchop1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">วันที่บันทึกขอความเห็นชอบ</td>
            <td>
                <asp:Label ID="lb_henchop_date1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="เลขที่รายงานขอซื้อขอจ้าง"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lb_ko1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">วันที่รายงานขอซื้อขอจ้าง</td>
            <td>
                <asp:Label ID="lb_ko_date1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
        <td align="right">เลขที่โครงการ</td>
        <td>
            <asp:Label ID="lb_project_number1" runat="server" Text="-"></asp:Label>
            </td>
    </tr>
        <tr>
        <td align="right">รายการ : </td>
        <td>
            <asp:Label ID="lb_description1" runat="server" Text="-"></asp:Label>
            </td>
    </tr>
  <tr>
        <td align="right" >ผู้มีสิทธิ์รับเงิน/เจ้าหนี้ : </td>
        <td >
        
            <asp:Label ID="lb_customer1" runat="server" Text="-"></asp:Label>
        
        </td>
    </tr>
  
<tr>
        <td align="right" valign="top"><asp:Label ID="Label4" runat="server" Text="ค่าใช้จ่าย :" ></asp:Label>
        </td>
        <td valign="top">

            <asp:Label ID="lb_paylist1" runat="server" Text="-"></asp:Label>
             
        </td>
   </tr>
    
        <tr>
            <td align="right" valign="top">เลขที่สัญญา/ใบสั่งซื้อสั่งจ้าง :</td>
            <td valign="top">
                <asp:Label ID="lb_PO_CONTRACT_NUMBER1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">วันที่สัญญา/ใบสั่งซื้อสั่งจ้าง :</td>
            <td valign="top">
                <asp:Label ID="lb_PO_CONTRACT_date1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    
       <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <asp:Label ID="lb_amount1" runat="server" Text="0.00"></asp:Label>
           &nbsp;บาท</td>
    </tr>
        
        <tr>
            
        <td align="right"> <asp:Label ID="Label6" runat="server" Text="เลขคุมสัญญา(EGP)"></asp:Label>

        </td>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lb_egp1" runat="server" Text="-"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            
            
        </td>
    </tr>
        <tr>
            <td align="right">เลขที่ P/O จากระบบ GFMIS :</td>
            <td>
                <asp:Label ID="lb_PO_GFMIS_NUMBER1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">วันที่จากระบบ GFMIS :</td>
            <td>
                <asp:Label ID="lb_PO_GFMIS_DATE1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
         <%--<tr>
            <td align="right">จำนวนงวดงาน :</td>
            <td>
                <asp:Label ID="lb_max_period" runat="server" Text="-"></asp:Label>
                &nbsp;งวด</td>
        </tr>--%>
        <tr>
        <td align="right" >วันที่ทำรายการ :</td>
        <td >
        
            <asp:Label ID="lb_do_date1" runat="server" Text="-"></asp:Label>
        
        </td>
    </tr>
        <tr>
            <td align="right">สถานที่ปฏิบัติราชการ :</td>
            <td>
                <asp:Label ID="lb_palce1" runat="server" Text="-"></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td align="right">วันที่เดินทาง :</td>
            <td>
                <asp:Label ID="lb_travel_date1" runat="server" Text="-"></asp:Label>
                &nbsp;ถึงวันที่
                <asp:Label ID="lb_travel_dateend1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">ประเภท :&nbsp;</td>
            <td>
                <asp:Label ID="lb_type1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
</table>
</asp:Panel>