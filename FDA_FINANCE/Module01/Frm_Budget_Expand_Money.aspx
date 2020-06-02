<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Budget_Expand_Money.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Expand_Money" %>
<%@ Register src="../Module02/Disburse_Budget/UserControl/UC_Budget_Amount_Detail.ascx" tagname="UC_Budget_Amount_Detail" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Budget_Expand_Money.ascx" tagname="UC_Budget_Expand_Money" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>เงินขยายเงินกันไว้เหลื่อมปี</td>
        </tr>
        <tr>
            <td bgcolor="#FFFFCC" style="border: thin ridge #000000">
                หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" Font-Names="TH SarabunPSK" Font-Size="14" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true">

            </asp:DropDownList> <br/>
                งบประมาณที่ได้รับการจัดสรร&nbsp;
                <asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr bgcolor="#CCFFCC">
            <td>
                <uc1:UC_Budget_Amount_Detail ID="UC_Budget_Amount_Detail1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>บันทึกเงินขยายเงินกันไว้เหลื่อมปี</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc2:UC_Budget_Expand_Money ID="UC_Budget_Expand_Money1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
