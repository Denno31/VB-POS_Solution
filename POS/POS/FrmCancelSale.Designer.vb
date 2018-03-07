<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCancelSale
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
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReturnQty = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQty.Location = New System.Drawing.Point(138, 115)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(110, 26)
        Me.txtQty.TabIndex = 14
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtName.Location = New System.Drawing.Point(138, 71)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(363, 26)
        Me.txtName.TabIndex = 13
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(138, 155)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 35)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 119)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "จำนวนที่ขาย"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 76)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "สินค้า"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "จำนวนที่คืน"
        '
        'txtReturnQty
        '
        Me.txtReturnQty.Location = New System.Drawing.Point(138, 31)
        Me.txtReturnQty.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtReturnQty.Name = "txtReturnQty"
        Me.txtReturnQty.Size = New System.Drawing.Size(110, 26)
        Me.txtReturnQty.TabIndex = 8
        '
        'FrmCancelSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 227)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReturnQty)
        Me.Name = "FrmCancelSale"
        Me.Text = "FrmCancelSale"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReturnQty As System.Windows.Forms.TextBox
End Class
