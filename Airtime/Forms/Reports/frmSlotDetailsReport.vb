Public Class frmSlotDetailsReport

    Dim ds As DataSet
    Dim isLoaded As Boolean

#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsSlots.DataTable1' table. You can move, or remove it, as needed.
        Me.DataTable1TableAdapter.Fill(Me.DsSlots.DataTable1)
        'TODO: This line of code loads data into the 'DsShifts.shifts' table. You can move, or remove it, as needed.
        Me.ShiftsTableAdapter.Fill(Me.DsShifts.shifts)
        'Me.BackColor = gBackColor

        FillTypes()
        isloaded = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        ' Dim lCountryID, lOperatorID As Long
        Dim oSlotInfoSearch As New SlotInfoSearch
        Try
            Me.btnSearch.Enabled = False
            Me.DataGridView1.Rows.Clear()
            generate(oSlotInfoSearch)
            ds = odbaccess.GetSlotDetailsReport(oSlotInfoSearch)

            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells("dgCountry").Value = dr.Item("Country")
                            .Cells("dgDevice").Value = dr.Item("Device")
                            .Cells("dgOperator").Value = dr.Item("Operator")
                            .Cells("dgSlot").Value = dr.Item("Slot")
                            .Cells("dgCreateTime").Value = CDate(dr.Item("Created_Time")).ToString("dd-MM-yyyy HH:mmm:ss")
                            If Not dr.Item("Start_Time") Is DBNull.Value Then
                                .Cells("dgStartTime").Value = CDate(dr.Item("Start_Time")).ToString("dd-MM-yyyy HH:mmm:ss")
                            End If
                            If Not dr.Item("Cut_Time") Is DBNull.Value Then
                                .Cells("dgCutTime").Value = CDate(dr.Item("Cut_Time")).ToString("dd-MM-yyyy HH:mmm:ss")
                            End If
                            If Not dr.Item("CreatedBy") Is DBNull.Value Then
                                .Cells("dgCreatedBy").Value = dr.Item("CreatedBy")
                            End If
                            If Not dr.Item("StartedBy") Is DBNull.Value Then
                                .Cells("dgStartedBy").Value = dr.Item("StartedBy")
                            End If
                            .Cells("dgRechargedBy").Value = getRechargedBy(CLng(dr.Item("id")))
                            If Not dr.Item("CutBy") Is DBNull.Value Then
                                .Cells("dgCutBy").Value = dr.Item("CutBy")
                            End If

                            If Not dr.Item("First_Start_Time") Is DBNull.Value Then
                                .Cells("dgFirstStartTime").Value = CDate(dr.Item("First_Start_Time")).ToString("dd-MM-yyyy HH:mmm:ss")
                            End If
                            If Not dr.Item("FirstStartUser") Is DBNull.Value Then
                                .Cells("dgFirstStartBy").Value = dr.Item("FirstStartUser")
                            End If

                            If Not dr.Item("First_Cut_Time") Is DBNull.Value Then
                                .Cells("dgFirstCutTime").Value = CDate(dr.Item("First_Cut_Time")).ToString("dd-MM-yyyy HH:mmm:ss")
                            End If
                            If Not dr.Item("FirstCutUser") Is DBNull.Value Then
                                .Cells("dgFirstCutBy").Value = dr.Item("FirstCutUser")
                            End If
                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next

            End If
            Me.btnSearch.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Public Function getRechargedBy(lDeviceSlotID As Long) As String
        Dim str As String = ""
        Try
            If Not ds.Tables(1).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(1).Rows
                    If CLng(dr.Item("id")) = lDeviceSlotID Then
                        str = str + dr.Item("UserName").ToString
                        str = str + ", "
                    End If
                Next
                If Not str.Length = 0 Then
                    str = str.Remove(str.Length - 2, 2)
                End If
            End If

            Return str
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Sub FillTypes()
        Try
            Dim dsCountries, dsDevices As DataSet
            dsCountries = odbaccess.GetCountriesDS
            If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
                Me.cmbCountries.DataSource = dsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If

            dsDevices = odbaccess.GetDevices(0)
            If Not dsDevices Is Nothing Then
                Me.cmbDevices.DataSource = dsDevices.Tables(0)
                Me.cmbDevices.DisplayMember = "Device"
                Me.cmbDevices.ValueMember = "ID"
            End If

            Dim colUsersCreate As ColUser = odbaccess.GetUsers(5)
            If Not colUsersCreate Is Nothing Then
                Me.cmbUsersCreate.DataSource = colUsersCreate
                Me.cmbUsersCreate.DisplayMember = "Username"
                Me.cmbUsersCreate.ValueMember = "ID"
            End If

            Dim colUsersCharge As ColUser = odbaccess.GetUsers(5)
            If Not colUsersCharge Is Nothing Then
                Me.cmbUsersCharged.DataSource = colUsersCharge
                Me.cmbUsersCharged.DisplayMember = "Username"
                Me.cmbUsersCharged.ValueMember = "ID"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub generate(ByRef oSlotInfoSearch As SlotInfoSearch)
        Try
            With oSlotInfoSearch
                If Me.chkCountry.Checked Then
                    .lCountryID = CInt(Me.cmbCountries.SelectedValue)
                Else
                    .lCountryID = 0
                End If

                If Me.chkOperator.Checked Then
                    .lOperator = CInt(Me.cmbOperators.SelectedValue)
                Else
                    .lOperator = 0
                End If

                If Me.chkDevice.Checked Then
                    .lDeviceID = CInt(Me.cmbDevices.SelectedValue)
                Else
                    .lDeviceID = 0
                End If
                If Me.chkSlot.Checked Then
                    .lSlotID = CInt(Me.cmbSlot.SelectedValue)
                Else
                    .lSlotID = 0
                End If

                If Me.chkUserCreated.Checked Then
                    .lCreatedBy = CInt(Me.cmbUsersCreate.SelectedValue)
                Else
                    .lCreatedBy = 0
                End If

                If Me.chkUsersCharged.Checked Then
                    .lChargedBy = CInt(Me.cmbUsersCharged.SelectedValue)
                Else
                    .lChargedBy = 0
                End If

                If Me.chkDate.Checked Then
                    .boolDate = True
                    .dDateFrom = Me.dtpFromDate.Value
                    .dDateTo = Me.dtpToDate.Value
                Else
                    .boolDate = False
                End If
            End With
        Catch ex As Exception

        End Try


    End Sub
