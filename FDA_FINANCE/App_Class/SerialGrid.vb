Imports Telerik.Web.UI
Public Class cls_serialgrid
    Public Function serialgrid(ByVal R As RadGrid) As DataTable
        Dim DT As New DataTable
        DT = gridaddcolumn(R)
        grid_reindex(DT, "num")
        For Each g As GridDataItem In R.Items
            Dim dr As DataRow = DT.NewRow()
            For Each C As DataColumn In DT.Columns
                dr(C.ColumnName) = g(C.ColumnName).Text
            Next
            DT.Rows.Add(dr)
        Next
        Return DT
    End Function

    Public Sub grid_reindex(ByRef dt As DataTable, ByVal Cname As String)
        Dim i As Integer = 1
        For Each dr As DataRow In dt.Rows
            dr(Cname) = i
            i = i + 1
        Next
    End Sub

    Public Overloads Function gridaddcolumn(ByVal SS As String) As DataTable
        Dim DT As New DataTable
        For Each s As String In SS.Split(",")
            DT.Columns.Add(s)
        Next
        Return DT
    End Function

    Public Overloads Function gridaddcolumn(ByVal R As RadGrid) As DataTable
        Dim DT As New DataTable
        For Each G As GridColumn In R.Columns
            DT.Columns.Add(G.UniqueName)
        Next
        Return DT
    End Function
End Class
