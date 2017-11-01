Public Class frmAddDevice

    Public enumEditAdd As New Enumerators.EditAdd
    Public lDeviceID As Integer
    Public boolSaved As Boolean
    Dim dgRow As DataGridViewRow

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal dgRow As DataGridViewRow = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.dgRow = dgRow

        Me.enumEditAdd = enumEditAdd

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsLocations.Locations' table. You can move, or remove it, as needed.
        Me.LocationsTableAdapter.Fill(Me.DsLocations.Locations)

        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Device"
            SetControls()
        End If
        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If Me.txtName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtName, "Please insert the Device name.")
                Exit Sub
            Else
                ErrorProvider1.SetError(txtName, "")
            End If

            If Me.cmbLocation.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbLocation, "Please select Location from the list.")
                Exit Sub
            Else
                ErrorProvider1.SetError(cmbLocation, "")
            End If

            If Me.txtPrefix.Text.Length = 0 Then
                ErrorProvider1.SetError(txtPrefix, "Please insert a valid value for Prefix field.")
                Exit Sub
            Else
                ErrorProvider1.SetError(txtPrefix, "")
            End If

            If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                lDeviceID = CInt(dgRow.Cells(0).Value)
            End If


            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.insertDevice(Me.txtName.Text, CInt(Me.cmbLocation.SelectedValue), txtPrefix.Text)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditDevice(lDeviceID, Me.txtName.Text, CInt(Me.cmbLocation.SelectedValue), txtPrefix.Text)
            End If
            If boolError Then
                MsgBox("Operation done successfully.", , "Airtime System")
                If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                    Me.Close()
                Else
                    Me.ResetForm()
                End If
            Else
                MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtName.Text = ""
        txtPrefix.Text = ""
    End Sub

    Public Sub SetControls()
        Me.txtName.Text = dgRow.Cells(2).Value.ToString
        Me.cmbLocation.SelectedValue = CInt(dgRow.Cells(4).Value)
        Me.txtPrefix.Text = dgRow.Cells(5).Value.ToString
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
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


End Class