Public Class frmDistributedCards

    Dim lCountryID, lProviderID, lOperatorID, lCategoryID, lGetCardFrom, lSenttoID, lDeviceID As Integer
    Dim boolUsed, isUsed, boolUsedDate, boolDistDate, isloaded As Boolean
    Dim FromDate, ToDate, DistFromDate, DistToDate As Date
    Dim strCardNo As String
    Dim dsCountries, dsDevices As DataSet

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        If Not gUser.type = Enumerators.UsersTypes.Admin Then
            Me.DeleteCardToolStripMenuItem.Visible = False
        End If
        FillTypes()
        isloaded = True

        Me.cmbCountries.SelectedIndex = -1
        Me.cmbCountries.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intTotal As Integer = 0
        Dim intRowIndex As Integer

        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            Generate()
            ds = odbaccess.GetDistributedCards(lCountryID, lProviderID, lOperatorID, lCategoryID, lSenttoID, boolUsed, isUsed, boolUsedDate, FromDate, ToDate, strCardNo, boolDistDate, DistFromDate, DistToDate, lDeviceID)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = intCounter + 1
                            .Cells(3).Value = dr.Item("card_number")
                            .Cells(4).Value = dr.Item("Country")
                            .Cells(5).Value = dr.Item("Provider")
                            .Cells(6).Value = dr.Item("Operator")
                            .Cells(7).Value = dr.Item("Category")
                            .Cells(8).Value = dr.Item("SentTo")
                            .Cells(9).Value = dr.Item("isUsed")
                            If CBool(dr.Item("isUsed")) Then
                                .Cells(10).Value = CDate(dr.Item("Used_Date")).ToString("yyyy-MM-dd HH:mm")
                            End If

                            intCounter += 1
                            If Me.chkCountry.Checked Then
                                intTotal += CInt(dr.Item("Category"))
                            End If
                        End With
                    Catch ex As Exception

                    End Try
                Next
                If Me.chkStatus.Checked AndAlso Me.rbNotSent.Checked Then
                    Me.Panel2.Visible = True
                    Me.DataGridView1.Columns(2).Visible = True
                Else
                    Me.Panel2.Visible = False
                    Me.DataGridView1.Columns(2).Visible = False
                End If
            End If
            Me.Text = "Distributed Cards:  " & intCounter & " Cards"
            If Me.chkCountry.Checked Then
                Me.Text += ", Value= " + intTotal.ToString + " " + GetCurrency(CInt(Me.cmbCountries.SelectedValue))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetCurrency(ByVal lCountryID As Integer) As String
        Try
            dsCountries = odbaccess.GetCountriesDS
            If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 Then
                For Each dr As DataRow In dsCountries.Tables(0).Rows
                    If CInt(dr.Item("ID")) = lCountryID Then
                        Return dr.Item("Currency").ToString
                    End If
                Next
            End If
            Return ""
        Catch ex As Exception

        End Try
    End Function

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

        If Me.chkUsers.Checked AndAlso Not cmbUsers.SelectedValue Is Nothing Then
            lSenttoID = CInt(Me.cmbUsers.SelectedValue)
        Else
            lSenttoID = 0
        End If
        If Me.chkStatus.Checked Then
            boolUsed = True
            If rbSent.Checked Then
                isUsed = True
            Else
                isUsed = False
            End If
        Else
            boolUsed = False
        End If
        If Me.chkDate.Checked Then
            boolUsedDate = True
            FromDate = Me.dtpFromDate.Value
            ToDate = CDate(Me.dtpToDate.Value).AddDays(1)
        Else
            boolUsedDate = False
        End If
        If Me.chkDistributedDate.Checked Then
            boolDistDate = True
            DistFromDate = Me.dtpDistFromDate.Value
            DistToDate = CDate(Me.dtpDistToDate.Value).AddDays(1)
        Else
            boolDistDate = False
        End If
        If Me.chkCard.Checked Then
            strCardNo = Me.txtCardNumber.Text
        Else
            strcardNo = ""
        End If

        If Me.chkDevice.Checked AndAlso Not cmbDevices.SelectedValue Is Nothing Then
            lDeviceID = CInt(Me.cmbDevices.SelectedValue)
        Else
            lDeviceID = 0
        End If
    End Sub
    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(2).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub FillTypes()
        Try

            dsCountries = odbaccess.GetCountriesDS
            If Not dsCountries Is Nothing AndAlso Not dsCountries.Tables.Count = 0 AndAlso Not dsCountries.Tables(0).Rows.Count = 0 Then
                Me.cmbCountries.DataSource = dsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If
           

            Dim colUsers As ColUser = odbaccess.GetUsers(2)
            If Not colUsers Is Nothing Then
                Me.cmbUsers.DataSource = colUsers
                Me.cmbUsers.DisplayMember = "Username"
                Me.cmbUsers.ValueMember = "ID"
            End If

            dsDevices = odbaccess.GetDevices(0)
            If Not dsDevices Is Nothing Then
                Me.cmbDevices.DataSource = dsDevices.Tables(0)
                Me.cmbDevices.DisplayMember = "Device"
                Me.cmbDevices.ValueMember = "ID"
            End If
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

    Private Sub chkClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmAddCategory(Enumerators.EditAdd.Add)
        frm.Show()
    End Sub

    Private Sub EditPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            If MsgBox("Are you sure you want to return this card?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim strCardID As String
                Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
                strCardID = Me.DataGridView1.Rows(RowIndex).Cells(0).Value.ToString + ","
                If odbaccess.ReturnCards(strCardID) Then
                    MsgBox("Cards sent back successfully.")
                    btnSearch_Click(Me, New System.EventArgs)
                Else
                    MsgBox("An error occured.", , "Airtime System")
                End If
            Else
                MsgBox("There is no cards to retrun.", , "Airtime System")
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

    Private Sub chkUsers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUsers.CheckedChanged
        Me.cmbUsers.Enabled = Me.chkUsers.Checked
    End Sub

    Private Sub chkEmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        Me.rbNotSent.Enabled = Me.chkStatus.Checked
        Me.rbSent.Enabled = Me.chkStatus.Checked
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCards.Click
        Dim strCardID As New System.Text.StringBuilder
     


        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            If CBool(dr.Cells(2).Value) = True Then
                strCardID.Append(dr.Cells(0).Value.ToString + ",")
            End If
        Next

        If Not strCardID.ToString.Length = 0 Then
            If MsgBox("Are you sure you want to return the selected cards?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If odbaccess.ReturnCards(strCardID.ToString) Then
                    MsgBox("Cards sent back successfully.")
                    btnSearch_Click(Me, New System.EventArgs)
                Else
                    MsgBox("An error occured.", , "Airtime System")
                End If
            End If
        Else
            MsgBox("Please choose the cards you need to return.", , "Airtime System")
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not CInt(Me.txtSelectNo.Text) = 0 Then
            chkClearAll_CheckedChanged(Me, New System.EventArgs)
            For i = 0 To CInt(Me.txtSelectNo.Text) - 1
                If i > Me.DataGridView1.Rows.Count - 1 Then
                    Exit For
                End If
                Me.DataGridView1.Rows(i).Cells(2).Value = True

            Next
        End If
    End Sub

    Private Sub chkClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAll.CheckedChanged
        Me.chkClearAll.Checked = False
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            dr.Cells(2).Value = False
        Next
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        Me.chkSelectAll.Checked = False
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            dr.Cells(2).Value = True
        Next
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpFromDate.Enabled = Me.chkDate.Checked
        Me.dtpToDate.Enabled = Me.chkDate.Checked
    End Sub

    Private Sub ShowHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHistoryToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex

            Dim frm As New frmCardHistory(Me.DataGridView1.Rows(RowIndex).Cells(3).Value.ToString, CLng(Me.DataGridView1.Rows(RowIndex).Cells(0).Value))
            frm.ShowDialog()
        End If
    End Sub

    Private Sub chkCard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCard.CheckedChanged
        Me.txtCardNumber.Enabled = Me.chkCard.Checked
    End Sub

    Private Sub DeleteCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCardToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            If MsgBox("Are you sure you want to delete the selected cards?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim ar As New ArrayList
                For Each cell As DataGridViewCell In Me.DataGridView1.SelectedCells()
                    If Not ar.Contains(cell.RowIndex) Then
                        ar.Add(cell.RowIndex)
                    End If
                Next

                '  Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
                Dim strCardIDs As String = ""
                Dim id As Integer
                For Each id In ar
                    strCardIDs += Me.DataGridView1.Rows(id).Cells(0).Value.ToString
                    strCardIDs += ","
                Next
                '  Dim lCardID As Long = CLng(Me.DataGridView1.Rows(RowIndex).Cells(0).Value)
                If odbaccess.DeleteCard(strCardIDs) Then
                    MsgBox("Operation done successfully.")
                    '   Me.DataGridView1.Rows.RemoveAt(RowIndex)
                    For Each id In ar
                        Me.DataGridView1.Rows.RemoveAt(id)
                    Next
                Else
                    MsgBox("An error occured!")
                End If
            End If
        End If
        'If Not Me.DataGridView1.SelectedCells.Count = 0 Then
        '    Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex
        '    If MsgBox("Are you sure you want to delete this card?" & vbCrLf & Me.DataGridView1.Rows(RowIndex).Cells(3).Value.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Dim lCardID As Long = CLng(Me.DataGridView1.Rows(RowIndex).Cells(0).Value)
        '        If odbaccess.DeleteCard(lCardID) Then
        '            MsgBox("Operation done successfully.")
        '            Me.DataGridView1.Rows.RemoveAt(RowIndex)
        '        Else
        '            MsgBox("An error occured!")
        '        End If
        '    End If
        'End If
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

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedIndexChanged
        If Me.chkOperator.Checked Then
            Dim dsCategory As DataSet = odbaccess.GetCategories(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbOperators.SelectedValue))
            If Not dsCategory Is Nothing AndAlso Not dsCategory.Tables.Count = 0 AndAlso Not dsCategory.Tables(0).Rows.Count = 0 Then
                Me.cmbCategory.DataSource = dsCategory.Tables(0)
                Me.cmbCategory.DisplayMember = "Category"
                Me.cmbCategory.ValueMember = "ID"
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDistributedDate.CheckedChanged
        Me.dtpDistFromDate.Enabled = Me.chkDistributedDate.Checked
        Me.dtpDistToDate.Enabled = Me.chkDistributedDate.Checked
    End Sub

    Private Sub chkDevice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDevice.CheckedChanged
        Me.cmbDevices.Enabled = chkDevice.Checked
    End Sub

End Class
