Public Class clsDate
    Public Enum Region
        TH = 0
        EN = 1
    End Enum
    Public Enum order
        ddmmyy = 0
        yymmdd = 1
        mmddyy = 2
    End Enum

    Public Overloads Shared Function getDateKey(ByVal datetext As String, ByVal order As order, Optional ByVal spliter As Char = "/") As Integer
        Try
            Dim day As Integer = 0
            Dim month As Integer = 0
            Dim year As Integer = 0

            Select Case order
                Case clsDate.order.ddmmyy
                    day = datetext.Split(spliter)(0)
                    month = datetext.Split(spliter)(1)
                    year = datetext.Split(spliter)(2)
                Case clsDate.order.mmddyy
                    day = datetext.Split(spliter)(1)
                    month = datetext.Split(spliter)(0)
                    year = datetext.Split(spliter)(2)
                Case clsDate.order.yymmdd
                    day = datetext.Split(spliter)(2)
                    month = datetext.Split(spliter)(1)
                    year = datetext.Split(spliter)(0)
                Case Else

            End Select

            Return (year * 10000) + (month * 100) + day

        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
