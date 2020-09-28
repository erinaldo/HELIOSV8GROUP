Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalSuministros
    Private intIdDetalle As Integer
    Dim xNetoPagarBack As Decimal = 0
    Public XManipulacion As String
    Public XDireccion As String
    Public xTipoProyecto As String


    Public Property TipoModulo As String
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
    '    Dim objItem() As HeliosService.DetalleitemsBO
    '    Dim objUbicaTabla As New List(Of HeliosService.TablaDetalleBO)
    '    Try
    '        objLista = objService.GetObtenerMaterialesporEventoPorItem(intIdEvento, strFiltro, intOpcion)
    '        If objLista.Length > 0 Then
    '            objItem = objService.GetUbicaDetalleItem(objLista(0).IdItem, CEmpresa, CEstablecimiento)
    '            txtIdItem.Text = objLista(0).IdItem
    '            txtItem.Text = objItem(0).DescripcionItem
    '            txtTipoPlan.Text = "EXIS."
    '            objUbicaTabla = UbicarTablaGeneral(6, "1", objLista(0).unidad1)
    '            lblUnidad.Text = objUbicaTabla(0).Descripcion
    '            lblIdUnidad.Text = objLista(0).unidad1
    '            lblEx.Visible = True
    '            txtTipoEx.Visible = True
    '            txtTipoEx.Text = objLista(0).tipoExistencia
    '            txtDetalle.Select()
    '            txtDetalle.Focus()
    '        Else
    '            lblEx.Visible = False
    '            txtTipoEx.Visible = False
    '            lblIdUnidad.Text = "00"
    '            lblUnidad.Text = "UND"
    '            txtItem.Clear()
    '            txtIdItem.Clear()
    '            txtTipoPlan.Clear()
    '            MsgBox("No se encontro el código ingresado", MsgBoxStyle.Information, "Atención")
    '        End If


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub UbicarItem(ByVal intIdItem As Integer)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.DetalleActividadPlaneacionBO
    '    Dim objUbicaTabla As New List(Of HeliosService.TablaDetalleBO)
    '    Try
    '        objLista = objService.GetUbicaEX_CadenaPorItem(intIdItem)

    '        If objLista.Length > 0 Then
    '            objUbicaTabla = UbicarTablaGeneral(6, "1", objLista(0).UnidadMedida)
    '            txtTipoPlan.Text = objLista(0).Tipo
    '            If objLista(0).Tipo = "EXIS." Then
    '                lblEx.Visible = True
    '                txtTipoEx.Visible = True
    '                txtTipoEx.Text = objLista(0).HabilidadRequerida ' tipo de existencia
    '                If objUbicaTabla.Count > 0 Then
    '                    lblUnidad.Text = objUbicaTabla(0).Descripcion
    '                    lblIdUnidad.Text = objLista(0).UnidadMedida
    '                End If

    '            Else
    '                lblEx.Visible = False
    '                txtTipoEx.Visible = False
    '                txtTipoEx.Text = "00"

    '                'lblUnidad.Visible = False
    '                'lblIdUnidad.Visible = False
    '            End If

    '            txtIdItem.Text = objLista(0).Composicion
    '            txtItem.Text = objLista(0).Descripcion
    '            txtDetalle.Text = objLista(0).Talla



    '            nudCan.Value = objLista(0).CantRequerida
    '            nudPU.Value = objLista(0).ValorMercado

    '            nudTotalCosto.Value = objLista(0).TotalCosto
    '            nudOtros1.Value = objLista(0).OtrosDeduc
    '            nudDeducPlanilla.Value = objLista(0).DeducPlanilla
    '            nudTotalDeduc.Value = objLista(0).TotalDeduc
    '            nudTotal.Value = objLista(0).Total
    '            nudNetoPagar.Value = objLista(0).NetoPagar
    '            nudOtros2.Value = objLista(0).Otros1
    '            nudAporPlanilla.Value = objLista(0).AporPlanilla
    '            nudTotalAporte.Value = objLista(0).TotalAporte
    '            nudTasaIGV.Value = objLista(0).PorIgv
    '            nudCosto.Value = objLista(0).Costo
    '            nudNoSustenta.Value = objLista(0).NoSustentado
    '            nudMontoPorcentaje.Value = objLista(0).Porcentaje
    '            nudIgv.Value = objLista(0).Igv
    '            nudPstoRef.Value = objLista(0).PsptoReferencial
    '            txtRefSustento.Text = objLista(0).ReferenciaSustento
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub saveUpdateaSuministro()

    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS

    '    Dim objpresupuesto As New HeliosService.DetalleActividadPlaneacionEO()
    '    Dim objpresupuestoDet As New HeliosService.DetalleActividadPlaneacionBO()
    '    Dim objDocumentoCompraDetalle() As HeliosService.DetalleActividadPlaneacionBO
    '    Dim conteo As Integer = 0 ' dgvCadenaSum.Rows.Count
    '    conteo = 0 ' conteo - 1
    '    ReDim objDocumentoCompraDetalle(conteo)

    '    Dim objLiquidacionDet As New HeliosService.TotalesLiquidacionBO()
    '    Dim objLiquidacionDetalle() As HeliosService.TotalesLiquidacionBO
    '    Dim conteoLiquidacion As Integer = 0 ' dgvIngresos.Rows.Count
    '    conteoLiquidacion = 0 ' conteoLiquidacion - 1
    '    ReDim objLiquidacionDetalle(conteoLiquidacion)
    '    Try

    '        Dim S As Integer = 0
    '        For S = 0 To conteo

    '            objpresupuestoDet = New HeliosService.DetalleActividadPlaneacionBO()
    '            objpresupuestoDet.idProyecto = cIdProyecto
    '            objpresupuestoDet.IdEstrategia = cIdEstrategia
    '            objpresupuestoDet.IdProceso = cIdProceso
    '            objpresupuestoDet.idTarea = cIdTarea
    '            objpresupuestoDet.NombreTarea = cNomTarea


    '            '  objpresupuestoDet.CodigoDetalle = lblId.Text ' dgvCadenaSum.Rows(S).Cells(0).Value()
    '            objpresupuestoDet.Descripcion = txtItem.Text ' dgvCadenaSum.Rows(S).Cells(1).Value()
    '            objpresupuestoDet.Tipo = txtTipoPlan.Text
    '            objpresupuestoDet.HabilidadRequerida = txtTipoEx.Text.Trim  ' TIPO DE EXISTENCIA
    '            objpresupuestoDet.IdentificarAdic = Nothing ' dgvCadenaSum.Rows(S).Cells(4).Value()
    '            objpresupuestoDet.Titularidad = Nothing ' dgvCadenaSum.Rows(S).Cells(5).Value()
    '            objpresupuestoDet.ElementoCosto = Nothing ' dgvCadenaSum.Rows(S).Cells(6).Value()
    '            objpresupuestoDet.Composicion = txtIdItem.Text ' dgvCadenaSum.Rows(S).Cells(7).Value()
    '            objpresupuestoDet.Talla = txtDetalle.Text ' dgvCadenaSum.Rows(S).Cells(8).Value() 'detall extra
    '            objpresupuestoDet.Color = Nothing ' dgvCadenaSum.Rows(S).Cells(9).Value()
    '            objpresupuestoDet.Lote = Nothing ' dgvCadenaSum.Rows(S).Cells(10).Value()
    '            objpresupuestoDet.Presentacion = Nothing ' dgvCadenaSum.Rows(S).Cells(11).Value()
    '            objpresupuestoDet.UnidadMedida = lblIdUnidad.Text  ' dgvCadenaSum.Rows(S).Cells(12).Value()
    '            objpresupuestoDet.ValorMercado = nudPU.Value ' dgvCadenaSum.Rows(S).Cells(13).Value()
    '            objpresupuestoDet.CantRequerida = nudCan.Value ' dgvCadenaSum.Rows(S).Cells(14).Value()
    '            objpresupuestoDet.TotalCosto = nudTotalCosto.Value ' dgvCadenaSum.Rows(S).Cells(15).Value()
    '            objpresupuestoDet.PsptoReferencial = nudPstoRef.Value ' dgvCadenaSum.Rows(S).Cells(16).Value()
    '            objpresupuestoDet.DocumentoSustento = Nothing ' dgvCadenaSum.Rows(S).Cells(17).Value()
    '            objpresupuestoDet.ReferenciaSustento = txtRefSustento.Text ' dgvCadenaSum.Rows(S).Cells(18).Value()
    '            objpresupuestoDet.Costo = nudCosto.Value ' dgvCadenaSum.Rows(S).Cells(19).Value()
    '            objpresupuestoDet.NoSustentado = nudNoSustenta.Value ' dgvCadenaSum.Rows(S).Cells(20).Value()
    '            objpresupuestoDet.PorIgv = nudTasaIGV.Value ' dgvCadenaSum.Rows(S).Cells(21).Value()
    '            objpresupuestoDet.Igv = nudIgv.Value ' dgvCadenaSum.Rows(S).Cells(22).Value()
    '            objpresupuestoDet.Total = nudTotal.Value ' dgvCadenaSum.Rows(S).Cells(23).Value()
    '            objpresupuestoDet.DeducPlanilla = nudDeducPlanilla.Value  ' dgvCadenaSum.Rows(S).Cells(24).Value()
    '            objpresupuestoDet.OtrosDeduc = nudOtros1.Value  ' dgvCadenaSum.Rows(S).Cells(25).Value()
    '            objpresupuestoDet.TotalDeduc = nudTotalDeduc.Value ' dgvCadenaSum.Rows(S).Cells(26).Value()
    '            objpresupuestoDet.NetoPagar = nudNetoPagar.Value ' dgvCadenaSum.Rows(S).Cells(27).Value()
    '            objpresupuestoDet.AporPlanilla = nudAporPlanilla.Value  ' dgvCadenaSum.Rows(S).Cells(28).Value()
    '            objpresupuestoDet.Otros1 = nudOtros2.Value ' dgvCadenaSum.Rows(S).Cells(29).Value()
    '            objpresupuestoDet.TotalAporte = nudTotalAporte.Value ' dgvCadenaSum.Rows(S).Cells(30).Value()
    '            objpresupuestoDet.TotalRetenciones = nudTotalRetenApor.Value ' dgvCadenaSum.Rows(S).Cells(31).Value()
    '            objpresupuestoDet.Estado = "1" ' dgvCadenaSum.Rows(S).Cells(32).Value()

    '            objpresupuestoDet.TipoPresupuesto = "INCIDENCIA DIRECTA"
    '            If xTipoProyecto = TIPO_PROYECTO.PLANEAMIENTO Then
    '                objpresupuestoDet.TipoPlan = TIPO_PROYECTO.PLANEAMIENTO
    '            ElseIf xTipoProyecto = TIPO_PROYECTO.REAL Then
    '                objpresupuestoDet.TipoPlan = TIPO_PROYECTO.REAL
    '            End If


    '            objpresupuestoDet.GrupoOperacional = "0" ' dgvCadenaSum.Rows(S).Cells(33).Value()
    '            objpresupuestoDet.IdPersonal = 0 ' dgvCadenaSum.Rows(S).Cells(34).Value()
    '            objpresupuestoDet.FechaInicioGop = Nothing ' dgvCadenaSum.Rows(S).Cells(36).Value()
    '            objpresupuestoDet.FechaFinGop = Nothing 'dgvCadenaSum.Rows(S).Cells(37).Value()
    '            objpresupuestoDet.HoraInicioGop = Nothing ' dgvCadenaSum.Rows(S).Cells(38).Value()
    '            objpresupuestoDet.HoraFinGop = Nothing ' dgvCadenaSum.Rows(S).Cells(39).Value()
    '            objpresupuestoDet.OcurrenciasGop = Nothing 'dgvCadenaSum.Rows(S).Cells(40).Value()

    '            objDocumentoCompraDetalle(S) = objpresupuestoDet

    '        Next S
    '        objpresupuesto.actividadDetalle = objDocumentoCompraDetalle


    '        '-----------------------------------------------------------------------------

    '        objLiquidacionDet = New HeliosService.TotalesLiquidacionBO()

    '        objLiquidacionDet.IdEmpresa = CEmpresa
    '        objLiquidacionDet.IdEstablecimiento = CEstablecimiento
    '        objLiquidacionDet.IdProyecto = cIdProyecto
    '        objLiquidacionDet.IdEstrategia = cIdEstrategia
    '        objLiquidacionDet.IdProceso = cIdProceso
    '        objLiquidacionDet.IdTarea = cIdTarea
    '        objLiquidacionDet.TipoLiquidacion = "INCIDENCIA DIRECTA"
    '        objLiquidacionDet.Otros = "CADIN"
    '        objLiquidacionDet.Modulo = "N"
    '        objLiquidacionDet.Fecha = Date.Now.Date

    '        objLiquidacionDet.LI_ib_ini = 0 ' nudIgv.Value  'IGV
    '        objLiquidacionDet.LI_cfAcum_ini = nudIgv.Value 'i.LI_cfAcum_ini

    '        objLiquidacionDet.LI_ib_ns = 0 'nudIgv.Value 'IGV
    '        objLiquidacionDet.LI_cfAcum_ns = nudIgv.Value ' i.LI_cfAcum_ns

    '        objLiquidacionDet.LI_ib_adic = 0 ' nudIgv.Value 'IGV
    '        objLiquidacionDet.LI_afAcum_adic = nudIgv.Value ' i.LI_afAcum_adic

    '        objLiquidacionDet.RefSustento1 = txtRefSustento.Text 'i.LI_cfAcum_ini

    '        'segundo reporte
    '        objLiquidacionDet.LR_costov_ini = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
    '        objLiquidacionDet.LR_costov_ns = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
    '        objLiquidacionDet.LR_costov_adic = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)

    '        '3er reporte
    '        objLiquidacionDet.LOO_ReDeAp_ini = nudTotalRetenApor.Value
    '        objLiquidacionDet.LOO_ReDeAp_ns = nudTotalRetenApor.Value
    '        objLiquidacionDet.LOO_ReDeAp_adic = nudTotalRetenApor.Value

    '        'ANALISIS FINANCIERO
    '        Select Case txtRefSustento.Text
    '            Case ReferenciaSustento.COSTO_IGV, ReferenciaSustento.SOLO_COSTO
    '                objLiquidacionDet.AF_TotalPagoProvSust_ini = nudNetoPagar.Value
    '                objLiquidacionDet.AF_TotalPagoProvSust_ns = nudNetoPagar.Value
    '                objLiquidacionDet.AF_TotalPagoProvSust_adic = nudNetoPagar.Value
    '            Case ReferenciaSustento.NO_SUSTENTADO
    '                objLiquidacionDet.AF_TotalPagoProvSust_ini = 0.0
    '                objLiquidacionDet.AF_TotalPagoProvSust_ns = 0.0
    '                objLiquidacionDet.AF_TotalPagoProvSust_adic = 0.0
    '        End Select

    '        'no sustentados
    '        objLiquidacionDet.AF_RefGastoNoSust_ini = nudNoSustenta.Value
    '        objLiquidacionDet.AF_RefGastoNoSust_ns = nudNoSustenta.Value
    '        '     objLiquidacionDet.AF_RefGastoNoSust_adic = nudNoSustenta.Value

    '        'Select Case txtRefSustento.Text
    '        '    Case ReferenciaSustento.COSTO_IGV, ReferenciaSustento.SOLO_COSTO, ReferenciaSustento.NO_SUSTENTADO
    '        objLiquidacionDet.LP_TotalPagoProvCSSust_ini = nudNetoPagar.Value
    '        objLiquidacionDet.LP_TotalPagoProvCSSust_ns = nudNetoPagar.Value
    '        objLiquidacionDet.LP_TotalPagoProvCSSust_adic = nudNetoPagar.Value
    '        'End Select


    '        If xTipoProyecto = TIPO_PROYECTO.PLANEAMIENTO Then
    '            objLiquidacionDet.TipoPlan = TIPO_PROYECTO.PLANEAMIENTO
    '        ElseIf xTipoProyecto = TIPO_PROYECTO.REAL Then
    '            objLiquidacionDet.TipoPlan = TIPO_PROYECTO.REAL
    '        End If

    '        objLiquidacionDet.UsuarioActualizacion = cIDUsuario
    '        objLiquidacionDet.FechaActualizacion = Date.Now

    '        objLiquidacionDetalle(0) = objLiquidacionDet
    '        '   Next t
    '        objpresupuesto.ListaTotalesLiquidacion = objLiquidacionDetalle


    '        If objService.UpdateSaveActividad(objpresupuesto) Then
    '            '    MsgBox("Se Grabo correctamente.", MsgBoxStyle.Information, "Done!")
    '            'lblGlosaIng.Text = "Done!: Datos guardados..."
    '            'Timer1.Enabled = True
    '            'TiempoEjecutar(8)
    '            Dispose()
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub UpdateSuministro()

    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS

    '    Dim objpresupuesto As New HeliosService.DetalleActividadPlaneacionEO()
    '    Dim objpresupuestoDet As New HeliosService.DetalleActividadPlaneacionBO()
    '    Dim objDocumentoCompraDetalle() As HeliosService.DetalleActividadPlaneacionBO
    '    Dim conteo As Integer = 0 ' dgvCadenaSum.Rows.Count
    '    conteo = 0 ' conteo - 1
    '    ReDim objDocumentoCompraDetalle(conteo)

    '    Dim objLiquidacionDet As New HeliosService.TotalesLiquidacionBO()
    '    Dim objLiquidacionDetalle() As HeliosService.TotalesLiquidacionBO
    '    Dim conteoLiquidacion As Integer = 0 ' dgvIngresos.Rows.Count
    '    conteoLiquidacion = 0 ' conteoLiquidacion - 1
    '    ReDim objLiquidacionDetalle(conteoLiquidacion)
    '    Try

    '        Dim S As Integer = 0
    '        For S = 0 To conteo

    '            objpresupuestoDet = New HeliosService.DetalleActividadPlaneacionBO()
    '            objpresupuestoDet.idProyecto = cIdProyecto
    '            objpresupuestoDet.IdEstrategia = cIdEstrategia
    '            objpresupuestoDet.IdProceso = cIdProceso
    '            objpresupuestoDet.idTarea = cIdTarea
    '            objpresupuestoDet.NombreTarea = cNomTarea


    '            objpresupuestoDet.CodigoDetalle = lblId.Text ' dgvCadenaSum.Rows(S).Cells(0).Value()
    '            objpresupuestoDet.Descripcion = txtItem.Text ' dgvCadenaSum.Rows(S).Cells(1).Value()
    '            objpresupuestoDet.Tipo = txtTipoPlan.Text
    '            objpresupuestoDet.HabilidadRequerida = Nothing ' dgvCadenaSum.Rows(S).Cells(3).Value()
    '            objpresupuestoDet.IdentificarAdic = Nothing ' dgvCadenaSum.Rows(S).Cells(4).Value()
    '            objpresupuestoDet.Titularidad = Nothing ' dgvCadenaSum.Rows(S).Cells(5).Value()
    '            objpresupuestoDet.ElementoCosto = Nothing ' dgvCadenaSum.Rows(S).Cells(6).Value()
    '            objpresupuestoDet.Composicion = txtIdItem.Text ' dgvCadenaSum.Rows(S).Cells(7).Value()
    '            objpresupuestoDet.Talla = txtDetalle.Text ' dgvCadenaSum.Rows(S).Cells(8).Value() 'detall extra
    '            objpresupuestoDet.Color = Nothing ' dgvCadenaSum.Rows(S).Cells(9).Value()
    '            objpresupuestoDet.Lote = Nothing ' dgvCadenaSum.Rows(S).Cells(10).Value()
    '            objpresupuestoDet.Presentacion = Nothing ' dgvCadenaSum.Rows(S).Cells(11).Value()
    '            objpresupuestoDet.UnidadMedida = Nothing ' dgvCadenaSum.Rows(S).Cells(12).Value()
    '            objpresupuestoDet.ValorMercado = nudPU.Value ' dgvCadenaSum.Rows(S).Cells(13).Value()
    '            objpresupuestoDet.CantRequerida = nudCan.Value ' dgvCadenaSum.Rows(S).Cells(14).Value()
    '            objpresupuestoDet.TotalCosto = nudTotalCosto.Value ' dgvCadenaSum.Rows(S).Cells(15).Value()
    '            objpresupuestoDet.PsptoReferencial = nudPstoRef.Value ' dgvCadenaSum.Rows(S).Cells(16).Value()
    '            objpresupuestoDet.DocumentoSustento = Nothing ' dgvCadenaSum.Rows(S).Cells(17).Value()
    '            objpresupuestoDet.ReferenciaSustento = txtRefSustento.Text ' dgvCadenaSum.Rows(S).Cells(18).Value()
    '            objpresupuestoDet.Costo = nudCosto.Value ' dgvCadenaSum.Rows(S).Cells(19).Value()
    '            objpresupuestoDet.NoSustentado = nudNoSustenta.Value ' dgvCadenaSum.Rows(S).Cells(20).Value()
    '            objpresupuestoDet.PorIgv = nudTasaIGV.Value ' dgvCadenaSum.Rows(S).Cells(21).Value()
    '            objpresupuestoDet.Igv = nudIgv.Value ' dgvCadenaSum.Rows(S).Cells(22).Value()
    '            objpresupuestoDet.Total = nudTotal.Value ' dgvCadenaSum.Rows(S).Cells(23).Value()
    '            objpresupuestoDet.DeducPlanilla = 0 ' dgvCadenaSum.Rows(S).Cells(24).Value()
    '            objpresupuestoDet.OtrosDeduc = nudOtros1.Value  ' dgvCadenaSum.Rows(S).Cells(25).Value()
    '            objpresupuestoDet.TotalDeduc = nudTotalDeduc.Value ' dgvCadenaSum.Rows(S).Cells(26).Value()
    '            objpresupuestoDet.NetoPagar = nudNetoPagar.Value ' dgvCadenaSum.Rows(S).Cells(27).Value()
    '            objpresupuestoDet.AporPlanilla = nudAporPlanilla.Value  ' dgvCadenaSum.Rows(S).Cells(28).Value()
    '            objpresupuestoDet.Otros1 = nudOtros2.Value ' dgvCadenaSum.Rows(S).Cells(29).Value()
    '            objpresupuestoDet.TotalAporte = nudTotalAporte.Value ' dgvCadenaSum.Rows(S).Cells(30).Value()
    '            objpresupuestoDet.TotalRetenciones = nudTotalRetenApor.Value ' dgvCadenaSum.Rows(S).Cells(31).Value()
    '            objpresupuestoDet.Estado = "2" ' dgvCadenaSum.Rows(S).Cells(32).Value()

    '            objpresupuestoDet.TipoPresupuesto = "INCIDENCIA DIRECTA"
    '            objpresupuestoDet.TipoPlan = "P"


    '            objpresupuestoDet.GrupoOperacional = "0" ' dgvCadenaSum.Rows(S).Cells(33).Value()
    '            objpresupuestoDet.IdPersonal = 0 ' dgvCadenaSum.Rows(S).Cells(34).Value()
    '            objpresupuestoDet.FechaInicioGop = Nothing ' dgvCadenaSum.Rows(S).Cells(36).Value()
    '            objpresupuestoDet.FechaFinGop = Nothing 'dgvCadenaSum.Rows(S).Cells(37).Value()
    '            objpresupuestoDet.HoraInicioGop = Nothing ' dgvCadenaSum.Rows(S).Cells(38).Value()
    '            objpresupuestoDet.HoraFinGop = Nothing ' dgvCadenaSum.Rows(S).Cells(39).Value()
    '            objpresupuestoDet.OcurrenciasGop = Nothing 'dgvCadenaSum.Rows(S).Cells(40).Value()

    '            objDocumentoCompraDetalle(S) = objpresupuestoDet

    '        Next S
    '        objpresupuesto.actividadDetalle = objDocumentoCompraDetalle


    '        '-----------------------------------------------------------------------------

    '        objLiquidacionDet = New HeliosService.TotalesLiquidacionBO()
    '        objLiquidacionDet.Secuencia = lblId.Text
    '        objLiquidacionDet.IdEmpresa = CEmpresa
    '        objLiquidacionDet.IdEstablecimiento = CEstablecimiento
    '        objLiquidacionDet.IdProyecto = cIdProyecto
    '        objLiquidacionDet.IdEstrategia = cIdEstrategia
    '        objLiquidacionDet.IdProceso = cIdProceso
    '        objLiquidacionDet.IdTarea = cIdTarea
    '        objLiquidacionDet.TipoLiquidacion = "INCIDENCIA DIRECTA"
    '        objLiquidacionDet.Otros = "CADIN"
    '        objLiquidacionDet.Modulo = "E"
    '        objLiquidacionDet.Fecha = Date.Now.Date

    '        objLiquidacionDet.LI_ib_ini = 0 ' nudIgv.Value  'IGV
    '        objLiquidacionDet.LI_cfAcum_ini = nudIgv.Value 'i.LI_cfAcum_ini

    '        objLiquidacionDet.LI_ib_ns = 0 'nudIgv.Value 'IGV
    '        objLiquidacionDet.LI_cfAcum_ns = nudIgv.Value ' i.LI_cfAcum_ns

    '        objLiquidacionDet.LI_ib_adic = 0 ' nudIgv.Value 'IGV
    '        objLiquidacionDet.LI_afAcum_adic = nudIgv.Value ' i.LI_afAcum_adic
    '        objLiquidacionDet.RefSustento1 = txtRefSustento.Text


    '        'segundo reporte
    '        objLiquidacionDet.LR_costov_ini = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
    '        objLiquidacionDet.LR_costov_ns = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
    '        objLiquidacionDet.LR_costov_adic = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)

    '        '3er reporte
    '        objLiquidacionDet.LOO_ReDeAp_ini = nudTotalRetenApor.Value
    '        objLiquidacionDet.LOO_ReDeAp_ns = nudTotalRetenApor.Value
    '        objLiquidacionDet.LOO_ReDeAp_adic = nudTotalRetenApor.Value

    '        'Select Case txtRefSustento.Text
    '        '    Case ReferenciaSustento.COSTO_IGV, ReferenciaSustento.SOLO_COSTO
    '        objLiquidacionDet.AF_TotalPagoProvSust_ini = nudNetoPagar.Value
    '        objLiquidacionDet.AF_TotalPagoProvSust_ns = nudNetoPagar.Value
    '        objLiquidacionDet.AF_TotalPagoProvSust_adic = nudNetoPagar.Value
    '        '    Case ReferenciaSustento.NO_SUSTENTADO
    '        'objLiquidacionDet.AF_TotalPagoProvSust_ini = 0.0
    '        'objLiquidacionDet.AF_TotalPagoProvSust_ns = 0.0
    '        'objLiquidacionDet.AF_TotalPagoProvSust_adic = 0.0
    '        'End Select

    '        'no sustentados
    '        objLiquidacionDet.AF_RefGastoNoSust_ini = nudNoSustenta.Value
    '        objLiquidacionDet.AF_RefGastoNoSust_ns = nudNoSustenta.Value
    '        objLiquidacionDet.AF_RefGastoNoSust_adic = nudNoSustenta.Value


    '        'Select Case txtRefSustento.Text
    '        '    Case ReferenciaSustento.COSTO_IGV, ReferenciaSustento.SOLO_COSTO, ReferenciaSustento.NO_SUSTENTADO
    '        objLiquidacionDet.LP_TotalPagoProvCSSust_ini = nudNetoPagar.Value
    '        objLiquidacionDet.LP_TotalPagoProvCSSust_ns = nudNetoPagar.Value
    '        objLiquidacionDet.LP_TotalPagoProvCSSust_adic = nudNetoPagar.Value
    '        'End Select

    '        objLiquidacionDet.UsuarioActualizacion = cIDUsuario
    '        objLiquidacionDet.FechaActualizacion = Date.Now

    '        objLiquidacionDetalle(0) = objLiquidacionDet
    '        '   Next t
    '        objpresupuesto.ListaTotalesLiquidacion = objLiquidacionDetalle

    '        If objService.UpdateSaveActividad(objpresupuesto) Then
    '            '    MsgBox("Se Grabo correctamente.", MsgBoxStyle.Information, "Done!")
    '            'lblGlosaIng.Text = "Done!: Datos guardados..."
    '            'Timer1.Enabled = True
    '            'TiempoEjecutar(8)
    '            Dispose()
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub eliminarCADENA()

    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS

    '    Dim objpresupuesto As New HeliosService.DetalleActividadPlaneacionEO()
    '    Dim objpresupuestoDet As New HeliosService.DetalleActividadPlaneacionBO()
    '    Dim objDocumentoCompraDetalle() As HeliosService.DetalleActividadPlaneacionBO
    '    Dim conteo As Integer = 0 ' dgvCadenaSum.Rows.Count
    '    conteo = 0 ' conteo - 1
    '    ReDim objDocumentoCompraDetalle(conteo)

    '    Dim objLiquidacionNueva As New HeliosService.TotalesLiquidacionEO()
    '    '   Dim objLiquidacionDetalle() As HeliosService.TotalesLiquidacionBO
    '    '  Dim conteoLiquidacion As Integer = 0 ' dgvIngresos.Rows.Count
    '    '   conteoLiquidacion = 0 ' conteoLiquidacion - 1
    '    '    ReDim objLiquidacionDetalle(conteoLiquidacion)
    '    Try

    '        Dim S As Integer = 0
    '        For S = 0 To conteo

    '            objpresupuestoDet = New HeliosService.DetalleActividadPlaneacionBO()
    '            objpresupuestoDet.CodigoDetalle = lblId.Text
    '            objpresupuestoDet.idProyecto = cIdProyecto
    '            objpresupuestoDet.IdEstrategia = cIdEstrategia
    '            objpresupuestoDet.IdProceso = cIdProceso
    '            objpresupuestoDet.idTarea = cIdTarea
    '            objpresupuestoDet.NombreTarea = cNomTarea


    '            '  objpresupuestoDet.CodigoDetalle = lblId.Text ' dgvCadenaSum.Rows(S).Cells(0).Value()
    '            objpresupuestoDet.Descripcion = txtItem.Text ' dgvCadenaSum.Rows(S).Cells(1).Value()
    '            objpresupuestoDet.Tipo = txtTipoPlan.Text
    '            objpresupuestoDet.HabilidadRequerida = txtTipoEx.Text.Trim  ' TIPO DE EXISTENCIA
    '            objpresupuestoDet.IdentificarAdic = Nothing ' dgvCadenaSum.Rows(S).Cells(4).Value()
    '            objpresupuestoDet.Titularidad = Nothing ' dgvCadenaSum.Rows(S).Cells(5).Value()
    '            objpresupuestoDet.ElementoCosto = Nothing ' dgvCadenaSum.Rows(S).Cells(6).Value()
    '            objpresupuestoDet.Composicion = txtIdItem.Text ' dgvCadenaSum.Rows(S).Cells(7).Value()
    '            objpresupuestoDet.Talla = txtDetalle.Text ' dgvCadenaSum.Rows(S).Cells(8).Value() 'detall extra
    '            objpresupuestoDet.Color = Nothing ' dgvCadenaSum.Rows(S).Cells(9).Value()
    '            objpresupuestoDet.Lote = Nothing ' dgvCadenaSum.Rows(S).Cells(10).Value()
    '            objpresupuestoDet.Presentacion = Nothing ' dgvCadenaSum.Rows(S).Cells(11).Value()
    '            objpresupuestoDet.UnidadMedida = lblIdUnidad.Text  ' dgvCadenaSum.Rows(S).Cells(12).Value()
    '            objpresupuestoDet.ValorMercado = nudPU.Value ' dgvCadenaSum.Rows(S).Cells(13).Value()
    '            objpresupuestoDet.CantRequerida = nudCan.Value ' dgvCadenaSum.Rows(S).Cells(14).Value()
    '            objpresupuestoDet.TotalCosto = nudTotalCosto.Value ' dgvCadenaSum.Rows(S).Cells(15).Value()
    '            objpresupuestoDet.PsptoReferencial = nudPstoRef.Value ' dgvCadenaSum.Rows(S).Cells(16).Value()
    '            objpresupuestoDet.DocumentoSustento = Nothing ' dgvCadenaSum.Rows(S).Cells(17).Value()
    '            objpresupuestoDet.ReferenciaSustento = txtRefSustento.Text ' dgvCadenaSum.Rows(S).Cells(18).Value()
    '            objpresupuestoDet.Costo = nudCosto.Value ' dgvCadenaSum.Rows(S).Cells(19).Value()
    '            objpresupuestoDet.NoSustentado = nudNoSustenta.Value ' dgvCadenaSum.Rows(S).Cells(20).Value()
    '            objpresupuestoDet.PorIgv = nudTasaIGV.Value ' dgvCadenaSum.Rows(S).Cells(21).Value()
    '            objpresupuestoDet.Igv = nudIgv.Value ' dgvCadenaSum.Rows(S).Cells(22).Value()
    '            objpresupuestoDet.Total = nudTotal.Value ' dgvCadenaSum.Rows(S).Cells(23).Value()
    '            objpresupuestoDet.DeducPlanilla = nudDeducPlanilla.Value  ' dgvCadenaSum.Rows(S).Cells(24).Value()
    '            objpresupuestoDet.OtrosDeduc = nudOtros1.Value  ' dgvCadenaSum.Rows(S).Cells(25).Value()
    '            objpresupuestoDet.TotalDeduc = nudTotalDeduc.Value ' dgvCadenaSum.Rows(S).Cells(26).Value()
    '            objpresupuestoDet.NetoPagar = nudNetoPagar.Value ' dgvCadenaSum.Rows(S).Cells(27).Value()
    '            objpresupuestoDet.AporPlanilla = nudAporPlanilla.Value  ' dgvCadenaSum.Rows(S).Cells(28).Value()
    '            objpresupuestoDet.Otros1 = nudOtros2.Value ' dgvCadenaSum.Rows(S).Cells(29).Value()
    '            objpresupuestoDet.TotalAporte = nudTotalAporte.Value ' dgvCadenaSum.Rows(S).Cells(30).Value()
    '            objpresupuestoDet.TotalRetenciones = nudTotalRetenApor.Value ' dgvCadenaSum.Rows(S).Cells(31).Value()
    '            objpresupuestoDet.Estado = "1" ' dgvCadenaSum.Rows(S).Cells(32).Value()

    '            objpresupuestoDet.TipoPresupuesto = "INCIDENCIA DIRECTA"
    '            If xTipoProyecto = TIPO_PROYECTO.PLANEAMIENTO Then
    '                objpresupuestoDet.TipoPlan = TIPO_PROYECTO.PLANEAMIENTO
    '            ElseIf xTipoProyecto = TIPO_PROYECTO.REAL Then
    '                objpresupuestoDet.TipoPlan = TIPO_PROYECTO.REAL
    '            End If


    '            objpresupuestoDet.GrupoOperacional = "0" ' dgvCadenaSum.Rows(S).Cells(33).Value()
    '            objpresupuestoDet.IdPersonal = 0 ' dgvCadenaSum.Rows(S).Cells(34).Value()
    '            objpresupuestoDet.FechaInicioGop = Nothing ' dgvCadenaSum.Rows(S).Cells(36).Value()
    '            objpresupuestoDet.FechaFinGop = Nothing 'dgvCadenaSum.Rows(S).Cells(37).Value()
    '            objpresupuestoDet.HoraInicioGop = Nothing ' dgvCadenaSum.Rows(S).Cells(38).Value()
    '            objpresupuestoDet.HoraFinGop = Nothing ' dgvCadenaSum.Rows(S).Cells(39).Value()
    '            objpresupuestoDet.OcurrenciasGop = Nothing 'dgvCadenaSum.Rows(S).Cells(40).Value()

    '            objDocumentoCompraDetalle(S) = objpresupuestoDet

    '        Next S
    '        objpresupuesto.actividadDetalle = objDocumentoCompraDetalle


    '        '-----------------------------------------------------------------------------

    '        objLiquidacionNueva = New HeliosService.TotalesLiquidacionEO()

    '        objLiquidacionNueva.IdEmpresa = CEmpresa
    '        objLiquidacionNueva.IdEstablecimiento = CEstablecimiento
    '        objLiquidacionNueva.IdProyecto = cIdProyecto
    '        objLiquidacionNueva.IdEstrategia = cIdEstrategia
    '        objLiquidacionNueva.IdProceso = cIdProceso
    '        objLiquidacionNueva.IdTarea = cIdTarea
    '        objLiquidacionNueva.TipoLiquidacion = "INCIDENCIA DIRECTA"
    '        objLiquidacionNueva.Otros = "CADIN"
    '        objLiquidacionNueva.Modulo = "N"
    '        objLiquidacionNueva.Fecha = Date.Now.Date

    '        objLiquidacionNueva.LI_ib_ini = 0 ' nudIgv.Value  'IGV
    '        objLiquidacionNueva.LI_cfAcum_ini = nudIgv.Value 'i.LI_cfAcum_ini

    '        objLiquidacionNueva.LI_ib_ns = 0 'nudIgv.Value 'IGV
    '        objLiquidacionNueva.LI_cfAcum_ns = nudIgv.Value ' i.LI_cfAcum_ns

    '        objLiquidacionNueva.LI_ib_adic = 0 ' nudIgv.Value 'IGV
    '        objLiquidacionNueva.LI_afAcum_adic = nudIgv.Value ' i.LI_afAcum_adic

    '        objLiquidacionNueva.RefSustento1 = txtRefSustento.Text 'i.LI_cfAcum_ini

    '        'segundo reporte
    '        objLiquidacionNueva.LR_costov_ini = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
    '        objLiquidacionNueva.LR_costov_ns = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)
    '        objLiquidacionNueva.LR_costov_adic = Math.Round(nudCosto.Value + nudOtros2.Value + nudAporPlanilla.Value, 2)

    '        '3er reporte
    '        objLiquidacionNueva.LOO_ReDeAp_ini = nudTotalRetenApor.Value
    '        objLiquidacionNueva.LOO_ReDeAp_ns = nudTotalRetenApor.Value
    '        objLiquidacionNueva.LOO_ReDeAp_adic = nudTotalRetenApor.Value

    '        'ANALISIS FINANCIERO
    '        Select Case txtRefSustento.Text
    '            Case ReferenciaSustento.COSTO_IGV, ReferenciaSustento.SOLO_COSTO
    '                objLiquidacionNueva.AF_TotalPagoProvSust_ini = nudNetoPagar.Value
    '                objLiquidacionNueva.AF_TotalPagoProvSust_ns = nudNetoPagar.Value
    '                objLiquidacionNueva.AF_TotalPagoProvSust_adic = nudNetoPagar.Value
    '            Case ReferenciaSustento.NO_SUSTENTADO
    '                objLiquidacionNueva.AF_TotalPagoProvSust_ini = 0.0
    '                objLiquidacionNueva.AF_TotalPagoProvSust_ns = 0.0
    '                objLiquidacionNueva.AF_TotalPagoProvSust_adic = 0.0

    '                'no sustentados
    '                objLiquidacionNueva.AF_RefGastoNoSust_ini = nudNoSustenta.Value
    '                objLiquidacionNueva.AF_RefGastoNoSust_ns = nudNoSustenta.Value
    '                '    objLiquidacionNueva.AF_RefGastoNoSust_adic = nudNoSustenta.Value

    '                '   AF_RefGastoNoSust_ns
    '        End Select

    '        'Select Case txtRefSustento.Text
    '        '    Case ReferenciaSustento.COSTO_IGV, ReferenciaSustento.SOLO_COSTO, ReferenciaSustento.NO_SUSTENTADO
    '        objLiquidacionNueva.LP_TotalPagoProvCSSust_ini = nudNetoPagar.Value
    '        objLiquidacionNueva.LP_TotalPagoProvCSSust_ns = nudNetoPagar.Value
    '        objLiquidacionNueva.LP_TotalPagoProvCSSust_adic = nudNetoPagar.Value
    '        'End Select


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

    '            .TipoLiquidacion = "INCIDENCIA DIRECTA"
    '            .Otros = "CADIN"
    '        End With

    '        'INGRESANDO NUEVO REGISTRO



    '        If objService.GabrarELim_TotalesLiquidacion(objpresupuesto, objLiquidacionNueva, objActividadDeleteEO) Then
    '            '     MsgBox("Registro eliminado correctamente!", MsgBoxStyle.Information, "Congratulations!")
    '            Dispose()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al eliminar registro." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
    '    End Try

    'End Sub

    'Sub MostrarCanasta()
    '    With frmModalSeleccionSum
    '        ._IdProyecto = cIdProyecto
    '        ._IdEstrategia = cIdEstrategia
    '        ._NomProyecto = cNomProyecto
    '        ._NomEstrategia = cNomEstrategia
    '        '.RadioButton1.Visible = False
    '        '.RbExistencia.Visible = True
    '        '.rbServicio.Visible = True
    '        '.ObtenerEstablecimientos()
    '        '.cboEstablecimiento.SelectedValue = CEstablecimiento
    '        .TipoModulo = TipoModulo


    '        Dim datos As List(Of recuperaCanastaPlaneamiento) = recuperaCanastaPlaneamiento.Instance()
    '        datos.Clear()
    '        '.RbExistencia.Checked = True
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()

    '        If datos.Count > 0 Then
    '            If datos(0).SinTarea = True Then
    '                checked()
    '            Else

    '                txtIdItem.Text = datos(0).m_Dato3
    '                txtItem.Text = datos(0).m_Dato4
    '                txtTipoPlan.Text = datos(0).m_Dato1
    '                If (datos(0).m_Dato1) = "EXIS." Then
    '                    Dim objListaTabla As New List(Of HeliosService.TablaDetalleBO)

    '                    objListaTabla = UbicarTablaGeneral(6, "1", datos(0).m_Dato7)

    '                    lblEx.Visible = True
    '                    txtTipoEx.Visible = True
    '                    txtTipoEx.Text = datos(0).m_Dato8
    '                    lblIdUnidad.Text = datos(0).m_Dato7
    '                    lblUnidad.Text = objListaTabla(0).Descripcion
    '                Else
    '                    lblEx.Visible = False
    '                    txtTipoEx.Visible = False
    '                    lblIdUnidad.Text = "00"
    '                    lblUnidad.Text = "UND"
    '                End If
    '                txtDetalle.Select()
    '                txtDetalle.Focus()
    '            End If



    '        Else
    '            txtIdItem.Text = String.Empty
    '            txtItem.Text = String.Empty
    '            txtTipoPlan.Text = String.Empty
    '        End If
    '    End With
    'End Sub

    Sub Insert()
        Dim tipRec As String = Nothing
        Dim tipCuenta As String = Nothing
        Dim IdActividad As Integer
        Dim RecursoSA As New actividadRecursoSA
        Dim objRecuros As New actividadRecurso
        Dim actividad As New Actividades
        Dim actividadsa As New ActividadesSA
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


        If (GModoProyecto = "Aprobado") Then
            '  actividad = actividadsa.GetUbicaProyectoActividad(GProyectos.IdProyecto)
            objRecuros = New actividadRecurso With {
                   .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                   .idProyecto = GProyectos.IdProyectoActividad,
                   .idActividad = GProyectos.IdProyecto,
                   .tipoActividad = "PY",
                   .Idempresa = Gempresas.IdEmpresaRuc,
                   .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                   .fechaIngreso = txtFechaIngreso.Value,
                   .TipoRecurso = tipRec,
                   .idTipoExistencia = cboTipoExist.SelectedValue,
                   .Descripcion = txtItem.Text,
                   .detalleExtra = txtDetalle.Text,
                   .unidadMedida = txtCodigoDetalle.Text,
                   .Clasificacion = txtClasificacion.Text,
                   .cuentaContable = tipCuenta,
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
                   .Utilidad = 0,
                   .ReferenciaSustento = txtRefSustento.Text.Trim,
                   .PorIgv = nudTasaIGV.Value,
                   .Costo = nudCosto.Value,
                   .NoSustentado = nudNoSustenta.Value,
                   .Porcentaje = nudMontoPorcentaje.Value,
                   .Igv = nudIgv.Value,
                   .PsptoReferencial = nudPstoRef.Value,
                   .Total = nudTotal.Value,
                   .tipoPlan = "AP",
                   .TipoPresupuesto = "INCIDENCIA DIRECTA",
                   .Sustentado = "G"}

            'LIQUIDACION INSERT
            objLiquidacionDet = New totalesLiquidacion()

            objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
            objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
            objLiquidacionDet.idActividad = GProyectos.IdProyecto
            objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
            objLiquidacionDet.Otros = "CADIN"
            objLiquidacionDet.modulo = "N"
            objLiquidacionDet.Fecha = Date.Now.Date

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

            objLiquidacionDet.tipoPlan = "AP"

            objLiquidacionDet.usuarioActualizacion = "NN"
            objLiquidacionDet.fechaActualizacion = DateTime.Now

            IdActividad = RecursoSA.SaveRecursoIniciacion(objRecuros, objLiquidacionDet)

            If (IdActividad <> Nothing) Then
                lblEstado.Text = "Recurso registrado!"
                lblEstado.Image = My.Resources.ok4
                frmActaConstitucionMaster.dgvGastos.Rows.Add(txtFechaIngreso.Value.Date, IdActividad, txtItem.Text, txtDetalle.Text, txtUM.Text, tipRec, nudCan.Value,
                                             nudPU.Value, nudTotalCosto.Value, nudOtros1.Value, nudDeducPlanilla.Value,
                                             nudTotalDeduc.Value, nudNetoPagar.Value, nudOtros2.Value,
                                             nudAporPlanilla.Value, nudTotalAporte.Value, nudTotalRetenApor.Value, txtRefSustento.Text, nudTasaIGV.Value,
                                             nudCosto.Value, nudNoSustenta.Value, nudMontoPorcentaje.Value, nudIgv.Value, nudPstoRef.Value, nudTotal.Value, txtClasificacion.Text)

                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Else
            '  actividad = actividadsa.GetUbicaProyectoActividad(GProyectos.IdProyecto)
            objRecuros = New actividadRecurso With {
                   .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                   .idProyecto = GProyectos.IdProyectoActividad,
                   .idActividad = GProyectos.IdProyecto,
                   .tipoActividad = "PY",
                   .Idempresa = Gempresas.IdEmpresaRuc,
                   .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                   .fechaIngreso = txtFechaIngreso.Value,
                   .TipoRecurso = tipRec,
                   .idTipoExistencia = cboTipoExist.SelectedValue,
                   .Descripcion = txtItem.Text,
                   .detalleExtra = txtDetalle.Text,
                   .unidadMedida = txtCodigoDetalle.Text,
                   .cuentaContable = tipCuenta,
                   .Clasificacion = txtClasificacion.Text,
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
                   .ReferenciaSustento = txtRefSustento.Text.Trim,
                   .PorIgv = nudTasaIGV.Value,
                   .Costo = nudCosto.Value,
                   .NoSustentado = nudNoSustenta.Value,
                   .Porcentaje = nudMontoPorcentaje.Value,
                   .Igv = nudIgv.Value,
                   .PsptoReferencial = nudPstoRef.Value,
                   .Total = nudTotal.Value,
                   .tipoPlan = "A",
                   .TipoPresupuesto = "INCIDENCIA DIRECTA",
                   .Sustentado = "G"}

            'LIQUIDACION INSERT
            objLiquidacionDet = New totalesLiquidacion()

            objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
            objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
            objLiquidacionDet.idActividad = GProyectos.IdProyecto
            objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
            objLiquidacionDet.Otros = "CADIN"
            objLiquidacionDet.modulo = "N"
            objLiquidacionDet.Fecha = Date.Now.Date

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
            IdActividad = RecursoSA.SaveRecursoIniciacion(objRecuros, objLiquidacionDet)
            If (IdActividad <> Nothing) Then
                lblEstado.Text = "Recurso registrado!"
                lblEstado.Image = My.Resources.ok4
                frmActaConstitucionMaster.dgvGastos.Rows.Add(txtFechaIngreso.Value.Date, IdActividad, txtItem.Text, txtDetalle.Text, txtUM.Text, tipRec, nudCan.Value,
                                             nudPU.Value, nudTotalCosto.Value, nudOtros1.Value, nudDeducPlanilla.Value,
                                             nudTotalDeduc.Value, nudNetoPagar.Value, nudOtros2.Value,
                                             nudAporPlanilla.Value, nudTotalAporte.Value, nudTotalRetenApor.Value, txtRefSustento.Text, nudTasaIGV.Value,
                                             nudCosto.Value, nudNoSustenta.Value, nudMontoPorcentaje.Value, nudIgv.Value, nudPstoRef.Value, nudTotal.Value, txtClasificacion.Text)
                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        End If
    End Sub

    Sub UpdateRecurso()
        Dim tipRec As String = Nothing
        Dim tipCuenta As String = Nothing
        Dim RecursoSA As New actividadRecursoSA
        Dim objRecuros As New actividadRecurso
        '    Dim actividad As New Actividades
        Dim actividadsa As New ActividadesSA
        Dim ObjLiquidacionNueva As New totalesLiquidacion()
        Dim objActividadDeleteEO As New totalesLiquidacion()
        '*********************************************************************

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

        If (GModoProyecto = "Aprobado") Then
            '   actividad = actividadsa.GetUbicaProyectoActividad(GProyectos.IdProyecto)
            objRecuros = New actividadRecurso With {
                   .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
                   .idActividadRecurso = lblId.Text,
                    .idProyecto = GProyectos.IdProyectoActividad,
                    .idActividad = GProyectos.IdProyecto,
                   .tipoActividad = "PY",
                   .Idempresa = Gempresas.IdEmpresaRuc,
                   .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                   .fechaIngreso = txtFechaIngreso.Value,
                   .TipoRecurso = tipRec,
                   .Clasificacion = txtClasificacion.Text,
                   .Descripcion = txtItem.Text,
                   .detalleExtra = txtDetalle.Text,
                   .idTipoExistencia = cboTipoExist.SelectedValue,
                   .unidadMedida = txtCodigoDetalle.Text,
                   .cuentaContable = tipCuenta,
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
                   .ReferenciaSustento = txtRefSustento.Text.Trim,
                   .PorIgv = nudTasaIGV.Value,
                   .Costo = nudCosto.Value,
                   .NoSustentado = nudNoSustenta.Value,
                   .Porcentaje = nudMontoPorcentaje.Value,
                   .Igv = nudIgv.Value,
                   .PsptoReferencial = nudPstoRef.Value,
                   .Total = nudTotal.Value,
                   .tipoPlan = "AP",
                   .Sustentado = "G",
                   .TipoPresupuesto = "INCIDENCIA DIRECTA"}

            'UPDATE LIQUIDACION
            ObjLiquidacionNueva = New totalesLiquidacion()

            ObjLiquidacionNueva.idEmpresa = Gempresas.IdEmpresaRuc
            ObjLiquidacionNueva.idEstablecimiento = GEstableciento.IdEstablecimiento
            ObjLiquidacionNueva.idActividad = GProyectos.IdProyecto
            ObjLiquidacionNueva.tipoLiquidacion = "INCIDENCIA DIRECTA"
            ObjLiquidacionNueva.Otros = "CADIN"
            ObjLiquidacionNueva.modulo = "N"
            ObjLiquidacionNueva.Fecha = DateTime.Now.Date

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

            ObjLiquidacionNueva.tipoPlan = "AP"

            ObjLiquidacionNueva.usuarioActualizacion = "NN"
            ObjLiquidacionNueva.fechaActualizacion = DateTime.Now


            '********************************** ELIMINANDO ***********************************************
            With objActividadDeleteEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idActividad = GProyectos.IdProyecto
                .secuencia = lblId.Text
                .tipoPlan = "AP"
                .tipoLiquidacion = "INCIDENCIA DIRECTA"
                .Otros = "CADIN"
            End With

            If RecursoSA.UpdateRecursoIniciacion(objRecuros, objActividadDeleteEO, ObjLiquidacionNueva) Then
                lblEstado.Text = "Recurso editado!"
                lblEstado.Image = My.Resources.ok4
                With frmActaConstitucionMaster.dgvGastos
                    .Item(0, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtFechaIngreso.Value.Date
                    .Item(1, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = lblId.Text
                    .Item(2, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtItem.Text
                    .Item(3, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtDetalle.Text
                    .Item(4, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtUM.Text
                    .Item(5, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = tipRec
                    .Item(6, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudCan.Value
                    .Item(7, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudPU.Value
                    .Item(8, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalCosto.Value
                    .Item(9, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudOtros1.Value
                    .Item(10, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudDeducPlanilla.Value
                    .Item(11, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalDeduc.Value
                    .Item(12, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudNetoPagar.Value
                    .Item(13, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudOtros2.Value
                    .Item(14, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudAporPlanilla.Value
                    .Item(15, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalAporte.Value
                    .Item(16, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalRetenApor.Value
                    .Item(17, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtRefSustento.Text
                    .Item(18, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTasaIGV.Value
                    .Item(19, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudCosto.Value
                    .Item(20, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudNoSustenta.Value
                    .Item(21, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudMontoPorcentaje.Value
                    .Item(22, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudIgv.Value
                    .Item(23, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudPstoRef.Value
                    .Item(24, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotal.Value
                    .Item(25, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtClasificacion.Text
                End With
                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Else
            '   actividad = actividadsa.GetUbicaProyectoActividad(GProyectos.IdProyecto)
            objRecuros = New actividadRecurso With {
                   .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
                   .idActividadRecurso = lblId.Text,
                    .idProyecto = GProyectos.IdProyectoActividad,
                    .idActividad = GProyectos.IdProyecto,
                   .tipoActividad = "PY",
                   .Idempresa = Gempresas.IdEmpresaRuc,
                   .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                   .fechaIngreso = txtFechaIngreso.Value,
                   .TipoRecurso = tipRec,
                    .idTipoExistencia = cboTipoExist.SelectedValue,
                   .Clasificacion = txtClasificacion.Text,
                   .Descripcion = txtItem.Text,
                   .detalleExtra = txtDetalle.Text,
                   .unidadMedida = txtCodigoDetalle.Text,
                   .cuentaContable = tipCuenta,
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
                   .ReferenciaSustento = txtRefSustento.Text.Trim,
                   .PorIgv = nudTasaIGV.Value,
                   .Costo = nudCosto.Value,
                   .NoSustentado = nudNoSustenta.Value,
                   .Porcentaje = nudMontoPorcentaje.Value,
                   .Igv = nudIgv.Value,
                   .PsptoReferencial = nudPstoRef.Value,
                   .Total = nudTotal.Value,
                   .tipoPlan = "A",
                   .Sustentado = "G",
                   .TipoPresupuesto = "INCIDENCIA DIRECTA"}

            'UPDATE LIQUIDACION
            ObjLiquidacionNueva = New totalesLiquidacion()

            ObjLiquidacionNueva.idEmpresa = Gempresas.IdEmpresaRuc
            ObjLiquidacionNueva.idEstablecimiento = GEstableciento.IdEstablecimiento
            ObjLiquidacionNueva.idActividad = GProyectos.IdProyecto
            ObjLiquidacionNueva.tipoLiquidacion = "INCIDENCIA DIRECTA"
            ObjLiquidacionNueva.Otros = "CADIN"
            ObjLiquidacionNueva.modulo = "N"
            ObjLiquidacionNueva.Fecha = DateTime.Now.Date

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

            If RecursoSA.UpdateRecursoIniciacion(objRecuros, objActividadDeleteEO, ObjLiquidacionNueva) Then
                lblEstado.Text = "Recurso editado!"
                lblEstado.Image = My.Resources.ok4
                With frmActaConstitucionMaster.dgvGastos
                    .Item(0, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtFechaIngreso.Value.Date
                    .Item(1, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = lblId.Text
                    .Item(2, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtItem.Text
                    .Item(3, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtDetalle.Text
                    .Item(4, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtUM.Text
                    .Item(5, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = tipRec
                    .Item(6, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudCan.Value
                    .Item(7, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudPU.Value
                    .Item(8, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalCosto.Value
                    .Item(9, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudOtros1.Value
                    .Item(10, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudDeducPlanilla.Value
                    .Item(11, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalDeduc.Value
                    .Item(12, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudNetoPagar.Value
                    .Item(13, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudOtros2.Value
                    .Item(14, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudAporPlanilla.Value
                    .Item(15, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalAporte.Value
                    .Item(16, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotalRetenApor.Value
                    .Item(17, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtRefSustento.Text
                    .Item(18, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTasaIGV.Value
                    .Item(19, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudCosto.Value
                    .Item(20, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudNoSustenta.Value
                    .Item(21, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudMontoPorcentaje.Value
                    .Item(22, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudIgv.Value
                    .Item(23, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudPstoRef.Value
                    .Item(24, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = nudTotal.Value
                    '.Item(25, frmActaConstitucionMaster.dgvGastos.CurrentRow.Index).Value = txtClasificacion.Text
                End With
                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        End If
    End Sub

    Public Sub UbicarID(intIdRecurso As Integer, strNombreItems As String)
        Dim recursoSA As New actividadRecursoSA
        Dim detalleSA As New tablaDetalleSA
        Dim ItemsSA As New itemSA
        Dim DetalleItemsSA As New detalleitemsSA
        Dim tipRec As String = ""
        With recursoSA.UbicaRecursoID(intIdRecurso)
            lblId.Text = .idActividadRecurso
            Select Case .TipoRecurso
                Case TipoRecurso.EXISTENCIA
                    ComboTipoExistencia()
                    txtTipoRecurso.Text = "EXISTENCIA"
                    txtCodigoItems.Text = ItemsSA.GetUbicarItemID(strNombreItems).idItem
                    cboTipoExist.SelectedValue = detalleitemsSA.InvocarProductoID(.idItem).tipoExistencia
                    cboTipoExist.Visible = True
                    txtClasificacion.Enabled = True
                Case TipoRecurso.SERVICIO
                    txtTipoRecurso.Text = "SERVICIO-CONTRATO"
                    txtCodigoItems.Text = ""
                    txtClasificacion.Text = ""
                    txtClasificacion.Enabled = False
                Case TipoRecurso.RECURSOS_HUMANOS
                    txtTipoRecurso.Text = "RECURSOS HUMANOS"
                    txtCodigoItems.Text = ""
                    txtClasificacion.Text = ""
                    txtClasificacion.Enabled = False
            End Select
            txtFechaIngreso.Value = .fechaIngreso
            txtItem.Text = .Descripcion
            txtDetalle.Text = .detalleExtra
            txtCodigoDetalle.Text = .unidadMedida
            txtUM.Text = detalleSA.GetUbicarTablaID(6, .unidadMedida).descripcion
            'If (IsNothing(strNombreItems)) Then


            'Else

            'End If
            txtClasificacion.Text = strNombreItems
            nudCan.Value = .CantRequerida
            nudPU.Value = .ValorMercadoPu
            nudTotalCosto.Value = .TotalCosto
            nudOtros1.Value = .OtrosDeduc
            nudDeducPlanilla.Value = .DeducPlanilla
            nudTotalDeduc.Value = .TotalDeduc
            nudNetoPagar.Value = .NetoPagar
            nudOtros2.Value = .Otros1 ' otros aportes
            nudAporPlanilla.Value = .AporPlanilla
            nudTotalAporte.Value = .TotalAporte
            nudTotalRetenApor.Value = .TotalRetenciones
            txtRefSustento.Text = .ReferenciaSustento
            nudTasaIGV.Value = .PorIgv
            nudCosto.Value = .Costo
            nudNoSustenta.Value = .NoSustentado
            nudMontoPorcentaje.Value = .Porcentaje
            nudIgv.Value = .Igv
            nudPstoRef.Value = .PsptoReferencial
            nudTotal.Value = .Total
        End With
    End Sub

    Sub InsertPlanificacion()
        Dim tipRec As String = Nothing
        Dim tipAct As String = Nothing
        Dim tipCuenta As String = Nothing
        Dim idActvidad As Integer
        Dim RecursoSA As New actividadRecursoSA
        Dim objRecuros As New actividadRecurso
        Dim actividad As New Actividades
        Dim actividadsa As New ActividadesSA

        Dim objLiquidacionDet As New totalesLiquidacion()
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

        '  actividad = actividadsa.GetUbicaProyectoActividad(GProyectos.IdProyecto)
        objRecuros = New actividadRecurso With {
               .Action = Business.Entity.BaseBE.EntityAction.INSERT,
               .idProyecto = GProyectos.IdProyectoActividad,
               .idActividad = GModoTRabajos.IdActividad,
               .tipoActividad = tipAct,
               .Idempresa = Gempresas.IdEmpresaRuc,
               .IdEstablecimiento = GEstableciento.IdEstablecimiento,
               .fechaIngreso = txtFechaIngreso.Value,
               .TipoRecurso = tipRec,
               .idTipoExistencia = cboTipoExist.SelectedValue,
               .Descripcion = txtItem.Text,
               .detalleExtra = txtDetalle.Text,
               .unidadMedida = txtCodigoDetalle.Text,
                .Clasificacion = txtClasificacion.Text,
               .cuentaContable = tipCuenta,
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
               .ReferenciaSustento = txtRefSustento.Text.Trim,
               .PorIgv = nudTasaIGV.Value,
               .Costo = nudCosto.Value,
               .NoSustentado = nudNoSustenta.Value,
               .Porcentaje = nudMontoPorcentaje.Value,
               .Igv = nudIgv.Value,
               .PsptoReferencial = nudPstoRef.Value,
               .Total = nudTotal.Value,
               .tipoPlan = "B",
               .TipoPresupuesto = "INCIDENCIA DIRECTA",
               .Sustentado = 0}

        'LIQUIDACION INSERT
        objLiquidacionDet = New totalesLiquidacion()

        objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
        objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
        objLiquidacionDet.idActividad = GModoTRabajos.IdActividad
        objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
        objLiquidacionDet.Otros = "CADIN"
        objLiquidacionDet.modulo = "N"
        objLiquidacionDet.Fecha = Date.Now.Date

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

        objLiquidacionDet.tipoPlan = "B"

        objLiquidacionDet.usuarioActualizacion = "NN"
        objLiquidacionDet.fechaActualizacion = DateTime.Now

        idActvidad = RecursoSA.SaveRecursoIniciacion(objRecuros, objLiquidacionDet)
        If ((idActvidad) <> Nothing) Then
            lblEstado.Text = "Recurso registrado!"
            lblEstado.Image = My.Resources.ok4
            frmPlanGestionProyecto.dgvGastos.Rows.Add(txtFechaIngreso.Value.Date, idActvidad, txtItem.Text, txtDetalle.Text, txtUM.Text, tipRec, nudCan.Value,
                                         nudPU.Value, nudTotalCosto.Value, nudOtros1.Value, nudDeducPlanilla.Value,
                                         nudTotalDeduc.Value, nudNetoPagar.Value, nudOtros2.Value,
                                         nudAporPlanilla.Value, nudTotalAporte.Value, nudTotalRetenApor.Value, txtRefSustento.Text, nudTasaIGV.Value,
                                         nudCosto.Value, nudNoSustenta.Value, nudMontoPorcentaje.Value, nudIgv.Value, nudPstoRef.Value, nudTotal.Value, txtClasificacion.Text)
            Dispose()
        Else
            lblEstado.Text = "Error al grabar Cadena!"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Sub UpdateRecursoPlanificacion()
        Dim tipRec As String = Nothing
        Dim tipAct As String = Nothing
        Dim tipCuenta As String = Nothing
        Dim RecursoSA As New actividadRecursoSA
        Dim objRecuros As New actividadRecurso
        Dim actividadsa As New ActividadesSA
        Dim ObjLiquidacionNueva As New totalesLiquidacion()
        Dim objActividadDeleteEO As New totalesLiquidacion()
        '*********************************************************************

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

        '   actividad = actividadsa.GetUbicaProyectoActividad(GProyectos.IdProyecto)
        objRecuros = New actividadRecurso With {
               .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
               .idActividadRecurso = lblId.Text,
                .idProyecto = GProyectos.IdProyectoActividad,
                .idActividad = GModoTRabajos.IdActividad,
               .tipoActividad = tipAct,
               .Idempresa = Gempresas.IdEmpresaRuc,
               .IdEstablecimiento = GEstableciento.IdEstablecimiento,
               .fechaIngreso = txtFechaIngreso.Value,
               .TipoRecurso = tipRec,
               .idTipoExistencia = cboTipoExist.SelectedValue,
               .Descripcion = txtItem.Text,
               .detalleExtra = txtDetalle.Text,
               .unidadMedida = txtCodigoDetalle.Text,
               .cuentaContable = tipCuenta,
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
               .ReferenciaSustento = txtRefSustento.Text.Trim,
               .PorIgv = nudTasaIGV.Value,
               .Costo = nudCosto.Value,
               .NoSustentado = nudNoSustenta.Value,
               .Porcentaje = nudMontoPorcentaje.Value,
               .Igv = nudIgv.Value,
               .PsptoReferencial = nudPstoRef.Value,
               .Total = nudTotal.Value,
               .tipoPlan = "B",
               .TipoPresupuesto = "INCIDENCIA DIRECTA",
                .Sustentado = 0}

        'UPDATE LIQUIDACION
        ObjLiquidacionNueva = New totalesLiquidacion()

        ObjLiquidacionNueva.idEmpresa = Gempresas.IdEmpresaRuc
        ObjLiquidacionNueva.idEstablecimiento = GEstableciento.IdEstablecimiento
        ObjLiquidacionNueva.idActividad = GModoTRabajos.IdActividad
        ObjLiquidacionNueva.tipoLiquidacion = "INCIDENCIA DIRECTA"
        ObjLiquidacionNueva.Otros = "CADIN"
        ObjLiquidacionNueva.modulo = "N"
        ObjLiquidacionNueva.Fecha = DateTime.Now.Date

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

        ObjLiquidacionNueva.tipoPlan = "B"

        ObjLiquidacionNueva.usuarioActualizacion = "NN"
        ObjLiquidacionNueva.fechaActualizacion = DateTime.Now


        '********************************** ELIMINANDO ***********************************************
        With objActividadDeleteEO
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .idActividad = GModoTRabajos.IdActividad
            .secuencia = lblId.Text
            .tipoPlan = "B"
            .tipoLiquidacion = "INCIDENCIA DIRECTA"
            .Otros = "CADIN"
        End With

        If RecursoSA.UpdateRecursoIniciacion(objRecuros, objActividadDeleteEO, ObjLiquidacionNueva) Then
            lblEstado.Text = "Recurso editado!"
            lblEstado.Image = My.Resources.ok4
            With frmPlanGestionProyecto.dgvGastos
                .Item(0, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = txtFechaIngreso.Value.Date
                .Item(1, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = lblId.Text
                .Item(2, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = txtItem.Text
                .Item(3, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = txtDetalle.Text
                .Item(4, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = txtUM.Text
                .Item(5, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = tipRec
                .Item(6, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudCan.Value
                .Item(7, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudPU.Value
                .Item(8, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudTotalCosto.Value
                .Item(9, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudOtros1.Value
                .Item(10, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudDeducPlanilla.Value
                .Item(11, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudTotalDeduc.Value
                .Item(12, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudNetoPagar.Value
                .Item(13, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudOtros2.Value
                .Item(14, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudAporPlanilla.Value
                .Item(15, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudTotalAporte.Value
                .Item(16, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudTotalRetenApor.Value
                .Item(17, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = txtRefSustento.Text
                .Item(18, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudTasaIGV.Value
                .Item(19, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudCosto.Value
                .Item(20, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudNoSustenta.Value
                .Item(21, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudMontoPorcentaje.Value
                .Item(22, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudIgv.Value
                .Item(23, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudPstoRef.Value
                .Item(24, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = nudTotal.Value
                .Item(25, frmPlanGestionProyecto.dgvGastos.CurrentRow.Index).Value = txtClasificacion.Text
            End With
            Dispose()
        Else
            lblEstado.Text = "Error al grabar Cadena!"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Sub Calculos()
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

    Enum Filtro
        PorNombre = 2
        PorCodigo = 1
    End Enum

#End Region

    Private Sub frmModalSuministros_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Sub Sustento()
        With FrmReferenciaAlSustento2

            '    Me.Cursor = Cursors.WaitCursor
            Dim datos As List(Of RecuperarDatosPlaneamiento) = RecuperarDatosPlaneamiento.Instance()
            datos.Clear()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()

            If datos.Count > 0 Then
                If Not IsNothing(datos(0).TipoSustento) Then
                    txtRefSustento.Text = datos(0).TipoSustento
                End If

            End If
        End With
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
        Calculos()
    End Sub

    Private Sub nudPU_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudPU.KeyDown

    End Sub

    Private Sub nudPU_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nudPU.MouseClick
        nudPU.Select(0, nudPU.Text.Length)
    End Sub

    Private Sub nudPU_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPU.ValueChanged
        Calculos()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Call MostrarCanasta()
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub nudOtros1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudOtros1.ValueChanged
        Calculos()
    End Sub

    Private Sub nudDeducPlanilla_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudDeducPlanilla.ValueChanged
        Calculos()
    End Sub

    Private Sub nudOtros2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudOtros2.ValueChanged
        Calculos()
    End Sub

    Private Sub nudAporPlanilla_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudAporPlanilla.ValueChanged
        Calculos()
    End Sub

    Private Sub txtDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDetalle.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If (txtTipoRecurso.Text = "EXISTENCIA") Then
              e.SuppressKeyPress = True
                txtClasificacion.Focus()
                txtClasificacion.Select(0, txtClasificacion.Text.Length)
            Else
                e.SuppressKeyPress = True
                txtUM.Focus()
                txtUM.Select(0, txtUM.Text.Length)
            End If
            
        End If
    End Sub
    Sub checked()
        '   If chSinMov.Checked = True Then
        'txtItem.Enabled = False
        txtItem.Text = "- Tarea Operacional -"
        txtDetalle.Text = "- Tarea Operacional -"
        'txtIdItem.Enabled = False
        'txtIdItem.Text = "00"
        '   txtTipoPlan.Text = "SM"
        txtRefSustento.Text = "tarea operacional"
        gbx1.Enabled = False
        gbx2.Enabled = False
        'LimpiarCajas(gbx1)
        'LimpiarCajas(gbx2)
        '   LinkLabel2.Enabled = False
        LinkLabel3.Enabled = False
        txtDetalle.Focus()
        txtDetalle.Select(0, txtDetalle.Text.Length)
        'Else
        ''    txtItem.Enabled = True
        'txtItem.Clear()
        'txtDetalle.Clear()
        'txtIdItem.Enabled = True
        'txtIdItem.Clear()
        'txtTipoPlan.Clear()
        'gbx1.Enabled = True
        'gbx2.Enabled = True
        'LimpiarCajas(gbx1)
        'LimpiarCajas(gbx2)
        'LinkLabel2.Enabled = True
        'LinkLabel3.Enabled = True
        'nudTasaIGV.Value = 18
        'End If
    End Sub
    Private Sub nudIgv_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudIgv.ValueChanged

    End Sub

    Private Sub nudPstoRef_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudCan.Focus()
            nudCan.Select(0, nudCan.Text.Length)
        End If
    End Sub

    Private Sub nudPstoRef_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        nudPstoRef.Select(0, nudPstoRef.Text.Length)
    End Sub

    Private Sub nudPstoRef_ValueChanged(sender As System.Object, e As System.EventArgs)
        If nudPstoRef.Text.Contains(".") Then
            nudPstoRef.DecimalPlaces = 2
        Else
            nudPstoRef.DecimalPlaces = 0
        End If
    End Sub

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub nudTasaIGV_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudTasaIGV.ValueChanged

    End Sub

    Private Sub txtBusqueda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    ObtenerPorEventoFiltro(cIdEstrategia, txtBusqueda.Text.Trim, Filtro.PorCodigo)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBusqueda_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtRefSustento_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtRefSustento.MouseDown
        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '    'ContextMenuFavorites.Show(e.Location)
        '    ContextMenuStrip1.Show(txtRefSustento, e.Location)
        'End If
    End Sub

    Private Sub txtRefSustento_MouseEnter(sender As Object, e As System.EventArgs) Handles txtRefSustento.MouseEnter

    End Sub

    Private Sub txtRefSustento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRefSustento.TextChanged

    End Sub

    Private Sub COSTOIGVToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles COSTOIGVToolStripMenuItem.Click
        txtRefSustento.Text = TipoReferenciaSustento.COSTO_IGV
        Call Calculos()
    End Sub

    Private Sub SOLOCOSTOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SOLOCOSTOToolStripMenuItem.Click
        txtRefSustento.Text = TipoReferenciaSustento.SOLO_COSTO
        Call Calculos()
    End Sub

    Private Sub NOSUSTENTADOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NOSUSTENTADOToolStripMenuItem.Click
        txtRefSustento.Text = TipoReferenciaSustento.NO_SUSTENTADO
        Call Calculos()
    End Sub

    Private Sub LinkLabel3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel3.MouseClick
        LinkLabel3.ContextMenuStrip.Show(LinkLabel3, e.Location)
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

    Private Sub txtTipoRecurso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTipoRecurso.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtItem.Select()
            txtItem.Focus()
        End If
    End Sub

    Private Sub txtTipoRecurso_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoRecurso.TextChanged

    End Sub

    Private Sub txtItem_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItem.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDetalle.Select()
            txtDetalle.Focus()
        End If
    End Sub

    Private Sub txtItem_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItem.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel1.MouseClick
        LinkLabel1.ContextMenuStrip.Show(LinkLabel1, e.Location)
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case XManipulacion
            Case ENTITY_ACTIONS.INSERT
                Select Case XDireccion
                    Case TIPO_DIRECCION.INICIACION
                        Insert()
                    Case TIPO_DIRECCION.PLANIFICACION
                        InsertPlanificacion()
                End Select
            Case ENTITY_ACTIONS.UPDATE
                Select Case XDireccion
                    Case TIPO_DIRECCION.INICIACION
                        UpdateRecurso()
                    Case TIPO_DIRECCION.PLANIFICACION
                        UpdateRecursoPlanificacion()
                End Select
        End Select
        Me.Cursor = Cursors.Arrow
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
                        With frmModalUM
                            .actyon = ENTITY_ACTIONS.INSERT
                            .Tag = "MS"
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

    Private Sub txtUM_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUM.TextChanged

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
                            .Tag = "MS"
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
End Class
