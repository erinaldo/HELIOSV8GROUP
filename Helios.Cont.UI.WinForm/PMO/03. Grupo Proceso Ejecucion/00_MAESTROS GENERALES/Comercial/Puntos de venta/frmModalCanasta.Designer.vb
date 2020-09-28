<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalCanasta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalCanasta))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbGMayor = New System.Windows.Forms.RadioButton()
        Me.rbMayor = New System.Windows.Forms.RadioButton()
        Me.rbMenor = New System.Windows.Forms.RadioButton()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblproducto = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.lblDisponible = New System.Windows.Forms.ToolStripLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblMenor = New System.Windows.Forms.Label()
        Me.lblMayor = New System.Windows.Forms.Label()
        Me.lblGMayor = New System.Windows.Forms.Label()
        Me.lblGMayorME = New System.Windows.Forms.Label()
        Me.lblMayorME = New System.Windows.Forms.Label()
        Me.lblMenorME = New System.Windows.Forms.Label()
        Me.lblDetaMenor = New System.Windows.Forms.Label()
        Me.lblDetaMayor = New System.Windows.Forms.Label()
        Me.lblDetaGMayor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDsctoME = New System.Windows.Forms.Label()
        Me.lblDscto = New System.Windows.Forms.Label()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.lblTotalMN = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblTotalME = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Indica la cantidad:"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.Location = New System.Drawing.Point(233, 293)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 35)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Snow
        Me.GroupBox2.Controls.Add(Me.rbGMayor)
        Me.GroupBox2.Controls.Add(Me.rbMayor)
        Me.GroupBox2.Controls.Add(Me.rbMenor)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(144, 207)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(339, 51)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Elija precio por:"
        '
        'rbGMayor
        '
        Me.rbGMayor.AutoSize = True
        Me.rbGMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rbGMayor.Location = New System.Drawing.Point(220, 21)
        Me.rbGMayor.Name = "rbGMayor"
        Me.rbGMayor.Size = New System.Drawing.Size(81, 17)
        Me.rbGMayor.TabIndex = 5
        Me.rbGMayor.Text = "Gran Mayor"
        Me.rbGMayor.UseVisualStyleBackColor = True
        '
        'rbMayor
        '
        Me.rbMayor.AutoSize = True
        Me.rbMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rbMayor.Location = New System.Drawing.Point(129, 21)
        Me.rbMayor.Name = "rbMayor"
        Me.rbMayor.Size = New System.Drawing.Size(64, 17)
        Me.rbMayor.TabIndex = 3
        Me.rbMayor.Text = "x Mayor"
        Me.rbMayor.UseVisualStyleBackColor = True
        '
        'rbMenor
        '
        Me.rbMenor.AutoSize = True
        Me.rbMenor.Checked = True
        Me.rbMenor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rbMenor.Location = New System.Drawing.Point(32, 21)
        Me.rbMenor.Name = "rbMenor"
        Me.rbMenor.Size = New System.Drawing.Size(64, 17)
        Me.rbMenor.TabIndex = 4
        Me.rbMenor.TabStop = True
        Me.rbMenor.Text = "x Menor"
        Me.rbMenor.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.Yellow
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(9, 237)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(129, 20)
        Me.txtCantidad.TabIndex = 0
        Me.txtCantidad.Text = "0.00"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.toolStripSeparator, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(492, 25)
        Me.ToolStrip2.TabIndex = 60
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(105, 22)
        Me.lblTitulo.Text = "ELEGIR PRECIOS::::"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Cancelar"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripButton2.Text = "Aceptar pedido"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.header_opened
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.lblproducto, Me.ToolStripSeparator2, Me.ToolStripLabel3, Me.lblDisponible})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(492, 25)
        Me.ToolStrip1.TabIndex = 61
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel1.Image = CType(resources.GetObject("ToolStripLabel1.Image"), System.Drawing.Image)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripLabel1.Text = "PRODUCTO:"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblproducto
        '
        Me.lblproducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblproducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblproducto.Name = "lblproducto"
        Me.lblproducto.Size = New System.Drawing.Size(83, 22)
        Me.lblproducto.Text = "NomProducto"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel3.Image = CType(resources.GetObject("ToolStripLabel3.Image"), System.Drawing.Image)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(84, 22)
        Me.ToolStripLabel3.Text = "Disponible:"
        '
        'lblDisponible
        '
        Me.lblDisponible.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDisponible.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDisponible.Name = "lblDisponible"
        Me.lblDisponible.Size = New System.Drawing.Size(35, 22)
        Me.lblDisponible.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(9, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(231, 18)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "PRECIO x MENOR:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(9, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(231, 18)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "PRECIO x MAYOR:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(9, 145)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(231, 18)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "PRECIO x GRAN MAYOR:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMenor
        '
        Me.lblMenor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMenor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMenor.Location = New System.Drawing.Point(238, 61)
        Me.lblMenor.Name = "lblMenor"
        Me.lblMenor.Size = New System.Drawing.Size(122, 18)
        Me.lblMenor.TabIndex = 66
        Me.lblMenor.Text = "0.00"
        Me.lblMenor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMayor
        '
        Me.lblMayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMayor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMayor.Location = New System.Drawing.Point(238, 103)
        Me.lblMayor.Name = "lblMayor"
        Me.lblMayor.Size = New System.Drawing.Size(122, 18)
        Me.lblMayor.TabIndex = 67
        Me.lblMayor.Text = "0.00"
        Me.lblMayor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGMayor
        '
        Me.lblGMayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGMayor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblGMayor.Location = New System.Drawing.Point(238, 145)
        Me.lblGMayor.Name = "lblGMayor"
        Me.lblGMayor.Size = New System.Drawing.Size(122, 18)
        Me.lblGMayor.TabIndex = 68
        Me.lblGMayor.Text = "0.00"
        Me.lblGMayor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGMayorME
        '
        Me.lblGMayorME.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGMayorME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGMayorME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblGMayorME.Location = New System.Drawing.Point(361, 145)
        Me.lblGMayorME.Name = "lblGMayorME"
        Me.lblGMayorME.Size = New System.Drawing.Size(122, 18)
        Me.lblGMayorME.TabIndex = 71
        Me.lblGMayorME.Text = "0.00"
        Me.lblGMayorME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMayorME
        '
        Me.lblMayorME.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMayorME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMayorME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMayorME.Location = New System.Drawing.Point(361, 103)
        Me.lblMayorME.Name = "lblMayorME"
        Me.lblMayorME.Size = New System.Drawing.Size(122, 18)
        Me.lblMayorME.TabIndex = 70
        Me.lblMayorME.Text = "0.00"
        Me.lblMayorME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMenorME
        '
        Me.lblMenorME.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMenorME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenorME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMenorME.Location = New System.Drawing.Point(361, 61)
        Me.lblMenorME.Name = "lblMenorME"
        Me.lblMenorME.Size = New System.Drawing.Size(122, 18)
        Me.lblMenorME.TabIndex = 69
        Me.lblMenorME.Text = "0.00"
        Me.lblMenorME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDetaMenor
        '
        Me.lblDetaMenor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDetaMenor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDetaMenor.Location = New System.Drawing.Point(9, 79)
        Me.lblDetaMenor.Name = "lblDetaMenor"
        Me.lblDetaMenor.Size = New System.Drawing.Size(351, 18)
        Me.lblDetaMenor.TabIndex = 72
        Me.lblDetaMenor.Text = "...."
        Me.lblDetaMenor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDetaMayor
        '
        Me.lblDetaMayor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDetaMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDetaMayor.Location = New System.Drawing.Point(9, 121)
        Me.lblDetaMayor.Name = "lblDetaMayor"
        Me.lblDetaMayor.Size = New System.Drawing.Size(351, 18)
        Me.lblDetaMayor.TabIndex = 73
        Me.lblDetaMayor.Text = "...."
        Me.lblDetaMayor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDetaGMayor
        '
        Me.lblDetaGMayor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDetaGMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDetaGMayor.Location = New System.Drawing.Point(9, 163)
        Me.lblDetaGMayor.Name = "lblDetaGMayor"
        Me.lblDetaGMayor.Size = New System.Drawing.Size(351, 18)
        Me.lblDetaGMayor.TabIndex = 74
        Me.lblDetaGMayor.Text = "...."
        Me.lblDetaGMayor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 18)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "DESCUENTOS:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDsctoME
        '
        Me.lblDsctoME.BackColor = System.Drawing.Color.SkyBlue
        Me.lblDsctoME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDsctoME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDsctoME.Location = New System.Drawing.Point(361, 185)
        Me.lblDsctoME.Name = "lblDsctoME"
        Me.lblDsctoME.Size = New System.Drawing.Size(122, 18)
        Me.lblDsctoME.TabIndex = 77
        Me.lblDsctoME.Text = "0.00"
        Me.lblDsctoME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDscto
        '
        Me.lblDscto.BackColor = System.Drawing.Color.SkyBlue
        Me.lblDscto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDscto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDscto.Location = New System.Drawing.Point(238, 185)
        Me.lblDscto.Name = "lblDscto"
        Me.lblDscto.Size = New System.Drawing.Size(122, 18)
        Me.lblDscto.TabIndex = 76
        Me.lblDscto.Text = "0.00"
        Me.lblDscto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalMN, Me.ToolStripLabel2, Me.ToolStripSeparator3, Me.lblTotalME, Me.ToolStripLabel5})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 268)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(492, 25)
        Me.ToolStrip3.TabIndex = 78
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'lblTotalMN
        '
        Me.lblTotalMN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTotalMN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalMN.ForeColor = System.Drawing.Color.Purple
        Me.lblTotalMN.Name = "lblTotalMN"
        Me.lblTotalMN.Size = New System.Drawing.Size(35, 22)
        Me.lblTotalMN.Text = "0.00"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripLabel2.Text = "Total m.n.:"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblTotalME
        '
        Me.lblTotalME.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTotalME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalME.Name = "lblTotalME"
        Me.lblTotalME.Size = New System.Drawing.Size(31, 22)
        Me.lblTotalME.Text = "0.00"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel5.Text = "Total m.e.:"
        '
        'frmModalCanasta
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(492, 293)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.lblDsctoME)
        Me.Controls.Add(Me.lblDscto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblDetaGMayor)
        Me.Controls.Add(Me.lblDetaMayor)
        Me.Controls.Add(Me.lblDetaMenor)
        Me.Controls.Add(Me.lblGMayorME)
        Me.Controls.Add(Me.lblMayorME)
        Me.Controls.Add(Me.lblMenorME)
        Me.Controls.Add(Me.lblGMayor)
        Me.Controls.Add(Me.lblMayor)
        Me.Controls.Add(Me.lblMenor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmModalCanasta"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbGMayor As System.Windows.Forms.RadioButton
    Friend WithEvents rbMayor As System.Windows.Forms.RadioButton
    Friend WithEvents rbMenor As System.Windows.Forms.RadioButton
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblproducto As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDisponible As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblMenor As System.Windows.Forms.Label
    Friend WithEvents lblMayor As System.Windows.Forms.Label
    Friend WithEvents lblGMayor As System.Windows.Forms.Label
    Friend WithEvents lblGMayorME As System.Windows.Forms.Label
    Friend WithEvents lblMayorME As System.Windows.Forms.Label
    Friend WithEvents lblMenorME As System.Windows.Forms.Label
    Friend WithEvents lblDetaMenor As System.Windows.Forms.Label
    Friend WithEvents lblDetaMayor As System.Windows.Forms.Label
    Friend WithEvents lblDetaGMayor As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDsctoME As System.Windows.Forms.Label
    Friend WithEvents lblDscto As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTotalMN As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblTotalME As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
End Class
