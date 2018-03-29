Public Class frmShiftEndUsers_Devices

    Public enumEditAdd As New Enumerators.EditAdd
    Public boolSaved As Boolean
    Dim oShift As New Shift
    Dim lUserID As Integer
    Dim strDevicesIDs As System.Text.StringBuilder
    Dim strDevices As New System.Text.StringBuilder
    'Dim dsDevices As DataSet
    Dim oDevice As Device

    Private Sub frmShiftEndUsers_Devices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsShifts.shifts' table. You can move, or remove it, as needed.
        Me.ShiftsTableAdapter.Fill(Me.DsShifts.shifts)

        FillData()


        boolSaved = True

        Me.cmbShifts.SelectedIndex = -1
    End Sub

    Public Sub FillData()
        Me.cmbShifts.DataSource = Me.DsShifts.shifts
        Me.cmbShifts.DisplayMember = "Shift"
        Me.cmbShifts.ValueMember = "id"

        Dim dr As DataRow
        ' dsDevices = odbaccess.GetDevices(0)
        If Not gdsDevices Is Nothing AndAlso Not gdsDevices.Tables.Count = 0 Then
            For Each dr In gdsDevices.Tables(0).Rows
                Me.CheckedListBox1.Items.Add(dr.Item("device").ToString, False)
            Next
        End If
    End Sub


    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        For Each ShiftUser As ShiftUser In oShift.ocolSiftUsers
            If ShiftUser.UserID = lUserID Then
                ShiftUser.ocolDevice.Clear()
                strDevices = New System.Text.StringBuilder
                For Each item In Me.CheckedListBox1.CheckedItems
                    strDevices.Append(item.ToString + ", ")
                    For Each dr As DataRow In gdsDevices.Tables(0).Rows
                        If dr.Item("Device").ToString = item.ToString Then
                            oDevice = New Device
                            oDevice.DeviceID = CInt(dr.Item("id"))
                            oDevice.Device = dr.Item("Device").ToString
                            ShiftUser.ocolDevice.Add(oDevice)
                            Exit For
                        End If
                    Next
                Next
                If Not strDevices.Length = 0 Then
                    Me.ListView1.SelectedItems(0).SubItems(2).Text = strDevices.ToString.Remove(strDevices.Length - 2)
                Else
                    Me.ListView1.SelectedItems(0).SubItems(2).Text = ""
                End If

            End If
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Dim strUserName As String
            lUserID = CInt(Me.ListView1.SelectedItems(0).SubItems(1).Text)
            strUserName = Me.ListView1.SelectedItems(0).SubItems(0).Text
            Me.Label2.Text = strUserName + " Devices:"

            For i As Integer = 0 To Me.CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next

            For Each ShiftUser As ShiftUser In oShift.ocolSiftUsers
                If ShiftUser.UserID = lUserID Then
                    For Each odevice As Device In ShiftUser.ocolDevice
                        For i As Integer = 0 To Me.CheckedListBox1.Items.Count - 1
                            If Me.CheckedListBox1.Items(i).ToString = odevice.Device Then
                                CheckedListBox1.SetItemChecked(i, True)
                            End If
                        Next
                    Next
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function checkValidation() As Boolean
        Dim boolError As Boolean = True
        If Not Me.cmbShifts.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbShifts, "")
        Else
            ErrorProvider1.SetError(cmbShifts, "Please choose shift from the list.")
            boolError = False
        End If

        If Not Me.DateTimePicker1.Value < Now().Date Then
            ErrorProvider1.SetError(DateTimePicker1, "")
        Else
            ErrorProvider1.SetError(DateTimePicker1, "You cannot add End User to an old date.")
            boolError = False
        End If
        Return boolError
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If Not checkValidation() Then
        '    Exit Sub
        'End If
        For Each oshiftuser As ShiftUser In oShift.ocolSiftUsers
            If oshiftuser.ocolDevice.Count = 0 Then
                ErrorProvider1.SetIconAlignment(ListView1, System.Windows.Forms.ErrorIconAlignment.TopRight)
                ErrorProvider1.SetError(ListView1, "Please add devices to all End Users.")
                Exit Sub
            Else
                ErrorProvider1.SetError(ListView1, "")
            End If
        Next
        Try
            Me.btnSave.Enabled = False
            '   1- will save each user's Devices seperately
            For Each oshiftuser As ShiftUser In oShift.ocolSiftUsers
                strDevicesIDs = New System.Text.StringBuilder
                For Each oDevice As Device In oshiftuser.ocolDevice
                    strDevicesIDs.Append(oDevice.DeviceID.ToString + ",")
                Next
                odbaccess.SaveShiftUsersDevices(strDevicesIDs.ToString, oShift.ShiftID, oshiftuser.UserID)
            Next
            MsgBox("Users saved successfully.")
            Me.btnSave.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        If Not checkValidation() Then
            Me.btnSave.Enabled = False
            ErrorProvider1.SetError(btnSave, "Cannot change old shift's data")
        End If
        Me.oShift = Nothing
        Me.oShift = odbaccess.GetShiftEndusers_Devices(Me.DateTimePicker1.Value, CInt(Me.cmbShifts.SelectedValue))
        ResetData()

        'Fill listview with user's devices
        If Not oShift Is Nothing Then
            For Each ShiftUser As ShiftUser In oShift.ocolSiftUsers
                Dim item As New ListViewItem
                item.Text = ShiftUser.Username
                item.SubItems.Add(ShiftUser.UserID.ToString)
                strDevices = New System.Text.StringBuilder
                For Each Device As Device In ShiftUser.ocolDevice
                    strDevices.Append(Device.Device + ", ")
                Next
                If Not strDevices.Length = 0 Then
                    item.SubItems.Add(strDevices.ToString.Remove(strDevices.Length - 2))
                Else
                    item.SubItems.Add("")
                End If
                Me.ListView1.Items.Add(item)
            Next
        End If

    End Sub

    Public Sub ResetData()
        Me.ListView1.Items.Clear()

        For i As Integer = 0 To Me.CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
    End Sub
End Class