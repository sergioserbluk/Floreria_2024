<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas
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
        Me.ComboBoxUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxProductos = New System.Windows.Forms.ComboBox()
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox()
        Me.ListViewCarrito = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxUsuarios
        '
        Me.ComboBoxUsuarios.FormattingEnabled = True
        Me.ComboBoxUsuarios.Location = New System.Drawing.Point(203, 57)
        Me.ComboBoxUsuarios.Name = "ComboBoxUsuarios"
        Me.ComboBoxUsuarios.Size = New System.Drawing.Size(243, 24)
        Me.ComboBoxUsuarios.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Producto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(335, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cantidad"
        '
        'ComboBoxProductos
        '
        Me.ComboBoxProductos.FormattingEnabled = True
        Me.ComboBoxProductos.Location = New System.Drawing.Point(152, 130)
        Me.ComboBoxProductos.Name = "ComboBoxProductos"
        Me.ComboBoxProductos.Size = New System.Drawing.Size(121, 24)
        Me.ComboBoxProductos.TabIndex = 4
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Location = New System.Drawing.Point(434, 126)
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxCantidad.TabIndex = 5
        '
        'ListViewCarrito
        '
        Me.ListViewCarrito.HideSelection = False
        Me.ListViewCarrito.Location = New System.Drawing.Point(6, 21)
        Me.ListViewCarrito.Name = "ListViewCarrito"
        Me.ListViewCarrito.Size = New System.Drawing.Size(704, 259)
        Me.ListViewCarrito.TabIndex = 6
        Me.ListViewCarrito.UseCompatibleStateImageBehavior = False
        Me.ListViewCarrito.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LabelTotal)
        Me.GroupBox1.Controls.Add(Me.ListViewCarrito)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 191)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(768, 346)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Carrito"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(569, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Total $:"
        '
        'LabelTotal
        '
        Me.LabelTotal.AutoSize = True
        Me.LabelTotal.Location = New System.Drawing.Point(674, 308)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(14, 16)
        Me.LabelTotal.TabIndex = 7
        Me.LabelTotal.Text = "0"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(355, 543)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 47)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Finalizar la venta"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(746, 617)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Salir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(585, 126)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 59)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Agregar al carrito"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(331, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 37)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Ventas"
        '
        'Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 662)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBoxCantidad)
        Me.Controls.Add(Me.ComboBoxProductos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxUsuarios)
        Me.Name = "Ventas"
        Me.Text = "Ventas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBoxUsuarios As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxProductos As ComboBox
    Friend WithEvents TextBoxCantidad As TextBox
    Friend WithEvents ListViewCarrito As ListView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelTotal As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
End Class
