Public Class Device

    Public DeviceID As Long
    Public Device As String
    Public NoOfSentCards As Integer


End Class


Public Class ColDevice
    Inherits CollectionBase

    Public Sub Add(ByVal oDevice As Device)
        List.Add(oDevice)
    End Sub

    Public Sub remove(ByVal oDevice As Device)
        List.Remove(oDevice)
    End Sub

    Public Sub remove(ByVal lDeviceSlotID As Long)
        For Each odevice As Device In Me.List
            If odevice.DeviceID = lDeviceSlotID Then
                List.Remove(odevice)
                Exit For
            End If
        Next
    End Sub

    Public Function FindByIDAndAdd1(lID As Long) As Integer
        For Each odevice As Device In Me.List
            If odevice.DeviceID = lID Then
                odevice.NoOfSentCards = odevice.NoOfSentCards + 1
                Return odevice.NoOfSentCards
                Exit For
            End If
        Next
        Return 0
    End Function

    Public Function GetNoOfUsedCards(lID As Long) As Integer
        For Each odevice As Device In Me.List
            If odevice.DeviceID = lID Then
                Return odevice.NoOfSentCards
                Exit For
            End If
        Next
        Return 0
    End Function

    Public Sub FillProperties(ds As DataSet)
        Dim oDevice As Device
        Try
            For Each dr As DataRow In ds.Tables(0).Rows
                oDevice = New Device
                With oDevice
                    .DeviceID = CInt(dr.Item("DeviceSlotID"))
                    .NoOfSentCards = CInt(dr.Item("NoOfCards"))
                End With
                Me.Add(oDevice)
            Next
        Catch ex As Exception

        End Try

    End Sub
End Class
