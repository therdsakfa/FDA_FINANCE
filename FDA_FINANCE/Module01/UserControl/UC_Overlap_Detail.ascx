<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Overlap_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Overlap_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
    <td align="right">
    งบประมาณ : 
    </td>
    <td>
      <%--  <asp:DropDownList ID="dd_Budget_Plan" runat="server" Height="22px" Width="128px" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
           
        </asp:DropDownList>--%>
        <asp:Label ID="lb_Budget_Plan" runat="server" ></asp:Label>
    </td>
        
    </tr>
    <tr>
    <td align="right">วันที่รับเอกสาร :</td>
        <td>
            <telerik:RadDatePicker ID="rdp_RECIEVE_DATE" Runat="server">
            </telerik:RadDatePicker>
&nbsp;</td>
    </tr>
    <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td><asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_DOC_DATE" Runat="server">
            </telerik:RadDatePicker>
        
        </td>
    </tr>
    <tr>
        <td align="right">วันที่กันไว้เหลื่อมปี : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_OVERLAP_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
  
<tr>
        <td align="right" >ค่าใช้จ่าย : </td>
        <td >
        <asp:DropDownList ID="dd_Paylist" runat="server" Height="22px" Width="128px" DataTextField="PAYLIST_DESCRIPTION" DataValueField="PATLIST_ID">

        </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">รายการ : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"></asp:TextBox></td>
    </tr>
       <tr>
        <td align="right">จำนวนเงินที่ขอกัน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server">
            </telerik:RadNumericTextBox>
           &nbsp;บาท</td>
    </tr>
  
</table>