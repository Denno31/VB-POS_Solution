Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared

Public Class Report_PO


    Public m_dt As DataTable

    Private Sub ReportView_Load(sender As Object, e As EventArgs) Handles ReportView.Load


        Dim dtMap As New DataTable("PO")
        '*** DataTable Map DataSet.xsd ***//
        Dim dr As DataRow = Nothing
        dtMap.Columns.Add(New DataColumn("ItemNo", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Docno", GetType(String)))
        dtMap.Columns.Add(New DataColumn("VendorCode", GetType(String)))
        dtMap.Columns.Add(New DataColumn("RecQty", GetType(String)))
        dtMap.Columns.Add(New DataColumn("UnitPrice", GetType(String)))
        dtMap.Columns.Add(New DataColumn("TotalPrice", GetType(Decimal)))
        dtMap.Columns.Add(New DataColumn("VendorName", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Attn_Name", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Address", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Tambon", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Amphur", GetType(String)))
        dtMap.Columns.Add(New DataColumn("City", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Zipcode", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Phone", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Fax", GetType(String)))
        dtMap.Columns.Add(New DataColumn("CR_DAYS", GetType(String)))


        Dim i As Int16
        For i = 0 To m_dt.Rows.Count - 1
            dr = dtMap.NewRow()
            dr("ItemNo") = m_dt.Rows(i)("ItemNo").ToString()
            dr("Docno") = m_dt.Rows(i)("Docno").ToString()
            dr("VendorCode") = m_dt.Rows(i)("VendorCode").ToString()
            dr("RecQty") = m_dt.Rows(i)("RecQty").ToString()
            dr("UnitPrice") = m_dt.Rows(i)("UnitPrice").ToString()
            dr("TotalPrice") = m_dt.Rows(i)("TotalPrice").ToString()
            dr("VendorName") = m_dt.Rows(i)("VendorName").ToString()
            dr("Attn_Name") = m_dt.Rows(i)("Attn_Name").ToString()
            dr("Address") = m_dt.Rows(i)("Address").ToString()

            dr("Tambon") = m_dt.Rows(i)("Tambon").ToString()
            dr("Amphur") = m_dt.Rows(i)("Amphur").ToString()
            dr("City") = m_dt.Rows(i)("City").ToString()
            dr("Zipcode") = m_dt.Rows(i)("Zipcode").ToString()

            dr("Phone") = m_dt.Rows(i)("Phone").ToString()
            dr("Fax") = m_dt.Rows(i)("Fax").ToString()
            dr("CR_DAYS") = m_dt.Rows(i)("CR_DAYS").ToString()
            dtMap.Rows.Add(dr)
        Next



        Dim rpt As New ReportDocument()

        rpt.Load(Directory.GetCurrentDirectory() + "/PO.rpt")


        For Each crTable As Table In rpt.Database.Tables
            Dim tableLogOnInfo As TableLogOnInfo = crTable.LogOnInfo
            Dim connectionInfo = tableLogOnInfo.ConnectionInfo
            crTable.ApplyLogOnInfo(tableLogOnInfo)
        Next


        rpt.SetDataSource(dtMap)

        ReportView.ReportSource = rpt


    End Sub
End Class