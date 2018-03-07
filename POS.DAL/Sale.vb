
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Globalization
Imports System.Data.Odbc

Imports POS.Model



Public Class Sale

    Public Function getCustomer(criteria As Model.Criteria.Sale.M_Customer) As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try


            Dim adp As New OdbcDataAdapter("usp_Cust_Read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure


            adp.SelectCommand.Parameters.AddWithValue("@ID", criteria.ID)

            adp.Fill(ds)

            Return ds.Tables(0)

        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);

            Throw ex
        Finally
            conn.Close()
        End Try
    End Function




    Public Function getStock_OnHand(criteria As Model.Criteria.Sale.M_Stock_OnHand) As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try

            Dim adp As New OdbcDataAdapter("usp_StockOnHand_Read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@PROD_CODE", criteria.PROD_CODE)
            adp.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function


    Public Function getMProduct(criteria As Model.Criteria.Sale.M_Stock_OnHand) As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try

            Dim adp As New OdbcDataAdapter("usp_MProduct_Read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@PROD_CODE", criteria.PROD_CODE)
            adp.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function



    Public Function getSaleSlip_Head(criteria As Model.Criteria.Sale.M_SaleSlip_Head) As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try

            Dim adp As New OdbcDataAdapter("usp_saleSlip_head_Read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            adp.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function


    Public Function getSaleSlip_Head_Running(criteria As Model.Criteria.Sale.M_SaleSlip_Head) As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try

            Dim adp As New OdbcDataAdapter("usp_saleSlip_head_running_read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            adp.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function



    Public Function getSaleSlip_Head_Doc(criteria As Model.Criteria.Sale.M_SaleSlip_Head) As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try

            Dim adp As New OdbcDataAdapter("usp_saleSlip_head_search_doc_Read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            adp.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function


    Public Function getSaleSlip_Tran(criteria As Model.Criteria.Sale.M_SaleSlip_Tran) As DataTable
        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)
        Dim ds As New DataSet()

        Try

            Dim adp As New OdbcDataAdapter("usp_saleSlip_tran_Read", conn)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            adp.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function

    ''' <summary>
    ''' '
    ''' </summary>
    ''' <param name="criteria"></param>
    ''' <param name="action"> insert or update </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaleSlip_Head_Save(criteria As Model.Criteria.Sale.M_SaleSlip_Head, action As String) As Int16

        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)

        Dim rows_affected As Int16 = 0

        Dim dt As DateTime = DateTime.Now
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")

        If action = "insert" Then

            If conn.State <> ConnectionState.Open Then
                conn.Close()
                conn.Open()
            End If


            Dim command As New OdbcCommand("[usp_saleSlip_Head_insert]", conn)
            command.Parameters.AddWithValue("@cust_id", criteria.cust_id)
            command.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            command.Parameters.AddWithValue("@description", criteria.description)
            command.Parameters.AddWithValue("@CreateDate", dt)
            command.Parameters.AddWithValue("@Sales_id", criteria.Sales_id)


            command.CommandType = CommandType.StoredProcedure
            rows_affected = command.ExecuteNonQuery()
            Return rows_affected
        ElseIf action = "update" Then
            If conn.State <> ConnectionState.Open Then
                conn.Close()
                conn.Open()
            End If

            Dim command As New OdbcCommand("[usp_saleSlip_Head_update]", conn)
            command.Parameters.AddWithValue("@cust_id", criteria.cust_id)
            command.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            command.Parameters.AddWithValue("@description", criteria.description)
            command.Parameters.AddWithValue("@UpdateDate", dt)


            command.CommandType = CommandType.StoredProcedure
            rows_affected = command.ExecuteNonQuery()
            Return rows_affected


        End If
    End Function

    Public Function SaleSlip_Tran_Save(criteria As Model.Criteria.Sale.M_SaleSlip_Tran, action As String) As Int16

        Dim connStr As String = My.Settings.ConnectionString
        Dim conn As Odbc.OdbcConnection = Common.DataHelper.getODBCConnectionObject(connStr)

        Dim rows_affected As Int16 = 0

        Dim dt As DateTime = DateTime.Now
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")

        If action = "insert" Then

            If conn.State <> ConnectionState.Open Then
                conn.Close()
                conn.Open()
            End If



            Dim command As New OdbcCommand("[usp_saleSlip_Tran_insert]", conn)
            command.Parameters.AddWithValue("@cust_id", criteria.cust_id)
            command.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            command.Parameters.AddWithValue("@Detail", criteria.Detail)
            command.Parameters.AddWithValue("@CreateDate", dt)
            command.Parameters.AddWithValue("@price", criteria.price)
            command.Parameters.AddWithValue("@amount", criteria.amount)

            command.Parameters.AddWithValue("@Prod_code", criteria.Prod_code)
            command.Parameters.AddWithValue("@Qty", criteria.Qty)


            command.CommandType = CommandType.StoredProcedure
            rows_affected = command.ExecuteNonQuery()
            Return rows_affected
        ElseIf action = "update" Then
            If conn.State <> ConnectionState.Open Then
                conn.Close()
                conn.Open()
            End If

            Dim command As New OdbcCommand("[usp_saleSlip_Tran_update]", conn)
            command.Parameters.AddWithValue("@cust_id", criteria.cust_id)
            command.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            command.Parameters.AddWithValue("@Detail", criteria.Detail)
            command.Parameters.AddWithValue("@UpdateDate", dt)
            command.Parameters.AddWithValue("@price", criteria.price)
            command.Parameters.AddWithValue("@amount", criteria.amount)
            command.Parameters.AddWithValue("@Prod_code", criteria.Prod_code)
            command.Parameters.AddWithValue("@Qty", criteria.Qty)


            command.CommandType = CommandType.StoredProcedure
            rows_affected = command.ExecuteNonQuery()
            Return rows_affected

        ElseIf action = "update_cancel" Then
            If conn.State <> ConnectionState.Open Then
                conn.Close()
                conn.Open()
            End If

            Dim command As New OdbcCommand("[usp_saleSlip_Tran_cancel_update]", conn)
            command.Parameters.AddWithValue("@cust_id", criteria.cust_id)
            command.Parameters.AddWithValue("@sale_slip_id", criteria.SaleSlip_id)
            command.Parameters.AddWithValue("@Detail", criteria.Detail)
            command.Parameters.AddWithValue("@UpdateDate", dt)
            command.Parameters.AddWithValue("@price", criteria.price)
            command.Parameters.AddWithValue("@amount", criteria.amount)
            command.Parameters.AddWithValue("@Prod_code", criteria.Prod_code)
            command.Parameters.AddWithValue("@Qty", criteria.Qty)


            command.CommandType = CommandType.StoredProcedure
            rows_affected = command.ExecuteNonQuery()
            Return rows_affected




        End If
    End Function


End Class

