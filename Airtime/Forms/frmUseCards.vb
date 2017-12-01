Public Class frmUseCards
    Dim dsUserCards As DataSet
    Dim lUsersCardsNo, CurrentRow As Integer
    Dim lCurrentCardIndex As Integer = 0
    Dim lCardId, lShiftID As Integer
    Dim lOnHold As Integer = 0
    Dim arOnHold(32, 2) As Object
    Dim oColOperatorsLimits, oColOperatorAlreadyUsedByUser As ColOperators
    Dim lCountryID, lOperatorID, lCategoryID, lDeviceID, lCategoryValue, lHoldDeviceSpotID1, lOldDeviceSpotID1 As Integer
    Dim isSelected As Boolean
    Dim strSlot As String
    Dim lCurrentDeviceSlotID As Long
    Dim lDeviceSlotId As Long
    Dim strDevice, strOperator As String
    Dim ocolDevices As ColDevice
    Dim enumCurrentStatus As Enumerators.HoldOldCut

    Public Sub New(ByVal lShiftID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lShiftID = lShiftID
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillDataSets()
        FillOnHoldListview()
        Me.ocolDevices = odbaccess.GetOnHoldDevices_UsedCards()

        'Get Operator limits for this user
        oColOperatorsLimits = odbaccess.GetUserShiftOperatorsLimits(lShiftID)
        'Get already used cards for this shift
        oColOperatorAlreadyUsedByUser = odbaccess.GetUserShiftAlreadyUsedOperators(lShiftID)

        'Disable Cell buttons
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            CType(row.Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = False
        Next
    End Sub

    Public Sub FillOnHoldListview()
        ' Dim arItems As New ArrayList(32)
        Dim arItems(32) As String

    End Sub

    Public Sub FillDataSets()
        Dim ds As New DataSet
        Dim intRowIndex As Integer
        Dim intCounter As Integer = 0

        Me.DataGridView1.Rows.Clear()
        Me.Label3.Text = "new cards."
        Me.lblCardsNo.Text = "0"
        lCurrentCardIndex = 0

        ds = odbaccess.GetCardUsersCategories()
        If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Try
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells(0).Value = dr.Item("fk_Country")
                        .Cells(1).Value = dr.Item("fk_Operator")
                        .Cells(2).Value = dr.Item("fk_Category")
                        .Cells(3).Value = intCounter + 1
                        .Cells(4).Value = dr.Item("Country")
                        .Cells(5).Value = dr.Item("Operator")
                        .Cells(6).Value = dr.Item("Category")
                        .Cells(7).Value = dr.Item("Device")
                        .Cells(8).Value = dr.Item("DeviceID")
                        .Cells(9).Value = dr.Item("Count")
                        .Cells("dgOldBtn").Value = "Check"
                        .Cells("dgHoldBtn").Value = "Check"
                        .Cells(12).Value = "Create"
                        .Cells(13).Value = "Get"
                        .Cells(14).Value = "Start"
                        .Cells(15).Value = "Cut"
                        .Cells(16).Value = "Add"
                        .Cells(17).Value = 0

                        intCounter += 1
                    End With
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub btnSetAsWrongCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.txtCardNumber.Text.Length = 0 Then
            If MsgBox("Are you sure you want to set this card as a 'Wrong card'", vbYesNo, "Airtime System") = MsgBoxResult.Yes Then
                lCardId = CInt(Me.dsUserCards.Tables(0).Rows(Me.lCurrentCardIndex).Item("id"))
                Dim lCategoryID As Integer = 0
                Dim enumWrongType As New Enumerators.WrongCardTypes

                If Me.rbWrongValue.Checked Then
                    enumWrongType = Enumerators.WrongCardTypes.WrongValue
                    lCategoryID = CInt(Me.cmbCategory.SelectedValue)
                ElseIf rbWrongName.Checked Then
                    enumWrongType = Enumerators.WrongCardTypes.WrongScratchNo
                ElseIf Me.rbAlreadyUsedCard.Checked Then
                    enumWrongType = Enumerators.WrongCardTypes.AlreadyUsedCard
                End If

                odbaccess.SetAsWrongCard(lCardId, enumWrongType, lCategoryID)
                Me.lCurrentCardIndex += 1
                Me.lUsersCardsNo -= 1
                Me.lblCardsNo.Text = lUsersCardsNo.ToString
                Me.txtCardNumber.Text = ""
                'Me.btnSetAsUsed.Enabled = False
                'Me.btnPutOnHold.Enabled = False
                'Me.Panel1.Enabled = False
            End If
        End If

    End Sub

    Private Sub btnRefreshTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshTable.Click
        Me.txtCardNumber.Text = ""

        lblExceedLimit.Visible = False
        oColOperatorsLimits = odbaccess.GetUserShiftOperatorsLimits(lShiftID)
        FillDataSets()

        'Disable Cell buttons
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            CType(row.Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = False
            CType(row.Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = False
        Next
        DataGridView1.Invalidate()
    End Sub

    Private Sub btnGetCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCard.Click
        Dim intLimit As Integer
        If CheckOperatorLimit(intLimit) Then
            'check if he gets more than 32 cards using Hold Slot.
            If enumCurrentStatus = Enumerators.HoldOldCut.Hold Then
                If (Me.ocolDevices.FindGetByIDAndAdd1(lCurrentDeviceSlotID)) >= 33 Then
                    MsgBox("Hold Slot cannot get more than 32 card." & vbCrLf & "You can 'Start' the slot then get more cards.")
                    Return
                End If
            End If

            If Not Me.lUsersCardsNo = 0 AndAlso Not Me.lblCardsNo.Text = "0" Then
                Me.txtCardNumber.Text = Me.dsUserCards.Tables(0).Rows(Me.lCurrentCardIndex).Item("card_number").ToString
                Me.txtCardNumber.Focus()
                'Me.btnSetAsUsed.Enabled = True
                Me.btnPutOnHold.Enabled = True

            Else
                'Me.btnSetAsUsed.Enabled = False
                Me.btnPutOnHold.Enabled = False
                '  Me.Panel1.Enabled = False
                btnGetCard.Enabled = False
            End If
        Else
            Me.btnGetCard.Enabled = False
            Dim strOperator As String = Me.DataGridView1.Rows(CurrentRow).Cells(5).Value.ToString

            lblExceedLimit.Text = "You exceeded your value limit (" + intLimit.ToString + ") for this Operator (" + strOperator + ")."
            lblExceedLimit.Visible = True
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 Then

            Dim buttonCell As DataGridViewDisableButtonCell = CType(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewDisableButtonCell)

            'If buttonCell.Enabled Then
            '    MsgBox(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() + " is enabled")
            'End If

            Select Case e.ColumnIndex
                Case 10 ' Old

                    lOperatorID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value)
                    lDeviceID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value)
                    Dim ofrm As New frmHoldOldSlots(Enumerators.HoldOldCut.Old, lDeviceID, lOperatorID)
                    ofrm.ShowDialog()
                    If ofrm.lDeviceSlotID <> -1 Then ' the user closed the form without choosing
                        If ofrm.lDeviceSlotID > 0 And (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "Check") Then ' the user chose one slot from Old, and Hold is not chosen then choose Old
                            ' Me.lOldDeviceSpotID = ofrm.lDeviceSlotID
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value = ofrm.strSlot
                            Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value = ofrm.lDeviceSlotID
                            Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value = ofrm.strSlot
                        ElseIf ofrm.lDeviceSlotID > 0 And (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "None") And (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "Check") Then
                            MsgBox("You cannot choose slot from 'Old' list unless the 'Hold' is 'None'")
                        ElseIf ofrm.lDeviceSlotID = 0 Then ' the user chose none
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value = ofrm.strSlot ' already slot in Old was chosen, don't take an action untill Old is none
                            '   Me.lOldDeviceSpotID = ofrm.lDeviceSlotID
                            If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "Check") Then ' if old is also none then change the slotID to 0
                                Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value = 0
                                Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value = ofrm.strSlot
                            End If
                        End If

                        'Manage Enable Disable Cells
                        'if Both Old and Hold are not selected then Disable all buttons in this row
                        If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "Check") And _
                            (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "Check") Then
                            '  CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = False
                        End If

                        'if Old is selected then manage Old buttons
                        If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) <> "None" AndAlso CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) <> "Check") _
                            And CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" Then
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = True
                        End If

                        'if Hold is selected then manage Hold buttons
                        If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "None" AndAlso CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "Check") _
                            And CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Then
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = True
                        End If

                        'If both Hold and Old are "None", activate Create button
                        If CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" And CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Then
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = True
                        End If
                        DataGridView1.Invalidate()
                    End If

                Case 11 ' Hold

                    lOperatorID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value)
                    lDeviceID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value)
                    Dim ofrm As New frmHoldOldSlots(Enumerators.HoldOldCut.Hold, lDeviceID, lOperatorID)
                    ofrm.ShowDialog()
                    If ofrm.lDeviceSlotID <> -1 Then ' the user closed the form without choosing
                        If ofrm.lDeviceSlotID > 0 And (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "Check") Then ' the user chose one slot from Hold, and Old is not chosen then choose Hold
                            '  Me.lHoldDeviceSpotID = ofrm.lDeviceSlotID
                            Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value = ofrm.lDeviceSlotID
                            Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value = ofrm.strSlot
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value = ofrm.strSlot
                        ElseIf ofrm.lDeviceSlotID > 0 And (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) <> "None") And (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) <> "Check") Then ' already slot in Old was chosen, don't take an action untill Old is none

                            MsgBox("You cannot choose slot from 'Hold' list unless the Old is 'None'")
                        ElseIf ofrm.lDeviceSlotID = 0 Then ' the user chose none
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value = ofrm.strSlot
                            '    Me.lHoldDeviceSpotID = ofrm.lDeviceSlotID

                            If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "Check") Then ' if old is also none then change the slotID to 0
                                Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value = 0
                                Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value = ofrm.strSlot

                            End If
                        End If

                        'Manage Enable Disable Cells
                        'if Both Old and Hold are not selected then Disable all buttons in this row
                        If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "Check") And _
                            (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Or CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "Check") Then
                            ' CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = False
                        End If

                        'if Old is selected then manage Old buttons
                        If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) <> "None" AndAlso CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) <> "Check") _
                            And CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" Then
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = True
                        End If

                        'if Hold is selected then manage Hold buttons
                        If (CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "None" AndAlso CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "Check") _
                            And CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Then
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = True
                        End If

                        'If both Hold and Old are "None", activate Create button
                        If CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) = "None" And CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value) = "None" Then
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = True
                        End If
                        DataGridView1.Invalidate()
                    End If

                Case 12 ' create new slot
                    If buttonCell.Enabled Then
                        Dim ofrm As frmCreateDeviceSlot

                        lDeviceID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value)
                        lOperatorID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value)
                        strDevice = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value)
                        strOperator = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value)

                        ofrm = New frmCreateDeviceSlot(strOperator, strDevice, lOperatorID, lDeviceID)
                        ofrm.ShowDialog()

                        ' add the new created slot to th ocolDevices 
                        If ofrm.boolSaved Then
                            Dim oDevice As New Device
                            oDevice.DeviceID = ofrm.lDeviceSlotID
                            oDevice.NoOfSentCards = 0
                            Me.ocolDevices.Add(oDevice)
                        End If
                    End If
                Case 13 ' Get Cards
                    If buttonCell.Enabled Then
                        If Me.lOnHold > 0 Then
                            MsgBox("You cannot get new cards when there are 'On hold' cards.")
                        Else
                            If CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "None" Then
                                enumCurrentStatus = Enumerators.HoldOldCut.Hold
                            Else
                                enumCurrentStatus = Enumerators.HoldOldCut.Old
                            End If

                            FillData(e.RowIndex)
                        End If
                    End If
                Case 14 ' Start
                    If buttonCell.Enabled Then
                        lDeviceSlotId = CLng(Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value)
                        strDevice = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value)
                        lCountryID = CInt(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
                        strOperator = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value)
                        strSlot = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value)

                        Dim ofrm As New frmStartDeviceSlot(strOperator, strDevice, lDeviceSlotId, strSlot, lCountryID)
                        ofrm.ShowDialog()
                        If ofrm.boolStarted = True Then
                            'Remove Slot from Hold to Old, and make Hold=none and Old=Slot
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value = Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value 'old
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value = "None" 'Hold
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False

                            If Me.lCurrentDeviceSlotID = CLng(Me.DataGridView1.Rows(e.RowIndex).Cells("dgDeviceSlotID").Value) Then
                                Me.enumCurrentStatus = Enumerators.HoldOldCut.Old
                            End If
                        End If
                    End If
                Case 15 ' Cut
                    If buttonCell.Enabled Then
                        lDeviceSlotId = CLng(Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value)
                        strDevice = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value)
                        strOperator = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value)
                        strSlot = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value)


                        Dim ofrm As New frmCutDeviceSlot(strOperator, strDevice, lDeviceSlotId, strSlot)
                        ofrm.ShowDialog()
                        If ofrm.boolCut = True Then
                            'Remove Slot from Hold to Old, and make Hold=none and Old=Slot
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgOldBtn").Value = "None" 'old
                            Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value = "None" 'Hold
                            Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value = 0
                            Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value = ""

                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCreateBtn"), DataGridViewDisableButtonCell).Enabled = True
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgGetBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgStartBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgCutBtn"), DataGridViewDisableButtonCell).Enabled = False
                            CType(Me.DataGridView1.Rows(e.RowIndex).Cells("dgAddSimsBtn"), DataGridViewDisableButtonCell).Enabled = False
                            DataGridView1.Invalidate()

                            'remove this device from ocolDevices
                            Me.ocolDevices.remove(lDeviceSlotId)
                        End If
                    End If
                Case 16 ' Add
                    If buttonCell.Enabled Then
                        lDeviceSlotId = CLng(Me.DataGridView1.Rows(e.RowIndex).Cells(17).Value)
                        strDevice = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value)
                        strOperator = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value)
                        strSlot = CStr(Me.DataGridView1.Rows(e.RowIndex).Cells(18).Value)
                        Dim enumCurrent As Enumerators.HoldOldCut
                        If CStr(Me.DataGridView1.Rows(e.RowIndex).Cells("dgHoldBtn").Value) <> "None" Then
                            enumCurrent = Enumerators.HoldOldCut.Hold
                        Else
                            enumCurrent = Enumerators.HoldOldCut.Old
                        End If
                        Dim ofrm As New frmAddSimsToDeviceSlot(strOperator, strDevice, lDeviceSlotId, strSlot, enumCurrent)
                        ofrm.ShowDialog()
                    End If
            End Select

        End If
    End Sub

    Public Sub FillData(ByVal RowIndex As Integer)
        dsUserCards = New DataSet
        Dim dsCategories As New DataSet
        Dim strSlot As String

        Try
            Me.txtCardNumber.Text = ""
            Me.lCurrentCardIndex = 0

            btnGetCard.Enabled = False
            lblExceedLimit.Visible = False

            CurrentRow = RowIndex
            lCountryID = CInt(Me.DataGridView1.Rows(RowIndex).Cells(0).Value)
            lOperatorID = CInt(Me.DataGridView1.Rows(RowIndex).Cells(1).Value)
            lCategoryID = CInt(Me.DataGridView1.Rows(RowIndex).Cells(2).Value)
            lDeviceID = CInt(Me.DataGridView1.Rows(RowIndex).Cells(8).Value)
            lCategoryValue = CInt(Me.DataGridView1.Rows(RowIndex).Cells(6).Value)
            lCurrentDeviceSlotID = CInt(Me.DataGridView1.Rows(RowIndex).Cells("dgDeviceSlotID").Value)
            strSlot = CStr(Me.DataGridView1.Rows(RowIndex).Cells("dgSlot").Value)

            dsUserCards = odbaccess.GetUsersCards(lCountryID, lOperatorID, lCategoryID, lDeviceID)
            If Not dsUserCards Is Nothing AndAlso Not dsUserCards.Tables.Count = 0 AndAlso Not dsUserCards.Tables(0).Rows.Count = 0 Then
                lUsersCardsNo = Me.dsUserCards.Tables(0).Rows.Count
                ' Me.Panel3.Enabled = True
                btnGetCard.Enabled = True
            Else
                lUsersCardsNo = 0
            End If
            Me.Label3.Text = "new cards of category " + Me.DataGridView1.Rows(RowIndex).Cells(6).Value.ToString + " Device " + Me.DataGridView1.Rows(RowIndex).Cells(7).Value.ToString + " Slot " + strSlot
            Me.lblCardsNo.Text = lUsersCardsNo.ToString

            dsCategories = odbaccess.GetCategories(lCountryID, lOperatorID)
            If Not dsCategories Is Nothing AndAlso Not dsCategories.Tables.Count = 0 AndAlso Not dsCategories.Tables(0).Rows.Count = 0 Then
                Me.cmbCategory.DataSource = dsCategories.Tables(0)
                Me.cmbCategory.ValueMember = "ID"
                Me.cmbCategory.DisplayMember = "Category"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPutOnHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPutOnHold.Click
        Dim intRowIndex As Integer
        Try
            If lOnHold < 32 AndAlso Not Me.txtCardNumber.Text.Length = 0 Then

                intRowIndex = Me.dgOnHold.Rows.Add
                With Me.dgOnHold.Rows(intRowIndex)
                    .Cells(0).Value = CInt(Me.dsUserCards.Tables(0).Rows(Me.lCurrentCardIndex).Item("id"))
                    .Cells(1).Value = 0
                    .Cells(2).Value = Me.dsUserCards.Tables(0).Rows(Me.lCurrentCardIndex).Item("card_number").ToString
                End With

                '4- increment lOnHold
                lOnHold += 1

                '5- act as "set as used"
                ' lCardId = CInt(Me.dsUserCards.Tables(0).Rows(Me.lCurrentCardIndex).Item("id"))

                Me.lCurrentCardIndex += 1
                Me.lUsersCardsNo -= 1
                Me.DataGridView1.Rows(CurrentRow).Cells(9).Value -= 1
                Me.lblCardsNo.Text = lUsersCardsNo.ToString
                Me.txtCardNumber.Text = ""
                '  Me.btnSetAsUsed.Enabled = False
                Me.btnPutOnHold.Enabled = False
                ' Me.Panel1.Enabled = False
                Me.Panel3.Enabled = True
            Else
                Me.lblExceedLimit.Text = "On Hold list cannot accept more cards."
                Me.lblExceedLimit.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetAsUsedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAsUsedToolStripMenuItem.Click
        '------------------------newm----------------------------
        If Not Me.dgOnHold.SelectedRows.Count = 0 Then
            lCardId = CInt(Me.dgOnHold.SelectedRows(0).Cells(0).Value)
            '1- act as set as used
            If Not odbaccess.UseCard(lCardId, lShiftID, Me.lCurrentDeviceSlotID) Then
                MsgBox("An error occured.", , "Airtime System")
            Else
                For Each lOperator As Operators In Me.oColOperatorAlreadyUsedByUser
                    If lOperator.OperatorID = lOperatorID Then
                        lOperator.UserLimit += lCategoryValue
                        Exit For
                    End If
                Next
            End If
        End If

        '2- empty the listview
        Me.dgOnHold.Rows.Remove(Me.dgOnHold.SelectedRows(0))

        '4- decrement lOnHold
        lOnHold -= 1

    End Sub

    'Private Sub WrongScratchNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrongScratchNumberToolStripMenuItem.Click
    '    If Not Me.ListView1.SelectedItems(0).SubItems(0).Text = "" Then
    '        Dim lItemIndex As Integer = Me.ListView1.SelectedItems(0).Index
    '        '1- act as set as used

    '        lCardId = CInt(arOnHold(lItemIndex, 0))
    '        If Not lCardId = 0 Then
    '            odbaccess.SetAsWrongCard(lCardId, Enumerators.WrongCardTypes.WrongScratchNo, 0)
    '        End If

    '        '2- empty the listview
    '        Me.ListView1.SelectedItems(0).SubItems(0).Text = ""

    '        '3- empty the array
    '        arOnHold(lItemIndex, 0) = 0
    '        arOnHold(lItemIndex, 1) = ""

    '        '4- decrement lOnHold
    '        lOnHold -= 1
    '    End If
    'End Sub

    'Private Sub AlreadyUsedCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlreadyUsedCardToolStripMenuItem.Click
    '    If Not Me.ListView1.SelectedItems(0).SubItems(0).Text = "" Then
    '        Dim lItemIndex As Integer = Me.ListView1.SelectedItems(0).Index
    '        '1- act as set as used

    '        lCardId = CInt(arOnHold(lItemIndex, 0))
    '        If Not lCardId = 0 Then
    '            odbaccess.SetAsWrongCard(lCardId, Enumerators.WrongCardTypes.AlreadyUsedCard, 0)
    '        End If

    '        '2- empty the listview
    '        Me.ListView1.SelectedItems(0).SubItems(0).Text = ""

    '        '3- empty the array
    '        arOnHold(lItemIndex, 0) = 0
    '        arOnHold(lItemIndex, 1) = ""

    '        '4- decrement lOnHold
    '        lOnHold -= 1
    '    End If
    'End Sub

    Public Function CheckOperatorLimit(ByRef intLimit As Integer) As Boolean
        '  For Each operator as operator in Me.oColOperatorAlreadyUsedByUser
        'Dim intLimit As Integer
        Dim lOperator As Operators
        Try
            If gUser.type = Enumerators.UsersTypes.Supervisor Then
                Return True
            End If
            For Each o As Operators In Me.oColOperatorsLimits
                If o.OperatorID = lOperatorID Then
                    intLimit = o.UserLimit
                    Exit For
                End If
            Next

            For Each lOperator In Me.oColOperatorAlreadyUsedByUser
                If lOperator.OperatorID = lOperatorID Then
                    If lOperator.UserLimit >= intLimit Then
                        Return False
                    Else
                        Return True
                    End If
                    Exit For
                End If
            Next
            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Sub btnSetAsUsed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAsUsed.Click
        '------------------------newm----------------------------
        Try
            If isThereCheckedRows() Then
                ErrorProvider1.SetError(Me.dgOnHold, "")
                Me.lblExceedLimit.Visible = False
            Else
                ErrorProvider1.SetIconAlignment(dgOnHold, System.Windows.Forms.ErrorIconAlignment.TopLeft)
                ErrorProvider1.SetError(Me.dgOnHold, "Please choose cards")
                Return
            End If
            Me.btnSetAsUsed.Enabled = False

            If enumCurrentStatus = Enumerators.HoldOldCut.Hold Then
                If (Me.ocolDevices.GetNoOfUsedCards(lCurrentDeviceSlotID)) >= 32 Then
                    MsgBox("Hold Slot cannot use more than 32 card." & vbCrLf & "You can 'Start' the slot then use more cards.")
                    Me.btnSetAsUsed.Enabled = True
                    Me.chkSelectClear.Checked = False
                    Return
                End If
            End If
            For j = dgOnHold.RowCount - 1 To 0 Step -1
                If CBool(dgOnHold.Rows(j).Cells(1).Value) = True Then
                    lCardId = CInt(dgOnHold.Rows(j).Cells(0).Value)
                    '1- act as set as used
                    If Not odbaccess.UseCard(lCardId, lShiftID, lCurrentDeviceSlotID) Then
                        MsgBox("An error occured.", , "Airtime System")
                    Else
                        For Each lOperator As Operators In Me.oColOperatorAlreadyUsedByUser
                            If lOperator.OperatorID = lOperatorID Then
                                lOperator.UserLimit += lCategoryValue
                                Exit For
                            End If
                        Next

                        '2- empty the listview  
                        Me.dgOnHold.Rows.RemoveAt(j)

                        '4- decrement lOnHold
                        lOnHold -= 1

                        '5- add used cards to ocolDevices column to check if it reached 32
                        If enumCurrentStatus = Enumerators.HoldOldCut.Hold Then
                            If (Me.ocolDevices.FindByIDAndAdd1(lCurrentDeviceSlotID)) >= 32 Then
                                MsgBox("Hold Slot cannot use more than 32 card." & vbCrLf & "You can 'Start' the slot then use the remaining cards.")
                                Exit For
                            End If
                        End If

                    End If
                End If
            Next
            If Me.dgOnHold.Rows.Count = 0 Then
                Me.Panel3.Enabled = False
            End If
            Me.btnSetAsUsed.Enabled = True
            Me.chkSelectClear.Checked = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSetAsWrongCard_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAsWrongCard.Click
        If isThereCheckedRows() Then
            ErrorProvider1.SetError(Me.dgOnHold, "")
            Me.lblExceedLimit.Visible = False
        Else
            ErrorProvider1.SetIconAlignment(dgOnHold, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            ErrorProvider1.SetError(Me.dgOnHold, "Please choose cards")
            Return
        End If
        If MsgBox("Are you sure you want to set this card as a 'Wrong card'", vbYesNo, "Airtime System") = MsgBoxResult.Yes Then
            Dim lCategoryID As Integer = 0
            Dim enumWrongType As New Enumerators.WrongCardTypes

            Me.btnSetAsWrongCard.Enabled = False

            If Me.rbWrongValue.Checked Then
                enumWrongType = Enumerators.WrongCardTypes.WrongValue
                lCategoryID = CInt(Me.cmbCategory.SelectedValue)
            ElseIf rbWrongName.Checked Then
                enumWrongType = Enumerators.WrongCardTypes.WrongScratchNo
            ElseIf Me.rbAlreadyUsedCard.Checked Then
                enumWrongType = Enumerators.WrongCardTypes.AlreadyUsedCard
            End If
            For j = dgOnHold.RowCount - 1 To 0 Step -1
                If CBool(dgOnHold.Rows(j).Cells(1).Value) = True Then
                    lCardId = CInt(dgOnHold.Rows(j).Cells(0).Value)

                    If Not lCardId = 0 Then
                        odbaccess.SetAsWrongCard(lCardId, enumWrongType, lCategoryID)
                    End If

                    '2- empty the listview  
                    Me.dgOnHold.Rows.RemoveAt(j)

                    '4- decrement lOnHold
                    lOnHold -= 1
                End If
            Next
            If Me.dgOnHold.Rows.Count = 0 Then
                Me.Panel3.Enabled = False
            End If
            Me.btnSetAsWrongCard.Enabled = True
            Me.chkSelectClear.Checked = False
        End If
    End Sub

    Public Function isThereCheckedRows() As Boolean
        For Each dr As DataGridViewRow In Me.dgOnHold.Rows
            If CBool(dr.Cells(1).Value) = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub rbWrongValue_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWrongValue.CheckedChanged
        Me.Panel2.Enabled = Me.rbWrongValue.Checked
    End Sub

    Private Sub chkSelectClear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectClear.CheckedChanged
        If isSelected Then
            '  Me.chkSelectClear.Checked = False
            isSelected = False
            For Each dr As DataGridViewRow In Me.dgOnHold.Rows
                dr.Cells(1).Value = False
            Next
        Else
            '   Me.chkSelectClear.Checked = False
            isSelected = True
            For Each dr As DataGridViewRow In Me.dgOnHold.Rows
                dr.Cells(1).Value = True
            Next
        End If
    End Sub


End Class