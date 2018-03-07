Public Class FrmItemMaster


    Dim oDataset As DataSet
    Dim clsLang As New clsLangMsg

    Private Sub lblAddCuntry_Click(sender As Object, e As EventArgs) Handles lblAddCuntry.Click
        If Not FrmVendor Is Nothing Then FrmVendor.Close()
        FrmVendor.ShowDialog()
    End Sub

    Private Sub cmdCuntry_Click(sender As Object, e As EventArgs) Handles cmdCuntry.Click

    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        saveData()
    End Sub


    Private Sub saveData()

        Try



            Dim obj As New POS.Model.PO.M_PRODUCT

            obj.CODE = txtCode.Text
            obj.NAME = txtName.Text
            obj.ENG_NAME = txtName.Text
            obj.TYPE1 = txtMPR_Type.Text
            obj.GEN_NAME = txtGen_Name.Text
            obj.BRAND_ID = txtBrand_ID.Text
            obj.MODEL_ID = txtModel_ID.Text
            obj.UNIT_TYPE = txtUnit_Type.Text
            obj.PRICE1 = txtPrice1.Text
            obj.PRICE2 = txtPrice2.Text
            obj.BARCODE = txtBarcode.Text
            obj.LAST_VEND = txtVendorID.Text
            obj.STOCK = txtStock.Text
            obj.MIN = txtMin.Text
            obj.MAX = txtMax.Text



            If txtCode.Enabled Then

                If txtCode.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_id, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtName.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_prefix_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtMPR_Type.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtGen_Name.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtBrand_ID.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtModel_ID.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

                If txtUnit_Type.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

                If txtPrice1.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

                '    If txtBarcode.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub




                Dim sql As String
                sql = "insert into MPRODUCT("
                sql += "CODE,"
                sql += "NAME,"
                sql += "ENG_NAME,"
                sql += "TYPE_1,"
                sql += "GEN_NAME,"
                sql += "BRAND_ID,"
                sql += "MODEL_ID,"
                sql += "UNIT_TYPE,"
                sql += "PRICE_1,"
                sql += "PRICE_2,"
                sql += "BARCODE,"
                sql += "LAST_QTY,"
                sql += "[MIN],"
                sql += "[MAX],"
                sql += "LAST_VEND)"

                sql += "VALUES('"
                sql += obj.CODE & "','"
                sql += obj.NAME & "','"
                sql += obj.NAME & "','"
                sql += obj.TYPE1 & "','"
                sql += obj.GEN_NAME & "','"
                sql += obj.BRAND_ID & "','"
                sql += obj.MODEL_ID & "','"
                sql += obj.UNIT_TYPE & "',"
                sql += obj.PRICE1 & ","
                sql += obj.PRICE2 & ",'"
                sql += obj.BARCODE & "',"
                sql += obj.STOCK & ","
                sql += obj.MIN & ","
                sql += obj.MAX & ",'"
                sql += obj.LAST_VEND & "')"

                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)



                If ret > 0 Then

                    MsgBox("เพิ่มสินค้าสำเร็จ")
                End If


            Else
                Dim sql As String

                sql = "UPDATE MPRODUCT SET "
                sql += "NAME='" & obj.NAME & "',"
                sql += "ENG_NAME='" & obj.NAME & "',"
                sql += "TYPE_1='" & obj.TYPE1 & "',"
                sql += "GEN_NAME='" & obj.GEN_NAME & "',"
                sql += "BRAND_ID='" & obj.BRAND_ID & "',"
                sql += "MODEL_ID='" & obj.MODEL_ID & "',"
                sql += "UNIT_TYPE='" & obj.UNIT_TYPE & "',"
                sql += "PRICE_1=" & obj.PRICE1 & ","
                sql += "PRICE_2=" & obj.PRICE2 & ","
                sql += "BARCODE='" & obj.BARCODE & "',"
                sql += "LAST_QTY=" & obj.STOCK & ","
                sql += "[MIN]=" & obj.MIN & ","
                sql += "[MAX]=" & obj.MAX & ","
                sql += "UPDATEDATE=getdate(),"
                sql += "UPDATEBY='" & User & "',"
                sql += "LAST_VEND='" & obj.LAST_VEND & "'   WHERE code ='" & obj.CODE & "'"

                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)
                If ret > 0 Then

                    MsgBox("แก้ไขสินค้าเรียบร้อย")
                    CLEAR_TEXT()
                    txtName.Select()

                End If

            End If



        Catch ex As Exception

        End Try





    End Sub

    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged

    End Sub

    Private Sub grdMain_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub initMPR_Type()

        Dim sql As String
        sql = "Select type,descript from MPR_TYPE"
        Dim ds As New DataSet
        Dim dt As DataTable

        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)

        cbMPR_Type.DisplayMember = "descript"
        cbMPR_Type.ValueMember = "type"

        cbMPR_Type.DataSource = dt







    End Sub

    Private Sub FrmItemMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        initMPR_Type()
        txtName.Select()
    End Sub

    Private Sub cbMPR_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMPR_Type.SelectedIndexChanged


        txtMPR_Type.Text = cbMPR_Type.SelectedValue

    End Sub

 

    Private Sub txtVendorName_Click(sender As Object, e As EventArgs) Handles txtVendorName.Click

        Try

            Dim x As New clsFind
            Dim oDataRow As DataRow = Nothing
            With x
                '.setConstring(clsSetting.GetSetting("ConString", ""))
                .setTableName(clsLang.msg_iss_type)
                .setSQL("SELECT id,Name from mvendor where id like '" & txtVendorName.Text & "%'")
                .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name)
                .setColumnWidth("100,200")
                .OpenFind()
                oDataRow = .getDatarow
                If oDataRow Is Nothing = False Then

                    txtVendorID.Text = oDataRow(0).ToString
                    txtVendorName.Text = oDataRow(1).ToString
             
                End If
            End With

            oDataRow = Nothing
            x = Nothing




        Catch ex As Exception

        End Try



    End Sub

    Private Sub txtVendorName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVendorName.KeyDown

        If e.KeyCode = Keys.Enter Then
            txtVendorName_Click(sender, Nothing)

        End If


    End Sub

    Private Sub txtVendorName_TextChanged(sender As Object, e As EventArgs) Handles txtVendorName.TextChanged

    End Sub


    Private Sub CLEAR_TEXT()
     For Each ctrl As Control In Panel1.Controls
            If ctrl.GetType() Is GetType(TextBox) Then
                ctrl.Text = "" 'You just need to add this.
            End If
        Next

    End Sub


    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

        CLEAR_TEXT()



    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs) Handles txtName.Click


    End Sub

    Private Sub txtUnit_Type_TextChanged(sender As Object, e As EventArgs) Handles txtUnit_Type.TextChanged

    End Sub

    Private Sub tbrMain_RefreshItems(sender As Object, e As EventArgs) Handles tbrMain.RefreshItems

    End Sub

    Private Sub lblId_Click(sender As Object, e As EventArgs) Handles lblId.Click

    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged

    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown

        If e.KeyCode = Keys.Enter Then


            Dim x As New clsFind
            Dim oDataRow As DataRow = Nothing
            With x
                '.setConstring(clsSetting.GetSetting("ConString", ""))
                .setTableName(clsLang.msg_iss_type)
                '.setCriteriaStockOnHand(stock_criteria)
                ' .setSQL("SELECT ItemNO,ItemName,ItemType,TypeName,ItemGroup,FullName,ItemPrice from vItemMaster")
                .setSQL("SELECT CODE,NAME,TYPE_1,GEN_NAME,BRAND_ID,MODEL_ID,UNIT_TYPE,PRICE_1,PRICE_2,BARCODE,LAST_VEND,LAST_QTY,[MIN] as min_,[MAX] as max_ FROM MPRODUCT Where CODE like '" & txtName.Text & "%'")
                .setColumnDesc("รหัสสินค้า,ชื่อสินค้า, กลุ่มสินค้า")
                .setColumnWidth("600,900,100")
                .OpenFind()
                oDataRow = .getDatarow
                If oDataRow Is Nothing = False Then
                    'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCode.Text = oDataRow("CODE").ToString
                    txtName.Text = oDataRow("NAME").ToString

                    txtMPR_Type.Text = oDataRow("TYPE_1").ToString
                    txtGen_Name.Text = oDataRow("GEN_NAME").ToString
                    txtBrand_ID.Text = oDataRow("BRAND_ID").ToString
                    txtModel_ID.Text = oDataRow("MODEL_ID").ToString
                    txtUnit_Type.Text = oDataRow("UNIT_TYPE").ToString
                    txtPrice1.Text = oDataRow("PRICE_1").ToString
                    txtPrice2.Text = oDataRow("PRICE_2").ToString
                    txtBarcode.Text = oDataRow("BARCODE").ToString
                    txtVendorID.Text = oDataRow("LAST_VEND").ToString
                    txtStock.Text = oDataRow("LAST_QTY").ToString

                    txtMin.Text = oDataRow("MIN_").ToString
                    txtMax.Text = oDataRow("MAX_").ToString
                    txtCode.Enabled = False
                    'txtId.Enabled = False
                End If
            End With

            oDataRow = Nothing
            x = Nothing



        End If


    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub btnPrintBarcode_Click(sender As Object, e As EventArgs) Handles btnPrintBarcode.Click

        Dim i As Integer
        i = Convert.ToInt32(InputBox("จำนวนที่จะปริ้นท์ :-> ", "User Input", "0"))
        ' MsgBox("Your Entered Value Is : " & i)


        For j As Int16 = 0 To i - 1


            Dim zpl As New clsZPL

            zpl.printOut2(txtBarcode.Text, txtCode.Text, TxtLocation.Text)

        Next
    End Sub

    Private Sub txtBrand_ID_TextChanged(sender As Object, e As EventArgs) Handles txtBrand_ID.TextChanged

    End Sub
End Class