Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDsctoAmarresModal
    Inherits MetroForm

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDsctoAmarresModal))
        Me.GridBeneficioImporte = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuThinButton22 = New Bunifu.Framework.UI.BunifuThinButton2()
        CType(Me.GridBeneficioImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridBeneficioImporte
        '
        Me.GridBeneficioImporte.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridBeneficioImporte.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridBeneficioImporte.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridBeneficioImporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.GridBeneficioImporte.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridBeneficioImporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridBeneficioImporte.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBeneficioImporte.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridBeneficioImporte.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.GridBeneficioImporte.Location = New System.Drawing.Point(0, 0)
        Me.GridBeneficioImporte.Name = "GridBeneficioImporte"
        Me.GridBeneficioImporte.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridBeneficioImporte.Size = New System.Drawing.Size(561, 392)
        Me.GridBeneficioImporte.TabIndex = 519
        Me.GridBeneficioImporte.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "iditem"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 20
        GridColumnDescriptor2.MappingName = "producto"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 324
        GridColumnDescriptor3.MappingName = "cantidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 70
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor4.MappingName = "btSeleccionar"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 81
        Me.GridBeneficioImporte.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
        Me.GridBeneficioImporte.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridBeneficioImporte.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridBeneficioImporte.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridBeneficioImporte.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("iditem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("btSeleccionar")})
        Me.GridBeneficioImporte.Text = "gridGroupingControl1"
        Me.GridBeneficioImporte.UseRightToLeftCompatibleTextBox = True
        Me.GridBeneficioImporte.VersionInfo = "12.2400.0.20"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BunifuThinButton22)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(561, 58)
        Me.Panel1.TabIndex = 520
        '
        'BunifuThinButton22
        '
        Me.BunifuThinButton22.ActiveBorderThickness = 1
        Me.BunifuThinButton22.ActiveCornerRadius = 20
        Me.BunifuThinButton22.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BunifuThinButton22.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton22.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BunifuThinButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.BunifuThinButton22.BackgroundImage = CType(resources.GetObject("BunifuThinButton22.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton22.ButtonText = "ACEPTAR"
        Me.BunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton22.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton22.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleBorderThickness = 1
        Me.BunifuThinButton22.IdleCornerRadius = 20
        Me.BunifuThinButton22.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BunifuThinButton22.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.BunifuThinButton22.Location = New System.Drawing.Point(210, 8)
        Me.BunifuThinButton22.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton22.Name = "BunifuThinButton22"
        Me.BunifuThinButton22.Size = New System.Drawing.Size(130, 42)
        Me.BunifuThinButton22.TabIndex = 711
        Me.BunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormDsctoAmarresModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.Yellow
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.CaptionFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(561, 450)
        Me.Controls.Add(Me.GridBeneficioImporte)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormDsctoAmarresModal"
        Me.ShowIcon = False
        Me.Text = "Dscto x amarres"
        CType(Me.GridBeneficioImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents GridBeneficioImporte As Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuThinButton22 As Bunifu.Framework.UI.BunifuThinButton2
End Class
