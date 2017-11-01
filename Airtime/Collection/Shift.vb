Public Class Shift

    '  Public UserID As Integer
    Public ShiftID As Integer
    Public ShiftDate As Date
    Public ocolSiftUsers As New colShiftUsers
    Public AuditID As Integer

    Public Sub SetProperties(ByVal ds As DataSet)
        Try
            'table 1 - users
            'Table 2 - Users + Devices 
            'Table 3 - Users Operators limits

            If Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Dim oShiftUser As ShiftUser
                For Each dr As DataRow In ds.Tables(0).Rows
                    oShiftUser = New ShiftUser
                    oShiftUser.UserID = CInt(dr.Item("UserID"))
                    oShiftUser.Username = dr.Item("Username").ToString
                    'fill Operators' limits
                    If Not ds.Tables.Count < 2 AndAlso Not ds.Tables(1).Rows.Count = 0 Then
                        Dim oOperator As Operators
                        For Each dr1 As DataRow In ds.Tables(1).Rows
                            If CInt(dr1.Item("UserID")) = CInt(dr.Item("UserID")) Then
                                oOperator = New Operators
                                oOperator.OperatorID = CInt(dr1.Item("FK_Operator"))
                                oOperator.UserLimit = CInt(dr1.Item("limit"))
                                oShiftUser.ocolOperators.Add(oOperator)
                            End If
                        Next
                    End If
                    'fill Devices
                    If Not ds.Tables.Count < 3 AndAlso Not ds.Tables(2).Rows.Count = 0 Then
                        Dim oDevice As Device
                        For Each dr2 As DataRow In ds.Tables(2).Rows
                            If CInt(dr2.Item("UserID")) = CInt(dr.Item("UserID")) Then
                                oDevice = New Device
                                oDevice.Device = dr2.Item("Device").ToString
                                oShiftUser.ocolDevice.Add(oDevice)
                            End If
                        Next
                    End If
                    Me.ocolSiftUsers.Add(oShiftUser)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub SetProperties_Devices(ByVal ds As DataSet)
        Try
            'table 1 - users
            'Table 2 - Users + Devices 
            'table 3 - shift id
            If Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Dim oShiftUser As ShiftUser
                If Not ds.Tables.Count < 3 Then
                    Me.ShiftID = CInt(ds.Tables(2).Rows(0).Item(0))
                End If
                For Each dr As DataRow In ds.Tables(0).Rows
                    oShiftUser = New ShiftUser
                    oShiftUser.UserID = CInt(dr.Item("UserID"))
                    oShiftUser.Username = dr.Item("Username").ToString
                   
                    'fill Devices
                    If Not ds.Tables.Count < 2 AndAlso Not ds.Tables(1).Rows.Count = 0 Then
                        Dim oDevice As Device
                        For Each dr2 As DataRow In ds.Tables(1).Rows
                            If CInt(dr2.Item("UserID")) = CInt(dr.Item("UserID")) Then
                                oDevice = New Device
                                oDevice.Device = dr2.Item("Device").ToString
                                oDevice.DeviceID = CInt(dr2.Item("DeviceId"))
                                oShiftUser.ocolDevice.Add(oDevice)
                            End If
                        Next
                    End If
                    Me.ocolSiftUsers.Add(oShiftUser)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class


Public Class ColShifts
    Inherits CollectionBase

    Public Sub Add(ByVal oShifts As Shift)
        List.Add(oShifts)
    End Sub

    Public Sub remove(ByVal oShifts As Shift)
        List.Remove(oShifts)
    End Sub

End Class