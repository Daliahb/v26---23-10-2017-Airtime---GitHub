Public Class frmAddSimCardType

    Public enumEditAdd As New Enumerators.EditAdd
    Public lSimTypeID As Integer
    Public boolSaved As Boolean
    Dim dgRow As DataGridViewRow

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal dgRow As DataGridViewRow = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.dgRow = dgRow

        Me.enumEditAdd = enumEditAdd

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillDs()
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Sim Card Type"
            SetControls()
        End If
        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If Me.txtName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtName, "Please insert the Sim Card Type name.")
                Exit Sub
            Else
                ErrorProvider1.SetError(txtName, "")
            End If

            If Me.cmbCountries.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbCountries, "Please select country from the list.")
                Exit Sub
            Else
                ErrorProvider1.SetError(cmbCountries, "")
            End If

            If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                lSimTypeID = CInt(dgRow.Cells(0).Value)
            End If


            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.insertSimType(Me.txtName.Text, CInt(Me.cmbCountries.SelectedValue))
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditSimType(lSimTypeID, Me.txtName.Text, CInt(Me.cmbCountries.SelectedValue))
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
    End Sub

    Public Sub SetControls()
        Me.txtName.Text = dgRow.Cells(2).Value.ToString
        Me.cmbCountries.SelectedValue = CInt(dgRow.Cells(4).Value)
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

    Public Sub FillDs()
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

    Private Sub txtLimit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class