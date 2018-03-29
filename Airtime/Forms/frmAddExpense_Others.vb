Public Class frmAddExpense_Others

    Public enumEditAdd As New Enumerators.EditAdd
    Public lExpenseID As Integer
    Public boolSaved As Boolean
    Dim isLoaded As Boolean
    Dim oExpense As New Expenses

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal oExpense As Expenses = Nothing) 'ByVal lExpenseID As Integer = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        If enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.oExpense = oExpense
        End If
        '  Me.lExpenseID = lExpenseID

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
                    boolSaved = True
                    MsgBox("Operation done successfully.", , "Airtime System")
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
        Me.txtTotal.Text = ""
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
                Me.cmbExpensesCat.SelectedValue = .ExpenseCategoryID
                Me.dtpFromDate.Value = .ExpenseDate
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
                    boolSaved = False
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

            Dim dsExpensesCategories As DataSet = odbaccess.getExpensesCategories(False)

            If Not dsExpensesCategories Is Nothing AndAlso Not dsExpensesCategories.Tables.Count = 0 AndAlso Not dsExpensesCategories.Tables(0).Rows.Count = 0 Then
                Me.cmbExpensesCat.DataSource = dsExpensesCategories.Tables(0)
                Me.cmbExpensesCat.DisplayMember = "Category"
                Me.cmbExpensesCat.ValueMember = "ID"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCountries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedIndexChanged
        If isLoaded Then
            '     Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            'Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            'If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
            '    Me.cmbProviders.DataSource = dsProvider.Tables(0)
            '    Me.cmbProviders.DisplayMember = "Provider"
            '    Me.cmbProviders.ValueMember = "ID"
            'End If
            If Not gdsProviders Is Nothing AndAlso Not gdsProviders.Tables.Count = 0 Then
                Dim dvProvider As New DataView(gdsProviders.Tables(0))
                dvProvider.RowFilter = "FK_Country = " & CInt(Me.cmbCountries.SelectedValue).ToString
                Me.cmbProviders.DataSource = dvProvider
                Me.cmbProviders.ValueMember = "Id"
                Me.cmbProviders.DisplayMember = "Provider"
            End If
        End If

    End Sub


    Public Function CheckValidation() As Boolean
        Dim boolError As Boolean = True

        If Me.cmbCountries.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbCountries, "Please select Country from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbCountries, "")
        End If

        If Me.cmbProviders.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbProviders, "Please select Provider from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbProviders, "")
        End If

        If Me.cmbExpensesCat.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbExpensesCat, "Please select Expensive Category from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbExpensesCat, "")
        End If

        If Me.txtTotal.Text.Length = 0 Then
            ErrorProvider1.SetError(Me.txtTotal, "Please insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.txtTotal, "")
        End If

        Return boolError
    End Function

    Private Sub txtCardValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Sub FillObject()
        With oExpense
            .CountryID = CInt(Me.cmbCountries.SelectedValue)
            .ProviderID = CInt(Me.cmbProviders.SelectedValue)
            .ExpenseDate = Me.dtpFromDate.Value
            .TotalAmount = CDbl(Me.txtTotal.Text)
            .enumExpenseType = Enumerators.EspenseType.Others
            .ExpenseCategoryID = CInt(Me.cmbExpensesCat.SelectedValue)
            .SimCardTypeID = 0
            .SimCardOrderID = 0
        End With
    End Sub

End Class