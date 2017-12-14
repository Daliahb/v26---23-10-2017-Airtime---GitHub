Imports System.Reflection

Public Class frmLogin

    Dim txtLink As String

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'MsgBox(odbaccess.oConnection.ConnectionString)

        Dim ds As DataSet
        Try
            ds = odbaccess.CheckLogin(Me.txtUserName.Text, Me.txtPassword.Text)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                gUser.setProperties(ds.Tables(0).Rows(0), ds.Tables(1))

                If Not ds.Tables(1).Rows.Count = 0 Then
                    Dim dr As DataRow = ds.Tables(1).Rows(0)
                    With dr
                        If (CInt(dr.Item("Major")) = Assembly.GetExecutingAssembly().GetName().Version().Major) And (CInt(dr.Item("Minor")) = Assembly.GetExecutingAssembly().GetName().Version().Minor) Then
                            Dim frmMain As New FrmMain
                            Me.Visible = False
                            Me.Hide()
                            frmMain.Show()
                        Else
                            Me.lblError.Visible = True
                            Me.lblError.Text = "Please install the updated version!"
                            txtLink = dr.Item("NewSetupLink").ToString
                            Me.lblURL.Visible = True

                        End If
                    End With

                End If


            Else
                Me.lblError.Visible = True
                Me.lblError.Text = "Wrong Username or Password!"
            End If
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
        'Assembly.GetExecutingAssembly().GetName().Version().Revision.ToString() & " Revision - " &
        'Assembly.GetExecutingAssembly().GetName().Version().Major.ToString() & " major -  " &
        'Assembly.GetExecutingAssembly().GetName().Version().Minor.ToString() & " minor - " &
        'Assembly.GetExecutingAssembly().GetName().Version().Build.ToString() & " build")
    End Sub

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.UserName = Me.txtUserName.Text
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        Me.txtUserName.Text = My.Settings.UserName
    End Sub

    Private Sub lblURL_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblURL.LinkClicked
        System.Diagnostics.Process.Start(txtLink)
    End Sub


End Class
