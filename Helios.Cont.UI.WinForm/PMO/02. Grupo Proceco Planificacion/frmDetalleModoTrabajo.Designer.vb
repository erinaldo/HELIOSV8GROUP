<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleModoTrabajo
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
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNombreProyecto = New System.Windows.Forms.Label()
        Me.lblModoTrabajo = New System.Windows.Forms.Label()
        Me.lblDirector = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.navBG
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.toolStripSeparator, Me.ToolStripButton2, Me.ToolStripSeparator1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(399, 25)
        Me.ToolStrip2.TabIndex = 57
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(141, 22)
        Me.lblTitulo.Text = "Detalle - Modo de Trabajo"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(29, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Nombre Proyecto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(29, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Modo de Trabajo:"
        '
        'lblNombreProyecto
        '
        Me.lblNombreProyecto.AutoSize = True
        Me.lblNombreProyecto.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreProyecto.Location = New System.Drawing.Point(127, 41)
        Me.lblNombreProyecto.Name = "lblNombreProyecto"
        Me.lblNombreProyecto.Size = New System.Drawing.Size(16, 13)
        Me.lblNombreProyecto.TabIndex = 60
        Me.lblNombreProyecto.Text = "..."
        '
        'lblModoTrabajo
        '
        Me.lblModoTrabajo.AutoSize = True
        Me.lblModoTrabajo.BackColor = System.Drawing.Color.Transparent
        Me.lblModoTrabajo.Location = New System.Drawing.Point(127, 93)
        Me.lblModoTrabajo.Name = "lblModoTrabajo"
        Me.lblModoTrabajo.Size = New System.Drawing.Size(16, 13)
        Me.lblModoTrabajo.TabIndex = 61
        Me.lblModoTrabajo.Text = "..."
        '
        'lblDirector
        '
        Me.lblDirector.AutoSize = True
        Me.lblDirector.BackColor = System.Drawing.Color.Transparent
        Me.lblDirector.Location = New System.Drawing.Point(127, 67)
        Me.lblDirector.Name = "lblDirector"
        Me.lblDirector.Size = New System.Drawing.Size(16, 13)
        Me.lblDirector.TabIndex = 63
        Me.lblDirector.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(12, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Director del Proyecto:"
        '
        'frmDetalleModoTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(399, 124)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDirector)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblModoTrabajo)
        Me.Controls.Add(Me.lblNombreProyecto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDetalleModoTrabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Public WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNombreProyecto As System.Windows.Forms.Label
    Friend WithEvents lblModoTrabajo As System.Windows.Forms.Label
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
