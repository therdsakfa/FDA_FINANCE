Imports System.Data.SqlClient

Namespace BAO_NCT2
    Public Class ConnectDatabass
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_NCT2ConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class
    Public Class LGT_NCT2
        Inherits ConnectDatabass

       Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum(ByVal feeno As String, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno_group_sum @feeno='" & feeno & "' ,@dvcd=" & dvcd
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_get_receipt_by_feeabbr_and_feeno_group_sum2(ByVal feeno As String, ByVal dvcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec dbo.SP_get_receipt_by_feeabbr_and_feeno_group_sum2 @feeno='" & feeno & "' ,@dvcd=" & dvcd
            dt = Queryds(command)
            Return dt
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ByVal ref01 As String, ref02 As String, ByVal process As Integer, ByVal dvcd As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' ,@dvcd=" & dvcd & " ,@process=" & process
            dt = Queryds(command)

        End Sub
        '
        Public Function SP_GET_IDA_NCT_FROM_FEE(ByVal ref01 As String, ref02 As String) As Integer
            Dim dt As New DataTable
            Dim IDA As Integer = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_IDA_NCT_FROM_FEE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                IDA = dr("IDA")
            Next

            Return IDA
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE2(ByVal ref01 As String, ref02 As String, ByVal dvcd As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE2] @ref01='" & ref01 & "', @ref02='" & ref02 & "' ,@dvcd=" & dvcd
            dt = Queryds(command)

        End Sub
    End Class
    Public Class LGT_NCT2_128
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_NCT2ConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ByVal ref01 As String, ref02 As String, ByVal process As Integer, ByVal dvcd As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_COMPLETE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' ,@dvcd=" & dvcd & " ,@process=" & process
            dt = Queryds(command)

        End Sub
        '
        Public Function SP_GET_IDA_NCT_FROM_FEE(ByVal ref01 As String, ref02 As String) As Integer
            Dim dt As New DataTable
            Dim IDA As Integer = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_IDA_NCT_FROM_FEE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                IDA = dr("IDA")
            Next

            Return IDA
        End Function
        Public Sub SP_FEE_UPDATE_STATUS_PAY_CANCEL(ByVal ref01 As String, ref02 As String, ByVal process As Integer, ByVal dvcd As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_FEE_UPDATE_STATUS_PAY_CANCEL] @ref01='" & ref01 & "', @ref02='" & ref02 & "' ,@dvcd=" & dvcd & " ,@process=" & process
            dt = Queryds(command)

        End Sub

    End Class
End Namespace
