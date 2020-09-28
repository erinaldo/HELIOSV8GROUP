<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabControlSubordinados
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabControlSubordinados))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePickerAdv1 = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtIdentificacion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCargo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.cboCargosAResponsabilidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.dgvSubordinados = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdentificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.cboCargosAResponsabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSubordinados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DateTimePickerAdv1)
        Me.Panel1.Controls.Add(Me.txtIdentificacion)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtCargo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1109, 48)
        Me.Panel1.TabIndex = 0
        '
        'DateTimePickerAdv1
        '
        Me.DateTimePickerAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.DateTimePickerAdv1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.DateTimePickerAdv1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.DateTimePickerAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateTimePickerAdv1.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.DateTimePickerAdv1.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.DateTimePickerAdv1.CalendarSize = New System.Drawing.Size(189, 176)
        Me.DateTimePickerAdv1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DateTimePickerAdv1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTimePickerAdv1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTimePickerAdv1.Checked = False
        Me.DateTimePickerAdv1.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.DateTimePickerAdv1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePickerAdv1.DropDownImage = Nothing
        Me.DateTimePickerAdv1.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DateTimePickerAdv1.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateTimePickerAdv1.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.DateTimePickerAdv1.EnableNullDate = False
        Me.DateTimePickerAdv1.EnableNullKeys = False
        Me.DateTimePickerAdv1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAdv1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateTimePickerAdv1.Location = New System.Drawing.Point(852, 16)
        Me.DateTimePickerAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateTimePickerAdv1.MinValue = New Date(CType(0, Long))
        Me.DateTimePickerAdv1.Name = "DateTimePickerAdv1"
        Me.DateTimePickerAdv1.ShowCheckBox = False
        Me.DateTimePickerAdv1.Size = New System.Drawing.Size(260, 23)
        Me.DateTimePickerAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.DateTimePickerAdv1.TabIndex = 681
        Me.DateTimePickerAdv1.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.DateTimePickerAdv1.Visible = False
        '
        'txtIdentificacion
        '
        Me.txtIdentificacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIdentificacion.BeforeTouchSize = New System.Drawing.Size(354, 23)
        Me.txtIdentificacion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdentificacion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIdentificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentificacion.ForeColor = System.Drawing.Color.LightGray
        Me.txtIdentificacion.Location = New System.Drawing.Point(492, 16)
        Me.txtIdentificacion.Metrocolor = System.Drawing.Color.Black
        Me.txtIdentificacion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtIdentificacion.Name = "txtIdentificacion"
        Me.txtIdentificacion.ReadOnly = True
        Me.txtIdentificacion.Size = New System.Drawing.Size(354, 23)
        Me.txtIdentificacion.TabIndex = 680
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(355, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 21)
        Me.Label2.TabIndex = 679
        Me.Label2.Text = "Identificación:"
        '
        'txtCargo
        '
        Me.txtCargo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCargo.BeforeTouchSize = New System.Drawing.Size(354, 23)
        Me.txtCargo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCargo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargo.ForeColor = System.Drawing.Color.LightGray
        Me.txtCargo.Location = New System.Drawing.Point(109, 14)
        Me.txtCargo.Metrocolor = System.Drawing.Color.Black
        Me.txtCargo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.ReadOnly = True
        Me.txtCargo.Size = New System.Drawing.Size(215, 23)
        Me.txtCargo.TabIndex = 678
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(33, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cargo:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BunifuThinButton23)
        Me.Panel2.Controls.Add(Me.cboCargosAResponsabilidad)
        Me.Panel2.Controls.Add(Me.dgvSubordinados)
        Me.Panel2.Controls.Add(Me.BunifuThinButton21)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1109, 403)
        Me.Panel2.TabIndex = 1
        '
        'BunifuThinButton23
        '
        Me.BunifuThinButton23.ActiveBorderThickness = 1
        Me.BunifuThinButton23.ActiveCornerRadius = 20
        Me.BunifuThinButton23.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton23.BackgroundImage = CType(resources.GetObject("BunifuThinButton23.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton23.ButtonText = "CONSULTAR"
        Me.BunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton23.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton23.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton23.IdleBorderThickness = 1
        Me.BunifuThinButton23.IdleCornerRadius = 20
        Me.BunifuThinButton23.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton23.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton23.Location = New System.Drawing.Point(320, 22)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(99, 35)
        Me.BunifuThinButton23.TabIndex = 700
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboCargosAResponsabilidad
        '
        Me.cboCargosAResponsabilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboCargosAResponsabilidad.BeforeTouchSize = New System.Drawing.Size(297, 21)
        Me.cboCargosAResponsabilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCargosAResponsabilidad.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboCargosAResponsabilidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCargosAResponsabilidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboCargosAResponsabilidad.Location = New System.Drawing.Point(16, 32)
        Me.cboCargosAResponsabilidad.MetroBorderColor = System.Drawing.Color.DimGray
        Me.cboCargosAResponsabilidad.Name = "cboCargosAResponsabilidad"
        Me.cboCargosAResponsabilidad.Size = New System.Drawing.Size(297, 21)
        Me.cboCargosAResponsabilidad.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboCargosAResponsabilidad.TabIndex = 699
        '
        'dgvSubordinados
        '
        Me.dgvSubordinados.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvSubordinados.BackColor = System.Drawing.Color.Black
        Me.dgvSubordinados.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Black
        Me.dgvSubordinados.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSubordinados.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvSubordinados.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.dgvSubordinados.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.dgvSubordinados.Location = New System.Drawing.Point(13, 64)
        Me.dgvSubordinados.Name = "dgvSubordinados"
        Me.dgvSubordinados.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.dgvSubordinados.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvSubordinados.Size = New System.Drawing.Size(1081, 313)
        Me.dgvSubordinados.TabIndex = 698
        Me.dgvSubordinados.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderText = "idUsuario"
        GridColumnDescriptor1.MappingName = "idUsuario"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "Detalle"
        GridColumnDescriptor2.MappingName = "idCargo"
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.HeaderText = "Cargo"
        GridColumnDescriptor3.MappingName = "nombreCargo"
        GridColumnDescriptor3.Width = 200
        GridColumnDescriptor4.MappingName = "Dni"
        GridColumnDescriptor4.Width = 110
        GridColumnDescriptor5.HeaderText = "Nombres"
        GridColumnDescriptor5.MappingName = "nombrePersona"
        GridColumnDescriptor5.Width = 400
        Me.dgvSubordinados.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.dgvSubordinados.TableDescriptor.TableOptions.CaptionRowHeight = 22
        Me.dgvSubordinados.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvSubordinados.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None
        Me.dgvSubordinados.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.dgvSubordinados.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvSubordinados.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idUsuario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idCargo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombreCargo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Dni"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombrePersona")})
        Me.dgvSubordinados.Text = "gridGroupingControl1"
        Me.dgvSubordinados.UseRightToLeftCompatibleTextBox = True
        Me.dgvSubordinados.VersionInfo = "12.1400.0.43"
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.WhiteSmoke
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "AGREGAR PERSONAL"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.WhiteSmoke
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(428, 22)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(149, 35)
        Me.BunifuThinButton21.TabIndex = 697
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(205, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cargos a Responsabilidad"
        '
        'TabControlSubordinados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TabControlSubordinados"
        Me.Size = New System.Drawing.Size(1109, 451)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdentificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.cboCargosAResponsabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSubordinados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIdentificacion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCargo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents DateTimePickerAdv1 As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Private WithEvents dgvSubordinados As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents cboCargosAResponsabilidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
End Class
