<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoCosto
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
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTipoDoc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNro = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtMoned = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txttipocambio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtmontoMN = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtmontoME = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCosto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtfecha = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtitem = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.txtTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMoned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttipocambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmontoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmontoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtitem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TIPO DOC."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NRO COMPROBANTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "PROVEEDOR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MONEDA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(154, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "T/C."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(41, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "IMPORTE MN."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(154, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "IMPORTE MN."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(41, 326)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "COSTO ASIGNADO"
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.BackColor = System.Drawing.Color.White
        Me.txtTipoDoc.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtTipoDoc.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtTipoDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDoc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoDoc.Location = New System.Drawing.Point(43, 35)
        Me.txtTipoDoc.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtTipoDoc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.ReadOnly = True
        Me.txtTipoDoc.Size = New System.Drawing.Size(174, 20)
        Me.txtTipoDoc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoDoc.TabIndex = 500
        '
        'txtNro
        '
        Me.txtNro.BackColor = System.Drawing.Color.White
        Me.txtNro.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtNro.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNro.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNro.Location = New System.Drawing.Point(43, 85)
        Me.txtNro.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtNro.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.ReadOnly = True
        Me.txtNro.Size = New System.Drawing.Size(174, 20)
        Me.txtNro.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNro.TabIndex = 501
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtProveedor.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedor.Location = New System.Drawing.Point(43, 134)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(296, 20)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtProveedor.TabIndex = 502
        '
        'txtMoned
        '
        Me.txtMoned.BackColor = System.Drawing.Color.White
        Me.txtMoned.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtMoned.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtMoned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMoned.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMoned.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoned.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMoned.Location = New System.Drawing.Point(43, 189)
        Me.txtMoned.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtMoned.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMoned.Name = "txtMoned"
        Me.txtMoned.ReadOnly = True
        Me.txtMoned.Size = New System.Drawing.Size(107, 20)
        Me.txtMoned.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMoned.TabIndex = 503
        '
        'txttipocambio
        '
        Me.txttipocambio.BackColor = System.Drawing.Color.White
        Me.txttipocambio.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txttipocambio.BorderColor = System.Drawing.Color.Gainsboro
        Me.txttipocambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttipocambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txttipocambio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttipocambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txttipocambio.Location = New System.Drawing.Point(156, 189)
        Me.txttipocambio.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txttipocambio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txttipocambio.Name = "txttipocambio"
        Me.txttipocambio.ReadOnly = True
        Me.txttipocambio.Size = New System.Drawing.Size(107, 20)
        Me.txttipocambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txttipocambio.TabIndex = 504
        '
        'txtmontoMN
        '
        Me.txtmontoMN.BackColor = System.Drawing.Color.White
        Me.txtmontoMN.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtmontoMN.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtmontoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmontoMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtmontoMN.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmontoMN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtmontoMN.Location = New System.Drawing.Point(43, 246)
        Me.txtmontoMN.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtmontoMN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtmontoMN.Name = "txtmontoMN"
        Me.txtmontoMN.ReadOnly = True
        Me.txtmontoMN.Size = New System.Drawing.Size(107, 20)
        Me.txtmontoMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtmontoMN.TabIndex = 505
        '
        'txtmontoME
        '
        Me.txtmontoME.BackColor = System.Drawing.Color.White
        Me.txtmontoME.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtmontoME.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtmontoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmontoME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtmontoME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmontoME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtmontoME.Location = New System.Drawing.Point(156, 246)
        Me.txtmontoME.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtmontoME.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtmontoME.Name = "txtmontoME"
        Me.txtmontoME.ReadOnly = True
        Me.txtmontoME.Size = New System.Drawing.Size(107, 20)
        Me.txtmontoME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtmontoME.TabIndex = 506
        '
        'txtCosto
        '
        Me.txtCosto.BackColor = System.Drawing.Color.White
        Me.txtCosto.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtCosto.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCosto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCosto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCosto.Location = New System.Drawing.Point(43, 345)
        Me.txtCosto.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtCosto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.ReadOnly = True
        Me.txtCosto.Size = New System.Drawing.Size(296, 20)
        Me.txtCosto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCosto.TabIndex = 507
        '
        'txtfecha
        '
        Me.txtfecha.BackColor = System.Drawing.Color.White
        Me.txtfecha.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtfecha.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtfecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfecha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtfecha.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtfecha.Location = New System.Drawing.Point(223, 35)
        Me.txtfecha.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtfecha.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.ReadOnly = True
        Me.txtfecha.Size = New System.Drawing.Size(116, 20)
        Me.txtfecha.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtfecha.TabIndex = 509
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(221, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 12)
        Me.Label9.TabIndex = 508
        Me.Label9.Text = "FECHA"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(135, 384)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 41)
        Me.Button1.TabIndex = 510
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtitem
        '
        Me.txtitem.BackColor = System.Drawing.Color.Goldenrod
        Me.txtitem.BeforeTouchSize = New System.Drawing.Size(296, 20)
        Me.txtitem.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtitem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtitem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtitem.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitem.ForeColor = System.Drawing.Color.White
        Me.txtitem.Location = New System.Drawing.Point(43, 295)
        Me.txtitem.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtitem.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtitem.Name = "txtitem"
        Me.txtitem.ReadOnly = True
        Me.txtitem.Size = New System.Drawing.Size(296, 20)
        Me.txtitem.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtitem.TabIndex = 512
        Me.txtitem.Text = "MARCADERIA"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(41, 276)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 12)
        Me.Label10.TabIndex = 511
        Me.Label10.Text = "EXISTENCIA / GASTO"
        '
        'frmInfoCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.Green
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 50
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(30, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Información General"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(376, 437)
        Me.Controls.Add(Me.txtitem)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtfecha)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCosto)
        Me.Controls.Add(Me.txtmontoME)
        Me.Controls.Add(Me.txtmontoMN)
        Me.Controls.Add(Me.txttipocambio)
        Me.Controls.Add(Me.txtMoned)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.txtNro)
        Me.Controls.Add(Me.txtTipoDoc)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoCosto"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMoned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttipocambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmontoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmontoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtitem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTipoDoc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNro As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtMoned As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txttipocambio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtmontoMN As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtmontoME As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCosto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtfecha As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtitem As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
