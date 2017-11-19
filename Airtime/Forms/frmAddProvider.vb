Public Class frmAddProvider

    Public enumEditAdd As New Enumerators.EditAdd
    Public lProviderID As Integer
    Public boolSaved As Boolean
    Dim dgRow As DataGridViewRow
    Dim strLocationIDs As New System.Text.StringBuilder
    Public strLocations As New System.Text.StringBuilder
    Dim dsLocations1, dsProvidersLocations As DataSet

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal dgRow As DataGridViewRow = Nothing, Optional ByVal dsProvidersLocations As DataSet = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.dgRow = dgRow
        Me.dsProvidersLocations = dsProvidersLocations
        Me.enumEditAdd = enumEditAdd

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillDs()
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Provider"
            SetControls()
        End If
        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If Me.txtName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtName, "Please insert the provider name.")
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


            GetProviderLocations()

            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.insertProvider(Me.txtName.Text, CInt(Me.cmbCountries.SelectedValue), strLocationIDs.ToString, Me.txtWaivedDeductible.Text)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditProvider(lProviderID, Me.txtName.Text, CInt(Me.cmbCountries.SelectedValue), strLocationIDs.ToString, Me.txtWaivedDeductible.Text)
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
        Me.txtWaivedDeductible.Text = 0
    End Sub

    Public Sub SetControls()
        Me.txtName.Text = dgRow.Cells(2).Value.ToString
        Me.cmbCountries.SelectedValue = CInt(dgRow.Cells(4).Value)
        Me.txtWaivedDeductible.Text = dgRow.Cells(6).Value.ToString
        lProviderID = CInt(dgRow.Cells(0).Value)

        If Not dsProvidersLocations Is Nothing AndAlso Not dsProvidersLocations.Tables.Count < 2 Then
            For Each dr As DataRow In dsProvidersLocations.Tables(1).Rows
                For i As Integer = 0 To Me.CheckedListBox1.Items.Count - 1
                    If CInt(dr.Item("fk_Provider")) = lProviderID And Me.CheckedListBox1.Items(i).ToString = dr.Item("Location").ToString Then
                        CheckedListBox1.SetItemChecked(i, True)
                        Exit For
                    End If
                Next
            Next
        End If
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

            Dim dr As DataRow
            dsLocations1 = odbaccess.GetLocations()
            If Not dsLocations1 Is Nothing AndAlso Not dsLocations1.Tables.Count = 0 Then
                For Each dr In dsLocations1.Tables(0).Rows
                    Me.CheckedListBox1.Items.Add(dr.Item("Location"), False)
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetProviderLocations()
        Try
            Dim dr As DataRow
            For Each item In Me.CheckedListBox1.CheckedItems
                For Each dr In DsLocations1.Tables(0).Rows
                    If item.ToString = dr.Item("Location").ToString Then
                        strLocationIDs.Append(dr.Item("id"))
                        strLocationIDs.Append(",")

                        strLocations.Append(dr.Item("Location"))
                        strLocations.Append(",")
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub txtWaivedDeductible_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWaivedDeductible.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
End Class