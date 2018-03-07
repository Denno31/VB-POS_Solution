Public Class FrmPromotion

    Dim oDataset As DataSet
    Dim clsLang As New clsLangMsg


    Private Sub lblId_Click(sender As Object, e As EventArgs) Handles lblId.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateStart.ValueChanged

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click



        saveData()


    End Sub


    Private Sub saveData()

        Try

            Dim obj As New POS.Model.Cust.M_Customer

            Dim bl As Int16

            If cbActive.Text = "YES" Then
                bl = 1
            Else
                bl = 0
            End If


            If txtID.Enabled Then
                If txtDescription.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_id, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If txtRate.Text.Trim = "" Then MessageBox.Show(clsLang.msg_data_not_complete & " : " & clsLang.msg_prefix_name, clsLang.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub



                Dim sql As String


                sql = "insert into N_PROMOTION("
                sql += "Description,"
                sql += "value_bath,"
                sql += "Date_Start,"
                sql += "Date_End,"
                sql += "Active)"


                sql += "VALUES('"
                sql += txtDescription.Text & "',"
                sql += txtRate.Text & ",'"
                sql += DateStart.Value.ToString("yyyy/MM/dd hh:mm:ss") & "','"
                sql += DateEnd.Value.ToString("yyyy/MM/dd hh:mm:ss") & "',"
                sql += bl & ")"



                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)
                MsgBox(ret)


            Else




                Dim sql As String
                sql = "UPDATE n_PROMOTION SET "
                sql += "DESCRIPTION='" & txtDescription.Text & "',"
                sql += "VALUE_BATH=" & txtRate.Text & ","
                sql += "DATE_START='" & DateStart.Value.ToString("yyyy/MM/dd hh:mm:ss") & "',"
                sql += "DATE_END='" & DateEnd.Value.ToString("yyyy/MM/dd hh:mm:ss") & "',"
                sql += "ACTIVE=" & bl
                sql += "  WHERE PROMOTION_ID=" & txtID.Text

                Dim ret As Int16
                ret = oService.ExecCommandRowRet(sql)
                MsgBox(ret)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cbActive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbActive.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged

    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescription.KeyDown

        If e.KeyCode = Keys.Enter Then

            txtDescription_Click(sender, Nothing)
        End If


    End Sub

    Private Sub txtDescription_Click(sender As Object, e As EventArgs) Handles txtDescription.Click

        Try

            Dim x As New clsFind
            Dim oDataRow As DataRow = Nothing
            With x
                '.setConstring(clsSetting.GetSetting("ConString", ""))
                .setTableName(clsLang.msg_iss_type)
                .setSQL("SELECT * from n_promotion where promotion_id like '" & txtDescription.Text & "%'")
                .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name)
                .setColumnWidth("100,200")
                .OpenFind()
                oDataRow = .getDatarow
                If oDataRow Is Nothing = False Then

                    txtID.Text = oDataRow("promotion_id").ToString
                    txtDescription.Text = oDataRow("Description").ToString
                    txtRate.Text = oDataRow("value_bath").ToString
                    DateStart.Text = oDataRow("date_start").ToString
                    DateEnd.Text = oDataRow("date_end").ToString

                    Dim tmp As Boolean
                    tmp = oDataRow("active").ToString
                    If tmp = True Then
                        cbActive.Text = "YES"
                    Else
                        cbActive.Text = "NO"
                    End If





              
                    txtID.Enabled = False

                End If
            End With

            oDataRow = Nothing
            x = Nothing




        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub
End Class