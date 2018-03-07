
Imports System.Globalization

Public Class FrmItemReceive

    Dim oDataset As DataSet
    Dim oDataOnhand As DataSet
    Dim clsLang As New clsLangMsg
    'Dim oService As New clsService

    Dim m_StockOnHand As New Model.Sale.M_Stock_OnHand
    Dim stock_criteria As New Model.Criteria.Sale.M_Stock_OnHand

    Public bFormat As String

    Private Sub cmdItem_Click(sender As Object, e As EventArgs) Handles cmdItem.Click

   Dim x As New clsFind
        Dim oDataRow As DataRow = Nothing
        With x

            .setTableName(clsLang.msg_iss_type)

            stock_criteria.PROD_CODE = txtItemName.Text
            '.setCriteriaStockOnHand(stock_criteria)
            .setSQL("SELECT CODE,name,price_1 FROM MPRODUCT Where CODE like '" & txtItemName.Text & "%'")
            .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name & ",ราคารวม")
            .setColumnWidth("300,600,100")
            .OpenFind()
            '  .OpenFindStockOnHand()
            oDataRow = .getDatarow
            If oDataRow Is Nothing = False Then

                txtItemNo.Text = oDataRow(0).ToString
                txtItemNo.Tag = ""
                txtItemName.Text = oDataRow(0).ToString & " : " & oDataRow(1).ToString
                '   txtStockOnHand.Text = "1"
                txtUnitPrice.Text = oDataRow(2).ToString
                '   Call CalTotalPrice()
                '   Call cmdSave_Click(sender, e)
             
            End If
        End With

        oDataRow = Nothing
        x = Nothing
    End Sub


    Private Class Item
        Public Name As String
        Public Value As String
        Public Sub New(name__1 As String, value__2 As String)
            Name = name__1
            Value = value__2
        End Sub
    End Class


    Private Sub init_BookName()

     

        Dim _Bll As New BLL.PO
        Dim dt As DataTable

        dt = _Bll.getBook

        cb_book.AutoCompleteMode = AutoCompleteMode.Suggest
        cb_book.DataSource = dt
        cb_book.DisplayMember = "BOOK_DESC"
        cb_book.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub


    Private Sub RefreshOnhand()
        Dim strSQL As String = ""
        Try
            strSQL = "SELECT vBarcode.FullName, Sum(vBarcode.OnhandQty) AS OnhandQty, TB_ITEM_MASTER.ItemUom"
            strSQL += " FROM (vBarcode INNER JOIN TB_ITEM_MASTER ON vBarcode.ItemNo = TB_ITEM_MASTER.ItemNO) LEFT JOIN TB_ITEM_TYPE ON TB_ITEM_MASTER.ItemType = TB_ITEM_TYPE.TypeId"
            strSQL += " GROUP BY vBarcode.ItemNo, vBarcode.FullName, TB_ITEM_MASTER.ItemUom"
            strSQL += " HAVING (((vBarcode.ItemNo)='" & txtItemNo.Text.Trim & "') AND ((Sum(vBarcode.OnhandQty))>0))"

            grdOnhand.Columns.Clear()
            oDataOnhand = oService.getDataSet(strSQL)
            Dim i As Integer
            With grdOnhand
                Dim xFont As New Font(grdMain.Font.Name.ToString, 8, FontStyle.Regular)
                .DataSource = oDataOnhand.Tables(0)
                .Columns(0).HeaderText = "ผู้ส่ง"
                .Columns(1).HeaderText = "จำนวน"
                .Columns(2).HeaderText = "หน่วย"

                '   Call AddBarcodeButtonColumn()
                '  Call AddEditButtonColumn()

                Call MasterGridFormat(grdOnhand)


                For i = 0 To .Columns.Count - 1
                    .Columns(i).Width = clsSetting.GetSetting(Me.Name & grdOnhand.Name & CType(i, String), .Columns(i).Width)
                    .Columns(i).DefaultCellStyle.Font = xFont
                Next
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .EditMode = DataGridViewEditMode.EditProgrammatically
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDocQty_TextChanged(sender As Object, e As EventArgs) Handles txtDocQty.TextChanged
        Call CalTotalPrice()
    End Sub

    Private Sub CalTotalPrice()
        txtTotal.Text = Val(txtDocQty.Text) * Val(txtUnitPrice.Text)
    End Sub

    Private Sub txtItemNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemNo.KeyDown


        If e.KeyCode = Keys.Enter Then



            If e.KeyCode = Keys.Enter Then
                Call getItemByBarcode()
                '     If txtItemNo.Text.Trim <> "" Then Call cmdSave_Click(sender, e)
                txtItemNo.SelectAll()
            End If




            '   initStockOnHand()

        End If
    End Sub

    Private Sub getItemByBarcode()

        Dim oDs As New DataSet
        Dim oDataRow As DataRow


        Dim _BLL As New BLL.Sale

        Dim dt As DataTable
        stock_criteria.PROD_CODE = txtItemNo.Text

        dt = _BLL.getStockOnHand(stock_criteria)
        If dt.Rows.Count > 0 Then
            oDataRow = dt.Rows(0)




            txtItemNo.Text = oDataRow(0).ToString
            txtItemNo.Tag = ""
            txtItemName.Text = oDataRow(0).ToString
            txtUnitPrice.Text = oDataRow("COST").ToString
            txtItemNo.SelectAll()
        Else

            MessageBox.Show("บาร์โค้ดไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemNo.Clear()
            txtItemName.Clear()
            ' txtStockOnHand.Clear()
            txtUnitPrice.Clear()
            txtItemNo.Focus()
        End If
    End Sub

    Private Sub lblAddItem_Click(sender As Object, e As EventArgs) Handles lblAddItem.Click
        If Not FrmItemMaster Is Nothing Then FrmItemMaster.Close()
        FrmItemMaster.ShowDialog()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim _clsSave As New clsSaveData
        _clsSave.Insert("", "")




        If MessageBox.Show(clsLang.msg_confirm_save, clsLang.msg_confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If saveData() Then
                Call RefreshData()
                Dim sDoc As String = txtDocNo.Text
                Call ClearText()
                txtDocNo.Text = sDoc
                txtDocNo.Enabled = False
            End If
        End If



    End Sub
    Private Sub ClearText()
        '  txtDocNo.Clear()
        txtRemark.Clear()
        txtItemName.Clear()
        txtItemNo.Clear()
        '    txtCuntry.Clear()
        '   txtCuntryNane.Clear()
        txtDocQty.Clear()
        txtUnitPrice.Clear()
        txtSalePrice.Clear()
        txtTotal.Clear()


        txtDocNo.Enabled = True
        txtDocNo.Focus()
        'Call getLastDoc()
    End Sub


    Private Sub RefreshData()
        'Me.daMain.Fill(Me.DsMainData.tb_mas_site)
        grdMain.Columns.Clear()

        '    oDataset = oService.getDataSetTableName("SELECT ItemNo, ItemName,FullName,RecQty,UnitPrice,TotalPrice,SalePrice,VendorCode,Remark,FullName FROM vReceive Where DocNo='" & txtDocNo.Text & "'", "vReceive")

        oDataset = oService.getDataSet("select m.Docdate,t.DocNo,t.ItemNo,t.RecQty,t.UnitPrice,t.TotalPrice,t.VendorCode,t.VendorName,m.remark from TB_REC_HD as m,TB_REC_DT as t where m.DocNo = t.DocNo and m.DocNo='" & txtDocNo.Text & "'")

        Dim i As Integer
        With grdMain
            .DataSource = oDataset.Tables(0)
            .Columns(0).HeaderText = "วันที่"
            .Columns(1).HeaderText = "สมุดรายการเลขที่"
            .Columns("ItemNo").HeaderText = "รหัสสินค้า"
            .Columns("RecQty").HeaderText = "จำนวน"
            .Columns("UnitPrice").HeaderText = "ราคาซื้อ"
            .Columns("TotalPrice").HeaderText = "ราคาซื้อรวม"
            '        .Columns("salePrice").HeaderText = "ราคาขาย"
            .Columns("vendorCode").HeaderText = "รหัสผู้ส่ง"
            .Columns("vendorName").HeaderText = "ผู้ส่ง"
            .Columns("Remark").HeaderText = "หมายเหตุ"
            
            '.Columns(9).HeaderText = "ContryName"
            '.Columns(9).Visible = False



            .Columns(0).Width = 150
            .Columns(1).Width = 150
            .Columns("ItemNo").Width = 300
            .Columns("RecQty").Width = 80
            .Columns("UnitPrice").Width = 100
            .Columns("TotalPrice").Width = 100
            '        .Columns("salePrice").HeaderText = "ราคาขาย"
            .Columns("vendorCode").Width = 100
            .Columns("vendorName").Width = 200
            .Columns("Remark").Width = 200

            Call AddBarcodeButtonColumn()
            Call AddEditButtonColumn()

            Call MasterGridFormat(grdMain)

            ''For i = 0 To .Columns.Count - 1
            '.Columns(i).Width = clsSetting.GetSetting(Me.Name & grdMain.Name & CType(i, String), .Columns(i).Width)
            'Next
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With
        lblTotalData.Text = oDataset.Tables(0).Rows.Count
        '  Me.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub AddEditButtonColumn()

        ' Initialize the button column.
        Dim buttonColumn As New DataGridViewButtonColumn

        With buttonColumn
            .HeaderText = "แก้ไข"
            .Name = "edit"
            .Text = "แก้ไข"
            .FlatStyle = FlatStyle.Flat
            .Visible = True
            .DefaultCellStyle.ForeColor = Color.Orange
            ' Use the Text property for the button text for all cells rather
            ' than using each cell's value as the text for its own button.
            .UseColumnTextForButtonValue = True
        End With

        ' Add the button column to the control.
        grdMain.Columns.Insert(0, buttonColumn)

    End Sub


    Private Sub AddBarcodeButtonColumn()

        ' Initialize the button column.
        Dim buttonColumn As New DataGridViewButtonColumn

        With buttonColumn
            .HeaderText = "บาร์โค้ด"
            .Name = "barcode"
            .Text = "พิมพ์บาร์โค้ด"

            .FlatStyle = FlatStyle.Flat
            .Visible = True
            .DefaultCellStyle.ForeColor = Color.Red
            ' Use the Text property for the button text for all cells rather
            ' than using each cell's value as the text for its own button.
            .UseColumnTextForButtonValue = True
        End With

        ' Add the button column to the control.
        grdMain.Columns.Add(buttonColumn) ' Insert(9, buttonColumn)

    End Sub

    Function saveData() As Boolean



        Dim strSql As String = ""
        Dim bReturn As Boolean = False
        Dim oDataset As DataSet = Nothing
        Dim strQty As String = "0"
        Dim strItem As String = txtItemNo.Tag
        Try



         


            If txtDocNo.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If txtItemNo.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If txtIV.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If txtCuntry.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If IsNumeric(txtDocQty.Text.Trim) = False Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If IsNumeric(txtUnitPrice.Text.Trim) = False Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            '   If IsNumeric(txtSalePrice.Text.Trim) = False Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If Val(txtDocQty.Text) = 0 Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            '   If Val(txtSalePrice.Text) = 0 Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If txtDocNo.Enabled = False Then '// Update

                If strItem = "" Then strItem = txtItemNo.Text
                txtItemNo.Tag = ""

                strSql = "select RecQty from  tb_rec_dt  Where DocNo='" & txtDocNo.Text & "'"
                strSql += " and ItemNO ='" & strItem & "'"
                oDataset = oService.getDataSet(strSql)

                If oDataset.Tables.Count > 0 Then
                    If oDataset.Tables(0).Rows.Count > 0 Then
                        strQty = oDataset.Tables(0).Rows(0)("RecQty").ToString
                    End If
                End If

                strSql = "Update TB_REC_HD set DocDate='" & txtDocDate.Value.Year & txtDocDate.Value.ToString("-MM-dd") & "', Remark='" & txtRemark.Text.Trim & "',ModifyDate=GETDATE()"
                strSql = strSql & " Where DocNo='" & txtDocNo.Text.Trim & "'"

                If oService.ExecCommand(strSql) Then
                    'MessageBox.Show(clsLang.msg_savesuccess, clsLang.msg_infomation, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bReturn = True
                Else
                    'MessageBox.Show(clsLang.msg_cannotsave, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                '//insert
                Dim DocNo As String
                DocNo = getLastDoc()
                txtDocNo.Text = DocNo
                oDataset = oService.getDataSet("Select 1 from TB_REC_HD where DocNo='" & txtDocNo.Text.Trim & "'")
                If oDataset.Tables(0).Rows.Count = 0 Then '// ตรวจสอบการซ้ำ
                    strSql = "Insert into TB_REC_HD (DocNo,docDate,Remark,ModifyBy,ModifyDate,Invoid)"
                    strSql = strSql & " values('" & txtDocNo.Text.Trim & "','" & txtDocDate.Value.Year & txtDocDate.Value.ToString("-MM-dd") & "','" & txtRemark.Text & "','" & oConFig.User & "',"
                    strSql = strSql & "GETDATE(),'" & txtIV.Text & "')"
                    If oService.ExecCommand(strSql) Then
                        'MessageBox.Show(clsLang.msg_savesuccess, clsLang.msg_infomation, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bReturn = True
                    Else
                        'MessageBox.Show(clsLang.msg_cannotsave, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    'MessageBox.Show(clsLang.msg_duplicate, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            If bReturn Then '// ถ้าบันทึกข้อมูลส่วนหัวสำเร็จ


                strSql = "Update tb_rec_dt set"
                strSql += " ItemNo='" & txtItemNo.Text & "'"
                strSql += " ,Modifyby='" & oConFig.User & "'"
                strSql += " ,ModifyDate=GETDATE()"
                strSql += " ,VendorCode='" & txtCuntry.Text & "'"
                strSql += " ,VendorName='" & txtCuntryNane.Text & "'"
                strSql += " ,RecQty=" & txtDocQty.Text ' & "'"
                strSql += " ,UnitPrice=" & txtUnitPrice.Text '& "'"
                strSql += " ,TotalPrice=" & txtTotal.Text '& "'"
                '   strSql += " ,SalePrice=" & txtSalePrice.Text '& "'"
                strSql += " Where DocNo='" & txtDocNo.Text & "'"
                strSql += " and ItemNO ='" & strItem & "'"

                If oService.ExecCommandRowRet(strSql) = 0 Then  '//  Cannot Update
                    strSql = "Insert into tb_rec_dt(DocNo,ItemNo,VendorCode,VendorName,RecQty,UnitPRice,TotalPrice,BalanceQty,ModifyBy,ModifyDate)"
                    strSql += " values("
                    strSql += "'" & txtDocNo.Text & "'"
                    strSql += ",'" & txtItemNo.Text & "'"
                    strSql += ",'" & txtCuntry.Text & "'"
                    strSql += ",'" & txtCuntryNane.Text & "'"
                    strSql += "," & txtDocQty.Text
                    strSql += "," & txtUnitPrice.Text
                    strSql += "," & txtTotal.Text
                    '    strSql += "," & txtSalePrice.Text
                    strSql += "," & txtDocQty.Text
                    strSql += ",'" & oConFig.User & "'"
                    strSql += ",GETDATE()"
                    strSql += ")"
                    If oService.ExecCommandRowRet(strSql) = 0 Then
                        bReturn = False
                    Else
                        bReturn = True
                    End If
                Else
                    bReturn = True
                End If
            End If

            If bReturn Then

                strSql = "Update  MPRODUCT set Last_Qty =LAST_QTY-" & strQty & " where  CODE='" & strItem & "'"
                bReturn = oService.ExecCommandRowRet(strSql) '// Delete data begor regenerate

                strSql = "Update  MPRODUCT set LAST_QTY =LAST_QTY+" & txtDocQty.Text & " where  CODE='" & txtItemNo.Text & "'"
                bReturn = oService.ExecCommandRowRet(strSql) '// Delete data begor regenerate
                MessageBox.Show(clsLang.msg_savesuccess, clsLang.msg_infomation, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                MessageBox.Show(clsLang.msg_cannotsave, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return bReturn
    End Function


    Private Sub UpdateStockMaster()


    End Sub
    Private Function getLastDoc() As String
        'Dim oDataset As DataSet = oService.getDataSetTableName("SELECT max(docno) FROM tb_rec_hd Where DocNo like '" & Today.Year & Today.ToString("MMdd") & "%'", "tb_mas_item")
        'If oDataset.Tables(0).Rows.Count > 0 Then
        '    If IsDBNull(oDataset.Tables(0).Rows(0).Item(0)) = False Then
        '        txtDocNo.Text = Today.Year & Today.ToString("MMdd") & (Convert.ToInt16(oDataset.Tables(0).Rows(0).Item(0).ToString.Substring(8)) + 1).ToString("000")
        '    Else
        '        txtDocNo.Text = Today.Year & Today.ToString("MMdd") & "001"
        '    End If
        'End If

        Dim strCurDate As String = curDate()
        Dim strPrefix As String
        strPrefix = retPrefix(txtDocNo.Text)
        Dim ds As DataSet = oService.getDataSet("Select CURR_NO From MBOOK where prefix ='" & strPrefix & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim Curr_base, Curr_base_mid, Curr_date, RunNo As String 'yyMM
            Curr_base = ds.Tables(0)(0)("CURR_NO").ToString
            Curr_base_mid = Mid(Curr_base, 1, 4)
            If strCurDate > Curr_base_mid Then
                Dim sql As String = "Update MBOOK SET CURR_NO = '" & strCurDate & "001' WHERE prefix= '" & strPrefix & "'"
                oService.ExecCommand(sql)
                Return strPrefix & strCurDate & "001"
            Else
                RunNo = Mid(Curr_base, 5, 3)
                RunNo = RunNo + 1
                Dim sql As String = "Update MBOOK SET CURR_NO = '" & Curr_base_mid & Convert.ToInt16(RunNo).ToString("000") & "' WHERE prefix= '" & strPrefix & "'"
                oService.ExecCommand(sql)
                Return strPrefix & Curr_base_mid & Convert.ToInt16(RunNo).ToString("000")
            End If

        End If

    End Function

    Private Function retPrefix(str As String) As String
        Dim i As Int16
        Dim strRet As String
        Dim tmp As String

        For i = 1 To Len(str)
            If IsNumeric(Mid(str, i, 1)) Then
                Return strRet
            Else
                tmp = Mid(str, i, 1)
                strRet = strRet & tmp
            End If

        Next


    End Function

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Dim x As New clsFind
        Dim oDataRow As DataRow = Nothing
        With x
            '.setConstring(clsSetting.GetSetting("ConString", ""))
            .setTableName(clsLang.msg_iss_type)
            .setSQL("SELECT DocNo,docdate,Remark,invoid from TB_REC_HD order by docno")
            .setColumnDesc("เลขที่เอกสาร,วันที่สั่งซื้อ,ใบกำกับภาษี")
            .setColumnWidth("300,300,0")
            .OpenFind()
            oDataRow = .getDatarow
            If oDataRow Is Nothing = False Then
                'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDocNo.Text = oDataRow(0).ToString
                txtDocDate.Value = oConFig.db2Date(oDataRow(1).ToString)
                txtRemark.Text = oDataRow(2).ToString
                txtDocNo.Enabled = False
                txtIV.Text = oDataRow("invoid").ToString
                Call RefreshData()
            End If
        End With

        oDataRow = Nothing
        x = Nothing

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub FrmItemReceive_Load(sender As Object, e As EventArgs) Handles Me.Load


        init_BookName()
    End Sub

    Private Sub cb_book_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_book.SelectedIndexChanged


        Dim drv As DataRowView = DirectCast(cb_book.SelectedItem, DataRowView)

        ' and display the info
        txtDocNo.Text = drv("prefix").ToString() & drv("curr_no").ToString()

    End Sub

    Private Sub cmdCuntry_Click(sender As Object, e As EventArgs) Handles cmdCuntry.Click
        Dim x As New clsFind
        Dim oDataRow As DataRow = Nothing
        With x
            '.setConstring(clsSetting.GetSetting("ConString", ""))
            .setTableName(clsLang.msg_iss_type)
            .setSQL("SELECT id,Name from mvendor where id like '" & txtCuntryNane.Text & "%'")
            .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name)
            .setColumnWidth("100,200")
            .OpenFind()
            oDataRow = .getDatarow
            If oDataRow Is Nothing = False Then
                'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCuntry.Text = oDataRow(0).ToString
                txtCuntryNane.Text = oDataRow(1).ToString
                'If txtId.Enabled Then Call getLastItem() : txtName.Focus()
                'txtId.Enabled = False
            End If
        End With

        oDataRow = Nothing
        x = Nothing
    End Sub

    Private Sub grdMain_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdMain.CellContentClick
        If e.RowIndex > -1 And e.ColumnIndex = 0 Then '// Edit
            'MessageBox.Show("Edit " & e.ColumnIndex)
            txtItemNo.Text = grdMain.Item("ItemNo", e.RowIndex).Value.ToString
            txtItemNo.Tag = txtItemNo.Text '// For detail edit mode
            txtItemName.Text = grdMain.Item("ItemNo", e.RowIndex).Value.ToString
            txtCuntry.Text = grdMain.Item("VendorCode", e.RowIndex).Value.ToString
            txtCuntryNane.Text = grdMain.Item("VendorName", e.RowIndex).Value.ToString
            txtDocQty.Text = grdMain.Item("RecQty", e.RowIndex).Value.ToString
            txtUnitPrice.Text = grdMain.Item("UnitPrice", e.RowIndex).Value.ToString
            txtTotal.Text = grdMain.Item("TotalPrice", e.RowIndex).Value.ToString

            '    txtSalePrice.Text = grdMain.Item("SalePrice", e.RowIndex).Value.ToString
            txtRemark.Text = grdMain.Item("Remark", e.RowIndex).Value.ToString
        ElseIf e.RowIndex > -1 And e.ColumnIndex = grdMain.Columns.Count - 1 Then '// barcode

            '  If frmBarFormat.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

            Try

                '   If Dir("c:\database.txt") <> "" Then Kill("c:\database.txt")

                '  If CopyDataToLocal(txtDocNo.Text, grdMain.Item("ItemNo", e.RowIndex).Value.ToString) Then Call Shell("Printbarcode" & bFormat & ".bat", AppWinStyle.NormalFocus, False)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
            'MessageBox.Show("Barcode =" & e.ColumnIndex)
        Else
        End If
    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click

        Dim sql As String
        sql = "Select * From vReceive where Docno = '" & txtDocNo.Text & "'"
        Dim ds As New DataSet
        ds = oService.getDataSet(sql)

        Dim frm As New Report_PO
        frm.m_dt = ds.Tables(0)
        frm.Show()

    End Sub


    Function curDate() As String
        Dim _curCulture As System.Globalization.CultureInfo
        ' System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("th-TH")
        _curCulture = New System.Globalization.CultureInfo("th-TH")
        Dim strYear As String = Today.ToString("yy", _curCulture)
        Dim strMonth As String = Today.ToString("MM", _curCulture)
        Dim strTmp As String
        If strYear < "60" Then
            strYear = strYear + 43
        End If
        strTmp = strYear & strMonth
        Return strTmp
    End Function





    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = Keys.Enter Then cmdItem_Click(sender, Nothing)
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged

    End Sub

    Private Sub txtCuntryNane_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuntryNane.KeyDown

        If e.KeyCode = Keys.Enter Then
            cmdCuntry_Click(sender, Nothing)

        End If
    End Sub

    Private Sub lblAddCuntry_Click(sender As Object, e As EventArgs) Handles lblAddCuntry.Click

    End Sub

    Private Sub txtCuntryNane_TextChanged(sender As Object, e As EventArgs) Handles txtCuntryNane.TextChanged

    End Sub

    Private Sub lblCapName_Click(sender As Object, e As EventArgs) Handles lblCapName.Click

    End Sub
End Class