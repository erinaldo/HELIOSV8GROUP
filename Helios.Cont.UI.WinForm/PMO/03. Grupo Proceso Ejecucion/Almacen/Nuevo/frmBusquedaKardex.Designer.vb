<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusquedaKardex
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
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtExistencia = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pcExistencias = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvArticulos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonAdv11 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv12 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.chkfiltro = New System.Windows.Forms.CheckBox()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.pcExistencias.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(369, 10)
        Me.GradientPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(22, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo Existencia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(22, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Describir Existencia"
        '
        'cboTipoExistencia
        '
        Me.cboTipoExistencia.BackColor = System.Drawing.Color.White
        Me.cboTipoExistencia.BeforeTouchSize = New System.Drawing.Size(312, 21)
        Me.cboTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExistencia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoExistencia.Location = New System.Drawing.Point(25, 51)
        Me.cboTipoExistencia.Name = "cboTipoExistencia"
        Me.cboTipoExistencia.Size = New System.Drawing.Size(312, 21)
        Me.cboTipoExistencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoExistencia.TabIndex = 3
        '
        'txtExistencia
        '
        Me.txtExistencia.BackColor = System.Drawing.Color.White
        Me.txtExistencia.BeforeTouchSize = New System.Drawing.Size(312, 22)
        Me.txtExistencia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtExistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExistencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExistencia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExistencia.Location = New System.Drawing.Point(25, 109)
        Me.txtExistencia.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.Size = New System.Drawing.Size(312, 22)
        Me.txtExistencia.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtExistencia.TabIndex = 4
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 162)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(369, 59)
        Me.GradientPanel2.TabIndex = 432
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(211, 15)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.TabIndex = 9
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(96, 15)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Consultar"
        Me.btOperacion.UseVisualStyle = True
        '
        'pcExistencias
        '
        Me.pcExistencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcExistencias.Controls.Add(Me.lsvArticulos)
        Me.pcExistencias.Controls.Add(Me.ButtonAdv11)
        Me.pcExistencias.Controls.Add(Me.ButtonAdv12)
        Me.pcExistencias.Location = New System.Drawing.Point(156, 79)
        Me.pcExistencias.Name = "pcExistencias"
        Me.pcExistencias.Size = New System.Drawing.Size(193, 80)
        Me.pcExistencias.TabIndex = 491
        Me.pcExistencias.Visible = False
        '
        'lsvArticulos
        '
        Me.lsvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvArticulos.Location = New System.Drawing.Point(0, 0)
        Me.lsvArticulos.Name = "lsvArticulos"
        Me.lsvArticulos.Size = New System.Drawing.Size(191, 78)
        Me.lsvArticulos.TabIndex = 492
        Me.lsvArticulos.UseCompatibleStateImageBehavior = False
        Me.lsvArticulos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Artículo"
        Me.ColumnHeader2.Width = 195
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Gr."
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 30
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Tipo existencia"
        Me.ColumnHeader4.Width = 93
        '
        'ButtonAdv11
        '
        Me.ButtonAdv11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv11.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv11.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv11.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv11.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv11.IsBackStageButton = False
        Me.ButtonAdv11.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv11.Name = "ButtonAdv11"
        Me.ButtonAdv11.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv11.TabIndex = 2
        Me.ButtonAdv11.Text = "Cancel"
        Me.ButtonAdv11.UseVisualStyle = True
        '
        'ButtonAdv12
        '
        Me.ButtonAdv12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv12.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv12.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv12.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv12.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv12.IsBackStageButton = False
        Me.ButtonAdv12.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv12.Name = "ButtonAdv12"
        Me.ButtonAdv12.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv12.TabIndex = 1
        Me.ButtonAdv12.Text = "OK"
        Me.ButtonAdv12.UseVisualStyle = True
        '
        'chkfiltro
        '
        Me.chkfiltro.AutoSize = True
        Me.chkfiltro.Location = New System.Drawing.Point(235, 28)
        Me.chkfiltro.Name = "chkfiltro"
        Me.chkfiltro.Size = New System.Drawing.Size(102, 17)
        Me.chkfiltro.TabIndex = 492
        Me.chkfiltro.Text = "Solo Existencia"
        Me.chkfiltro.UseVisualStyleBackColor = True
        '
        'frmBusquedaKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(30, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Búsqueda interactiva."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(369, 221)
        Me.Controls.Add(Me.chkfiltro)
        Me.Controls.Add(Me.pcExistencias)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.txtExistencia)
        Me.Controls.Add(Me.cboTipoExistencia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBusquedaKardex"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.pcExistencias.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtExistencia As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents pcExistencias As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents ButtonAdv11 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv12 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lsvArticulos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkfiltro As CheckBox
End Class
