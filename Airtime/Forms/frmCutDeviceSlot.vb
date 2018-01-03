Public Class frmCutDeviceSlot

    Public lDeviceSlotID As Long, StrSlot, strPrefix As String
    Public boolError, boolCut As Boolean
    Dim strNote As String, dblBurnedBalance As Double
    Dim dblTalkTime, dblACD, dblASR As Double
    Dim intTotalCalls As Integer
    Dim dStartDate As DateTime

    Public Sub New(ByVal strOperator As String, ByVal strDevice As String, lDeviceSlotID As Long, StrSlot As String)
        ' This call is required by the designer.
        InitializeComponent()

        Me.Label4.Text = "Cut Slot " & StrSlot & " in device " & strDevice
        Me.lblOperator.Text = strOperator

        Me.lDeviceSlotID = lDeviceSlotID

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As DataSet
        ds = odbaccess.GetSlotStartDate_Prefix(lDeviceSlotID)
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
            If Not ds.Tables(0).Rows(0).Item("Start_Time") Is DBNull.Value Then
                dStartDate = CDate(ds.Tables(0).Rows(0).Item("Start_Time")).ToUniversalTime

            Else
                dStartDate = DateTime.UtcNow
                ' ToUniversalTime()
            End If

            If Not ds.Tables(0).Rows(0).Item("Prefix") Is DBNull.Value Then
                strPrefix = CStr(ds.Tables(0).Rows(0).Item("Prefix"))
            Else
                strPrefix = ""
            End If
        Else
            MsgBox("Cannot get Created Time from server!")
        End If
        If dStartDate = Nothing Then
            MsgBox("Cannot get Created Time from server!")
        End If
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
            'If Me.txtNote.Text.Length = 0 Then
            '    ErrorProvider1.SetError(txtNote, "Please insert a valid value in Offer field.")
            '    boolError = False
            'Else
            '    ErrorProvider1.SetError(txtNote, "")
            'End If

            If Not IsNumeric(Me.txtBurnedBalance.Text) Then
                ErrorProvider1.SetError(txtBurnedBalance, "Please insert a valid value in Burned Balance field.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtBurnedBalance, "")
            End If
            Return boolError
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
            Return Nothing
        End Try

    End Function


    Public Sub FillObject()
        Dim strResult As String
        strNote = Me.txtNote.Text
        dblBurnedBalance = CDbl(Me.txtBurnedBalance.Text)

        'Dim result As String = webClient.DownloadString("http://144.76.18.44/nc/api.php?par=cdr&date_from=2017-11-01_05:31:01&date_to=2017-11-02_05:31:01&prefix=99234")

        dblTalkTime = 0
        dblACD = 0
        dblASR = 0
        intTotalCalls = 0
        Try
            If Not dStartDate = Nothing And Not strPrefix.Length = 0 Then
                ' Get Slot created time, Slot cut time, Device Prefix
                Dim dStartDateTime, dCutDateTime As String
                dCutDateTime = CDate(DateTime.UtcNow).ToString("yyyy-MM-dd_HH:mm:ss")
                dStartDateTime = dStartDate.ToString("yyyy-MM-dd_HH:mm:ss")

                Dim webClient As New System.Net.WebClient
                strResult = "http://144.76.18.44/nc/api.php?par=cdr&date_from=" & dStartDateTime & "&"
                strResult = strResult & "date_to=" & dCutDateTime & "&"
                strResult = strResult & "prefix=" & strPrefix

                Dim result As String = webClient.DownloadString(strResult)

                If Not result Is Nothing AndAlso Not result.Length = 0 Then
                    result.Trim()

                    Dim strArr() As String

                    strArr = result.Split(CChar("|"))
                    If Not strArr.Count = 0 Then
                        If IsNumeric(strArr(0)) Then
                            intTotalCalls = CInt(strArr(0))
                        End If

                        If IsNumeric(strArr(1)) Then
                            dblTalkTime = CDbl(strArr(1))
                        End If
                        If IsNumeric(strArr(2)) Then
                            dblACD = CDbl(strArr(2))
                        End If
                        If IsNumeric(strArr(3)) Then
                            dblASR = CDbl(strArr(3))
                        End If
                    End If
                Else
                    MsgBox("Couldn't get data from SPO server.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub


    Private Sub txtMinuteCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBurnedBalance.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
End Class