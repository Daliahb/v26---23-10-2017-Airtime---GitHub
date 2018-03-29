Public Class frmAddCategory

    Public enumEditAdd As New Enumerators.EditAdd
    Public lCategoryID As Long
    Public boolSaved As Boolean
    Dim dgRow As DataGridViewRow
    Dim isLoaded As Boolean

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal dgRow As DataGridViewRow = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.dgRow = dgRow

        Me.enumEditAdd = enumEditAdd

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        isLoaded = True
        FillDs()
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Category"
            SetControls()
        End If
        boolSaved = True

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If Me.txtCategory.Text.Length = 0 Then
                ErrorProvider1.SetError(txtCategory, "Please insert the Category name.")
                Exit Sub
            Else
                ErrorProvider1.SetError(txtCategory, "")
            End If

            If Me.cmbCountries.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbCountries, "Please select country from the list.")
                Exit Sub
            Else
                ErrorProvider1.SetError(cmbCountries, "")
            End If

            If Me.cmbOperators.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbOperators, "Please select operator from the list.")
                Exit Sub
            Else
                ErrorProvider1.SetError(cmbOperators, "")
            End If

            If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                lCategoryID = CLng(dgRow.Cells(0).Value)
            End If


            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.insertCategory(Me.txtCategory.Text, Me.cmbCountries.SelectedValue, Me.cmbOperators.SelectedValue)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditCategory(lCategoryID, Me.txtCategory.Text, Me.cmbCountries.SelectedValue, Me.cmbOperators.SelectedValue)
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
        Me.txtCategory.Text = ""

    End Sub

    Public Sub SetControls()
        Me.txtCategory.Text = dgRow.Cells(2).Value.ToString

        Me.cmbCountries.SelectedValue = CInt(dgRow.Cells(6).Value)
        Me.cmbOperators.SelectedValue = CInt(dgRow.Cells(4).Value)
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
            'Dim dsCountries As DataSet = odbaccess.GetCountriesDS
            'If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
            '    Me.cmbCountries.DataSource = dsCountries.Tables(0)
            '    Me.cmbCountries.DisplayMember = "Country"
            '    Me.cmbCountries.ValueMember = "ID"
            'End If

            If Not gdsCountries Is Nothing AndAlso Not gdsCountries.Tables.Count = 0 Then
                Me.cmbCountries.DataSource = gdsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCountries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedIndexChanged
        If isLoaded Then
            Me.cmbOperators.DataSource = Nothing
            'Dim dsOperators As DataSet = odbaccess.GetOperators(True, Me.cmbCountries.SelectedValue)

            'If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
            '    Me.cmbOperators.DataSource = dsOperators.Tables(0)
            '    Me.cmbOperators.DisplayMember = "Operator"
            '    Me.cmbOperators.ValueMember = "ID"
            'End If
            If Not gdsOperators Is Nothing AndAlso Not gdsOperators.Tables.Count = 0 Then
                Dim dv As New DataView(gdsOperators.Tables(0))
                dv.RowFilter = "FK_Country = " & CInt(Me.cmbCountries.SelectedValue).ToString
                Me.cmbOperators.DataSource = dv
                Me.cmbOperators.ValueMember = "Id"
                Me.cmbOperators.DisplayMember = "Operator"
            End If
        End If

    End Sub

    Private Sub txtCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCategory.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class