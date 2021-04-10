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
        DisplayItem()

    End Sub
    Private Sub DisplayItem()
        Con.Open()
        Dim query = "select * from  ItemTbl"
        Dim cmd = New SqlCommand(query, Con)
        Dim adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        builder = New SqlCommandBuilder(adapter)
        Dim ds = New DataSet()
        adapter.Fill(ds)
        ItemDGV.DataSource = ds.Tables(0)
        Con.Close()

    End Sub


    Dim key = 0
    Private Sub ItemDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ItemDGV.CellMouseClick
        Dim row As DataGridViewRow = ItemDGV.Rows(e.RowIndex)
        ItNameTb.Text = row.Cells(1).Value.ToString
        CatCb.SelectedValue = row.Cells(2).Value.ToString
        ItPriceTb.Text = row.Cells(3).Value.ToString
        QuantityTb.Text = row.Cells(4).Value.ToString
        If ItNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then
            MsgBox("Chọn sản phẩm cần xóa ")
        Else
            Con.Open()
            Dim query = "delete from ItemTbl where ItId=" & key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Xóa thành công")
            Con.Close()
            Reset()

        End If
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If CatCb.SelectedIndex = -1 Or ItNameTb.Text = "" Or ItPriceTb.Text = "" Or QuantityTb.Text = "" Then
            MsgBox("Chọn sản phẩm cần chỉnh sửa")
        Else
            Con.Open()
            Dim query = "Update ItemTbl set ItName='" & ItNameTb.Text & "',ItCat='" & CatCb.SelectedValue.ToString() & "', ItPrice=" & ItPriceTb.Text & ", ItQty=" & QuantityTb.Text & " where ItId = " & key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Chỉnh sửa thành công")
            Con.Close()
            Reset()

        End If
    End Sub

    Private Sub AddBtn_Click_1(sender As Object, e As EventArgs) Handles AddBtn.Click

        If CatCb.SelectedIndex = -1 Or ItNameTb.Text = "" Or ItPriceTb.Text = "" Or QuantityTb.Text = "" Then
            MsgBox("Thiếu thông tin!")
        Else
            Con.Open()
            Dim query = "insert into ItemTbl values('" & ItNameTb.Text & "','" & CatCb.SelectedValue.ToString() & "'," & ItPriceTb.Text & "," & QuantityTb.Text & ")"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Sản phẩm đã được thêm vào!")
            Con.Close()
            Reset()

        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim Obj = New Login
        Obj.Show()
        Me.Hide()

    End Sub

    Private Sub CatCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CatCb.SelectedIndexChanged

    End Sub
End Class