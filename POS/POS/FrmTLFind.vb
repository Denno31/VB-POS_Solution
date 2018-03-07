


Public Class FrmTLFind

    Dim oDataset As New DataSet()
    Dim oDatatable As DataTable
    Dim strColumnDesc As String
    Dim strColumnWidth As String
    Dim strTableName As String
    Dim isCancel As Boolean = True
    Dim oDataRow As DataRow
    ' Dim clsLang As New clsLangMsg
    Dim sFindColumnIndex As Integer

    Public storedName As String


    Public Overloads Sub ShowDialog(ByVal mDataset As DataSet, ByVal mcolumnDesc As String, ByVal mColumnWidth As String, ByVal mTableName As String, Optional ByVal parent As IWin32Window = Nothing)


        Dim i As Integer = 0
        Dim sArray() As String
        Dim nFormWidth As Long = 0
        Me.Cursor = Cursors.WaitCursor
        Try

            oDataset = mDataset
            strColumnDesc = mcolumnDesc
            strColumnWidth = mColumnWidth
            strTableName = mTableName

            With DataGridView1
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .EditMode = DataGridViewEditMode.EditProgrammatically
                .DataSource = oDataset.Tables(0)
                'oConFig.StdGridFormat(DataGridView1)
                Call MasterGridFormat(DataGridView1)
                lblTotalData.Text = oDataset.Tables(0).Rows.Count

                '// กำหนดหัว Column
                sArray = strColumnDesc.Split(",")
                For i = sArray.GetLowerBound(0) To sArray.GetUpperBound(0)
                    .Columns(i).HeaderText = sArray(i)
                Next

                '// กำหนดหัว Column width
                sArray = strColumnWidth.Split(",")
                For i = sArray.GetLowerBound(0) To sArray.GetUpperBound(0)
                    If Val(sArray(i)) = 0 Then
                        .Columns(i).Visible = False
                    Else
                        .Columns(i).Width = Val(sArray(i))
                    End If
                    nFormWidth = nFormWidth + Val(sArray(i))

                Next

                'Me.Width = nFormWidth + 30

                '//เตรียมข้อมูลสำหรับค้นหา
                sFindColumnIndex = 1 ' 0
                lblFindFeild.Text = DataGridView1.Columns(sFindColumnIndex).HeaderText


            End With
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Call UpdateRowStatus()
        End Try


        ' Show the dialog.
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.ShowDialog(parent)
    End Sub

    Public Overloads Sub ShowDialog(ByVal mDataTable As DataTable, ByVal mcolumnDesc As String, ByVal mColumnWidth As String, ByVal mTableName As String, Optional ByVal parent As IWin32Window = Nothing)


        Dim i As Integer = 0
        Dim sArray() As String
        Dim nFormWidth As Long = 0
        Me.Cursor = Cursors.WaitCursor
        Try
            oDatatable = mDataTable
            '  oDataset = mDataset
            strColumnDesc = mcolumnDesc
            strColumnWidth = mColumnWidth
            strTableName = mTableName

            With DataGridView1
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .EditMode = DataGridViewEditMode.EditProgrammatically
                .DataSource = oDatatable
                'oConFig.StdGridFormat(DataGridView1)
                Call MasterGridFormat(DataGridView1)
                lblTotalData.Text = oDatatable.Rows.Count

                '// กำหนดหัว Column
                sArray = strColumnDesc.Split(",")
                For i = sArray.GetLowerBound(0) To sArray.GetUpperBound(0)
                    .Columns(i).HeaderText = sArray(i)
                Next

                '// กำหนดหัว Column width
                sArray = strColumnWidth.Split(",")
                For i = sArray.GetLowerBound(0) To sArray.GetUpperBound(0)
                    If Val(sArray(i)) = 0 Then
                        .Columns(i).Visible = False
                    Else
                        .Columns(i).Width = Val(sArray(i))
                    End If
                    nFormWidth = nFormWidth + Val(sArray(i))

                Next

                'Me.Width = nFormWidth + 30

                '//เตรียมข้อมูลสำหรับค้นหา
                sFindColumnIndex = 1 ' 0
                lblFindFeild.Text = DataGridView1.Columns(sFindColumnIndex).HeaderText


            End With
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Call UpdateRowStatus()
        End Try


        ' Show the dialog.
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.ShowDialog(parent)
    End Sub
    Public Function getDataRow() As DataRow
        Return oDataRow
    End Function

    Private Sub UpdateRowStatus()
        lblTotalData.Text = DataGridView1.Rows.Count
    End Sub



    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        DataGridView1.DataSource = oDataset.Tables(0)
        Call UpdateRowStatus()
    End Sub

    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click




    End Sub

    Private Sub txtFind_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmdFind_Click(sender, e)
            DataGridView1.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        If e.RowIndex = -1 Then Exit Sub
        'oDataRow = oDataset.Tables(0).Rows(e.RowIndex)
        'DataGridView1.SelectedRows(0)
        'Call setDataRow(e.RowIndex)
        '        MessageBox.Show(DataGridView1.SelectedRows(0).Cells(1).Value.ToString)
        Call setDataRow(DataGridView1.SelectedRows(0))

        ''Dim i As Integer = 0
        'For i = 0 To DataGridView1.SelectedRows(0).Cells.Count - 1
        '    MessageBox.Show(DataGridView1.SelectedRows(0).Cells(i).Value.ToString)
        '    'MessageBox.Show(oRow.Cells(i).Value.ToString)
        '    oDataRow.Item(i) = DataGridView1.SelectedRows(0).Cells(i).Value
        'Next

        Me.Close()
    End Sub

    Private Sub setDataRow(ByVal oRow As DataGridViewRow) '  ByVal RowId As Long)
        Try
            'oDataRow = DataGridView1.DataSource.Rows(0)
            oDataRow = DataGridView1.DataSource.NewRow  '// Set structure

            'MsgBox(oRow.Index)
            'Exit Sub

            'MessageBox.Show(DataGridView1.SelectedRows(0).Cells(1).Value.ToString)

            ' oDataRow.ItemArray = oRow.itemarray

            Dim i As Integer = 0
            For i = 0 To oRow.Cells.Count - 1
                'MessageBox.Show(DataGridView1.SelectedRows(0).Cells(i).Value.ToString)
                'MessageBox.Show(oRow.Cells(i).Value.ToString)
                oDataRow.Item(i) = oRow.Cells(i).Value
            Next
            'oDataRow = DataGridView1.DataSource.Rows(RowId)  '  CType(DataGridView1.Rows(RowId), DataRow)
            'oDataRow = CType(DataGridView1.SelectedRows(0), DataRow)


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub



   

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Enter Then

            Call setDataRow(DataGridView1.SelectedRows(0))

            ''Dim i As Integer = 0
            'For i = 0 To DataGridView1.SelectedRows(0).Cells.Count - 1
            '    MessageBox.Show(DataGridView1.SelectedRows(0).Cells(i).Value.ToString)
            '    'MessageBox.Show(oRow.Cells(i).Value.ToString)
            '    oDataRow.Item(i) = DataGridView1.SelectedRows(0).Cells(i).Value
            'Next

            Me.Close()

        End If

    End Sub
End Class