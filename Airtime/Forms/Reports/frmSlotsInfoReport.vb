Public Class frmSlotsInfoReport

    Dim isLoaded As Boolean
    Dim intTotalSims As Integer = 0
    Dim dblTotalDuration, dblTotalBalance, dblTotalCalls As Double

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsSlots1.DataTable1' table. You can move, or remove it, as needed.
        Me.DataTable1TableAdapter1.Fill(Me.DsSlots1.DataTable1)


        FillTypes()
        isloaded = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        ' Dim lCountryID, lOperatorID As Long
        Dim ds As DataSet
        Dim oSlotInfoSearch As New SlotInfoSearch
        Try
            Me.DataGridView1.Rows.Clear()
            GenerateControl(oSlotInfoSearch)
            Me.btnSearch.Enabled = False
            ds = odbaccess.GetSlotsReport(oSlotInfoSearch)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                Me.dblTotalDuration = 0
                Me.dblTotalCalls = 0
                Me.dblTotalBalance = 0
                Me.intTotalSims = 0
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = dr.Item("FK_Device")
                            .Cells("dgCountry").Value = dr.Item("Country")
                            .Cells("dgShift").Value = dr.Item("shift")
                            .Cells("dgDevice").Value = dr.Item("Device")
                            .Cells("dgSlot").Value = dr.Item("Slot")
                            .Cells("dgNoOfsims").Value = dr.Item("NoOfsims")
                            intTotalSims += CInt(dr.Item("NoOfsims"))
                            .Cells("dgCreatedTime").Value = CDate(dr.Item("Created_Time")).ToString("dd-MM-yyyy HH:mmm")

                            If Not dr.Item("Create_Note") Is DBNull.Value Then
                                .Cells("dgCreateNote").Value = dr.Item("Create_Note")
                            End If

                            If Not dr.Item("Start_Time") Is DBNull.Value Then
                                .Cells("dgStartTime").Value = CDate(dr.Item("Start_Time")).ToString("dd-MM-yyyy HH:mmm")
                            End If

                            If Not dr.Item("Traffic") Is DBNull.Value Then
                                .Cells("dgTrafficType").Value = dr.Item("Traffic")
                            End If
                            If Not dr.Item("Offer") Is DBNull.Value Then
                                .Cells("dgOffer").Value = dr.Item("Offer")
                            End If
                            If Not dr.Item("MinuteCost") Is DBNull.Value Then
                                .Cells("dgMinuteCost").Value = dr.Item("MinuteCost")
                            End If
                            If Not dr.Item("Cut_Time") Is DBNull.Value Then
                                .Cells("dgCutTime").Value = CDate(dr.Item("Cut_Time")).ToString("dd-MM-yyyy HH:mmm")
                            End If

                            If Not dr.Item("Cut_Note") Is DBNull.Value Then
                                .Cells("dgCutNote").Value = dr.Item("Cut_Note")
                            End If
                            If Not dr.Item("BurnedBalance") Is DBNull.Value Then
                                .Cells("dgBurnedBalance").Value = dr.Item("BurnedBalance")
                            End If
                            If Not dr.Item("ACD") Is DBNull.Value Then
                                .Cells("dgACD").Value = dr.Item("ACD")
                            End If

                            If Not dr.Item("ASR") Is DBNull.Value Then
                                .Cells("dgASR").Value = dr.Item("ASR").ToString + " %"
                            End If

                            If Not dr.Item("TotalCalls") Is DBNull.Value Then
                                .Cells("dgTotalCalls").Value = dr.Item("TotalCalls")
                                dblTotalCalls += CDbl(dr.Item("TotalCalls"))
                            End If
                            If Not dr.Item("TalkTime") Is DBNull.Value Then
                                .Cells("dgDuration").Value = dr.Item("TalkTime")
                                dblTotalDuration += CDbl(dr.Item("TalkTime"))
                            End If
                            If Not dr.Item("Balance") Is DBNull.Value Then
                                .Cells("dgBalance").Value = dr.Item("Balance")
                                dblTotalBalance += CDbl(dr.Item("Balance"))
                            End If
                            If Not dr.Item("ExpectedUsage") Is DBNull.Value Then
                                .Cells("dgExpectedUsage").Value = dr.Item("ExpectedUsage")
                            End If
                            .Cells("dgDifference").Value = CDbl(dr.Item("Balance")) - CDbl(dr.Item("ExpectedUsage"))
                            .Cells("dgHumanBehaviour").Value = getHumanBehaviour(dr.Item("HumanBehaviour").ToString)
                            .Cells("dgOwner").Value = dr.Item("Owner")
                            .Cells("dgOperator").Value = dr.Item("Operator")
                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
                Me.lblTotalBalance.Text = Me.dblTotalBalance.ToString
                Me.lblTotalCalls.Text = Me.dblTotalCalls.ToString
                Me.lblTotalDuration.Text = Me.dblTotalDuration.ToString
                Me.lblTotalSims.Text = Me.intTotalSims.ToString
            End If
            Me.btnSearch.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
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
        For i As Integer = 2 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns(i).Visible = True
        Next
    End Sub

    Private Sub EditPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Public Function getHumanBehaviour(str As String) As String
        Dim strArr() As String
        Dim count As Integer
        strArr = str.Split("|")
        Dim strBehaviours As String = ""
        For count = 0 To strArr.Length - 1
            If IsNumeric(strArr(count)) Then
                Select Case CType(strArr(count), Enumerators.Humanbehaviour)
                    Case Enumerators.Humanbehaviour.None
                        strBehaviours = strBehaviours + " None - "
                    Case Enumerators.Humanbehaviour.RecieveInternationalCalls
                        strBehaviours = strBehaviours + " Recieve I/C - "
                    Case Enumerators.Humanbehaviour.RecieveLocalCalls
                        strBehaviours = strBehaviours + "Recieve L/C - "
                    Case Enumerators.Humanbehaviour.SendInternationalCalls
                        strBehaviours = strBehaviours + "Send I/C - "
                    Case Enumerators.Humanbehaviour.SendLocalCalls
                        strBehaviours = strBehaviours + "Send L/C - "
                End Select
            End If
        Next
        If Not strBehaviours.Length = 0 Then
            strBehaviours = strBehaviours.Remove(strBehaviours.Length - 2, 2)
        End If

        Return strBehaviours
    End Function

    Public Sub GenerateControl(ByRef oSlotInfoSearch As SlotInfoSearch)
        Try
            With oSlotInfoSearch
                If Me.chkCountry.Checked Then
                    .lCountryID = CInt(Me.cmbCountries.SelectedValue)
                Else
                    .lCountryID = 0
                End If
                If Me.chkHumanBehaiviour.Checked Then
                    .enumHumanBehaviour = CType(cmbHumanBehaiviour.SelectedItem.value, Enumerators.Humanbehaviour)
                Else
                    .enumHumanBehaviour = 0
                End If
                If Me.chkOperator.Checked Then
                    .lOperator = CInt(Me.cmbOperators.SelectedValue)
                Else
                    .lOperator = 0
                End If
                If Me.chkOwner.Checked Then
                    .lOwner = CInt(Me.cmbOwner.SelectedValue)
                Else
                    .lOwner = 0
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
                If Me.chkTrafficType.Checked Then
                    .boolTraficType = True
                    .lTrafficType = CInt(Me.cmbTrafficType.SelectedValue)
                Else
                    .boolTraficType = False
                End If
                If Me.chkTotalSims.Checked Then
                    .boolTotalSims = True
                    .intTotalSimsFrom = CInt(Me.txtTotalSimsFrom.Text)
                    .intTotalSimsTo = CInt(Me.txtTotalSimsTo.Text)
                Else
                    .boolTotalSims = False
                End If
                If Me.chkBalance.Checked Then
                    .boolBalance = True
                    .dblBalanceFrom = CInt(Me.txtBalanceFrom.Text)
                    .dblBalanceTo = CInt(Me.txtBalanceTo.Text)
                Else
                    .boolBalance = False
                End If
                If Me.chkDuration.Checked Then
                    .boolDuration = True
                    .dblDurationFrom = CInt(Me.txtDurationFrom.Text)
                    .dblDurationTo = CInt(Me.txtDurationTo.Text)
                Else
                    .boolDuration = False
                End If
                If Me.chkACD.Checked Then
                    .boolACD = True
                    .dblACDFrom = CInt(Me.txtACDFrom.Text)
                    .dblACDTo = CInt(Me.txtACDTo.Text)
                Else
                    .boolACD = False
                End If
                If Me.chkASR.Checked Then
                    .boolASR = True
                    .dblASRFrom = CInt(Me.txtASRFrom.Text)
                    .dblASRTo = CInt(Me.txtASRTo.Text)
                Else
                    .boolASR = False
                End If
                If Me.chkDate.Checked Then
                    .boolDate = True
                    .dDateFrom = Me.dtpFromDate.Value
                    .dDateTo = Me.dtpToDate.Value
                Else
                    .boolDate = False
                End If
                If Me.chkDifference.Checked Then
                    .boolDifference = True
                    .dblDifferenceFrom = CInt(Me.txtDifferenceFrom.Text)
                    .dblDifferenceTo = CInt(Me.txtDifferenceTo.Text)
                Else
                    .boolDifference = False
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

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

            Try
                Me.cmbHumanBehaiviour.DataSource = Nothing
                Me.cmbHumanBehaiviour.Items.Add(New Obj("Send International Calls", Enumerators.Humanbehaviour.SendInternationalCalls))
                Me.cmbHumanBehaiviour.Items.Add(New Obj("Send Local Calls", Enumerators.Humanbehaviour.SendLocalCalls))
                Me.cmbHumanBehaiviour.Items.Add(New Obj("Recieve International Calls", Enumerators.Humanbehaviour.RecieveInternationalCalls))
                Me.cmbHumanBehaiviour.Items.Add(New Obj("Recieve Local Calls", Enumerators.Humanbehaviour.RecieveLocalCalls))
                Me.cmbHumanBehaiviour.Items.Add(New Obj("None", Enumerators.Humanbehaviour.None))

                Me.cmbHumanBehaiviour.ValueMember = "Value"
                Me.cmbHumanBehaiviour.DisplayMember = "Name"
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
            Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
                Me.cmbOperators.DataSource = dsOperators.Tables(0)
                Me.cmbOperators.DisplayMember = "Operator"
                Me.cmbOperators.ValueMember = "ID"
            End If

            Dim ds As DataSet
            ds = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))
            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                ds.Tables(0).Rows.Add(0, "All")
                Me.cmbTrafficType.DataSource = ds.Tables(0)
                Me.cmbTrafficType.DisplayMember = "Operator"
                Me.cmbTrafficType.ValueMember = "ID"
            End If

            Dim dsOwner As DataSet
            dsOwner = odbaccess.GetLocations()
            If Not dsOwner Is Nothing AndAlso Not dsOwner.Tables.Count = 0 AndAlso Not dsOwner.Tables(0).Rows.Count = 0 Then
                Me.cmbOwner.DataSource = dsOwner.Tables(0)
                Me.cmbOwner.DisplayMember = "Location"
                Me.cmbOwner.ValueMember = "ID"
            End If

        End If
    End Sub

    Private Sub chkCountry_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCountry.CheckedChanged
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub

    Private Sub chkHumanBehaiviour_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHumanBehaiviour.CheckedChanged
        Me.cmbHumanBehaiviour.Enabled = chkHumanBehaiviour.Checked
    End Sub

    Private Sub chkOperator_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOperator.CheckedChanged
        Me.cmbOperators.Enabled = Me.chkOperator.Checked
    End Sub

    Private Sub chkOwner_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOwner.CheckedChanged
        Me.cmbOwner.Enabled = Me.chkOwner.Checked
    End Sub

    Private Sub chkDevice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDevice.CheckedChanged
        Me.cmbDevices.Enabled = Me.chkDevice.Checked
    End Sub

    Private Sub chkSlot_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSlot.CheckedChanged
        Me.cmbSlot.Enabled = Me.chkSlot.Checked
    End Sub

    Private Sub chkTrafficType_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTrafficType.CheckedChanged
        Me.cmbTrafficType.Enabled = chkTrafficType.Checked
    End Sub

    Private Sub chkTotalSims_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTotalSims.CheckedChanged
        Me.txtTotalSimsFrom.Enabled = Me.chkTotalSims.Checked
        Me.txtTotalSimsTo.Enabled = Me.chkTotalSims.Checked
    End Sub

    Private Sub chkDifference_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDifference.CheckedChanged
        Me.txtDifferenceFrom.Enabled = Me.chkDifference.Checked
        Me.txtDifferenceTo.Enabled = Me.chkDifference.Checked
    End Sub

    Private Sub chkBalance_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBalance.CheckedChanged
        Me.txtBalanceFrom.Enabled = Me.chkBalance.Checked
        Me.txtBalanceTo.Enabled = Me.chkBalance.Checked
    End Sub

    Private Sub chkDuration_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDuration.CheckedChanged
        Me.txtDurationFrom.Enabled = Me.chkDuration.Checked
        Me.txtDurationTo.Enabled = Me.chkDuration.Checked
    End Sub

    Private Sub chkACD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkACD.CheckedChanged
        Me.txtACDFrom.Enabled = Me.chkACD.Checked
        Me.txtACDTo.Enabled = Me.chkACD.Checked
    End Sub

    Private Sub chkASR_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkASR.CheckedChanged
        Me.txtASRFrom.Enabled = Me.chkASR.Checked
        Me.txtASRTo.Enabled = Me.chkASR.Checked
    End Sub

    Private Sub chkDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpFromDate.Enabled = Me.chkDate.Checked
        Me.dtpToDate.Enabled = Me.chkDate.Checked
    End Sub

    Private Sub Numeric_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtACDFrom.KeyPress, txtACDTo.KeyPress, txtASRFrom.KeyPress, txtASRTo.KeyPress, txtBalanceFrom.KeyPress, txtBalanceTo.KeyPress, txtDurationFrom.KeyPress, txtDurationTo.KeyPress, txtTotalSimsFrom.KeyPress, txtTotalSimsTo.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDifferenceFrom_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDifferenceFrom.KeyPress, txtDifferenceFrom.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If
    End Sub


End Class
