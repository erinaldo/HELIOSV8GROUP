<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActaConstitucion
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActaConstitucion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPropuesta = New System.Windows.Forms.TextBox()
        Me.txtDirector = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.dgvImportar = New System.Windows.Forms.DataGridView()
        Me.colIdEx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLabor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCAnhm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPorcInfoTec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostoUntHM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostoUni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostoDirecto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostoDirecto2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGGPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGGImp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUtiPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUTImp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostoFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIgvPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImporIgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtrosAportes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanillaAporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtrosDeduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanillaDeduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrecFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantFinalCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPUFina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSustento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clasificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoRecursoExist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblRows = New System.Windows.Forms.ToolStripLabel()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.dgvGastos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colssss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtrasDeducss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDedcPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalDeduc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetoPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtrosAportes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAportePaln = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalAoporet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalretenApo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTasaIgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNoSustentado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIgvMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPstoRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClasificacionGastos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoRecursosGasto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblRowsGasto = New System.Windows.Forms.ToolStripLabel()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvEDT = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroEntregable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dniResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppatResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApMatResponsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEntregable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiasAtraso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblRowEDT = New System.Windows.Forms.ToolStripLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        CType(Me.dgvImportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.dgvGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvEDT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Proyecto Preliminar:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Director:"
        '
        'txtPropuesta
        '
        Me.txtPropuesta.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtPropuesta.Location = New System.Drawing.Point(12, 73)
        Me.txtPropuesta.Name = "txtPropuesta"
        Me.txtPropuesta.ReadOnly = True
        Me.txtPropuesta.Size = New System.Drawing.Size(357, 21)
        Me.txtPropuesta.TabIndex = 50
        '
        'txtDirector
        '
        Me.txtDirector.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtDirector.Location = New System.Drawing.Point(12, 113)
        Me.txtDirector.Name = "txtDirector"
        Me.txtDirector.ReadOnly = True
        Me.txtDirector.Size = New System.Drawing.Size(357, 21)
        Me.txtDirector.TabIndex = 51
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 149)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 344)
        Me.Panel1.TabIndex = 52
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(727, 344)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(719, 318)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cotización de la Propuesta"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(3, 3)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(713, 312)
        Me.TabControl2.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.dgvImportar)
        Me.TabPage7.Controls.Add(Me.ToolStrip3)
        Me.TabPage7.Location = New System.Drawing.Point(24, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(685, 304)
        Me.TabPage7.TabIndex = 1
        Me.TabPage7.Text = "Importar Datos"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'dgvImportar
        '
        Me.dgvImportar.AllowUserToAddRows = False
        Me.dgvImportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIdEx, Me.colDesc, Me.colDetalle, Me.colUM, Me.colLabor, Me.colCAnhm, Me.colPorcInfoTec, Me.colDias, Me.colCostoUntHM, Me.colCan, Me.colCostoUni, Me.colCostoDirecto1, Me.colCostoDirecto2, Me.colGGPorc, Me.colGGImp, Me.colUtiPorc, Me.colUTImp, Me.colCostoFinal, Me.colIgvPorc, Me.colImporIgv, Me.OtrosAportes, Me.PlanillaAporte, Me.OtrosDeduccion, Me.PlanillaDeduccion, Me.colPrecFinal, Me.CantFinalCol, Me.colPUFina, Me.colSustento, Me.Clasificacion, Me.TipoRecursoExist})
        Me.dgvImportar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvImportar.Location = New System.Drawing.Point(3, 28)
        Me.dgvImportar.Name = "dgvImportar"
        Me.dgvImportar.RowHeadersVisible = False
        Me.dgvImportar.Size = New System.Drawing.Size(679, 273)
        Me.dgvImportar.TabIndex = 480
        '
        'colIdEx
        '
        Me.colIdEx.HeaderText = "IdItem"
        Me.colIdEx.Name = "colIdEx"
        Me.colIdEx.ReadOnly = True
        Me.colIdEx.Width = 20
        '
        'colDesc
        '
        Me.colDesc.HeaderText = "Descripción"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.Width = 200
        '
        'colDetalle
        '
        Me.colDetalle.HeaderText = "Detalle extra"
        Me.colDetalle.Name = "colDetalle"
        Me.colDetalle.Width = 150
        '
        'colUM
        '
        Me.colUM.HeaderText = "U.M."
        Me.colUM.Name = "colUM"
        Me.colUM.Width = 50
        '
        'colLabor
        '
        Me.colLabor.HeaderText = "Labor diaria"
        Me.colLabor.Name = "colLabor"
        Me.colLabor.Width = 60
        '
        'colCAnhm
        '
        Me.colCAnhm.HeaderText = "Cant: HM"
        Me.colCAnhm.Name = "colCAnhm"
        Me.colCAnhm.Width = 60
        '
        'colPorcInfoTec
        '
        Me.colPorcInfoTec.HeaderText = "%"
        Me.colPorcInfoTec.Name = "colPorcInfoTec"
        Me.colPorcInfoTec.Width = 60
        '
        'colDias
        '
        Me.colDias.HeaderText = "días"
        Me.colDias.Name = "colDias"
        Me.colDias.Width = 60
        '
        'colCostoUntHM
        '
        Me.colCostoUntHM.HeaderText = "Costo Unit: HM"
        Me.colCostoUntHM.Name = "colCostoUntHM"
        Me.colCostoUntHM.Width = 65
        '
        'colCan
        '
        Me.colCan.HeaderText = "Cant."
        Me.colCan.Name = "colCan"
        Me.colCan.Width = 55
        '
        'colCostoUni
        '
        Me.colCostoUni.HeaderText = "Costo Unit."
        Me.colCostoUni.Name = "colCostoUni"
        Me.colCostoUni.Width = 60
        '
        'colCostoDirecto1
        '
        Me.colCostoDirecto1.HeaderText = "Costo Directo(1)"
        Me.colCostoDirecto1.Name = "colCostoDirecto1"
        Me.colCostoDirecto1.ReadOnly = True
        Me.colCostoDirecto1.Width = 65
        '
        'colCostoDirecto2
        '
        Me.colCostoDirecto2.HeaderText = "Costo Directo(2)"
        Me.colCostoDirecto2.Name = "colCostoDirecto2"
        Me.colCostoDirecto2.Width = 67
        '
        'colGGPorc
        '
        Me.colGGPorc.HeaderText = "G.G. %"
        Me.colGGPorc.Name = "colGGPorc"
        Me.colGGPorc.Width = 60
        '
        'colGGImp
        '
        Me.colGGImp.HeaderText = "G.G. Importe"
        Me.colGGImp.Name = "colGGImp"
        Me.colGGImp.Width = 60
        '
        'colUtiPorc
        '
        Me.colUtiPorc.HeaderText = "UT. %"
        Me.colUtiPorc.Name = "colUtiPorc"
        Me.colUtiPorc.Width = 60
        '
        'colUTImp
        '
        Me.colUTImp.HeaderText = "UT. Importe"
        Me.colUTImp.Name = "colUTImp"
        Me.colUTImp.Width = 60
        '
        'colCostoFinal
        '
        Me.colCostoFinal.HeaderText = "Costo final"
        Me.colCostoFinal.Name = "colCostoFinal"
        Me.colCostoFinal.Width = 65
        '
        'colIgvPorc
        '
        Me.colIgvPorc.HeaderText = "Igv %"
        Me.colIgvPorc.Name = "colIgvPorc"
        Me.colIgvPorc.Width = 60
        '
        'colImporIgv
        '
        Me.colImporIgv.HeaderText = "Igv imp."
        Me.colImporIgv.Name = "colImporIgv"
        Me.colImporIgv.Width = 60
        '
        'OtrosAportes
        '
        Me.OtrosAportes.HeaderText = "Otros Aportes"
        Me.OtrosAportes.Name = "OtrosAportes"
        '
        'PlanillaAporte
        '
        Me.PlanillaAporte.HeaderText = "Planilla Aporte"
        Me.PlanillaAporte.Name = "PlanillaAporte"
        '
        'OtrosDeduccion
        '
        Me.OtrosDeduccion.HeaderText = "Otros Deducción"
        Me.OtrosDeduccion.Name = "OtrosDeduccion"
        '
        'PlanillaDeduccion
        '
        Me.PlanillaDeduccion.HeaderText = "Planilla Deduccion"
        Me.PlanillaDeduccion.Name = "PlanillaDeduccion"
        '
        'colPrecFinal
        '
        Me.colPrecFinal.HeaderText = "Precio Final"
        Me.colPrecFinal.Name = "colPrecFinal"
        Me.colPrecFinal.Width = 65
        '
        'CantFinalCol
        '
        Me.CantFinalCol.HeaderText = "Cant."
        Me.CantFinalCol.Name = "CantFinalCol"
        Me.CantFinalCol.Width = 65
        '
        'colPUFina
        '
        Me.colPUFina.HeaderText = "P.U. Final"
        Me.colPUFina.Name = "colPUFina"
        Me.colPUFina.Width = 65
        '
        'colSustento
        '
        Me.colSustento.HeaderText = "Sustento"
        Me.colSustento.Name = "colSustento"
        '
        'Clasificacion
        '
        Me.Clasificacion.HeaderText = "Clasificacion"
        Me.Clasificacion.Name = "Clasificacion"
        Me.Clasificacion.Width = 150
        '
        'TipoRecursoExist
        '
        Me.TipoRecursoExist.HeaderText = "Tipo Recursos"
        Me.TipoRecursoExist.Name = "TipoRecursoExist"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.NuevoToolStripButton, Me.ToolStripSeparator4, Me.lblRows})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(679, 25)
        Me.ToolStrip3.TabIndex = 479
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripButton1.Text = "Importar..."
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'lblRows
        '
        Me.lblRows.ForeColor = System.Drawing.Color.Red
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(30, 22)
        Me.lblRows.Text = "Filas"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TabControl3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(719, 318)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Gastos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabControl3
        '
        Me.TabControl3.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl3.Controls.Add(Me.TabPage6)
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.Location = New System.Drawing.Point(3, 3)
        Me.TabControl3.Multiline = True
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(713, 312)
        Me.TabControl3.TabIndex = 1
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.dgvGastos)
        Me.TabPage6.Controls.Add(Me.ToolStrip4)
        Me.TabPage6.Location = New System.Drawing.Point(24, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(685, 304)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "Importar Datos"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'dgvGastos
        '
        Me.dgvGastos.AllowUserToAddRows = False
        Me.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGastos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.colssss, Me.colOtrasDeducss, Me.colDedcPlanilla, Me.colTotalDeduc, Me.colNetoPagar, Me.colOtrosAportes, Me.colAportePaln, Me.colTotalAoporet, Me.colTotalretenApo, Me.DataGridViewTextBoxColumn24, Me.colTasaIgv, Me.colCosto, Me.colNoSustentado, Me.colPorcentaje, Me.colIgvMonto, Me.colPstoRef, Me.colTotal, Me.ClasificacionGastos, Me.TipoRecursosGasto})
        Me.dgvGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGastos.Location = New System.Drawing.Point(3, 28)
        Me.dgvGastos.Name = "dgvGastos"
        Me.dgvGastos.RowHeadersVisible = False
        Me.dgvGastos.Size = New System.Drawing.Size(679, 273)
        Me.dgvGastos.TabIndex = 480
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdItem"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 20
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Detalle extra"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "U.M."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 50
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Width = 65
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "P.U."
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Width = 65
        '
        'colssss
        '
        Me.colssss.HeaderText = "Total"
        Me.colssss.Name = "colssss"
        Me.colssss.Width = 65
        '
        'colOtrasDeducss
        '
        Me.colOtrasDeducss.HeaderText = "OtrasDeduc"
        Me.colOtrasDeducss.Name = "colOtrasDeducss"
        Me.colOtrasDeducss.Width = 65
        '
        'colDedcPlanilla
        '
        Me.colDedcPlanilla.HeaderText = "Deduc Planilla"
        Me.colDedcPlanilla.Name = "colDedcPlanilla"
        Me.colDedcPlanilla.Width = 65
        '
        'colTotalDeduc
        '
        Me.colTotalDeduc.HeaderText = "TotalDeduc"
        Me.colTotalDeduc.Name = "colTotalDeduc"
        Me.colTotalDeduc.ReadOnly = True
        Me.colTotalDeduc.Width = 65
        '
        'colNetoPagar
        '
        Me.colNetoPagar.HeaderText = "NetoPagar"
        Me.colNetoPagar.Name = "colNetoPagar"
        Me.colNetoPagar.ReadOnly = True
        Me.colNetoPagar.Width = 65
        '
        'colOtrosAportes
        '
        Me.colOtrosAportes.HeaderText = "OtrosAportes"
        Me.colOtrosAportes.Name = "colOtrosAportes"
        Me.colOtrosAportes.ReadOnly = True
        Me.colOtrosAportes.Width = 65
        '
        'colAportePaln
        '
        Me.colAportePaln.HeaderText = "Aporte Planilla"
        Me.colAportePaln.Name = "colAportePaln"
        Me.colAportePaln.ReadOnly = True
        Me.colAportePaln.Width = 65
        '
        'colTotalAoporet
        '
        Me.colTotalAoporet.HeaderText = "Total aporte"
        Me.colTotalAoporet.Name = "colTotalAoporet"
        Me.colTotalAoporet.ReadOnly = True
        Me.colTotalAoporet.Width = 65
        '
        'colTotalretenApo
        '
        Me.colTotalretenApo.HeaderText = "Total RetenApor."
        Me.colTotalretenApo.Name = "colTotalretenApo"
        Me.colTotalretenApo.ReadOnly = True
        Me.colTotalretenApo.Width = 65
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "Sustento"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        '
        'colTasaIgv
        '
        Me.colTasaIgv.HeaderText = "I.G.V"
        Me.colTasaIgv.Name = "colTasaIgv"
        Me.colTasaIgv.ReadOnly = True
        Me.colTasaIgv.Width = 65
        '
        'colCosto
        '
        Me.colCosto.HeaderText = "Costo"
        Me.colCosto.Name = "colCosto"
        Me.colCosto.ReadOnly = True
        Me.colCosto.Width = 65
        '
        'colNoSustentado
        '
        Me.colNoSustentado.HeaderText = "No Sustentado"
        Me.colNoSustentado.Name = "colNoSustentado"
        Me.colNoSustentado.ReadOnly = True
        Me.colNoSustentado.Width = 65
        '
        'colPorcentaje
        '
        Me.colPorcentaje.HeaderText = "%"
        Me.colPorcentaje.Name = "colPorcentaje"
        Me.colPorcentaje.ReadOnly = True
        Me.colPorcentaje.Width = 65
        '
        'colIgvMonto
        '
        Me.colIgvMonto.HeaderText = "I.G.V."
        Me.colIgvMonto.Name = "colIgvMonto"
        Me.colIgvMonto.ReadOnly = True
        Me.colIgvMonto.Width = 65
        '
        'colPstoRef
        '
        Me.colPstoRef.HeaderText = "Psto Ref."
        Me.colPstoRef.Name = "colPstoRef"
        Me.colPstoRef.ReadOnly = True
        Me.colPstoRef.Width = 65
        '
        'colTotal
        '
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        Me.colTotal.Width = 65
        '
        'ClasificacionGastos
        '
        Me.ClasificacionGastos.HeaderText = "Clasificación"
        Me.ClasificacionGastos.Name = "ClasificacionGastos"
        '
        'TipoRecursosGasto
        '
        Me.TipoRecursosGasto.HeaderText = "Tipo Recursos"
        Me.TipoRecursosGasto.Name = "TipoRecursosGasto"
        Me.TipoRecursosGasto.Width = 150
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator3, Me.lblRowsGasto})
        Me.ToolStrip4.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(679, 25)
        Me.ToolStrip4.TabIndex = 479
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripButton3.Text = "Importar..."
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "&Nuevo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblRowsGasto
        '
        Me.lblRowsGasto.ForeColor = System.Drawing.Color.Red
        Me.lblRowsGasto.Name = "lblRowsGasto"
        Me.lblRowsGasto.Size = New System.Drawing.Size(30, 22)
        Me.lblRowsGasto.Text = "Filas"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvEDT)
        Me.TabPage5.Controls.Add(Me.ToolStrip5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(719, 318)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "E.D.T."
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvEDT
        '
        Me.dgvEDT.AllowUserToAddRows = False
        Me.dgvEDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEDT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.NroEntregable, Me.Concepto, Me.dniResponsable, Me.NomResponsable, Me.AppatResponsable, Me.ApMatResponsable, Me.FechaEntregable, Me.DiasAtraso, Me.Observaciones})
        Me.dgvEDT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEDT.Location = New System.Drawing.Point(3, 28)
        Me.dgvEDT.Name = "dgvEDT"
        Me.dgvEDT.RowHeadersVisible = False
        Me.dgvEDT.Size = New System.Drawing.Size(713, 287)
        Me.dgvEDT.TabIndex = 482
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "IdItem"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 20
        '
        'NroEntregable
        '
        Me.NroEntregable.HeaderText = "Nro."
        Me.NroEntregable.Name = "NroEntregable"
        Me.NroEntregable.Width = 30
        '
        'Concepto
        '
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.Width = 150
        '
        'dniResponsable
        '
        Me.dniResponsable.HeaderText = "DNI"
        Me.dniResponsable.Name = "dniResponsable"
        '
        'NomResponsable
        '
        Me.NomResponsable.HeaderText = "Nombre"
        Me.NomResponsable.Name = "NomResponsable"
        Me.NomResponsable.Width = 150
        '
        'AppatResponsable
        '
        Me.AppatResponsable.HeaderText = "Apellido Paterno"
        Me.AppatResponsable.Name = "AppatResponsable"
        '
        'ApMatResponsable
        '
        Me.ApMatResponsable.HeaderText = "Apellido Materno"
        Me.ApMatResponsable.Name = "ApMatResponsable"
        '
        'FechaEntregable
        '
        Me.FechaEntregable.HeaderText = "Fecha Entrega"
        Me.FechaEntregable.Name = "FechaEntregable"
        Me.FechaEntregable.Width = 80
        '
        'DiasAtraso
        '
        Me.DiasAtraso.HeaderText = "Dias Atraso"
        Me.DiasAtraso.Name = "DiasAtraso"
        Me.DiasAtraso.Width = 60
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 200
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator5, Me.lblRowEDT})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(713, 25)
        Me.ToolStrip5.TabIndex = 481
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripButton5.Text = "Importar..."
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "&Nuevo"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'lblRowEDT
        '
        Me.lblRowEDT.ForeColor = System.Drawing.Color.Red
        Me.lblRowEDT.Name = "lblRowEDT"
        Me.lblRowEDT.Size = New System.Drawing.Size(30, 22)
        Me.lblRowEDT.Text = "Filas"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(727, 25)
        Me.ToolStrip1.TabIndex = 47
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 22)
        Me.lblEstado.Text = "Estado"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.navBG
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.toolStripSeparator, Me.GuardarToolStripButton, Me.ToolStripButton2, Me.ToolStripSeparator1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(727, 25)
        Me.ToolStrip2.TabIndex = 46
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(261, 22)
        Me.lblTitulo.Text = "Acta de Constitución: Importar datos desde excel."
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'frmActaConstitucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(727, 493)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtDirector)
        Me.Controls.Add(Me.txtPropuesta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmActaConstitucion"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        CType(Me.dgvImportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.dgvGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dgvEDT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPropuesta As System.Windows.Forms.TextBox
    Friend WithEvents txtDirector As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents dgvImportar As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblRows As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents dgvGastos As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblRowsGasto As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents dgvEDT As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblRowEDT As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroEntregable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dniResponsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomResponsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AppatResponsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApMatResponsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEntregable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiasAtraso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colssss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtrasDeducss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDedcPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalDeduc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNetoPagar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtrosAportes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAportePaln As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalAoporet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalretenApo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTasaIgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNoSustentado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPorcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIgvMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPstoRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClasificacionGastos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoRecursosGasto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdEx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLabor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCAnhm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPorcInfoTec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoUntHM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoUni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoDirecto1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoDirecto2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGGPorc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGGImp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUtiPorc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUTImp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoFinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIgvPorc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporIgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtrosAportes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanillaAporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtrosDeduccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanillaDeduccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecFinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantFinalCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPUFina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSustento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clasificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoRecursoExist As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
