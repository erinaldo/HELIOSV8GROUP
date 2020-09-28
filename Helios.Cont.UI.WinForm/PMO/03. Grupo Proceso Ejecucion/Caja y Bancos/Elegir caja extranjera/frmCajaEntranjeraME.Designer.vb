Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCajaEntranjeraME
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextMonedaObligacion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDeuda = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.lblDeuda = New System.Windows.Forms.Label()
        Me.cboPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMontoconvertido = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.btnAceptar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.dgvPagos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.TxtMontoDesembolso = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMonedaObligacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeuda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoconvertido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMontoDesembolso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GradientPanel1.TabIndex = 1
        '
        'TextMonedaObligacion
        '
        Me.TextMonedaObligacion.BackColor = System.Drawing.Color.White
        Me.TextMonedaObligacion.BeforeTouchSize = New System.Drawing.Size(273, 22)
        Me.TextMonedaObligacion.BorderColor = System.Drawing.Color.SeaGreen
        Me.TextMonedaObligacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMonedaObligacion.CornerRadius = 4
        Me.TextMonedaObligacion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextMonedaObligacion.Location = New System.Drawing.Point(402, 31)
        Me.TextMonedaObligacion.Metrocolor = System.Drawing.Color.SeaGreen
        Me.TextMonedaObligacion.MinimumSize = New System.Drawing.Size(12, 8)
        Me.TextMonedaObligacion.Name = "TextMonedaObligacion"
        Me.TextMonedaObligacion.ReadOnly = True
        Me.TextMonedaObligacion.Size = New System.Drawing.Size(127, 22)
        Me.TextMonedaObligacion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextMonedaObligacion.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(408, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Moneda obligación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(345, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 14)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "T/C."
        '
        'txtDeuda
        '
        Me.txtDeuda.BackGroundColor = System.Drawing.Color.OrangeRed
        Me.txtDeuda.BeforeTouchSize = New System.Drawing.Size(273, 22)
        Me.txtDeuda.BorderColor = System.Drawing.Color.SeaGreen
        Me.txtDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeuda.CornerRadius = 4
        Me.txtDeuda.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDeuda.DoubleValue = 0R
        Me.txtDeuda.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeuda.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtDeuda.Location = New System.Drawing.Point(294, 24)
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
        Me.txtDeuda.TabIndex = 27
        Me.txtDeuda.Text = "0.000"
        Me.txtDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDeuda.ZeroColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'lblDeuda
        '
        Me.lblDeuda.AutoSize = True
        Me.lblDeuda.Location = New System.Drawing.Point(293, 6)
        Me.lblDeuda.Name = "lblDeuda"
        Me.lblDeuda.Size = New System.Drawing.Size(41, 13)
        Me.lblDeuda.TabIndex = 26
        Me.lblDeuda.Text = "Deuda"
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
        Me.cboPago.Location = New System.Drawing.Point(15, 93)
        Me.cboPago.Name = "cboPago"
        Me.cboPago.Size = New System.Drawing.Size(214, 21)
        Me.cboPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboPago.TabIndex = 25
        Me.cboPago.Text = "NACIONAL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Pago a realizar en:"
        '
        'txtMontoconvertido
        '
        Me.txtMontoconvertido.BackGroundColor = System.Drawing.Color.White
        Me.txtMontoconvertido.BeforeTouchSize = New System.Drawing.Size(273, 22)
        Me.txtMontoconvertido.BorderColor = System.Drawing.Color.Fuchsia
        Me.txtMontoconvertido.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.txtMontoconvertido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoconvertido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMontoconvertido.DoubleValue = 0R
        Me.txtMontoconvertido.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoconvertido.ForeColor = System.Drawing.Color.DarkMagenta
        Me.txtMontoconvertido.Location = New System.Drawing.Point(401, 92)
        Me.txtMontoconvertido.Metrocolor = System.Drawing.Color.Fuchsia
        Me.txtMontoconvertido.Name = "txtMontoconvertido"
        Me.txtMontoconvertido.NullString = ""
        Me.txtMontoconvertido.PositiveColor = System.Drawing.Color.Fuchsia
        Me.txtMontoconvertido.ReadOnly = True
        Me.txtMontoconvertido.ReadOnlyBackColor = System.Drawing.Color.White
        Me.txtMontoconvertido.Size = New System.Drawing.Size(100, 22)
        Me.txtMontoconvertido.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMontoconvertido.TabIndex = 23
        Me.txtMontoconvertido.Text = "0.00"
        Me.txtMontoconvertido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMontoconvertido.ZeroColor = System.Drawing.Color.DarkMagenta
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.Color.White
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(273, 22)
        Me.txtTipoCambio.BorderColor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DoubleValue = 1.0R
        Me.txtTipoCambio.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.Location = New System.Drawing.Point(348, 92)
        Me.txtTipoCambio.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.NumberDecimalDigits = 3
        Me.txtTipoCambio.PositiveColor = System.Drawing.SystemColors.Highlight
        Me.txtTipoCambio.Size = New System.Drawing.Size(47, 22)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCambio.TabIndex = 22
        Me.txtTipoCambio.Text = "1.000"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAceptar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnAceptar.BackColor = System.Drawing.Color.OrangeRed
        Me.btnAceptar.BeforeTouchSize = New System.Drawing.Size(115, 32)
        Me.btnAceptar.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.IsBackStageButton = False
        Me.btnAceptar.Location = New System.Drawing.Point(227, 133)
        Me.btnAceptar.MetroColor = System.Drawing.Color.OrangeRed
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(115, 32)
        Me.btnAceptar.TabIndex = 21
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyle = True
        '
        'dgvPagos
        '
        Me.dgvPagos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvPagos.BackColor = System.Drawing.SystemColors.Window
        Me.dgvPagos.Location = New System.Drawing.Point(12, 181)
        Me.dgvPagos.Name = "dgvPagos"
        Me.dgvPagos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvPagos.Size = New System.Drawing.Size(540, 279)
        Me.dgvPagos.TabIndex = 20
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
        Me.dgvPagos.Visible = False
        '
        'TxtMontoDesembolso
        '
        Me.TxtMontoDesembolso.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtMontoDesembolso.BeforeTouchSize = New System.Drawing.Size(273, 22)
        Me.TxtMontoDesembolso.BorderColor = System.Drawing.Color.OrangeRed
        Me.TxtMontoDesembolso.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.TxtMontoDesembolso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMontoDesembolso.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtMontoDesembolso.DoubleValue = 0R
        Me.TxtMontoDesembolso.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoDesembolso.Location = New System.Drawing.Point(242, 92)
        Me.TxtMontoDesembolso.Metrocolor = System.Drawing.Color.OrangeRed
        Me.TxtMontoDesembolso.Name = "TxtMontoDesembolso"
        Me.TxtMontoDesembolso.NullString = ""
        Me.TxtMontoDesembolso.Size = New System.Drawing.Size(100, 22)
        Me.TxtMontoDesembolso.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TxtMontoDesembolso.TabIndex = 19
        Me.TxtMontoDesembolso.Text = "0.00"
        Me.TxtMontoDesembolso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(239, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Desembolsar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Cuenta"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.White
        Me.txtCuenta.BeforeTouchSize = New System.Drawing.Size(273, 22)
        Me.txtCuenta.BorderColor = System.Drawing.Color.SeaGreen
        Me.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta.CornerRadius = 4
        Me.txtCuenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCuenta.Location = New System.Drawing.Point(15, 31)
        Me.txtCuenta.Metrocolor = System.Drawing.Color.SeaGreen
        Me.txtCuenta.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(273, 22)
        Me.txtCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuenta.TabIndex = 16
        '
        'frmCajaEntranjeraME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarHeight = 55
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(565, 167)
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
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCajaEntranjeraME"
        Me.ShowIcon = False
        Me.Text = "Caja Entranjera"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMonedaObligacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeuda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoconvertido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMontoDesembolso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents TextMonedaObligacion As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDeuda As Tools.DoubleTextBox
    Friend WithEvents lblDeuda As Label
    Friend WithEvents cboPago As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMontoconvertido As Tools.DoubleTextBox
    Friend WithEvents txtTipoCambio As Tools.DoubleTextBox
    Friend WithEvents btnAceptar As ButtonAdv
    Friend WithEvents dgvPagos As Grid.Grouping.GridGroupingControl
    Friend WithEvents TxtMontoDesembolso As Tools.DoubleTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCuenta As Tools.TextBoxExt
End Class
