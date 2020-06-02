<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Budget_Transfer_Share_Type_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Transfer_Share_Type_Insert" %>

<%@ Register src="UserControl/UC_Budget_Transfer_Share_Type_Detail.ascx" tagname="UC_Budget_Transfer_Share_Type_Detail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Scripts/jquery-1.7.1.js"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Budget_Transfer_Receive_Detail1_txt_BUDGET_TRANSFER_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Budget_Transfer_Receive_Detail1_txt_BUDGET_TRANSFER_DOC_DATE"));
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");

        });


</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกการโอน">
    <table>
    <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                
               
                
              
                
               
                
                <uc1:UC_Budget_Transfer_Share_Type_Detail ID="UC_Budget_Transfer_Share_Type_Detail1" runat="server" />
                
               
                
              
                
               
                
            </td>
        </tr>
        <tr>
        <td>
        <asp:Button ID="btn_save" runat="server" Text="บันทึกการโอน" />
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
