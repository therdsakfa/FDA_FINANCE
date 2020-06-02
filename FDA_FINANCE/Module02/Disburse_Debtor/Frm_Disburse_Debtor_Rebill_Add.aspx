<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Debtor_Rebill_Add.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor_Rebill_Add" %>

<%@ Register Src="~/Module02/Disburse_Debtor/UserControl/UC_Disburse_Debtor_Rebill_Add.ascx" TagPrefix="uc1" TagName="UC_Disburse_Debtor_Rebill_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />

    <table width="100%">
     <tr>
         <td align="right">
             <asp:Button ID="btn_bill_add" runat="server" Text="ดึงข้อมูล" Width="100px"/>
         </td>
     </tr>
     <tr>
         <td>
               <uc1:UC_Disburse_Debtor_Rebill_Add runat="server" id="UC_Disburse_Debtor_Rebill_Add" />
         </td>
     </tr>
 </table>
</asp:Content>
