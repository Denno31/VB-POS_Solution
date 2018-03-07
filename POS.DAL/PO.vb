

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Globalization

Imports POS.Model


Public Class PO


    Public Function getBOOK() As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try

            Dim adp As New Odbc.OdbcDataAdapter("usp_PO_Book_Read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.Fill(ds)

            Return ds.Tables(0)

        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function

End Class
