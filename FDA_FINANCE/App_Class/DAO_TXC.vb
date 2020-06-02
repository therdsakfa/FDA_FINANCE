Namespace DAO_TXC
    Public MustInherit Class MainContext
        Public db As New LINQ_TXCDataContext
        Public datas

    End Class
    Public Class TB_RECIVE
        Inherits MainContext
        Public fields As New RECIVE

        Private _Details As New List(Of RECIVE)
        Public Property Details() As List(Of RECIVE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of RECIVE))
                _Details = value
            End Set
        End Property


        Public Sub GetDataby_Feeno(ByVal feeno As String)
            datas = (From p In db.RECIVEs Where p.FEE_NO = feeno Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.RECIVEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.RECIVEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
    End Class
End Namespace
