Public Class frmCutDeviceSlot

    Public lDeviceSlotID As Long, StrSlot As String
    Public boolError, boolCut As Boolean
    Dim strNote As String, dblBurnedBalance As Double
    Dim dblTalkTime, dblACD, dblASR As Double
    Dim intTotalCalls As Integer

    Public Sub New(ByVal strOperator As String, ByVal strDevice As String, lDeviceSlotID As Long, StrSlot As String)
        ' This call is required by the designer.
        InitializeComponent()

        Me.Label4.Text = "Cut Slot " & StrSlot & " in device " & strDevice
        Me.lblOperator.Text = strOperator

        Me.lDeviceSlotID = lDeviceSlotID
    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean

        Try
            If validation() Then
                fillObject()
                boolError = odbaccess.CutSlot(lDeviceSlotID, Me.DateTimePicker1.Value, Me.strNote, Me.dblBurnedBalance, dblTalkTime, dblACD, dblASR, intTotalCalls)

                If boolError Then
                    MsgBox("The operation done successfuly.")
                    boolCut = True
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
            If Me.txtNote.Text.Length = 0 Then
                ErrorProvider1.SetError(txtNote, "Please insert a valid value in Offer field.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtNote, "")
            End If

            If Not IsNumeric(Me.txtBurnedBalance.Text) Then
                ErrorProvider1.SetError(txtNote, "Please insert a valid value in Minute Cost field.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtNote, "")
            End If
            Return boolError
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
            Return Nothing
        End Try

    End Function


    Public Sub FillObject()

        strNote = Me.txtNote.Text
        dblBurnedBalance = CDbl(Me.txtBurnedBalance.Text)
        dblTalkTime = 0
        dblACD = 0
        dblASR = 0
        intTotalCalls = 0
    End Sub


    Private Sub txtMinuteCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBurnedBalance.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub


End Class