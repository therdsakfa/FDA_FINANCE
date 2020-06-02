<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Cure_Pay_Unlock_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Cure_Pay_Unlock_Insert" %>
<%@ Register src="UserControl/UC_Disburse_Budget_PayType_Pass_Pay_Unlock_Detail.ascx" tagname="UC_Disburse_Budget_PayType_Pass_Pay_Unlock_Detail" tagprefix="uc1" %>

<%@ Register src="UserControl/UC_Disburse_Cure_Study_Pay_Unlock_Detail.ascx" tagname="UC_Disburse_Cure_Study_Pay_Unlock_Detail" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Cure_Study_Pay_Unlock_Detail1_txt_RETURN_APPROVE_DATE"));

        });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%"> 
<tr>
<td>

    <uc2:UC_Disburse_Cure_Study_Pay_Unlock_Detail ID="UC_Disburse_Cure_Study_Pay_Unlock_Detail1" runat="server" />

</td>
</tr>
<tr>
<td> 
    <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="btn-lg" />
</td>
</tr>
</table>
</asp:Content>
