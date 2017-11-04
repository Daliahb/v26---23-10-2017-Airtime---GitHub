<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUseCards
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUseCards))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelCardsUser = New System.Windows.Forms.Panel()
        Me.chkSelectClear = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbAlreadyUsedCard = New System.Windows.Forms.RadioButton()
        Me.rbWrongValue = New System.Windows.Forms.RadioButton()
        Me.rbWrongName = New System.Windows.Forms.RadioButton()
        Me.btnSetAsWrongCard = New System.Windows.Forms.Button()
        Me.btnSetAsUsed = New System.Windows.Forms.Button()
        Me.lblExceedLimit = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgOnHold = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRefreshTable = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnPutOnHold = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCardsNo = New System.Windows.Forms.Label()
        Me.txtCardNumber = New System.Windows.Forms.TextBox()
        Me.btnGetCard = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetAsUsedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WrongScratchNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlreadyUsedCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewDisableButtonColumn1 = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.DataGridViewDisableButtonColumn2 = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.DataGridViewDisableButtonColumn3 = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.DataGridViewDisableButtonColumn4 = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.DataGridViewDisableButtonColumn5 = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.DataGridViewDisableButtonColumn6 = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.DataGridViewDisableButtonColumn7 = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgOldBtn = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.dgHoldBtn = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.dgCreateBtn = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.dgGetBtn = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.dgStartBtn = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.dgCutBtn = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.dgAddSimsBtn = New WindowsApplication1.DataGridViewDisableButtonColumn()
        Me.dgDeviceSlotID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSlot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCardsUser.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgOnHold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PanelCardsUser
        '
        Me.PanelCardsUser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelCardsUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCardsUser.Controls.Add(Me.chkSelectClear)
        Me.PanelCardsUser.Controls.Add(Me.Label5)
        Me.PanelCardsUser.Controls.Add(Me.Panel3)
        Me.PanelCardsUser.Controls.Add(Me.lblExceedLimit)
        Me.PanelCardsUser.Controls.Add(Me.Label4)
        Me.PanelCardsUser.Controls.Add(Me.dgOnHold)
        Me.PanelCardsUser.Controls.Add(Me.btnRefreshTable)
        Me.PanelCardsUser.Controls.Add(Me.DataGridView1)
        Me.PanelCardsUser.Controls.Add(Me.btnPutOnHold)
        Me.PanelCardsUser.Controls.Add(Me.Label1)
        Me.PanelCardsUser.Controls.Add(Me.Label3)
        Me.PanelCardsUser.Controls.Add(Me.lblCardsNo)
        Me.PanelCardsUser.Controls.Add(Me.txtCardNumber)
        Me.PanelCardsUser.Controls.Add(Me.btnGetCard)
        Me.PanelCardsUser.Location = New System.Drawing.Point(5, 9)
        Me.PanelCardsUser.Name = "PanelCardsUser"
        Me.PanelCardsUser.Size = New System.Drawing.Size(1498, 699)
        Me.PanelCardsUser.TabIndex = 21
        '
        'chkSelectClear
        '
        Me.chkSelectClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSelectClear.AutoSize = True
        Me.chkSelectClear.Location = New System.Drawing.Point(1121, 516)
        Me.chkSelectClear.Name = "chkSelectClear"
        Me.chkSelectClear.Size = New System.Drawing.Size(128, 20)
        Me.chkSelectClear.TabIndex = 119
        Me.chkSelectClear.Text = "Select/Clear All"
        Me.chkSelectClear.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "Availale cards:"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.btnSetAsUsed)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(694, 557)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(563, 144)
        Me.Panel3.TabIndex = 117
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.rbAlreadyUsedCard)
        Me.Panel1.Controls.Add(Me.rbWrongValue)
        Me.Panel1.Controls.Add(Me.rbWrongName)
        Me.Panel1.Controls.Add(Me.btnSetAsWrongCard)
        Me.Panel1.Location = New System.Drawing.Point(7, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 90)
        Me.Panel1.TabIndex = 118
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmbCategory)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(132, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(216, 35)
        Me.Panel2.TabIndex = 113
        '
        'cmbCategory
        '
        Me.cmbCategory.DisplayMember = "Name"
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(128, 5)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(82, 24)
        Me.cmbCategory.TabIndex = 110
        Me.cmbCategory.ValueMember = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-2, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 16)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "*Right category is:"
        '
        'rbAlreadyUsedCard
        '
        Me.rbAlreadyUsedCard.AutoSize = True
        Me.rbAlreadyUsedCard.Location = New System.Drawing.Point(3, 57)
        Me.rbAlreadyUsedCard.Name = "rbAlreadyUsedCard"
        Me.rbAlreadyUsedCard.Size = New System.Drawing.Size(149, 20)
        Me.rbAlreadyUsedCard.TabIndex = 111
        Me.rbAlreadyUsedCard.Text = "Already used card."
        Me.rbAlreadyUsedCard.UseVisualStyleBackColor = True
        '
        'rbWrongValue
        '
        Me.rbWrongValue.AutoSize = True
        Me.rbWrongValue.Location = New System.Drawing.Point(3, 31)
        Me.rbWrongValue.Name = "rbWrongValue"
        Me.rbWrongValue.Size = New System.Drawing.Size(112, 20)
        Me.rbWrongValue.TabIndex = 110
        Me.rbWrongValue.Text = "Wrong value."
        Me.rbWrongValue.UseVisualStyleBackColor = True
        '
        'rbWrongName
        '
        Me.rbWrongName.AutoSize = True
        Me.rbWrongName.Checked = True
        Me.rbWrongName.Location = New System.Drawing.Point(3, 6)
        Me.rbWrongName.Name = "rbWrongName"
        Me.rbWrongName.Size = New System.Drawing.Size(179, 20)
        Me.rbWrongName.TabIndex = 109
        Me.rbWrongName.TabStop = True
        Me.rbWrongName.Text = "Wrong scratch number."
        Me.rbWrongName.UseVisualStyleBackColor = True
        '
        'btnSetAsWrongCard
        '
        Me.btnSetAsWrongCard.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetAsWrongCard.Location = New System.Drawing.Point(397, 26)
        Me.btnSetAsWrongCard.Name = "btnSetAsWrongCard"
        Me.btnSetAsWrongCard.Size = New System.Drawing.Size(145, 38)
        Me.btnSetAsWrongCard.TabIndex = 108
        Me.btnSetAsWrongCard.Text = "Set as wrong card"
        Me.btnSetAsWrongCard.UseVisualStyleBackColor = True
        '
        'btnSetAsUsed
        '
        Me.btnSetAsUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetAsUsed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetAsUsed.Location = New System.Drawing.Point(406, 3)
        Me.btnSetAsUsed.Name = "btnSetAsUsed"
        Me.btnSetAsUsed.Size = New System.Drawing.Size(145, 38)
        Me.btnSetAsUsed.TabIndex = 117
        Me.btnSetAsUsed.Text = "Set as used"
        Me.btnSetAsUsed.UseVisualStyleBackColor = True
        '
        'lblExceedLimit
        '
        Me.lblExceedLimit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExceedLimit.AutoSize = True
        Me.lblExceedLimit.ForeColor = System.Drawing.Color.DarkRed
        Me.lblExceedLimit.Location = New System.Drawing.Point(5, 516)
        Me.lblExceedLimit.Name = "lblExceedLimit"
        Me.lblExceedLimit.Size = New System.Drawing.Size(50, 16)
        Me.lblExceedLimit.TabIndex = 113
        Me.lblExceedLimit.Text = "Label4"
        Me.lblExceedLimit.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1254, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "On hold cards:"
        '
        'dgOnHold
        '
        Me.dgOnHold.AllowUserToAddRows = False
        Me.dgOnHold.AllowUserToDeleteRows = False
        Me.dgOnHold.AllowUserToOrderColumns = True
        Me.dgOnHold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOnHold.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOnHold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOnHold.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column8, Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOnHold.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgOnHold.Location = New System.Drawing.Point(1257, 25)
        Me.dgOnHold.Margin = New System.Windows.Forms.Padding(4)
        Me.dgOnHold.Name = "dgOnHold"
        Me.dgOnHold.RowHeadersVisible = False
        Me.dgOnHold.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgOnHold.Size = New System.Drawing.Size(231, 669)
        Me.dgOnHold.TabIndex = 114
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 15
        '
        'Column8
        '
        Me.Column8.HeaderText = ""
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 30
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "Scratch Number"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 180
        '
        'btnRefreshTable
        '
        Me.btnRefreshTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshTable.Location = New System.Drawing.Point(1037, 458)
        Me.btnRefreshTable.Name = "btnRefreshTable"
        Me.btnRefreshTable.Size = New System.Drawing.Size(116, 39)
        Me.btnRefreshTable.TabIndex = 107
        Me.btnRefreshTable.Text = "Refresh table"
        Me.btnRefreshTable.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.clID, Me.Column3, Me.clNo, Me.Category, Me.Column2, Me.Column4, Me.Column6, Me.Column7, Me.Column5, Me.dgOldBtn, Me.dgHoldBtn, Me.dgCreateBtn, Me.dgGetBtn, Me.dgStartBtn, Me.dgCutBtn, Me.dgAddSimsBtn, Me.dgDeviceSlotID, Me.dgSlot})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridView1.Location = New System.Drawing.Point(3, 25)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1149, 426)
        Me.DataGridView1.TabIndex = 110
        '
        'btnPutOnHold
        '
        Me.btnPutOnHold.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPutOnHold.Enabled = False
        Me.btnPutOnHold.Location = New System.Drawing.Point(300, 481)
        Me.btnPutOnHold.Name = "btnPutOnHold"
        Me.btnPutOnHold.Size = New System.Drawing.Size(145, 31)
        Me.btnPutOnHold.TabIndex = 110
        Me.btnPutOnHold.Text = "Put On Hold"
        Me.btnPutOnHold.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 460)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "You have"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 460)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "new cards."
        '
        'lblCardsNo
        '
        Me.lblCardsNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCardsNo.AutoSize = True
        Me.lblCardsNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardsNo.Location = New System.Drawing.Point(73, 460)
        Me.lblCardsNo.Name = "lblCardsNo"
        Me.lblCardsNo.Size = New System.Drawing.Size(32, 16)
        Me.lblCardsNo.TabIndex = 15
        Me.lblCardsNo.Text = "999"
        Me.lblCardsNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCardNumber
        '
        Me.txtCardNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCardNumber.Location = New System.Drawing.Point(7, 484)
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.ReadOnly = True
        Me.txtCardNumber.Size = New System.Drawing.Size(204, 23)
        Me.txtCardNumber.TabIndex = 1
        '
        'btnGetCard
        '
        Me.btnGetCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGetCard.Enabled = False
        Me.btnGetCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetCard.Location = New System.Drawing.Point(217, 481)
        Me.btnGetCard.Name = "btnGetCard"
        Me.btnGetCard.Size = New System.Drawing.Size(77, 31)
        Me.btnGetCard.TabIndex = 0
        Me.btnGetCard.Text = "Get Card"
        Me.btnGetCard.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetAsUsedToolStripMenuItem, Me.WrongScratchNumberToolStripMenuItem, Me.AlreadyUsedCardToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(197, 70)
        '
        'SetAsUsedToolStripMenuItem
        '
        Me.SetAsUsedToolStripMenuItem.Name = "SetAsUsedToolStripMenuItem"
        Me.SetAsUsedToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.SetAsUsedToolStripMenuItem.Text = "Set as used"
        '
        'WrongScratchNumberToolStripMenuItem
        '
        Me.WrongScratchNumberToolStripMenuItem.Name = "WrongScratchNumberToolStripMenuItem"
        Me.WrongScratchNumberToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.WrongScratchNumberToolStripMenuItem.Text = "Wrong scratch number"
        '
        'AlreadyUsedCardToolStripMenuItem
        '
        Me.AlreadyUsedCardToolStripMenuItem.Name = "AlreadyUsedCardToolStripMenuItem"
        Me.AlreadyUsedCardToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.AlreadyUsedCardToolStripMenuItem.Text = "Already used card"
        '
        'DataGridViewDisableButtonColumn1
        '
        Me.DataGridViewDisableButtonColumn1.HeaderText = "Old"
        Me.DataGridViewDisableButtonColumn1.Name = "DataGridViewDisableButtonColumn1"
        Me.DataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewDisableButtonColumn1.Width = 60
        '
        'DataGridViewDisableButtonColumn2
        '
        Me.DataGridViewDisableButtonColumn2.HeaderText = "Hold"
        Me.DataGridViewDisableButtonColumn2.Name = "DataGridViewDisableButtonColumn2"
        Me.DataGridViewDisableButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewDisableButtonColumn2.Width = 60
        '
        'DataGridViewDisableButtonColumn3
        '
        Me.DataGridViewDisableButtonColumn3.HeaderText = "New Slot"
        Me.DataGridViewDisableButtonColumn3.Name = "DataGridViewDisableButtonColumn3"
        Me.DataGridViewDisableButtonColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewDisableButtonColumn3.Width = 90
        '
        'DataGridViewDisableButtonColumn4
        '
        Me.DataGridViewDisableButtonColumn4.HeaderText = "Get"
        Me.DataGridViewDisableButtonColumn4.Name = "DataGridViewDisableButtonColumn4"
        Me.DataGridViewDisableButtonColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn4.Width = 50
        '
        'DataGridViewDisableButtonColumn5
        '
        Me.DataGridViewDisableButtonColumn5.HeaderText = "Start"
        Me.DataGridViewDisableButtonColumn5.Name = "DataGridViewDisableButtonColumn5"
        Me.DataGridViewDisableButtonColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewDisableButtonColumn5.Width = 50
        '
        'DataGridViewDisableButtonColumn6
        '
        Me.DataGridViewDisableButtonColumn6.HeaderText = "Cut"
        Me.DataGridViewDisableButtonColumn6.Name = "DataGridViewDisableButtonColumn6"
        Me.DataGridViewDisableButtonColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn6.Width = 50
        '
        'DataGridViewDisableButtonColumn7
        '
        Me.DataGridViewDisableButtonColumn7.HeaderText = "Add New Sims"
        Me.DataGridViewDisableButtonColumn7.Name = "DataGridViewDisableButtonColumn7"
        Me.DataGridViewDisableButtonColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn7.Width = 80
        '
        'Column1
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column1.HeaderText = "Country_Id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 120
        '
        'clID
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clID.DefaultCellStyle = DataGridViewCellStyle7
        Me.clID.HeaderText = "Operator_ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        Me.clID.Visible = False
        Me.clID.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "Category_ID"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'clNo
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clNo.DefaultCellStyle = DataGridViewCellStyle8
        Me.clNo.HeaderText = "No."
        Me.clNo.Name = "clNo"
        Me.clNo.ReadOnly = True
        Me.clNo.Width = 40
        '
        'Category
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle9
        Me.Category.HeaderText = "Country"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 180
        '
        'Column2
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column2.HeaderText = "Operator"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column4
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column4.HeaderText = "Category"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column6
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle12
        Me.Column6.HeaderText = "Device"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "DeviceID"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column5
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle13
        Me.Column5.HeaderText = "No. of cards"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 110
        '
        'dgOldBtn
        '
        Me.dgOldBtn.HeaderText = "Old"
        Me.dgOldBtn.Name = "dgOldBtn"
        Me.dgOldBtn.ReadOnly = True
        Me.dgOldBtn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOldBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgOldBtn.Width = 60
        '
        'dgHoldBtn
        '
        Me.dgHoldBtn.HeaderText = "Hold"
        Me.dgHoldBtn.Name = "dgHoldBtn"
        Me.dgHoldBtn.ReadOnly = True
        Me.dgHoldBtn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHoldBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgHoldBtn.Width = 60
        '
        'dgCreateBtn
        '
        Me.dgCreateBtn.HeaderText = "New Slot"
        Me.dgCreateBtn.Name = "dgCreateBtn"
        Me.dgCreateBtn.ReadOnly = True
        Me.dgCreateBtn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCreateBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgCreateBtn.Width = 90
        '
        'dgGetBtn
        '
        Me.dgGetBtn.HeaderText = "Get"
        Me.dgGetBtn.Name = "dgGetBtn"
        Me.dgGetBtn.ReadOnly = True
        Me.dgGetBtn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGetBtn.Width = 50
        '
        'dgStartBtn
        '
        Me.dgStartBtn.HeaderText = "Start"
        Me.dgStartBtn.Name = "dgStartBtn"
        Me.dgStartBtn.ReadOnly = True
        Me.dgStartBtn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStartBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgStartBtn.Width = 50
        '
        'dgCutBtn
        '
        Me.dgCutBtn.HeaderText = "Cut"
        Me.dgCutBtn.Name = "dgCutBtn"
        Me.dgCutBtn.ReadOnly = True
        Me.dgCutBtn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCutBtn.Width = 50
        '
        'dgAddSimsBtn
        '
        Me.dgAddSimsBtn.HeaderText = "Add New Sims"
        Me.dgAddSimsBtn.Name = "dgAddSimsBtn"
        Me.dgAddSimsBtn.ReadOnly = True
        Me.dgAddSimsBtn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAddSimsBtn.Width = 80
        '
        'dgDeviceSlotID
        '
        Me.dgDeviceSlotID.HeaderText = "DeviceSlotID"
        Me.dgDeviceSlotID.Name = "dgDeviceSlotID"
        Me.dgDeviceSlotID.ReadOnly = True
        Me.dgDeviceSlotID.Visible = False
        '
        'dgSlot
        '
        Me.dgSlot.HeaderText = "Slot"
        Me.dgSlot.Name = "dgSlot"
        Me.dgSlot.ReadOnly = True
        Me.dgSlot.Visible = False
        '
        'frmUseCards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1507, 711)
        Me.Controls.Add(Me.PanelCardsUser)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmUseCards"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Use Cards"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCardsUser.ResumeLayout(False)
        Me.PanelCardsUser.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgOnHold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PanelCardsUser As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnGetCard As System.Windows.Forms.Button
    Friend WithEvents lblCardsNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshTable As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnPutOnHold As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SetAsUsedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WrongScratchNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlreadyUsedCardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblExceedLimit As System.Windows.Forms.Label
    Friend WithEvents dgOnHold As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbAlreadyUsedCard As System.Windows.Forms.RadioButton
    Friend WithEvents rbWrongValue As System.Windows.Forms.RadioButton
    Friend WithEvents rbWrongName As System.Windows.Forms.RadioButton
    Friend WithEvents btnSetAsWrongCard As System.Windows.Forms.Button
    Friend WithEvents btnSetAsUsed As System.Windows.Forms.Button
    Friend WithEvents chkSelectClear As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewDisableButtonColumn1 As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewDisableButtonColumn2 As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewDisableButtonColumn3 As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewDisableButtonColumn4 As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewDisableButtonColumn5 As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewDisableButtonColumn6 As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewDisableButtonColumn7 As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgOldBtn As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents dgHoldBtn As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents dgCreateBtn As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents dgGetBtn As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents dgStartBtn As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents dgCutBtn As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents dgAddSimsBtn As WindowsApplication1.DataGridViewDisableButtonColumn
    Friend WithEvents dgDeviceSlotID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgSlot As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
