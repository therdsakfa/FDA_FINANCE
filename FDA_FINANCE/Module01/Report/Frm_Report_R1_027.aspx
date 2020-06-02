<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R1_027.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R1_027" %>
<%@ Register src="../../Module09/UserControl/UC_Report_Dept_Budget_Adjust.ascx" tagname="UC_Report_Dept_Budget_Adjust" tagprefix="uc2" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register src="../../Module09/UserControl/UC_Report_Dept_Budget_Adjust_Sub.ascx" tagname="UC_Report_Dept_Budget_Adjust_Sub" tagprefix="uc3" %>
<%@ Register src="../../Module09/UserControl/UC_Report_SelectDate_Single.ascx" tagname="UC_Report_SelectDate_Single" tagprefix="uc4" %>
<%@ Register src="../../Module09/UserControl/UC_Report_SelectDate_Between.ascx" tagname="UC_Report_SelectDate_Between" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Report_SelectDate_Between1_txt_DateBegin"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Report_SelectDate_Between1_txt_DateEnd"));
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>รายงานสรุปผลการใช้จ่ายงบประมาณ</td>
        </tr>
        <tr>
            <td>
               ปีงบประมาณ &nbsp;<asp:DropDownList ID="dd_BudgetYear" runat="server" Width="100px" DataTextField="byear" DataValueField="byear">
        </asp:DropDownList>
               <%--<uc2:UC_Report_Dept_Budget_Adjust ID="UC_Report_Dept_Budget_Adjust1" runat="server" />--%>
                <uc1:UC_Report_SelectDate_Between ID="UC_Report_SelectDate_Between1" runat="server" />
            </td>
            <td valign="top">
                <asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />
                
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
