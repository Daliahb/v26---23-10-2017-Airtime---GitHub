Public Class frmCardHistory

    Public strCardNo As String
    Public lCardId As Long

    Public Sub New(ByVal strCardNo As String, ByVal lCardId As Long)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.strCardNo = strCardNo
        Me.lCardId = lCardId
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor

        Me.lblScratchNo.Text = strCardNo
        btnSearch_Click(Me, New System.EventArgs)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lCountryID As Long = 0
        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()

            ds = odbaccess.GetCardHistory(lCardID)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = intCounter + 1
                            .Cells(2).Value = dr.Item("Username")
                            .Cells(3).Value = CDate(dr.Item("inst_Date")).ToString("yyyy-MM-dd")
                            .Cells(4).Value = CDate(dr.Item("inst_Date")).ToString("HH:mm")
                            .Cells(5).Value = dr.Item("Note")

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

    Private Sub EditPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditProviderToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
            Dim frm As New frmAddProvider(Enumerators.EditAdd.Edit, Me.DataGridView1.Rows(RowIndex))
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
