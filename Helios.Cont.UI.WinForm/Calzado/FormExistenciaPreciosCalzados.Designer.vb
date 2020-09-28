Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormExistenciaPreciosCalzados
    Inherits MetroForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormExistenciaPreciosCalzados))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.BunifuThinButton25 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.DockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GridProductos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockingClientPanel1.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuThinButton25
        '
        Me.BunifuThinButton25.ActiveBorderThickness = 1
        Me.BunifuThinButton25.ActiveCornerRadius = 20
        Me.BunifuThinButton25.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton25.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton25.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton25.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton25.BackgroundImage = CType(resources.GetObject("BunifuThinButton25.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton25.ButtonText = "Editar"
        Me.BunifuThinButton25.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton25.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton25.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton25.IdleBorderThickness = 1
        Me.BunifuThinButton25.IdleCornerRadius = 20
        Me.BunifuThinButton25.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton25.IdleForecolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuThinButton25.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BunifuThinButton25.Location = New System.Drawing.Point(459, 12)
        Me.BunifuThinButton25.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton25.Name = "BunifuThinButton25"
        Me.BunifuThinButton25.Size = New System.Drawing.Size(95, 37)
        Me.BunifuThinButton25.TabIndex = 743
        Me.BunifuThinButton25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(261, 29)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.CornerRadius = 4
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFiltrar.FarImage = CType(resources.GetObject("txtFiltrar.FarImage"), System.Drawing.Image)
        Me.txtFiltrar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.White
        Me.txtFiltrar.Location = New System.Drawing.Point(12, 22)
        Me.txtFiltrar.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFiltrar.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFiltrar.Size = New System.Drawing.Size(303, 22)
        Me.txtFiltrar.TabIndex = 741
        Me.txtFiltrar.ThemesEnabled = False
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "NUEVO  PRODUCTO"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(322, 12)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(131, 37)
        Me.BunifuThinButton21.TabIndex = 742
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dockingManager1
        '
        Me.dockingManager1.AnimateAutoHiddenWindow = True
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideTabForeColor = System.Drawing.Color.Empty
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DragProviderStyle = Syncfusion.Windows.Forms.Tools.DragProviderStyle.Office2016Black
        Me.dockingManager1.HostControl = Me
        Me.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dockingManager1.Office2007Theme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.dockingManager1.Office2010Theme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.dockingManager1.ReduceFlickeringInRtl = False
        Me.dockingManager1.ShowCaption = False
        Me.dockingManager1.ThemesEnabled = True
        Me.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'DockingClientPanel1
        '
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DockingClientPanel1.Controls.Add(Me.GradientPanel1)
        Me.DockingClientPanel1.Controls.Add(Me.txtFiltrar)
        Me.DockingClientPanel1.Controls.Add(Me.BunifuThinButton25)
        Me.DockingClientPanel1.Controls.Add(Me.BunifuThinButton21)
        Me.DockingClientPanel1.Location = New System.Drawing.Point(4, -10)
        Me.DockingClientPanel1.Name = "DockingClientPanel1"
        Me.DockingClientPanel1.Size = New System.Drawing.Size(1215, 672)
        Me.DockingClientPanel1.TabIndex = 744
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.DimGray
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.GridProductos)
        Me.GradientPanel1.Location = New System.Drawing.Point(12, 52)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1182, 351)
        Me.GradientPanel1.TabIndex = 744
        '
        'GridProductos
        '
        Me.GridProductos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridProductos.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridProductos.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridProductos.BackColor = System.Drawing.Color.Black
        Me.GridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridProductos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridProductos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.GridProductos.Location = New System.Drawing.Point(0, 0)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridProductos.Size = New System.Drawing.Size(1180, 349)
        Me.GridProductos.TabIndex = 519
        Me.GridProductos.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderText = "GRUPO"
        GridColumnDescriptor1.MappingName = "categoria"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 101
        GridColumnDescriptor2.HeaderText = "AFEC."
        GridColumnDescriptor2.MappingName = "gravado"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 52
        GridColumnDescriptor3.MappingName = "idproducto"
        GridColumnDescriptor3.Width = 80
        GridColumnDescriptor4.HeaderText = "CODIGO"
        GridColumnDescriptor4.MappingName = "codigo"
        GridColumnDescriptor4.Width = 115
        GridColumnDescriptor5.HeaderText = "PRODUCTO"
        GridColumnDescriptor5.MappingName = "producto"
        GridColumnDescriptor5.Width = 264
        GridColumnDescriptor6.HeaderText = "U.M."
        GridColumnDescriptor6.MappingName = "unidad"
        GridColumnDescriptor6.Width = 65
        GridColumnDescriptor7.HeaderText = "PRESENTACIÓN"
        GridColumnDescriptor7.MappingName = "composicion"
        GridColumnDescriptor7.Width = 0
        GridColumnDescriptor8.HeaderText = "TIPO EX."
        GridColumnDescriptor8.MappingName = "tipoexistencia"
        GridColumnDescriptor8.Width = 80
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor9.HeaderText = "STATUS"
        GridColumnDescriptor9.MappingName = "estado"
        GridColumnDescriptor9.Width = 85
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor10.HeaderText = "SEL"
        GridColumnDescriptor10.MappingName = "sel"
        GridColumnDescriptor10.Width = 35
        Me.GridProductos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        Me.GridProductos.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridProductos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridProductos.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridProductos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("sel"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("composicion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoexistencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("gravado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("categoria"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.GridProductos.Text = "gridGroupingControl1"
        Me.GridProductos.UseRightToLeftCompatibleTextBox = True
        Me.GridProductos.VersionInfo = "12.2400.0.20"
        '
        'FormExistenciaPreciosCalzados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1231, 665)
        Me.Controls.Add(Me.DockingClientPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormExistenciaPreciosCalzados"
        Me.ShowIcon = False
        Me.Text = "FormExistenciaPreciosCalzados"
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockingClientPanel1.ResumeLayout(False)
        Me.DockingClientPanel1.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BunifuThinButton25 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents txtFiltrar As Tools.TextBoxExt
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Private WithEvents dockingManager1 As Tools.DockingManager
    Friend WithEvents DockingClientPanel1 As Tools.DockingClientPanel
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents GridProductos As Grid.Grouping.GridGroupingControl
End Class
