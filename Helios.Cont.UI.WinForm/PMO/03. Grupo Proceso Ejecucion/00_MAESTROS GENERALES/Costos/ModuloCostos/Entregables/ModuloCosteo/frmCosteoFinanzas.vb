Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmCosteoFinanzas

    Public Property documentocajaSA As New DocumentoCajaSA
    Dim oper As Object
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        GridCFG(dgFinanzas)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


#Region "Metodos"

    Public Sub RegistrarFinanzasAll()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA

        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        ' Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)

            'FINANZAS
            '--------------------------------------------------------------------------------------------
            For Each i As Record In dgFinanzas.Table.Records

                Select Case i.GetValue("abrev")
                    Case "HC"
                        'validando edt seleccionado






                        Select Case i.GetValue("movimientoCaja")
                            Case MovimientoCaja.Otras_Entradas
                                oper = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                            Case MovimientoCaja.Otras_Saliadas
                                oper = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                            Case MovimientoCaja.TrasferenciaEntreCajas
                                oper = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
                        End Select

                        obj = New recursoCostoDetalle With {
                                         .idCosto = CInt(i.GetValue("idEDT")),
                                        .fechaRegistro = CDate(i.GetValue("fechaCobro")),
                                        .iditem = Val(i.GetValue("entidadFinanciera")),
                                        .destino = "1",
                                        .descripcion = i.GetValue("glosa"),
                                        .um = "UND",
                                        .cant = 1,
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.GetValue("montoSoles")),
                                        .montoME = CDec(i.GetValue("montoUsd")),
                                        .documentoRef = CInt(i.GetValue("secuencia")),
                                        .itemRef = 0,
                                        .operacion = oper,
                                        .procesado = "N",
                                        .idProceso = CInt(i.GetValue("idEDT")),
                                      .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                      .Periodo = PeriodoGeneral,
                                       .tipoCosto = "HC"
                                    }
                        Lista.Add(obj)


                        objAsiento = New asiento
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                        objAsiento.idEntidad = 0
                        objAsiento.nombreEntidad = "SIN IDENTIDAD"
                        objAsiento.tipoEntidad = "OT"
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.periodo = txtPeriodo.Text
                        objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                        objAsiento.importeMN = CDec(i.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.GetValue("montoUsd"))
                        objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = i.GetValue("cuentaCosteo")
                        objMovimiento.descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "791"
                        objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        ''2
                        objAsiento = New asiento
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idEntidad = 0
                        objAsiento.nombreEntidad = "SIN IDENTIDAD"
                        objAsiento.tipoEntidad = "OT"
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.periodo = txtPeriodo.Text
                        objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                        objAsiento.importeMN = CDec(i.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.GetValue("montoUsd"))
                        objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "711"
                        objMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        ''3
                        objAsiento = New asiento
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                        objAsiento.idEntidad = 0
                        objAsiento.nombreEntidad = "SIN IDENTIDAD"
                        objAsiento.tipoEntidad = "OT"
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.periodo = txtPeriodo.Text
                        objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                        objAsiento.importeMN = CDec(i.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.GetValue("montoUsd"))
                        objAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "694"
                        objMovimiento.descripcion = "SERVICIOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)



                    Case "HG"
                        'objAsiento = New asiento
                        'objAsiento.periodo = PeriodoGeneral
                        'objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        'objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        'objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                        'objAsiento.idDocumentoRef = Nothing
                        'objAsiento.idAlmacen = 0
                        'objAsiento.nombreAlmacen = String.Empty
                        'objAsiento.idEntidad = String.Empty
                        'objAsiento.nombreEntidad = String.Empty
                        'objAsiento.tipoEntidad = String.Empty
                        'objAsiento.fechaProceso = DateTime.Now
                        'objAsiento.codigoLibro = "8"
                        'objAsiento.tipo = "D"
                        'objAsiento.tipoAsiento = "ACCA"
                        'objAsiento.importeMN = CDec(i.GetValue("montoSoles"))
                        'objAsiento.importeME = CDec(i.GetValue("montoUsd"))


                        'objAsiento.glosa = "Ingreso a centro de costo"
                        'objAsiento.usuarioActualizacion = usuario.IDUsuario
                        'objAsiento.fechaActualizacion = DateTime.Now

                        'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.GetValue("idEDT")})

                        'objMovimiento = New movimiento With {
                        '      .cuenta = recurso.codigo,
                        '      .descripcion = recurso.nombreCosto,
                        '      .tipo = "D",
                        '      .monto = CDec(i.GetValue("montoSoles")),
                        '      .montoUSD = CDec(i.GetValue("montoUsd")),
                        '      .usuarioActualizacion = usuario.IDUsuario,
                        '      .fechaActualizacion = DateTime.Now
                        '  }
                        'objAsiento.movimiento.Add(objMovimiento)


                        'objMovimiento = New movimiento With {
                        '        .cuenta = "791",
                        '        .descripcion = "COSTOS POR DISTRIBUIR.",
                        '        .tipo = "H",
                        '        .monto = CDec(i.GetValue("montoSoles")),
                        '        .montoUSD = CDec(i.GetValue("montoUsd")),
                        '        .usuarioActualizacion = usuario.IDUsuario,
                        '        .fechaActualizacion = DateTime.Now
                        '    }
                        'objAsiento.movimiento.Add(objMovimiento)

                        'listaAsiento.Add(objAsiento)


                        objAsiento = New asiento
                        objAsiento.periodo = PeriodoGeneral
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                        objAsiento.idDocumentoRef = Nothing
                        objAsiento.idAlmacen = 0
                        objAsiento.nombreAlmacen = String.Empty
                        objAsiento.idEntidad = String.Empty
                        objAsiento.nombreEntidad = String.Empty
                        objAsiento.tipoEntidad = String.Empty
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.codigoLibro = "8"
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = "ACCA"
                        objAsiento.importeMN = CDec(i.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.GetValue("montoUsd"))


                        objAsiento.glosa = "Ingreso a centro de costo"
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = DateTime.Now

                        'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

                        objMovimiento = New movimiento With {
                                      .cuenta = i.GetValue("cuentaCosteo"),
                                      .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                      .tipo = "D",
                                      .monto = CDec(i.GetValue("montoSoles")),
                                      .montoUSD = CDec(i.GetValue("montoUsd")),
                                      .usuarioActualizacion = usuario.IDUsuario,
                                      .fechaActualizacion = DateTime.Now
                                  }
                        objAsiento.movimiento.Add(objMovimiento)


                        objMovimiento = New movimiento With {
                                        .cuenta = "791",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "H",
                                        .monto = CDec(i.GetValue("montoSoles")),
                                        .montoUSD = CDec(i.GetValue("montoUsd")),
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                        objAsiento.movimiento.Add(objMovimiento)

                        listaAsiento.Add(objAsiento)


                        Select Case i.GetValue("movimientoCaja")
                            Case MovimientoCaja.Otras_Entradas
                                oper = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                            Case MovimientoCaja.Otras_Saliadas
                                oper = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                            Case MovimientoCaja.TrasferenciaEntreCajas
                                oper = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
                        End Select

                        obj = New recursoCostoDetalle With {
                                         .idCosto = CInt(i.GetValue("idEDT")),
                                        .fechaRegistro = CDate(i.GetValue("fechaCobro")),
                                        .iditem = Val(i.GetValue("entidadFinanciera")),
                                        .destino = "1",
                                        .descripcion = i.GetValue("glosa"),
                                        .um = "UND",
                                        .cant = 1,
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.GetValue("montoSoles")),
                                        .montoME = CDec(i.GetValue("montoUsd")),
                                        .documentoRef = CInt(i.GetValue("secuencia")),
                                        .itemRef = 0,
                                        .operacion = oper,
                                        .procesado = "N",
                                        .idProceso = CInt(i.GetValue("idEDT")),
                                      .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                      .Periodo = PeriodoGeneral,
                                       .tipoCosto = "HG"}
                        Lista.Add(obj)

                End Select
            Next

            costoSA.GrabarDetalleRecursoFinanza(Lista, listaAsiento)
            GetItemsNoAsignadosFinanzas(txtidEntregable.Text)
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub RegistrarFinanzas()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA

        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        ' Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)

            'FINANZAS
            '--------------------------------------------------------------------------------------------
            For Each i As SelectedRecord In dgFinanzas.Table.SelectedRecords

                Select Case i.Record.GetValue("abrev")
                    Case "HC"
                        'validando edt seleccionado






                        Select Case i.Record.GetValue("movimientoCaja")
                            Case MovimientoCaja.Otras_Entradas
                                oper = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                            Case MovimientoCaja.Otras_Saliadas
                                oper = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                            Case MovimientoCaja.TrasferenciaEntreCajas
                                oper = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
                        End Select

                        obj = New recursoCostoDetalle With {
                                         .idCosto = CInt(i.Record.GetValue("idEDT")),
                                        .fechaRegistro = CDate(i.Record.GetValue("fechaCobro")),
                                        .iditem = Val(i.Record.GetValue("entidadFinanciera")),
                                        .destino = "1",
                                        .descripcion = i.Record.GetValue("glosa"),
                                        .um = "UND",
                                        .cant = 1,
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montoSoles")),
                                        .montoME = CDec(i.Record.GetValue("montoUsd")),
                                        .documentoRef = CInt(i.Record.GetValue("secuencia")),
                                        .itemRef = 0,
                                        .operacion = oper,
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                      .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
                                      .Periodo = PeriodoGeneral,
                                       .tipoCosto = "HC"
                                    }
                        Lista.Add(obj)


                        'ASIENTO SEGUN TIPO 
                        objAsiento = New asiento
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idEntidad = 0
                        objAsiento.nombreEntidad = "SIN IDENTIDAD"
                        objAsiento.tipoEntidad = "OT"
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.periodo = txtPeriodo.Text
                        objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                        objAsiento.importeMN = CDec(i.Record.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montoUsd"))
                        objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = i.Record.GetValue("cuentaCosteo")
                        objMovimiento.descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "791"
                        objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        ''2
                        objAsiento = New asiento
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idEntidad = 0
                        objAsiento.nombreEntidad = "SIN IDENTIDAD"
                        objAsiento.tipoEntidad = "OT"
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.periodo = txtPeriodo.Text
                        objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                        objAsiento.importeMN = CDec(i.Record.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montoUsd"))
                        objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "711"
                        objMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        ''3
                        objAsiento = New asiento
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idEntidad = 0
                        objAsiento.nombreEntidad = "SIN IDENTIDAD"
                        objAsiento.tipoEntidad = "OT"
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.periodo = txtPeriodo.Text
                        objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                        objAsiento.importeMN = CDec(i.Record.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montoUsd"))
                        objAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "694"
                        objMovimiento.descripcion = "SERVICIOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("montoSoles"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montoUsd"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)




                    Case "HG"

                        objAsiento = New asiento
                        objAsiento.periodo = PeriodoGeneral
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idDocumentoRef = Nothing
                        objAsiento.idAlmacen = 0
                        objAsiento.nombreAlmacen = String.Empty
                        objAsiento.idEntidad = String.Empty
                        objAsiento.nombreEntidad = String.Empty
                        objAsiento.tipoEntidad = String.Empty
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.codigoLibro = "8"
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = "ACCA"
                        objAsiento.importeMN = CDec(i.Record.GetValue("montoSoles"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montoUsd"))


                        objAsiento.glosa = "Ingreso a centro de costo"
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = DateTime.Now

                        'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

                        objMovimiento = New movimiento With {
                                      .cuenta = i.Record.GetValue("cuentaCosteo"),
                                      .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                      .tipo = "D",
                                      .monto = CDec(i.Record.GetValue("montoSoles")),
                                      .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                      .usuarioActualizacion = usuario.IDUsuario,
                                      .fechaActualizacion = DateTime.Now
                                  }
                        objAsiento.movimiento.Add(objMovimiento)


                        objMovimiento = New movimiento With {
                                        .cuenta = "791",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "H",
                                        .monto = CDec(i.Record.GetValue("montoSoles")),
                                        .montoUSD = CDec(i.Record.GetValue("montoUsd")),
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                        objAsiento.movimiento.Add(objMovimiento)

                        listaAsiento.Add(objAsiento)

                        Select Case i.Record.GetValue("movimientoCaja")
                            Case MovimientoCaja.Otras_Entradas
                                oper = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                            Case MovimientoCaja.Otras_Saliadas
                                oper = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                            Case MovimientoCaja.TrasferenciaEntreCajas
                                oper = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
                        End Select

                        obj = New recursoCostoDetalle With {
                                         .idCosto = CInt(i.Record.GetValue("idEDT")),
                                        .fechaRegistro = CDate(i.Record.GetValue("fechaCobro")),
                                        .iditem = Val(i.Record.GetValue("entidadFinanciera")),
                                        .destino = "1",
                                        .descripcion = i.Record.GetValue("glosa"),
                                        .um = "UND",
                                        .cant = 1,
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montoSoles")),
                                        .montoME = CDec(i.Record.GetValue("montoUsd")),
                                        .documentoRef = CInt(i.Record.GetValue("secuencia")),
                                        .itemRef = 0,
                                        .operacion = oper,
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                      .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
                                      .Periodo = PeriodoGeneral,
                                       .tipoCosto = "HG"}
                        Lista.Add(obj)

                End Select
            Next

            costoSA.GrabarDetalleRecursoFinanza(Lista, listaAsiento)
            'GetItemsNoAsignadosFinanzas()
            GetItemsNoAsignadosFinanzas(txtidEntregable.Text)
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GetGastosAsignadosFinanzas(idCosto As Integer)
        documentocajaSA = New DocumentoCajaSA()
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("movimientoCaja")
        dt.Columns.Add("fechaCobro")
        dt.Columns.Add("entidadFinanciera")
        dt.Columns.Add("tipoDocPago")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("moneda")
        dt.Columns.Add("montoSoles")
        dt.Columns.Add("montoUsd")
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")
        dt.Columns.Add("glosa")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("cuentaCosteo")

        Dim lista = documentocajaSA.GastosFinanzas(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                            .idcosto = idCosto})


        For Each i In lista


            dt.Rows.Add(i.idDocumento,
                        i.movimientoCaja,
                        i.fechaCobro,
                        i.entidadFinanciera,
                        i.tipoDocPago,
                        i.numeroDoc,
                        i.moneda, i.montoSoles, i.montoUsd,
                        Nothing, Nothing, Nothing, Nothing, i.idcosto,
                        i.nombreCosto, Nothing, Nothing, Nothing, i.tipoCosto,
                        i.glosa, DateTime.Now, i.idEstado, i.cuentaCosteo)
        Next

        dgFinanzas.DataSource = dt ' documentocajaSA.GetItemsNoAsignadosFinanzas(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '.asientoCosto = StatusAsientoCosto.AsientoPorConfirmar})
    End Sub


    Private Sub GetItemsNoAsignadosFinanzas(idCosto As Integer)
        DocumentoCajaSA = New DocumentoCajaSA()
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("movimientoCaja")
        dt.Columns.Add("fechaCobro")
        dt.Columns.Add("entidadFinanciera")
        dt.Columns.Add("tipoDocPago")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("moneda")
        dt.Columns.Add("montoSoles")
        dt.Columns.Add("montoUsd")
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")
        dt.Columns.Add("glosa")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("cuentaCosteo")

        Dim lista = DocumentoCajaSA.GetItemsNoAsignadosFinanzas(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                            .idcosto = idCosto})


        For Each i In lista


            dt.Rows.Add(i.idDocumento,
                        i.movimientoCaja,
                        i.fechaCobro,
                        i.entidadFinanciera,
                        i.tipoDocPago,
                        i.numeroDoc,
                        i.moneda, i.montoSoles, i.montoUsd,
                        Nothing, Nothing, Nothing, Nothing, i.idcosto,
                        i.nombreCosto, Nothing, Nothing, Nothing, i.tipoCosto,
                        i.glosa, DateTime.Now, i.idEstado, i.cuentaCosteo)
        Next

        dgFinanzas.DataSource = dt ' documentocajaSA.GetItemsNoAsignadosFinanzas(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '.asientoCosto = StatusAsientoCosto.AsientoPorConfirmar})
    End Sub


    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

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
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region
    Private Sub frmCosteoFinanzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        If txtTipoCosteo.Text = "HC" Then
            GetItemsNoAsignadosFinanzas(txtidEntregable.Text)
        ElseIf txtTipoCosteo.Text = "HG" Then
            GetGastosAsignadosFinanzas(txtidEntregable.Text)
        End If
        txtPeriodo.Text = PeriodoGeneral
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If dgFinanzas.Table.Records.Count > 0 Then



            RegistrarFinanzasAll()


        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click



        If dgFinanzas.Table.Records.Count > 0 Then
            If dgFinanzas.Table.SelectedRecords.Count > 0 Then

                RegistrarFinanzas()

            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


End Class