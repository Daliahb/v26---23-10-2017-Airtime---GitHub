Public Class frmAddExpense_Cards

    Public enumEditAdd As New Enumerators.EditAdd
    Public lExpenseID As Integer
    Public boolSaved As Boolean
    Dim isLoaded As Boolean
    Dim oExpense As New Expenses

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal oExpense As Expenses = Nothing) 'ByVal lExpenseID As Integer = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        '  Me.lExpenseID = lExpenseID
        If enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.oExpense = oExpense
        End If
        Me.enumEditAdd = enumEditAdd

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDs()
        isLoaded = True
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Expense"

            ' oExpense = odbaccess.getExpense(lExpenseID)
            SetControls()
        End If

        boolSaved = False

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If CheckValidation() Then

                FillObject()
                If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                    boolError = odbaccess.InsertExpense(oExpense)
                ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                    boolError = odbaccess.EditExpense(oExpense)
                End If
                If boolError Then
                    MsgBox("Operation done successfully.", , "Airtime System")
                    boolSaved = True
                    If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                        Me.Close()
                    Else
                        Me.ResetForm()
                    End If
                Else
                    boolSaved = False
                    MsgBox("Error occured!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtCardValue.Text = ""
        Me.txtNoOfCards.Text = ""
        If Not cmbCountries.Items.Count = 0 Then
            Me.cmbCountries.SelectedIndex = 0
        End If
    End Sub

    Public Sub SetControls()
        If Not Me.oExpense Is Nothing Then
            With oExpense
                Me.cmbCountries.SelectedValue = -1
                Me.cmbCountries.SelectedValue = .CountryID
                Me.cmbProviders.SelectedValue = .ProviderID
                Me.cmbOperators.SelectedValue = .OperatorID
                Me.cmbCategory.SelectedValue = .CategoryID
                Me.dtpFromDate.Value = .ExpenseDate
                Me.txtNoOfCards.Text = .NoOfCards.ToString
                Me.txtCardValue.Text = .CardValue.ToString
                Me.txtTotal.Text = .TotalAmount.ToString
            End With
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSave_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No
                    Me.Close()
                Case MsgBoxResult.Cancel
                    Return
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Public Sub FillDs()
        Try
            'Dim dsCountries As DataSet = odbaccess.GetCountriesDS

            'If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
            '    Me.cmbCountries.DataSource = dsCountries.Tables(0)
            '    Me.cmbCountries.DisplayMember = "Country"
            '    Me.cmbCountries.ValueMember = "ID"
            'End If

            If Not gdsCountries Is Nothing AndAlso Not gdsCountries.Tables.Count = 0 Then
                Me.cmbCountries.DataSource = gdsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCountries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedIndexChanged
        If isLoaded Then
            'Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            'If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
            '    Me.cmbOperators.DataSource = dsOperators.Tables(0)
            '    Me.cmbOperators.DisplayMember = "Operator"
            '    Me.cmbOperators.ValueMember = "ID"
            'End If

            'Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            'If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
            '    Me.cmbProviders.DataSource = dsProvider.Tables(0)
            '    Me.cmbProviders.DisplayMember = "Provider"
            '    Me.cmbProviders.ValueMember = "ID"
            'End If
            If Not gdsOperators Is Nothing AndAlso Not gdsOperators.Tables.Count = 0 Then
                Dim dv As New DataView(gdsOperators.Tables(0))
                dv.RowFilter = "FK_Country = " & CInt(Me.cmbCountries.SelectedValue).ToString
                Me.cmbOperators.DataSource = dv
                Me.cmbOperators.ValueMember = "Id"
                Me.cmbOperators.DisplayMember = "Operator"
            End If

            If Not gdsProviders Is Nothing AndAlso Not gdsProviders.Tables.Count = 0 Then
                Dim dvProvider As New DataView(gdsProviders.Tables(0))
                dvProvider.RowFilter = "FK_Country = " & CInt(Me.cmbCountries.SelectedValue).ToString
                Me.cmbProviders.DataSource = dvProvider
                Me.cmbProviders.ValueMember = "Id"
                Me.cmbProviders.DisplayMember = "Provider"
            End If
        End If

    End Sub

    Private Sub txtExpense_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfCards.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCardValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCardValue.KeyPress, txtTotal.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedIndexChanged
        'Dim dsCategory As DataSet = odbaccess.GetCategories(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbOperators.SelectedValue))
        'If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
        '    Me.cmbCategory.DataSource = dsCategory.Tables(0)
        '    Me.cmbCategory.DisplayMember = "Category"
        '    Me.cmbCategory.ValueMember = "ID"
        'End If
        If isLoaded Then
            If Not gdsCategories Is Nothing AndAlso Not gdsCategories.Tables.Count = 0 Then
                Dim dvCategory As New DataView(gdsCategories.Tables(0))
                dvCategory.RowFilter = "Country_Id = " & CInt(Me.cmbCountries.SelectedValue).ToString
                dvCategory.RowFilter = "Operator_Id = " & CInt(Me.cmbOperators.SelectedValue).ToString
                Me.cmbCategory.DataSource = dvCategory
                Me.cmbCategory.ValueMember = "Id"
                Me.cmbCategory.DisplayMember = "Category"
            End If
        End If
    End Sub

    Public Function CheckValidation() As Boolean
        Dim boolError As Boolean = True

        If Me.cmbCountries.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbCountries, "Please select country from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbCountries, "")
        End If

        If Me.cmbProviders.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbProviders, "Please select provider from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbProviders, "")
        End If

        If Me.cmbOperators.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbOperators, "Please select operator from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbOperators, "")
        End If

        If Me.cmbCategory.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbCategory, "Please select category from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbCategory, "")
        End If

        If Me.txtNoOfCards.Text.Length = 0 Then
            ErrorProvider1.SetError(Me.txtNoOfCards, "Please insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.txtNoOfCards, "")
        End If

        If Me.txtCardValue.Text.Length = 0 Then
            ErrorProvider1.SetError(Me.txtCardValue, "Please insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.txtCardValue, "")
        End If

        Return boolError
    End Function

    Public Sub FillObject()
        With oExpense
            .CountryID = CInt(Me.cmbCountries.SelectedValue)
            .ProviderID = CInt(Me.cmbProviders.SelectedValue)
            .OperatorID = CInt(Me.cmbOperators.SelectedValue)
            .CategoryID = CInt(Me.cmbCategory.SelectedValue)
            .ExpenseDate = Me.dtpFromDate.Value
            .NoOfCards = CInt(Me.txtNoOfCards.Text)
            .CardValue = CDbl(Me.txtCardValue.Text)
            .TotalAmount = CDbl(Me.txtTotal.Text)
            .enumExpenseType = Enumerators.EspenseType.AirtimeCards
            .ExpenseCategoryID = 1 'airtime cards
            .SimCardTypeID = 0
            .SimCardOrderID = 0
        End With
    End Sub

   
    Private Sub txtNoOfCards_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoOfCards.TextChanged
        If Not Me.txtNoOfCards.Text.Length = 0 AndAlso Not Me.txtCardValue.Text.Length = 0 Then
            Me.txtTotal.Text = Math.Round((CInt(Me.txtNoOfCards.Text) * CDec(Me.txtCardValue.Text)), 3).ToString
        Else
            Me.txtTotal.Text = "0.0"
        End If
    End Sub

    Private Sub txtCardValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCardValue.TextChanged
        If Not Me.txtNoOfCards.Text.Length = 0 AndAlso Not Me.txtCardValue.Text.Length = 0 Then
            Me.txtTotal.Text = Math.Round((CInt(Me.txtNoOfCards.Text) * CDec(Me.txtCardValue.Text)), 3).ToString
        Else
            Me.txtTotal.Text = "0.0"
        End If
    End Sub
End Class