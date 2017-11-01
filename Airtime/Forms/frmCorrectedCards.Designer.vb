<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorrectedCards
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCorrectedCards))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCardNumber = New System.Windows.Forms.TextBox()
        Me.chkCard = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.cmbOperators = New System.Windows.Forms.ComboBox()
        Me.cmbProviders = New System.Windows.Forms.ComboBox()
        Me.cmbCountries = New System.Windows.Forms.ComboBox()
        Me.chkLocation = New System.Windows.Forms.CheckBox()
        Me.chkCategory = New System.Windows.Forms.CheckBox()
        Me.chkOperator = New System.Windows.Forms.CheckBox()
        Me.chkCountry = New System.Windows.Forms.CheckBox()
        Me.chkProvider = New System.Windows.Forms.CheckBox()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnGetUsers = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUsers = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtSelectNo = New System.Windows.Forms.TextBox()
        Me.chkClearAll = New System.Windows.Forms.CheckBox()
        Me.btnSendCards = New System.Windows.Forms.Button()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operatorww = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDevices = New System.Windows.Forms.ComboBox()
        Me.chkDevice = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripHideColumn.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbDevices)
        Me.Panel1.Controls.Add(Me.chkDevice)
        Me.Panel1.Controls.Add(Me.txtCardNumber)
        Me.Panel1.Controls.Add(Me.chkCard)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpToDate)
        Me.Panel1.Controls.Add(Me.dtpFromDate)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbLocation)
        Me.Panel1.Controls.Add(Me.cmbCategory)
        Me.Panel1.Controls.Add(Me.cmbOperators)
        Me.Panel1.Controls.Add(Me.cmbProviders)
        Me.Panel1.Controls.Add(Me.cmbCountries)
        Me.Panel1.Controls.Add(Me.chkLocation)
        Me.Panel1.Controls.Add(Me.chkCategory)
        Me.Panel1.Controls.Add(Me.chkOperator)
        Me.Panel1.Controls.Add(Me.chkCountry)
        Me.Panel1.Controls.Add(Me.chkProvider)
        Me.Panel1.Controls.Add(Me.chkDate)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1159, 472)
        Me.Panel1.TabIndex = 0
        '
        'txtCardNumber
        '
        Me.txtCardNumber.Enabled = False
        Me.txtCardNumber.Location = New System.Drawing.Point(440, 70)
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.Size = New System.Drawing.Size(214, 23)
        Me.txtCardNumber.TabIndex = 138
        '
        'chkCard
        '
        Me.chkCard.AutoSize = True
        Me.chkCard.Location = New System.Drawing.Point(334, 72)
        Me.chkCard.Name = "chkCard"
        Me.chkCard.Size = New System.Drawing.Size(101, 20)
        Me.chkCard.TabIndex = 137
        Me.chkCard.Text = "Scratch No."
        Me.chkCard.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(410, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(441, 111)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(213, 23)
        Me.dtpToDate.TabIndex = 132
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpFromDate.Enabled = False
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(193, 111)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(200, 23)
        Me.dtpFromDate.TabIndex = 133
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "From"
        '
        'cmbLocation
        '
        Me.cmbLocation.DisplayMember = "ID"
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocation.Enabled = False
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(440, 42)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(214, 24)
        Me.cmbLocation.TabIndex = 124
        Me.cmbLocation.ValueMember = "ID"
        '
        'cmbCategory
        '
        Me.cmbCategory.DisplayMember = "Name"
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.Enabled = False
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(440, 14)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(214, 24)
        Me.cmbCategory.TabIndex = 125
        Me.cmbCategory.ValueMember = "ID"
        '
        'cmbOperators
        '
        Me.cmbOperators.DisplayMember = "Name"
        Me.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperators.Enabled = False
        Me.cmbOperators.FormattingEnabled = True
        Me.cmbOperators.Location = New System.Drawing.Point(94, 70)
        Me.cmbOperators.Name = "cmbOperators"
        Me.cmbOperators.Size = New System.Drawing.Size(215, 24)
        Me.cmbOperators.TabIndex = 123
        Me.cmbOperators.ValueMember = "ID"
        '
        'cmbProviders
        '
        Me.cmbProviders.DisplayMember = "Name"
        Me.cmbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProviders.Enabled = False
        Me.cmbProviders.FormattingEnabled = True
        Me.cmbProviders.Location = New System.Drawing.Point(94, 42)
        Me.cmbProviders.Name = "cmbProviders"
        Me.cmbProviders.Size = New System.Drawing.Size(216, 24)
        Me.cmbProviders.TabIndex = 121
        Me.cmbProviders.ValueMember = "ID"
        '
        'cmbCountries
        '
        Me.cmbCountries.DisplayMember = "Name"
        Me.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountries.Enabled = False
        Me.cmbCountries.FormattingEnabled = True
        Me.cmbCountries.Location = New System.Drawing.Point(94, 14)
        Me.cmbCountries.Name = "cmbCountries"
        Me.cmbCountries.Size = New System.Drawing.Size(216, 24)
        Me.cmbCountries.TabIndex = 122
        Me.cmbCountries.ValueMember = "ID"
        '
        'chkLocation
        '
        Me.chkLocation.AutoSize = True
        Me.chkLocation.Location = New System.Drawing.Point(334, 44)
        Me.chkLocation.Name = "chkLocation"
        Me.chkLocation.Size = New System.Drawing.Size(82, 20)
        Me.chkLocation.TabIndex = 129
        Me.chkLocation.Text = "Location"
        Me.chkLocation.UseVisualStyleBackColor = True
        '
        'chkCategory
        '
        Me.chkCategory.AutoSize = True
        Me.chkCategory.Location = New System.Drawing.Point(334, 16)
        Me.chkCategory.Name = "chkCategory"
        Me.chkCategory.Size = New System.Drawing.Size(87, 20)
        Me.chkCategory.TabIndex = 131
        Me.chkCategory.Text = "Category"
        Me.chkCategory.UseVisualStyleBackColor = True
        '
        'chkOperator
        '
        Me.chkOperator.AutoSize = True
        Me.chkOperator.Location = New System.Drawing.Point(9, 72)
        Me.chkOperator.Name = "chkOperator"
        Me.chkOperator.Size = New System.Drawing.Size(86, 20)
        Me.chkOperator.TabIndex = 128
        Me.chkOperator.Text = "Operator"
        Me.chkOperator.UseVisualStyleBackColor = True
        '
        'chkCountry
        '
        Me.chkCountry.AutoSize = True
        Me.chkCountry.Location = New System.Drawing.Point(9, 16)
        Me.chkCountry.Name = "chkCountry"
        Me.chkCountry.Size = New System.Drawing.Size(79, 20)
        Me.chkCountry.TabIndex = 126
        Me.chkCountry.Text = "Country"
        Me.chkCountry.UseVisualStyleBackColor = True
        '
        'chkProvider
        '
        Me.chkProvider.AutoSize = True
        Me.chkProvider.Location = New System.Drawing.Point(9, 44)
        Me.chkProvider.Name = "chkProvider"
        Me.chkProvider.Size = New System.Drawing.Size(82, 20)
        Me.chkProvider.TabIndex = 127
        Me.chkProvider.Text = "Provider"
        Me.chkProvider.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(10, 112)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(154, 20)
        Me.chkDate.TabIndex = 136
        Me.chkDate.Text = "Card inserted date:"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnGetUsers)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbUsers)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.txtSelectNo)
        Me.Panel2.Controls.Add(Me.chkClearAll)
        Me.Panel2.Controls.Add(Me.btnSendCards)
        Me.Panel2.Controls.Add(Me.chkSelectAll)
        Me.Panel2.Location = New System.Drawing.Point(734, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(417, 84)
        Me.Panel2.TabIndex = 101
        Me.Panel2.Visible = False
        '
        'btnGetUsers
        '
        Me.btnGetUsers.Location = New System.Drawing.Point(219, 48)
        Me.btnGetUsers.Name = "btnGetUsers"
        Me.btnGetUsers.Size = New System.Drawing.Size(43, 23)
        Me.btnGetUsers.TabIndex = 139
        Me.btnGetUsers.Text = "Get"
        Me.btnGetUsers.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Send to:"
        '
        'cmbUsers
        '
        Me.cmbUsers.DisplayMember = "Name"
        Me.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsers.FormattingEnabled = True
        Me.cmbUsers.Location = New System.Drawing.Point(72, 47)
        Me.cmbUsers.Name = "cmbUsers"
        Me.cmbUsers.Size = New System.Drawing.Size(141, 24)
        Me.cmbUsers.TabIndex = 102
        Me.cmbUsers.ValueMember = "ID"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(8, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 23)
        Me.Button2.TabIndex = 102
        Me.Button2.Text = "Select"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtSelectNo
        '
        Me.txtSelectNo.Location = New System.Drawing.Point(91, 12)
        Me.txtSelectNo.Name = "txtSelectNo"
        Me.txtSelectNo.Size = New System.Drawing.Size(39, 23)
        Me.txtSelectNo.TabIndex = 61
        Me.txtSelectNo.Text = "0"
        '
        'chkClearAll
        '
        Me.chkClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkClearAll.AutoSize = True
        Me.chkClearAll.BackColor = System.Drawing.Color.Transparent
        Me.chkClearAll.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearAll.Location = New System.Drawing.Point(336, 15)
        Me.chkClearAll.Name = "chkClearAll"
        Me.chkClearAll.Size = New System.Drawing.Size(72, 17)
        Me.chkClearAll.TabIndex = 59
        Me.chkClearAll.Text = "Clear All"
        Me.chkClearAll.UseVisualStyleBackColor = False
        '
        'btnSendCards
        '
        Me.btnSendCards.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendCards.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendCards.Location = New System.Drawing.Point(280, 44)
        Me.btnSendCards.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSendCards.Name = "btnSendCards"
        Me.btnSendCards.Size = New System.Drawing.Size(131, 31)
        Me.btnSendCards.TabIndex = 60
        Me.btnSendCards.Tag = ""
        Me.btnSendCards.Text = "Send Cards"
        Me.btnSendCards.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.chkSelectAll.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelectAll.Location = New System.Drawing.Point(242, 15)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(78, 17)
        Me.chkSelectAll.TabIndex = 58
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(926, 8)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 33)
        Me.Button1.TabIndex = 88
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.Column8, Me.clNo, Me.Column1, Me.Category, Me.Column3, Me.Operatorww, Me.Column2, Me.Column4, Me.Column7, Me.Column6, Me.Column9, Me.Column5, Me.Column10})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView1.Location = New System.Drawing.Point(4, 153)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1151, 315)
        Me.DataGridView1.TabIndex = 37
        '
        'clID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clID.DefaultCellStyle = DataGridViewCellStyle2
        Me.clID.HeaderText = "ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        Me.clID.Visible = False
        Me.clID.Width = 80
        '
        'Column8
        '
        Me.Column8.HeaderText = "Send"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 55
        '
        'clNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.clNo.HeaderText = "No."
        Me.clNo.Name = "clNo"
        Me.clNo.ReadOnly = True
        Me.clNo.Width = 40
        '
        'Column1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column1.HeaderText = "Scratch No."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 220
        '
        'Category
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle5
        Me.Category.HeaderText = "Country"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 120
        '
        'Column3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column3.HeaderText = "Provider"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Operatorww
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Operatorww.DefaultCellStyle = DataGridViewCellStyle7
        Me.Operatorww.HeaderText = "Operator"
        Me.Operatorww.Name = "Operatorww"
        Me.Operatorww.ReadOnly = True
        Me.Operatorww.Width = 150
        '
        'Column2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column2.HeaderText = "Category"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Insert Date"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column7.HeaderText = "Insert Time"
        Me.Column7.Name = "Column7"
        '
        'Column6
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column6.HeaderText = "Recieved Using"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Set as Wrong Date"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 150
        '
        'Column5
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column5.HeaderText = "Corrected By"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Corrected Date"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 150
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1019, 7)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 34)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHistoryToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 54)
        '
        'ShowHistoryToolStripMenuItem
        '
        Me.ShowHistoryToolStripMenuItem.Name = "ShowHistoryToolStripMenuItem"
        Me.ShowHistoryToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ShowHistoryToolStripMenuItem.Text = "Show Card History"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'ContextMenuStripHideColumn
        '
        Me.ContextMenuStripHideColumn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideColumnToolStripMenuItem, Me.ShowAllColumnsToolStripMenuItem})
        Me.ContextMenuStripHideColumn.Name = "ContextMenuStripHideColumn"
        Me.ContextMenuStripHideColumn.Size = New System.Drawing.Size(172, 48)
        '
        'HideColumnToolStripMenuItem
        '
        Me.HideColumnToolStripMenuItem.Name = "HideColumnToolStripMenuItem"
        Me.HideColumnToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.HideColumnToolStripMenuItem.Text = "Hide Column"
        '
        'ShowAllColumnsToolStripMenuItem
        '
        Me.ShowAllColumnsToolStripMenuItem.Name = "ShowAllColumnsToolStripMenuItem"
        Me.ShowAllColumnsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ShowAllColumnsToolStripMenuItem.Text = "Show All Columns"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(683, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 16)
        Me.Label4.TabIndex = 140
        '
        'cmbDevices
        '
        Me.cmbDevices.DisplayMember = "Name"
        Me.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevices.Enabled = False
        Me.cmbDevices.FormattingEnabled = True
        Me.cmbDevices.Location = New System.Drawing.Point(748, 14)
        Me.cmbDevices.Name = "cmbDevices"
        Me.cmbDevices.Size = New System.Drawing.Size(141, 24)
        Me.cmbDevices.TabIndex = 139
        Me.cmbDevices.ValueMember = "ID"
        '
        'chkDevice
        '
        Me.chkDevice.AutoSize = True
        Me.chkDevice.Location = New System.Drawing.Point(679, 16)
        Me.chkDevice.Name = "chkDevice"
        Me.chkDevice.Size = New System.Drawing.Size(70, 20)
        Me.chkDevice.TabIndex = 141
        Me.chkDevice.Text = "Device"
        Me.chkDevice.UseVisualStyleBackColor = True
        '
        'frmCorrectedCards
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1163, 477)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCorrectedCards"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corrected Cards"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripHideColumn.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripHideColumn As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtSelectNo As System.Windows.Forms.TextBox
    Friend WithEvents chkClearAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnSendCards As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbUsers As System.Windows.Forms.ComboBox
    Friend WithEvents ShowHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents chkCard As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperators As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProviders As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCountries As System.Windows.Forms.ComboBox
    Friend WithEvents chkLocation As System.Windows.Forms.CheckBox
    Friend WithEvents chkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents chkOperator As System.Windows.Forms.CheckBox
    Friend WithEvents chkCountry As System.Windows.Forms.CheckBox
    Friend WithEvents chkProvider As System.Windows.Forms.CheckBox
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operatorww As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnGetUsers As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbDevices As System.Windows.Forms.ComboBox
    Friend WithEvents chkDevice As System.Windows.Forms.CheckBox

End Class
