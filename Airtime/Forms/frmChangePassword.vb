Public Class frmChangePassword

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If checkValidation() Then
            If odbaccess.ChangePassword(gUser.Id, Me.txtNewPassword.Text) Then
                MsgBox("Password changed successfully", , "Airtime System")
                Me.Close()
            Else
                MsgBox("An error occured, please try again later", , "Airtime System")
            End If
        End If


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Function CheckValidation() As Boolean
        If Not Me.txtNewPassword.Text = Me.txtRetypePassword.Text Then
            ErrorProvider1.SetError(txtRetypePassword, "Passwords dont match.")
            Return False
        Else
            ErrorProvider1.SetError(txtRetypePassword, "")
        End If

        If Not Me.txtOldPassword.Text = gUser.Password Then
            ErrorProvider1.SetError(txtOldPassword, "Incorrect Password.")
            Return False
        Else
            ErrorProvider1.SetError(txtOldPassword, "")
        End If
        Return True
    End Function

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
    End Sub
End Class

