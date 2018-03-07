<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.เรมToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PO_MainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeL_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sale_MainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IV_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cust_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Promot_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Item_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Vendor_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rpt_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.rpt_by_dateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Product_ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Min_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MAX_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sales_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BySalesAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByCustAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานการขายToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานการขายลกหนToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานภาษขายToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานภาษซอToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PO_AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ออกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.เรมToolStripMenuItem, Me.PO_MainToolStripMenuItem, Me.Sale_MainToolStripMenuItem, Me.StockToolStripMenuItem, Me.Rpt_ToolStripMenuItem, Me.ออกToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1314, 33)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'เรมToolStripMenuItem
        '
        Me.เรมToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem, Me.VendorToolStripMenuItem})
        Me.เรมToolStripMenuItem.Name = "เรมToolStripMenuItem"
        Me.เรมToolStripMenuItem.Size = New System.Drawing.Size(49, 29)
        Me.เรมToolStripMenuItem.Text = "เริ่ม"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(173, 30)
        Me.CustomerToolStripMenuItem.Text = "Customer"
        '
        'VendorToolStripMenuItem
        '
        Me.VendorToolStripMenuItem.Name = "VendorToolStripMenuItem"
        Me.VendorToolStripMenuItem.Size = New System.Drawing.Size(173, 30)
        Me.VendorToolStripMenuItem.Text = "Vendor"
        '
        'PO_MainToolStripMenuItem
        '
        Me.PO_MainToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem1, Me.MenuItem2, Me.ChangeL_ToolStripMenuItem})
        Me.PO_MainToolStripMenuItem.Name = "PO_MainToolStripMenuItem"
        Me.PO_MainToolStripMenuItem.Size = New System.Drawing.Size(44, 29)
        Me.PO_MainToolStripMenuItem.Text = "ซื้อ"
        '
        'MenuItem1
        '
        Me.MenuItem1.Name = "MenuItem1"
        Me.MenuItem1.Size = New System.Drawing.Size(240, 30)
        Me.MenuItem1.Text = "1.สั่งซื้อทันที"
        '
        'MenuItem2
        '
        Me.MenuItem2.Name = "MenuItem2"
        Me.MenuItem2.Size = New System.Drawing.Size(240, 30)
        Me.MenuItem2.Text = "2.สั่งซื้อ (ออกใบ PO)"
        '
        'ChangeL_ToolStripMenuItem
        '
        Me.ChangeL_ToolStripMenuItem.Name = "ChangeL_ToolStripMenuItem"
        Me.ChangeL_ToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.ChangeL_ToolStripMenuItem.Text = "3.แต่งบัญชี"
        '
        'Sale_MainToolStripMenuItem
        '
        Me.Sale_MainToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IV_ToolStripMenuItem, Me.ServiceSVToolStripMenuItem, Me.Cust_ToolStripMenuItem, Me.Promot_ToolStripMenuItem})
        Me.Sale_MainToolStripMenuItem.Name = "Sale_MainToolStripMenuItem"
        Me.Sale_MainToolStripMenuItem.Size = New System.Drawing.Size(51, 29)
        Me.Sale_MainToolStripMenuItem.Text = "ขาย"
        '
        'IV_ToolStripMenuItem
        '
        Me.IV_ToolStripMenuItem.Name = "IV_ToolStripMenuItem"
        Me.IV_ToolStripMenuItem.Size = New System.Drawing.Size(276, 30)
        Me.IV_ToolStripMenuItem.Text = "ขายแบบ VAT หน้าร้าน IV"
        '
        'ServiceSVToolStripMenuItem
        '
        Me.ServiceSVToolStripMenuItem.Name = "ServiceSVToolStripMenuItem"
        Me.ServiceSVToolStripMenuItem.Size = New System.Drawing.Size(276, 30)
        Me.ServiceSVToolStripMenuItem.Text = "ขายแบบ Service SV"
        '
        'Cust_ToolStripMenuItem
        '
        Me.Cust_ToolStripMenuItem.Name = "Cust_ToolStripMenuItem"
        Me.Cust_ToolStripMenuItem.Size = New System.Drawing.Size(276, 30)
        Me.Cust_ToolStripMenuItem.Text = "จัดการสมาชิก / สมาชิก"
        '
        'Promot_ToolStripMenuItem
        '
        Me.Promot_ToolStripMenuItem.Name = "Promot_ToolStripMenuItem"
        Me.Promot_ToolStripMenuItem.Size = New System.Drawing.Size(276, 30)
        Me.Promot_ToolStripMenuItem.Text = "จัดการโปรโมชั่น"
        '
        'StockToolStripMenuItem
        '
        Me.StockToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Item_ToolStripMenuItem, Me.Vendor_ToolStripMenuItem})
        Me.StockToolStripMenuItem.Name = "StockToolStripMenuItem"
        Me.StockToolStripMenuItem.Size = New System.Drawing.Size(62, 29)
        Me.StockToolStripMenuItem.Text = "สินค้า"
        '
        'Item_ToolStripMenuItem
        '
        Me.Item_ToolStripMenuItem.Name = "Item_ToolStripMenuItem"
        Me.Item_ToolStripMenuItem.Size = New System.Drawing.Size(210, 30)
        Me.Item_ToolStripMenuItem.Text = "จัดการสินค้า"
        '
        'Vendor_ToolStripMenuItem
        '
        Me.Vendor_ToolStripMenuItem.Name = "Vendor_ToolStripMenuItem"
        Me.Vendor_ToolStripMenuItem.Size = New System.Drawing.Size(210, 30)
        Me.Vendor_ToolStripMenuItem.Text = "จัดการผู้ขาย"
        '
        'Rpt_ToolStripMenuItem
        '
        Me.Rpt_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rpt_by_dateToolStripMenuItem, Me.Product_ToolStripMenuItem1, Me.Min_ToolStripMenuItem, Me.MAX_ToolStripMenuItem, Me.Sales_ToolStripMenuItem, Me.BySalesAllToolStripMenuItem, Me.ByCustAllToolStripMenuItem, Me.ByCustomerToolStripMenuItem, Me.รายงานการขายToolStripMenuItem, Me.รายงานการขายลกหนToolStripMenuItem, Me.รายงานภาษขายToolStripMenuItem, Me.รายงานภาษซอToolStripMenuItem, Me.PO_AllToolStripMenuItem})
        Me.Rpt_ToolStripMenuItem.Name = "Rpt_ToolStripMenuItem"
        Me.Rpt_ToolStripMenuItem.Size = New System.Drawing.Size(77, 29)
        Me.Rpt_ToolStripMenuItem.Text = "รายงาน"
        '
        'rpt_by_dateToolStripMenuItem
        '
        Me.rpt_by_dateToolStripMenuItem.Name = "rpt_by_dateToolStripMenuItem"
        Me.rpt_by_dateToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.rpt_by_dateToolStripMenuItem.Text = "รายงานการขาย By Date"
        '
        'Product_ToolStripMenuItem1
        '
        Me.Product_ToolStripMenuItem1.Name = "Product_ToolStripMenuItem1"
        Me.Product_ToolStripMenuItem1.Size = New System.Drawing.Size(300, 30)
        Me.Product_ToolStripMenuItem1.Text = "รายงานสินค้าคงคลัง"
        '
        'Min_ToolStripMenuItem
        '
        Me.Min_ToolStripMenuItem.Name = "Min_ToolStripMenuItem"
        Me.Min_ToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.Min_ToolStripMenuItem.Text = "รายงานสินค้าคงคลัง  MIN"
        '
        'MAX_ToolStripMenuItem
        '
        Me.MAX_ToolStripMenuItem.Name = "MAX_ToolStripMenuItem"
        Me.MAX_ToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.MAX_ToolStripMenuItem.Text = "รายงานสินค้าคงคลัง MAX"
        '
        'Sales_ToolStripMenuItem
        '
        Me.Sales_ToolStripMenuItem.Name = "Sales_ToolStripMenuItem"
        Me.Sales_ToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.Sales_ToolStripMenuItem.Text = "รายงานการขาย By Sales"
        '
        'BySalesAllToolStripMenuItem
        '
        Me.BySalesAllToolStripMenuItem.Name = "BySalesAllToolStripMenuItem"
        Me.BySalesAllToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.BySalesAllToolStripMenuItem.Text = "รายงานการขาย By Sales All"
        '
        'ByCustAllToolStripMenuItem
        '
        Me.ByCustAllToolStripMenuItem.Name = "ByCustAllToolStripMenuItem"
        Me.ByCustAllToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.ByCustAllToolStripMenuItem.Text = "รายงานการขาย By Cust All"
        '
        'ByCustomerToolStripMenuItem
        '
        Me.ByCustomerToolStripMenuItem.Name = "ByCustomerToolStripMenuItem"
        Me.ByCustomerToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.ByCustomerToolStripMenuItem.Text = "รายงานกาขาย By Customer"
        '
        'รายงานการขายToolStripMenuItem
        '
        Me.รายงานการขายToolStripMenuItem.Name = "รายงานการขายToolStripMenuItem"
        Me.รายงานการขายToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.รายงานการขายToolStripMenuItem.Text = "รายงานการขาย"
        '
        'รายงานการขายลกหนToolStripMenuItem
        '
        Me.รายงานการขายลกหนToolStripMenuItem.Name = "รายงานการขายลกหนToolStripMenuItem"
        Me.รายงานการขายลกหนToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.รายงานการขายลกหนToolStripMenuItem.Text = "รายงานการขายลูกหนี้"
        '
        'รายงานภาษขายToolStripMenuItem
        '
        Me.รายงานภาษขายToolStripMenuItem.Name = "รายงานภาษขายToolStripMenuItem"
        Me.รายงานภาษขายToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.รายงานภาษขายToolStripMenuItem.Text = "รายงานภาษีขาย"
        '
        'รายงานภาษซอToolStripMenuItem
        '
        Me.รายงานภาษซอToolStripMenuItem.Name = "รายงานภาษซอToolStripMenuItem"
        Me.รายงานภาษซอToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.รายงานภาษซอToolStripMenuItem.Text = "รายงานภาษีซื้อ"
        '
        'PO_AllToolStripMenuItem
        '
        Me.PO_AllToolStripMenuItem.Name = "PO_AllToolStripMenuItem"
        Me.PO_AllToolStripMenuItem.Size = New System.Drawing.Size(300, 30)
        Me.PO_AllToolStripMenuItem.Text = "รายงานสั่งซื้อแยกตามรายวัน"
        '
        'ออกToolStripMenuItem
        '
        Me.ออกToolStripMenuItem.Name = "ออกToolStripMenuItem"
        Me.ออกToolStripMenuItem.Size = New System.Drawing.Size(52, 29)
        Me.ออกToolStripMenuItem.Text = "ออก"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1314, 1155)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.Text = "POS System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents เรมToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PO_MainToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sale_MainToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Rpt_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ออกToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rpt_by_dateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Min_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MAX_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sales_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BySalesAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByCustAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByCustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents รายงานการขายToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents รายงานการขายลกหนToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents รายงานภาษขายToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents รายงานภาษซอToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IV_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServiceSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cust_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Promot_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Item_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Vendor_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeL_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Product_ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PO_AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
