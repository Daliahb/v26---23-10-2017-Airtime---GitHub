﻿Public Class frmStartDeviceSlot

    Public lSlotID, lCountryID As Integer
    Public lDeviceSlotID As Long, StrSlot As String
    Public boolSaved, boolError, isLoaded, boolStarted As Boolean
    Public strHumanBehaiviour As String
    Dim lTrafficeType As Long, strOffer As String, dblMinuteCost As Double


    Public Sub New(ByVal strOperator As String, ByVal strDevice As String, lDeviceSlotID As Long, StrSlot As String, lCountryID As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        Me.Label4.Text = "Start Slot " & StrSlot & " in device " & strDevice
        Me.lblOperator.Text = strOperator
        Me.lCountryID = lCountryID
        Me.lDeviceSlotID = lDeviceSlotID
    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolSaved = True

        Dim ds As DataSet
        ds = odbaccess.GetOperators(True, lCountryID)
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
            ds.Tables(0).Rows.Add(0, "All")
            Me.cmbTrafficType.DataSource = ds.Tables(0)
            Me.cmbTrafficType.DisplayMember = "Operator"
            Me.cmbTrafficType.ValueMember = "ID"
        End If
        isLoaded = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean

        Try
            If validation() Then
                fillObject()
                boolError = odbaccess.StartSlot(lDeviceSlotID, Me.DateTimePicker1.Value, Me.lTrafficeType, Me.strOffer, Me.dblMinuteCost)

                If boolError Then
                    MsgBox("The operation done successfuly.")
                    boolStarted = True
                    Me.Close()
                Else
                    MsgBox("An error occured.")

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Function validation() As Boolean
        boolError = True
        Try
            If Me.cmbTrafficType.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbTrafficType, "Please select Traffic Type from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbTrafficType, "")
            End If

            If Me.txtOffer.Text.Length = 0 Then
                ErrorProvider1.SetError(txtOffer, "Please insert a valid value in Offer field.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtOffer, "")
            End If

            If Not IsNumeric(Me.txtMinuteCost.Text) Then
                ErrorProvider1.SetError(txtMinuteCost, "Please insert a valid value in Minute Cost field.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtMinuteCost, "")
            End If
            Return boolError
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
            Return Nothing
        End Try

    End Function


    Public Sub FillObject()
        lTrafficeType = CLng(Me.cmbTrafficType.SelectedValue)
        strOffer = Me.txtOffer.Text
        dblMinuteCost = CDbl(Me.txtMinuteCost.Text)

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


    Private Sub txtMinuteCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinuteCost.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub


End Class