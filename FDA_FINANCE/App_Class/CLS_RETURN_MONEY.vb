Public Class CLS_RETURN_MONEY
    Private _Amount As Double
    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property

    Private _Pay_Date As Date
    Public Property Pay_Date() As Date
        Get
            Return _Pay_Date
        End Get
        Set(ByVal value As Date)
            _Pay_Date = value
        End Set
    End Property

    Private _Receive_Type As String
    Public Property Receive_Type() As String
        Get
            Return _Receive_Type
        End Get
        Set(ByVal value As String)
            _Receive_Type = value
        End Set
    End Property

    Private _RECEIVE_MONEY_ID As Integer
    Public Property RECEIVE_MONEY_ID() As Integer
        Get
            Return _RECEIVE_MONEY_ID
        End Get
        Set(ByVal value As Integer)
            _RECEIVE_MONEY_ID = value
        End Set
    End Property
End Class
