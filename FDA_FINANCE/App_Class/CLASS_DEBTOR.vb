Public Class CLASS_DEBTOR
    Public DEBTOR_BILLs As New DEBTOR_BILL
#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW
    Public Property DT_SHOW() As CLS_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW)
            _DT_SHOW = value
        End Set
    End Property
#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER
    Public Property DT_MASTER() As CLS_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER)
            _DT_MASTER = value
        End Set
    End Property
#End Region

#Region "DataBase"

#Region "DETAIL"
    Private _DEBTOR_BILL_DETAILs As New List(Of DEBTOR_BILL_DETAIL)
    Public Property DEBTOR_BILL_DETAILs() As List(Of DEBTOR_BILL_DETAIL)
        Get
            Return _DEBTOR_BILL_DETAILs
        End Get
        Set(ByVal value As List(Of DEBTOR_BILL_DETAIL))
            _DEBTOR_BILL_DETAILs = value
        End Set
    End Property
#End Region


#End Region
End Class