#End Region

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


    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
            Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
                Me.cmbOperators.DataSource = dsOperators.Tables(0)
                Me.cmbOperators.DisplayMember = "Operator"
                Me.cmbOperators.ValueMember = "ID"
            End If

        End If
    End Sub

    Private Sub chkCountry_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCountry.CheckedChanged
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub

    Private Sub chkDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpFromDate.Enabled = Me.chkDate.Checked
        Me.dtpToDate.Enabled = Me.chkDate.Checked
    End Sub

    Private Sub chkDevice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDevice.CheckedChanged
        Me.cmbDevices.Enabled = Me.chkDevice.Checked
    End Sub

    Private Sub chkOperator_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOperator.CheckedChanged
        Me.cmbOperators.Enabled = Me.chkOperator.Checked
    End Sub

    Private Sub chkSlot_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSlot.CheckedChanged
        Me.cmbSlot.Enabled = Me.chkSlot.Checked
    End Sub

    Private Sub chkUserCreated_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUserCreated.CheckedChanged
        Me.cmbUsersCreate.Enabled = Me.chkUserCreated.Checked
    End Sub

    Private Sub chkUsersCharged_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUsersCharged.CheckedChanged
        Me.cmbUsersCharged.Enabled = Me.chkUsersCharged.Checked
    End Sub
End Class
