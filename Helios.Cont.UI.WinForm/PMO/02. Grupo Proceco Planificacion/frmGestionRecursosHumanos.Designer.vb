<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestionRecursosHumanos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGestionRecursosHumanos))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFinaliza = New System.Windows.Forms.DateTimePicker()
        Me.txtInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDirector = New System.Windows.Forms.TextBox()
        Me.txtProyecto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lsvTRabadores = New System.Windows.Forms.ListView()
        Me.coIdEsytable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEstable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNombres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.txtDirector)
        Me.Panel3.Controls.Add(Me.txtProyecto)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(727, 93)
        Me.Panel3.TabIndex = 62
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFinaliza)
        Me.GroupBox2.Controls.Add(Me.txtInicio)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(405, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 77)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Plazo Proyecto"
        '
        'txtFinaliza
        '
        Me.txtFinaliza.Enabled = False
        Me.txtFinaliza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFinaliza.Location = New System.Drawing.Point(105, 46)
        Me.txtFinaliza.Name = "txtFinaliza"
        Me.txtFinaliza.Size = New System.Drawing.Size(150, 20)
        Me.txtFinaliza.TabIndex = 3
        '
        'txtInicio
        '
        Me.txtInicio.Enabled = False
        Me.txtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtInicio.Location = New System.Drawing.Point(105, 19)
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(150, 20)
        Me.txtInicio.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Finaliza:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(63, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Inicio:"
        '
        'txtDirector
        '
        Me.txtDirector.BackColor = System.Drawing.Color.GhostWhite
        Me.txtDirector.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDirector.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtDirector.Location = New System.Drawing.Point(13, 62)
        Me.txtDirector.Multiline = True
        Me.txtDirector.Name = "txtDirector"
        Me.txtDirector.ReadOnly = True
        Me.txtDirector.Size = New System.Drawing.Size(357, 20)
        Me.txtDirector.TabIndex = 69
        '
        'txtProyecto
        '
        Me.txtProyecto.BackColor = System.Drawing.Color.GhostWhite
        Me.txtProyecto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProyecto.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtProyecto.Location = New System.Drawing.Point(13, 22)
        Me.txtProyecto.Multiline = True
        Me.txtProyecto.Name = "txtProyecto"
        Me.txtProyecto.ReadOnly = True
        Me.txtProyecto.Size = New System.Drawing.Size(357, 20)
        Me.txtProyecto.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(10, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Director:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Proyecto Aprobado:"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton1, Me.ImprimirToolStripButton, Me.toolStripSeparator3})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 143)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(727, 25)
        Me.ToolStrip3.TabIndex = 63
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(66, 22)
        Me.NuevoToolStripButton.Text = "&Agregar"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Image = CType(resources.GetObject("AbrirToolStripButton.Image"), System.Drawing.Image)
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        Me.AbrirToolStripButton.Visible = False
        '
        'GuardarToolStripButton1
        '
        Me.GuardarToolStripButton1.Image = CType(resources.GetObject("GuardarToolStripButton1.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton1.Name = "GuardarToolStripButton1"
        Me.GuardarToolStripButton1.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton1.Text = "Eliminar"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(59, 22)
        Me.ImprimirToolStripButton.Text = "&Buscar"
        Me.ImprimirToolStripButton.Visible = False
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lsvTRabadores
        '
        Me.lsvTRabadores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.coIdEsytable, Me.colEstable, Me.colNumDoc, Me.colNombres})
        Me.lsvTRabadores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvTRabadores.FullRowSelect = True
        Me.lsvTRabadores.HideSelection = False
        Me.lsvTRabadores.Location = New System.Drawing.Point(0, 168)
        Me.lsvTRabadores.MultiSelect = False
        Me.lsvTRabadores.Name = "lsvTRabadores"
        Me.lsvTRabadores.Size = New System.Drawing.Size(727, 325)
        Me.lsvTRabadores.TabIndex = 64
        Me.lsvTRabadores.UseCompatibleStateImageBehavior = False
        Me.lsvTRabadores.View = System.Windows.Forms.View.Details
        '
        'coIdEsytable
        '
        Me.coIdEsytable.Text = "ID EStable"
        Me.coIdEsytable.Width = 13
        '
        'colEstable
        '
        Me.colEstable.Text = "Establecimiento"
        Me.colEstable.Width = 215
        '
        'colNumDoc
        '
        Me.colNumDoc.Text = "Nro.Doc."
        Me.colNumDoc.Width = 97
        '
        'colNombres
        '
        Me.colNombres.Text = "Nombres"
        Me.colNombres.Width = 398
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(727, 25)
        Me.ToolStrip1.TabIndex = 58
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._32384
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(202, 22)
        Me.lblEstado.Text = "Gestión Selección Equipo de proyecto"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.navBG
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.toolStripSeparator, Me.GuardarToolStripButton, Me.ToolStripButton2, Me.ToolStripSeparator1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(727, 25)
        Me.ToolStrip2.TabIndex = 57
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(276, 22)
        Me.lblTitulo.Text = "Grupo de Proceso: Planificación: Equipo de Proyecto"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "dispose"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'frmGestionRecursosHumanos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 493)
        Me.ControlBox = False
        Me.Controls.Add(Me.lsvTRabadores)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmGestionRecursosHumanos"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFinaliza As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDirector As System.Windows.Forms.TextBox
    Friend WithEvents txtProyecto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents lsvTRabadores As System.Windows.Forms.ListView
    Friend WithEvents coIdEsytable As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEstable As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNombres As System.Windows.Forms.ColumnHeader
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
End Class
