<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProyectoBuscar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProyectoBuscar))
        Me.lsvListaProyectos = New System.Windows.Forms.ListView()
        Me.colIDProyec = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colNom = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colEstado = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colInicio = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colFecaFin = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.grbMenuPlaneacion = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lblGrabar = New System.Windows.Forms.Label()
        Me.pcbAdmiProy = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.btnEditarCuenta = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblConteo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtIndice = New System.Windows.Forms.ToolStripTextBox()
        Me.txtIndiceTotal = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.grbMenuPlaneacion.SuspendLayout
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pcbAdmiProy,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.Panel3.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        Me.Panel4.SuspendLayout
        Me.ToolStrip3.SuspendLayout
        Me.SuspendLayout
        '
        'lsvListaProyectos
        '
        Me.lsvListaProyectos.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvListaProyectos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIDProyec, Me.colNom, Me.colEstado, Me.colInicio, Me.colFecaFin})
        Me.lsvListaProyectos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvListaProyectos.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lsvListaProyectos.FullRowSelect = true
        Me.lsvListaProyectos.GridLines = true
        Me.lsvListaProyectos.HideSelection = false
        Me.lsvListaProyectos.Location = New System.Drawing.Point(0, 25)
        Me.lsvListaProyectos.MultiSelect = false
        Me.lsvListaProyectos.Name = "lsvListaProyectos"
        Me.lsvListaProyectos.Size = New System.Drawing.Size(678, 373)
        Me.lsvListaProyectos.TabIndex = 11
        Me.lsvListaProyectos.UseCompatibleStateImageBehavior = false
        Me.lsvListaProyectos.View = System.Windows.Forms.View.Details
        '
        'colIDProyec
        '
        Me.colIDProyec.Text = "ID"
        Me.colIDProyec.Width = 0
        '
        'colNom
        '
        Me.colNom.Text = "Proyecto"
        Me.colNom.Width = 386
        '
        'colEstado
        '
        Me.colEstado.Text = "Estado"
        '
        'colInicio
        '
        Me.colInicio.Text = "Inicio"
        Me.colInicio.Width = 99
        '
        'colFecaFin
        '
        Me.colFecaFin.Text = "Finaliza"
        Me.colFecaFin.Width = 88
        '
        'grbMenuPlaneacion
        '
        Me.grbMenuPlaneacion.Controls.Add(Me.Label5)
        Me.grbMenuPlaneacion.Controls.Add(Me.Label4)
        Me.grbMenuPlaneacion.Controls.Add(Me.Label2)
        Me.grbMenuPlaneacion.Controls.Add(Me.PictureBox5)
        Me.grbMenuPlaneacion.Controls.Add(Me.lblGrabar)
        Me.grbMenuPlaneacion.Controls.Add(Me.pcbAdmiProy)
        Me.grbMenuPlaneacion.Controls.Add(Me.PictureBox3)
        Me.grbMenuPlaneacion.Location = New System.Drawing.Point(149, 551)
        Me.grbMenuPlaneacion.Name = "grbMenuPlaneacion"
        Me.grbMenuPlaneacion.Size = New System.Drawing.Size(337, 86)
        Me.grbMenuPlaneacion.TabIndex = 12
        Me.grbMenuPlaneacion.TabStop = false
        Me.grbMenuPlaneacion.Visible = false
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.Label5.Location = New System.Drawing.Point(36, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "procesos y tareas"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.Label4.Location = New System.Drawing.Point(132, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "cadena de suministros e Inicidencias"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.Label2.Location = New System.Drawing.Point(202, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Ingresos,"
        '
        'PictureBox5
        '
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"),System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(264, 31)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(87, 53)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 15
        Me.PictureBox5.TabStop = false
        Me.PictureBox5.Visible = false
        '
        'lblGrabar
        '
        Me.lblGrabar.AutoSize = true
        Me.lblGrabar.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lblGrabar.Location = New System.Drawing.Point(19, 3)
        Me.lblGrabar.Name = "lblGrabar"
        Me.lblGrabar.Size = New System.Drawing.Size(124, 13)
        Me.lblGrabar.TabIndex = 5
        Me.lblGrabar.Text = "Estrategias de ejecución"
        '
        'pcbAdmiProy
        '
        Me.pcbAdmiProy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbAdmiProy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcbAdmiProy.Image = CType(resources.GetObject("pcbAdmiProy.Image"),System.Drawing.Image)
        Me.pcbAdmiProy.InitialImage = Nothing
        Me.pcbAdmiProy.Location = New System.Drawing.Point(39, 32)
        Me.pcbAdmiProy.Name = "pcbAdmiProy"
        Me.pcbAdmiProy.Size = New System.Drawing.Size(87, 52)
        Me.pcbAdmiProy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pcbAdmiProy.TabIndex = 16
        Me.pcbAdmiProy.TabStop = false
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"),System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(187, 32)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(87, 52)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 13
        Me.PictureBox3.TabStop = false
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230,Byte),Integer), CType(CType(240,Byte),Integer), CType(CType(200,Byte),Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"),System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(678, 27)
        Me.Panel1.TabIndex = 430
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = true
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTitulo.Location = New System.Drawing.Point(10, 6)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(107, 12)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "LISTA DE PROYECTOS"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"),System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.ToolStripButton2, Me.btnEditarCuenta, Me.toolStripSeparator, Me.ToolStripButton1, Me.ToolStripButton3, Me.ToolStripSeparator1, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 27)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(678, 25)
        Me.ToolStrip1.TabIndex = 431
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.Black
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"),System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(107, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo Proyecto"
        Me.NuevoToolStripButton.Visible = false
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"),System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripButton2.Text = "&Editar"
        '
        'btnEditarCuenta
        '
        Me.btnEditarCuenta.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.btnEditarCuenta.ForeColor = System.Drawing.Color.Black
        Me.btnEditarCuenta.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.cross
        Me.btnEditarCuenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditarCuenta.Name = "btnEditarCuenta"
        Me.btnEditarCuenta.Size = New System.Drawing.Size(68, 22)
        Me.btnEditarCuenta.Text = "Eliminar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"),System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton1.Text = "&Buscar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "&Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripButton4.Text = "Definir situación"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel2.Controls.Add(Me.lblConteo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 479)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(678, 18)
        Me.Panel2.TabIndex = 432
        '
        'lblConteo
        '
        Me.lblConteo.AutoSize = true
        Me.lblConteo.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0,Byte))
        Me.lblConteo.ForeColor = System.Drawing.Color.White
        Me.lblConteo.Location = New System.Drawing.Point(4, 2)
        Me.lblConteo.Name = "lblConteo"
        Me.lblConteo.Size = New System.Drawing.Size(112, 12)
        Me.lblConteo.TabIndex = 5
        Me.lblConteo.Text = "Registros encontrados: 0"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.ToolStrip2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 52)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(678, 29)
        Me.Panel3.TabIndex = 433
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.header_opened
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator4, Me.txtIndice, Me.txtIndiceTotal, Me.ToolStripSeparator5, Me.ToolStripButton7, Me.ToolStripButton8})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(678, 25)
        Me.ToolStrip2.TabIndex = 437
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"),System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "ToolStripButton2"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"),System.Drawing.Image)
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "ToolStripButton4"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'txtIndice
        '
        Me.txtIndice.Name = "txtIndice"
        Me.txtIndice.ReadOnly = true
        Me.txtIndice.Size = New System.Drawing.Size(50, 25)
        Me.txtIndice.Text = "0"
        '
        'txtIndiceTotal
        '
        Me.txtIndiceTotal.Name = "txtIndiceTotal"
        Me.txtIndiceTotal.Size = New System.Drawing.Size(37, 22)
        Me.txtIndiceTotal.Text = "de {0}"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"),System.Drawing.Image)
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "ToolStripButton5"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"),System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "ToolStripButton6"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lsvListaProyectos)
        Me.Panel4.Controls.Add(Me.ToolStrip3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 81)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(678, 398)
        Me.Panel4.TabIndex = 434
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(225,Byte),Integer), CType(CType(240,Byte),Integer), CType(CType(190,Byte),Integer))
        Me.ToolStrip3.BackgroundImage = CType(resources.GetObject("ToolStrip3.BackgroundImage"),System.Drawing.Image)
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(678, 25)
        Me.ToolStrip3.TabIndex = 46
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(151, 22)
        Me.lblEstado.Text = "Estado: Proyectos  en cartera"
        '
        'FormProyectoBuscar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(678, 497)
        Me.ControlBox = false
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbMenuPlaneacion)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Name = "FormProyectoBuscar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grbMenuPlaneacion.ResumeLayout(false)
        Me.grbMenuPlaneacion.PerformLayout
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pcbAdmiProy,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.Panel4.ResumeLayout(false)
        Me.Panel4.PerformLayout
        Me.ToolStrip3.ResumeLayout(false)
        Me.ToolStrip3.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents lsvListaProyectos As System.Windows.Forms.ListView
    Friend WithEvents grbMenuPlaneacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lblGrabar As System.Windows.Forms.Label
    Friend WithEvents pcbAdmiProy As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditarCuenta As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblConteo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtIndice As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtIndiceTotal As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents colIDProyec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNom As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents colInicio As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFecaFin As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
End Class
