<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_RELATE_BILL_DETAILV2.ascx.vb" Inherits="FDA_FINANCE.UC_RELATE_BILL_DETAILV2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียด">
    <table>
        <tr>
            <td align="right">ประเภทตัดงบประมาณ :&nbsp;</td>
            <td>
                <asp:RadioButtonList ID="rdl_type" runat="server" RepeatDirection="Horizontal">
              <%--      <asp:ListItem Value="1" Selected="True">เบิกจ่าย</asp:ListItem>--%>
                    <asp:ListItem Value="2" Selected="True">เงินยืม</asp:ListItem>
                    <asp:ListItem Value="3">ก่อหนี้ผูกพัน (PO)</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
     <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td><asp:TextBox ID="txt_DOC_NUMBER" runat="server" AutoPostBack="true" ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_DATE" runat="server"  ></asp:TextBox>

        </td>
    </tr>
    
        <tr>
        <td align="right">รายการ : </td>
        <td><asp:TextBox ID="txt_DESCRIPTION" runat="server"   TextMode="MultiLine" Height="40px" Width="100%"> </asp:TextBox></td>
    </tr>
  
        
        <tr>
        <td align="right" >วันที่ทำรายการ :</td>
        <td >
        
            <asp:TextBox ID="txt_dodate" runat="server"></asp:TextBox>
        
        </td>
    </tr>
        
</table>
</asp:Panel>


