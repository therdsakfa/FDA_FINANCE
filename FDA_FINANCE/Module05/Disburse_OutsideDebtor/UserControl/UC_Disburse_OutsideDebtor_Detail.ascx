<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_OutsideDebtor_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_OutsideDebtor_Detail" %>
<%@ Register Assembly="Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4"
    Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
<table>
    <tr>
        <td align="right">ปีงบประมาณ : </td>
        <td>
            <asp:DropDownList ID="dd_BUDGET_YEAR" runat="server" Height="22px" Width="128px">
                <asp:ListItem>2556</asp:ListItem>
            </asp:DropDownList>
        </td>
        <%--<td align="right">หน่วยงาน : </td>
        <td>
            <asp:DropDownList ID="dd_DEPARTMENT" runat="server" Height="22px" Width="128px">
                <asp:ListItem Value="1">ทดสอบหน่วยงาน</asp:ListItem>
            </asp:DropDownList>
        </td>--%>
    </tr>
    <tr>
    <td align="right">
    งบประมาณ : 
    </td>
    <td>
        <asp:DropDownList ID="dd_Budget_Plan" runat="server" Height="22px" Width="128px">
            <asp:ListItem Value="1">ทดสอบ</asp:ListItem>
        </asp:DropDownList>
    </td>
        
    </tr>
    <tr>
    <td align="right">วันที่รับเอกสาร :</td>
        <td>
            <telerik:RadDatePicker ID="rdp_Bill_RECIEVE_DATE" Runat="server">
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
        <td align="right">เลขที่เบิก : </td>
        <td><asp:TextBox ID="txt_BILL_NUMBER" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เบิก : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_BILL_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
  
  <tr>
        <td align="right" >ประเภทเจ้าหนี้ : </td>
        <td >
        
            <asp:DropDownList ID="dd_CUSTOMER_TYPE" runat="server">
                <asp:ListItem Value="1">ทดสอบ</asp:ListItem>
            </asp:DropDownList>
        
        </td>
    </tr>
<tr>
        <td align="right" >ค่าใช้จ่าย : </td>
        <td ><asp:TextBox ID="txt_PAYLIST_DESCRIPTION" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">รายการ : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"></asp:TextBox></td>
    </tr>
    
</table>