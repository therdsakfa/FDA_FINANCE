﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R3_018.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R3_018" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../../Module09/UserControl/UC_Report_SelectDate_Between.ascx" tagname="UC_Report_SelectDate_Between" tagprefix="uc2" %>

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
            showdate($("#ctl00_ContentPlaceHolder1_UC_Report_SelectDate_Between1_txt_DateBegin"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Report_SelectDate_Between1_txt_DateEnd"));
        });
    </script>
    <table>
        <tr>
            <td>รายงานการรับเงินแยกตามประเภทรายได้</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <uc2:UC_Report_SelectDate_Between ID="UC_Report_SelectDate_Between1" runat="server" />
                        </td>
                        <td>ผู้รับเงิน :</td>
                        <td>
                            <asp:DropDownList ID="ddl_receiver" runat="server" Width="90px" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="ชื่อผู้พิมพ์รายงาน :" style="display:none;"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddl_print" runat="server" Width="90px" style="display:none;"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />
                            <asp:Button ID="btn_Print" runat="server" Text="พิมพ์รายงาน" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>