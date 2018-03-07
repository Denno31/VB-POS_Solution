Imports System.Linq
Imports System.Data.Entity
Imports System.Reflection


Public Class FrmSearchReport



    Dim oDataset As DataSet
    Dim oDT As DataTable
    Dim clsLang As New clsLangMsg
    Dim m_StockOnHand As New Model.Sale.M_Stock_OnHand
    Dim stock_criteria As New Model.Criteria.Sale.M_Stock_OnHand
    Dim m_saleSlipTran_criteria As New Model.Criteria.Sale.M_SaleSlip_Tran
    Public clsSetting As New mySetting(mySetting.Config.ApplicationFile)

    Public reportName As String



    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click



        Dim d1, d2 As String
        d1 = Format(DateTimePicker1.Value, "yyyy-MM-dd hh:mm:ss")
        d2 = Format(DateTimePicker2.Value, "yyyy-MM-dd hh:mm:ss")

        Dim ds As New DataSet
        Dim sql As String
    



        If reportName = "SaleBySales" Then

            sql = "Select * from Vsale where (createDate > '" & d1 & "' and createDate < '" & d2 & "') and (sales_id = '" & txtSales.Text & "')"
            ds = oService.getDataSet(sql)

            Dim frm As New Report_SaleBySales
            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2
            frm.sales_id = txtNameSales.Text

            frm.Show()


        ElseIf reportName = "SaleByDate" Then

            sql = "Select * from Vsale where createDate > '" & d1 & "' and createDate < '" & d2 & "'"
            ds = oService.getDataSet(sql)

            Dim frm As New Report_SaleByDate
            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2

            frm.Show()



        ElseIf reportName = "SaleBySalesAll" Then

            sql = "Select * from Vsale where (createDate > '" & d1 & "' and createDate < '" & d2 & "') "
            ds = oService.getDataSet(sql)

            Dim frm As New Report_SaleBySalesAll
            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2
            frm.sales_id = txtNameSales.Text

            frm.Show()


        ElseIf reportName = "SaleByCustAll" Then

            sql = "Select * from Vsale where (createDate > '" & d1 & "' and createDate < '" & d2 & "') "
            ds = oService.getDataSet(sql)

            Dim frm As New Report_SaleByCustAll

            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2

            frm.Show()



        ElseIf reportName = "SaleByCust" Then

            sql = "Select * from Vsale where (createDate > '" & d1 & "' and createDate < '" & d2 & "')  and c_id='" & txtCustID.Text.Replace(vbCrLf, "") & "'"
            ds = oService.getDataSet(sql) '

            Dim frm As New Report_SaleByCust

            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2
            frm.CUST_ID = txtCustID.Text
            frm.CUST_NAME = txtNameCust.Text

            frm.Show()

        ElseIf reportName = "PO_PaperOne" Then

            sql = "Select * from vReceive where (ModifyDate > '" & d1 & "' and ModifyDate < '" & d2 & "')"
            ds = oService.getDataSet(sql) '

            Dim frm As New Report_POPaperOne

            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2
        

            frm.Show()


        ElseIf reportName = "PO" Then

            sql = "Select * from vReceive where (ModifyDate > '" & d1 & "' and ModifyDate < '" & d2 & "')"
            ds = oService.getDataSet(sql) '

            Dim frm As New Report_PO_All

            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2


            frm.Show()


        ElseIf reportName = "SALE_CREDIT" Then

            sql = "select sale_slip_id,createdate,IIF(CREDIT = 1 , 'ค้างชำระ','เงินสด') as CREDIT,sum(amount) as amount  From vSale group by SALE_SLIP_ID,createdate,credit having (CreateDate > '" & d1 & "' and CreateDate < '" & d2 & "')"
            ds = oService.getDataSet(sql) '

            Dim frm As New Report_SaleCredit

            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2


            frm.Show()



        ElseIf reportName = "SALE_OUTPUTTAX" Then

            sql = "select SALE_SLIP_ID,sum([amount]) as amount,sum([amount]) * 0.07 as tax,tax_id,name,CREATEDATE From vSale group by SALE_SLIP_ID,tax_id,name,CREATEDATE having (CreateDate > '" & d1 & "' and CreateDate < '" & d2 & "')"
            ds = oService.getDataSet(sql) '

            Dim frm As New Report_SaleOutputTax

            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2


            frm.Show()

        ElseIf reportName = "PO_INPUTTAX" Then

            sql = "SELECT DocNo,sum(totalprice) as totalprice,sum(totalprice) * 0.07 as tax,name,tax_id,DocDate FROM vReceive GROUP BY DocNo,name,TAX_ID,docdate having (DocDate > '" & d1 & "' and DocDate < '" & d2 & "')"
            ds = oService.getDataSet(sql) '

            Dim frm As New Report_POInputTax

            frm.m_dt = ds.Tables(0)
            frm.dateStart = d1
            frm.dateEnd = d2


            frm.Show()



        End If

     

    End Sub

    Private Sub txtSales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSales.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim x As New clsFind
            Dim oDataRow As DataRow = Nothing
            With x
                '.setConstring(clsSetting.GetSetting("ConString", ""))
                .setTableName(clsLang.msg_iss_type)
                '.setCriteriaStockOnHand(stock_criteria)
                ' .setSQL("SELECT ItemNO,ItemName,ItemType,TypeName,ItemGroup,FullName,ItemPrice from vItemMaster")
                .setSQL("SELECT ID,NAME,SURNAME FROM MSALES Where ID like '" & txtSales.Text & "%'")
                .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name & ",ราคา")
                .setColumnWidth("200,300,300")
                .OpenFind()
                oDataRow = .getDatarow
                If oDataRow Is Nothing = False Then
                    'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSales.Text = oDataRow("ID").ToString
                    txtNameSales.Text = oDataRow("NAME").ToString & "  " & oDataRow("SURNAME").ToString
                End If
            End With

            oDataRow = Nothing
            x = Nothing
        End If
    End Sub

    Private Sub txtSales_TextChanged(sender As Object, e As EventArgs) Handles txtSales.TextChanged

    End Sub

    Private Sub FrmSearchReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCustID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustID.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim x As New clsFind
            Dim oDataRow As DataRow = Nothing
            With x
                '.setConstring(clsSetting.GetSetting("ConString", ""))
                .setTableName(clsLang.msg_iss_type)
                '.setCriteriaStockOnHand(stock_criteria)
                ' .setSQL("SELECT ItemNO,ItemName,ItemType,TypeName,ItemGroup,FullName,ItemPrice from vItemMaster")
                .setSQL("SELECT ID,NAME FROM MCUST Where ID like '" & txtCustID.Text.Replace(vbCrLf, "") & "%'")
                .setColumnDesc(clsLang.msg_id & ",ชื่อ")
                .setColumnWidth("200,400")
                .OpenFind()
                oDataRow = .getDatarow
                If oDataRow Is Nothing = False Then
                    'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCustID.Text = oDataRow("ID").ToString
                    txtNameCust.Text = oDataRow("NAME").ToString
                End If
            End With

            oDataRow = Nothing
            x = Nothing
        End If

    End Sub

    Private Sub txtCustID_TextChanged(sender As Object, e As EventArgs) Handles txtCustID.TextChanged

    End Sub
End Class