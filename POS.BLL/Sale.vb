



Public Class Sale

    Private _ObjDal As DAL.Sale

    Sub New()
        _ObjDal = New DAL.Sale
    End Sub


    Public Function getCustomer(criteria As Model.Criteria.Sale.M_Customer) As DataTable
        Return _ObjDal.getCustomer(criteria)
    End Function

    Public Function getStockOnHand(criteria As Model.Criteria.Sale.M_Stock_OnHand) As DataTable
        Return _ObjDal.getStock_OnHand(criteria)
    End Function

    Public Function getMProduct(criteria As Model.Criteria.Sale.M_Stock_OnHand) As DataTable
        Return _ObjDal.getMProduct(criteria)
    End Function

    Public Function getSaleSlip_Head_Running(criteria As Model.Criteria.Sale.M_SaleSlip_Head) As DataTable
        Return _ObjDal.getSaleSlip_Head_Running(criteria)
    End Function

    Public Function getSaleSlip_Head_Doc(criteria As Model.Criteria.Sale.M_SaleSlip_Head) As DataTable
        Return _ObjDal.getSaleSlip_Head_Doc(criteria)
    End Function


    Public Function getSaleSlip_Head(criteria As Model.Criteria.Sale.M_SaleSlip_Head) As DataTable
        Return _ObjDal.getSaleSlip_Head(criteria)
    End Function

    Public Function getSaleSlip_Tran(criteria As Model.Criteria.Sale.M_SaleSlip_Tran) As DataTable
        Return _ObjDal.getSaleSlip_Tran(criteria)
    End Function


    Public Function SaleSlip_Head_Save(criteria As Model.Criteria.Sale.M_SaleSlip_Head, action As String) As Int16
        Return _ObjDal.SaleSlip_Head_Save(criteria, action)
    End Function

    Public Function SaleSlip_Tran_Save(criteria As Model.Criteria.Sale.M_SaleSlip_Tran, action As String) As Int16
        Return _ObjDal.SaleSlip_Tran_Save(criteria, action)
    End Function

End Class
