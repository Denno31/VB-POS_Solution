Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared

Public Class Report_Sale

    Public m_dt As DataTable
    Private Sub ReportView_Load(sender As Object, e As EventArgs) Handles ReportView.Load



        Dim dtMap As New DataTable("SALE")
        '*** DataTable Map DataSet.xsd ***//
        Dim dr As DataRow = Nothing
        dtMap.Columns.Add(New DataColumn("Sale_Slip_ID", GetType(String)))
        dtMap.Columns.Add(New DataColumn("DETAIL", GetType(String)))
        dtMap.Columns.Add(New DataColumn("PROD_CODE", GetType(String)))
        dtMap.Columns.Add(New DataColumn("QTY", GetType(Integer)))
        dtMap.Columns.Add(New DataColumn("PRICE", GetType(Decimal)))
        dtMap.Columns.Add(New DataColumn("AMOUNT", GetType(Decimal)))
        dtMap.Columns.Add(New DataColumn("C_ID", GetType(String)))
        dtMap.Columns.Add(New DataColumn("NAME", GetType(String)))
        dtMap.Columns.Add(New DataColumn("CR_DAYS", GetType(String)))
        dtMap.Columns.Add(New DataColumn("CR_LIMIT", GetType(String)))

        dtMap.Columns.Add(New DataColumn("AMPHUR", GetType(String)))
        dtMap.Columns.Add(New DataColumn("CITY", GetType(String)))
        dtMap.Columns.Add(New DataColumn("ZIPCODE", GetType(String)))
        dtMap.Columns.Add(New DataColumn("TAMBON", GetType(String)))

        dtMap.Columns.Add(New DataColumn("ADDRESS", GetType(String)))
        dtMap.Columns.Add(New DataColumn("PHONE", GetType(String)))
        dtMap.Columns.Add(New DataColumn("FAX", GetType(String)))









        Dim i As Int16
        For i = 0 To m_dt.Rows.Count - 1
            dr = dtMap.NewRow()
            dr("SALE_SLIP_ID") = m_dt.Rows(i)("SALE_SLIP_ID").ToString()
            dr("DETAIL") = m_dt.Rows(i)("DETAIL").ToString()
            dr("PROD_CODE") = m_dt.Rows(i)("PROD_CODE").ToString()
            dr("QTY") = m_dt.Rows(i)("QTY").ToString()
            dr("PRICE") = m_dt.Rows(i)("PRICE").ToString()
            dr("AMOUNT") = m_dt.Rows(i)("AMOUNT").ToString()
            dr("C_ID") = m_dt.Rows(i)("C_ID").ToString()
            dr("NAME") = m_dt.Rows(i)("NAME").ToString()
            dr("CR_DAYS") = m_dt.Rows(i)("CR_DAYS").ToString()
            dr("CR_LIMIT") = m_dt.Rows(i)("CR_LIMIT").ToString()

            dr("AMPHUR") = m_dt.Rows(i)("AMPHUR").ToString()
            dr("CITY") = m_dt.Rows(i)("CITY").ToString()
            dr("ZIPCODE") = m_dt.Rows(i)("ZIPCODE").ToString()
            dr("TAMBON") = m_dt.Rows(i)("TAMBON").ToString()
            dr("ADDRESS") = m_dt.Rows(i)("ADDRESS").ToString()
            dr("PHONE") = m_dt.Rows(i)("PHONE").ToString()
            dr("FAX") = m_dt.Rows(i)("FAX").ToString()


            dtMap.Rows.Add(dr)
        Next


        Dim rpt As New ReportDocument()

        rpt.Load(Directory.GetCurrentDirectory() + "/SALE.rpt")


        For Each crTable As Table In rpt.Database.Tables
            Dim tableLogOnInfo As TableLogOnInfo = crTable.LogOnInfo
            Dim connectionInfo = tableLogOnInfo.ConnectionInfo
            crTable.ApplyLogOnInfo(tableLogOnInfo)
        Next


        rpt.SetDataSource(dtMap)

        ReportView.ReportSource = rpt

    End Sub
End Class