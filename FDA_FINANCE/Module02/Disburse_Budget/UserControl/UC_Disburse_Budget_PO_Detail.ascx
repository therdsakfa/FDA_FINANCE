<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_PO_Detail.ascx.vb" Inherits="DTAM_BG.UC_Disburse_Budget_PO_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
    <td align="right">
    หน่วยงาน : 
    </td>
    <td>

        <asp:DropDownList ID="dd_dept" runat="server" class="ddl" AutoPostBack="true" 
                    DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" Font-Names="TH SarabunPSK" Font-Size="14">
                </asp:DropDownList>

    </td>
        
    </tr>

    <tr>
    <td align="right">
    โครงการ : 
    </td>
    <td>
      <%--  <asp:DropDownList ID="dd_Budget_Plan" runat="server" Height="22px" Width="128px" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
           
        </asp:DropDownList>--%>
        
        <asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" 
                    DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Font-Names="TH SarabunPSK" Font-Size="14">
                </asp:DropDownList>

    </td>
        
    </tr>
    <tr>
    <td align="right">วันที่รับเอกสาร :</td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_Bill_RECIEVE_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_Bill_RECIEVE_DATE" runat="server"  ></asp:TextBox>
&nbsp;</td>
    </tr>
    <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td><asp:TextBox ID="txt_DOC_NUMBER" runat="server"  ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_DOC_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_DOC_DATE" runat="server"  ></asp:TextBox>

        </td>
    </tr>
   <tr>
        <td align="right">เลขบ. : </td>
        <td><asp:TextBox ID="txt_BILL_NUMBER" runat="server"  ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่บ.: </td>
        <td>
          <%--  <telerik:RadDatePicker ID="rdp_BILL_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_BILL_DATE" runat="server"  ></asp:TextBox>

        </td>
    </tr>
  
    <tr>
        <td align="right" valign="top">รายการ : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"  TextMode="MultiLine" Width="300" Height="70"></asp:TextBox></td>
    </tr>
       <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server"  AutoPostBack="true" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:RadNumericTextBox>
           &nbsp;บาท</td>
    </tr>
  
</table>