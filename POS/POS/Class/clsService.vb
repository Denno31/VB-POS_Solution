Imports System.Data.OleDb
Imports System.Data
Imports System.Data.Odbc

Public Class clsService

    Dim clsSett As New mySetting(mySetting.Config.ApplicationFile)
    Dim clsLang As New clsLangMsg
    Dim strConnectionString As String = "Provider=sqloledb;Data Source=localhost;Initial Catalog=POS;User Id=SA;Password=nopassword;"
    Dim SecurityKey As String = "SAHARUT-YOURPOS"

    Public Function TestConnection() As Boolean
        Return True
    End Function

    Public Function getConnectionString() As String
        Return strConnectionString
    End Function

    Public Function TestDBConnect() As Boolean
        '   Dim objcon As New System.Data.OleDb.OleDbConnection(strConnectionString)

        Dim objcon As New System.Data.Odbc.OdbcConnection(strConnectionString)

        Try
            objcon.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
        objcon.Dispose()
    End Function

    Public Function InitConnection() As Boolean
        Dim isConnected As Boolean = False
        Dim objCon As New OdbcConnection
        Try
            objCon = New OdbcConnection(strConnectionString)
            objCon.Open()
            isConnected = True
        Catch ex As Exception
            isConnected = False
        End Try
        objCon.Dispose()
        Return isConnected
    End Function


    Public Function getDataSet(ByVal SQL As String) As System.Data.DataSet

        Dim objCon As New Odbc.OdbcConnection
        Dim objDs As New System.Data.DataSet("Table1")
        Dim objDa As Odbc.OdbcDataAdapter = Nothing
        'MsgBox("strConnectionString")
        Try
            'MsgBox(strConnectionString)
            'objCon.ConnectionString = strConnectionString
            'objCon.Open()
            objDa = New Odbc.OdbcDataAdapter(SQL, strConnectionString)
            objDa.Fill(objDs, "Table1")

        Catch ex As Exception
            'MsgBox(ex.Message.ToString())
            'MsgBox(strConnectionString)
            MessageBox.Show(ex.Message, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            'objDs = Nothing
            objDa.Dispose()
            objCon.Dispose()
        End Try
        Return objDs

    End Function


    Public Function ExecCommand(ByVal SQL As String) As Boolean

        Dim objCon As New Odbc.OdbcConnection
        Dim objCmd As New Odbc.OdbcCommand
        Try
            objCon.ConnectionString = strConnectionString
            objCon.Open()
            objCmd.CommandText = SQL
            objCmd.Connection = objCon
            objCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            objCmd.Dispose()
            objCon.Dispose()
        End Try

    End Function


    Public Function ExecCommandRowRet(ByVal SQL As String) As Integer
       Dim objCon As New Odbc.OdbcConnection
        Dim objCmd As New Odbc.OdbcCommand
        Dim nRow As Integer = 0
        Try
            objCon.ConnectionString = strConnectionString
            objCon.Open()
            objCmd.CommandText = SQL
            objCmd.Connection = objCon
            nRow = objCmd.ExecuteNonQuery()
            'Return True
        Catch ex As Exception
            nRow = 0
        Finally
            objCmd.Dispose()
            objCon.Dispose()
        End Try

        Return nRow

    End Function

    Public Function getDataSetTableName(ByVal SQL As String, ByVal TableName As String) As DataSet
        Dim objCon As New Odbc.OdbcConnection
        Dim objDs As New DataSet
        Dim objDa As Odbc.OdbcDataAdapter = Nothing
        Try
            ''objCon.ConnectionString = My.Settings.ConnectionString.ToString()
            ''objCon.Open()
            objDa = New Odbc.OdbcDataAdapter(SQL, strConnectionString)
            objDa.Fill(objDs, TableName)

        Catch ex As Exception
            '            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            'objDs = Nothing
            objDa.Dispose()
            objCon.Dispose()
        End Try
        Return objDs
    End Function

    Public Function getExistBarcode(ByVal Barcode As String) As DataSet
        Dim oDataset As New DataSet("Table1")
        Dim strSql As String = ""
        Try
            strSql = "Select itemcode, UomId,1 as Qty,1 as Ratio from tb_mas_item Where Barcode='" & Barcode & "' or ItemCode='" & Barcode & "'"
            oDataset = getDataSet(strSql)
            If oDataset.Tables(0).Rows.Count > 0 Then
                Return oDataset
            Else
                strSql = "Select ItemCode,UomId,1 as Qty,Ratio from tb_mas_barcode where barcode='" & Barcode & "'"
                oDataset = getDataSet(strSql)
                If oDataset.Tables(0).Rows.Count > 0 Then
                    Return oDataset
                End If
            End If
        Catch ex As Exception

        End Try
        Return oDataset
    End Function

    Public Function UpdateDataset(ByVal oDataset As System.Data.DataSet, ByVal SQL As String, ByVal TableName As String) As Boolean ' System.Data.DataSet
        Dim objCon As New OdbcConnection
        Dim objDA As New OdbcDataAdapter
        Dim objDataset As New System.Data.DataSet

        Try

            objCon.ConnectionString = strConnectionString
            objCon.Open()
            objDA = New OdbcDataAdapter(SQL, objCon)

            Dim builder As New OdbcCommandBuilder(objDA)
            Try
                objDA.InsertCommand = builder.GetInsertCommand
                objDA.DeleteCommand = builder.GetDeleteCommand
                objDA.UpdateCommand = builder.GetUpdateCommand
                'builder.GetUpdateCommand()
                objDA.Update(oDataset, TableName) ' "table1")
                Return True
            Catch ex As Exception
                'MsgBox(ex.Message)
                Return False
            Finally
                'objDA = New OleDbDataAdapter(SQL, objCon)
                'objDA.Fill(objDataset, "table1")
            End Try

        Catch ex As Exception
            objDA.Dispose()
            objCon.Dispose()
        End Try

        'Return objDataset

    End Function


    Private Function getItemLineNumber(ByVal DocNo As String) As Integer
        Dim strSql As String = "Select max(LineNumber) from tb_ic_trn_detail Where DocNo='" & DocNo & "'"
        Dim oDataset As New DataSet
        Dim nReturn As Integer = 1
        Try
            oDataset = getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    nReturn = Val(oDataset.Tables(0).Rows(0).Item(0).ToString) + 1
                End If
            End If
        Catch ex As Exception

        End Try
        Return nReturn
    End Function

    Private Function getItemLineNumberWh(ByVal DocNo As String) As Integer
        Dim strSql As String = "Select max(LineNumber) from tb_wh_trn_detail Where DocNo='" & DocNo & "'"
        Dim oDataset As New DataSet
        Dim nReturn As Integer = 1
        Try
            oDataset = getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    nReturn = Val(oDataset.Tables(0).Rows(0).Item(0).ToString) + 1
                End If
            End If
        Catch ex As Exception

        End Try
        Return nReturn
    End Function

    Public Function SaveShareCarryDown(ByVal sKey As String, ByVal DocNo As String, ByVal DocDate As String, _
    ByVal BranchId As String, ByVal ShareHolder As String, ByVal Qty As Single, _
    ByVal Price As Single, ByVal Amount As Single, ByVal sUser As String, Optional ByVal Remark As String = "") As String

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0

        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                strSql = "Select 1 from tb_trn_share_movement Where DocNO='" & DocNo & "' and ShareHolder='" & ShareHolder & "'"
                oDataset = getDataSet(strSql)

                If oDataset.Tables(0).Rows.Count = 0 Then  '// New item
                    strSql = " INSERT INTO TB_TRN_SHARE_MOVEMENT"
                    strSql = strSql & " (DocNo"
                    strSql = strSql & " ,DocDate"
                    strSql = strSql & " ,BranchId"
                    strSql = strSql & " ,ShareHolder"
                    strSql = strSql & " ,CaryDown_Share"
                    strSql = strSql & " ,CaryDown_amount"
                    strSql = strSql & " ,Receive_Share"
                    strSql = strSql & " ,Receive_amount"
                    strSql = strSql & " ,Issue_Share"
                    strSql = strSql & " ,Issue_amount"
                    strSql = strSql & " ,CarryFwd_Share"
                    strSql = strSql & " ,CarryFwd_amount"
                    strSql = strSql & " ,Remark"
                    strSql = strSql & " ,ModifyBy"
                    strSql = strSql & " ,ModifyDate)"
                    strSql = strSql & " Values("
                    strSql = strSql & "'" & DocNo & "'"
                    strSql = strSql & ",'" & DocDate & "'"
                    strSql = strSql & ",'" & BranchId & "'"
                    strSql = strSql & ",'" & ShareHolder & "'"
                    strSql = strSql & "," & Qty ' & "'"
                    strSql = strSql & "," & Amount ' & "'"
                    strSql = strSql & "," & 0 ' รับ
                    strSql = strSql & "," & 0 ' & "'"
                    strSql = strSql & "," & 0 'จาย
                    strSql = strSql & "," & 0 ' & "'"
                    strSql = strSql & "," & Qty ' & คงเหลือ
                    strSql = strSql & "," & Amount ' & "'"
                    strSql = strSql & ",'" & Remark & "' "
                    strSql = strSql & ",'" & sUser & "'"
                    strSql = strSql & ",getDate())"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed."
                    End If
                Else        '// Existing item
                    strSql = " UPDATE TB_TRN_SHARE_MOVEMENT "
                    strSql = strSql & " SET  DocNo  = '" & DocNo & "'"
                    strSql = strSql & " , DocDate  =  '" & DocDate & "'"
                    strSql = strSql & " , BranchId  = '" & BranchId & "'"
                    strSql = strSql & " , ShareHolder  =  '" & ShareHolder & "'"
                    strSql = strSql & " , CaryDown_Share  = " & Qty
                    strSql = strSql & " , CaryDown_amount  =" & Amount
                    strSql = strSql & " , Receive_Share  = 0"
                    strSql = strSql & " , Receive_amount  =0"
                    strSql = strSql & " , Issue_Share  = 0"
                    strSql = strSql & " , Issue_amount  = 0"
                    strSql = strSql & " , CarryFwd_Share  =" & Qty
                    strSql = strSql & " , CarryFwd_amount  = " & Amount
                    strSql = strSql & " , Remark  = '" & Remark & "'"
                    strSql = strSql & " , ModifyBy  = '" & sUser & "'"
                    strSql = strSql & " , ModifyDate  = getDate()"
                    strSql = strSql & " WHERE DocNo='" & DocNo & "' and ShareHolder='" & ShareHolder & "'"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed."
                    End If
                End If
                '// Update Share in contact
                strSql = "Update tb_mas_contact set sharetotal=" & Qty & ",sharevalue=" & Amount & " Where memberid='" & ShareHolder & "'"
                ExecCommand(strSql)
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
        Finally
            objCmd.Dispose()
            objConn.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function SaveShareTrans(ByVal sKey As String, ByVal DocNo As String, ByVal DocDate As String, _
    ByVal BranchId As String, ByVal ShareHolder As String, ByVal InQty As Single, _
    ByVal InPrice As Single, ByVal OutQty As Single, _
    ByVal OutPrice As Single, ByVal sUser As String, Optional ByVal Remark As String = "") As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim objTran As OleDbTransaction = Nothing
        Dim oDataset As New DataSet
        Dim oDatasetContact As New DataSet
        Dim nBeginShare As Integer = 0
        Dim nBeginValue As Single = 0

        Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                strSql = "Select * from tb_trn_share_movement Where ShareHolder='" & ShareHolder & "' and TrnId >=(select top 1 TrnId from tb_trn_share_movement Where DocNO='" & DocNo & "' and ShareHolder='" & ShareHolder & "') order by TrnId"
                oDataset = getDataSet(strSql)
                '//get หุ้นตั้งต้น
                strSql = "select sharetotal,sharevalue from tb_mas_contact where memberid='" & ShareHolder & "'"
                oDatasetContact = getDataSet(strSql)
                If oDatasetContact.Tables(0).Rows.Count > 0 Then
                    nBeginShare = Val(oDatasetContact.Tables(0).Rows(0).Item("sharetotal").ToString)
                    nBeginValue = Val(oDatasetContact.Tables(0).Rows(0).Item("sharevalue").ToString)
                End If

                If oDataset.Tables(0).Rows.Count = 0 Then  '// New item
                    strSql = " INSERT INTO TB_TRN_SHARE_MOVEMENT"
                    strSql = strSql & " (DocNo"
                    strSql = strSql & " ,DocDate"
                    strSql = strSql & " ,BranchId"
                    strSql = strSql & " ,ShareHolder"
                    'strSql = strSql & " ,CaryDown_Share"
                    'strSql = strSql & " ,CaryDown_amount"
                    strSql = strSql & " ,Receive_Share"
                    strSql = strSql & " ,Receive_amount"
                    strSql = strSql & " ,Issue_Share"
                    strSql = strSql & " ,Issue_amount"
                    strSql = strSql & " ,CarryFwd_Share"
                    strSql = strSql & " ,CarryFwd_amount"
                    strSql = strSql & " ,Remark"
                    strSql = strSql & " ,ModifyBy"
                    strSql = strSql & " ,ModifyDate)"
                    strSql = strSql & " Values("
                    strSql = strSql & "'" & DocNo & "'"
                    strSql = strSql & ",'" & DocDate & "'"
                    strSql = strSql & ",'" & BranchId & "'"
                    strSql = strSql & ",'" & ShareHolder & "'"
                    'strSql = strSql & "," & Qty ' & "'"
                    'strSql = strSql & "," & Amount ' & "'"
                    strSql = strSql & "," & InQty ' รับ
                    strSql = strSql & "," & InPrice ' & "'"
                    strSql = strSql & "," & OutQty 'จาย
                    strSql = strSql & "," & OutPrice ' & "'"
                    strSql = strSql & "," & InQty + nBeginShare - OutQty ' คงเหลือ
                    strSql = strSql & "," & InPrice + nBeginValue - OutPrice ' 
                    strSql = strSql & ",'" & Remark & "' "
                    strSql = strSql & ",'" & sUser & "'"
                    strSql = strSql & ",getDate())"


                    nTotalShare = InQty + nBeginShare - OutQty
                    nTotalValues = InPrice + nBeginValue - OutPrice

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                    isTrans = True
                    objCmd.Transaction = objTran
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                        If isTrans Then objTran.Rollback()
                    Else
                        '//ปรับปรุงค่าหุ้นตั้งต้น

                        strSql = "Update tb_mas_contact set ShareTotal=" & nTotalShare & ",ShareValue=" & nTotalValues & " Where MemberId='" & ShareHolder & "'"
                        objCmd.CommandText = strSql
                        objCmd.ExecuteNonQuery()
                        'ExecCommand(strSql)

                        strReturn = "0//Save data completed."

                        If isTrans Then
                            objTran.Commit()
                        End If

                    End If
                Else        '// Existing item
                    strSql = " UPDATE TB_TRN_SHARE_MOVEMENT "
                    strSql = strSql & " SET  DocNo  = '" & DocNo & "'"
                    strSql = strSql & " , DocDate  =  '" & DocDate & "'"
                    strSql = strSql & " , BranchId  = '" & BranchId & "'"
                    strSql = strSql & " , ShareHolder  =  '" & ShareHolder & "'"
                    'strSql = strSql & " , CaryDown_Share  = " & Qty
                    'strSql = strSql & " , CaryDown_amount  =" & Amount
                    strSql = strSql & " , Receive_Share  = " & InQty
                    strSql = strSql & " , Receive_amount  =" & InPrice
                    strSql = strSql & " , Issue_Share  = " & OutQty
                    strSql = strSql & " , Issue_amount  = " & OutPrice
                    strSql = strSql & " , CarryFwd_Share  =CarryFwd_Share+(" & InQty & "-Receive_Share)-(" & OutQty & "-Issue_Share)"
                    strSql = strSql & " , CarryFwd_amount  =CarryFwd_amount+(" & InPrice & "-Receive_amount)-(" & OutPrice & "-Issue_amount)"
                    strSql = strSql & " , Remark  = '" & Remark & "'"
                    strSql = strSql & " , ModifyBy  = '" & sUser & "'"
                    strSql = strSql & " , ModifyDate  = getDate()"
                    strSql = strSql & " WHERE DocNo='" & DocNo & "' and ShareHolder='" & ShareHolder & "'"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                    isTrans = True
                    objCmd.Transaction = objTran
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                        If isTrans Then objTran.Rollback()
                    Else


                        nTotalShare = (InQty - oDataset.Tables(0).Rows(0).Item("Receive_Share")) - (OutQty - oDataset.Tables(0).Rows(0).Item("Issue_Share"))
                        nTotalValues = (InPrice - oDataset.Tables(0).Rows(0).Item("Receive_amount")) - (OutPrice - oDataset.Tables(0).Rows(0).Item("Issue_amount"))
                        '//ปรับปรุงค่าหุ้นตั้งต้น

                        strSql = "Update tb_mas_contact set ShareTotal=ShareTotal+" & nTotalShare & ",ShareValue=ShareValue+" & nTotalValues & " Where MemberId='" & ShareHolder & "'"
                        objCmd.CommandText = strSql
                        objCmd.ExecuteNonQuery()

                        Dim i As Integer = 0

                        nBeginShare = oDataset.Tables(0).Rows(0).Item("CarryFwd_Share") + (InQty - oDataset.Tables(0).Rows(0).Item("Receive_Share")) - (OutQty - oDataset.Tables(0).Rows(0).Item("Issue_Share"))
                        nBeginValue = oDataset.Tables(0).Rows(0).Item("CarryFwd_amount") + (InPrice - oDataset.Tables(0).Rows(0).Item("Receive_amount")) - (OutPrice - oDataset.Tables(0).Rows(0).Item("Issue_amount"))
                        For i = 1 To oDataset.Tables(0).Rows.Count - 1
                            strSql = " UPDATE TB_TRN_SHARE_MOVEMENT "
                            strSql = strSql & " set CarryFwd_Share  =" & (nBeginShare + oDataset.Tables(0).Rows(i).Item("Receive_Share") - oDataset.Tables(0).Rows(i).Item("Issue_Share")).ToString  'CarryFwd_Share+(" & InQty & "-Receive_Share)-(" & OutQty & "-Issue_Share)"
                            strSql = strSql & " , CarryFwd_amount  =" & (nBeginValue + oDataset.Tables(0).Rows(i).Item("Receive_amount") - oDataset.Tables(0).Rows(i).Item("Issue_amount")).ToString  'CarryFwd_amount+(" & InPrice & "-Receive_amount)-(" & OutPrice & "-Issue_amount)"
                            strSql = strSql & " , ModifyBy  = '" & sUser & "'"
                            strSql = strSql & " , ModifyDate  = getDate()"
                            strSql = strSql & " WHERE TrnId=" & oDataset.Tables(0).Rows(i).Item("TrnId").ToString
                            objCmd.CommandText = strSql
                            objCmd.ExecuteNonQuery()

                            nBeginShare = (nBeginShare + oDataset.Tables(0).Rows(i).Item("Receive_Share") - oDataset.Tables(0).Rows(i).Item("Issue_Share"))
                            nBeginValue = (nBeginValue + oDataset.Tables(0).Rows(i).Item("Receive_amount") - oDataset.Tables(0).Rows(i).Item("Issue_amount"))

                        Next

                        strReturn = "0//Save data completed."

                        If isTrans Then objTran.Commit()

                    End If


                End If




            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function SaveBankCarryDown(ByVal sKey As String, ByVal DocNo As String, ByVal DocDate As String, _
ByVal BranchId As String, ByVal TrnId As String, _
ByVal AccNo As String, ByVal Amount As Single, ByVal sUser As String, Optional ByVal Remark As String = "") As String

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        'Dim objTran As OleDbTransaction
        'Dim isTrans As Boolean = False
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                strSql = "Select 1 from tb_trn_bank_movement Where DocNO='" & DocNo & "' and TrnId=" & Val(TrnId).ToString  ' & "'"
                oDataset = getDataSet(strSql)

                If oDataset.Tables(0).Rows.Count = 0 Then  '// New item
                    strSql = " INSERT INTO TB_TRN_BANK_MOVEMENT"
                    strSql = strSql & " (DocNo,ItemDesc"
                    strSql = strSql & " ,DocDate"
                    strSql = strSql & " ,BranchId"
                    strSql = strSql & " ,AccNo"
                    strSql = strSql & " ,CaryDown_amount"
                    strSql = strSql & " ,Receive_amount"
                    strSql = strSql & " ,Issue_amount"
                    strSql = strSql & " ,CarryFwd_amount"
                    strSql = strSql & " ,Remark"
                    strSql = strSql & " ,ModifyBy"
                    strSql = strSql & " ,ModifyDate)"
                    strSql = strSql & " Values('" & DocNo & "'"
                    strSql = strSql & ",'ยอดยกมา'"
                    strSql = strSql & ",'" & DocDate & "'"             '//convert(varchar(10), getDate(),102)"
                    strSql = strSql & ",'" & BranchId & "'"
                    strSql = strSql & ",'" & AccNo & "'"
                    strSql = strSql & "," & Amount ' & "ยกมา"
                    strSql = strSql & ",0 " 'รับ"
                    strSql = strSql & ",0 "  'จ่าย
                    strSql = strSql & "," & Amount  'คงเหลือ
                    strSql = strSql & ",'" & Remark & "' "
                    strSql = strSql & ",'" & sUser & "'"
                    strSql = strSql & ",getDate())"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    'objTran = objConn.BeginTransaction()'IsolationLevel.ReadCommitted)
                    'isTrans = True
                    'objCmd.Transaction = objTran
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed."
                    End If
                Else        '// Existing item
                    strSql = " UPDATE TB_TRN_BANK_MOVEMENT "
                    strSql = strSql & " SET  DocNo  = '" & DocNo & "'"
                    strSql = strSql & " , DocDate  =  '" & DocDate & "'"
                    strSql = strSql & " , BranchId  = '" & BranchId & "'"
                    strSql = strSql & " , AccNo  =  '" & AccNo & "'"
                    strSql = strSql & " , CaryDown_amount  =" & Amount
                    strSql = strSql & " , Receive_amount  =0"
                    strSql = strSql & " , Issue_amount  = 0"
                    strSql = strSql & " , CarryFwd_amount  = " & Amount
                    strSql = strSql & " , Remark  = '" & Remark & "'"
                    strSql = strSql & " , ModifyBy  = '" & sUser & "'"
                    strSql = strSql & " , ModifyDate  = getDate()"
                    strSql = strSql & " WHERE DocNo='" & DocNo & "' and TrnId=" & TrnId   ' & "'"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed."
                    End If
                End If
                ''// Update Share in contact
                'strSql = "Update tb_mas_contact set sharetotal=" & Qty & ",sharevalue=" & Amount & " Where memberid='" & ShareHolder & "'"
                'ExecCommand(strSql)
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
        Finally
            objCmd.Dispose()
            objConn.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function SaveLoanPay(ByVal sDocType As String, ByVal sKey As String, ByVal BranchId As String, _
ByVal sPrjNO As String, ByVal sLoanNo As String, ByVal PayAmount As Single, ByVal DocNo As String, ByVal DocDate As Date, _
ByVal sUser As String, Optional ByVal Remark As String = "") As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim AccNo As String = sPrjNO & sLoanNo
        Dim nBeginValue As Single = 0

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                strSql = " SELECT     PrjNo, LoanNo, TPrefix, CustGroup, CustId, Name, PrjName, AppAmount, PaidAmount"
                strSql = strSql & " FROM V024_LOAN_PAID_REMAIN"
                strSql = strSql & " Where PrjNo+LoanNo='" & AccNo & "'"
                oDataset = getDataSet(strSql)


                If oDataset.Tables(0).Rows.Count > 0 Then  '// New item

                    If oDataset.Tables(0).Rows(0).Item("PaidAmount") + PayAmount > oDataset.Tables(0).Rows(0).Item("AppAmount") Then
                        strReturn = "102//จำนวนที่จ่ายมากกว่าจำนวนอนุมัติ"
                    Else
                        strSql = " INSERT INTO TB_TRN_LOAN_PAID"
                        strSql = strSql & " (DocType,DocNo"
                        strSql = strSql & " ,DocDate"
                        strSql = strSql & " ,BranchId"
                        strSql = strSql & " ,PrjNo"
                        strSql = strSql & " ,LoanNo"
                        strSql = strSql & " ,Money1"
                        strSql = strSql & " ,Remark"
                        strSql = strSql & " ,ModifyBy"
                        strSql = strSql & " ,ModifyDate)"
                        strSql = strSql & " Values('" & sDocType & "','" & DocNo & "'"
                        strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                        strSql = strSql & ",'" & BranchId & "'"
                        strSql = strSql & ",'" & sPrjNO & "'"
                        strSql = strSql & ",'" & sLoanNo & "'"
                        strSql = strSql & "," & PayAmount ' & "'"
                        strSql = strSql & ",'" & Remark & "' "
                        strSql = strSql & ",'" & sUser & "'"
                        strSql = strSql & ",getDate())"
                        objCmd.CommandText = strSql
                        nResult = objCmd.ExecuteNonQuery
                        If nResult = 1 Then
                            '// อ่านค่าล่าสุด

                            strSql = "Select  isnull(LoanBalance,0) from TB_TRN_LOAN_CONTRACT Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                            oDataset = oService.getDataSet(strSql)
                            If oDataset.Tables(0).Rows.Count > 0 Then
                                nBeginValue = oDataset.Tables(0).Rows(0).Item(0)
                            Else
                                nBeginValue = 0
                            End If
                            strSql = "Update TB_TRN_LOAN_CONTRACT set lastdate='" & oConFig.Date2db(DocDate).ToString & "', LoanBalance=isnull(LoanBalance,0)+" & PayAmount & " Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                            objCmd.CommandText = strSql
                            nResult = objCmd.ExecuteNonQuery

                            strSql = "Insert into TB_TRN_LOAN_MOVEMENT"
                            strSql = strSql & " ("
                            strSql = strSql & " [RefNo]"
                            strSql = strSql & " ,[BranchId]"
                            strSql = strSql & " ,[DocDate]"
                            strSql = strSql & " ,[TrnType]"
                            strSql = strSql & " ,[PrjNo]"
                            strSql = strSql & " ,[LoanNo]"
                            strSql = strSql & " ,[CaryDown_amount]"
                            strSql = strSql & " ,[Receive_amount]"
                            strSql = strSql & " ,[Issue_amount]"
                            strSql = strSql & " ,[CarryFwd_amount]"
                            strSql = strSql & " ,[LastDate]"
                            strSql = strSql & " ,[Remark]"
                            strSql = strSql & " ,[ModifyBy]"
                            strSql = strSql & " ,[ModifyDate]"
                            strSql = strSql & " ,[isPosted])"
                            strSql = strSql & " Values("
                            strSql = strSql & "'" & DocNo & "'"
                            strSql = strSql & ",'" & BranchId & "'"
                            strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                            strSql = strSql & ",1"
                            strSql = strSql & ",'" & sPrjNO & "'"
                            strSql = strSql & ",'" & sLoanNo & "'"
                            strSql = strSql & ",0"
                            strSql = strSql & "," & PayAmount
                            strSql = strSql & ",0"
                            strSql = strSql & "," & nBeginValue + PayAmount
                            strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                            strSql = strSql & ",'" & Remark & "'"
                            strSql = strSql & ",'" & sUser & "'"
                            strSql = strSql & ",getdate()"
                            strSql = strSql & ",0"
                            strSql = strSql & " )"

                            objCmd.CommandText = strSql
                            nResult = objCmd.ExecuteNonQuery

                            If nResult = 0 Then
                                strReturn = "101//Unknow error can not save this data."
                                If isTrans Then objTran.Rollback()
                            Else
                                strReturn = "0//Save data completed."
                                If isTrans Then objTran.Commit()
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function SaveLoanPay_Manual(ByVal sDocType As String, ByVal sKey As String, ByVal BranchId As String, _
ByVal sPrjNO As String, ByVal sLoanNo As String, ByVal PayAmount As Single, ByVal DocNo As String, ByVal DocDate As Date, _
ByVal sUser As String, Optional ByVal Remark As String = "") As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim AccNo As String = sPrjNO & sLoanNo
        Dim nBeginValue As Single = 0

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                strSql = " SELECT     PrjNo, LoanNo, TPrefix, CustGroup, CustId, Name, PrjName, AppAmount, PaidAmount,LoanBalance"
                strSql = strSql & " FROM V024_LOAN_PAID_REMAIN"
                strSql = strSql & " Where PrjNo+LoanNo='" & AccNo & "'"
                oDataset = getDataSet(strSql)


                If oDataset.Tables(0).Rows.Count > 0 Then  '// New item

                    If oDataset.Tables(0).Rows(0).Item("LoanBalance") + PayAmount > oDataset.Tables(0).Rows(0).Item("AppAmount") Then
                        strReturn = "102//จำนวนที่จ่ายมากกว่าจำนวนอนุมัติ"
                    Else
                        strSql = " INSERT INTO TB_TRN_LOAN_PAID"
                        strSql = strSql & " (DocType,DocNo"
                        strSql = strSql & " ,DocDate"
                        strSql = strSql & " ,BranchId"
                        strSql = strSql & " ,PrjNo"
                        strSql = strSql & " ,LoanNo"
                        strSql = strSql & " ,Money1"
                        strSql = strSql & " ,Remark"
                        strSql = strSql & " ,ModifyBy"
                        strSql = strSql & " ,ModifyDate)"
                        strSql = strSql & " Values('" & sDocType & "','" & DocNo & "'"
                        strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                        strSql = strSql & ",'" & BranchId & "'"
                        strSql = strSql & ",'" & sPrjNO & "'"
                        strSql = strSql & ",'" & sLoanNo & "'"
                        strSql = strSql & "," & PayAmount ' & "'"
                        strSql = strSql & ",'" & Remark & "' "
                        strSql = strSql & ",'" & sUser & "'"
                        strSql = strSql & ",getDate())"
                        objCmd.CommandText = strSql
                        nResult = objCmd.ExecuteNonQuery
                        If nResult = 1 Then
                            '// อ่านค่าล่าสุด

                            strSql = "Select  isnull(LoanBalance,0) from TB_TRN_LOAN_CONTRACT Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                            oDataset = oService.getDataSet(strSql)
                            If oDataset.Tables(0).Rows.Count > 0 Then
                                nBeginValue = oDataset.Tables(0).Rows(0).Item(0)
                            Else
                                nBeginValue = 0
                            End If
                            strSql = "Update TB_TRN_LOAN_CONTRACT set lastdate='" & oConFig.Date2db(DocDate).ToString & "', LoanBalance=isnull(LoanBalance,0)+" & PayAmount & " Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                            objCmd.CommandText = strSql
                            nResult = objCmd.ExecuteNonQuery

                            strSql = "Insert into TB_TRN_LOAN_MOVEMENT"
                            strSql = strSql & " ("
                            strSql = strSql & " [RefNo]"
                            strSql = strSql & " ,[BranchId]"
                            strSql = strSql & " ,[DocDate]"
                            strSql = strSql & " ,[TrnType]"
                            strSql = strSql & " ,[PrjNo]"
                            strSql = strSql & " ,[LoanNo]"
                            strSql = strSql & " ,[CaryDown_amount]"
                            strSql = strSql & " ,[Receive_amount]"
                            strSql = strSql & " ,[Issue_amount]"
                            strSql = strSql & " ,[CarryFwd_amount]"
                            strSql = strSql & " ,[LastDate]"
                            strSql = strSql & " ,[Remark]"
                            strSql = strSql & " ,[ModifyBy]"
                            strSql = strSql & " ,[ModifyDate]"
                            strSql = strSql & " ,[isPosted])"
                            strSql = strSql & " Values("
                            strSql = strSql & "'" & DocNo & "'"
                            strSql = strSql & ",'" & BranchId & "'"
                            strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                            strSql = strSql & ",1"
                            strSql = strSql & ",'" & sPrjNO & "'"
                            strSql = strSql & ",'" & sLoanNo & "'"
                            strSql = strSql & ",0"
                            strSql = strSql & "," & PayAmount
                            strSql = strSql & ",0"
                            strSql = strSql & "," & nBeginValue + PayAmount
                            strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                            strSql = strSql & ",'" & Remark & "'"
                            strSql = strSql & ",'" & sUser & "'"
                            strSql = strSql & ",getdate()"
                            strSql = strSql & ",0"
                            strSql = strSql & " )"

                            objCmd.CommandText = strSql
                            nResult = objCmd.ExecuteNonQuery

                            If nResult = 0 Then
                                strReturn = "101//Unknow error can not save this data."
                                If isTrans Then objTran.Rollback()
                            Else
                                strReturn = "0//Save data completed."
                                If isTrans Then objTran.Commit()
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function SaveLoanCancelPay(ByVal sKey As String, ByVal BranchId As String, _
ByVal sPrjNO As String, ByVal sLoanNo As String, ByVal PayAmount As Single, ByVal DocNo As String, ByVal DocDate As Date, _
ByVal sUser As String, ByVal RunId As String) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim AccNo As String = sPrjNO & sLoanNo
        Dim nBeginValue As Single = 0

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran


                strSql = "Delete TB_TRN_LOAN_PAID where RunId=" & RunId.ToString
                objCmd.CommandText = strSql
                nResult = objCmd.ExecuteNonQuery


                strSql = "Select  isnull(LoanBalance,0) from TB_TRN_LOAN_CONTRACT Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                oDataset = oService.getDataSet(strSql)
                If oDataset.Tables(0).Rows.Count > 0 Then
                    nBeginValue = oDataset.Tables(0).Rows(0).Item(0)
                Else
                    nBeginValue = 0
                End If
                strSql = "Update TB_TRN_LOAN_CONTRACT set lastdate='" & oConFig.Date2db(DocDate).ToString & "', LoanBalance=isnull(LoanBalance,0)-" & PayAmount & " Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                objCmd.CommandText = strSql
                nResult = objCmd.ExecuteNonQuery

                strSql = "Insert into TB_TRN_LOAN_MOVEMENT"
                strSql = strSql & " ("
                strSql = strSql & " [RefNo]"
                strSql = strSql & " ,[BranchId]"
                strSql = strSql & " ,[DocDate]"
                strSql = strSql & " ,[TrnType]"
                strSql = strSql & " ,[PrjNo]"
                strSql = strSql & " ,[LoanNo]"
                strSql = strSql & " ,[CaryDown_amount]"
                strSql = strSql & " ,[Receive_amount]"
                strSql = strSql & " ,[Issue_amount]"
                strSql = strSql & " ,[CarryFwd_amount]"
                strSql = strSql & " ,[LastDate]"
                strSql = strSql & " ,[Remark]"
                strSql = strSql & " ,[ModifyBy]"
                strSql = strSql & " ,[ModifyDate]"
                strSql = strSql & " ,[isPosted])"
                strSql = strSql & " Values("
                strSql = strSql & "'" & DocNo & "'"
                strSql = strSql & ",'" & BranchId & "'"
                strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                strSql = strSql & ",1"
                strSql = strSql & ",'" & sPrjNO & "'"
                strSql = strSql & ",'" & sLoanNo & "'"
                strSql = strSql & ",0"
                strSql = strSql & ",-" & PayAmount
                strSql = strSql & ",0"
                strSql = strSql & "," & nBeginValue - PayAmount
                strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                strSql = strSql & ",'ยกเลิกการจ่าย'"
                strSql = strSql & ",'" & sUser & "'"
                strSql = strSql & ",getdate()"
                strSql = strSql & ",0"
                strSql = strSql & " )"

                objCmd.CommandText = strSql
                nResult = objCmd.ExecuteNonQuery

                If nResult = 0 Then
                    strReturn = "101//Unknow error can not save this data."
                    If isTrans Then objTran.Rollback()
                Else
                    strReturn = "0//Save data completed."
                    If isTrans Then objTran.Commit()
                End If

                'strSql = " SELECT     PrjNo, LoanNo, TPrefix, CustGroup, CustId, Name, PrjName, AppAmount, PaidAmount"
                'strSql = strSql & " FROM V024_LOAN_PAID_REMAIN"
                'strSql = strSql & " Where PrjNo+LoanNo='" & AccNo & "'"
                'oDataset = getDataSet(strSql)


                'If oDataset.Tables(0).Rows.Count > 0 Then  '// New item

                '    If oDataset.Tables(0).Rows(0).Item("PaidAmount") + PayAmount > oDataset.Tables(0).Rows(0).Item("AppAmount") Then
                '        strReturn = "102//จำนวนที่จ่ายมากกว่าจำนวนอนุมัติ"
                '    Else
                '        strSql = " INSERT INTO TB_TRN_LOAN_PAID"
                '        strSql = strSql & " (DocNo"
                '        strSql = strSql & " ,DocDate"
                '        strSql = strSql & " ,BranchId"
                '        strSql = strSql & " ,PrjNo"
                '        strSql = strSql & " ,LoanNo"
                '        strSql = strSql & " ,Money1"
                '        strSql = strSql & " ,Remark"
                '        strSql = strSql & " ,ModifyBy"
                '        strSql = strSql & " ,ModifyDate)"
                '        strSql = strSql & " Values('" & DocNo & "'"
                '        strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                '        strSql = strSql & ",'" & BranchId & "'"
                '        strSql = strSql & ",'" & sPrjNO & "'"
                '        strSql = strSql & ",'" & sLoanNo & "'"
                '        strSql = strSql & "," & PayAmount ' & "'"
                '        strSql = strSql & ",'" & Remark & "' "
                '        strSql = strSql & ",'" & sUser & "'"
                '        strSql = strSql & ",getDate())"
                '        objCmd.CommandText = strSql
                '        nResult = objCmd.ExecuteNonQuery
                '        If nResult = 1 Then
                '            '// อ่านค่าล่าสุด

                '            strSql = "Select  isnull(LoanBalance,0) from TB_TRN_LOAN_CONTRACT Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                '            oDataset = oService.getDataSet(strSql)
                '            If oDataset.Tables(0).Rows.Count > 0 Then
                '                nBeginValue = oDataset.Tables(0).Rows(0).Item(0)
                '            Else
                '                nBeginValue = 0
                '            End If
                '            strSql = "Update TB_TRN_LOAN_CONTRACT set lastdate='" & oConFig.Date2db(DocDate).ToString & "', LoanBalance=isnull(LoanBalance,0)+" & PayAmount & " Where PrjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                '            objCmd.CommandText = strSql
                '            nResult = objCmd.ExecuteNonQuery

                '            strSql = "Insert into TB_TRN_LOAN_MOVEMENT"
                '            strSql = strSql & " ("
                '            strSql = strSql & " [RefNo]"
                '            strSql = strSql & " ,[BranchId]"
                '            strSql = strSql & " ,[DocDate]"
                '            strSql = strSql & " ,[TrnType]"
                '            strSql = strSql & " ,[PrjNo]"
                '            strSql = strSql & " ,[LoanNo]"
                '            strSql = strSql & " ,[CaryDown_amount]"
                '            strSql = strSql & " ,[Receive_amount]"
                '            strSql = strSql & " ,[Issue_amount]"
                '            strSql = strSql & " ,[CarryFwd_amount]"
                '            strSql = strSql & " ,[LastDate]"
                '            strSql = strSql & " ,[Remark]"
                '            strSql = strSql & " ,[ModifyBy]"
                '            strSql = strSql & " ,[ModifyDate]"
                '            strSql = strSql & " ,[isPosted])"
                '            strSql = strSql & " Values("
                '            strSql = strSql & "'" & DocNo & "'"
                '            strSql = strSql & ",'" & BranchId & "'"
                '            strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                '            strSql = strSql & ",1"
                '            strSql = strSql & ",'" & sPrjNO & "'"
                '            strSql = strSql & ",'" & sLoanNo & "'"
                '            strSql = strSql & ",0"
                '            strSql = strSql & "," & PayAmount
                '            strSql = strSql & ",0"
                '            strSql = strSql & "," & nBeginValue + PayAmount
                '            strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                '            strSql = strSql & ",'" & Remark & "'"
                '            strSql = strSql & ",'" & sUser & "'"
                '            strSql = strSql & ",getdate()"
                '            strSql = strSql & ",0"
                '            strSql = strSql & " )"

                '            objCmd.CommandText = strSql
                '            nResult = objCmd.ExecuteNonQuery

                '            If nResult = 0 Then
                '                strReturn = "101//Unknow error can not save this data."
                '                If isTrans Then objTran.Rollback()
                '            Else
                '                strReturn = "0//Save data completed."
                '                If isTrans Then objTran.Commit()
                '            End If
                '        End If
                '    End If
                'End If
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function


    Public Function SaveLoanReceipt(ByVal RecType As String, ByVal sKey As String, ByVal BranchId As String, ByVal CustId As String, _
ByVal sPrjNO As String, ByVal sLoanNo As String, ByVal Money1 As Single, ByVal Money2 As Single, ByVal Money3 As Single _
, ByVal Money4 As Single, ByVal Money5 As Single, ByVal MoneyTotal As Single, ByVal DocNo As String, ByVal DocDate As Date, _
ByVal sUser As String, Optional ByVal Remark As String = "") As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetReceipt As New DataSet
        Dim oDatasetPeriod As New DataSet
        Dim AccNo As String = sPrjNO & sLoanNo
        Dim nBeginValue As Single = 0
        Dim oDrow As DataRow
        Dim i As Long
        Dim nTotalValues As Single = 0
        Dim sField As String = ""
        Dim strSql1 As String = ""
        Dim nMoneys As Single = 0
        Dim nMoneyTemp As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                'Receipt operation flow.
                '1. check exist of contract no
                '2. Update to contract Loanbalance,OldFine,OldDb,Fine,Db
                '3. Insert into movement table
                '4. If exist Update to receipt table else insert 
                '5. Update money for period

                strSql = "select * from tb_trn_loan_contract where prjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                oDataset = getDataSet(strSql)

                If oDataset.Tables(0).Rows.Count > 0 Then
                    'For i = 0 To oDataset.Tables(0).Rows.Count - 1

                    oDrow = oDataset.Tables(0).Rows(0)

                    '// Check Qty
                    If Val(oDrow.Item("LoanBalance").ToString) < Money5 Then
                        strReturn = "101//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_balance
                    ElseIf Val(oDrow.Item("OldFineBalance").ToString) < Money1 Then
                        strReturn = "102//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_old_fine_balance
                    ElseIf Val(oDrow.Item("OldDbBalance").ToString) < Money2 Then
                        strReturn = "103//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_old_db_balance
                    ElseIf Val(oDrow.Item("FineBalance").ToString) < Money3 Then
                        strReturn = "104//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_fine_balance
                    ElseIf Val(oDrow.Item("dbBalance").ToString) < Money4 Then
                        strReturn = "105//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_db_balance
                    Else


                        sField = "LoanBalance=isnull(LoanBalance,0)-" & Money5.ToString
                        If Val(oDrow.Item("OldFineBalance").ToString) > 0 Then sField = sField & ",  OldFineBalance=isnull(OldFineBalance,0)-" & Money1.ToString
                        If Val(oDrow.Item("OldDbBalance").ToString) > 0 Then sField = sField & ",  OldDbBalance=isnull(OldDbBalance,0)-" & Money2.ToString
                        If Val(oDrow.Item("FineBalance").ToString) > 0 Then sField = sField & ",  FineBalance=isnull(FineBalance,0)-" & Money3.ToString
                        If Val(oDrow.Item("DbBalance").ToString) > 0 Then sField = sField & ",  DbBalance=isnull(DbBalance,0)-" & Money4.ToString

                        strSql = "Update tb_trn_loan_contract set " & sField
                        strSql = strSql & " Where PrjNO='" & sPrjNO.Trim & "' and LoanNO='" & sLoanNo.Trim & "'"
                        'MessageBox.Show(strSql)
                        objCmd.CommandText = strSql
                        objCmd.ExecuteNonQuery()

                        strSql = "Insert into [TB_TRN_LOAN_MOVEMENT]"
                        strSql = strSql & " ([RefNo]"
                        strSql = strSql & " ,[BranchId]"
                        strSql = strSql & " ,[DocDate]"
                        strSql = strSql & " ,[TrnType]"
                        strSql = strSql & " ,[PrjNo]"
                        strSql = strSql & " ,[LoanNo]"
                        strSql = strSql & " ,[CaryDown_amount]"
                        strSql = strSql & " ,[Receive_amount]"
                        strSql = strSql & " ,[Issue_amount]"
                        strSql = strSql & " ,[CarryFwd_amount]"
                        strSql = strSql & " ,[LastDate]"
                        strSql = strSql & " ,[Remark]"
                        strSql = strSql & " ,[ModifyBy]"
                        strSql = strSql & " ,[ModifyDate]"
                        strSql = strSql & " ,[isPosted])"
                        '/1=เงินต้น
                        '/2=ดอกค้าง
                        '/3=คป.ค้าง
                        '/4=ดอก
                        '/5=คป
                        If Money5 > 0 Then  '// เงินต้น
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',1,'" & sPrjNO & "','" & sLoanNo & "',0," & Money5.ToString & ",0," & Val(oDrow.Item("LoanBalance").ToString) - Money5 & ",'" & oConFig.Date2db(DocDate) & "','" & Remark & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money2 > 0 Then  '// ดอกค้าง
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',2,'" & sPrjNO & "','" & sLoanNo & "',0," & Money2.ToString & ",0," & Val(oDrow.Item("OldDbBalance").ToString) - Money2 & ",'" & oConFig.Date2db(DocDate) & "','" & Remark & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money1 > 0 Then  '// คป ค้าง
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',3,'" & sPrjNO & "','" & sLoanNo & "',0," & Money1.ToString & ",0," & Val(oDrow.Item("OldFineBalance").ToString) - Money1 & ",'" & oConFig.Date2db(DocDate) & "','" & Remark & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money4 > 0 Then  '// ดอก
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',4,'" & sPrjNO & "','" & sLoanNo & "',0," & Money4.ToString & ",0," & Val(oDrow.Item("DbBalance").ToString) - Money4 & ",'" & oConFig.Date2db(DocDate) & "','" & Remark & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money3 > 0 Then  '// คป
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',5,'" & sPrjNO & "','" & sLoanNo & "',0," & Money3.ToString & ",0," & Val(oDrow.Item("FineBalance").ToString) - Money3 & ",'" & oConFig.Date2db(DocDate) & "','" & Remark & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If

                        strSql = "Select * from tb_trn_loan_receipt where docno='" & DocNo & "' and prjno='" & sPrjNO & "' and LoanNO='" & sLoanNo & "'"
                        oDatasetReceipt = oService.getDataSet(strSql)
                        If oDatasetReceipt.Tables(0).Rows.Count = 0 Then  'New 
                            strSql = "Insert into tb_trn_loan_receipt (DocType,CustId,DocNo,PrjNo,LoanNo,DocDate,BranchId) Values('" & RecType.ToString & "','" & CustId & "','" & DocNo & "','" & sPrjNO & "','" & sLoanNo & "','" & oConFig.Date2db(DocDate) & "','" & BranchId & "')"
                            'MessageBox.Show(strSql)
                            objCmd.CommandText = strSql
                            objCmd.ExecuteNonQuery()
                        End If
                        '//Update
                        strSql = "Update tb_trn_loan_receipt set "
                        strSql = strSql & "Money1=isnull(money1,0)+" & Money1
                        strSql = strSql & ",Money2=isnull(money2,0)+" & Money2
                        strSql = strSql & ",Money3=isnull(money3,0)+" & Money3
                        strSql = strSql & ",Money4=isnull(money4,0)+" & Money4
                        strSql = strSql & ",Money5=isnull(money5,0)+" & Money5
                        strSql = strSql & ",MoneyTotal=isnull(MoneyTotal,0)+" & MoneyTotal
                        strSql = strSql & " where docno='" & DocNo & "' and prjno='" & sPrjNO & "' and LoanNO='" & sLoanNo & "'"
                        'MessageBox.Show(strSql)
                        objCmd.CommandText = strSql
                        objCmd.ExecuteNonQuery()


                        '// Open Period 
                        'SELECT     PrjNo, LoanNo, PeriodNo, isnull(PayAmount.0)as PayAmount, PeriodDate, isnull(PaidAmount,0) as PaidAmount, LastDate
                        'FROM         TB_TRN_LOAN_PERIOD
                        nMoneys = Money5        '// ใช้เงินต้น
                        strSql = "SELECT TrnId,PrjNo, LoanNo, PeriodNo, isnull(PayAmount,0)as PayAmount, PeriodDate, isnull(PaidAmount,0) as PaidAmount from tb_trn_loan_period where PrjNO='" & sPrjNO & "' and LoanNo='" & sLoanNo & "' order by PeriodNo"
                        oDatasetPeriod = oService.getDataSet(strSql)
                        If oDatasetPeriod.Tables(0).Rows.Count > 0 Then
                            For i = 0 To oDatasetPeriod.Tables(0).Rows.Count - 1
                                If nMoneys > 0 Then
                                    oDrow = oDatasetPeriod.Tables(0).Rows(i)
                                    If oDrow("PayAmount") > oDrow("PaidAmount") Then
                                        nMoneyTemp = oDrow("PayAmount") - oDrow("PaidAmount")
                                        If nMoneys > nMoneyTemp Then
                                            nMoneys = nMoneys - nMoneyTemp
                                        Else
                                            nMoneyTemp = nMoneys
                                            nMoneys = 0
                                        End If
                                    End If
                                    '// Save data
                                    strSql = "Update tb_trn_loan_period set paidamount=isnull(paidamount,0)+" & nMoneyTemp & " Where TrnId=" & oDrow("TrnId").ToString
                                    'MessageBox.Show(strSql)
                                    objCmd.CommandText = strSql
                                    objCmd.ExecuteNonQuery()
                                End If
                            Next i
                        End If

                    End If
                    'If nResult = 0 Then
                    '    strReturn = "101//Unknow error can not save this data."
                    '    If isTrans Then objTran.Rollback()
                    'Else
                    strReturn = "0//Save data completed."
                    If isTrans Then objTran.Commit()
                    'End If
                Else
                    '// invalid contract no
                    strReturn = "109//" & clsLang.msg_loan_contract_no
                End If

            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function


    Public Function CancelLoanReceipt(ByVal sKey As String, ByVal BranchId As String, ByVal CustId As String, _
ByVal sPrjNO As String, ByVal sLoanNo As String, ByVal Money1 As Single, ByVal Money2 As Single, ByVal Money3 As Single _
, ByVal Money4 As Single, ByVal Money5 As Single, ByVal MoneyTotal As Single, ByVal DocNo As String, ByVal DocDate As Date, _
ByVal sUser As String, ByVal TrnId As String) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetReceipt As New DataSet
        Dim oDatasetPeriod As New DataSet
        Dim AccNo As String = sPrjNO & sLoanNo
        Dim nBeginValue As Single = 0
        Dim oDrow As DataRow
        Dim i As Long
        Dim nTotalValues As Single = 0
        Dim sField As String = ""
        Dim strSql1 As String = ""
        Dim nMoneys As Single = 0
        Dim nMoneyTemp As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                'Receipt operation flow.
                '1. check exist of contract no
                '2. Update to contract Loanbalance,OldFine,OldDb,Fine,Db
                '3. Insert into movement table
                '4. If exist Update to receipt table else insert 
                '5. Update money for period

                strSql = "select * from tb_trn_loan_contract where prjNo='" & sPrjNO & "' and LoanNo='" & sLoanNo & "'"
                oDataset = getDataSet(strSql)

                If oDataset.Tables(0).Rows.Count > 0 Then
                    'For i = 0 To oDataset.Tables(0).Rows.Count - 1

                    oDrow = oDataset.Tables(0).Rows(0)

                    '// Check Qty
                    'If Val(oDrow.Item("LoanBalance").ToString) < Money5 Then
                    '    strReturn = "101//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_balance
                    'ElseIf Val(oDrow.Item("OldFineBalance").ToString) < Money1 Then
                    '    strReturn = "102//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_old_fine_balance
                    'ElseIf Val(oDrow.Item("OldDbBalance").ToString) < Money2 Then
                    '    strReturn = "103//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_old_db_balance
                    'ElseIf Val(oDrow.Item("FineBalance").ToString) < Money3 Then
                    '    strReturn = "104//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_fine_balance
                    'ElseIf Val(oDrow.Item("dbBalance").ToString) < Money4 Then
                    '    strReturn = "105//" & clsLang.msg_invaliddata & " " & clsLang.msg_loan_db_balance
                    If True Then


                        sField = "LoanBalance=isnull(LoanBalance,0)+" & Money5.ToString
                        sField = sField & ",  OldFineBalance=isnull(OldFineBalance,0)+" & Money1.ToString
                        sField = sField & ",  OldDbBalance=isnull(OldDbBalance,0)+" & Money2.ToString
                        sField = sField & ",  FineBalance=isnull(FineBalance,0)+" & Money3.ToString
                        sField = sField & ",  DbBalance=isnull(DbBalance,0)+" & Money4.ToString

                        strSql = "Update tb_trn_loan_contract set " & sField
                        strSql = strSql & " Where PrjNO='" & sPrjNO.Trim & "' and LoanNO='" & sLoanNo.Trim & "'"
                        'MessageBox.Show(strSql)
                        objCmd.CommandText = strSql
                        objCmd.ExecuteNonQuery()

                        strSql = "Insert into [TB_TRN_LOAN_MOVEMENT]"
                        strSql = strSql & " ([RefNo]"
                        strSql = strSql & " ,[BranchId]"
                        strSql = strSql & " ,[DocDate]"
                        strSql = strSql & " ,[TrnType]"
                        strSql = strSql & " ,[PrjNo]"
                        strSql = strSql & " ,[LoanNo]"
                        strSql = strSql & " ,[CaryDown_amount]"
                        strSql = strSql & " ,[Receive_amount]"
                        strSql = strSql & " ,[Issue_amount]"
                        strSql = strSql & " ,[CarryFwd_amount]"
                        strSql = strSql & " ,[LastDate]"
                        strSql = strSql & " ,[Remark]"
                        strSql = strSql & " ,[ModifyBy]"
                        strSql = strSql & " ,[ModifyDate]"
                        strSql = strSql & " ,[isPosted])"
                        '/1=เงินต้น
                        '/2=ดอกค้าง
                        '/3=คป.ค้าง
                        '/4=ดอก
                        '/5=คป
                        If Money5 > 0 Then  '// เงินต้น
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',1,'" & sPrjNO & "','" & sLoanNo & "',0,-" & Money5.ToString & ",0," & Val(oDrow.Item("LoanBalance").ToString) + Money5 & ",'" & oConFig.Date2db(DocDate) & "','" & TrnId & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money2 > 0 Then  '// ดอกค้าง
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',2,'" & sPrjNO & "','" & sLoanNo & "',0,-" & Money2.ToString & ",0," & Val(oDrow.Item("OldDbBalance").ToString) + Money2 & ",'" & oConFig.Date2db(DocDate) & "','" & TrnId & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money1 > 0 Then  '// คป ค้าง
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',3,'" & sPrjNO & "','" & sLoanNo & "',0,-" & Money1.ToString & ",0," & Val(oDrow.Item("OldFineBalance").ToString) + Money1 & ",'" & oConFig.Date2db(DocDate) & "','" & TrnId & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money4 > 0 Then  '// ดอก
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',4,'" & sPrjNO & "','" & sLoanNo & "',0,-" & Money4.ToString & ",0," & Val(oDrow.Item("DbBalance").ToString) + Money4 & ",'" & oConFig.Date2db(DocDate) & "','" & TrnId & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If
                        If Money3 > 0 Then  '// คป
                            strSql1 = " values('" & DocNo & "','" & BranchId & "','" & oConFig.Date2db(DocDate) & "',5,'" & sPrjNO & "','" & sLoanNo & "',0,-" & Money3.ToString & ",0," & Val(oDrow.Item("FineBalance").ToString) + Money3 & ",'" & oConFig.Date2db(DocDate) & "','" & TrnId & "','" & sUser & "',getdate(),0)"
                            'MessageBox.Show(strSql & strSql1)
                            objCmd.CommandText = strSql & strSql1
                            objCmd.ExecuteNonQuery()
                        End If


                        strSql = "delete tb_trn_loan_receipt where RunId=" & TrnId.ToString
                        objCmd.CommandText = strSql
                        objCmd.ExecuteNonQuery()

                        'strSql = "Select * from tb_trn_loan_receipt where docno='" & DocNo & "' and prjno='" & sPrjNO & "' and LoanNO='" & sLoanNo & "'"
                        'oDatasetReceipt = oService.getDataSet(strSql)
                        'If oDatasetReceipt.Tables(0).Rows.Count = 0 Then  'New 
                        '    strSql = "Insert into tb_trn_loan_receipt (CustId,DocNo,PrjNo,LoanNo,DocDate,BranchId) Values('" & CustId & "','" & DocNo & "','" & sPrjNO & "','" & sLoanNo & "','" & oConFig.Date2db(DocDate) & "','" & BranchId & "')"
                        '    'MessageBox.Show(strSql)
                        '    objCmd.CommandText = strSql
                        '    objCmd.ExecuteNonQuery()
                        'End If
                        ''//Update
                        'strSql = "Update tb_trn_loan_receipt set "
                        'strSql = strSql & "Money1=isnull(money1,0)-" & Money1
                        'strSql = strSql & ",Money2=isnull(money2,0)-" & Money2
                        'strSql = strSql & ",Money3=isnull(money3,0)-" & Money3
                        'strSql = strSql & ",Money4=isnull(money4,0)-" & Money4
                        'strSql = strSql & ",Money5=isnull(money5,0)-" & Money5
                        'strSql = strSql & ",MoneyTotal=isnull(MoneyTotal,0)-" & MoneyTotal
                        'strSql = strSql & " where docno='" & DocNo & "' and prjno='" & sPrjNO & "' and LoanNO='" & sLoanNo & "'"
                        ''MessageBox.Show(strSql)
                        'objCmd.CommandText = strSql
                        'objCmd.ExecuteNonQuery()


                        '// Open Period 
                        'SELECT     PrjNo, LoanNo, PeriodNo, isnull(PayAmount.0)as PayAmount, PeriodDate, isnull(PaidAmount,0) as PaidAmount, LastDate
                        'FROM         TB_TRN_LOAN_PERIOD
                        nMoneys = Money5        '// ใช้เงินต้น
                        strSql = "SELECT TrnId,PrjNo, LoanNo, PeriodNo, isnull(PayAmount,0)as PayAmount, PeriodDate, isnull(PaidAmount,0) as PaidAmount from tb_trn_loan_period where PrjNO='" & sPrjNO & "' and LoanNo='" & sLoanNo & "' and isnull(PaidAmount,0)>0 order by PeriodNo desc"
                        oDatasetPeriod = oService.getDataSet(strSql)
                        If oDatasetPeriod.Tables(0).Rows.Count > 0 Then
                            For i = 0 To oDatasetPeriod.Tables(0).Rows.Count - 1
                                If nMoneys > 0 Then
                                    oDrow = oDatasetPeriod.Tables(0).Rows(i)
                                    If oDrow("PaidAmount") > 0 Then
                                        nMoneyTemp = oDrow("PaidAmount")
                                        If nMoneys > nMoneyTemp Then
                                            nMoneys = nMoneys - nMoneyTemp
                                        Else
                                            nMoneyTemp = nMoneys
                                            nMoneys = 0
                                        End If
                                    End If
                                    '// Save data
                                    strSql = "Update tb_trn_loan_period set paidamount=isnull(paidamount,0)-" & nMoneyTemp & " Where TrnId=" & oDrow("TrnId").ToString
                                    'MessageBox.Show(strSql)
                                    objCmd.CommandText = strSql
                                    objCmd.ExecuteNonQuery()
                                End If
                            Next i
                        End If

                    End If
                    'If nResult = 0 Then
                    '    strReturn = "101//Unknow error can not save this data."
                    '    If isTrans Then objTran.Rollback()
                    'Else
                    strReturn = "0//Save data completed."
                    If isTrans Then objTran.Commit()
                    'End If
                Else
                    '// invalid contract no
                    strReturn = "109//" & clsLang.msg_loan_contract_no
                End If

            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function


    Public Function SaveBankTrans(ByVal sKey As String, ByVal ItemDesc As String, ByVal BranchId As String, _
    ByVal AccNo As String, ByVal InQty As Single, ByVal DocNo As String, ByVal DocDate As Date, _
    ByVal OutQty As Single, _
    ByVal sUser As String, Optional ByVal Remark As String = "", Optional ByVal TranId As Decimal = 0) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        'Dim nBeginShare As Integer = 0
        Dim nBeginValue As Decimal = 0

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Decimal = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                'SELECT     DocNo, DocDate,AccNo, CaryDown_amount, Receive_amount, Issue_amount, Interest_amount, CarryFwd_amount, Remark, ModifyBy, ModifyDate
                'FROM         TB_TRN_BANK_MOVEMENT
                strSql = "Select 1 from TB_TRN_BANK_MOVEMENT Where TrnId='" & TranId & "'"
                oDataset = getDataSet(strSql)

                If oDataset.Tables(0).Rows.Count = 0 Then  '// New item

                    '//ดึงข้อมูลล่าสุด
                    strSql = "Select isnull(CarryFwd_amount,0) From TB_TRN_BANK_MOVEMENT  where  TrnId=(Select Max(TrnId) from TB_TRN_BANK_MOVEMENT Where AccNo='" & AccNo & "')"
                    oDatasetLastAmount = getDataSet(strSql)
                    If oDatasetLastAmount.Tables(0).Rows.Count > 0 Then
                        nBeginValue = oDatasetLastAmount.Tables(0).Rows(0).Item(0)
                    End If

                    '// ปรับปรุงวันที่ทำการ
                    strSql = "Update TB_TRN_BANK_MOVEMENT set LastDate='" & oConFig.Date2db(DocDate).ToString & "' where  (LastDate ='' or LastDate  is null) and  TrnId=(Select Max(TrnId) from TB_TRN_BANK_MOVEMENT Where AccNo='" & AccNo & "')"  '//convert(varchar(10), getDate(),102)
                    objCmd.CommandText = strSql
                    objCmd.ExecuteNonQuery()
                    'Call ExecCommand(strSql)

                    strSql = " INSERT INTO TB_TRN_BANK_MOVEMENT"
                    strSql = strSql & " (DocNo,ItemDesc"
                    strSql = strSql & " ,DocDate"
                    strSql = strSql & " ,BranchId"
                    strSql = strSql & " ,AccNo"
                    strSql = strSql & " ,Receive_amount"
                    strSql = strSql & " ,Issue_amount"
                    strSql = strSql & " ,CarryFwd_amount"
                    strSql = strSql & " ,Remark"
                    strSql = strSql & " ,ModifyBy"
                    strSql = strSql & " ,ModifyDate)"
                    strSql = strSql & " Values('" & DocNo & "'"
                    strSql = strSql & ",'" & ItemDesc & "'"
                    strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                    'strSql = strSql & ",convert(varchar(10), getDate(),102)"           '// date from server
                    strSql = strSql & ",'" & BranchId & "'"
                    strSql = strSql & ",'" & AccNo & "'"
                    strSql = strSql & "," & InQty ' & "'"
                    strSql = strSql & "," & OutQty ' & "'"
                    strSql = strSql & "," & (CDec(InQty) + CDec(nBeginValue) - CDec(OutQty)).ToString("0.00#") ' 
                    strSql = strSql & ",'" & Remark & "' "
                    strSql = strSql & ",'" & sUser & "'"
                    strSql = strSql & ",getDate())"

                    'nTotalValues = InQty.ToString & "+" & nBeginValue.ToString & "-" & OutQty.ToString 

                    objCmd.CommandText = strSql
                    nResult = objCmd.ExecuteNonQuery

                    strSql = "Update tb_trn_bank_account set cf_amountx =" & (CDec(InQty) + CDec(nBeginValue) - CDec(OutQty)).ToString("0.00#")
                    strSql = strSql & " ,dp_amount=isnull(dp_amount,0)+" & CStr(InQty) & ",dw_amount=isnull(dw_amount,0)+" & CStr(OutQty)
                    strSql = strSql & " Where Accno='" & AccNo.ToString & "'"

                    objCmd.CommandText = strSql
                    nResult = objCmd.ExecuteNonQuery

                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                        If isTrans Then objTran.Rollback()
                    Else
                        strReturn = "0//Save data completed."
                        If isTrans Then objTran.Commit()
                        ''//ปรับปรุงเงินฝาก

                        'strSql = "Update tb_mas_contact set ShareTotal=" & nTotalShare & ",ShareValue=" & nTotalValues & " Where MemberId='" & ShareHolder & "'"
                        'ExecCommand(strSql)
                    End If
                Else        '// Existing item
                    'strSql = " UPDATE TB_TRN_SHARE_MOVEMENT "
                    'strSql = strSql & " SET  DocNo  = '" & DocNo & "'"
                    'strSql = strSql & " , DocDate  =  '" & DocDate & "'"
                    'strSql = strSql & " , AccNo  = '" & AccNo & "'"
                    'strSql = strSql & " , Receive_amount  =" & InPrice
                    'strSql = strSql & " , Issue_amount  = " & OutPrice
                    'strSql = strSql & " , CarryFwd_amount  =CarryFwd_amount+(" & InPrice & "-Receive_amount)-(" & OutPrice & "-Issue_amount)"
                    'strSql = strSql & " , Remark  = '" & Remark & "'"
                    'strSql = strSql & " , ModifyBy  = '" & sUser & "'"
                    'strSql = strSql & " , ModifyDate  = getDate()"
                    'strSql = strSql & " WHERE DocNo='" & DocNo & "'" ' and ShareHolder='" & ShareHolder & "'"

                    'objConn.ConnectionString = strConnectionString
                    'objConn.Open()
                    'objCmd.Connection = objConn
                    'objCmd.CommandText = strSql
                    'objCmd.CommandTimeout = 0
                    'nResult = objCmd.ExecuteNonQuery
                    'If nResult = 0 Then
                    '    strReturn = "101//Unknow error can not save this data."
                    'Else
                    '    strReturn = "0//Save data completed."
                    'End If

                End If

            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function SaveFunTrans(ByVal sKey As String, ByVal BranchId As String, ByVal Fun_Code As String, _
ByVal AccNo As String, ByVal InQty As Single, ByVal DocNo As String, ByVal DocDate As Date, _
ByVal sUser As String, Optional ByVal Remark As String = "", Optional ByVal TranId As Decimal = 0) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim nCf As Single = 0
        Dim nRec As Single = 0
        Dim nDebt As Single = 0
        Dim nAdv As Single = 0
        'Dim nBeginShare As Integer = 0
        'Dim nBeginValue As Single = 0

        ''Dim nTotalShare As Integer = 0
        'Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                'SELECT     DocNo, DocDate,AccNo, CaryDown_amount, Receive_amount, Issue_amount, Interest_amount, CarryFwd_amount, Remark, ModifyBy, ModifyDate
                'FROM         TB_TRN_BANK_MOVEMENT
                strSql = "Select 1 from TB_TRN_FUN_MOVEMENT Where TrnId='" & TranId & "'"
                oDataset = getDataSet(strSql)

                If oDataset.Tables(0).Rows.Count = 0 Then  '// New item

                    '//ดึงข้อมูลล่าสุด
                    'strSql = "Select isnull(CarryDown_amount,0) as Cf_amount,isnull(Receive_amount,0) as rec_amount,isnull(Issue_amount,0) as debt_rem_amount,isnull(CarryFwd_amount,0) as adv_amount, From TB_TRN_FUN_MOVEMENT  where  TrnId=(Select Max(TrnId) from TB_TRN_FUN_MOVEMENT Where AccNo='" & AccNo & "')"
                    strSql = "Select isnull(Cf_amount,0) as Cf_amount,isnull(Rec_amount,0) as rec_amount,isnull(Debt_amount,0) as debt_rem_amount,isnull(Adv_amount,0) as adv_amount From TB_MAS_FUN_MEMBER  where  MemberId='" & AccNo.Trim & "'" ' TrnId=(Select Max(TrnId) from TB_TRN_FUN_MOVEMENT Where AccNo='" & AccNo & "')"
                    oDatasetLastAmount = getDataSet(strSql)
                    If oDatasetLastAmount.Tables(0).Rows.Count > 0 Then
                        nCf = oDatasetLastAmount.Tables(0).Rows(0).Item("Cf_amount")
                        nRec = oDatasetLastAmount.Tables(0).Rows(0).Item("rec_amount")
                        nDebt = oDatasetLastAmount.Tables(0).Rows(0).Item("debt_rem_amount")
                        nAdv = oDatasetLastAmount.Tables(0).Rows(0).Item("adv_amount")
                    End If

                    '// ปรับปรุงวันที่ทำการ
                    'strSql = "Update TB_TRN_FUN_MOVEMENT set LastDate='" & oConFig.Date2db(DocDate).ToString & "' where  TrnId=(Select Max(TrnId) from TB_TRN_BANK_MOVEMENT Where AccNo='" & AccNo & "')"  '//convert(varchar(10), getDate(),102)
                    'objCmd.CommandText = strSql
                    'objCmd.ExecuteNonQuery()
                    ''Call ExecCommand(strSql)
                    'If nRec + nDebt = 0 Then  '// New Record

                    'End If


                    strSql = " INSERT INTO TB_TRN_FUN_MOVEMENT"
                    strSql = strSql & " (DocNo,Fun_code"
                    strSql = strSql & " ,DocDate"
                    strSql = strSql & " ,BranchId"
                    strSql = strSql & " ,MemId"
                    strSql = strSql & " ,CaryDown_amount"
                    strSql = strSql & " ,Receive_amount"
                    strSql = strSql & " ,Issue_amount"
                    strSql = strSql & " ,CarryFwd_amount"
                    strSql = strSql & " ,Remark"
                    strSql = strSql & " ,ModifyBy"
                    strSql = strSql & " ,ModifyDate)"
                    strSql = strSql & " Values('" & DocNo & "'"
                    strSql = strSql & ",'" & Fun_Code & "'"
                    strSql = strSql & ",'" & oConFig.Date2db(DocDate).ToString & "'"
                    'strSql = strSql & ",convert(varchar(10), getDate(),102)"           '// date from server
                    strSql = strSql & ",'" & BranchId & "'"
                    strSql = strSql & ",'" & AccNo & "'"
                    If nCf > (nRec + nDebt) Then
                        strSql = strSql & "," & nCf  ' & "'" ยกมา
                    Else
                        strSql = strSql & ",0"
                    End If

                    If nCf >= nRec + InQty Then
                        strSql = strSql & "," & InQty.ToString ' & "'"   รับ
                    Else
                        strSql = strSql & "," & nDebt '   & ""   รับ
                    End If

                    If (nRec + InQty) < nCf Then
                        strSql = strSql & "," & nCf - (InQty + nRec)  ' & "'"  ' & "'" ยอดหนี้ค้างรับ
                    Else
                        strSql = strSql & ",0" ' & "'"  ' & "'" ยอดหนี้ค้างรับ
                    End If

                    If (nRec + InQty) > nCf Then
                        strSql = strSql & "," & (InQty + nRec) - nCf  ' & "'"  ' & "'" ยอดจ่ายล่วงหน้า
                    Else
                        strSql = strSql & ",0"
                    End If

                    strSql = strSql & ",'" & Remark & "' "
                    strSql = strSql & ",'" & sUser & "'"
                    strSql = strSql & ",getDate())"

                    'nTotalValues = InQty.ToString & "+" & nBeginValue.ToString & "-" & OutQty.ToString 

                    objCmd.CommandText = strSql
                    nResult = objCmd.ExecuteNonQuery

                    strSql = "Update TB_MAS_FUN_MEMBER set cf_amount=cf_amount "
                    If nCf >= nRec + InQty Then
                        strSql = strSql & " ,rec_amount=rec_amount+" & InQty.ToString
                        strSql = strSql & " ,debt_amount=cf_amount-(rec_amount+" & InQty.ToString & ")"
                        strSql = strSql & " ,adv_amount=0"
                    Else
                        strSql = strSql & " ,rec_amount=cf_amount"
                        strSql = strSql & " ,debt_amount=0"
                        strSql = strSql & " ,adv_amount=adv_amount+((rec_amount+" & InQty.ToString & ")-cf_amount)"
                    End If
                    strSql = strSql & " Where memberid='" & AccNo.ToString & "'"

                    objCmd.CommandText = strSql
                    nResult = objCmd.ExecuteNonQuery

                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                        If isTrans Then objTran.Rollback()
                    Else
                        strReturn = "0//Save data completed."
                        If isTrans Then objTran.Commit()
                        ''//ปรับปรุงเงินฝาก

                        'strSql = "Update tb_mas_contact set ShareTotal=" & nTotalShare & ",ShareValue=" & nTotalValues & " Where MemberId='" & ShareHolder & "'"
                        'ExecCommand(strSql)
                    End If
                Else        '// Existing item
                    'strSql = " UPDATE TB_TRN_SHARE_MOVEMENT "
                    'strSql = strSql & " SET  DocNo  = '" & DocNo & "'"
                    'strSql = strSql & " , DocDate  =  '" & DocDate & "'"
                    'strSql = strSql & " , AccNo  = '" & AccNo & "'"
                    'strSql = strSql & " , Receive_amount  =" & InPrice
                    'strSql = strSql & " , Issue_amount  = " & OutPrice
                    'strSql = strSql & " , CarryFwd_amount  =CarryFwd_amount+(" & InPrice & "-Receive_amount)-(" & OutPrice & "-Issue_amount)"
                    'strSql = strSql & " , Remark  = '" & Remark & "'"
                    'strSql = strSql & " , ModifyBy  = '" & sUser & "'"
                    'strSql = strSql & " , ModifyDate  = getDate()"
                    'strSql = strSql & " WHERE DocNo='" & DocNo & "'" ' and ShareHolder='" & ShareHolder & "'"

                    'objConn.ConnectionString = strConnectionString
                    'objConn.Open()
                    'objCmd.Connection = objConn
                    'objCmd.CommandText = strSql
                    'objCmd.CommandTimeout = 0
                    'nResult = objCmd.ExecuteNonQuery
                    'If nResult = 0 Then
                    '    strReturn = "101//Unknow error can not save this data."
                    'Else
                    '    strReturn = "0//Save data completed."
                    'End If

                End If

            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function


    Public Function ChangeContactId(ByVal sKey As String, ByVal OldContactId As String, ByVal NewContactId As String, ByVal sUser As String) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        'Dim nBeginShare As Integer = 0
        Dim nBeginValue As Single = 0

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                objCmd.CommandText = "Update tb_mas_contact set ContactId='" & NewContactId & "' Where ContactId='" & OldContactId & "'"
                objCmd.ExecuteNonQuery()

                objCmd.CommandText = "update TB_TRN_BANK_ACCOUNT set custid='" & NewContactId & "' Where Custid='" & OldContactId & "'"
                objCmd.ExecuteNonQuery()

                'objCmd.CommandText = "upate TB_TRN_BANK_ACCOUNT set custid='" & NewContactId & "' Where Custid='" & OldContactId & "'"
                'objCmd.ExecuteNonQuery()


                'If nResult = 0 Then
                'strReturn = "101//Unknow error can not save this data."
                'If isTrans Then objTran.Rollback()
                'Else
                strReturn = "0//Save data completed."
                If isTrans Then objTran.Commit()
                ''//ปรับปรุงค่าหุ้นตั้งต้น

                'strSql = "Update tb_mas_contact set ShareTotal=" & nTotalShare & ",ShareValue=" & nTotalValues & " Where MemberId='" & ShareHolder & "'"
                'ExecCommand(strSql)
                'End If
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function SaveIcTrnDetail(ByVal sKey As String, ByVal TrnType As String, ByVal DocNo As String, ByVal DocDate As String, _
    ByVal Whid As String, ByVal VatType As Byte, ByVal VatRate As Single, ByVal ContactId As String, ByVal DepartCode As String, ByVal ProjectCode As String, ByVal RefNo As String, _
    ByVal RefDate As String, ByVal CashierCode As String, ByVal LineNumber As Integer, ByVal ItemCode As String, ByVal ItemName As String, ByVal LocCode As String, ByVal Qty As Single, _
    ByVal Price As Single, ByVal DisCount As Single, ByVal DisCountText As String, ByVal Amount As Single, ByVal Cost As Single, ByVal UnitRatio As Single, ByVal UnitCode As String, ByVal ItemType As Byte, _
    ByVal PriceFlag As Byte, ByVal isFree As Byte) As String

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0

        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else
                If LineNumber = 0 Then   '// New item
                    LineNumber = getItemLineNumber(DocNo)
                    strSql = " INSERT INTO TB_IC_TRN_DETAIL ("
                    strSql = strSql & " TrnType"
                    strSql = strSql & " ,DocNo"
                    strSql = strSql & " ,DocDate"
                    strSql = strSql & " ,WhId"
                    strSql = strSql & " ,VatType"
                    strSql = strSql & " ,VatRate"
                    strSql = strSql & " ,ContactId"
                    strSql = strSql & " ,DepartCode"
                    strSql = strSql & " ,ProjectCode"
                    strSql = strSql & " ,RefNo"
                    strSql = strSql & " ,RefDate"
                    strSql = strSql & " ,CashierCode"
                    strSql = strSql & " ,LineNumber"
                    strSql = strSql & " ,ItemCode"
                    strSql = strSql & " ,ItemName"
                    strSql = strSql & " ,LocCode"
                    strSql = strSql & " ,Qty"
                    strSql = strSql & " ,Price"
                    strSql = strSql & " ,Discount"
                    strSql = strSql & " ,DisCountText"
                    strSql = strSql & " ,Amount"
                    strSql = strSql & " ,Cost"
                    strSql = strSql & " ,UnitRatio"
                    strSql = strSql & " ,UnitCode"
                    strSql = strSql & " ,ItemType"
                    strSql = strSql & " ,PriceFlag"
                    strSql = strSql & " ,isFree)"
                    strSql = strSql & " Values("
                    strSql = strSql & "'" & TrnType & "'"
                    strSql = strSql & ",'" & DocNo & "'"
                    strSql = strSql & ",'" & DocDate & "'"
                    strSql = strSql & ",'" & Whid & "'"
                    strSql = strSql & "," & VatType
                    strSql = strSql & "," & VatRate '& "'"
                    strSql = strSql & ",'" & ContactId & "'"
                    strSql = strSql & ",'" & DepartCode & "'"
                    strSql = strSql & ",'" & ProjectCode & "'"
                    strSql = strSql & ",'" & RefNo & "'"
                    strSql = strSql & ",'" & RefDate & "'"
                    strSql = strSql & ",'" & CashierCode & "'"
                    strSql = strSql & "," & LineNumber ' & "'"
                    strSql = strSql & ",'" & ItemCode & "'"
                    strSql = strSql & ",'" & ItemName & "'"
                    strSql = strSql & ",'" & LocCode & "'"
                    strSql = strSql & "," & Qty ' & "'"
                    strSql = strSql & "," & Price ' & "'"
                    strSql = strSql & "," & DisCount ' & "'"
                    strSql = strSql & ",'" & DisCountText & "'"
                    strSql = strSql & "," & Amount ' & "'"
                    strSql = strSql & "," & Cost ' & "'"
                    strSql = strSql & "," & UnitRatio ' & "'"
                    strSql = strSql & ",'" & UnitCode & "'"
                    strSql = strSql & "," & ItemType ' & "'"
                    strSql = strSql & "," & PriceFlag ' & "'"
                    strSql = strSql & "," & isFree & ")"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed.//" & LineNumber.ToString
                    End If
                Else        '// Existing item
                    strSql = " Update TB_IC_TRN_DETAIL set "
                    'strSql = strSql & " TrnType"
                    'strSql = strSql & " ,DocNo"
                    'strSql = strSql & " ,DocDate"
                    strSql = strSql & " WhId='" & Whid & "'"
                    'strSql = strSql & " ,VatType"
                    'strSql = strSql & " ,VatRate"
                    strSql = strSql & " ,ContactId='" & ContactId & "'"
                    strSql = strSql & " ,DepartCode='" & DepartCode & "'"
                    strSql = strSql & " ,ProjectCode='" & ProjectCode & "'"
                    strSql = strSql & " ,RefNo='" & RefNo & "'"
                    strSql = strSql & " ,RefDate='" & RefDate & "'"
                    strSql = strSql & " ,CashierCode='" & CashierCode & "'"
                    'strSql = strSql & " ,LineNumber"
                    strSql = strSql & " ,ItemCode='" & ItemCode & "'"
                    strSql = strSql & " ,ItemName='" & ItemName & "'"
                    strSql = strSql & " ,LocCode='" & LocCode & "'"
                    strSql = strSql & " ,Qty=" & Qty '& "'"
                    strSql = strSql & " ,Price=" & Price '& "'"
                    strSql = strSql & " ,Discount=" & DisCount '& "'"
                    strSql = strSql & " ,DisCountText='" & DisCountText & "'"
                    strSql = strSql & " ,Amount=" & Amount '& "'"
                    strSql = strSql & " ,Cost=" & Cost '& "'"
                    strSql = strSql & " ,UnitRatio=" & UnitRatio '& "'"
                    strSql = strSql & " ,UnitCode='" & UnitCode & "'"
                    strSql = strSql & " ,ItemType=" & ItemType '& "'"
                    strSql = strSql & " ,PriceFlag=" & PriceFlag '& "'"
                    strSql = strSql & " ,isFree=" & isFree '& "'"
                    strSql = strSql & " Where LineNumber=" & LineNumber & " and DocNo='" & DocNo & "'"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed.//" & LineNumber.ToString
                    End If
                End If
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
        Finally
            objCmd.Dispose()
            objConn.Dispose()
        End Try

        Return strReturn

    End Function

    Public Function SaveWhTrnDetail(ByVal sKey As String, ByVal DocNo As String, ByVal DocDate As String, _
    ByVal WhidFrom As String, ByVal WhIdTo As String, ByVal WhNameFrom As String, ByVal WhNameTo As String, ByVal RefNo As String, _
    ByVal RefDate As String, ByVal LineNumber As Integer, ByVal ItemCode As String, ByVal ItemName As String, ByVal LocCodeFrom As String, ByVal LocCodeTo As String, ByVal Qty As Single, _
    ByVal UnitCode As String) As String

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0

        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else
                If LineNumber = 0 Then   '// New item
                    LineNumber = getItemLineNumberWh(DocNo)
                    strSql = " INSERT INTO TB_WH_TRN_DETAIL ("
                    strSql = strSql & " DocNO"
                    'strSql = strSql & " ,WhIdFrom"
                    'strSql = strSql & " ,WhIdTo"
                    'strSql = strSql & " ,WhNameFrom"
                    'strSql = strSql & " ,WhNameTo"
                    'strSql = strSql & " ,RefNo"
                    'strSql = strSql & " ,RefDate"
                    strSql = strSql & " ,LineNumber"
                    strSql = strSql & " ,ItemCode"
                    strSql = strSql & " ,ItemName"
                    strSql = strSql & " ,LocCodeFrom"
                    strSql = strSql & " ,LocCodeTo"
                    strSql = strSql & " ,Qty"
                    strSql = strSql & " ,UnitCode)"
                    strSql = strSql & " Values("
                    strSql = strSql & "'" & DocNo & "'"
                    'strSql = strSql & ",'" & DocDate & "'"
                    'strSql = strSql & ",'" & WhidFrom & "'"
                    'strSql = strSql & ",'" & WhIdTo & "'"
                    'strSql = strSql & ",'" & WhNameFrom & "'"
                    'strSql = strSql & ",'" & WhNameTo & "'"
                    'strSql = strSql & ",'" & RefNo & "'"
                    'strSql = strSql & ",'" & RefDate & "'"
                    strSql = strSql & "," & LineNumber ' & "'"
                    strSql = strSql & ",'" & ItemCode & "'"
                    strSql = strSql & ",'" & ItemName & "'"
                    strSql = strSql & ",'" & LocCodeFrom & "'"
                    strSql = strSql & ",'" & LocCodeTo & "'"
                    strSql = strSql & "," & Qty ' & "'"
                    strSql = strSql & ",'" & UnitCode & "')"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed.//" & LineNumber.ToString
                    End If
                Else        '// Existing item
                    strSql = " Update TB_Wh_TRN_DETAIL set "
                    'strSql = strSql & " TrnType"
                    'strSql = strSql & " ,DocNo"
                    'strSql = strSql & " DocDate='" & DocDate & "'"
                    'strSql = strSql & " ,WhIdFrom='" & WhidFrom & "'"
                    'strSql = strSql & " ,WhIdTo='" & WhIdTo & "'"
                    'strSql = strSql & " ,WhNameFrom='" & WhNameFrom & "'"
                    'strSql = strSql & " ,WhNameTo='" & WhNameTo & "'"
                    'strSql = strSql & " ,RefNo='" & RefNo & "'"
                    'strSql = strSql & " ,RefDate='" & RefDate & "'"
                    'strSql = strSql & " ,LineNumber"
                    strSql = strSql & " ItemCode='" & ItemCode & "'"
                    strSql = strSql & " ,ItemName='" & ItemName & "'"
                    strSql = strSql & " ,LocCodeFrom='" & LocCodeFrom & "'"
                    strSql = strSql & " ,LocCodeTo='" & LocCodeTo & "'"
                    strSql = strSql & " ,Qty=" & Qty '& "'"
                    strSql = strSql & " ,UnitCode='" & UnitCode & "'"
                    strSql = strSql & " Where LineNumber=" & LineNumber & " and DocNo='" & DocNo & "'"

                    objConn.ConnectionString = strConnectionString
                    objConn.Open()
                    objCmd.Connection = objConn
                    objCmd.CommandText = strSql
                    objCmd.CommandTimeout = 0
                    nResult = objCmd.ExecuteNonQuery
                    If nResult = 0 Then
                        strReturn = "101//Unknow error can not save this data."
                    Else
                        strReturn = "0//Save data completed.//" & LineNumber.ToString
                    End If
                End If
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
        Finally
            objCmd.Dispose()
            objConn.Dispose()
        End Try

        Return strReturn

    End Function

    Public Function UpdateBankLastDate(ByVal sDate As String) As Boolean
        Dim bReturn As Boolean = False
        Dim sQL As String = "update tb_trn_bank_movement set lastdateTemp='" & sDate & "' where lastdate is null or lastdate=''"
        Try
            bReturn = ExecCommand(sQL)
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function CalculateLoanInterest(ByVal sKey As String, ByVal strWhere As String, ByVal sCalFromDate As String, ByVal sCalToDate As String) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataInterest As New DataSet
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim sDateFrom As String
        Dim sDateTo As String
        Dim nMoney As Single
        Dim nInt As Single
        Dim nNoOfDay As Integer
        Dim sTempDate As String
        Dim sGrade As String
        Dim sLoanNo As String
        Dim nIntAmount As Single
        Dim sProj As String
        Dim sIntRateField As String

        'Dim nMoneyFrom As Single
        'Dim nMoneyTo As Single
        'Dim nBeginShare As Integer = 0
        'Dim nBeginValue As Single = 0
        Dim i, j As Long

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                'objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                'isTrans = True
                'objCmd.Transaction = objTran

                '// Clear วันครบกำหนดชำระเงินก่อนคำนวน
                strSql = "Update TB_TRN_LOAN_CONTRACT set LoanToPayDate=NULL , LoanToPay=0 Where not LoanToPayDate is Null"
                objCmd.CommandText = strSql
                objCmd.ExecuteNonQuery()

                '//ลบข้อมูลตารางประวัติการการคำนวนที่ยังไม่ได้ post
                strSql = "Delete TB_TRN_LOAN_INT_HISTORY Where CalType=1 and isPosted=0 " 'and ((FromDate>='" & sCalFromDate & "' and FromDate<='" & sCalToDate & "')or(ToDate>='" & sCalFromDate & "' and ToDate<='" & sCalToDate & "'))"
                objCmd.CommandText = strSql
                objCmd.ExecuteNonQuery()

                ''//Clear ข้อมูลการคำนวนดอกที่ตาราง Movement ที่ยังไม่ได้ Post
                'strSql = "Update TB_TRN_BANK_MOVEMENT set Interest_ratio=0,Interest_amount=0 Where DocDate>='" & sCalFromDate & "' and DocDate<='" & sCalToDate & "'"
                'objCmd.CommandText = strSql
                'objCmd.ExecuteNonQuery()

                'objTran.Commit()

                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran


                'strSql = " SELECT A.TrnID,A.PrjNo,A.LoanNo,  A.PrjNO + '/' + A.LoanNo AS LoanNO1, B.Name, A.LastDate,A.DocDate,A.Carydown_amount, A.CarryFwd_amount, C.CustGrade "
                'strSql = strSql & " FROM   TB_TRN_LOAN_MOVEMENT AS A INNER JOIN"
                'strSql = strSql & " V021_LOAN_CONTRACT AS B ON A.PrjNO = B.PrjNo AND A.LoanNo = B.LoanNo INNER JOIN"
                'strSql = strSql & " TB_MAS_LOAN_MEM_GRADE AS C ON B.CustId = C.CustId"

                strSql = " SELECT A.PrjNo,A.LoanNo,  A.PrjNO + '/' + A.LoanNo AS LoanNO1, A.Name, A.LastDate,isnull(A.LoanBalance,0) LoanBalance,  B.CustGrade "
                strSql = strSql & " FROM   V021_LOAN_CONTRACT AS A INNER JOIN"
                strSql = strSql & " TB_MAS_LOAN_MEM_GRADE AS B ON  A.CustId = B.CustId "

                oDataset = getDataSetTableName(strSql & strWhere & " order by PrjNo,LoanNO", "V021_LOAN_CONTRACT")  'Where AccNo='" & AccNO & "'

                For i = 0 To oDataset.Tables(0).Rows.Count - 1
                    '// Check ว่าในวันที่กำลังคิดดอกเบี้ยต้องคิดกี่ครั้งและแต่ละครั้งคิดกีเปอร์เซ็นต์

                    sLoanNo = oDataset.Tables(0).Rows(i).Item("LoanNO").ToString
                    nMoney = oDataset.Tables(0).Rows(i).Item("LoanBalance")
                    If IsDBNull(oDataset.Tables(0).Rows(i).Item("LastDate")) Then
                        sDateFrom = oConFig.getBeginDate(Today)    'oDataset.Tables(0).Rows(i).Item("DocDate").ToString
                    Else
                        sDateFrom = oConFig.Date2db(DateAdd(DateInterval.Day, 1, oConFig.db2Date(oDataset.Tables(0).Rows(i).Item("LastDate").ToString)))
                    End If

                    sGrade = oDataset.Tables(0).Rows(i).Item("CustGrade").ToString
                    sProj = oDataset.Tables(0).Rows(i).Item("PrjNo").ToString

                    'If oDataset.Tables(0).Rows(i).Item("LastDate").ToString = "" Then
                    sDateTo = sCalToDate
                    'Else
                    '    sDateTo = oDataset.Tables(0).Rows(i).Item("LastDate").ToString
                    'End If

                    Debug.Print(i + 1 & ". Date=" & oDataset.Tables(0).Rows(i).Item("LastDate").ToString & "  LoanNO=" & oDataset.Tables(0).Rows(i).Item("LoanNO1").ToString & " Date from " & sDateFrom & " - " & sDateTo & " Moneys=" & nMoney.ToString & " Grade=" & sGrade)

                    strWhere = " Where PrjNo='" & sProj.Trim & "'"
                    strWhere = strWhere & " and ((FromDate <='" & sDateFrom & "' and ToDate >='" & sDateFrom & "')) "  ' Or (FromDate <='" & sDateTo & "' and ToDate >='" & sDateTo & "')
                    oDataInterest = getDataSet("SELECT     PrjNo, FromDate, ToDate, Rate1, Rate2, Rate3, Rate4, Rate5 FROM  TB_MAS_LOAN_INTEREST " & strWhere & " order by FromDate")
                    If oDataInterest.Tables.Count > 0 Then
                        If oDataInterest.Tables(0).Rows.Count > 0 Then
                            For j = 0 To oDataInterest.Tables(0).Rows.Count - 1  '// ไล่ทีละอัตราภาษี
                                If sDateFrom < oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString Then
                                    sDateFrom = oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString
                                End If
                                If sDateTo > oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString Then
                                    sTempDate = oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString
                                Else
                                    sTempDate = sDateTo
                                End If
                                If sGrade = "AA" Then
                                    sIntRateField = "Rate1"
                                ElseIf sGrade = "A" Then
                                    sIntRateField = "Rate2"
                                ElseIf sGrade = "B" Then
                                    sIntRateField = "Rate3"
                                ElseIf sGrade = "C" Then
                                    sIntRateField = "Rate4"
                                Else
                                    sIntRateField = "Rate5"
                                End If

                                nInt = oDataInterest.Tables(0).Rows(j).Item(sIntRateField).ToString
                                'nNoOfDay = DateDiff(DateInterval.Day, CDate(sDateFrom), CDate(sTempDate)) ' - 1
                                nNoOfDay = DateDiff(DateInterval.Day, oConFig.db2Date(sDateFrom), oConFig.db2Date(sTempDate)) ' - 1
                                If nNoOfDay < 0 Then nNoOfDay = 0
                                nNoOfDay = nNoOfDay + 1
                                'If Val(oDataset.Tables(0).Rows(i).Item("CaryDown_amount").ToString) > 0 Then nNoOfDay = nNoOfDay + 1

                                nIntAmount = Math.Round(nMoney * (nInt / 100) * (nNoOfDay * 1.0 / 365), 0)  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
                                Debug.Print("   " & j + 1 & ". Date from (" & sDateFrom & " To " & sTempDate & ") Moneys=" & nMoney.ToString & " NoOfDay=" & nNoOfDay & " Int=" & nInt.ToString & " Amount=" & nIntAmount.ToString)

                                strSql = "Insert into [TB_TRN_LOAN_INT_HISTORY] (CalType,PrjNo,LoanNo,FromDate,ToDate,NoOfDay,TMoneys,IntRatio,IntAmount,isPosted)"
                                strSql = strSql & " Values(1,'" & sProj & "','" & sLoanNo & "','" & sDateFrom & "','" & sTempDate & "'," & nNoOfDay.ToString & "," & nMoney.ToString & "," & nInt.ToString & "," & nIntAmount.ToString & ",0)"
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()


                            Next j
                        End If
                    End If

                    '//Update เงินต้นพึงชำระ
                    strSql = "Update tb_trn_loan_contract set LoanToPayDate='" & sCalToDate & "',  LoanToPay=(SELECT ISNULL(SUM(PayAmount - ISNULL(PaidAmount, 0)), 0) AS LoanToPay"
                    strSql = strSql & " FROM TB_TRN_LOAN_PERIOD "
                    strSql = strSql & " WHERE     (PeriodDate <= '" & sCalToDate & "') AND (PrjNo = '" & sProj & "') AND (LoanNo = '" & sLoanNo & "'))"
                    strSql = strSql & " Where (PrjNo = '" & sProj & "') AND (LoanNo = '" & sLoanNo & "')"
                    objCmd.CommandText = strSql
                    objCmd.ExecuteNonQuery()

                Next i



                strReturn = "0//Save data completed."
                If isTrans Then objTran.Commit() : isTrans = False
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            If objTran Is Nothing = False Then objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function PostLoanInterest(ByVal sKey As String, ByVal strWhere As String, ByVal sCalFromDate As String, ByVal sCalToDate As String) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataInterest As New DataSet
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim sDateFrom As String
        Dim sDateTo As String
        Dim nMoney As Single
        Dim nInt As Single
        Dim nNoOfDay As Integer
        Dim sTempDate As String
        Dim sGrade As String
        Dim sLoanNo As String
        Dim nIntAmount As Single
        Dim sProj As String
        Dim sIntRateField As String
        'Dim nMoneyFrom As Single
        'Dim nMoneyTo As Single
        'Dim nBeginShare As Integer = 0
        'Dim nBeginValue As Single = 0
        Dim i, j As Long

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                'objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                'isTrans = True
                'objCmd.Transaction = objTran

                '//ลบข้อมูลตารางประวัติการการคำนวนที่ยังไม่ได้ post
                strSql = "Delete TB_TRN_LOAN_INT_HISTORY Where CalType=1 and isPosted=0 " 'and ((FromDate>='" & sCalFromDate & "' and FromDate<='" & sCalToDate & "')or(ToDate>='" & sCalFromDate & "' and ToDate<='" & sCalToDate & "'))"
                objCmd.CommandText = strSql
                objCmd.ExecuteNonQuery()

                ''//Clear ข้อมูลการคำนวนดอกที่ตาราง Movement ที่ยังไม่ได้ Post
                'strSql = "Update TB_TRN_BANK_MOVEMENT set Interest_ratio=0,Interest_amount=0 Where DocDate>='" & sCalFromDate & "' and DocDate<='" & sCalToDate & "'"
                'objCmd.CommandText = strSql
                'objCmd.ExecuteNonQuery()

                'objTran.Commit()

                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran


                'strSql = " SELECT A.TrnID,A.PrjNo,A.LoanNo,  A.PrjNO + '/' + A.LoanNo AS LoanNO1, B.Name, A.LastDate,A.DocDate,A.Carydown_amount, A.CarryFwd_amount, C.CustGrade "
                'strSql = strSql & " FROM   TB_TRN_LOAN_MOVEMENT AS A INNER JOIN"
                'strSql = strSql & " V021_LOAN_CONTRACT AS B ON A.PrjNO = B.PrjNo AND A.LoanNo = B.LoanNo INNER JOIN"
                'strSql = strSql & " TB_MAS_LOAN_MEM_GRADE AS C ON B.CustId = C.CustId"

                strSql = " SELECT A.PrjNo,A.LoanNo,  A.PrjNO + '/' + A.LoanNo AS LoanNO1, A.Name, A.LastDate,isnull(A.LoanBalance,0) LoanBalance,  B.CustGrade "
                strSql = strSql & " FROM   V021_LOAN_CONTRACT AS A INNER JOIN"
                strSql = strSql & " TB_MAS_LOAN_MEM_GRADE AS B ON  A.CustId = B.CustId "

                oDataset = getDataSetTableName(strSql & strWhere & " order by PrjNo,LoanNO", "V021_LOAN_CONTRACT")  'Where AccNo='" & AccNO & "'

                For i = 0 To oDataset.Tables(0).Rows.Count - 1
                    '// Check ว่าในวันที่กำลังคิดดอกเบี้ยต้องคิดกี่ครั้งและแต่ละครั้งคิดกีเปอร์เซ็นต์

                    sLoanNo = oDataset.Tables(0).Rows(i).Item("LoanNO").ToString
                    nMoney = oDataset.Tables(0).Rows(i).Item("LoanBalance")
                    If IsDBNull(oDataset.Tables(0).Rows(i).Item("LastDate")) Then
                        sDateFrom = oConFig.getBeginDate(Today)    'oDataset.Tables(0).Rows(i).Item("DocDate").ToString
                    Else
                        sDateFrom = oConFig.Date2db(DateAdd(DateInterval.Day, 1, oConFig.db2Date(oDataset.Tables(0).Rows(i).Item("LastDate").ToString)))
                    End If

                    sGrade = oDataset.Tables(0).Rows(i).Item("CustGrade").ToString
                    sProj = oDataset.Tables(0).Rows(i).Item("PrjNo").ToString

                    'If oDataset.Tables(0).Rows(i).Item("LastDate").ToString = "" Then
                    sDateTo = sCalToDate
                    'Else
                    '    sDateTo = oDataset.Tables(0).Rows(i).Item("LastDate").ToString
                    'End If

                    Debug.Print(i + 1 & ". Date=" & oDataset.Tables(0).Rows(i).Item("LastDate").ToString & "  LoanNO=" & oDataset.Tables(0).Rows(i).Item("LoanNO1").ToString & " Date from " & sDateFrom & " - " & sDateTo & " Moneys=" & nMoney.ToString & " Grade=" & sGrade)

                    strWhere = " Where PrjNo='" & sProj.Trim & "'"
                    strWhere = strWhere & " and ((FromDate <='" & sDateFrom & "' and ToDate >='" & sDateFrom & "')) "  ' Or (FromDate <='" & sDateTo & "' and ToDate >='" & sDateTo & "')
                    oDataInterest = getDataSet("SELECT     PrjNo, FromDate, ToDate, Rate1, Rate2, Rate3, Rate4, Rate5 FROM  TB_MAS_LOAN_INTEREST " & strWhere & " order by FromDate")
                    If oDataInterest.Tables.Count > 0 Then
                        If oDataInterest.Tables(0).Rows.Count > 0 Then
                            For j = 0 To oDataInterest.Tables(0).Rows.Count - 1  '// ไล่ทีละอัตราภาษี
                                If sDateFrom < oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString Then
                                    sDateFrom = oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString
                                End If
                                If sDateTo > oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString Then
                                    sTempDate = oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString
                                Else
                                    sTempDate = sDateTo
                                End If
                                If sGrade = "AA" Then
                                    sIntRateField = "Rate1"
                                ElseIf sGrade = "A" Then
                                    sIntRateField = "Rate2"
                                ElseIf sGrade = "B" Then
                                    sIntRateField = "Rate3"
                                ElseIf sGrade = "C" Then
                                    sIntRateField = "Rate4"
                                Else
                                    sIntRateField = "Rate5"
                                End If

                                nInt = oDataInterest.Tables(0).Rows(j).Item(sIntRateField).ToString
                                'nNoOfDay = DateDiff(DateInterval.Day, CDate(sDateFrom), CDate(sTempDate)) ' - 1
                                nNoOfDay = DateDiff(DateInterval.Day, oConFig.db2Date(sDateFrom), oConFig.db2Date(sTempDate)) ' - 1
                                If nNoOfDay < 0 Then nNoOfDay = 0
                                nNoOfDay = nNoOfDay + 1
                                'If Val(oDataset.Tables(0).Rows(i).Item("CaryDown_amount").ToString) > 0 Then nNoOfDay = nNoOfDay + 1

                                nIntAmount = Math.Round(nMoney * (nInt / 100) * (nNoOfDay * 1.0 / 365), 0)  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
                                Debug.Print("   " & j + 1 & ". Date from (" & sDateFrom & " To " & sTempDate & ") Moneys=" & nMoney.ToString & " NoOfDay=" & nNoOfDay & " Int=" & nInt.ToString & " Amount=" & nIntAmount.ToString)

                                strSql = "Insert into [TB_TRN_LOAN_INT_HISTORY] (CalType,PrjNo,LoanNo,FromDate,ToDate,NoOfDay,TMoneys,IntRatio,IntAmount,isPosted)"
                                strSql = strSql & " Values(1,'" & sProj & "','" & sLoanNo & "','" & sDateFrom & "','" & sTempDate & "'," & nNoOfDay.ToString & "," & nMoney.ToString & "," & nInt.ToString & "," & nIntAmount.ToString & ",1)"
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()

                                'strSql = "Update TB_TRN_LOAN_MOVEMENT set LastDate='" & sTempDate & "' Where TrnId=" & oDataset.Tables(0).Rows(i).Item("TrnId").ToString
                                'objCmd.CommandText = strSql
                                'objCmd.ExecuteNonQuery()

                                strSql = "Update TB_TRN_LOAN_CONTRACT SET LASTDATE='" & sTempDate & "', DBBALANCE=ISNULL(DBBALANCE,0)+" & nIntAmount.ToString & " WHERE PRJNO='" & sProj & "' AND LOANNO='" & sLoanNo & "'"
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()



                            Next j
                        End If
                    End If

                Next i



                strReturn = "0//Save data completed."
                If isTrans Then objTran.Commit() : isTrans = False
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function CalculateLoanFine(ByVal sKey As String, ByVal strWhere As String, ByVal sCalFromDate As String, ByVal sCalToDate As String) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataInterest As New DataSet
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim sDateFrom As String
        Dim sDateTo As String
        Dim nMoney As Single
        Dim nInt As Single
        Dim nNoOfDay As Integer
        Dim sTempDate As String
        'Dim sGrade As String
        Dim sLoanNo As String
        Dim nIntAmount As Single
        Dim sProj As String
        Dim sIntRateField As String
        'Dim nMoneyFrom As Single
        'Dim nMoneyTo As Single
        'Dim nBeginShare As Integer = 0
        'Dim nBeginValue As Single = 0
        Dim i, j As Long

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                'objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                'isTrans = True
                'objCmd.Transaction = objTran

                '//ลบข้อมูลตารางประวัติการการคำนวนที่ยังไม่ได้ post
                strSql = "Delete TB_TRN_LOAN_INT_HISTORY Where CalType=2 and isPosted=0 " 'and ((FromDate>='" & sCalFromDate & "' and FromDate<='" & sCalToDate & "')or(ToDate>='" & sCalFromDate & "' and ToDate<='" & sCalToDate & "'))"
                objCmd.CommandText = strSql
                objCmd.ExecuteNonQuery()

                ''//Clear ข้อมูลการคำนวนดอกที่ตาราง Movement ที่ยังไม่ได้ Post
                'strSql = "Update TB_TRN_BANK_MOVEMENT set Interest_ratio=0,Interest_amount=0 Where DocDate>='" & sCalFromDate & "' and DocDate<='" & sCalToDate & "'"
                'objCmd.CommandText = strSql
                'objCmd.ExecuteNonQuery()

                'objTran.Commit()

                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                strSql = " SELECT A.TrnId,A.PrjNo, A.LoanNo,  A.PeriodNo, isnull(A.PayAmount,0)as PayAmount, A.LastDate, A.PeriodDate, isnull(A.PaidAmount,0) as PaidAmount,(isnull(A.PayAmount,0)-isnull(A.PaidAmount,0)) as CarryFwd_amount, B.PrjPctFine"
                strSql = strSql & " FROM  TB_TRN_LOAN_PERIOD AS A INNER JOIN"
                strSql = strSql & " V021_LOAN_CONTRACT AS B ON A.PrjNo = B.PrjNo AND A.LoanNo = B.LoanNo"

                'strSql = " SELECT A.TrnID,A.PrjNo,A.LoanNo,  A.PrjNO + '/' + A.LoanNo AS LoanNO1, B.Name, A.LastDate, A.CarryFwd_amount, C.CustGrade"
                'strSql = strSql & " FROM   TB_TRN_LOAN_MOVEMENT AS A INNER JOIN"
                'strSql = strSql & " V021_LOAN_CONTRACT AS B ON A.PrjNO = B.PrjNo AND A.LoanNo = B.LoanNo INNER JOIN"
                'strSql = strSql & " TB_MAS_LOAN_MEM_GRADE AS C ON B.CustId = C.CustId"

                oDataset = getDataSetTableName(strSql & strWhere & " order by TrnId", "TB_TRN_LOAN_MOVEMENT")  'Where AccNo='" & AccNO & "'

                For i = 0 To oDataset.Tables(0).Rows.Count - 1
                    '// Check ว่าในวันที่กำลังคิดดอกเบี้ยต้องคิดกี่ครั้งและแต่ละครั้งคิดกีเปอร์เซ็นต์

                    sLoanNo = oDataset.Tables(0).Rows(i).Item("LoanNO").ToString
                    nMoney = oDataset.Tables(0).Rows(i).Item("CarryFwd_amount")
                    If oDataset.Tables(0).Rows(i).Item("LastDate").ToString = "" Then
                        'sDateFrom = oDataset.Tables(0).Rows(i).Item("PeriodDate").ToString
                        sDateFrom = oConFig.Date2db(DateAdd(DateInterval.Day, 1, oConFig.db2Date(oDataset.Tables(0).Rows(i).Item("PeriodDate").ToString)))
                    Else
                        sDateFrom = oConFig.Date2db(DateAdd(DateInterval.Day, 1, oConFig.db2Date(oDataset.Tables(0).Rows(i).Item("LastDate").ToString)))
                    End If

                    sProj = oDataset.Tables(0).Rows(i).Item("PrjNo").ToString

                    If sDateFrom < oConFig.getBeginDate(Today) Then
                        sTempDate = oConFig.getBeginDate(Today)
                    Else
                        sTempDate = sDateFrom
                    End If


                    sDateTo = sCalToDate



                    nInt = oDataset.Tables(0).Rows(i).Item("PrjPctFine").ToString
                    'nNoOfDay = DateDiff(DateInterval.Day, CDate(sTempDate), CDate(sDateTo)) ' - 1
                    nNoOfDay = DateDiff(DateInterval.Day, oConFig.db2Date(sTempDate), oConFig.db2Date(sDateTo)) '- 1
                    If Right(sTempDate, 5) <> "04-01" Then
                        ' nNoOfDay = nNoOfDay - 1
                    End If
                    If nNoOfDay < 0 Then nNoOfDay = 0
                    If nNoOfDay > 365 Then nNoOfDay = 365

                    nNoOfDay = nNoOfDay + 1

                    nIntAmount = Math.Round(nMoney * (nInt / 100) * (nNoOfDay * 1.0 / 365), 0)  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
                    Debug.Print("   คป." & j + 1 & ". Date from (" & sTempDate & " To " & sDateTo & ") Moneys=" & nMoney.ToString & " NoOfDay=" & nNoOfDay & " Int=" & nInt.ToString & " Amount=" & nIntAmount.ToString)

                    strSql = "Insert into [TB_TRN_LOAN_INT_HISTORY] (CalType,PrjNo,LoanNo,FromDate,ToDate,NoOfDay,TMoneys,IntRatio,IntAmount,isPosted,MovementId)"
                    strSql = strSql & " Values(2,'" & sProj & "','" & sLoanNo & "','" & sTempDate & "','" & sDateTo & "'," & nNoOfDay.ToString & "," & nMoney.ToString & "," & nInt.ToString & "," & nIntAmount.ToString & ",0," & oDataset.Tables(0).Rows(i).Item("TrnId").ToString & ")"
                    objCmd.CommandText = strSql
                    objCmd.ExecuteNonQuery()


                    ''If oDataset.Tables(0).Rows(i).Item("LastDate").ToString = "" Then
                    'sDateTo = sCalToDate
                    ''Else
                    ''    sDateTo = oDataset.Tables(0).Rows(i).Item("LastDate").ToString
                    ''End If

                    'Debug.Print(i + 1 & ". Date=" & oDataset.Tables(0).Rows(i).Item("LastDate").ToString & "  LoanNO=" & oDataset.Tables(0).Rows(i).Item("LoanNO1").ToString & " Date from " & sDateFrom & " - " & sDateTo & " Moneys=" & nMoney.ToString)

                    'strWhere = " Where PrjNo='" & sProj.Trim & "'"
                    'strWhere = strWhere & " and ((FromDate <='" & sDateFrom & "' and ToDate >='" & sDateFrom & "')) "  ' Or (FromDate <='" & sDateTo & "' and ToDate >='" & sDateTo & "')
                    'oDataInterest = getDataSet("SELECT     PrjNo, FromDate, ToDate, Rate1, Rate2, Rate3, Rate4, Rate5 FROM  TB_MAS_LOAN_INTEREST " & strWhere & " order by FromDate")
                    'If oDataInterest.Tables.Count > 0 Then
                    '    If oDataInterest.Tables(0).Rows.Count > 0 Then
                    '        For j = 0 To oDataInterest.Tables(0).Rows.Count - 1  '// ไล่ทีละอัตราภาษี
                    '            If sDateFrom < oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString Then
                    '                sDateFrom = oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString
                    '            End If
                    '            If sDateTo > oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString Then
                    '                sTempDate = oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString
                    '            Else
                    '                sTempDate = sDateTo
                    '            End If
                    '            'If sGrade = "AA" Then
                    '            '    sIntRateField = "Rate1"
                    '            'ElseIf sGrade = "A" Then
                    '            '    sIntRateField = "Rate2"
                    '            'ElseIf sGrade = "B" Then
                    '            '    sIntRateField = "Rate3"
                    '            'ElseIf sGrade = "C" Then
                    '            '    sIntRateField = "Rate4"
                    '            'Else
                    '            '    sIntRateField = "Rate5"
                    '            'End If

                    '            nInt = oDataInterest.Tables(0).Rows(j).Item(sIntRateField).ToString
                    '            nNoOfDay = DateDiff(DateInterval.Day, CDate(sDateFrom), CDate(sTempDate)) ' - 1
                    '            If nNoOfDay < 0 Then nNoOfDay = 0
                    '            nIntAmount = Math.Round(nMoney * (nInt / 100) * (nNoOfDay * 1.0 / 365), 0)  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
                    '            Debug.Print("   " & j + 1 & ". Date from (" & sDateFrom & " To " & sTempDate & ") Moneys=" & nMoney.ToString & " NoOfDay=" & nNoOfDay & " Int=" & nInt.ToString & " Amount=" & nIntAmount.ToString)

                    '            strSql = "Insert into [TB_TRN_LOAN_INT_HISTORY] (CalType,PrjNo,LoanNo,FromDate,ToDate,NoOfDay,TMoneys,IntRatio,IntAmount,isPosted,MovementId)"
                    '            strSql = strSql & " Values(1,'" & sProj & "','" & sLoanNo & "','" & sDateFrom & "','" & sTempDate & "'," & nNoOfDay.ToString & "," & nMoney.ToString & "," & nInt.ToString & "," & nIntAmount.ToString & ",0," & oDataset.Tables(0).Rows(i).Item("TrnId").ToString & ")"
                    '            objCmd.CommandText = strSql
                    '            objCmd.ExecuteNonQuery()


                    '        Next j
                    '    End If
                    'End If

                Next i



                strReturn = "0//Save data completed."
                If isTrans Then objTran.Commit() : isTrans = False
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            If objTran Is Nothing = False Then objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function PostLoanFine(ByVal sKey As String, ByVal strWhere As String, ByVal sCalFromDate As String, ByVal sCalToDate As String) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataInterest As New DataSet
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim sDateFrom As String
        Dim sDateTo As String
        Dim nMoney As Single
        Dim nInt As Single
        Dim nNoOfDay As Integer
        Dim sTempDate As String
        'Dim sGrade As String
        Dim sLoanNo As String
        Dim nIntAmount As Single
        Dim sProj As String
        Dim sIntRateField As String
        'Dim nMoneyFrom As Single
        'Dim nMoneyTo As Single
        'Dim nBeginShare As Integer = 0
        'Dim nBeginValue As Single = 0
        Dim i, j As Long

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                'objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                'isTrans = True
                'objCmd.Transaction = objTran

                '//ลบข้อมูลตารางประวัติการการคำนวนที่ยังไม่ได้ post
                strSql = "Delete TB_TRN_LOAN_INT_HISTORY Where CalType=2 and isPosted=0 " 'and ((FromDate>='" & sCalFromDate & "' and FromDate<='" & sCalToDate & "')or(ToDate>='" & sCalFromDate & "' and ToDate<='" & sCalToDate & "'))"
                objCmd.CommandText = strSql
                objCmd.ExecuteNonQuery()

                ''//Clear ข้อมูลการคำนวนดอกที่ตาราง Movement ที่ยังไม่ได้ Post
                'strSql = "Update TB_TRN_BANK_MOVEMENT set Interest_ratio=0,Interest_amount=0 Where DocDate>='" & sCalFromDate & "' and DocDate<='" & sCalToDate & "'"
                'objCmd.CommandText = strSql
                'objCmd.ExecuteNonQuery()

                'objTran.Commit()

                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran

                strSql = " SELECT A.TrnId,A.PrjNo, A.LoanNo,  A.PeriodNo, isnull(A.PayAmount,0)as PayAmount, A.LastDate, A.PeriodDate, isnull(A.PaidAmount,0) as PaidAmount,(isnull(A.PayAmount,0)-isnull(A.PaidAmount,0)) as CarryFwd_amount, B.PrjPctFine"
                strSql = strSql & " FROM  TB_TRN_LOAN_PERIOD AS A INNER JOIN"
                strSql = strSql & " V021_LOAN_CONTRACT AS B ON A.PrjNo = B.PrjNo AND A.LoanNo = B.LoanNo"

                'strSql = " SELECT A.TrnID,A.PrjNo,A.LoanNo,  A.PrjNO + '/' + A.LoanNo AS LoanNO1, B.Name, A.LastDate, A.CarryFwd_amount, C.CustGrade"
                'strSql = strSql & " FROM   TB_TRN_LOAN_MOVEMENT AS A INNER JOIN"
                'strSql = strSql & " V021_LOAN_CONTRACT AS B ON A.PrjNO = B.PrjNo AND A.LoanNo = B.LoanNo INNER JOIN"
                'strSql = strSql & " TB_MAS_LOAN_MEM_GRADE AS C ON B.CustId = C.CustId"

                oDataset = getDataSetTableName(strSql & strWhere & " order by TrnId", "TB_TRN_LOAN_MOVEMENT")  'Where AccNo='" & AccNO & "'

                For i = 0 To oDataset.Tables(0).Rows.Count - 1
                    '// Check ว่าในวันที่กำลังคิดดอกเบี้ยต้องคิดกี่ครั้งและแต่ละครั้งคิดกีเปอร์เซ็นต์

                    sLoanNo = oDataset.Tables(0).Rows(i).Item("LoanNO").ToString
                    nMoney = oDataset.Tables(0).Rows(i).Item("CarryFwd_amount")
                    If oDataset.Tables(0).Rows(i).Item("LastDate").ToString = "" Then
                        'sDateFrom = oDataset.Tables(0).Rows(i).Item("PeriodDate").ToString
                        sDateFrom = oConFig.Date2db(DateAdd(DateInterval.Day, 1, oConFig.db2Date(oDataset.Tables(0).Rows(i).Item("PeriodDate").ToString)))
                    Else
                        sDateFrom = oConFig.Date2db(DateAdd(DateInterval.Day, 1, oConFig.db2Date(oDataset.Tables(0).Rows(i).Item("LastDate").ToString)))
                    End If

                    sProj = oDataset.Tables(0).Rows(i).Item("PrjNo").ToString

                    If sDateFrom < oConFig.getBeginDate(Today) Then
                        sTempDate = oConFig.getBeginDate(Today)
                    Else
                        sTempDate = sDateFrom
                    End If


                    sDateTo = sCalToDate

                    nInt = oDataset.Tables(0).Rows(i).Item("PrjPctFine").ToString
                    'nNoOfDay = DateDiff(DateInterval.Day, CDate(sTempDate), CDate(sDateTo)) ' - 1
                    'nNoOfDay = DateDiff(DateInterval.Day, oConFig.db2Date(sTempDate), oConFig.db2Date(sDateTo)) ' - 1
                    nNoOfDay = DateDiff(DateInterval.Day, oConFig.db2Date(sTempDate), oConFig.db2Date(sDateTo)) '- 1
                    If Right(sTempDate, 5) <> "04-01" Then
                        'nNoOfDay = nNoOfDay - 1
                    End If
                    If nNoOfDay < 0 Then nNoOfDay = 0
                    If nNoOfDay > 365 Then nNoOfDay = 365

                    nNoOfDay = nNoOfDay + 1

                    nIntAmount = Math.Round(nMoney * (nInt / 100) * (nNoOfDay * 1.0 / 365), 0)  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
                    Debug.Print("   คป." & j + 1 & ". Date from (" & sTempDate & " To " & sDateTo & ") Moneys=" & nMoney.ToString & " NoOfDay=" & nNoOfDay & " Int=" & nInt.ToString & " Amount=" & nIntAmount.ToString)

                    strSql = "Insert into [TB_TRN_LOAN_INT_HISTORY] (CalType,PrjNo,LoanNo,FromDate,ToDate,NoOfDay,TMoneys,IntRatio,IntAmount,isPosted,MovementId)"
                    strSql = strSql & " Values(2,'" & sProj & "','" & sLoanNo & "','" & sTempDate & "','" & sDateTo & "'," & nNoOfDay.ToString & "," & nMoney.ToString & "," & nInt.ToString & "," & nIntAmount.ToString & ",1," & oDataset.Tables(0).Rows(i).Item("TrnId").ToString & ")"
                    objCmd.CommandText = strSql
                    objCmd.ExecuteNonQuery()

                    strSql = "Update TB_TRN_LOAN_PERIOD set  LastDate='" & sDateTo & "' Where TrnId=" & oDataset.Tables(0).Rows(i).Item("TrnId").ToString
                    objCmd.CommandText = strSql
                    objCmd.ExecuteNonQuery()

                    strSql = "Update TB_TRN_LOAN_CONTRACT SET FINEBALANCE=ISNULL(FINEBALANCE,0)+" & nIntAmount.ToString & " WHERE PRJNO='" & sProj & "' AND LOANNO='" & sLoanNo & "'"
                    objCmd.CommandText = strSql
                    objCmd.ExecuteNonQuery()

                Next i

                strReturn = "0//Save data completed."
                If isTrans Then objTran.Commit() : isTrans = False
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            If objTran Is Nothing = False Then objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function CalculateInterest(ByVal sKey As String, ByVal sAccType As String, ByVal strWhere As String, ByVal sCalFromDate As String, ByVal sCalToDate As String, ByVal isPosted As Byte) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataInterest As New DataSet
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim sDateFrom As String
        Dim sDateTo As String
        Dim nMoney As Decimal
        Dim nInt As Decimal
        Dim nNoOfDay As Integer
        Dim sTempDate As String
        Dim sAccNo As String
        Dim nIntAmount As Decimal
        'Dim nMoneyFrom As Single
        'Dim nMoneyTo As Single
        'Dim nBeginShare As Integer = 0
        'Dim nBeginValue As Single = 0
        Dim i, j As Long

        'Dim nTotalShare As Integer = 0
        Dim nTotalValues As Decimal = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                'objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                'isTrans = True
                'objCmd.Transaction = objTran

                '//ลบข้อมูลตารางประวัติการการคำนวนที่ยังไม่ได้ post
                strSql = "Delete TB_TRN_BANK_INT_HISTORY Where isPosted=0 and (FromDate>='" & sCalFromDate & "' and FromDate<='" & sCalToDate & "')"
                objCmd.CommandText = strSql
                objCmd.ExecuteNonQuery()

                '//Clear ข้อมูลการคำนวนดอกที่ตาราง Movement ที่ยังไม่ได้ Post
                strSql = "Update TB_TRN_BANK_MOVEMENT set Interest_ratio=0,Interest_amount=0 Where DocDate>='" & sCalFromDate & "' and DocDate<='" & sCalToDate & "'"
                objCmd.CommandText = strSql
                objCmd.ExecuteNonQuery()

                'objTran.Commit()

                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = True
                objCmd.Transaction = objTran


                'SELECT     AccNo, TPrefix, Name, ItemDesc, BranchId, CaryDown_amount, Receive_amount, Issue_amount, Interest_amount, CarryFwd_amount, DocNo, 
                'ModifyBy, ModifyDate, TrnId, DocDate, isPrinted, LastDate, Remark, Interest_ratio, isPosted, DepType, MemType
                'FROM         V022_BANK_MOVEMENT
                oDataset = getDataSetTableName(" Select * from v008_BANK_STATEMENT Where " & strWhere & " order by TrnId", "TB_TRN_BANK_MOVEMENT")  'Where AccNo='" & AccNO & "'

                For i = 0 To oDataset.Tables(0).Rows.Count - 1
                    '// Check ว่าในวันที่กำลังคิดดอกเบี้ยต้องคิดกี่ครั้งและแต่ละครั้งคิดกีเปอร์เซ็นต์

                    sAccNo = oDataset.Tables(0).Rows(i).Item("AccNo").ToString
                    nMoney = oDataset.Tables(0).Rows(i).Item("CarryFwd_amount")
                    sDateFrom = oDataset.Tables(0).Rows(i).Item("DocDate").ToString
                    If oDataset.Tables(0).Rows(i).Item("LastDate").ToString = "" Then
                        sDateTo = sCalToDate
                    Else
                        sDateTo = oDataset.Tables(0).Rows(i).Item("LastDate").ToString
                    End If

                    Debug.Print(i + 1 & ". Date=" & oDataset.Tables(0).Rows(i).Item("DocDate").ToString & "  AccNo=" & oDataset.Tables(0).Rows(i).Item("AccNo").ToString & " Date from " & sDateFrom & " - " & sDateTo & " Moneys=" & nMoney)

                    strWhere = "Where AccType='" & sAccType.Trim & "'"
                    strWhere = strWhere & " and ((FromDate <='" & sDateFrom & "' and ToDate >='" & sDateFrom & "') Or (FromDate <='" & sDateTo & "' and ToDate >='" & sDateTo & "')) "
                    strWhere = strWhere & " and (FromMoney<=" & nMoney & " and ToMoney>=" & nMoney & ")"
                    oDataInterest = getDataSet("SELECT  AccType, FromDate, ToDate, FromMoney, ToMoney, IntRatio FROM  TB_TRN_BANK_INT_RATIO " & strWhere & " order by FromDate")
                    If oDataInterest.Tables.Count > 0 Then
                        If oDataInterest.Tables(0).Rows.Count > 0 Then
                            For j = 0 To oDataInterest.Tables(0).Rows.Count - 1  '// ไล่ทีละอัตราภาษี
                                If sDateFrom < oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString Then
                                    sDateFrom = oDataInterest.Tables(0).Rows(j).Item("FromDate").ToString
                                End If
                                If sDateTo > oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString Then
                                    sTempDate = oDataInterest.Tables(0).Rows(j).Item("ToDate").ToString
                                Else
                                    sTempDate = sDateTo
                                End If

                                nInt = oDataInterest.Tables(0).Rows(j).Item("IntRatio").ToString
                                'nNoOfDay = DateDiff(DateInterval.Day, CDate(sDateFrom), CDate(sTempDate)) ' - 1
                                nNoOfDay = DateDiff(DateInterval.Day, oConFig.db2Date(sDateFrom), oConFig.db2Date(sTempDate)) ' - 1
                                If nNoOfDay < 0 Then nNoOfDay = 0
                                nIntAmount = Math.Round(nMoney * (nInt / 100) * (nNoOfDay * 1.0 / 365), 0)  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
                                Debug.Print("   " & j + 1 & ". Date from (" & sDateFrom & " To " & sTempDate & ") Moneys=" & nMoney & " NoOfDay=" & nNoOfDay & " Int=" & nInt & " Amount=" & nIntAmount)

                                strSql = "Insert into [TB_TRN_BANK_INT_HISTORY] (AccNo,FromDate,ToDate,NoOfDay,TMoneys,IntRatio,IntAmount,isPosted,MovementId)"
                                strSql = strSql & " Values('" & sAccNo & "','" & sDateFrom & "','" & sTempDate & "'," & nNoOfDay.ToString & "," & nMoney & "," & nInt & "," & nIntAmount & ",0," & oDataset.Tables(0).Rows(i).Item("TrnId").ToString & ")"
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()

                                '//Update ข้อมูลการคำนวนดอกที่ตาราง Movement ยังไม่ Post
                                strSql = "Update TB_TRN_BANK_MOVEMENT set Interest_ratio=0,Interest_amount=isnull(Interest_Amount,0)+" & nIntAmount & " Where TrnId=" & oDataset.Tables(0).Rows(i).Item("TrnId").ToString
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()

                            Next j
                        End If
                    End If

                    'strSql = "Update tb_trn_bank_movement set interest_ratio=" & oDataInterest.Tables(0).Rows(i).Item("interests").ToString
                    'strSql = strSql & " Where TrnId in(Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & oDataInterest.Tables(0).Rows(i).Item("BeginMoney").ToString & " and " & oDataInterest.Tables(0).Rows(i).Item("ToMoney").ToString & ")"
                    'objCmd.CommandText = strSql
                    'objCmd.ExecuteNonQuery()

                    'strSql = "Update tb_trn_bank_movement set Interest_amount= round(a.CarryFwd_amount*(a.Interest_ratio/100)*(b.noofdate*1.0/365),0)"  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
                    'strSql = strSql & " From tb_trn_bank_movement a,V012_BANK_NO_OF_DEPOSIT b"
                    'strSql = strSql & " Where a.TrnId=b.TrnId and " & strWhere & " and a.CarryFwd_amount between " & oDataInterest.Tables(0).Rows(i).Item("BeginMoney").ToString & " and " & oDataInterest.Tables(0).Rows(i).Item("ToMoney").ToString
                    'objCmd.CommandText = strSql
                    'objCmd.ExecuteNonQuery()
                Next i



                strReturn = "0//Save data completed."
                If isTrans Then objTran.Commit() : isTrans = False
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    Public Function PostBankInterest(ByVal sKey As String, ByVal strWhere As String, ByVal sAccType As String, ByVal sUser As String, ByVal DocDate As Date) As String

        '//sTrnType is 0=Recieve, 1=Issue

        Dim strReturn As String = ""
        Dim strSql As String = ""
        Dim nResult As Integer = 0
        Dim isTrans As Boolean = False
        Dim objTran As OleDbTransaction
        Dim objCmd As New OleDbCommand
        Dim objConn As New OleDbConnection
        Dim oDataInterest As New DataSet
        Dim oDataset As New DataSet
        Dim oDatasetLastAmount As New DataSet
        Dim nBeginMoney As Single = 0
        Dim nToMoney As Single = 0
        Dim sAccNo As String = ""
        Dim nMoneys As Single = 0
        Dim sTrnId As String = ""
        Dim sBranch As String = ""
        'Dim isSave As Boolean = False
        'Dim nBeginShare As Integer = 0
        'Dim nBeginValue As Single = 0
        'Dim i As Long = 0
        Dim j As Long = 0

        ''Dim nTotalShare As Integer = 0
        'Dim nTotalValues As Single = 0

        Try
            If sKey.ToUpper <> SecurityKey.ToUpper Then
                strReturn = "100//Invalid security key"
            Else

                objConn.ConnectionString = strConnectionString
                objConn.Open()
                objCmd.Connection = objConn
                'objCmd.CommandText = strSql
                objCmd.CommandTimeout = 0
                'objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                isTrans = False ' True

                strSql = "Select * from v008_BANK_STATEMENT Where " & strWhere & " order by BranchId, AccNo"
                oDataset = getDataSet(strSql)

                If oDataset.Tables.Count > 0 Then
                    For j = 0 To oDataset.Tables(0).Rows.Count - 1

                        If sAccNo <> "" Then
                            If sAccNo <> oDataset.Tables(0).Rows(j).Item("AccNO").ToString Then
                                '//บันทึกข้อมูล
                                Debug.Print(j & ". AccNo=" & sAccNo & " TrnId=" & sTrnId & " Money=" & nMoneys.ToString)
                                objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                                isTrans = True
                                objCmd.Transaction = objTran
                                strReturn = SaveBankTrans(sKey, "IND", sBranch.ToString, sAccNo.ToString, nMoneys, Format(Now, "yyyyMMdd"), DocDate, 0, sUser, "", 0)
                                If strReturn.Substring(0, 1) = "0" Then
                                    strSql = "Update tb_trn_bank_movement set isPosted=1,Interest_ratio=0,Interest_amount=0"
                                    strSql = strSql & " Where accno='" & sAccNo.ToString & "' and TrnId in(" & sTrnId & ")"   'Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & nBeginMoney.ToString & " and " & nToMoney.ToString & ")"
                                    objCmd.CommandText = strSql
                                    objCmd.ExecuteNonQuery()
                                    '// ปรับปรุงวันที่ทำการ
                                    strSql = "Update TB_TRN_BANK_MOVEMENT set LastDate='" & Date2db(DocDate).ToString & "' where  accno='" & sAccNo & "' and (LastDate is Null or LastDate='') and  TrnId in(" & sTrnId & ")" '  Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & nBeginMoney.ToString & " and " & nToMoney.ToString & ")"
                                    objCmd.CommandText = strSql
                                    objCmd.ExecuteNonQuery()

                                    '//บันทึกการ Post ในตารางการคำนวนดอกเบี้ย
                                    strSql = "Update TB_TRN_BANK_INT_HISTORY set IsPosted=1 Where MovementId in(" & sTrnId & ")"
                                    objCmd.CommandText = strSql
                                    objCmd.ExecuteNonQuery()
                                    If isTrans Then objTran.Commit() : isTrans = False
                                End If
                            End If
                        End If

                        If sAccNo <> oDataset.Tables(0).Rows(j).Item("AccNO").ToString Then
                            sAccNo = oDataset.Tables(0).Rows(j).Item("AccNO").ToString
                            nMoneys = Val(oDataset.Tables(0).Rows(j).Item("Interest_amount").ToString)
                            sTrnId = oDataset.Tables(0).Rows(j).Item("TrnId").ToString
                            sBranch = oDataset.Tables(0).Rows(j).Item("BranchId").ToString
                        Else
                            nMoneys = nMoneys + Val(oDataset.Tables(0).Rows(j).Item("Interest_amount").ToString)
                            sTrnId = sTrnId & "," & oDataset.Tables(0).Rows(j).Item("TrnId").ToString
                        End If

                        If j = oDataset.Tables(0).Rows.Count - 1 Then
                            '//บันทึกข้อมูล
                            Debug.Print(j & ". AccNo=" & sAccNo & " TrnId=" & sTrnId & " Money=" & nMoneys.ToString)
                            objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
                            isTrans = True
                            objCmd.Transaction = objTran
                            strReturn = SaveBankTrans(sKey, "IND", sBranch.ToString, sAccNo.ToString, nMoneys, Format(Now, "yyyyMMdd"), DocDate, 0, sUser, "", 0)
                            If strReturn.Substring(0, 1) = "0" Then
                                strSql = "Update tb_trn_bank_movement set isPosted=1,Interest_ratio=0,Interest_amount=0"
                                strSql = strSql & " Where accno='" & sAccNo.ToString & "' and TrnId in(" & sTrnId & ")"   'Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & nBeginMoney.ToString & " and " & nToMoney.ToString & ")"
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()
                                '// ปรับปรุงวันที่ทำการ
                                strSql = "Update TB_TRN_BANK_MOVEMENT set LastDate='" & Date2db(DocDate).ToString & "' where  accno='" & sAccNo & "' and (LastDate is Null or LastDate='') and  TrnId in(" & sTrnId & ")" '  Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & nBeginMoney.ToString & " and " & nToMoney.ToString & ")"
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()

                                '//บันทึกการ Post ในตารางการคำนวนดอกเบี้ย
                                strSql = "Update TB_TRN_BANK_INT_HISTORY set IsPosted=1 Where MovementId in(" & sTrnId & ")"
                                objCmd.CommandText = strSql
                                objCmd.ExecuteNonQuery()
                                If isTrans Then objTran.Commit() : isTrans = False
                            End If
                        End If
                    Next j
                End If

                strReturn = "0//Save data completed."
                'If isTrans Then objTran.Commit() : isTrans = False
            End If

        Catch ex As Exception
            strReturn = "99//" & ex.Message.ToString
            If isTrans Then objTran.Rollback()
        Finally
            objCmd.Dispose()
            objConn.Dispose()
            objTran.Dispose()
        End Try

        Return strReturn
    End Function

    'Public Function CalculateInterest1(ByVal sKey As String, ByVal sAccType As String, ByVal strWhere As String) As String

    '    '//sTrnType is 0=Recieve, 1=Issue

    '    Dim strReturn As String = ""
    '    Dim strSql As String = ""
    '    Dim nResult As Integer = 0
    '    Dim isTrans As Boolean = False
    '    Dim objTran As OleDbTransaction
    '    Dim objCmd As New OleDbCommand
    '    Dim objConn As New OleDbConnection
    '    Dim oDataInterest As New DataSet
    '    Dim oDataset As New DataSet
    '    Dim oDatasetLastAmount As New DataSet
    '    'Dim nBeginShare As Integer = 0
    '    'Dim nBeginValue As Single = 0
    '    Dim i As Long

    '    'Dim nTotalShare As Integer = 0
    '    Dim nTotalValues As Single = 0

    '    Try
    '        If sKey.ToUpper <> SecurityKey.ToUpper Then
    '            strReturn = "100//Invalid security key"
    '        Else

    '            objConn.ConnectionString = strConnectionString
    '            objConn.Open()
    '            objCmd.Connection = objConn
    '            'objCmd.CommandText = strSql
    '            objCmd.CommandTimeout = 0
    '            objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
    '            isTrans = True
    '            objCmd.Transaction = objTran

    '            oDataInterest = getDataSetTableName("SELECT rowid, BeginMoney, ToMoney, Interests FROM  TB_MAS_BANK_INTEREST_RATIO Where DepType='" & sAccType.Trim & "' order by BeginMoney", "TB_TRN_BANK_MOVEMENT")  'Where AccNo='" & AccNO & "'

    '            For i = 0 To oDataInterest.Tables(0).Rows.Count - 1
    '                strSql = "Update tb_trn_bank_movement set interest_ratio=" & oDataInterest.Tables(0).Rows(i).Item("interests").ToString
    '                strSql = strSql & " Where TrnId in(Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & oDataInterest.Tables(0).Rows(i).Item("BeginMoney").ToString & " and " & oDataInterest.Tables(0).Rows(i).Item("ToMoney").ToString & ")"
    '                objCmd.CommandText = strSql
    '                objCmd.ExecuteNonQuery()

    '                strSql = "Update tb_trn_bank_movement set Interest_amount= round(a.CarryFwd_amount*(a.Interest_ratio/100)*(b.noofdate*1.0/365),0)"  '//เศษ <.5 ปัดลง >.5 ปัดขึ้น
    '                strSql = strSql & " From tb_trn_bank_movement a,V012_BANK_NO_OF_DEPOSIT b"
    '                strSql = strSql & " Where a.TrnId=b.TrnId and " & strWhere & " and a.CarryFwd_amount between " & oDataInterest.Tables(0).Rows(i).Item("BeginMoney").ToString & " and " & oDataInterest.Tables(0).Rows(i).Item("ToMoney").ToString
    '                objCmd.CommandText = strSql
    '                objCmd.ExecuteNonQuery()
    '            Next



    '            strReturn = "0//Save data completed."
    '            If isTrans Then objTran.Commit() : isTrans = False
    '        End If

    '    Catch ex As Exception
    '        strReturn = "99//" & ex.Message.ToString
    '        If isTrans Then objTran.Rollback()
    '    Finally
    '        objCmd.Dispose()
    '        objConn.Dispose()
    '        objTran.Dispose()
    '    End Try

    '    Return strReturn
    'End Function

    'Public Function PostBankInterest1(ByVal sKey As String, ByVal strWhere As String, ByVal sAccType As String, ByVal sUser As String, ByVal DocDate As Date) As String

    '    '//sTrnType is 0=Recieve, 1=Issue

    '    Dim strReturn As String = ""
    '    Dim strSql As String = ""
    '    Dim nResult As Integer = 0
    '    Dim isTrans As Boolean = False
    '    Dim objTran As OleDbTransaction
    '    Dim objCmd As New OleDbCommand
    '    Dim objConn As New OleDbConnection
    '    Dim oDataInterest As New DataSet
    '    Dim oDataset As New DataSet
    '    Dim oDatasetLastAmount As New DataSet
    '    Dim nBeginMoney As Single = 0
    '    Dim nToMoney As Single = 0
    '    'Dim nBeginShare As Integer = 0
    '    'Dim nBeginValue As Single = 0
    '    Dim i As Long
    '    Dim j As Long

    '    'Dim nTotalShare As Integer = 0
    '    Dim nTotalValues As Single = 0

    '    Try
    '        If sKey.ToUpper <> SecurityKey.ToUpper Then
    '            strReturn = "100//Invalid security key"
    '        Else

    '            objConn.ConnectionString = strConnectionString
    '            objConn.Open()
    '            objCmd.Connection = objConn
    '            'objCmd.CommandText = strSql
    '            objCmd.CommandTimeout = 0
    '            'objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
    '            isTrans = False ' True
    '            'objCmd.Transaction = objTran

    '            oDataInterest = getDataSetTableName("SELECT rowid, BeginMoney, ToMoney, Interests FROM  TB_MAS_BANK_INTEREST_RATIO Where DepType='" & sAccType.Trim & "' order by BeginMoney", "TB_TRN_BANK_MOVEMENT")  'Where AccNo='" & AccNO & "'

    '            For i = 0 To oDataInterest.Tables(0).Rows.Count - 1
    '                If nBeginMoney = 0 Then nBeginMoney = oDataInterest.Tables(0).Rows(i).Item("BeginMoney")
    '                nToMoney = oDataInterest.Tables(0).Rows(i).Item("ToMoney")
    '            Next i

    '            '//not LastDate is Null and LastDate<>'' and
    '            strSql = " SELECT     BranchId, AccNo, SUM(Interest_amount) AS Interest_amount"
    '            strSql = strSql & " FROM TB_TRN_BANK_MOVEMENT"
    '            strSql = strSql & " Where interest_amount>0 and isnull(isposted,0)=0 and   TrnId in(Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & nBeginMoney.ToString & " and " & nToMoney.ToString & ")"
    '            strSql = strSql & " GROUP BY BranchId, AccNo"
    '            oDataset = getDataSet(strSql)

    '            If oDataset.Tables.Count > 0 Then
    '                For j = 0 To oDataset.Tables(0).Rows.Count - 1
    '                    objTran = objConn.BeginTransaction() 'IsolationLevel.ReadCommitted)
    '                    isTrans = True
    '                    objCmd.Transaction = objTran
    '                    strReturn = SaveBankTrans(sKey, "ด/บ", oDataset.Tables(0).Rows(j).Item("BranchId"), oDataset.Tables(0).Rows(j).Item("AccNo"), oDataset.Tables(0).Rows(j).Item("Interest_amount"), Format(Now, "yyyyMMdd"), DocDate, 0, sUser, "", 0)
    '                    If strReturn.Substring(0, 1) = "0" Then
    '                        strSql = "Update tb_trn_bank_movement set isPosted=1,Interest_amount=0"
    '                        strSql = strSql & " Where accno='" & oDataset.Tables(0).Rows(j).Item("AccNo") & "' and TrnId in(Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & nBeginMoney.ToString & " and " & nToMoney.ToString & ")"
    '                        objCmd.CommandText = strSql
    '                        objCmd.ExecuteNonQuery()
    '                        '// ปรับปรุงวันที่ทำการ
    '                        strSql = "Update TB_TRN_BANK_MOVEMENT set LastDate='" & Date2db(DocDate).ToString & "' where  accno='" & oDataset.Tables(0).Rows(j).Item("AccNo") & "' and (LastDate is Null or LastDate='') and  TrnId in(Select TrnId From  V012_BANK_NO_OF_DEPOSIT b  Where " & strWhere & " and CarryFwd_amount between " & nBeginMoney.ToString & " and " & nToMoney.ToString & ")"
    '                        objCmd.CommandText = strSql
    '                        objCmd.ExecuteNonQuery()
    '                        'Call ExecCommand(strSql)
    '                        If isTrans Then objTran.Commit() : isTrans = False
    '                    End If
    '                Next j
    '            End If
    '            'Next

    '            strReturn = "0//Save data completed."
    '            If isTrans Then objTran.Commit() : isTrans = False
    '        End If

    '    Catch ex As Exception
    '        strReturn = "99//" & ex.Message.ToString
    '        If isTrans Then objTran.Rollback()
    '    Finally
    '        objCmd.Dispose()
    '        objConn.Dispose()
    '        objTran.Dispose()
    '    End Try

    '    Return strReturn
    'End Function

    Public Function db2Date(ByVal sDate As Object) As Date
        Dim nDif As Integer = 0
        If Year(Now) <> Today.Year Then nDif = 543
        If IsDBNull(sDate) Then
            Return Nothing
        Else
            Return DateSerial(CInt(sDate.ToString.Substring(0, 4)) + nDif, CInt(sDate.ToString.Substring(5, 2)), CInt(sDate.ToString.Substring(8, 2)))
        End If
    End Function

    Public Function Date2db(ByVal sDate As Date) As String
        'Dim nDif As Integer = 0
        'If Year(Now) <> Today.Year Then nDif = 543
        If IsDate(sDate) = False Then
            Return ""
        Else
            Return sDate.Year & Format(sDate.Month, "-0#") & Format(sDate.Day, "-0#")
        End If
    End Function

    Public Sub New()

        ' strConnectionString = "Provider=sqloledb;Data Source=localhost;Initial Catalog=POS;User Id=sa;Password=nopassword;"

        ' strConnectionString = "Driver={SQL Server Native Client 11.0};Server=localhost;Database=POS;Uid=sa;Pwd=nopassword;"
        strConnectionString = My.Settings.StringConnection

        'strConnectionString = clsSett.GetSetting("constring")
        'MsgBox(strConnectionString)
    End Sub
End Class
