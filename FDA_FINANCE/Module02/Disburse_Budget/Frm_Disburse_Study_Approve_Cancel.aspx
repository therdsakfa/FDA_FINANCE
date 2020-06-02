<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Study_Approve_Cancel.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Study_Approve_Cancel" %>
<%@ Register src="UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Disburse_Cure_Approve_Cancel.ascx" tagname="UC_Disburse_Cure_Approve_Cancel" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
       
        <tr>
        <td>
        <table><tr><td>  
            <uc1:UC_Search_Form ID="UC_Search_Form1" runat="server" />
            </td>
        
        <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" 
                Height="59px" /></td></tr></table>
          
            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </td>
        </tr>
        <tr >
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td>การยกเลิกการอนุมัติการเบิกค่าเล่าเรียนบุตร</td>
        </tr>
        <tr>
            <td>
                
                <uc2:UC_Disburse_Cure_Approve_Cancel ID="UC_Disburse_Cure_Approve_Cancel1" runat="server" />
                
            </td>
        </tr>
    </table>
</asp:Content>
