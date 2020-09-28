<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalCambioCosto
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
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboproceso = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboCosto = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cbotipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.cboproceso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbotipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proceso"
        '
        'cboproceso
        '
        Me.cboproceso.BackColor = System.Drawing.Color.White
        Me.cboproceso.BeforeTouchSize = New System.Drawing.Size(274, 21)
        Me.cboproceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboproceso.Enabled = False
        Me.cboproceso.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboproceso.Location = New System.Drawing.Point(40, 35)
        Me.cboproceso.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboproceso.Name = "cboproceso"
        Me.cboproceso.Size = New System.Drawing.Size(274, 21)
        Me.cboproceso.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboproceso.TabIndex = 441
        '
        'cboCosto
        '
        Me.cboCosto.BackColor = System.Drawing.Color.White
        Me.cboCosto.BeforeTouchSize = New System.Drawing.Size(274, 21)
        Me.cboCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCosto.Enabled = False
        Me.cboCosto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCosto.Location = New System.Drawing.Point(40, 86)
        Me.cboCosto.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboCosto.Name = "cboCosto"
        Me.cboCosto.Size = New System.Drawing.Size(274, 21)
        Me.cboCosto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCosto.TabIndex = 443
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 442
        Me.Label2.Text = "Costo"
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(214, 172)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 444
        Me.btOperacion.Text = "Cambiar"
        Me.btOperacion.UseVisualStyle = True
        '
        'cbotipo
        '
        Me.cbotipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.cbotipo.BeforeTouchSize = New System.Drawing.Size(274, 21)
        Me.cbotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipo.Enabled = False
        Me.cbotipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipo.Items.AddRange(New Object() {"PROYECTO", "ORDEN DE PRODUCCION", "ACTIVO FIJO", "GASTO ADMINISTRATIVO", "GASTO DE VENTAS", "GASTO FINANCIERO"})
        Me.cbotipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipo, "PROYECTO"))
        Me.cbotipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipo, "ORDEN DE PRODUCCION"))
        Me.cbotipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipo, "ACTIVO FIJO"))
        Me.cbotipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipo, "GASTO ADMINISTRATIVO"))
        Me.cbotipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipo, "GASTO DE VENTAS"))
        Me.cbotipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipo, "GASTO FINANCIERO"))
        Me.cbotipo.Location = New System.Drawing.Point(40, 137)
        Me.cbotipo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cbotipo.Name = "cbotipo"
        Me.cbotipo.Size = New System.Drawing.Size(274, 21)
        Me.cbotipo.Style = Syncfusion.Windows.Forms.VisualStyle.Office2010
        Me.cbotipo.TabIndex = 446
        Me.cbotipo.Text = "PROYECTO"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(37, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 445
        Me.Label12.Text = "Tipo"
        '
        'frmModalCambioCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(30, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(180, 24)
        CaptionLabel1.Text = "Cambiar de proceso"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(356, 217)
        Me.Controls.Add(Me.cbotipo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.cboCosto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboproceso)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalCambioCosto"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.cboproceso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbotipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboproceso As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboCosto As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cbotipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
