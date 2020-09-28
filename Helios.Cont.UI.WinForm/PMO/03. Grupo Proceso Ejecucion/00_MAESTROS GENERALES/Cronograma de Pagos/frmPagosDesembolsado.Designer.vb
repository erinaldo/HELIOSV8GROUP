<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagosDesembolsado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagosDesembolsado))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txttipoProveedor = New System.Windows.Forms.TextBox()
        Me.txttipo = New System.Windows.Forms.TextBox()
        Me.txtcabezera = New System.Windows.Forms.Label()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1.SuspendLayout()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtProveedor)
        Me.Panel1.Controls.Add(Me.txttipoProveedor)
        Me.Panel1.Controls.Add(Me.txttipo)
        Me.Panel1.Controls.Add(Me.txtcabezera)
        Me.Panel1.Controls.Add(Me.BtnGrabar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(658, 97)
        Me.Panel1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(387, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 12)
        Me.Label4.TabIndex = 586
        Me.Label4.Text = "TIPO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(22, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 12)
        Me.Label7.TabIndex = 583
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
        Me.txtProveedor.Location = New System.Drawing.Point(24, 54)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(359, 22)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProveedor.TabIndex = 584
        '
        'txttipoProveedor
        '
        Me.txttipoProveedor.Location = New System.Drawing.Point(389, 54)
        Me.txttipoProveedor.Name = "txttipoProveedor"
        Me.txttipoProveedor.ReadOnly = True
        Me.txttipoProveedor.Size = New System.Drawing.Size(41, 22)
        Me.txttipoProveedor.TabIndex = 585
        '
        'txttipo
        '
        Me.txttipo.Location = New System.Drawing.Point(640, 25)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(67, 22)
        Me.txttipo.TabIndex = 217
        Me.txttipo.Visible = False
        '
        'txtcabezera
        '
        Me.txtcabezera.AutoSize = True
        Me.txtcabezera.BackColor = System.Drawing.Color.Transparent
        Me.txtcabezera.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcabezera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcabezera.Location = New System.Drawing.Point(466, 27)
        Me.txtcabezera.Name = "txtcabezera"
        Me.txtcabezera.Size = New System.Drawing.Size(136, 12)
        Me.txtcabezera.TabIndex = 216
        Me.txtcabezera.Text = "APROBAR OBLIGACIONES"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.Chocolate
        Me.BtnGrabar.ForeColor = System.Drawing.Color.White
        Me.BtnGrabar.Location = New System.Drawing.Point(483, 51)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(94, 31)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "Aceptar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GridGroupingControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 97)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(658, 161)
        Me.Panel3.TabIndex = 2
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.FreezeCaption = False
        Me.GridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.Size = New System.Drawing.Size(658, 161)
        Me.GridGroupingControl1.TabIndex = 5
        Me.GridGroupingControl1.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Número Doc."
        GridColumnDescriptor1.MappingName = "nrodoc"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 80
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Monto Pagado"
        GridColumnDescriptor2.MappingName = "monto"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 70
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Monto Pagado ME"
        GridColumnDescriptor3.MappingName = "montome"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 70
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Detalle"
        GridColumnDescriptor4.MappingName = "glosa"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Fecha Programada"
        GridColumnDescriptor5.MappingName = "fecha"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 0
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Fecha de Pago"
        GridColumnDescriptor6.MappingName = "fechaPago"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 155
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "idDocRef"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 0
        Me.GridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.GridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridGroupingControl1.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.GridGroupingControl1.Text = "GridGroupingControl3"
        Me.GridGroupingControl1.VersionInfo = "12.4400.0.24"
        '
        'frmPagosDesembolsado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.DarkCyan
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(658, 258)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPagosDesembolsado"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txttipoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents txtcabezera As System.Windows.Forms.Label
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
