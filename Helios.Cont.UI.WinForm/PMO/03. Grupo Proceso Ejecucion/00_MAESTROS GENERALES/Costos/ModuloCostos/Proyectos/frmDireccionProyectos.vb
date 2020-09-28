Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing

Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Public Class frmDireccionProyectos
    Inherits frmMaster

    Public Property IdSesionProyecto() As Integer

    Public Sub New(idProyecto As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        IdSesionProyecto = idProyecto
        'ConfigPlan()
        'GridCFGDetetail(dgvPlaneamiento)
        GridCFGDetetail(dgvCronograma)
        GridCFG(dgvEstimacionRec)
        GridCFGDetetail(grdRecursos)
        GridCFG(dgvConsultaPlan)
        GridCFGDetetail(dgvRQ)

        GridCFG(dgvRecursosAsignados)
        GridCFG(dgvDO)
        GridCFG(dgvProgess)
        GridCFG(dgvKanaFin)
        GridCFGDetetail(dgvEntregables)

        UbicarInformacionGeneral()
        CMBEstatus2()
        GetAvanceCostosProyectos()
    End Sub

#Region "Costos Ejecutados"
    Dim card As New GridCardView()
    Private Sub Settings()
        card.ShowCardCellBorders = True
        card.ApplyRoundedCorner = False
        card.BrowseOnly = True
        card.ShowCaption = True
        AutoFit()
    End Sub

    Private Sub AutoFit()
        Me.GDBSource.Model.ColWidths.ResizeToFit(GridRangeInfo.Table())
        Me.GDBSource.Refresh()
    End Sub

    Public Sub GetRecursosAsignadosXCosto(be As recursoCosto)
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)
        recurso = recursoSA.GetListadoRecursosByPadre(be)
        dgvRecursosAsignados.DataSource = recurso 'recursoSA.GetListadoRecursosByIdCosto(be)

        'lblTotalCosto.Text = CDec(recurso.Sum(Function(o) o.montoMN)).ToString("N2")

    End Sub

    Private Sub ComprobanteInfo(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarDocumentoCompra(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "COMPRA"
            dr(1) = .fechaDoc
            dr(2) = .tipoDoc
            dr(3) = .serie & "-" & .numeroDoc
            dr(4) = "-" ' entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto

            If .monedaDoc = "1" Then
                dr(5) = "NAC"
            ElseIf .monedaDoc = "2" Then
                dr(5) = "EXT"
            End If

            dr(6) = .tcDolLoc
            dr(7) = .importeTotal
            dr(8) = 0
            'dr(9) = IIf(.destino = "IC", "Incremento capital", "Saldo de inicio")
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

    Private Sub ComprobanteInfoLibroDiario(intIdDocumento As Integer)
        Dim compraSA As New documentoLibroDiarioSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarDocumentoLibroDiario(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "LIBRO DIARIO"
            dr(1) = .fecha
            dr(2) = .tipoDoc
            dr(3) = .serie & "/" & .nroDoc
            dr(4) = String.Empty ' entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto

            If .moneda = "1" Then
                dr(5) = "NAC"
            ElseIf .moneda = "2" Then
                dr(5) = "EXT"
            End If

            dr(6) = .tipoCambio
            dr(7) = .importeMN
            dr(8) = 0
            'dr(9) = IIf(.destino = "IC", "Incremento capital", "Saldo de inicio")
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

    Private Sub ComprobanteInfoFinanzas(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCajaSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.GetUbicar_documentoCajaPorID(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "CAJA"
            dr(1) = .fechaProceso
            dr(2) = .tipoDocPago
            dr(3) = .numeroDoc
            dr(4) = String.Empty ' entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto

            If .moneda = "1" Then
                dr(5) = "NAC"
            ElseIf .moneda = "2" Then
                dr(5) = "EXT"
            End If

            dr(6) = .tipoCambio
            dr(7) = .montoSoles
            dr(8) = 0
            'dr(9) = IIf(.destino = "IC", "Incremento capital", "Saldo de inicio")
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub
#End Region

#Region "Chart"
    'Protected Sub InitializeChartData()
    '    Dim fec As New Date
    '    Dim costoSA As New recursoCostoSA
    '    Dim listaActividades As New List(Of recursoCosto)
    '    fec = CDate(txtInicio.Text)

    '    Dim Completion As New ChartSeries("Completion", ChartSeriesType.Gantt)

    '    'Dim dt As New DateTime(2009, 1, 1)
    '    listaActividades = New List(Of recursoCosto)
    '    listaActividades = costoSA.GetPlaneamientoActividades(New recursoCosto With {.idCosto = IdSesionProyecto})
    '    For Each i In listaActividades
    '        Completion.Points.Add(i.IdActividad, i.inicio, i.finaliza)
    '    Next
    '    'Completion.Points.Add(0, dt, dt.AddDays(2))
    '    'Completion.Points.Add(1, dt.AddDays(1), dt.AddDays(2))
    '    'Completion.Points.Add(2, dt.AddDays(3), dt.AddDays(5))
    '    'Completion.Points.Add(3, dt.AddDays(6), dt.AddDays(9))
    '    'Completion.Points.Add(4, dt.AddDays(10), dt.AddDays(13))
    '    'Completion.Points.Add(5, dt.AddDays(15), dt.AddDays(18))

    '    Completion.Style.PointWidth = 0.5F

    '    Me.chartControl1.Series.Add(Completion)
    '    Completion.PointsToolTipFormat = "{1}{2}"

    '    Dim Task As New ChartSeries("Actividad", ChartSeriesType.Gantt)


    '    For Each i In listaActividades
    '        Task.Points.Add(i.IdActividad, i.inicio, i.finaliza)
    '    Next

    '    'Task.Points.Add(0, dt, dt.AddDays(2))
    '    'Task.Points.Add(1, dt.AddDays(1), dt.AddDays(3))
    '    'Task.Points.Add(2, dt.AddDays(3), dt.AddDays(6))
    '    'Task.Points.Add(3, dt.AddDays(6), dt.AddDays(10))
    '    'Task.Points.Add(4, dt.AddDays(10), dt.AddDays(15))
    '    'Task.Points.Add(5, dt.AddDays(15), dt.AddDays(20))

    '    ' Make a note of the last day:
    '    Dim fecUltima = listaActividades.Select(Function(o) o.finaliza).Max


    '    Dim lastDay As DateTime =fecUltima' DateTime.FromOADate(Task.Points(Task.Points.Count - 1).YValues(1))

    '    Task.Style.PointWidth = 0.7F
    '    Me.chartControl1.Series.Add(Task)
    '    Task.PointsToolTipFormat = "{1}{2}"

    '    Me.chartControl1.ShowToolTips = True
    '    Me.chartControl1.CalcRegions = True


    '    Me.chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.[Set]
    '    Me.chartControl1.PrimaryXAxis.DateTimeRange = New ChartDateTimeRange(fec, lastDay.AddDays(2), 1, ChartDateTimeIntervalType.Days)

    '    ' Displays custom into on Points
    '    For i As Integer = 0 To Me.chartControl1.Series(0).Points.Count - 1
    '        If Me.chartControl1.Series(1).Points(i).YValues(0) <> Me.chartControl1.Series(1).Points(i).YValues(1) Then
    '            Dim ccp As New ChartCustomPoint()

    '            Dim pt As ChartPoint = Me.chartControl1.Series(1).Points(i)
    '            ccp.XValue = pt.X
    '            ccp.YValue = pt.YValues(0) + 1
    '            ccp.CustomType = ChartCustomPointType.ChartCoordinates
    '            ccp.Text = [String].Format("{0} días", pt.YValues(1) - pt.YValues(0))
    '            ccp.Color = Color.White
    '            ccp.Font.Facename = "Segoe UI"
    '            Me.chartControl1.CustomPoints.Add(ccp)
    '        End If
    '    Next

    '    ' To indicate weekends
    '    Dim stripLineColor As Color() = New Color() {Color.LightGray, Color.WhiteSmoke, Color.LightGray}

    '    'Chart Strip Lines
    '    Dim stripLine1 As New ChartStripLine()
    '    stripLine1.Enabled = True
    '    stripLine1.Vertical = False
    '    stripLine1.StartDate = fec.AddDays(2)

    '    stripLine1.EndDate = lastDay
    '    stripLine1.Width = 2

    '    ' Repetition frequency: every 7 days
    '    stripLine1.PeriodDate = New TimeSpan(7, 0, 0, 0)
    '    stripLine1.Text = String.Empty
    '    stripLine1.Interior = New BrushInfo(GradientStyle.ForwardDiagonal, stripLineColor)
    '    Me.chartControl1.PrimaryXAxis.StripLines.Add(stripLine1)

    '    '   AddHandler Me.chartControl1.Series(0).PrepareStyle, AddressOf Form1_PrepareStyle
    '    AddHandler Me.chartControl1.Series(0).PrepareStyle, AddressOf Form1_PrepareStyle
    '    AddHandler Me.chartControl1.Series(1).PrepareStyle, AddressOf Form1_PrepareStyle
    '    'Me.chartControl1.Series(0).PrepareStyle += New ChartPrepareStyleInfoHandler(Form1_PrepareStyle)
    '    'Me.chartControl1.Series(1).PrepareStyle += New ChartPrepareStyleInfoHandler(Form1_PrepareStyle)
    'End Sub

    'Private Sub Form1_PrepareStyle(sender As Object, args As ChartPrepareStyleInfoEventArgs)
    '    Dim series As ChartSeries = TryCast(sender, ChartSeries)
    '    If series Is Nothing Then
    '        Return
    '    End If

    '    Dim taskPoint As ChartPoint = Me.chartControl1.Series(1).Points(args.Index)
    '    Dim completionPoint As ChartPoint = Me.chartControl1.Series(0).Points(args.Index)

    '    Dim completionStartDate As DateTime = DateTime.FromOADate(completionPoint.YValues(0))
    '    Dim completionEndDate As DateTime = DateTime.FromOADate(completionPoint.YValues(1))

    '    Dim taskStartDate As DateTime = DateTime.FromOADate(taskPoint.YValues(0))
    '    Dim taskEndDate As DateTime = DateTime.FromOADate(taskPoint.YValues(1))
    '    Dim percentCompleted As Double = (CDbl(completionEndDate.Day - completionStartDate.Day) / CDbl(taskEndDate.Day - taskStartDate.Day)) * 100
    '    Dim percentRemaining As Double = 100 - percentCompleted
    '    args.Style.ToolTip = "Fec. Inicio:" + taskStartDate.ToShortDateString() + vbLf & "Fec. Finaliza:" + taskEndDate.ToShortDateString() '+ vbLf & "Percent Completed:" + Math.Round(percentCompleted, 2) + "%" & vbLf & "Percent Remaining: " + Math.Round(percentRemaining, 2) + "%"

    '    args.Handled = True
    'End Sub

#End Region

#Region "Chart Presentacion"
    Protected Sub InitializeChartDataPie()
        'Dim random As New Random()
        Dim costoSA As New recursoCostoSA
        Dim listaActividades As New List(Of recursoCosto)
        Dim conteo As Integer = 0
        Dim series1 As New ChartSeries("Avance General")
        Dim DuracionTotal As Integer = 0
        Dim DuracionActual As Integer = 0
        Dim Avance As Decimal = 0

        listaActividades = New List(Of recursoCosto)
        listaActividades = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = IdSesionProyecto})

        For Each i In listaActividades
            DuracionTotal = (i.finaliza.Value.Date - i.inicio.Value.Date).TotalDays
            DuracionActual = (DateTime.Now.Date - i.inicio.Value.Date).TotalDays
            If DuracionActual < 0 Then
                DuracionActual = 0
            End If
            If DuracionActual > 0 Then
                Avance = (DuracionActual / DuracionTotal) * 100
            Else
                Avance = 0
            End If

            series1.Points.Add(conteo, Avance)
            series1.Styles(conteo).Text = String.Format(i.nombreCosto)
            conteo = conteo + 1
        Next


        'series1.Points.Add(0, 20)
        'series1.Points.Add(1, 28)
        'series1.Points.Add(2, 23)
        'series1.Points.Add(3, 10)
        'series1.Points.Add(4, 12)
        'series1.Points.Add(5, 3)
        'series1.Points.Add(6, 2)
        series1.Type = ChartSeriesType.Pie
        Me.ChartControl2.Series.Add(series1)
        series1.OptimizePiePointPositions = True ' Me.checkBox1.Checked

        For i As Integer = 0 To series1.Points.Count - 1
            series1.Styles(i).Border.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Next
        'series1.Styles(0).Text = String.Format("Production {0}%", series1.Points(0).YValues(0))
        'series1.Styles(1).Text = String.Format("Labor {0}%", series1.Points(1).YValues(0))
        'series1.Styles(2).Text = String.Format("Facilities {0}%", series1.Points(2).YValues(0))
        'series1.Styles(3).Text = String.Format("Taxes {0}%", series1.Points(3).YValues(0))
        'series1.Styles(4).Text = String.Format("Insurance{0}%", series1.Points(4).YValues(0))
        'series1.Styles(5).Text = String.Format("Licenses {0}%", series1.Points(5).YValues(0))
        'series1.Styles(6).Text = String.Format("Legal {0}%", series1.Points(6).YValues(0))
        series1.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.OutsideInColumn
        series1.Style.DisplayText = True
        series1.Style.Font.Size = 8.0F
        series1.ConfigItems.PieItem.AngleOffset = 60

    End Sub
#End Region

#Region "Métodos"
    Dim captionCoverCols As Integer = 0

    Sub UpdateCronograma(r As Record)
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto

        costo = New recursoCosto
        costo.idCosto = Val(r.GetValue("idActividad"))
        Dim ini = r.GetValue("Inicio")

        If IsDate(ini) Then
            costo.inicio = CDate(r.GetValue("Inicio"))
        Else
            costo.inicio = DateTime.Now
        End If

        Dim fina = r.GetValue("Finaliza")
        If IsDate(fina) Then
            costo.finaliza = CDate(r.GetValue("Finaliza"))
        Else
            costo.finaliza = DateTime.Now
        End If

        costoSA.GetUpdateCronograma(costo)
        dgvCronograma.Table.ExpandAllRecords()
    End Sub

    Sub UpdateFechaActual(r As Record)
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto

        costo = New recursoCosto
        costo.idCosto = Val(r.GetValue("idActividad"))
        Dim ini = r.GetValue("inicioActual")

        If IsDate(ini) Then
            costo.inicioActual = CDate(r.GetValue("inicioActual"))
        Else
            costo.inicioActual = DateTime.Now
        End If

        'Dim fina = r.GetValue("finActual")
        'If IsDate(fina) Then
        '    costo.finalizaActual = CDate(r.GetValue("finActual"))
        'Else
        '    costo.finalizaActual = DateTime.Now
        'End If

        costoSA.GetUpdatefechaActual(costo)
        dgvCronograma.Table.ExpandAllRecords()
    End Sub

    Sub CMBEstatus2()
        Dim tablaSA As New tablaDetalleSA

        '---------------------------------------------------------------------
        Dim dtTipo As New DataTable()
        dtTipo.Columns.Add("codigo", GetType(Integer))
        dtTipo.Columns.Add("descripcion")

        Dim drTipo As DataRow = dtTipo.NewRow
        drTipo(0) = CInt(TipoRecursoPlaneado.Inventario)
        drTipo(1) = "INVENTARIO"
        dtTipo.Rows.Add(drTipo)

        Dim drTipo2 As DataRow = dtTipo.NewRow
        drTipo2(0) = CInt(TipoRecursoPlaneado.ManoDeObra)
        drTipo2(1) = "MANO DE OBRA"
        dtTipo.Rows.Add(drTipo2)

        Dim drTipo3 As DataRow = dtTipo.NewRow
        drTipo3(0) = CInt(TipoRecursoPlaneado.ActivoInmovilizado)
        drTipo3(1) = "ACTIVO INMOVILIZADO"
        dtTipo.Rows.Add(drTipo3)

        Dim drTipo4 As DataRow = dtTipo.NewRow
        drTipo4(0) = CInt(TipoRecursoPlaneado.Terceros)
        drTipo4(1) = "TERCEROS"
        dtTipo.Rows.Add(drTipo4)
        '--------------------------------------------------------------------------


        Dim tabla As New List(Of tabladetalle)
        tabla = tablaSA.GetListaTablaDetalle(6, "1").OrderBy(Function(o) o.descripcion).ToList

        Dim ggcStyle22 As GridTableCellStyleInfo = dgvRQ.TableDescriptor.Columns("um").Appearance.AnyRecordFieldCell
        ggcStyle22.CellType = "ComboBox"
        ggcStyle22.DataSource = tabla
        ggcStyle22.ValueMember = "codigoDetalle"
        ggcStyle22.DisplayMember = "descripcion"
        ggcStyle22.DropDownStyle = GridDropDownStyle.Exclusive


        Dim ggcStyle33 As GridTableCellStyleInfo = dgvRQ.TableDescriptor.Columns("tipoRecurso").Appearance.AnyRecordFieldCell
        ggcStyle33.CellType = "ComboBox"
        ggcStyle33.DataSource = dtTipo
        ggcStyle33.ValueMember = "codigo"
        ggcStyle33.DisplayMember = "descripcion"
        ggcStyle33.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Sub GrabarRQ()
        Dim recursoSA As New recursoCostoDetalleSA
        Dim obj As New recursoCostoDetalle

        obj = New recursoCostoDetalle
        obj.fechaRegistro = DateTime.Now
        obj.idCosto = Val(IdSesionProyecto)
        obj.fechaRegistro = DateTime.Now
        Select Case cboTipoRQ.Text
            Case "INVENTARIO"
                obj.iditem = TipoRecursoPlaneado.Inventario
                obj.um = dgvConsultaPlan.Table.CurrentRecord.GetValue("um")
            Case "MANO DE OBRA"
                obj.iditem = TipoRecursoPlaneado.ManoDeObra
                obj.um = dgvConsultaPlan.Table.CurrentRecord.GetValue("um")
            Case "ACTIVOS INMOVILIZADOS"
                obj.iditem = TipoRecursoPlaneado.ActivoInmovilizado
                obj.um = dgvConsultaPlan.Table.CurrentRecord.GetValue("um")
            Case "TERCEROS"
                obj.iditem = TipoRecursoPlaneado.Terceros
                obj.um = dgvConsultaPlan.Table.CurrentRecord.GetValue("um")
        End Select

        obj.destino = "1"
        obj.descripcion = txtRecursoRequerimiento.Text

        obj.cant = 0
        obj.puMN = 0
        obj.puME = 0
        obj.montoMN = 0
        obj.montoME = 0
        obj.documentoRef = Nothing
        obj.itemRef = Nothing
        obj.operacion = Nothing
        obj.procesado = Nothing
        obj.idProceso = Val(dgvConsultaPlan.Table.CurrentRecord.GetValue("idedt"))
        obj.tipoCosto = "RQ"
        recursoSA.GrabarDetalleRecursosByTarea(obj)
        'GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
    End Sub

    Sub ConteoRecursos()
        Dim detSA As New recursoCostoDetalleSA
        lsvPlaneado.Items.Clear()

        For Each i In detSA.GetRecursoPlaneadoConteo(New recursoCosto With {.idCosto = Val(IdSesionProyecto), .procesado = "PL"})
            Dim n As New ListViewItem(i.descripcion)
            n.SubItems.Add(i.cant)
            lsvPlaneado.Items.Add(n)
        Next

        lsvEjecutado.Items.Clear()
        For Each i In detSA.GetRecursoPlaneadoConteo(New recursoCosto With {.idCosto = Val(IdSesionProyecto), .procesado = "RQ"})
            Dim n As New ListViewItem(i.descripcion)
            n.SubItems.Add(i.cant)
            lsvEjecutado.Items.Add(n)
        Next


    End Sub

    Public Sub GetRequerimientosByProyecto(be As recursoCosto)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("tipoRecurso")
        dt.Columns.Add("actividad")
        dt.Columns.Add("fecha")

        recurso = recursoSA.GetRecursosAsignadosByCosto(be)

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.um
            dr(3) = i.cant
            dr(4) = i.iditem
            dr(5) = i.idProceso
            dr(6) = i.fechaRegistro
            dt.Rows.Add(dr)
        Next

        dgvRQ.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub

    Public Sub GetRecursosAsignadosPlaneado(be As recursoCostoDetalle)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importetotal")
        dt.Columns.Add("pu")
        dt.Columns.Add("tipoRecurso")
        dt.Columns.Add("edt")
        dt.Columns.Add("idedt")

        recurso = recursoSA.GetRecursosAsignadosByTipoCosto(be)

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.um
            dr(3) = i.cant
            dr(4) = i.montoMN
            If i.cant > 0 Then
                dr(5) = Math.Round(CDec(i.montoMN) / CDec(i.cant), 2)
            Else
                dr(5) = 0
            End If
            dr(6) = i.iditem
            dr(7) = i.NomActividad & "-" & i.NombreProceso
            dr(8) = i.idActividad
            dt.Rows.Add(dr)
        Next

        dgvConsultaPlan.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub

    Sub GrabarRecurso()
        Dim recursoSA As New recursoCostoDetalleSA
        Dim obj As New recursoCostoDetalle

        obj = New recursoCostoDetalle
        obj.idCosto = dgvEstimacionRec.Table.CurrentRecord.GetValue("idActividad")
        obj.fechaRegistro = DateTime.Now

        Select Case cbotipoRecurso.Text
            Case "INVENTARIO"
                obj.iditem = TipoRecursoPlaneado.Inventario
                obj.um = "07"
            Case "MANO DE OBRA"
                obj.iditem = TipoRecursoPlaneado.ManoDeObra
                obj.um = "HH"
            Case "ACTIVOS INMOVILIZADOS"
                obj.iditem = TipoRecursoPlaneado.ActivoInmovilizado
                obj.um = "HM"
            Case "TERCEROS"
                obj.iditem = TipoRecursoPlaneado.Terceros
                obj.um = "07"
        End Select

        obj.destino = "1"
        obj.descripcion = txtCategoria.Text
        obj.cant = 0
        obj.puMN = 0
        obj.puME = 0
        obj.montoMN = 0
        obj.montoME = 0
        obj.documentoRef = Nothing
        obj.itemRef = Nothing
        obj.operacion = Nothing
        obj.procesado = Nothing
        obj.idProceso = Nothing
        obj.tipoCosto = "PL"
        recursoSA.GrabarDetalleRecursosByTarea(obj)
        GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
    End Sub

    'Sub ConfigPlan()
    '    Dim ordersDescriptor As GridTableDescriptor = Me.dgvPlaneamiento.TableDescriptor

    '    ' You can define a summary row and mark it hidden.
    '    ' In that summary row you can add a column and set it's mapping name (and DisplayColumn) to be Freight
    '    Dim summaryColumn1 As New GridSummaryColumnDescriptor("FreightAverage", SummaryType.DoubleAggregate, "costo", "{Sum:##,##00.00}")
    '    Dim summaryRow1 As New GridSummaryRowDescriptor()

    '    summaryRow1.Name = "Caption"
    '    summaryRow1.Visible = False
    '    summaryRow1.SummaryColumns.Add(summaryColumn1)
    '    ordersDescriptor.SummaryRows.Add(summaryRow1)

    '    ' This is a second row, not marked hidden and therefore shown at the end of the group.
    '    Dim summaryColumn2 As New GridSummaryColumnDescriptor("FreightTotal", SummaryType.DoubleAggregate, "costo", "{Sum:##,##00.00}")
    '    Dim summaryRow2 As New GridSummaryRowDescriptor()
    '    summaryRow2.Name = "Costo Proyecto"
    '    summaryRow2.Visible = True
    '    summaryRow2.SummaryColumns.Add(summaryColumn2)
    '    ordersDescriptor.SummaryRows.Add(summaryRow2)

    '    ' Here you define the summary row that should be used for displaying summaries in caption bar.
    '    ordersDescriptor.ChildGroupOptions.ShowCaptionSummaryCells = True
    '    ordersDescriptor.ChildGroupOptions.CaptionSummaryRow = "Caption"

    '    ' Let's you hide/show the second row in child groups.
    '    ordersDescriptor.ChildGroupOptions.ShowSummaries = False
    '    captionCoverCols = 2
    '    ' Move Freight column ahead 
    '    ' ordersDescriptor.VisibleColumns.LoadDefault();
    '    Dim count As Integer = ordersDescriptor.VisibleColumns.Count
    '    ' force populating VisibleColumns

    '    'aquidddddddddddddddddddddddd

    '    Me.dgvPlaneamiento.Appearance.GroupCaptionCell.BackColor = Me.dgvPlaneamiento.Appearance.RecordFieldCell.BackColor
    '    Me.dgvPlaneamiento.Appearance.GroupCaptionCell.Borders.Top = New GridBorder(GridBorderStyle.Standard)
    '    Me.dgvPlaneamiento.Appearance.GroupCaptionCell.CellType = "Static"

    '    Me.dgvPlaneamiento.TableOptions.CaptionRowHeight = Me.dgvPlaneamiento.TableOptions.RecordRowHeight

    '    Me.dgvPlaneamiento.ChildGroupOptions.ShowAddNewRecordBeforeDetails = False

    '    ' Specify group sort order behavoir when adding SortColumnDescriptor to GroupedColumns
    '    Me.dgvPlaneamiento.TableDescriptor.GroupedColumns.Clear()
    '    Dim gsd As New SortColumnDescriptor("nomProceso")

    '    ' specify your own Comparer
    '    'gsd.GroupSortOrderComparer = new ShipViaComparer(summaryColumn1.GetSummaryDescriptorName(), "Average");

    '    ' or specify a summary name and the property (values will be determined using reflection)
    '    gsd.SetGroupSummarySortOrder(summaryColumn1.GetSummaryDescriptorName(), "Sum")

    '    Me.dgvPlaneamiento.TableDescriptor.GroupedColumns.Add(gsd)
    '    ' this should always be true since changing one record can cause the whole group to move 
    '    ' to a different position.
    '    Me.dgvPlaneamiento.InvalidateAllWhenListChanged = True

    '    Me.dgvPlaneamiento.TableOptions.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
    '    Me.dgvPlaneamiento.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
    '    Me.dgvPlaneamiento.TopLevelGroupOptions.ShowCaption = False
    '    Me.dgvPlaneamiento.Appearance.AnySummaryCell.BackColor = Color.FromArgb(255, 231, 162)

    '    dgvPlaneamiento.ShowRowHeaders = True
    'End Sub
    Sub UbicarInformacionGeneral()
        Dim costo As New recursoCosto
        Dim costoSA As New recursoCostoSA
        Dim personaSA As New PersonaSA
        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = IdSesionProyecto})
        If Not IsNothing(costo) Then
            txtProyecto.Text = costo.nombreCosto
            txtInicio.Text = costo.inicio
            txtFin.Text = costo.finaliza
            lblNomProyecto.Text = costo.nombreCosto
            txtDirector.Text = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, costo.director).nombreCompleto
            Select Case costo.status
                Case StatusCosto.Avance_Obra_Cartera
                    txtEstado.Text = "EN CARTERA"
                Case StatusCosto.Culminado
                    txtEstado.Text = "CULMINADO"
                Case StatusCosto.Proceso
                    txtEstado.Text = "EN PROCESO"
                Case StatusCosto.Suspendido
                    txtEstado.Text = "SUSPENDIDO"
            End Select
            txtContrato.Tag = costo.subtipo
            Select Case costo.subtipo
                Case TipoCosto.Proyecto
                Case TipoCosto.CONTRATOS_DE_CONSTRUCCION
                    txtContrato.Text = "CONTRATOS DE CONSTRUCCION"

                Case TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                    txtContrato.Text = "CONTRATOS DE ARRENDAMIENTOS"
                Case TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                    txtContrato.Text = "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES"
                Case TipoCosto.OrdenProduccion
                Case TipoCosto.OP_CONTINUA_DE_BIENES
                    txtContrato.Text = "OP. CONTINUA DE BIENES"
                Case TipoCosto.OP_CONTINUA_DE_SERVICIOS
                    txtContrato.Text = "OP. CONTINUA DE SERVICIOS"
                Case TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE
                    txtContrato.Text = "OP. DE BIENES - CONTROL INDEPENDIENTE"
                Case TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES
                    txtContrato.Text = "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES"
                Case TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                    txtContrato.Text = "OP. DE SERVICIOS - CONTROL INDEPENDIENTE"

            End Select

        Else

        End If

    End Sub

    Sub GridCFGDetetail(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GetEstimacionActividad(intIdProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim listaCosto As New List(Of recursoCosto)
        Dim dt As New DataTable("Orders")

        dt.Columns.Add("idProceso")
        dt.Columns.Add("nomProceso")
        dt.Columns.Add("idActividad")
        dt.Columns.Add("nomActividad")
        dt.Columns.Add("costo")
        dt.Columns.Add("sec")


        listaCosto = costoSA.GetPlaneamientoActividades(New recursoCosto With {.idCosto = intIdProyecto})
        Dim listaCosto2 = (From n In listaCosto _
                          Order By n.SecuenciaTrabajoProceso Ascending, n.secuenciaCosto Ascending).ToList


        For Each i In listaCosto2
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.IdProceso
            dr(1) = i.NomProceso
            dr(2) = i.IdActividad
            If IsNothing(i.NomActividad) Then
                dr(3) = String.Empty
            Else
                dr(3) = i.NomActividad
            End If
            dr(4) = i.TotalMN
            dr(5) = i.secuenciaCosto
            dt.Rows.Add(dr)
        Next
        dgvEstimacionRec.DataSource = dt
        Me.dgvEstimacionRec.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation Or GridMergeCellsMode.MergeRowsInColumn
        Me.dgvEstimacionRec.TableDescriptor.Columns("nomProceso").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn
        'Me.dgvEstimacionRec.TableDescriptor.Columns("nomProceso").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.Both
        'Me.dgvEstimacionRec.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation
        ''Sets the range of cells.
        'Me.dgvEstimacionRec.TableModel.Options.MergeCellsLayout = GridMergeCellsLayout.Grid
    End Sub
    Dim listaCronograma As New List(Of recursoCosto)
    Sub GetCronogramaGrid(intIdProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim dt As New DataTable("Cronograma")
        listaCronograma = New List(Of recursoCosto)

        dt.Columns.Add("idProceso")
        dt.Columns.Add("nomProceso")
        dt.Columns.Add("idActividad")
        dt.Columns.Add("nomActividad")
        dt.Columns.Add("Inicio")
        dt.Columns.Add("Finaliza")

        dt.Columns.Add("duracion")
        dt.Columns.Add("inicioActual")
        dt.Columns.Add("finActual")
        dt.Columns.Add("duracionActual")
        dt.Columns.Add("variacion")
        dt.Columns.Add("sec")
        'sdsdf()
        listaCronograma = costoSA.GetPlaneamientoActividades(New recursoCosto With {.idCosto = intIdProyecto})
        Dim listaCronograma2 = (From n In listaCronograma _
                          Order By n.SecuenciaTrabajoProceso Ascending, n.secuenciaCosto Ascending).ToList
        For Each i In listaCronograma2
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.IdProceso
            dr(1) = i.NomProceso
            dr(2) = i.IdActividad
            If IsNothing(i.NomActividad) Then
                dr(3) = String.Empty
            Else
                dr(3) = i.NomActividad
            End If
            dr(4) = i.inicio
            dr(5) = i.finaliza
            dr(6) = (i.finaliza.Value.Date - i.inicio.Value.Date).TotalDays

            If IsNothing(i.inicioActual) Or i.inicioActual = "#12:00:00 AM#" Then
                dr(7) = String.Empty
            Else
                dr(7) = FormatDateTime(i.inicioActual.GetValueOrDefault, DateFormat.ShortDate)
            End If

            If IsNothing(i.finalizaActual) Or i.finalizaActual = "#12:00:00 AM#" Then
                dr(8) = String.Empty
                dr(9) = String.Empty
            Else
                dr(8) = FormatDateTime(i.finalizaActual.GetValueOrDefault, DateFormat.ShortDate)
                dr(9) = (i.finalizaActual.Value.Date - i.inicioActual.Value.Date).TotalDays
            End If


            dr(10) = 0
            dr(11) = i.secuenciaCosto.GetValueOrDefault
            dt.Rows.Add(dr)
        Next
        dgvCronograma.DataSource = dt
        'dgvCronograma.TableDescriptor.Columns("nomProceso").AllowFilter = True
        'Me.dgvCronograma.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation Or GridMergeCellsMode.MergeRowsInColumn
        'Me.dgvCronograma.TableDescriptor.Columns("nomProceso").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn
        ''Me.dgvEstimacionRec.TableDescriptor.Columns("nomProceso").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.Both
        'Me.dgvEstimacionRec.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation
        ''Sets the range of cells.
        'Me.dgvEstimacionRec.TableModel.Options.MergeCellsLayout = GridMergeCellsLayout.Grid
    End Sub

    Sub CMBEstatus()
        Dim tablaSA As New tablaDetalleSA

        '---------------------------------------------------------------------
        Dim dtTipo As New DataTable()
        dtTipo.Columns.Add("codigo", GetType(Integer))
        dtTipo.Columns.Add("descripcion")

        Dim drTipo As DataRow = dtTipo.NewRow
        drTipo(0) = CInt(TipoRecursoPlaneado.Inventario)
        drTipo(1) = "INVENTARIO"
        dtTipo.Rows.Add(drTipo)

        Dim drTipo2 As DataRow = dtTipo.NewRow
        drTipo2(0) = CInt(TipoRecursoPlaneado.ManoDeObra)
        drTipo2(1) = "MANO DE OBRA"
        dtTipo.Rows.Add(drTipo2)

        Dim drTipo3 As DataRow = dtTipo.NewRow
        drTipo3(0) = CInt(TipoRecursoPlaneado.ActivoInmovilizado)
        drTipo3(1) = "ACTIVO INMOVILIZADO"
        dtTipo.Rows.Add(drTipo3)

        Dim drTipo4 As DataRow = dtTipo.NewRow
        drTipo4(0) = CInt(TipoRecursoPlaneado.Terceros)
        drTipo4(1) = "TERCEROS"
        dtTipo.Rows.Add(drTipo4)
        '--------------------------------------------------------------------------


        Dim tabla As New List(Of tabladetalle)
        tabla = tablaSA.GetListaTablaDetalle(6, "1").OrderBy(Function(o) o.descripcion).ToList

        Dim ggcStyle2 As GridTableCellStyleInfo = grdRecursos.TableDescriptor.Columns("um").Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = tabla
        ggcStyle2.ValueMember = "codigoDetalle"
        ggcStyle2.DisplayMember = "descripcion"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive


        Dim ggcStyle3 As GridTableCellStyleInfo = grdRecursos.TableDescriptor.Columns("tipoRecurso").Appearance.AnyRecordFieldCell
        ggcStyle3.CellType = "ComboBox"
        ggcStyle3.DataSource = dtTipo
        ggcStyle3.ValueMember = "codigo"
        ggcStyle3.DisplayMember = "descripcion"
        ggcStyle3.DropDownStyle = GridDropDownStyle.Exclusive


    End Sub

    Public Sub GetKanban()
        Dim costoSA As New recursoCostoSA
        Dim listaActividades As New List(Of recursoCosto)


        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("sec")
        dt.Columns.Add("actividad")
        dt.Columns.Add("responsable")
        dt.Columns.Add("proceso")

        listaActividades = costoSA.GetPlaneamientoKanban(New recursoCosto With {.idCosto = IdSesionProyecto, .status = StatusCosto.Avance_Obra_Cartera})
        '  Dim listaActividades2 = listaActividades.OrderBy(Function(o) o.secuenciaCosto).ToList

        Dim listaActividades2 = (From n In listaActividades _
                         Order By n.SecuenciaTrabajoProceso Ascending, n.secuenciaCosto Ascending).ToList

        For Each i In listaActividades2
            dt.Rows.Add(i.IdActividad, i.secuenciaCosto, i.NomActividad, i.NombreResponsable, i.NomProceso)
        Next
        dgvDO.DataSource = dt
        dgvDO.TableDescriptor.GroupedColumns.Clear()
        'dgvDO.TableDescriptor.GroupedColumns.Add("proceso")
        'dgvDO.TableDescriptor.VisibleColumns.Remove("proceso")
        dgvDO.TableDescriptor.VisibleColumns.Remove("idcosto")
        dgvDO.Table.ExpandAllGroups()
        dgvDO.Table.ExpandAllRecords()
    End Sub

    Public Sub GetKanbanProgress()
        Dim costoSA As New recursoCostoSA
        Dim listaActividades As New List(Of recursoCosto)


        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("sec")
        dt.Columns.Add("actividad")
        dt.Columns.Add("responsable")
        dt.Columns.Add("proceso")

        listaActividades = costoSA.GetPlaneamientoKanban(New recursoCosto With {.idCosto = IdSesionProyecto, .status = StatusCosto.Proceso})
        'Dim listaActividades2 = listaActividades.OrderBy(Function(o) o.secuenciaCosto).ToList
        Dim listaActividades2 = (From n In listaActividades _
                        Order By n.SecuenciaTrabajoProceso Ascending, n.secuenciaCosto Ascending).ToList

        For Each i In listaActividades2
            dt.Rows.Add(i.IdActividad, i.secuenciaCosto, i.NomActividad, i.NombreResponsable, i.NomProceso)
        Next
        dgvProgess.DataSource = dt
        dgvProgess.TableDescriptor.GroupedColumns.Clear()
        'dgvProgess.TableDescriptor.GroupedColumns.Add("proceso")
        'dgvProgess.TableDescriptor.VisibleColumns.Remove("proceso")
        dgvProgess.TableDescriptor.VisibleColumns.Remove("idcosto")
        dgvProgess.Table.ExpandAllGroups()
        dgvProgess.Table.ExpandAllRecords()
    End Sub

    Public Sub GetKanbanCulminados()
        Dim costoSA As New recursoCostoSA
        Dim listaActividades As New List(Of recursoCosto)


        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("sec")
        dt.Columns.Add("actividad")
        dt.Columns.Add("responsable")
        dt.Columns.Add("proceso")

        listaActividades = costoSA.GetPlaneamientoKanban(New recursoCosto With {.idCosto = IdSesionProyecto, .status = StatusCosto.Culminado})
        'Dim listaActividades2 = listaActividades.OrderBy(Function(o) o.secuenciaCosto).ToList
        Dim listaActividades2 = (From n In listaActividades _
                        Order By n.SecuenciaTrabajoProceso Ascending, n.secuenciaCosto Ascending).ToList

        For Each i In listaActividades2
            dt.Rows.Add(i.IdActividad, i.secuenciaCosto, i.NomActividad, i.NombreResponsable, i.NomProceso)
        Next
        dgvKanaFin.DataSource = dt
        dgvKanaFin.TableDescriptor.GroupedColumns.Clear()
        'dgvKanaFin.TableDescriptor.GroupedColumns.Add("proceso")
        'dgvKanaFin.TableDescriptor.VisibleColumns.Remove("proceso")
        dgvKanaFin.TableDescriptor.VisibleColumns.Remove("idcosto")
        dgvKanaFin.Table.ExpandAllGroups()
        dgvKanaFin.Table.ExpandAllRecords()
    End Sub

    Sub GetPlaneamiento(intIdProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim listaCostos As New List(Of recursoCosto)
        'Dim dt As New DataTable("Orders")

        'dt.Columns.Add("idProceso")
        'dt.Columns.Add("nomProceso")
        'dt.Columns.Add("idActividad")
        'dt.Columns.Add("nomActividad")

        listaCostos = New List(Of recursoCosto)
        listaCostos = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdProyecto})
        Dim listacostosSec = listaCostos.OrderBy(Function(o) o.secuenciaCosto).ToList()

        lsvEdtSec.Items.Clear()
        For Each i In listacostosSec
            Dim n As New ListViewItem(i.idCosto)
            n.SubItems.Add(i.nombreCosto)
            n.SubItems.Add(i.secuenciaCosto.GetValueOrDefault)
            lsvEdtSec.Items.Add(n)
        Next

        'For Each i In costoSA.GetPlaneamientoActividades(New recursoCosto With {.idCosto = intIdProyecto})
        '    Dim dr As DataRow = dt.NewRow
        '    dr(0) = i.IdProceso
        '    dr(1) = i.NomProceso
        '    dr(2) = i.IdActividad
        '    If IsNothing(i.NomActividad) Then
        '        dr(3) = String.Empty
        '    Else
        '        dr(3) = i.NomActividad
        '    End If
        '    dt.Rows.Add(dr)
        'Next
        'dgvPlaneamiento.DataSource = dt
        'dgvPlaneamiento.Table.ExpandAllRecords()

    End Sub

    Sub GetActividadesByProceso(intIdProceso As Integer)
        Dim costoSA As New recursoCostoSA
        Dim lista As New List(Of recursoCosto)

        lista = New List(Of recursoCosto)
        lista = costoSA.GetTareasByProyecto(New recursoCosto With {.idCosto = intIdProceso})

        Dim lista2 = lista.OrderBy(Function(o) o.secuenciaCosto).ToList

        lsvActividad.Items.Clear()
        For Each i In lista2
            Dim n As New ListViewItem(i.idCosto)
            n.SubItems.Add(i.nombreCosto)
            n.SubItems.Add(i.secuenciaCosto.GetValueOrDefault)
            lsvActividad.Items.Add(n)
        Next
    End Sub

    Public Sub GetRecursosAsignadosXTarea(be As recursoCosto)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importetotal")
        dt.Columns.Add("pu")
        dt.Columns.Add("tipoRecurso")

        recurso = recursoSA.GetRecursosAsignadosByCosto(be)

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.um
            dr(3) = i.cant
            dr(4) = i.montoMN
            If i.cant > 0 Then
                dr(5) = Math.Round(CDec(i.montoMN) / CDec(i.cant), 2)
            Else
                dr(5) = 0
            End If
            dr(6) = i.iditem
            dt.Rows.Add(dr)
        Next

        grdRecursos.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        'GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

#Region "Entregables"
    Sub GetAvanceCostosProyectos()
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCostoDetalle)

        costo = costoSA.GetSumaTotalByProyecto(New recursoCostoDetalle With {.idCosto = IdSesionProyecto})

        If Not IsNothing(costo) Then
            For Each i In costo
                Select Case i.tipoCosto
                    Case "PL"
                        lblTotalPlaneado.Text = i.montoMN.GetValueOrDefault.ToString("N2")
                    Case "RL"
                        lblTotalEjecutado.Text = i.montoMN.GetValueOrDefault.ToString("N2")
                End Select

            Next
        Else
            lblTotalPlaneado.Text = 0
            lblTotalEjecutado.Text = 0
        End If



    End Sub

    Sub GetEntregables()
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("entregable")
        dt.Columns.Add("fechaplan")
        dt.Columns.Add("fechareal")
        dt.Columns.Add("recurso")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeplan")
        dt.Columns.Add("puplan")
        dt.Columns.Add("cantidadReal")
        dt.Columns.Add("importereal")
        dt.Columns.Add("pureal")
        dt.Columns.Add("difCostoProd")

        costo = costoSA.GetProductosTerminadosByProyecto(New recursoCosto With {.idCosto = IdSesionProyecto})
        For Each i In costo
            dt.Rows.Add(i.idCosto, i.secuenciaCosto, i.nombreCosto, i.finaliza.GetValueOrDefault, i.finalizaActual.GetValueOrDefault, _
                        i.tipoExistencia, i.UnidadMedida, i.cantidad, 0, 0, i.cantidad, i.costoCierre.GetValueOrDefault, 0, 0)
        Next
        dgvEntregables.DataSource = dt
    End Sub
#End Region

    Private Sub TableModel_QueryCanMergeCells(ByVal sender As Object, ByVal e As GridQueryCanMergeCellsEventArgs)
        ' Checking whether it is already merged cells
        If Not e.Result Then
            ' Sets merging for two columns with different data
            If e.Style1.CellIdentity.ColIndex = 0 AndAlso e.Style2.CellIdentity.ColIndex = 2 Then
                e.Result = True
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmDireccionProyectos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        GetPlaneamiento(IdSesionProyecto)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoProcesoToolStripMenuItem.Click
        Dim f As New frmNuevoproceso()
        f.IdCostoPadre = (IdSesionProyecto)
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetPlaneamiento(IdSesionProyecto)
    End Sub

    Private Sub NuevaTareaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '      If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
        Dim f As New frmTarea
        '   f.idProyecto = dgvPlaneamiento.Table.CurrentRecord.GetValue("idProceso")
        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.LimitarFechaPadre(Val(IdSesionProyecto))
        f.ShowDialog()
        GetPlaneamiento(IdSesionProyecto)
        '   End If
    End Sub

    Private Sub EditarProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarProcesoToolStripMenuItem.Click
        If lsvEdtSec.SelectedItems.Count > 0 Then
            Dim f As New frmNuevoproceso
            f.UbicarCosto(Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text))
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetPlaneamiento(IdSesionProyecto)
        Else
            MessageBox.Show("Debe seleccionar un EDT. válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub EditarActividadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '  If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
        '  Dim nomacti = dgvPlaneamiento.Table.CurrentRecord.GetValue("nomActividad")
        'If nomacti.ToString.Trim.Length > 0 Then
        '    '    Dim f As New frmTarea(dgvPlaneamiento.Table.CurrentRecord.GetValue("idActividad"), IdSesionProyecto)
        '    f.idProyecto = IdSesionProyecto
        '    f.Manipulacion = ENTITY_ACTIONS.UPDATE
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.LimitarFechaPadre(Val(IdSesionProyecto))
        '    f.ShowDialog()
        '    GetPlaneamiento(IdSesionProyecto)
        'Else
        '    MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        'Else
        'MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub EliminarProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarProcesoToolStripMenuItem.Click
        'If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
        '    Dim recursoSA As New recursoCostoSA
        '    Dim recursoDetalleSA As New recursoCostoDetalleSA
        '    Try
        '        If MessageBox.Show("Desea eliminar el proceso seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '            Dim codProceso As Integer = dgvPlaneamiento.Table.CurrentRecord.GetValue("idProceso")
        '            recursoSA.EliminarProcesos(New recursoCosto With {.idCosto = codProceso})
        '            GetPlaneamiento(IdSesionProyecto)
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub

    Private Sub EliminarActividadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
        '    Dim recursoSA As New recursoCostoSA
        '    Dim recursoDetalleSA As New recursoCostoDetalleSA
        '    Try
        '        Dim nomacti = dgvPlaneamiento.Table.CurrentRecord.GetValue("nomActividad")
        '        If nomacti.ToString.Trim.Length > 0 Then
        '            If MessageBox.Show("Desea eliminar la actividad seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '                Dim codTarea As Integer = dgvPlaneamiento.Table.CurrentRecord.GetValue("idActividad")
        '                recursoDetalleSA.EliminarCostoDetalleBySec(New recursoCostoDetalle With {.idCosto = codTarea})
        '                GetPlaneamiento(IdSesionProyecto)
        '            End If
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub

    'Private Sub dgvPlaneamiento_QueryCoveredRange(sender As Object, e As GridTableQueryCoveredRangeEventArgs)
    '    Dim thisTable As GridTable = Me.dgvPlaneamiento.Table
    '    If e.RowIndex < thisTable.DisplayElements.Count Then
    '        Dim el As Element = thisTable.DisplayElements(e.RowIndex)

    '        Select Case el.Kind
    '            Case DisplayElementKind.Caption
    '                If True Then
    '                    ' Cover some cells of the caption bar (specified with captionCover)
    '                    Dim gs As IGridGroupOptionsSource = TryCast(el.ParentGroup, IGridGroupOptionsSource)
    '                    If gs IsNot Nothing AndAlso gs.GroupOptions.ShowCaptionSummaryCells Then
    '                        Dim startCol As Integer = el.GroupLevel + 1
    '                        If Not gs.GroupOptions.ShowCaptionPlusMinus Then
    '                            startCol -= 1
    '                        End If
    '                        If e.ColIndex >= startCol AndAlso e.ColIndex <= startCol + Me.captionCoverCols Then
    '                            e.Range = GridRangeInfo.Cells(e.RowIndex, startCol, e.RowIndex, startCol + Me.captionCoverCols)
    '                            e.Handled = True
    '                        End If
    '                    End If
    '                    Exit Select

    '                End If
    '        End Select
    '    End If
    'End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        CMBEstatus()
        grdRecursos.DataSource = New DataTable
        GetEstimacionActividad(IdSesionProyecto)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEstimacionRec_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEstimacionRec.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvEstimacionRec.Table.CurrentRecord) Then
            Dim actividad = dgvEstimacionRec.Table.CurrentRecord.GetValue("nomActividad")
            If actividad.ToString.Trim.Length > 0 Then
                txtActividadActual.Text = dgvEstimacionRec.Table.CurrentRecord.GetValue("nomActividad") ' MetodosGenericos.GetCellValue(dgTareas, "FirstName")
                txtActividadActual.Tag = dgvEstimacionRec.Table.CurrentRecord.GetValue("idActividad")
                GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
            Else
                grdRecursos.DataSource = New DataTable
                txtActividadActual.Text = String.Empty
                txtActividadActual.Tag = String.Empty
            End If
        Else
            grdRecursos.DataSource = New DataTable
            txtActividadActual.Text = String.Empty
            txtActividadActual.Tag = String.Empty
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvEstimacionRec.Table.CurrentRecord) Then
            'If txtCategoria.ForeColor = Color.Black Then
            '    MessageBox.Show("Verificar el ingreso correcto de la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtCategoria.Select()
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If
            GrabarRecurso()
            txtCategoria.Clear()
            txtCategoria.Focus()
            txtCategoria.Select()
        Else
            MessageBox.Show("Debe seleccionar una actividad para asignar un recurso", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If Not IsNothing(grdRecursos.Table.CurrentRecord) Then
            Dim costoSA As New recursoCostoDetalleSA

            costoSA.EliminarDetalleCostoPlan(New recursoCostoDetalle With {.secuencia = Val(grdRecursos.Table.CurrentRecord.GetValue("secuencia"))})
            grdRecursos.Table.CurrentRecord.Delete()
            MessageBox.Show("Recurso quitado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Debe seleccionar un recurso válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub grdRecursos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles grdRecursos.TableControlCellClick

    End Sub
    Private Sub grdRecursos_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles grdRecursos.TableControlCurrentCellCloseDropDown

        Dim recursoDet As New recursoCostoDetalle
        Dim recursoDetSA As New recursoCostoDetalleSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim r As Record = grdRecursos.Table.CurrentRecord
        If Not IsNothing(r) Then
            recursoDet = New recursoCostoDetalle
            recursoDet.secuencia = Val(r.GetValue("secuencia"))
            recursoDet.descripcion = r.GetValue("descripcion")
            recursoDet.um = r.GetValue("um")
            recursoDet.cant = CDec(r.GetValue("cantidad"))
            recursoDet.montoMN = CDec(r.GetValue("importetotal"))
            recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))

            recursoDetSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)
        End If

    End Sub

    Private Sub grdRecursos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles grdRecursos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoSA As New recursoCostoDetalleSA
        Dim colMonto As Decimal = 0
        If Not IsNothing(Me.grdRecursos.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 6
                    grdRecursos.TableControl.CurrentCell.EndEdit()
                    grdRecursos.TableControl.Table.TableDirty = True
                    grdRecursos.TableControl.Table.EndEdit()


                    Dim r As Record = grdRecursos.Table.CurrentRecord

                    colMonto = Math.Round(CDec(r.GetValue("cantidad")) * CDec(r.GetValue("pu")), 2)

                    recursoDet = New recursoCostoDetalle
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.montoMN = colMonto
                    r.SetValue("importetotal", colMonto)
                    recursoSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)
                Case 3
                    grdRecursos.TableControl.CurrentCell.EndEdit()
                    grdRecursos.TableControl.Table.TableDirty = True
                    grdRecursos.TableControl.Table.EndEdit()


                    Dim r As Record = grdRecursos.Table.CurrentRecord

                    colMonto = Math.Round(CDec(r.GetValue("cantidad")) * CDec(r.GetValue("pu")), 2)

                    recursoDet = New recursoCostoDetalle
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.montoMN = colMonto
                    r.SetValue("importetotal", colMonto)
                    recursoSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)
                Case 5
                    grdRecursos.TableControl.CurrentCell.EndEdit()
                    grdRecursos.TableControl.Table.TableDirty = True
                    grdRecursos.TableControl.Table.EndEdit()


                    Dim r As Record = grdRecursos.Table.CurrentRecord

                    colMonto = Math.Round(CDec(r.GetValue("cantidad")) * CDec(r.GetValue("pu")), 2)

                    recursoDet = New recursoCostoDetalle
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.montoMN = colMonto
                    r.SetValue("importetotal", colMonto)
                    recursoSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)

            End Select
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Me.Cursor = Cursors.WaitCursor

        Select Case cboConsultarPlaneado.Text
            Case "INVENTARIO"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = IdSesionProyecto, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.Inventario})
            Case "MANO DE OBRA"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = IdSesionProyecto, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.ManoDeObra})
            Case "ACTIVOS INMOVILIZADOS"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = IdSesionProyecto, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.ActivoInmovilizado})
            Case "TERCEROS"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = IdSesionProyecto, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.Terceros})
        End Select

        ConteoRecursos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvConsultaPlan_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvConsultaPlan.SelectedRecordsChanged
        If Not IsNothing(dgvConsultaPlan.Table.CurrentRecord) Then
            cboTipoRQ.Text = cboConsultarPlaneado.Text
            txtRecursoRequerimiento.Text = dgvConsultaPlan.Table.CurrentRecord.GetValue("descripcion")
            txtRecursoRequerimiento.Focus()
            txtRecursoRequerimiento.SelectAll()
        End If
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Me.Cursor = Cursors.WaitCursor
        GetRequerimientosByProyecto(New recursoCosto With {.idCosto = IdSesionProyecto})
        ConteoRecursos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvConsultaPlan_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvConsultaPlan.TableControlCellClick

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProyecto.Text.Trim.Length > 0 Then

            GrabarRQ()
            ConteoRecursos()
            GetRequerimientosByProyecto(New recursoCosto With {.idCosto = IdSesionProyecto})
            txtRecursoRequerimiento.Clear()
            txtRecursoRequerimiento.Focus()
            txtRecursoRequerimiento.Select()
        Else
            MessageBox.Show("Debe indicar un proyecto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If Not IsNothing(dgvRQ.Table.CurrentRecord) Then
            Dim costoSA As New recursoCostoDetalleSA

            costoSA.EliminarDetalleCostoPlan(New recursoCostoDetalle With {.secuencia = Val(dgvRQ.Table.CurrentRecord.GetValue("secuencia"))})
            dgvRQ.Table.CurrentRecord.Delete()
            ConteoRecursos()
            MessageBox.Show("Recurso quitado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Debe seleccionar un recurso válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvRQ_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvRQ.TableControlCurrentCellCloseDropDown
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoDetSA As New recursoCostoDetalleSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim r As Record = dgvRQ.Table.CurrentRecord

        If Not IsNothing(r) Then
            recursoDet = New recursoCostoDetalle
            recursoDet.secuencia = Val(r.GetValue("secuencia"))
            recursoDet.descripcion = r.GetValue("descripcion")
            recursoDet.um = r.GetValue("um")
            recursoDet.cant = CDec(r.GetValue("cantidad"))
            recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))

            Dim f = r.GetValue("actividad")
            If f.ToString.Trim.Length > 0 Then
                recursoDet.idProceso = CInt(r.GetValue("actividad"))
            Else
                recursoDet.idProceso = Nothing
            End If

            Dim fec = r.GetValue("fecha")
            If IsDate(fec) Then
                r.SetValue("fecha", Convert.ToDateTime(fec))
                recursoDet.fechaRegistro = Convert.ToDateTime(fec)
            Else
                r.SetValue("fecha", DateTime.Now)
                recursoDet.fechaRegistro = DateTime.Now
            End If

            recursoDetSA.EditarRequerimeintoBySec(recursoDet)
        End If


    End Sub

    Private Sub dgvRQ_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvRQ.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoSA As New recursoCostoDetalleSA
        Dim colMonto As Decimal = 0
        If Not IsNothing(Me.dgvRQ.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 5
                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()


                    Dim r As Record = dgvRQ.Table.CurrentRecord

                    recursoDet = New recursoCostoDetalle
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    Dim f = r.GetValue("actividad")
                    If f.ToString.Trim.Length > 0 Then
                        recursoDet.idProceso = CInt(r.GetValue("actividad"))
                    Else
                        recursoDet.idProceso = Nothing
                    End If

                    Dim fec = r.GetValue("fecha")
                    If IsDate(fec) Then
                        r.SetValue("fecha", Convert.ToDateTime(fec))
                        recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                    Else
                        r.SetValue("fecha", DateTime.Now)
                        recursoDet.fechaRegistro = DateTime.Now
                    End If

                    recursoSA.EditarRequerimeintoBySec(recursoDet)
                Case 3

                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()


                    Dim r As Record = dgvRQ.Table.CurrentRecord

                    recursoDet = New recursoCostoDetalle
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    Dim f = r.GetValue("actividad")
                    If f.ToString.Trim.Length > 0 Then
                        recursoDet.idProceso = CInt(r.GetValue("actividad"))
                    Else
                        recursoDet.idProceso = Nothing
                    End If

                    Dim fec = r.GetValue("fecha")
                    If IsDate(fec) Then
                        r.SetValue("fecha", Convert.ToDateTime(fec))
                        recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                    Else
                        r.SetValue("fecha", DateTime.Now)
                        recursoDet.fechaRegistro = DateTime.Now
                    End If

                    recursoSA.EditarRequerimeintoBySec(recursoDet)
                Case 6
                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()


                    Dim r As Record = dgvRQ.Table.CurrentRecord

                    recursoDet = New recursoCostoDetalle
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    Dim f = r.GetValue("actividad")
                    If f.ToString.Trim.Length > 0 Then
                        recursoDet.idProceso = CInt(r.GetValue("actividad"))
                    Else
                        recursoDet.idProceso = Nothing
                    End If

                    Dim fec = r.GetValue("fecha")
                    If IsDate(fec) Then
                        r.SetValue("fecha", Convert.ToDateTime(fec))
                        recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                    Else
                        r.SetValue("fecha", DateTime.Now)
                        recursoDet.fechaRegistro = DateTime.Now
                    End If

                    recursoSA.EditarRequerimeintoBySec(recursoDet)
                Case 7
                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()

                    Dim r As Record = dgvRQ.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        recursoDet = New recursoCostoDetalle
                        recursoDet.secuencia = Val(r.GetValue("secuencia"))
                        recursoDet.descripcion = r.GetValue("descripcion")
                        recursoDet.um = r.GetValue("um")
                        recursoDet.cant = CDec(r.GetValue("cantidad"))
                        recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                        Dim f = r.GetValue("actividad")
                        If f.ToString.Trim.Length > 0 Then
                            recursoDet.idProceso = CInt(r.GetValue("actividad"))
                        Else
                            recursoDet.idProceso = Nothing
                        End If

                        Dim fec = r.GetValue("fecha")
                        If IsDate(fec) Then
                            r.SetValue("fecha", Convert.ToDateTime(fec))
                            recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                        Else
                            r.SetValue("fecha", DateTime.Now)
                            recursoDet.fechaRegistro = DateTime.Now
                        End If

                        recursoSA.EditarRequerimeintoBySec(recursoDet)
                    End If

            End Select
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        GetCronogramaGrid(IdSesionProyecto)
        dgvCronograma.TableDescriptor.GroupedColumns.Clear()
        dgvCronograma.TableDescriptor.GroupedColumns.Add("nomProceso")
        dgvCronograma.Table.ExpandAllRecords()


        'Me.chartControl1.Series.Clear()

        'InitializeChartData()
        'Me.chartControl1.PrimaryXAxis.RangePaddingType = ChartAxisRangePaddingType.Calculate
        'Me.chartControl1.PrimaryYAxis.RangePaddingType = ChartAxisRangePaddingType.Calculate
        'Me.chartControl1.LegendPosition = ChartDock.Top
        'Me.chartControl1.Legend.ColumnsCount = 2
        'ChartAppearancePlan.ApplyChartStyles(Me.chartControl1)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCronograma_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCronograma.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then


            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "Inicio" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                '  e.Handled = True
            End If

            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "inicioActual" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                '  e.Handled = True
            End If

            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "Finaliza" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                '  e.Handled = True
            End If

            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "finActual" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                '  e.Handled = True
            End If

            '  End If

        End If
    End Sub

    Private Sub dgvCronograma_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCronograma.TableControlCellClick

    End Sub

    Private Sub dgvCronograma_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCronograma.TableControlCurrentCellCloseDropDown
        dgvCronograma.TableControl.CurrentCell.EndEdit()
        dgvCronograma.TableControl.Table.TableDirty = True
        dgvCronograma.TableControl.Table.EndEdit()


        'Dim r As Record = grdRecursos.Table.CurrentRecord
        'If Not IsNothing(r) Then
        '    UpdateCronograma(r)
        'End If

    End Sub

    Private Sub dgvCronograma_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCronograma.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoSA As New recursoCostoDetalleSA
        Dim colMonto As Decimal = 0
        If Not IsNothing(Me.dgvCronograma.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 4
                    dgvCronograma.TableControl.CurrentCell.EndEdit()
                    dgvCronograma.TableControl.Table.TableDirty = True
                    dgvCronograma.TableControl.Table.EndEdit()


                    Dim r As Record = dgvCronograma.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        UpdateCronograma(r)
                    End If


                Case 5

                    dgvCronograma.TableControl.CurrentCell.EndEdit()
                    dgvCronograma.TableControl.Table.TableDirty = True
                    dgvCronograma.TableControl.Table.EndEdit()


                    Dim r As Record = dgvCronograma.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        UpdateCronograma(r)
                    End If

                Case 7 ' Inicio ejecutado
                    'dgvCronograma.TableControl.CurrentCell.EndEdit()
                    'dgvCronograma.TableControl.Table.TableDirty = True
                    'dgvCronograma.TableControl.Table.EndEdit()

                    'Dim r As Record = dgvCronograma.Table.CurrentRecord
                    'If Not IsNothing(r) Then
                    '    Dim fecInicio = r.GetValue("inicioActual")
                    '    If IsDate(fecInicio) Then
                    '        UpdateFechaActual(r)
                    '    End If
                    'End If

                Case 8 ' fin ejecutado
                    'dgvCronograma.TableControl.CurrentCell.EndEdit()
                    'dgvCronograma.TableControl.Table.TableDirty = True
                    'dgvCronograma.TableControl.Table.EndEdit()

                    'Dim r As Record = dgvCronograma.Table.CurrentRecord
                    'If Not IsNothing(r) Then
                    '    Dim fecfin = r.GetValue("finActual")
                    '    If IsDate(fecfin) Then
                    '        UpdateFechaActual(r)
                    '    End If
                    'End If

            End Select
        End If
    End Sub
    Private Function ConvertScreenPointToChartAreaPoint(screenPoint As Point) As Point
        ' We cant directly convert a Screen Point to Chart Area Coordinates
        ' This converts the point in screen coordinates to chartcontrol coordinates
        'Dim ccp As Point = Me.chartControl1.PointToClient(screenPoint)

        'Return ccp
    End Function

    Private Sub chartControl1_ChartFormatAxisLabel(sender As Object, e As ChartFormatAxisLabelEventArgs)
        If e.AxisOrientation = ChartOrientation.Vertical Then
            ' To make the label text as "Activity N"
            'If e.Value >= 0 AndAlso e.Value < Me.chartControl1.Series(0).Points.Count Then
            'e.Label = [String].Format("Activity {0}", e.Value + 1)
            'Else
            If listaCronograma.Count > 0 Then
                Dim task = (From n In listaCronograma _
                       Where n.IdActividad = Val(e.Value)).FirstOrDefault

                If Not IsNothing(task) Then
                    e.Label = task.NomActividad
                Else
                    e.Label = String.Empty
                End If
            End If
            'End If
        Else
            e.Label = e.ValueAsDate.ToString("dd/MM/yy")
        End If

        e.Handled = True

    End Sub
    Private Sub chartControl1_ChartRegionMouseUp(sender As Object, e As ChartRegionMouseEventArgs)
        'If Me.checkBox_Drag.Checked Then
        '    If Me.isDragging Then
        '        chartAreaPoint = ConvertScreenPointToChartAreaPoint(Control.MousePosition)

        '        Dim newY As Double = Math.Floor(Me.chartControl1.ChartArea.GetValueByPoint(chartAreaPoint).YValues(0))
        '        Dim newX As Double = Math.Floor(Me.chartControl1.ChartArea.GetValueByPoint(chartAreaPoint).X)

        '        If newY < 0 OrElse newY >= 39835 OrElse newX < 0 OrElse newX > 7 Then
        '            MessageBox.Show("Cannot drag outside chart bounds")
        '        Else
        '            Me.NewYValue(newY)
        '        End If
        '        Me.isDragging = False
        '        Me.currentRegion = Nothing
        '    End If
        '    Me.isDragging = False
        '    Me.currentRegion = Nothing
        '    Me.chartControl1.Redraw(True)
        'End If
    End Sub

    Private Sub chartControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = IdSesionProyecto})
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvRecursosAsignados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvRecursosAsignados.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvRecursosAsignados.Table.CurrentRecord) Then
            Select Case dgvRecursosAsignados.Table.CurrentRecord.GetValue("operacion")
                Case "02", "8"
                    ComprobanteInfo(Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")))
                Case "9923"
                    ComprobanteInfoLibroDiario(Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")))
                Case "1"
                    ComprobanteInfoFinanzas(Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")))
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim asientoSA As New AsientoSA

        If Not IsNothing(dgvRecursosAsignados.Table.CurrentRecord) Then
            If MessageBox.Show("Va quitar la asignación del recurso seleccionado." & vbCrLf & _
                           "Nota: Se eliminarán todos los servicios asignados del comprobante", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                asientoSA.EliminarAsientoCostos(New asiento With {.idDocumento = Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")),
                                                                  .codigoLibro = dgvRecursosAsignados.Table.CurrentRecord.GetValue("operacion")})

                MessageBox.Show("Recursos liberados de asignación!." & vbCrLf & _
                                "Puede verificar en contabilidad, alertas de recursos x asignar.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(IdSesionProyecto)})

            End If
        Else
            MessageBox.Show("Debe seleccionar un recurso válido!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto
        Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(dgvCostos.Table.CurrentRecord) Then

        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(IdSesionProyecto)})

        Select Case costo.subtipo
            Case TipoCosto.Proyecto, _
                TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
                TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS, _
                TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES, _
                TipoCosto.ActivoFijo
                Select Case costo.status
                    Case StatusCosto.Culminado
                        MessageBox.Show("El proyecto seleccionado ya fue cerrado, intente en otra ocasión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Case Else
                        Dim f As New frminfocierreCosto(IdSesionProyecto)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                End Select


            Case TipoCosto.OrdenProduccion, _
                TipoCosto.OP_CONTINUA_DE_BIENES, _
                TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
                TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
                TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES, _
                TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                Select Case costo.status
                    Case StatusCosto.Culminado
                        MessageBox.Show("El proyecto seleccionado ya fue cerrado, intente en otra ocasión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Case Else
                        Dim f As New frminfocierreProduccion(IdSesionProyecto)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                End Select
        End Select


        'Else
        '    MessageBox.Show("Debe indicar un costo para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto


        Try
            'If Not IsNothing(dgvCostos.Table.CurrentRecord) Then

            Select Case txtContrato.Tag
                Case TipoCosto.Proyecto, _
                     TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
                     TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS, _
                     TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES

                    If MessageBox.Show("Desea eliminar el cierre del costo? ", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        costo = New recursoCosto
                        costo.idCosto = Val(IdSesionProyecto)
                        costo.status = StatusCosto.Avance_Obra_Cartera

                        costoSA.GetEliminarCierreCosto(costo)
                        MessageBox.Show("Status de costo cambiado a en proceso y/o avance de obra", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Case TipoCosto.OrdenProduccion, _
                    TipoCosto.OP_CONTINUA_DE_BIENES, _
                    TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES, _
                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE

                    If MessageBox.Show("Desea eliminar el cierre de la orden de producción? ", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        costo = New recursoCosto
                        costo.idCosto = IdSesionProyecto
                        costo.status = StatusCosto.Proceso

                        costoSA.GetEliminarCierreProduccion(costo)
                        MessageBox.Show("Status de la orden cambiado a en proceso y/o avance de obra", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case "ACTIVO FIJO"


            End Select


            'Else
            '    MessageBox.Show("Debe indicar un costo para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chartControl1_Legend_FilterItems(sender As Object, e As ChartLegendFilterItemsEventArgs) Handles ChartControl2.Legend.FilterItems
        Dim series As ChartSeries = Me.ChartControl2.Series(0)
        For i As Integer = 0 To series.Points.Count - 1
            e.Items(i).Text = series.Points(i).YValues(0).ToString() + "%"
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        InitializeChartDataPie()
        ChartAppearancePie.ApplyChartStyles(Me.ChartControl2)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ChartControl2_Click(sender As Object, e As EventArgs) Handles ChartControl2.Click

    End Sub

   

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Dim f As New frmCulminarActividad
        f.StartPosition = FormStartPosition.CenterParent
        f.IdSesionActividad = 0
        f.ShowDialog()
    End Sub

    Private Sub lsvEdtSec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvEdtSec.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If lsvEdtSec.SelectedItems.Count > 0 Then
            GetActividadesByProceso(Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If lsvEdtSec.SelectedItems.Count > 0 Then
            Dim f As New frmTarea
            f.idProyecto = Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text)
            f.Manipulacion = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.LimitarFechaPadre(Val(IdSesionProyecto))
            f.ShowDialog()
            'GetPlaneamiento(IdSesionProyecto)
            If lsvEdtSec.SelectedItems.Count > 0 Then
                GetActividadesByProceso(Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text))
            End If
        Else
            MessageBox.Show("Debe seleccionar un EDT válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If lsvActividad.SelectedItems.Count > 0 Then
            Dim nomacti = lsvActividad.SelectedItems(0).SubItems(1).Text
            If nomacti.ToString.Trim.Length > 0 Then
                Dim f As New frmTarea(Val(lsvActividad.SelectedItems(0).SubItems(0).Text), IdSesionProyecto)
                f.idProyecto = IdSesionProyecto
                f.Manipulacion = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.LimitarFechaPadre(Val(IdSesionProyecto))
                f.ShowDialog()
                If lsvEdtSec.SelectedItems.Count > 0 Then
                    GetActividadesByProceso(Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text))
                End If
            Else
                MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click 'If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
        Dim recursoSA As New recursoCostoSA
        Dim recursoDetalleSA As New recursoCostoDetalleSA
        If lsvActividad.SelectedItems.Count > 0 Then
            Try
                Dim nomacti = lsvActividad.SelectedItems(0).SubItems(1).Text
                If nomacti.ToString.Trim.Length > 0 Then
                    If MessageBox.Show("Desea eliminar la actividad seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Dim codTarea As Integer = Val(lsvActividad.SelectedItems(0).SubItems(0).Text)
                        recursoDetalleSA.EliminarCostoDetalleBySec(New recursoCostoDetalle With {.idCosto = codTarea})
                        If lsvEdtSec.SelectedItems.Count > 0 Then
                            GetActividadesByProceso(Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text))
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        If lsvEdtSec.SelectedItems.Count > 0 Then
            Dim ind As Integer = lsvEdtSec.SelectedItems(0).Index

            If ind = 0 Then

            Else
                Dim litem As ListViewItem = lsvEdtSec.Items(ind)
                lsvEdtSec.Items.RemoveAt(ind)
                lsvEdtSec.Items.Insert(ind - 1, litem)
            End If
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If lsvEdtSec.SelectedItems.Count > 0 Then
            Dim ultimaFila = lsvEdtSec.Items.Count - 1

            Dim ind As Integer = lsvEdtSec.SelectedItems(0).Index

            If ind = ultimaFila Then

            Else
                Dim litem As ListViewItem = lsvEdtSec.Items(ind)
                lsvEdtSec.Items.RemoveAt(ind)
                lsvEdtSec.Items.Insert(ind + 1, litem)
            End If
        End If
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Dim obj As New recursoCosto
        Dim listaCosto As New List(Of recursoCosto)
        Dim conteo As Integer = 1
        For Each i As ListViewItem In lsvEdtSec.Items
            obj = New recursoCosto
            obj.idCosto = i.SubItems(0).Text
            obj.secuenciaCosto = conteo
            conteo = conteo + 1
            listaCosto.Add(obj)
        Next
        costoSA.GetUpdateSecuencia(listaCosto)
        MessageBox.Show("Secuencia aplicada para los EDTs, con éxito", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GetPlaneamiento(IdSesionProyecto)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        If lsvActividad.SelectedItems.Count > 0 Then
            Dim ind As Integer = lsvActividad.SelectedItems(0).Index

            If ind = 0 Then

            Else
                Dim litem As ListViewItem = lsvActividad.Items(ind)
                lsvActividad.Items.RemoveAt(ind)
                lsvActividad.Items.Insert(ind - 1, litem)
            End If
        End If
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        If lsvActividad.SelectedItems.Count > 0 Then
            Dim ultimaFila = lsvActividad.Items.Count - 1

            Dim ind As Integer = lsvActividad.SelectedItems(0).Index

            If ind = ultimaFila Then

            Else
                Dim litem As ListViewItem = lsvActividad.Items(ind)
                lsvActividad.Items.RemoveAt(ind)
                lsvActividad.Items.Insert(ind + 1, litem)
            End If
        End If
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Dim obj As New recursoCosto
        Dim listaCosto As New List(Of recursoCosto)
        Dim conteo As Integer = 1
        For Each i As ListViewItem In lsvActividad.Items
            obj = New recursoCosto
            obj.idCosto = i.SubItems(0).Text
            obj.secuenciaCosto = conteo
            conteo = conteo + 1
            listaCosto.Add(obj)
        Next
        costoSA.GetUpdateSecuencia(listaCosto)
        MessageBox.Show("Secuencia aplicada para las actividades, con éxito", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If lsvEdtSec.SelectedItems.Count > 0 Then
            GetActividadesByProceso(Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text))
        Else
            lsvActividad.Items.Clear()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If lsvEdtSec.SelectedItems.Count > 0 Then
            GetActividadesByProceso(Val(lsvEdtSec.SelectedItems(0).SubItems(0).Text))
        Else
            lsvActividad.Items.Clear()
        End If
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Me.Cursor = Cursors.WaitCursor
        GetKanban()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProgess.TableControlCellClick

    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        Me.Cursor = Cursors.WaitCursor
        GetKanbanProgress()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs) Handles ToolStripButton18.Click
        Me.Cursor = Cursors.WaitCursor
        GetKanbanCulminados()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvDO.Table.CurrentRecord) Then
            Dim f As New frmInicioActividad
            f.IdSesionActividad = dgvDO.Table.CurrentRecord.GetValue("idcosto")
            f.txtActividad.Text = dgvDO.Table.CurrentRecord.GetValue("actividad")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetKanbanProgress()
            GetKanban()
        Else
            MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvDO.Table.CurrentRecord) Then
            Dim f As New frmCulminarActividad
            f.IdSesionActividad = dgvDO.Table.CurrentRecord.GetValue("idcosto")
            f.txtActividad.Text = dgvDO.Table.CurrentRecord.GetValue("actividad")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetKanbanCulminados()
        Else
            MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvProgess.Table.CurrentRecord) Then
            Dim f As New frmCulminarActividad
            f.IdSesionActividad = dgvProgess.Table.CurrentRecord.GetValue("idcosto")
            f.txtActividad.Text = dgvProgess.Table.CurrentRecord.GetValue("actividad")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetKanbanCulminados()
            GetKanbanProgress()
        Else
            MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmDireccionProyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripDropDownButton4_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmEntregable
        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.IdProyecto = IdSesionProyecto
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
        Me.Cursor = Cursors.WaitCursor
        GetEntregables()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripDropDownButton5_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton5.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvEntregables.Table.CurrentRecord) Then

            Dim f As New frmEntregable(Val(dgvEntregables.Table.CurrentRecord.GetValue("idcosto")))
            f.Manipulacion = ENTITY_ACTIONS.UPDATE
            'f.txtEntregable.Tag = Val(dgvEntregables.Table.CurrentRecord.GetValue("idcosto"))
            f.IdProyecto = IdSesionProyecto
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetEntregables()
        Else
            MessageBox.Show("Debe seleccionar un entregable para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripDropDownButton6_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton6.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA

        If Not IsNothing(dgvEntregables.Table.CurrentRecord) Then
            If MessageBox.Show("Desea eliminar el entregable seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                costoSA.EliminarEntregable(New recursoCosto With {.idCosto = Val(dgvEntregables.Table.CurrentRecord.GetValue("idcosto"))})
                dgvEntregables.Table.CurrentRecord.Delete()
            End If
        Else
            MessageBox.Show("Debe seleccionar un entregable para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton21_Click(sender As Object, e As EventArgs) Handles ToolStripButton21.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        If Not IsNothing(dgvProgess.Table.CurrentRecord) Then
            If MessageBox.Show("Desea enviar a pendientes," & vbCrLf & "la actividad seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                costoSA.GetPendingActividad(New recursoCosto With {.idCosto = Val(dgvProgess.Table.CurrentRecord.GetValue("idcosto"))})
                dgvProgess.Table.CurrentRecord.Delete()
                GetKanban()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEntregables_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntregables.TableControlCellClick

    End Sub

    Private Sub dgvEntregables_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvEntregables.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoSA As New recursoCostoDetalleSA
        Dim colMonto As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colImportePlan As Decimal = 0
        Dim colPUPlan As Decimal = 0
        If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 8
                    dgvEntregables.TableControl.CurrentCell.EndEdit()
                    dgvEntregables.TableControl.Table.TableDirty = True
                    dgvEntregables.TableControl.Table.EndEdit()

                    Dim r As Record = dgvEntregables.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        colCantidad = r.GetValue("cantidad")
                        colImportePlan = r.GetValue("importeplan")
                        If colCantidad > 0 Then
                            colPUPlan = Math.Round(colImportePlan / colCantidad, 2)
                        Else
                            colPUPlan = 0
                        End If
                        r.SetValue("puplan", colPUPlan)
                    End If

                Case 9
                    dgvEntregables.TableControl.CurrentCell.EndEdit()
                    dgvEntregables.TableControl.Table.TableDirty = True
                    dgvEntregables.TableControl.Table.EndEdit()


                    Dim r As Record = dgvEntregables.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        colCantidad = r.GetValue("cantidad")
                        colImportePlan = r.GetValue("importeplan")
                        If colCantidad > 0 Then
                            colPUPlan = Math.Round(colImportePlan / colCantidad, 2)
                        Else
                            colPUPlan = 0
                        End If
                        r.SetValue("puplan", colPUPlan)
                    End If


                Case 11

                    dgvEntregables.TableControl.CurrentCell.EndEdit()
                    dgvEntregables.TableControl.Table.TableDirty = True
                    dgvEntregables.TableControl.Table.EndEdit()

                    Dim r As Record = dgvEntregables.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        colCantidad = r.GetValue("cantidadReal")
                        colImportePlan = r.GetValue("importereal")
                        If colCantidad > 0 Then
                            colPUPlan = Math.Round(colImportePlan / colCantidad, 2)
                        Else
                            colPUPlan = 0
                        End If
                        r.SetValue("pureal", colPUPlan)
                    End If

                Case 12
                    dgvEntregables.TableControl.CurrentCell.EndEdit()
                    dgvEntregables.TableControl.Table.TableDirty = True
                    dgvEntregables.TableControl.Table.EndEdit()

                    Dim r As Record = dgvEntregables.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        colCantidad = r.GetValue("cantidadReal")
                        colImportePlan = r.GetValue("importereal")
                        If colCantidad > 0 Then
                            colPUPlan = Math.Round(colImportePlan / colCantidad, 2)
                        Else
                            colPUPlan = 0
                        End If
                        r.SetValue("pureal", colPUPlan)
                    End If

            End Select
        End If
    End Sub

    Private Sub dgvRQ_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvRQ.TableControlCellClick

    End Sub

    Private Sub TabPageAdv3_Click(sender As Object, e As EventArgs) Handles TabPageAdv3.Click

    End Sub
End Class