Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmGastosLibro

    Public Property ListaContable As New List(Of cuentaplanContableEmpresa)

#Region "Constructor"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GridCFGDetetail(dgvAsientosNoAsignados)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#End Region


#Region "Metodos"



    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA



        Dim dt As New DataTable()
        dt.Columns.Add("cuenta", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))



        'If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
        ListaContable = cuentaSA.CuentasServicios(Gempresas.IdEmpresaRuc).ToList
        'For Each i In cuentaSA.CuentasServicios(Gempresas.IdEmpresaRuc).ToList
        For Each i In ListaContable

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta & "-" & i.descripcion
            dt.Rows.Add(dr)
        Next

        'Else
        'For Each i In almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.idAlmacen
        '    dr(1) = i.descripcionAlmacen
        '    dt.Rows.Add(dr)
        'Next
        'End If


        Return dt
    End Function

    Public Sub RegistrarItemsAsignadosLibroAll()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA

        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)


            'ASIENTO MANUALES LIBRO DIARIO

            For Each i As Record In dgvAsientosNoAsignados.Table.Records
                Dim alm = i.GetValue("cuentaCont")
                If alm.ToString.Trim.Length > 0 Then

                    Select Case txtTipoCosteo.Text
                        Case "HC"
                            'validando edt seleccionado

                            obj = New recursoCostoDetalle With {
                                    .idCosto = txtidEntregable.Text,
                                    .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                    .iditem = Val(i.GetValue("cuenta")),
                                    .descripcion = i.GetValue("descripcionItem"),
                                    .montoMN = CDec(i.GetValue("importeMN")),
                                    .montoME = CDec(i.GetValue("importeME")),
                                    .documentoRef = CInt(i.GetValue("idDocumento")),
                                    .itemRef = CInt(i.GetValue("secuencia")),
                                    .cant = CDec(1),
                                    .operacion = i.GetValue("TipoOperacion"),
                                    .procesado = "N",
                                    .idProceso = txtidEntregable.Text,
                                  .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                  .Periodo = PeriodoGeneral,
                                    .elementoCosto = "CIFoci",
                            .tipoCosto = "HC"
                                }
                            Lista.Add(obj)

                            ' ''2
                            objAsiento = New asiento
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idEntidad = 0
                            objAsiento.nombreEntidad = "SIN IDENTIDAD"
                            objAsiento.tipoEntidad = "OT"
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.periodo = txtPeriodo.Text
                            objAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                            objAsiento.importeMN = CDec(i.GetValue("importeMN"))
                            objAsiento.importeME = CDec(i.GetValue("importeME"))
                            objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)



                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "231"
                            objMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("importeMN"))
                            objMovimiento.montoUSD = CDec(i.GetValue("importeME"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "189"
                            objMovimiento.descripcion = "OTROS GASTOS CONTRATADOS POR ANTICIPADO"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("importeMN"))
                            objMovimiento.montoUSD = CDec(i.GetValue("importeME"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)



                        Case "HG"

                            Dim cuenta = i.GetValue("cuentaCont")

                            Dim nombreCuenta = (From cue In ListaContable
                                               Where cue.cuenta = cuenta
                                               Select cue.descripcion).FirstOrDefault


                            '1//////////////////////////
                            objAsiento = New asiento
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idEntidad = 0
                            objAsiento.nombreEntidad = "SIN IDENTIDAD"
                            objAsiento.tipoEntidad = "OT"
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.periodo = txtPeriodo.Text
                            objAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                            objAsiento.importeMN = CDec(i.GetValue("importeMN"))
                            objAsiento.importeME = CDec(i.GetValue("importeME"))
                            objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)



                            objMovimiento = New movimiento
                            objMovimiento.cuenta = i.GetValue("cuentaCont")
                            objMovimiento.descripcion = CStr(nombreCuenta)
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("importeMN"))
                            objMovimiento.montoUSD = CDec(i.GetValue("importeME"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "189"
                            objMovimiento.descripcion = "OTROS GASTOS CONTRATADOS POR ANTICIPADO"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("importeMN"))
                            objMovimiento.montoUSD = CDec(i.GetValue("importeME"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            '2/////////////////////////
                            objAsiento = New asiento
                            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                            objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
                            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                            objAsiento.idEntidad = 0
                            objAsiento.nombreEntidad = "SIN IDENTIDAD"
                            objAsiento.tipoEntidad = "OT"
                            objAsiento.fechaProceso = DateTime.Now
                            objAsiento.periodo = txtPeriodo.Text
                            objAsiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
                            objAsiento.tipo = "D"
                            objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                            objAsiento.importeMN = CDec(i.GetValue("importeMN"))
                            objAsiento.importeME = CDec(i.GetValue("importeME"))
                            objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)



                            objMovimiento = New movimiento
                            objMovimiento.cuenta = txtCuentaGasto.Text
                            objMovimiento.descripcion = txtProyectoGeneral.Text
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("importeMN"))
                            objMovimiento.montoUSD = CDec(i.GetValue("importeME"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "791"
                            objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("importeMN"))
                            objMovimiento.montoUSD = CDec(i.GetValue("importeME"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)



                            obj = New recursoCostoDetalle With {
                                             .idCosto = txtidEntregable.Text,
                                    .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                    .iditem = CInt(i.GetValue("cuentaCont")),
                                    .descripcion = CStr(nombreCuenta),
                                    .montoMN = CDec(i.GetValue("importeMN")),
                                    .montoME = CDec(i.GetValue("importeME")),
                                    .documentoRef = CInt(i.GetValue("idDocumento")),
                                    .itemRef = CInt(i.GetValue("secuencia")),
                                     .cant = CDec(1),
                                    .operacion = i.GetValue("TipoOperacion"),
                                    .procesado = "N",
                                    .idProceso = txtidEntregable.Text,
                                  .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                  .Periodo = PeriodoGeneral,
                                    .elementoCosto = "CIFoci",
                                      .tipoCosto = "HG"
                                }
                            Lista.Add(obj)


                            '.idCosto = CInt(i.GetValue("idEDT")),
                            '               .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                            '               .iditem = Val(i.GetValue("cuenta")),
                            '               .descripcion = i.GetValue("descripcionItem"),
                            '               .montoMN = CDec(i.GetValue("importeMN")),
                            '               .montoME = CDec(i.GetValue("importeME")),
                            '               .documentoRef = CInt(i.GetValue("idDocumento")),
                            '               .itemRef = CInt(i.GetValue("secuencia")),
                            '               .operacion = i.GetValue("TipoOperacion"),
                            '               .procesado = "N",
                            '               .idProceso = CInt(i.GetValue("idEDT")),
                            '           .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                            '          .Periodo = PeriodoGeneral,

                    End Select
                    'hasta aqui


                    'End Select
                Else

                    MessageBox.Show("Inghre una Cuenta para el servicio")
                    Exit Sub
                End If

            Next

            costoSA.GrabarDetalleRecursosLibro(Lista, listaAsiento)
            GetItemsAsientosNoAsignados()
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub RegistrarItemsAsignadosLibro()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA

        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)


            'ASIENTO MANUALES LIBRO DIARIO

            For Each i As SelectedRecord In dgvAsientosNoAsignados.Table.SelectedRecords

                Select Case i.Record.GetValue("abrev")
                    Case "HC"
                        'validando edt seleccionado

                        obj = New recursoCostoDetalle With {
                                .idCosto = CInt(i.Record.GetValue("idEDT")),
                                .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                .iditem = Val(i.Record.GetValue("cuenta")),
                                .descripcion = i.Record.GetValue("descripcionItem"),
                                .montoMN = CDec(i.Record.GetValue("importeMN")),
                                .montoME = CDec(i.Record.GetValue("importeME")),
                                .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                .itemRef = CInt(i.Record.GetValue("secuencia")),
                                .operacion = i.Record.GetValue("TipoOperacion"),
                                .procesado = "N",
                                .idProceso = CInt(i.Record.GetValue("idEDT")),
                              .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
                              .Periodo = PeriodoGeneral,
                                  .tipoCosto = "HC"
                            }
                        Lista.Add(obj)
                        'End Select
                        'asiento por tipo
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
                        objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                        objAsiento.importeME = CDec(i.Record.GetValue("importeME"))
                        objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = i.Record.GetValue("cuentaCosteo")
                        objMovimiento.descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("importeMN"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("importeME"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "791"
                        objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("importeMN"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("importeME"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        ''2
                        objAsiento = New asiento
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        objAsiento.idEntidad = CDec(i.Record.GetValue("importeME"))
                        objAsiento.nombreEntidad = "SIN IDENTIDAD"
                        objAsiento.tipoEntidad = "OT"
                        objAsiento.fechaProceso = DateTime.Now
                        objAsiento.periodo = txtPeriodo.Text
                        objAsiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
                        objAsiento.tipo = "D"
                        objAsiento.tipoAsiento = ASIENTO_CONTABLE.Entregables
                        objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                        objAsiento.importeME = 0
                        objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("importeMN"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("importeME"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "711"
                        objMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("importeMN"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("importeME"))
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
                        objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                        objAsiento.importeME = CDec(i.Record.GetValue("importeME"))
                        objAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "694"
                        objMovimiento.descripcion = "SERVICIOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("importeMN"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("importeME"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("importeMN"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("importeME"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)




                    Case "HG"

                        objAsiento = New asiento
                        objAsiento.periodo = PeriodoGeneral
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
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
                        objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                        objAsiento.importeME = CDec(i.Record.GetValue("importeME"))


                        objAsiento.glosa = "Ingreso a centro de costo"
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = DateTime.Now

                        'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

                        objMovimiento = New movimiento With {
                                      .cuenta = i.Record.GetValue("cuentaCosteo"),
                                      .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                      .tipo = "H",
                                      .monto = CDec(i.Record.GetValue("importeMN")),
                                      .montoUSD = CDec(i.Record.GetValue("importeME")),
                                      .usuarioActualizacion = usuario.IDUsuario,
                                      .fechaActualizacion = DateTime.Now
                                  }
                        objAsiento.movimiento.Add(objMovimiento)


                        objMovimiento = New movimiento With {
                                        .cuenta = "791",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "D",
                                        .monto = CDec(i.Record.GetValue("importeMN")),
                                        .montoUSD = CDec(i.Record.GetValue("importeME")),
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                        objAsiento.movimiento.Add(objMovimiento)

                        listaAsiento.Add(objAsiento)

                        '    objAsiento = New asiento
                        '    objAsiento.periodo = PeriodoGeneral
                        '    objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        '    objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                        '    objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                        '    objAsiento.idDocumentoRef = Nothing
                        '    objAsiento.idAlmacen = 0
                        '    objAsiento.nombreAlmacen = String.Empty
                        '    objAsiento.idEntidad = String.Empty
                        '    objAsiento.nombreEntidad = String.Empty
                        '    objAsiento.tipoEntidad = String.Empty
                        '    objAsiento.fechaProceso = DateTime.Now
                        '    objAsiento.codigoLibro = "8"
                        '    objAsiento.tipo = "D"
                        '    objAsiento.tipoAsiento = "ACCA"

                        '    If i.Record.GetValue("importeMN") < 0 Then
                        '        objAsiento.importeMN = CDec(i.Record.GetValue("importeMN")) * -1
                        '        objAsiento.importeME = CDec(i.Record.GetValue("importeME")) * -1
                        '    Else
                        '        objAsiento.importeMN = CDec(i.Record.GetValue("importeMN"))
                        '        objAsiento.importeME = CDec(i.Record.GetValue("importeME"))
                        '    End If


                        '    objAsiento.glosa = "Ingreso a centro de costo"
                        '    objAsiento.usuarioActualizacion = usuario.IDUsuario
                        '    objAsiento.fechaActualizacion = DateTime.Now

                        'recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

                        'If i.Record.GetValue("importeMN") > 0 Then
                        '        objMovimiento = New movimiento With {
                        '          .cuenta = recurso.codigo,
                        '          .descripcion = recurso.nombreCosto,
                        '          .tipo = "D",
                        '          .monto = CDec(i.Record.GetValue("importeMN")),
                        '          .montoUSD = CDec(i.Record.GetValue("importeME")),
                        '          .usuarioActualizacion = usuario.IDUsuario,
                        '          .fechaActualizacion = DateTime.Now
                        '      }
                        '        objAsiento.movimiento.Add(objMovimiento)


                        '        objMovimiento = New movimiento With {
                        '            .cuenta = "791",
                        '            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                        '            .tipo = "H",
                        '            .monto = CDec(i.Record.GetValue("importeMN")),
                        '            .montoUSD = CDec(i.Record.GetValue("importeME")),
                        '            .usuarioActualizacion = usuario.IDUsuario,
                        '            .fechaActualizacion = DateTime.Now
                        '        }
                        '        objAsiento.movimiento.Add(objMovimiento)
                        '        'SI ES NEGATIVO
                        '    Else
                        '        objMovimiento = New movimiento With {
                        '         .cuenta = recurso.codigo,
                        '         .descripcion = recurso.nombreCosto,
                        '         .tipo = "D",
                        '         .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                        '         .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                        '         .usuarioActualizacion = usuario.IDUsuario,
                        '         .fechaActualizacion = DateTime.Now
                        '     }
                        '        objAsiento.movimiento.Add(objMovimiento)


                        '        objMovimiento = New movimiento With {
                        '            .cuenta = "791",
                        '            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                        '            .tipo = "H",
                        '            .monto = CDec(i.Record.GetValue("importeMN")) * -1,
                        '            .montoUSD = CDec(i.Record.GetValue("importeME")) * -1,
                        '            .usuarioActualizacion = usuario.IDUsuario,
                        '            .fechaActualizacion = DateTime.Now
                        '        }
                        '        objAsiento.movimiento.Add(objMovimiento)
                        '    End If
                        '    listaAsiento.Add(objAsiento)

                        obj = New recursoCostoDetalle With {
                                        .idCosto = CInt(i.Record.GetValue("idEDT")),
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("cuenta")),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .montoMN = CDec(i.Record.GetValue("importeMN")),
                                        .montoME = CDec(i.Record.GetValue("importeME")),
                                        .documentoRef = CInt(i.Record.GetValue("secuencia")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                              .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
                              .Periodo = PeriodoGeneral,
                                  .tipoCosto = "HG"
                            }
                        Lista.Add(obj)
                End Select
                'hasta aqui


                'End Select


            Next






            costoSA.GrabarDetalleRecursosLibro(Lista, listaAsiento)
            GetItemsAsientosNoAsignados()
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetGastosNoAsignados(idCosto As Integer)
        Dim libroSA As New documentoLibroDiarioSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("TipoOperacion")
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
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("cuentaCosteo")
        dt.Columns.Add("glosa")
        dt.Columns.Add("cuentaCont")

        For Each i In libroSA.ListaRecursosGastoLibroEntregable(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                                .fechaPeriodo = PeriodoGeneral, .idCosto = idCosto})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.fecha
            dr(3) = i.tipoDocumento
            dr(4) = i.nroDoc
            dr(5) = i.moneda
            dr(6) = i.cuenta
            dr(7) = i.descripcion

            If i.tipoAsiento = "D" Then
                dr(8) = i.importeMN
                dr(9) = i.importeME
            Else
                dr(8) = (i.importeMN) * -1
                dr(9) = (i.importeME) * -1
            End If


            dr(10) = i.operacion
            dr(11) = 0
            dr(12) = ""
            dr(13) = Nothing
            dr(14) = Nothing
            dr(15) = i.idCosto
            dr(16) = i.NombreRazon
            dr(17) = Nothing
            dr(18) = Nothing
            dr(19) = Nothing
            If i.tipoCosto = "PC" Then
                dr(20) = "HC"
            ElseIf i.tipoCosto = "PG" Then
                dr(20) = "HG"
            End If

            dr(21) = DateTime.Now
            dr(22) = i.cuentaCosto
            dr(23) = i.glosa
            dt.Rows.Add(dr)
        Next



        dgvAsientosNoAsignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvAsientosNoAsignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub


    Public Sub GetItemsAsientosNoAsignados()
        Dim libroSA As New documentoLibroDiarioSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("TipoOperacion")
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
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("cuentaCosteo")
        dt.Columns.Add("glosa")
        dt.Columns.Add("cuentaCont")

        For Each i In libroSA.ListaRecursosCostoLibroEntregable(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                                .fechaPeriodo = PeriodoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.fecha
            dr(3) = i.tipoDocumento
            dr(4) = i.nroDoc
            dr(5) = i.moneda
            dr(6) = i.cuenta
            dr(7) = i.descripcion

            If i.tipoAsiento = "D" Then
                dr(8) = i.importeMN
                dr(9) = i.importeME
            Else
                dr(8) = (i.importeMN) * -1
                dr(9) = (i.importeME) * -1
            End If


            dr(10) = i.operacion
            dr(11) = 0
            dr(12) = ""
            dr(13) = Nothing
            dr(14) = Nothing
            dr(15) = i.idCosto
            dr(16) = i.NombreRazon
            dr(17) = Nothing
            dr(18) = Nothing
            dr(19) = Nothing
            If i.tipoCosto = "PC" Then
                dr(20) = "HC"
            ElseIf i.tipoCosto = "PG" Then
                dr(20) = "HG"
            End If

            dr(21) = DateTime.Now
            dr(22) = i.cuentaCosto
            dr(23) = i.glosa
            dt.Rows.Add(dr)
        Next



        dgvAsientosNoAsignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvAsientosNoAsignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

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

    Dim comboTableP As New DataTable

    Private Sub frmGastosLibro_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub frmGastosLibro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Private Sub frmCosteoLibro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtTipoCosteo.Text = "HC" Then

            GetItemsAsientosNoAsignados()

        ElseIf txtTipoCosteo.Text = "HG" Then

            GetGastosNoAsignados(txtidEntregable.Text)

        End If

        comboTableP = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvAsientosNoAsignados.TableDescriptor.Columns(24).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTableP
        ggcStyle.ValueMember = "cuenta"
        ggcStyle.DisplayMember = "descripcion"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvAsientosNoAsignados.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvAsientosNoAsignados.ShowRowHeaders = False

        txtPeriodo.Text = PeriodoGeneral
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If dgvAsientosNoAsignados.Table.Records.Count > 0 Then
            If dgvAsientosNoAsignados.Table.SelectedRecords.Count > 0 Then

                RegistrarItemsAsignadosLibro()

            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If dgvAsientosNoAsignados.Table.Records.Count > 0 Then



            RegistrarItemsAsignadosLibroAll()


        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgvAsientosNoAsignados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAsientosNoAsignados.TableControlCellClick

    End Sub

    Private Sub dgvAsientosNoAsignados_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvAsientosNoAsignados.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub
End Class