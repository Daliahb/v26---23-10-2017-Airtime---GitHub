Public Class frmAddProviderPayment

    Public enumEditAdd As New Enumerators.EditAdd
    Public lPaymentID As Integer
    Public boolSaved As Boolean
    Dim isLoaded As Boolean
    Dim dRow As DataGridViewRow

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal dRow As DataGridViewRow = Nothing) 'ByVal lPaymentID As Integer = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.dRow = dRow
        '  Me.lPaymentID = lPaymentID

        Me.enumEditAdd = enumEditAdd
    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDs()
        isLoaded = True
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Transfer"

            ' oExpense = odbaccess.getExpense(lPaymentID)
            SetControls()
        End If

        boolSaved = False

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If CheckValidation() Then

                'FillObject()
                If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                    boolError = odbaccess.InsertPayment(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbProviders.SelectedValue), CDec(Me.txtTotalAmount.Text), Me.dtpFromDate.Value)
                ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                    boolError = odbaccess.EditPayment(Me.lPaymentID, CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbProviders.SelectedValue), CDec(Me.txtTotalAmount.Text), Me.dtpFromDate.Value)
                End If
                If boolError Then
                    boolSaved = True
                    MsgBox("Operation done successfully.", , "Airtime System")
                    If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                        Me.Close()
                    Else
                        Me.ResetForm()
                    End If
                Else
                    boolSaved = False
                    MsgBox("Error occured!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtTotalAmount.Text = ""
        If Not cmbCountries.Items.Count = 0 Then
            Me.cmbCountries.SelectedIndex = 0
        End If
        Me.dtpFromDate.Value = Now()
    End Sub

    Public Sub SetControls()
        If Not dRow Is Nothing Then
            With dRow
                Me.lPaymentID = CInt(.Cells(0).Value)
                Me.cmbCountries.SelectedValue = -1
                Me.cmbCountries.SelectedValue = .Cells(1).Value
                Me.cmbProviders.SelectedValue = .Cells(2).Value
                Me.txtTotalAmount.Text = .Cells(6).Value.ToString
                Me.dtpFromDate.Value = CDate(.Cells(7).Value)
            End With
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSave_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No
                    boolSaved = False
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
            '     Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            'Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            'If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
            '    Me.cmbProviders.DataSource = dsProvider.Tables(0)
            '    Me.cmbProviders.DisplayMember = "Provider"
            '    Me.cmbProviders.ValueMember = "ID"
            'End If
            If Not gdsProviders Is Nothing AndAlso Not gdsProviders.Tables.Count = 0 Then
                Dim dvProvider As New DataView(gdsProviders.Tables(0))
                dvProvider.RowFilter = "FK_Country = " & CInt(Me.cmbCountries.SelectedValue).ToString
                Me.cmbProviders.DataSource = dvProvider
                Me.cmbProviders.ValueMember = "Id"
                Me.cmbProviders.DisplayMember = "Provider"
            End If
        End If

    End Sub


    Public Function CheckValidation() As Boolean
        Dim boolError As Boolean = True

        If Me.cmbCountries.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbCountries, "Please select Country from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbCountries, "")
        End If

        If Me.cmbProviders.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Me.cmbProviders, "Please select Provider from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.cmbProviders, "")
        End If

        If Me.txtTotalAmount.Text.Length = 0 Then
            ErrorProvider1.SetError(Me.txtTotalAmount, "Please insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.txtTotalAmount, "")
        End If

        Return boolError
    End Function

    Private Sub txtCardValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalAmount.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class