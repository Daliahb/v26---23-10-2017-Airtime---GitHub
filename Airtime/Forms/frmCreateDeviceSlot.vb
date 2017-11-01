Public Class frmCreateDeviceSlot

    Public lShiftID, lSlotID, intNoOfSims As Integer
    Public lOperatorID, lDeviceID As Integer
    Public boolSaved, boolError, isLoaded As Boolean
    Public strHumanBehaiviour As String
    Public lDeviceSlotID As Long

    Public Sub New(ByVal strOperator As String, ByVal strDevice As String, lOperatorID As Integer, lDeviceID As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        Me.lblDevice.Text = strDevice
        Me.lblOperator.Text = strOperator
        Me.lDeviceID = lDeviceID
        Me.lOperatorID = lOperatorID
        isLoaded = True
    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsSlots1.DataTable1' table. You can move, or remove it, as needed.
        Me.DataTable1TableAdapter1.Fill(Me.DsSlots1.DataTable1)
        'TODO: This line of code loads data into the 'DsShifts.shifts' table. You can move, or remove it, as needed.
        Me.ShiftsTableAdapter.Fill(Me.DsShifts.shifts)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Try
            If validation() Then
                fillObject()
                intResult = odbaccess.CreateSlot(lDeviceID, lOperatorID, lSlotID, lShiftID, intNoOfSims, strHumanBehaiviour, Me.txtNote.Text, lDeviceSlotID)

                Select Case intResult
                    Case -1
                        MsgBox("The same slot is already created On this device and still on Hold. This slot cannot be created!", MsgBoxStyle.Critical)
                    Case 0
                        MsgBox("An error occured!")
                    Case 1
                        MsgBox("Operation done successfully.", , "Airtime System")
                        boolSaved = True
                        Me.Close()
                    Case 2
                        MsgBox("The device is already have 4 slots on hold, this slot cannot be created!", MsgBoxStyle.Exclamation)
                End Select
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Function validation() As Boolean
        boolError = True
        Try
            If Me.cmbSlots.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbSlots, "Please select Slot from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbSlots, "")
            End If

            If Me.cmbShifts.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbShifts, "Please select Shift from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbShifts, "")
            End If

            If Me.txtNoOfSims.Text.Length = 0 Then
                ErrorProvider1.SetError(txtNoOfSims, "Please insert a valid value in Number of sims field.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtNoOfSims, "")
            End If

            If Me.CheckedListBox1.CheckedItems.Count = 0 Then
                ErrorProvider1.SetError(CheckedListBox1, "Please select at least one option from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(CheckedListBox1, "")
            End If

            If Me.txtNoOfSims.Text.Length > 0 AndAlso CInt(Me.txtNoOfSims.Text) > 32 Then
                ErrorProvider1.SetError(txtNoOfSims, "Number of Sims cannot be exceed 32 sims when creating a slot.")
                boolError = False
            End If
            Return boolError
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
            Return Nothing
        End Try

    End Function


    Public Sub FillObject()
        lShiftID = CInt(Me.cmbShifts.SelectedValue)
        lSlotID = CInt(Me.cmbSlots.SelectedValue)
        strHumanBehaiviour = ""

        For Each item As Object In Me.CheckedListBox1.CheckedItems
            strHumanBehaiviour += CheckedListBox1.Items.IndexOf(item).ToString() & "|"
            '     item.index()
        Next
        intNoOfSims = CInt(Me.txtNoOfSims.Text)
    End Sub

    'Public Sub SetControls()
    '    Me.cmbGetItBy.SelectedValue = lGetCardFrom
    '    Me.cmbCategory.SelectedValue = lCategoryID
    '    Me.cmbOperators.SelectedValue = lOperatorID
    '    Me.cmbProviders.SelectedValue = lProviderID
    '    Me.cmbCountries.SelectedValue = lCountryID
    'End Sub

    Private Sub txtNoOfSims_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfSims.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class