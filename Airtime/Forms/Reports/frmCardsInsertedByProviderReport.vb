Public Class frmCardsInsertedByProviderReport

    Dim lCountryID, lProviderID As Integer
    Dim FromDate, ToDate As Date
    Dim isloaded As Boolean
    Dim strCardNo As String
    Dim dsCountries As DataSet
    Dim boolError As Boolean = True

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillTypes()
        isloaded = True

        Me.cmbCountries.SelectedIndex = -1
        Me.cmbCountries.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim lCount As Integer
        Dim intRowIndex As Integer

        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            Generate()
            If boolError Then
                ds = odbaccess.GetCardsInsertedByProviderReport(lCountryID, lProviderID, FromDate, ToDate)
                If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                    For Each dr As DataRow In ds.Tables(0).Rows
                        Try
                            intRowIndex = Me.DataGridView1.Rows.Add
                            With Me.DataGridView1.Rows(intRowIndex)
                                .Cells(0).Value = dr.Item("Category")
                                .Cells(1).Value = dr.Item("Operator")
                                .Cells(2).Value = dr.Item("Count")
                                .Cells(3).Value = dr.Item("Insert_Date")
                                .Cells(4).Value = dr.Item("Approved cards")
                                .Cells(5).Value = dr.Item("wrong cards")
                                lCount += CInt(dr.Item("Count"))

                            End With
                        Catch ex As Exception

                        End Try
                    Next
                    Me.lblTotal.Text = CStr(lCount)
                    Me.Text = "Cards Inserted by Provider - Total cards are " + CStr(lCount)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Public Sub Generate()
        If Me.cmbCountries.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbCountries, "Please select country from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbCountries, "")
        End If

        If Me.cmbProviders.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbProviders, "Please select provider from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbProviders, "")
        End If

        lProviderID = CInt(Me.cmbProviders.SelectedValue)
        lCountryID = CInt(Me.cmbCountries.SelectedValue)
        FromDate = Me.dtpFromDate.Value
        ToDate = CDate(Me.dtpToDate.Value).AddDays(1)
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
            Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
                Me.cmbProviders.DataSource = dsProvider.Tables(0)
                Me.cmbProviders.DisplayMember = "Provider"
                Me.cmbProviders.ValueMember = "ID"
            End If
        End If
    End Sub

End Class
