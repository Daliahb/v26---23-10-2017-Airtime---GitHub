﻿Public Class frmCardsReport

    Dim lCountryID, lProviderID, lOperatorID, lCategoryID, lGetCardFrom As Integer
    Dim FromDate, ToDate As Date
    Dim boolCheckDate, isloaded As Boolean
    Dim strCardNo As String
    'Dim dsCountries As DataSet

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        FillTypes()
        isloaded = True

        If Not cmbCountries.Items.Count = 0 Then
            Me.cmbCountries.SelectedIndex = -1
            Me.cmbCountries.SelectedIndex = 0
        Else
            FillTypes()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim lUnusedCount, lUsedCount As Integer
        Dim intRowIndex As Integer

        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            Generate()
            ds = odbaccess.GetCardsReport(lCountryID, lProviderID, lOperatorID, lCategoryID, FromDate, ToDate)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = intCounter + 1
                            .Cells(2).Value = dr.Item("card_number")
                            .Cells(3).Value = dr.Item("Country")
                            .Cells(4).Value = dr.Item("Provider")
                            .Cells(5).Value = dr.Item("Operator")
                            .Cells(6).Value = dr.Item("Category")
                            .Cells(7).Value = CDate(dr.Item("inst_Date")).ToString("yyyy-MM-dd HH:mm")
                            If CBool(dr.Item("isUsed")) Then
                                .Cells(8).Value = "Yes"
                                .Cells(9).Value = CDate(dr.Item("Used_Date")).ToString("yyyy-MM-dd HH:mm")
                                lUsedCount += 1
                            Else
                                .Cells(8).Value = "No"
                                .Cells(9).Value = ""
                                lUnusedCount += 1
                            End If

                            intCounter += 1

                        End With
                    Catch ex As Exception

                    End Try
                Next
                Me.lblUnusedCards.Text = lUnusedCount.ToString
                Me.lblUsedCards.Text = lUsedCount.ToString
                Me.lblTotal.Text = CStr(lUnusedCount + lUsedCount)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
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

        FromDate = Me.dtpFromDate.Value
        ToDate = CDate(Me.dtpToDate.Value).AddDays(1)
    End Sub

    Public Sub FillTypes()
        Try

            'dsCountries = odbaccess.GetCountriesDS
            'If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
            '    Me.cmbCountries.DataSource = dsCountries.Tables(0)
            '    Me.cmbCountries.DisplayMember = "Country"
            '    Me.cmbCountries.ValueMember = "ID"
            'End If
            '   gdsCountries = odbaccess.GetCountriesDS
            '   If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
            If Not gdsCountries Is Nothing AndAlso Not gdsCountries.Tables.Count = 0 Then
                Me.cmbCountries.DataSource = gdsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If

            '  End If
        Catch ex As Exception

        End Try
    End Sub

    Dim intColumnIndex As Integer

    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.DataGridView1.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                DataGridView1.ContextMenuStrip = ContextMenuStrip1

            ElseIf ht.Type = DataGridViewHitTestType.ColumnHeader Then
                Me.intColumnIndex = ht.ColumnIndex
                DataGridView1.ContextMenuStrip = ContextMenuStripHideColumn
            Else
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
    End Sub

    Private Sub HideColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideColumnToolStripMenuItem.Click
        Me.DataGridView1.Columns(intColumnIndex).Visible = False
    End Sub

    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        For i As Integer = 1 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns(i).Visible = True
        Next
    End Sub

    Private Sub ShowHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHistoryToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex

            Dim frm As New frmCardHistory(Me.DataGridView1.Rows(RowIndex).Cells(3).Value.ToString, CLng(Me.DataGridView1.Rows(RowIndex).Cells(0).Value))
            frm.ShowDialog()
        End If
    End Sub

    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
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

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedIndexChanged
        If Me.chkOperator.Checked Then
            'Dim dsCategory As DataSet = odbaccess.GetCategories(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbOperators.SelectedValue))
            'If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
            '    Me.cmbCategory.DataSource = dsCategory.Tables(0)
            '    Me.cmbCategory.DisplayMember = "Category"
            '    Me.cmbCategory.ValueMember = "ID"
            'End If
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
End Class
