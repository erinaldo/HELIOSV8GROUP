Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCMaestroProgramacion
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCMaestroProgramacion))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.GridCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.RoundButton28 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.pnBody = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton11 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.pnPrincipal.SuspendLayout()
        CType(Me.GridCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBody.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(30, 40)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(31, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(204, 20)
        Me.Label10.TabIndex = 693
        Me.Label10.Text = "HORARIOS DE SALIDA"
        '
        'pnPrincipal
        '
        Me.pnPrincipal.BackColor = System.Drawing.Color.White
        Me.pnPrincipal.Controls.Add(Me.GridCompra)
        Me.pnPrincipal.Controls.Add(Me.RoundButton28)
        Me.pnPrincipal.Controls.Add(Me.TextFechaProgramada)
        Me.pnPrincipal.Controls.Add(Me.Line21)
        Me.pnPrincipal.Controls.Add(Me.Label10)
        Me.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnPrincipal.Location = New System.Drawing.Point(0, 40)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(1104, 343)
        Me.pnPrincipal.TabIndex = 8
        '
        'GridCompra
        '
        Me.GridCompra.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.SelectAll
        Me.GridCompra.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.GridCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridCompra.BackColor = System.Drawing.Color.White
        Me.GridCompra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCompra.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.GridCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridCompra.Location = New System.Drawing.Point(35, 76)
        Me.GridCompra.Name = "GridCompra"
        Me.GridCompra.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridCompra.Size = New System.Drawing.Size(1066, 255)
        Me.GridCompra.TabIndex = 733
        Me.GridCompra.TableDescriptor.AllowNew = False
        Me.GridCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.GridCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GridCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.GridCompra.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.GridCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.GridCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.GridCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.GridCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.GridCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.GridCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "TIPO"
        GridColumnDescriptor2.MappingName = "tipo"
        GridColumnDescriptor2.Name = "tipo"
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.HeaderText = "FECHA"
        GridColumnDescriptor3.MappingName = "Fecha"
        GridColumnDescriptor3.Name = "Fecha"
        GridColumnDescriptor3.Width = 120
        GridColumnDescriptor4.HeaderText = "HORA"
        GridColumnDescriptor4.MappingName = "ColHora"
        GridColumnDescriptor4.Name = "ColHora"
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.MappingName = "HoraID"
        GridColumnDescriptor5.Name = "HoraID"
        GridColumnDescriptor5.Width = 0
        GridColumnDescriptor6.MappingName = "idBus"
        GridColumnDescriptor6.Name = "idBus"
        GridColumnDescriptor6.Width = 0
        GridColumnDescriptor7.HeaderText = "TRANSPORTE"
        GridColumnDescriptor7.MappingName = "nombreBus"
        GridColumnDescriptor7.Name = "nombreBus"
        GridColumnDescriptor7.Width = 200
        GridColumnDescriptor8.HeaderText = "RUTA"
        GridColumnDescriptor8.MappingName = "RutaID"
        GridColumnDescriptor8.Name = "RutaID"
        GridColumnDescriptor8.Width = 0
        GridColumnDescriptor9.HeaderText = "ORIGEN"
        GridColumnDescriptor9.MappingName = "origen"
        GridColumnDescriptor9.Name = "origen"
        GridColumnDescriptor9.Width = 250
        GridColumnDescriptor10.HeaderText = "DESTINO"
        GridColumnDescriptor10.MappingName = "Destino"
        GridColumnDescriptor10.Name = "Destino"
        GridColumnDescriptor10.Width = 250
        GridColumnDescriptor11.HeaderText = "ESTADO"
        GridColumnDescriptor11.MappingName = "Estado"
        GridColumnDescriptor11.Name = "Estado"
        GridColumnDescriptor11.Width = 0
        GridColumnDescriptor12.HeaderText = "MANIFIESTO"
        GridColumnDescriptor12.MappingName = "manifiesto"
        GridColumnDescriptor12.Name = "manifiesto"
        GridColumnDescriptor12.Width = 120
        GridColumnDescriptor13.MappingName = "programacionID"
        GridColumnDescriptor13.Name = "programacionID"
        GridColumnDescriptor13.Width = 0
        GridColumnDescriptor14.MappingName = "ubigeoOrigen"
        GridColumnDescriptor14.Name = "ubigeoOrigen"
        GridColumnDescriptor14.Width = 0
        GridColumnDescriptor15.MappingName = "ubigeoDestino"
        GridColumnDescriptor15.Name = "ubigeoDestino"
        GridColumnDescriptor15.Width = 0
        Me.GridCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15})
        Me.GridCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.GridCompra.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.GridCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ColHora"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HoraID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idBus"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombreBus"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("RutaID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("origen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Destino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("manifiesto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("programacionID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ubigeoOrigen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ubigeoDestino")})
        Me.GridCompra.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridCompra.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridCompra.Text = "GridGroupingControl2"
        Me.GridCompra.UseRightToLeftCompatibleTextBox = True
        Me.GridCompra.VersionInfo = "12.4400.0.24"
        '
        'RoundButton28
        '
        Me.RoundButton28.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton28.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.RoundButton28.BeforeTouchSize = New System.Drawing.Size(102, 31)
        Me.RoundButton28.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.RoundButton28.ForeColor = System.Drawing.Color.White
        Me.RoundButton28.Image = CType(resources.GetObject("RoundButton28.Image"), System.Drawing.Image)
        Me.RoundButton28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton28.IsBackStageButton = False
        Me.RoundButton28.Location = New System.Drawing.Point(281, 39)
        Me.RoundButton28.Name = "RoundButton28"
        Me.RoundButton28.Size = New System.Drawing.Size(102, 31)
        Me.RoundButton28.TabIndex = 732
        Me.RoundButton28.Text = "Mostrar"
        Me.RoundButton28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RoundButton28.UseVisualStyle = True
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd-MM-yyyy"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(35, 39)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(240, 31)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 731
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.Gainsboro
        Me.Line21.Location = New System.Drawing.Point(12, 16)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(3, 320)
        Me.Line21.TabIndex = 729
        Me.Line21.Text = "Line21"
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'pnBody
        '
        Me.pnBody.BackColor = System.Drawing.Color.White
        Me.pnBody.Controls.Add(Me.pnPrincipal)
        Me.pnBody.Controls.Add(Me.GradientPanel1)
        Me.pnBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBody.Location = New System.Drawing.Point(0, 0)
        Me.pnBody.Name = "pnBody"
        Me.pnBody.Size = New System.Drawing.Size(1104, 383)
        Me.pnBody.TabIndex = 9
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton11)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1104, 40)
        Me.GradientPanel1.TabIndex = 9
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.DodgerBlue
        Me.BunifuFlatButton1.BackgroundImage = CType(resources.GetObject("BunifuFlatButton1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 5
        Me.BunifuFlatButton1.ButtonText = ""
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(1059, 0)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.DodgerBlue
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(43, 38)
        Me.BunifuFlatButton1.TabIndex = 29
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton11
        '
        Me.BunifuFlatButton11.Activecolor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton11.BorderRadius = 5
        Me.BunifuFlatButton11.ButtonText = "PROGRAMACIÓN  SIMPLE"
        Me.BunifuFlatButton11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton11.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton11.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton11.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton11.Iconimage = CType(resources.GetObject("BunifuFlatButton11.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton11.Iconimage_right = Nothing
        Me.BunifuFlatButton11.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton11.Iconimage_Selected = Nothing
        Me.BunifuFlatButton11.IconMarginLeft = 0
        Me.BunifuFlatButton11.IconMarginRight = 0
        Me.BunifuFlatButton11.IconRightVisible = False
        Me.BunifuFlatButton11.IconRightZoom = 0R
        Me.BunifuFlatButton11.IconVisible = True
        Me.BunifuFlatButton11.IconZoom = 50.0R
        Me.BunifuFlatButton11.IsTab = False
        Me.BunifuFlatButton11.Location = New System.Drawing.Point(15, 7)
        Me.BunifuFlatButton11.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton11.Name = "BunifuFlatButton11"
        Me.BunifuFlatButton11.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton11.selected = False
        Me.BunifuFlatButton11.Size = New System.Drawing.Size(179, 23)
        Me.BunifuFlatButton11.TabIndex = 13
        Me.BunifuFlatButton11.Text = "PROGRAMACIÓN  SIMPLE"
        Me.BunifuFlatButton11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton11.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton11.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'notifyIcon1
        '
        Me.notifyIcon1.Icon = CType(resources.GetObject("notifyIcon1.Icon"), System.Drawing.Icon)
        Me.notifyIcon1.Text = "Proyecto Demo v1.0"
        Me.notifyIcon1.Visible = True
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.Green
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Green
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 5
        Me.BunifuFlatButton2.ButtonText = "PROGRAMACIÓN  COMPLETA"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Green
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = CType(resources.GetObject("BunifuFlatButton2.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = False
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 50.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(203, 7)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Green
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Green
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(197, 23)
        Me.BunifuFlatButton2.TabIndex = 30
        Me.BunifuFlatButton2.Text = "PROGRAMACIÓN  COMPLETA"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'UCMaestroProgramacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.pnBody)
        Me.Name = "UCMaestroProgramacion"
        Me.Size = New System.Drawing.Size(1104, 383)
        Me.pnPrincipal.ResumeLayout(False)
        Me.pnPrincipal.PerformLayout()
        CType(Me.GridCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBody.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label10 As Label
    Friend WithEvents pnPrincipal As Panel
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Private WithEvents Line21 As Line2
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents pnBody As Panel
    Private WithEvents notifyIcon1 As NotifyIcon
    Friend WithEvents RoundButton28 As RoundButton2
    Friend WithEvents TextFechaProgramada As Tools.DateTimePickerAdv
    Friend WithEvents GridCompra As Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton11 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
End Class
