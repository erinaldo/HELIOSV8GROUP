<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoAportes
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoAportes))
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.CompraPagadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConpraAlCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lsvProduccion = New System.Windows.Forms.ListView()
        Me.DesdeExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaulToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.lblEstado, Me.ToolStripSeparator1, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.toolStripSeparator, Me.ToolStripButton1})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(714, 25)
        Me.ToolStrip3.TabIndex = 286
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Navy
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok4
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(101, 22)
        Me.lblEstado.Text = "Lista de Aportes"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompraPagadaToolStripMenuItem, Me.ConpraAlCréditoToolStripMenuItem})
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(70, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'CompraPagadaToolStripMenuItem
        '
        Me.CompraPagadaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesdeExcelToolStripMenuItem, Me.DefaulToolStripMenuItem})
        Me.CompraPagadaToolStripMenuItem.Name = "CompraPagadaToolStripMenuItem"
        Me.CompraPagadaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CompraPagadaToolStripMenuItem.Text = "Aporte de existencia"
        '
        'ConpraAlCréditoToolStripMenuItem
        '
        Me.ConpraAlCréditoToolStripMenuItem.Name = "ConpraAlCréditoToolStripMenuItem"
        Me.ConpraAlCréditoToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ConpraAlCréditoToolStripMenuItem.Text = "Aporte de Dinero"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.pencil
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripButton1.Text = "Consultar compras"
        '
        'lsvProduccion
        '
        Me.lsvProduccion.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProduccion.FullRowSelect = True
        Me.lsvProduccion.GridLines = True
        Me.lsvProduccion.HideSelection = False
        Me.lsvProduccion.Location = New System.Drawing.Point(0, 25)
        Me.lsvProduccion.MultiSelect = False
        Me.lsvProduccion.Name = "lsvProduccion"
        Me.lsvProduccion.Size = New System.Drawing.Size(714, 337)
        Me.lsvProduccion.TabIndex = 290
        Me.lsvProduccion.UseCompatibleStateImageBehavior = False
        Me.lsvProduccion.View = System.Windows.Forms.View.Details
        '
        'DesdeExcelToolStripMenuItem
        '
        Me.DesdeExcelToolStripMenuItem.Name = "DesdeExcelToolStripMenuItem"
        Me.DesdeExcelToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DesdeExcelToolStripMenuItem.Text = "Desde Excel"
        '
        'DefaulToolStripMenuItem
        '
        Me.DefaulToolStripMenuItem.Name = "DefaulToolStripMenuItem"
        Me.DefaulToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DefaulToolStripMenuItem.Text = "Default"
        '
        'frmListadoAportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 362)
        Me.Controls.Add(Me.lsvProduccion)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmListadoAportes"
        Me.Text = "frmListadoAportes"
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents CompraPagadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConpraAlCréditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lsvProduccion As System.Windows.Forms.ListView
    Friend WithEvents DesdeExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefaulToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
