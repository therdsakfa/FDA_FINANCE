<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="Panel3" runat="server" GroupingText="ข้อมูลงบประมาณ">
    <table>
        <tr>
            <td align="right">หน่วยงาน :</td>
            <td >&nbsp;
                <asp:Label ID="lb_dept" runat="server" ></asp:Label>
            </td>
           
        </tr>
         <tr>
            <td align="right">ชื่อกิจกรรมหลัก :</td>
            <td>&nbsp;
                <asp:Label ID="lb_activity" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">ชื่อโครงการ/กิจกรรม :</td>
            <td>&nbsp;
                <asp:Label ID="lb_project_name" runat="server"></asp:Label>
            </td>
        </tr>
       
        <tr>
                <td align="right">งบรายจ่าย :</td>
                <td>
                    &nbsp;<asp:Label ID="lb_budget" runat="server" Text="-"></asp:Label>
                </td>
            
            </tr>
        <tr>
            <td align="right">จำนวนเงินงบประมาณ</td>
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
<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียด">
    <table>
    <tr>
    <td align="right">
    งบประมาณ : 
    </td>
    <td>

        <asp:Label ID="lb_Budget_Plan" runat="server" ></asp:Label>
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
            <td align="right">เบิกให้กับ :</td>
            <td>
                <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataTextField="CUSTOMER_NAME" DataValueField="CUSTOMER_ID" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
  
  
<tr>
        <td align="right" >&nbsp;<asp:Label ID="lb_paylist" runat="server" Text="ค่าใช้จ่าย :" ></asp:Label>
        </td>
        <td >

            <asp:DropDownList ID="ddl_GL" runat="server" DataTextField="GL_NAME" DataValueField="IDA" Width="200px">
            </asp:DropDownList>
            <asp:Label ID="lb_paylist_des" runat="server"></asp:Label>
             
        </td>
    </tr>
    <tr>
        <td align="right">รายการ : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"   TextMode="MultiLine" Height="40px" Width="100%"> </asp:TextBox></td>
    </tr>
       <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server"    Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:RadNumericTextBox>
           &nbsp;บาท</td>
    </tr>
</table>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server" GroupingText="บันทึกรับเรื่อง" style="display:none;">
    <table>
        <tr>
        <td align="right">เลขที่เบิก : </td>
        <td><asp:TextBox ID="txt_BILL_NUMBER" runat="server"  ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เบิก : </td>
        <td>
            <asp:TextBox ID="txt_BILL_DATE" runat="server"  ></asp:TextBox>
            
        </td>
    </tr>
  <tr>
    <td align="right">วันที่รับเอกสาร :</td>
        <td>
            <asp:TextBox ID="txt_Bill_RECIEVE_DATE" runat="server"   ></asp:TextBox>
&nbsp;</td>
   
    </table>
</asp:Panel>