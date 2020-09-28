Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormExistenciaPrecioV1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormExistenciaPrecioV1))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GridProductos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BunifuiOSSwitch1 = New Bunifu.Framework.UI.BunifuiOSSwitch()
        Me.BunifuThinButton22 = New Bunifu.Framework.UI.BunifuThinButton2()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.BunifuThinButton21.Location = New System.Drawing.Point(326, 17)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(131, 37)
        Me.BunifuThinButton21.TabIndex = 670
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.CornerRadius = 4
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFiltrar.FarImage = CType(resources.GetObject("txtFiltrar.FarImage"), System.Drawing.Image)
        Me.txtFiltrar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.White
        Me.txtFiltrar.Location = New System.Drawing.Point(16, 27)
        Me.txtFiltrar.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFiltrar.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFiltrar.Size = New System.Drawing.Size(303, 22)
        Me.txtFiltrar.TabIndex = 669
        Me.txtFiltrar.ThemesEnabled = False
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.GridProductos)
        Me.GradientPanel3.Location = New System.Drawing.Point(15, 57)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(1066, 599)
        Me.GradientPanel3.TabIndex = 668
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
        Me.GridProductos.Size = New System.Drawing.Size(1064, 597)
        Me.GridProductos.TabIndex = 518
        Me.GridProductos.TableDescriptor.AllowNew = False
        Me.GridProductos.TableDescriptor.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor1.HeaderText = "GRUPO"
        GridColumnDescriptor1.MappingName = "categoria"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 101
        GridColumnDescriptor2.HeaderText = "GR."
        GridColumnDescriptor2.MappingName = "gravado"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 52
        GridColumnDescriptor3.MappingName = "idproducto"
        GridColumnDescriptor3.Width = 80
        GridColumnDescriptor4.HeaderText = "CODIGO"
        GridColumnDescriptor4.MappingName = "codigo"
        GridColumnDescriptor4.Width = 122
        GridColumnDescriptor5.HeaderText = "PRODUCTO"
        GridColumnDescriptor5.MappingName = "producto"
        GridColumnDescriptor5.Width = 264
        GridColumnDescriptor6.HeaderText = "U.M."
        GridColumnDescriptor6.MappingName = "unidad"
        GridColumnDescriptor6.Width = 68
        GridColumnDescriptor7.HeaderText = "PRESENTACIÓN"
        GridColumnDescriptor7.MappingName = "composicion"
        GridColumnDescriptor7.Width = 140
        GridColumnDescriptor8.HeaderText = "TIPO EX."
        GridColumnDescriptor8.MappingName = "tipoexistencia"
        GridColumnDescriptor8.Width = 83
        GridColumnDescriptor9.HeaderText = "STATUS"
        GridColumnDescriptor9.MappingName = "estado"
        GridColumnDescriptor9.Width = 90
        Me.GridProductos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.GridProductos.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridProductos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridProductos.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridProductos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("composicion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoexistencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("gravado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("categoria"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.GridProductos.Text = "gridGroupingControl1"
        Me.GridProductos.UseRightToLeftCompatibleTextBox = True
        Me.GridProductos.VersionInfo = "12.2400.0.20"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 18)
        Me.Label4.TabIndex = 667
        Me.Label4.Text = "Administración de precios"
        '
        'BunifuiOSSwitch1
        '
        Me.BunifuiOSSwitch1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuiOSSwitch1.BackgroundImage = CType(resources.GetObject("BunifuiOSSwitch1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuiOSSwitch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuiOSSwitch1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuiOSSwitch1.Location = New System.Drawing.Point(464, 25)
        Me.BunifuiOSSwitch1.Name = "BunifuiOSSwitch1"
        Me.BunifuiOSSwitch1.OffColor = System.Drawing.Color.Gray
        Me.BunifuiOSSwitch1.OnColor = System.Drawing.SystemColors.Highlight
        Me.BunifuiOSSwitch1.Size = New System.Drawing.Size(43, 25)
        Me.BunifuiOSSwitch1.TabIndex = 672
        Me.BunifuiOSSwitch1.Value = False
        '
        'BunifuThinButton22
        '
        Me.BunifuThinButton22.ActiveBorderThickness = 1
        Me.BunifuThinButton22.ActiveCornerRadius = 20
        Me.BunifuThinButton22.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.BunifuThinButton22.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton22.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.BunifuThinButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton22.BackgroundImage = CType(resources.GetObject("BunifuThinButton22.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton22.ButtonText = "Unidad Comercial"
        Me.BunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton22.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton22.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleBorderThickness = 1
        Me.BunifuThinButton22.IdleCornerRadius = 20
        Me.BunifuThinButton22.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.BunifuThinButton22.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.BunifuThinButton22.Location = New System.Drawing.Point(514, 17)
        Me.BunifuThinButton22.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton22.Name = "BunifuThinButton22"
        Me.BunifuThinButton22.Size = New System.Drawing.Size(131, 37)
        Me.BunifuThinButton22.TabIndex = 673
        Me.BunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormExistenciaPrecioV1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1095, 655)
        Me.Controls.Add(Me.BunifuThinButton22)
        Me.Controls.Add(Me.BunifuiOSSwitch1)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FormExistenciaPrecioV1"
        Me.ShowIcon = False
        Me.Text = "Precios"
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents txtFiltrar As Tools.TextBoxExt
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Private WithEvents GridProductos As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label4 As Label
    Friend WithEvents BunifuiOSSwitch1 As Bunifu.Framework.UI.BunifuiOSSwitch
    Friend WithEvents BunifuThinButton22 As Bunifu.Framework.UI.BunifuThinButton2
End Class
