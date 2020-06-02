<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_BudgetPlan_Adjust_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_BudgetPlan_Adjust_Edit" %>
<%@ Register src="UserControl/UC_BudgetPlan_Adjust_Detail.ascx" tagname="UC_BudgetPlan_Adjust_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/Jsdatemain.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_BudgetPlan_Adjust_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_BudgetPlan_Adjust_Detail1_txt_EXPORT_DATE"));


        });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
<tr>
<td>
แก้ไขข้อมูลงบประมาณจัดสรร
</td>
</tr>
<tr>
<td>



    <uc1:UC_BudgetPlan_Adjust_Detail ID="UC_BudgetPlan_Adjust_Detail1" 
        runat="server" />



</td>
</tr>
<tr>
<td align = "center"> 
    <asp:Button ID="btnSave" runat="server" Text="บันทึก" /> &nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" />
</td>
</tr>
</table>
</asp:Content>
