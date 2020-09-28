<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCRankingVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCRankingVentas))
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboMesPedido = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ComboUnidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboReporte = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.BunifuThinButton23)
        Me.GradientPanel2.Controls.Add(Me.cboAnio)
        Me.GradientPanel2.Controls.Add(Me.cboMesPedido)
        Me.GradientPanel2.Controls.Add(Me.ComboUnidad)
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Controls.Add(Me.ComboReporte)
        Me.GradientPanel2.Controls.Add(Me.Label2)
        Me.GradientPanel2.Controls.Add(Me.Label4)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1107, 60)
        Me.GradientPanel2.TabIndex = 716
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
        Me.BunifuThinButton23.Location = New System.Drawing.Point(652, 19)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(94, 35)
        Me.BunifuThinButton23.TabIndex = 713
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboAnio
        '
        Me.cboAnio.AutoComplete = False
        Me.cboAnio.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboAnio.Location = New System.Drawing.Point(585, 28)
        Me.cboAnio.MetroBorderColor = System.Drawing.Color.DimGray
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboAnio.TabIndex = 463
        '
        'cboMesPedido
        '
        Me.cboMesPedido.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboMesPedido.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMesPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesPedido.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboMesPedido.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesPedido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboMesPedido.Location = New System.Drawing.Point(460, 28)
        Me.cboMesPedido.MetroBorderColor = System.Drawing.Color.DimGray
        Me.cboMesPedido.Name = "cboMesPedido"
        Me.cboMesPedido.Size = New System.Drawing.Size(121, 21)
        Me.cboMesPedido.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboMesPedido.TabIndex = 462
        '
        'ComboUnidad
        '
        Me.ComboUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboUnidad.BeforeTouchSize = New System.Drawing.Size(222, 21)
        Me.ComboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUnidad.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboUnidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboUnidad.Location = New System.Drawing.Point(14, 28)
        Me.ComboUnidad.MetroBorderColor = System.Drawing.Color.DimGray
        Me.ComboUnidad.Name = "ComboUnidad"
        Me.ComboUnidad.Size = New System.Drawing.Size(222, 21)
        Me.ComboUnidad.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboUnidad.TabIndex = 704
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 705
        Me.Label1.Text = "UNIDAD DE NEGOCIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboReporte
        '
        Me.ComboReporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboReporte.BeforeTouchSize = New System.Drawing.Size(212, 21)
        Me.ComboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboReporte.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboReporte.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboReporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboReporte.Items.AddRange(New Object() {"CLIENTES", "PRODUCTO", "VENDEDOR"})
        Me.ComboReporte.Location = New System.Drawing.Point(242, 28)
        Me.ComboReporte.MetroBorderColor = System.Drawing.Color.DimGray
        Me.ComboReporte.Name = "ComboReporte"
        Me.ComboReporte.Size = New System.Drawing.Size(212, 21)
        Me.ComboReporte.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboReporte.TabIndex = 706
        Me.ComboReporte.Text = "CLIENTES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(240, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 707
        Me.Label2.Text = "CONSULTAR"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(456, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 712
        Me.Label4.Text = "PERIODO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelBody
        '
        Me.PanelBody.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 60)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1107, 434)
        Me.PanelBody.TabIndex = 717
        '
        'UCRankingVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "UCRankingVentas"
        Me.Size = New System.Drawing.Size(1107, 494)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ComboUnidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboReporte As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboMesPedido As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
End Class
