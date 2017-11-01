Public Class frmAddSimsToDeviceSlot

    Public lDeviceSlotID As Long, StrSlot As String
    Public boolError As Boolean
    Public lAddedSims As Long
    Dim enumCurrent As Enumerators.HoldOldCut
    Dim lAlreadyAddedSims As Long

    Public Sub New(ByVal strOperator As String, ByVal strDevice As String, lDeviceSlotID As Long, StrSlot As String, enumCurrent As Enumerators.HoldOldCut)
        ' This call is required by the designer.
        InitializeComponent()

        Me.Label4.Text = "Add sims to Slot " & StrSlot & " in device " & strDevice
        Me.lblOperator.Text = strOperator

        Me.lDeviceSlotID = lDeviceSlotID
        Me.enumCurrent = enumCurrent
    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lAlreadyAddedSims = odbaccess.GetNoOfSims(Me.lDeviceSlotID)
        Me.lblNoOfSims.Text = lAlreadyAddedSims.ToString
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean

        Try
            If validation() Then

                boolError = odbaccess.AddSimsToDeviceSlot(lDeviceSlotID, CInt(Me.txtNoOfSims.Text))

                If boolError Then
                    MsgBox("The operation done successfuly.")

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
            If Not IsNumeric(Me.txtNoOfSims.Text) Then
                ErrorProvider1.SetError(txtNoOfSims, "Please insert a valid value in 'Added Sims' field.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtNoOfSims, "")
            End If
            If IsNumeric(txtNoOfSims.Text) Then
                If enumCurrent = Enumerators.HoldOldCut.Hold Then
                    If CInt(txtNoOfSims.Text) + lAlreadyAddedSims > 32 Then
                        ErrorProvider1.SetError(txtNoOfSims, "Cannot add more than 32 Sim cards to a slot on Hold.")
                        boolError = False
                    Else
                        ErrorProvider1.SetError(txtNoOfSims, "")
                    End If
                End If
            End If
            Return boolError
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
            Return Nothing
        End Try

    End Function


   


    Private Sub txtMinuteCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfSims.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub


End Class