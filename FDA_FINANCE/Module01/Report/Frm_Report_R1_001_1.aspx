<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R1_001_1.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R1_001_1" %>
<%@ Register src="../../Module09/UserControl/UC_Report_SelectDate_Between.ascx" tagname="UC_Report_SelectDate_Between" tagprefix="uc1" %>
<%@ Register src="../../Module09/UserControl/UC_Report_Dept_Budget_Adjust.ascx" tagname="UC_Report_Dept_Budget_Adjust" tagprefix="uc2" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register src="../../Module09/UserControl/UC_Report_Dept_Budget_Adjust_Sub.ascx" tagname="UC_Report_Dept_Budget_Adjust_Sub" tagprefix="uc3" %>
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

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Report_Dept_Budget_Adjust1_rcb_budget");
            combo.set_text(node.get_text());
            combo.set_value(node.get_value());
            cancelDropDownClosing = false;
            combo.hideDropDown();


            //}
        }

        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>รายงานทะเบียนคุมย่อย รง.1</td>
        </tr>
        <tr>
            <td>
               
               <uc1:UC_Report_SelectDate_Between ID="UC_Report_SelectDate_Between1" runat="server" />
               <%--<uc2:UC_Report_Dept_Budget_Adjust ID="UC_Report_Dept_Budget_Adjust1" runat="server" />--%>
                <uc3:UC_Report_Dept_Budget_Adjust_Sub ID="UC_Report_Dept_Budget_Adjust_Sub1" runat="server" />
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
