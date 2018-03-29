Public Class frmShiftReport

    Public boolEqual, isLoaded, isSaved As Boolean
    Dim ds As DataSet

#Region "Controls Events"
   

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsShifts.shifts' table. You can move, or remove it, as needed.
        Me.ShiftsTableAdapter.Fill(Me.DsShifts.shifts)
        'Me.BackColor = gBackColor
        isSaved = True
        Try
            'Dim dsCountries As New DataSet
            'dsCountries = odbaccess.GetCountriesDS
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

            Dim dsShifts As New DataSet
            dsShifts = odbaccess.GetAuditShifts
            If Not dsShifts Is Nothing AndAlso Not dsShifts.Tables.Count = 0 AndAlso Not dsShifts.Tables(0).Rows.Count = 0 Then
                Me.cmbShifts.DataSource = dsShifts.Tables(0)
                Me.cmbShifts.DisplayMember = "Shift"
                Me.cmbShifts.ValueMember = "ID"
            End If

            ' print
            'GridPrinter = New DataGridPrinter(Me.DataGridView1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        ' Dim lCountryID, lOperatorID As Long
        Dim strProvider As String = ""


        Me.lblError.Visible = False
        Me.DataGridView1.Rows.Clear()
        Me.btnSearch.Enabled = False
        isLoaded = False
        Try

            ds = odbaccess.GetShiftReport(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbShifts.SelectedValue), Me.DateTimePicker1.Value)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 And Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        If strProvider <> dr.Item("Provider").ToString Then
                            boolEqual = True
                            intRowIndex = Me.DataGridView1.Rows.Add
                            With Me.DataGridView1.Rows(intRowIndex)
                                .Cells(0).Value = ""
                                .Cells(1).Value = ""
                                .Cells(2).Value = ""
                                .Cells(3).Value = ""
                                .Cells(4).Value = ""
                                .Cells(5).Value = ""
                                .Cells(6).Value = dr.Item("Provider").ToString
                                .Cells(7).Value = ""
                                .Cells(8).Value = ""
                                .Cells(9).Value = ""
                                .Cells(10).Value = ""
                                .Cells(11).Value = 0
                                .DefaultCellStyle.Font = Me.Label2.Font
                                For i = 0 To Me.DataGridView1.ColumnCount - 1
                                    .DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
                                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                                Next
                                '   Me.DataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
                            End With
                            strProvider = dr.Item("Provider").ToString
                            '  Me.DataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single
                        End If
                        '  boolEqual = False
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("FK_Provider")
                            .Cells(1).Value = dr.Item("Operator")
                            .Cells(2).Value = dr.Item("ShiftStartStatus")
                            .Cells(3).Value = dr.Item("ShiftInsertedCards")
                            .Cells(4).Value = dr.Item("ShiftUsedCards")
                            .Cells(5).Value = CDbl(dr.Item("ShiftStartStatus")) + CDbl(dr.Item("ShiftInsertedCards")) - CDbl(dr.Item("ShiftUsedCards")) ' total
                            .Cells(6).Value = dr.Item("ShiftRemainingCards")
                            .Cells(7).Value = dr.Item("ShiftWrongCards")
                            .Cells(8).Value = dr.Item("SimsInSite") 'Sim cards in site
                            .Cells(9).Value = dr.Item("AirtimeCardsInSite") ' Airtime cards in site
                            .Cells(10).Value = dr.Item("ProviderBalance")
                            .Cells(11).Value = dr.Item("ID")
                        End With
                    Catch ex As Exception

                    End Try
                Next

                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(1).Cells(8)

                ' check if not isWithinShiftTiming then disable "Save Report" and changing in In sites values
                If Not ds.Tables.Count = 1 AndAlso Not ds.Tables(1).Rows.Count = 0 Then
                    If CBool(ds.Tables(1).Rows(0).Item(0)) = False Then
                        Me.btnSaveReport.Enabled = False
                        For Each row As DataGridViewRow In Me.DataGridView1.Rows
                            row.Cells(8).ReadOnly = True
                            row.Cells(9).ReadOnly = True
                        Next
                    End If
                End If


                Me.btnPrint.Enabled = True
                isLoaded = True
            Else
                lblError.Text = "There is no data matching your filter in database.." & vbLf & "The system cannot generate reports for past or future shifts!"
                Me.lblError.Visible = True
                Me.btnPrint.Enabled = False
            End If
            Me.btnSearch.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If isLoaded Then
            Me.btnSaveReport.Enabled = True
            isSaved = False
            updateDS(e.RowIndex, e.ColumnIndex)
        End If
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

