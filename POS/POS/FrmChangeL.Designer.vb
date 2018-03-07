<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChangeL))
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
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.DateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.grdMain = New System.Windows.Forms.DataGridView()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotalTxt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalData = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbrMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.tbrMain.Size = New System.Drawing.Size(1324, 56)
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
        Me.Panel2.Controls.Add(Me.lblAppName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 56)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1324, 40)
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
        Me.lblAppName.Size = New System.Drawing.Size(46, 28)
        Me.lblAppName.TabIndex = 2
        Me.lblAppName.Text = "ไทย"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.DateEnd)
        Me.Panel1.Controls.Add(Me.dateStart)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.lblId)
        Me.Panel1.Location = New System.Drawing.Point(0, 95)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1324, 134)
        Me.Panel1.TabIndex = 128
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(626, 51)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 39)
        Me.btnSearch.TabIndex = 50
        Me.btnSearch.Text = "ค้นหา"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'DateEnd
        '
        Me.DateEnd.Location = New System.Drawing.Point(400, 55)
        Me.DateEnd.Name = "DateEnd"
        Me.DateEnd.Size = New System.Drawing.Size(200, 26)
        Me.DateEnd.TabIndex = 49
        '
        'dateStart
        '
        Me.dateStart.Location = New System.Drawing.Point(148, 55)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(200, 26)
        Me.dateStart.TabIndex = 48
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(355, 51)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 34)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "ถึง"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblId.Location = New System.Drawing.Point(62, 51)
        Me.lblId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(79, 34)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "วันที่ :"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdMain
        '
        Me.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMain.Location = New System.Drawing.Point(0, 237)
        Me.grdMain.Name = "grdMain"
        Me.grdMain.RowTemplate.Height = 28
        Me.grdMain.Size = New System.Drawing.Size(1324, 425)
        Me.grdMain.TabIndex = 129
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(1171, 686)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(141, 43)
        Me.btnOK.TabIndex = 130
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalTxt, Me.lblTotalData})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 739)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1324, 30)
        Me.StatusStrip1.TabIndex = 131
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
        'FrmChangeL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1324, 769)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tbrMain)
        Me.Name = "FrmChangeL"
        Me.Text = "FrmChangeL"
        CType(Me.tbrMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbrMain.ResumeLayout(False)
        Me.tbrMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents grdMain As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents DateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblTotalTxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalData As System.Windows.Forms.ToolStripStatusLabel
End Class
