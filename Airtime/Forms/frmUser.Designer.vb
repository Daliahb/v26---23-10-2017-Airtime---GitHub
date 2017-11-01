<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbProviderAdd = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbTypeAdd = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.txtAddUserName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAddPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddPasswrod2 = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbProviderEdit = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbTypeEdit = New System.Windows.Forms.ComboBox()
        Me.btnDeleteUser = New System.Windows.Forms.Button()
        Me.btnEditUser = New System.Windows.Forms.Button()
        Me.cmbEditUserName = New System.Windows.Forms.ComboBox()
        Me.UsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsUsers = New WindowsApplication1.dsUsers()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEditPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEditUserName = New System.Windows.Forms.TextBox()
        Me.txtEditPassword2 = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CardsresourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UsersTableAdapter = New WindowsApplication1.dsUsersTableAdapters.usersTableAdapter()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardsresourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(550, 196)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.txtAddUserName)
        Me.TabPage1.Controls.Add(Me.txtAddPassword)
        Me.TabPage1.Controls.Add(Me.txtAddPasswrod2)
        Me.TabPage1.Controls.Add(Me.cmbProviderAdd)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cmbTypeAdd)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.btnAddUser)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(542, 167)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Add User"
        '
        'cmbProviderAdd
        '
        Me.cmbProviderAdd.DisplayMember = "Name"
        Me.cmbProviderAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProviderAdd.Enabled = False
        Me.cmbProviderAdd.FormattingEnabled = True
        Me.cmbProviderAdd.Location = New System.Drawing.Point(385, 74)
        Me.cmbProviderAdd.Name = "cmbProviderAdd"
        Me.cmbProviderAdd.Size = New System.Drawing.Size(152, 24)
        Me.cmbProviderAdd.TabIndex = 34
        Me.cmbProviderAdd.ValueMember = "ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(320, 78)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 16)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Provider"
        '
        'cmbTypeAdd
        '
        Me.cmbTypeAdd.DisplayMember = "Name"
        Me.cmbTypeAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeAdd.FormattingEnabled = True
        Me.cmbTypeAdd.Location = New System.Drawing.Point(81, 74)
        Me.cmbTypeAdd.Name = "cmbTypeAdd"
        Me.cmbTypeAdd.Size = New System.Drawing.Size(152, 24)
        Me.cmbTypeAdd.TabIndex = 32
        Me.cmbTypeAdd.ValueMember = "ID"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 78)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Type"
        '
        'btnAddUser
        '
        Me.btnAddUser.Location = New System.Drawing.Point(234, 125)
        Me.btnAddUser.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(74, 28)
        Me.btnAddUser.TabIndex = 24
        Me.btnAddUser.Text = "Save"
        Me.btnAddUser.UseVisualStyleBackColor = True
        '
        'txtAddUserName
        '
        Me.txtAddUserName.Location = New System.Drawing.Point(83, 14)
        Me.txtAddUserName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddUserName.Name = "txtAddUserName"
        Me.txtAddUserName.Size = New System.Drawing.Size(151, 23)
        Me.txtAddUserName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 13)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "User Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 47)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Password"
        '
        'txtAddPassword
        '
        Me.txtAddPassword.Location = New System.Drawing.Point(82, 44)
        Me.txtAddPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddPassword.Name = "txtAddPassword"
        Me.txtAddPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAddPassword.Size = New System.Drawing.Size(151, 23)
        Me.txtAddPassword.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(250, 47)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Re-Enter Password"
        '
        'txtAddPasswrod2
        '
        Me.txtAddPasswrod2.Location = New System.Drawing.Point(385, 44)
        Me.txtAddPasswrod2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddPasswrod2.Name = "txtAddPasswrod2"
        Me.txtAddPasswrod2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAddPasswrod2.Size = New System.Drawing.Size(151, 23)
        Me.txtAddPasswrod2.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.cmbProviderEdit)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.cmbTypeEdit)
        Me.TabPage2.Controls.Add(Me.btnDeleteUser)
        Me.TabPage2.Controls.Add(Me.btnEditUser)
        Me.TabPage2.Controls.Add(Me.cmbEditUserName)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtEditPassword)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtEditUserName)
        Me.TabPage2.Controls.Add(Me.txtEditPassword2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(542, 167)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit User"
        '
        'cmbProviderEdit
        '
        Me.cmbProviderEdit.DisplayMember = "Name"
        Me.cmbProviderEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProviderEdit.Enabled = False
        Me.cmbProviderEdit.FormattingEnabled = True
        Me.cmbProviderEdit.Location = New System.Drawing.Point(387, 70)
        Me.cmbProviderEdit.Name = "cmbProviderEdit"
        Me.cmbProviderEdit.Size = New System.Drawing.Size(145, 24)
        Me.cmbProviderEdit.TabIndex = 36
        Me.cmbProviderEdit.ValueMember = "ID"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(319, 74)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Provider"
        '
        'cmbTypeEdit
        '
        Me.cmbTypeEdit.DisplayMember = "Name"
        Me.cmbTypeEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeEdit.FormattingEnabled = True
        Me.cmbTypeEdit.Location = New System.Drawing.Point(80, 69)
        Me.cmbTypeEdit.Name = "cmbTypeEdit"
        Me.cmbTypeEdit.Size = New System.Drawing.Size(152, 24)
        Me.cmbTypeEdit.TabIndex = 30
        Me.cmbTypeEdit.ValueMember = "ID"
        '
        'btnDeleteUser
        '
        Me.btnDeleteUser.Location = New System.Drawing.Point(273, 121)
        Me.btnDeleteUser.Name = "btnDeleteUser"
        Me.btnDeleteUser.Size = New System.Drawing.Size(102, 28)
        Me.btnDeleteUser.TabIndex = 18
        Me.btnDeleteUser.Text = "Delete User"
        Me.btnDeleteUser.UseVisualStyleBackColor = True
        '
        'btnEditUser
        '
        Me.btnEditUser.Location = New System.Drawing.Point(186, 121)
        Me.btnEditUser.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(82, 28)
        Me.btnEditUser.TabIndex = 16
        Me.btnEditUser.Text = "Save"
        Me.btnEditUser.UseVisualStyleBackColor = True
        '
        'cmbEditUserName
        '
        Me.cmbEditUserName.DataSource = Me.UsersBindingSource
        Me.cmbEditUserName.DisplayMember = "Username"
        Me.cmbEditUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEditUserName.FormattingEnabled = True
        Me.cmbEditUserName.Location = New System.Drawing.Point(80, 9)
        Me.cmbEditUserName.Name = "cmbEditUserName"
        Me.cmbEditUserName.Size = New System.Drawing.Size(152, 24)
        Me.cmbEditUserName.TabIndex = 0
        Me.cmbEditUserName.ValueMember = "ID"
        '
        'UsersBindingSource
        '
        Me.UsersBindingSource.DataMember = "users"
        Me.UsersBindingSource.DataSource = Me.DsUsers
        '
        'DsUsers
        '
        Me.DsUsers.DataSetName = "dsUsers"
        Me.DsUsers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(305, 13)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "User Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 13)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 71)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Password"
        '
        'txtEditPassword
        '
        Me.txtEditPassword.Location = New System.Drawing.Point(80, 39)
        Me.txtEditPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditPassword.Name = "txtEditPassword"
        Me.txtEditPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEditPassword.Size = New System.Drawing.Size(152, 23)
        Me.txtEditPassword.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(249, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Re-Enter Password"
        '
        'txtEditUserName
        '
        Me.txtEditUserName.Location = New System.Drawing.Point(387, 10)
        Me.txtEditUserName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditUserName.Name = "txtEditUserName"
        Me.txtEditUserName.Size = New System.Drawing.Size(145, 23)
        Me.txtEditUserName.TabIndex = 0
        '
        'txtEditPassword2
        '
        Me.txtEditPassword2.Location = New System.Drawing.Point(387, 40)
        Me.txtEditPassword2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditPassword2.Name = "txtEditPassword2"
        Me.txtEditPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEditPassword2.Size = New System.Drawing.Size(145, 23)
        Me.txtEditPassword2.TabIndex = 2
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UsersTableAdapter
        '
        Me.UsersTableAdapter.ClearBeforeFill = True
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(554, 205)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit Users"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardsresourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtAddUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAddPasswrod2 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmbEditUserName As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEditPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEditUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtEditPassword2 As System.Windows.Forms.TextBox
    '  Friend WithEvents DsUsers As Tempo.dsUsers
    '  Friend WithEvents UsersTableAdapter As Tempo.dsUsersTableAdapters.UsersTableAdapter
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnAddUser As System.Windows.Forms.Button
    Friend WithEvents btnDeleteUser As System.Windows.Forms.Button
    Friend WithEvents btnEditUser As System.Windows.Forms.Button
    Friend WithEvents cmbTypeEdit As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTypeAdd As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    ' Friend WithEvents DsUser As CardsSystem.dsUser
    'Friend WithEvents UsersTableAdapter As CardsSystem.dsUserTableAdapters.usersTableAdapter
    Friend WithEvents cmbProviderAdd As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbProviderEdit As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CardsresourcesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsUsers As WindowsApplication1.dsUsers
    Friend WithEvents UsersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsersTableAdapter As WindowsApplication1.dsUsersTableAdapters.usersTableAdapter

End Class
