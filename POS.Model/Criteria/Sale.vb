

Namespace Criteria

    Public Class Sale

        Public Class M_Customer
            Public ID As String
        End Class

        Public Class M_Stock_OnHand
            Public PROD_CODE As String
        End Class


        Public Class M_SaleSlip_Head
            Public cust_id As String
            Public SaleSlip_id As String
            Public description As String
            Public CreateDate As String
            Public UpdateDate As String
            Public Sales_id As String
        End Class


        Public Class M_SaleSlip_Tran
            Public cust_id As String
            Public SaleSlip_id As String
            Public Detail As String
            Public Stk_id As String
            Public id As Int16
            Public Prod_code As String
            Public Qty As String
            Public price As Decimal
            Public amount As Decimal
            Public CreateDate As String
            Public UpdateDate As String
        End Class

    End Class
End Namespace
