﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Search_Form_Check.ascx.vb" Inherits="FDA_FINANCE.UC_Search_Form_Check" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    #tb_search {
        font-size: 12px;
    }
</style>
ค้นหาข้อมูล
<table width = "100%" id="tb_search">
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_DOC_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
        <td align="right">เลขที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่รับเอกสาร : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_Bill_RECIEVE_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่เช็ค : </td>
        <td>
            <asp:TextBox ID="txt_Check_Number" runat="server"></asp:TextBox>
        </td>
        <td align="right">เลขที่เบิก : </td>
        <td>
            <asp:TextBox ID="txt_BILL_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">เลข ขบ. : </td>
        <td>
            <asp:TextBox ID="txt_GFMIS" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>