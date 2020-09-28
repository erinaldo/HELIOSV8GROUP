Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCanastaCompras
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCanastaCompras))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ChFiltro2 = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnNuevoProd = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GridItems = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel2.SuspendLayout()
        CType(Me.btnNuevoProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel2.Controls.Add(Me.ChFiltro2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.btnNuevoProd)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtFiltrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(899, 62)
        Me.Panel2.TabIndex = 118
        '
        'ChFiltro2
        '
        Me.ChFiltro2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChFiltro2.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChFiltro2.Checked = True
        Me.ChFiltro2.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChFiltro2.ForeColor = System.Drawing.Color.White
        Me.ChFiltro2.Location = New System.Drawing.Point(313, 35)
        Me.ChFiltro2.Name = "ChFiltro2"
        Me.ChFiltro2.Size = New System.Drawing.Size(20, 20)
        Me.ChFiltro2.TabIndex = 519
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(336, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 14)
        Me.Label7.TabIndex = 518
        Me.Label7.Text = "Por Coincidencia"
        '
        'btnNuevoProd
        '
        Me.btnNuevoProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevoProd.Image = CType(resources.GetObject("btnNuevoProd.Image"), System.Drawing.Image)
        Me.btnNuevoProd.Location = New System.Drawing.Point(429, 27)
        Me.btnNuevoProd.Name = "btnNuevoProd"
        Me.btnNuevoProd.Size = New System.Drawing.Size(25, 25)
        Me.btnNuevoProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnNuevoProd.TabIndex = 408
        Me.btnNuevoProd.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 14)
        Me.Label1.TabIndex = 407
        Me.Label1.Text = "Buscar producto - (double clic en la tabla para agregar)"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(297, 22)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFiltrar.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtFiltrar.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.Location = New System.Drawing.Point(12, 33)
        Me.txtFiltrar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(297, 22)
        Me.txtFiltrar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFiltrar.TabIndex = 400
        '
        'GridItems
        '
        Me.GridItems.BackColor = System.Drawing.Color.LavenderBlush
        Me.GridItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridItems.FreezeCaption = False
        Me.GridItems.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridItems.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.GridItems.Location = New System.Drawing.Point(0, 62)
        Me.GridItems.Name = "GridItems"
        Me.GridItems.Size = New System.Drawing.Size(899, 353)
        Me.GridItems.TabIndex = 408
        Me.GridItems.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Gr."
        GridColumnDescriptor1.MappingName = "destino"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 40
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "id"
        GridColumnDescriptor2.MappingName = "idItem"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 0
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(239, Byte), Integer)))
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Producto"
        GridColumnDescriptor3.MappingName = "descripcion"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 350
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(214, Byte), Integer)))
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(18, Byte), Integer))
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "U.M."
        GridColumnDescriptor4.MappingName = "unidad"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Tipo Existencia"
        GridColumnDescriptor5.MappingName = "tipoExistencia"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 85
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Marca"
        GridColumnDescriptor6.MappingName = "marca"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 90
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "ultimaEntrada"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 170
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "precio"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 80
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "contenido"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 70
        Me.GridItems.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.GridItems.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridItems.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridItems.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("destino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("contenido"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("marca"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoExistencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ultimaEntrada"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precio")})
        Me.GridItems.Text = "gridGroupingControl1"
        Me.GridItems.TopLevelGroupOptions.ShowCaption = False
        Me.GridItems.VersionInfo = "12.2400.0.20"
        '
        'FormCanastaCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(60, 20)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Canasta de existencias"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(899, 415)
        Me.Controls.Add(Me.GridItems)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCanastaCompras"
        Me.ShowIcon = False
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.btnNuevoProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFiltrar As Tools.TextBoxExt
    Friend WithEvents GridItems As Grid.Grouping.GridGroupingControl
    Friend WithEvents btnNuevoProd As PictureBox
    Friend WithEvents ChFiltro2 As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label7 As Label
End Class
