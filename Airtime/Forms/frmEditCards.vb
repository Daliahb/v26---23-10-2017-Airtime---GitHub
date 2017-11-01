Public Class frmEditCards

    Public lCountryID, lProviderID, lOperatorID, lCategoryID, lGetCardFrom As Integer
    Public boolSaved, boolError, isLoaded As Boolean
    Public strCardIDs As String

    Public Sub New(ByVal strCountry As String, ByVal strProvider As String, ByVal strOperator As String, ByVal strCategory As String, ByVal strCardsRecource As String, ByVal strCardIDs As String)
        ' This call is required by the designer.
        InitializeComponent()

        FillDs()
        isLoaded = True

        Me.cmbCountries.Text = strCountry
        Me.cmbProviders.Text = strProvider
        Me.cmbOperators.Text = strOperator
        Me.cmbCategory.Text = strCategory
        Me.cmbGetItBy.Text = strCardsRecource





        Me.strCardIDs = strCardIDs

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


       


        boolSaved = True


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim boolError As Boolean
        Try
            If validation() Then
                fillObject()
                boolError = odbaccess.EditCards(lCountryID, lProviderID, lOperatorID, lCategoryID, lGetCardFrom, strCardIDs)

                If boolError Then
                    MsgBox("Operation done successfully.", , "Airtime System")

                    Me.Close()

                Else
                    MsgBox("An error occured!")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Function validation() As Boolean
        boolError = True
        Try
            If Me.cmbCountries.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbCountries, "Please select country from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbCountries, "")
            End If

            If Me.cmbOperators.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbOperators, "Please select operator from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbOperators, "")
            End If

            If Me.cmbProviders.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbProviders, "Please select provider from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbProviders, "")
            End If

            If Me.cmbCategory.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbCategory, "Please select category from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbCategory, "")
            End If

          
            Return boolError
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
            Return Nothing
        End Try

    End Function


    Public Sub FillObject()
        lCountryID = CInt(Me.cmbCountries.SelectedValue)
        lProviderID = CInt(Me.cmbProviders.SelectedValue)
        lOperatorID = CInt(Me.cmbOperators.SelectedValue)
        lCategoryID = CInt(Me.cmbCategory.SelectedValue)
        lGetCardFrom = CInt(Me.cmbGetItBy.SelectedValue)
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

    'Public Sub SetControls()
    '    Me.cmbGetItBy.SelectedValue = lGetCardFrom
    '    Me.cmbCategory.SelectedValue = lCategoryID
    '    Me.cmbOperators.SelectedValue = lOperatorID
    '    Me.cmbProviders.SelectedValue = lProviderID
    '    Me.cmbCountries.SelectedValue = lCountryID
    'End Sub

    Public Sub FillDs()
        Try
            Dim dsCountries As DataSet = odbaccess.GetCountriesDS

            If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
                Me.cmbCountries.DataSource = dsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If

            Dim dsCardsResources As DataSet = odbaccess.GetCardsResources

            If Not dsCardsResources Is Nothing AndAlso Not dsCardsResources.Tables.Count = 0 AndAlso Not dsCardsResources.Tables(0).Rows.Count = 0 Then
                Me.cmbGetItBy.DataSource = dsCardsResources.Tables(0)
                Me.cmbGetItBy.DisplayMember = "How"
                Me.cmbGetItBy.ValueMember = "ID"
            End If

            Dim dsOperators As DataSet = odbaccess.GetOperators(False, 0)
            Me.cmbOperators.DataSource = Nothing
            If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
                Me.cmbOperators.DataSource = dsOperators.Tables(0)
                Me.cmbOperators.DisplayMember = "Operator"
                Me.cmbOperators.ValueMember = "ID"
            End If

            Dim dsProvider As DataSet = odbaccess.GetProviders(False, 0)
            Me.cmbProviders.DataSource = Nothing
            If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
                Me.cmbProviders.DataSource = dsProvider.Tables(0)
                Me.cmbProviders.DisplayMember = "Provider"
                Me.cmbProviders.ValueMember = "ID"
            End If

            Dim dsCategory As DataSet = odbaccess.GetCategories(0, 0)
            Me.cmbCategory.DataSource = Nothing
            If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
                Me.cmbCategory.DataSource = dsCategory.Tables(0)
                Me.cmbCategory.DisplayMember = "Category"
                Me.cmbCategory.ValueMember = "ID"
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbCountries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isLoaded Then
            Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))
            Me.cmbOperators.DataSource = Nothing
            If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
                Me.cmbOperators.DataSource = dsOperators.Tables(0)
                Me.cmbOperators.DisplayMember = "Operator"
                Me.cmbOperators.ValueMember = "ID"
            End If

            Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            Me.cmbProviders.DataSource = Nothing
            If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
                Me.cmbProviders.DataSource = dsProvider.Tables(0)
                Me.cmbProviders.DisplayMember = "Provider"
                Me.cmbProviders.ValueMember = "ID"
            End If


        End If

    End Sub

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedValueChanged
        If isLoaded Then
            Dim dsCategory As DataSet = odbaccess.GetCategories(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbOperators.SelectedValue))
            Me.cmbCategory.DataSource = Nothing
            If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
                Me.cmbCategory.DataSource = dsCategory.Tables(0)
                Me.cmbCategory.DisplayMember = "Category"
                Me.cmbCategory.ValueMember = "ID"
            End If
        End If

    End Sub

End Class