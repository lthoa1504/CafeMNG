<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewOrders
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OrdersDGV = New System.Windows.Forms.DataGridView()
        CType(Me.OrdersDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(255, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(297, 41)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Danh sách đặt hàng"
        '
        'OrdersDGV
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.HotPink
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrdersDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.OrdersDGV.BackgroundColor = System.Drawing.Color.White
        Me.OrdersDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OrdersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrdersDGV.Location = New System.Drawing.Point(30, 68)
        Me.OrdersDGV.Name = "OrdersDGV"
        Me.OrdersDGV.RowHeadersWidth = 62
        Me.OrdersDGV.RowTemplate.Height = 28
        Me.OrdersDGV.Size = New System.Drawing.Size(753, 488)
        Me.OrdersDGV.TabIndex = 23
        '
        'ViewOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkTurquoise
        Me.ClientSize = New System.Drawing.Size(808, 586)
        Me.Controls.Add(Me.OrdersDGV)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ViewOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewOrders"
        CType(Me.OrdersDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents OrdersDGV As DataGridView
End Class
