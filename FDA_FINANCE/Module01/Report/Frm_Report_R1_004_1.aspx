<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R1_004_1.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R1_004_1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="../../Module09/UserControl/UC_Report_SelectDate_Between.ascx" TagPrefix="uc1" TagName="UC_Report_SelectDate_Between" %>

<%@ Register src="../../Module09/UserControl/UC_Report_Dept.ascx" tagname="UC_Report_Dept" tagprefix="uc2" %>

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
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Report_Dept_Plan1_rcb_budget");
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
            <td>รายงานยอดรวมแบ่งตามกอง รง.3</td>
        </tr>
        <tr>
            <td>
                ปีงบประมาณ &nbsp;<asp:DropDownList ID="dd_BudgetYear" runat="server" Width="100px" DataTextField="byear" DataValueField="byear" AutoPostBack="true">
        </asp:DropDownList>
                <uc1:UC_Report_SelectDate_Between runat="server" ID="UC_Report_SelectDate_Between1" />
                <asp:Panel ID="Panel1" runat="server">
                    <uc2:UC_Report_Dept ID="UC_Report_Dept1" runat="server" />
                </asp:Panel>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td valign="top">
                
                
                
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
