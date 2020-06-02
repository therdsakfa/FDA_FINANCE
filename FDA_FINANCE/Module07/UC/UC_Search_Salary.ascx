<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Search_Salary.ascx.vb" Inherits="FDA_FINANCE.UC_Search_Salary" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<h3>ค้นหาข้อมูล</h3>
<table >
    <tr>
        <td align="right">รายชื่อ : </td>
        <td>
           <%-- <asp:DropDownList ID="ddlName" runat="server" DataTextField="fullname" DataValueField="IDRUN"></asp:DropDownList>--%>
            <asp:TextBox ID="txt_NAME" runat="server" Width="193px"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </td>
       <%-- <td align="right">สถานะพนักงาน : </td>
        <td>
            <asp:DropDownList ID="dd_Status" runat="server" >
                <asp:ListItem Value="">--ทั้งหมด--</asp:ListItem>
                <asp:ListItem Value="1">ปกติ</asp:ListItem>
                <asp:ListItem Value="2">ลาออก</asp:ListItem>
            </asp:DropDownList>
        </td>--%>
        <td align="right">หน่วยงาน : </td>
        <td>
            <asp:DropDownList ID="ddl_department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" 
                            DataValueField="DEPARTMENT_ID" Width="230px" Height="21px"></asp:DropDownList>
        </td>
        
    </tr>
    
</table>