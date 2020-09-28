<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalTrab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalTrab))
        Me.lsvTrab = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbNombres = New System.Windows.Forms.RadioButton()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.rbNum = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblTipo = New System.Windows.Forms.ToolStripLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtIdEstable = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEstable = New System.Windows.Forms.TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvTrab
        '
        Me.lsvTrab.FullRowSelect = True
        Me.lsvTrab.GridLines = True
        Me.lsvTrab.HideSelection = False
        Me.lsvTrab.Location = New System.Drawing.Point(3, 116)
        Me.lsvTrab.MultiSelect = False
        Me.lsvTrab.Name = "lsvTrab"
        Me.lsvTrab.Size = New System.Drawing.Size(421, 181)
        Me.lsvTrab.TabIndex = 11
        Me.lsvTrab.UseCompatibleStateImageBehavior = False
        Me.lsvTrab.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbNombres)
        Me.GroupBox1.Controls.Add(Me.txtBusqueda)
        Me.GroupBox1.Controls.Add(Me.rbNum)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(421, 42)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por:"
        '
        'rbNombres
        '
        Me.rbNombres.AutoSize = True
        Me.rbNombres.Enabled = False
        Me.rbNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNombres.Location = New System.Drawing.Point(82, 19)
        Me.rbNombres.Name = "rbNombres"
        Me.rbNombres.Size = New System.Drawing.Size(67, 17)
        Me.rbNombres.TabIndex = 2
        Me.rbNombres.TabStop = True
        Me.rbNombres.Text = "Nombres"
        Me.rbNombres.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(161, 14)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(253, 22)
        Me.txtBusqueda.TabIndex = 0
        '
        'rbNum
        '
        Me.rbNum.AutoSize = True
        Me.rbNum.Checked = True
        Me.rbNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNum.Location = New System.Drawing.Point(7, 19)
        Me.rbNum.Name = "rbNum"
        Me.rbNum.Size = New System.Drawing.Size(66, 17)
        Me.rbNum.TabIndex = 1
        Me.rbNum.TabStop = True
        Me.rbNum.Text = "Nro doc."
        Me.rbNum.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.lblTipo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(429, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(60, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '  Me.AbrirToolStripButton.Image = Global.HeliosUI.My.Resources.Resources.pencil
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(57, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Enabled = False
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(77, 22)
        Me.GuardarToolStripButton.Text = "&Actualizar"
        '
        'lblTipo
        '
        Me.lblTipo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTipo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(20, 22)
        Me.lblTipo.Text = "PL"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(371, 98)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel1.TabIndex = 19
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Cambiar"
        '
        'txtIdEstable
        '
        Me.txtIdEstable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdEstable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdEstable.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdEstable.Location = New System.Drawing.Point(329, 89)
        Me.txtIdEstable.Name = "txtIdEstable"
        Me.txtIdEstable.ReadOnly = True
        Me.txtIdEstable.Size = New System.Drawing.Size(36, 22)
        Me.txtIdEstable.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Establecimiento:"
        '
        'txtEstable
        '
        Me.txtEstable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstable.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstable.Location = New System.Drawing.Point(3, 89)
        Me.txtEstable.Name = "txtEstable"
        Me.txtEstable.ReadOnly = True
        Me.txtEstable.Size = New System.Drawing.Size(322, 22)
        Me.txtEstable.TabIndex = 16
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(4, 7)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(168, 13)
        Me.LinkLabel2.TabIndex = 20
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Ingreso Interactivo Trabajador..."
        '
        'frmModalTrab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(429, 301)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtIdEstable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEstable)
        Me.Controls.Add(Me.lsvTrab)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmModalTrab"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsvTrab As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNombres As System.Windows.Forms.RadioButton
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents rbNum As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTipo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtIdEstable As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEstable As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
End Class
