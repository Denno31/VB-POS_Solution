<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManageMember
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmManageMember))
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotalTxt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalData = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblAppName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbName = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtPoint = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCreditLimit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCreditDays = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtNameSales = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSales = New System.Windows.Forms.TextBox()
        Me.cb_book = New System.Windows.Forms.ComboBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtDocNo = New System.Windows.Forms.TextBox()
        Me.lblReceiveMoney = New System.Windows.Forms.LinkLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStockOnHand = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.cmdItem = New System.Windows.Forms.Button()
        Me.txtItemNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDocDate = New System.Windows.Forms.DateTimePicker()
        Me.grdMain = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnReceive = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtMoneyChange = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMoneyRec = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PanelWarning = New System.Windows.Forms.Panel()
        Me.lblDes1 = New System.Windows.Forms.Label()
        Me.lblDes2 = New System.Windows.Forms.Label()
        Me.lblContentProm = New System.Windows.Forms.Label()
        Me.lblWarnPoint = New System.Windows.Forms.Label()
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbrMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.pnReceive.SuspendLayout()
        Me.PanelWarning.SuspendLayout()
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
        Me.tbrMain.Size = New System.Drawing.Size(1380, 56)
        Me.tbrMain.TabIndex = 11
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
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalTxt, Me.lblTotalData})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 1003)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1380, 30)
        Me.StatusStrip1.TabIndex = 14
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblAppName)
        Me.Panel2.Location = New System.Drawing.Point(2, 56)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1378, 40)
        Me.Panel2.TabIndex = 127
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
        Me.lblAppName.Size = New System.Drawing.Size(204, 28)
        Me.lblAppName.TabIndex = 2
        Me.lblAppName.Text = "ข้อมูลสมาชิก - โปรโมชั่น"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelWarning)
        Me.Panel1.Controls.Add(Me.cbName)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.txtPoint)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtCreditLimit)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtCreditDays)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtName)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.txtBarcode)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 95)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1380, 234)
        Me.Panel1.TabIndex = 126
        '
        'cbName
        '
        Me.cbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbName.FormattingEnabled = True
        Me.cbName.Location = New System.Drawing.Point(554, 13)
        Me.cbName.Name = "cbName"
        Me.cbName.Size = New System.Drawing.Size(396, 28)
        Me.cbName.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(352, 180)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(148, 34)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Date Start :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(508, 182)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(157, 30)
        Me.TextBox1.TabIndex = 29
        Me.TextBox1.Text = "25/08/2017"
        '
        'txtPoint
        '
        Me.txtPoint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPoint.ForeColor = System.Drawing.Color.Red
        Me.txtPoint.Location = New System.Drawing.Point(176, 182)
        Me.txtPoint.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPoint.Name = "txtPoint"
        Me.txtPoint.ReadOnly = True
        Me.txtPoint.Size = New System.Drawing.Size(137, 30)
        Me.txtPoint.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 178)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 34)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "POINT :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCreditLimit.Location = New System.Drawing.Point(454, 130)
        Me.txtCreditLimit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.ReadOnly = True
        Me.txtCreditLimit.Size = New System.Drawing.Size(110, 30)
        Me.txtCreditLimit.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 126)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 34)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "CREDIT LIMIT :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCreditDays
        '
        Me.txtCreditDays.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCreditDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCreditDays.Location = New System.Drawing.Point(176, 130)
        Me.txtCreditDays.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCreditDays.Name = "txtCreditDays"
        Me.txtCreditDays.ReadOnly = True
        Me.txtCreditDays.Size = New System.Drawing.Size(90, 30)
        Me.txtCreditDays.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 126)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 34)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "CREDIT DAYS :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 68)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 34)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "NAME :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtName
        '
        Me.TxtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TxtName.BackColor = System.Drawing.Color.White
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtName.Location = New System.Drawing.Point(293, 72)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(348, 30)
        Me.TxtName.TabIndex = 21
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(176, 72)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(90, 30)
        Me.txtTitle.TabIndex = 20
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(176, 9)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(360, 39)
        Me.txtBarcode.TabIndex = 2
        Me.txtBarcode.TabStop = False
        Me.txtBarcode.Text = "บส-043"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 34)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "BARCODE :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtNameSales)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.txtSales)
        Me.Panel3.Controls.Add(Me.cb_book)
        Me.Panel3.Controls.Add(Me.cmdSearch)
        Me.Panel3.Controls.Add(Me.lblId)
        Me.Panel3.Controls.Add(Me.txtDocNo)
        Me.Panel3.Controls.Add(Me.lblReceiveMoney)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.txtUnitPrice)
        Me.Panel3.Controls.Add(Me.txtTotal)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtStockOnHand)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtRemark)
        Me.Panel3.Controls.Add(Me.lblRemark)
        Me.Panel3.Controls.Add(Me.txtItemName)
        Me.Panel3.Controls.Add(Me.cmdItem)
        Me.Panel3.Controls.Add(Me.txtItemNo)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtDocDate)
        Me.Panel3.Location = New System.Drawing.Point(1, 369)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1378, 297)
        Me.Panel3.TabIndex = 128
        '
        'txtNameSales
        '
        Me.txtNameSales.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNameSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtNameSales.Location = New System.Drawing.Point(292, 19)
        Me.txtNameSales.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNameSales.Name = "txtNameSales"
        Me.txtNameSales.Size = New System.Drawing.Size(284, 30)
        Me.txtNameSales.TabIndex = 47
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 19)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(148, 34)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "พนักงานขาย :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSales
        '
        Me.txtSales.BackColor = System.Drawing.Color.White
        Me.txtSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSales.Location = New System.Drawing.Point(168, 19)
        Me.txtSales.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSales.Name = "txtSales"
        Me.txtSales.Size = New System.Drawing.Size(108, 30)
        Me.txtSales.TabIndex = 45
        '
        'cb_book
        '
        Me.cb_book.FormattingEnabled = True
        Me.cb_book.Location = New System.Drawing.Point(381, 71)
        Me.cb_book.Name = "cb_book"
        Me.cb_book.Size = New System.Drawing.Size(321, 28)
        Me.cb_book.TabIndex = 44
        '
        'cmdSearch
        '
        Me.cmdSearch.Image = Global.POS.My.Resources.Resources.openfolderHS
        Me.cmdSearch.Location = New System.Drawing.Point(709, 65)
        Me.cmdSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(48, 38)
        Me.cmdSearch.TabIndex = 43
        Me.cmdSearch.Text = "..."
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblId.Location = New System.Drawing.Point(12, 67)
        Me.lblId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(148, 34)
        Me.lblId.TabIndex = 42
        Me.lblId.Text = "เลขที่เอกสาร :"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDocNo
        '
        Me.txtDocNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDocNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDocNo.Location = New System.Drawing.Point(168, 69)
        Me.txtDocNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocNo.Name = "txtDocNo"
        Me.txtDocNo.Size = New System.Drawing.Size(206, 30)
        Me.txtDocNo.TabIndex = 41
        '
        'lblReceiveMoney
        '
        Me.lblReceiveMoney.AutoSize = True
        Me.lblReceiveMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblReceiveMoney.Location = New System.Drawing.Point(861, 235)
        Me.lblReceiveMoney.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReceiveMoney.Name = "lblReceiveMoney"
        Me.lblReceiveMoney.Size = New System.Drawing.Size(198, 40)
        Me.lblReceiveMoney.TabIndex = 40
        Me.lblReceiveMoney.TabStop = True
        Me.lblReceiveMoney.Text = "รับเงิน (F10)"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblPrice)
        Me.Panel4.Location = New System.Drawing.Point(976, 65)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(384, 76)
        Me.Panel4.TabIndex = 39
        '
        'lblPrice
        '
        Me.lblPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPrice.ForeColor = System.Drawing.Color.Gold
        Me.lblPrice.Location = New System.Drawing.Point(30, -3)
        Me.lblPrice.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(346, 80)
        Me.lblPrice.TabIndex = 0
        Me.lblPrice.Text = "999,999.00"
        Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUnitPrice.Enabled = False
        Me.txtUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtUnitPrice.Location = New System.Drawing.Point(435, 191)
        Me.txtUnitPrice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(166, 30)
        Me.txtUnitPrice.TabIndex = 33
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(674, 191)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(166, 30)
        Me.txtTotal.TabIndex = 35
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(580, 191)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 34)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "รวม :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(342, 191)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 34)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "ราคา :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStockOnHand
        '
        Me.txtStockOnHand.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtStockOnHand.Enabled = False
        Me.txtStockOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtStockOnHand.Location = New System.Drawing.Point(168, 191)
        Me.txtStockOnHand.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStockOnHand.Name = "txtStockOnHand"
        Me.txtStockOnHand.Size = New System.Drawing.Size(166, 30)
        Me.txtStockOnHand.TabIndex = 32
        Me.txtStockOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 191)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 34)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "จำนวน :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemark
        '
        Me.txtRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtRemark.Location = New System.Drawing.Point(168, 234)
        Me.txtRemark.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(672, 30)
        Me.txtRemark.TabIndex = 38
        '
        'lblRemark
        '
        Me.lblRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblRemark.Location = New System.Drawing.Point(22, 234)
        Me.lblRemark.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(144, 34)
        Me.lblRemark.TabIndex = 30
        Me.lblRemark.Text = "หมายเหตุ :"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(585, 153)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(439, 30)
        Me.txtItemName.TabIndex = 18
        '
        'cmdItem
        '
        Me.cmdItem.Image = Global.POS.My.Resources.Resources.openfolderHS
        Me.cmdItem.Location = New System.Drawing.Point(528, 145)
        Me.cmdItem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdItem.Name = "cmdItem"
        Me.cmdItem.Size = New System.Drawing.Size(48, 38)
        Me.cmdItem.TabIndex = 17
        Me.cmdItem.Text = "..."
        Me.cmdItem.UseVisualStyleBackColor = True
        '
        'txtItemNo
        '
        Me.txtItemNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtItemNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtItemNo.Location = New System.Drawing.Point(166, 149)
        Me.txtItemNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtItemNo.Name = "txtItemNo"
        Me.txtItemNo.Size = New System.Drawing.Size(340, 30)
        Me.txtItemNo.TabIndex = 16
        Me.txtItemNo.Text = "A7-15-ฟิลคอยล์DB9616176B"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 149)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 34)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "บาร์โค้ดสินค้า :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 108)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 34)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "วันที่ :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDocDate
        '
        Me.txtDocDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDocDate.Location = New System.Drawing.Point(168, 109)
        Me.txtDocDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocDate.Name = "txtDocDate"
        Me.txtDocDate.Size = New System.Drawing.Size(206, 28)
        Me.txtDocDate.TabIndex = 9
        '
        'grdMain
        '
        Me.grdMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdMain.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdMain.Location = New System.Drawing.Point(5, 708)
        Me.grdMain.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(1374, 290)
        Me.grdMain.TabIndex = 129
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Location = New System.Drawing.Point(1, 327)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1378, 40)
        Me.Panel5.TabIndex = 130
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(18, 6)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 28)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "ขายสินค้า"
        '
        'pnReceive
        '
        Me.pnReceive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnReceive.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnReceive.Controls.Add(Me.cmdCancel)
        Me.pnReceive.Controls.Add(Me.cmdOk)
        Me.pnReceive.Controls.Add(Me.txtMoneyChange)
        Me.pnReceive.Controls.Add(Me.Label13)
        Me.pnReceive.Controls.Add(Me.txtMoneyRec)
        Me.pnReceive.Controls.Add(Me.Label14)
        Me.pnReceive.Location = New System.Drawing.Point(183, 803)
        Me.pnReceive.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnReceive.Name = "pnReceive"
        Me.pnReceive.Size = New System.Drawing.Size(1004, 195)
        Me.pnReceive.TabIndex = 131
        Me.pnReceive.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(848, 285)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(150, 49)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(700, 285)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(138, 49)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "บันทึก"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtMoneyChange
        '
        Me.txtMoneyChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtMoneyChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtMoneyChange.Location = New System.Drawing.Point(284, 108)
        Me.txtMoneyChange.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMoneyChange.Name = "txtMoneyChange"
        Me.txtMoneyChange.ReadOnly = True
        Me.txtMoneyChange.Size = New System.Drawing.Size(712, 53)
        Me.txtMoneyChange.TabIndex = 4
        Me.txtMoneyChange.Text = "123"
        Me.txtMoneyChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(27, 106)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(237, 62)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "เงินทอน:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMoneyRec
        '
        Me.txtMoneyRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMoneyRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtMoneyRec.Location = New System.Drawing.Point(285, 45)
        Me.txtMoneyRec.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMoneyRec.Name = "txtMoneyRec"
        Me.txtMoneyRec.Size = New System.Drawing.Size(712, 53)
        Me.txtMoneyRec.TabIndex = 2
        Me.txtMoneyRec.Text = "123"
        Me.txtMoneyRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.Location = New System.Drawing.Point(27, 38)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(237, 62)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "เงินสดรับ :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelWarning
        '
        Me.PanelWarning.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelWarning.Controls.Add(Me.lblDes1)
        Me.PanelWarning.Controls.Add(Me.lblDes2)
        Me.PanelWarning.Controls.Add(Me.lblContentProm)
        Me.PanelWarning.Controls.Add(Me.lblWarnPoint)
        Me.PanelWarning.Location = New System.Drawing.Point(687, 58)
        Me.PanelWarning.Name = "PanelWarning"
        Me.PanelWarning.Size = New System.Drawing.Size(674, 156)
        Me.PanelWarning.TabIndex = 34
        Me.PanelWarning.Visible = False
        '
        'lblDes1
        '
        Me.lblDes1.AutoSize = True
        Me.lblDes1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblDes1.ForeColor = System.Drawing.Color.Green
        Me.lblDes1.Location = New System.Drawing.Point(31, 42)
        Me.lblDes1.Name = "lblDes1"
        Me.lblDes1.Size = New System.Drawing.Size(109, 29)
        Me.lblDes1.TabIndex = 35
        Me.lblDes1.Text = "Warning"
        '
        'lblDes2
        '
        Me.lblDes2.AutoSize = True
        Me.lblDes2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblDes2.ForeColor = System.Drawing.Color.Green
        Me.lblDes2.Location = New System.Drawing.Point(31, 71)
        Me.lblDes2.Name = "lblDes2"
        Me.lblDes2.Size = New System.Drawing.Size(109, 29)
        Me.lblDes2.TabIndex = 34
        Me.lblDes2.Text = "Warning"
        '
        'lblContentProm
        '
        Me.lblContentProm.AutoSize = True
        Me.lblContentProm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblContentProm.ForeColor = System.Drawing.Color.Blue
        Me.lblContentProm.Location = New System.Drawing.Point(253, 11)
        Me.lblContentProm.Name = "lblContentProm"
        Me.lblContentProm.Size = New System.Drawing.Size(109, 29)
        Me.lblContentProm.TabIndex = 33
        Me.lblContentProm.Text = "Warning"
        '
        'lblWarnPoint
        '
        Me.lblWarnPoint.AutoSize = True
        Me.lblWarnPoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblWarnPoint.ForeColor = System.Drawing.Color.Red
        Me.lblWarnPoint.Location = New System.Drawing.Point(31, 106)
        Me.lblWarnPoint.Name = "lblWarnPoint"
        Me.lblWarnPoint.Size = New System.Drawing.Size(128, 32)
        Me.lblWarnPoint.TabIndex = 32
        Me.lblWarnPoint.Text = "Warning"
        '
        'FrmManageMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1380, 1033)
        Me.Controls.Add(Me.pnReceive)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tbrMain)
        Me.Name = "FrmManageMember"
        Me.Text = "FrmManageMember"
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbrMain.ResumeLayout(False)
        Me.tbrMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnReceive.ResumeLayout(False)
        Me.pnReceive.PerformLayout()
        Me.PanelWarning.ResumeLayout(False)
        Me.PanelWarning.PerformLayout()
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
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblTotalTxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalData As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCreditDays As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblReceiveMoney As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStockOnHand As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents cmdItem As System.Windows.Forms.Button
    Friend WithEvents txtItemNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdMain As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtDocNo As System.Windows.Forms.TextBox
    Friend WithEvents pnReceive As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtMoneyChange As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMoneyRec As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cbName As System.Windows.Forms.ComboBox
    Friend WithEvents cb_book As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSales As System.Windows.Forms.TextBox
    Friend WithEvents txtNameSales As System.Windows.Forms.TextBox
    Friend WithEvents PanelWarning As System.Windows.Forms.Panel
    Friend WithEvents lblDes1 As System.Windows.Forms.Label
    Friend WithEvents lblDes2 As System.Windows.Forms.Label
    Friend WithEvents lblContentProm As System.Windows.Forms.Label
    Friend WithEvents lblWarnPoint As System.Windows.Forms.Label
End Class
