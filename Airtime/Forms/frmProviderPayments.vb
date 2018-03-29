Public Class frmProviderPayments

    Dim ds As DataSet
    Dim lCountryID, lProviderID, lSimCardType, lInsertedByID As Integer
    Dim FromDate, ToDate As Date
    Dim boolCheckDate, isloaded, isCheckIsSentToExpenses, isCheckIsSentToExpensesYes As Boolean
    ' Dim dsCountries As DataSet
    Dim dblTotalAmount As Double = 0.0
    Dim oColSimcardsOrder As New ColSimcardsOrder

    Private Sub frmProviderPayments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            ds = odbaccess.getPayments(lCountryID, lProviderID, boolCheckDate, FromDate, ToDate)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = dr.Item("fk_Country")
                            .Cells(2).Value = dr.Item("fk_Provider")
                            .Cells(3).Value = intCounter + 1
                            .Cells(4).Value = dr.Item("Country")
                            .Cells(5).Value = dr.Item("Provider")
                            .Cells(6).Value = dr.Item("Amount")
                            .Cells(7).Value = CDate(dr.Item("Payment_Date")).ToString("yyyy-MM-dd")
                            .Cells(8).Value = dr.Item("Username")

                            intCounter += 1
                            dblTotalAmount += CDec(dr.Item("Amount"))

                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If
            Me.Text = "Providers Payments - " + dblTotalAmount.ToString + " $"
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
            Dim RowIndex As Integer = Me.DataGridView1.SelectedRows(0).Index
            Dim frm3 As New frmAddProviderPayment(Enumerators.EditAdd.Edit, Me.DataGridView1.SelectedRows(0))
            frm3.ShowDialog()
            If frm3.boolSaved Then
                Me.DataGridView1.Rows(RowIndex).Cells(1).Value = frm3.cmbCountries.SelectedValue
                Me.DataGridView1.Rows(RowIndex).Cells(2).Value = frm3.cmbProviders.SelectedValue
                '  Me.DataGridView1.Rows(RowIndex).Cells(3).Value = frm3.cmbProviders.Text
                Me.DataGridView1.Rows(RowIndex).Cells(4).Value = frm3.cmbCountries.Text
                Me.DataGridView1.Rows(RowIndex).Cells(5).Value = frm3.cmbProviders.Text
                Me.DataGridView1.Rows(RowIndex).Cells(6).Value = frm3.txtTotalAmount.Text
                Me.DataGridView1.Rows(RowIndex).Cells(7).Value = frm3.dtpFromDate.Value.ToString("yyyy-MM-dd")

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
            Me.Text = "Providers Payments - " + dblTotalAmount.ToString + " $"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
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
            If Not gdsCountries Is Nothing AndAlso Not gdsCountries.Tables.Count = 0 Then
                Me.cmbCountries.DataSource = gdsCountries.Tables(0)
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

        If Me.chkDate.Checked Then
            boolCheckDate = True
            FromDate = Me.dtpFromDate.Value
            ToDate = CDate(Me.dtpToDate.Value).AddDays(1)
        Else
            boolCheckDate = False
        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAirtimeCards.Click
        If Application.OpenForms().OfType(Of frmAddProviderPayment).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddProviderPayment") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddProviderPayment(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

End Class
