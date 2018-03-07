Public Class FrmCustomer

    Dim oDataset As DataSet
    Dim clsLang As New clsLangMsg



    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click




    End Sub

    Private Sub CLEAR_TEXT()
        For Each ctrl As Control In Panel1.Controls
            If ctrl.GetType() Is GetType(TextBox) Then
                ctrl.Text = "" 'You just need to add this.
            End If
        Next

    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        saveData()
    End Sub

    Private Sub saveData()

        Try

            Dim obj As New POS.Model.Cust.M_Customer


            obj.id = txtBarcode.Text
            obj.title = txtTitle.Text
            obj.name = TxtName.Text
            obj.eng_name = TxtName.Text
            obj.Address = txtAddress.Text
            obj.tumbol = txtTumbol.Text
            obj.Amphur = txtAmphur.Text
            obj.province = txtProvince.Text
            obj.attn_name = txtAttnName.Text
            obj.CR_DAYS = txtCreditDays.Text
            obj.CR_LIMIT = txtCreditLimit.Text
            obj.zipcode = txtZipcode.Text
            obj.phone = txtTel.Text
            obj.fax = txtFax.Text


            If txtBarcode.Enabled Then
                If txtBarcode.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_id, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtTitle.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_prefix_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If TxtName.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtAddress.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtTumbol.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtAmphur.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub


                If txtProvince.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_address, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                '     If txtTel.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_id, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtAttnName.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub


                Dim sql As String


                sql = "insert into MCUST("
                sql += "ID,"
                sql += "TITLE,"
                sql += "name,"
                sql += "eng_name,"
                sql += "CR_DAYS,"
                sql += "CR_LIMIT,"
                sql += "address,"
                sql += "tambon,"
                sql += "amphur,"
                sql += "city,"
                sql += "zipcode,"
                sql += "phone,"
                sql += "fax,"
                sql += "attn_name)"

                sql += "VALUES('"
                sql += obj.id & "','"
                sql += obj.title & "','"
                sql += obj.name & "','"
                sql += obj.eng_name & "','"
                sql += obj.CR_DAYS & "','"
                sql += obj.CR_LIMIT & "','"
                sql += obj.Address & "','"
                sql += obj.tumbol & "','"
                sql += obj.Amphur & "','"
                sql += obj.province & "','"

                sql += obj.zipcode & "','"
                sql += obj.phone & "','"
                sql += obj.fax & "','"
                sql += obj.attn_name & "')"

                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)
                MsgBox(ret)


            Else

                Dim sql As String
                sql = "UPDATE MCUST SET "
                sql += "TITLE='" & obj.title & "',"
                sql += "name='" & obj.name & "',"
                sql += "eng_name='" & obj.name & "',"
                sql += "CR_DAYS=" & obj.CR_DAYS & ","
                sql += "CR_LIMIT=" & obj.CR_LIMIT & ","
                sql += "address='" & obj.Address & "',"
                sql += "tambon='" & obj.tumbol & "',"
                sql += "amphur='" & obj.Amphur & "',"
                sql += "city='" & obj.province & "',"
                sql += "zipcode='" & obj.zipcode & "',"
                sql += "phone='" & obj.phone & "',"
                sql += "fax='" & obj.fax & "',"
                sql += "attn_name='" & obj.attn_name & "' WHERE ID='" & obj.id & "'"

                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)
                MsgBox(ret)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub txtBarcode_Click(sender As Object, e As EventArgs) Handles txtBarcode.Click


        Try

            Dim x As New clsFind
            Dim oDataRow As DataRow = Nothing
            With x
                '.setConstring(clsSetting.GetSetting("ConString", ""))
                .setTableName(clsLang.msg_iss_type)
                .setSQL("SELECT * from mcust where id like '" & txtBarcode.Text & "%'")
                .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name)
                .setColumnWidth("100,200")
                .OpenFind()
                oDataRow = .getDatarow
                If oDataRow Is Nothing = False Then

                    txtBarcode.Text = oDataRow("ID").ToString
                    TxtName.Text = oDataRow("NAME").ToString
                    txtTitle.Text = oDataRow("TITLE").ToString
                    txtAddress.Text = oDataRow("ADDRESS").ToString
                    txtTumbol.Text = oDataRow("TAMBON").ToString
                    txtAmphur.Text = oDataRow("AMPHUR").ToString
                    txtProvince.Text = oDataRow("CITY").ToString
                    txtZipcode.Text = oDataRow("ZIPCODE").ToString
                    txtTel.Text = oDataRow("phone").ToString
                    txtFax.Text = oDataRow("FAX").ToString
                    txtAttnName.Text = oDataRow("ATTN_NAME").ToString
                    txtCreditDays.Text = oDataRow("CR_DAYS").ToString
                    txtCreditLimit.Text = oDataRow("CR_LIMIT").ToString
                    txtBarcode.Enabled = False

                End If
            End With

            oDataRow = Nothing
            x = Nothing




        Catch ex As Exception

        End Try



    End Sub

    Private Sub txtTel_TextChanged(sender As Object, e As EventArgs) Handles txtTel.TextChanged

    End Sub
End Class