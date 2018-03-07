﻿
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared

Public Class Report_SaleByCust

    Public m_dt As DataTable
    Public dateStart As String
    Public dateEnd As String
    Public CUST_ID As String
    Public CUST_NAME As String

    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles ReportViewer.Load




        Dim dtMap As New DataTable("SALE")
        '*** DataTable Map DataSet.xsd ***//
        Dim dr As DataRow = Nothing
        dtMap.Columns.Add(New DataColumn("Sale_Slip_ID", GetType(String)))
        dtMap.Columns.Add(New DataColumn("CreateDate", GetType(String)))
        dtMap.Columns.Add(New DataColumn("PROD_CODE", GetType(String)))
        dtMap.Columns.Add(New DataColumn("QTY", GetType(Integer)))
        dtMap.Columns.Add(New DataColumn("PRICE", GetType(Decimal)))
        dtMap.Columns.Add(New DataColumn("AMOUNT", GetType(Decimal)))
        'dtMap.Columns.Add(New DataColumn("C_ID", GetType(String)))
        'dtMap.Columns.Add(New DataColumn("NAME", GetType(String)))
        'dtMap.Columns.Add(New DataColumn("CR_DAYS", GetType(String)))
        'dtMap.Columns.Add(New DataColumn("CR_LIMIT", GetType(String)))


        Dim i As Int16
        For i = 0 To m_dt.Rows.Count - 1
            dr = dtMap.NewRow()
            dr("SALE_SLIP_ID") = m_dt.Rows(i)("SALE_SLIP_ID").ToString()
            dr("createDate") = m_dt.Rows(i)("createDate").ToString()
            dr("PROD_CODE") = m_dt.Rows(i)("PROD_CODE").ToString()
            dr("QTY") = m_dt.Rows(i)("QTY").ToString()
            dr("PRICE") = m_dt.Rows(i)("PRICE").ToString()
            dr("AMOUNT") = m_dt.Rows(i)("AMOUNT").ToString()
            'dr("C_ID") = m_dt.Rows(i)("C_ID").ToString()
            'dr("NAME") = m_dt.Rows(i)("NAME").ToString()
            'dr("CR_DAYS") = m_dt.Rows(i)("CR_DAYS").ToString()
            'dr("CR_LIMIT") = m_dt.Rows(i)("CR_LIMIT").ToString()

            dtMap.Rows.Add(dr)
        Next


        Dim rpt As New ReportDocument()

        rpt.Load(Directory.GetCurrentDirectory() + "/SaleByCust.rpt")


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

        Dim paramField3 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal3 As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim paramField4 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal4 As New CrystalDecisions.Shared.ParameterDiscreteValue()

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

        paramField3.ParameterFieldName = "CUST_ID"
        Dim str3 As String = CUST_ID
        discreteVal3.Value = str3
        paramField3.CurrentValues.Add(discreteVal3)
        paramFields.Add(paramField3)


        paramField4.ParameterFieldName = "CUST_NAME"
        Dim str4 As String = CUST_NAME
        discreteVal4.Value = str4
        paramField4.CurrentValues.Add(discreteVal4)
        paramFields.Add(paramField4)




        ReportViewer.ParameterFieldInfo = paramFields




        'rpt.SetParameterValue("@dateStart", dateStart)
        'rpt.SetParameterValue("@dateEnd", dateEnd)
        rpt.SetDataSource(dtMap)

        ReportViewer.ReportSource = rpt

    End Sub
End Class