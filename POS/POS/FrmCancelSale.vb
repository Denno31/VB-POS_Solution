Public Class FrmCancelSale

    Private m_ReturnQty As Double

    Public Property ReturnQty() As Double
        Get
            Return m_ReturnQty
        End Get
        Set(ByVal value As Double)
            m_ReturnQty = txtReturnQty.Text.Trim
        End Set
    End Property


    Private m_Name As String
    Public Property _Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property


    Private m_qty As Integer
    Public Property Qty() As Integer
        Get
            Return m_qty
        End Get
        Set(ByVal value As Integer)
            m_qty = value
        End Set
    End Property

    Private Sub frmCancelSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtReturnQty.Text = m_qty
        Me.txtName.Text = m_Name
        Me.txtQty.Text = m_qty
    End Sub



    Public Function ret(ByVal str As String) As Double
        Return str
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtReturnQty.Text = "" Then
            MsgBox("กรุณาป้อนจำนวนที่คืน")
            Exit Sub
        End If
        If IsNumeric(txtReturnQty.Text.Trim) = False Then
            MsgBox("กรุณาป้อนตัวเลข")
            Exit Sub
        End If
        If CInt(txtQty.Text.Trim) < CInt(txtReturnQty.Text.Trim) Then
            MsgBox("จำนวนขายน้อยกว่าจำนวนที่เบิก")
            Exit Sub
        End If

        m_ReturnQty = CType(txtReturnQty.Text.Trim, Double)

        Me.Close()
    End Sub

    Private Sub txtReturnQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnQty.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnOK_Click(Me.btnOK, e)
        End If

    End Sub
End Class