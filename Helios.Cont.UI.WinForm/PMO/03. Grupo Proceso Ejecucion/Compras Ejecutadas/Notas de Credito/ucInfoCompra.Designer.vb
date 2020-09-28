<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucInfoCompra
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AutoLabel1 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTipoCompra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtMoneda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtIgv = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtImportemn = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtImporteme = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDocPagado = New System.Windows.Forms.RadioButton()
        Me.rbTramite = New System.Windows.Forms.RadioButton()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImportemn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteme, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AutoLabel1
        '
        Me.AutoLabel1.AutoSize = False
        Me.AutoLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.AutoLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.unnamed
        Me.AutoLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AutoLabel1.Location = New System.Drawing.Point(79, 12)
        Me.AutoLabel1.Name = "AutoLabel1"
        Me.AutoLabel1.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Custom
        Me.AutoLabel1.Size = New System.Drawing.Size(211, 27)
        Me.AutoLabel1.TabIndex = 2
        Me.AutoLabel1.Text = "Comprobante de compra"
        Me.AutoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(31, 242)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 13)
        Me.Label23.TabIndex = 352
        Me.Label23.Text = "Tipo compra:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(55, 217)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 350
        Me.Label14.Text = "Cuenta:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(54, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 351
        Me.Label13.Text = "Período:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(62, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 345
        Me.Label1.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(10, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 346
        Me.Label2.Text = "Tipo documento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(42, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 349
        Me.Label5.Text = "Proveedor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(53, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 348
        Me.Label4.Text = "Número:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(69, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 347
        Me.Label3.Text = "Serie:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(51, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 353
        Me.Label6.Text = "Moneda:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(76, 293)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 354
        Me.Label7.Text = "Igv.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(185, 293)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 355
        Me.Label8.Text = "t/c.:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(30, 317)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 356
        Me.Label9.Text = "Importe mn.:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(33, 343)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 357
        Me.Label10.Text = "Importe me.:"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(111, 51)
        Me.txtFecha.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(179, 22)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtFecha.TabIndex = 358
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.Color.White
        Me.txtPeriodo.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeriodo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(111, 76)
        Me.txtPeriodo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(179, 22)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPeriodo.TabIndex = 359
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.Color.White
        Me.txtComprobante.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtComprobante.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobante.Location = New System.Drawing.Point(111, 101)
        Me.txtComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(179, 22)
        Me.txtComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtComprobante.TabIndex = 360
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtSerie.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(111, 126)
        Me.txtSerie.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(92, 22)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSerie.TabIndex = 361
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtNumero.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(110, 151)
        Me.txtNumero.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(179, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumero.TabIndex = 362
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(110, 176)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProveedor.Multiline = True
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProveedor.Size = New System.Drawing.Size(284, 33)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtProveedor.TabIndex = 363
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.White
        Me.txtCuenta.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtCuenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuenta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(110, 212)
        Me.txtCuenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(52, 22)
        Me.txtCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuenta.TabIndex = 364
        '
        'txtTipoCompra
        '
        Me.txtTipoCompra.BackColor = System.Drawing.Color.White
        Me.txtTipoCompra.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtTipoCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCompra.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCompra.Location = New System.Drawing.Point(110, 237)
        Me.txtTipoCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCompra.Name = "txtTipoCompra"
        Me.txtTipoCompra.Size = New System.Drawing.Size(179, 22)
        Me.txtTipoCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCompra.TabIndex = 365
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.White
        Me.txtMoneda.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtMoneda.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMoneda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMoneda.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(110, 262)
        Me.txtMoneda.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(179, 22)
        Me.txtMoneda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMoneda.TabIndex = 366
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.Color.White
        Me.txtIgv.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIgv.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIgv.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIgv.Location = New System.Drawing.Point(110, 287)
        Me.txtIgv.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.Size = New System.Drawing.Size(49, 22)
        Me.txtIgv.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtIgv.TabIndex = 367
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.White
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.Location = New System.Drawing.Point(217, 287)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(73, 22)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCambio.TabIndex = 368
        '
        'txtImportemn
        '
        Me.txtImportemn.BackColor = System.Drawing.Color.White
        Me.txtImportemn.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtImportemn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImportemn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImportemn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImportemn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportemn.Location = New System.Drawing.Point(110, 312)
        Me.txtImportemn.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImportemn.Name = "txtImportemn"
        Me.txtImportemn.Size = New System.Drawing.Size(93, 22)
        Me.txtImportemn.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtImportemn.TabIndex = 369
        '
        'txtImporteme
        '
        Me.txtImporteme.BackColor = System.Drawing.Color.White
        Me.txtImporteme.BeforeTouchSize = New System.Drawing.Size(284, 33)
        Me.txtImporteme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteme.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImporteme.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteme.Location = New System.Drawing.Point(110, 337)
        Me.txtImporteme.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteme.Name = "txtImporteme"
        Me.txtImporteme.Size = New System.Drawing.Size(93, 22)
        Me.txtImporteme.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtImporteme.TabIndex = 370
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDocPagado)
        Me.GroupBox1.Controls.Add(Me.rbTramite)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(209, 313)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 46)
        Me.GroupBox1.TabIndex = 371
        Me.GroupBox1.TabStop = False
        '
        'rbDocPagado
        '
        Me.rbDocPagado.AutoSize = True
        Me.rbDocPagado.Checked = True
        Me.rbDocPagado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rbDocPagado.Location = New System.Drawing.Point(22, 20)
        Me.rbDocPagado.Name = "rbDocPagado"
        Me.rbDocPagado.Size = New System.Drawing.Size(64, 17)
        Me.rbDocPagado.TabIndex = 0
        Me.rbDocPagado.TabStop = True
        Me.rbDocPagado.Text = "Pagado"
        Me.rbDocPagado.UseVisualStyleBackColor = True
        '
        'rbTramite
        '
        Me.rbTramite.AutoSize = True
        Me.rbTramite.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rbTramite.Location = New System.Drawing.Point(98, 21)
        Me.rbTramite.Name = "rbTramite"
        Me.rbTramite.Size = New System.Drawing.Size(77, 17)
        Me.rbTramite.TabIndex = 1
        Me.rbTramite.Text = "En trámite"
        Me.rbTramite.UseVisualStyleBackColor = True
        '
        'ucInfoCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtImporteme)
        Me.Controls.Add(Me.txtImportemn)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.txtIgv)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.txtTipoCompra)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.txtComprobante)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.AutoLabel1)
        Me.Name = "ucInfoCompra"
        Me.Size = New System.Drawing.Size(400, 371)
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImportemn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteme, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AutoLabel1 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtTipoCompra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtMoneda As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtIgv As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtImportemn As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtImporteme As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDocPagado As System.Windows.Forms.RadioButton
    Friend WithEvents rbTramite As System.Windows.Forms.RadioButton

End Class
