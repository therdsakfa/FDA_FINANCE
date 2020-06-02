<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Relate_Detail_New.ascx.vb" Inherits="FDA_FINANCE.UC_Relate_Detail_New" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลงบประมาณ">
    <table>
        <tr>
            <td align="right">ชื่อหน่วยงาน :</td>
            <td>
                <asp:Label ID="lb_dept" runat="server"></asp:Label>
            </td>

        </tr>
        <tr>
            <td align="right">ชื่อโครงการ/กิจกรรม :</td>
            <td>
                <asp:Label ID="lb_project_name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">แผนงาน :</td>
            <td>
                <asp:Label ID="lb_plan" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">ผลผลิต :</td>
            <td>
                <asp:Label ID="lb_product" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">กิจกรรมหลักที่ :</td>
            <td>
                <asp:Label ID="lb_activity" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">จำนวนเงินคงเหลือ :</td>
            <td> &nbsp;
                <asp:Label ID="lb_Amount" runat="server" Text="0.00"></asp:Label>
                &nbsp; บาท
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" GroupingText="ข้อมูลผูกพัน">
    <table>
        <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td><asp:TextBox ID="txt_DOC_NUMBER" runat="server"  ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_DATE" runat="server"  ></asp:TextBox>

        </td>
    </tr>
        <tr>
        <td align="right">เรื่อง : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"   TextMode="MultiLine" Height="40px" Width="100%"> </asp:TextBox></td>
    </tr>
        <tr>
            <td align="right">ประเภทค่าใช้จ่าย :</td>
            <td>
                <asp:DropDownList ID="dd_paylist" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_AMOUNT" Runat="server"    Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
           &nbsp;บาท</td>
    </tr>
        <tr>
            <td align="right">รหัสกิจกรรม :</td>
            <td>
                <asp:TextBox ID="txt_act_code" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>
