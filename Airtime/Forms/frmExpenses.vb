Public Class frmExpenses

    Dim ds As DataSet
    Dim lCountryID, lProviderID, lOperatorID, lCategoryID, lInsertedByID, lSimCardType, lExpenseCategory As Integer
    Dim FromDate, ToDate As Date
    Dim boolCheckDate, isloaded As Boolean
    Dim dsCountries As DataSet
    Dim dblTotalAmount As Double = 0.0
    Dim ocolExpenses As New ColExpenses

    Private Sub frmWrongCards_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        FillTypes()
        isloaded = True

        If gUser.type = Enumerators.UsersTypes.Provider Then
            Me.cmbCountries.SelectedValue = -1
            Me.cmbCountries.SelectedValue = gUser.ProviderCountry
            Me.chkCountry.Checked = True
            Me.chkCountry.Enabled = False
            Me.cmbCountries.Enabled = False
            Me.chkProvider.Enabled = False
            Me.chkProvider.Checked = True
            Me.cmbProviders.SelectedValue = gUser.Provider
            Me.cmbProviders.Enabled = False
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 1
        Dim intRowIndex As Integer

        Try
            dblTotalAmount = 0.0
            Me.DataGridView1.Rows.Clear()
            Generate()
            ocolExpenses = odbaccess.GetExpenses(lExpenseCategory, lCountryID, lProviderID, lOperatorID, lCategoryID, lSimCardType, lInsertedByID, boolCheckDate, FromDate, ToDate)
            If Not ocolExpenses Is Nothing AndAlso Not ocolExpenses.Count = 0 Then
                For Each oExpense As Expenses In ocolExpenses
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = oExpense.ExpenseID
                            .Cells(1).Value = CType(oExpense.enumExpenseType, Enumerators.EspenseType)
                            .Cells(2).Value = intCounter
                            .Cells(3).Value = oExpense.ExpenseCategory
                            .Cells(4).Value = oExpense.Country
                            .Cells(5).Value = oExpense.Provider
                            .Cells(6).Value = oExpense.oOperator
                            .Cells(7).Value = oExpense.Category
                            .Cells(8).Value = oExpense.NoOfCards
                            .Cells(9).Value = oExpense.CardValue
                            .Cells(10).Value = oExpense.TotalAmount
                            .Cells(11).Value = oExpense.SimCardType
                            .Cells(12).Value = oExpense.UserName
                            .Cells(13).Value = CDate(oExpense.ExpenseDate).ToString("yyyy-MM-dd")

                            dblTotalAmount += oExpense.TotalAmount
                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If
            Me.Text = "Expenses - " + dblTotalAmount.ToString + " $"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(2).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim intColumnIndex As Integer


    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.DataGridView1.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.ColumnHeader Then
                Me.intColumnIndex = ht.ColumnIndex
                DataGridView1.ContextMenuStrip = ContextMenuStripHideColumn
            ElseIf ht.Type = DataGridViewHitTestType.Cell Then
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
    End Sub

    Private Sub HideColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideColumnToolStripMenuItem.Click
        Me.DataGridView1.Columns(intColumnIndex).Visible = False
    End Sub

    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        For i As Integer = 2 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns(i).Visible = True
        Next
    End Sub

    Private Sub EditCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExpenseToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim lExpenseID As Integer
            Dim enumExpenseType As Enumerators.EspenseType
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
            Dim oExpense As Expenses
            lExpenseID = CInt(Me.DataGridView1.Rows(RowIndex).Cells(0).Value)
            enumExpenseType = CType(Me.DataGridView1.Rows(RowIndex).Cells(1).Value, Enumerators.EspenseType)

            For Each oExp As Expenses In Me.ocolExpenses
                If oExp.ExpenseID = lExpenseID Then
                    oExpense = oExp
                End If
            Next

            Select Case enumExpenseType
                Case Enumerators.EspenseType.AirtimeCards
                    Dim frm3 As New frmAddExpense_Cards(Enumerators.EditAdd.Edit, oExpense)
                    frm3.ShowDialog()
                    If frm3.boolSaved Then
                        Me.DataGridView1.Rows(RowIndex).Cells(4).Value = frm3.cmbCountries.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(5).Value = frm3.cmbProviders.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(6).Value = frm3.cmbOperators.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(7).Value = frm3.cmbCategory.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(13).Value = frm3.dtpFromDate.Value.ToString("yyyy-MM-dd")
                        Me.DataGridView1.Rows(RowIndex).Cells(8).Value = frm3.txtNoOfCards.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(9).Value = frm3.txtCardValue.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(10).Value = frm3.txtTotal.Text
                    End If
                Case Enumerators.EspenseType.SimCards
                    MessageBox.Show("Cannot edit sim cards expenses")

                Case Enumerators.EspenseType.Others
                    Dim frm4 As New frmAddExpense_Others(Enumerators.EditAdd.Edit, oExpense)
                    frm4.ShowDialog()
                    If frm4.boolSaved Then
                        Me.DataGridView1.Rows(RowIndex).Cells(4).Value = frm4.cmbCountries.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(5).Value = frm4.cmbProviders.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(3).Value = frm4.cmbExpensesCat.Text
                        Me.DataGridView1.Rows(RowIndex).Cells(13).Value = frm4.dtpFromDate.Value.ToString("yyyy-MM-dd")
                        Me.DataGridView1.Rows(RowIndex).Cells(10).Value = frm4.txtTotal.Text

                        CalculateTotalAmounts()

                    End If
            End Select
        End If
    End Sub

    Public Sub CalculateTotalAmounts()
        dblTotalAmount = 0.0
        Try

            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                dblTotalAmount += CDec(row.Cells(6).Value)
            Next
            Me.Text = "Expenses - " + dblTotalAmount.ToString + " $"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpenseCategory.CheckedChanged
        Me.cmbExpensesCategory.Enabled = Me.chkExpenseCategory.Checked
    End Sub


    Private Sub CopyCardNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim s As String = ""
        'Dim o As New DataObject
        's = Me.DataGridView1.SelectedRows(0).Cells(2).Value.ToString
        'o.SetText(s)
        'Clipboard.SetDataObject(o, True)
    End Sub

    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
            Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
                Me.cmbOperators.DataSource = dsOperators.Tables(0)
                Me.cmbOperators.DisplayMember = "Operator"
                Me.cmbOperators.ValueMember = "ID"
            End If

            Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
                Me.cmbProviders.DataSource = dsProvider.Tables(0)
                Me.cmbProviders.DisplayMember = "Provider"
                Me.cmbProviders.ValueMember = "ID"
            End If

            Me.cmbSimCardType.DataSource = Nothing
            Dim dsSimCardTypes As DataSet = odbaccess.GetSimCardsTypes(CInt(Me.cmbCountries.SelectedValue))
            If Not dsSimCardTypes Is Nothing AndAlso Not dsSimCardTypes.Tables.Count = 0 AndAlso Not dsSimCardTypes.Tables(0).Rows.Count = 0 Then
                Me.cmbSimCardType.DataSource = dsSimCardTypes.Tables(0)
                Me.cmbSimCardType.DisplayMember = "CardType"
                Me.cmbSimCardType.ValueMember = "ID"
            End If

        End If
    End Sub

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedIndexChanged
        If Me.chkOperator.Checked Then
            Dim dsCategory As DataSet = odbaccess.GetCategories(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbOperators.SelectedValue))
            If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
                Me.cmbCategory.DataSource = dsCategory.Tables(0)
                Me.cmbCategory.DisplayMember = "Category"
                Me.cmbCategory.ValueMember = "ID"
            End If
        End If

    End Sub

    Private Sub chkCountry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCountry.CheckedChanged
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub

    Private Sub chkProvider_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProvider.CheckedChanged
        Me.cmbProviders.Enabled = Me.chkProvider.Checked
    End Sub

    Private Sub chkOperator_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOperator.CheckedChanged
        Me.cmbOperators.Enabled = Me.chkOperator.Checked
    End Sub

    Private Sub chkCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCategory.CheckedChanged
        Me.cmbCategory.Enabled = Me.chkCategory.Checked
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpToDate.Enabled = chkDate.Checked
        Me.dtpFromDate.Enabled = chkDate.Checked
    End Sub

    Public Sub FillTypes()
        Try
            dsCountries = odbaccess.GetCountriesDS
            If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
                Me.cmbCountries.DataSource = dsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If

            Dim colUsers As ColUser = odbaccess.GetUsers(0)
            If Not colUsers Is Nothing Then
                Me.cmbUsers.DataSource = colUsers
                Me.cmbUsers.DisplayMember = "Username"
                Me.cmbUsers.ValueMember = "ID"
            End If

            Dim dsExpensesCategories As DataSet = odbaccess.getExpensesCategories(True)
            If Not dsExpensesCategories Is Nothing AndAlso Not dsExpensesCategories.Tables.Count = 0 AndAlso Not dsExpensesCategories.Tables(0).Rows.Count = 0 Then
                Me.cmbExpensesCategory.DataSource = dsExpensesCategories.Tables(0)
                Me.cmbExpensesCategory.DisplayMember = "Category"
                Me.cmbExpensesCategory.ValueMember = "ID"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Generate()
        If Me.chkCategory.Checked AndAlso Not cmbCategory.SelectedValue Is Nothing Then
            lCategoryID = CInt(Me.cmbCategory.SelectedValue)
        Else
            lCategoryID = 0
        End If

        If Me.chkCountry.Checked AndAlso Not cmbCountries.SelectedValue Is Nothing Then
            lCountryID = CInt(Me.cmbCountries.SelectedValue)
        Else
            lCountryID = 0
        End If

        If Me.chkOperator.Checked AndAlso Not cmbOperators.SelectedValue Is Nothing Then
            lOperatorID = CInt(Me.cmbOperators.SelectedValue)
        Else
            lOperatorID = 0
        End If

        If Me.chkProvider.Checked AndAlso Not cmbProviders.SelectedValue Is Nothing Then
            lProviderID = CInt(Me.cmbProviders.SelectedValue)
        Else
            lProviderID = 0
        End If
        If Me.chkSimCardType.Checked AndAlso Not cmbSimCardType.SelectedValue Is Nothing Then
            lSimCardType = CInt(Me.cmbSimCardType.SelectedValue)
        Else
            lSimCardType = 0
        End If
        If Me.chkDate.Checked Then
            boolCheckDate = True
            FromDate = Me.dtpFromDate.Value
            ToDate = CDate(Me.dtpToDate.Value).AddDays(1)
        Else
            boolCheckDate = False
        End If

        If Me.chkUsers.Checked AndAlso Not cmbUsers.SelectedValue Is Nothing Then
            lInsertedByID = CInt(Me.cmbUsers.SelectedValue)
        Else
            lInsertedByID = 0
        End If

        If Me.chkExpenseCategory.Checked Then
            lExpenseCategory = CInt(Me.cmbExpensesCategory.SelectedValue)
        Else
            lExpenseCategory = 0
        End If
    End Sub

    Private Sub chkUsers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUsers.CheckedChanged
        Me.cmbUsers.Enabled = Me.chkUsers.Checked
    End Sub


    Private Sub chkLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSimCardType.CheckedChanged
        Me.cmbSimCardType.Enabled = chkSimCardType.Checked
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAirtimeCards.Click
        If Application.OpenForms().OfType(Of frmAddExpense_Cards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddExpense_Cards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddExpense_Cards(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOtherExpenses.Click
        If Application.OpenForms().OfType(Of frmAddExpense_Others).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddExpense_Others") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddExpense_Others(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub


End Class
