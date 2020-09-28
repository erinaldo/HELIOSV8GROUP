<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAnularPasaje
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAnularPasaje))
        Me.pnBuscardor = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAsiento = New System.Windows.Forms.Button()
        Me.lblAsientoEncontrado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporte = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombrePasajero = New System.Windows.Forms.TextBox()
        Me.txtEdad = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAsiento = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnBuscardor.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAsiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnBuscardor
        '
        Me.pnBuscardor.Controls.Add(Me.GradientPanel1)
        Me.pnBuscardor.Controls.Add(Me.GroupBox1)
        Me.pnBuscardor.Controls.Add(Me.lblAsiento)
        Me.pnBuscardor.Controls.Add(Me.Label2)
        Me.pnBuscardor.Controls.Add(Me.GradientPanel2)
        Me.pnBuscardor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBuscardor.Location = New System.Drawing.Point(0, 0)
        Me.pnBuscardor.Name = "pnBuscardor"
        Me.pnBuscardor.Size = New System.Drawing.Size(583, 395)
        Me.pnBuscardor.TabIndex = 692
        Me.pnBuscardor.Visible = False
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GradientPanel1.Location = New System.Drawing.Point(273, 12)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(119, 30)
        Me.GradientPanel1.TabIndex = 707
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(117, 28)
        Me.ButtonAdv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonAdv2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.White
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(117, 28)
        Me.ButtonAdv2.TabIndex = 53
        Me.ButtonAdv2.Text = "BUSCAR"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAsiento)
        Me.GroupBox1.Controls.Add(Me.lblAsientoEncontrado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDestino)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtOrigen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtImporte)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNombrePasajero)
        Me.GroupBox1.Controls.Add(Me.txtEdad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(561, 260)
        Me.GroupBox1.TabIndex = 703
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles de Pasaje"
        '
        'btnAsiento
        '
        Me.btnAsiento.AutoEllipsis = True
        Me.btnAsiento.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAsiento.BackgroundImage = CType(resources.GetObject("btnAsiento.BackgroundImage"), System.Drawing.Image)
        Me.btnAsiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAsiento.FlatAppearance.BorderSize = 0
        Me.btnAsiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAsiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsiento.Font = New System.Drawing.Font("Arial Narrow", 20.0!, System.Drawing.FontStyle.Bold)
        Me.btnAsiento.ForeColor = System.Drawing.Color.White
        Me.btnAsiento.Location = New System.Drawing.Point(449, 106)
        Me.btnAsiento.Name = "btnAsiento"
        Me.btnAsiento.Size = New System.Drawing.Size(97, 69)
        Me.btnAsiento.TabIndex = 706
        Me.btnAsiento.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnAsiento.UseVisualStyleBackColor = True
        '
        'lblAsientoEncontrado
        '
        Me.lblAsientoEncontrado.BackColor = System.Drawing.Color.Transparent
        Me.lblAsientoEncontrado.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!)
        Me.lblAsientoEncontrado.ForeColor = System.Drawing.Color.Maroon
        Me.lblAsientoEncontrado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAsientoEncontrado.Location = New System.Drawing.Point(461, 178)
        Me.lblAsientoEncontrado.Name = "lblAsientoEncontrado"
        Me.lblAsientoEncontrado.Size = New System.Drawing.Size(82, 21)
        Me.lblAsientoEncontrado.TabIndex = 705
        Me.lblAsientoEncontrado.Text = "ASIENTO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(37, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 21)
        Me.Label6.TabIndex = 706
        Me.Label6.Text = "Destino:"
        '
        'txtDestino
        '
        Me.txtDestino.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtDestino.Location = New System.Drawing.Point(115, 170)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(267, 30)
        Me.txtDestino.TabIndex = 705
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(45, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 21)
        Me.Label5.TabIndex = 704
        Me.Label5.Text = "Origen:"
        '
        'txtOrigen
        '
        Me.txtOrigen.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtOrigen.Location = New System.Drawing.Point(115, 125)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(267, 30)
        Me.txtOrigen.TabIndex = 703
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(28, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 21)
        Me.Label3.TabIndex = 698
        Me.Label3.Text = "Pasajero:"
        '
        'txtImporte
        '
        Me.txtImporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtImporte.BeforeTouchSize = New System.Drawing.Size(174, 30)
        Me.txtImporte.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporte.DecimalPlaces = 2
        Me.txtImporte.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtImporte.ForeColor = System.Drawing.Color.Black
        Me.txtImporte.Location = New System.Drawing.Point(115, 216)
        Me.txtImporte.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtImporte.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(174, 30)
        Me.txtImporte.TabIndex = 702
        Me.txtImporte.TabStop = False
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtImporte.ThousandsSeparator = True
        Me.txtImporte.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.GradientPanel2.Location = New System.Drawing.Point(150, 333)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(283, 45)
        Me.GradientPanel2.TabIndex = 522
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(281, 43)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold)
        Me.ButtonAdv1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.White
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(281, 43)
        Me.ButtonAdv1.TabIndex = 53
        Me.ButtonAdv1.Text = "ANULAR"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(36, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 21)
        Me.Label4.TabIndex = 701
        Me.Label4.Text = "Importe:"
        '
        'txtNombrePasajero
        '
        Me.txtNombrePasajero.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtNombrePasajero.Location = New System.Drawing.Point(115, 30)
        Me.txtNombrePasajero.Name = "txtNombrePasajero"
        Me.txtNombrePasajero.Size = New System.Drawing.Size(431, 30)
        Me.txtNombrePasajero.TabIndex = 695
        '
        'txtEdad
        '
        Me.txtEdad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtEdad.BeforeTouchSize = New System.Drawing.Size(119, 30)
        Me.txtEdad.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEdad.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtEdad.ForeColor = System.Drawing.Color.Black
        Me.txtEdad.Location = New System.Drawing.Point(115, 79)
        Me.txtEdad.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtEdad.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.Size = New System.Drawing.Size(119, 30)
        Me.txtEdad.TabIndex = 700
        Me.txtEdad.TabStop = False
        Me.txtEdad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEdad.ThousandsSeparator = True
        Me.txtEdad.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(57, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 21)
        Me.Label1.TabIndex = 699
        Me.Label1.Text = "Edad:"
        '
        'lblAsiento
        '
        Me.lblAsiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAsiento.BeforeTouchSize = New System.Drawing.Size(117, 30)
        Me.lblAsiento.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.lblAsiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAsiento.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblAsiento.ForeColor = System.Drawing.Color.Black
        Me.lblAsiento.Location = New System.Drawing.Point(150, 12)
        Me.lblAsiento.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.lblAsiento.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.lblAsiento.Name = "lblAsiento"
        Me.lblAsiento.Size = New System.Drawing.Size(117, 30)
        Me.lblAsiento.TabIndex = 697
        Me.lblAsiento.TabStop = False
        Me.lblAsiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lblAsiento.ThousandsSeparator = True
        Me.lblAsiento.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(18, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 21)
        Me.Label2.TabIndex = 696
        Me.Label2.Text = "Buscar Asiento:"
        '
        'FormAnularPasaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 395)
        Me.Controls.Add(Me.pnBuscardor)
        Me.Name = "FormAnularPasaje"
        Me.Text = "Anular Venta"
        Me.pnBuscardor.ResumeLayout(False)
        Me.pnBuscardor.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAsiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnBuscardor As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtImporte As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNombrePasajero As TextBox
    Friend WithEvents txtEdad As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAsiento As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAsientoEncontrado As Label
    Friend WithEvents btnAsiento As Button
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
End Class
