Public Class Expenses

    Public ExpenseID As Integer
    Public CountryID As Integer
    Public ProviderID As Integer
    Public OperatorID As Integer 'Airtime cards
    Public CategoryID As Integer 'Airtime cards
    Public enumExpenseType As Integer '(SimCard, AirtimeCard, Other)
    Public ExpenseCategoryID As Integer '(All Expenses Categories)
    Public SimCardTypeID As Integer
    Public NoOfCards As Integer
    Public CardValue As Double
    Public TotalAmount As Double
    Public ExpenseDate As Date
    Public SimCardOrderID As Integer


    Public Country As String
    Public oOperator As String
    Public Provider As String
    Public Category As String
    Public ExpenseCategory As String
    Public SimCardType As String
    Public UserName As String


    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            With dr
                If Not dr.Item("ID") Is DBNull.Value Then
                    Me.ExpenseID = CInt(dr.Item("ID"))
                End If
                If Not dr.Item("FK_Provider") Is DBNull.Value Then
                    Me.ProviderID = CInt(dr.Item("FK_Provider"))
                End If
                If Not dr.Item("FK_Country") Is DBNull.Value Then
                    Me.CountryID = CInt(dr.Item("FK_Country"))
                End If
                If Not dr.Item("FK_Operator") Is DBNull.Value Then
                    Me.OperatorID = CInt(dr.Item("FK_Operator"))
                End If
                If Not dr.Item("FK_Category") Is DBNull.Value Then
                    Me.CategoryID = CInt(dr.Item("FK_Category"))
                End If
                If Not dr.Item("FK_ExpensesCategory") Is DBNull.Value Then
                    Me.ExpenseCategoryID = CInt(dr.Item("FK_ExpensesCategory"))
                End If
                If Not dr.Item("ExpenseType") Is DBNull.Value Then
                    Me.enumExpenseType = CInt(dr.Item("ExpenseType"))
                End If
                If Not dr.Item("FK_SimCardType") Is DBNull.Value Then
                    Me.SimCardTypeID = CInt(dr.Item("FK_SimCardType"))
                End If
                If Not dr.Item("NoOfCards") Is DBNull.Value Then
                    Me.NoOfCards = CInt(dr.Item("NoOfCards"))
                End If
                If Not dr.Item("FK_InsertByUser") Is DBNull.Value Then
                    Me.SimCardOrderID = CInt(dr.Item("FK_InsertByUser"))
                End If
                If Not dr.Item("CardValue") Is DBNull.Value Then
                    Me.CardValue = CDbl(dr.Item("CardValue"))
                End If
                If Not dr.Item("TotalAmount") Is DBNull.Value Then
                    Me.TotalAmount = CDbl(dr.Item("TotalAmount"))
                End If
                If Not dr.Item("ExpenseDate") Is DBNull.Value Then
                    Me.ExpenseDate = CDate(dr.Item("ExpenseDate"))
                End If

                If Not dr.Item("Country") Is DBNull.Value Then
                    Me.Country = dr.Item("Country").ToString
                End If
                If Not dr.Item("Operator") Is DBNull.Value Then
                    Me.oOperator = dr.Item("Operator").ToString
                End If
                If Not dr.Item("Provider") Is DBNull.Value Then
                    Me.Provider = dr.Item("Provider").ToString
                End If
                If Not dr.Item("Category") Is DBNull.Value Then
                    Me.Category = dr.Item("Category").ToString
                End If
                If Not dr.Item("ExpenseCategory") Is DBNull.Value Then
                    Me.ExpenseCategory = dr.Item("ExpenseCategory").ToString
                End If
                If Not dr.Item("SimcardType") Is DBNull.Value Then
                    Me.SimCardType = dr.Item("SimcardType").ToString
                End If
                If Not dr.Item("UserName") Is DBNull.Value Then
                    Me.UserName = dr.Item("UserName").ToString
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class


Public Class ColExpenses
    Inherits CollectionBase

    Public Sub Add(ByVal oExpenses As Expenses)
        List.Add(oExpenses)
    End Sub

    Public Sub remove(ByVal oExpenses As Expenses)
        List.Remove(oExpenses)
    End Sub


    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oExpenses As Expenses
        Try
            For Each dr In ds.Tables(0).Rows
                oExpenses = New Expenses
                oExpenses.SetProperties(dr)
                Me.Add(oExpenses)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
