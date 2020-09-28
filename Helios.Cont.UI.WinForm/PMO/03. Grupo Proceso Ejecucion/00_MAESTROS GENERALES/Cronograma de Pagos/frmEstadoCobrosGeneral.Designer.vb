<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadoCobrosGeneral
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
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor18 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor19 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor20 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor21 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor22 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor23 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor24 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv7 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvProcesoCrono = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvProcesoCrono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonAdv2)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.ButtonAdv7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(910, 59)
        Me.Panel1.TabIndex = 2
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.Goldenrod
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(106, 33)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(156, 12)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(106, 33)
        Me.ButtonAdv1.TabIndex = 528
        Me.ButtonAdv1.Text = "Programar Cobros"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'ButtonAdv7
        '
        Me.ButtonAdv7.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv7.BackColor = System.Drawing.Color.Goldenrod
        Me.ButtonAdv7.BeforeTouchSize = New System.Drawing.Size(106, 33)
        Me.ButtonAdv7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv7.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv7.IsBackStageButton = False
        Me.ButtonAdv7.Location = New System.Drawing.Point(30, 12)
        Me.ButtonAdv7.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv7.Name = "ButtonAdv7"
        Me.ButtonAdv7.Size = New System.Drawing.Size(106, 33)
        Me.ButtonAdv7.TabIndex = 527
        Me.ButtonAdv7.Text = "Acreencias"
        Me.ButtonAdv7.UseVisualStyle = True
        Me.ButtonAdv7.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvProcesoCrono)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 59)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(910, 540)
        Me.Panel3.TabIndex = 7
        '
        'dgvProcesoCrono
        '
        Me.dgvProcesoCrono.BackColor = System.Drawing.SystemColors.Window
        Me.dgvProcesoCrono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProcesoCrono.FreezeCaption = False
        Me.dgvProcesoCrono.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvProcesoCrono.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvProcesoCrono.Location = New System.Drawing.Point(0, 0)
        Me.dgvProcesoCrono.Name = "dgvProcesoCrono"
        Me.dgvProcesoCrono.Size = New System.Drawing.Size(910, 540)
        Me.dgvProcesoCrono.TabIndex = 3
        Me.dgvProcesoCrono.TableDescriptor.AllowNew = False
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.MappingName = "idProveedor"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 0
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "Razon Social"
        GridColumnDescriptor14.MappingName = "razonSocial"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 180
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "Deuda"
        GridColumnDescriptor15.MappingName = "deuda"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 70
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.HeaderText = "monto Cobrado"
        GridColumnDescriptor16.MappingName = "montoPago"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.SerializedImageArray = ""
        GridColumnDescriptor16.Width = 70
        GridColumnDescriptor17.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Red)
        GridColumnDescriptor17.HeaderImage = Nothing
        GridColumnDescriptor17.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor17.HeaderText = "Saldo"
        GridColumnDescriptor17.MappingName = "saldo"
        GridColumnDescriptor17.ReadOnly = True
        GridColumnDescriptor17.SerializedImageArray = ""
        GridColumnDescriptor17.Width = 70
        GridColumnDescriptor18.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gold)
        GridColumnDescriptor18.HeaderImage = Nothing
        GridColumnDescriptor18.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor18.HeaderText = "Monto Vencido"
        GridColumnDescriptor18.MappingName = "montoVencido"
        GridColumnDescriptor18.ReadOnly = True
        GridColumnDescriptor18.SerializedImageArray = ""
        GridColumnDescriptor18.Width = 70
        GridColumnDescriptor19.HeaderImage = Nothing
        GridColumnDescriptor19.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor19.MappingName = "montoProg"
        GridColumnDescriptor19.ReadOnly = True
        GridColumnDescriptor19.SerializedImageArray = ""
        GridColumnDescriptor19.Width = 70
        GridColumnDescriptor20.HeaderImage = Nothing
        GridColumnDescriptor20.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor20.HeaderText = "Deuda ME"
        GridColumnDescriptor20.MappingName = "deudaME"
        GridColumnDescriptor20.ReadOnly = True
        GridColumnDescriptor20.SerializedImageArray = ""
        GridColumnDescriptor20.Width = 70
        GridColumnDescriptor21.HeaderImage = Nothing
        GridColumnDescriptor21.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor21.HeaderText = "monto Cobrado ME"
        GridColumnDescriptor21.MappingName = "montoPagoME"
        GridColumnDescriptor21.ReadOnly = True
        GridColumnDescriptor21.SerializedImageArray = ""
        GridColumnDescriptor21.Width = 70
        GridColumnDescriptor22.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Red)
        GridColumnDescriptor22.HeaderImage = Nothing
        GridColumnDescriptor22.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor22.HeaderText = "Saldo ME"
        GridColumnDescriptor22.MappingName = "saldome"
        GridColumnDescriptor22.ReadOnly = True
        GridColumnDescriptor22.SerializedImageArray = ""
        GridColumnDescriptor22.Width = 70
        GridColumnDescriptor23.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gold)
        GridColumnDescriptor23.HeaderImage = Nothing
        GridColumnDescriptor23.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor23.HeaderText = "Monto Vencido ME"
        GridColumnDescriptor23.MappingName = "montoVencidoME"
        GridColumnDescriptor23.ReadOnly = True
        GridColumnDescriptor23.SerializedImageArray = ""
        GridColumnDescriptor23.Width = 70
        GridColumnDescriptor24.HeaderImage = Nothing
        GridColumnDescriptor24.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor24.MappingName = "montoProgME"
        GridColumnDescriptor24.ReadOnly = True
        GridColumnDescriptor24.SerializedImageArray = ""
        GridColumnDescriptor24.Width = 70
        Me.dgvProcesoCrono.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17, GridColumnDescriptor18, GridColumnDescriptor19, GridColumnDescriptor20, GridColumnDescriptor21, GridColumnDescriptor22, GridColumnDescriptor23, GridColumnDescriptor24})
        Me.dgvProcesoCrono.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "DEUDA MN", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("deuda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("saldo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoProg"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoVencido")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 2", "DEUDA ME", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("deudaME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoPagoME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("saldome"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoProgME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("montoVencidoME")})}))
        Me.dgvProcesoCrono.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvProcesoCrono.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvProcesoCrono.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvProcesoCrono.Text = "GridGroupingControl3"
        Me.dgvProcesoCrono.VersionInfo = "12.4400.0.24"
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.Goldenrod
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(163, 33)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(283, 12)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(163, 33)
        Me.ButtonAdv2.TabIndex = 530
        Me.ButtonAdv2.Text = "Otras Acreencias"
        Me.ButtonAdv2.UseVisualStyle = True
        Me.ButtonAdv2.UseVisualStyleBackColor = False
        '
        'frmEstadoCobrosGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.SeaGreen
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(910, 599)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmEstadoCobrosGeneral"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvProcesoCrono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv7 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvProcesoCrono As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
End Class
