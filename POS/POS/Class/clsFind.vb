Public Class clsFind
    Dim mDataSet As New DataSet
    Dim mDataTable As DataTable
    Dim mDatarow As DataRow
    Dim strSql As String = ""
    Dim strColumnDesc As String = ""
    Dim strColumnWidth As String = ""
    Dim strTableName As String = ""
    Dim mCriteriaStockOnHand As New Model.Criteria.Sale.M_Stock_OnHand
    Dim mCriteriaDoc As New Model.Criteria.Sale.M_SaleSlip_Head
    Dim mClsService As New clsService
    Dim mClsLang As New clsLangMsg
    '// Needed parameter

    Public Sub setSQL(ByVal pSql As String)
        strSql = pSql
    End Sub

    Public Sub setCriteriaStockOnHand(criteria As Model.Criteria.Sale.M_Stock_OnHand)
        mCriteriaStockOnHand = criteria
    End Sub

    Public Sub setCriteriaDoc(criteria As Model.Criteria.Sale.M_SaleSlip_Head)
        mCriteriaDoc = criteria
    End Sub

    Public Sub setColumnWidth(ByVal pColumnWidth As String)
        strColumnWidth = pColumnWidth
    End Sub

    Public Sub setColumnDesc(ByVal pColumnDesc As String)
        strColumnDesc = pColumnDesc
    End Sub

    Public Sub setTableName(ByVal pTablename As String)
        strTableName = pTablename
    End Sub

    '// End needed


    Private Function OpenData() As Boolean
        'Dim oDA As New OleDb.OleDbDataAdapter
        'Dim sColumnDesc As String()
        'Dim nRows As Integer
        Dim bReturn As Boolean = False

        Try
            'oDA = New OleDb.OleDbDataAdapter(strSql, sConstring)
            'nRows = oDA.Fill(mDataSet, "Table1")
            'sColumnDesc = strColumnDesc.Split("//")
            mDataSet = mClsService.getDataSet(strSql)
            If mDataSet.Tables.Count = 0 Then
                bReturn = False
            ElseIf mDataSet.Tables(0).Rows.Count = 0 Then
                bReturn = False
            Else
                bReturn = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mClsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            bReturn = False
        Finally
            'oDA.Dispose()
        End Try

        Return bReturn
    End Function

    Public Function OpenFind(Optional ByVal sLocation As String = "") As DataRow
        '//data must "x,y"

        Dim x As DataRow = Nothing
        Dim frm As New frmTLFind
        Dim frmLoc As Point
        Try
            If OpenData() Then
                With frm
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
                    .StartPosition = FormStartPosition.Manual
                    .Width = 1200
                    .Height = 1600
                    If sLocation = "" Then
                        frmLoc.X = System.Windows.Forms.Cursor.Position.X
                        frmLoc.Y = System.Windows.Forms.Cursor.Position.Y
                    Else
                        frmLoc.X = Val(sLocation.Split(",")(0))
                        frmLoc.Y = Val(sLocation.Split(",")(1))
                    End If
                    '// แก้ปัญหากินขอบหน้าจอบนและล่าง
                    If frmLoc.Y + .Height > Screen.PrimaryScreen.WorkingArea.Bottom Then
                        frmLoc.Y = frmLoc.Y - ((frmLoc.Y + .Height) - Screen.PrimaryScreen.WorkingArea.Bottom)
                    End If
                    If frmLoc.X + .Width > Screen.PrimaryScreen.WorkingArea.Width Then
                        frmLoc.X = frmLoc.X - ((frmLoc.X + .Width) - Screen.PrimaryScreen.WorkingArea.Width)
                    End If

                    .Location = frmLoc
                    .ShowDialog(mDataSet, strColumnDesc, strColumnWidth, strTableName)
                    mDatarow = .getDataRow
                    'x = .getDataRow
                    'If x Is Nothing = False Then
                    '    MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If

                End With
            Else
                MessageBox.Show(mClsLang.msg_nodata, mClsLang.msg_warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mClsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frm.Dispose()
            'x = Nothing
        End Try
        Return x

    End Function

    Public Function OpenFindStockOnHand(Optional ByVal sLocation As String = "") As DataRow
        '//data must "x,y"

        Dim x As DataRow = Nothing
        Dim frm As New FrmTLFind
        Dim frmLoc As Point
        Try
            If OpenDataStockOnHand() Then
                With frm
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
                    .StartPosition = FormStartPosition.Manual
                    If sLocation = "" Then
                        frmLoc.X = System.Windows.Forms.Cursor.Position.X
                        frmLoc.Y = System.Windows.Forms.Cursor.Position.Y
                    Else
                        frmLoc.X = Val(sLocation.Split(",")(0))
                        frmLoc.Y = Val(sLocation.Split(",")(1))
                    End If
                    '// แก้ปัญหากินขอบหน้าจอบนและล่าง
                    If frmLoc.Y + .Height > Screen.PrimaryScreen.WorkingArea.Bottom Then
                        frmLoc.Y = frmLoc.Y - ((frmLoc.Y + .Height) - Screen.PrimaryScreen.WorkingArea.Bottom)
                    End If
                    If frmLoc.X + .Width > Screen.PrimaryScreen.WorkingArea.Width Then
                        frmLoc.X = frmLoc.X - ((frmLoc.X + .Width) - Screen.PrimaryScreen.WorkingArea.Width)
                    End If

                    .Location = frmLoc
                    .ShowDialog(mDataTable, strColumnDesc, strColumnWidth, strTableName)
                    mDatarow = .getDataRow


                End With
            Else
                '    MessageBox.Show(mClsLang.msg_nodata, mClsLang.msg_warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            '  MessageBox.Show(ex.Message, mClsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frm.Dispose()
            'x = Nothing
        End Try
        Return x

    End Function

    Public Function OpenFindDoc(Optional ByVal sLocation As String = "") As DataRow
        '//data must "x,y"

        Dim x As DataRow = Nothing
        Dim frm As New FrmTLFind
        Dim frmLoc As Point
        Try
            If OpenDataDoc() Then
                With frm
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
                    .StartPosition = FormStartPosition.Manual
                    If sLocation = "" Then
                        frmLoc.X = System.Windows.Forms.Cursor.Position.X
                        frmLoc.Y = System.Windows.Forms.Cursor.Position.Y
                    Else
                        frmLoc.X = Val(sLocation.Split(",")(0))
                        frmLoc.Y = Val(sLocation.Split(",")(1))
                    End If
                    '// แก้ปัญหากินขอบหน้าจอบนและล่าง
                    If frmLoc.Y + .Height > Screen.PrimaryScreen.WorkingArea.Bottom Then
                        frmLoc.Y = frmLoc.Y - ((frmLoc.Y + .Height) - Screen.PrimaryScreen.WorkingArea.Bottom)
                    End If
                    If frmLoc.X + .Width > Screen.PrimaryScreen.WorkingArea.Width Then
                        frmLoc.X = frmLoc.X - ((frmLoc.X + .Width) - Screen.PrimaryScreen.WorkingArea.Width)
                    End If

                    .Location = frmLoc
                    .ShowDialog(mDataTable, strColumnDesc, strColumnWidth, strTableName)
                    mDatarow = .getDataRow


                End With
            Else
                '    MessageBox.Show(mClsLang.msg_nodata, mClsLang.msg_warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            '  MessageBox.Show(ex.Message, mClsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frm.Dispose()
            'x = Nothing
        End Try
        Return x

    End Function

    Public Function getDatarow() As DataRow
        Return mDatarow
        'mDataSet.Tables(0).Select()
    End Function


    Private Function OpenDataStockOnHand() As Boolean

        Dim bReturn As Boolean = False

        Try
            Dim _Bll As New BLL.Sale
            mDataTable = _Bll.getStockOnHand(mCriteriaStockOnHand)
            If mDataTable.Rows.Count = 0 Then
                bReturn = False

            Else
                bReturn = True
            End If
        Catch ex As Exception
            '    MessageBox.Show(ex.Message, mClsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            bReturn = False
        Finally

        End Try

        Return bReturn
    End Function


    'Private Function OpenDataProduct() As Boolean

    '    Dim bReturn As Boolean = False

    '    Try
    '        Dim _Bll As New BLL.Sale
    '        mDataTable = _Bll.getStockOnHand(mCriteriaStockOnHand)
    '        If mDataTable.Rows.Count = 0 Then
    '            bReturn = False

    '        Else
    '            bReturn = True
    '        End If
    '    Catch ex As Exception
    '        '    MessageBox.Show(ex.Message, mClsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        bReturn = False
    '    Finally

    '    End Try

    '    Return bReturn
    'End Function


    Private Function OpenDataDoc() As Boolean

        Dim bReturn As Boolean = False

        Try
            Dim _Bll As New BLL.Sale
            mDataTable = _Bll.getSaleSlip_Head_Doc(mCriteriaDoc)
            If mDataTable.Rows.Count = 0 Then
                bReturn = False

            Else
                bReturn = True
            End If
        Catch ex As Exception
            '    MessageBox.Show(ex.Message, mClsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            bReturn = False
        Finally

        End Try

        Return bReturn
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

