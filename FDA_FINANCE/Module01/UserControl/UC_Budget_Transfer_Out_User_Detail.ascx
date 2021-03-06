﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Transfer_Out_User_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Transfer_Out_User_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
   
    <tr>
        <td align="right">
            วันที่ทำรายการ :
        </td>
        <td>
            <asp:TextBox ID="txt_BUDGET_TRANSFER_DATE" runat="server"></asp:TextBox>
        </td>
        <td align="right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td align="right">
            วันที่เอกสาร :
        </td>
        <td>
            <asp:TextBox ID="txt_BUDGET_TRANSFER_DOC_DATE" runat="server"></asp:TextBox>
        </td>
        <td align="right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     
     <tr>
        <td align="right">
            เลขที่เอกสาร :</td>
        <td>
            <asp:TextBox ID="txt_BUDGET_TRANSFER_DOC_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     
     <tr>
        <td align="right">
            ครั้งที่โอน :</td>
        <td>
            <asp:TextBox ID="txt_BUDGET_TRANSFER_COUNT" runat="server"></asp:TextBox>
        </td>
        <td align="right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     
     <tr>
        <td align="right">
            หน่วยงานที่โอน : 
        </td>
        <td>
            <asp:Label ID="lb_dept" runat="server"></asp:Label>
         </td>
        <td align="right">
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
    </tr>
     
     <tr>
        <td align="right">
            งบค่าใช้จ่าย 
        </td>
        <td colspan="3">
            
            <asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" class="ddl" Width="300px" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
            </asp:DropDownList>
            
         </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lb_sub_bg1" runat="server" Text="งบย่อย" style="display:none"></asp:Label>
        </td>
        <td>
            
            <asp:DropDownList ID="dd_sub_bg1" runat="server" style="display:none" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" AutoPostBack="true">
            </asp:DropDownList>
         </td>
    </tr>
    <tr>
        <td align="right">
            จำนวนเงินคงเหลือ :</td>
        <td>
            
            <asp:Label ID="lb_money" runat="server"></asp:Label>
            
         &nbsp;บาท</td>
    </tr>
    <tr>
        <td align="right">
            รายละเอียดของหน่วยงานที่โอน :
        </td>
        <td colspan="3">
            <asp:TextBox ID="txt_BUDGET_FROM_TRANSFER_DESCRIPTION" runat="server" Width="350px" Height="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            หน่วยงานภายนอกที่รับโอน :
        </td>
        <td colspan="3">
            <asp:DropDownList ID="dd_out_dept" runat="server" DataTextField="OUTSIDE_DEPARTMENT_NAME" DataValueField="ID" AutoPostBack="true">

            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            จำนวนเงินที่โอน : 
        </td>
        <td colspan="3">
            <telerik:RadNumericTextBox ID="rnt_BUDGET_TRANSFER_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
        &nbsp;บาท</td>
    </tr>
</table>