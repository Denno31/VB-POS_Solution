Public Class FrmQuotation


    Dim oDataset As DataSet
    Dim oDT As DataTable
    Dim clsLang As New clsLangMsg
    Dim m_StockOnHand As New Model.Sale.M_Stock_OnHand
    Dim stock_criteria As New Model.Criteria.Sale.M_Stock_OnHand
    Dim m_saleSlipTran_criteria As New Model.Criteria.Sale.M_SaleSlip_Tran
    Public clsSetting As New mySetting(mySetting.Config.ApplicationFile)

    Private m_customer As New Model.Sale.M_Customer



    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Dim _clsSave As New clsSaveData
        _clsSave.Insert("", "")

    End Sub

    Private Sub lblOther_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblOther.LinkClicked
        If Not FrmQoutationOther Is Nothing Then FrmQoutationOther.Close()
        FrmQoutationOther.ShowDialog()


    End Sub

    Private Sub cmdItem_Click(sender As Object, e As EventArgs) Handles cmdItem.Click

        Dim x As New clsFind
        Dim oDataRow As DataRow = Nothing
        With x
            '.setConstring(clsSetting.GetSetting("ConString", ""))
            .setTableName(clsLang.msg_iss_type)
            .setCriteriaStockOnHand(stock_criteria)
            ' .setSQL("SELECT ItemNO,ItemName,ItemType,TypeName,ItemGroup,FullName,ItemPrice from vItemMaster")
            .setColumnDesc(clsLang.msg_id & "," & clsLang.msg_name & ",ราคารวม,จำนวน")
            .setColumnWidth("100,400,0,250,0,250,0")
            .OpenFindStockOnHand()
            oDataRow = .getDatarow
            If oDataRow Is Nothing = False Then
                'MessageBox.Show(x.Item(0).ToString, mClsLang.msg_testing, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtItemNo.Text = oDataRow(0).ToString
                txtItemNo.Tag = ""
                txtItemName.Text = oDataRow(0).ToString & " : " & oDataRow(1).ToString
                txtStockOnHand.Text = "1"
                txtUnitPrice.Text = oDataRow(2).ToString
                '     Call CalTotalPrice()
                Call cmdSave_Click(sender, e)
                'txtTypeId.Text = oDataRow(2).ToString
                'txtTypeName.Text = oDataRow(3).ToString
                'txtId.Enabled = False
            End If
        End With

        oDataRow = Nothing
        x = Nothing
    End Sub
End Class