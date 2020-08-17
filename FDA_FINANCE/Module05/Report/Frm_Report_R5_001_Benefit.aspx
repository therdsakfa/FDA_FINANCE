﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R5_001_Benefit.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R5_001_Benefit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="~/Module09/UserControl/UC_Report_SelectDate_Between.ascx" TagPrefix="uc1" TagName="UC_Report_SelectDate_Between" %>

<%@ Register src="../../Module09/UserControl/UC_Money_Type_Node.ascx" tagname="UC_Money_Type_Node" tagprefix="uc2" %>

<%@ Register src="../../Module09/UserControl/UC_MoneyType_Head.ascx" tagname="UC_MoneyType_Head" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Report_SelectDate_Between_txt_DateBegin"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Report_SelectDate_Between_txt_DateEnd"));
        });

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Money_Type_Node1_rcb_money_type");
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
            <td>รายงานทะเบียนคุม สวัสดิการกรมพัฒ ฯ (รง.1)</td>
        </tr>
        <tr>
            <td>
                ปี พ.ศ. &nbsp;<asp:DropDownList ID="dd_BudgetYear" runat="server" Width="100px" DataTextField="byear" DataValueField="byear" AutoPostBack="true">
        </asp:DropDownList>
                <%--<uc2:UC_Money_Type_Node ID="UC_Money_Type_Node1" runat="server" />--%>

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