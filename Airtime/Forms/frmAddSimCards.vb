Public Class frmAddSimCards

    Public enumEditAdd As New Enumerators.EditAdd
    Public lSimCardID As Long
    Public boolSaved As Boolean
    Dim dgRow As DataGridViewRow
    Dim isLoaded As Boolean
    Dim oSimcardOrder As New SimcardsOrder

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal oSimcardOrder As SimcardsOrder = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        If enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.oSimcardOrder = oSimcardOrder
        End If


        Me.enumEditAdd = enumEditAdd

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gUser.type = Enumerators.UsersTypes.Admin OrElse gUser.type = Enumerators.UsersTypes.Audit Then
            Me.txtCardValue.Enabled = True
        End If
        FillDs()
        isLoaded = True
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Sim Cards Order"
            SetControls()
        End If
        boolSaved = False
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If CheckValidation() Then
                FillObject()
                If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                    boolError = odbaccess.InsertSimCardOrder(oSimcardOrder)
                ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                    boolError = odbaccess.EditSimCardOrder(oSimcardOrder)
                End If
                If boolError Then
                    MsgBox("Operation done successfully.", , "Airtime System")
                    boolSaved = True
                    If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                        Me.Close()
                    Else
                        Me.ResetForm()
                    End If
                Else
                    MsgBox("Error occured!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtCardValue.Text = "0.0"
        Me.txtNoOfCards.Text = "0"
        Me.dtpFromDate.Value = Now()
        Me.cmbCountries.SelectedIndex = 0
    End Sub

    Public Sub SetControls()
        If Not Me.oSimcardOrder Is Nothing Then
            With oSimcardOrder
                Me.cmbCountries.SelectedValue = -1
                Me.cmbCountries.SelectedValue = .CountryID
                Me.cmbProviders.SelectedValue = .ProviderID
                Me.cmbSimCardTypes.SelectedValue = .SimCardTypeID
                Me.dtpFromDate.Value = .SimcardOrderDate
                Me.txtNoOfCards.Text = .NoOfCards.ToString
                Me.txtCardValue.Text = .CardValue.ToString
                Me.txtTotalAmount.Text = .TotalAmount.ToString
            End With
        End If
    End Sub

    Public Function CheckValidation() As Boolean
        Dim boolError As Boolean = True

        If Me.cmbCountries.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbCountries, "Please select country from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbCountries, "")
        End If

        If Me.cmbProviders.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbProviders, "Please select provider from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbProviders, "")
        End If

        If Me.cmbSimCardTypes.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbSimCardTypes, "Please select sim cards type from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbSimCardTypes, "")
        End If

        If Me.txtNoOfCards.Text.Length = 0 OrElse (CInt(Me.txtNoOfCards.Text) = 0) Then
            ErrorProvider1.SetError(Me.txtNoOfCards, "Please insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.txtNoOfCards, "")
        End If

        If Me.txtCardValue.Text.Length = 0 Then
            ErrorProvider1.SetError(Me.txtCardValue, "Please insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(Me.txtCardValue, "")
        End If

        Return boolError
    End Function

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

    Public Sub FillObject()
        With Me.oSimcardOrder
            .CountryID = CInt(Me.cmbCountries.SelectedValue)
            .ProviderID = CInt(Me.cmbProviders.SelectedValue)
            .SimcardOrderDate = Me.dtpFromDate.Value
            .NoOfCards = CInt(Me.txtNoOfCards.Text)
            .CardValue = CDbl(Me.txtCardValue.Text)
            .TotalAmount = CDbl(Me.txtTotalAmount.Text)
            .SimCardTypeID = CInt(Me.cmbSimCardTypes.SelectedValue)
        End With
    End Sub


    Private Sub cmbCountries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedIndexChanged
        If isLoaded Then
            Me.cmbProviders.DataSource = Nothing
            Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
                Me.cmbProviders.DataSource = dsProvider.Tables(0)
                Me.cmbProviders.DisplayMember = "Provider"
                Me.cmbProviders.ValueMember = "ID"
            End If

            Me.cmbSimCardTypes.DataSource = Nothing
            Dim dsSimCardTypes As DataSet = odbaccess.GetSimCardsTypes(CInt(Me.cmbCountries.SelectedValue))
            If Not dsSimCardTypes Is Nothing AndAlso Not dsSimCardTypes.Tables.Count = 0 AndAlso Not dsSimCardTypes.Tables(0).Rows.Count = 0 Then
                Me.cmbSimCardTypes.DataSource = dsSimCardTypes.Tables(0)
                Me.cmbSimCardTypes.DisplayMember = "CardType"
                Me.cmbSimCardTypes.ValueMember = "ID"
            End If
        End If

    End Sub

    Private Sub txtExpense_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfCards.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCardValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCardValue.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNoOfCards_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoOfCards.TextChanged
        If Not Me.txtNoOfCards.Text.Length = 0 AndAlso Not Me.txtCardValue.Text.Length = 0 Then
            Me.txtTotalAmount.Text = Math.Round((CInt(Me.txtNoOfCards.Text) * CDec(Me.txtCardValue.Text)), 3).ToString
        Else
            Me.txtTotalAmount.Text = "0.0"
        End If
    End Sub

    Private Sub txtCardValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCardValue.TextChanged
        If Not Me.txtNoOfCards.Text.Length = 0 AndAlso Not Me.txtCardValue.Text.Length = 0 Then
            Me.txtTotalAmount.Text = Math.Round((CInt(Me.txtNoOfCards.Text) * CDec(Me.txtCardValue.Text)), 3).ToString
        Else
            Me.txtTotalAmount.Text = "0.0"
        End If
    End Sub
End Class