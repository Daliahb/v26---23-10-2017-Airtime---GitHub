Public Class frmSimCardsType

    Dim dsSimCardsType As DataSet

#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor

        FillTypes()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex, intDsTables As Integer
        Dim lCountryID As Integer = 0

        Try
            Me.DataGridView1.Rows.Clear()
            If Me.chkCountry.Checked AndAlso Not Me.cmbCountries.SelectedValue Is Nothing Then
                lCountryID = CInt(Me.cmbCountries.SelectedValue)
            Else
                lCountryID = 0
            End If

            dsSimCardsType = odbaccess.GetSimCardsTypes(lCountryID)
            intDsTables = dsSimCardsType.Tables.Count
            If Not dsSimCardsType Is Nothing AndAlso Not dsSimCardsType.Tables().Count = 0 Then
                For Each dr As DataRow In dsSimCardsType.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = intCounter + 1
                            .Cells(2).Value = dr.Item("CardType")
                            .Cells(3).Value = dr.Item("Country")
                            .Cells(4).Value = dr.Item("fk_country")

                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
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

#End Region

    Public Sub FillTypes()
        Try
            Dim dsCountries As DataSet = odbaccess.GetCountriesDS

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

    Private Sub chkClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCountry.CheckedChanged
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmAddSimCardType(Enumerators.EditAdd.Add)
        frm.Show()
    End Sub

    Private Sub EditPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditProviderToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
            Dim frm As New frmAddSimCardType(Enumerators.EditAdd.Edit, Me.DataGridView1.Rows(RowIndex))
            frm.ShowDialog()
            Me.DataGridView1.Rows(RowIndex).Cells(2).Value = frm.txtName.Text
            Me.DataGridView1.Rows(RowIndex).Cells(3).Value = frm.cmbCountries.Text
            Me.DataGridView1.Rows(RowIndex).Cells(4).Value = frm.cmbCountries.SelectedValue
        End If
    End Sub

    Private Sub DeleteProviderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteProviderToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
            Dim lId As Integer
            lId = CInt(Me.DataGridView1.Rows(RowIndex).Cells(0).Value)
            If odbaccess.DeleteProvider(lId) Then
                MsgBox("Operation done successfuly.", , "Airtime System")
                Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(RowIndex))
            Else
                MsgBox("An error occured.", , "Airtime System")
            End If
        End If
    End Sub


End Class
