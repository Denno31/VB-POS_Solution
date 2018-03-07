Public Class FrmMain


    Private Sub MenuItem1_Click(sender As Object, e As EventArgs)


        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmItemReceive" Then
                F.Close()
            End If
        Next
        Dim frm As New FrmItemReceive
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub MenuItem2_Click(sender As Object, e As EventArgs) Handles MenuItem2.Click

        'FrmPO.MdiParent = Me
        'FrmPO.Show()



        'Dim frm As New FrmSearchReport
        'frm.reportName = "PO_PaperOne"
        'frm.Show()

        Dim frm As New FrmItemReceive
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub MenuItem9_Click(sender As Object, e As EventArgs)

        FrmAdjustCost.MdiParent = Me
        FrmAdjustCost.Show()



    End Sub

    Private Sub บญชToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Rpt_ToolStripMenuItem.Click

    End Sub

    Private Sub rpt_by_dateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles rpt_by_dateToolStripMenuItem.Click

        Dim frm As New FrmSearchReport
        frm.reportName = "SaleByDate"
        frm.Show()

    End Sub

    Private Sub Sale_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Sale_MainToolStripMenuItem.Click

    End Sub

    Private Sub MIN_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Min_ToolStripMenuItem.Click

        Dim dt As DataTable
        Dim ds As New DataSet
        Dim sql As String
        sql = "select code,name,last_qty,[min],[max] from MPRODUCT where LAST_QTY < [min] "
        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)
        Dim frm As New Report_Item_min
        frm.m_dt = dt
        frm.Show()

    End Sub

    Private Sub MAX_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MAX_ToolStripMenuItem.Click

        Dim dt As DataTable
        Dim ds As New DataSet
        Dim sql As String
        sql = "select code,name,last_qty,[min],[max] from MPRODUCT where LAST_QTY > [max] "
        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)
        Dim frm As New Report_Item_Max
        frm.m_dt = dt
        frm.Show()

    End Sub

    Private Sub Sales_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Sales_ToolStripMenuItem.Click

        Dim frm As New FrmSearchReport
        frm.reportName = "SaleBySales"
        frm.Show()
    End Sub

    Private Sub BySalesAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BySalesAllToolStripMenuItem.Click

        Dim frm As New FrmSearchReport
        frm.reportName = "SaleBySalesAll"
        frm.Show()
    End Sub

    Private Sub ByCustAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByCustAllToolStripMenuItem.Click


        Dim frm As New FrmSearchReport
        frm.reportName = "SaleByCustAll"
        frm.Show()

    End Sub

    Private Sub ByCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByCustomerToolStripMenuItem.Click

        Dim frm As New FrmSearchReport
        frm.reportName = "SaleByCust"
        frm.Show()

    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click

        Dim frm As New FrmCustomer
        frm.Show()
    End Sub

    Private Sub รบสนคาทยอยรบToolStripMenuItem_Click(sender As Object, e As EventArgs)



        Dim frm As New FrmSearchReport
        frm.reportName = "PO"
        frm.Show()
    End Sub

    Private Sub รายงานการขายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการขายToolStripMenuItem.Click

        Dim dt As DataTable
        Dim ds As New DataSet
        Dim sql As String
        sql = "select * from VSALE where sale_slip_id = 'รมค6009017' "
        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)
        Dim frm As New Report_Sale
        frm.m_dt = dt
        frm.Show()
    End Sub

    Private Sub รายงานการขายลกหนToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการขายลกหนToolStripMenuItem.Click

        Dim frm As New FrmSearchReport
        frm.reportName = "SALE_CREDIT"
        frm.Show()

    End Sub

    Private Sub รายงานภาษขายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานภาษขายToolStripMenuItem.Click

        Dim frm As New FrmSearchReport
        frm.reportName = "SALE_OUTPUTTAX"
        frm.Show()


    End Sub

    Private Sub รายงานภาษซอToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานภาษซอToolStripMenuItem.Click

        Dim frm As New FrmSearchReport
        frm.reportName = "PO_INPUTTAX"
        frm.Show()

    End Sub


    Private Sub IV_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IV_ToolStripMenuItem.Click


        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmManageMember" Then
                F.Close()
            End If
        Next

        Dim frm As New FrmManageMember
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub สนคาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click

    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initToolStrip()
        grantLevel()
    End Sub

    Private Sub initToolStrip()


        'For Each StripButton As ToolStripMenuItem In MenuStrip1
        '    If Controls.Equals(StripButton) Then
        '        StripButton.Enabled = False
        '    End If
        'Next

        'For Each item In Me.MenuStrip1.Items
        '    If TypeOf item Is ToolStripMenuItem Then
        '        Dim mnu = CType(item, ToolStripMenuItem)
        '        mnu.Enabled = False
        '    End If
        'Next

    End Sub


    Private Sub grantLevel()

        If Level = "ADMIN" Then
            'For Each item In Me.MenuStrip1.Items
            '    If TypeOf item Is ToolStripMenuItem Then
            '        Dim mnu = CType(item, ToolStripMenuItem)
            '        mnu.Enabled = True
            '    End If
            'Next

        ElseIf Level = "PO" Then
            PO_MainToolStripMenuItem.Enabled = True
            MenuItem1.Enabled = True
            MenuItem2.Enabled = True
            ChangeL_ToolStripMenuItem.Enabled = False

        ElseIf Level = "STOCK" Then
            StockToolStripMenuItem.Enabled = True
            'MenuItem1.Enabled = True
            'MenuItem2.Enabled = True
            Item_ToolStripMenuItem.Enabled = True
            '  ChangeL_ToolStripMenuItem.Enabled = False

        End If

    End Sub


    Private Sub Item_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Item_ToolStripMenuItem.Click

        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmItemMaster" Then
                F.Close()
            End If
        Next
        Dim frm As New FrmItemMaster
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub Vendor_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Vendor_ToolStripMenuItem.Click


        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmVendor" Then
                F.Close()
            End If
        Next
        Dim frm As New FrmVendor
        frm.MdiParent = Me
        frm.Show()



    End Sub

    Private Sub Cust_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Cust_ToolStripMenuItem.Click

        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmCustomer" Then
                F.Close()
            End If
        Next
        Dim frm As New FrmCustomer
        frm.MdiParent = Me
        frm.Show()




    End Sub

    Private Sub Promot_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Promot_ToolStripMenuItem.Click

        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmPromotion" Then
                F.Close()
            End If
        Next
        Dim frm As New FrmPromotion
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ซอToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PO_MainToolStripMenuItem.Click

    End Sub

    Private Sub ChangeL_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeL_ToolStripMenuItem.Click

        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmPromotion" Then
                F.Close()
            End If
        Next
        Dim frm As New FrmPromotion
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles Product_ToolStripMenuItem1.Click

        Dim dt As DataTable
        Dim ds As New DataSet
        Dim sql As String
        sql = "select top 29 code,name,last_qty,[min],[max] from MPRODUCT where name is not null"
        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)


        For Each F As Form In Me.MdiChildren
            If F.Name = "Report_Item_min" Then
                F.Close()
            End If
        Next


        Dim frm As New Report_Item_min
        frm.m_dt = dt
        frm.Show()



    End Sub

    Private Sub PO_AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PO_AllToolStripMenuItem.Click


        Dim frm As New FrmSearchReport
        frm.reportName = "PO"
        frm.Show()


    End Sub

    Private Sub ServiceSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceSVToolStripMenuItem.Click

        For Each F As Form In Me.MdiChildren
            If F.Name = "FrmSaleService" Then
                F.Close()
            End If
        Next

        Dim frm As New FrmSaleService
        frm.MdiParent = Me
        frm.Show()

    End Sub
End Class
