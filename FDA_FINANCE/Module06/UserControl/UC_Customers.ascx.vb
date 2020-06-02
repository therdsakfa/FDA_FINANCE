Imports Telerik.Web.UI
Partial Public Class UC_Customers
    Inherits System.Web.UI.UserControl



    Private _EnableEdit As Boolean
    <System.ComponentModel.DefaultValue(True)> Public Property EnaleEdit() As Boolean
        Get
            Return _EnableEdit
        End Get
        Set(ByVal value As Boolean)
            _EnableEdit = value
        End Set
    End Property





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ut_seq As New Radgrid_Utility
            rgCustomer.Rebind()
            ut_seq.addSeqRG(rgCustomer)
        End If
    End Sub


    ''' <summary>
    ''' กำหนดชื่อคอลัมน์ของตารางรายละเอียดเจ้าหนี้
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgCustomer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgCustomer.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgCustomer
        Rad_Utility.addColumnBound("CUSTOMER_ID", "CUSTOMER_ID", False)
        Rad_Utility.addColumnBound("id", "ลำดับที่", width:=40)
        'Rad_Utility.addColumnBound("TAX_NUMBER", "เลขประจำตัวผู้เสียภาษี", width:=130)
        Rad_Utility.addColumnBound("PERSONAL_ID", "เลขประจำตัวประชาชน", width:=130)
        Rad_Utility.addColumnBound("FullName", "ชื่อเจ้าหนี้", width:=130)
        Rad_Utility.addColumnBound("TEL_NUMBER", "โทรศัพท์")
        'Rad_Utility.addColumnBound("FAX", "FAX")
        'Rad_Utility.addColumnBound("EMAIL", "EMAIL")
        'Rad_Utility.addColumnIMG("E", "แก้ไขข้อมูล", "E", 0, "คุณต้องการแก้ไขหรือไม่", img:=True, type_img:="edit")
        'Rad_Utility.addColumnButton("D", "ลบข้อมูล", "D", 0, "คุณต้องการลบหรือไม่")
        Rad_Utility.addColumnButton("A", "เพิ่มสัญญา", "A", 0, "")
        'Rad_Utility.addColumnIMG("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", img:=True, type_img:="delete")

    End Sub
    ''' <summary>
    ''' กำหนดคำสั่งของตารางรายละเอียดเจ้าหนี้
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgCustomer_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgCustomer.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            'If e.CommandName = "Delete" Then
            '    Dim dao_customer As New DAO_MAS.TB_MAS_CUSTOMER
            '    dao_customer.Getdata_by_CUSTOMER_ID(item("CUSTOMER_ID").Text)
            '    Dim log As New log_event.log
            '    log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), Request.Url.AbsoluteUri.ToString(), _
            '                   "ลบข้อมูลเจ้าหนี้/ลูกหนี้ " & dao_customer.fields.CUSTOMER_NAME, "MAS_CUSTOMER", item("CUSTOMER_ID").Text)
            '    dao_customer.delete()
            '    rgCustomer.Rebind()
            'Else
            If e.CommandName = "A" Then
                Dim url As String = ""
                Try
                    'Dim dao As New DAO_DISBURSE.TB_RELATE_BG_ALL
                    Dim dao As New DAO_MAS.TB_MAS_CUSTOMER
                    dao.Getdata_by_CUSTOMER_ID(item("CUSTOMER_ID").Text)
                    url = "Frm_Customer_Add_Cer.aspx?bid=" & item("CUSTOMER_ID").Text


                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
            End If
        End If
    End Sub

    Private Sub rgCustomer_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rgCustomer.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("CUSTOMER_ID").Text
            'Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
            Dim url As String = "Frm_Customer_Edit.aspx?cusid=" & id
            'h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")


        End If
    End Sub

    ''' <summary>
    ''' ดึงข้อมูลรายละเอียดเจ้าหนี้ใส่ radgrid
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgCustomer_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgCustomer.NeedDataSource
        'Dim dao_Customer As New DAO_MAS.TB_MAS_CUSTOMER
        'dao_Customer.Getdata()
        Dim dt_Customer As DataTable '= dao_Customer.dt
        'Dim dv As DataView = dt_Customer.DefaultView
        'dv.Sort = "CUSTOMER_ID DESC"
        'dt_Customer = dv.ToTable
        Dim bao As New BAO_BUDGET.MASS
        dt_Customer = bao.get_customer_store()
        rgCustomer.DataSource = dt_Customer
    End Sub
    Public Sub bindseq()
        Dim ut_seq As New Radgrid_Utility
        ut_seq.addSeqRG(rgCustomer)
    End Sub
    Public Sub rg_rebind()
        rgCustomer.Rebind()
    End Sub
    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rgCustomer, str)
    End Sub
End Class