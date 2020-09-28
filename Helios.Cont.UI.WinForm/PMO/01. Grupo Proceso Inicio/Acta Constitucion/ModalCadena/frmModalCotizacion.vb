Imports Helios.General
Imports Helios.Cont.Business.Entity
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalCotizacion
    Public Property actyon As String
#Region "Métodos"

    Sub ComboTipoExistencia()
        lblTipoExist.Visible = True
        cboTipoExist.Visible = True
        Dim dtEstab As New DataTable()
        Try
            dtEstab.Columns.Add("ID")
            dtEstab.Columns.Add("Nombre")

            dtEstab.Rows.Add("01", "MERCADERIA")
            dtEstab.Rows.Add("03", "MATERIA PRIMA")
            dtEstab.Rows.Add("04", "ENVASES Y EMBALAJES")
            dtEstab.Rows.Add("05", "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS")

            cboTipoExist.DisplayMember = "Nombre"
            cboTipoExist.ValueMember = "ID"
            cboTipoExist.DataSource = dtEstab

            cboTipoExist.DisplayMember = "Nombre"
            cboTipoExist.ValueMember = "idCentroCosto"
            cboTipoExist.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Sub Calculos2()
        Dim Costo As Decimal = 0
        Dim NoSustenta As Decimal = 0
        Dim Porcentaje As Decimal = 0
        Dim IGV As Decimal = 0
        Dim Total As Decimal = 0


        '
        '-------------------------
        Dim TotalCosto As Decimal = 0
        Dim TotalDeduc As Decimal = 0
        Dim NetoAPagar As Decimal = 0
        Dim TotalAporte As Decimal = 0
        Dim TotalRetenAport As Decimal = 0

        Dim cantidad As Decimal = 0
        cantidad = nudCan.Value
        Dim pu As Decimal = 0
        pu = nudPU.Value

        TotalCosto = Math.Round(cantidad * pu, 2)
        nudTotalCosto.Value = TotalCosto




        Select Case txtRefSustento.Text
            Case TipoReferenciaSustento.COSTO_IGV
                Costo = Math.Round(TotalCosto / 1.18, 2)
                NoSustenta = 0
                Porcentaje = 0
                IGV = Math.Round(Costo * 0.18, 2)
                Total = Math.Round(Costo + IGV + NoSustenta + Porcentaje, 2)

                nudCosto.Value = Costo
                nudNoSustenta.Value = NoSustenta
                nudMontoPorcentaje.Value = Porcentaje
                nudIgv.Value = IGV
                nudTotal.Value = Total

                TotalDeduc = Math.Round(nudOtros1.Value + nudDeducPlanilla.Value, 2)
                nudTotalDeduc.Value = TotalDeduc

                NetoAPagar = Math.Round(nudTotal.Value - TotalDeduc, 2)
                nudNetoPagar.Value = NetoAPagar

                TotalAporte = Math.Round(nudOtros2.Value + nudAporPlanilla.Value, 2)
                nudTotalAporte.Value = TotalAporte

                TotalRetenAport = Math.Round(nudTotalDeduc.Value + nudTotalAporte.Value, 2)
                nudTotalRetenApor.Value = TotalRetenAport

            Case TipoReferenciaSustento.SOLO_COSTO
                Costo = Math.Round(TotalCosto, 2)
                NoSustenta = 0
                Porcentaje = 0
                IGV = 0
                Total = Math.Round(Costo + IGV + NoSustenta + Porcentaje, 2)
                nudCosto.Value = Costo
                nudNoSustenta.Value = NoSustenta
                nudMontoPorcentaje.Value = Porcentaje
                nudIgv.Value = IGV
                nudTotal.Value = Total

                TotalDeduc = Math.Round(nudOtros1.Value + nudDeducPlanilla.Value, 2)
                nudTotalDeduc.Value = TotalDeduc

                NetoAPagar = Math.Round(nudTotal.Value - TotalDeduc, 2)
                nudNetoPagar.Value = NetoAPagar

                TotalAporte = Math.Round(nudOtros2.Value + nudAporPlanilla.Value, 2)
                nudTotalAporte.Value = TotalAporte

                TotalRetenAport = Math.Round(nudTotalDeduc.Value + nudTotalAporte.Value, 2)
                nudTotalRetenApor.Value = TotalRetenAport
            Case TipoReferenciaSustento.NO_SUSTENTADO
                Costo = 0
                NoSustenta = Math.Round(TotalCosto, 2)
                Porcentaje = 0
                IGV = 0
                Total = Math.Round(Costo + IGV + NoSustenta + Porcentaje, 2)
                nudCosto.Value = Costo
                nudNoSustenta.Value = NoSustenta
                nudMontoPorcentaje.Value = Porcentaje
                nudIgv.Value = IGV
                nudTotal.Value = Total

                TotalDeduc = Math.Round(nudOtros1.Value + nudDeducPlanilla.Value, 2)
                nudTotalDeduc.Value = TotalDeduc

                NetoAPagar = Math.Round(nudTotal.Value - TotalDeduc, 2)
                nudNetoPagar.Value = NetoAPagar

                TotalAporte = Math.Round(nudOtros2.Value + nudAporPlanilla.Value, 2)
                nudTotalAporte.Value = TotalAporte

                TotalRetenAport = Math.Round(nudTotalDeduc.Value + nudTotalAporte.Value, 2)
                nudTotalRetenApor.Value = TotalRetenAport
        End Select

    End Sub

    Sub Grabar()
        Dim recursoSA As New actividadRecursoSA
        Dim objrecurso As New actividadRecurso
        Dim intIdRecursoActividad As Integer
        Dim actividadSA As New ActividadesSA
        Dim actividad As New Actividades
        Dim tipRec As String = Nothing
        Dim tipCuenta As String = Nothing
        Dim objLiquidacionDet As New totalesLiquidacion()
        Select Case txtTipoRecurso.Text
            Case "EXISTENCIA"
                tipRec = TipoRecurso.EXISTENCIA
                Select Case cboTipoExist.SelectedValue
                    Case "01"
                        tipCuenta = "601111"
                    Case "03"
                        tipCuenta = "601111"
                    Case "04"
                        tipCuenta = "604111"
                    Case "05"
                        tipCuenta = "603111"
                End Select

            Case "SERVICIO-CONTRATO"
                tipRec = TipoRecurso.SERVICIO
                tipCuenta = "63"
            Case "RECURSOS HUMANOS"
                tipRec = TipoRecurso.RECURSOS_HUMANOS
                tipCuenta = "62"
            Case TipoRecurso.TAREA_OPERACIONAL
                tipRec = TipoRecurso.TAREA_OPERACIONAL
        End Select
        '   actividad = actividadSA.GetUbicaProyectoActividad(GProyectos.IdProyecto)
        objrecurso = New actividadRecurso With {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .Idempresa = Gempresas.IdEmpresaRuc,
        .IdEstablecimiento = GEstableciento.IdEstablecimiento,
        .idProyecto = GProyectos.IdProyectoActividad,
        .idActividad = GProyectos.IdProyecto,
        .tipoActividad = "PY",
        .idTipoExistencia = cboTipoExist.SelectedValue,
        .Clasificacion = txtClasificacion.Text,
        .fechaIngreso = txtFechaIngreso.Value,
        .TipoRecurso = tipRec,
        .cuentaContable = tipCuenta,
        .Descripcion = txtItem.Text,
        .detalleExtra = txtDetalle.Text,
        .tipoPlan = "A",
        .ReferenciaSustento = txtRefSustento.Text,
        .unidadMedida = txtCodigoDetalle.Text,
               .ValorMercadoPu = nudPU.Value,
               .CantRequerida = nudCan.Value,
               .TotalCosto = nudTotalCosto.Value,
               .OtrosDeduc = 0,
               .DeducPlanilla = 0,
               .TotalDeduc = 0,
               .NetoPagar = nudNetoPagar.Value,
               .Otros1 = 0,
               .AporPlanilla = 0,
               .TotalAporte = 0,
               .TotalRetenciones = 0,
               .PorIgv = nudTasaIGV.Value,
               .Costo = nudCosto.Value,
               .NoSustentado = nudNoSustenta.Value,
               .Porcentaje = nudMontoPorcentaje.Value,
               .Igv = nudIgv.Value,
               .PsptoReferencial = nudPstoRef.Value,
               .Total = nudTotal.Value,
               .TipoPresupuesto = "INCIDENCIA DIRECTA",
               .Sustentado = "C"}

        objrecurso.actividadRecursoCalculo = New actividadRecursoCalculo() With {
        .laborDiaria = nudLaborDiaria.Value,
        .hm = nudCantHH.Value,
        .porcentaje = nudPorcentaje.Value,
        .dias = nudDias.Value,
        .costoUnithh = nudCostoUnitHH.Value,
        .cant = nudCant.Value,
        .costoUnit = nudCostoUnit.Value,
        .costoDirecto1 = nudCostoDirecto1.Value,
        .costoDirecto2 = nudCostoDirecto2.Value,
        .ggPorc = nudGGPorc.Value,
        .ggImporte = nudGGImporte.Value,
        .utPorc = nudUTPorc.Value,
        .utImporte = nudUTImporte.Value,
        .costoFinal = nudCostoFinal.Value,
        .igvPorc = nudIgvPor.Value,
        .igvImporte = nudIgvImporte.Value,
        .precioFinal = nudPrecioFinal.Value,
        .cantFinal = nudCanFinal.Value,
        .precUnitFinal = nudPUFinal.Value}

        'LIQUIDACION INSERT
        objLiquidacionDet = New totalesLiquidacion()

        objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
        objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
        objLiquidacionDet.idActividad = GProyectos.IdProyecto
        objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
        objLiquidacionDet.Otros = "CADIN"
        objLiquidacionDet.modulo = "N"
        objLiquidacionDet.Fecha = DateTime.Now.Date

        objLiquidacionDet.LI_ib_ini = 0 ' nudIgv.Value  'IGV
        objLiquidacionDet.LI_cfAcum_ini = nudIgv.Value 'i.LI_cfAcum_ini

        objLiquidacionDet.LI_ib_ns = 0 'nudIgv.Value 'IGV
        objLiquidacionDet.LI_cfAcum_ns = nudIgv.Value ' i.LI_cfAcum_ns

        objLiquidacionDet.LI_ib_adic = 0 ' nudIgv.Value 'IGV
        objLiquidacionDet.LI_afAcum_adic = nudIgv.Value ' i.LI_afAcum_adic

        objLiquidacionDet.RefSustento1 = txtRefSustento.Text 'i.LI_cfAcum_ini

        'segundo reporte
        objLiquidacionDet.LR_costov_ini = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
        objLiquidacionDet.LR_costov_ns = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
        objLiquidacionDet.LR_costov_adic = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)

        '3er reporte
        objLiquidacionDet.LOO_ReDeAp_ini = nudTotalRetenApor.Value
        objLiquidacionDet.LOO_ReDeAp_ns = nudTotalRetenApor.Value
        objLiquidacionDet.LOO_ReDeAp_adic = nudTotalRetenApor.Value

        'ANALISIS FINANCIERO
        Select Case txtRefSustento.Text
            Case TipoReferenciaSustento.COSTO_IGV, TipoReferenciaSustento.SOLO_COSTO
                objLiquidacionDet.AF_TotalPagoProvSust_ini = nudNetoPagar.Value
                objLiquidacionDet.AF_TotalPagoProvSust_ns = nudNetoPagar.Value
                objLiquidacionDet.AF_TotalPagoProvSust_adic = nudNetoPagar.Value
            Case TipoReferenciaSustento.NO_SUSTENTADO
                objLiquidacionDet.AF_TotalPagoProvSust_ini = 0.0
                objLiquidacionDet.AF_TotalPagoProvSust_ns = 0.0
                objLiquidacionDet.AF_TotalPagoProvSust_adic = 0.0
        End Select

        'no sustentados
        objLiquidacionDet.AF_RefGastoNoSust_ini = nudNoSustenta.Value
        objLiquidacionDet.AF_RefGastoNoSust_ns = nudNoSustenta.Value
        '     objLiquidacionDet.AF_RefGastoNoSust_adic = nudNoSustenta.Value

        objLiquidacionDet.LP_TotalPagoProvCSSust_ini = nudNetoPagar.Value
        objLiquidacionDet.LP_TotalPagoProvCSSust_ns = nudNetoPagar.Value
        objLiquidacionDet.LP_TotalPagoProvCSSust_adic = nudNetoPagar.Value

        objLiquidacionDet.tipoPlan = "A"

        objLiquidacionDet.usuarioActualizacion = "NN"
        objLiquidacionDet.fechaActualizacion = DateTime.Now

        '   End With
        intIdRecursoActividad = recursoSA.SaveRecursoCotizacion(objrecurso, objLiquidacionDet)
        lblEstado.Text = "Cotización agregada!"
        lblEstado.Image = My.Resources.ok4

        With frmActaConstitucionMaster.dgvPropuesta
            .Rows.Add(txtFechaIngreso.Value, intIdRecursoActividad, txtItem.Text, txtDetalle.Text,
                      txtUM.Text, nudLaborDiaria.Value, nudCantHH.Value, nudPorcentaje.Value,
                      nudDias.Value, nudCostoUnitHH.Value, nudCant.Value, nudCostoUnit.Value,
                      nudCostoDirecto1.Value, nudCostoDirecto2.Value, nudGGPorc.Value, nudGGImporte.Value,
                       nudUTPorc.Value, nudUTImporte.Value, nudCostoFinal.Value, nudIgvPor.Value, nudIgvImporte.Value,
                        nudPrecioFinal.Value, nudCanFinal.Value, nudPUFinal.Value, txtRefSustento.Text, txtClasificacion.Text)

        End With
        Dispose()
    End Sub

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

    Public Sub ObtenerClasificacion()
        Dim objServiceSA As New itemSA
        Dim ACTDBSuggestions As New AutoCompleteStringCollection()
        Try
            For Each i In objServiceSA.ObtenerItemsFull()
                ACTDBSuggestions.Add(i)
            Next

            txtClasificacion.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtClasificacion.AutoCompleteCustomSource = ACTDBSuggestions
            txtClasificacion.AutoCompleteMode = AutoCompleteMode.Suggest

        Catch ex As Exception
            lblEstado.Text = "No se pudo cargar la información para la lista de EF."
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Sub Editar()
        Dim recursoSA As New actividadRecursoSA
        Dim objrecurso As New actividadRecurso
        Dim actividadSA As New ActividadesSA
        Dim tipRec As String = Nothing
        Dim tipCuenta As String = Nothing
        Dim ObjLiquidacionNueva As New totalesLiquidacion()
        Dim objActividadDeleteEO As New totalesLiquidacion()
        Select Case txtTipoRecurso.Text
            Case "EXISTENCIA"
                tipRec = TipoRecurso.EXISTENCIA
                Select Case cboTipoExist.SelectedValue
                    Case "01"
                        tipCuenta = "601111"
                    Case "03"
                        tipCuenta = "601111"
                    Case "04"
                        tipCuenta = "604111"
                    Case "05"
                        tipCuenta = "603111"
                End Select
            Case "SERVICIO-CONTRATO"
                tipRec = TipoRecurso.SERVICIO
                tipCuenta = "63"
            Case "RECURSOS HUMANOS"
                tipRec = TipoRecurso.RECURSOS_HUMANOS
                tipCuenta = "62"
            Case TipoRecurso.TAREA_OPERACIONAL
                tipRec = TipoRecurso.TAREA_OPERACIONAL
        End Select
        '   actividad = actividadSA.GetUbicaProyectoActividad(GProyectos.IdProyecto)
        objrecurso = New actividadRecurso With {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .idActividadRecurso = lblId.Text,
        .Idempresa = Gempresas.IdEmpresaRuc,
        .IdEstablecimiento = GEstableciento.IdEstablecimiento,
         .idProyecto = GProyectos.IdProyectoActividad,
        .idActividad = GProyectos.IdProyecto,
        .tipoActividad = "PY",
        .fechaIngreso = txtFechaIngreso.Value,
        .TipoRecurso = tipRec,
        .idTipoExistencia = cboTipoExist.SelectedValue,
        .Clasificacion = txtClasificacion.Text,
        .cuentaContable = tipCuenta,
        .Descripcion = txtItem.Text,
        .detalleExtra = txtDetalle.Text,
        .ReferenciaSustento = txtRefSustento.Text,
        .unidadMedida = txtCodigoDetalle.Text,
               .ValorMercadoPu = nudPU.Value,
               .CantRequerida = nudCan.Value,
               .TotalCosto = nudTotalCosto.Value,
               .OtrosDeduc = 0,
               .DeducPlanilla = 0,
               .TotalDeduc = 0,
               .NetoPagar = nudNetoPagar.Value,
               .Otros1 = 0,
               .AporPlanilla = 0,
               .TotalAporte = 0,
               .TotalRetenciones = 0,
               .PorIgv = nudTasaIGV.Value,
               .Costo = nudCosto.Value,
               .NoSustentado = nudNoSustenta.Value,
               .Porcentaje = nudMontoPorcentaje.Value,
               .Igv = nudIgv.Value,
               .PsptoReferencial = nudPstoRef.Value,
               .Total = nudTotal.Value,
               .TipoPresupuesto = "INCIDENCIA DIRECTA",
               .tipoPlan = "A",
               .Sustentado = "C"}

        objrecurso.actividadRecursoCalculo = New actividadRecursoCalculo() With {
            .idActividadRecurso = lblId.Text,
        .laborDiaria = nudLaborDiaria.Value,
        .hm = nudCantHH.Value,
        .porcentaje = nudPorcentaje.Value,
        .dias = nudDias.Value,
        .costoUnithh = nudCostoUnitHH.Value,
        .cant = nudCant.Value,
        .costoUnit = nudCostoUnit.Value,
        .costoDirecto1 = nudCostoDirecto1.Value,
        .costoDirecto2 = nudCostoDirecto2.Value,
        .ggPorc = nudGGPorc.Value,
        .ggImporte = nudGGImporte.Value,
        .utPorc = nudUTPorc.Value,
        .utImporte = nudUTImporte.Value,
        .costoFinal = nudCostoFinal.Value,
        .igvPorc = nudIgvPor.Value,
        .igvImporte = nudIgvImporte.Value,
        .precioFinal = nudPrecioFinal.Value,
        .cantFinal = nudCanFinal.Value,
        .precUnitFinal = nudPUFinal.Value}
        '   End With


        'UPDATE LIQUIDACION
        ObjLiquidacionNueva = New totalesLiquidacion()

        ObjLiquidacionNueva.idEmpresa = Gempresas.IdEmpresaRuc
        ObjLiquidacionNueva.idEstablecimiento = GEstableciento.IdEstablecimiento
        ObjLiquidacionNueva.idActividad = GProyectos.IdProyecto
        ObjLiquidacionNueva.tipoLiquidacion = "INCIDENCIA DIRECTA"
        ObjLiquidacionNueva.Otros = "CADIN"
        ObjLiquidacionNueva.modulo = "N"
        ObjLiquidacionNueva.Fecha = Date.Now.Date

        ObjLiquidacionNueva.LI_ib_ini = 0 ' nudIgv.Value  'IGV
        ObjLiquidacionNueva.LI_cfAcum_ini = nudIgv.Value 'i.LI_cfAcum_ini

        ObjLiquidacionNueva.LI_ib_ns = 0 'nudIgv.Value 'IGV
        ObjLiquidacionNueva.LI_cfAcum_ns = nudIgv.Value ' i.LI_cfAcum_ns

        ObjLiquidacionNueva.LI_ib_adic = 0 ' nudIgv.Value 'IGV
        ObjLiquidacionNueva.LI_afAcum_adic = nudIgv.Value ' i.LI_afAcum_adic

        ObjLiquidacionNueva.RefSustento1 = txtRefSustento.Text 'i.LI_cfAcum_ini

        'segundo reporte
        ObjLiquidacionNueva.LR_costov_ini = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
        ObjLiquidacionNueva.LR_costov_ns = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
        ObjLiquidacionNueva.LR_costov_adic = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)

        '3er reporte
        ObjLiquidacionNueva.LOO_ReDeAp_ini = nudTotalRetenApor.Value
        ObjLiquidacionNueva.LOO_ReDeAp_ns = nudTotalRetenApor.Value
        ObjLiquidacionNueva.LOO_ReDeAp_adic = nudTotalRetenApor.Value

        'ANALISIS FINANCIERO
        Select Case txtRefSustento.Text
            Case TipoReferenciaSustento.COSTO_IGV, TipoReferenciaSustento.SOLO_COSTO
                ObjLiquidacionNueva.AF_TotalPagoProvSust_ini = nudNetoPagar.Value
                ObjLiquidacionNueva.AF_TotalPagoProvSust_ns = nudNetoPagar.Value
                ObjLiquidacionNueva.AF_TotalPagoProvSust_adic = nudNetoPagar.Value
            Case TipoReferenciaSustento.NO_SUSTENTADO
                ObjLiquidacionNueva.AF_TotalPagoProvSust_ini = 0.0
                ObjLiquidacionNueva.AF_TotalPagoProvSust_ns = 0.0
                ObjLiquidacionNueva.AF_TotalPagoProvSust_adic = 0.0

                'no sustentados
                ObjLiquidacionNueva.AF_RefGastoNoSust_ini = nudNoSustenta.Value
                ObjLiquidacionNueva.AF_RefGastoNoSust_ns = nudNoSustenta.Value
                '    objLiquidacionNueva.AF_RefGastoNoSust_adic = nudNoSustenta.Value

                '   AF_RefGastoNoSust_ns
        End Select

        'Select Case txtRefSustento.Text
        '    Case ReferenciaSustento.COSTO_IGV, ReferenciaSustento.SOLO_COSTO, ReferenciaSustento.NO_SUSTENTADO
        ObjLiquidacionNueva.LP_TotalPagoProvCSSust_ini = nudNetoPagar.Value
        ObjLiquidacionNueva.LP_TotalPagoProvCSSust_ns = nudNetoPagar.Value
        ObjLiquidacionNueva.LP_TotalPagoProvCSSust_adic = nudNetoPagar.Value
        'End Select

        ObjLiquidacionNueva.tipoPlan = "A"

        ObjLiquidacionNueva.usuarioActualizacion = "NN"
        ObjLiquidacionNueva.fechaActualizacion = DateTime.Now


        '********************************** ELIMINANDO ***********************************************
        With objActividadDeleteEO
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .idActividad = GProyectos.IdProyecto
            .secuencia = lblId.Text
            .tipoPlan = "A"
            .tipoLiquidacion = "INCIDENCIA DIRECTA"
            .Otros = "CADIN"
        End With

        If recursoSA.UpdateRecursoCotizacion(objrecurso, objActividadDeleteEO, ObjLiquidacionNueva) Then
            lblEstado.Text = "Cotización modificada!"
            lblEstado.Image = My.Resources.ok4

            With frmActaConstitucionMaster.dgvPropuesta
                .Item(0, .CurrentRow.Index).Value = txtFechaIngreso.Value
                '    .Item(1, .CurrentRow.Index).Value = idRecursoActividad
                .Item(2, .CurrentRow.Index).Value = txtItem.Text
                .Item(3, .CurrentRow.Index).Value = txtDetalle.Text
                .Item(4, .CurrentRow.Index).Value = txtUM.Text
                .Item(5, .CurrentRow.Index).Value = nudLaborDiaria.Value
                .Item(6, .CurrentRow.Index).Value = nudCantHH.Value
                .Item(7, .CurrentRow.Index).Value = nudPorcentaje.Value
                .Item(8, .CurrentRow.Index).Value = nudDias.Value
                .Item(9, .CurrentRow.Index).Value = nudCostoUnitHH.Value
                .Item(10, .CurrentRow.Index).Value = nudCant.Value
                .Item(11, .CurrentRow.Index).Value = nudCostoUnit.Value
                .Item(12, .CurrentRow.Index).Value = nudCostoDirecto1.Value
                .Item(13, .CurrentRow.Index).Value = nudCostoDirecto2.Value
                .Item(14, .CurrentRow.Index).Value = nudGGPorc.Value
                .Item(15, .CurrentRow.Index).Value = nudGGImporte.Value
                .Item(16, .CurrentRow.Index).Value = nudUTPorc.Value
                .Item(17, .CurrentRow.Index).Value = nudUTImporte.Value
                .Item(18, .CurrentRow.Index).Value = nudCostoFinal.Value
                .Item(19, .CurrentRow.Index).Value = nudIgvPor.Value
                .Item(20, .CurrentRow.Index).Value = nudIgvImporte.Value

                .Item(21, .CurrentRow.Index).Value = nudPrecioFinal.Value
                .Item(22, .CurrentRow.Index).Value = nudCanFinal.Value
                .Item(23, .CurrentRow.Index).Value = nudPUFinal.Value
                .Item(24, .CurrentRow.Index).Value = txtRefSustento.Text
                .Item(25, .CurrentRow.Index).Value = txtClasificacion.Text
            End With
            Dispose()
        End If
    End Sub

    Public Sub UbicaCotizacionID(intIdRecurso As Integer, strNombreItems As String)
        Dim recursoSA As New actividadRecursoSA
        Dim detalleSA As New tablaDetalleSA
        Dim ItemsSA As New itemSA
        Dim DetalleItemsSA As New detalleitemsSA
        Dim tipRec As String = ""
        With recursoSA.UbicaCotizacionRecursoID(intIdRecurso)

            Select Case .TipoRecurso
                Case TipoRecurso.EXISTENCIA
                    ComboTipoExistencia()
                    tipRec = "EXISTENCIA"
                    txtClasificacion.Enabled = True
                    txtCodigoItems.Text = ItemsSA.GetUbicarItemID(strNombreItems).idItem
                    cboTipoExist.SelectedValue = DetalleItemsSA.InvocarProductoID(.idItem).tipoExistencia
                    cboTipoExist.Visible = True
                Case TipoRecurso.SERVICIO
                    tipRec = "SERVICIO-CONTRATO"
                    txtClasificacion.Enabled = False
                Case TipoRecurso.RECURSOS_HUMANOS
                    tipRec = "RECURSOS HUMANOS"
                    txtClasificacion.Enabled = False
            End Select

            If .laborDiaria > 0 Then
                rbConIF.Checked = True
            Else
                rbSinIF.Checked = True
            End If
            txtFechaIngreso.Value = .fechaIngreso
            lblId.Text = .idActividadRecurso
            txtItem.Text = .Descripcion
            txtDetalle.Text = .detalleExtra
            txtCodigoDetalle.Text = .unidadMedida
            txtTipoRecurso.Text = tipRec
            txtUM.Text = detalleSA.GetUbicarTablaID(6, .unidadMedida).descripcion
            txtClasificacion.Text = strNombreItems
            txtRefSustento.Text = .ReferenciaSustento
            nudLaborDiaria.Value = .laborDiaria
            nudCantHH.Value = .hm
            nudPorcentaje.Value = .Porcentaje
            nudDias.Value = .dias
            nudCostoUnitHH.Value = .costoUnithh
            nudCant.Value = .cant
            nudCostoUnit.Value = .costoUnit
            nudCostoDirecto1.Value = .costoDirecto1
            nudCostoDirecto2.Value = .costoDirecto2
            nudGGPorc.Value = .ggPorc
            nudGGImporte.Value = .ggImporte
            nudUTPorc.Value = .utPorc
            nudUTImporte.Value = .utImporte
            nudCostoFinal.Value = .costoFinal
            nudIgvPor.Value = .igvPorc
            nudIgvImporte.Value = .igvImporte
            nudPrecioFinal.Value = .precioFinal
            nudCanFinal.Value = .cantFinal
            nudPUFinal.Value = .precUnitFinal
        End With
    End Sub

    Public Sub LimpiarCajas(ByVal controls As Control)
        For Each control As Control In controls.Controls
            If TypeOf control Is TextBox Then
                'control.Text = ""
                'If control.TabIndex = 1 Then
                '    control.Focus()
                'End If
            ElseIf TypeOf control Is NumericUpDown Then
                control.Text = "0.00"
            ElseIf TypeOf control Is ComboBox Then
                control.Text = ""
            End If
        Next
    End Sub

    Sub calculos()
        Dim cLalorDiaria As Decimal = nudLaborDiaria.Value
        Dim cCantHM As Decimal = nudCantHH.Value
        Dim cCostoUnitHM As Decimal = nudCostoUnitHH.Value
        Dim cPorcGG As Decimal = nudGGPorc.Value / 100
        Dim cPorcUT As Decimal = nudUTPorc.Value / 100
        Dim cPorcIGV As Decimal = nudIgvPor.Value / 100
        Dim cDias As Decimal = 0
        Dim cCostoDirecto As Decimal = 0
        Dim cImporteGG As Decimal = 0
        Dim cImporteUT As Decimal = 0
        Dim cImporteIGV As Decimal = 0

        If rbConIF.Checked = True Then
            cDias = Math.Round(cCantHM / cLalorDiaria, 2)
            nudDias.Value = cDias

            cCostoDirecto = Math.Round(cCantHM * cCostoUnitHM, 2)
            nudCostoDirecto1.Value = cCostoDirecto
            nudCostoDirecto2.Value = cCostoDirecto

            cImporteGG = Math.Round(cCostoDirecto * cPorcGG, 2)
            nudGGImporte.Value = cImporteGG
            cImporteUT = Math.Round(cCostoDirecto * cPorcUT, 2)
            nudUTImporte.Value = cImporteUT

            nudCostoFinal.Value = Math.Round(nudCostoDirecto2.Value + cImporteGG + cImporteUT, 2)

            cImporteIGV = nudCostoFinal.Value * cPorcIGV
            nudIgvImporte.Value = cImporteIGV

            nudPrecioFinal.Value = nudCostoFinal.Value + cImporteIGV
            If nudCanFinal.Value > 0 Then
                nudPUFinal.Value = nudPrecioFinal.Value / nudCanFinal.Value
            End If
        ElseIf rbSinIF.Checked = True Then

            cCostoDirecto = Math.Round(nudCant.Value * nudCostoUnit.Value, 2)
            nudCostoDirecto1.Value = cCostoDirecto
            nudCostoDirecto2.Value = cCostoDirecto

            cImporteGG = Math.Round(cCostoDirecto * cPorcGG, 2)
            nudGGImporte.Value = cImporteGG
            cImporteUT = Math.Round(cCostoDirecto * cPorcUT, 2)
            nudUTImporte.Value = cImporteUT

            nudCostoFinal.Value = Math.Round(nudCostoDirecto2.Value + cImporteGG + cImporteUT, 2)

            cImporteIGV = nudCostoFinal.Value * cPorcIGV
            nudIgvImporte.Value = cImporteIGV

            nudPrecioFinal.Value = nudCostoFinal.Value + cImporteIGV
            If nudCanFinal.Value > 0 Then
                nudPUFinal.Value = nudPrecioFinal.Value / nudCanFinal.Value
            End If
        End If

        nudCan.Value = nudCanFinal.Value
        nudPU.Value = nudPUFinal.Value
        nudTotalCosto.Value = nudPrecioFinal.Value
        Calculos2()
    End Sub
