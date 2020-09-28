<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frminfocierreCosto
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
        Me.txtTipoCosto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNomCosto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporteMN = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtImporteME = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.txtTipoCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TIPO COSTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "NOMBRE DEL COSTO"
        '
        'txtTipoCosto
        '
        Me.txtTipoCosto.BackColor = System.Drawing.Color.White
        Me.txtTipoCosto.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTipoCosto.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtTipoCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCosto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCosto.Enabled = False
        Me.txtTipoCosto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCosto.Location = New System.Drawing.Point(26, 41)
        Me.txtTipoCosto.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtTipoCosto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoCosto.Name = "txtTipoCosto"
        Me.txtTipoCosto.ReadOnly = True
        Me.txtTipoCosto.Size = New System.Drawing.Size(289, 20)
        Me.txtTipoCosto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCosto.TabIndex = 503
        '
        'txtNomCosto
        '
        Me.txtNomCosto.BackColor = System.Drawing.Color.White
        Me.txtNomCosto.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNomCosto.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtNomCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomCosto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNomCosto.Enabled = False
        Me.txtNomCosto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNomCosto.Location = New System.Drawing.Point(26, 96)
        Me.txtNomCosto.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtNomCosto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNomCosto.Multiline = True
        Me.txtNomCosto.Name = "txtNomCosto"
        Me.txtNomCosto.ReadOnly = True
        Me.txtNomCosto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNomCosto.Size = New System.Drawing.Size(289, 71)
        Me.txtNomCosto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNomCosto.TabIndex = 504
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 12)
        Me.Label3.TabIndex = 505
        Me.Label3.Text = "TOTAL IMPORTES DE CIERRE"
        '
        'txtImporteMN
        '
        Me.txtImporteMN.BackColor = System.Drawing.Color.Goldenrod
        Me.txtImporteMN.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtImporteMN.BorderColor = System.Drawing.Color.Lavender
        Me.txtImporteMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImporteMN.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteMN.ForeColor = System.Drawing.Color.White
        Me.txtImporteMN.Location = New System.Drawing.Point(26, 212)
        Me.txtImporteMN.Metrocolor = System.Drawing.Color.Lavender
        Me.txtImporteMN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtImporteMN.Name = "txtImporteMN"
        Me.txtImporteMN.ReadOnly = True
        Me.txtImporteMN.Size = New System.Drawing.Size(114, 20)
        Me.txtImporteMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtImporteMN.TabIndex = 506
        Me.txtImporteMN.Text = "0.00"
        Me.txtImporteMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteME
        '
        Me.txtImporteME.BackColor = System.Drawing.Color.White
        Me.txtImporteME.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtImporteME.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtImporteME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImporteME.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtImporteME.Location = New System.Drawing.Point(146, 212)
        Me.txtImporteME.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtImporteME.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtImporteME.Name = "txtImporteME"
        Me.txtImporteME.ReadOnly = True
        Me.txtImporteME.Size = New System.Drawing.Size(114, 20)
        Me.txtImporteME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtImporteME.TabIndex = 507
        Me.txtImporteME.Text = "0.00"
        Me.txtImporteME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(117, 254)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 41)
        Me.Button1.TabIndex = 511
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frminfocierreCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(30, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Concluir costo"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(343, 314)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtImporteME)
        Me.Controls.Add(Me.txtImporteMN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNomCosto)
        Me.Controls.Add(Me.txtTipoCosto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frminfocierreCosto"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtTipoCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCosto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNomCosto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImporteMN As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtImporteME As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
