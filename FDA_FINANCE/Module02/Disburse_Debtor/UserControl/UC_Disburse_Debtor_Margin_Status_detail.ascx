<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Margin_Status_detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Margin_Status_detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%--<asp:Panel ID="Panel1" runat="server" Width ="900px" GroupingText="บันทึกเลขที่เช็ค" Enabled="false">
<table>
       
    <tr>
        <td align="right">หมายเลขเช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ของเช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_DATE" runat="server"></asp:TextBox>
        </td>

    </tr>
    
    
</table>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server" Width ="900px" GroupingText ="การอนุมัติเช็ค" Enabled="false">
<table>
<tr>
        <td align="right">การอนุมัติเช็ค : </td>
        <td>
            <asp:CheckBox ID="cb_CHECK_APPROVE" runat="server" />
        </td>
        <td align="right">วันที่อนุมัติเช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_APPROVE_DATE" runat="server"></asp:TextBox>
        </td>
    
    </tr>
   
</table>
    </asp:Panel>
<asp:Panel ID="Panel3" runat="server" Width ="900px" GroupingText ="รับเช็ค" Enabled="false">
<table>
<tr>
        <td align="right">รับเช็ค : </td>
        <td>
            <asp:CheckBox ID="cb_IS_CHECK_RECEIVE" runat="server" />
        </td>
        <td align="right"> วันที่มารับเช็ค :</td>
        <td>
            <asp:TextBox ID="txt_CHECK_RECEIVE_DATE" runat="server"></asp:TextBox>
        </td>
    <td align="right">วันครบคืนคลัง : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_BUDGET_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
   
</table>
    </asp:Panel>
<asp:Panel ID="Panel4" runat="server" Width ="900px" GroupingText ="บันทึกการจ่ายเงิน" Enabled="false">
<table>
<tr>
        <td align="right"> ระยะเวลาคืนเงิน: </td>
        <td>
            <asp:TextBox ID="txt_returnday" runat="server" AutoPostBack="True" 
            ></asp:TextBox> &nbsp; วัน &nbsp;
        </td>
        <td align="right">วันที่ครบกำหนดคืน : </td>
        <td>
            <asp:TextBox ID="txt_return_date" runat="server"></asp:TextBox>
        </td>
    
    </tr>
   
</table>
</asp:Panel>--%>
<br />
<div class="panel panel-body"  style="width:80%;padding-left:5%;">
<table width="100%">
    <tr>
        <td align="right"><b>เลขเอกสาร :</b></td>
        <td>
            <asp:Label ID="lb_DOC_NUMBER" runat="server"></asp:Label>
        </td>
        <td align="right"><b>เลขที่เบิก :</b></td>
        <td>
            <asp:Label ID="lb_BILL_NUMBER" runat="server"></asp:Label>
        </td>
        <td align="right"><b>เลขขบ. :</b></td>
        <td>
            <asp:Label ID="lb_GFMIS_NUMBER" runat="server"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td align="right"><b>ชื่อลูกหนี้ :</b></td>
        <td>
            <asp:Label ID="lb_customer_name" runat="server"></asp:Label>
        </td>
        <td align="right"><b>จำนวนเงิน :</b></td>
        <td>
            <asp:Label ID="lb_Amount" runat="server"></asp:Label>
        &nbsp;บาท</td>
        <td></td>
        <td></td>
    </tr>
</table>
    </div>
<div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel1" runat="server" Width ="100%" GroupingText="บันทึกเลขที่เช็ค" Enabled="false">
<table>
       
    <tr>
        <td align="right">หมายเลขเช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ของเช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
    
    
</table>
</asp:Panel>
    </div>
<div class="panel panel-body"  style="width:80%;padding-left:5%;">

