<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonalExistente
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonalExistente))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.gbx1 = New System.Windows.Forms.GroupBox()
        Me.txtIdTipoDoc = New System.Windows.Forms.TextBox()
        Me.LinkTipoDoc = New System.Windows.Forms.LinkLabel()
        Me.txtTipoDoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtApmat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAppat = New System.Windows.Forms.TextBox()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lsvPersonas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.textFilterNum = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.textFilterNombres = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip2.SuspendLayout()
        Me.gbx1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.ImprimirToolStripButton, Me.btnEdit, Me.btnEliminar, Me.toolStripSeparator, Me.AyudaToolStripButton, Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(510, 25)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.Enabled = False
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.ImprimirToolStripButton.Text = "&Grabar"
        '
        'btnEdit
        '
        Me.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEdit.Enabled = False
        ' Me.btnEdit.Image = Global.HeliosUI.My.Resources.Resources.pencil
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(23, 22)
        Me.btnEdit.Text = "&editar"
        '
        'btnEliminar
        '
        Me.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEliminar.Enabled = False
        '  Me.btnEliminar.Image = Global.HeliosUI.My.Resources.Resources.cross
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(23, 22)
        Me.btnEliminar.Text = "&Eliminar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AyudaToolStripButton.Text = "Cancelar/Deshacer"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Salir"
        '
        'gbx1
        '
        Me.gbx1.Controls.Add(Me.txtIdTipoDoc)
        Me.gbx1.Controls.Add(Me.LinkTipoDoc)
        Me.gbx1.Controls.Add(Me.txtTipoDoc)
        Me.gbx1.Controls.Add(Me.Label2)
        Me.gbx1.Controls.Add(Me.txtNumDoc)
        Me.gbx1.Controls.Add(Me.Label5)
        Me.gbx1.Controls.Add(Me.txtApmat)
        Me.gbx1.Controls.Add(Me.Label1)
        Me.gbx1.Controls.Add(Me.txtAppat)
        Me.gbx1.Controls.Add(Me.txtNombres)
        Me.gbx1.Controls.Add(Me.Label4)
        Me.gbx1.Controls.Add(Me.Label3)
        Me.gbx1.Enabled = False
        Me.gbx1.Location = New System.Drawing.Point(8, 62)
        Me.gbx1.Name = "gbx1"
        Me.gbx1.Size = New System.Drawing.Size(494, 137)
        Me.gbx1.TabIndex = 4
        Me.gbx1.TabStop = False
        Me.gbx1.Text = "Ingresar datos de la persona:"
        '
        'txtIdTipoDoc
        '
        Me.txtIdTipoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtIdTipoDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdTipoDoc.Location = New System.Drawing.Point(393, 135)
        Me.txtIdTipoDoc.Name = "txtIdTipoDoc"
        Me.txtIdTipoDoc.ReadOnly = True
        Me.txtIdTipoDoc.Size = New System.Drawing.Size(27, 21)
        Me.txtIdTipoDoc.TabIndex = 37
        Me.txtIdTipoDoc.Visible = False
        '
        'LinkTipoDoc
        '
        Me.LinkTipoDoc.AutoSize = True
        Me.LinkTipoDoc.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkTipoDoc.Location = New System.Drawing.Point(435, 142)
        Me.LinkTipoDoc.Name = "LinkTipoDoc"
        Me.LinkTipoDoc.Size = New System.Drawing.Size(46, 13)
        Me.LinkTipoDoc.TabIndex = 36
        Me.LinkTipoDoc.TabStop = True
        Me.LinkTipoDoc.Text = "Cambiar"
        Me.LinkTipoDoc.Visible = False
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtTipoDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDoc.Location = New System.Drawing.Point(81, 135)
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.ReadOnly = True
        Me.txtTipoDoc.Size = New System.Drawing.Size(311, 21)
        Me.txtTipoDoc.TabIndex = 35
        Me.txtTipoDoc.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(19, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Tipo Doc.:"
        Me.Label2.Visible = False
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumDoc.Location = New System.Drawing.Point(106, 105)
        Me.txtNumDoc.MaxLength = 8
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(116, 21)
        Me.txtNumDoc.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(47, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Nro Doc.:"
        '
        'txtApmat
        '
        Me.txtApmat.BackColor = System.Drawing.SystemColors.Info
        Me.txtApmat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApmat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApmat.Location = New System.Drawing.Point(106, 78)
        Me.txtApmat.Name = "txtApmat"
        Me.txtApmat.Size = New System.Drawing.Size(260, 21)
        Me.txtApmat.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(35, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "A. Materno:"
        '
        'txtAppat
        '
        Me.txtAppat.BackColor = System.Drawing.SystemColors.Info
        Me.txtAppat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAppat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAppat.Location = New System.Drawing.Point(106, 51)
        Me.txtAppat.Name = "txtAppat"
        Me.txtAppat.Size = New System.Drawing.Size(260, 21)
        Me.txtAppat.TabIndex = 18
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Location = New System.Drawing.Point(106, 24)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(260, 21)
        Me.txtNombres.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(37, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "A. Paterno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(47, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Nombres:"
        '
        'lsvPersonas
        '
        Me.lsvPersonas.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvPersonas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lsvPersonas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lsvPersonas.FullRowSelect = True
        Me.lsvPersonas.HideSelection = False
        Me.lsvPersonas.Location = New System.Drawing.Point(0, 303)
        Me.lsvPersonas.MultiSelect = False
        Me.lsvPersonas.Name = "lsvPersonas"
        Me.lsvPersonas.Size = New System.Drawing.Size(510, 191)
        Me.lsvPersonas.TabIndex = 5
        Me.lsvPersonas.UseCompatibleStateImageBehavior = False
        Me.lsvPersonas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 89
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Apellidos y Nombres"
        Me.ColumnHeader2.Width = 418
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.textFilterNum)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.textFilterNombres)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 203)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(494, 69)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar personal existente por:"
        '
        'textFilterNum
        '
        Me.textFilterNum.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.textFilterNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textFilterNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textFilterNum.Location = New System.Drawing.Point(106, 41)
        Me.textFilterNum.Name = "textFilterNum"
        Me.textFilterNum.Size = New System.Drawing.Size(119, 21)
        Me.textFilterNum.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(50, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Nro.Doc.:"
        '
        'textFilterNombres
        '
        Me.textFilterNombres.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.textFilterNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textFilterNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textFilterNombres.Location = New System.Drawing.Point(106, 16)
        Me.textFilterNombres.Name = "textFilterNombres"
        Me.textFilterNombres.Size = New System.Drawing.Size(319, 21)
        Me.textFilterNombres.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(9, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Nombres (ap, nn):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.Label8.Location = New System.Drawing.Point(5, 278)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(217, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Trabajadores encontrados de la empresa: 0"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(510, 25)
        Me.ToolStrip4.TabIndex = 8
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkGreen
        '  Me.lblEstado.Image = Global.HeliosUI.My.Resources.Resources.ok
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(157, 22)
        Me.lblEstado.Text = "Estado: nuevo trabajador"
        '
        'Timer1
        '
        '
        'frmPersonalExistente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(510, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lsvPersonas)
        Me.Controls.Add(Me.gbx1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPersonalExistente"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.gbx1.ResumeLayout(False)
        Me.gbx1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents gbx1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtApmat As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAppat As System.Windows.Forms.TextBox
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AyudaToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtIdTipoDoc As System.Windows.Forms.TextBox
    Friend WithEvents LinkTipoDoc As System.Windows.Forms.LinkLabel
    Friend WithEvents txtTipoDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lsvPersonas As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents textFilterNum As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents textFilterNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
