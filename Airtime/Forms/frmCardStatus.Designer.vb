<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardStatus
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCardStatus))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCardNumber = New System.Windows.Forms.TextBox()
        Me.chkCard = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpInstToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpInstFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpUsedToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpUsecFromDate = New System.Windows.Forms.DateTimePicker()
        Me.chkInsertedDate = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkUsedDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbUsed = New System.Windows.Forms.RadioButton()
        Me.rbNotUsed = New System.Windows.Forms.RadioButton()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.chkCheckDistribute = New System.Windows.Forms.CheckBox()
        Me.chkWrong = New System.Windows.Forms.CheckBox()
        Me.chkCorrected = New System.Windows.Forms.CheckBox()
        Me.chkDeleted = New System.Windows.Forms.CheckBox()
        Me.chkCheckUsed = New System.Windows.Forms.CheckBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.cmbOperators = New System.Windows.Forms.ComboBox()
        Me.cmbProviders = New System.Windows.Forms.ComboBox()
        Me.cmbCountries = New System.Windows.Forms.ComboBox()
        Me.chkCategory = New System.Windows.Forms.CheckBox()
        Me.chkOperator = New System.Windows.Forms.CheckBox()
        Me.chkCountry = New System.Windows.Forms.CheckBox()
        Me.chkProvider = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbDistributed = New System.Windows.Forms.RadioButton()
        Me.rbNotDistributed = New System.Windows.Forms.RadioButton()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operatorww = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStripHideColumn.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtCardNumber)
        Me.Panel1.Controls.Add(Me.chkCard)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpInstToDate)
        Me.Panel1.Controls.Add(Me.dtpInstFromDate)
        Me.Panel1.Controls.Add(Me.dtpUsedToDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpUsecFromDate)
        Me.Panel1.Controls.Add(Me.chkInsertedDate)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.chkUsedDate)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.chkCheckDistribute)
        Me.Panel1.Controls.Add(Me.chkWrong)
        Me.Panel1.Controls.Add(Me.chkCorrected)
        Me.Panel1.Controls.Add(Me.chkDeleted)
        Me.Panel1.Controls.Add(Me.chkCheckUsed)
        Me.Panel1.Controls.Add(Me.cmbCategory)
        Me.Panel1.Controls.Add(Me.cmbOperators)
        Me.Panel1.Controls.Add(Me.cmbProviders)
        Me.Panel1.Controls.Add(Me.cmbCountries)
        Me.Panel1.Controls.Add(Me.chkCategory)
        Me.Panel1.Controls.Add(Me.chkOperator)
        Me.Panel1.Controls.Add(Me.chkCountry)
        Me.Panel1.Controls.Add(Me.chkProvider)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1205, 737)
        Me.Panel1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 16)
        Me.Label5.TabIndex = 117
        '
        'txtCardNumber
        '
        Me.txtCardNumber.Enabled = False
        Me.txtCardNumber.Location = New System.Drawing.Point(99, 114)
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.Size = New System.Drawing.Size(189, 23)
        Me.txtCardNumber.TabIndex = 115
        '
        'chkCard
        '
        Me.chkCard.AutoSize = True
        Me.chkCard.Location = New System.Drawing.Point(3, 116)
        Me.chkCard.Name = "chkCard"
        Me.chkCard.Size = New System.Drawing.Size(101, 20)
        Me.chkCard.TabIndex = 114
        Me.chkCard.Text = "Scratch No."
        Me.chkCard.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(839, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 16)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(839, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "To"
        '
        'dtpInstToDate
        '
        Me.dtpInstToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpInstToDate.Enabled = False
        Me.dtpInstToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstToDate.Location = New System.Drawing.Point(862, 35)
        Me.dtpInstToDate.Name = "dtpInstToDate"
        Me.dtpInstToDate.Size = New System.Drawing.Size(213, 23)
        Me.dtpInstToDate.TabIndex = 109
        '
        'dtpInstFromDate
        '
        Me.dtpInstFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpInstFromDate.Enabled = False
        Me.dtpInstFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstFromDate.Location = New System.Drawing.Point(862, 10)
        Me.dtpInstFromDate.Name = "dtpInstFromDate"
        Me.dtpInstFromDate.Size = New System.Drawing.Size(213, 23)
        Me.dtpInstFromDate.TabIndex = 110
        '
        'dtpUsedToDate
        '
        Me.dtpUsedToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpUsedToDate.Enabled = False
        Me.dtpUsedToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpUsedToDate.Location = New System.Drawing.Point(862, 102)
        Me.dtpUsedToDate.Name = "dtpUsedToDate"
        Me.dtpUsedToDate.Size = New System.Drawing.Size(213, 23)
        Me.dtpUsedToDate.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(825, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "From"
        '
        'dtpUsecFromDate
        '
        Me.dtpUsecFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpUsecFromDate.Enabled = False
        Me.dtpUsecFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpUsecFromDate.Location = New System.Drawing.Point(862, 77)
        Me.dtpUsecFromDate.Name = "dtpUsecFromDate"
        Me.dtpUsecFromDate.Size = New System.Drawing.Size(213, 23)
        Me.dtpUsecFromDate.TabIndex = 110
        '
        'chkInsertedDate
        '
        Me.chkInsertedDate.AutoSize = True
        Me.chkInsertedDate.Location = New System.Drawing.Point(708, 12)
        Me.chkInsertedDate.Name = "chkInsertedDate"
        Me.chkInsertedDate.Size = New System.Drawing.Size(122, 20)
        Me.chkInsertedDate.TabIndex = 113
        Me.chkInsertedDate.Text = "Inserted date:"
        Me.chkInsertedDate.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(825, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "From"
        '
        'chkUsedDate
        '
        Me.chkUsedDate.AutoSize = True
        Me.chkUsedDate.Location = New System.Drawing.Point(708, 79)
        Me.chkUsedDate.Name = "chkUsedDate"
        Me.chkUsedDate.Size = New System.Drawing.Size(97, 20)
        Me.chkUsedDate.TabIndex = 113
        Me.chkUsedDate.Text = "Used date:"
        Me.chkUsedDate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbUsed)
        Me.GroupBox1.Controls.Add(Me.rbNotUsed)
        Me.GroupBox1.Controls.Add(Me.CheckBox9)
        Me.GroupBox1.Controls.Add(Me.CheckBox10)
        Me.GroupBox1.Controls.Add(Me.CheckBox11)
        Me.GroupBox1.Controls.Add(Me.CheckBox12)
        Me.GroupBox1.Location = New System.Drawing.Point(425, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 33)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        '
        'rbUsed
        '
        Me.rbUsed.AutoSize = True
        Me.rbUsed.Enabled = False
        Me.rbUsed.Location = New System.Drawing.Point(5, 11)
        Me.rbUsed.Name = "rbUsed"
        Me.rbUsed.Size = New System.Drawing.Size(57, 20)
        Me.rbUsed.TabIndex = 0
        Me.rbUsed.Text = "Used"
        Me.rbUsed.UseVisualStyleBackColor = True
        '
        'rbNotUsed
        '
        Me.rbNotUsed.AutoSize = True
        Me.rbNotUsed.Enabled = False
        Me.rbNotUsed.Location = New System.Drawing.Point(105, 11)
        Me.rbNotUsed.Name = "rbNotUsed"
        Me.rbNotUsed.Size = New System.Drawing.Size(83, 20)
        Me.rbNotUsed.TabIndex = 1
        Me.rbNotUsed.Text = "Not used"
        Me.rbNotUsed.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(-95, 6)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(70, 20)
        Me.CheckBox9.TabIndex = 106
        Me.CheckBox9.Text = "Status"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(-95, -70)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(118, 20)
        Me.CheckBox10.TabIndex = 106
        Me.CheckBox10.Text = "Deleted Cards"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(-95, -45)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(133, 20)
        Me.CheckBox11.TabIndex = 106
        Me.CheckBox11.Text = "Corrected Cards"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(-95, -20)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(111, 20)
        Me.CheckBox12.TabIndex = 106
        Me.CheckBox12.Text = "Wrong Cards"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'chkCheckDistribute
        '
        Me.chkCheckDistribute.AutoSize = True
        Me.chkCheckDistribute.Location = New System.Drawing.Point(343, 120)
        Me.chkCheckDistribute.Name = "chkCheckDistribute"
        Me.chkCheckDistribute.Size = New System.Drawing.Size(82, 20)
        Me.chkCheckDistribute.TabIndex = 106
        Me.chkCheckDistribute.Text = "Status 2"
        Me.chkCheckDistribute.UseVisualStyleBackColor = True
        '
        'chkWrong
        '
        Me.chkWrong.AutoSize = True
        Me.chkWrong.Location = New System.Drawing.Point(343, 62)
        Me.chkWrong.Name = "chkWrong"
        Me.chkWrong.Size = New System.Drawing.Size(111, 20)
        Me.chkWrong.TabIndex = 106
        Me.chkWrong.Text = "Wrong Cards"
        Me.chkWrong.UseVisualStyleBackColor = True
        '
        'chkCorrected
        '
        Me.chkCorrected.AutoSize = True
        Me.chkCorrected.Location = New System.Drawing.Point(343, 36)
        Me.chkCorrected.Name = "chkCorrected"
        Me.chkCorrected.Size = New System.Drawing.Size(133, 20)
        Me.chkCorrected.TabIndex = 106
        Me.chkCorrected.Text = "Corrected Cards"
        Me.chkCorrected.UseVisualStyleBackColor = True
        '
        'chkDeleted
        '
        Me.chkDeleted.AutoSize = True
        Me.chkDeleted.Location = New System.Drawing.Point(343, 11)
        Me.chkDeleted.Name = "chkDeleted"
        Me.chkDeleted.Size = New System.Drawing.Size(118, 20)
        Me.chkDeleted.TabIndex = 106
        Me.chkDeleted.Text = "Deleted Cards"
        Me.chkDeleted.UseVisualStyleBackColor = True
        '
        'chkCheckUsed
        '
        Me.chkCheckUsed.AutoSize = True
        Me.chkCheckUsed.Location = New System.Drawing.Point(343, 88)
        Me.chkCheckUsed.Name = "chkCheckUsed"
        Me.chkCheckUsed.Size = New System.Drawing.Size(82, 20)
        Me.chkCheckUsed.TabIndex = 106
        Me.chkCheckUsed.Text = "Status 1"
        Me.chkCheckUsed.UseVisualStyleBackColor = True
        '
        'cmbCategory
        '
        Me.cmbCategory.DisplayMember = "Name"
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.Enabled = False
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(99, 87)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(189, 24)
        Me.cmbCategory.TabIndex = 96
        Me.cmbCategory.ValueMember = "ID"
        '
        'cmbOperators
        '
        Me.cmbOperators.DisplayMember = "Name"
        Me.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperators.Enabled = False
        Me.cmbOperators.FormattingEnabled = True
        Me.cmbOperators.Location = New System.Drawing.Point(99, 61)
        Me.cmbOperators.Name = "cmbOperators"
        Me.cmbOperators.Size = New System.Drawing.Size(189, 24)
        Me.cmbOperators.TabIndex = 95
        Me.cmbOperators.ValueMember = "ID"
        '
        'cmbProviders
        '
        Me.cmbProviders.DisplayMember = "Name"
        Me.cmbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProviders.Enabled = False
        Me.cmbProviders.FormattingEnabled = True
        Me.cmbProviders.Location = New System.Drawing.Point(99, 35)
        Me.cmbProviders.Name = "cmbProviders"
        Me.cmbProviders.Size = New System.Drawing.Size(190, 24)
        Me.cmbProviders.TabIndex = 91
        Me.cmbProviders.ValueMember = "ID"
        '
        'cmbCountries
        '
        Me.cmbCountries.DisplayMember = "Name"
        Me.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountries.Enabled = False
        Me.cmbCountries.FormattingEnabled = True
        Me.cmbCountries.Location = New System.Drawing.Point(99, 9)
        Me.cmbCountries.Name = "cmbCountries"
        Me.cmbCountries.Size = New System.Drawing.Size(190, 24)
        Me.cmbCountries.TabIndex = 92
        Me.cmbCountries.ValueMember = "ID"
        '
        'chkCategory
        '
        Me.chkCategory.AutoSize = True
        Me.chkCategory.Location = New System.Drawing.Point(3, 90)
        Me.chkCategory.Name = "chkCategory"
        Me.chkCategory.Size = New System.Drawing.Size(87, 20)
        Me.chkCategory.TabIndex = 98
        Me.chkCategory.Text = "Category"
        Me.chkCategory.UseVisualStyleBackColor = True
        '
        'chkOperator
        '
        Me.chkOperator.AutoSize = True
        Me.chkOperator.Location = New System.Drawing.Point(3, 63)
        Me.chkOperator.Name = "chkOperator"
        Me.chkOperator.Size = New System.Drawing.Size(86, 20)
        Me.chkOperator.TabIndex = 98
        Me.chkOperator.Text = "Operator"
        Me.chkOperator.UseVisualStyleBackColor = True
        '
        'chkCountry
        '
        Me.chkCountry.AutoSize = True
        Me.chkCountry.Location = New System.Drawing.Point(3, 11)
        Me.chkCountry.Name = "chkCountry"
        Me.chkCountry.Size = New System.Drawing.Size(79, 20)
        Me.chkCountry.TabIndex = 98
        Me.chkCountry.Text = "Country"
        Me.chkCountry.UseVisualStyleBackColor = True
        '
        'chkProvider
        '
        Me.chkProvider.AutoSize = True
        Me.chkProvider.Location = New System.Drawing.Point(3, 37)
        Me.chkProvider.Name = "chkProvider"
        Me.chkProvider.Size = New System.Drawing.Size(82, 20)
        Me.chkProvider.TabIndex = 98
        Me.chkProvider.Text = "Provider"
        Me.chkProvider.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.clNo, Me.Column1, Me.Category, Me.Column3, Me.Operatorww, Me.Column2, Me.Column4, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column6})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.Location = New System.Drawing.Point(4, 161)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1198, 573)
        Me.DataGridView1.TabIndex = 37
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHistoryToolStripMenuItem, Me.DeleteCardToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 76)
        '
        'ShowHistoryToolStripMenuItem
        '
        Me.ShowHistoryToolStripMenuItem.Name = "ShowHistoryToolStripMenuItem"
        Me.ShowHistoryToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ShowHistoryToolStripMenuItem.Text = "Show Card History"
        '
        'DeleteCardToolStripMenuItem
        '
        Me.DeleteCardToolStripMenuItem.Name = "DeleteCardToolStripMenuItem"
        Me.DeleteCardToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.DeleteCardToolStripMenuItem.Text = "Delete Cards"
        Me.DeleteCardToolStripMenuItem.Visible = False
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
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1082, 10)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(119, 30)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbDistributed)
        Me.GroupBox2.Controls.Add(Me.rbNotDistributed)
        Me.GroupBox2.Location = New System.Drawing.Point(425, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 33)
        Me.GroupBox2.TabIndex = 105
        Me.GroupBox2.TabStop = False
        '
        'rbDistributed
        '
        Me.rbDistributed.AutoSize = True
        Me.rbDistributed.Location = New System.Drawing.Point(5, 11)
        Me.rbDistributed.Name = "rbDistributed"
        Me.rbDistributed.Size = New System.Drawing.Size(98, 20)
        Me.rbDistributed.TabIndex = 0
        Me.rbDistributed.Text = "Distributed"
        Me.rbDistributed.UseVisualStyleBackColor = True
        '
        'rbNotDistributed
        '
        Me.rbNotDistributed.AutoSize = True
        Me.rbNotDistributed.Location = New System.Drawing.Point(105, 11)
        Me.rbNotDistributed.Name = "rbNotDistributed"
        Me.rbNotDistributed.Size = New System.Drawing.Size(124, 20)
        Me.rbNotDistributed.TabIndex = 1
        Me.rbNotDistributed.Text = "Not Distributed"
        Me.rbNotDistributed.UseVisualStyleBackColor = True
        '
        'ShowAllColumnsToolStripMenuItem
        '
        Me.ShowAllColumnsToolStripMenuItem.Name = "ShowAllColumnsToolStripMenuItem"
        Me.ShowAllColumnsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ShowAllColumnsToolStripMenuItem.Text = "Show All Columns"
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
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
        Me.Column1.Width = 200
        '
        'Category
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle5
        Me.Category.HeaderText = "Country"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 150
        '
        'Column3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column3.HeaderText = "Provider"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 140
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
        Me.Column2.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "Got it from"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Inserted By"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 120
        '
        'Column9
        '
        Me.Column9.HeaderText = "Inserted Date"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 120
        '
        'Column10
        '
        Me.Column10.HeaderText = "Distributed?"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column11
        '
        Me.Column11.HeaderText = "Distributed to"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 120
        '
        'Column12
        '
        Me.Column12.HeaderText = "Distribution date"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 120
        '
        'Column13
        '
        Me.Column13.HeaderText = "Used?"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column13.Width = 80
        '
        'Column14
        '
        Me.Column14.HeaderText = "Used Date"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 120
        '
        'Column15
        '
        Me.Column15.HeaderText = "Wrong Card?"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column15.Width = 80
        '
        'Column16
        '
        Me.Column16.HeaderText = "Wrong Card Type"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 110
        '
        'Column17
        '
        Me.Column17.HeaderText = "Set as wrong by"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 120
        '
        'Column18
        '
        Me.Column18.HeaderText = "Set as wrong date"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 120
        '
        'Column19
        '
        Me.Column19.HeaderText = "Corrected?"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column19.Width = 80
        '
        'Column20
        '
        Me.Column20.HeaderText = "Corrected by"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        Me.Column20.Width = 120
        '
        'Column21
        '
        Me.Column21.HeaderText = "Corrected date"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        Me.Column21.Width = 120
        '
        'Column22
        '
        Me.Column22.HeaderText = "Device"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        Me.Column22.Width = 110
        '
        'Column6
        '
        Me.Column6.HeaderText = "Deleted?"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column6.Width = 80
        '
        'frmCardStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1208, 740)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCardStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cards Status"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStripHideColumn.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents chkCard As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpInstToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInstFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpUsedToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpUsecFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkInsertedDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkUsedDate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbUsed As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotUsed As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckDistribute As System.Windows.Forms.CheckBox
    Friend WithEvents chkWrong As System.Windows.Forms.CheckBox
    Friend WithEvents chkCorrected As System.Windows.Forms.CheckBox
    Friend WithEvents chkDeleted As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckUsed As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperators As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProviders As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCountries As System.Windows.Forms.ComboBox
    Friend WithEvents chkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents chkOperator As System.Windows.Forms.CheckBox
    Friend WithEvents chkCountry As System.Windows.Forms.CheckBox
    Friend WithEvents chkProvider As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDistributed As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotDistributed As System.Windows.Forms.RadioButton
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripHideColumn As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operatorww As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
