<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_RELATE_BILL_DETAIL2.ascx.vb" Inherits="FDA_FINANCE.UC_RELATE_BILL_DETAIL2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel3" runat="server" GroupingText="ข้อมูลงบประมาณ">
    <table>
        <tr>
            <td align="right">หน่วยงาน :</td>
            <td > &nbsp;
                <asp:Label ID="lb_dept" runat="server" ></asp:Label>
            </td>
           
        </tr>
        <tr>
            <td align="right">ชื่อโครงการ/กิจกรรม :</td>
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
        <caption>
            &nbsp;
            <tr>
                <td align="right">งบรายจ่าย :</td>
                <td>
                    &nbsp; <asp:Label ID="lb_budget" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">จำนวนเงินงบประมาณ</td>
                <td>&nbsp;
                    <asp:Label ID="lb_adjust_amount" runat="server" Text="0.00"></asp:Label>
                    &nbsp;บาท</td>
            </tr>
        </caption>
        </tr>
        <tr>
            <td align="right">จำนวนเงินคงเหลือ :</td>
            <td>&nbsp;
                <asp:Label ID="lb_Amount" runat="server" Text="0.00"></asp:Label>
                &nbsp; บาท </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียด">
    <table>
        <tr>
            <td align="right">ประเภทตัดงบประมาณ :&nbsp;</td>
            <td>
                <asp:RadioButtonList ID="rdl_type" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">เบิกจ่าย</asp:ListItem>
                    <asp:ListItem Value="2">เงินยืม</asp:ListItem>
                    <asp:ListItem Value="3">ก่อหนี้ผูกพัน (PO)</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
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

            <asp:DropDownList ID="ddl_GL" runat="server" DataValueField="IDA" DataTextField="GL_NAME" Width="200px">
            </asp:DropDownList>
             
        </td>
   </tr>
    
        <tr>
            <td align="right">จำนวนเงินผูกพัน : </td>
            <td>
                <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
                </telerik:RadNumericTextBox>
                &nbsp;บาท</td>
        </tr>
        
        <tr>
        <td align="right" >วันที่ทำรายการ :</td>
        <td >
        
            <asp:TextBox ID="txt_dodate" runat="server"></asp:TextBox>
        
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
            <td align="right">ประเภท :&nbsp;</td>
            <td>
                <asp:Label ID="lb_type1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
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
                รายการ :
            </td>
            <td>
                <asp:Label ID="lb_description1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">ผู้มีสิทธิ์รับเงิน/เจ้าหนี้ : </td>
            <td>
                <asp:Label ID="lb_customer1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <asp:Label ID="Label4" runat="server" Text="ค่าใช้จ่าย :"></asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lb_paylist1" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">จำนวนเงิน : </td>
            <td>
                <asp:Label ID="lb_amount1" runat="server" Text="0.00"></asp:Label>
                &nbsp;บาท</td>
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
        
</table>
</asp:Panel>