﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_Transfer_Out_Budget.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Transfer_Out_Budget" %>
<%@ Register src="UseControl/UC_Maintain_Transfer_Out_BG.ascx" tagname="UC_Maintain_Transfer_Out_BG" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
       
        <tr>
            <td>รายการบันทึกการโอนคืนเงินงบประมาณ</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                
                
                
                <uc1:UC_Maintain_Transfer_Out_BG ID="UC_Maintain_Transfer_Out_BG1" runat="server" />
                
                
                
            </td>
        </tr>
    </table>
</asp:Content>
