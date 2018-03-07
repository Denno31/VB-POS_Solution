Public Class FrmReportMember

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

        Dim dtMap As DataTable
        Dim dr As DataRow
        dtMap = New DataTable("Member")

        dtMap.Columns.Add(New DataColumn("id", GetType(String)))
        dtMap.Columns.Add(New DataColumn("Barcode", GetType(System.Byte())))
        dtMap.Columns.Add(New DataColumn("title", GetType(String)))
        dtMap.Columns.Add(New DataColumn("name", GetType(String)))



    End Sub
End Class