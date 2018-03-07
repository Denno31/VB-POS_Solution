Public Class PO


    Private _ObjDal As DAL.PO

    Sub New()
        _ObjDal = New DAL.PO
    End Sub


    Public Function getBook() As DataTable
        Return _ObjDal.getBOOK()
    End Function

End Class
