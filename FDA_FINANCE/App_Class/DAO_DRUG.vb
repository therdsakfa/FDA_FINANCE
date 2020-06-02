Namespace DAO_DRUG
    Public MustInherit Class MainContext
        Public db As New LINQ_DRUGDataContext
        Public datas

    End Class
    Public Class TB_LCN_EXTEND_LITE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LCN_EXTEND_LITE

        Public Sub insert()
            db.LCN_EXTEND_LITEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_EXTEND_LITEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_EXTEND_LITEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataby_u1_code(ByVal u1 As String)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.U1_CODE = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1_year(ByVal u1 As String, ByVal _year As Integer)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.U1_CODE = u1 And p.extend_year = _year Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace
