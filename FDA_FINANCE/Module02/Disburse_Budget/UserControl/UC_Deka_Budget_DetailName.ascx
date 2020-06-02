<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Deka_Budget_DetailName.ascx.vb" Inherits="FDA_FINANCE.UC_Deka_Budget_DetailName" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<table width="80%" align="center" >
        <tr>
            <td>
                <table width="100%" align="center">
                    <tr>
                        <td style="width: 30%">
                            <asp:Label ID="lb_CarPosition" runat="server" Text="หมวดค่าใช้จ่าย"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                        <td style="width: 70%" align="left">
                            <asp:DropDownList ID="dd_Budgetype" runat="server" DataTextField="BUDGET_NAMELIST" AutoPostBack="true" DataValueField="IDA" Width="50%" Height="30px"  ForeColor="Black" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td >
                            <br />

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">
                            <asp:Label ID="lb_NameList" runat="server" Text="ชื่อรายการซื้อ/จ้าง"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                        <td style="width: 70%" align="left">
                            <asp:TextBox ID="txt_NameList" runat="server" Width="80%" Height="30px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td >
                            <br />
                       <%--     <br />--%>
                        </td>
                    </tr>
                </table>
                    
            </td>
        </tr>
    </table>