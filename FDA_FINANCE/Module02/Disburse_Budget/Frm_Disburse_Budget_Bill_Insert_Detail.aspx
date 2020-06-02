<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_Bill_Insert_Detail.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_Bill_Edit_Detail" %>
<%@ Register src="UserControl/UC_Disburse_Budget_Bill_Detail.ascx" tagname="UC_Disburse_Budget_Bill_Detail" tagprefix="uc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../validate/jquery.validationEngine.js"></script>
    <script src="../../validate/jquery.validationEngine-en.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Bill_Detail1_rdp_GFMIS_DATE"));
            jQuery("#aspnetForm").validationEngine();
        });
</script> 


    <table>
<tr>
<td>บันทึกเลข GFMIS</td>
</tr>
<tr>
    
<td>
    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
<uc1:UC_Disburse_Budget_Bill_Detail ID="UC_Disburse_Budget_Bill_Detail1" 
        runat="server" />
</td>
</tr>

<tr>
<td align="center" >
    <asp:Button ID="btnSave" runat="server" Text="บันทึกข้อมูล" class="submit"/>
    &nbsp;</td>
</tr>
</table>
    
</asp:Content>
