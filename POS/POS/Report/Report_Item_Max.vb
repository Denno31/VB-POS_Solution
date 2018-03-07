Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared


Public Class Report_Item_Max



    Public m_dt As DataTable

    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles ReportViewer.Load




        Dim dtMap As New DataTable("mproduct")
        '*** DataTable Map DataSet.xsd ***//
        Dim dr As DataRow = Nothing
        dtMap.Columns.Add(New DataColumn("CODE", GetType(String)))
        dtMap.Columns.Add(New DataColumn("NAME", GetType(String)))
        dtMap.Columns.Add(New DataColumn("MIN", GetType(String)))
        dtMap.Columns.Add(New DataColumn("MAX", GetType(Integer)))
        dtMap.Columns.Add(New DataColumn("LAST_QTY", GetType(Decimal)))



        Dim i As Int16
        For i = 0 To m_dt.Rows.Count - 1
            dr = dtMap.NewRow()
            dr("CODE") = m_dt.Rows(i)("CODE").ToString()
            dr("NAME") = m_dt.Rows(i)("NAME").ToString()
            dr("MIN") = m_dt.Rows(i)("MIN").ToString()
            dr("MAX") = m_dt.Rows(i)("MAX").ToString()
            dr("LAST_QTY") = m_dt.Rows(i)("LAST_QTY").ToString()


            dtMap.Rows.Add(dr)
        Next


        Dim rpt As New ReportDocument()

        rpt.Load(Directory.GetCurrentDirectory() + "/Product_Max.rpt")


        For Each crTable As Table In rpt.Database.Tables
            Dim tableLogOnInfo As TableLogOnInfo = crTable.LogOnInfo
            Dim connectionInfo = tableLogOnInfo.ConnectionInfo
            crTable.ApplyLogOnInfo(tableLogOnInfo)
        Next


        rpt.SetDataSource(dtMap)

        ReportViewer.ReportSource = rpt



    End Sub
End Class