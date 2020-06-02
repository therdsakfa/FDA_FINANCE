Imports Telerik.Web.UI
Public Class UC_User_Debtor
    Inherits System.Web.UI.UserControl
    Private _is_salary As Boolean
    Public Property is_salary() As Boolean
        Get
            Return _is_salary
        End Get
        Set(ByVal value As Boolean)
            _is_salary = value
        End Set
    End Property
    Private _per_type As Integer
    Public Property per_type() As Integer
        Get
            Return _per_type
        End Get
        Set(ByVal value As Integer)
            _per_type = value
        End Set
    End Property

    Private _str As String
    Public Property str() As String
        Get
            Return _str
        End Get
        Set(ByVal value As String)
            _str = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not IsPostBack Then
        '    If _str <> "" Then
        '        rgFilter(_str)
        '    End If
        'End If



    End Sub

    Private Sub rg_user_debtor_Init(sender As Object, e As EventArgs) Handles rg_user_debtor.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_user_debtor
        Rad_Utility.addColumnBound("Row_num", "ลำดับที่")
        Rad_Utility.addColumnBound("IDRUN", "IDRUN", False)
        Rad_Utility.addColumnBound("fullname", "ชื่อ-นามสกุล")
        Rad_Utility.addColumnBound("NATIONAL_ID", "เลขบัตรประชาชน")
        Rad_Utility.addColumnBound("POSITION_NAME", "ตำแหน่ง")
        Rad_Utility.addColumnBound("LEVEL_NAME", "ระดับ")
        Rad_Utility.addColumnBound("DEPARTMENT_DESCRIPTION", "หน่วยงาน")
        Rad_Utility.addColumnBound("BANK_ID", "เลขบัญชีธนาคาร")
        Rad_Utility.addColumnBound("PERSON_TYPE", "ประเภท")
        Rad_Utility.addColumnBound("status_per", "สถานะ")
        Rad_Utility.addColumnButton("E", "แก้ไขข้อมูล", "E", 0, "", width:=120)
        Rad_Utility.addColumnButton("Delete", "ลบข้อมูล", "DeleteColumn", 0, "คุณต้องการลบหรือไม่", width:=120)
    End Sub

    Private Sub rg_user_debtor_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_user_debtor.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "D" Then
                Dim dao_bank As New DAO_MAS.TB_Personal
                dao_bank.Getdata_by_ID(item("IDRUN").Text)
                dao_bank.delete()
                rg_user_debtor.Rebind()

            End If
        End If
    End Sub

    Private Sub rg_user_debtor_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_user_debtor.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            If Not item("IDRUN").Text.Contains("&nbsp;") Then
                Dim id As Integer = item("IDRUN").Text
                ' Dim h2 As ImageButton = DirectCast(item("E").Controls(0), ImageButton)
                Dim h2 As LinkButton = DirectCast(item("E").Controls(0), LinkButton)
                Dim url As String = ""
                'If is_salary = True Then
                url = "../Module07/Frm_Gov_Personel_Edit.aspx?uid=" & id & "&t=" & per_type
                'Else
                '    url = "Frm_User_Debtor_Edit.aspx?uid=" & id
                'End If


                h2.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
            End If



        End If
    End Sub

    Private Sub rg_user_debtor_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_user_debtor.NeedDataSource
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As New DataTable
        dt = bao.get_user_personel(per_type)
        rg_user_debtor.DataSource = dt
    End Sub

    Public Sub rgFilter(ByVal str As String)
        Dim uti_filter As New Utility_other
        uti_filter.filter_rg(rg_user_debtor, str)
    End Sub

    Public Sub rg_rebind()
        rg_user_debtor.Rebind()
    End Sub
    Public Sub export()
        'rg_salary.MasterTableView.GetColumn("EmployeeID").HeaderStyle.BackColor = Color.LightGray
        'rg_salary.MasterTableView.GetColumn("EmployeeID").ItemStyle.BackColor = Color.LightGray

        'rg_salary.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML
        rg_user_debtor.ExportSettings.IgnorePaging = True
        rg_user_debtor.ExportSettings.ExportOnlyData = True
        rg_user_debtor.ExportSettings.OpenInNewWindow = True
        rg_user_debtor.MasterTableView.ExportToExcel()
    End Sub
End Class