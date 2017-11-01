Public Class SimcardsOrder

    Public SimCardOrderID As Integer
    Public CountryID As Integer
    Public ProviderID As Integer
    Public SimCardTypeID As Integer
    Public NoOfCards As Integer
    Public CardValue As Double
    Public TotalAmount As Double
    Public SimcardOrderDate As Date
    Public isApproved As Boolean

    Public Country As String
    Public Provider As String
    Public SimCardType As String
    Public InsertedByUserName As String
    Public EditedByUserName As String


    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            With dr
                If Not dr.Item("ID") Is DBNull.Value Then
                    Me.SimCardOrderID = CInt(dr.Item("ID"))
                End If
                If Not dr.Item("FK_Provider") Is DBNull.Value Then
                    Me.ProviderID = CInt(dr.Item("FK_Provider"))
                End If
                If Not dr.Item("FK_Country") Is DBNull.Value Then
                    Me.CountryID = CInt(dr.Item("FK_Country"))
                End If
                If Not dr.Item("FK_SimType") Is DBNull.Value Then
                    Me.SimCardTypeID = CInt(dr.Item("FK_SimType"))
                End If
                If Not dr.Item("NoOfCards") Is DBNull.Value Then
                    Me.NoOfCards = CInt(dr.Item("NoOfCards"))
                End If
                If Not dr.Item("isApproved") Is DBNull.Value Then
                    Me.isApproved = CBool(dr.Item("isApproved"))
                End If
                If Not dr.Item("CardValue") Is DBNull.Value Then
                    Me.CardValue = CDbl(dr.Item("CardValue"))
                End If
                If Not dr.Item("TotalAmount") Is DBNull.Value Then
                    Me.TotalAmount = CDbl(dr.Item("TotalAmount"))
                End If
                If Not dr.Item("SimsOrder_Date") Is DBNull.Value Then
                    Me.SimcardOrderDate = CDate(dr.Item("SimsOrder_Date"))
                End If

                If Not dr.Item("Country") Is DBNull.Value Then
                    Me.Country = dr.Item("Country").ToString
                End If
                If Not dr.Item("Provider") Is DBNull.Value Then
                    Me.Provider = dr.Item("Provider").ToString
                End If
                If Not dr.Item("SimcardType") Is DBNull.Value Then
                    Me.SimCardType = dr.Item("SimcardType").ToString
                End If
                If Not dr.Item("InsertUserName") Is DBNull.Value Then
                    Me.InsertedByUserName = dr.Item("InsertUserName").ToString
                End If
                If Not dr.Item("EditUserName") Is DBNull.Value Then
                    Me.EditedByUserName = dr.Item("EditUserName").ToString
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class


Public Class ColSimcardsOrder
    Inherits CollectionBase

    Public Sub Add(ByVal oSimcardsOrder As SimcardsOrder)
        List.Add(oSimcardsOrder)
    End Sub

    Public Sub remove(ByVal oSimcardsOrder As SimcardsOrder)
        List.Remove(oSimcardsOrder)
    End Sub


    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oSimcardsOrder As SimcardsOrder
        Try
            For Each dr In ds.Tables(0).Rows
                oSimcardsOrder = New SimcardsOrder
                oSimcardsOrder.SetProperties(dr)
                Me.Add(oSimcardsOrder)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
