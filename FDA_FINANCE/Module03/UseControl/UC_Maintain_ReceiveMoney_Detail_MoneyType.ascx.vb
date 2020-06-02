Public Class UC_Maintain_ReceiveMoney_Detail_MoneyType
    Inherits System.Web.UI.UserControl

    Public Validataion As Boolean = True
    Private _nodeID As Integer
    Public Property nodeID() As Integer
        Get
            Return _nodeID
        End Get
        Set(ByVal value As Integer)
            _nodeID = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    'Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
    '    dao.fields.RECEIVE_MONEY_TYPE = txt_MoneyType.Text
    '    dao.fields.RECEIVE_MONEY_TYPE = txt_MoneyType_List.Text
    '    dao.fields.RECEIVE_MONEY_TYPE = txt_List_1.Text
    '    dao.fields.RECEIVE_MONEY_TYPE = txt_List_2.Text
    'End Sub

    'Public Sub getdata(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
    '    txt_MoneyType.Text = dao.fields.RECEIVE_MONEY_TYPE
    '    txt_MoneyType_List.Text = dao.fields.RECEIVE_MONEY_TYPE
    '    txt_List_1.Text = dao.fields.RECEIVE_MONEY_TYPE
    '    txt_List_2.Text = dao.fields.RECEIVE_MONEY_TYPE
    'End Sub
    Public Sub bindTxtbox()
        Dim baobudget As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        dt.Columns.Add("seq")
        dt.Columns.Add("MONEY_TYPE_DESCRIPTION")
        dt.Columns.Add("MONEY_AMOUNT")
        dt.Columns.Add("TYPE_ID")
        dt = baobudget.getMoneyTypeNodeBack(dt, nodeID)

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "seq desc"
        dt = dv.ToTable

        lb_level1.Text = ""
        lb_level2.Text = ""
        lb_level3.Text = ""
        lb_level4.Text = ""

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                If IsDBNull(dt(i)("MONEY_TYPE_DESCRIPTION")) = False And IsDBNull(dt(i)("TYPE_ID")) = False Then
                    Select Case dt(i)("TYPE_ID")
                        Case "1"
                            lb_level1.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "2"
                            lb_level2.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "3"
                            lb_level3.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                        Case "4"
                            lb_level4.Text = dt(i)("MONEY_TYPE_DESCRIPTION")
                    End Select

                End If

            Next
        End If
    End Sub
    'Public Function getPlanBack() As DataTable
    '    Dim baobudget As New BAO_BUDGET.Budget
    '    Dim dt As New DataTable
    '    dt.Columns.Add("seq")
    '    dt.Columns.Add("MONEY_TYPE_DESCRIPTION")
    '    dt.Columns.Add("MONEY_AMOUNT")
    '    dt.Columns.Add("TYPE_ID")
    '    dt = baobudget.getMoneyTypeNodeBack(dt, nodeID)

    '    Dim dv As DataView = dt.DefaultView
    '    dv.Sort = "seq desc"
    '    dt = dv.ToTable
    '    Return dt
    'End Function
    'Public Sub insert(ByRef dao As DAO_MAINTAIN.TB_RECEIVE_MONEY)
    '    dao.fields.MONEY_TYPE_ID = nodeID
    'End Sub
End Class