<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report_PO
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
        Me.ReportView = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'ReportView
        '
        Me.ReportView.ActiveViewIndex = -1
        Me.ReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReportView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReportView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportView.Location = New System.Drawing.Point(0, 0)
        Me.ReportView.Name = "ReportView"
        Me.ReportView.Size = New System.Drawing.Size(1060, 1019)
        Me.ReportView.TabIndex = 0
        '
        'Report_PO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 1019)
        Me.Controls.Add(Me.ReportView)
        Me.Name = "Report_PO"
        Me.Text = "Report_PO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportView As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
