<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="FRM_PAY_FEENO.aspx.vb" Inherits="FDA_FINANCE.FRM_PAY_FEENO" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body" style="width: 100%;">
        <h3>ดึงข้อมูลใบสั่งชำระระบบ Privus ไปออกใบเสร็จรับเงินในระบบโลจิสติกส์ (ฝ่ายการคลัง)</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display: none;" />
    </div>
    <div class="panel panel-body" style="width: 100%;">
        <table width="100%">
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">เลขที่ใบสั่งชำระ : 
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY1" runat="server" Width="90px" style="display:none;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY2" runat="server" Width="90px"></asp:TextBox>
                            </td>
                            <td align="right">หน่วยงาน</td>
                            <td>
                                <asp:DropDownList ID="ddl_department" runat="server" DataTextField="DEPARTMENT_NAME" DataValueField="DVCD" Width="200px">
                    </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btn_Search" runat="server" Text="ค้นหาใบสั่งชำระ" CssClass="btn-lg" />
                            </td>
                        </tr>
                    </table>
                </td>
              
            </tr>
        </table>
    </div>
    <div class="panel panel-body" style="width: 100%;">
 <telerik:radgrid ID="rg_receive" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" Width="100%">
                    </telerik:radgrid>
        </div>
</asp:Content>
