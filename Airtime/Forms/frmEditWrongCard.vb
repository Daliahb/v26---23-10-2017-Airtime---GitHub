Public Class frmEditWrongCard


    Public lCardID As Integer
    Public boolSaved As Boolean
    Public strCardNumber As String


    Public Sub New(ByVal lCardID As Integer, ByVal strCardNumber As String)
        ' This call is required by the designer.
        InitializeComponent()

        Me.lCardID = lCardID
        Me.strCardNumber = strCardNumber

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtName.Text = strCardNumber
        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            boolError = odbaccess.EditWrongCard(Me.txtName.Text, lCardID)

            If boolError Then
                MsgBox("Operation done successfully.", , "Airtime System")

                Me.Close()
            
            Else
            MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtName.Text = ""

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
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

End Class