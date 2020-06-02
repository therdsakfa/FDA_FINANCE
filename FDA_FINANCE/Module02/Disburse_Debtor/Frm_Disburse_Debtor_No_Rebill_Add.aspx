<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Debtor_No_Rebill_Add.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor_No_Rebill_Add" %>
<%@ Register src="UserControl/UC_Disburse_Debtor_No_Rebill_Add.ascx" tagname="UC_Disburse_Debtor_No_Rebill_Add" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="750px">
     <tr>
         <td align="right">
             <asp:Button ID="btn_bill_add" runat="server" Text="เบิก" Width="100px"/>
         </td>
     </tr>
     <tr>
         <td>
               
             <uc1:UC_Disburse_Debtor_No_Rebill_Add ID="UC_Disburse_Debtor_No_Rebill_Add1" runat="server" />
               
         </td>
     </tr>
 </table>
</asp:Content>
