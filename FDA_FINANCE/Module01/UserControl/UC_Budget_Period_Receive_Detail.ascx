<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Period_Receive_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Period_Receive_Detail" %>
<table>
    <tr>
        <td>เลขที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>วันที่ออกหนังสือ : </td>
        <td>
            <asp:TextBox ID="txt_DOC_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>ชื่อหน่วยงานย่อย : </td>
        <td>
            <asp:TextBox ID="txt_SUB_DEPARTMENT_NAME" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>วันที่ส่งออก : </td>
        <td>
            <asp:TextBox ID="txt_EXPORT_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>งวดที่ : </td>
        <td>
            <asp:TextBox ID="txt_PERIOD_COUNT" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>ครั้งที่ : </td>
        <td>
            <asp:TextBox ID="txt_COUNT" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>จำนวนเงิน :</td>
        <td>
            <asp:Label ID="lb_Amount" runat="server" Text="0.00"></asp:Label>
        &nbsp;บาท</td>
    </tr>
    <tr>
        <td>รายละเอียด : </td>
        <td>
            <asp:TextBox ID="txt_DESCRIPTION" runat="server" Width="250px" Height="60px"></asp:TextBox>
        </td>
    </tr>
</table>