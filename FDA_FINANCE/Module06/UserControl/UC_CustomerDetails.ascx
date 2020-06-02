<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_CustomerDetails.ascx.vb" Inherits="FDA_FINANCE.UC_CustomerDetails" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .style1
    {
        height: 26px;
    }
</style>
<table width="900">
<tr>
<td colspan = "4">
    <asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลเจ้าหนี้">
    <table>
    <tr>
    <%--<td align="right" >เลขประจำตัวผู้เสียภาษี : </td>
        <td class="style1">
            <asp:TextBox ID="txt_TAX_NUMBER" runat="server"  ></asp:TextBox>

        </td>--%>
        <td align="right" >เลขประจำตัวประชาชน : </td>
        <td class="style1">
            <asp:DropDownList ID="dd_Personal_ID" runat="server" AutoPostBack="True" DataTextField="NATIONAL_ID" DataValueField="NATIONAL_ID" DataSourceID="sql_personalID" style="display:none;"></asp:DropDownList>
            <asp:TextBox ID="txt_personal_edit" runat="server"></asp:TextBox>
            <asp:Button ID="get_detail" runat="server" Text="เรียกข้อมูลเจ้าหนี้" />
            <%--<asp:TextBox ID="txt_personal_edit_v2" runat="server"></asp:TextBox>--%>
            
            <%--&nbsp;<asp:Button ID="getSW" runat="server" Text="เรียกข้อมูลIDEM" />--%>
            <%--<asp:Button ID="getSW_2" runat="server" Text="เรียกข้อมูลส่วนกลาง"/>--%>
        
        </td>
    </tr>
    <tr>
     <td align="right">
    ประเภทเจ้าหนี้ : 
    </td>
    <td>
        <asp:DropDownList ID="ddCustomerType" runat="server" DataValueField="CUSTOMER_TYPE_ID" DataTextField="CUSTOMER_TYPE" AutoPostBack="True">
        </asp:DropDownList>
       <%-- <asp:RadioButtonList ID="rd_Customertype" runat="server" >
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
        </asp:RadioButtonList>--%>
        <%--<asp:DropDownList ID="ddCustomerType" runat="server">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
        </asp:DropDownList>--%>
    </td>
     <td align="right">ชื่อเจ้าหนี้ : </td>
        <td><asp:TextBox ID="txt_CUSTOMER_NAME" runat="server"  Width="250px" ></asp:TextBox></td>
    </tr>
     <tr>
   
        <td align="right">สั่งจ่ายในนาม : </td>
        <td><asp:TextBox ID="txt_PAYABLE_NAME" runat="server"  ></asp:TextBox></td>
        <td align="right">ประเภทเจ้าหน้าที่ :</td>
        <td>
            <asp:DropDownList ID="dd_personal_type" runat="server">
                <asp:ListItem Value="0">ไม่มี</asp:ListItem>
                <asp:ListItem Value="1">ข้าราชการ</asp:ListItem>
                <asp:ListItem Value="2">ลูกจ้างประจำ</asp:ListItem>
                <asp:ListItem Value="3">พนักงานราชการ</asp:ListItem>
                <asp:ListItem Value="4">ข้าราชการบำนาญ</asp:ListItem>
                <asp:ListItem Value="5">ลูกจ้างเหมา</asp:ListItem>
            </asp:DropDownList>
         </td>
    </tr>
        
    </table>
    </asp:Panel>
</td>
</tr>
    
<tr>
<td colspan = "4">
    <asp:Panel ID="Panel2" runat="server" GroupingText="รายละเอียดย่อย">
    <table>
        <tr>
            <td align="right">ที่อยู่เต็ม :</td>
            <td><asp:TextBox ID="txt_FullAddress" runat="server" TextMode="MultiLine" Height="57px" Width="304px"></asp:TextBox></td>
        </tr>
    <%--<tr>
    <td align="right">บ้านเลขที่ : </td>
        <td><asp:TextBox ID="txt_H_NUMBER" runat="server"  ></asp:TextBox></td>
        <td align="right">หมู่ที่ : </td>
        <td><asp:TextBox ID="txt_MOO" runat="server"  ></asp:TextBox></td>
    </tr>--%>
    <%--<tr>
        <td align="right">ซอย : </td>
        <td><asp:TextBox ID="txt_SOI" runat="server"  ></asp:TextBox></td>
        <td align="right">ถนน : </td>
        <td><asp:TextBox ID="txt_ROAD_NAME" runat="server"   ></asp:TextBox></td>
    </tr>--%>
    <%--<tr>
        <td align="right">แขวง/ตำบล : </td>
        <td>
            
            <asp:TextBox ID="txt_DISTICT" runat="server"></asp:TextBox>
        </td>
        <td align="right">เขต/อำเภอ : </td>
        <td>
           
             <asp:TextBox ID="txt_PREFECTURE" runat="server"></asp:TextBox>
        </td>
    </tr>--%>
    <%--<tr>
        
        <td align="right">จังหวัด : </td>
        <td>
            
             <asp:TextBox ID="txt_PROVINCE" runat="server"></asp:TextBox>
        </td>
         <td align="right">รหัสไปรษณีย์ : </td>
        <td><asp:TextBox ID="txt_ZIP_CODE" runat="server"  ></asp:TextBox></td>
    </tr>--%>
    <tr>
       
        <td align="right">โทรศัพท์ : </td>
        <td><asp:TextBox ID="txt_TEL_NUMBER" runat="server"  ></asp:TextBox></td>
        <td align="right">E-mail : </td>
        <td><asp:TextBox ID="txt_EMAIL" runat="server"  ></asp:TextBox></td>
    </tr>
     <tr>
        
        <td align="right">แฟกซ์ : </td>
        <td><asp:TextBox ID="txt_FAX" runat="server"  ></asp:TextBox></td>
        <td></td><td></td>
    </tr>
    </table>
    </asp:Panel>
</td>
</tr>
    
    
</table>

<%--<asp:SqlDataSource ID="sql_taxID" runat="server" ConnectionString="<%$ ConnectionStrings:DTAMConnectionString %>" SelectCommand="Select*
From MAS_CUSTOMER c
Where c.TAX_NUMBER <> ''
and c.TAX_NUMBER is not null
and c.TAX_NUMBER <> '0000000000'
order by c.TAX_NUMBER asc">
            </asp:SqlDataSource>--%>
<asp:SqlDataSource ID="sql_personalID" runat="server" ConnectionString="<%$ ConnectionStrings:DTAMConnectionString %>" SelectCommand="SELECT *
  FROM [FDA_BG].[dbo].[MAS_PERSONAL] as p
  Where p.NATIONAL_ID <> ''
  and p.NATIONAL_ID <> '-'
  order by p.NATIONAL_ID asc">
            </asp:SqlDataSource>

<asp:SqlDataSource ID="sql_dept" runat="server" ConnectionString="<%$ ConnectionStrings:DTAMConnectionString %>" SelectCommand="Select*
From MAS_DEPARTMENT d
Order By DEPARTMENT_ID asc">
            </asp:SqlDataSource>