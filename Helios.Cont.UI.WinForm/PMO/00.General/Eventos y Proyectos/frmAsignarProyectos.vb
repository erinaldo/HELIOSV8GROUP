Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmAsignarProyectos
    Inherits frmMaster
    Public Property GConfiguracion As New GConfiguracionModulo
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GConfiguracion = New GConfiguracionModulo
        configuracionModulo(Gempresas.IdEmpresaRuc, "AST", Me.Text)
        Me.WindowState = FormWindowState.Maximized
        GridCFG(dgvCosto)
        GridCFG(dgvOrdenProd)
        GridCFG(dgvActivo)
        GridCFG(dgvGastoAdmin)
        GridCFG(dgvGastoventas)
        GridCFG(dgvGastoFin)
        GridCFG2(dgvEstadoCostos)
        GridCFG2(dgvComprobantesORP)
        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvRecursos)
        GridCFG3(dgvGestionCostos)

        dockingManager1.SetDockLabel(GradientPanel2, "Recursos x asignar")
        ' dockingManager1.DockControlInAutoHideMode(GradientPanel2, DockingStyle.Bottom, 300)
        dockingManager1.DockControl(GradientPanel2, Me, DockingStyle.Bottom, 300)
        dockingManager1.CloseEnabled = False
        dockingManager1.SetDockVisibility(GradientPanel2, False)

        CountItemsNoAsignados()
    End Sub

