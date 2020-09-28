<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRentabilidad
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRentabilidad))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtIndice = New System.Windows.Forms.ToolStripTextBox()
        Me.txtIndiceTotal = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.lblMensaje = New System.Windows.Forms.ToolStripLabel()
        Me.lblAgregar = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtTotalKardex = New System.Windows.Forms.TextBox()
        Me.txtTotalCosto = New System.Windows.Forms.TextBox()
        Me.txtRenta = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lsvRentabilidad = New System.Windows.Forms.ListView()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ToolStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.ToolStripButton1, Me.lblPeriodo, Me.ToolStripLabel1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(703, 25)
        Me.ToolStrip2.TabIndex = 60
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(145, 22)
        Me.lblTitulo.Text = "ANALISIS DE RENTABILIDAD"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Salir"
        Me.ToolStripButton1.Visible = False
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPeriodo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPeriodo.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(54, 22)
        Me.lblPeriodo.Text = "01/2014"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStripLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel1.Text = "PERIODO:"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.ToolStrip4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(703, 49)
        Me.Panel1.TabIndex = 61
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator2, Me.txtIndice, Me.txtIndiceTotal, Me.ToolStripSeparator4, Me.ToolStripButton5, Me.ToolStripButton6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(703, 25)
        Me.ToolStrip1.TabIndex = 290
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton2"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "ToolStripButton4"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'txtIndice
        '
        Me.txtIndice.Name = "txtIndice"
        Me.txtIndice.ReadOnly = True
        Me.txtIndice.Size = New System.Drawing.Size(50, 25)
        Me.txtIndice.Text = "0"
        '
        'txtIndiceTotal
        '
        Me.txtIndiceTotal.Name = "txtIndiceTotal"
        Me.txtIndiceTotal.Size = New System.Drawing.Size(37, 22)
        Me.txtIndiceTotal.Text = "de {0}"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "ToolStripButton6"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.lblMensaje, Me.lblAgregar, Me.ToolStripButton2})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip4.Size = New System.Drawing.Size(703, 25)
        Me.ToolStrip4.TabIndex = 1
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(161, 22)
        Me.lblEstado.Text = "Analisis de rentas obtenidad."
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(59, 22)
        Me.lblMensaje.Text = "Mensaje:::"
        Me.lblMensaje.Visible = False
        '
        'lblAgregar
        '
        Me.lblAgregar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblAgregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAgregar.Name = "lblAgregar"
        Me.lblAgregar.Size = New System.Drawing.Size(61, 22)
        Me.lblAgregar.Text = "(click aqui)"
        Me.lblAgregar.Visible = False
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton1"
        Me.ToolStripButton2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.txtCantidad)
        Me.Panel2.Controls.Add(Me.txtTotalKardex)
        Me.Panel2.Controls.Add(Me.txtTotalCosto)
        Me.Panel2.Controls.Add(Me.txtRenta)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 375)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(703, 28)
        Me.Panel2.TabIndex = 63
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCantidad.ForeColor = System.Drawing.SystemColors.Info
        Me.txtCantidad.Location = New System.Drawing.Point(297, 5)
        Me.txtCantidad.Multiline = True
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 9
        Me.txtCantidad.Text = "0.00"
        '
        'txtTotalKardex
        '
        Me.txtTotalKardex.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalKardex.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalKardex.ForeColor = System.Drawing.SystemColors.Info
        Me.txtTotalKardex.Location = New System.Drawing.Point(398, 5)
        Me.txtTotalKardex.Multiline = True
        Me.txtTotalKardex.Name = "txtTotalKardex"
        Me.txtTotalKardex.ReadOnly = True
        Me.txtTotalKardex.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalKardex.TabIndex = 8
        Me.txtTotalKardex.Text = "0.00"
        '
        'txtTotalCosto
        '
        Me.txtTotalCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalCosto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalCosto.ForeColor = System.Drawing.SystemColors.Info
        Me.txtTotalCosto.Location = New System.Drawing.Point(499, 5)
        Me.txtTotalCosto.Multiline = True
        Me.txtTotalCosto.Name = "txtTotalCosto"
        Me.txtTotalCosto.ReadOnly = True
        Me.txtTotalCosto.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCosto.TabIndex = 7
        Me.txtTotalCosto.Text = "0.00"
        '
        'txtRenta
        '
        Me.txtRenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRenta.ForeColor = System.Drawing.SystemColors.Info
        Me.txtRenta.Location = New System.Drawing.Point(600, 5)
        Me.txtRenta.Multiline = True
        Me.txtRenta.Name = "txtRenta"
        Me.txtRenta.ReadOnly = True
        Me.txtRenta.Size = New System.Drawing.Size(100, 20)
        Me.txtRenta.TabIndex = 6
        Me.txtRenta.Text = "0.00"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lsvRentabilidad)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 74)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(703, 301)
        Me.Panel3.TabIndex = 64
        '
        'lsvRentabilidad
        '
        Me.lsvRentabilidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvRentabilidad.GridLines = True
        Me.lsvRentabilidad.HideSelection = False
        Me.lsvRentabilidad.Location = New System.Drawing.Point(0, 0)
        Me.lsvRentabilidad.MultiSelect = False
        Me.lsvRentabilidad.Name = "lsvRentabilidad"
        Me.lsvRentabilidad.Size = New System.Drawing.Size(703, 301)
        Me.lsvRentabilidad.TabIndex = 63
        Me.lsvRentabilidad.UseCompatibleStateImageBehavior = False
        Me.lsvRentabilidad.View = System.Windows.Forms.View.Details
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'frmRentabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 403)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Name = "frmRentabilidad"
        Me.Text = "Análisis de rentabilidad de las ventas"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lsvRentabilidad As System.Windows.Forms.ListView
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalKardex As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtRenta As System.Windows.Forms.TextBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblMensaje As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblAgregar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtIndice As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtIndiceTotal As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
End Class
