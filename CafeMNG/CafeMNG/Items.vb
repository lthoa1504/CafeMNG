Imports System.Data.SqlClient
Public Class items


    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHPC\Documents\CafeVbDb.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CatTb.Text = "" Then
            MsgBox("Hãy nhập danh mục!")
        Else
            Con.Open()
            Dim query = "insert into CategoryTbl values('" & CatTb.Text & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Danh mục đã được thêm vào!")
            Con.Close()
            CatTb.Text = ""
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub
    Private Sub Reset()
        ItNameTb.Text = ""
        CatCb.SelectedIndex = 0
        QuantityTb.Text = ""
        ItPriceTb.Text = ""
    End Sub
    Private Sub FillCategory()
        Con.Open()
        Dim cmd = New SqlCommand("select * From CategoryTbl", Con)
        Dim adapter = New SqlDataAdapter(cmd)
        Dim Tbl = New DataTable()
        adapter.Fill(Tbl)
        CatCb.DataSource = Tbl
        CatCb.DisplayMember = "CatName"
        CatCb.ValueMember = "CatName"
        Con.Close()
    End Sub
    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    Private Sub items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCategory()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub




End Class