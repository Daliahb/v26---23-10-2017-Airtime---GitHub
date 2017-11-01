Public Class ShiftUser

    Public UserID As Integer
    Public ShiftID As Integer
    Public Username As String
    Public ocolOperators As New ColOperators
    Public ocolDevice As New ColDevice

    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            With dr
                'Me.ID = CInt(dr.Item("id"))
                'If Not dr.Item("Name") Is DBNull.Value Then
                '    Me.ShiftUsersName = dr.Item("Name").ToString
                'End If
                'If Not dr.Item("Address") Is DBNull.Value Then
                '    Me.Address = dr.Item("Address").ToString
                'End If
                'If Not dr.Item("Billing_Email") Is DBNull.Value Then
                '    Me.BillingEmail = dr.Item("Billing_Email").ToString
                'End If
                'If Not dr.Item("CC_Emails") Is DBNull.Value Then
                '    Me.CCEmails = dr.Item("CC_Emails").ToString
                'End If
                'If Not dr.Item("EmailSignature") Is DBNull.Value Then
                '    Me.Signature = dr.Item("EmailSignature").ToString
                'End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class


Public Class ColShiftUsers
    Inherits CollectionBase

    Public Sub Add(ByVal oShiftUsers As ShiftUser)
        List.Add(oShiftUsers)
    End Sub

    Public Sub remove(ByVal oShiftUsers As ShiftUser)
        List.Remove(oShiftUsers)
    End Sub


    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oShiftUsers As ShiftUser
        Try
            For Each dr In ds.Tables(0).Rows
                oShiftUsers = New ShiftUser
                oShiftUsers.SetProperties(dr)
                Me.Add(oShiftUsers)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
