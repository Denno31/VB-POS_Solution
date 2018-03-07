

Public Class FrmSaleService

    Dim oDataset As DataSet
    Dim oDT As DataTable
    Dim clsLang As New clsLangMsg
    Dim m_StockOnHand As New Model.Sale.M_Stock_OnHand
    Dim stock_criteria As New Model.Criteria.Sale.M_Stock_OnHand
    Dim m_saleSlipTran_criteria As New Model.Criteria.Sale.M_SaleSlip_Tran
    Public clsSetting As New mySetting(mySetting.Config.ApplicationFile)

    Private m_customer As New Model.Sale.M_Customer

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
    Private Sub init_BookName()



        Dim _Bll As New BLL.PO
        Dim dt As DataTable

        dt = _Bll.getBook

        cb_book.AutoCompleteMode = AutoCompleteMode.Suggest
        cb_book.DataSource = dt
        cb_book.DisplayMember = "BOOK_DESC"
        cb_book.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    Private Sub FrmSaleService_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        init_BookName()
    End Sub

    Private Sub cb_book_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_book.SelectedIndexChanged
        Dim drv As DataRowView = DirectCast(cb_book.SelectedItem, DataRowView)

        ' and display the info
        txtDocNo.Text = drv("prefix").ToString() & drv("curr_no").ToString()
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

    Private Sub ClearText()
        ' txtDocNo.Clear()

        txtItemName.Clear()
        '  txtItemNo.Clear()
        txtStockOnHand.Clear()
        txtUnitPrice.Clear()

        txtTotal.Clear()

        txtDocNo.Enabled = True
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
            If txtSales.Text.Trim = "" Then MessageBox.Show(clsLang.msg_invaliddata, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Function
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
                dt = _BLL.getSaleSlip_Head(mCriteriaHead)




                If dt.Rows.Count = 0 Then '// ตรวจสอบการซ้ำ


                    'mCriteriaHead.cust_id = Trim(txtBarcode.Text.Replace(vbCrLf, ""))
                    mCriteriaHead.SaleSlip_id = txtDocNo.Text
                    mCriteriaHead.description = txtItemName.Text
                    mCriteriaHead.UpdateDate = DateTime.Now()
                    mCriteriaHead.Sales_id = Trim(txtSales.Text)

                    result = _BLL.SaleSlip_Head_Save(mCriteriaHead, "insert")


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

                ' result = _BLL.SaleSlip_Tran_Save(mCriteriaTan, "update")
                result = 0
                If result = 0 Then  '//  Cannot Update
                    result = _BLL.SaleSlip_Tran_Save(mCriteriaTan, "insert")
                    If result = 0 Then
                        bReturn = False
                    Else
                        bReturn = True
                    End If
                Else
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

    Private Sub RefreshData()
        'Me.daMain.Fill(Me.DsMainData.tb_mas_site)
        grdMain.Columns.Clear()

        '   oDataset = oService.getDataSetTableName("SELECT Barcode,(Barcode + ' : ' + ItemName) as ItemNox ,FullName,issQty,SalePrice,TotalPrice,Remark FROM vIssue Where DocNo='" & txtDocNo.Text & "'", "vIssue")
        Dim _BLL As New BLL.Sale
        m_saleSlipTran_criteria.SaleSlip_id = txtDocNo.Text
        oDT = _BLL.getSaleSlip_Tran(m_saleSlipTran_criteria)


        Dim i As Integer
        With grdMain
            .DataSource = oDT
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

        lblTotalData.Text = oDT.Rows.Count

        Call SumMoney()

        Me.WindowState = FormWindowState.Maximized
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

    Private Sub SumMoney()
        Dim i As Integer = 0
        Dim nMoney As Single = 0
        lblPrice.Text = "0.00"
        With grdMain
            For i = 0 To .Rows.Count - 1
                nMoney += .Rows(i).Cells(3).Value
            Next
            lblPrice.Text = nMoney.ToString("#,##0.00")
        End With
    End Sub

    Private Sub txtUnitPrice_TextChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.TextChanged
        Call CalTotalPrice()
    End Sub
    Private Sub CalTotalPrice()
        txtTotal.Text = Val(txtStockOnHand.Text) * Val(txtUnitPrice.Text)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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

            M_Customer.id = dt.Rows(0)("ID").ToString()
            M_Customer.name = dt.Rows(0)("name").ToString()
            M_Customer.title = dt.Rows(0)("title").ToString()
            M_Customer.cr_Day = dt.Rows(0)("cr_Days").ToString()
            M_Customer.CR_LIMIT = dt.Rows(0)("cr_limit").ToString()

            txtTitle.Text = M_Customer.title
            TxtName.Text = M_Customer.name
            txtCreditDays.Text = M_Customer.cr_Day
            txtCreditLimit.Text = M_Customer.CR_LIMIT
            lblTotalData.Text = "1"
            ' calPoint()
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

    Private Sub txtUnitPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnitPrice.KeyDown


        If e.KeyCode = Keys.Enter Then

            cmdSave_Click(sender, Nothing)


        End If

    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged

    End Sub

    Private Sub lblDes1_Click(sender As Object, e As EventArgs) Handles lblDes1.Click

    End Sub

    Private Sub lblDes2_Click(sender As Object, e As EventArgs) Handles lblDes2.Click

    End Sub
End Class