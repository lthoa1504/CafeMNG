﻿Imports System.Data.SqlClient

Public Class Orders
    Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHPC\Documents\CafeVbDb.mdf;Integrated Security=True;Connect Timeout=30")



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim Obj = New Login
        Obj.Show()
        Me.Hide()
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
    Private Sub FilteByCategory()

        Dim query = "select * from  ItemTbl where ItCat='" & CatCb.SelectedValue.ToString() & "'"
        Dim cmd = New SqlCommand(query, Con)
        Dim adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        builder = New SqlCommandBuilder(adapter)
        Dim ds = New DataSet()
        adapter.Fill(ds)
        ItemDGV.DataSource = ds.Tables(0)
        Con.Close()

    End Sub

    Private Sub Orders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayItem()
        FillCategory()

    End Sub

    Private Sub CatCb_SelectedValueChanged(sender As Object, e As EventArgs) Handles CatCb.SelectedValueChanged
        FilteByCategory()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DisplayItem()

    End Sub
    Dim ProdName As String
    Dim i = 0, GrdTotal = 0, price, qty
    Private Sub AddBill()
        Con.Open()
        Dim query = "INSERT INTO OderTbl VALUES('" & DateTime.Today.Date & "'," & GrdTotal & ")"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("Bill đã được thêm !")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AddBill()
        PrintPreviewDialog1.Show()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("Cafe Cont", New Font("Time new roman", 22), Brushes.BlueViolet, 355, 35)
        e.Graphics.DrawString("-----Your Bill--", New Font("Time new roman", 14), Brushes.BlueViolet, 350, 60)

        Dim bm As New Bitmap(Me.BillDVG.Width, Me.BillDVG.Height)
        BillDVG.DrawToBitmap(bm, New Rectangle(0, 0, Me.BillDVG.Width, Me.BillDVG.Height))
        e.Graphics.DrawImage(bm, 0, 90)
        e.Graphics.DrawString("Total Amount" + GrdTotal.ToString(), New Font("Time new roman", 15), Brushes.Crimson, 325, 580)
        e.Graphics.DrawString("============Tks For Buying In out Cafe=========", New Font("Time new roman", 15), Brushes.Crimson, 130, 600)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Obj = New ViewOrders
        Obj.Show()
        ' Me.Hide()

    End Sub
    Private Sub UpdateItem()
        Try
            Dim newQty = stock - Convert.ToInt32(QuantityTb.Text)
            Con.Open()
            Dim query = "Update ItemTbl set ItQty=" & newQty & " where ItId = " & key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Chỉnh sửa thành công")
            Con.Close()
            DisplayItem()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub BillDVG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BillDVG.CellContentClick

    End Sub

    Private Sub AddBillBtn_Click(sender As Object, e As EventArgs) Handles AddBillBtn.Click
        If key = 0 Then
            MsgBox("chọn sản phẩm")
        ElseIf Convert.ToInt32(QuantityTb.Text) > stock Then
            MsgBox("Không đủ số lượng")
        Else
            Dim rnum As Integer = BillDVG.Rows.Add()
            Dim total = Convert.ToInt32(QuantityTb.Text) * price
            i = i + 1
            BillDVG.Rows.Item(rnum).Cells("Column1").Value = i
            BillDVG.Rows.Item(rnum).Cells("Column2").Value = ProdName
            BillDVG.Rows.Item(rnum).Cells("Column3").Value = price
            BillDVG.Rows.Item(rnum).Cells("Column4").Value = QuantityTb.Text
            BillDVG.Rows.Item(rnum).Cells("Column5").Value = total
            GrdTotal = GrdTotal + total
            TotalLbl.Text = "" + Convert.ToString(GrdTotal)
            UpdateItem()
            QuantityTb.Text = ""
            key = 0
        End If
    End Sub

    Dim key = 0, stock
    Private Sub ItemDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ItemDGV.CellMouseClick
        Dim row As DataGridViewRow = ItemDGV.Rows(e.RowIndex)
        ProdName = row.Cells(1).Value.ToString

        If ProdName = "" Then
            key = 0
            stock = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
            stock = Convert.ToInt32(row.Cells(4).Value.ToString)
            price = Convert.ToInt32(row.Cells(3).Value.ToString)
        End If
    End Sub

End Class