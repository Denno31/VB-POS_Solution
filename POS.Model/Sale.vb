


Public Class Sale



    Public Class M_Customer
        Public ID As String
        Public title As String
        Public name As String
        Public cr_limit As String
        Public cr_Day As String
    End Class



    Public Class M_Stock_OnHand
        Public PROD_CODE As String
        Public Cost As String
        Public ValueOnHand As String
        Public STK_OnHand As String

    End Class


    Public Class M_SaleSlip_Head
        Public cust_id As String
        Public SaleSlip_id As String
        Public description As String
        Public CreateDate As DateTime
        Public UpdateDate As DateTime
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
        Public CreateDate As DateTime
        Public UpdateDate As DateTime
    End Class





End Class
