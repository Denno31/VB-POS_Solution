<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomer))
        Me.tbrMain = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdReport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblAppName = New System.Windows.Forms.Label()
        Me.txtCreditLimit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCreditDays = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotalTxt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalData = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTumbol = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAmphur = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtProvince = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtZipcode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAttnName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbrMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbrMain
        '
        Me.tbrMain.AddNewItem = Nothing
        Me.tbrMain.CountItem = Nothing
        Me.tbrMain.DeleteItem = Nothing
        Me.tbrMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tbrMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorSeparator2, Me.cmdNew, Me.ToolStripSeparator5, Me.cmdSave, Me.ToolStripSeparator4, Me.cmdDelete, Me.ToolStripSeparator1, Me.cmdReport, Me.ToolStripSeparator3, Me.cmdRefresh, Me.ToolStripSeparator2, Me.cmdClose})
        Me.tbrMain.Location = New System.Drawing.Point(0, 0)
        Me.tbrMain.MoveFirstItem = Nothing
        Me.tbrMain.MoveLastItem = Nothing
        Me.tbrMain.MoveNextItem = Nothing
        Me.tbrMain.MovePreviousItem = Nothing
        Me.tbrMain.Name = "tbrMain"
        Me.tbrMain.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.tbrMain.PositionItem = Nothing
        Me.tbrMain.Size = New System.Drawing.Size(1058, 56)
        Me.tbrMain.TabIndex = 12
        Me.tbrMain.Text = "BindingNavigator1"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 56)
        '
        'cmdNew
        '
        Me.cmdNew.Image = Global.POS.My.Resources.Resources.NewDocumentHS
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.RightToLeftAutoMirrorImage = True
        Me.cmdNew.Size = New System.Drawing.Size(87, 53)
        Me.cmdNew.Text = "Add new"
        Me.cmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 56)
        '
        'cmdSave
        '
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(95, 53)
        Me.cmdSave.Text = "Save Data"
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 56)
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = Global.POS.My.Resources.Resources.DeleteHS
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RightToLeftAutoMirrorImage = True
        Me.cmdDelete.Size = New System.Drawing.Size(66, 53)
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 56)
        '
        'cmdReport
        '
        Me.cmdReport.Image = Global.POS.My.Resources.Resources.PrintHS
        Me.cmdReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(70, 53)
        Me.cmdReport.Text = "Report"
        Me.cmdReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 56)
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Image = Global.POS.My.Resources.Resources.SychronizeListHS1
        Me.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 53)
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 56)
        '
        'cmdClose
        '
        Me.cmdClose.Image = Global.POS.My.Resources.Resources.S_B_CANC1
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(59, 53)
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblAppName)
        Me.Panel2.Location = New System.Drawing.Point(5, 57)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1053, 40)
        Me.Panel2.TabIndex = 128
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = True
        Me.lblAppName.BackColor = System.Drawing.Color.Transparent
        Me.lblAppName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblAppName.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppName.ForeColor = System.Drawing.Color.White
        Me.lblAppName.Location = New System.Drawing.Point(18, 6)
        Me.lblAppName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(109, 28)
        Me.lblAppName.TabIndex = 2
        Me.lblAppName.Text = "ข้อมูลสมาชิก"
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.BackColor = System.Drawing.Color.White
        Me.txtCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCreditLimit.Location = New System.Drawing.Point(486, 429)
        Me.txtCreditLimit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.Size = New System.Drawing.Size(110, 30)
        Me.txtCreditLimit.TabIndex = 137
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(320, 425)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 34)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = "CREDIT LIMIT :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCreditDays
        '
        Me.txtCreditDays.BackColor = System.Drawing.Color.White
        Me.txtCreditDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCreditDays.Location = New System.Drawing.Point(208, 429)
        Me.txtCreditDays.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCreditDays.Name = "txtCreditDays"
        Me.txtCreditDays.Size = New System.Drawing.Size(90, 30)
        Me.txtCreditDays.TabIndex = 135
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 425)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 34)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "CREDIT DAYS :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(313, 109)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 34)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "NAME :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtName
        '
        Me.TxtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TxtName.BackColor = System.Drawing.Color.White
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtName.Location = New System.Drawing.Point(405, 111)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(348, 30)
        Me.TxtName.TabIndex = 132
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.White
        Me.txtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(191, 113)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(102, 30)
        Me.txtTitle.TabIndex = 131
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(210, 52)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(360, 39)
        Me.txtBarcode.TabIndex = 129
        Me.txtBarcode.TabStop = False
        Me.txtBarcode.Text = "บส-043"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(58, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 34)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "รหัสสมาชิก :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalTxt, Me.lblTotalData})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 610)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1058, 30)
        Me.StatusStrip1.TabIndex = 138
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotalTxt
        '
        Me.lblTotalTxt.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblTotalTxt.Name = "lblTotalTxt"
        Me.lblTotalTxt.Size = New System.Drawing.Size(156, 25)
        Me.lblTotalTxt.Text = "จำนวนรายการที่พบ :"
        '
        'lblTotalData
        '
        Me.lblTotalData.Name = "lblTotalData"
        Me.lblTotalData.Size = New System.Drawing.Size(32, 25)
        Me.lblTotalData.Text = "10"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 109)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 34)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "คำนำหน้าชื่อ :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(41, 171)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 34)
        Me.Label6.TabIndex = 140
        Me.Label6.Text = "ที่อยู่ :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress
        '
        Me.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(191, 173)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(732, 30)
        Me.txtAddress.TabIndex = 141
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(41, 241)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 34)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "ตำบล :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTumbol
        '
        Me.txtTumbol.BackColor = System.Drawing.Color.White
        Me.txtTumbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtTumbol.Location = New System.Drawing.Point(191, 245)
        Me.txtTumbol.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTumbol.Name = "txtTumbol"
        Me.txtTumbol.Size = New System.Drawing.Size(178, 30)
        Me.txtTumbol.TabIndex = 142
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(381, 241)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 34)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "อำเภอ :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAmphur
        '
        Me.txtAmphur.BackColor = System.Drawing.Color.White
        Me.txtAmphur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtAmphur.Location = New System.Drawing.Point(469, 245)
        Me.txtAmphur.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAmphur.Name = "txtAmphur"
        Me.txtAmphur.Size = New System.Drawing.Size(158, 30)
        Me.txtAmphur.TabIndex = 144
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(645, 241)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 34)
        Me.Label9.TabIndex = 147
        Me.Label9.Text = "จังหวัด :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProvince
        '
        Me.txtProvince.BackColor = System.Drawing.Color.White
        Me.txtProvince.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtProvince.Location = New System.Drawing.Point(737, 245)
        Me.txtProvince.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Size = New System.Drawing.Size(186, 30)
        Me.txtProvince.TabIndex = 146
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(41, 299)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(137, 34)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "รหัสไปรษณีย์ :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtZipcode
        '
        Me.txtZipcode.BackColor = System.Drawing.Color.White
        Me.txtZipcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtZipcode.Location = New System.Drawing.Point(191, 301)
        Me.txtZipcode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtZipcode.Name = "txtZipcode"
        Me.txtZipcode.Size = New System.Drawing.Size(178, 30)
        Me.txtZipcode.TabIndex = 148
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(391, 297)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 34)
        Me.Label11.TabIndex = 151
        Me.Label11.Text = "โทร :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTel
        '
        Me.txtTel.BackColor = System.Drawing.Color.White
        Me.txtTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtTel.Location = New System.Drawing.Point(469, 301)
        Me.txtTel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(158, 30)
        Me.txtTel.TabIndex = 150
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(663, 293)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 34)
        Me.Label12.TabIndex = 153
        Me.Label12.Text = "Fax :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.Color.White
        Me.txtFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtFax.Location = New System.Drawing.Point(737, 297)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(186, 30)
        Me.txtFax.TabIndex = 152
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(99, 357)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 34)
        Me.Label13.TabIndex = 155
        Me.Label13.Text = "ติดต่อคุณ :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAttnName
        '
        Me.txtAttnName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtAttnName.BackColor = System.Drawing.Color.White
        Me.txtAttnName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtAttnName.Location = New System.Drawing.Point(191, 359)
        Me.txtAttnName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAttnName.Name = "txtAttnName"
        Me.txtAttnName.Size = New System.Drawing.Size(433, 30)
        Me.txtAttnName.TabIndex = 154
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.txtBarcode)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtAttnName)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TxtName)
        Me.Panel1.Controls.Add(Me.txtFax)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtTel)
        Me.Panel1.Controls.Add(Me.txtCreditDays)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtZipcode)
        Me.Panel1.Controls.Add(Me.txtCreditLimit)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtProvince)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.txtAmphur)
        Me.Panel1.Controls.Add(Me.txtTumbol)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(5, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1058, 512)
        Me.Panel1.TabIndex = 156
        '
        'FrmCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 640)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tbrMain)
        Me.Name = "FrmCustomer"
        Me.Text = "FrmCustomer"
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbrMain.ResumeLayout(False)
        Me.tbrMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbrMain As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents txtCreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCreditDays As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblTotalTxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalData As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTumbol As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAmphur As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtProvince As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtZipcode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAttnName As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
