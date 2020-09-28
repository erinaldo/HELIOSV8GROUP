Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabTR_ConfTipoServicio
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabTR_ConfTipoServicio))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GridSERVICIO = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton11 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.pnBody = New System.Windows.Forms.Panel()
        Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnPrincipal.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GridSERVICIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(30, 40)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'pnPrincipal
        '
        Me.pnPrincipal.BackColor = System.Drawing.Color.White
        Me.pnPrincipal.Controls.Add(Me.GradientPanel2)
        Me.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(496, 411)
        Me.pnPrincipal.TabIndex = 8
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.GridSERVICIO)
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Controls.Add(Me.GradientPanel1)
        Me.GradientPanel2.Controls.Add(Me.TextBoxExt1)
        Me.GradientPanel2.Controls.Add(Me.txtFiltrar)
        Me.GradientPanel2.Controls.Add(Me.Label3)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(496, 411)
        Me.GradientPanel2.TabIndex = 2
        '
        'GridSERVICIO
        '
        Me.GridSERVICIO.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.SelectAll
        Me.GridSERVICIO.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.GridSERVICIO.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridSERVICIO.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridSERVICIO.BackColor = System.Drawing.Color.White
        Me.GridSERVICIO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridSERVICIO.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.GridSERVICIO.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridSERVICIO.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridSERVICIO.Location = New System.Drawing.Point(133, 155)
        Me.GridSERVICIO.Name = "GridSERVICIO"
        Me.GridSERVICIO.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridSERVICIO.Size = New System.Drawing.Size(321, 243)
        Me.GridSERVICIO.TabIndex = 734
        Me.GridSERVICIO.TableDescriptor.AllowNew = False
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridSERVICIO.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.GridSERVICIO.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridSERVICIO.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridSERVICIO.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.GridSERVICIO.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.GridSERVICIO.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.GridSERVICIO.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.GridSERVICIO.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "DESCRIPCION"
        GridColumnDescriptor2.MappingName = "DESCRIPCION"
        GridColumnDescriptor2.Name = "DESCRIPCION"
        GridColumnDescriptor2.Width = 300
        Me.GridSERVICIO.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2})
        Me.GridSERVICIO.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.GridSERVICIO.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridSERVICIO.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.GridSERVICIO.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DESCRIPCION")})
        Me.GridSERVICIO.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridSERVICIO.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridSERVICIO.Text = "GridGroupingControl2"
        Me.GridSERVICIO.UseRightToLeftCompatibleTextBox = True
        Me.GridSERVICIO.VersionInfo = "12.4400.0.24"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(38, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 673
        Me.Label1.Text = "SERVICIO"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton11)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(494, 46)
        Me.GradientPanel1.TabIndex = 672
        '
        'BunifuFlatButton11
        '
        Me.BunifuFlatButton11.Activecolor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton11.BorderRadius = 5
        Me.BunifuFlatButton11.ButtonText = "Grabar"
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
        Me.BunifuFlatButton11.Location = New System.Drawing.Point(18, 10)
        Me.BunifuFlatButton11.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton11.Name = "BunifuFlatButton11"
        Me.BunifuFlatButton11.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BunifuFlatButton11.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton11.selected = False
        Me.BunifuFlatButton11.Size = New System.Drawing.Size(118, 25)
        Me.BunifuFlatButton11.TabIndex = 13
        Me.BunifuFlatButton11.Text = "Grabar"
        Me.BunifuFlatButton11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton11.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton11.TextFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Color = System.Drawing.Color.WhiteSmoke
        BannerTextInfo1.Text = "Buscar producto ..."
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextBoxExt1, BannerTextInfo1)
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(321, 28)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.CornerRadius = 4
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxExt1.FarImage = CType(resources.GetObject("TextBoxExt1.FarImage"), System.Drawing.Image)
        Me.TextBoxExt1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxExt1.Location = New System.Drawing.Point(133, 67)
        Me.TextBoxExt1.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.TextBoxExt1.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.TextBoxExt1.ReadOnly = True
        Me.TextBoxExt1.Size = New System.Drawing.Size(321, 29)
        Me.TextBoxExt1.TabIndex = 671
        Me.TextBoxExt1.ThemesEnabled = False
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Color = System.Drawing.Color.WhiteSmoke
        BannerTextInfo2.Text = "Buscar producto ..."
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtFiltrar, BannerTextInfo2)
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(321, 28)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.CornerRadius = 4
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFiltrar.FarImage = CType(resources.GetObject("txtFiltrar.FarImage"), System.Drawing.Image)
        Me.txtFiltrar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Black
        Me.txtFiltrar.Location = New System.Drawing.Point(133, 116)
        Me.txtFiltrar.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Multiline = True
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFiltrar.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFiltrar.Size = New System.Drawing.Size(321, 28)
        Me.txtFiltrar.TabIndex = 667
        Me.txtFiltrar.ThemesEnabled = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 16)
        Me.Label3.TabIndex = 589
        Me.Label3.Text = "PLACA BUS"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(282, 27)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cboTipoDoc.Location = New System.Drawing.Point(8, 28)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(282, 27)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 588
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'pnBody
        '
        Me.pnBody.BackColor = System.Drawing.Color.White
        Me.pnBody.Controls.Add(Me.pnPrincipal)
        Me.pnBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBody.Location = New System.Drawing.Point(0, 0)
        Me.pnBody.Name = "pnBody"
        Me.pnBody.Size = New System.Drawing.Size(496, 411)
        Me.pnBody.TabIndex = 9
        '
        'notifyIcon1
        '
        Me.notifyIcon1.Icon = CType(resources.GetObject("notifyIcon1.Icon"), System.Drawing.Icon)
        Me.notifyIcon1.Text = "Proyecto Demo v1.0"
        Me.notifyIcon1.Visible = True
        '
        'TabTR_ConfTipoServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(496, 411)
        Me.Controls.Add(Me.pnBody)
        Me.Name = "TabTR_ConfTipoServicio"
        Me.pnPrincipal.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.GridSERVICIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents pnPrincipal As Panel
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents pnBody As Panel
    Private WithEvents notifyIcon1 As NotifyIcon
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtFiltrar As Tools.TextBoxExt
    Friend WithEvents TextBoxExt1 As Tools.TextBoxExt
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents BunifuFlatButton11 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label1 As Label
    Friend WithEvents GridSERVICIO As Grid.Grouping.GridGroupingControl
End Class
