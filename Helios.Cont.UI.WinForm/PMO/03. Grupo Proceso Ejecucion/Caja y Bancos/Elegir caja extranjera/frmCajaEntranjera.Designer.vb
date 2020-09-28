<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaEntranjera
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCajaEntranjera))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtMontoDesembolso = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.dgvPagos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.btnAceptar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.txtMontoconvertido = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.lblDeuda = New System.Windows.Forms.Label()
        Me.txtDeuda = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextMonedaObligacion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMontoDesembolso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoconvertido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeuda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMonedaObligacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(565, 10)
        Me.GradientPanel1.TabIndex = 0
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.White
        Me.txtCuenta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCuenta.BorderColor = System.Drawing.Color.SeaGreen
        Me.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta.CornerRadius = 4
        Me.txtCuenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCuenta.Location = New System.Drawing.Point(17, 35)
        Me.txtCuenta.Metrocolor = System.Drawing.Color.SeaGreen
        Me.txtCuenta.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(273, 22)
        Me.txtCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuenta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cuenta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(241, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Desembolsar"
        '
        'TxtMontoDesembolso
        '
        Me.TxtMontoDesembolso.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtMontoDesembolso.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TxtMontoDesembolso.BorderColor = System.Drawing.Color.OrangeRed
        Me.TxtMontoDesembolso.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.TxtMontoDesembolso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMontoDesembolso.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtMontoDesembolso.DoubleValue = 0R
        Me.TxtMontoDesembolso.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoDesembolso.Location = New System.Drawing.Point(244, 96)
        Me.TxtMontoDesembolso.Metrocolor = System.Drawing.Color.OrangeRed
        Me.TxtMontoDesembolso.Name = "TxtMontoDesembolso"
        Me.TxtMontoDesembolso.NullString = ""
        Me.TxtMontoDesembolso.Size = New System.Drawing.Size(100, 22)
        Me.TxtMontoDesembolso.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TxtMontoDesembolso.TabIndex = 4
        Me.TxtMontoDesembolso.Text = "0.00"
        Me.TxtMontoDesembolso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvPagos
        '
        Me.dgvPagos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvPagos.BackColor = System.Drawing.SystemColors.Window
        Me.dgvPagos.Location = New System.Drawing.Point(14, 124)
        Me.dgvPagos.Name = "dgvPagos"
        Me.dgvPagos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvPagos.Size = New System.Drawing.Size(540, 279)
        Me.dgvPagos.TabIndex = 5
        GridColumnDescriptor1.MappingName = "iddocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 10
        GridColumnDescriptor2.HeaderText = "FECHA"
        GridColumnDescriptor2.MappingName = "cuenta"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 120
        GridColumnDescriptor3.HeaderText = "T/C."
        GridColumnDescriptor3.MappingName = "tipocambio"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 40
        GridColumnDescriptor4.HeaderText = "MONTO"
        GridColumnDescriptor4.MappingName = "monto"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.HeaderText = "DESEMB."
        GridColumnDescriptor5.MappingName = "desembolso"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 75
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.NavajoWhite)
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Text = "0.00"
        GridColumnDescriptor6.HeaderText = "SALDO"
        GridColumnDescriptor6.MappingName = "saldo"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.Width = 70
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Font.Bold = True
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Lavender)
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Text = "0.00"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.MidnightBlue
        GridColumnDescriptor7.HeaderText = "RETIRO"
        GridColumnDescriptor7.MappingName = "pago"
        GridColumnDescriptor7.Width = 70
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor8.HeaderText = "Pedir"
        GridColumnDescriptor8.MappingName = "confirmar"
        GridColumnDescriptor8.Width = 50
        Me.dgvPagos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.InactiveBorder)
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("saldo", Syncfusion.Grouping.SummaryType.DoubleAggregate, "saldo", "{Sum}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("monto", Syncfusion.Grouping.SummaryType.DoubleAggregate, "monto", "{Sum}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("desembolso", Syncfusion.Grouping.SummaryType.DoubleAggregate, "desembolso", "{Sum}")})
        GridSummaryRowDescriptor1.Title = "Total"
        Me.dgvPagos.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvPagos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuenta"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipocambio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("desembolso"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("saldo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("confirmar")})
        Me.dgvPagos.Text = "GridGroupingControl1"
        Me.dgvPagos.UseRightToLeftCompatibleTextBox = True
        Me.dgvPagos.VersionInfo = "12.4400.0.24"
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnAceptar.BackColor = System.Drawing.Color.OrangeRed
        Me.btnAceptar.BeforeTouchSize = New System.Drawing.Size(115, 35)
        Me.btnAceptar.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.IsBackStageButton = False
        Me.btnAceptar.Location = New System.Drawing.Point(231, 409)
        Me.btnAceptar.MetroColor = System.Drawing.Color.OrangeRed
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(115, 35)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyle = True
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.Color.White
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DoubleValue = 1.0R
        Me.txtTipoCambio.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.Location = New System.Drawing.Point(350, 96)
        Me.txtTipoCambio.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.NumberDecimalDigits = 3
        Me.txtTipoCambio.PositiveColor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.Size = New System.Drawing.Size(47, 22)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "1.000"
        '
        'txtMontoconvertido
        '
        Me.txtMontoconvertido.BackGroundColor = System.Drawing.Color.White
        Me.txtMontoconvertido.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtMontoconvertido.BorderColor = System.Drawing.Color.Fuchsia
        Me.txtMontoconvertido.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.txtMontoconvertido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoconvertido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMontoconvertido.DoubleValue = 0R
        Me.txtMontoconvertido.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoconvertido.ForeColor = System.Drawing.Color.DarkMagenta
        Me.txtMontoconvertido.Location = New System.Drawing.Point(403, 96)
        Me.txtMontoconvertido.Metrocolor = System.Drawing.Color.Fuchsia
        Me.txtMontoconvertido.Name = "txtMontoconvertido"
        Me.txtMontoconvertido.NullString = ""
        Me.txtMontoconvertido.PositiveColor = System.Drawing.Color.Fuchsia
        Me.txtMontoconvertido.ReadOnly = True
        Me.txtMontoconvertido.ReadOnlyBackColor = System.Drawing.Color.White
        Me.txtMontoconvertido.Size = New System.Drawing.Size(100, 22)
        Me.txtMontoconvertido.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMontoconvertido.TabIndex = 8
        Me.txtMontoconvertido.Text = "0.00"
        Me.txtMontoconvertido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMontoconvertido.ZeroColor = System.Drawing.Color.DarkMagenta
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Pago a realizar en:"
        '
        'cboPago
        '
        Me.cboPago.BackColor = System.Drawing.Color.White
        Me.cboPago.BeforeTouchSize = New System.Drawing.Size(214, 21)
        Me.cboPago.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.cboPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPago.Enabled = False
        Me.cboPago.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPago.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cboPago.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERO"})
        Me.cboPago.Location = New System.Drawing.Point(17, 97)
        Me.cboPago.Name = "cboPago"
        Me.cboPago.Size = New System.Drawing.Size(214, 21)
        Me.cboPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboPago.TabIndex = 10
        Me.cboPago.Text = "NACIONAL"
        '
        'lblDeuda
        '
        Me.lblDeuda.AutoSize = True
        Me.lblDeuda.Location = New System.Drawing.Point(295, 10)
        Me.lblDeuda.Name = "lblDeuda"
        Me.lblDeuda.Size = New System.Drawing.Size(41, 13)
        Me.lblDeuda.TabIndex = 11
        Me.lblDeuda.Text = "Deuda"
        '
        'txtDeuda
        '
        Me.txtDeuda.BackGroundColor = System.Drawing.Color.OrangeRed
        Me.txtDeuda.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtDeuda.BorderColor = System.Drawing.Color.SeaGreen
        Me.txtDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeuda.CornerRadius = 4
        Me.txtDeuda.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDeuda.DoubleValue = 0R
        Me.txtDeuda.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeuda.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtDeuda.Location = New System.Drawing.Point(296, 28)
        Me.txtDeuda.Metrocolor = System.Drawing.Color.SeaGreen
        Me.txtDeuda.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtDeuda.Name = "txtDeuda"
        Me.txtDeuda.NullString = ""
        Me.txtDeuda.NumberDecimalDigits = 3
        Me.txtDeuda.PositiveColor = System.Drawing.Color.Black
        Me.txtDeuda.ReadOnly = True
        Me.txtDeuda.ReadOnlyBackColor = System.Drawing.Color.White
        Me.txtDeuda.Size = New System.Drawing.Size(101, 29)
        Me.txtDeuda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDeuda.TabIndex = 12
        Me.txtDeuda.Text = "0.000"
        Me.txtDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDeuda.ZeroColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(347, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "T/C."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(410, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Moneda obligación"
        '
        'TextMonedaObligacion
        '
        Me.TextMonedaObligacion.BackColor = System.Drawing.Color.White
        Me.TextMonedaObligacion.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextMonedaObligacion.BorderColor = System.Drawing.Color.SeaGreen
        Me.TextMonedaObligacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMonedaObligacion.CornerRadius = 4
        Me.TextMonedaObligacion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextMonedaObligacion.Location = New System.Drawing.Point(404, 35)
        Me.TextMonedaObligacion.Metrocolor = System.Drawing.Color.SeaGreen
        Me.TextMonedaObligacion.MinimumSize = New System.Drawing.Size(12, 8)
        Me.TextMonedaObligacion.Name = "TextMonedaObligacion"
        Me.TextMonedaObligacion.ReadOnly = True
        Me.TextMonedaObligacion.Size = New System.Drawing.Size(127, 22)
        Me.TextMonedaObligacion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextMonedaObligacion.TabIndex = 15
        '
        'frmCajaEntranjera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.OrangeRed
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.OrangeRed
        CaptionLabel1.Location = New System.Drawing.Point(50, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Operación Pagos"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel2.Location = New System.Drawing.Point(50, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Moneda Nacional y Extranjera"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(565, 447)
        Me.Controls.Add(Me.TextMonedaObligacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDeuda)
        Me.Controls.Add(Me.lblDeuda)
        Me.Controls.Add(Me.cboPago)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMontoconvertido)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvPagos)
        Me.Controls.Add(Me.TxtMontoDesembolso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCajaEntranjera"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMontoDesembolso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoconvertido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeuda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMonedaObligacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtMontoDesembolso As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents dgvPagos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents btnAceptar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents txtMontoconvertido As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPago As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents lblDeuda As System.Windows.Forms.Label
    Friend WithEvents txtDeuda As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextMonedaObligacion As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class
