Public Class FrmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click


        Dim sql As String
        sql = "Select * From TB_ACCOUNT WHERE username = '" & txtUsername.Text & "' AND password='" & txtPassword.Text & "'"
        Dim ds As New DataSet
        ds = oService.getDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then

            User = ds.Tables(0).Rows(0)("name").ToString
            Level = ds.Tables(0).Rows(0)("level").ToString
            FrmMain.Show()

        Else

            MsgBox("ไม่พบ Account นี้")
        End If

        Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

   
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class
