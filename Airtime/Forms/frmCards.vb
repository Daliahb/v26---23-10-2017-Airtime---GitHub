﻿Public Class frmCards

    Dim lCountryID, lProviderID, lOperatorID, lCategoryID, lGetCardFrom, lLocationID As Integer
    Dim FromDate, ToDate As Date
    Dim boolCheckDate, isloaded, boolDeviceSetYes, boolDeviceSet As Boolean
    Dim strCardNo As String
    'Dim dsCountries, dsDevices, dsLocations As DataSet


    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'DsLocations.Locations' table. You can move, or remove it, as needed.
        '  Me.LocationsTableAdapter.Fill(Me.DsLocations.Locations)
        'Me.BackColor = gBackColor
        If Not gUser.type = Enumerators.UsersTypes.Admin Then
            Me.DeleteCardToolStripMenuItem.Visible = False
            Me.EditCardsToolStripMenuItem.Visible = False
        End If

        FillTypes()

        isloaded = True

        If gUser.type = Enumerators.UsersTypes.Provider Then
            Me.DataGridView1.Columns(1).Visible = False
            ' Me.PanelDistribute.Visible = False
            Me.cmbCountries.SelectedIndex = 0
            Me.chkCountry.Checked = True
            Me.chkLocation.Visible = False
            Me.cmbLocation.Visible = False
        End If

        If Not cmbCountries.Items.Count = 0 Then
            Me.cmbCountries.SelectedIndex = -1
            Me.cmbCountries.SelectedIndex = 0
        Else
            FillTypes()
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intTotal As Integer = 0
        Dim intRowIndex As Integer

        Dim ds As DataSet
        Try
            If Not gUser.type = Enumerators.UsersTypes.Provider Then
                Me.PanelSetDevices.Visible = True
            Else
                Me.PanelSetDevices.Visible = False
            End If

            Me.DataGridView1.Rows.Clear()
            Generate()
            ds = odbaccess.GetNewCards(lCountryID, lProviderID, lOperatorID, lCategoryID, boolCheckDate, FromDate, ToDate, strCardNo, lLocationID, boolDeviceSet, boolDeviceSetYes)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(2).Value = intCounter + 1
                            .Cells(3).Value = dr.Item("card_number")
                            .Cells(4).Value = dr.Item("Country")
                            .Cells(5).Value = dr.Item("Provider")
                            .Cells(6).Value = dr.Item("Operator")
                            .Cells(7).Value = dr.Item("Category")
                            .Cells(8).Value = CDate(dr.Item("inst_Date")).ToString("yyyy-MM-dd")
                            .Cells(9).Value = CDate(dr.Item("inst_Date")).ToString("HH:mm")
                            .Cells(10).Value = dr.Item("Username")
                            .Cells(11).Value = dr.Item("How")
                            If Not dr.Item("Device") Is DBNull.Value Then
                                .Cells(12).Value = dr.Item("Device")
                            End If

                            intCounter += 1
                            If Me.chkCountry.Checked Then
                                intTotal += CInt(dr.Item("Category"))
                            End If

                        End With
                    Catch ex As Exception

                    End Try
                Next
                Me.Text = "New Cards: " + intCounter.ToString + " Cards"
                If Me.chkCountry.Checked Then
                    Me.Text += ", Value= " + intTotal.ToString + " " + GetCurrency(CInt(Me.cmbCountries.SelectedValue))
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
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
        If Me.chkCard.Checked Then
            strCardNo = Me.txtCardNumber.Text
        Else
            strcardNo = ""
        End If
        If Me.chkDeviceSet.Checked Then
            boolDeviceSet = True
            If Me.rbYes.Checked Then
                boolDeviceSetYes = True
            Else
                boolDeviceSetYes = False
            End If
        Else
            boolDeviceSet = False
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
            gdsCountries = odbaccess.GetCountriesDS
            If Not gdsCountries Is Nothing AndAlso Not gdsCountries.Tables.Count = 0 AndAlso Not gdsCountries.Tables(0).Rows.Count = 0 Then
                Me.cmbCountries.DataSource = gdsCountries.Tables(0)
                Me.cmbCountries.DisplayMember = "Country"
                Me.cmbCountries.ValueMember = "ID"
            End If

            'Dim colUsers As ColUser = odbaccess.GetUsers(2)
            'If Not colUsers Is Nothing Then
            '    Me.cmbUsers.DataSource = colUsers
            '    Me.cmbUsers.DisplayMember = "Username"
            '    Me.cmbUsers.ValueMember = "ID"
            'End If

            ' dsLocations = odbaccess.GetLocations
            If Not gdsLocations Is Nothing AndAlso Not gdsLocations.Tables.Count = 0 AndAlso Not gdsLocations.Tables(0).Rows.Count = 0 Then
                Me.cmbLocation.DataSource = gdsLocations.Tables(0)
                Me.cmbLocation.DisplayMember = "Location"
                Me.cmbLocation.ValueMember = "ID"
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

    Private Sub chkCountry_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCountry.CheckedChanged
        Me.cmbCountries.Enabled = Me.chkCountry.Checked
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Application.OpenForms().OfType(Of frmAddCards).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddCards") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddCards(Enumerators.EditAdd.Add)
            frm.Show()
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

    Private Sub chkLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocation.CheckedChanged
        Me.cmbLocation.Enabled = Me.chkLocation.Checked
        Me.chkDeviceSet.Visible = chkLocation.Checked
        Me.gbDeviceSet.Visible = chkLocation.Checked
    End Sub

    Private Sub txtSelectNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpToDate.Enabled = chkDate.Checked
        Me.dtpFromDate.Enabled = chkDate.Checked
    End Sub

    Public Function GetCurrency(ByVal lCountryID As Integer) As String
        Try
            'dsCountries = odbaccess.GetCountriesDS
            If Not gdsCountries Is Nothing AndAlso Not gdsCountries.Tables.Count = 0 Then
                For Each dr As DataRow In gdsCountries.Tables(0).Rows
                    If dr.Item("ID") = lCountryID Then
                        Return dr.Item("Currency").ToString
                    End If
                Next
            End If
            Return ""
        Catch ex As Exception

        End Try
    End Function


    Private Sub chkCard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCard.CheckedChanged
        Me.txtCardNumber.Enabled = chkCard.Checked
    End Sub

    Private Sub ShowHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHistoryToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = Me.DataGridView1.SelectedCells(0).RowIndex

            Dim frm As New frmCardHistory(Me.DataGridView1.Rows(RowIndex).Cells(3).Value.ToString, CLng(Me.DataGridView1.Rows(RowIndex).Cells(0).Value))
            frm.ShowDialog()
        End If
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

    End Sub

    Private Sub cmbOperators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperators.SelectedIndexChanged
        If Me.chkOperator.Checked Then
            'Dim dsCategory As DataSet = odbaccess.GetCategories(CInt(Me.cmbCountries.SelectedValue), CInt(Me.cmbOperators.SelectedValue))
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

    Private Sub cmbCountries_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountries.SelectedValueChanged
        If isloaded Then
            'Dim dsOperators As DataSet = odbaccess.GetOperators(True, CInt(Me.cmbCountries.SelectedValue))

            'If Not dsOperators Is Nothing AndAlso Not dsOperators.Tables.Count = 0 AndAlso Not dsOperators.Tables(0).Rows.Count = 0 Then
            '    Me.cmbOperators.DataSource = dsOperators.Tables(0)
            '    Me.cmbOperators.DisplayMember = "Operator"
            '    Me.cmbOperators.ValueMember = "ID"
            'End If

            'Dim dsProvider As DataSet = odbaccess.GetProviders(True, CInt(Me.cmbCountries.SelectedValue))
            'If Not dsProvider Is Nothing AndAlso Not dsProvider.Tables.Count = 0 AndAlso Not dsProvider.Tables(0).Rows.Count = 0 Then
            '    Me.cmbProviders.DataSource = dsProvider.Tables(0)
            '    Me.cmbProviders.DisplayMember = "Provider"
            '    Me.cmbProviders.ValueMember = "ID"
            'End If
            If Not gdsOperators Is Nothing AndAlso Not gdsOperators.Tables.Count = 0 Then
                Dim dv As New DataView(gdsOperators.Tables(0))
                dv.RowFilter = "FK_Country = " & CInt(Me.cmbCountries.SelectedValue).ToString
                Me.cmbOperators.DataSource = dv
                Me.cmbOperators.ValueMember = "Id"
                Me.cmbOperators.DisplayMember = "Operator"
            End If

            If Not gdsProviders Is Nothing AndAlso Not gdsProviders.Tables.Count = 0 Then
                Dim dvProvider As New DataView(gdsProviders.Tables(0))
                dvProvider.RowFilter = "FK_Country = " & CInt(Me.cmbCountries.SelectedValue).ToString
                Me.cmbProviders.DataSource = dvProvider
                Me.cmbProviders.ValueMember = "Id"
                Me.cmbProviders.DisplayMember = "Provider"
            End If
        End If
    End Sub

    Private Sub chkClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAll2.CheckedChanged
        Me.chkClearAll2.Checked = False
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            dr.Cells(1).Value = False
        Next
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll2.CheckedChanged
        ' Me.chkSelectAll.Checked = False
        Me.chkSelectAll2.Checked = False
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            dr.Cells(1).Value = True
        Next
    End Sub

    'Private Sub btnSendCards_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strCardID As New System.Text.StringBuilder

    '    If Me.cmbUsers.SelectedValue Is Nothing Then
    '        ErrorProvider1.SetError(cmbUsers, "Please select user from the list.")
    '        Exit Sub
    '    Else
    '        ErrorProvider1.SetError(cmbUsers, "")
    '    End If

    '    For Each dr As DataGridViewRow In Me.DataGridView1.Rows
    '        If CBool(dr.Cells(1).Value) = True Then
    '            strCardID.Append(dr.Cells(0).Value.ToString + ",")
    '        End If
    '    Next

    '    If Not strCardID.ToString.Length = 0 Then
    '        Dim ds As New DataSet
    '        ds = odbaccess.SendCards(CInt(Me.cmbUsers.SelectedValue), strCardID.ToString)
    '        If Not ds Is Nothing Then
    '            MsgBox("Cards sent successfully.")
    '            btnSearch_Click(Me, New System.EventArgs)
    '            If Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
    '                Dim frm As New frmCardsLessThanOperatorLimit(ds)
    '                frm.Show()
    '            End If
    '            'For Each dr As DataGridViewRow In Me.DataGridView1.Rows
    '            '    If CBool(dr.Cells(1).Value) = True Then
    '            '        Me.DataGridView1.Rows.Remove(dr)
    '            '    End If
    '            'Next
    '        Else
    '            MsgBox("An error occured.", , "Airtime System")
    '        End If
    '    Else
    '        MsgBox("Please choose the cards you need to send.", , "Airtime System")
    '    End If
    'End Sub

    Private Sub EditCardsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCardsToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedCells.Count = 0 Then
            If MsgBox("Are you sure you want to edit the selected cards?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

                Dim strCountry, strProvider, strOperator, strCategory, strCardsRecource As String
                strCountry = Me.DataGridView1.Rows(Me.DataGridView1.SelectedCells(0).RowIndex).Cells(4).Value.ToString
                strProvider = Me.DataGridView1.Rows(Me.DataGridView1.SelectedCells(0).RowIndex).Cells(5).Value.ToString
                strOperator = Me.DataGridView1.Rows(Me.DataGridView1.SelectedCells(0).RowIndex).Cells(6).Value.ToString
                strCategory = Me.DataGridView1.Rows(Me.DataGridView1.SelectedCells(0).RowIndex).Cells(7).Value.ToString
                strCardsRecource = Me.DataGridView1.Rows(Me.DataGridView1.SelectedCells(0).RowIndex).Cells(11).Value.ToString
                Dim frm As New frmEditCards(strCountry, strProvider, strOperator, strCategory, strCardsRecource, strCardIDs.ToString)
                frm.ShowDialog()

                btnSearch_Click(Me, New System.EventArgs)
                
            End If
        End If
    End Sub

    
    Private Sub btnSelect2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect2.Click
        If Not CInt(Me.txtSelectNo2.Text) = 0 Then
            chkClearAll_CheckedChanged(Me, New System.EventArgs)
            For i = 0 To CInt(Me.txtSelectNo2.Text) - 1
                If i > Me.DataGridView1.Rows.Count - 1 Then
                    Exit For
                End If
                Me.DataGridView1.Rows(i).Cells(1).Value = True

            Next
        End If
    End Sub

    Private Sub btnSetDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDevice.Click
        Dim strCardID As New System.Text.StringBuilder
        Dim lDeviceID As Integer

        If Me.rbDevice.Checked Then
            If Me.cmbDevices.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbDevices, "Please select device from the list.")
                Exit Sub
            Else
                ErrorProvider1.SetError(cmbDevices, "")
                lDeviceID = CInt(Me.cmbDevices.SelectedValue)
            End If
        Else
            lDeviceID = 0
        End If


        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            If CBool(dr.Cells(1).Value) = True Then
                strCardID.Append(dr.Cells(0).Value.ToString + ",")
            End If
        Next

        If Not strCardID.ToString.Length = 0 Then
            Dim boolError As Boolean
            boolError = odbaccess.SetCardsDevice(lDeviceID, strCardID.ToString)
            If boolError Then
                MsgBox("Cards's device was set successfully.")
                btnSearch_Click(Me, New System.EventArgs)
            Else
                MsgBox("An error occured.", , "Airtime System")
            End If
        Else
            MsgBox("Please choose the cards you need to send.", , "Airtime System")
        End If
    End Sub

    Private Sub chkDeviceSet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDeviceSet.CheckedChanged
        Me.gbDeviceSet.Enabled = chkDeviceSet.Checked
    End Sub

    Private Sub cmbLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocation.SelectedIndexChanged
        'dsDevices = odbaccess.GetDevices(CInt(Me.cmbLocation.SelectedValue))
        'If Not dsDevices Is Nothing Then
        '    Me.cmbDevices.DataSource = dsDevices.Tables(0)
        '    Me.cmbDevices.DisplayMember = "Device"
        '    Me.cmbDevices.ValueMember = "ID"
        'End If
        If Not gdsDevices Is Nothing AndAlso Not gdsDevices.Tables.Count = 0 Then
            Dim dv As New DataView(gdsDevices.Tables(0))
            dv.RowFilter = "fk_Location = " & CInt(Me.cmbLocation.SelectedValue).ToString
            Me.cmbDevices.DataSource = dv
            Me.cmbDevices.ValueMember = "Id"
            Me.cmbDevices.DisplayMember = "Device"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        Me.PrintForm1.Print()
    End Sub
End Class
