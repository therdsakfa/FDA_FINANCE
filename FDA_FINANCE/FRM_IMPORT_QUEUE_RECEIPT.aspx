<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_IMPORT_QUEUE_RECEIPT.aspx.vb" Inherits="FDA_FINANCE.FRM_IMPORT_QUEUE_RECEIPT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดไฟล์" />
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        รายการ REF ที่ยังไม่ได้ออกใบเสร็จ
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false">
                            <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="IDA" Display="false" HeaderText="IDA" DataField="IDA">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="REF01" HeaderText="REF01" DataField="REF01">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="REF02" HeaderText="REF02" DataField="REF02">
                            </telerik:GridBoundColumn>
                            
                        </Columns>
                    </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
