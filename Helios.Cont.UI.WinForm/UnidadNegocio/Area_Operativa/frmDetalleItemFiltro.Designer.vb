<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDetalleItemFiltro
    Inherits frmMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleItemFiltro))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.dgvExistencias = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.bgCombos = New System.ComponentModel.BackgroundWorker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblNombreComposicion = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        CType(Me.dgvExistencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel19.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvExistencias
        '
        Me.dgvExistencias.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvExistencias.BackColor = System.Drawing.SystemColors.Window
        Me.dgvExistencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExistencias.Location = New System.Drawing.Point(0, 23)
        Me.dgvExistencias.Name = "dgvExistencias"
        Me.dgvExistencias.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvExistencias.Size = New System.Drawing.Size(579, 284)
        Me.dgvExistencias.TabIndex = 448
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 40
        GridColumnDescriptor2.HeaderText = "DESCRIPCIÓN"
        GridColumnDescriptor2.MappingName = "descripcionComposicion"
        GridColumnDescriptor2.Name = "descripcionComposicion"
        GridColumnDescriptor2.Width = 400
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor3.HeaderText = "ESTADO"
        GridColumnDescriptor3.MappingName = "boton"
        GridColumnDescriptor3.Name = "boton"
        GridColumnDescriptor3.Width = 100
        Me.dgvExistencias.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.dgvExistencias.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionComposicion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("boton")})
        Me.dgvExistencias.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvExistencias.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvExistencias.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvExistencias.Text = "gridGroupingControl1"
        Me.dgvExistencias.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.dgvExistencias.UseRightToLeftCompatibleTextBox = True
        Me.dgvExistencias.VersionInfo = "12.2400.0.20"
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.GradientPanel1)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(0, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(579, 12)
        Me.Panel19.TabIndex = 449
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BackgroundImage = CType(resources.GetObject("GradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(579, 12)
        Me.GradientPanel1.TabIndex = 699
        '
        'TextFiltrar
        '
        Me.TextFiltrar.BackColor = System.Drawing.Color.White
        Me.TextFiltrar.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextFiltrar.BorderColor = System.Drawing.Color.LightCoral
        Me.TextFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFiltrar.CornerRadius = 1
        Me.TextFiltrar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextFiltrar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFiltrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextFiltrar.Location = New System.Drawing.Point(128, 6)
        Me.TextFiltrar.Metrocolor = System.Drawing.Color.LightCoral
        Me.TextFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextFiltrar.Multiline = True
        Me.TextFiltrar.Name = "TextFiltrar"
        Me.TextFiltrar.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.TextFiltrar.Size = New System.Drawing.Size(377, 22)
        Me.TextFiltrar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextFiltrar.TabIndex = 526
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(18, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 524
        Me.Label8.Text = "BUSCAR  (INSUMO)"
        '
        'bgCombos
        '
        Me.bgCombos.WorkerSupportsCancellation = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(579, 349)
        Me.Panel1.TabIndex = 451
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvExistencias)
        Me.Panel4.Controls.Add(Me.lblNombreComposicion)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 42)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(579, 307)
        Me.Panel4.TabIndex = 527
        '
        'lblNombreComposicion
        '
        Me.lblNombreComposicion.BackColor = System.Drawing.Color.Silver
        Me.lblNombreComposicion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNombreComposicion.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombreComposicion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNombreComposicion.Location = New System.Drawing.Point(0, 0)
        Me.lblNombreComposicion.Name = "lblNombreComposicion"
        Me.lblNombreComposicion.Size = New System.Drawing.Size(579, 23)
        Me.lblNombreComposicion.TabIndex = 449
        Me.lblNombreComposicion.Text = "Productos"
        Me.lblNombreComposicion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.TextFiltrar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(579, 42)
        Me.Panel5.TabIndex = 530
        '
        'frmDetalleItemFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 45
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.ForeColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(20, 3)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(45, 45)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(65, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Productos"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(579, 361)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel19)
        Me.Name = "frmDetalleItemFiltro"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ""
        CType(Me.dgvExistencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel19.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents dgvExistencias As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel19 As Panel
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents bgCombos As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextFiltrar As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblNombreComposicion As Label
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Panel5 As Panel
End Class
