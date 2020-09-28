<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlVentas
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlVentas))
        Me.Panel31 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.labelventaTotal = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Panel31.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel25.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel31
        '
        Me.Panel31.Controls.Add(Me.Panel2)
        Me.Panel31.Controls.Add(Me.Panel25)
        Me.Panel31.Controls.Add(Me.Panel27)
        Me.Panel31.Controls.Add(Me.Panel26)
        Me.Panel31.Location = New System.Drawing.Point(3, 3)
        Me.Panel31.Name = "Panel31"
        Me.Panel31.Size = New System.Drawing.Size(682, 366)
        Me.Panel31.TabIndex = 785
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.labelventaTotal)
        Me.Panel2.Controls.Add(Me.Label41)
        Me.Panel2.Controls.Add(Me.Label42)
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel2.Location = New System.Drawing.Point(24, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(140, 100)
        Me.Panel2.TabIndex = 715
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(15, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 14)
        Me.Label7.TabIndex = 693
        Me.Label7.Text = "VENTAS"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelventaTotal
        '
        Me.labelventaTotal.BackColor = System.Drawing.Color.Transparent
        Me.labelventaTotal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelventaTotal.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelventaTotal.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelventaTotal.ForeColor = System.Drawing.Color.White
        Me.labelventaTotal.Image = CType(resources.GetObject("labelventaTotal.Image"), System.Drawing.Image)
        Me.labelventaTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.labelventaTotal.Location = New System.Drawing.Point(15, 0)
        Me.labelventaTotal.Name = "labelventaTotal"
        Me.labelventaTotal.Size = New System.Drawing.Size(125, 43)
        Me.labelventaTotal.TabIndex = 56
        Me.labelventaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label41.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(15, 57)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(125, 43)
        Me.Label41.TabIndex = 692
        Me.Label41.Text = "S/. 0.00"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label42.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(0, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(15, 100)
        Me.Label42.TabIndex = 694
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Panel25.BackgroundImage = CType(resources.GetObject("Panel25.BackgroundImage"), System.Drawing.Image)
        Me.Panel25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel25.Controls.Add(Me.Label43)
        Me.Panel25.Controls.Add(Me.Label44)
        Me.Panel25.Controls.Add(Me.Label45)
        Me.Panel25.Controls.Add(Me.Label46)
        Me.Panel25.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel25.Location = New System.Drawing.Point(24, 218)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(140, 100)
        Me.Panel25.TabIndex = 781
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label43.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label43.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(15, 43)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(125, 14)
        Me.Label43.TabIndex = 693
        Me.Label43.Text = "ANTICIPOS RECIBIDOS"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label44.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label44.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Image = CType(resources.GetObject("Label44.Image"), System.Drawing.Image)
        Me.Label44.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label44.Location = New System.Drawing.Point(15, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(125, 43)
        Me.Label44.TabIndex = 56
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label45.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(15, 57)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(125, 43)
        Me.Label45.TabIndex = 692
        Me.Label45.Text = "S/. 0.00"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label46.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label46.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(0, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(15, 100)
        Me.Label46.TabIndex = 694
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Panel27.BackgroundImage = CType(resources.GetObject("Panel27.BackgroundImage"), System.Drawing.Image)
        Me.Panel27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel27.Controls.Add(Me.Label51)
        Me.Panel27.Controls.Add(Me.Label52)
        Me.Panel27.Controls.Add(Me.Label53)
        Me.Panel27.Controls.Add(Me.Label54)
        Me.Panel27.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel27.Location = New System.Drawing.Point(23, 321)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(140, 100)
        Me.Panel27.TabIndex = 783
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label51.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label51.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(15, 43)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(125, 14)
        Me.Label51.TabIndex = 693
        Me.Label51.Text = "ANTICIPOS RECIBIDOS"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label52.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label52.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Image = CType(resources.GetObject("Label52.Image"), System.Drawing.Image)
        Me.Label52.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label52.Location = New System.Drawing.Point(15, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(125, 43)
        Me.Label52.TabIndex = 56
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label53.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label53.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label53.ForeColor = System.Drawing.Color.White
        Me.Label53.Location = New System.Drawing.Point(15, 57)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(125, 43)
        Me.Label53.TabIndex = 692
        Me.Label53.Text = "S/. 0.00"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label54.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label54.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.ForeColor = System.Drawing.Color.White
        Me.Label54.Location = New System.Drawing.Point(0, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(15, 100)
        Me.Label54.TabIndex = 694
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Panel26.BackgroundImage = CType(resources.GetObject("Panel26.BackgroundImage"), System.Drawing.Image)
        Me.Panel26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel26.Controls.Add(Me.Label47)
        Me.Panel26.Controls.Add(Me.Label48)
        Me.Panel26.Controls.Add(Me.Label49)
        Me.Panel26.Controls.Add(Me.Label50)
        Me.Panel26.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel26.Location = New System.Drawing.Point(24, 115)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(140, 100)
        Me.Panel26.TabIndex = 782
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label47.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label47.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(15, 43)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(125, 14)
        Me.Label47.TabIndex = 693
        Me.Label47.Text = "CUENTAS X COBRAR"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label48.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Image = CType(resources.GetObject("Label48.Image"), System.Drawing.Image)
        Me.Label48.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label48.Location = New System.Drawing.Point(15, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(125, 43)
        Me.Label48.TabIndex = 56
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label49.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label49.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(15, 57)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(125, 43)
        Me.Label49.TabIndex = 692
        Me.Label49.Text = "S/. 0.00"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label50.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label50.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(0, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(15, 100)
        Me.Label50.TabIndex = 694
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ControlVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel31)
        Me.Name = "ControlVentas"
        Me.Size = New System.Drawing.Size(756, 372)
        Me.Panel31.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.Panel27.ResumeLayout(False)
        Me.Panel26.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel31 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents labelventaTotal As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Panel25 As Panel
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel26 As Panel
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
End Class
