<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_Receive_Review.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_Receive_Review" %>
<%@ Register src="UserControl/UC_Disburse_Budget_DetailV2.ascx" tagname="UC_Disburse_Budget_DetailV2" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Disburse_Budget_DetailV2_Table.ascx" tagname="UC_Disburse_Budget_DetailV2_Table" tagprefix="uc2" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_DetailV3_Table.ascx" TagPrefix="uc3" TagName="UC_Disburse_Budget_DetailV3_Table" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_DetailV4_Table.ascx" TagPrefix="uc1" TagName="UC_Disburse_Budget_DetailV4_Table" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.2.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {;
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_dodate"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_DOC_DATE"));

            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV2_Table1_dd_CUSTOMER").searchable();
        });

        function clickclose() {
            $("#ctl00_ContentPlaceHolder1_btn_bill_save").hide();

        }

        function clickopen() {
            $("#ctl00_ContentPlaceHolder1_btn_bill_save").show();

        }

    
        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }
</script> 
    
   <script type="text/javascript">
       
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="Panel1" runat="server">
    <table width="100%">
    <tr>
            <td>
           
                <uc1:UC_Disburse_Budget_DetailV2 ID="UC_Disburse_Budget_DetailV21" runat="server" />
           
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_recive" runat="server" Text="รับเรื่องคืน" style="display:none;"/>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Panel ID="Panel4" runat="server" style="display:none;">
             <uc2:UC_Disburse_Budget_DetailV2_Table ID="UC_Disburse_Budget_DetailV2_Table1" runat="server" />
                     </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" style="display:none;">
                <uc1:UC_Disburse_Budget_DetailV4_Table runat="server" ID="UC_Disburse_Budget_DetailV4_Table1" />
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" style="display:none;">
                <uc3:UC_Disburse_Budget_DetailV3_Table runat="server" ID="UC_Disburse_Budget_DetailV3_Table" />
                </asp:Panel>
                
                
            </td>
        </tr>
    </table>
    </asp:Panel>
    </asp:Content>