<asp:Panel ID="Panel2" runat="server" Width ="100%" GroupingText ="การรับเช็ค" Enabled="false">
<table>
<tr>
        <td align="right">สถานะเช็คลงนามแล้ว : </td>
        <td>
            <asp:CheckBox ID="cb_CHECK_APPROVE" runat="server" />
        </td>
        <td align="right">วันที่ลงนามเช็ค : </td>
        <td>


            <asp:TextBox ID="txt_CHECK_APPROVE_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>
    </div>
<%--<asp:Panel ID="Panel3" runat="server" Width ="900px" GroupingText ="บันทึกเลขบก. อนุมัติ " Enabled="false">
<table>
<tr>
        <td align="right"> เลขบก. อนุมัติ : </td>
        <td>
           <asp:TextBox ID="txt_Return_appr" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่บก. อนุมัติ : </td>
        <td>
            <asp:TextBox ID="txt_Return_Appr_date" runat="server"></asp:TextBox>
        </td>
    <td align="right">วันครบกำหนดคืนคลัง : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_BUDGET_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>--%>
<div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel3" runat="server" Width ="100%" GroupingText ="การอนุมัติพร้อมจ่าย" Enabled="false">
<table>
   <tr>
       <td align="right">
           สถานะเช็คพร้อมจ่าย :
       </td>
       <td>
           <asp:CheckBox ID="cb_is_check_ready" runat="server" />
       </td>
       <td align="right"> วันที่อนุมัติพร้อมจ่าย :</td>
        <td>
            <asp:TextBox ID="txt_Check_ready_date" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันครบกำหนดคืนคลัง : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_BUDGET_DATE" runat="server"></asp:TextBox>
        </td>
   </tr>
</table>
</asp:Panel>
    </div>

<div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel4" runat="server" Width ="100%" GroupingText ="บันทึกการจ่ายเงิน" Enabled="false">
<table>
<tr>

    <td align="right">สถานะการจ่าย : </td>
        <td>
            <asp:CheckBox ID="cb_IS_CHECK_RECEIVE" runat="server" />
        </td>
        <td align="right"> วันที่จ่าย :</td>
        <td>
            <asp:TextBox ID="txt_CHECK_RECEIVE_DATE" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ครบกำหนดคืน : </td>
        <td>

            <asp:TextBox ID="txt_Return_date" runat="server"></asp:TextBox>

        </td>
    </tr>
   
</table>
</asp:Panel>
    </div>
<%--<br />
<br />
<br />
<br />--%>
<asp:Panel ID="Panel6" runat="server" GroupingText="การยกเลิกรายการ" Width="900px" style="display:none;">
    <table>
        <tr>
            <td>การยกเลิกเช็ค</td>
            <td>
                <asp:CheckBox ID="cb_IS_CANCEL" runat="server" />
            </td>
        </tr>
    </table>
</asp:Panel>

<%--<asp:Panel ID="Panel4" runat="server" Width ="900px" GroupingText ="บันทึกการจ่ายเงิน" Enabled="false">
<table>
<tr>
    <td>จ่าย/ยกเลิก</td>
    <td>
        <asp:RadioButtonList ID="rdl_IS_Cancel" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
            <asp:ListItem Value="1" Selected="true">จ่าย</asp:ListItem>
            <asp:ListItem Value="2">ยกเลิกการจ่าย</asp:ListItem>
        </asp:RadioButtonList>
    </td>
    <td>
        <asp:Panel ID="pn_pay" runat="server" BorderStyle="None">
            <table>
            <tr>
                <td align="right">สถานะการจ่าย : </td>
        <td>
            <asp:CheckBox ID="cb_IS_CHECK_RECEIVE" runat="server" />
        </td>
        <td align="right"> วันที่จ่าย :</td>
        <td>
            <asp:TextBox ID="txt_CHECK_RECEIVE_DATE" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ครบกำหนดคืน : </td>
        <td>

            <asp:TextBox ID="txt_Return_date" runat="server"></asp:TextBox>

        </td>
            </tr>
        </table>
        </asp:Panel>
        
    </td>
    
    </tr>
   
</table>
</asp:Panel>--%>