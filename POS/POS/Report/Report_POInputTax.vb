

Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Public Class Report_POInputTax

    Public m_dt As DataTable
    Public dateStart As String
    Public dateEnd As String
    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles ReportViewer.Load


        Dim dtMap As New DataTable("PO")
        '*** DataTable Map DataSet.xsd ***//
        Dim dr As DataRow = Nothing
        dtMap.Columns.Add(New DataColumn("Docdate", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Docno", GetType(String)))

        dtMap.Columns.Add(New DataColumn("name", GetType(String)))
        dtMap.Columns.Add(New DataColumn("tax_id", GetType(String)))
        dtMap.Columns.Add(New DataColumn("TotalPrice", GetType(Decimal)))
        dtMap.Columns.Add(New DataColumn("tax", GetType(Decimal)))


        Dim i As Int16
        For i = 0 To m_dt.Rows.Count - 1
            dr = dtMap.NewRow()
            dr("Docdate") = m_dt.Rows(i)("docdate").ToString()
            dr("Docno") = m_dt.Rows(i)("Docno").ToString()

            dr("name") = m_dt.Rows(i)("name").ToString()
            dr("tax_id") = m_dt.Rows(i)("tax_id").ToString()
            dr("TotalPrice") = m_dt.Rows(i)("TotalPrice").ToString()
            dr("tax") = m_dt.Rows(i)("tax").ToString()

            dtMap.Rows.Add(dr)
        Next


        Dim rpt As New ReportDocument()

        rpt.Load(Directory.GetCurrentDirectory() + "/PO_InputTax.rpt")


        For Each crTable As Table In rpt.Database.Tables
            Dim tableLogOnInfo As TableLogOnInfo = crTable.LogOnInfo
            Dim connectionInfo = tableLogOnInfo.ConnectionInfo
            crTable.ApplyLogOnInfo(tableLogOnInfo)
        Next


        Dim paramFields As New CrystalDecisions.Shared.ParameterFields()
        Dim paramField As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim paramField2 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal2 As New CrystalDecisions.Shared.ParameterDiscreteValue()

        paramField.ParameterFieldName = "dateStart"
        Dim str As String = dateStart
        discreteVal.Value = str
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)



        paramField2.ParameterFieldName = "dateEnd"
        Dim str2 As String = dateEnd
        discreteVal2.Value = str2
        paramField2.CurrentValues.Add(discreteVal2)
        paramFields.Add(paramField2)
        ReportViewer.ParameterFieldInfo = paramFields




        'rpt.SetParameterValue("@dateStart", dateStart)
        'rpt.SetParameterValue("@dateEnd", dateEnd)
        rpt.SetDataSource(dtMap)

        ReportViewer.ReportSource = rpt
    End Sub
End Class