<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSlotsInfoReport
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSlotsInfoReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBurnedFrom = New System.Windows.Forms.TextBox()
        Me.txtBurnedTo = New System.Windows.Forms.TextBox()
        Me.chkBurenedBalance = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtACDFrom = New System.Windows.Forms.TextBox()
        Me.txtASRFrom = New System.Windows.Forms.TextBox()
        Me.txtDurationFrom = New System.Windows.Forms.TextBox()
        Me.txtBalanceFrom = New System.Windows.Forms.TextBox()
        Me.txtDifferenceFrom = New System.Windows.Forms.TextBox()
        Me.txtTotalSimsFrom = New System.Windows.Forms.TextBox()
        Me.txtACDTo = New System.Windows.Forms.TextBox()
        Me.txtASRTo = New System.Windows.Forms.TextBox()
        Me.txtDurationTo = New System.Windows.Forms.TextBox()
        Me.txtBalanceTo = New System.Windows.Forms.TextBox()
        Me.txtDifferenceTo = New System.Windows.Forms.TextBox()
        Me.txtTotalSimsTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.chkSlot = New System.Windows.Forms.CheckBox()
        Me.cmbSlot = New System.Windows.Forms.ComboBox()
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSlots1 = New WindowsApplication1.dsSlots()
        Me.cmbTrafficType = New System.Windows.Forms.ComboBox()
        Me.chkACD = New System.Windows.Forms.CheckBox()
        Me.chkASR = New System.Windows.Forms.CheckBox()
        Me.chkDuration = New System.Windows.Forms.CheckBox()
        Me.chkBalance = New System.Windows.Forms.CheckBox()
        Me.chkDifference = New System.Windows.Forms.CheckBox()
        Me.chkTotalSims = New System.Windows.Forms.CheckBox()
        Me.chkTrafficType = New System.Windows.Forms.CheckBox()
        Me.cmbDevices = New System.Windows.Forms.ComboBox()
        Me.chkDevice = New System.Windows.Forms.CheckBox()
        Me.cmbOwner = New System.Windows.Forms.ComboBox()
        Me.cmbOperators = New System.Windows.Forms.ComboBox()
        Me.cmbHumanBehaiviour = New System.Windows.Forms.ComboBox()
        Me.cmbCountries = New System.Windows.Forms.ComboBox()
        Me.chkOwner = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkOperator = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkCountry = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkHumanBehaiviour = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTotalCalls = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalBalance = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotalDuration = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalSims = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dgDeviceSlotID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDeviceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCountry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgShift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDevice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSlot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgNoOfSims = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCreatedTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCreateNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgOffer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMinuteCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCutTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCutNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgBurnedBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgExpectedUsage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDifference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgOperator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTrafficType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgACD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgASR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTotalCalls = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgHumanBehaviour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgOwner = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataTable1TableAdapter1 = New WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSlots1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtBurnedFrom)
        Me.Panel1.Controls.Add(Me.txtBurnedTo)
        Me.Panel1.Controls.Add(Me.chkBurenedBalance)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtACDFrom)
        Me.Panel1.Controls.Add(Me.txtASRFrom)
        Me.Panel1.Controls.Add(Me.txtDurationFrom)
        Me.Panel1.Controls.Add(Me.txtBalanceFrom)
        Me.Panel1.Controls.Add(Me.txtDifferenceFrom)
        Me.Panel1.Controls.Add(Me.txtTotalSimsFrom)
        Me.Panel1.Controls.Add(Me.txtACDTo)
        Me.Panel1.Controls.Add(Me.txtASRTo)
        Me.Panel1.Controls.Add(Me.txtDurationTo)
        Me.Panel1.Controls.Add(Me.txtBalanceTo)
        Me.Panel1.Controls.Add(Me.txtDifferenceTo)
        Me.Panel1.Controls.Add(Me.txtTotalSimsTo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpToDate)
        Me.Panel1.Controls.Add(Me.dtpFromDate)
        Me.Panel1.Controls.Add(Me.chkDate)
        Me.Panel1.Controls.Add(Me.chkSlot)
        Me.Panel1.Controls.Add(Me.cmbSlot)
        Me.Panel1.Controls.Add(Me.cmbTrafficType)
        Me.Panel1.Controls.Add(Me.chkACD)
        Me.Panel1.Controls.Add(Me.chkASR)
        Me.Panel1.Controls.Add(Me.chkDuration)
        Me.Panel1.Controls.Add(Me.chkBalance)
        Me.Panel1.Controls.Add(Me.chkDifference)
        Me.Panel1.Controls.Add(Me.chkTotalSims)
        Me.Panel1.Controls.Add(Me.chkTrafficType)
        Me.Panel1.Controls.Add(Me.cmbDevices)
        Me.Panel1.Controls.Add(Me.chkDevice)
        Me.Panel1.Controls.Add(Me.cmbOwner)
        Me.Panel1.Controls.Add(Me.cmbOperators)
        Me.Panel1.Controls.Add(Me.cmbHumanBehaiviour)
        Me.Panel1.Controls.Add(Me.cmbCountries)
        Me.Panel1.Controls.Add(Me.chkOwner)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.chkOperator)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.chkCountry)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.chkHumanBehaiviour)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lblTotalCalls)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lblTotalBalance)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblTotalDuration)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblTotalSims)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1411, 658)
        Me.Panel1.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(898, 149)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 16)
        Me.Label18.TabIndex = 156
        Me.Label18.Text = "From"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(898, 121)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 16)
        Me.Label16.TabIndex = 155
        Me.Label16.Text = "From"
        '
        'txtBurnedFrom
        '
        Me.txtBurnedFrom.Enabled = False
        Me.txtBurnedFrom.Location = New System.Drawing.Point(937, 118)
        Me.txtBurnedFrom.Name = "txtBurnedFrom"
        Me.txtBurnedFrom.Size = New System.Drawing.Size(68, 23)
        Me.txtBurnedFrom.TabIndex = 154
        '
        'txtBurnedTo
        '
        Me.txtBurnedTo.Enabled = False
        Me.txtBurnedTo.Location = New System.Drawing.Point(1040, 118)
        Me.txtBurnedTo.Name = "txtBurnedTo"
        Me.txtBurnedTo.Size = New System.Drawing.Size(68, 23)
        Me.txtBurnedTo.TabIndex = 153
        '
        'chkBurenedBalance
        '
        Me.chkBurenedBalance.AutoSize = True
        Me.chkBurenedBalance.Location = New System.Drawing.Point(765, 119)
        Me.chkBurenedBalance.Name = "chkBurenedBalance"
        Me.chkBurenedBalance.Size = New System.Drawing.Size(127, 20)
        Me.chkBurenedBalance.TabIndex = 152
        Me.chkBurenedBalance.Text = "Burned Balance"
        Me.chkBurenedBalance.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1011, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 16)
        Me.Label17.TabIndex = 151
        Me.Label17.Text = "To"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(898, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 16)
        Me.Label14.TabIndex = 150
        Me.Label14.Text = "From"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(898, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 16)
        Me.Label13.TabIndex = 150
        Me.Label13.Text = "From"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(898, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 16)
        Me.Label12.TabIndex = 150
        Me.Label12.Text = "From"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(898, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 16)
        Me.Label11.TabIndex = 149
        Me.Label11.Text = "From"
        '
        'txtACDFrom
        '
        Me.txtACDFrom.Enabled = False
        Me.txtACDFrom.Location = New System.Drawing.Point(937, 62)
        Me.txtACDFrom.Name = "txtACDFrom"
        Me.txtACDFrom.Size = New System.Drawing.Size(68, 23)
        Me.txtACDFrom.TabIndex = 148
        '
        'txtASRFrom
        '
        Me.txtASRFrom.Enabled = False
        Me.txtASRFrom.Location = New System.Drawing.Point(937, 90)
        Me.txtASRFrom.Name = "txtASRFrom"
        Me.txtASRFrom.Size = New System.Drawing.Size(68, 23)
        Me.txtASRFrom.TabIndex = 148
        '
        'txtDurationFrom
        '
        Me.txtDurationFrom.Enabled = False
        Me.txtDurationFrom.Location = New System.Drawing.Point(937, 35)
        Me.txtDurationFrom.Name = "txtDurationFrom"
        Me.txtDurationFrom.Size = New System.Drawing.Size(68, 23)
        Me.txtDurationFrom.TabIndex = 148
        '
        'txtBalanceFrom
        '
        Me.txtBalanceFrom.Enabled = False
        Me.txtBalanceFrom.Location = New System.Drawing.Point(937, 7)
        Me.txtBalanceFrom.Name = "txtBalanceFrom"
        Me.txtBalanceFrom.Size = New System.Drawing.Size(68, 23)
        Me.txtBalanceFrom.TabIndex = 148
        '
        'txtDifferenceFrom
        '
        Me.txtDifferenceFrom.Enabled = False
        Me.txtDifferenceFrom.Location = New System.Drawing.Point(550, 130)
        Me.txtDifferenceFrom.Name = "txtDifferenceFrom"
        Me.txtDifferenceFrom.Size = New System.Drawing.Size(64, 23)
        Me.txtDifferenceFrom.TabIndex = 148
        '
        'txtTotalSimsFrom
        '
        Me.txtTotalSimsFrom.Enabled = False
        Me.txtTotalSimsFrom.Location = New System.Drawing.Point(550, 101)
        Me.txtTotalSimsFrom.Name = "txtTotalSimsFrom"
        Me.txtTotalSimsFrom.Size = New System.Drawing.Size(64, 23)
        Me.txtTotalSimsFrom.TabIndex = 148
        '
        'txtACDTo
        '
        Me.txtACDTo.Enabled = False
        Me.txtACDTo.Location = New System.Drawing.Point(1040, 62)
        Me.txtACDTo.Name = "txtACDTo"
        Me.txtACDTo.Size = New System.Drawing.Size(68, 23)
        Me.txtACDTo.TabIndex = 147
        '
        'txtASRTo
        '
        Me.txtASRTo.Enabled = False
        Me.txtASRTo.Location = New System.Drawing.Point(1040, 90)
        Me.txtASRTo.Name = "txtASRTo"
        Me.txtASRTo.Size = New System.Drawing.Size(68, 23)
        Me.txtASRTo.TabIndex = 147
        '
        'txtDurationTo
        '
        Me.txtDurationTo.Enabled = False
        Me.txtDurationTo.Location = New System.Drawing.Point(1040, 35)
        Me.txtDurationTo.Name = "txtDurationTo"
        Me.txtDurationTo.Size = New System.Drawing.Size(68, 23)
        Me.txtDurationTo.TabIndex = 147
        '
        'txtBalanceTo
        '
        Me.txtBalanceTo.Enabled = False
        Me.txtBalanceTo.Location = New System.Drawing.Point(1040, 7)
        Me.txtBalanceTo.Name = "txtBalanceTo"
        Me.txtBalanceTo.Size = New System.Drawing.Size(68, 23)
        Me.txtBalanceTo.TabIndex = 147
        '
        'txtDifferenceTo
        '
        Me.txtDifferenceTo.Enabled = False
        Me.txtDifferenceTo.Location = New System.Drawing.Point(642, 130)
        Me.txtDifferenceTo.Name = "txtDifferenceTo"
        Me.txtDifferenceTo.Size = New System.Drawing.Size(64, 23)
        Me.txtDifferenceTo.TabIndex = 147
        '
        'txtTotalSimsTo
        '
        Me.txtTotalSimsTo.Enabled = False
        Me.txtTotalSimsTo.Location = New System.Drawing.Point(642, 101)
        Me.txtTotalSimsTo.Name = "txtTotalSimsTo"
        Me.txtTotalSimsTo.Size = New System.Drawing.Size(64, 23)
        Me.txtTotalSimsTo.TabIndex = 147
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1147, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 16)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(1173, 146)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(201, 23)
        Me.dtpToDate.TabIndex = 142
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpFromDate.Enabled = False
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(937, 146)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(201, 23)
        Me.dtpFromDate.TabIndex = 143
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(765, 147)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(96, 20)
        Me.chkDate.TabIndex = 146
        Me.chkDate.Text = "Start Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'chkSlot
        '
        Me.chkSlot.AutoSize = True
        Me.chkSlot.Location = New System.Drawing.Point(421, 40)
        Me.chkSlot.Name = "chkSlot"
        Me.chkSlot.Size = New System.Drawing.Size(52, 20)
        Me.chkSlot.TabIndex = 141
        Me.chkSlot.Text = "Slot"
        Me.chkSlot.UseVisualStyleBackColor = True
        '
        'cmbSlot
        '
        Me.cmbSlot.DataSource = Me.DataTable1BindingSource
        Me.cmbSlot.DisplayMember = "Slot"
        Me.cmbSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSlot.Enabled = False
        Me.cmbSlot.FormattingEnabled = True
        Me.cmbSlot.Location = New System.Drawing.Point(525, 38)
        Me.cmbSlot.Name = "cmbSlot"
        Me.cmbSlot.Size = New System.Drawing.Size(182, 24)
        Me.cmbSlot.TabIndex = 140
        Me.cmbSlot.ValueMember = "ID"
        '
        'DataTable1BindingSource
        '
        Me.DataTable1BindingSource.DataMember = "DataTable1"
        Me.DataTable1BindingSource.DataSource = Me.DsSlots1
        '
        'DsSlots1
        '
        Me.DsSlots1.DataSetName = "dsSlots"
        Me.DsSlots1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbTrafficType
        '
        Me.cmbTrafficType.DisplayMember = "Name"
        Me.cmbTrafficType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrafficType.Enabled = False
        Me.cmbTrafficType.FormattingEnabled = True
        Me.cmbTrafficType.Location = New System.Drawing.Point(525, 68)
        Me.cmbTrafficType.Name = "cmbTrafficType"
        Me.cmbTrafficType.Size = New System.Drawing.Size(182, 24)
        Me.cmbTrafficType.TabIndex = 138
        Me.cmbTrafficType.ValueMember = "ID"
        '
        'chkACD
        '
        Me.chkACD.AutoSize = True
        Me.chkACD.Location = New System.Drawing.Point(765, 63)
        Me.chkACD.Name = "chkACD"
        Me.chkACD.Size = New System.Drawing.Size(54, 20)
        Me.chkACD.TabIndex = 139
        Me.chkACD.Text = "ACD"
        Me.chkACD.UseVisualStyleBackColor = True
        '
        'chkASR
        '
        Me.chkASR.AutoSize = True
        Me.chkASR.Location = New System.Drawing.Point(765, 91)
        Me.chkASR.Name = "chkASR"
        Me.chkASR.Size = New System.Drawing.Size(54, 20)
        Me.chkASR.TabIndex = 139
        Me.chkASR.Text = "ASR"
        Me.chkASR.UseVisualStyleBackColor = True
        '
        'chkDuration
        '
        Me.chkDuration.AutoSize = True
        Me.chkDuration.Location = New System.Drawing.Point(765, 36)
        Me.chkDuration.Name = "chkDuration"
        Me.chkDuration.Size = New System.Drawing.Size(83, 20)
        Me.chkDuration.TabIndex = 139
        Me.chkDuration.Text = "Duration"
        Me.chkDuration.UseVisualStyleBackColor = True
        '
        'chkBalance
        '
        Me.chkBalance.AutoSize = True
        Me.chkBalance.Location = New System.Drawing.Point(765, 8)
        Me.chkBalance.Name = "chkBalance"
        Me.chkBalance.Size = New System.Drawing.Size(77, 20)
        Me.chkBalance.TabIndex = 139
        Me.chkBalance.Text = "Balance"
        Me.chkBalance.UseVisualStyleBackColor = True
        '
        'chkDifference
        '
        Me.chkDifference.AutoSize = True
        Me.chkDifference.Location = New System.Drawing.Point(421, 131)
        Me.chkDifference.Name = "chkDifference"
        Me.chkDifference.Size = New System.Drawing.Size(94, 20)
        Me.chkDifference.TabIndex = 139
        Me.chkDifference.Text = "Difference"
        Me.chkDifference.UseVisualStyleBackColor = True
        '
        'chkTotalSims
        '
        Me.chkTotalSims.AutoSize = True
        Me.chkTotalSims.Location = New System.Drawing.Point(421, 102)
        Me.chkTotalSims.Name = "chkTotalSims"
        Me.chkTotalSims.Size = New System.Drawing.Size(127, 20)
        Me.chkTotalSims.TabIndex = 139
        Me.chkTotalSims.Text = "Total Sims From"
        Me.chkTotalSims.UseVisualStyleBackColor = True
        '
        'chkTrafficType
        '
        Me.chkTrafficType.AutoSize = True
        Me.chkTrafficType.Location = New System.Drawing.Point(421, 70)
        Me.chkTrafficType.Name = "chkTrafficType"
        Me.chkTrafficType.Size = New System.Drawing.Size(103, 20)
        Me.chkTrafficType.TabIndex = 139
        Me.chkTrafficType.Text = "Traffic Type"
        Me.chkTrafficType.UseVisualStyleBackColor = True
        '
        'cmbDevices
        '
        Me.cmbDevices.DisplayMember = "Name"
        Me.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevices.Enabled = False
        Me.cmbDevices.FormattingEnabled = True
        Me.cmbDevices.Location = New System.Drawing.Point(525, 7)
        Me.cmbDevices.Name = "cmbDevices"
        Me.cmbDevices.Size = New System.Drawing.Size(182, 24)
        Me.cmbDevices.TabIndex = 136
        Me.cmbDevices.ValueMember = "ID"
        '
        'chkDevice
        '
        Me.chkDevice.AutoSize = True
        Me.chkDevice.Location = New System.Drawing.Point(421, 9)
        Me.chkDevice.Name = "chkDevice"
        Me.chkDevice.Size = New System.Drawing.Size(70, 20)
        Me.chkDevice.TabIndex = 137
        Me.chkDevice.Text = "Device"
        Me.chkDevice.UseVisualStyleBackColor = True
        '
        'cmbOwner
        '
        Me.cmbOwner.DisplayMember = "Name"
        Me.cmbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOwner.Enabled = False
        Me.cmbOwner.FormattingEnabled = True
        Me.cmbOwner.Location = New System.Drawing.Point(149, 98)
        Me.cmbOwner.Name = "cmbOwner"
        Me.cmbOwner.Size = New System.Drawing.Size(215, 24)
        Me.cmbOwner.TabIndex = 131
        Me.cmbOwner.ValueMember = "ID"
        '
        'cmbOperators
        '
        Me.cmbOperators.DisplayMember = "Name"
        Me.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperators.Enabled = False
        Me.cmbOperators.FormattingEnabled = True
        Me.cmbOperators.Location = New System.Drawing.Point(149, 68)
        Me.cmbOperators.Name = "cmbOperators"
        Me.cmbOperators.Size = New System.Drawing.Size(215, 24)
        Me.cmbOperators.TabIndex = 130
        Me.cmbOperators.ValueMember = "ID"
        '
        'cmbHumanBehaiviour
        '
        Me.cmbHumanBehaiviour.DisplayMember = "Name"
        Me.cmbHumanBehaiviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHumanBehaiviour.Enabled = False
        Me.cmbHumanBehaiviour.FormattingEnabled = True
        Me.cmbHumanBehaiviour.Location = New System.Drawing.Point(148, 38)
        Me.cmbHumanBehaiviour.Name = "cmbHumanBehaiviour"
        Me.cmbHumanBehaiviour.Size = New System.Drawing.Size(216, 24)
        Me.cmbHumanBehaiviour.TabIndex = 128
        Me.cmbHumanBehaiviour.ValueMember = "ID"
        '
        'cmbCountries
        '
        Me.cmbCountries.DisplayMember = "Name"
        Me.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountries.Enabled = False
        Me.cmbCountries.FormattingEnabled = True
        Me.cmbCountries.Location = New System.Drawing.Point(148, 7)
        Me.cmbCountries.Name = "cmbCountries"
        Me.cmbCountries.Size = New System.Drawing.Size(216, 24)
        Me.cmbCountries.TabIndex = 129
        Me.cmbCountries.ValueMember = "ID"
        '
        'chkOwner
        '
        Me.chkOwner.AutoSize = True
        Me.chkOwner.Location = New System.Drawing.Point(7, 100)
        Me.chkOwner.Name = "chkOwner"
        Me.chkOwner.Size = New System.Drawing.Size(69, 20)
        Me.chkOwner.TabIndex = 134
        Me.chkOwner.Text = "Owner"
        Me.chkOwner.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1011, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 16)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "To"
        '
        'chkOperator
        '
        Me.chkOperator.AutoSize = True
        Me.chkOperator.Location = New System.Drawing.Point(7, 70)
        Me.chkOperator.Name = "chkOperator"
        Me.chkOperator.Size = New System.Drawing.Size(86, 20)
        Me.chkOperator.TabIndex = 135
        Me.chkOperator.Text = "Operator"
        Me.chkOperator.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1011, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 16)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "To"
        '
        'chkCountry
        '
        Me.chkCountry.AutoSize = True
        Me.chkCountry.Location = New System.Drawing.Point(7, 9)
        Me.chkCountry.Name = "chkCountry"
        Me.chkCountry.Size = New System.Drawing.Size(79, 20)
        Me.chkCountry.TabIndex = 132
        Me.chkCountry.Text = "Country"
        Me.chkCountry.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1011, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 16)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "To"
        '
        'chkHumanBehaiviour
        '
        Me.chkHumanBehaiviour.AutoSize = True
        Me.chkHumanBehaiviour.Location = New System.Drawing.Point(7, 40)
        Me.chkHumanBehaiviour.Name = "chkHumanBehaiviour"
        Me.chkHumanBehaiviour.Size = New System.Drawing.Size(140, 20)
        Me.chkHumanBehaiviour.TabIndex = 133
        Me.chkHumanBehaiviour.Text = "Human Behaviour"
        Me.chkHumanBehaiviour.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1011, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 16)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "To"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(617, 133)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 16)
        Me.Label15.TabIndex = 126
        Me.Label15.Text = "To"
        '
        'lblTotalCalls
        '
        Me.lblTotalCalls.AutoSize = True
        Me.lblTotalCalls.Location = New System.Drawing.Point(705, 164)
        Me.lblTotalCalls.Name = "lblTotalCalls"
        Me.lblTotalCalls.Size = New System.Drawing.Size(16, 16)
        Me.lblTotalCalls.TabIndex = 127
        Me.lblTotalCalls.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(617, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 16)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "To"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(631, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "Total Calls:"
        '
        'lblTotalBalance
        '
        Me.lblTotalBalance.AutoSize = True
        Me.lblTotalBalance.Location = New System.Drawing.Point(520, 164)
        Me.lblTotalBalance.Name = "lblTotalBalance"
        Me.lblTotalBalance.Size = New System.Drawing.Size(16, 16)
        Me.lblTotalBalance.TabIndex = 125
        Me.lblTotalBalance.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(425, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 16)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Total Balance:"
        '
        'lblTotalDuration
        '
        Me.lblTotalDuration.AutoSize = True
        Me.lblTotalDuration.Location = New System.Drawing.Point(302, 164)
        Me.lblTotalDuration.Name = "lblTotalDuration"
        Me.lblTotalDuration.Size = New System.Drawing.Size(16, 16)
        Me.lblTotalDuration.TabIndex = 123
        Me.lblTotalDuration.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Total Duration:"
        '
        'lblTotalSims
        '
        Me.lblTotalSims.AutoSize = True
        Me.lblTotalSims.Location = New System.Drawing.Point(80, 164)
        Me.lblTotalSims.Name = "lblTotalSims"
        Me.lblTotalSims.Size = New System.Drawing.Size(16, 16)
        Me.lblTotalSims.TabIndex = 121
        Me.lblTotalSims.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Total Sims:"
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgDeviceSlotID, Me.dgDeviceID, Me.dgCountry, Me.dgShift, Me.dgDevice, Me.dgSlot, Me.dgNoOfSims, Me.dgCreatedTime, Me.dgCreateNote, Me.dgStartTime, Me.dgOffer, Me.dgMinuteCost, Me.dgCutTime, Me.dgCutNote, Me.dgBurnedBalance, Me.dgBalance, Me.dgExpectedUsage, Me.dgDifference, Me.dgDuration, Me.dgOperator, Me.dgTrafficType, Me.dgACD, Me.dgASR, Me.dgTotalCalls, Me.dgHumanBehaviour, Me.dgOwner})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Location = New System.Drawing.Point(4, 193)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1403, 461)
        Me.DataGridView1.TabIndex = 37
        '
        'dgDeviceSlotID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgDeviceSlotID.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgDeviceSlotID.HeaderText = "DeviceSlotID"
        Me.dgDeviceSlotID.Name = "dgDeviceSlotID"
        Me.dgDeviceSlotID.ReadOnly = True
        Me.dgDeviceSlotID.Visible = False
        Me.dgDeviceSlotID.Width = 120
        '
        'dgDeviceID
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgDeviceID.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDeviceID.HeaderText = "DeviceID"
        Me.dgDeviceID.Name = "dgDeviceID"
        Me.dgDeviceID.ReadOnly = True
        Me.dgDeviceID.Visible = False
        Me.dgDeviceID.Width = 120
        '
        'dgCountry
        '
        Me.dgCountry.HeaderText = "Counrty"
        Me.dgCountry.Name = "dgCountry"
        Me.dgCountry.ReadOnly = True
        '
        'dgShift
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgShift.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgShift.HeaderText = "Shift"
        Me.dgShift.Name = "dgShift"
        Me.dgShift.ReadOnly = True
        Me.dgShift.Width = 80
        '
        'dgDevice
        '
        Me.dgDevice.HeaderText = "Device"
        Me.dgDevice.Name = "dgDevice"
        Me.dgDevice.ReadOnly = True
        '
        'dgSlot
        '
        Me.dgSlot.HeaderText = "Slot"
        Me.dgSlot.Name = "dgSlot"
        Me.dgSlot.ReadOnly = True
        Me.dgSlot.Width = 80
        '
        'dgNoOfSims
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgNoOfSims.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgNoOfSims.HeaderText = "No. Of Sims"
        Me.dgNoOfSims.Name = "dgNoOfSims"
        Me.dgNoOfSims.ReadOnly = True
        Me.dgNoOfSims.Width = 80
        '
        'dgCreatedTime
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgCreatedTime.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgCreatedTime.HeaderText = "Created Time"
        Me.dgCreatedTime.Name = "dgCreatedTime"
        Me.dgCreatedTime.ReadOnly = True
        Me.dgCreatedTime.Width = 140
        '
        'dgCreateNote
        '
        Me.dgCreateNote.HeaderText = "Create Note"
        Me.dgCreateNote.Name = "dgCreateNote"
        Me.dgCreateNote.ReadOnly = True
        '
        'dgStartTime
        '
        Me.dgStartTime.HeaderText = "Start Time"
        Me.dgStartTime.Name = "dgStartTime"
        Me.dgStartTime.ReadOnly = True
        Me.dgStartTime.Width = 140
        '
        'dgOffer
        '
        Me.dgOffer.HeaderText = "Offer"
        Me.dgOffer.Name = "dgOffer"
        Me.dgOffer.ReadOnly = True
        '
        'dgMinuteCost
        '
        Me.dgMinuteCost.HeaderText = "Minute Cost"
        Me.dgMinuteCost.Name = "dgMinuteCost"
        Me.dgMinuteCost.ReadOnly = True
        Me.dgMinuteCost.Width = 80
        '
        'dgCutTime
        '
        Me.dgCutTime.HeaderText = "Cut Time"
        Me.dgCutTime.Name = "dgCutTime"
        Me.dgCutTime.ReadOnly = True
        Me.dgCutTime.Width = 140
        '
        'dgCutNote
        '
        Me.dgCutNote.HeaderText = "Cut Note"
        Me.dgCutNote.Name = "dgCutNote"
        Me.dgCutNote.ReadOnly = True
        '
        'dgBurnedBalance
        '
        Me.dgBurnedBalance.HeaderText = "Burned Balance"
        Me.dgBurnedBalance.Name = "dgBurnedBalance"
        Me.dgBurnedBalance.ReadOnly = True
        '
        'dgBalance
        '
        Me.dgBalance.HeaderText = "Balance"
        Me.dgBalance.Name = "dgBalance"
        Me.dgBalance.ReadOnly = True
        '
        'dgExpectedUsage
        '
        Me.dgExpectedUsage.HeaderText = "Expected Usage"
        Me.dgExpectedUsage.Name = "dgExpectedUsage"
        Me.dgExpectedUsage.ReadOnly = True
        '
        'dgDifference
        '
        Me.dgDifference.HeaderText = "Difference"
        Me.dgDifference.Name = "dgDifference"
        Me.dgDifference.ReadOnly = True
        '
        'dgDuration
        '
        Me.dgDuration.HeaderText = "Duration"
        Me.dgDuration.Name = "dgDuration"
        Me.dgDuration.ReadOnly = True
        '
        'dgOperator
        '
        Me.dgOperator.HeaderText = "Operator"
        Me.dgOperator.Name = "dgOperator"
        Me.dgOperator.ReadOnly = True
        '
        'dgTrafficType
        '
        Me.dgTrafficType.HeaderText = "Traffic Type"
        Me.dgTrafficType.Name = "dgTrafficType"
        Me.dgTrafficType.ReadOnly = True
        '
        'dgACD
        '
        Me.dgACD.HeaderText = "ACD"
        Me.dgACD.Name = "dgACD"
        Me.dgACD.ReadOnly = True
        '
        'dgASR
        '
        Me.dgASR.HeaderText = "ASR"
        Me.dgASR.Name = "dgASR"
        Me.dgASR.ReadOnly = True
        '
        'dgTotalCalls
        '
        Me.dgTotalCalls.HeaderText = "Total Calls"
        Me.dgTotalCalls.Name = "dgTotalCalls"
        Me.dgTotalCalls.ReadOnly = True
        '
        'dgHumanBehaviour
        '
        Me.dgHumanBehaviour.HeaderText = "Human Behaviour"
        Me.dgHumanBehaviour.Name = "dgHumanBehaviour"
        Me.dgHumanBehaviour.ReadOnly = True
        '
        'dgOwner
        '
        Me.dgOwner.HeaderText = "Owner"
        Me.dgOwner.Name = "dgOwner"
        Me.dgOwner.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(126, 26)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1271, 7)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 34)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
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
        'DataTable1TableAdapter1
        '
        Me.DataTable1TableAdapter1.ClearBeforeFill = True
        '
        'frmSlotsInfoReport
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1412, 663)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSlotsInfoReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Device Performance Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSlots1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DsShifts As WindowsApplication1.dsShifts
    Friend WithEvents ShiftsTableAdapter As WindowsApplication1.dsShiftsTableAdapters.shiftsTableAdapter
    Friend WithEvents dgDeviceSlotID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgDeviceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCountry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShift As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgDevice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgSlot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgNoOfSims As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCreatedTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCreateNote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgOffer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMinuteCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCutNote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgBurnedBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgExpectedUsage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgDifference As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgOperator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgTrafficType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgACD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgASR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgTotalCalls As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgHumanBehaviour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgOwner As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotalCalls As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalBalance As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotalDuration As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalSims As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOwner As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperators As System.Windows.Forms.ComboBox
    Friend WithEvents cmbHumanBehaiviour As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCountries As System.Windows.Forms.ComboBox
    Friend WithEvents chkOwner As System.Windows.Forms.CheckBox
    Friend WithEvents chkOperator As System.Windows.Forms.CheckBox
    Friend WithEvents chkCountry As System.Windows.Forms.CheckBox
    Friend WithEvents chkHumanBehaiviour As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDevices As System.Windows.Forms.ComboBox
    Friend WithEvents chkDevice As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTrafficType As System.Windows.Forms.ComboBox
    Friend WithEvents chkTrafficType As System.Windows.Forms.CheckBox
    Friend WithEvents chkSlot As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSlot As System.Windows.Forms.ComboBox
    Friend WithEvents txtACDFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtASRFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtDurationFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtBalanceFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSimsFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtACDTo As System.Windows.Forms.TextBox
    Friend WithEvents txtASRTo As System.Windows.Forms.TextBox
    Friend WithEvents txtDurationTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBalanceTo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSimsTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkACD As System.Windows.Forms.CheckBox
    Friend WithEvents chkASR As System.Windows.Forms.CheckBox
    Friend WithEvents chkDuration As System.Windows.Forms.CheckBox
    Friend WithEvents chkBalance As System.Windows.Forms.CheckBox
    Friend WithEvents chkTotalSims As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DsSlots As WindowsApplication1.dsSlots
    Friend WithEvents DataTable1TableAdapter As WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter
    Friend WithEvents DsSlots1 As WindowsApplication1.dsSlots
    Friend WithEvents DataTable1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataTable1TableAdapter1 As WindowsApplication1.dsSlotsTableAdapters.DataTable1TableAdapter
    Friend WithEvents txtDifferenceFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtDifferenceTo As System.Windows.Forms.TextBox
    Friend WithEvents chkDifference As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBurnedFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtBurnedTo As System.Windows.Forms.TextBox
    Friend WithEvents chkBurenedBalance As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
