<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemReceive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemReceive))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.lblCapName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIV = New System.Windows.Forms.TextBox()
        Me.cb_book = New System.Windows.Forms.ComboBox()
        Me.grdOnhand = New System.Windows.Forms.DataGridView()
        Me.lblAddCuntry = New System.Windows.Forms.Label()
        Me.lblAddItem = New System.Windows.Forms.Label()
        Me.txtSalePrice = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDocQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCuntryNane = New System.Windows.Forms.TextBox()
        Me.cmdCuntry = New System.Windows.Forms.Button()
        Me.txtCuntry = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.cmdItem = New System.Windows.Forms.Button()
        Me.txtItemNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDocDate = New System.Windows.Forms.DateTimePicker()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.txtDocNo = New System.Windows.Forms.TextBox()
        Me.lblId = New System.Windows.Forms.Label()
        Me.grdMain = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotalTxt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalData = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbrMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdOnhand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tbrMain.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.tbrMain.PositionItem = Nothing
        Me.tbrMain.Size = New System.Drawing.Size(1562, 56)
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
        Me.cmdRefresh.Image = Global.POS.My.Resources.Resources.SychronizeListHS
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
        Me.cmdClose.Image = Global.POS.My.Resources.Resources.S_B_CANC
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(59, 53)
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblCapName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 56)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1562, 72)
        Me.Panel2.TabIndex = 27
        '
        'lblCapName
        '
        Me.lblCapName.AutoSize = True
        Me.lblCapName.BackColor = System.Drawing.Color.Transparent
        Me.lblCapName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCapName.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapName.ForeColor = System.Drawing.Color.White
        Me.lblCapName.Location = New System.Drawing.Point(4, 11)
        Me.lblCapName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCapName.Name = "lblCapName"
        Me.lblCapName.Size = New System.Drawing.Size(183, 55)
        Me.lblCapName.TabIndex = 2
        Me.lblCapName.Text = "รับสินค้า"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtIV)
        Me.Panel1.Controls.Add(Me.cb_book)
        Me.Panel1.Controls.Add(Me.grdOnhand)
        Me.Panel1.Controls.Add(Me.lblAddCuntry)
        Me.Panel1.Controls.Add(Me.lblAddItem)
        Me.Panel1.Controls.Add(Me.txtSalePrice)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtUnitPrice)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtDocQty)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtCuntryNane)
        Me.Panel1.Controls.Add(Me.cmdCuntry)
        Me.Panel1.Controls.Add(Me.txtCuntry)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtItemName)
        Me.Panel1.Controls.Add(Me.cmdItem)
        Me.Panel1.Controls.Add(Me.txtItemNo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtDocDate)
        Me.Panel1.Controls.Add(Me.cmdSearch)
        Me.Panel1.Controls.Add(Me.txtRemark)
        Me.Panel1.Controls.Add(Me.lblRemark)
        Me.Panel1.Controls.Add(Me.txtDocNo)
        Me.Panel1.Controls.Add(Me.lblId)
        Me.Panel1.Location = New System.Drawing.Point(0, 140)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1560, 314)
        Me.Panel1.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(391, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 34)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "เลขที่ใบกำกับภาษี :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIV
        '
        Me.txtIV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtIV.Location = New System.Drawing.Point(546, 53)
        Me.txtIV.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIV.Name = "txtIV"
        Me.txtIV.Size = New System.Drawing.Size(293, 30)
        Me.txtIV.TabIndex = 35
        '
        'cb_book
        '
        Me.cb_book.FormattingEnabled = True
        Me.cb_book.Location = New System.Drawing.Point(400, 12)
        Me.cb_book.Name = "cb_book"
        Me.cb_book.Size = New System.Drawing.Size(321, 28)
        Me.cb_book.TabIndex = 34
        '
        'grdOnhand
        '
        Me.grdOnhand.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdOnhand.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdOnhand.Location = New System.Drawing.Point(858, 178)
        Me.grdOnhand.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdOnhand.Name = "grdOnhand"
        Me.grdOnhand.Size = New System.Drawing.Size(693, 115)
        Me.grdOnhand.TabIndex = 33
        '
        'lblAddCuntry
        '
        Me.lblAddCuntry.AutoSize = True
        Me.lblAddCuntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAddCuntry.Enabled = False
        Me.lblAddCuntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAddCuntry.ForeColor = System.Drawing.Color.Blue
        Me.lblAddCuntry.Location = New System.Drawing.Point(854, 145)
        Me.lblAddCuntry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAddCuntry.Name = "lblAddCuntry"
        Me.lblAddCuntry.Size = New System.Drawing.Size(124, 25)
        Me.lblAddCuntry.TabIndex = 32
        Me.lblAddCuntry.Text = "เพิ่มรายชื่อผู้ส่ง"
        '
        'lblAddItem
        '
        Me.lblAddItem.AutoSize = True
        Me.lblAddItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAddItem.ForeColor = System.Drawing.Color.Blue
        Me.lblAddItem.Location = New System.Drawing.Point(854, 103)
        Me.lblAddItem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAddItem.Name = "lblAddItem"
        Me.lblAddItem.Size = New System.Drawing.Size(146, 25)
        Me.lblAddItem.TabIndex = 31
        Me.lblAddItem.Text = "เพิ่มรายการสินค้า"
        '
        'txtSalePrice
        '
        Me.txtSalePrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSalePrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSalePrice.Location = New System.Drawing.Point(168, 218)
        Me.txtSalePrice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSalePrice.Name = "txtSalePrice"
        Me.txtSalePrice.Size = New System.Drawing.Size(166, 30)
        Me.txtSalePrice.TabIndex = 27
        Me.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 218)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 34)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "ราคาขาย :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtUnitPrice.Location = New System.Drawing.Point(435, 178)
        Me.txtUnitPrice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(166, 30)
        Me.txtUnitPrice.TabIndex = 25
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(674, 178)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(166, 30)
        Me.txtTotal.TabIndex = 26
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(580, 178)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 34)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "รวม :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(342, 178)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 34)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "ราคา :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDocQty
        '
        Me.txtDocQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDocQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDocQty.Location = New System.Drawing.Point(168, 178)
        Me.txtDocQty.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocQty.Name = "txtDocQty"
        Me.txtDocQty.Size = New System.Drawing.Size(166, 30)
        Me.txtDocQty.TabIndex = 24
        Me.txtDocQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 178)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 34)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "จำนวน :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCuntryNane
        '
        Me.txtCuntryNane.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCuntryNane.Location = New System.Drawing.Point(400, 135)
        Me.txtCuntryNane.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCuntryNane.Name = "txtCuntryNane"
        Me.txtCuntryNane.Size = New System.Drawing.Size(439, 30)
        Me.txtCuntryNane.TabIndex = 22
        '
        'cmdCuntry
        '
        Me.cmdCuntry.Image = Global.POS.My.Resources.Resources.openfolderHS
        Me.cmdCuntry.Location = New System.Drawing.Point(344, 134)
        Me.cmdCuntry.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCuntry.Name = "cmdCuntry"
        Me.cmdCuntry.Size = New System.Drawing.Size(48, 38)
        Me.cmdCuntry.TabIndex = 21
        Me.cmdCuntry.Text = "..."
        Me.cmdCuntry.UseVisualStyleBackColor = True
        '
        'txtCuntry
        '
        Me.txtCuntry.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCuntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCuntry.Location = New System.Drawing.Point(166, 135)
        Me.txtCuntry.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCuntry.Name = "txtCuntry"
        Me.txtCuntry.ReadOnly = True
        Me.txtCuntry.Size = New System.Drawing.Size(166, 30)
        Me.txtCuntry.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 135)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 34)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "ผู้ส่งสินค้า :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(400, 92)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(439, 30)
        Me.txtItemName.TabIndex = 18
        '
        'cmdItem
        '
        Me.cmdItem.Image = Global.POS.My.Resources.Resources.openfolderHS
        Me.cmdItem.Location = New System.Drawing.Point(344, 91)
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
        Me.txtItemNo.Location = New System.Drawing.Point(166, 92)
        Me.txtItemNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtItemNo.Name = "txtItemNo"
        Me.txtItemNo.Size = New System.Drawing.Size(166, 30)
        Me.txtItemNo.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 92)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 34)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "สินค้า :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 34)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "วันที่ :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDocDate
        '
        Me.txtDocDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDocDate.Location = New System.Drawing.Point(168, 52)
        Me.txtDocDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocDate.Name = "txtDocDate"
        Me.txtDocDate.Size = New System.Drawing.Size(206, 28)
        Me.txtDocDate.TabIndex = 9
        '
        'cmdSearch
        '
        Me.cmdSearch.Image = Global.POS.My.Resources.Resources.openfolderHS
        Me.cmdSearch.Location = New System.Drawing.Point(754, 5)
        Me.cmdSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(48, 38)
        Me.cmdSearch.TabIndex = 8
        Me.cmdSearch.Text = "..."
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtRemark
        '
        Me.txtRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtRemark.Location = New System.Drawing.Point(168, 260)
        Me.txtRemark.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(672, 30)
        Me.txtRemark.TabIndex = 28
        '
        'lblRemark
        '
        Me.lblRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblRemark.Location = New System.Drawing.Point(22, 260)
        Me.lblRemark.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(144, 34)
        Me.lblRemark.TabIndex = 2
        Me.lblRemark.Text = "หมายเหตุ :"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDocNo
        '
        Me.txtDocNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDocNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDocNo.Location = New System.Drawing.Point(168, 11)
        Me.txtDocNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDocNo.Name = "txtDocNo"
        Me.txtDocNo.ReadOnly = True
        Me.txtDocNo.Size = New System.Drawing.Size(206, 30)
        Me.txtDocNo.TabIndex = 1
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblId.Location = New System.Drawing.Point(18, 11)
        Me.lblId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(148, 34)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "เลขที่เอกสาร :"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdMain
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grdMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdMain.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdMain.Location = New System.Drawing.Point(-2, 445)
        Me.grdMain.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(1562, 321)
        Me.grdMain.TabIndex = 29
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalTxt, Me.lblTotalData})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 771)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1562, 30)
        Me.StatusStrip1.TabIndex = 30
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
        'FrmItemReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1562, 801)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tbrMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmItemReceive"
        Me.Text = "FrmItemReceive"
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbrMain.ResumeLayout(False)
        Me.tbrMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdOnhand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblCapName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdOnhand As System.Windows.Forms.DataGridView
    Friend WithEvents lblAddCuntry As System.Windows.Forms.Label
    Friend WithEvents lblAddItem As System.Windows.Forms.Label
    Friend WithEvents txtSalePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDocQty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCuntryNane As System.Windows.Forms.TextBox
    Friend WithEvents cmdCuntry As System.Windows.Forms.Button
    Friend WithEvents txtCuntry As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents cmdItem As System.Windows.Forms.Button
    Friend WithEvents txtItemNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtDocNo As System.Windows.Forms.TextBox
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents grdMain As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblTotalTxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalData As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cb_book As System.Windows.Forms.ComboBox
    Friend WithEvents txtIV As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
