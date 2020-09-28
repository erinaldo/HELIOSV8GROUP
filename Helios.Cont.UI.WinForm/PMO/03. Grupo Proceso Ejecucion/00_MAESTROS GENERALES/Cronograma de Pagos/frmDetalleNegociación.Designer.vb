<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleNegociación
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleNegociación))
        Me.dgvObligaciones = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel35 = New System.Windows.Forms.Panel()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv37 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv38 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv39 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.dgvObligaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel35.SuspendLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvObligaciones
        '
        Me.dgvObligaciones.BackColor = System.Drawing.SystemColors.Window
        Me.dgvObligaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvObligaciones.FreezeCaption = False
        Me.dgvObligaciones.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvObligaciones.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvObligaciones.Location = New System.Drawing.Point(0, 70)
        Me.dgvObligaciones.Name = "dgvObligaciones"
        Me.dgvObligaciones.Size = New System.Drawing.Size(816, 284)
        Me.dgvObligaciones.TabIndex = 251
        Me.dgvObligaciones.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Fecha Programada"
        GridColumnDescriptor1.MappingName = "fecha"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Fecha de Pago"
        GridColumnDescriptor2.MappingName = "fechaPago"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 180
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Monto"
        GridColumnDescriptor3.MappingName = "importe"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 80
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "MontoME"
        GridColumnDescriptor4.MappingName = "importeme"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 80
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "idCronograma"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 0
        Me.dgvObligaciones.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.dgvObligaciones.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvObligaciones.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvObligaciones.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvObligaciones.Text = "GridGroupingControl3"
        Me.dgvObligaciones.VersionInfo = "12.4400.0.24"
        '
        'Panel35
        '
        Me.Panel35.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel35.Controls.Add(Me.lblIdDocumento)
        Me.Panel35.Controls.Add(Me.BtnGrabar)
        Me.Panel35.Controls.Add(Me.Label2)
        Me.Panel35.Controls.Add(Me.Label1)
        Me.Panel35.Controls.Add(Me.txtNumero)
        Me.Panel35.Controls.Add(Me.txtSerie)
        Me.Panel35.Controls.Add(Me.Label7)
        Me.Panel35.Controls.Add(Me.txtProveedor)
        Me.Panel35.Controls.Add(Me.ButtonAdv37)
        Me.Panel35.Controls.Add(Me.ButtonAdv38)
        Me.Panel35.Controls.Add(Me.ButtonAdv39)
        Me.Panel35.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel35.Location = New System.Drawing.Point(0, 0)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Size = New System.Drawing.Size(816, 70)
        Me.Panel35.TabIndex = 250
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.Location = New System.Drawing.Point(767, 28)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 13)
        Me.lblIdDocumento.TabIndex = 592
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.Chocolate
        Me.BtnGrabar.ForeColor = System.Drawing.Color.White
        Me.BtnGrabar.Location = New System.Drawing.Point(640, 9)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(106, 45)
        Me.BtnGrabar.TabIndex = 591
        Me.BtnGrabar.Text = "Eliminar Cuotas"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(511, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 12)
        Me.Label2.TabIndex = 590
        Me.Label2.Text = "NÚMERO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(408, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 589
        Me.Label1.Text = "SERIE"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(359, 22)
        Me.txtNumero.BorderColor = System.Drawing.Color.DarkGray
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.CornerRadius = 5
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(513, 28)
        Me.txtNumero.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(102, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumero.TabIndex = 588
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(359, 22)
        Me.txtSerie.BorderColor = System.Drawing.Color.DarkGray
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.CornerRadius = 5
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSerie.Location = New System.Drawing.Point(407, 28)
        Me.txtSerie.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(86, 22)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSerie.TabIndex = 587
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(23, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 12)
        Me.Label7.TabIndex = 585
        Me.Label7.Text = "IDENTIFICACION"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(359, 22)
        Me.txtProveedor.BorderColor = System.Drawing.Color.DarkGray
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.CornerRadius = 5
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedor.Location = New System.Drawing.Point(25, 28)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(359, 22)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProveedor.TabIndex = 586
        '
        'ButtonAdv37
        '
        Me.ButtonAdv37.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv37.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv37.BeforeTouchSize = New System.Drawing.Size(25, 27)
        Me.ButtonAdv37.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None
        Me.ButtonAdv37.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv37.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv37.Image = CType(resources.GetObject("ButtonAdv37.Image"), System.Drawing.Image)
        Me.ButtonAdv37.IsBackStageButton = False
        Me.ButtonAdv37.Location = New System.Drawing.Point(1057, 17)
        Me.ButtonAdv37.Name = "ButtonAdv37"
        Me.ButtonAdv37.Size = New System.Drawing.Size(25, 27)
        Me.ButtonAdv37.TabIndex = 524
        Me.ButtonAdv37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv37.UseVisualStyle = True
        Me.ButtonAdv37.Visible = False
        '
        'ButtonAdv38
        '
        Me.ButtonAdv38.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv38.BackColor = System.Drawing.Color.Gray
        Me.ButtonAdv38.BeforeTouchSize = New System.Drawing.Size(25, 27)
        Me.ButtonAdv38.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None
        Me.ButtonAdv38.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv38.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv38.Image = CType(resources.GetObject("ButtonAdv38.Image"), System.Drawing.Image)
        Me.ButtonAdv38.IsBackStageButton = False
        Me.ButtonAdv38.Location = New System.Drawing.Point(1088, 17)
        Me.ButtonAdv38.Name = "ButtonAdv38"
        Me.ButtonAdv38.Size = New System.Drawing.Size(25, 27)
        Me.ButtonAdv38.TabIndex = 523
        Me.ButtonAdv38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv38.UseVisualStyle = True
        Me.ButtonAdv38.Visible = False
        '
        'ButtonAdv39
        '
        Me.ButtonAdv39.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv39.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv39.BeforeTouchSize = New System.Drawing.Size(25, 27)
        Me.ButtonAdv39.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None
        Me.ButtonAdv39.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv39.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv39.Image = CType(resources.GetObject("ButtonAdv39.Image"), System.Drawing.Image)
        Me.ButtonAdv39.IsBackStageButton = False
        Me.ButtonAdv39.Location = New System.Drawing.Point(1119, 17)
        Me.ButtonAdv39.Name = "ButtonAdv39"
        Me.ButtonAdv39.Size = New System.Drawing.Size(25, 27)
        Me.ButtonAdv39.TabIndex = 522
        Me.ButtonAdv39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv39.UseVisualStyle = True
        Me.ButtonAdv39.Visible = False
        '
        'frmDetalleNegociación
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(816, 354)
        Me.Controls.Add(Me.dgvObligaciones)
        Me.Controls.Add(Me.Panel35)
        Me.Name = "frmDetalleNegociación"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.dgvObligaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel35.ResumeLayout(False)
        Me.Panel35.PerformLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvObligaciones As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel35 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAdv37 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv38 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv39 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
End Class
