Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UnameTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("hãy nhập tên đăng nhập và mật khẩu")
        ElseIf UnameTb.Text = "admin" And PasswordTb.Text = "123456" Then
            Dim Obj = New items
            Obj.Show()
            Me.Hide()
        Else
            MsgBox("Điền sai tên hoặc mật khẩu")
            UnameTb.Text = ""
            PasswordTb.Text = ""
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim Obj = New Orders
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()

    End Sub

    Private Sub PasswordTb_TextChanged(sender As Object, e As EventArgs) Handles PasswordTb.TextChanged
        PasswordTb.PasswordChar = "*"
        PasswordTb.UseSystemPasswordChar = False

    End Sub

    Private Sub UnameTb_TextChanged(sender As Object, e As EventArgs) Handles UnameTb.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
