﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R2_027.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R2_027" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Src="~/Module09/UserControl/UC_Report_SelectDate_Single.ascx" TagPrefix="uc1" TagName="UC_Report_SelectDate_Single" %>


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
            <td>รายงานใบสำคัญรอการจ่ายเช็ค</td>
        </tr>
        <tr>
            
            <td>
                <%--<uc1:UC_Report_SelectDate_Single runat="server" ID="UC_Report_SelectDate_Single" />--%>
                ปีงบประมาณ : <asp:DropDownList ID="dd_BudgetYear" runat="server" AutoPostBack="true" DataTextField="BUDGET_YEAR" DataValueField="BUDGET_YEAR">
                
                        </asp:DropDownList> 
                เดือน : <asp:DropDownList id="dd_month" runat="server">
                <asp:ListItem Value="1">มกราคม</asp:ListItem>
                <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                <asp:ListItem Value="4">เมษายน</asp:ListItem>
                <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                <asp:ListItem Value="7">กรกฏาคม</asp:ListItem>
                <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                <asp:ListItem Value="9">กันยายน</asp:ListItem>
                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
            </asp:DropDownList>
                &nbsp;<asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
