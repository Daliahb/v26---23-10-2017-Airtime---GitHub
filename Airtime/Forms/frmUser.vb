Public Class frmUser
    Dim oUser As New User
    Dim oColUsers As New ColUser
    Dim booloaded As Boolean

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmAddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsUsers.users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.DsUsers.users)


        Me.oColUsers.Clear()
        Me.oColUsers = odbaccess.GetUsers(0)

        fillType()
        booloaded = True
    End Sub

    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click
        Dim boolError As Boolean
        Dim lNewId As Integer = 0
        Try
            If CheckValidation(Enumerators.EditAdd.Add) Then
                FillObject(Enumerators.EditAdd.Add)

                lNewId = odbaccess.InsertUser(oUser)
                If Not lNewId = 0 Then
                    MsgBox("Operation done successfully.")
                    oUser.Id = lNewId
                    oColUsers.Add(oUser)
                    Me.UsersTableAdapter.Fill(Me.DsUsers.users)

                    ResetForm()
                Else
                    MsgBox("Error occured!")
                End If
           
            End If


        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUser.Click
        Try
            Dim boolError As Boolean = True
            If CheckValidation(Enumerators.EditAdd.Edit) Then
                FillObject(Enumerators.EditAdd.Edit)

                boolError = odbaccess.EditUser(oUser)
                If boolError Then
                    MsgBox("Operation done successfully.")
                    Me.oColUsers = odbaccess.GetUsers(0)

                    ResetForm()
                Else
                    MsgBox("Error occured!")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtAddPasswrod2.Text = ""
        Me.txtAddPassword.Text = ""
        Me.txtAddUserName.Text = ""

    End Sub

    Public Function CheckValidation(ByVal enumAddEdit As Enumerators.EditAdd) As Boolean
        Dim boolError As Boolean = True
        If enumAddEdit = Enumerators.EditAdd.Add Then
            If txtAddUserName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtAddUserName, "Insert a valid UserName")
                boolError = False
            Else
                ErrorProvider1.SetError(txtAddUserName, "")
            End If

            If Me.txtAddPassword.Text.Length = 0 Then
                ErrorProvider1.SetError(txtAddPassword, "Insert a Password")
                boolError = False
            Else
                ErrorProvider1.SetError(txtAddPassword, "")
            End If

            If Me.txtAddPassword.Text <> Me.txtAddPasswrod2.Text Then
                ErrorProvider1.SetError(txtAddPasswrod2, "Passwords don't match.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtAddPasswrod2, "")
            End If
            If Me.cmbTypeAdd.SelectedItem Is Nothing Then
                ErrorProvider1.SetError(cmbTypeAdd, "Please choose user type from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbTypeAdd, "")
                If CType(Me.cmbTypeAdd.SelectedItem.value, Enumerators.UsersTypes) = Enumerators.UsersTypes.Provider Then
                    If Me.cmbProviderAdd.SelectedValue Is Nothing Then
                        ErrorProvider1.SetError(cmbProviderAdd, "Please choose user Provider from the list.")
                        boolError = False
                    Else
                        ErrorProvider1.SetError(cmbProviderAdd, "")
                    End If
                End If
            End If


        ElseIf enumAddEdit = Enumerators.EditAdd.Edit Then
            If txtEditUserName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtEditUserName, "Insert a valid UserName")
                boolError = False
            Else
                ErrorProvider1.SetError(txtEditUserName, "")
            End If

            If Me.txtEditPassword.Text.Length = 0 Then
                ErrorProvider1.SetError(txtEditPassword, "Insert a Password")
                boolError = False
            Else
                ErrorProvider1.SetError(txtEditPassword, "")
            End If

            If Me.txtEditPassword.Text <> Me.txtEditPassword2.Text Then
                ErrorProvider1.SetError(txtEditPassword2, "Passwords don't match.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtEditPassword2, "")
            End If

            If Me.cmbEditUserName.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbEditUserName, "Choose User from the list")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbEditUserName, "")
            End If

            If Me.cmbTypeEdit.SelectedItem Is Nothing Then
                ErrorProvider1.SetError(cmbTypeEdit, "Please choose user type from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbTypeEdit, "")
            End If

            If CType(Me.cmbTypeEdit.SelectedItem.value, Enumerators.UsersTypes) = Enumerators.UsersTypes.Provider Then
                If Me.cmbProviderEdit.SelectedValue Is Nothing Then
                    ErrorProvider1.SetError(cmbTypeEdit, "Please choose user Provider from the list.")
                    boolError = False
                Else
                    ErrorProvider1.SetError(cmbTypeEdit, "")
                End If
            End If
        End If

        Return boolError
    End Function

    Public Sub FillObject(ByVal enumAddEdit As Enumerators.EditAdd)
        oUser = New User
        'Dim oRole As Role
        'Dim oColRole As New ColRole
        If enumAddEdit = Enumerators.EditAdd.Add Then
            With oUser
                .UserName = Me.txtAddUserName.Text
                .Password = Me.txtAddPassword.Text
                .type = Me.cmbTypeAdd.SelectedItem.value
                If CType(Me.cmbTypeAdd.SelectedItem.value, Enumerators.UsersTypes) = Enumerators.UsersTypes.Provider Then
                    oUser.Provider = Me.cmbProviderAdd.SelectedValue
                Else
                    oUser.Provider = 0
                End If

            End With

        Else
            With oUser
                .Id = CLng(cmbEditUserName.SelectedValue)
                .UserName = Me.txtEditUserName.Text
                .Password = Me.txtEditPassword.Text
                .type = Me.cmbTypeEdit.SelectedItem.value
                If CType(Me.cmbTypeEdit.SelectedItem.value, Enumerators.UsersTypes) = Enumerators.UsersTypes.Provider Then
                    oUser.Provider = Me.cmbProviderEdit.SelectedValue
                Else
                    oUser.Provider = 0
                End If
            End With

        End If

    End Sub

  

    Private Sub cmbEditUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEditUserName.SelectedIndexChanged
        If booloaded Then
            For Each oUser As User In Me.oColUsers
                If oUser.Id = CLng(Me.cmbEditUserName.SelectedValue) Then
                    Me.oUser = oUser
                    Exit For
                End If
            Next

            Me.txtEditUserName.Text = Me.cmbEditUserName.Text
            Me.txtEditPassword.Text = oUser.Password
            Me.txtEditPassword2.Text = oUser.Password

            For i As Integer = 0 To Me.cmbTypeEdit.Items.Count - 1
                If Me.cmbTypeEdit.Items(i).value = oUser.type Then
                    Me.cmbTypeEdit.SelectedIndex = i
                    If CType(oUser.type, Enumerators.UsersTypes) = Enumerators.UsersTypes.Provider Then
                        Me.cmbProviderEdit.SelectedValue = oUser.Provider
                    End If
                    Exit For
                End If
            Next
            setRoles()

        End If


    End Sub

    Private Sub btnAddClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnEditClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub setRoles()



    End Sub

    Private Sub btnDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUser.Click
        If MsgBox("Are you sure you want to delete the selected User?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If odbaccess.DeleteUser(CLng(Me.cmbEditUserName.SelectedValue)) Then
                MsgBox("User deleted successfuly")
                Me.oColUsers.RemoveUser(CLng(Me.cmbEditUserName.SelectedValue))
                Me.UsersTableAdapter.Fill(Me.DsUsers.users)
            Else
                MsgBox("An Error Occured.")
            End If
        End If
    End Sub

    Private Sub cmbTypeEdit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeEdit.SelectedIndexChanged
        If Me.cmbTypeEdit.SelectedItem.name = "Provider" Then
            Me.cmbProviderEdit.Enabled = True
        Else
            Me.cmbProviderEdit.Enabled = False
        End If

    End Sub
    Public Sub FillType()
        Try
            Me.cmbTypeAdd.DataSource = Nothing

            Me.cmbTypeAdd.Items.Add(New Obj("Admin", Enumerators.UsersTypes.Admin))
            Me.cmbTypeAdd.Items.Add(New Obj("Audit", Enumerators.UsersTypes.Audit))
            Me.cmbTypeAdd.Items.Add(New Obj("Supervisor", Enumerators.UsersTypes.Supervisor))
            Me.cmbTypeAdd.Items.Add(New Obj("Cards User", Enumerators.UsersTypes.CardsUser))
            Me.cmbTypeAdd.Items.Add(New Obj("Provider", Enumerators.UsersTypes.Provider))
            Me.cmbTypeAdd.ValueMember = "Value"
            Me.cmbTypeAdd.DisplayMember = "Name"

            Me.cmbTypeEdit.DataSource = Nothing
            Me.cmbTypeEdit.Items.Add(New Obj("Admin", Enumerators.UsersTypes.Admin))
            Me.cmbTypeEdit.Items.Add(New Obj("Audit", Enumerators.UsersTypes.Audit))
            Me.cmbTypeEdit.Items.Add(New Obj("Supervisor", Enumerators.UsersTypes.Supervisor))
            Me.cmbTypeEdit.Items.Add(New Obj("Cards User", Enumerators.UsersTypes.CardsUser))
            Me.cmbTypeEdit.Items.Add(New Obj("Provider", Enumerators.UsersTypes.Provider))

            Me.cmbTypeEdit.ValueMember = "Value"
            Me.cmbTypeEdit.DisplayMember = "Name"

            Dim dsProviders As New DataSet
            dsProviders = odbaccess.GetProvidersDS
            If Not dsProviders Is Nothing AndAlso Not dsProviders.Tables.Count = 0 AndAlso Not dsProviders.Tables(0).Rows.Count = 0 Then
                Me.cmbProviderAdd.DataSource = dsProviders.Tables(0)
                Me.cmbProviderAdd.ValueMember = "ID"
                Me.cmbProviderAdd.DisplayMember = "Provider"

                Me.cmbProviderEdit.DataSource = dsProviders.Tables(0)
                Me.cmbProviderEdit.ValueMember = "ID"
                Me.cmbProviderEdit.DisplayMember = "Provider"
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbTypeAdd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeAdd.SelectedIndexChanged
        If Me.cmbTypeAdd.SelectedItem.name = "Provider" Then
            Me.cmbProviderAdd.Enabled = True
        Else
            Me.cmbProviderAdd.Enabled = False
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProviderEdit.SelectedIndexChanged

    End Sub
End Class