#Region "Métodos"

    Sub ListaCostosBySubTipo(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New List(Of recursoCosto)
        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("nombreCosto")
        dt.Columns.Add("status")
        dt.Columns.Add("codigo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("subdetalle")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")

        recurso = recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = be.tipo, .subtipo = be.subtipo})
        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            Select Case i.status
                Case StatusCosto.Avance_Obra
                    dr(2) = "AVANCE DE OBRA"
                Case StatusCosto.Culminado
                    dr(2) = "CULMINADO"
                Case StatusCosto.Proceso
                    dr(2) = "PROCESO"
            End Select

            dr(3) = i.codigo
            dr(4) = i.detalle
            dr(5) = i.subdetalle
            dr(6) = i.inicio
            dr(7) = i.finaliza
            dt.Rows.Add(dr)
        Next

        dgvGestionCostos.DataSource = dt
    End Sub

    Sub ListaGastosByTipo(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New List(Of recursoCosto)
        Dim dt As New DataTable()
        dt.Columns.Add("idcosto")
        dt.Columns.Add("nombreCosto")
        dt.Columns.Add("status")
        dt.Columns.Add("codigo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("subdetalle")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")

        recurso = recursoSA.ObtenerGastosEmpresa(New recursoCosto With {.tipo = be.tipo, .subtipo = be.subtipo})
        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            Select Case i.status
                Case StatusCosto.Avance_Obra
                    dr(2) = "-"
                Case StatusCosto.Culminado
                    dr(2) = "-"
                Case StatusCosto.Proceso
                    dr(2) = "-"
            End Select

            dr(3) = i.codigo
            dr(4) = i.detalle
            dr(5) = i.subdetalle
            dr(6) = i.inicio
            dr(7) = i.finaliza
            dt.Rows.Add(dr)
        Next

        dgvGestionCostos.DataSource = dt
    End Sub

    Sub ListadoComprobantesORP(intIdCosto As Integer)
        Dim compraBL As New DocumentoCompraSA
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("persona")
        dt.Columns.Add("CostoMN")
        dt.Columns.Add("CostoME")

        For Each i In compraBL.ListadoComprobantesPorORP(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                   .idPadre = intIdCosto})

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDoc
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.idProveedor
            dr(6) = i.importeTotal
            dr(7) = i.importeUS
            dt.Rows.Add(dr)
        Next
        dgvComprobantesORP.DataSource = dt
    End Sub

    Private Sub CerrarAbrirCosto(r As recursoCosto, rec As Record)
        Dim recursoSA As New recursoCostoSA
        Dim recursoSumatoria As New documentocompradetalle
        Dim documento As New documento
        Dim asiento As New asiento
        Dim movimiento As New movimiento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim documentoLibroDiarioSA As New documentoLibroDiarioSA
        Dim listaAsientos As New List(Of asiento)

        Dim recurso As New recursoCosto With
            {
                .idCosto = r.idCosto,
                .status = r.status,
                .subtipo = r.subtipo
            }

        'Obteniendo sumatoria
        recursoSumatoria = recursoSA.SumatoriaXcosto(New recursoCosto With {.idCosto = r.idCosto})

        '-------------------------------------------------------------------
        asiento = New asiento With
                  {
                      .idEmpresa = Gempresas.IdEmpresaRuc,
                      .idCentroCostos = GEstableciento.IdEstablecimiento,
                      .idAlmacen = Nothing,
                      .nombreAlmacen = Nothing,
                      .idEntidad = Nothing,
                      .nombreEntidad = Nothing,
                      .tipoEntidad = Nothing,
                      .fechaProceso = DateTime.Now,
                      .codigoLibro = "5",
                      .tipo = "D",
                      .tipoAsiento = "AS-MN",
                      .importeMN = recursoSumatoria.montokardex,
                      .importeME = recursoSumatoria.montokardexUS,
                      .glosa = "Asiento de Costos",
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = DateTime.Now
                  }

        Select Case r.subtipo
            Case "ORDEN DE PRODUCCION"
                movimiento = New movimiento With
                   {
                       .cuenta = "71",
                       .descripcion = rec.GetValue("descripcion"),
                       .tipo = "D",
                       .monto = recursoSumatoria.montokardex,
                       .montoUSD = recursoSumatoria.montokardexUS,
                       .usuarioActualizacion = usuario.IDUsuario,
                       .fechaActualizacion = DateTime.Now
                   }
                asiento.movimiento.Add(movimiento)


                movimiento = New movimiento With
                             {
                                 .cuenta = "23",
                                 .descripcion = rec.GetValue("descripcion"),
                                 .tipo = "H",
                                 .monto = recursoSumatoria.montokardex,
                                 .montoUSD = recursoSumatoria.montokardexUS,
                                 .usuarioActualizacion = usuario.IDUsuario,
                                 .fechaActualizacion = DateTime.Now
                             }
                asiento.movimiento.Add(movimiento)

                '-------------------------------------ASIENTO 2-------------------------------------------
                movimiento = New movimiento With
                         {
                             .cuenta = "92",
                             .descripcion = rec.GetValue("descripcion"),
                             .tipo = "D",
                             .monto = recursoSumatoria.montokardex,
                             .montoUSD = recursoSumatoria.montokardexUS,
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
                asiento.movimiento.Add(movimiento)


                movimiento = New movimiento With
                             {
                                 .cuenta = "79",
                                 .descripcion = rec.GetValue("descripcion"),
                                 .tipo = "H",
                                 .monto = recursoSumatoria.montokardex,
                                 .montoUSD = recursoSumatoria.montokardexUS,
                                 .usuarioActualizacion = usuario.IDUsuario,
                                 .fechaActualizacion = DateTime.Now
                             }
                asiento.movimiento.Add(movimiento)
                '-----------------------------------------------------------------

            Case Else

        End Select

        'If TabControlAdv1.SelectedTab Is TabProyecto Then

        'ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then


        'ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then


        'End If
        Select Case r.subtipo
            Case "ORDEN DE PRODUCCION"
                documento = New documento
                documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
                documento.idEmpresa = Gempresas.IdEmpresaRuc
                documento.idCentroCosto = GEstableciento.IdEstablecimiento
                documento.tipoDoc = "9901" 'VOUCHER CONTABLE
                documento.fechaProceso = DateTime.Now
                documento.nroDoc = "1"
                documento.tipoOperacion = "9924"  'INGRESO CUENTAS MANUALES
                documento.idOrden = Nothing
                documento.usuarioActualizacion = usuario.IDUsuario
                documento.fechaActualizacion = DateTime.Now

                documentoLibroDiario = New documentoLibroDiario
                documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
                documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
                documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
                documentoLibroDiario.tipoRegistro = "CST"
                documentoLibroDiario.fecha = DateTime.Now
                documentoLibroDiario.fechaPeriodo = PeriodoGeneral

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                documentoLibroDiario.tipoRazonSocial = "PR"
                documentoLibroDiario.razonSocial = Nothing
                documentoLibroDiario.infoReferencial = "Por Asientos Manuales"
                documentoLibroDiario.idReferencia = Val(rec.GetValue("idcosto"))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                documentoLibroDiario.tipoDoc = "9901"
                documentoLibroDiario.nroDoc = "1"
                documentoLibroDiario.tipoOperacion = "9924"
                documentoLibroDiario.moneda = "1"
                documentoLibroDiario.tipoCambio = TmpTipoCambio
                documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
                documentoLibroDiario.fechaActualizacion = DateTime.Now

                documento.documentoLibroDiario = documentoLibroDiario
                SumaTotalDebeMN = 0
                SumaTotalHaberMN = 0

                SumaTotalDebeME = 0
                SumaTotalHaberME = 0
                '-----------------------------------------------------------------------
                documentoLibroDiarioDet = New documentoLibroDiarioDetalle
                documentoLibroDiarioDet.cuenta = "71"
                documentoLibroDiarioDet.descripcion = rec.GetValue("descripcion")
                documentoLibroDiarioDet.tipoAsiento = "D"
                documentoLibroDiarioDet.importeMN = recursoSumatoria.montokardex
                documentoLibroDiarioDet.importeME = recursoSumatoria.montokardexUS
                documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
                documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
                ListaDetalle.Add(documentoLibroDiarioDet)

                documentoLibroDiarioDet = New documentoLibroDiarioDetalle
                documentoLibroDiarioDet.cuenta = "23"
                documentoLibroDiarioDet.descripcion = rec.GetValue("descripcion")
                documentoLibroDiarioDet.tipoAsiento = "H"
                documentoLibroDiarioDet.importeMN = recursoSumatoria.montokardex
                documentoLibroDiarioDet.importeME = recursoSumatoria.montokardexUS
                documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
                documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
                ListaDetalle.Add(documentoLibroDiarioDet)
                '-------------------------------------------------------------------------

                '-------------------------------Asiento 2----------------------------------------
                documentoLibroDiarioDet = New documentoLibroDiarioDetalle
                documentoLibroDiarioDet.cuenta = "92"
                documentoLibroDiarioDet.descripcion = rec.GetValue("descripcion")
                documentoLibroDiarioDet.tipoAsiento = "D"
                documentoLibroDiarioDet.importeMN = recursoSumatoria.montokardex
                documentoLibroDiarioDet.importeME = recursoSumatoria.montokardexUS

                documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
                documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
                ListaDetalle.Add(documentoLibroDiarioDet)

                documentoLibroDiarioDet = New documentoLibroDiarioDetalle
                documentoLibroDiarioDet.cuenta = "79"
                documentoLibroDiarioDet.descripcion = rec.GetValue("descripcion")
                documentoLibroDiarioDet.tipoAsiento = "H"
                documentoLibroDiarioDet.importeMN = recursoSumatoria.montokardex
                documentoLibroDiarioDet.importeME = recursoSumatoria.montokardexUS
                documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
                documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
                ListaDetalle.Add(documentoLibroDiarioDet)
                '-------------------------------------------------------------------------

                documento.documentoLibroDiario.importeMN = recursoSumatoria.montokardex
                documento.documentoLibroDiario.importeME = recursoSumatoria.montokardexUS
                documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle

                listaAsientos.Add(asiento)

                documento.asiento = listaAsientos
            Case Else
                documento.asiento = Nothing
        End Select

        recursoSA.CulminarCosto(recurso, documento)
        dgvEstadoCostos.Table.CurrentRecord.Delete()
        'Select Case recurso.status
        '    Case StatusCosto.Culminado
        '        dgvEstadoCostos.Table.CurrentRecord.SetValue("estado", "CULMINADO")
        '    Case StatusCosto.Avance_Obra
        '        dgvEstadoCostos.Table.CurrentRecord.SetValue("estado", "AVANCE DE OBRA")
        '    Case StatusCosto.Proceso
        '        dgvEstadoCostos.Table.CurrentRecord.SetValue("estado", "PROCESO")
        'End Select

    End Sub

    Private Sub LoadRecursosoPorEstado(recursoBE As recursoCosto)
        Dim dt As New DataTable()
        Dim recursoSA As New recursoCostoSA

        dt.Columns.Add("idcosto")
        dt.Columns.Add("subtipo")
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("estado")
        dt.Columns.Add("detalle")
        dt.Columns.Add("subdetalle")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")

        For Each i In recursoSA.ObtenerCostosPorSubTipoPorStatus(recursoBE, Nothing)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            Select Case i.subtipo
                Case "PY"
                    dr(1) = "PROYECTO"
                Case "ORP"
                    dr(1) = "ORDEN DE PRODUCCION"
                Case "ACT"
                    dr(1) = "ACTIVO"

            End Select
            dr(2) = i.codigo
            dr(3) = i.nombreCosto
            Select Case i.status
                Case StatusCosto.Avance_Obra
                    dr(4) = "AVANCE DE OBRA"
                Case StatusCosto.Culminado
                    dr(4) = "CULMINADO"
                Case StatusCosto.Proceso
                    dr(4) = "PROCESO"
            End Select
            dr(5) = i.detalle
            dr(6) = i.subdetalle
            dr(7) = i.inicio
            dr(8) = i.finaliza
            dt.Rows.Add(dr)
        Next
        dgvEstadoCostos.DataSource = dt
        dgvEstadoCostos.TableDescriptor.GroupedColumns.Clear()
        dgvEstadoCostos.ShowGroupDropArea = False
    End Sub

    Private Sub LoadRecursosoPorEstadoGastos(recursoBE As recursoCosto)
        Dim dt As New DataTable()
        Dim recursoSA As New recursoCostoSA

        dt.Columns.Add("idcosto")
        dt.Columns.Add("subtipo")
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("estado")
        dt.Columns.Add("detalle")
        dt.Columns.Add("subdetalle")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")

        For Each i In recursoSA.ObtenerCostosPorSubTipoPorStatus(recursoBE, Nothing)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            Select Case i.subtipo
                Case "GADM"
                    dr(1) = "GASTO ADMINISTRATIVO"
                Case "GAVT"
                    dr(1) = "GASTO DE VENTAS"
                Case "FIN"
                    dr(1) = "GASTO FINANCIERO"

            End Select
            dr(2) = i.codigo
            dr(3) = i.nombreCosto
            Select Case i.status
                Case StatusCosto.Avance_Obra
                    dr(4) = "-"
                Case StatusCosto.Culminado
                    dr(4) = "-"
                Case StatusCosto.Proceso
                    dr(4) = "-"
            End Select
            dr(5) = i.detalle
            dr(6) = i.subdetalle
            dr(7) = "-"
            dr(8) = "-"
            dt.Rows.Add(dr)
        Next
        dgvEstadoCostos.DataSource = dt
        dgvEstadoCostos.TableDescriptor.GroupedColumns.Clear()
        dgvEstadoCostos.ShowGroupDropArea = False
    End Sub

    Private Sub LoadproductosTerminadosCulminados(recursoBE As recursoCosto)
        Dim dt As New DataTable()
        Dim recursoSA As New recursoCostoSA

        dt.Columns.Add("idcosto")
        dt.Columns.Add("subtipo")
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("estado")
        dt.Columns.Add("detalle")
        dt.Columns.Add("subdetalle")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")

        For Each i In recursoSA.ObtenerCostosPorSubTipoPorStatus(recursoBE, Nothing)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            Select Case i.subtipo
                Case "PY"
                    dr(1) = "PROYECTO"
                Case "ORP"
                    dr(1) = "ORDEN DE PRODUCCION"
                Case "ACT"
                    dr(1) = "ACTIVO"

            End Select
            dr(2) = i.codigo
            dr(3) = i.nombreCosto
            Select Case i.status
                Case StatusCosto.Avance_Obra
                    dr(4) = "AVANCE DE OBRA"
                Case StatusCosto.Culminado
                    dr(4) = "CULMINADO"
                Case StatusCosto.Proceso
                    dr(4) = "PROCESO"
            End Select
            dr(5) = i.detalle
            dr(6) = i.subdetalle
            dr(7) = i.inicio
            dr(8) = i.finaliza
            dt.Rows.Add(dr)
        Next
        dgvDistribucionProd.DataSource = dt
        dgvDistribucionProd.TableDescriptor.GroupedColumns.Clear()
        dgvDistribucionProd.ShowGroupDropArea = False
    End Sub

    Private Sub LoadResumenCostosGeneral(recursoBE As recursoCosto)
        Dim dt As New DataTable()
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of String)

        Select Case recursoBE.subtipo
            Case "PY", "ACT"
                lista.Add(StatusCosto.Avance_Obra)
                lista.Add(StatusCosto.Culminado)
            Case "ORP"
                lista.Add(StatusCosto.Proceso)
                lista.Add(StatusCosto.Culminado)
        End Select

        dt.Columns.Add("idcosto")
        dt.Columns.Add("subtipo")
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("estado")
        dt.Columns.Add("detalle")
        dt.Columns.Add("subdetalle")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")

        For Each i In recursoSA.ObtenerCostosPorSubTipoPorStatus(recursoBE, lista)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            Select Case i.subtipo
                Case "PY"
                    dr(1) = "PROYECTO"
                Case "ORP"
                    dr(1) = "ORDEN DE PRODUCCION"
                Case "ACT"
                    dr(1) = "ACTIVO"

            End Select
            dr(2) = i.codigo
            dr(3) = i.nombreCosto
            Select Case i.status
                Case StatusCosto.Avance_Obra
                    dr(4) = "AVANCE DE OBRA"
                Case StatusCosto.Culminado
                    dr(4) = "CULMINADO"
                Case StatusCosto.Proceso
                    dr(4) = "PROCESO"
            End Select
            dr(5) = i.detalle
            dr(6) = i.subdetalle
            dr(7) = i.inicio
            dr(8) = i.finaliza
            dt.Rows.Add(dr)
        Next
        dgvEstadoCostos.DataSource = dt
        dgvEstadoCostos.TableDescriptor.GroupedColumns.Clear()
        'dgvEstadoCostos.TableDescriptor.GroupedColumns.Add("estado")
        dgvEstadoCostos.ShowGroupDropArea = True
        dgvEstadoCostos.GridVisualStyles = GridVisualStyles.Metro
    End Sub

    Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String)
        Dim moduloConfiguracionSA As New ModuloConfiguracionSA
        Dim moduloConfiguracion As New moduloConfiguracion
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        Dim cajaSA As New EstadosFinancierosSA

        moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa)
        If Not IsNothing(moduloConfiguracion) Then
            With moduloConfiguracion
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.IdModulo = .idModulo
                GConfiguracion.NomModulo = strNomModulo
                GConfiguracion.TipoConfiguracion = .tipoConfiguracion
                Select Case .tipoConfiguracion
                    Case "P"
                        With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
                            GConfiguracion.ConfigComprobante = .IdEnumeracion
                            GConfiguracion.TipoComprobante = .tipo
                            GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
                            GConfiguracion.Serie = .serie
                            GConfiguracion.ValorActual = .valorInicial
                            '  txtSerie.Text = .serie
                            'txtSerieComp.Visible = True
                            'txtSerieComp.Text = .serie
                            'txtNumeroComp.Visible = False
                            'txtIdComprobante.Text = GConfiguracion.TipoComprobante
                            'txtComprobante.Text = GConfiguracion.NombreComprobante
                            'LinkTipoDoc.Enabled = False
                            'txtSerieComp.Enabled = False
                        End With
                    Case "M"
                        'txtSerieComp.Visible = True
                        'txtNumeroComp.Visible = True
                        'LinkTipoDoc.Enabled = True
                        'txtSerieComp.Enabled = True
                End Select
                If Not IsNothing(.configAlmacen) Then
                    Dim estableSA As New establecimientoSA
                    With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
                        GConfiguracion.IdAlmacen = .idAlmacen
                        GConfiguracion.NombreAlmacen = .descripcionAlmacen

                        'txtAlmacen.Text = GConfiguracion.NombreAlmacen
                        'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
                        With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
                            'txtIdEstableAlmacen.Text = .idCentroCosto
                            'txtEstableAlmacen.Text = .nombre
                        End With
                    End With
                End If
                If Not IsNothing(.ConfigentidadFinanciera) Then
                    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
                        GConfiguracion.IDCaja = .idestado
                        GConfiguracion.NomCaja = .descripcion
                    End With
                End If

            End With
        Else
            '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
            'Timer1.Enabled = True
            'TabCompra.Enabled = False
            'TiempoEjecutar(5)
        End If
    End Sub

    Sub ADDrecursoProyecto(r As Record)
        Dim detSA As New DocumentoCompraDetalleSA
        Dim det As New documentocompradetalle
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New List(Of recursoCosto)


        If TabControlAdv1.SelectedTab Is TabProyecto Then
            recurso = recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})

        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            recurso = recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = "HC", .subtipo = "ORP"})

        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            recurso = recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = "HC", .subtipo = "ACT"})

        ElseIf TabControlAdv1.SelectedTab Is TabGastoAdmin Then
            recurso = recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = "HG", .subtipo = "GADM"})

        ElseIf TabControlAdv1.SelectedTab Is TabGastoVenta Then
            recurso = recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = "HG", .subtipo = "GAVT"})

        ElseIf TabControlAdv1.SelectedTab Is TabGastoFin Then
            recurso = recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = "HG", .subtipo = "FIN"})

        End If

        If recurso.Count > 0 Then
            det.secuencia = r.GetValue("secuencia")
            det.idCosto = recurso(0).idCosto

            If TabControlAdv1.SelectedTab Is TabProyecto Then
                det.tipoCosto = "PY"

            ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
                det.tipoCosto = "ORP"

            ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
                det.tipoCosto = "ACT"

            ElseIf TabControlAdv1.SelectedTab Is TabGastoAdmin Then
                det.tipoCosto = "GADM"

            ElseIf TabControlAdv1.SelectedTab Is TabGastoVenta Then
                det.tipoCosto = "GAVT"

            ElseIf TabControlAdv1.SelectedTab Is TabGastoFin Then
                det.tipoCosto = "FIN"

            End If
            GrabarAsiento(det, Me.dgvRecursos.Table.CurrentRecord)

        End If

        If TabControlAdv1.SelectedTab Is TabProyecto Then
            ListaRecursosAsignados("PY")

        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            ListaRecursosAsignados("ORP")

        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            ListaRecursosAsignados("ACT")

        ElseIf TabControlAdv1.SelectedTab Is TabGastoAdmin Then
            ListaRecursosAsignados("GADM")

        ElseIf TabControlAdv1.SelectedTab Is TabGastoVenta Then
            ListaRecursosAsignados("GAVT")

        ElseIf TabControlAdv1.SelectedTab Is TabGastoFin Then
            ListaRecursosAsignados("FIN")

        End If

        dgvRecursos.Table.CurrentRecord.Delete()
    End Sub

    Sub QuitarAsignacion(r As Record)
        Dim detSA As New DocumentoCompraDetalleSA
        Dim det As New documentocompradetalle
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New List(Of recursoCosto)


        det.secuencia = r.GetValue("secuencia")
        det.idCosto = Nothing
        det.tipoCosto = Nothing
        detSA.QuitarAsignacionRecurso(det)

        If TabControlAdv1.SelectedTab Is TabProyecto Then
            ListaRecursosAsignados("PY")
        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            ListaRecursosAsignados("ORP")
        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            ListaRecursosAsignados("ACT")
        End If


        ListaRecursosPendientes()
    End Sub

    Function getGridConfigDT() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("costo")
        dt.Columns.Add("tipo")
        dt.Columns.Add("estado")
        dt.Columns.Add("codigo")
        dt.Columns.Add("produccion")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")
        dt.Columns.Add("insumo")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("cant")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        Return dt
    End Function

    Sub ListaRecursosAsignados(strTipoCosto As String)
        Dim detSA As New DocumentoCompraDetalleSA
        Dim det As New List(Of documentocompradetalle)
        Dim dt As New DataTable()
        Try
            dt.Columns.Add("costo")
            dt.Columns.Add("tipo")
            dt.Columns.Add("estado")
            dt.Columns.Add("codigo")
            dt.Columns.Add("produccion")
            dt.Columns.Add("inicio")
            dt.Columns.Add("finaliza")
            dt.Columns.Add("insumo")
            dt.Columns.Add("iditem")
            dt.Columns.Add("item")
            dt.Columns.Add("destino")
            dt.Columns.Add("cant")
            dt.Columns.Add("montoMN")
            dt.Columns.Add("montoME")
            dt.Columns.Add("secuencia")

            det = detSA.ListaRecursoAsignadoByIdCosto(New documentocompradetalle With {.tipoCosto = strTipoCosto},
                                                      New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                .fechaContable = PeriodoGeneral})





            For Each i In det
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.idCosto
                dr(1) = i.tipoCosto
                dr(2) = i.Status
                dr(3) = i.CodigoCosto

                dr(4) = i.produccion
                dr(5) = i.Inicio
                dr(6) = i.Finaliza
                dr(7) = ""
                dr(8) = i.idItem
                dr(9) = i.descripcionItem
                dr(10) = i.destino
                dr(11) = i.monto1
                dr(12) = i.montokardex
                dr(13) = i.montokardexUS
                dr(14) = i.secuencia
                dt.Rows.Add(dr)
            Next
            If TabControlAdv1.SelectedTab Is TabProyecto Then
                dgvCosto.DataSource = dt

            ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
                dgvOrdenProd.DataSource = dt

            ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
                dgvActivo.DataSource = dt

            ElseIf TabControlAdv1.SelectedTab Is TabGastoAdmin Then
                dgvGastoAdmin.DataSource = dt

            ElseIf TabControlAdv1.SelectedTab Is TabGastoVenta Then
                dgvGastoventas.DataSource = dt

            ElseIf TabControlAdv1.SelectedTab Is TabGastoFin Then
                dgvGastoFin.DataSource = dt

            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub ListaRecursosAsignadosPorIdCosto(intIdCosto As Integer)
        Dim detSA As New DocumentoCompraDetalleSA
        Dim det As New List(Of documentocompradetalle)
        Dim dt As New DataTable()
        Try
            dt.Columns.Add("costo")
            dt.Columns.Add("tipo")
            dt.Columns.Add("estado")
            dt.Columns.Add("codigo")
            dt.Columns.Add("produccion")
            dt.Columns.Add("inicio")
            dt.Columns.Add("finaliza")
            dt.Columns.Add("insumo")
            dt.Columns.Add("iditem")
            dt.Columns.Add("item")
            dt.Columns.Add("destino")
            dt.Columns.Add("cant")
            dt.Columns.Add("montoMN")
            dt.Columns.Add("montoME")
            dt.Columns.Add("secuencia")

            det = detSA.ListaRecursoAsignadoByIdCostoSingle(New documentocompradetalle With {.idCosto = intIdCosto},
                                                      New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                .fechaContable = PeriodoGeneral})





            For Each i In det
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.idCosto
                dr(1) = i.tipoCosto
                dr(2) = i.Status
                dr(3) = i.CodigoCosto

                dr(4) = i.produccion
                dr(5) = i.Inicio
                dr(6) = i.Finaliza
                dr(7) = ""
                dr(8) = i.idItem
                dr(9) = i.descripcionItem
                dr(10) = i.destino
                dr(11) = i.monto1
                dr(12) = i.montokardex
                dr(13) = i.montokardexUS
                dr(14) = i.secuencia
                dt.Rows.Add(dr)
            Next
            dgvRecursosAsignados.Table.Records.DeleteAll()
            dgvRecursosAsignados.DataSource = dt
            ToolStripLabel1.Text = "Resursos asignados a: " & "' " & dgvEstadoCostos.Table.CurrentRecord.GetValue("descripcion") & " '"
        Catch ex As Exception

        End Try
    End Sub

    Sub CountItemsNoAsignados()
        Dim comprasa As New DocumentoCompraDetalleSA

        lblConteo.Text = comprasa.GetCountItemsNoAsignados(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .fechaContable = PeriodoGeneral})

    End Sub

    Sub ListaRecursosPendientes()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("idItem")
        dt.Columns.Add("destino")
        dt.Columns.Add("item")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        dt.Columns.Add("modulo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")

        For Each i In compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .fechaContable = PeriodoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.idItem
            dr(3) = i.destino
            dr(4) = i.descripcionItem
            dr(5) = i.montokardex
            dr(6) = i.montokardexUS

            dr(7) = "COMPRA"
            dr(8) = i.NombreProveedor
            dr(9) = i.FechaDoc
            dr(10) = i.TipoDoc
            dr(11) = i.Serie
            dr(12) = i.NumDoc
            dt.Rows.Add(dr)
        Next
        dgvRecursos.DataSource = dt

    End Sub

    Sub GridCFG(grid As GridGroupingControl)
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

    Sub GridCFG2(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
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
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG3(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.White ' Color.YellowGreen
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.YellowGreen
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
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
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Function cmbAll() As DataTable
        Dim recursoSA As New recursoCostoSA

        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        For Each i In recursoSA.ObtenerCostosPorTipo(New recursoCosto With {.tipo = "PY"})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Function cmbAllByTipo(tipo As String, subtipo As String) As DataTable
        Dim recursoSA As New recursoCostoSA

        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        For Each i In recursoSA.ObtenerCostosPorSubTipo(New recursoCosto With {.tipo = tipo, .subtipo = subtipo})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Sub cmbCostoGeneral(strTipo As String, subTipo As String)


        If TabControlAdv1.SelectedTab Is TabProyecto Then
            Dim ggcStyle As GridTableCellStyleInfo = dgvCosto.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
            ggcStyle.CellType = "ComboBox"
            ggcStyle.DataSource = cmbAllByTipo(strTipo, subTipo)
            ggcStyle.ValueMember = "id"
            ggcStyle.DisplayMember = "name"
            ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive


        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            Dim ggcStyle As GridTableCellStyleInfo = dgvOrdenProd.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
            ggcStyle.CellType = "ComboBox"
            ggcStyle.DataSource = cmbAllByTipo(strTipo, subTipo)
            ggcStyle.ValueMember = "id"
            ggcStyle.DisplayMember = "name"
            ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            Dim ggcStyle As GridTableCellStyleInfo = dgvActivo.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
            ggcStyle.CellType = "ComboBox"
            ggcStyle.DataSource = cmbAllByTipo(strTipo, subTipo)
            ggcStyle.ValueMember = "id"
            ggcStyle.DisplayMember = "name"
            ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

        ElseIf TabControlAdv1.SelectedTab Is TabGastoAdmin Then
            Dim ggcStyle As GridTableCellStyleInfo = dgvGastoAdmin.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
            ggcStyle.CellType = "ComboBox"
            ggcStyle.DataSource = cmbAllByTipo(strTipo, subTipo)
            ggcStyle.ValueMember = "id"
            ggcStyle.DisplayMember = "name"
            ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

        ElseIf TabControlAdv1.SelectedTab Is TabGastoVenta Then
            Dim ggcStyle As GridTableCellStyleInfo = dgvGastoventas.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
            ggcStyle.CellType = "ComboBox"
            ggcStyle.DataSource = cmbAllByTipo(strTipo, subTipo)
            ggcStyle.ValueMember = "id"
            ggcStyle.DisplayMember = "name"
            ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

        ElseIf TabControlAdv1.SelectedTab Is TabGastoFin Then
            Dim ggcStyle As GridTableCellStyleInfo = dgvGastoFin.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
            ggcStyle.CellType = "ComboBox"
            ggcStyle.DataSource = cmbAllByTipo(strTipo, subTipo)
            ggcStyle.ValueMember = "id"
            ggcStyle.DisplayMember = "name"
            ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

        End If


    End Sub

    Function cmbCostos1() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow
        dr(0) = "HC"
        dr(1) = "HOJA DE COSTOS"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = "HG"
        dr1(1) = "HOJA DE GASTOS"
        dt.Rows.Add(dr1)

        Return dt
    End Function

    Function cmbCostos2() As DataTable
        Dim dttipoCosto As New DataTable()
        dttipoCosto.Columns.Add("id")
        dttipoCosto.Columns.Add("name")

        Dim drtipo As DataRow = dttipoCosto.NewRow
        drtipo(0) = "PY"
        drtipo(1) = "PROYECTOS"
        dttipoCosto.Rows.Add(drtipo)

        Dim drtipo1 As DataRow = dttipoCosto.NewRow
        drtipo1(0) = "ORP"
        drtipo1(1) = "ORDENES DE PRODUCCION"
        dttipoCosto.Rows.Add(drtipo1)

        Dim drtipo2 As DataRow = dttipoCosto.NewRow
        drtipo2(0) = "ACT"
        drtipo2(1) = "ACTIVOS INMOVILIZADOS"
        dttipoCosto.Rows.Add(drtipo2)


        Dim drtipo3 As DataRow = dttipoCosto.NewRow
        drtipo3(0) = "GADM"
        drtipo3(1) = "GASTO ADMINISTRATIVO"
        dttipoCosto.Rows.Add(drtipo3)

        Dim drtipo4 As DataRow = dttipoCosto.NewRow
        drtipo4(0) = "GAVT"
        drtipo4(1) = "GASTO DE VENTAS"
        dttipoCosto.Rows.Add(drtipo4)

        Dim drtipo5 As DataRow = dttipoCosto.NewRow
        drtipo5(0) = "FIN"
        drtipo5(1) = "GASTO FINANCIERO"
        dttipoCosto.Rows.Add(drtipo5)

        Return dttipoCosto
    End Function

    Function cmbHojaCostos() As DataTable
        Dim dttipoCosto As New DataTable()
        dttipoCosto.Columns.Add("id")
        dttipoCosto.Columns.Add("name")

        Dim drtipo As DataRow = dttipoCosto.NewRow
        drtipo(0) = "PY"
        drtipo(1) = "PROYECTOS"
        dttipoCosto.Rows.Add(drtipo)

        Dim drtipo1 As DataRow = dttipoCosto.NewRow
        drtipo1(0) = "ORP"
        drtipo1(1) = "ORDENES DE PRODUCCION"
        dttipoCosto.Rows.Add(drtipo1)

        Dim drtipo2 As DataRow = dttipoCosto.NewRow
        drtipo2(0) = "ACT"
        drtipo2(1) = "ACTIVOS INMOVILIZADOS"
        dttipoCosto.Rows.Add(drtipo2)

        Return dttipoCosto
    End Function

    Function cmbCostosGastos() As DataTable
        Dim dttipoCosto As New DataTable()
        dttipoCosto.Columns.Add("id")
        dttipoCosto.Columns.Add("name")

        Dim drtipo As DataRow = dttipoCosto.NewRow
        drtipo(0) = "GADM"
        drtipo(1) = "GASTO ADMINISTRATIVO"
        dttipoCosto.Rows.Add(drtipo)

        Dim drtipo1 As DataRow = dttipoCosto.NewRow
        drtipo1(0) = "GAVT"
        drtipo1(1) = "GASTO DE VENTAS"
        dttipoCosto.Rows.Add(drtipo1)

        Dim drtipo2 As DataRow = dttipoCosto.NewRow
        drtipo2(0) = "FIN"
        drtipo2(1) = "GASTO FINANCIERO"
        dttipoCosto.Rows.Add(drtipo2)

        Return dttipoCosto
    End Function

    Sub cmbProyecto()
        Dim dttipoCosto As New DataTable()
        Dim ggcStyle2 As New GridTableCellStyleInfo
        dttipoCosto.Columns.Add("id")
        dttipoCosto.Columns.Add("name")

        Dim drtipo As DataRow = dttipoCosto.NewRow
        drtipo(0) = "1"
        drtipo(1) = "AVANCE DE OBRA"
        dttipoCosto.Rows.Add(drtipo)

        Dim drtipo1 As DataRow = dttipoCosto.NewRow
        drtipo1(0) = "2"
        drtipo1(1) = "CULMINADO"
        dttipoCosto.Rows.Add(drtipo1)

        If TabControlAdv1.SelectedTab Is TabProyecto Then
            ggcStyle2 = dgvCosto.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            ggcStyle2 = dgvOrdenProd.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            ggcStyle2 = dgvActivo.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        End If


        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = dttipoCosto
        ggcStyle2.ValueMember = "id"
        ggcStyle2.DisplayMember = "name"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Sub cmbProyecto2()
        Dim dttipoCosto As New DataTable()
        Dim ggcStyle2 As New GridTableCellStyleInfo
        dttipoCosto.Columns.Add("id")
        dttipoCosto.Columns.Add("name")

        Dim drtipo As DataRow = dttipoCosto.NewRow
        drtipo(0) = "3"
        drtipo(1) = "PROCESO"
        dttipoCosto.Rows.Add(drtipo)

        Dim drtipo1 As DataRow = dttipoCosto.NewRow
        drtipo1(0) = "2"
        drtipo1(1) = "CULMINADO"
        dttipoCosto.Rows.Add(drtipo1)

        ggcStyle2 = dgvOrdenProd.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell


        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = dttipoCosto
        ggcStyle2.ValueMember = "id"
        ggcStyle2.DisplayMember = "name"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Sub LoadCombos()

        Dim dt As New DataTable()
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("subtipo")
        dt.Columns.Add("costo")

        Dim dr As DataRow = dt.NewRow
        dr(0) = ""
        dr(1) = ""
        dr(2) = ""
        dt.Rows.Add(dr)
        dgvCosto.DataSource = dt



        Dim ggcStyle As GridTableCellStyleInfo = dgvCosto.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = cmbCostos1()
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive


        Dim ggcStyle2 As GridTableCellStyleInfo = dgvCosto.TableDescriptor.Columns(1).Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = cmbCostos2()
        ggcStyle2.ValueMember = "id"
        ggcStyle2.DisplayMember = "name"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

        Dim ggcStyle3 As GridTableCellStyleInfo = dgvCosto.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        ggcStyle3.CellType = "ComboBox"
        ggcStyle3.DataSource = Nothing ' cmbAll()
        ggcStyle3.ValueMember = "id"
        ggcStyle3.DisplayMember = "name"
        ggcStyle3.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCosto.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCosto.ShowRowHeaders = False
    End Sub

    Private Sub dockingRecursosAsignados()
        dockingManager1.DockControl(PanelEstadoProyecto, Me, DockingStyle.Bottom, 300)
        dockingManager1.SetDockLabel(PanelEstadoProyecto, "Recursos procesados")
        dockingManager1.CloseEnabled = False
    End Sub
#End Region

#Region "Manipulación data"
    Dim SumaTotalDebeMN As Decimal = 0
    Dim SumaTotalHaberMN As Decimal = 0

    Dim SumaTotalDebeME As Decimal = 0
    Dim SumaTotalHaberME As Decimal = 0

    Public Sub GrabarAsiento(detalle As documentocompradetalle, r As Record)
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim det As New documentocompradetalle
        Dim documento As New documento
        Dim asiento As New asiento
        Dim movimiento As New movimiento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim documentoLibroDiarioSA As New documentoLibroDiarioSA
        Dim listaAsientos As New List(Of asiento)

        det = New documentocompradetalle
        det.secuencia = detalle.secuencia
        det.idCosto = detalle.idCosto
        det.tipoCosto = detalle.tipoCosto

        '-------------------------------------------------------------------
        asiento = New asiento With
                  {
                      .idEmpresa = Gempresas.IdEmpresaRuc,
                      .idCentroCostos = GEstableciento.IdEstablecimiento,
                      .idAlmacen = Nothing,
                      .nombreAlmacen = Nothing,
                      .idEntidad = Nothing,
                      .nombreEntidad = Nothing,
                      .tipoEntidad = Nothing,
                      .fechaProceso = DateTime.Now,
                      .codigoLibro = "5",
                      .tipo = "D",
                      .tipoAsiento = "AS-MN",
                      .importeMN = CDbl(r.GetValue("montoMN")),
                      .importeME = CDbl(r.GetValue("montoME")),
                      .glosa = "Asiento de Costos",
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = DateTime.Now
                  }


        If TabControlAdv1.SelectedTab Is TabProyecto Then
            movimiento = New movimiento With
        {
            .cuenta = "92",
            .descripcion = r.GetValue("item"),
            .tipo = "D",
            .monto = CDbl(r.GetValue("montoMN")),
            .montoUSD = CDbl(r.GetValue("montoME")),
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = DateTime.Now
        }
            asiento.movimiento.Add(movimiento)

            movimiento = New movimiento With
            {
                .cuenta = "79",
                .descripcion = r.GetValue("item"),
                .tipo = "H",
                .monto = CDbl(r.GetValue("montoMN")),
                .montoUSD = CDbl(r.GetValue("montoME")),
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
            }
            asiento.movimiento.Add(movimiento)

            '---------------------------------------------------------
            '----- Asiento N02 ---------------------------------------
            movimiento = New movimiento With
            {
                .cuenta = "21",
                .descripcion = r.GetValue("item"),
                .tipo = "D",
                .monto = CDbl(r.GetValue("montoMN")),
                .montoUSD = CDbl(r.GetValue("montoME")),
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
            }
            asiento.movimiento.Add(movimiento)

            movimiento = New movimiento With
            {
                .cuenta = "71",
                .descripcion = r.GetValue("item"),
                .tipo = "H",
                .monto = CDbl(r.GetValue("montoMN")),
                .montoUSD = CDbl(r.GetValue("montoME")),
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
            }
            asiento.movimiento.Add(movimiento)

            '---------------------------------------------------------------

            '---------------------------------------------------------
            '----- Asiento N03 ---------------------------------------
            movimiento = New movimiento With
            {
                .cuenta = "692",
                .descripcion = r.GetValue("item"),
                .tipo = "D",
                .monto = CDbl(r.GetValue("montoMN")),
                .montoUSD = CDbl(r.GetValue("montoME")),
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
            }
            asiento.movimiento.Add(movimiento)

            movimiento = New movimiento With
            {
                .cuenta = "211",
                .descripcion = r.GetValue("item"),
                .tipo = "H",
                .monto = CDbl(r.GetValue("montoMN")),
                .montoUSD = CDbl(r.GetValue("montoME")),
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = DateTime.Now
            }
            asiento.movimiento.Add(movimiento)

            '---------------------------------------------------------------
        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            movimiento = New movimiento With
                         {
                             .cuenta = "23",
                             .descripcion = r.GetValue("item"),
                             .tipo = "D",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

            movimiento = New movimiento With
                         {
                             .cuenta = "71",
                             .descripcion = r.GetValue("item"),
                             .tipo = "H",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            'FALTA ESPECIFICAR


        ElseIf TabControlAdv1.SelectedTab Is TabGastoAdmin Then

            movimiento = New movimiento With
                         {
                             .cuenta = "94",
                             .descripcion = r.GetValue("item"),
                             .tipo = "D",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

            movimiento = New movimiento With
                         {
                             .cuenta = "79",
                             .descripcion = r.GetValue("item"),
                             .tipo = "H",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

        ElseIf TabControlAdv1.SelectedTab Is TabGastoVenta Then

            movimiento = New movimiento With
                         {
                             .cuenta = "94",
                             .descripcion = r.GetValue("item"),
                             .tipo = "D",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

            movimiento = New movimiento With
                         {
                             .cuenta = "79",
                             .descripcion = r.GetValue("item"),
                             .tipo = "H",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

        ElseIf TabControlAdv1.SelectedTab Is TabGastoFin Then

            movimiento = New movimiento With
                         {
                             .cuenta = "94",
                             .descripcion = r.GetValue("item"),
                             .tipo = "D",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

            movimiento = New movimiento With
                         {
                             .cuenta = "79",
                             .descripcion = r.GetValue("item"),
                             .tipo = "H",
                             .monto = CDbl(r.GetValue("montoMN")),
                             .montoUSD = CDbl(r.GetValue("montoME")),
                             .usuarioActualizacion = usuario.IDUsuario,
                             .fechaActualizacion = DateTime.Now
                         }
            asiento.movimiento.Add(movimiento)

        End If

        

        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = DateTime.Now
        documento.nroDoc = "1"
        documento.tipoOperacion = "9924"  'INGRESO CUENTAS MANUALES
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "CST"
        documentoLibroDiario.fecha = DateTime.Now
        documentoLibroDiario.fechaPeriodo = PeriodoGeneral

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        documentoLibroDiario.tipoRazonSocial = "PR"
        documentoLibroDiario.razonSocial = Nothing
        documentoLibroDiario.infoReferencial = "Por Asientos Manuales"
        documentoLibroDiario.idReferencia = Val(r.GetValue("secuencia"))
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "9924"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = TmpTipoCambio
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now

        documento.documentoLibroDiario = documentoLibroDiario
        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0

        If TabControlAdv1.SelectedTab Is TabProyecto Then
            '-------------------------------1--------------------------------------
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "92"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "D"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "79"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "H"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
            '-------------------------------------------------------------------------

            '-------------------------------2--------------------------------------
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "21"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "D"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "71"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "H"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
            '-------------------------------------------------------------------------

            '-------------------------------3--------------------------------------
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "692"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "D"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "211"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "H"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
            '-------------------------------------------------------------------------


        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            '-------------------------------1--------------------------------------
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "23"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "D"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "71"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "H"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
            '-------------------------------------------------------------------------
        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            'FALTA ESPECIFICAR

        ElseIf TabControlAdv1.SelectedTab Is TabGastoAdmin Then
            '-------------------------------1--------------------------------------
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "94"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "D"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "79"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "H"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
            '-------------------------------------------------------------------------

        ElseIf TabControlAdv1.SelectedTab Is TabGastoVenta Then
            '-------------------------------1--------------------------------------
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "94"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "D"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "79"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "H"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
            '-------------------------------------------------------------------------
        ElseIf TabControlAdv1.SelectedTab Is TabGastoFin Then
            '-------------------------------1--------------------------------------
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "94"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "D"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)

            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.cuenta = "79"
            documentoLibroDiarioDet.descripcion = r.GetValue("item")
            documentoLibroDiarioDet.tipoAsiento = "H"
            documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
            documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
            ListaDetalle.Add(documentoLibroDiarioDet)
            '-------------------------------------------------------------------------
        End If


        documento.documentoLibroDiario.importeMN = CDbl(r.GetValue("montoMN"))
        documento.documentoLibroDiario.importeME = CDbl(r.GetValue("montoME"))
        documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle

        listaAsientos.Add(asiento)

        documento.asiento = listaAsientos
        compraSA.UpdateCostoItem(det, documento)

    End Sub

    Public Sub GrabarAsignacion(detalle As documentocompradetalle, r As Record)
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim det As New documentocompradetalle
        Dim documento As New documento
        Dim asiento As New asiento
        Dim movimiento As New movimiento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim documentoLibroDiarioSA As New documentoLibroDiarioSA


        det = New documentocompradetalle
        det.secuencia = detalle.secuencia
        det.idCosto = detalle.idCosto
        det.tipoCosto = detalle.tipoCosto

        '-------------------------------------------------------------------
        asiento = New asiento With
                  {
                      .idEmpresa = Gempresas.IdEmpresaRuc,
                      .idCentroCostos = GEstableciento.IdEstablecimiento,
                      .idAlmacen = Nothing,
                      .nombreAlmacen = Nothing,
                      .idEntidad = Nothing,
                      .nombreEntidad = Nothing,
                      .tipoEntidad = Nothing,
                      .fechaProceso = DateTime.Now,
                      .codigoLibro = "5",
                      .tipo = "D",
                      .tipoAsiento = "AS-MN",
                      .importeMN = CDbl(r.GetValue("montoMN")),
                      .importeME = CDbl(r.GetValue("montoME")),
                      .glosa = "Asiento de Costos",
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = DateTime.Now
                  }

        movimiento = New movimiento With
        {
            .cuenta = "92",
            .descripcion = r.GetValue("item"),
            .tipo = "D",
            .monto = CDbl(r.GetValue("montoMN")),
            .montoUSD = CDbl(r.GetValue("montoME")),
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = DateTime.Now
        }
        asiento.movimiento.Add(movimiento)

        movimiento = New movimiento With
        {
            .cuenta = "79",
            .descripcion = r.GetValue("item"),
            .tipo = "H",
            .monto = CDbl(r.GetValue("montoMN")),
            .montoUSD = CDbl(r.GetValue("montoME")),
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = DateTime.Now
        }
        asiento.movimiento.Add(movimiento)

        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = DateTime.Now
        documento.nroDoc = "1"
        documento.tipoOperacion = "9924"  'INGRESO CUENTAS MANUALES
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "CST"
        documentoLibroDiario.fecha = DateTime.Now
        documentoLibroDiario.fechaPeriodo = PeriodoGeneral

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        documentoLibroDiario.tipoRazonSocial = "PR"
        documentoLibroDiario.razonSocial = Nothing
        documentoLibroDiario.infoReferencial = "Por Asientos Manuales"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "9924"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = TmpTipoCambio
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now

        documento.documentoLibroDiario = documentoLibroDiario
        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0

        documentoLibroDiarioDet = New documentoLibroDiarioDetalle
        documentoLibroDiarioDet.cuenta = "92"
        documentoLibroDiarioDet.descripcion = r.GetValue("item")
        documentoLibroDiarioDet.tipoAsiento = "D"
        documentoLibroDiarioDet.importeMN = r.GetValue("montoMN")
        documentoLibroDiarioDet.importeME = r.GetValue("montoME")
        documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
        ListaDetalle.Add(documentoLibroDiarioDet)

        documentoLibroDiarioDet = New documentoLibroDiarioDetalle
        documentoLibroDiarioDet.cuenta = "79"
        documentoLibroDiarioDet.descripcion = r.GetValue("item")
        documentoLibroDiarioDet.tipoAsiento = "H"
        documentoLibroDiarioDet.importeMN = CDbl(r.GetValue("montoMN"))
        documentoLibroDiarioDet.importeME = CDbl(r.GetValue("montoME"))
        documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
        ListaDetalle.Add(documentoLibroDiarioDet)
        '-------------------------------------------------------------------------

        documento.documentoLibroDiario.importeMN = CDbl(r.GetValue("montoMN"))
        documento.documentoLibroDiario.importeME = CDbl(r.GetValue("montoME"))
        documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle

        documento.asiento = asiento
        compraSA.UpdateCostoItem(det, documento)

    End Sub
#End Region

    Private Sub frmAsignarProyectos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAsignarProyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadCombos()
        'cmbCostoGeneral("HC", "PY")
        'cmbHojaCostos()
        TabProyecto.Parent = TabControlAdv1
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabEstadoCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabGestionCostos.Parent = Nothing
    End Sub

    Private Sub dgvCosto_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCosto.TableControlCellClick

    End Sub

    Private Sub dgvCosto_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCosto.TableControlCurrentCellCloseDropDown
        Me.Cursor = Cursors.WaitCursor
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvCosto.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 1
                    Dim recursoSA As New recursoCostoSA
                    Dim compraSA As New DocumentoCompraDetalleSA
                    'GrabarAsiento(Me.dgvCosto.Table.CurrentRecord)


                    compraSA.UpdateCostoItemSingle(New documentocompradetalle With {
                                          .secuencia = Val(dgvCosto.Table.CurrentRecord.GetValue("secuencia")),
                                          .idCosto = Val(dgvCosto.Table.CurrentRecord.GetValue("costo")),
                                          .tipoCosto = "PY"
                                          })

                    With recursoSA.ObtenerCostoById(New recursoCosto With {.idCosto = Val(dgvCosto.Table.CurrentRecord.GetValue("costo"))})
                        dgvCosto.Table.CurrentRecord.SetValue("estado", .status)
                        dgvCosto.Table.CurrentRecord.SetValue("codigo", .codigo)
                        dgvCosto.Table.CurrentRecord.SetValue("tipo", .subtipo)
                        dgvCosto.Table.CurrentRecord.SetValue("produccion", .detalle)
                        dgvCosto.Table.CurrentRecord.SetValue("inicio", .inicio.Value.ToShortDateString)
                        dgvCosto.Table.CurrentRecord.SetValue("finaliza", .finaliza.Value.ToShortDateString)
                    End With

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TabControlAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlAdv1.SelectedIndexChanged

    End Sub
    Structure Operacion
        Const Proyecto = "Proyecto"
        Const Orden_Produccion = "Orden de Producción"
        Const Activo_Inmovilizado = "Activo Inmoviliario"
        Const Gasto_Administrativo = "Gasto Adminstrativo"
        Const Gasto_Ventas = "Gasto de Ventas"
        Const Gasto_Financiero = "Gastos Financiero"
    End Structure

    Private Sub treeViewAdv2_AfterNodePaint(sender As Object, e As TreeNodeAdvPaintEventArgs) Handles treeViewAdv2.AfterNodePaint

    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case Operacion.Proyecto
                TabProyecto.Parent = TabControlAdv1
                TabProduccion.Parent = Nothing
                TabActivo.Parent = Nothing
                TabGastoAdmin.Parent = Nothing
                TabGastoVenta.Parent = Nothing
                TabGastoFin.Parent = Nothing
                TabEstadoCostos.Parent = Nothing
                TabProductosTerminadosAlmacen.Parent = Nothing
                TabGestionCostos.Parent = Nothing

                cmbCostoGeneral("HC", "PY")
                cmbProyecto()
                ListaRecursosAsignados("PY")

                dockingManager1.SetDockVisibility(GradientPanel2, True)
                dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)

                GridCFG(dgvCosto)
            Case Operacion.Orden_Produccion
                TabProyecto.Parent = Nothing
                TabProduccion.Parent = TabControlAdv1
                TabActivo.Parent = Nothing
                TabGastoAdmin.Parent = Nothing
                TabGastoVenta.Parent = Nothing
                TabGastoFin.Parent = Nothing
                TabEstadoCostos.Parent = Nothing
                TabProductosTerminadosAlmacen.Parent = Nothing
                TabGestionCostos.Parent = Nothing

                cmbCostoGeneral("HC", "ORP")
                cmbProyecto2()
                ListaRecursosAsignados("ORP")
                dockingManager1.SetDockVisibility(GradientPanel2, True)
                dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)

                GridCFG(dgvOrdenProd)
            Case Operacion.Activo_Inmovilizado
                TabProyecto.Parent = Nothing
                TabProduccion.Parent = Nothing
                TabActivo.Parent = TabControlAdv1
                TabGastoAdmin.Parent = Nothing
                TabGastoVenta.Parent = Nothing
                TabGastoFin.Parent = Nothing
                TabEstadoCostos.Parent = Nothing
                TabProductosTerminadosAlmacen.Parent = Nothing
                TabGestionCostos.Parent = Nothing

                cmbCostoGeneral("HC", "ACT")
                cmbProyecto()
                ListaRecursosAsignados("ACT")
                dockingManager1.SetDockVisibility(GradientPanel2, True)
                dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)

                GridCFG(dgvActivo)
            Case Operacion.Gasto_Administrativo
                TabProyecto.Parent = Nothing
                TabProduccion.Parent = Nothing
                TabActivo.Parent = Nothing
                TabGastoAdmin.Parent = TabControlAdv1
                TabGastoVenta.Parent = Nothing
                TabGastoFin.Parent = Nothing
                TabEstadoCostos.Parent = Nothing
                TabProductosTerminadosAlmacen.Parent = Nothing
                TabGestionCostos.Parent = Nothing

                cmbCostoGeneral("HG", "GADM")
                cmbProyecto2()
                ListaRecursosAsignados("GADM")

                dockingManager1.SetDockVisibility(GradientPanel2, True)
                dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)
                GridCFG(dgvGastoAdmin)
            Case Operacion.Gasto_Ventas
                TabProyecto.Parent = Nothing
                TabProduccion.Parent = Nothing
                TabActivo.Parent = Nothing
                TabGastoAdmin.Parent = Nothing
                TabGastoVenta.Parent = TabControlAdv1
                TabGastoFin.Parent = Nothing
                TabEstadoCostos.Parent = Nothing
                TabProductosTerminadosAlmacen.Parent = Nothing
                TabGestionCostos.Parent = Nothing

                cmbCostoGeneral("HG", "GAVT")
                cmbProyecto2()
                ListaRecursosAsignados("GAVT")

                dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)
                dockingManager1.SetDockVisibility(GradientPanel2, True)
                GridCFG(dgvGastoventas)
            Case Operacion.Gasto_Financiero
                TabProyecto.Parent = Nothing
                TabProduccion.Parent = Nothing
                TabActivo.Parent = Nothing
                TabGastoAdmin.Parent = Nothing
                TabGastoVenta.Parent = Nothing
                TabEstadoCostos.Parent = Nothing
                TabGastoFin.Parent = TabControlAdv1
                TabProductosTerminadosAlmacen.Parent = Nothing
                TabGestionCostos.Parent = Nothing

                cmbCostoGeneral("HG", "FIN")
                cmbProyecto2()
                ListaRecursosAsignados("FIN")

                dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)
                dockingManager1.SetDockVisibility(GradientPanel2, True)
                GridCFG(dgvGastoFin)
            Case "Administración de Costos"
                GridCFG3(dgvGestionCostos)
                TabProyecto.Parent = Nothing
                TabProduccion.Parent = Nothing
                TabActivo.Parent = Nothing
                TabGastoAdmin.Parent = Nothing
                TabGastoVenta.Parent = Nothing
                TabGastoFin.Parent = Nothing
                TabEstadoCostos.Parent = Nothing
                TabProductosTerminadosAlmacen.Parent = Nothing
                TabGestionCostos.Parent = TabControlAdv1

                dockingManager1.SetDockVisibility(GradientPanel2, False)
                dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click
      
    End Sub

    Private Sub dgvRecursos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvRecursos.TableControlCellClick

    End Sub

    Private Sub dgvRecursos_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvRecursos.TableControlCellDoubleClick
        ' ADDrecurso(dgvRecursos.Table.CurrentRecord)
    End Sub

    Private Sub dgvRecursos_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvRecursos.TableControlCurrentCellControlDoubleClick

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvRecursos.Table.CurrentRecord) Then
            ADDrecursoProyecto(dgvRecursos.Table.CurrentRecord)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabProyecto Then
            QuitarAsignacion(dgvCosto.Table.CurrentRecord)

        ElseIf TabControlAdv1.SelectedTab Is TabProduccion Then
            QuitarAsignacion(dgvOrdenProd.Table.CurrentRecord)

        ElseIf TabControlAdv1.SelectedTab Is TabActivo Then
            QuitarAsignacion(dgvActivo.Table.CurrentRecord)

        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Me.Cursor = Cursors.WaitCursor
        ListaRecursosPendientes()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvOrdenProd_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvOrdenProd.TableControlCellClick

    End Sub

    Private Sub dgvOrdenProd_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvOrdenProd.TableControlCurrentCellCloseDropDown
        Me.Cursor = Cursors.WaitCursor
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvOrdenProd.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 1
                    Dim recursoSA As New recursoCostoSA
                    Dim compraSA As New DocumentoCompraDetalleSA

                    compraSA.UpdateCostoItemSingle(New documentocompradetalle With {
                                          .secuencia = Val(dgvOrdenProd.Table.CurrentRecord.GetValue("secuencia")),
                                          .idCosto = Val(dgvOrdenProd.Table.CurrentRecord.GetValue("costo")),
                                          .tipoCosto = "ORP"
                                          })

                    With recursoSA.ObtenerCostoById(New recursoCosto With {.idCosto = Val(dgvOrdenProd.Table.CurrentRecord.GetValue("costo"))})
                        dgvOrdenProd.Table.CurrentRecord.SetValue("estado", .status)
                        dgvOrdenProd.Table.CurrentRecord.SetValue("codigo", .codigo)
                        dgvOrdenProd.Table.CurrentRecord.SetValue("tipo", .subtipo)
                        dgvOrdenProd.Table.CurrentRecord.SetValue("produccion", .detalle)
                        dgvOrdenProd.Table.CurrentRecord.SetValue("inicio", .inicio.Value.ToShortDateString)
                        dgvOrdenProd.Table.CurrentRecord.SetValue("finaliza", .finaliza.Value.ToShortDateString)
                    End With

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvActivo_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvActivo.TableControlCellClick

    End Sub

    Private Sub dgvActivo_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvActivo.TableControlCurrentCellCloseDropDown
        Me.Cursor = Cursors.WaitCursor
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvActivo.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 1
                    Dim compraSA As New DocumentoCompraDetalleSA
                    Dim recursoSA As New recursoCostoSA
                    compraSA.UpdateCostoItemSingle(New documentocompradetalle With {
                                                  .secuencia = Val(dgvActivo.Table.CurrentRecord.GetValue("secuencia")),
                                                  .idCosto = Val(dgvActivo.Table.CurrentRecord.GetValue("costo")),
                                                  .tipoCosto = "ACT"
                                                  })

                    With recursoSA.ObtenerCostoById(New recursoCosto With {.idCosto = Val(dgvActivo.Table.CurrentRecord.GetValue("costo"))})
                        dgvActivo.Table.CurrentRecord.SetValue("estado", .status)
                        dgvActivo.Table.CurrentRecord.SetValue("codigo", .codigo)
                        dgvActivo.Table.CurrentRecord.SetValue("tipo", .subtipo)
                        dgvActivo.Table.CurrentRecord.SetValue("produccion", .detalle)
                        dgvActivo.Table.CurrentRecord.SetValue("inicio", .inicio.Value.ToShortDateString)
                        dgvActivo.Table.CurrentRecord.SetValue("finaliza", .finaliza.Value.ToShortDateString)
                    End With

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ProyectosEnAvanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProyectosEnAvanceToolStripMenuItem.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Proyectos en Avance"
        LoadRecursosoPorEstado(New recursoCosto With {.tipo = "HC", .subtipo = "PY", .status = StatusCosto.Avance_Obra})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ProyectosCulimnadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProyectosCulimnadosToolStripMenuItem.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Proyectos culminados"
        LoadRecursosoPorEstado(New recursoCosto With {.tipo = "HC", .subtipo = "PY", .status = StatusCosto.Culminado})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ResumenDeProyectosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenDeProyectosToolStripMenuItem.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabEstadoCostos.Text = "Resúmen de proyectos"
        TabEstadoCostos.Parent = TabControlAdv1
        LoadResumenCostosGeneral(New recursoCosto With {.tipo = "HC", .subtipo = "PY", .status = StatusCosto.Culminado})

        dockingRecursosAsignados()
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TabGastoVenta_Click(sender As Object, e As EventArgs) Handles TabGastoVenta.Click

    End Sub

    Private Sub dgvEstadoCostos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEstadoCostos.TableControlCellClick
        If Not IsNothing(dgvEstadoCostos.Table.CurrentRecord) Then
            Me.Cursor = Cursors.WaitCursor
            ListaRecursosAsignadosPorIdCosto(Val(dgvEstadoCostos.Table.CurrentRecord.GetValue("idcosto")))
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Productos en proceso"
        LoadRecursosoPorEstado(New recursoCosto With {.tipo = "HC", .subtipo = "ORP", .status = StatusCosto.Proceso})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ResumenProducciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenProducciónToolStripMenuItem.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabEstadoCostos.Text = "Resúmen producción"
        TabEstadoCostos.Parent = TabControlAdv1
        LoadResumenCostosGeneral(New recursoCosto With {.tipo = "HC", .subtipo = "ORP", .status = StatusCosto.Proceso})

        dockingRecursosAsignados()
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Activos en avance"
        LoadRecursosoPorEstado(New recursoCosto With {.tipo = "HC", .subtipo = "ACT", .status = StatusCosto.Avance_Obra})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Activos culminados"
        LoadRecursosoPorEstado(New recursoCosto With {.tipo = "HC", .subtipo = "ACT", .status = StatusCosto.Culminado})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabEstadoCostos.Text = "Resúmen de activos inmovilizados"
        TabEstadoCostos.Parent = TabControlAdv1
        LoadResumenCostosGeneral(New recursoCosto With {.tipo = "HC", .subtipo = "ACT", .status = StatusCosto.Culminado})

        dockingRecursosAsignados()
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvEstadoCostos.Table.CurrentRecord) Then
            If MessageBoxAdv.Show("Desea culminar el costo?", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                CerrarAbrirCosto(New recursoCosto With {.idCosto = Val(dgvEstadoCostos.Table.CurrentRecord.GetValue("idcosto")),
                                                   .status = StatusCosto.Culminado,
                                                   .subtipo = dgvEstadoCostos.Table.CurrentRecord.GetValue("subtipo")},
                                               dgvEstadoCostos.Table.CurrentRecord)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Me.Cursor = Cursors.WaitCursor
        If MessageBoxAdv.Show("Desea volver a abrir el costo?", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            CerrarAbrirCosto(New recursoCosto With {.idCosto = Val(dgvEstadoCostos.Table.CurrentRecord.GetValue("idcosto")),
                                               .status = StatusCosto.Avance_Obra,
                                               .subtipo = dgvEstadoCostos.Table.CurrentRecord.GetValue("subtipo")},
                                           dgvEstadoCostos.Table.CurrentRecord)
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        'Dim f As New frmNuevoProductoTerminado
        'f.lblCosto.Text = "ORP: " & dgvDistribucionProd.Table.CurrentRecord.GetValue("descripcion")
        'f.lblCosto.Tag = dgvDistribucionProd.Table.CurrentRecord.GetValue("idcosto")
        'f.WindowState = FormWindowState.Maximized
        'f.ShowDialog()
    End Sub

    Private Sub ProductosPorDistribuirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosPorDistribuirToolStripMenuItem.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, False)
        '  dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabEstadoCostos.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Productos para distribución"
        LoadproductosTerminadosCulminados(New recursoCosto With {.tipo = "HC", .subtipo = "ORP", .status = StatusCosto.Culminado})

        GridCFG2(dgvDistribucionProd)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvDistribucionProd_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDistribucionProd.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvDistribucionProd.Table.CurrentRecord) Then
            ListadoComprobantesORP(Val(dgvDistribucionProd.Table.CurrentRecord.GetValue("idcosto")))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        If Not IsNothing(dgvComprobantesORP.Table.CurrentRecord) Then
            If MessageBoxAdv.Show("Desea eliminar el comprobante seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                Dim r As Record = dgvComprobantesORP.Table.CurrentRecord
                EliminarComprobanteORP(New documento With {.idDocumento = r.GetValue("idDocumento"),
                                                           .idEmpresa = Gempresas.IdEmpresaRuc,
                                                           .idCentroCosto = GEstableciento.IdEstablecimiento})

                Me.Cursor = Cursors.Arrow
            End If
        Else
            MessageBoxAdv.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub EliminarComprobanteORP(be As documento)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento()

        documento = New documento With {
            .idDocumento = be.idDocumento,
            .idEmpresa = be.idEmpresa,
            .idCentroCosto = be.idCentroCosto
            }

        documentoSA.EliminarComprobanteORPByCosto(documento)
        dgvComprobantesORP.Table.CurrentRecord.Delete()
        MessageBoxAdv.Show("Comprobante eliminado correctamente!")
    End Sub

    Private Sub ComboBoxAdv2_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv2.Click

    End Sub

    Private Sub ComboBoxAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv2.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor

        Dim COD = ComboBoxAdv2.Text

        Select Case COD
            Case "PROYECTO"
                ListaCostosBySubTipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})

            Case "ORDEN DE PRODUCCION"
                ListaCostosBySubTipo(New recursoCosto With {.tipo = "HC", .subtipo = "ORP"})

            Case "ACTIVOS INMOVILIZADOS"
                ListaCostosBySubTipo(New recursoCosto With {.tipo = "HC", .subtipo = "ACT"})

            Case "GASTO ADMINISTRATIVO"
                ListaGastosByTipo(New recursoCosto With {.tipo = "HG", .subtipo = "GADM"})

            Case "GASTO DE VENTAS"
                ListaGastosByTipo(New recursoCosto With {.tipo = "HG", .subtipo = "GAVT"})

            Case "GASTO FINANCIERO"
                ListaGastosByTipo(New recursoCosto With {.tipo = "HG", .subtipo = "FIN"})

        End Select

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        'Dim f As New frmNuevoCosto

        'Select Case ComboBoxAdv2.Text
        '    Case "PROYECTO"
        '        f.cboTipo.Text = "HOJA DE COSTO"
        '        f.cboSubtipo.Text = "PROYECTO"
        '        f.cboEstatus.Text = "AVANCE DE OBRA"
        '        f.Label3.Text = "NOMBRE PROYECTO"

        '    Case "ORDEN DE PRODUCCION"
        '        f.cboTipo.Text = "HOJA DE COSTO"
        '        f.cboSubtipo.Text = "ORDEN DE PRODUCCION"
        '        f.cboEstatus.Text = "PROCESO"
        '        f.Label3.Text = "NOMBRE ORD. PRODUCCION"

        '    Case "ACTIVOS INMOVILIZADOS"
        '        f.cboTipo.Text = "HOJA DE COSTO"
        '        f.cboSubtipo.Text = "ACTIVOS INMOVILIZADOS"
        '        f.cboEstatus.Text = "AVANCE DE OBRA"
        '        f.Label3.Text = "NOMBRE ACTIVO INMOVILIZADO"

        '    Case "GASTO ADMINISTRATIVO"
        '        f.Label4.Visible = False
        '        f.cboEstatus.Visible = False
        '        f.Label8.Visible = False
        '        f.txtInicio.Visible = False
        '        f.Label9.Visible = False
        '        f.txtFinaliza.Visible = False
        '        f.Label10.Visible = False
        '        f.Label3.Text = "OF. ADMINISTRATIVA"

        '        f.cboTipo.Text = "HOJA DE GASTO"
        '        f.cboSubtipo.Text = "GASTO ADMINISTRATIVO"
        '        f.cboEstatus.Text = "AVANCE DE OBRA"


        '    Case "GASTO DE VENTAS"
        '        f.Label4.Visible = False
        '        f.cboEstatus.Visible = False
        '        f.Label8.Visible = False
        '        f.txtInicio.Visible = False
        '        f.Label9.Visible = False
        '        f.txtFinaliza.Visible = False
        '        f.Label10.Visible = False
        '        f.Label3.Text = "OF. VENTAS"

        '        f.cboTipo.Text = "HOJA DE GASTO"
        '        f.cboSubtipo.Text = "GASTO DE VENTAS"
        '        f.cboEstatus.Text = "AVANCE DE OBRA"

        '    Case "GASTO FINANCIERO"
        '        f.Label4.Visible = False
        '        f.cboEstatus.Visible = False
        '        f.Label8.Visible = False
        '        f.txtInicio.Visible = False
        '        f.Label9.Visible = False
        '        f.txtFinaliza.Visible = False
        '        f.Label10.Visible = False
        '        f.Label3.Text = "OF. FINANZAS"

        '        f.cboTipo.Text = "HOJA DE GASTO"
        '        f.cboSubtipo.Text = "GASTO FINANCIERO"
        '        f.cboEstatus.Text = "AVANCE DE OBRA"

        'End Select

        'f.Manipulacion = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        ComboBoxAdv2_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        If Not IsNothing(dgvGestionCostos.Table.CurrentRecord) Then
            'Dim f As New frmNuevoCosto
            'f.Tag = Val(dgvGestionCostos.Table.CurrentRecord.GetValue("idcosto"))
            'f.Manipulacion = ENTITY_ACTIONS.UPDATE
            'f.UbicarCosto(New recursoCosto With {.idCosto = Val(dgvGestionCostos.Table.CurrentRecord.GetValue("idcosto"))})
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
            'ComboBoxAdv2_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Gasto administrativo"
        LoadRecursosoPorEstadoGastos(New recursoCosto With {.tipo = "HG", .subtipo = "GADM", .status = StatusCosto.Avance_Obra})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Gasto de ventas"
        LoadRecursosoPorEstadoGastos(New recursoCosto With {.tipo = "HG", .subtipo = "GAVT", .status = StatusCosto.Avance_Obra})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        ToolStripLabel1.Text = String.Empty
        dgvRecursosAsignados.Table.Records.DeleteAll()

        dockingManager1.SetDockVisibility(GradientPanel2, False)
        dockingManager1.SetDockVisibility(PanelEstadoProyecto, True)
        dockingRecursosAsignados()

        Me.Cursor = Cursors.WaitCursor
        TabProyecto.Parent = Nothing
        TabProduccion.Parent = Nothing
        TabActivo.Parent = Nothing
        TabGastoAdmin.Parent = Nothing
        TabGastoVenta.Parent = Nothing
        TabGastoFin.Parent = Nothing
        TabProductosTerminadosAlmacen.Parent = Nothing
        TabGestionCostos.Parent = Nothing
        TabEstadoCostos.Parent = TabControlAdv1
        TabEstadoCostos.Text = "Gasto financiero"
        LoadRecursosoPorEstadoGastos(New recursoCosto With {.tipo = "HG", .subtipo = "FIN", .status = StatusCosto.Avance_Obra})

        GridCFG2(dgvRecursosAsignados)
        GridCFG2(dgvEstadoCostos)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvGastoAdmin_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvGastoAdmin.TableControlCellClick

    End Sub

    Private Sub dgvGastoAdmin_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvGastoAdmin.TableControlCurrentCellCloseDropDown
        Me.Cursor = Cursors.WaitCursor
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvGastoAdmin.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 1
                    Dim recursoSA As New recursoCostoSA
                    Dim compraSA As New DocumentoCompraDetalleSA
                    'GrabarAsiento(Me.dgvCosto.Table.CurrentRecord)


                    compraSA.UpdateCostoItemSingle(New documentocompradetalle With {
                                          .secuencia = Val(dgvGastoAdmin.Table.CurrentRecord.GetValue("secuencia")),
                                          .idCosto = Val(dgvGastoAdmin.Table.CurrentRecord.GetValue("costo")),
                                          .tipoCosto = "GADM"
                                          })

                    With recursoSA.ObtenerCostoById(New recursoCosto With {.idCosto = Val(dgvGastoAdmin.Table.CurrentRecord.GetValue("costo"))})
                        dgvGastoAdmin.Table.CurrentRecord.SetValue("estado", "-")
                        dgvGastoAdmin.Table.CurrentRecord.SetValue("codigo", .codigo)
                        dgvGastoAdmin.Table.CurrentRecord.SetValue("tipo", .subtipo)
                        dgvGastoAdmin.Table.CurrentRecord.SetValue("produccion", .detalle)
                        dgvGastoAdmin.Table.CurrentRecord.SetValue("inicio", "-")
                        dgvGastoAdmin.Table.CurrentRecord.SetValue("finaliza", "-")
                    End With

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvGastoventas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvGastoventas.TableControlCellClick

    End Sub

    Private Sub dgvGastoventas_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvGastoventas.TableControlCurrentCellCloseDropDown
        Me.Cursor = Cursors.WaitCursor
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvGastoventas.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 1
                    Dim recursoSA As New recursoCostoSA
                    Dim compraSA As New DocumentoCompraDetalleSA
                    'GrabarAsiento(Me.dgvCosto.Table.CurrentRecord)


                    compraSA.UpdateCostoItemSingle(New documentocompradetalle With {
                                          .secuencia = Val(dgvGastoventas.Table.CurrentRecord.GetValue("secuencia")),
                                          .idCosto = Val(dgvGastoventas.Table.CurrentRecord.GetValue("costo")),
                                          .tipoCosto = "GAVT"
                                          })

                    With recursoSA.ObtenerCostoById(New recursoCosto With {.idCosto = Val(dgvGastoventas.Table.CurrentRecord.GetValue("costo"))})
                        dgvGastoventas.Table.CurrentRecord.SetValue("estado", "-")
                        dgvGastoventas.Table.CurrentRecord.SetValue("codigo", .codigo)
                        dgvGastoventas.Table.CurrentRecord.SetValue("tipo", .subtipo)
                        dgvGastoventas.Table.CurrentRecord.SetValue("produccion", .detalle)
                        dgvGastoventas.Table.CurrentRecord.SetValue("inicio", "-")
                        dgvGastoventas.Table.CurrentRecord.SetValue("finaliza", "-")
                    End With

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvGastoFin_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvGastoFin.TableControlCellClick

    End Sub

    Private Sub dgvGastoFin_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvGastoFin.TableControlCurrentCellCloseDropDown
        Me.Cursor = Cursors.WaitCursor
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvGastoFin.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 1
                    Dim recursoSA As New recursoCostoSA
                    Dim compraSA As New DocumentoCompraDetalleSA
                    'GrabarAsiento(Me.dgvCosto.Table.CurrentRecord)


                    compraSA.UpdateCostoItemSingle(New documentocompradetalle With {
                                          .secuencia = Val(dgvGastoFin.Table.CurrentRecord.GetValue("secuencia")),
                                          .idCosto = Val(dgvGastoFin.Table.CurrentRecord.GetValue("costo")),
                                          .tipoCosto = "FIN"
                                          })

                    With recursoSA.ObtenerCostoById(New recursoCosto With {.idCosto = Val(dgvGastoFin.Table.CurrentRecord.GetValue("costo"))})
                        dgvGastoFin.Table.CurrentRecord.SetValue("estado", "-")
                        dgvGastoFin.Table.CurrentRecord.SetValue("codigo", .codigo)
                        dgvGastoFin.Table.CurrentRecord.SetValue("tipo", .subtipo)
                        dgvGastoFin.Table.CurrentRecord.SetValue("produccion", .detalle)
                        dgvGastoFin.Table.CurrentRecord.SetValue("inicio", "-")
                        dgvGastoFin.Table.CurrentRecord.SetValue("finaliza", "-")
                    End With

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblConteo_Click(sender As Object, e As EventArgs) Handles lblConteo.Click
        Me.Cursor = Cursors.WaitCursor
        dockingManager1.SetDockLabel(GradientPanel2, "Recursos x asignar")
        'dockingManager1.DockControlInAutoHideMode(GradientPanel2, DockingStyle.Bottom, 300)
        dockingManager1.DockControl(GradientPanel2, Me, DockingStyle.Bottom, 300)
        dockingManager1.CloseEnabled = False
        dockingManager1.SetDockVisibility(GradientPanel2, True)
        ListaRecursosPendientes()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class