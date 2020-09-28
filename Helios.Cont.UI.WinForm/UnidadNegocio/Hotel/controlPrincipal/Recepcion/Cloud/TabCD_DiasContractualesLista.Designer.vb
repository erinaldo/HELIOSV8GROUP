Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabCD_DiasContractualesLista
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabCD_DiasContractualesLista))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Line25 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvCompras = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1055, 590)
        Me.GradientPanel2.TabIndex = 411
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.dgvCompras)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1055, 546)
        Me.Panel1.TabIndex = 413
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Frank Ruhl Hofshi", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(13, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(273, 26)
        Me.Label5.TabIndex = 776
        Me.Label5.Text = "INFORMACION  DE ESTADIA"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel3.Controls.Add(Me.Line25)
        Me.GradientPanel3.Controls.Add(Me.Label10)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(1055, 44)
        Me.GradientPanel3.TabIndex = 415
        '
        'Line25
        '
        Me.Line25.BackColor = System.Drawing.Color.White
        Me.Line25.LineColor = System.Drawing.Color.DodgerBlue
        Me.Line25.Location = New System.Drawing.Point(938, 35)
        Me.Line25.Name = "Line25"
        Me.Line25.Size = New System.Drawing.Size(110, 3)
        Me.Line25.TabIndex = 777
        Me.Line25.Text = "Line25"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(942, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 23)
        Me.Label10.TabIndex = 776
        Me.Label10.Text = "Retornar"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvCompras
        '
        Me.dgvCompras.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCompras.FreezeCaption = False
        Me.dgvCompras.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompras.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCompras.Location = New System.Drawing.Point(18, 55)
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.Size = New System.Drawing.Size(1014, 452)
        Me.dgvCompras.TabIndex = 777
        Me.dgvCompras.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "N°"
        GridColumnDescriptor1.MappingName = "numero"
        GridColumnDescriptor1.Name = "numero"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 50
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "TIPO"
        GridColumnDescriptor2.MappingName = "tipo"
        GridColumnDescriptor2.Name = "tipo"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "HABITACION"
        GridColumnDescriptor3.MappingName = "habitacion"
        GridColumnDescriptor3.Name = "habitacion"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 250
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "FECHA DEL"
        GridColumnDescriptor4.MappingName = "fechaIngreso"
        GridColumnDescriptor4.Name = "fechaIngreso"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 200
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "FECHA HASTA"
        GridColumnDescriptor5.MappingName = "fechaSalida"
        GridColumnDescriptor5.Name = "fechaSalida"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 200
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "DIAS CONTRACTUAL"
        GridColumnDescriptor6.MappingName = "dias"
        GridColumnDescriptor6.Name = "dias"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 150
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "ESTADO"
        GridColumnDescriptor7.MappingName = "estado"
        GridColumnDescriptor7.Name = "estado"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 0
        Me.dgvCompras.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.dgvCompras.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.dgvCompras.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompras.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCompras.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("habitacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaIngreso"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaSalida"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("dias"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.dgvCompras.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvCompras.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvCompras.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvCompras.Text = "gridGroupingControl1"
        Me.dgvCompras.VersionInfo = "12.2400.0.20"
        '
        'TabCD_DiasContractualesLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "TabCD_DiasContractualesLista"
        Me.Size = New System.Drawing.Size(1055, 590)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Line25 As Line2
    Friend WithEvents Label10 As Label
    Private WithEvents dgvCompras As Grid.Grouping.GridGroupingControl
End Class
