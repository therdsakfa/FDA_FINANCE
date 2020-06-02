<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_User.ascx.vb" Inherits="FDA_FINANCE.UC_User" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgUser" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="800px">
<%--<MasterTableView >
    <Columns>
        <telerik:GridBoundColumn HeaderText="ลำดับที่" >
        <ItemStyle Width="5%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="เลขประจำตัวประชาชน" >
        <ItemStyle Width="10%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="คำนำหน้าชื่อ" >
        <ItemStyle Width="10%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ชื่อ" >
        <ItemStyle Width="25%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="นามสกุล" >
        <ItemStyle Width="30%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ประเภทเจ้าหน้าที่" >
        <ItemStyle Width="10%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="หน่วยงาน" >
        <ItemStyle Width="10%" />
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn HeaderText="การกำหนดสิทธิ์">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server">กำหนดสิทธิ์ผู้ใช้</asp:LinkButton>
        </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>
</MasterTableView>--%>
</telerik:RadGrid>