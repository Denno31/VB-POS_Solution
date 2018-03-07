Public Class FrmDoc

    Dim oDataset As DataSet
    Dim clsLang As New clsLangMsg

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click

    End Sub

    Private Sub cmdSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles cmdSearch.KeyDown


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown


        If e.KeyCode = Keys.Enter Then

            Try

                Dim x As New clsFind
                Dim oDataRow As DataRow = Nothing
                With x
                    '.setConstring(clsSetting.GetSetting("ConString", ""))
                    .setTableName(clsLang.msg_iss_type)
                    .setSQL("SELECT book_id,book_desc,prefix from mbook where prefix like '" & txtId.Text & "%'")
                    .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name)
                    .setColumnWidth("100,200")
                    .OpenFind()
                    oDataRow = .getDatarow
                    If oDataRow Is Nothing = False Then

                        txtId.Text = oDataRow("BOOK_ID").ToString
                        TxtName.Text = oDataRow("BOOK_DESC").ToString

                        txtPrefix.Text = oDataRow("PREFIX").ToString



                        txtId.Enabled = False

                    End If
                End With

                oDataRow = Nothing
                x = Nothing




            Catch ex As Exception

            End Try


        End If




    End Sub

    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        saveData()


    End Sub

    Private Sub saveData()

        Try


            If txtId.Enabled Then

                If txtId.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_id, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtPrefix.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_prefix_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If TxtName.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

                Dim sql As String
                sql = "insert into MBOOK("
                sql += "BOOK_DESC,"
                sql += "PREFIX)"
                sql += " VALUES('"
                sql += TxtName.Text & "','"
                sql += txtPrefix.Text & "')"
                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)

                If ret > 0 Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อย")

                End If

            Else

                Dim sql As String
                sql = "UPDATE MBOOK SET "
                sql += "BOOK_DESC='" & TxtName.Text & "',"
                sql += "PREFIX='" & txtPrefix.Text & "'"
                sql += " WHERE BOOK_ID ='" & txtId.Text & "'"

                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)

                If ret > 0 Then

                    MsgBox("อัพเดทข้อมูลเรียบร้อย")

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

        clearText()


    End Sub

    Private Sub clearText()

        txtId.Text = ""
        TxtName.Text = ""
        txtPrefix.Text = ""


    End Sub


End Class