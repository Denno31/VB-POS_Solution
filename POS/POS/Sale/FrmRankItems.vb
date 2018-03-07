Public Class FrmRankItems

    Private Sub FrmRankItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        initData()

    End Sub


    Private Sub initData()

        Try


            'Rank
            Dim sql As String
            sql = "select prod_code,count(prod_code) as count_ from [N_CUST_SALE_SLIP_TRAN] group by PROD_CODE order by count_ desc"
            Dim ds As New DataSet
            Dim dt As DataTable
            ds = oService.getDataSet(sql)
            dt = ds.Tables(0)

            'MIN


            sql = "Select CODE,NAME,MIN,MAX,LAST_QTY FROM MPRODUCT WHERE LAST_QTY < MIN"

            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            ds2 = oService.getDataSet(sql)
            dt2 = ds.Tables(0)



        Catch ex As Exception

        End Try




    End Sub
End Class