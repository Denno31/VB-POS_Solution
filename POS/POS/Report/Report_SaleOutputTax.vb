Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared

Public Class Report_SaleOutputTax

    Public m_dt As DataTable
    Public dateStart As String
    Public dateEnd As String

    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles ReportViewer.Load



        Dim dtMap As New DataTable("SALE")
        '*** DataTable Map DataSet.xsd ***//
        Dim dr As DataRow = Nothing
        dtMap.Columns.Add(New DataColumn("Sale_Slip_ID", GetType(String)))
        dtMap.Columns.Add(New DataColumn("CreateDate", GetType(String)))
        dtMap.Columns.Add(New DataColumn("NAME", GetType(String)))
        dtMap.Columns.Add(New DataColumn("AMOUNT", GetType(Decimal)))
        dtMap.Columns.Add(New DataColumn("TAX_ID", GetType(String)))
        dtMap.Columns.Add(New DataColumn("TAX", GetType(Decimal)))
        'dtMap.Columns.Add(New DataColumn("CR_DAYS", GetType(String)))
        'dtMap.Columns.Add(New DataColumn("CR_LIMIT", GetType(String)))


        Dim i As Int16
        For i = 0 To m_dt.Rows.Count - 1
            dr = dtMap.NewRow()
            dr("SALE_SLIP_ID") = m_dt.Rows(i)("SALE_SLIP_ID").ToString()
            dr("createDate") = m_dt.Rows(i)("createDate").ToString()
            dr("NAME") = m_dt.Rows(i)("NAME").ToString()
            dr("AMOUNT") = m_dt.Rows(i)("AMOUNT").ToString()
            dr("TAX_ID") = m_dt.Rows(i)("TAX_ID").ToString()
            dr("TAX") = m_dt.Rows(i)("TAX").ToString()
            'dr("CR_DAYS") = m_dt.Rows(i)("CR_DAYS").ToString()
            'dr("CR_LIMIT") = m_dt.Rows(i)("CR_LIMIT").ToString()

            dtMap.Rows.Add(dr)
        Next


        Dim rpt As New ReportDocument()

        rpt.Load(Directory.GetCurrentDirectory() + "/SaleOutputTax.rpt")


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


        rpt.SetDataSource(dtMap)

        ReportViewer.ReportSource = rpt


    End Sub
End Class