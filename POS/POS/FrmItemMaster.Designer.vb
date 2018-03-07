<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemMaster))
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtLocation = New System.Windows.Forms.TextBox()
        Me.btnPrintBarcode = New System.Windows.Forms.Button()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPrice2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtModel_ID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBrand_ID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGen_Name = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMPR_Type = New System.Windows.Forms.TextBox()
        Me.cbMPR_Type = New System.Windows.Forms.ComboBox()
        Me.lblAddCuntry = New System.Windows.Forms.Label()
        Me.txtVendorName = New System.Windows.Forms.TextBox()
        Me.cmdCuntry = New System.Windows.Forms.Button()
        Me.txtVendorID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrice1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUnit_Type = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblId = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotalTxt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalData = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbrMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.tbrMain.PositionItem = Nothing
        Me.tbrMain.Size = New System.Drawing.Size(875, 46)
        Me.tbrMain.TabIndex = 11
        Me.tbrMain.Text = "BindingNavigator1"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 46)
        '
        'cmdNew
        '
        Me.cmdNew.Image = Global.POS.My.Resources.Resources.NewDocumentHS
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.RightToLeftAutoMirrorImage = True
        Me.cmdNew.Size = New System.Drawing.Size(58, 43)
        Me.cmdNew.Text = "Add new"
        Me.cmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 46)
        '
        'cmdSave
        '
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(62, 43)
        Me.cmdSave.Text = "Save Data"
        Me.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 46)
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = Global.POS.My.Resources.Resources.DeleteHS
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RightToLeftAutoMirrorImage = True
        Me.cmdDelete.Size = New System.Drawing.Size(44, 43)
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 46)
        '
        'cmdReport
        '
        Me.cmdReport.Image = Global.POS.My.Resources.Resources.PrintHS
        Me.cmdReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(46, 43)
        Me.cmdReport.Text = "Report"
        Me.cmdReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 46)
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Image = Global.POS.My.Resources.Resources.SychronizeListHS
        Me.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(50, 43)
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 46)
        '
        'cmdClose
        '
        Me.cmdClose.Image = Global.POS.My.Resources.Resources.S_B_CANC
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(40, 43)
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblAppName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(875, 26)
        Me.Panel2.TabIndex = 126
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = True
        Me.lblAppName.BackColor = System.Drawing.Color.Transparent
        Me.lblAppName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblAppName.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppName.ForeColor = System.Drawing.Color.White
        Me.lblAppName.Location = New System.Drawing.Point(12, 4)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(30, 18)
        Me.lblAppName.TabIndex = 2
        Me.lblAppName.Text = "ไทย"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.TxtLocation)
        Me.Panel1.Controls.Add(Me.btnPrintBarcode)
        Me.Panel1.Controls.Add(Me.txtStock)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtMax)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtMin)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtBarcode)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtPrice2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtModel_ID)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtBrand_ID)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtGen_Name)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtMPR_Type)
        Me.Panel1.Controls.Add(Me.cbMPR_Type)
        Me.Panel1.Controls.Add(Me.lblAddCuntry)
        Me.Panel1.Controls.Add(Me.txtVendorName)
        Me.Panel1.Controls.Add(Me.cmdCuntry)
        Me.Panel1.Controls.Add(Me.txtVendorID)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtPrice1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtUnit_Type)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmdSearch)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.lblId)
        Me.Panel1.Location = New System.Drawing.Point(0, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(875, 335)
        Me.Panel1.TabIndex = 127
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 272)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 22)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "LOCATION :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtLocation
        '
        Me.TxtLocation.BackColor = System.Drawing.Color.White
        Me.TxtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtLocation.Location = New System.Drawing.Point(121, 272)
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.Size = New System.Drawing.Size(195, 22)
        Me.TxtLocation.TabIndex = 55
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.Location = New System.Drawing.Point(677, 161)
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(185, 82)
        Me.btnPrintBarcode.TabIndex = 54
        Me.btnPrintBarcode.Text = "PRINT BARCODE"
        Me.btnPrintBarcode.UseVisualStyleBackColor = True
        '
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.Color.White
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtStock.Location = New System.Drawing.Point(123, 237)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(57, 22)
        Me.txtStock.TabIndex = 52
        Me.txtStock.Text = "50"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.Location = New System.Drawing.Point(23, 237)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 22)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "STOCK :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMax
        '
        Me.txtMax.BackColor = System.Drawing.Color.White
        Me.txtMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtMax.Location = New System.Drawing.Point(455, 240)
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(57, 22)
        Me.txtMax.TabIndex = 50
        Me.txtMax.Text = "50"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.Location = New System.Drawing.Point(351, 236)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 22)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "MAX :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMin
        '
        Me.txtMin.BackColor = System.Drawing.Color.White
        Me.txtMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtMin.Location = New System.Drawing.Point(293, 240)
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(53, 22)
        Me.txtMin.TabIndex = 48
        Me.txtMin.Text = "10"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(189, 237)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 22)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "MIN :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(351, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 22)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "ชื่อ :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(123, 198)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(197, 22)
        Me.txtBarcode.TabIndex = 45
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(23, 198)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 22)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "BARCODE :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(517, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 22)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "บาท"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice2
        '
        Me.txtPrice2.BackColor = System.Drawing.Color.White
        Me.txtPrice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPrice2.Location = New System.Drawing.Point(407, 161)
        Me.txtPrice2.Name = "txtPrice2"
        Me.txtPrice2.Size = New System.Drawing.Size(105, 22)
        Me.txtPrice2.TabIndex = 42
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(307, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 22)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "ราคาขาย 2 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtModel_ID
        '
        Me.txtModel_ID.BackColor = System.Drawing.Color.White
        Me.txtModel_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtModel_ID.Location = New System.Drawing.Point(677, 90)
        Me.txtModel_ID.Name = "txtModel_ID"
        Me.txtModel_ID.Size = New System.Drawing.Size(185, 22)
        Me.txtModel_ID.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(577, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 22)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "MODEL ID :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBrand_ID
        '
        Me.txtBrand_ID.BackColor = System.Drawing.Color.White
        Me.txtBrand_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtBrand_ID.Location = New System.Drawing.Point(389, 92)
        Me.txtBrand_ID.Name = "txtBrand_ID"
        Me.txtBrand_ID.Size = New System.Drawing.Size(195, 22)
        Me.txtBrand_ID.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(289, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 22)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "BRAND ID :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGen_Name
        '
        Me.txtGen_Name.BackColor = System.Drawing.Color.White
        Me.txtGen_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtGen_Name.Location = New System.Drawing.Point(123, 90)
        Me.txtGen_Name.Name = "txtGen_Name"
        Me.txtGen_Name.Size = New System.Drawing.Size(163, 22)
        Me.txtGen_Name.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 22)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "GEN NAME :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMPR_Type
        '
        Me.txtMPR_Type.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtMPR_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtMPR_Type.Location = New System.Drawing.Point(123, 66)
        Me.txtMPR_Type.Name = "txtMPR_Type"
        Me.txtMPR_Type.ReadOnly = True
        Me.txtMPR_Type.Size = New System.Drawing.Size(74, 22)
        Me.txtMPR_Type.TabIndex = 35
        Me.txtMPR_Type.TabStop = False
        Me.txtMPR_Type.Text = "S1"
        '
        'cbMPR_Type
        '
        Me.cbMPR_Type.FormattingEnabled = True
        Me.cbMPR_Type.Location = New System.Drawing.Point(206, 66)
        Me.cbMPR_Type.Margin = New System.Windows.Forms.Padding(2)
        Me.cbMPR_Type.Name = "cbMPR_Type"
        Me.cbMPR_Type.Size = New System.Drawing.Size(189, 21)
        Me.cbMPR_Type.TabIndex = 34
        '
        'lblAddCuntry
        '
        Me.lblAddCuntry.AutoSize = True
        Me.lblAddCuntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAddCuntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAddCuntry.ForeColor = System.Drawing.Color.Blue
        Me.lblAddCuntry.Location = New System.Drawing.Point(577, 306)
        Me.lblAddCuntry.Name = "lblAddCuntry"
        Me.lblAddCuntry.Size = New System.Drawing.Size(87, 16)
        Me.lblAddCuntry.TabIndex = 33
        Me.lblAddCuntry.Text = "เพิ่มรายชื่อผู้ส่ง"
        '
        'txtVendorName
        '
        Me.txtVendorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtVendorName.Location = New System.Drawing.Point(277, 300)
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(294, 22)
        Me.txtVendorName.TabIndex = 5
        '
        'cmdCuntry
        '
        Me.cmdCuntry.Image = Global.POS.My.Resources.Resources.openfolderHS
        Me.cmdCuntry.Location = New System.Drawing.Point(239, 299)
        Me.cmdCuntry.Name = "cmdCuntry"
        Me.cmdCuntry.Size = New System.Drawing.Size(32, 25)
        Me.cmdCuntry.TabIndex = 29
        Me.cmdCuntry.Text = "..."
        Me.cmdCuntry.UseVisualStyleBackColor = True
        '
        'txtVendorID
        '
        Me.txtVendorID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtVendorID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtVendorID.Location = New System.Drawing.Point(121, 300)
        Me.txtVendorID.Name = "txtVendorID"
        Me.txtVendorID.ReadOnly = True
        Me.txtVendorID.Size = New System.Drawing.Size(112, 22)
        Me.txtVendorID.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 22)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "ผู้ส่ง :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(235, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 22)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "บาท"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice1
        '
        Me.txtPrice1.BackColor = System.Drawing.Color.White
        Me.txtPrice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPrice1.Location = New System.Drawing.Point(123, 161)
        Me.txtPrice1.Name = "txtPrice1"
        Me.txtPrice1.Size = New System.Drawing.Size(95, 22)
        Me.txtPrice1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 22)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "ราคาขาย 1 :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnit_Type
        '
        Me.txtUnit_Type.BackColor = System.Drawing.Color.White
        Me.txtUnit_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtUnit_Type.Location = New System.Drawing.Point(123, 125)
        Me.txtUnit_Type.Name = "txtUnit_Type"
        Me.txtUnit_Type.Size = New System.Drawing.Size(74, 22)
        Me.txtUnit_Type.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 22)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "หน่วยนับ :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 22)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "กลุ่มสินค้า :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSearch
        '
        Me.cmdSearch.Image = Global.POS.My.Resources.Resources.openfolderHS
        Me.cmdSearch.Location = New System.Drawing.Point(695, 32)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(32, 25)
        Me.cmdSearch.TabIndex = 2
        Me.cmdSearch.Text = "..."
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtName.Location = New System.Drawing.Point(418, 31)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(273, 22)
        Me.txtName.TabIndex = 3
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCode.Location = New System.Drawing.Point(121, 32)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(235, 22)
        Me.txtCode.TabIndex = 1
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblId.Location = New System.Drawing.Point(17, 34)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(99, 22)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Code :"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalTxt, Me.lblTotalData})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 425)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(875, 22)
        Me.StatusStrip1.TabIndex = 129
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotalTxt
        '
        Me.lblTotalTxt.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblTotalTxt.Name = "lblTotalTxt"
        Me.lblTotalTxt.Size = New System.Drawing.Size(104, 17)
        Me.lblTotalTxt.Text = "จำนวนรายการที่พบ :"
        '
        'lblTotalData
        '
        Me.lblTotalData.Name = "lblTotalData"
        Me.lblTotalData.Size = New System.Drawing.Size(19, 17)
        Me.lblTotalData.Text = "10"
        '
        'FrmItemMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 447)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tbrMain)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmItemMaster"
        Me.Text = "FrmItemMaster"
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbrMain.ResumeLayout(False)
        Me.tbrMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblAddCuntry As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cmdCuntry As System.Windows.Forms.Button
    Friend WithEvents txtVendorID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPrice1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUnit_Type As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblTotalTxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalData As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cbMPR_Type As System.Windows.Forms.ComboBox
    Friend WithEvents txtMPR_Type As System.Windows.Forms.TextBox
    Friend WithEvents txtModel_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBrand_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGen_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPrice2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMax As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMin As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtLocation As System.Windows.Forms.TextBox
End Class
