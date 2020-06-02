Public Class UC_MoneyType_Head
    Inherits System.Web.UI.UserControl
    Private _money_id As Integer
    Public Property money_id() As Integer
        Get
            Return _money_id
        End Get
        Set(ByVal value As Integer)
            _money_id = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl()
        End If
    End Sub
    Private Sub bind_ddl()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_head_moneytype()

        dd_money_type.DataSource = dt
        dd_money_type.DataBind()
    End Sub
    Public Sub getDateSelect()
        If dd_money_type.SelectedValue <> "" Then
            money_id = dd_money_type.SelectedValue
        Else
            money_id = 0
        End If


    End Sub
End Class