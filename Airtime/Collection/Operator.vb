Public Class Operators

    Public OperatorID As Integer
    Public OperatorName As String
    Public Country As String
    Public UserLimit As Integer


    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            With dr
                If Not dr.Item("FK_Operator") Is DBNull.Value Then
                    Me.OperatorID = CInt(dr.Item("FK_Operator"))
                End If
                If Not dr.Item("Limit") Is DBNull.Value Then
                    Me.UserLimit = CInt(dr.Item("Limit"))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class


Public Class ColOperators
    Inherits CollectionBase

    Public Sub Add(ByVal oOperators As Operators)
        List.Add(oOperators)
    End Sub

    Public Sub remove(ByVal oOperators As Operators)
        List.Remove(oOperators)
    End Sub


    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oOperators As Operators
        Try
            For Each dr In ds.Tables(0).Rows
                oOperators = New Operators
                oOperators.SetProperties(dr)
                Me.Add(oOperators)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
