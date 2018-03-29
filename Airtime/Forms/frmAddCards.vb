Public Class frmAddCards

    Public enumEditAdd As New Enumerators.EditAdd
    Public lCountryID, lProviderID, lOperatorID, lCategoryID, lGetCardFrom As Integer
    Public boolSaved, isLoaded, boolError As Boolean
    Public strCards As New System.Text.StringBuilder
    Dim Sql As New System.Text.StringBuilder
    Public strLastCard As String

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal dgRow As DataGridViewRow = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        Me.enumEditAdd = enumEditAdd

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillDs()
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Category"
            SetControls()
        End If
        boolSaved = True

        isLoaded = True

        If Not cmbCountries.Items.Count = 0 Then
            Me.cmbCountries.SelectedIndex = -1
            Me.cmbCountries.SelectedIndex = 0
        Else
            FillDs()
        End If

        Try
            If gUser.type = Enumerators.UsersTypes.Provider Then
                Me.cmbGetItBy.SelectedValue = 6
                Me.cmbGetItBy.Enabled = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If validation() Then
                Me.btnSave.Enabled = False

                SaveCards()

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

            If Me.DataGridView1.Rows.Count = 1 Then
                If Me.DataGridView1.Rows(0).Cells(1).Value Is Nothing Then
                    ErrorProvider1.SetError(DataGridView1, "Please insert data to the grid.")
                    boolError = False
                Else
                    ErrorProvider1.SetError(DataGridView1, "")
                End If
            End If
            Return boolError
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
            Return Nothing
        End Try

    End Function

    Public Sub ResetForm()
        Me.DataGridView1.Rows.Clear()
        strCards = New System.Text.StringBuilder
    End Sub

    Public Sub FillObject()
        lCountryID = CInt(Me.cmbCountries.SelectedValue)
        lProviderID = CInt(Me.cmbProviders.SelectedValue)
        lOperatorID = CInt(Me.cmbOperators.SelectedValue)
        lCategoryID = CInt(Me.cmbCategory.SelectedValue)
        lGetCardFrom = CInt(Me.cmbGetItBy.SelectedValue)

        'For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
        '    If Not Me.DataGridView1.Rows(i).Cells(1).Value Is Nothing Then
        '        strCards.Append(Me.DataGridView1.Rows(i).Cells(1).Value)
        '        strCards.Append(",")
        '    End If
        'Next
        'For i As Integer = Me.DataGridView1.Rows.Count - 1 To 0 Step -1
        '    If Not Me.DataGridView1.Rows(i).Cells(1).Value Is Nothing AndAlso Not Me.DataGridView1.Rows(i).Cells(1).Value.ToString = "" Then
        '        strLastCard = Me.DataGridView1.Rows(i).Cells(1).Value.ToString
        '        Exit For
        '    End If
        'Next
        Sql = New System.Text.StringBuilder
        Sql.Append("  insert into cards (card_number,fk_Country,fk_Provider,fk_Operator,fk_Category,fk_insertedby,inst_date,fk_GotFrom) values ")
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If Not Me.DataGridView1.Rows(i).Cells(1).Value Is Nothing Then
                Sql.Append("('" & Me.DataGridView1.Rows(i).Cells(1).Value.ToString & "'," & lCountryID & "," & lProviderID & "," & lOperatorID & "," & lCategoryID & "," & gUser.Id & ",'" & Now().ToString("yyyy-MM-dd HH:mm:ss") & "'," & lGetCardFrom & "),")
            End If
        Next
        If Not Sql.Length = 0 Then
            Sql.Remove(Sql.Length - 1, 1)
        End If
    End Sub

    Public Sub SetControls()

    End Sub

    Public Sub SaveCards()

        Dim boolError As Boolean
        FillObject()
        'boolError = odbaccess.InsertCards(lCountryID, lProviderID, lOperatorID, lCategoryID, lGetCardFrom, strCards.ToString, strLastCard)
        boolError = odbaccess.InsertCards(Sql.ToString)
        If boolError Then
            MsgBox("Operation done successfully.", , "Airtime System")
            If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                Me.Close()
            Else
                Me.ResetForm()
            End If
        Else
            MsgBox("Error occured!", , "Airtime System")
        End If
        Me.btnSave.Enabled = True

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

            Dim dsCardsResources As DataSet = odbaccess.GetCardsResources

            If Not dsCardsResources Is Nothing AndAlso Not dsCardsResources.Tables.Count = 0 AndAlso Not dsCardsResources.Tables(0).Rows.Count = 0 Then
                Me.cmbGetItBy.DataSource = dsCardsResources.Tables(0)
                Me.cmbGetItBy.DisplayMember = "How"
                Me.cmbGetItBy.ValueMember = "ID"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub PasteData(ByRef dgv As DataGridView)
        Dim tArr() As String
        Dim arT() As String
        Dim i, ii As Integer
        Dim c, cc, r As Integer

        tArr = Clipboard.GetText().Split(Environment.NewLine)

        c = 1
        For i = 0 To tArr.Length - 1
            arT = tArr(i).Split(vbTab)
            If Not arT(0) Is Nothing Then 'AndAlso Not arT(0).Length < 10 Then
                cc = c
                r = Me.DataGridView1.Rows.Add
                For ii = 0 To arT.Length - 1
                    With dgv.Item(cc, r)
                        .Value = arT(ii).Trim
                    End With
                    cc = cc + 1
                Next

            End If
        Next

    End Sub

    Private Sub KeyPaste(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.V And Keys.ControlKey Then
            Paste()
        End If
    End Sub

    Public Sub Paste()
        PasteData(Me.DataGridView1)
    End Sub

    Private Sub cmbCountries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedIndexChanged
        If isLoaded Then
            'Dim dsOperators As DataSet = odbaccess.GetOperators(True, Me.cmbCountries.SelectedValue)
            'Me.cmbOperators.DataSource = Nothing
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


            'Dim dsProvider As DataSet = odbaccess.GetProviders(True, Me.cmbCountries.SelectedValue)
            'Me.cmbProviders.DataSource = Nothing
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

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedIndexChanged
        If isLoaded Then
            'Dim dsCategory As DataSet = odbaccess.GetCategories(Me.cmbCountries.SelectedValue, Me.cmbOperators.SelectedValue)
            'Me.cmbCategory.DataSource = Nothing
            'If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
            '    Me.cmbCategory.DataSource = dsCategory.Tables(0)
            '    Me.cmbCategory.DisplayMember = "Category"
            '    Me.cmbCategory.ValueMember = "ID"
            'End If
            If Not gdsCategories Is Nothing AndAlso Not gdsCategories.Tables.Count = 0 Then
                Dim dvCategory As New DataView(gdsCategories.Tables(0))
                dvCategory.RowFilter = "Country_Id = " & CInt(Me.cmbCountries.SelectedValue).ToString
                dvCategory.RowFilter = "Operator_Id = " & CInt(Me.cmbOperators.SelectedValue).ToString
                Me.cmbCategory.DataSource = dvCategory
                Me.cmbCategory.ValueMember = "Id"
                Me.cmbCategory.DisplayMember = "Category"
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Paste()
    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded

        'Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(i).Cells(0).Value = i + 1

        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DataGridView1.Rows.Clear()
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = i + 1
        Next
    End Sub

End Class