Public Class frmWrongCards

    Dim ds As DataSet
    Dim lCountryID, lProviderID, lOperatorID, lCategoryID, lReturnedByID, lLocationID, lWrongType As Integer
    Dim FromDate, ToDate, WrongDateFrom, WrongDateTo As Date
    Dim boolCheckDate, isloaded, boolWrongDate As Boolean
    Dim strCardNo As String
    Dim dsCountries, dsDevices, dsLocations As DataSet


    Private Sub frmWrongCards_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gUser.type = Enumerators.UsersTypes.Admin Then
            Me.mnChangeWrogCardTypeToolStripMenuItem.Visible = True
            Me.ToolStripSeparator1.Visible = True
            Me.ChangeFromWrongCardToUsedCardToolStripMenuItem.Visible = True
            Me.ToolStripSeparator2.Visible = True
        ElseIf gUser.type = Enumerators.UsersTypes.Provider Then
            Me.chkProvider.Enabled = False
            Me.cmbProviders.SelectedValue = gUser.Provider
            Me.chkLocation.Enabled = False
        End If
        '   btnSearch_Click(Me, New System.EventArgs)

        FillTypes()

        isloaded = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer

        Try
            Me.DataGridView1.Rows.Clear()
            Generate()
            ds = odbaccess.GetWrongCards(lWrongType, lCountryID, lProviderID, lOperatorID, lCategoryID, lReturnedByID, lLocationID, strCardNo, boolCheckDate, FromDate, ToDate, boolWrongDate, WrongDateFrom, WrongDateTo)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = CType(dr.Item("WrongCardType"), Enumerators.WrongCardTypes)
                            .Cells(2).Value = intCounter + 1
                            .Cells(3).Value = dr.Item("card_number")
                            .Cells(4).Value = dr.Item("Country")
                            .Cells(5).Value = dr.Item("Operator")
                            .Cells(6).Value = dr.Item("Category")
                            .Cells(7).Value = dr.Item("Provider")
                            .Cells(8).Value = CDate(dr.Item("inst_date")).ToString("yyyy-MM-dd")
                            .Cells(9).Value = CDate(dr.Item("inst_date")).ToString("HH:mm")

                            If Not dr.Item("username") Is DBNull.Value Then
                                .Cells(10).Value = dr.Item("username")
                            End If
                            If Not dr.Item("SetAsWrong_Date") Is DBNull.Value Then
                                .Cells(11).Value = CDate(dr.Item("SetAsWrong_Date")).ToString("yyyy-MM-dd HH:mm")
                            End If
                            If Not dr.Item("WrongCardType") Is DBNull.Value Then
                                If CType(dr.Item("WrongCardType"), Enumerators.WrongCardTypes) = Enumerators.WrongCardTypes.WrongValue Then
                                    .Cells(12).Value = "Wrong value"
                                ElseIf CType(dr.Item("WrongCardType"), Enumerators.WrongCardTypes) = Enumerators.WrongCardTypes.WrongScratchNo Then
                                    .Cells(12).Value = "Wrong scratch no."
                                ElseIf CType(dr.Item("WrongCardType"), Enumerators.WrongCardTypes) = Enumerators.WrongCardTypes.AlreadyUsedCard Then
                                    .Cells(12).Value = "Already used card"
                                    .DefaultCellStyle.BackColor = Color.RosyBrown
                                End If
                            End If

                            If Not dr.Item("RightCategory") Is DBNull.Value Then
                                .Cells(13).Value = dr.Item("RightCategory").ToString
                            End If

                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(1).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim intColumnIndex As Integer


    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.DataGridView1.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
                If CType(DataGridView1.Rows(ht.RowIndex).Cells(1).Value, Enumerators.WrongCardTypes) = Enumerators.WrongCardTypes.WrongValue Then
                    ContextMenuStrip1.Items(0).Visible = False
                    ContextMenuStrip1.Items(1).Visible = True
                    '   ContextMenuStrip1.Items(3).Visible = True
                ElseIf CType(DataGridView1.Rows(ht.RowIndex).Cells(1).Value, Enumerators.WrongCardTypes) = Enumerators.WrongCardTypes.WrongScratchNo Then
                    ContextMenuStrip1.Items(0).Visible = True
                    ContextMenuStrip1.Items(1).Visible = False
                    '  ContextMenuStrip1.Items(3).Visible = True
                Else
                    ContextMenuStrip1.Items(0).Visible = False
                    ContextMenuStrip1.Items(1).Visible = False
                    '   ContextMenuStrip1.Items(3).Visible = True
                End If

            ElseIf ht.Type = DataGridViewHitTestType.ColumnHeader Then
                Me.intColumnIndex = ht.ColumnIndex
                DataGridView1.ContextMenuStrip = ContextMenuStripHideColumn
            Else
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
    End Sub

    Private Sub HideColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideColumnToolStripMenuItem.Click
        Me.DataGridView1.Columns(intColumnIndex).Visible = False
    End Sub

    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        For i As Integer = 1 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns(i).Visible = True
        Next
    End Sub

    Private Sub EditCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCategoryToolStripMenuItem.Click
        ' If Not Me.DataGridView1.SelectedRows.Count = 0 Then
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex

            Dim frm As New frmEditWrongCard(CInt(Me.DataGridView1.Rows(RowIndex).Cells(0).Value), Me.DataGridView1.Rows(RowIndex).Cells(3).Value.ToString)
            frm.ShowDialog()
            'btnSearch_Click(Me, New System.EventArgs)
            ' Me.DataGridView1.Rows(RowIndex).Cells(3).Value = frm.txtName.Text
            Me.DataGridView1.Rows.RemoveAt(RowIndex)
        End If
    End Sub

    Private Sub ConfirmRightCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmRightCategoryToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
            If MsgBox("Are you sure you want to change the category of this card?" & vbCrLf & Me.DataGridView1.Rows(RowIndex).Cells(3).Value.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim lCardID As Integer = CInt(Me.DataGridView1.Rows(RowIndex).Cells(0).Value)
                odbaccess.EditWrongValue(lCardID)
                Me.DataGridView1.Rows.RemoveAt(RowIndex)
            End If
        End If

    End Sub

    Private Sub chkTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTypes.CheckedChanged
        Me.cmbTypes.Enabled = Me.chkTypes.Checked
    End Sub

    Private Sub ChangeWrogCardTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnChangeWrogCardTypeToolStripMenuItem.Click
        Dim oWrongCard As New WrongCard
        Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex

        With Me.DataGridView1.Rows(RowIndex)
            For Each dr As DataRow In ds.Tables(0).Rows
                If CLng(dr.Item("ID")) = CLng(.Cells(0).Value) Then
                    oWrongCard.ID = CLng(dr.Item("ID"))
                    oWrongCard.ScratchNo = dr.Item("card_number").ToString
                    oWrongCard.Country = CInt(dr.Item("fk_country"))
                    oWrongCard.OperatorID = CInt(dr.Item("fk_Operator"))
                    oWrongCard.NewCategory = dr.Item("RightCategory").ToString
                    oWrongCard.WrongType = CType(dr.Item("WrongCardType"), Enumerators.WrongCardTypes)
                    Exit For
                End If
            Next
        End With
        Dim frm As New frmEditWrongCardType(oWrongCard)
        frm.ShowDialog()

        ' Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
        With Me.DataGridView1.Rows(RowIndex)
            .Cells(1).Value = frm.oWrongCard.WrongType

            Select Case frm.oWrongCard.WrongType
                Case Enumerators.WrongCardTypes.WrongValue
                    .Cells(12).Value = "Wrong value"
                Case Enumerators.WrongCardTypes.WrongScratchNo
                    .Cells(12).Value = "Wrong scratch no."
                Case Enumerators.WrongCardTypes.AlreadyUsedCard
                    .Cells(12).Value = "Already used card"
            End Select
            .Cells(13).Value = oWrongCard.NewCategory
        End With
    End Sub

    Private Sub CopyCardNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim s As String = ""
        'Dim o As New DataObject
        's = Me.DataGridView1.SelectedRows(0).Cells(2).Value.ToString
        'o.SetText(s)
        'Clipboard.SetDataObject(o, True)
    End Sub

    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
            Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
                Me.cmbOperators.DataSource = dsOperators.Tables(0)
                Me.cmbOperators.DisplayMember = "Operator"
                Me.cmbOperators.ValueMember = "ID"
            End If

            Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
                Me.cmbProviders.DataSource = dsProvider.Tables(0)
                Me.cmbProviders.DisplayMember = "Provider"
                Me.cmbProviders.ValueMember = "ID"
            End If

        End If
    End Sub

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedIndexChanged
        If Me.chkOperator.Checked Then
            Dim dsCategory As DataSet = odbaccess.GetCategories(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbOperators.SelectedValue))
            If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
                Me.cmbCategory.DataSource = dsCategory.Tables(0)
                Me.cmbCategory.DisplayMember = "Category"
                Me.cmbCategory.ValueMember = "ID"
            End If
        End If

    End Sub

    Private Sub chkCountry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCountry.CheckedChanged
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub

    Private Sub chkProvider_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProvider.CheckedChanged
        Me.cmbProviders.Enabled = Me.chkProvider.Checked
    End Sub

    Private Sub chkOperator_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOperator.CheckedChanged
        Me.cmbOperators.Enabled = Me.chkOperator.Checked
    End Sub

    Private Sub chkCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCategory.CheckedChanged
        Me.cmbCategory.Enabled = Me.chkCategory.Checked
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpToDate.Enabled = chkDate.Checked
        Me.dtpFromDate.Enabled = chkDate.Checked
    End Sub

    Private Sub chkWrongDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWrongDate.CheckedChanged
        Me.dtpWrongDateFrom.Enabled = chkWrongDate.Checked
        Me.dtpWrongDateTo.Enabled = chkWrongDate.Checked
    End Sub

    Public Sub FillTypes()
        Try
            dsCountries = odbaccess.GetCountriesDS
            If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
                Me.cmbCountries.DataSource = dsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If

            Dim colUsers As ColUser = odbaccess.GetUsers(5)
            If Not colUsers Is Nothing Then
                Me.cmbUsers.DataSource = colUsers
                Me.cmbUsers.DisplayMember = "Username"
                Me.cmbUsers.ValueMember = "ID"
            End If

            dsLocations = odbaccess.GetLocations
            If Not dsLocations Is Nothing AndAlso Not dsLocations.Tables.Count = 0 AndAlso Not dsLocations.Tables(0).Rows.Count = 0 Then
                Me.cmbLocation.DataSource = dsLocations.Tables(0)
                Me.cmbLocation.DisplayMember = "Location"
                Me.cmbLocation.ValueMember = "ID"
            End If

            Me.cmbTypes.DataSource = Nothing
            Me.cmbTypes.Items.Add(New Obj("Wrong scratch number", Enumerators.WrongCardTypes.WrongScratchNo))
            Me.cmbTypes.Items.Add(New Obj("Wrong value", Enumerators.WrongCardTypes.WrongValue))
            Me.cmbTypes.Items.Add(New Obj("Already used card", Enumerators.WrongCardTypes.AlreadyUsedCard))

            Me.cmbTypes.ValueMember = "Value"
            Me.cmbTypes.DisplayMember = "Name"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Generate()
        If Me.chkCategory.Checked AndAlso Not cmbCategory.SelectedValue Is Nothing Then
            lCategoryID = CInt(Me.cmbCategory.SelectedValue)
        Else
            lCategoryID = 0
        End If

        If Me.chkCountry.Checked AndAlso Not cmbCountries.SelectedValue Is Nothing Then
            lCountryID = CInt(Me.cmbCountries.SelectedValue)
        Else
            lCountryID = 0
        End If

        If Me.chkOperator.Checked AndAlso Not cmbOperators.SelectedValue Is Nothing Then
            lOperatorID = CInt(Me.cmbOperators.SelectedValue)
        Else
            lOperatorID = 0
        End If

        If Me.chkProvider.Checked AndAlso Not cmbProviders.SelectedValue Is Nothing Then
            lProviderID = CInt(Me.cmbProviders.SelectedValue)
        Else
            lProviderID = 0
        End If
        If Me.chkLocation.Checked AndAlso Not cmbLocation.SelectedValue Is Nothing Then
            lLocationID = CInt(Me.cmbLocation.SelectedValue)
        Else
            lLocationID = 0
        End If
        If Me.chkDate.Checked Then
            boolCheckDate = True
            FromDate = Me.dtpFromDate.Value
            ToDate = CDate(Me.dtpToDate.Value).AddDays(1)
        Else
            boolCheckDate = False
        End If

        If Me.chkWrongDate.Checked Then
            boolWrongDate = True
            WrongDateFrom = Me.dtpWrongDateFrom.Value
            WrongDateTo = CDate(Me.dtpWrongDateTo.Value).AddDays(1)
        Else
            boolWrongDate = False
        End If

        If Me.chkCard.Checked Then
            strCardNo = Me.txtCardNumber.Text
        Else
            strcardNo = ""
        End If
        If Me.chkUsers.Checked AndAlso Not cmbUsers.SelectedValue Is Nothing Then
            lReturnedByID = CInt(Me.cmbUsers.SelectedValue)
        Else
            lReturnedByID = 0
        End If

        If Me.chkTypes.Checked Then
            lWrongType = CInt(Me.cmbTypes.SelectedItem.value)
        Else
            lWrongType = 0
        End If
    End Sub

    Private Sub chkUsers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUsers.CheckedChanged
        Me.cmbUsers.Enabled = Me.chkUsers.Checked
    End Sub

    Private Sub chkCard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCard.CheckedChanged
        Me.txtCardNumber.Enabled = Me.chkCard.Checked
    End Sub

    Private Sub chkLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocation.CheckedChanged
        Me.cmbLocation.Enabled = chkLocation.Checked
    End Sub

    Private Sub ChangeFromWrongCardToUsedCardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChangeFromWrongCardToUsedCardToolStripMenuItem.Click

        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            If MsgBox("Are you sure you want to change the selected cards from Wrong Cards to Used Cards?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim ar As New ArrayList
                For Each cell As DataGridViewCell In Me.DataGridView1.SelectedCells()
                    If Not ar.Contains(cell.RowIndex) Then
                        ar.Add(cell.RowIndex)
                    End If
                Next
                ar.Sort()
                Dim strCardIDs As String = ""
                Dim id As Integer
                For Each id In ar
                    strCardIDs += Me.DataGridView1.Rows(id).Cells(0).Value.ToString
                    strCardIDs += ","
                Next
                If odbaccess.ChangeFromWrongCardToUsedCard(strCardIDs) Then
                    MsgBox("Operation done successfully.")
                    '   Me.DataGridView1.Rows.RemoveAt(RowIndex)
                    For i As Integer = ar.Count - 1 To 0 Step -1
                        Me.DataGridView1.Rows.RemoveAt(CInt(ar(i)))
                    Next
                    'For Each id In ar
                    '    Me.DataGridView1.Rows.RemoveAt(id)
                    'Next
                Else
                    MsgBox("An error occured!")
                End If
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
