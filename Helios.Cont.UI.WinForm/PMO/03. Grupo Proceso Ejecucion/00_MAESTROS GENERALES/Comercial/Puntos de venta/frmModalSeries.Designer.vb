<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalSeries
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalSeries))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.gbSeries = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.rbFact = New System.Windows.Forms.RadioButton()
        Me.rbBol = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbFac = New System.Windows.Forms.RadioButton()
        Me.rbBoleta = New System.Windows.Forms.RadioButton()
        Me.lsvNumeracion = New System.Windows.Forms.ListView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnRegistrar = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ReiniciarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.nudMaximo = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudinicio = New System.Windows.Forms.NumericUpDown()
        Me.txtSerieSel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudincremento = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lsvSerie = New System.Windows.Forms.ListView()
        Me.colSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colComprobante = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1.SuspendLayout()
        Me.gbSeries.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.nudMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudinicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudincremento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnEdit, Me.GuardarToolStripButton, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(413, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 22)
        Me.btnNuevo.Text = "&Nuevo"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(41, 22)
        Me.btnEdit.Text = "&Editar"
        Me.btnEdit.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Enabled = False
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(43, 22)
        Me.GuardarToolStripButton.Text = "&Quitar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripButton1.Text = "Asignar numeración"
        '
        'gbSeries
        '
        Me.gbSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.gbSeries.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gbSeries.Controls.Add(Me.lblEstado)
        Me.gbSeries.Controls.Add(Me.rbFact)
        Me.gbSeries.Controls.Add(Me.rbBol)
        Me.gbSeries.Controls.Add(Me.Label8)
        Me.gbSeries.Controls.Add(Me.btnCancelar)
        Me.gbSeries.Controls.Add(Me.btnGrabar)
        Me.gbSeries.Controls.Add(Me.txtSerie)
        Me.gbSeries.Controls.Add(Me.txtFecha)
        Me.gbSeries.Controls.Add(Me.Label2)
        Me.gbSeries.Controls.Add(Me.Label1)
        Me.gbSeries.Enabled = False
        Me.gbSeries.Location = New System.Drawing.Point(226, 26)
        Me.gbSeries.Name = "gbSeries"
        Me.gbSeries.Size = New System.Drawing.Size(183, 229)
        Me.gbSeries.TabIndex = 3
        Me.gbSeries.TabStop = False
        Me.gbSeries.Text = "Nuevo Registro"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblEstado.ForeColor = System.Drawing.Color.Black
        Me.lblEstado.Location = New System.Drawing.Point(0, 204)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(183, 22)
        Me.lblEstado.TabIndex = 6
        Me.lblEstado.Text = "configuracion"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbFact
        '
        Me.rbFact.AutoSize = True
        Me.rbFact.Location = New System.Drawing.Point(100, 134)
        Me.rbFact.Name = "rbFact"
        Me.rbFact.Size = New System.Drawing.Size(45, 17)
        Me.rbFact.TabIndex = 8
        Me.rbFact.Text = "FAC"
        Me.rbFact.UseVisualStyleBackColor = True
        '
        'rbBol
        '
        Me.rbBol.AutoSize = True
        Me.rbBol.Checked = True
        Me.rbBol.Location = New System.Drawing.Point(19, 134)
        Me.rbBol.Name = "rbBol"
        Me.rbBol.Size = New System.Drawing.Size(44, 17)
        Me.rbBol.TabIndex = 7
        Me.rbBol.TabStop = True
        Me.rbBol.Text = "BOL"
        Me.rbBol.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(18, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Documento:"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCancelar.BackgroundImage = CType(resources.GetObject("btnCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.Location = New System.Drawing.Point(100, 157)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnGrabar.BackgroundImage = CType(resources.GetObject("btnGrabar.BackgroundImage"), System.Drawing.Image)
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGrabar.Location = New System.Drawing.Point(19, 157)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 32)
        Me.btnGrabar.TabIndex = 4
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'txtSerie
        '
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Location = New System.Drawing.Point(19, 86)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(114, 20)
        Me.txtSerie.TabIndex = 3
        '
        'txtFecha
        '
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(19, 45)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(114, 20)
        Me.txtFecha.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Serie:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(-1, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(413, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Asignar Numeración"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbFac)
        Me.Panel1.Controls.Add(Me.rbBoleta)
        Me.Panel1.Controls.Add(Me.lsvNumeracion)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Controls.Add(Me.nudMaximo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.nudinicio)
        Me.Panel1.Controls.Add(Me.txtSerieSel)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.nudincremento)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(0, 290)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(412, 203)
        Me.Panel1.TabIndex = 5
        '
        'rbFac
        '
        Me.rbFac.AutoSize = True
        Me.rbFac.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.rbFac.Location = New System.Drawing.Point(356, 3)
        Me.rbFac.Name = "rbFac"
        Me.rbFac.Size = New System.Drawing.Size(45, 17)
        Me.rbFac.TabIndex = 18
        Me.rbFac.Text = "FAC"
        Me.rbFac.UseVisualStyleBackColor = False
        '
        'rbBoleta
        '
        Me.rbBoleta.AutoSize = True
        Me.rbBoleta.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.rbBoleta.Checked = True
        Me.rbBoleta.Location = New System.Drawing.Point(292, 3)
        Me.rbBoleta.Name = "rbBoleta"
        Me.rbBoleta.Size = New System.Drawing.Size(44, 17)
        Me.rbBoleta.TabIndex = 17
        Me.rbBoleta.TabStop = True
        Me.rbBoleta.Text = "BOL"
        Me.rbBoleta.UseVisualStyleBackColor = False
        '
        'lsvNumeracion
        '
        Me.lsvNumeracion.FullRowSelect = True
        Me.lsvNumeracion.GridLines = True
        Me.lsvNumeracion.HideSelection = False
        Me.lsvNumeracion.Location = New System.Drawing.Point(2, 28)
        Me.lsvNumeracion.MultiSelect = False
        Me.lsvNumeracion.Name = "lsvNumeracion"
        Me.lsvNumeracion.Size = New System.Drawing.Size(254, 170)
        Me.lsvNumeracion.TabIndex = 1
        Me.lsvNumeracion.UseCompatibleStateImageBehavior = False
        Me.lsvNumeracion.View = System.Windows.Forms.View.Details
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRegistrar, Me.AbrirToolStripButton, Me.toolStripSeparator1, Me.ToolStripSplitButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(412, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnRegistrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRegistrar.Image = CType(resources.GetObject("btnRegistrar.Image"), System.Drawing.Image)
        Me.btnRegistrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(73, 22)
        Me.btnRegistrar.Text = "&Registrar"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AbrirToolStripButton.Image = CType(resources.GetObject("AbrirToolStripButton.Image"), System.Drawing.Image)
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AbrirToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReiniciarToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripSplitButton1.Text = "Reinicio"
        '
        'ReiniciarToolStripMenuItem
        '
        Me.ReiniciarToolStripMenuItem.Name = "ReiniciarToolStripMenuItem"
        Me.ReiniciarToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ReiniciarToolStripMenuItem.Text = "Reiniciar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.ToolStripMenuItem1.Text = "Anclar serie"
        '
        'nudMaximo
        '
        Me.nudMaximo.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.nudMaximo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudMaximo.Location = New System.Drawing.Point(265, 133)
        Me.nudMaximo.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.nudMaximo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMaximo.Name = "nudMaximo"
        Me.nudMaximo.Size = New System.Drawing.Size(109, 20)
        Me.nudMaximo.TabIndex = 16
        Me.nudMaximo.Value = New Decimal(New Integer() {1000000, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(262, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Serie seleccionada:"
        '
        'nudinicio
        '
        Me.nudinicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.nudinicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudinicio.Location = New System.Drawing.Point(265, 84)
        Me.nudinicio.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudinicio.Name = "nudinicio"
        Me.nudinicio.Size = New System.Drawing.Size(109, 20)
        Me.nudinicio.TabIndex = 15
        '
        'txtSerieSel
        '
        Me.txtSerieSel.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.txtSerieSel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSerieSel.ForeColor = System.Drawing.Color.Black
        Me.txtSerieSel.Location = New System.Drawing.Point(265, 45)
        Me.txtSerieSel.Multiline = True
        Me.txtSerieSel.Name = "txtSerieSel"
        Me.txtSerieSel.ReadOnly = True
        Me.txtSerieSel.Size = New System.Drawing.Size(109, 20)
        Me.txtSerieSel.TabIndex = 7
        Me.txtSerieSel.Text = "000000"
        Me.txtSerieSel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(265, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Incremento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Inicio:"
        '
        'nudincremento
        '
        Me.nudincremento.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.nudincremento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudincremento.Location = New System.Drawing.Point(265, 175)
        Me.nudincremento.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudincremento.Name = "nudincremento"
        Me.nudincremento.Size = New System.Drawing.Size(109, 20)
        Me.nudincremento.TabIndex = 12
        Me.nudincremento.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Máximo Valor:"
        '
        'lsvSerie
        '
        Me.lsvSerie.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSerie, Me.colComprobante})
        Me.lsvSerie.FullRowSelect = True
        Me.lsvSerie.GridLines = True
        Me.lsvSerie.HideSelection = False
        Me.lsvSerie.Location = New System.Drawing.Point(0, 28)
        Me.lsvSerie.MultiSelect = False
        Me.lsvSerie.Name = "lsvSerie"
        Me.lsvSerie.Size = New System.Drawing.Size(223, 227)
        Me.lsvSerie.TabIndex = 6
        Me.lsvSerie.UseCompatibleStateImageBehavior = False
        Me.lsvSerie.View = System.Windows.Forms.View.Details
        '
        'colSerie
        '
        Me.colSerie.Text = "Serie"
        Me.colSerie.Width = 133
        '
        'colComprobante
        '
        Me.colComprobante.Text = "Comprobante"
        Me.colComprobante.Width = 86
        '
        'frmModalSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(413, 497)
        Me.Controls.Add(Me.lsvSerie)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbSeries)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalSeries"
        Me.Text = "Series"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbSeries.ResumeLayout(False)
        Me.gbSeries.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.nudMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudinicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudincremento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbSeries As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRegistrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerieSel As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudincremento As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lsvNumeracion As System.Windows.Forms.ListView
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ReiniciarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents nudinicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMaximo As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbBoleta As System.Windows.Forms.RadioButton
    Friend WithEvents rbFac As System.Windows.Forms.RadioButton
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rbFact As System.Windows.Forms.RadioButton
    Friend WithEvents rbBol As System.Windows.Forms.RadioButton
    Friend WithEvents lsvSerie As System.Windows.Forms.ListView
    Friend WithEvents colSerie As System.Windows.Forms.ColumnHeader
    Friend WithEvents colComprobante As System.Windows.Forms.ColumnHeader
End Class
