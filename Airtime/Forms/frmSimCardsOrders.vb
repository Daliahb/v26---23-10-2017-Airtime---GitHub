Public Class frmSimCardsOrders

    Dim ds As DataSet
    Dim lCountryID, lProviderID, lSimCardType, lInsertedByID As Integer
    Dim FromDate, ToDate As Date
    Dim boolCheckDate, isloaded, isCheckIsSentToExpenses, isCheckIsSentToExpensesYes As Boolean
    Dim dsCountries As DataSet
    Dim dblTotalAmount As Double = 0.0
    Dim oColSimcardsOrder As New ColSimcardsOrder

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
            oColSimcardsOrder = odbaccess.GetSimcardsOrders(lCountryID, lProviderID, lSimCardType, boolCheckDate, FromDate, ToDate, isCheckIsSentToExpenses, isCheckIsSentToExpensesYes)
            If Not oColSimcardsOrder Is Nothing AndAlso Not oColSimcardsOrder.Count = 0 Then
                For Each oSimcardsOrder As SimcardsOrder In oColSimcardsOrder
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = oSimcardsOrder.SimCardOrderID
                            .Cells(1).Value = intCounter
                            .Cells(2).Value = oSimcardsOrder.Country
                            .Cells(3).Value = oSimcardsOrder.Provider
                            .Cells(4).Value = oSimcardsOrder.NoOfCards
                            .Cells(5).Value = oSimcardsOrder.CardValue
                            .Cells(6).Value = oSimcardsOrder.TotalAmount
                            .Cells(7).Value = oSimcardsOrder.SimCardType
                            .Cells(8).Value = oSimcardsOrder.InsertedByUserName
                            .Cells(9).Value = CDate(oSimcardsOrder.SimcardOrderDate).ToString("yyyy-MM-dd")
                            .Cells(10).Value = oSimcardsOrder.isApproved
                            dblTotalAmount += oSimcardsOrder.TotalAmount
                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If
            Me.Text = "Sim cards orders - " + dblTotalAmount.ToString + " $"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(1).Value = i + 1
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
            Dim lSimcardsOrderID As Integer
            Dim RowIndex As Integer = Me.DataGridView1.SelectedRows(0).Index
            Dim oSimcardsOrder As SimcardsOrder
            lSimcardsOrderID = CInt(Me.DataGridView1.Rows(RowIndex).Cells(0).Value)


            For Each oExp As SimcardsOrder In Me.oColSimcardsOrder
                If oExp.SimCardOrderID = lSimcardsOrderID Then
                    oSimcardsOrder = oExp
                End If
            Next

            Dim frm3 As New frmAddSimCards(Enumerators.EditAdd.Edit, oSimcardsOrder)
            frm3.ShowDialog()
            If frm3.boolSaved Then
                Me.DataGridView1.Rows(RowIndex).Cells(2).Value = frm3.cmbCountries.Text
                Me.DataGridView1.Rows(RowIndex).Cells(3).Value = frm3.cmbProviders.Text
                Me.DataGridView1.Rows(RowIndex).Cells(4).Value = frm3.txtNoOfCards.Text
                Me.DataGridView1.Rows(RowIndex).Cells(5).Value = frm3.txtCardValue.Text
                Me.DataGridView1.Rows(RowIndex).Cells(6).Value = frm3.txtTotalAmount.Text
                Me.DataGridView1.Rows(RowIndex).Cells(7).Value = frm3.cmbSimCardTypes.Text
                Me.DataGridView1.Rows(RowIndex).Cells(9).Value = frm3.dtpFromDate.Value.ToString("yyyy-MM-dd")
                If gUser.type = Enumerators.UsersTypes.Admin Or gUser.type = Enumerators.UsersTypes.Audit Then
                    Me.DataGridView1.Rows(RowIndex).Cells(10).Value = True
                End If

                CalculateTotalAmounts()
            End If
        End If
    End Sub

    Public Sub CalculateTotalAmounts()
        dblTotalAmount = 0.0
        Try

            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                dblTotalAmount += CDec(row.Cells(6).Value)
            Next
            Me.Text = "Sim cards orders - " + dblTotalAmount.ToString + " $"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
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

    Private Sub chkCountry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCountry.CheckedChanged
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub

    Private Sub chkProvider_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProvider.CheckedChanged
        Me.cmbProviders.Enabled = Me.chkProvider.Checked
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

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Generate()
        If Me.chkCountry.Checked AndAlso Not cmbCountries.SelectedValue Is Nothing Then
            lCountryID = CInt(Me.cmbCountries.SelectedValue)
        Else
            lCountryID = 0
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

        If Me.chkSentToExpenses.Checked Then
            isCheckIsSentToExpenses = True
            If Me.rbYes.Checked Then
                isCheckIsSentToExpensesYes = True
            Else
                isCheckIsSentToExpensesYes = False
            End If
        Else
            isCheckIsSentToExpenses = False
        End If
        'If Me.chkUsers.Checked AndAlso Not cmbUsers.SelectedValue Is Nothing Then
        '    lInsertedByID = CInt(Me.cmbUsers.SelectedValue)
        'Else
        '    lInsertedByID = 0
        'End If
    End Sub

    Private Sub chkSimCardType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSimCardType.CheckedChanged
        Me.cmbSimCardType.Enabled = chkSimCardType.Checked
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAirtimeCards.Click
        If Application.OpenForms().OfType(Of frmAddSimCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddSimCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddSimCards(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

   
    Private Sub chkSentToExpenses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSentToExpenses.CheckedChanged
        Me.gbSentToExpenses.Enabled = Me.chkSentToExpenses.Checked
    End Sub
End Class
