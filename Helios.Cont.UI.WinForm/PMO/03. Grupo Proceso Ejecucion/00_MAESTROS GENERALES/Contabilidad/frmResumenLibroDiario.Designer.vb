<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResumenLibroDiario
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.dgvPersonal = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPersonal
        '
        Me.dgvPersonal.BackColor = System.Drawing.SystemColors.Window
        Me.dgvPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPersonal.FreezeCaption = False
        Me.dgvPersonal.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvPersonal.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvPersonal.Location = New System.Drawing.Point(0, 0)
        Me.dgvPersonal.Name = "dgvPersonal"
        Me.dgvPersonal.Size = New System.Drawing.Size(1037, 476)
        Me.dgvPersonal.TabIndex = 1
        Me.dgvPersonal.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "idAsiento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 27
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "periodo"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 58
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "T-A"
        GridColumnDescriptor3.MappingName = "tipoAsiento"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 39
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Cuenta"
        GridColumnDescriptor4.MappingName = "cuentaCont"
        GridColumnDescriptor4.Name = "cuentaCont"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 55
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Operación"
        GridColumnDescriptor5.MappingName = "tipoOperacion"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "moneda"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "idEntidad"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Entidad"
        GridColumnDescriptor8.MappingName = "nombreEntidad"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 128
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Nro. doc."
        GridColumnDescriptor9.MappingName = "NroDocEntidad"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 93
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Tipo Doc."
        GridColumnDescriptor10.MappingName = "tipoDocumento"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 62
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Nro. Doc."
        GridColumnDescriptor11.MappingName = "nroDoc"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 135
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Fec. Proceso"
        GridColumnDescriptor12.MappingName = "fechaProceso"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 86
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.MappingName = "glosa"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 144
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "Cod. Libro"
        GridColumnDescriptor14.MappingName = "codigoLibro"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 61
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.MappingName = "tipo"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.MappingName = "importeMN"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.SerializedImageArray = ""
        GridColumnDescriptor17.HeaderImage = Nothing
        GridColumnDescriptor17.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor17.MappingName = "importeME"
        GridColumnDescriptor17.ReadOnly = True
        GridColumnDescriptor17.SerializedImageArray = ""
        Me.dgvPersonal.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17})
        Me.dgvPersonal.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvPersonal.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvPersonal.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idAsiento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("periodo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoAsiento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuentaCont"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoOperacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombreEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NroDocEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaProceso"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("glosa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigoLibro"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeME")})
        Me.dgvPersonal.Text = "GridGroupingControl1"
        Me.dgvPersonal.VersionInfo = "12.4400.0.24"
        '
        'frmResumenLibroDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(1037, 476)
        Me.Controls.Add(Me.dgvPersonal)
        Me.Name = "frmResumenLibroDiario"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvPersonal As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class
