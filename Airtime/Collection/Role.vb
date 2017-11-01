Public Class Role

    Public ID As Long

    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            ID = CLng(dr.Item("id"))
        Catch ex As Exception

        End Try
    End Sub
End Class


Public Class ColRole
    Inherits CollectionBase

    Public Sub Add(ByVal oRole As Role)
        List.Add(oRole)
    End Sub

    Public Sub remove(ByVal oRole As Role)
        List.Remove(oRole)
    End Sub

    Public Function find(ByVal lId As Long) As Boolean
        For Each oRole As Role In Me
            If oRole.ID = lId Then
                Return True
            End If
        Next
        Return False
    End Function



    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oRole As Role
        Try
            For Each dr In ds.Tables(0).Rows
                oRole = New Role
                oRole.SetProperties(dr)
                Me.Add(oRole)
            Next
        Catch ex As Exception

        End Try
    End Sub


End Class