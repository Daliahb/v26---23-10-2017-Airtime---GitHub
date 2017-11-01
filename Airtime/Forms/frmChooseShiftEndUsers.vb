Public Class frmChooseShiftEndUsers

    Public enumEditAdd As New Enumerators.EditAdd
    Public boolSaved As Boolean = False
    Dim dsOperator As New dsOperators
    Dim oShift As New Shift
    Dim UserID, lOperatorID, lShiftID As Integer
    Dim strOperationsLimits, strUserIDs As System.Text.StringBuilder

    Private Sub frmChooseShiftEndUsers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSave_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No

                Case MsgBoxResult.Cancel
                    Return
            End Select
        End If
    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsShifts.shifts' table. You can move, or remove it, as needed.
        Me.ShiftsTableAdapter.Fill(Me.DsShifts.shifts)

        FillData()
        ResetData()
      
        boolSaved = True
        Me.cmbUsers.SelectedIndex = -1
        Me.cmbShifts.SelectedIndex = -1

    End Sub


    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click
        Try
            boolSaved = False
            If enumEditAdd = Enumerators.EditAdd.Add Then
                btnAddUser.Enabled = False
                Dim item As New ListViewItem
                item.Text = Me.cmbUsers.Text
                item.SubItems.Add(Me.cmbUsers.SelectedValue)

                Me.ListView1.Items.Add(item)

                Dim oShiftUser As New ShiftUser
                oShiftUser.UserID = Me.UserID
                oShiftUser.ocolOperators = GetOperatorsData()
                Me.oShift.ocolSiftUsers.Add(oShiftUser)

            Else
                For Each oShiftUser As ShiftUser In Me.oShift.ocolSiftUsers
                    If oShiftUser.UserID = Me.UserID Then
                        oShiftUser.ocolOperators = Nothing
                        oShiftUser.ocolOperators = GetOperatorsData()
                    End If
                Next
            End If
            MsgBox("End User saved successfully.")
            '  ResetData()
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSave_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No
                    Me.Close()
                Case MsgBoxResult.Cancel
                    Return
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Public Sub FillData()
        Dim colUsers As ColUser = odbaccess.GetUsers(2)
        If Not colUsers Is Nothing Then
            Me.cmbUsers.DataSource = colUsers
            Me.cmbUsers.DisplayMember = "Username"
            Me.cmbUsers.ValueMember = "ID"
        End If


        Dim OperatorsTableAdapters As New dsOperatorsTableAdapters.OperatorsTableAdapter
        OperatorsTableAdapters.Fill(Me.dsOperator.Operators)

        Me.cmbShifts.DataSource = Me.DsShifts.shifts
        Me.cmbShifts.DisplayMember = "Shift"
        Me.cmbShifts.ValueMember = "id"

        FillDatagrid()
    End Sub

    Public Sub FillDatagrid()
        Dim intRowIndex As Integer
        If Not dsOperator Is Nothing AndAlso Not dsOperator.Tables.Count = 0 AndAlso Not dsOperator.Tables(0).Rows.Count = 0 Then
            For Each dr As DataRow In dsOperator.Tables(0).Rows
                Try
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells(0).Value = dr.Item("id")
                        .Cells(1).Value = dr.Item("Country")
                        .Cells(2).Value = dr.Item("Operator")
                        .Cells(3).Value = 0
                        .Cells(3).Style.BackColor = Color.LightBlue
                    End With
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        ' Me.ListView1.Items.Add(Me.cmbUsers.Text)

        If Not isUserAlreadyUsed() Then
            btnAddUser.Enabled = True
            Me.btnAddUser.Text = "Add User"
            Me.UserID = CInt(Me.cmbUsers.SelectedValue)
            Me.lblUsername.Text = Me.cmbUsers.Text
            Me.Panel2.Enabled = True
            'clear datagrdi data
            For Each dr As DataGridViewRow In Me.DataGridView1.Rows
                dr.Cells(3).Value = 0
            Next
            ErrorProvider1.SetError(cmbUsers, "")
            enumEditAdd = Enumerators.EditAdd.Add
        Else
            ErrorProvider1.SetError(cmbUsers, "User is already added.")
            Exit Sub
        End If

    End Sub

    'Private Sub ListView1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseHover
    '    ListView1.ShowItemToolTips = True
    '    ' ListView1.Items(0).ToolTipText = ListView1.Items(0).SubItems(0).Text
    'End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Me.btnAddUser.Text = "Edit User"
            Me.btnAddUser.Enabled = True
            enumEditAdd = Enumerators.EditAdd.Edit
            Me.lblUsername.Text = Me.ListView1.SelectedItems(0).SubItems(0).Text
            Me.UserID = CInt(Me.ListView1.SelectedItems(0).SubItems(1).Text)
            Me.Panel2.Enabled = True
            For Each shiftuser As ShiftUser In Me.oShift.ocolSiftUsers
                If shiftuser.UserID = CInt(Me.ListView1.SelectedItems(0).SubItems(1).Text) Then
                    ' For Each dr As DataGridViewRow In Me.DataGridView1.Rows
                    For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                        Me.DataGridView1.Rows(i).Cells(3).Value = CType(shiftuser.ocolOperators(i), Operators).UserLimit
                        ' Next
                    Next
                    Exit For
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Function GetOperatorsData() As ColOperators
        Dim ocolOperators As New ColOperators
        Dim oOperator As Operators
        Try

            For Each dr As DataGridViewRow In Me.DataGridView1.Rows
                oOperator = New Operators
                With oOperator
                    .OperatorID = CInt(dr.Cells(0).Value)
                    .Country = dr.Cells(1).Value.ToString
                    .OperatorName = dr.Cells(2).Value.ToString
                    .UserLimit = CInt(dr.Cells(3).Value)
                End With
                ocolOperators.Add(oOperator)
            Next
            Return ocolOperators
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function isUserAlreadyUsed() As Boolean
        For i As Integer = 0 To Me.ListView1.Items.Count - 1
            If Me.ListView1.Items(i).SubItems(1).Text = Me.cmbUsers.SelectedValue.ToString Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub RemoveUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveUserToolStripMenuItem.Click
        If MsgBox("Are you sure you want to remove this User from the list?", vbYesNo) = MsgBoxResult.Yes Then
            If Not Me.ListView1.SelectedItems.Count = 0 Then
                For Each shiftuser As ShiftUser In Me.oShift.ocolSiftUsers
                    If shiftuser.UserID = CInt(Me.ListView1.SelectedItems(0).SubItems(1).Text) Then
                        oShift.ocolSiftUsers.remove(shiftuser)
                        Me.ListView1.Items.RemoveAt(Me.ListView1.SelectedItems(0).Index)
                        ResetData()
                        Exit For
                    End If
                Next

            End If
        End If

    End Sub

    Public Sub ResetData()
        Me.lblUsername.Text = ""
        Me.Panel2.Enabled = False
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            dr.Cells(3).Value = 0
        Next
    End Sub


    Public Function checkValidation() As Boolean
        Dim boolError As Boolean = True
        If Not Me.cmbShifts.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbShifts, "")
        Else
            ErrorProvider1.SetError(cmbShifts, "Please choose shift from the list.")
            boolError = False
        End If
        If Not Me.oShift.ocolSiftUsers.Count = 0 Then
            ErrorProvider1.SetError(cmbUsers, "")
        Else
            ErrorProvider1.SetError(cmbUsers, "You should add at least one End User.")
            boolError = False
        End If
        'If Not Me.DateTimePicker1.Value < Now().Date Then
        '    ErrorProvider1.SetError(DateTimePicker1, "")
        'Else
        '    ErrorProvider1.SetError(DateTimePicker1, "You cannot add End User to an old date.")
        '    boolError = False
        'End If
        Return boolError
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not checkValidation() Then
            Exit Sub
        End If

        Try
            Me.btnSave.Enabled = False
            '1- Get shift ID (either select or insert new), + remove all the end users for this shift + insert new End Users
            strUserIDs = New System.Text.StringBuilder
            For Each oshiftuser As ShiftUser In oShift.ocolSiftUsers
                strUserIDs.Append(oshiftuser.UserID.ToString + ",")
            Next
            lShiftID = odbaccess.SaveShiftEndUsers(strUserIDs.ToString, Me.DateTimePicker1.Value, CInt(Me.cmbShifts.SelectedValue))
            If Not lShiftID = -1 Then
                '   2- will save each user's limists seperately
                For Each oshiftuser As ShiftUser In oShift.ocolSiftUsers
                    strOperationsLimits = New System.Text.StringBuilder
                    For Each oper As Operators In oshiftuser.ocolOperators
                        strOperationsLimits.Append(oper.OperatorID.ToString + "-" + oper.UserLimit.ToString + ",")
                    Next
                    odbaccess.SaveShiftUsersOperatorsLimits(strOperationsLimits.ToString, lShiftID, oshiftuser.UserID)
                Next
                boolSaved = True
                MsgBox("Users saved successfully.")

            End If
            Me.btnSave.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click

        If Me.DateTimePicker1.Value < Now().Date Then
            Me.btnSave.Enabled = False
            Me.btnAddUser.Enabled = False
            Me.btnChoose.Enabled = False
            Me.ErrorProvider1.SetError(Me.DateTimePicker1, "You cannot edit an old shift.")
        Else
            Me.btnSave.Enabled = True
            Me.btnAddUser.Enabled = True
            Me.btnChoose.Enabled = True
            Me.ErrorProvider1.SetError(Me.DateTimePicker1, "")
        End If

        Dim strDevices As New System.Text.StringBuilder
        Me.oShift = Nothing
        Me.oShift = odbaccess.GetShiftEndusersFull(Me.DateTimePicker1.Value, CInt(Me.cmbShifts.SelectedValue))
        ResetData()
        Me.ListView1.Items.Clear()
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
                End If
                Me.ListView1.Items.Add(item)
            Next
        End If

    End Sub
End Class