Public Class FrmChkReceive

    Private Sub FrmChkReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initDataGridHead()




    End Sub


    Private Sub initDataGridHead()

        Dim sql As String
        sql = "Select [DocNo]  ,[DocDate],[ModifyDate],[ModifyBy] From TB_REC_HD WHERE SUSCESS = 0 order by modifyDate"
        Dim dt As DataTable
        Dim ds As New DataSet
        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)


        DG.DataSource = dt
        DG.Columns("Docno").ReadOnly = True
        DG.Columns("DocDate").ReadOnly = True
        DG.Columns("ModifyDate").ReadOnly = True
        DG.Columns("ModifyBy").ReadOnly = True


    End Sub





    Private Sub initDataGridHead(docNo As String)

        Dim sql As String
        sql = "Select [DocNo],[ItemNo], [ItemName],[RecQty],[BalanceQty],[RECEIVE] = 0 ,[UnitPrice],[TotalPrice],[ModifyBy],[ModifyDate] "
        sql += " From TB_REC_DT WHERE DocNo = '" & docNo & "'"
        Dim dt As DataTable
        Dim ds As New DataSet
        ds = oService.getDataSet(sql)
        dt = ds.Tables(0)


        DGDetail.DataSource = dt


        DGDetail.Columns("DocNo").ReadOnly = True
        DGDetail.Columns("ItemNo").ReadOnly = True
        DGDetail.Columns("ItemName").ReadOnly = True
        DGDetail.Columns("RecQTY").ReadOnly = True
        DGDetail.Columns("BalanceQty").ReadOnly = True
        DGDetail.Columns("RECEIVE").ReadOnly = True



        If DGDetail.RowCount > -1 Then

            For Each row As DataGridViewRow In DGDetail.Rows
                If Not row.IsNewRow Then


                    If row.Cells("RecQty").Value.ToString > row.Cells("BalanceQTY").Value.ToString Then
                        row.Cells("RECEIVE").ReadOnly = False
                        row.Cells("RECEIVE").Style.BackColor = Color.Green
                    End If


                End If
            Next


        End If


    End Sub




    Private Sub DG_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellClick


        If e.RowIndex > -1 Then '// Edit

            initDataGridHead(DG.Item("Docno", e.RowIndex).Value.ToString)

        End If
    End Sub

    Private Sub DG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellContentClick


    End Sub

    Private Sub DG_RowEnter(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DG.RowEnter


    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        saveData()

    End Sub


    Private Sub saveData()


        If DGDetail.RowCount > -1 Then

            For Each row As DataGridViewRow In DGDetail.Rows
                If Not row.IsNewRow Then
                    '   MessageBox.Show(row.Cells(0).Value.ToString & "," & row.Cells(1).Value.ToString)

                    Dim qty As Int16
                    qty = row.Cells("RECEIVE").Value.ToString
                    upDateStock(row.Cells("ITEMNO").Value.ToString, qty, row.Cells("DocNo").Value.ToString)


                End If
            Next

        End If

    End Sub


    Private Sub DGDetail_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetail.CellValueChanged


        If e.RowIndex > -1 Then '// Edit


            Dim rec, balance, receive, tmpRec As Int16
            rec = DGDetail.Item("RECQTY", e.RowIndex).Value.ToString()
            balance = DGDetail.Item("balanceQTY", e.RowIndex).Value.ToString()
            receive = DGDetail.Item("RECEIVE", e.RowIndex).Value.ToString()

            tmpRec = rec - balance

            If receive > tmpRec Then
                MsgBox("มีข้อผิดพลาด -รับสินค้ามากกว่าจำนวนที่สั่ง")
                DGDetail.Item("RECEIVE", e.RowIndex).Value = 0

            End If

        End If

    End Sub



    Private Sub upDateStock(CODE As String, QTY As Int16, DocNo As String)

        Dim sql As String
        sql = "Update MPRODUCT SET LAST_QTY = LAST_QTY + " & QTY & " WHERE CODE = '" & CODE & "';" & vbCrLf
        sql += "Update TB_REC_DT SET BalanceQTY = BalanceQTY +  " & QTY & " where ITEMNO ='" & CODE & "' AND DocNo='" & DocNo & "'"
        Dim ret As Int16
        ret = oService.ExecCommandRowRet(sql)

        MsgBox(ret)

    End Sub



End Class