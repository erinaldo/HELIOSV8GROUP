<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmHistorialCosteo
    Inherits frmMaster

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
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnReconocimiento = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lblidEntregable = New System.Windows.Forms.Label()
        Me.txtEntregable = New System.Windows.Forms.Label()
        Me.txtSubProyecto = New System.Windows.Forms.Label()
        Me.txtProyectoGeneral = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvHistorial = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnReconocimiento)
        Me.Panel1.Controls.Add(Me.lblidEntregable)
        Me.Panel1.Controls.Add(Me.txtEntregable)
        Me.Panel1.Controls.Add(Me.txtSubProyecto)
        Me.Panel1.Controls.Add(Me.txtProyectoGeneral)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(854, 152)
        Me.Panel1.TabIndex = 0
        '
        'btnReconocimiento
        '
        Me.btnReconocimiento.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnReconocimiento.BackColor = System.Drawing.Color.Olive
        Me.btnReconocimiento.BeforeTouchSize = New System.Drawing.Size(141, 37)
        Me.btnReconocimiento.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReconocimiento.ForeColor = System.Drawing.Color.White
        Me.btnReconocimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReconocimiento.IsBackStageButton = False
        Me.btnReconocimiento.Location = New System.Drawing.Point(22, 89)
        Me.btnReconocimiento.Name = "btnReconocimiento"
        Me.btnReconocimiento.Size = New System.Drawing.Size(141, 37)
        Me.btnReconocimiento.TabIndex = 561
        Me.btnReconocimiento.Text = "Generar Reconocimiento del Ingreso"
        Me.btnReconocimiento.UseVisualStyle = True
        '
        'lblidEntregable
        '
        Me.lblidEntregable.AutoSize = True
        Me.lblidEntregable.Location = New System.Drawing.Point(537, 57)
        Me.lblidEntregable.Name = "lblidEntregable"
        Me.lblidEntregable.Size = New System.Drawing.Size(40, 13)
        Me.lblidEntregable.TabIndex = 560
        Me.lblidEntregable.Text = "Label6"
        Me.lblidEntregable.Visible = False
        '
        'txtEntregable
        '
        Me.txtEntregable.AutoSize = True
        Me.txtEntregable.Location = New System.Drawing.Point(652, 26)
        Me.txtEntregable.Name = "txtEntregable"
        Me.txtEntregable.Size = New System.Drawing.Size(40, 13)
        Me.txtEntregable.TabIndex = 559
        Me.txtEntregable.Text = "Label6"
        '
        'txtSubProyecto
        '
        Me.txtSubProyecto.AutoSize = True
        Me.txtSubProyecto.Location = New System.Drawing.Point(331, 27)
        Me.txtSubProyecto.Name = "txtSubProyecto"
        Me.txtSubProyecto.Size = New System.Drawing.Size(40, 13)
        Me.txtSubProyecto.TabIndex = 558
        Me.txtSubProyecto.Text = "Label6"
        '
        'txtProyectoGeneral
        '
        Me.txtProyectoGeneral.AutoSize = True
        Me.txtProyectoGeneral.Location = New System.Drawing.Point(19, 27)
        Me.txtProyectoGeneral.Name = "txtProyectoGeneral"
        Me.txtProyectoGeneral.Size = New System.Drawing.Size(40, 13)
        Me.txtProyectoGeneral.TabIndex = 557
        Me.txtProyectoGeneral.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 554
        Me.Label5.Text = "Proyecto General"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(328, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 555
        Me.Label3.Text = "Sub proyecto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(643, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 14)
        Me.Label4.TabIndex = 556
        Me.Label4.Text = "Entregable / producto terminado"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvHistorial)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 152)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(854, 155)
        Me.Panel2.TabIndex = 1
        '
        'dgvHistorial
        '
        Me.dgvHistorial.BackColor = System.Drawing.SystemColors.Window
        Me.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistorial.FreezeCaption = False
        Me.dgvHistorial.Location = New System.Drawing.Point(0, 0)
        Me.dgvHistorial.Name = "dgvHistorial"
        Me.dgvHistorial.Size = New System.Drawing.Size(854, 155)
        Me.dgvHistorial.TabIndex = 557
        Me.dgvHistorial.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "fecha"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "tipoDoc"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "nroDoc"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "importe"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "tipoCliente"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "idCliente"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Tiene Reconocimiento"
        GridColumnDescriptor8.MappingName = "reconocimiento"
        GridColumnDescriptor8.SerializedImageArray = ""
        Me.dgvHistorial.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor1.DataMember = "cantidad"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "cantidad"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor2.DataMember = "importeplan"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "importeplan"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor3.DataMember = "cantidadReal"
        GridSummaryColumnDescriptor3.Format = "{Sum}"
        GridSummaryColumnDescriptor3.Name = "cantidadReal"
        GridSummaryColumnDescriptor3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor4.DataMember = "importereal"
        GridSummaryColumnDescriptor4.Format = "{Sum}"
        GridSummaryColumnDescriptor4.Name = "importereal"
        GridSummaryColumnDescriptor4.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1, GridSummaryColumnDescriptor2, GridSummaryColumnDescriptor3, GridSummaryColumnDescriptor4})
        Me.dgvHistorial.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvHistorial.TableOptions.AllowDragColumns = False
        Me.dgvHistorial.TableOptions.AllowDropDownCell = False
        Me.dgvHistorial.TableOptions.AllowMultiColumnSort = False
        Me.dgvHistorial.TableOptions.AllowSortColumns = False
        Me.dgvHistorial.Text = "GridGroupingControl1"
        Me.dgvHistorial.VersionInfo = "12.4400.0.24"
        '
        'fmHistorialCosteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.ForestGreen
        Me.CaptionBarColor = System.Drawing.Color.ForestGreen
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(854, 307)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fmHistorialCosteo"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvHistorial As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents lblidEntregable As System.Windows.Forms.Label
    Friend WithEvents txtEntregable As System.Windows.Forms.Label
    Friend WithEvents txtSubProyecto As System.Windows.Forms.Label
    Friend WithEvents txtProyectoGeneral As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnReconocimiento As Syncfusion.Windows.Forms.ButtonAdv
End Class
