<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R2_008.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R2_008" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Src="~/Module09/UserControl/UC_Report_SelectUser_NAME_AD_NAME.ascx" TagPrefix="uc1" TagName="UC_Report_SelectUser_NAME_AD_NAME" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_ctl00_dl_User").searchable();

        });


   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>รายงานทะเบียนคุมลูกหนี้รายตัว (เงินทดรองราชการ)</td>
        </tr>
        <tr>
            <td>
                 ปีงบประมาณ  &nbsp;<asp:DropDownList ID="dd_BudgetYear" runat="server" Width="100px" DataTextField="byear" DataValueField="byear" AutoPostBack="true">
        </asp:DropDownList> &nbsp;
                <uc1:UC_Report_SelectUser_NAME_AD_NAME runat="server" ID="UC_Report_SelectUser_NAME_AD_NAME1" />
            </td>
            <td>
                <asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />
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