#End Region

    Public Sub updateDS(lRow As Integer, lColumn As Integer)
        For Each dr As DataRow In Me.ds.Tables(0).Rows
            If CInt(dr.Item("id")) = CInt(Me.DataGridView1.Rows(lRow).Cells(11).Value) Then
                If lColumn = 8 Then 'Sims in site
                    dr.Item("SimsInSite") = Me.DataGridView1.Rows(lRow).Cells(lColumn).Value
                    Exit Sub
                Else 'Airtime cards in site
                    dr.Item("AirtimeCardsInSite") = Me.DataGridView1.Rows(lRow).Cells(lColumn).Value
                    Exit Sub
                End If
            End If
        Next
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

    Private Sub EditPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCategoryToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
            Dim frm As New frmAddCategory(Enumerators.EditAdd.Edit, Me.DataGridView1.Rows(RowIndex))
            frm.ShowDialog()
            With Me.DataGridView1.Rows(RowIndex)
                .Cells(2).Value = frm.txtCategory.Text
                .Cells(3).Value = frm.cmbOperators.Text
                .Cells(4).Value = frm.cmbOperators.SelectedValue
                .Cells(5).Value = frm.cmbCountries.Text
                .Cells(6).Value = frm.cmbCountries.SelectedValue
            End With

        End If
    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '     If e.ColumnIndex = 0 Then
        e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
        If (e.RowIndex < 0 Or e.ColumnIndex < 0) Then
            Exit Sub
        End If
        If Not Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString = "" Then

            ' e.Value = "";
            'e.FormattingApplied = True
            'Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.
            'Me.DataGridView1.Rows(e.RowIndex).Cells(0).FormattingApplie = True

            e.AdvancedBorderStyle.Right = DataGridView1.AdvancedCellBorderStyle.Right
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Inset
            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.OutsetDouble
        Else
            e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single
            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single
        End If
        '  End If
        'If boolEqual Then
        '    e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
        'Else
        '    e.AdvancedBorderStyle.Right = DataGridView1.AdvancedCellBorderStyle.Right
        'End If
    End Sub

    Private Sub btnSaveReport_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveReport.Click
        Me.btnSaveReport.Enabled = False
        Dim strData As New System.Text.StringBuilder
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            If CInt(row.Cells(11).Value) > 0 Then
                strData.Append(row.Cells(11).Value.ToString) ' ID
                strData.Append(",")
                strData.Append(row.Cells(8).Value.ToString) ' Sims in site
                strData.Append(",")
                strData.Append(row.Cells(9).Value.ToString) ' Airtime in site
                strData.Append("|")
            End If
        Next
        If Not strData.ToString.Length = 0 Then
            If odbaccess.SaveShiftReport(strData.ToString, Me.DateTimePicker1.Value, CInt(Me.cmbShifts.SelectedValue), CInt(Me.cmbCountries.SelectedValue)) Then
                isSaved = True
                MsgBox("Report saved successfully.", , "Airtime System")
            Else
                MsgBox("An error occured.", , "Airtime System")
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If isSaved Then
            Dim x As New GenerateExcel
            x.GenerateExcelFile(Me.ds, Me.cmbShifts.Text, Me.cmbCountries.Text)
        Else
            Select Case MsgBox("Do you want to save changes before you print this report?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSaveReport_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No

                Case MsgBoxResult.Cancel
                    Return
            End Select
            Dim x As New GenerateExcel
            x.GenerateExcelFile(Me.ds, Me.cmbShifts.Text, Me.cmbCountries.Text)
        End If

    End Sub

End Class
