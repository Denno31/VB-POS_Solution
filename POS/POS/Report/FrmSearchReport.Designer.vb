<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearchReport
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtNameSales = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSales = New System.Windows.Forms.TextBox()
        Me.txtNameCust = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCustID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(140, 107)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker1.TabIndex = 0
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(489, 108)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "เริ่ม"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(441, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ถึง"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(568, 160)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(155, 45)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "OK"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtNameSales
        '
        Me.txtNameSales.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNameSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtNameSales.Location = New System.Drawing.Point(283, 21)
        Me.txtNameSales.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNameSales.Name = "txtNameSales"
        Me.txtNameSales.Size = New System.Drawing.Size(284, 30)
        Me.txtNameSales.TabIndex = 50
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.Location = New System.Drawing.Point(0, 21)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(148, 34)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "พนักงานขาย :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSales
        '
        Me.txtSales.BackColor = System.Drawing.Color.White
        Me.txtSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSales.Location = New System.Drawing.Point(159, 21)
        Me.txtSales.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSales.Name = "txtSales"
        Me.txtSales.Size = New System.Drawing.Size(108, 30)
        Me.txtSales.TabIndex = 48
        '
        'txtNameCust
        '
        Me.txtNameCust.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNameCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtNameCust.Location = New System.Drawing.Point(283, 55)
        Me.txtNameCust.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNameCust.Name = "txtNameCust"
        Me.txtNameCust.Size = New System.Drawing.Size(284, 30)
        Me.txtNameCust.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 55)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 34)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "ลูกค้า :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCustID
        '
        Me.txtCustID.BackColor = System.Drawing.Color.White
        Me.txtCustID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCustID.Location = New System.Drawing.Point(159, 55)
        Me.txtCustID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.Size = New System.Drawing.Size(108, 30)
        Me.txtCustID.TabIndex = 51
        '
        'FrmSearchReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 217)
        Me.Controls.Add(Me.txtNameCust)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCustID)
        Me.Controls.Add(Me.txtNameSales)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSales)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "FrmSearchReport"
        Me.Text = "FrmSearchReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtNameSales As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSales As System.Windows.Forms.TextBox
    Friend WithEvents txtNameCust As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCustID As System.Windows.Forms.TextBox
End Class
