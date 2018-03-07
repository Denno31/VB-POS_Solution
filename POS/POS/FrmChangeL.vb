Public Class FrmChangeL



    Dim ds As New DataSet

    Private Sub initGrdMain()


        grdMain.DataSource = DBNull.Value
        If grdMain.ColumnCount > 0 Then
            grdMain.Columns.RemoveAt(0)
        End If
        Dim D1, D2 As String

        D1 = dateStart.Value.ToString("yyyy-MM-dd")
        D2 = DateEnd.Value.ToString("yyyy-MM-dd")

        Dim Sql As String = "SELECT DocNo,sum(totalprice) as totalprice,sum(totalprice) * 0.07 as tax,name,tax_id,DocDate FROM vReceive GROUP BY DocNo,name,TAX_ID,docdate  having (DocDate > '" & D1 & "' and DocDate < '" & D2 & "')"
        ds = oService.getDataSet(Sql)
        grdMain.DataSource = ds.Tables(0)

        Dim chk As New DataGridViewCheckBoxColumn()
        grdMain.Columns.Add(chk)
        chk.HeaderText = "Check Data"
        chk.Name = "chk"
        lblTotalData.Text = ds.Tables(0).Rows.Count





    End Sub


    Private Sub FrmChangeL_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click


        Dim sql As String
        Dim Docname As String
        Dim DocDate As String
        Dim tmp As String
        For i As Integer = 0 To (grdMain.Rows.Count - 1)

            Dim c As Boolean
            c = grdMain.Rows(i).Cells("chk").Value
            If c = True Then

                Docname = grdMain.Rows(i).Cells(0).Value
                DocDate = grdMain.Rows(i).Cells("Docdate").Value
                tmp = CDate(DocDate).AddMonths(1).ToString("yyyy-MM-dd")
                sql += "Update TB_REC_HD SET DOCDATE = '" & tmp & "' WHERE DocNo='" & Docname & "';" & vbCrLf
            End If
        Next
        changeL(sql)

    End Sub


    Private Sub changeL(sql As String)

        Dim ret As Int16
        ret = oService.ExecCommandRowRet(sql)
        If ret > 0 Then
            MsgBox("อัพเดทสำเร็จ " & ret & " รายการ")
            initGrdMain()
        End If
    End Sub



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        initGrdMain()

    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click

        Dim frm As New Report_POInputTax
        frm.m_dt = ds.Tables(0)
        frm.dateStart = dateStart.Value
        frm.dateEnd = DateEnd.Value
        frm.Show()

    End Sub
End Class