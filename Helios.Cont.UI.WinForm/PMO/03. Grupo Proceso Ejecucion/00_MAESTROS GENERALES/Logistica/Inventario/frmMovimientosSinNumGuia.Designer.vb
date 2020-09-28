<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientosSinNumGuia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientosSinNumGuia))
        Dim GridColumnDescriptor34 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor35 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor36 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor37 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor38 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor39 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor40 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor41 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor42 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor43 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor44 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel42 = New System.Windows.Forms.Panel()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.dgvPendiente = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel42.SuspendLayout()
        CType(Me.dgvPendiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel42
        '
        Me.Panel42.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Panel42.Controls.Add(Me.Label66)
        Me.Panel42.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel42.Location = New System.Drawing.Point(0, 0)
        Me.Panel42.Name = "Panel42"
        Me.Panel42.Size = New System.Drawing.Size(914, 37)
        Me.Panel42.TabIndex = 409
        '
        'Label66
        '
        Me.Label66.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.Black
        Me.Label66.Image = CType(resources.GetObject("Label66.Image"), System.Drawing.Image)
        Me.Label66.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label66.Location = New System.Drawing.Point(5, 6)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(206, 25)
        Me.Label66.TabIndex = 0
        Me.Label66.Text = "GUIA DE REMISION / Pendientes"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvPendiente
        '
        Me.dgvPendiente.BackColor = System.Drawing.SystemColors.Window
        Me.dgvPendiente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendiente.FreezeCaption = False
        Me.dgvPendiente.Location = New System.Drawing.Point(0, 69)
        Me.dgvPendiente.Name = "dgvPendiente"
        Me.dgvPendiente.Size = New System.Drawing.Size(914, 430)
        Me.dgvPendiente.TabIndex = 410
        GridColumnDescriptor34.HeaderImage = Nothing
        GridColumnDescriptor34.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor34.HeaderText = "ID"
        GridColumnDescriptor34.MappingName = "idDocumento"
        GridColumnDescriptor34.Name = "idDocumento"
        GridColumnDescriptor34.SerializedImageArray = ""
        GridColumnDescriptor34.Width = 70
        GridColumnDescriptor35.HeaderImage = Nothing
        GridColumnDescriptor35.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor35.MappingName = "idEmpresa"
        GridColumnDescriptor35.Name = "idEmpresa"
        GridColumnDescriptor35.SerializedImageArray = ""
        GridColumnDescriptor36.HeaderImage = Nothing
        GridColumnDescriptor36.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor36.MappingName = "idCentroCosto"
        GridColumnDescriptor36.Name = "idCentroCosto"
        GridColumnDescriptor36.SerializedImageArray = ""
        GridColumnDescriptor37.HeaderImage = Nothing
        GridColumnDescriptor37.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor37.HeaderText = "Fecha"
        GridColumnDescriptor37.MappingName = "fechaDoc"
        GridColumnDescriptor37.Name = "fechaDoc"
        GridColumnDescriptor37.SerializedImageArray = ""
        GridColumnDescriptor37.Width = 90
        GridColumnDescriptor38.HeaderImage = Nothing
        GridColumnDescriptor38.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor38.HeaderText = "Tipo Doc."
        GridColumnDescriptor38.MappingName = "tipoDoc"
        GridColumnDescriptor38.Name = "tipoDoc"
        GridColumnDescriptor38.SerializedImageArray = ""
        GridColumnDescriptor38.Width = 80
        GridColumnDescriptor39.HeaderImage = Nothing
        GridColumnDescriptor39.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor39.HeaderText = "Estado"
        GridColumnDescriptor39.MappingName = "estadoGuia"
        GridColumnDescriptor39.Name = "estadoGuia"
        GridColumnDescriptor39.SerializedImageArray = ""
        GridColumnDescriptor39.Width = 90
        GridColumnDescriptor40.HeaderImage = Nothing
        GridColumnDescriptor40.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor40.HeaderText = "Importe MN"
        GridColumnDescriptor40.MappingName = "importeMN"
        GridColumnDescriptor40.Name = "importeMN"
        GridColumnDescriptor40.SerializedImageArray = ""
        GridColumnDescriptor40.Width = 90
        GridColumnDescriptor41.HeaderImage = Nothing
        GridColumnDescriptor41.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor41.HeaderText = "Importe ME"
        GridColumnDescriptor41.MappingName = "importeME"
        GridColumnDescriptor41.Name = "importeME"
        GridColumnDescriptor41.SerializedImageArray = ""
        GridColumnDescriptor41.Width = 90
        GridColumnDescriptor42.HeaderImage = Nothing
        GridColumnDescriptor42.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor42.HeaderText = "Empresa"
        GridColumnDescriptor42.MappingName = "nombreEmpresa"
        GridColumnDescriptor42.Name = "nombreEmpresa"
        GridColumnDescriptor42.SerializedImageArray = ""
        GridColumnDescriptor42.Width = 200
        GridColumnDescriptor43.HeaderImage = Nothing
        GridColumnDescriptor43.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor43.HeaderText = "Establecimiento"
        GridColumnDescriptor43.MappingName = "nombreEstablecimiento"
        GridColumnDescriptor43.Name = "nombreEstablecimiento"
        GridColumnDescriptor43.SerializedImageArray = ""
        GridColumnDescriptor43.Width = 200
        GridColumnDescriptor44.HeaderImage = Nothing
        GridColumnDescriptor44.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor44.MappingName = "idPadre"
        GridColumnDescriptor44.Name = "idPadre"
        GridColumnDescriptor44.SerializedImageArray = ""
        Me.dgvPendiente.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor34, GridColumnDescriptor35, GridColumnDescriptor36, GridColumnDescriptor37, GridColumnDescriptor38, GridColumnDescriptor39, GridColumnDescriptor40, GridColumnDescriptor41, GridColumnDescriptor42, GridColumnDescriptor43, GridColumnDescriptor44})
        Me.dgvPendiente.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombreEmpresa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombreEstablecimiento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estadoGuia")})
        Me.dgvPendiente.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvPendiente.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvPendiente.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvPendiente.Text = "gridGroupingControl1"
        Me.dgvPendiente.VersionInfo = "12.2400.0.20"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 37)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(914, 32)
        Me.ToolStrip1.TabIndex = 411
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(157, 29)
        Me.ToolStripButton1.Text = "Insertar númeración guía"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(86, 29)
        Me.ToolStripButton2.Text = "Actualizar"
        '
        'frmMovimientosSinNumGuia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(914, 499)
        Me.Controls.Add(Me.dgvPendiente)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel42)
        Me.Name = "frmMovimientosSinNumGuia"
        Me.ShowIcon = False
        Me.Text = "Movimientos sin número de guía"
        Me.Panel42.ResumeLayout(False)
        CType(Me.dgvPendiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel42 As Panel
    Friend WithEvents Label66 As Label
    Private WithEvents dgvPendiente As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
End Class
