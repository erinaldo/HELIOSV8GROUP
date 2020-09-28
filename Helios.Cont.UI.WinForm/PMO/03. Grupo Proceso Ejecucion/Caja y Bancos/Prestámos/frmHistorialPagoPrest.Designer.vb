<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialPagoPrest
    Inherits frmMaster

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorialPagoPrest))
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor18 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor19 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor20 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.lbltipoanticipo = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.dgvCompras = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.lbltipoanticipo.SuspendLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltipoanticipo
        '
        Me.lbltipoanticipo.BackColor = System.Drawing.Color.Transparent
        Me.lbltipoanticipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbltipoanticipo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.ToolStripButton2})
        Me.lbltipoanticipo.Location = New System.Drawing.Point(0, 0)
        Me.lbltipoanticipo.Name = "lbltipoanticipo"
        Me.lbltipoanticipo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.lbltipoanticipo.Size = New System.Drawing.Size(888, 47)
        Me.lbltipoanticipo.TabIndex = 417
        Me.lbltipoanticipo.Text = "ToolStrip3"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.SaveToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(106, 44)
        Me.SaveToolStripButton.Text = "&Editar pago"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 47)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PrintToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(114, 44)
        Me.PrintToolStripButton.Text = "Eliminar pago"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 47)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(130, 44)
        Me.ToolStripButton2.Text = "Actualizar Pagos"
        '
        'dgvCompras
        '
        Me.dgvCompras.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompras.FreezeCaption = False
        Me.dgvCompras.Location = New System.Drawing.Point(0, 47)
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.Size = New System.Drawing.Size(888, 399)
        Me.dgvCompras.TabIndex = 419
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "id"
        GridColumnDescriptor11.MappingName = "idDocumento"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 50
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Fecha"
        GridColumnDescriptor12.MappingName = "fecha"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "Tipo Documento"
        GridColumnDescriptor13.MappingName = "tipoDoc"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 120
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "Nùmro doc."
        GridColumnDescriptor14.MappingName = "numroDoc"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 70
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "Moneda"
        GridColumnDescriptor15.MappingName = "moneda"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 70
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.HeaderText = "t/c"
        GridColumnDescriptor16.MappingName = "tipoCambio"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.SerializedImageArray = ""
        GridColumnDescriptor16.Width = 50
        GridColumnDescriptor17.HeaderImage = Nothing
        GridColumnDescriptor17.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor17.HeaderText = "Pago"
        GridColumnDescriptor17.MappingName = "montoSoles"
        GridColumnDescriptor17.ReadOnly = True
        GridColumnDescriptor17.SerializedImageArray = ""
        GridColumnDescriptor17.Width = 75
        GridColumnDescriptor18.HeaderImage = Nothing
        GridColumnDescriptor18.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor18.HeaderText = "ME."
        GridColumnDescriptor18.MappingName = "montoUsd"
        GridColumnDescriptor18.ReadOnly = True
        GridColumnDescriptor18.SerializedImageArray = ""
        GridColumnDescriptor18.Width = 75
        GridColumnDescriptor19.HeaderImage = Nothing
        GridColumnDescriptor19.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor19.MappingName = "operacion"
        GridColumnDescriptor19.ReadOnly = True
        GridColumnDescriptor19.SerializedImageArray = ""
        GridColumnDescriptor19.Width = 50
        GridColumnDescriptor20.HeaderImage = Nothing
        GridColumnDescriptor20.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor20.HeaderText = "TipoPago"
        GridColumnDescriptor20.MappingName = "tipo"
        GridColumnDescriptor20.SerializedImageArray = ""
        GridColumnDescriptor20.Width = 80
        Me.dgvCompras.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17, GridColumnDescriptor18, GridColumnDescriptor19, GridColumnDescriptor20})
        Me.dgvCompras.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoCambio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("montoSoles"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("montoUsd"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("operacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo")})
        Me.dgvCompras.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvCompras.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvCompras.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvCompras.Text = "gridGroupingControl1"
        Me.dgvCompras.VersionInfo = "12.2400.0.20"
        '
        'frmHistorialPagoPrest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(888, 446)
        Me.Controls.Add(Me.dgvCompras)
        Me.Controls.Add(Me.lbltipoanticipo)
        Me.Name = "frmHistorialPagoPrest"
        Me.ShowIcon = False
        Me.Text = ""
        Me.lbltipoanticipo.ResumeLayout(False)
        Me.lbltipoanticipo.PerformLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltipoanticipo As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Private WithEvents dgvCompras As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
