<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_UserPermission.ascx.vb" Inherits="DTAM.UC_UserPermissionAdd" %>
<table width="800px">
    <tr>
        <td>
            <table width="50%">
                <tr>
                    <td>
                    ชื่อ - นามสกุล : 
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    ตำแหน่ง : 
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div id="chBoxMenu">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="ทดสอบ1" /><br />
                <asp:CheckBox ID="CheckBox2" runat="server" Text="ทดสอบ2" />
            </div>
            
           
        </td>
    </tr>
</table>