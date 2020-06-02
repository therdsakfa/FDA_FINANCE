<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R9_002.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R9_002" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register src="../UserControl/UC_Report_SelectDate_Single.ascx" tagname="UC_Report_SelectDate_Single" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Report_SelectDate_Single_txt_DateSelect"));
        });
    </script>
    <table>
        <tr>
            <td>รายงานใบหักภาษี</td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Report_SelectDate_Single ID="UC_Report_SelectDate_Single1" runat="server" />
            </td>
            <td>
                <asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />
            </td>
        </tr>
        <tr>
            <td>เลขบ. <asp:TextBox ID="txt_bill_number" runat="server"></asp:TextBox></td>
            <td>
                <asp:DropDownList ID="dd_BudgetYear" runat="server" DataTextField="byear" DataValueField="byear" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
