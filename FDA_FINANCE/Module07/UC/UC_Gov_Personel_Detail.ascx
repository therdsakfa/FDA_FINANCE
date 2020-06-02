 <%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Gov_Personel_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Gov_Personel_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table width="80%" align="center">
    <tr>
        <td>
            <br /><br />
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 30%">คำนำหน้าชื่อ :
        </td>
        <td style="width: 70%">
             <asp:DropDownList ID="dd_prefix" runat="server" Height="30px" Width="25%" DataTextField="PREFIX_NAME" DataValueField="PREFIX_ID">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 30%">ชื่อ :</td>
        <td style="width: 70%">
             <asp:TextBox ID="txt_Name" runat="server"  Height="30px" Width="70%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 30%">นามสกุล :</td>
        <td style="width: 70%">
            <asp:TextBox ID="txt_Surname" runat="server" Height="30px" Width="70%"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right" style="width: 30%">เลขที่บัตรประจำตัวประชาชน :</td>
        <td style="width: 70%">
            <asp:TextBox ID="txt_Personal_ID" runat="server" Height="30px" Width="50%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 30%">ตำแหน่ง : </td>
        <td style="width: 70%">
            <asp:DropDownList ID="dd_Position" runat="server" 
                 DataTextField="POSITION_NAME" DataValueField="POSITION_ID" Height="30px" Width="70%">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 30%">ระดับ : </td>
        <td style="width: 70%">
            <asp:DropDownList ID="dd_level" runat="server" 
                 DataTextField="LEVEL_NAME" DataValueField="LEVEL_ID" Height="30px" Width="50%">
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td align="right" style="width: 30%">หน่วยงาน :</td>
        <td style="width: 70%">
            <asp:DropDownList ID="dd_Department" runat="server" 
                 DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID"  Height="30px" Width="70%">
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td align="right" style="width: 30%">ธนาคาร : </td>
        <td style="width: 70%">
          <asp:DropDownList ID="dd_BookBank" runat="server" DataValueField="BANK_ID" DataTextField="BANK_NAME" Height="30px" Width="70%">
          </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 30%">เลขบัญชีธนาคาร : </td>
        <td style="width: 70%">
          <%--  <telerik:RadMaskedTextBox ID="rmt_Bank_Account" runat="server" Height="30px" Width="50%"></telerik:RadMaskedTextBox>--%>
<%--         Mask="###-#-#####-#" --%>
            <asp:TextBox ID="txt_Bank_Account" runat="server" Height="30px" Width="50%"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right" style="width: 30%">เลขสหกรณ์ :&nbsp;</td>
        <td style="width: 70%">
            <asp:TextBox ID="txt_cooperate" runat="server" Height="30px" Width="50%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 30%">สถานะ :</td>
        <td style="width: 70%">
            <asp:DropDownList ID="dd_Status" runat="server"  Height="30px" Width="30%">
                <asp:ListItem Value="1">ปกติ</asp:ListItem>
                <asp:ListItem Value="2">ลาออก</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
</table>
