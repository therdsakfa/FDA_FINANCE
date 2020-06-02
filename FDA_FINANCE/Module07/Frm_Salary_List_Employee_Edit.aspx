<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Salary_List_Employee_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Salary_List_Employee_Edit" %>
<%@ Register src="UC/UC_Salary_Paylist_Employee_Detail.ascx" tagname="UC_Salary_Paylist_Employee_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../../Scripts/jquery-1.7.1.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Other_Detail1_txt_DOC_RECEIVE_DATE"));
        //    showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Other_Detail1_txt_DOC_DATE"));
        //    showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Other_Detail1_txt_BILL_DATE"));
        //    $("#ctl00_ContentPlaceHolder1_UC_Disburse_Other_Detail1_dd_CUSTOMER").searchable();
        //});
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="900px">
    <tr>
            <td>

           
           

                <uc1:UC_Salary_Paylist_Employee_Detail ID="UC_Salary_Paylist_Employee_Detail1" runat="server" />

           
           

            </td>
        </tr>
        <tr>
        <td>
        <asp:Button ID="btn_bill_save" runat="server" Text="แก้ไข" Width="70px" />
        </td>
            
        </tr>
    </table>
</asp:Content>