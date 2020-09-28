<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVerPagos
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVerPagos))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextTipoComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextFechaTrans = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextFechaPago = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextMoneda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextTipoCuentaFinanciera = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextCuentaFinanciera = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextImporte = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextNumeroFormaPago = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextFormaPago = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextTipoPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextDNI = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextGlosa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.TextTipoComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTipoCuentaFinanciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCuentaFinanciera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TextImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumeroFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TextTipoPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TextGlosa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comprobante de pago"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(240, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Número"
        '
        'TextTipoComprobante
        '
        Me.TextTipoComprobante.BackColor = System.Drawing.Color.SeaShell
        Me.TextTipoComprobante.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextTipoComprobante.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoComprobante.CornerRadius = 4
        Me.TextTipoComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTipoComprobante.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoComprobante.Location = New System.Drawing.Point(27, 46)
        Me.TextTipoComprobante.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoComprobante.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoComprobante.Name = "TextTipoComprobante"
        Me.TextTipoComprobante.ReadOnly = True
        Me.TextTipoComprobante.Size = New System.Drawing.Size(210, 22)
        Me.TextTipoComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTipoComprobante.TabIndex = 401
        Me.TextTipoComprobante.Text = "VOUCHER DE CAJA"
        '
        'TextNumero
        '
        Me.TextNumero.BackColor = System.Drawing.Color.White
        Me.TextNumero.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextNumero.BorderColor = System.Drawing.Color.Silver
        Me.TextNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumero.CornerRadius = 4
        Me.TextNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumero.Location = New System.Drawing.Point(243, 46)
        Me.TextNumero.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumero.Name = "TextNumero"
        Me.TextNumero.ReadOnly = True
        Me.TextNumero.Size = New System.Drawing.Size(127, 22)
        Me.TextNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumero.TabIndex = 402
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(376, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 14)
        Me.Label3.TabIndex = 403
        Me.Label3.Text = "Fecha de transacción"
        '
        'TextFechaTrans
        '
        Me.TextFechaTrans.BackColor = System.Drawing.Color.White
        Me.TextFechaTrans.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextFechaTrans.BorderColor = System.Drawing.Color.Silver
        Me.TextFechaTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaTrans.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFechaTrans.CornerRadius = 4
        Me.TextFechaTrans.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextFechaTrans.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaTrans.Location = New System.Drawing.Point(379, 46)
        Me.TextFechaTrans.Metrocolor = System.Drawing.Color.Silver
        Me.TextFechaTrans.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextFechaTrans.Name = "TextFechaTrans"
        Me.TextFechaTrans.ReadOnly = True
        Me.TextFechaTrans.Size = New System.Drawing.Size(127, 22)
        Me.TextFechaTrans.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextFechaTrans.TabIndex = 404
        '
        'TextFechaPago
        '
        Me.TextFechaPago.BackColor = System.Drawing.Color.SeaShell
        Me.TextFechaPago.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextFechaPago.BorderColor = System.Drawing.Color.Silver
        Me.TextFechaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFechaPago.CornerRadius = 4
        Me.TextFechaPago.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextFechaPago.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaPago.Location = New System.Drawing.Point(512, 46)
        Me.TextFechaPago.Metrocolor = System.Drawing.Color.Silver
        Me.TextFechaPago.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextFechaPago.Name = "TextFechaPago"
        Me.TextFechaPago.ReadOnly = True
        Me.TextFechaPago.Size = New System.Drawing.Size(127, 22)
        Me.TextFechaPago.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextFechaPago.TabIndex = 406
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(509, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 14)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Fecha de pago"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextMoneda)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextTipoCuentaFinanciera)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextCuentaFinanciera)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(612, 82)
        Me.GroupBox1.TabIndex = 407
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuenta Financiera de uso"
        '
        'TextMoneda
        '
        Me.TextMoneda.BackColor = System.Drawing.Color.White
        Me.TextMoneda.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextMoneda.BorderColor = System.Drawing.Color.Silver
        Me.TextMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMoneda.CornerRadius = 4
        Me.TextMoneda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMoneda.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMoneda.Location = New System.Drawing.Point(362, 47)
        Me.TextMoneda.Metrocolor = System.Drawing.Color.Silver
        Me.TextMoneda.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMoneda.Name = "TextMoneda"
        Me.TextMoneda.ReadOnly = True
        Me.TextMoneda.Size = New System.Drawing.Size(76, 22)
        Me.TextMoneda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextMoneda.TabIndex = 406
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(359, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 14)
        Me.Label10.TabIndex = 405
        Me.Label10.Text = "Moneda"
        '
        'TextTipoCuentaFinanciera
        '
        Me.TextTipoCuentaFinanciera.BackColor = System.Drawing.Color.White
        Me.TextTipoCuentaFinanciera.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextTipoCuentaFinanciera.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoCuentaFinanciera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoCuentaFinanciera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoCuentaFinanciera.CornerRadius = 4
        Me.TextTipoCuentaFinanciera.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextTipoCuentaFinanciera.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoCuentaFinanciera.Location = New System.Drawing.Point(266, 47)
        Me.TextTipoCuentaFinanciera.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoCuentaFinanciera.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoCuentaFinanciera.Name = "TextTipoCuentaFinanciera"
        Me.TextTipoCuentaFinanciera.ReadOnly = True
        Me.TextTipoCuentaFinanciera.Size = New System.Drawing.Size(91, 22)
        Me.TextTipoCuentaFinanciera.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTipoCuentaFinanciera.TabIndex = 404
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(263, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 14)
        Me.Label6.TabIndex = 403
        Me.Label6.Text = "Tipo"
        '
        'TextCuentaFinanciera
        '
        Me.TextCuentaFinanciera.BackColor = System.Drawing.Color.White
        Me.TextCuentaFinanciera.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextCuentaFinanciera.BorderColor = System.Drawing.Color.Silver
        Me.TextCuentaFinanciera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCuentaFinanciera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCuentaFinanciera.CornerRadius = 4
        Me.TextCuentaFinanciera.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCuentaFinanciera.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCuentaFinanciera.Location = New System.Drawing.Point(19, 47)
        Me.TextCuentaFinanciera.Metrocolor = System.Drawing.Color.Silver
        Me.TextCuentaFinanciera.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCuentaFinanciera.Name = "TextCuentaFinanciera"
        Me.TextCuentaFinanciera.ReadOnly = True
        Me.TextCuentaFinanciera.Size = New System.Drawing.Size(241, 22)
        Me.TextCuentaFinanciera.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCuentaFinanciera.TabIndex = 402
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Descripción"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextImporte)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextNumeroFormaPago)
        Me.GroupBox2.Controls.Add(Me.TextFormaPago)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 162)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(612, 82)
        Me.GroupBox2.TabIndex = 408
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Forma de Pago realizada"
        '
        'TextImporte
        '
        Me.TextImporte.BackColor = System.Drawing.Color.White
        Me.TextImporte.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextImporte.BorderColor = System.Drawing.Color.Silver
        Me.TextImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextImporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextImporte.CornerRadius = 4
        Me.TextImporte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextImporte.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextImporte.Location = New System.Drawing.Point(371, 47)
        Me.TextImporte.Metrocolor = System.Drawing.Color.Silver
        Me.TextImporte.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextImporte.Name = "TextImporte"
        Me.TextImporte.ReadOnly = True
        Me.TextImporte.Size = New System.Drawing.Size(91, 22)
        Me.TextImporte.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextImporte.TabIndex = 406
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(371, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 14)
        Me.Label7.TabIndex = 405
        Me.Label7.Text = "Monto pagado"
        '
        'TextNumeroFormaPago
        '
        Me.TextNumeroFormaPago.BackColor = System.Drawing.Color.White
        Me.TextNumeroFormaPago.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextNumeroFormaPago.BorderColor = System.Drawing.Color.Silver
        Me.TextNumeroFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumeroFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumeroFormaPago.CornerRadius = 4
        Me.TextNumeroFormaPago.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumeroFormaPago.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumeroFormaPago.Location = New System.Drawing.Point(266, 47)
        Me.TextNumeroFormaPago.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumeroFormaPago.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumeroFormaPago.Name = "TextNumeroFormaPago"
        Me.TextNumeroFormaPago.ReadOnly = True
        Me.TextNumeroFormaPago.Size = New System.Drawing.Size(91, 22)
        Me.TextNumeroFormaPago.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumeroFormaPago.TabIndex = 404
        '
        'TextFormaPago
        '
        Me.TextFormaPago.BackColor = System.Drawing.Color.White
        Me.TextFormaPago.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextFormaPago.BorderColor = System.Drawing.Color.Silver
        Me.TextFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFormaPago.CornerRadius = 4
        Me.TextFormaPago.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextFormaPago.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFormaPago.Location = New System.Drawing.Point(19, 47)
        Me.TextFormaPago.Metrocolor = System.Drawing.Color.Silver
        Me.TextFormaPago.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextFormaPago.Name = "TextFormaPago"
        Me.TextFormaPago.ReadOnly = True
        Me.TextFormaPago.Size = New System.Drawing.Size(241, 22)
        Me.TextFormaPago.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextFormaPago.TabIndex = 402
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(16, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 14)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Descripción"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextTipoPersona)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TextDNI)
        Me.GroupBox3.Controls.Add(Me.TextPersona)
        Me.GroupBox3.Location = New System.Drawing.Point(27, 250)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(612, 70)
        Me.GroupBox3.TabIndex = 409
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Persona encargada de la recepción o entrega del dinero"
        '
        'TextTipoPersona
        '
        Me.TextTipoPersona.BackColor = System.Drawing.Color.White
        Me.TextTipoPersona.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextTipoPersona.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoPersona.CornerRadius = 4
        Me.TextTipoPersona.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextTipoPersona.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoPersona.Location = New System.Drawing.Point(371, 38)
        Me.TextTipoPersona.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoPersona.Name = "TextTipoPersona"
        Me.TextTipoPersona.ReadOnly = True
        Me.TextTipoPersona.Size = New System.Drawing.Size(91, 22)
        Me.TextTipoPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTipoPersona.TabIndex = 406
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(371, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 14)
        Me.Label9.TabIndex = 405
        Me.Label9.Text = "Tipo"
        '
        'TextDNI
        '
        Me.TextDNI.BackColor = System.Drawing.Color.White
        Me.TextDNI.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextDNI.BorderColor = System.Drawing.Color.Silver
        Me.TextDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDNI.CornerRadius = 4
        Me.TextDNI.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextDNI.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDNI.Location = New System.Drawing.Point(266, 38)
        Me.TextDNI.Metrocolor = System.Drawing.Color.Silver
        Me.TextDNI.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDNI.Name = "TextDNI"
        Me.TextDNI.ReadOnly = True
        Me.TextDNI.Size = New System.Drawing.Size(91, 22)
        Me.TextDNI.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextDNI.TabIndex = 404
        '
        'TextPersona
        '
        Me.TextPersona.BackColor = System.Drawing.Color.White
        Me.TextPersona.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextPersona.BorderColor = System.Drawing.Color.Silver
        Me.TextPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPersona.CornerRadius = 4
        Me.TextPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPersona.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPersona.Location = New System.Drawing.Point(19, 38)
        Me.TextPersona.Metrocolor = System.Drawing.Color.Silver
        Me.TextPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPersona.Name = "TextPersona"
        Me.TextPersona.ReadOnly = True
        Me.TextPersona.Size = New System.Drawing.Size(241, 22)
        Me.TextPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPersona.TabIndex = 402
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextGlosa)
        Me.GroupBox4.Location = New System.Drawing.Point(27, 323)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(612, 70)
        Me.GroupBox4.TabIndex = 410
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Glosa, detalle motivo"
        '
        'TextGlosa
        '
        Me.TextGlosa.BackColor = System.Drawing.Color.White
        Me.TextGlosa.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TextGlosa.BorderColor = System.Drawing.Color.Silver
        Me.TextGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextGlosa.CornerRadius = 4
        Me.TextGlosa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextGlosa.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGlosa.Location = New System.Drawing.Point(19, 21)
        Me.TextGlosa.Metrocolor = System.Drawing.Color.Silver
        Me.TextGlosa.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextGlosa.Multiline = True
        Me.TextGlosa.Name = "TextGlosa"
        Me.TextGlosa.ReadOnly = True
        Me.TextGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextGlosa.Size = New System.Drawing.Size(579, 37)
        Me.TextGlosa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextGlosa.TabIndex = 402
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(110, 37)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.Image = CType(resources.GetObject("ButtonAdv5.Image"), System.Drawing.Image)
        Me.ButtonAdv5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(279, 400)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(110, 37)
        Me.ButtonAdv5.TabIndex = 615
        Me.ButtonAdv5.Text = "       Aceptar"
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'FormVerPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Visualizar pago"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(672, 441)
        Me.Controls.Add(Me.ButtonAdv5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextFechaPago)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextFechaTrans)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextNumero)
        Me.Controls.Add(Me.TextTipoComprobante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVerPagos"
        Me.ShowIcon = False
        CType(Me.TextTipoComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTipoCuentaFinanciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCuentaFinanciera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TextImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumeroFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TextTipoPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TextGlosa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextTipoComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextFechaPago As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents TextFechaTrans As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextTipoCuentaFinanciera As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents TextCuentaFinanciera As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextNumeroFormaPago As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextFormaPago As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextImporte As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextTipoPersona As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label9 As Label
    Friend WithEvents TextDNI As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextPersona As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextGlosa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents TextMoneda As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label10 As Label
End Class