#End Region

    Private Sub rbConIF_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbConIF.CheckedChanged
        If rbConIF.Checked = True Then
            gbx1.Enabled = True
            nudCant.Visible = False
            nudCostoUnit.Visible = False
            LimpiarCajas(Me)
            LimpiarCajas(gbx1)
            nudLaborDiaria.Select()
        End If
    End Sub

    Private Sub rbSinIF_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSinIF.CheckedChanged
        If rbSinIF.Checked = True Then
            gbx1.Enabled = False
            nudCant.Visible = True
            nudCostoUnit.Visible = True
            LimpiarCajas(Me)
            LimpiarCajas(gbx1)
            nudCant.Select()
        End If
    End Sub

    Private Sub nudLaborDiaria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudLaborDiaria.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudCantHH.Select(0, nudCantHH.Text.Length)
            nudCantHH.Focus()
        End If
    End Sub

    Private Sub nudLaborDiaria_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudLaborDiaria.ValueChanged
        calculos()
    End Sub

    Private Sub nudCantHH_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudCantHH.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudCostoUnitHH.Select(0, nudCostoUnitHH.Text.Length)
            nudCostoUnitHH.Focus()
        End If
    End Sub

    Private Sub nudCantHH_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudCantHH.ValueChanged
        calculos()
    End Sub

    Private Sub nudCanFinal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudCanFinal.ValueChanged
        calculos()
    End Sub

    Private Sub nudGGPorc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudGGPorc.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudUTPorc.Select(0, nudUTPorc.Text.Length)
            nudUTPorc.Focus()
        End If
    End Sub

    Private Sub nudGGPorc_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudGGPorc.ValueChanged
        calculos()
    End Sub

    Private Sub nudUTPorc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudUTPorc.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudIgvPor.Select(0, nudIgvPor.Text.Length)
            nudIgvPor.Focus()
        End If
    End Sub

    Private Sub nudUTPorc_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudUTPorc.ValueChanged
        calculos()
    End Sub

    Private Sub nudIgvPor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudIgvPor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudCanFinal.Select(0, nudCanFinal.Text.Length)
            nudCanFinal.Focus()
        End If
    End Sub

    Private Sub nudIgvPor_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudIgvPor.ValueChanged
        calculos()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel1.MouseClick

        LinkLabel1.ContextMenuStrip.Show(LinkLabel1, e.Location)
    End Sub

    Private Sub COSTOIGVToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles COSTOIGVToolStripMenuItem.Click
        txtRefSustento.Text = TipoReferenciaSustento.COSTO_IGV
        Calculos2()
    End Sub

    Private Sub SOLOCOSTOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SOLOCOSTOToolStripMenuItem.Click
        txtRefSustento.Text = TipoReferenciaSustento.SOLO_COSTO
        Calculos2()
    End Sub

    Private Sub NOSUSTENTADOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NOSUSTENTADOToolStripMenuItem.Click
        txtRefSustento.Text = TipoReferenciaSustento.NO_SUSTENTADO
        Calculos2()
    End Sub

    Private Sub EXISTENCIAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXISTENCIAToolStripMenuItem.Click
        txtTipoRecurso.Text = "EXISTENCIA"
        txtClasificacion.Enabled = True
        ComboTipoExistencia()
    End Sub

    Private Sub SERVICIOCONTRATOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SERVICIOCONTRATOToolStripMenuItem.Click
        txtTipoRecurso.Text = "SERVICIO-CONTRATO"
        txtCodigoItems.Enabled = False
        txtClasificacion.Enabled = False
        txtCodigoItems.Text = ""
        txtClasificacion.Text = ""
        lblTipoExist.Visible = False
        cboTipoExist.Visible = False
    End Sub

    Private Sub RECURSOSHUMANOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RECURSOSHUMANOSToolStripMenuItem.Click
        txtTipoRecurso.Text = "RECURSOS HUMANOS"
        txtCodigoItems.Enabled = False
        txtClasificacion.Enabled = False
        txtCodigoItems.Text = ""
        txtClasificacion.Text = ""
        lblTipoExist.Visible = False
        cboTipoExist.Visible = False
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

    End Sub

    Private Sub LinkLabel3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel3.MouseClick
        LinkLabel3.ContextMenuStrip.Show(LinkLabel3, e.Location)
    End Sub

    Private Sub nudCostoUnitHH_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudCostoUnitHH.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudGGPorc.Select(0, nudGGPorc.Text.Length)
            nudGGPorc.Focus()
        End If
    End Sub

    Private Sub nudCostoUnitHH_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudCostoUnitHH.ValueChanged
        calculos()
    End Sub

    Private Sub nudCant_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudCant.ValueChanged
        If rbSinIF.Checked = True Then
            calculos()
        End If

    End Sub

    Private Sub nudCostoUnit_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudCostoUnit.ValueChanged
        If rbSinIF.Checked = True Then
            calculos()
        End If
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If (txtUM.AutoCompleteCustomSource.Contains(txtUM.Text) And txtCodigoDetalle.Text <> "") Then
            Select Case actyon
                Case ENTITY_ACTIONS.INSERT
                    Grabar()
                Case ENTITY_ACTIONS.UPDATE
                    Editar()
            End Select
        Else
            lblEstado.Text = "Incorrecta Unidad Medida"
            lblEstado.Image = My.Resources.warning2
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtItem_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtDetalle.Select(0, txtDetalle.Text.Length)
            txtDetalle.Focus()
        End If
    End Sub

    Private Sub txtItem_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItem.TextChanged

    End Sub

    Private Sub txtDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (txtTipoRecurso.Text = "EXISTENCIA") Then
                e.SuppressKeyPress = True
                txtClasificacion.Select(0, txtClasificacion.Text.Length)
                txtClasificacion.Focus()
            Else
                e.SuppressKeyPress = True
                txtUM.Focus()
                txtUM.Select(0, txtUM.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtUM_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUM.KeyDown
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
                    If (txtTipoRecurso.Text = "Existencia") Then
                        cboTipoExist.Select(0, cboTipoExist.Text.Length)
                        cboTipoExist.Focus()
                    Else
                        nudLaborDiaria.Select(0, nudLaborDiaria.Text.Length)
                        nudLaborDiaria.Focus()
                    End If
                    
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
                        With frmModalUM
                            .actyon = ENTITY_ACTIONS.INSERT
                            .Tag = "MC"
                            .txtCodigoDetalle.Text = objServiceSA.ObtenerTablaMaximo + 1
                            .txtDescipcionUM.Text = txtUM.Text
                            .txtDescipcionUM.Select(0, .txtDescipcionUM.Text.Length)
                            .txtDescipcionUM.Focus()
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                End Select
            End If
        ElseIf (e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete) Then
            txtCodigoDetalle.Text = ""
        End If
    End Sub
    
    Private Sub txtClasificacion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClasificacion.KeyDown
        Dim objServiceSA As New itemSA
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtClasificacion.AutoCompleteCustomSource.Contains(txtClasificacion.Text.Trim) Then
                lblEstado.Text = "Ingreso correcto - Claficicación"
                lblEstado.Image = My.Resources.ok4
                lblEstado.Tag = "H"
                If lblEstado.Tag = "H" Then
                    e.SuppressKeyPress = True
                    txtCodigoItems.Text = objServiceSA.GetListaItemID(txtClasificacion.Text)
                    txtUM.Select(0, txtUM.Text.Length)
                    txtUM.Focus()
                End If
            Else
                Dim result As Integer = MessageBox.Show("¿Desea registrar nueva clasificación?", "Nueva Clasificación", MessageBoxButtons.YesNo)
                Select Case result
                    Case DialogResult.No
                        lblEstado.Text = "Elija una correcta Unidad Medida"
                        lblEstado.Image = My.Resources.warning2
                        txtClasificacion.Text = ""
                        txtClasificacion.Select(0, txtClasificacion.Text.Length)
                        txtClasificacion.Focus()
                    Case DialogResult.Yes
                        With frmModalClasificacionItem
                            .actyon = ENTITY_ACTIONS.INSERT
                            .Tag = "MC"
                            .txtDescipcionUM.Text = txtClasificacion.Text
                            .txtDescipcionUM.Select(0, .txtDescipcionUM.Text.Length)
                            .txtDescipcionUM.Focus()
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                End Select
            End If
        ElseIf (e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete) Then
            txtCodigoDetalle.Text = ""
        End If
    End Sub

    Private Sub cboTipoExist_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoExist.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudLaborDiaria.Focus()
            nudLaborDiaria.Select(0, nudLaborDiaria.Text.Length)
        End If
    End Sub

    Private Sub cboTipoExist_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles cboTipoExist.MouseClick
        If e.Clicks = True Then
            nudLaborDiaria.Focus()
            nudLaborDiaria.Select(0, nudLaborDiaria.Text.Length)
        End If
    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click

    End Sub
End Class
