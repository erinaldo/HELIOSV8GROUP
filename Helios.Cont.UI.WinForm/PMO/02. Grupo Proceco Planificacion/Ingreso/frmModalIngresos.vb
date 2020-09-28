Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalIngresos
    Public XManipulacion As String
    Public XDireccion As String
    Public xTipoProyecto As String

    Public cIdProyecto As Integer
    Public cIdEstrategia As Integer
    Public cIdProceso As Integer
    Public cIdTarea As Integer
    Public cNomTarea As String

    Enum Filtro
        PorNombre = 2
        PorCodigo = 1
    End Enum
#Region "Métdos"
    Public Sub ObtenerUM()
        Dim objServiceSA As New tablaDetalleSA
        Dim ACTDBSuggestions As New AutoCompleteStringCollection()
        Try
            For Each i In objServiceSA.ObtenerTablaFull()
                ACTDBSuggestions.Add(i)
            Next

            txtUM.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtUM.AutoCompleteCustomSource = ACTDBSuggestions
            txtUM.AutoCompleteMode = AutoCompleteMode.Suggest

        Catch ex As Exception
            lblEstado.Text = "No se pudo cargar la información para la lista de EF."
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    'Public Sub ObtenerPorEventoFiltro(intIdEvento As Integer, strFiltro As String, intOpcion As Filtro)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.ProyectoListaMaterialesBO
    '    ' Dim objItem() As HeliosService.DetalleitemsBO
    '    Try
    '        objLista = objService.GetObtenerMaterialesporEventoPorItem(intIdEvento, strFiltro, intOpcion)
    '        If objLista.Length > 0 Then
    '            txtIdItem.Text = objLista(0).IdItem
    '            txtItem.Text = objLista(0).DescripcionItem
    '        End If


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'Public Sub CargarCombos()
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.TablaDetalleBO
    '    Try
    '        objLista = objService.GetLista(6, "1")

    '        cboUM.DisplayMember = "descripcion"
    '        cboUM.ValueMember = "codigoDetalle"
    '        cboUM.DataSource = objLista
    '        cboUM.SelectedValue = "07"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub UbicarItem(ByVal intIdItem As Integer)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.DetalleActividadPlaneacionBO
    '    Try
    '        objLista = objService.GetUbicaEX_IngresoPorItem(intIdItem)
    '        If objLista.Length > 0 Then
    '            cboUM.SelectedValue = objLista(0).UnidadMedida

    '            txtIdItem.Text = objLista(0).Composicion
    '            txtItem.Text = objLista(0).Descripcion
    '            txtDetalle.Text = objLista(0).Talla
    '            nudCan.Value = objLista(0).Cantidad
    '            nudPU.Value = objLista(0).PrecioUnit
    '            nudCostoDirecto.Value = objLista(0).CostoDirecto
    '            nudPorcentaje.Value = objLista(0).Porcentaje
    '            nudPorcGastos.Value = objLista(0).PorGastosGenerales
    '            nudGastosGen.Value = objLista(0).GastosGenerales
    '            nudPorcUti.Value = objLista(0).PorUtilidad
    '            nudUti.Value = objLista(0).Utilidad
    '            nudOtros1.Value = objLista(0).OtrosIn1
    '            nudValorVenta.Value = objLista(0).ValorVenta
    '            nudPorIGV.Value = objLista(0).PorIgv
    '            nudIGV.Value = objLista(0).Igv
    '            nudTotalProyecto.Value = objLista(0).TotalProyecto
    '            nudPorcPerc.Value = objLista(0).PorPercep
    '            nudPerc.Value = objLista(0).Percepciones
    '            nudPorcReten.Value = objLista(0).PorRetenciones
    '            nudReten.Value = objLista(0).Retenciones
    '            nudOtros2.Value = objLista(0).OtrosIn2
    '            nudTotalCobrar.Value = objLista(0).TotalPorCobrar
    '            nudPorcDetra.Value = objLista(0).PorDetracciones
    '            nudDetra.Value = objLista(0).Detracciones
    '            nudOtros3.Value = objLista(0).OtroIn3
    '            nudNetoCobrar.Value = objLista(0).NetoCobrar
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Sub IngresoPlanificacion()
        Dim objLiquidacionDet As New totalesLiquidacion()
        Dim RecursoSA As New actividadRecursoSA
        Dim objRecuros As New actividadRecurso
        Dim IdActividad As Integer
        Dim tipAct As String = Nothing

        Select Case GProyectos.IdModoTrabajo
            Case "FS"
                tipAct = TIPO_ACTIVIDAD_MODULO.FASE

            Case "AC"
                tipAct = TIPO_ACTIVIDAD_MODULO.ACTIVIDAD

            Case "EDT"
                tipAct = TIPO_ACTIVIDAD_MODULO.ENTREGABLE

            Case "PY"
                tipAct = TIPO_ACTIVIDAD_MODULO.PROYECTO
        End Select

        objRecuros = New actividadRecurso With {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .idProyecto = GProyectos.IdProyectoActividad,
        .idActividad = GModoTRabajos.IdActividad,
        .tipoActividad = tipAct,
        .Idempresa = Gempresas.IdEmpresaRuc,
        .IdEstablecimiento = GEstableciento.IdEstablecimiento,
        .fechaIngreso = txtFechaIngreso.Value,
        .TipoRecurso = IIf(chSinMov.Checked = True, "SM", "ING"),
        .Descripcion = txtItem.Text.Trim,
        .detalleExtra = txtDetalle.Text,
        .cuentaContable = txtIdItem.Text,
        .unidadMedida = txtCodigoDetalle.Text,
        .CantRequerida = nudCan.Value,
        .ValorMercadoPu = nudPU.Value,
        .CostoDirecto = nudCostoDirecto.Value,
        .PorGastosGenerales = nudPorcGastos.Value,
        .GastosGenerales = nudGastosGen.Value,
        .PorUtilidad = nudPorcUti.Value,
        .Utilidad = nudUti.Value,
        .PorOtrosIn1 = 0,
        .OtrosIn1 = nudOtros1.Value,
        .ValorVenta = nudValorVenta.Value,
        .PorIgv = nudPorIGV.Value,
        .Igv = nudIGV.Value,
        .TotalProyecto = nudTotalProyecto.Value,
        .PorPercep = nudPorcPerc.Value,
        .Percepciones = nudPerc.Value,
        .PorOtrosIn2 = 0,
        .OtrosIn2 = nudOtros2.Value,
        .TotalPorCobrar = nudTotalCobrar.Value,
        .PorDetracciones = nudPorcDetra.Value,
        .Detracciones = nudDetra.Value,
        .PorRetenciones = nudPorcReten.Value,
        .Retenciones = nudReten.Value,
        .PorOtroIn3 = 0,
        .OtroIn3 = nudOtros3.Value,
        .NetoCobrar = nudNetoCobrar.Value,
        .Porcentaje = nudPorcentaje.Value,
        .TipoPresupuesto = "INGRESOS",
        .tipoPlan = "B",
        .Sustentado = 0}

        'LIQUIDACION INSERT
        objLiquidacionDet = New totalesLiquidacion()


        objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
        objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
        objLiquidacionDet.idActividad = GModoTRabajos.IdActividad
        objLiquidacionDet.tipoLiquidacion = "INGRESOS"
        objLiquidacionDet.Otros = "INGRESOS"
        objLiquidacionDet.modulo = "N"
        objLiquidacionDet.Fecha = Date.Now.Date

        objLiquidacionDet.LI_ib_ini = nudIGV.Value  'IGV
        objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini

        objLiquidacionDet.LI_ib_ns = nudIGV.Value 'IGV
        objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns

        objLiquidacionDet.LI_ib_adic = nudIGV.Value 'IGV
        objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic

        'segundo reporte
        objLiquidacionDet.LR_ventan_ini = nudValorVenta.Value
        objLiquidacionDet.LR_ventan_ns = nudValorVenta.Value
        objLiquidacionDet.LR_ventan_adic = nudValorVenta.Value

        'otros reportes
        '***********************************************************
        objLiquidacionDet.detraccion_ini = nudDetra.Value
        objLiquidacionDet.detraccion_ns = nudDetra.Value
        objLiquidacionDet.detraccion_adic = nudDetra.Value

        'ANALISIS FINANCIERO
        '---------------------------------------------------------------
        objLiquidacionDet.AF_EjecucionIng_ini = nudTotalProyecto.Value
        objLiquidacionDet.AF_EjecucionIng_ns = nudTotalProyecto.Value
        objLiquidacionDet.AF_EjecucionIng_adic = nudTotalProyecto.Value

        objLiquidacionDet.AF_Percepcion_ini = nudPerc.Value
        objLiquidacionDet.AF_Percepcion_ns = nudPerc.Value
        objLiquidacionDet.AF_Percepcion_adic = nudPerc.Value

        objLiquidacionDet.AF_Otrosps_ini = nudOtros2.Value
        objLiquidacionDet.AF_Otrosps_ns = nudOtros2.Value
        objLiquidacionDet.AF_Otrosps_adic = nudOtros2.Value

        objLiquidacionDet.AF_Detraccion_ini = nudDetra.Value
        objLiquidacionDet.AF_Detraccion_ns = nudDetra.Value
        objLiquidacionDet.AF_Detraccion_adic = nudDetra.Value

        objLiquidacionDet.AF_Retencion_ini = nudReten.Value
        objLiquidacionDet.AF_Retencion_ns = nudReten.Value
        objLiquidacionDet.AF_Retencion_adic = nudReten.Value

        objLiquidacionDet.AF_Otrosng_ini = nudOtros3.Value
        objLiquidacionDet.AF_Otrosng_ns = nudOtros3.Value
        objLiquidacionDet.AF_Otrosng_adic = nudOtros3.Value

        objLiquidacionDet.totalIngresos = nudTotalProyecto.Value

        objLiquidacionDet.tipoPlan = "B"

        objLiquidacionDet.usuarioActualizacion = "NN"
        objLiquidacionDet.fechaActualizacion = DateTime.Now

        IdActividad = RecursoSA.SaveRecurso(objRecuros, objLiquidacionDet)
        If (IdActividad <> Nothing) Then
            lblEstado.Text = "Recurso registrado!"
            lblEstado.Image = My.Resources.ok4
            frmPlanGestionProyecto.dgvIngresos.Rows.Add(txtFechaIngreso.Value.Date, IdActividad, txtItem.Text, txtDetalle.Text, txtUM.Text, _
                                                      "ING", nudCan.Value, nudPU.Value, nudCostoDirecto.Value, nudPorcGastos.Value,
                                                      nudGastosGen.Value, nudPorcUti.Value, nudUti.Value, nudOtros1.Value, nudValorVenta.Value,
                                                      nudPorIGV.Value, nudIGV.Value, nudTotalProyecto.Text, nudPorcPerc.Value, nudPerc.Value,
                                                      nudOtros2.Value, nudTotalCobrar.Value, nudPorcDetra.Value, nudDetra.Value, nudPorcReten.Value,
                                                      nudReten.Value, nudOtros3.Value, nudNetoCobrar.Value, nudPorcentaje.Value)

            Dispose()
        Else
            lblEstado.Text = "Error al grabar Cadena!"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Public Sub UpdateIngresoPlanificacion()
         Dim objLiquidacionDet As New totalesLiquidacion()
        Dim RecursoSA As New actividadRecursoSA
        Dim objRecuros As New actividadRecurso
        Dim objActividadDeleteEO As New totalesLiquidacion()
        Dim tipAct As String = Nothing

        Select Case GProyectos.IdModoTrabajo
            Case "FS"
                tipAct = TIPO_ACTIVIDAD_MODULO.FASE
            Case "AC"
                tipAct = TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
            Case "EDT"
                tipAct = TIPO_ACTIVIDAD_MODULO.ENTREGABLE
            Case "PY"
                tipAct = TIPO_ACTIVIDAD_MODULO.PROYECTO
        End Select

        objRecuros = New actividadRecurso With {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .idProyecto = GProyectos.IdProyectoActividad,
         .idActividadRecurso = lblId.Text,
        .idActividad = GModoTRabajos.IdActividad,
        .tipoActividad = tipAct,
        .Idempresa = Gempresas.IdEmpresaRuc,
        .IdEstablecimiento = GEstableciento.IdEstablecimiento,
        .fechaIngreso = txtFechaIngreso.Value,
        .TipoRecurso = IIf(chSinMov.Checked = True, "SM", "ING"),
        .Descripcion = txtItem.Text.Trim,
        .detalleExtra = txtDetalle.Text,
        .cuentaContable = txtIdItem.Text,
        .unidadMedida = txtCodigoDetalle.Text,
        .CantRequerida = nudCan.Value,
        .ValorMercadoPu = nudPU.Value,
        .CostoDirecto = nudCostoDirecto.Value,
        .PorGastosGenerales = nudPorcGastos.Value,
        .GastosGenerales = nudGastosGen.Value,
        .PorUtilidad = nudPorcUti.Value,
        .Utilidad = nudUti.Value,
        .PorOtrosIn1 = 0,
        .OtrosIn1 = nudOtros1.Value,
        .ValorVenta = nudValorVenta.Value,
        .PorIgv = nudPorIGV.Value,
        .Igv = nudIGV.Value,
        .TotalProyecto = nudTotalProyecto.Value,
        .PorPercep = nudPorcPerc.Value,
        .Percepciones = nudPerc.Value,
        .PorOtrosIn2 = 0,
        .OtrosIn2 = nudOtros2.Value,
        .TotalPorCobrar = nudTotalCobrar.Value,
        .PorDetracciones = nudPorcDetra.Value,
        .Detracciones = nudDetra.Value,
        .PorRetenciones = nudPorcReten.Value,
        .Retenciones = nudReten.Value,
        .PorOtroIn3 = 0,
        .OtroIn3 = nudOtros3.Value,
        .NetoCobrar = nudNetoCobrar.Value,
        .Porcentaje = nudPorcentaje.Value,
        .TipoPresupuesto = "INGRESOS",
        .tipoPlan = "B",
        .Sustentado = 0}

           objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
        objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
        objLiquidacionDet.idActividad = GModoTRabajos.IdActividad
        objLiquidacionDet.tipoLiquidacion = "INGRESOS"
        objLiquidacionDet.Otros = "INGRESOS"
        objLiquidacionDet.modulo = "E"
        objLiquidacionDet.Fecha = Date.Now.Date

        objLiquidacionDet.LI_ib_ini = nudIGV.Value  'IGV
        objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini

        objLiquidacionDet.LI_ib_ns = nudIGV.Value 'IGV
        objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns

        objLiquidacionDet.LI_ib_adic = nudIGV.Value 'IGV
        objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic

        'segundo(reporte)
        objLiquidacionDet.LR_ventan_ini = nudValorVenta.Value
        objLiquidacionDet.LR_ventan_ns = nudValorVenta.Value
        objLiquidacionDet.LR_ventan_adic = nudValorVenta.Value

        'otros(reportes)
        '***********************************************************
        objLiquidacionDet.detraccion_ini = nudDetra.Value
        objLiquidacionDet.detraccion_ns = nudDetra.Value
        objLiquidacionDet.detraccion_adic = nudDetra.Value

        'ANALISIS(FINANCIERO)
        '---------------------------------------------------------------
        objLiquidacionDet.AF_EjecucionIng_ini = nudTotalProyecto.Value
        objLiquidacionDet.AF_EjecucionIng_ns = nudTotalProyecto.Value
        objLiquidacionDet.AF_EjecucionIng_adic = nudTotalProyecto.Value

        objLiquidacionDet.AF_Percepcion_ini = nudPerc.Value
        objLiquidacionDet.AF_Percepcion_ns = nudPerc.Value
        objLiquidacionDet.AF_Percepcion_adic = nudPerc.Value

        objLiquidacionDet.AF_Otrosps_ini = nudOtros2.Value
        objLiquidacionDet.AF_Otrosps_ns = nudOtros2.Value
        objLiquidacionDet.AF_Otrosps_adic = nudOtros2.Value

        objLiquidacionDet.AF_Detraccion_ini = nudDetra.Value
        objLiquidacionDet.AF_Detraccion_ns = nudDetra.Value
        objLiquidacionDet.AF_Detraccion_adic = nudDetra.Value

        objLiquidacionDet.AF_Retencion_ini = nudReten.Value
        objLiquidacionDet.AF_Retencion_ns = nudReten.Value
        objLiquidacionDet.AF_Retencion_adic = nudReten.Value

        objLiquidacionDet.AF_Otrosng_ini = nudOtros3.Value
        objLiquidacionDet.AF_Otrosng_ns = nudOtros3.Value
        objLiquidacionDet.AF_Otrosng_adic = nudOtros3.Value

        objLiquidacionDet.tipoPlan = "B"

        objLiquidacionDet.usuarioActualizacion = "NN"
        objLiquidacionDet.fechaActualizacion = DateTime.Now

        '********************************** ELIMINANDO ***********************************************
        With objActividadDeleteEO
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .idActividad = GModoTRabajos.IdActividad
            .secuencia = lblId.Text
            .tipoPlan = "B"
            .tipoLiquidacion = "INGRESOS"
            .Otros = "INGRESOS"
        End With

        If RecursoSA.UpdateRecurso(objRecuros, objActividadDeleteEO, objLiquidacionDet) Then
            lblEstado.Text = "Recurso editado!"
            lblEstado.Image = My.Resources.ok4

            With frmPlanGestionProyecto.dgvIngresos
                .Item(0, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = txtFechaIngreso.Value.Date
                .Item(1, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = lblId.Text
                .Item(2, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = txtItem.Text
                .Item(3, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = txtDetalle.Text
                .Item(4, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = txtUM.Text
                .Item(5, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = "ING"
                .Item(6, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudCan.Value
                .Item(7, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPU.Value
                .Item(8, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudCostoDirecto.Value
                .Item(9, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPorcGastos.Value
                .Item(10, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudGastosGen.Value
                .Item(11, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPorcUti.Value
                .Item(12, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudUti.Value
                .Item(13, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudOtros1.Value
                .Item(14, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudValorVenta.Value
                .Item(15, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPorIGV.Value
                .Item(16, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudIGV.Value
                .Item(17, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudTotalProyecto.Text
                .Item(18, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPorcPerc.Value
                .Item(19, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPerc.Value
                .Item(20, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudOtros2.Value
                .Item(21, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudTotalCobrar.Value
                .Item(22, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPorcDetra.Value
                .Item(23, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudDetra.Value
                .Item(24, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPorcReten.Value
                .Item(25, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudReten.Value
                .Item(26, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudOtros3.Value
                .Item(27, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudNetoCobrar.Value
                .Item(28, frmPlanGestionProyecto.dgvIngresos.CurrentRow.Index).Value = nudPorcentaje.Value
            End With
            Dispose()
        Else
            lblEstado.Text = "Error al grabar Cadena!"
            lblEstado.Image = My.Resources.cross
        End If

    End Sub

    Public Sub UbicarID(intIdRecurso As Integer)
        Dim recursoSA As New actividadRecursoSA
        Dim detalleSA As New tablaDetalleSA
        Dim ItemsSA As New itemSA
        Dim tipRec As String = ""
        With recursoSA.UbicaRecursoID(intIdRecurso)

            lblId.Text = .idActividadRecurso
            txtFechaIngreso.Value = .fechaIngreso
            txtItem.Text = .Descripcion
            txtDetalle.Text = .detalleExtra
            txtCodigoDetalle.Text = .unidadMedida
            txtUM.Text = detalleSA.GetUbicarTablaID(6, .unidadMedida).descripcion
            nudCan.Value = .CantRequerida
            nudPU.Value = .ValorMercadoPu
            nudCostoDirecto.Value = .CostoDirecto
            nudPorcGastos.Value = .PorGastosGenerales
            nudGastosGen.Value = .GastosGenerales
            nudPorcUti.Value = .PorUtilidad
            'nudUti.Value = .Utilidad
            nudValorVenta.Value = .OtrosIn1
            nudPorIGV.Value = .PorIgv
            nudIGV.Value = .Igv  ' otros aportes
            nudTotalProyecto.Value = .TotalProyecto
            nudPorcPerc.Value = .PorPercep
            nudPerc.Value = .Percepciones
            nudOtros2.Text = .OtrosIn2
            nudTotalCobrar.Value = .TotalPorCobrar
            nudPorcDetra.Value = .PorDetracciones
            'nudDetra.Value = .Detracciones
            nudPorcReten.Value = .PorRetenciones
            nudReten.Value = .Retenciones
            nudOtros3.Value = .OtroIn3
            nudNetoCobrar.Value = .NetoCobrar
            nudPorcentaje.Value = .Porcentaje

        End With
    End Sub



    'Public Sub eliminarINGRESO()

    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS

    '    Dim objpresupuesto As New HeliosService.DetalleActividadPlaneacionEO()
    '    Dim objpresupuestoDet As New HeliosService.DetalleActividadPlaneacionBO()
    '    Dim objDocumentoCompraDetalle() As HeliosService.DetalleActividadPlaneacionBO
    '    Dim conteo As Integer = 0 ' dgvCadenaSum.Rows.Count
    '    conteo = 0 ' conteo - 1
    '    ReDim objDocumentoCompraDetalle(conteo)

    '    Dim objLiquidacionNueva As New HeliosService.TotalesLiquidacionEO()

    '    Try
    '        Dim S As Integer = 0
    '        'For S = 0 To conteo

    '        objpresupuestoDet = New HeliosService.DetalleActividadPlaneacionBO()
    '        objpresupuestoDet.idProyecto = cIdProyecto
    '        objpresupuestoDet.IdEstrategia = cIdEstrategia
    '        objpresupuestoDet.IdProceso = cIdProceso

    '        objpresupuestoDet.idTarea = cIdTarea
    '        objpresupuestoDet.NombreTarea = cNomTarea

    '        objpresupuestoDet.CodigoDetalle = lblId.Text


    '        'Select Case dgvIngresos.Rows(S).Cells(1).Value()
    '        '    Case "EXIS."
    '        '        objpresupuestoDet.TipoGrav = tipoItemPlan.EXIS
    '        '    Case "SERV."
    '        '        objpresupuestoDet.TipoGrav = tipoItemPlan.SERV
    '        '      Case "ING."
    '        objpresupuestoDet.TipoGrav = "3" 'tipoItemPlan.ING
    '        ' End Select

    '        objpresupuestoDet.Tipo = IIf(chSinMov.Checked = True, "SM", "ING.")
    '        objpresupuestoDet.Descripcion = txtItem.Text.Trim ' dgvIngresos.Rows(S).Cells(2).Value()
    '        objpresupuestoDet.Composicion = txtIdItem.Text.Trim ' dgvIngresos.Rows(S).Cells(3).Value()
    '        objpresupuestoDet.Talla = txtDetalle.Text.Trim ' dgvIngresos.Rows(S).Cells(4).Value()
    '        objpresupuestoDet.Color = Nothing ' dgvIngresos.Rows(S).Cells(5).Value()
    '        objpresupuestoDet.Lote = Nothing ' dgvIngresos.Rows(S).Cells(6).Value()
    '        objpresupuestoDet.Presentacion = Nothing ' dgvIngresos.Rows(S).Cells(7).Value()
    '        objpresupuestoDet.UnidadMedida = cboUM.SelectedValue  ' dgvIngresos.Rows(S).Cells(8).Value()
    '        objpresupuestoDet.Cantidad = nudCan.Value ' dgvIngresos.Rows(S).Cells(9).Value()
    '        objpresupuestoDet.PrecioUnit = nudPU.Value ' dgvIngresos.Rows(S).Cells(10).Value()
    '        objpresupuestoDet.CostoDirecto = nudCostoDirecto.Value ' dgvIngresos.Rows(S).Cells(11).Value()
    '        objpresupuestoDet.PorGastosGenerales = nudPorcGastos.Value ' dgvIngresos.Rows(S).Cells(12).Value()
    '        objpresupuestoDet.GastosGenerales = nudGastosGen.Value ' dgvIngresos.Rows(S).Cells(13).Value()
    '        objpresupuestoDet.PorUtilidad = nudPorcUti.Value ' dgvIngresos.Rows(S).Cells(14).Value()
    '        objpresupuestoDet.Utilidad = nudUti.Value ' dgvIngresos.Rows(S).Cells(15).Value()
    '        objpresupuestoDet.PorOtrosIn1 = 0 ' dgvIngresos.Rows(S).Cells(16).Value()
    '        objpresupuestoDet.OtrosIn1 = nudOtros1.Value ' dgvIngresos.Rows(S).Cells(17).Value()
    '        objpresupuestoDet.ValorVenta = nudValorVenta.Value ' dgvIngresos.Rows(S).Cells(18).Value()
    '        objpresupuestoDet.PorIgv = nudPorIGV.Value ' dgvIngresos.Rows(S).Cells(19).Value()
    '        objpresupuestoDet.Igv = nudIGV.Value ' dgvIngresos.Rows(S).Cells(20).Value()

    '        objpresupuestoDet.TotalProyecto = nudTotalProyecto.Value ' dgvIngresos.Rows(S).Cells(21).Value()
    '        objpresupuestoDet.PorPercep = nudPorcPerc.Value ' dgvIngresos.Rows(S).Cells(22).Value()
    '        objpresupuestoDet.Percepciones = nudPerc.Value ' dgvIngresos.Rows(S).Cells(23).Value()
    '        objpresupuestoDet.PorOtrosIn2 = 0 ' dgvIngresos.Rows(S).Cells(24).Value()
    '        objpresupuestoDet.OtrosIn2 = nudOtros2.Value ' dgvIngresos.Rows(S).Cells(25).Value()
    '        objpresupuestoDet.TotalPorCobrar = nudTotalCobrar.Value ' dgvIngresos.Rows(S).Cells(26).Value()
    '        objpresupuestoDet.PorDetracciones = nudPorcDetra.Value ' dgvIngresos.Rows(S).Cells(27).Value()
    '        objpresupuestoDet.Detracciones = nudDetra.Value ' dgvIngresos.Rows(S).Cells(28).Value()
    '        objpresupuestoDet.PorRetenciones = nudPorcReten.Value ' dgvIngresos.Rows(S).Cells(29).Value()
    '        objpresupuestoDet.Retenciones = nudReten.Value ' dgvIngresos.Rows(S).Cells(30).Value()
    '        objpresupuestoDet.PorOtroIn3 = 0 ' dgvIngresos.Rows(S).Cells(31).Value()
    '        objpresupuestoDet.OtroIn3 = nudOtros3.Value ' dgvIngresos.Rows(S).Cells(32).Value()
    '        objpresupuestoDet.NetoCobrar = nudNetoCobrar.Value ' dgvIngresos.Rows(S).Cells(33).Value()
    '        objpresupuestoDet.Porcentaje = nudPorcentaje.Value ' dgvIngresos.Rows(S).Cells(34).Value()
    '        objpresupuestoDet.Estado = "1" ' dgvIngresos.Rows(S).Cells(35).Value()
    '        objpresupuestoDet.TipoPresupuesto = "INGRESOS"

    '        objpresupuestoDet.GrupoOperacional = "0" ' dgvIngresos.Rows(S).Cells(36).Value()
    '        objpresupuestoDet.IdPersonal = 0 ' dgvIngresos.Rows(S).Cells(37).Value()
    '        objpresupuestoDet.FechaInicioGop = Nothing ' dgvIngresos.Rows(S).Cells(39).Value()
    '        objpresupuestoDet.FechaFinGop = Nothing 'dgvIngresos.Rows(S).Cells(40).Value()
    '        objpresupuestoDet.HoraInicioGop = Nothing ' dgvIngresos.Rows(S).Cells(41).Value()
    '        objpresupuestoDet.HoraFinGop = Nothing ' dgvIngresos.Rows(S).Cells(42).Value()
    '        objpresupuestoDet.OcurrenciasGop = Nothing ' dgvIngresos.Rows(S).Cells(43).Value()


    '        If xTipoProyecto = TIPO_PROYECTO.PLANEAMIENTO Then
    '            objpresupuestoDet.TipoPlan = TIPO_PROYECTO.PLANEAMIENTO
    '        ElseIf xTipoProyecto = TIPO_PROYECTO.REAL Then
    '            objpresupuestoDet.TipoPlan = TIPO_PROYECTO.REAL
    '        End If

    '        objDocumentoCompraDetalle(S) = objpresupuestoDet

    '        '  Next S
    '        objpresupuesto.actividadDetalle = objDocumentoCompraDetalle


    '        '-----------------------------------------------------------------------------

    '        objLiquidacionNueva = New HeliosService.TotalesLiquidacionEO()

    '        objLiquidacionNueva.IdEmpresa = CEmpresa
    '        objLiquidacionNueva.IdEstablecimiento = CEstablecimiento
    '        objLiquidacionNueva.IdProyecto = cIdProyecto
    '        objLiquidacionNueva.IdEstrategia = cIdEstrategia
    '        objLiquidacionNueva.IdProceso = cIdProceso
    '        objLiquidacionNueva.IdTarea = cIdTarea
    '        objLiquidacionNueva.TipoLiquidacion = "INGRESOS"
    '        objLiquidacionNueva.Otros = "INGRESOS"
    '        objLiquidacionNueva.Modulo = "N"
    '        objLiquidacionNueva.Fecha = Date.Now.Date

    '        objLiquidacionNueva.LI_ib_ini = nudIGV.Value  'IGV
    '        objLiquidacionNueva.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini

    '        objLiquidacionNueva.LI_ib_ns = nudIGV.Value 'IGV
    '        objLiquidacionNueva.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns

    '        objLiquidacionNueva.LI_ib_adic = nudIGV.Value 'IGV
    '        objLiquidacionNueva.LI_afAcum_adic = 0 ' i.LI_afAcum_adic

    '        'segundo reporte
    '        objLiquidacionNueva.LR_ventan_ini = nudValorVenta.Value
    '        objLiquidacionNueva.LR_ventan_ns = nudValorVenta.Value
    '        objLiquidacionNueva.LR_ventan_adic = nudValorVenta.Value

    '        'otros reportes
    '        '***********************************************************
    '        objLiquidacionNueva.detraccion_ini = nudDetra.Value
    '        objLiquidacionNueva.detraccion_ns = nudDetra.Value
    '        objLiquidacionNueva.detraccion_adic = nudDetra.Value

    '        'ANALISIS FINANCIERO
    '        '---------------------------------------------------------------
    '        objLiquidacionNueva.AF_EjecucionIng_ini = nudTotalProyecto.Value
    '        objLiquidacionNueva.AF_EjecucionIng_ns = nudTotalProyecto.Value
    '        objLiquidacionNueva.AF_EjecucionIng_adic = nudTotalProyecto.Value

    '        objLiquidacionNueva.AF_Percepcion_ini = nudPerc.Value
    '        objLiquidacionNueva.AF_Percepcion_ns = nudPerc.Value
    '        objLiquidacionNueva.AF_Percepcion_adic = nudPerc.Value

    '        objLiquidacionNueva.AF_Otrosps_ini = nudOtros2.Value
    '        objLiquidacionNueva.AF_Otrosps_ns = nudOtros2.Value
    '        objLiquidacionNueva.AF_Otrosps_adic = nudOtros2.Value

    '        objLiquidacionNueva.AF_Detraccion_ini = nudDetra.Value
    '        objLiquidacionNueva.AF_Detraccion_ns = nudDetra.Value
    '        objLiquidacionNueva.AF_Detraccion_adic = nudDetra.Value

    '        objLiquidacionNueva.AF_Retencion_ini = nudReten.Value
    '        objLiquidacionNueva.AF_Retencion_ns = nudReten.Value
    '        objLiquidacionNueva.AF_Retencion_adic = nudReten.Value

    '        objLiquidacionNueva.AF_Otrosng_ini = nudOtros3.Value
    '        objLiquidacionNueva.AF_Otrosng_ns = nudOtros3.Value
    '        objLiquidacionNueva.AF_Otrosng_adic = nudOtros3.Value

    '        objLiquidacionNueva.TotalIngresos = nudTotalProyecto.Value

    '        If xTipoProyecto = TIPO_PROYECTO.PLANEAMIENTO Then
    '            objLiquidacionNueva.TipoPlan = TIPO_PROYECTO.PLANEAMIENTO
    '        ElseIf xTipoProyecto = TIPO_PROYECTO.REAL Then
    '            objLiquidacionNueva.TipoPlan = TIPO_PROYECTO.REAL
    '        End If

    '        objLiquidacionNueva.UsuarioActualizacion = cIDUsuario
    '        objLiquidacionNueva.FechaActualizacion = Date.Now


    '        '********************************** ELIMINANDO ***********************************************
    '        Dim objActividadDeleteEO As New HeliosService.TotalesLiquidacionEO()
    '        ' Dim objNuevaActividadEO As New HeliosService.TotalesLiquidacionEO()

    '        With objActividadDeleteEO
    '            .IdEmpresa = CEmpresa
    '            .IdEstablecimiento = CEstablecimiento
    '            .IdProyecto = cIdProyecto
    '            .IdEstrategia = cIdEstrategia
    '            .IdProceso = cIdProceso
    '            .IdTarea = cIdTarea
    '            '  .NombreTarea = cNomTarea

    '            .Secuencia = lblId.Text
    '            If xTipoProyecto = TIPO_PROYECTO.PLANEAMIENTO Then
    '                .TipoPlan = TIPO_PROYECTO.PLANEAMIENTO
    '            ElseIf xTipoProyecto = TIPO_PROYECTO.REAL Then
    '                .TipoPlan = TIPO_PROYECTO.REAL
    '            End If

    '            .TipoLiquidacion = "INGRESOS"
    '            .Otros = "INGRESOS"
    '        End With

    '        'INGRESANDO NUEVO REGISTRO

    '        If objService.GabrarELimIngresos_TotalesLiquidacion(objpresupuesto, objLiquidacionNueva, objActividadDeleteEO) Then
    '            '     MsgBox("Registro eliminado correctamente!", MsgBoxStyle.Information, "Congratulations!")
    '            Dispose()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al eliminar registro." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
    '    End Try

    'End Sub
#End Region

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'Call MostrarCanasta()
    End Sub

    'Sub MostrarCanasta()
    '    With frmCanastaPlaneamiento
    '        '  .RadioButton1.Checked = True
    '        .RbExistencia.Visible = False
    '        .rbServicio.Visible = False
    '        .ObtenerEstablecimientos()
    '        .cboEstablecimiento.SelectedValue = CEstablecimiento
    '        Dim datos As List(Of recuperaCanastaPlaneamiento) = recuperaCanastaPlaneamiento.Instance()
    '        datos.Clear()

    '        .StartPosition = FormStartPosition.CenterParent
    '        .RadioButton1.Checked = True
    '        '.TabPage1.Parent = Nothing
    '        '.TabPage2.Parent = Nothing
    '        '.TabPage3.Parent = TabControl1
    '        .ShowDialog()

    '        If datos.Count > 0 Then
    '            txtIdItem.Text = datos(0).m_Dato3
    '            txtItem.Text = datos(0).m_Dato4
    '        Else
    '            txtIdItem.Text = String.Empty
    '            txtItem.Text = String.Empty
    '        End If
    ''    End With
    'End Sub

    Private Sub frmModalIngresos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalIngresos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDetalle.Select()
    End Sub

    Sub calculos()
        Dim CostoDirecto As Decimal = 0
        Dim GastosGenerales As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim ValorVenta As Decimal = 0
        Dim IGV As Decimal = 0

        Dim TotalProyecto As Decimal = 0
        Dim Percepcion As Decimal = 0
        Dim TotalCobrar As Decimal = 0
        Dim Detraccion As Decimal = 0
        Dim Retencion As Decimal = 0
        Dim NetoCobrar As Decimal = 0

        Dim cantidad As Decimal = 0
        cantidad = nudCan.Value

        Dim pu As Decimal = 0
        pu = nudPU.Value

        CostoDirecto = 0 ' Math.Round(cantidad * pu, 2)

        nudCostoDirecto.Value = CostoDirecto
        GastosGenerales = 0 ' Math.Round(CostoDirecto * (nudPorcGastos.Value / 100), 2)
        nudGastosGen.Value = GastosGenerales

        Utilidad = 0 ' Math.Round(CostoDirecto * (nudPorcUti.Value / 100), 2)
        nudUti.Value = Utilidad

        '   TotalProyecto = Math.Round(IGV + ValorVenta, 2)
        TotalProyecto = Math.Round(cantidad * pu, 2)
        nudTotalProyecto.Value = TotalProyecto

        ' ValorVenta = Math.Round(nudOtros1.Value + Utilidad + GastosGenerales + CostoDirecto, 2)
        ValorVenta = Math.Round(TotalProyecto / (1 + (nudPorIGV.Value / 100)), 2)
        nudValorVenta.Value = ValorVenta

        IGV = Math.Round(ValorVenta * (nudPorIGV.Value / 100), 2)
        nudIGV.Value = IGV

        Percepcion = Math.Round(TotalProyecto * (nudPorcPerc.Value / 100), 2)
        nudPerc.Value = Percepcion

        TotalCobrar = Math.Round(TotalProyecto + Percepcion + nudOtros2.Value, 2)
        nudTotalCobrar.Value = TotalCobrar

        Detraccion = Math.Round(TotalCobrar * (nudPorcDetra.Value / 100), 2)
        nudDetra.Value = Detraccion

        Retencion = Math.Round(TotalProyecto * (nudPorcReten.Value / 100), 2)
        nudReten.Value = Retencion

        NetoCobrar = Math.Round(TotalCobrar - Detraccion - Retencion - nudOtros3.Value, 2)
        nudNetoCobrar.Value = NetoCobrar
    End Sub

    Private Sub nudCan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudCan.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudPU.Focus()
            nudPU.Select(0, nudPU.Text.Length)
        End If
    End Sub

    Private Sub nudCan_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nudCan.MouseClick
        nudCan.Select(0, nudCan.Text.Length)
    End Sub

    Private Sub nudCan_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudCan.ValueChanged
        calculos()
    End Sub

    Private Sub nudPU_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudPU.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudPorcPerc.Focus()
            nudPorcPerc.Select(0, nudPorcPerc.Text.Length)
        End If
    End Sub

    Private Sub nudPU_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nudPU.MouseClick
        nudPU.Select(0, nudPU.Text.Length)
    End Sub

    Private Sub nudPU_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPU.ValueChanged
        calculos()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        If txtItem.Text.Trim.Length > 0 Then
            'If XManipulacion = Manipulacion.Nuevo Then
            '    'saveIngreso()
            'ElseIf XManipulacion = Manipulacion.Editar Then
            '    '    UpdateIngreso()
            '    'eliminarINGRESO()
            'End If
        Else
            MsgBox("Ingrese el nombre del item.", MsgBoxStyle.Information, "Atención!")
            txtItem.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TabPage1_Click(sender As System.Object, e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub nudDetra_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudDetra.ValueChanged
        calculos()
    End Sub

    Private Sub nudReten_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudReten.ValueChanged
        calculos()
    End Sub

    Private Sub nudPerc_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPerc.ValueChanged
        calculos()
    End Sub

    Private Sub nudPorcPerc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudPorcPerc.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudPorcDetra.Focus()
            nudPorcDetra.Select(0, nudPorcDetra.Text.Length)
        End If
    End Sub

    Private Sub nudPorcPerc_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPorcPerc.ValueChanged
        calculos()
    End Sub

    Private Sub nudPorcReten_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudPorcReten.KeyDown
      
    End Sub

    Private Sub nudPorcReten_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPorcReten.ValueChanged
        calculos()
    End Sub

    Private Sub nudPorcDetra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudPorcDetra.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudPorcReten.Focus()
            nudPorcReten.Select(0, nudPorcReten.Text.Length)
        End If
    End Sub

    Private Sub nudPorcDetra_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPorcDetra.ValueChanged
        calculos()
    End Sub

    Private Sub nudPorIGV_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPorIGV.ValueChanged
        calculos()
    End Sub

    Private Sub txtDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDetalle.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtUM.Focus()
            txtUM.Select(0, txtUM.Text.Length)
        End If
    End Sub

    Private Sub chSinMov_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chSinMov.CheckedChanged
        If chSinMov.Checked = True Then
            'txtItem.Enabled = False
            txtItem.Text = "- Sin movimiento -"
            txtDetalle.Text = "- Sin movimiento -"
            txtIdItem.Text = "00"
            '  txtTipoPlan.Text = "SM"
            gbx1.Enabled = False
            LimpiarCajas(gbx1)
            LinkLabel2.Enabled = False
            txtDetalle.Focus()
            txtUM.Enabled = False
            txtCodigoDetalle.Enabled = False
            txtDetalle.Select(0, txtDetalle.Text.Length)
        Else
            '    txtItem.Enabled = True
            txtItem.Clear()
            txtDetalle.Clear()
            txtIdItem.Clear()
            '  txtTipoPlan.Clear()
            txtItem.Text = "VENTAS"
            txtIdItem.Text = "70"
            gbx1.Enabled = True
            txtUM.Enabled = True
            txtCodigoDetalle.Enabled = True
            LimpiarCajas(gbx1)
            LinkLabel2.Enabled = True
            nudPorIGV.Value = 18
        End If
    End Sub

    Private Sub txtBusqueda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            'ObtenerPorEventoFiltro(cIdEstrategia, txtBusqueda.Text.Trim, Filtro.PorCodigo)
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case XManipulacion
            Case ENTITY_ACTIONS.INSERT
                IngresoPlanificacion()
            Case ENTITY_ACTIONS.UPDATE
                UpdateIngresoPlanificacion()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtUM_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUM.KeyDown
        Dim objServiceSA As New tablaDetalleSA
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtUM.AutoCompleteCustomSource.Contains(txtUM.Text.Trim) Then
                lblEstado.Text = "Ingreso correcto - Unidad Medida"
                lblEstado.Image = My.Resources.ok4
                lblEstado.Tag = "H"
                If lblEstado.Tag = "H" Then
                    e.SuppressKeyPress = True
                    txtCodigoDetalle.Text = objServiceSA.GetListaTablaID(txtUM.Text)
                    nudCan.Select(0, nudCan.Text.Length)
                    nudCan.Focus()
                End If
            Else
                Dim result As Integer = MessageBox.Show("¿Desea registrar nueva UM?", "Unidad Medida", MessageBoxButtons.YesNo)
                Select Case result
                    Case DialogResult.No
                        lblEstado.Text = "Elija una correcta Unidad Medida"
                        lblEstado.Image = My.Resources.warning2
                        txtUM.Text = ""
                        txtUM.Select(0, txtUM.Text.Length)
                        txtUM.Focus()
                    Case DialogResult.Yes
                        'With frmModalUM
                        '    .actyon = ENTITY_ACTIONS.INSERT
                        '    .Tag = "MS"
                        '    .txtCodigoDetalle.Text = objServiceSA.ObtenerTablaMaximo + 1
                        '    .txtDescipcionUM.Text = txtUM.Text
                        '    .txtDescipcionUM.Select(0, .txtDescipcionUM.Text.Length)
                        '    .txtDescipcionUM.Focus()
                        '    .StartPosition = FormStartPosition.CenterParent
                        '    .ShowDialog()
                        'End With
                End Select
            End If
        ElseIf (e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete) Then
            txtCodigoDetalle.Text = ""
        End If
    End Sub
End Class