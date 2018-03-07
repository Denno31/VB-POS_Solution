Imports System.Linq
Imports System.Data.Entity
Imports System.Reflection

Public Class FrmManageMember

    Dim oDataset As DataSet
    Dim oDT As DataTable
    Dim clsLang As New clsLangMsg
    Dim m_StockOnHand As New Model.Sale.M_Stock_OnHand
    Dim stock_criteria As New Model.Criteria.Sale.M_Stock_OnHand
    Dim m_saleSlipTran_criteria As New Model.Criteria.Sale.M_SaleSlip_Tran
    Public clsSetting As New mySetting(mySetting.Config.ApplicationFile)

    Private m_customer As New Model.Sale.M_Customer


    Private Sub FrmManageMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call ClearText()
        ' Call RefreshData()
        Call getLastDoc()
        init_BookName()

        '   init_custName()
    End Sub


    Private Sub WarningPoint()

        Dim R As Boolean = False
        Dim ds As New DataSet
        Dim sql As String
        sql = "Select * From n_PROMOTION Where Active = 1 "
        ds = oService.getDataSet(sql)
        Dim tb As DataTable
        tb = ds.Tables(0).Copy

        Dim dateStart, dateEnd As String
        Dim point, des As String

        If tb.Rows.Count > 0 Then
            dateStart = tb.Rows(0)("date_Start").ToString
            dateEnd = tb.Rows(0)("date_End").ToString
            point = tb.Rows(0)("VALUE_BATH").ToString
            des = tb.Rows(0)("Description").ToString
            R = True


            lblContentProm.Text = des

            lblDes1.Text = "เพียงทำยอดสั่งซื้อถึง  " & Format(CDec(point), "#,000.00") & "  บาท"
            lblDes2.Text = "สะสมยอดซื้อตั้งแต่วันที่ " & CDate(dateStart).ToString("dd-MM-yyyy") & "  ถึงวันที่  " & CDate(dateEnd).ToString("dd-MM-yyyy")




        End If

        '###### MEMBER 
        If R = True Then

            Dim Dstart, Dend As Date


            sql = "Select sum(amount) as point_ From vSale where c_id = '" & Trim(txtBarcode.Text.Replace(vbCrLf, "")) & "' "
            sql += " AND (Createdate >'" & CDate(dateStart).ToString("yyyyMMdd") & "' and Createdate < '" & CDate(dateEnd).ToString("yyyyMMdd") & "')"
            Dim ds2 As New DataSet
            ds2 = oService.getDataSet(sql)
            If ds2.Tables(0).Rows.Count > 0 Then

                If IsDBNull(ds2.Tables(0)(0)("point_")) Then Exit Sub


                Dim pointCust As String
                pointCust = ds2.Tables(0)(0)("point_").ToString
                If CInt(point) > CInt(pointCust) Then

                    'Dim 
                    'Format(Convert.ToDecimal(Str), "#,000.00")
                    lblWarnPoint.Text = "ท่านเหลือยอดเพียง  " & Format(CInt(point) - CInt(pointCust), "#,000.00") & "  เท่านั้น !!"
                    txtPoint.Text = Format(CInt(pointCust), "#,000.00")
                End If

            End If

        End If

        PanelWarning.Visible = True
    End Sub


    Private Sub init_BookName()



        Dim _Bll As New BLL.PO
        Dim dt As DataTable

        dt = _Bll.getBook

        cb_book.AutoCompleteMode = AutoCompleteMode.Suggest
        cb_book.DataSource = dt
        cb_book.DisplayMember = "BOOK_DESC"
        cb_book.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    Private Sub RefreshData()
        'Me.daMain.Fill(Me.DsMainData.tb_mas_site)
        grdMain.Columns.Clear()

        '   oDataset = oService.getDataSetTableName("SELECT Barcode,(Barcode + ' : ' + ItemName) as ItemNox ,FullName,issQty,SalePrice,TotalPrice,Remark FROM vIssue Where DocNo='" & txtDocNo.Text & "'", "vIssue")
        Dim _BLL As New BLL.Sale
        m_saleSlipTran_criteria.SaleSlip_id = txtDocNo.Text


        Dim sql As String
        sql = "select PROD_CODE,DETAIL,PRICE,AMOUNT,QTY from N_CUST_SALE_SLIP_TRAN where SALE_SLIP_ID = '" & txtDocNo.Text & "'"



        Dim ds As New DataSet
        Dim dt As DataTable

        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)

        Dim i As Integer
        With grdMain
            .DataSource = dt
            .Columns(0).HeaderText = "รหัสสินค้า"
            .Columns(1).HeaderText = "รายละเอียดสินค้า"
            .Columns(2).HeaderText = "ราคาต่อชิ้น"
            .Columns(3).HeaderText = "ราคารวม"
            .Columns(4).HeaderText = "จำนวน"
            '.Columns(4).HeaderText = "ราคา"
            '.Columns(5).HeaderText = "ราคารวม"
            '.Columns(6).HeaderText = "หมายเหตุ"
            '.Columns(6).Visible = False


            Call AddEditButtonColumn()

            Call MasterGridFormat(grdMain)

            For i = 0 To .Columns.Count - 1
                .Columns(i).Width = clsSetting.GetSetting(Me.Name & grdMain.Name & CType(i, String), .Columns(i).Width)
            Next
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With

        lblTotalData.Text = dt.Rows.Count

        Call SumMoney()

        Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub SumMoney()
        Dim i As Integer = 0
        Dim nMoney As Single = 0
        lblPrice.Text = "0.00"
        With grdMain
            For i = 0 To .Rows.Count - 1
                nMoney += .Rows(i).Cells("AMOUNT").Value
            Next
            lblPrice.Text = nMoney.ToString("#,##0.00")
        End With
    End Sub


    Private Sub AddEditButtonColumn()

        ' Initialize the button column.
        Dim buttonColumn As New DataGridViewButtonColumn

        With buttonColumn
            .HeaderText = "ยกเลิก"
            .Name = "edit"
            .Text = "ยกเลิก"
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub



    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown

        If e.KeyCode = Keys.Enter Then

            initData()
            WarningPoint()
        End If


    End Sub

    Private Sub initData()

        Dim _bll As New BLL.Sale
        Dim criteria As New Model.Criteria.Sale.M_Customer
        criteria.ID = txtBarcode.Text.Trim
        Dim dt As DataTable

        dt = _bll.getCustomer(criteria)

        If dt.Rows.Count > 0 Then

            m_customer.ID = dt.Rows(0)("ID").ToString()
            m_customer.name = dt.Rows(0)("name").ToString()
            m_customer.title = dt.Rows(0)("title").ToString()
            m_customer.cr_Day = dt.Rows(0)("cr_Days").ToString()
            m_customer.cr_limit = dt.Rows(0)("cr_limit").ToString()

            txtTitle.Text = m_customer.title
            TxtName.Text = m_customer.name
            txtCreditDays.Text = m_customer.cr_Day
            txtCreditLimit.Text = m_customer.cr_limit
            lblTotalData.Text = "1"
            '   calPoint()
        Else
            lblTotalData.Text = "0"
        End If

    End Sub



    'Private Sub calPoint()

    '    Dim sql As String
    '    sql = "Select sum(amount) as point_ From vSale where c_id = '" & Trim(txtBarcode.Text.Replace(vbCrLf, "")) & "'"
    '    Dim ds As New DataSet
    '    Dim str As String
    '    sql = sql.Replace(vbCrLf, "")
    '    ds = oService.getDataSet(sql)

    '    If ds.Tables(0).Rows.Count > 0 Then
    '        str = ds.Tables(0)(0)(0).ToString()
    '        txtPoint.Text = Format(Convert.ToDecimal(str), "#,000.00")

    '    Else
    '        txtPoint.Text = "0.00"
    '    End If


    'End Sub


    Private Sub initStockOnHand()

        Dim _bll As New BLL.Sale

        stock_criteria.PROD_CODE = txtItemNo.Text


        Dim dt As DataTable

        dt = _bll.getStockOnHand(stock_criteria)

        If dt.Rows.Count > 0 Then

            m_StockOnHand.PROD_CODE = dt.Rows(0)("PROD_CODE").ToString()
            m_StockOnHand.Cost = dt.Rows(0)("COST").ToString()
            m_StockOnHand.ValueOnHand = dt.Rows(0)("VALUONHAND").ToString()
            m_StockOnHand.STK_OnHand = dt.Rows(0)("STK_ONHAND").ToString()

            txtUnitPrice.Text = m_StockOnHand.Cost
            txtStockOnHand.Text = m_StockOnHand.STK_OnHand
            txtUnitPrice.Text = m_StockOnHand.Cost

            lblTotalData.Text = "1"
        Else
            lblTotalData.Text = "0"
        End If

    End Sub

    'Private Sub init_custName()

    '    Dim db = New POSEntities
    '    Dim ds = (From c In db.MCUST Select New With { _
    '              c.ID, _
    '              c.NAME
    '          }).ToList



    '    '     Dim ds = db.MCUST.ToList()

    '    Dim collection As New AutoCompleteStringCollection
    '    For i As Integer = 0 To ds.Count - 1
    '        collection.Add(ds.Item(i).NAME)
    '        cbName.Items.Add(ds.Item(i).NAME)
    '    Next




    '    '            textBox1.AutoCompleteMode = AutoCompleteMode.Append;
    '    'textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    '    'textBox1.AutoCompleteCustomSource = namesCollec


    '    TxtName.AutoCompleteMode = AutoCompleteMode.Suggest
    '    TxtName.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TxtName.AutoCompleteCustomSource = collection

    '    cbName.AutoCompleteMode = AutoCompleteMode.Suggest
    '    cbName.AutoCompleteSource = AutoCompleteSource.ListItems
    '    'cbName.AutoCompleteCustomSource = collection


    'End Sub

    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub CalTotalPrice()
        txtTotal.Text = Val(txtStockOnHand.Text) * Val(txtUnitPrice.Text)
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click

        Dim x As New clsFind

        Dim criteria As New Model.Criteria.Sale.M_SaleSlip_Head
        Dim oDataRow As DataRow = Nothing


        criteria.SaleSlip_id = Today.Year & Today.ToString("MMdd")

        With x

            .setTableName(clsLang.msg_iss_type)
            .setSQL("SELECT * FROM N_Cust_Sale_Slip_Head")
            '  .setCriteriaDoc(criteria)
            .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_issue_date & "," & clsLang.msg_remark)
            .setColumnWidth("100,200,0")
            .OpenFind()

            oDataRow = .getDatarow
            If oDataRow Is Nothing = False Then
                'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDocNo.Text = oDataRow(1).ToString
                txtDocDate.Value = oConFig.db2Date(oDataRow(1).ToString)
                txtRemark.Text = oDataRow(2).ToString
                txtDocNo.Enabled = False
                Call RefreshData()
            End If
        End With

        oDataRow = Nothing
        x = Nothing


    End Sub

    Private Sub cmdItem_Click(sender As Object, e As EventArgs) Handles cmdItem.Click
        Dim x As New clsFind
        Dim oDataRow As DataRow = Nothing
        With x
            '.setConstring(clsSetting.GetSetting("ConString", ""))
            .setTableName(clsLang.msg_iss_type)
            '.setCriteriaStockOnHand(stock_criteria)
            ' .setSQL("SELECT ItemNO,ItemName,ItemType,TypeName,ItemGroup,FullName,ItemPrice from vItemMaster")
            .setSQL("SELECT CODE,NAME,PRICE_1 FROM MPRODUCT Where CODE like '" & txtItemName.Text & "%'")
            .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name & ",ราคา")
            .setColumnWidth("300,600,100")
            .OpenFind()
            oDataRow = .getDatarow
            If oDataRow Is Nothing = False Then
                'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtItemNo.Text = oDataRow("CODE").ToString
                txtItemNo.Tag = ""
                txtItemName.Text = oDataRow("NAME").ToString
                txtStockOnHand.Text = "1"
                txtUnitPrice.Text = oDataRow("PRICE_1").ToString
                Call CalTotalPrice()
                Call cmdSave_Click(sender, e)
                'txtTypeId.Text = oDataRow(2).ToString
                'txtTypeName.Text = oDataRow(3).ToString
                'txtId.Enabled = False
            End If
        End With

        oDataRow = Nothing
        x = Nothing
    End Sub

    Private Sub txtItemNo_TextChanged(sender As Object, e As EventArgs) Handles txtItemNo.TextChanged

    End Sub

    Private Sub getItemByBarcode()
        'Dim strSql = "SELECT ItemNO,ItemName,Barcode,FullName,SalePrice from vBarcode where OnhandQty>0 and barcode='" & txtItemNo.Text & "'"
        '     Dim strSql = "SELECT ItemNO,ItemName,ItemType,TypeName,ItemGroup,FullName,ItemPrice,OnhandQty from vItemMaster where  ItemNO='" & txtItemNo.Text & "'" 'OnhandQty>0 and
        Dim oDs As New DataSet
        Dim oDataRow As DataRow


        Dim _BLL As New BLL.Sale

        Dim dt As DataTable
        stock_criteria.PROD_CODE = txtItemNo.Text

        dt = _BLL.getMProduct(stock_criteria)



        '  oDs = oService.getDataSet(strSql)
        If dt.Rows.Count > 0 Then
            oDataRow = dt.Rows(0)


            'If oDataRow("OnhandQty").ToString <= 0 Then
            '    MessageBox.Show("สินค้าไม่พอขาย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txtItemNo.Text = ""
            '    txtItemNo.SelectAll()
            '    Exit Sub
            'End If

            txtItemNo.Text = oDataRow(0).ToString
            txtItemNo.Tag = ""
            txtItemName.Text = oDataRow(0).ToString
            'txtDocQty.Text = "1"
            txtUnitPrice.Text = oDataRow("PRICE_1").ToString
            txtStockOnHand.Text = "1"
            txtUnitPrice_TextChanged(txtUnitPrice, Nothing)
            txtItemNo.SelectAll()
        Else

            MessageBox.Show("บาร์โค้ดไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemNo.Clear()
            txtItemName.Clear()
            'txtDocQty.Clear()
            txtStockOnHand.Clear()
            txtUnitPrice.Clear()
            txtItemNo.Focus()
        End If
    End Sub

    Private Sub txtItemNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemNo.KeyDown

        If e.KeyCode = Keys.Enter Then



            If e.KeyCode = Keys.Enter Then
                Call getItemByBarcode()
                If txtItemNo.Text.Trim <> "" Then Call cmdSave_Click(sender, e)
                txtItemNo.SelectAll()
            End If




            '   initStockOnHand()

        End If


    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If saveData() Then
            Call RefreshData()
            '    Dim sDoc As String = txtDocNo.Text
            Call ClearText()
            '   txtDocNo.Text = sDoc
            txtDocNo.Enabled = False
        End If
        txtItemNo.Focus()
    End Sub



    Function saveData() As Boolean
        Dim strSql As String = ""
        Dim bReturn As Boolean = False
        Dim oDataset As DataSet = Nothing


        Dim dt As DataTable
        Dim _BLL As New BLL.Sale
        Dim mCriteriaHead As New Model.Criteria.Sale.M_SaleSlip_Head
        Dim mCriteriaTan As New Model.Criteria.Sale.M_SaleSlip_Tran
        Dim result As Int16

        Try

            If txtDocNo.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If txtItemNo.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            'If txtSales.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            '  If IsNumeric(txtDocQty.Text.Trim) = False Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
            If IsNumeric(txtUnitPrice.Text.Trim) = False Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function

            '   If Val(txtDocQty.Text) = 0 Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function

            If txtDocNo.Enabled = False Then '// Update

                'strSql = "Update TB_ISS_HD set DocDate='" & txtDocDate.Value.Year & txtDocDate.Value.ToString("-MM-dd") & "', Remark='" & txtRemark.Text.Trim & "',ModifyDate=Now()"
                'strSql = strSql & " Where DocNo='" & txtDocNo.Text.Trim & "'"



                bReturn = True

            Else
                '//insert


                Call getLastDoc()
                'By ARM
                mCriteriaHead.SaleSlip_id = txtDocNo.Text


                Dim s As String
                s = "Select * from [N_Cust_Sale_Slip_Head] where SALE_SLIP_ID = '" & txtDocNo.Text & "'"

                Dim ds As New DataSet

                ds = oService.getDataSet(s)
                dt = ds.Tables(0)
                '   dt = _BLL.getSaleSlip_Head(mCriteriaHead)




                If dt.Rows.Count = 0 Then '// ตรวจสอบการซ้ำ


                    mCriteriaHead.cust_id = Trim(txtBarcode.Text.Replace(vbCrLf, ""))
                    mCriteriaHead.SaleSlip_id = txtDocNo.Text
                    mCriteriaHead.description = txtItemName.Text
                    mCriteriaHead.UpdateDate = DateTime.Now()
                    mCriteriaHead.Sales_id = Trim(txtSales.Text)



                    Dim s3 As String
                    s3 = "	INSERT INTO N_Cust_Sale_Slip_Head(CUST_ID,SALE_SLIP_ID,[DESCRIPTION],CreateDate,SALE_ID)"
                    s3 += "VALUES  ('" & mCriteriaHead.cust_id & "','"
                    s3 += mCriteriaHead.SaleSlip_id & "','"
                    s3 += mCriteriaHead.description & "',"
                    s3 += " getdate() ,'"
                    s3 += mCriteriaHead.Sales_id & "')"


                    result = oService.ExecCommandRowRet(s3)


                    If result > 0 Then
                        'MessageBox.Show(clsLang.msg_savesuccess, clsLang.msg_infomation, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bReturn = True
                    Else
                        'MessageBox.Show(clsLang.msg_cannotsave, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else

                    bReturn = True
                    'MessageBox.Show(clsLang.msg_duplicate, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            If bReturn Then '// ถ้าบันทึกข้อมูลส่วนหัวสำเร็จ

                mCriteriaTan.Qty = txtStockOnHand.Text.Trim
                mCriteriaTan.Prod_code = txtItemNo.Text
                mCriteriaTan.Detail = txtItemName.Text
                mCriteriaTan.cust_id = Trim(txtBarcode.Text.Replace(vbCrLf, ""))
                mCriteriaTan.price = txtUnitPrice.Text
                mCriteriaTan.amount = txtTotal.Text
                mCriteriaTan.SaleSlip_id = txtDocNo.Text
                mCriteriaTan.CreateDate = Date.Now.ToString("MM/dd/yyyy HHH:mm:ss")

                Dim sql As String
                sql = "	UPDATE N_CUST_SALE_SLIP_TRAN SET "
                sql += "CUST_ID ='" & mCriteriaTan.cust_id & "',"
                sql += "SALE_SLIP_ID ='" & mCriteriaTan.SaleSlip_id & "',"
                sql += "DETAIL = '" & mCriteriaTan.Detail & "',"
                sql += "QTY = QTY + " & mCriteriaTan.Qty & ","
                sql += "PROD_CODE ='" & mCriteriaTan.Prod_code & "',"
                sql += "price = " & mCriteriaTan.price & ","
                sql += " amount = AMOUNT + " & mCriteriaTan.amount
                sql += " WHERE SALE_SLIP_ID ='" & mCriteriaTan.SaleSlip_id & "' AND PROD_CODE ='" & mCriteriaTan.Prod_code & "'"



                result = oService.ExecCommandRowRet(sql)

                If result = 0 Then  '//  Cannot Update

                    Dim sql2 As String
                    sql2 = "	INSERT INTO N_CUST_SALE_SLIP_TRAN"
                    sql2 += "(CUST_ID,"
                    sql2 += " [SALE_SLIP_ID]"
                    sql2 += " ,[DETAIL]"
                    sql2 += " ,[QTY]"
                    sql2 += " ,[PROD_CODE]"
                    sql2 += " ,price"
                    sql2 += " ,amount"
                    sql2 += " ,CreateDate) "
                    sql2 += " VALUES"
                    sql2 += "('" & mCriteriaTan.cust_id & "','"
                    sql2 += mCriteriaTan.SaleSlip_id & "','"
                    sql2 += mCriteriaTan.Detail & "',"
                    sql2 += mCriteriaTan.Qty & ",'"
                    sql2 += mCriteriaTan.Prod_code & "',"
                    sql2 += mCriteriaTan.price & ","
                    sql2 += mCriteriaTan.amount & ","
                    sql2 += "getdate())"




                    result = oService.ExecCommandRowRet(sql2)
                    If result = 0 Then
                        bReturn = False
                    Else

                        UpdateStock(mCriteriaTan.Prod_code, mCriteriaTan.Qty)

                        bReturn = True
                    End If
                Else

                    UpdateStock(mCriteriaTan.Prod_code, mCriteriaTan.Qty)

                    bReturn = True '//  Update success
                End If
            End If

            If bReturn Then
                'MessageBox.Show(clsLang.msg_savesuccess, clsLang.msg_infomation, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '// Reduce Qty onhand 
                'strSql = "Update TB_ITEM_MASTER set OnhandQty=OnhandQty-" & txtDocQty.Text & " Where ItemNo='" & txtItemNo.Text & "'"
                'oService.ExecCommandRowRet(strSql)
            Else
                MessageBox.Show(clsLang.msg_cannotsave & vbCrLf & "ข้อมูลซ้ำหรือจำนวนสินค้าไม่พอขาย", clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return bReturn
    End Function


    Private Sub UpdateStock(prodCode As String, QTY As Int16)


        Dim sql As String
        sql = "Update MPRODUCT SET LAST_QTY = LAST_QTY -  " & QTY
        sql += " WHERE CODE='" & prodCode & "'"

        MsgBox(oService.ExecCommandRowRet(sql))









    End Sub


    Private Sub ClearText()
        ' txtDocNo.Clear()
        txtRemark.Clear()
        txtItemName.Clear()
        txtItemNo.Clear()
        txtStockOnHand.Clear()
        txtUnitPrice.Clear()

        txtTotal.Clear()

        txtDocNo.Enabled = True
        txtItemNo.Focus()

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

    Private Function getLastDoc() As String
        'Dim oDataset As DataSet = oService.getDataSetTableName("SELECT max(docno) FROM TB_ISS_HD Where DocNo like '" & Today.Year & Today.ToString("MMdd") & "%'", "tb_mas_item")

        'Dim dt As DataTable
        'Dim _bll As New BLL.Sale
        'Dim m_criteria As New Model.Criteria.Sale.M_SaleSlip_Head
        'm_criteria.SaleSlip_id = Today.Year & Today.ToString("MMdd")
        'dt = _bll.getSaleSlip_Head_Running(m_criteria)



        'If dt.Rows.Count > 0 Then
        '    If IsDBNull(dt.Rows(0).Item(0)) = False Then
        '        txtDocNo.Text = Today.Year & Today.ToString("MMdd") & (Convert.ToInt16(dt.Rows(0).Item(0).ToString.Substring(8)) + 1).ToString("000")
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

    Private Sub txtUnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CalTotalPrice()
    End Sub

    Private Sub grdMain_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdMain.CellContentClick


        If e.RowIndex > -1 And e.ColumnIndex = 0 Then '// Edit
            If MessageBox.Show("ยืนยันการยกเลิกรายการสินค้าบาร์โค้ด : " & grdMain.Item(1, e.RowIndex).Value.ToString & " หรือไม่", "ยืนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then


                Dim fReturn As New FrmCancelSale
                fReturn._Name = grdMain.Item(1, e.RowIndex).Value.ToString
                fReturn.Qty = grdMain.Item("QTY", e.RowIndex).Value.ToString
                fReturn.ShowDialog(Me)
                Dim y As Double
                y = fReturn.ReturnQty
                Dim x As Double
                x = y * CType(grdMain.Item("PRICE", e.RowIndex).Value.ToString, Double)


                m_saleSlipTran_criteria.amount = x
                m_saleSlipTran_criteria.Qty = y
                m_saleSlipTran_criteria.SaleSlip_id = txtDocNo.Text
                m_saleSlipTran_criteria.Prod_code = fReturn._Name

                ''ยกเลิกสินค้า
                Dim _bll As New BLL.Sale
                Dim result As Int16



                Dim sql As String
                sql = "	UPDATE N_CUST_SALE_SLIP_TRAN SET "
                sql += "QTY = " & m_saleSlipTran_criteria.Qty
                sql += ",Price = " & m_saleSlipTran_criteria.price
                sql += ",amount=" & m_saleSlipTran_criteria.amount
                sql += " WHERE sale_slip_id='" & m_saleSlipTran_criteria.SaleSlip_id & "' AND PROD_CODE='" & m_saleSlipTran_criteria.Prod_code & "'"
                result = oService.ExecCommandRowRet(sql)


                txtItemNo.Focus()
                Call RefreshData()





                'If bReturn > 0 Then
                '    '//บันทึก Void
                '    strsql = "Insert into TB_SALE_VOID(DocNo,Barcode,issQty,UnitPRice,TotalPrice,ModifyBy,ModifyDate)"
                '    strsql += " values("
                '    strsql += ",'" & grdMain.Item("Barcode", e.RowIndex).Value.ToString & "'"
                '    strsql += "," & y & ""
                '    strsql += "," & grdMain.Item("SalePrice", e.RowIndex).Value.ToString
                '    strsql += "," & grdMain.Item("TotalPrice", e.RowIndex).Value.ToString
                '    strsql += ",'" & oConFig.User & "'"
                '    strsql += ",Now()"
                '    strsql += ")"

                '    bReturn = oService.ExecCommandRowRet(strsql)
                '    'If bReturn > 0 Then

                '    '    strsql = "Update  tb_item_master set ONhandQty =ONhandQty+" & grdMain.Item("issQty", e.RowIndex).Value.ToString & " where  ItemNo='" & grdMain.Item("Barcode", e.RowIndex).Value.ToString & "'"
                '    '    oService.ExecCommandRowRet(strsql)

                '    '    If bReturn > 0 Then

                '    '        txtItemNo.Focus()
                '    '        Call RefreshData()
                '    '    Else
                '    '        MessageBox.Show("ไม่สามารถลบข้อมูลได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    '    End If
                '    'Else

                '    'End If
                'End If
            End If
        End If
    End Sub

    Private Sub pnReceive_Paint(sender As Object, e As PaintEventArgs) Handles pnReceive.Paint

    End Sub

    Private Sub lblReceiveMoney_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblReceiveMoney.LinkClicked
        pnReceive.Visible = True
        If pnReceive.Visible Then txtMoneyRec.Text = 0
    End Sub

    Private Sub FrmManageMember_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            pnReceive.Visible = Not pnReceive.Visible
            If pnReceive.Visible Then txtMoneyRec.Text = 0
        End If
    End Sub

    Private Sub txtMoneyRec_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMoneyRec.KeyDown
        If e.KeyCode = Keys.Enter Then cmdOk.Focus()
    End Sub

    Private Sub txtMoneyRec_TextChanged(sender As Object, e As EventArgs) Handles txtMoneyRec.TextChanged
        txtMoneyChange.Text = String.Format("{0:N}", Val(txtMoneyRec.Text) - Val(lblPrice.Text.Replace(",", "")))
    End Sub


    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        If IsNumeric(txtMoneyRec.Text) = False Then MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        If Val(txtMoneyRec.Text) = 0 Then MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        If Val(txtMoneyRec.Text) < Val(lblPrice.Text.Replace(",", "")) Then MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        pnReceive.Visible = False
        cmdNew_Click(sender, e)
        Me.Focus()

    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Call ClearText()
        Call getLastDoc()
        Call RefreshData()

    End Sub

    Private Sub pnReceive_VisibleChanged(sender As Object, e As EventArgs) Handles pnReceive.VisibleChanged
        If pnReceive.Visible Then txtMoneyRec.Focus()
    End Sub

    Private Sub FrmManageMember_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        'If e.KeyChar = Keys.F10 Then
        '    pnReceive.Visible = Not pnReceive.Visible
        '    If pnReceive.Visible Then txtMoneyRec.Text = 0
        'End If
    End Sub

    Private Sub txtUnitPrice_TextChanged_1(sender As Object, e As EventArgs) Handles txtUnitPrice.TextChanged

    End Sub


    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged

    End Sub

    Private Sub txtDocNo_TextChanged(sender As Object, e As EventArgs) Handles txtDocNo.TextChanged

    End Sub

    Private Sub cb_book_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_book.SelectedIndexChanged
        Dim drv As DataRowView = DirectCast(cb_book.SelectedItem, DataRowView)

        ' and display the info
        txtDocNo.Text = drv("prefix").ToString() & drv("curr_no").ToString()
    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click


        Dim sql As String
        sql = "Select * From vSALE where SALE_SLIP_ID = '" & Trim(txtDocNo.Text) & "'"
        Dim ds As New DataSet
        ds = oService.getDataSet(sql)

        Dim frm As New Report_Sale
        frm.m_dt = ds.Tables(0)
        frm.Show()

    End Sub

 

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown

        If e.KeyCode = Keys.Enter Then cmdItem_Click(sender, Nothing)
    End Sub

 

    Private Sub txtSales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSales.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim x As New clsFind
            Dim oDataRow As DataRow = Nothing
            With x
                '.setConstring(clsSetting.GetSetting("ConString", ""))
                .setTableName(clsLang.msg_iss_type)
                '.setCriteriaStockOnHand(stock_criteria)
                ' .setSQL("SELECT ItemNO,ItemName,ItemType,TypeName,ItemGroup,FullName,ItemPrice from vItemMaster")
                .setSQL("SELECT ID,NAME,SURNAME FROM MSALES Where ID like '" & txtSales.Text & "%'")
                .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name & ",ราคา")
                .setColumnWidth("700,900,300,300")
                .OpenFind()
                oDataRow = .getDatarow
                If oDataRow Is Nothing = False Then
                    'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSales.Text = oDataRow("ID").ToString
                    txtNameSales.Text = oDataRow("NAME").ToString & "  " & oDataRow("SURNAME").ToString
                End If
            End With

            oDataRow = Nothing
            x = Nothing





        End If
    End Sub

    Private Sub txtSales_TextChanged(sender As Object, e As EventArgs) Handles txtSales.TextChanged

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub txtNameSales_TextChanged(sender As Object, e As EventArgs) Handles txtNameSales.TextChanged

    End Sub

    Private Sub txtPoint_TextChanged(sender As Object, e As EventArgs) Handles txtPoint.TextChanged

    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged

    End Sub

    Private Sub txtStockOnHand_TextChanged(sender As Object, e As EventArgs) Handles txtStockOnHand.TextChanged

    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged

    End Sub
End Class