Public Class AddSlotNote

    Dim lDeviceSlotId As Long

    Public Sub New(lDeviceSlotId As Long)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lDeviceSlotId = lDeviceSlotId
    End Sub

    Private Sub AddSlotNote_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.txtNote.Text = odbaccess.GetSlotNote(lDeviceSlotId)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If odbaccess.SaveSlotNote(lDeviceSlotId, Me.txtNote.Text) Then
            MsgBox("Note added successfully.")
        Else
            MsgBox("An error occured!")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
   

End Class

