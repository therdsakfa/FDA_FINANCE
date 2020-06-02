Public Partial Class UC_Budgetplan_Information
    Inherits System.Web.UI.UserControl
    Private _bg_ID As Integer
    Public Property bg_ID() As Integer
        Get
            Return _bg_ID
        End Get
        Set(ByVal value As Integer)
            _bg_ID = value
        End Set
    End Property

    Private dtMain As New DataTable


    Public Sub BindData(ByVal dt As DataTable)
        dtMain = dt
        rgInformation.Rebind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub rgInformation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgInformation.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rgInformation
        '   Rad_Utility.addColumnBound("Seq", "Seq", True)
        Rad_Utility.addColumnBound("BUDGET_DESCRIPTION", "ชืองบ", True)

    End Sub

    Private Sub rgInformation_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgInformation.NeedDataSource
        rgInformation.DataSource = dtMain
    End Sub
   
End Class