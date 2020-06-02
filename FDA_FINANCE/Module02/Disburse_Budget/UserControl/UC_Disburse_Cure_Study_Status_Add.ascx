<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Cure_Study_Status_Add.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Cure_Study_Status_Add" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="Panel1" runat="server" Width ="900px" GroupingText="บันทึกเลขที่เช็ค" Enabled="false">
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
<asp:Panel ID="Panel2" runat="server" Width ="900px" GroupingText ="การรับเช็ค" Enabled="false">
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

<asp:Panel ID="Panel3" runat="server" Width ="900px" GroupingText ="บันทึกเลขปลดจ่าย " Enabled="false">
<table>
<tr>
        <td align="right"> เลขปลดจ่าย : </td>
        <td>
           <asp:TextBox ID="txt_Return_appr" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่เลขปลดจ่าย : </td>
        <td>
            <asp:TextBox ID="txt_Return_Appr_date" runat="server"></asp:TextBox>
        </td>
     <td align="right">วันครบกำหนดคืนคลัง : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_BUDGET_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>
<asp:Panel ID="Panel4" runat="server" Width ="900px" GroupingText ="การอนุมัติพร้อมจ่าย" Enabled="false">
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
   </tr>
</table>
</asp:Panel>

<asp:Panel ID="Panel5" runat="server" Width ="900px" GroupingText ="บันทึกการจ่ายเงิน" Enabled="false">
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
    </tr>
   
</table>
</asp:Panel>
