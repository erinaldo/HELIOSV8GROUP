Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmCosteoInventario

    Public Property RecursoEnvio As New recursoCostoDetalle
    Public Property listaAsientoEnvio As New List(Of asiento)



    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GridCFG(GridGroupingControl1)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Metodos"

    Public Sub RegistrarItemsAsignadosAll()
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




            'INVENTARIO PENDIENTE DE ENVIO
            '-----------------------------------------------------------

            'For Each r As Record In dgvCompra.Table.Records
            '    objDocumentoCompraDet = New documentocompradetalle
            '    'Validando el nro de lote
            '    If TmpProduccionPorLotes = True Then
            '        Dim nroLotex = r.GetValue("lote").ToString

            '        If nroLotex.ToString.Trim.Length > 0 Then
            '            If costoSA.ExisteCodigoLote(r.GetValue("lote")) = True Then


            For Each i As Record In GridGroupingControl1.Table.Records
                Select Case i.GetValue("abrev")
                    Case "HC"
                        'validando edt seleccionado
                        Dim valEdt = i.GetValue("edt")
                        If IsNothing(valEdt) Then
                            MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        If valEdt.ToString.Trim.Length <= 0 Then
                            MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        'Select Case i.GetValue("TipoDoc")
                        '    Case "07" 'NOTA DE CREDITO

                        '    Case Else
                        If i.GetValue("tipoCompra") = "OEA" Then
                            ' si hay devolucion por produccion

                            obj = New recursoCostoDetalle With {
                                        .idCosto = CInt(i.GetValue("idEDT")),
                                        .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                        .iditem = Val(i.GetValue("idItem")),
                                        .destino = i.GetValue("destino"),
                                        .descripcion = i.GetValue("descripcionItem"),
                                        .um = i.GetValue("unidad1"),
                                        .cant = CDec(i.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.GetValue("montokardex")) * -1,
                                        .montoME = CDec(i.GetValue("montokardexUS")) * -1,
                                        .documentoRef = CInt(i.GetValue("idDocumento")),
                                        .itemRef = CInt(i.GetValue("secuencia")),
                                        .operacion = i.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                        .Periodo = PeriodoGeneral,
                                        .idProceso = CInt(i.GetValue("idEDT")),
                                    .tipoCosto = "HC"
                                    }
                            Lista.Add(obj)
                            ' End Select

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
                            objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.GetValue("montokardexUS"))
                            objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = i.GetValue("cuentaCosteo")
                            objMovimiento.descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "791"
                            objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
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
                            objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.GetValue("montokardexUS"))
                            objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "211"
                            objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "711"
                            objMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
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
                            objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.GetValue("montokardexUS"))
                            objAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "694"
                            objMovimiento.descripcion = "SERVICIOS"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "211"
                            objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            '/////////////////////// DEVOLUCION DE PRODUCCION

                        Else



                            obj = New recursoCostoDetalle With {
                                .idCosto = CInt(i.GetValue("idEDT")),
                                .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                .iditem = Val(i.GetValue("idItem")),
                                .destino = i.GetValue("destino"),
                                .descripcion = i.GetValue("descripcionItem"),
                                .um = i.GetValue("unidad1"),
                                .cant = CDec(i.GetValue("monto1")),
                                .puMN = 0,
                                .puME = 0,
                                .montoMN = CDec(i.GetValue("montokardex")),
                                .montoME = CDec(i.GetValue("montokardexUS")),
                                .documentoRef = CInt(i.GetValue("idDocumento")),
                                .itemRef = CInt(i.GetValue("secuencia")),
                                .operacion = i.GetValue("TipoOperacion"),
                                .procesado = "N",
                                .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                .Periodo = PeriodoGeneral,
                                .idProceso = CInt(i.GetValue("idEDT")),
                            .tipoCosto = "HC"
                            }
                            Lista.Add(obj)
                            ' End Select

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
                            objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.GetValue("montokardexUS"))
                            objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = i.GetValue("cuentaCosteo")
                            objMovimiento.descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "791"
                            objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
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
                            objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.GetValue("montokardexUS"))
                            objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "211"
                            objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "711"
                            objMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
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
                            objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                            objAsiento.importeME = CDec(i.GetValue("montokardexUS"))
                            objAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtEntregable.Text
                            objAsiento.usuarioActualizacion = usuario.IDUsuario
                            objAsiento.fechaActualizacion = Date.Now
                            listaAsiento.Add(objAsiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "694"
                            objMovimiento.descripcion = "SERVICIOS"
                            objMovimiento.tipo = "D"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                            objMovimiento = New movimiento
                            objMovimiento.cuenta = "211"
                            objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                            objMovimiento.tipo = "H"
                            objMovimiento.monto = CDec(i.GetValue("montokardex"))
                            objMovimiento.montoUSD = CDec(i.GetValue("montokardexUS"))
                            objMovimiento.usuarioActualizacion = usuario.IDUsuario
                            objMovimiento.fechaActualizacion = Date.Now
                            objAsiento.movimiento.Add(objMovimiento)

                        End If


                    Case "HG"


                        'martin
                        objAsiento = New asiento
                        objAsiento.periodo = PeriodoGeneral
                        objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                        objAsiento.idDocumento = Val(i.GetValue("idDocumento"))
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
                        objAsiento.importeMN = CDec(i.GetValue("montokardex"))
                        objAsiento.importeME = CDec(i.GetValue("montokardexUS"))


                        objAsiento.glosa = "Ingreso a centro de costo"
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = DateTime.Now

                        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.GetValue("idEDT")})

                        objMovimiento = New movimiento With {
                                      .cuenta = i.GetValue("cuentaCosteo"),
                                      .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                      .tipo = "H",
                                      .monto = CDec(i.GetValue("montokardex")),
                                      .montoUSD = CDec(i.GetValue("montokardexUS")),
                                      .usuarioActualizacion = usuario.IDUsuario,
                                      .fechaActualizacion = DateTime.Now
                                  }
                        objAsiento.movimiento.Add(objMovimiento)


                        objMovimiento = New movimiento With {
                                        .cuenta = "791",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "D",
                                        .monto = CDec(i.GetValue("montokardex")),
                                        .montoUSD = CDec(i.GetValue("montokardexUS")),
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                        objAsiento.movimiento.Add(objMovimiento)

                        listaAsiento.Add(objAsiento)

                        obj = New recursoCostoDetalle With {
                                            .idCosto = CInt(i.GetValue("idEDT")),
                                            .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                            .iditem = Val(i.GetValue("idItem")),
                                            .destino = i.GetValue("destino"),
                                            .descripcion = i.GetValue("descripcionItem"),
                                            .um = i.GetValue("unidad1"),
                                            .cant = CDec(i.GetValue("monto1")),
                                            .puMN = 0,
                                            .puME = 0,
                                            .montoMN = CDec(i.GetValue("montokardex")) * -1,
                                            .montoME = CDec(i.GetValue("montokardexUS")) * -1,
                                            .documentoRef = CInt(i.GetValue("idDocumento")),
                                            .itemRef = CInt(i.GetValue("secuencia")),
                                            .operacion = i.GetValue("TipoOperacion"),
                                            .procesado = "N",
                                            .idProceso = CInt(i.GetValue("idEDT")),
                                    .Periodo = PeriodoGeneral,
                                     .fechaTrabajo = CDate(i.GetValue("fechaTrabajo")),
                                .tipoCosto = "HG"
                                }
                        Lista.Add(obj)

                        obj = New recursoCostoDetalle With {
                                        .idCosto = recurso.idCosto,
                                        .fechaRegistro = CDate(i.GetValue("FechaDoc")),
                                        .iditem = Val(i.GetValue("idItem")),
                                        .destino = i.GetValue("destino"),
                                        .descripcion = i.GetValue("descripcionItem"),
                                        .um = i.GetValue("unidad1"),
                                        .cant = CDec(i.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.GetValue("montokardex")),
                                        .montoME = CDec(i.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.GetValue("idDocumento")),
                                        .itemRef = CInt(i.GetValue("secuencia")),
                                        .operacion = i.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = Nothing,
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.GetValue("tipoCosto")
                                                    }
                                    }
                        Lista.Add(obj)

                End Select

            Next


            costoSA.GrabarDetalleRecursos(Lista, listaAsiento)

            GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)

            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub EnvioDeCosteo()
        'Dim obj As New recursoCostoDetalle
        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento

        If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then

            'f.txtNuevoCosto.Text = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("Proyecto")
            'f.txtIdProyecto.Text = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idProyecto")
            Select Case Me.GridGroupingControl1.Table.CurrentRecord.GetValue("abrev")
                Case "HC"




                    RecursoEnvio = New recursoCostoDetalle With {
                                   .idCosto = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idEDT")),
                                   .fechaRegistro = CDate(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("FechaDoc")),
                                   .iditem = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idItem")),
                                   .destino = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("destino"),
                                   .descripcion = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("descripcionItem"),
                                   .um = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("unidad1"),
                                   .cant = CDec(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("monto1")),
                                   .puMN = 0,
                                   .puME = 0,
                                   .montoMN = CDec(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("montokardex")),
                                   .montoME = CDec(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("montokardexUS")),
                                   .documentoRef = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento")),
                                   .itemRef = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("secuencia")),
                                   .operacion = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("TipoOperacion"),
                                   .procesado = "N",
                                   .fechaTrabajo = CDate(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("fechaTrabajo")),
                                   .Periodo = PeriodoGeneral,
                                   .idProceso = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idEDT")),
                                   .cuenta = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cuentaCosteo"),
                                   .NombreProceso = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                   .tipoCosto = "HC"
                                   }




                Case "HG"
                    RecursoEnvio = New recursoCostoDetalle With {
                                                .idCosto = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idEDT")),
                                           .fechaRegistro = CDate(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("FechaDoc")),
                                           .iditem = Val(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idItem")),
                                           .destino = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("destino"),
                                           .descripcion = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("descripcionItem"),
                                           .um = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("unidad1"),
                                           .cant = CDec(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("monto1")),
                                           .puMN = 0,
                                           .puME = 0,
                                           .montoMN = CDec(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("montokardex")),
                                           .montoME = CDec(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("montokardexUS")),
                                           .documentoRef = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento")),
                                            .itemRef = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("secuencia")),
                                                .operacion = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("TipoOperacion"),
                                                .procesado = "N",
                                           .fechaTrabajo = CDate(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("fechaTrabajo")),
                                           .Periodo = PeriodoGeneral,
                                           .idProceso = CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idEDT")),
                                           .cuenta = Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cuentaCosteo"),
                                           .NombreProceso = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                           .tipoCosto = "HG"
                                            }

            End Select

        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If







        'asiento por tipo

        ' asientpo por tipo





        '  


    End Sub

    Public Sub RegistrarItemsAsignados()
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




            'INVENTARIO PENDIENTE DE ENVIO
            '-----------------------------------------------------------

            For Each i As SelectedRecord In GridGroupingControl1.Table.SelectedRecords
                Select Case i.Record.GetValue("abrev")
                    Case "HC"
                        'validando edt seleccionado
                        Dim valEdt = i.Record.GetValue("edt")
                        If IsNothing(valEdt) Then
                            MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        If valEdt.ToString.Trim.Length <= 0 Then
                            MessageBox.Show("Debe identificar el Entregable y elemento del costo" & vbCrLf & "del item " & i.Record.GetValue("descripcionItem"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        Select Case i.Record.GetValue("TipoDoc")
                            Case "07" 'NOTA DE CREDITO


                            Case Else

                                obj = New recursoCostoDetalle With {
                                        .idCosto = CInt(i.Record.GetValue("idEDT")),
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")),
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .fechaTrabajo = CDate(i.Record.GetValue("fechaTrabajo")),
                                        .Periodo = PeriodoGeneral,
                                        .idProceso = CInt(i.Record.GetValue("idEDT")),
                                        .tipoCosto = "HC"
                                        }
                                Lista.Add(obj)
                        End Select

                        'asiento por tipo

                        ' asientpo por tipo

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
                        objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))
                        objAsiento.glosa = "Por determinacion del costo por valoración del Entregable" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = i.Record.GetValue("cuentaCosteo")
                        objMovimiento.descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "791"
                        objMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
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
                        objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))
                        objAsiento.glosa = "Por determinacion del costo de producto terminado" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "711"
                        objMovimiento.descripcion = "VARIACI?N DE PRODUCTOS TERMINADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
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
                        objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))
                        objAsiento.glosa = "Por determinacion del costo de venta por valoración" & " " & txtEntregable.Text
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = Date.Now
                        listaAsiento.Add(objAsiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "694"
                        objMovimiento.descripcion = "SERVICIOS"
                        objMovimiento.tipo = "D"
                        objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
                        objMovimiento.usuarioActualizacion = usuario.IDUsuario
                        objMovimiento.fechaActualizacion = Date.Now
                        objAsiento.movimiento.Add(objMovimiento)

                        objMovimiento = New movimiento
                        objMovimiento.cuenta = "211"
                        objMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
                        objMovimiento.tipo = "H"
                        objMovimiento.monto = CDec(i.Record.GetValue("montokardex"))
                        objMovimiento.montoUSD = CDec(i.Record.GetValue("montokardexUS"))
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
                        objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                        objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                        objAsiento.glosa = "Ingreso a centro de costo"
                        objAsiento.usuarioActualizacion = usuario.IDUsuario
                        objAsiento.fechaActualizacion = DateTime.Now

                        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = i.Record.GetValue("idEDT")})

                        objMovimiento = New movimiento With {
                                      .cuenta = i.Record.GetValue("cuentaCosteo"),
                                      .descripcion = txtProyectoGeneral.Text & "-" & txtSubProyecto.Text & "-" & txtEntregable.Text,
                                      .tipo = "H",
                                      .monto = CDec(i.Record.GetValue("montokardex")),
                                      .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                      .usuarioActualizacion = usuario.IDUsuario,
                                      .fechaActualizacion = DateTime.Now
                                  }
                        objAsiento.movimiento.Add(objMovimiento)


                        objMovimiento = New movimiento With {
                                        .cuenta = "791",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "D",
                                        .monto = CDec(i.Record.GetValue("montokardex")),
                                        .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                        objAsiento.movimiento.Add(objMovimiento)

                        listaAsiento.Add(objAsiento)

                        obj = New recursoCostoDetalle With {
                                        .idCosto = recurso.idCosto,
                                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                                        .iditem = Val(i.Record.GetValue("idItem")),
                                        .destino = i.Record.GetValue("destino"),
                                        .descripcion = i.Record.GetValue("descripcionItem"),
                                        .um = i.Record.GetValue("unidad1"),
                                        .cant = CDec(i.Record.GetValue("monto1")),
                                        .puMN = 0,
                                        .puME = 0,
                                        .montoMN = CDec(i.Record.GetValue("montokardex")),
                                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
                                        .documentoRef = CInt(i.Record.GetValue("idDocumento")),
                                        .itemRef = CInt(i.Record.GetValue("secuencia")),
                                        .operacion = i.Record.GetValue("TipoOperacion"),
                                        .procesado = "N",
                                        .idProceso = Nothing,
                                    .recursoCosto = New recursoCosto With
                                                    {
                                    .subtipo = i.Record.GetValue("tipoCosto")
                                                    }
                                    }
                        Lista.Add(obj)

                End Select

            Next


            costoSA.GrabarDetalleRecursos(Lista, listaAsiento)

            GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)

            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
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

    Public Sub GastosInventarioxEntregable(idEntregable As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("Serie")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("unidad1")
        dt.Columns.Add("monto1")
        dt.Columns.Add("montokardex")
        dt.Columns.Add("montokardexUS")
        dt.Columns.Add("TipoOperacion")
        dt.Columns.Add("idPadreDTCompra")
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
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("cantEnv")
        For Each i In compraSA.ListaRecursosGastoInventarioEntregables(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                     .fechaContable = PeriodoGeneral, .idCosto = idEntregable})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.FechaDoc
            dr(3) = i.TipoDoc
            dr(4) = i.Serie
            dr(5) = i.NumDoc
            dr(6) = i.Moneda
            dr(7) = i.idItem
            dr(8) = i.descripcionItem
            dr(9) = i.tipoExistencia

            dr(10) = i.destino
            dr(11) = i.unidad1
            dr(12) = i.monto1
            dr(13) = i.montokardex
            dr(14) = i.montokardexUS
            dr(15) = i.TipoOperacion
            dr(16) = i.idPadreDTCompra
            dr(17) = i.idCosto
            dr(18) = i.NombreProyectoGeneral
            dr(19) = Nothing
            dr(20) = Nothing
            dr(21) = i.idCosto
            dr(22) = i.NombreProyectoGeneral
            dr(23) = Nothing
            dr(24) = Nothing
            dr(25) = Nothing
            dr(26) = "HG"
            dr(27) = DateTime.Now
            dr(28) = i.CuentaItem
            dr(29) = i.tipoCompra

            dr(30) = i.almacenDestino
            dr(31) = 0
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt ' compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '.fechaContable = PeriodoGeneral})
        GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended


        GridGroupingControl1.TableDescriptor.Columns("idPadreDTCompra").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idCosto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("NombreProyectoGeneral").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idSubProyecto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("Subproyecto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idEDT").Width = 70


        GridGroupingControl1.TableDescriptor.Columns("tipoCosto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idElemento").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("Elemento").Width = 0



    End Sub



    Public Sub GetItemsNoAsignadosInventarioxEntregable(idEntregable As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("Serie")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("unidad1")
        dt.Columns.Add("monto1")
        dt.Columns.Add("montokardex")
        dt.Columns.Add("montokardexUS")
        dt.Columns.Add("TipoOperacion")
        dt.Columns.Add("idPadreDTCompra")
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
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("cantEnv")
        For Each i In compraSA.ListaRecursosCostoInventarioEntregables(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                   .fechaContable = PeriodoGeneral, .idCosto = idEntregable})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.FechaDoc
            dr(3) = i.TipoDoc
            dr(4) = i.Serie
            dr(5) = i.NumDoc
            dr(6) = i.Moneda
            dr(7) = i.idItem
            dr(8) = i.descripcionItem
            dr(9) = i.tipoExistencia

            dr(10) = i.destino
            dr(11) = i.unidad1
            dr(12) = i.monto1
            dr(13) = i.montokardex
            dr(14) = i.montokardexUS
            dr(15) = i.TipoOperacion
            dr(16) = i.idPadreDTCompra
            dr(17) = i.idCosto
            dr(18) = i.NombreProyectoGeneral
            dr(19) = Nothing
            dr(20) = Nothing
            dr(21) = i.idCosto
            dr(22) = i.NombreProyectoGeneral
            dr(23) = Nothing
            dr(24) = Nothing
            dr(25) = Nothing
            dr(26) = "HC"
            dr(27) = DateTime.Now
            dr(28) = i.CuentaItem
            dr(29) = i.tipoCompra

            dr(30) = i.almacenDestino
            dr(31) = 0
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt ' compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '.fechaContable = PeriodoGeneral})
        GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended


        GridGroupingControl1.TableDescriptor.Columns("idPadreDTCompra").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idCosto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("NombreProyectoGeneral").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idSubProyecto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("Subproyecto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idEDT").Width = 70


        GridGroupingControl1.TableDescriptor.Columns("tipoCosto").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("idElemento").Width = 0
        GridGroupingControl1.TableDescriptor.Columns("Elemento").Width = 0



    End Sub
#End Region

    Private Sub frmCosteoInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtTipoCosteo.Text = "HC" Then
            GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)

        ElseIf txtTipoCosteo.Text = "HG" Then
            GastosInventarioxEntregable(txtidEntregable.Text)
        End If
        txtPeriodo.Text = PeriodoGeneral
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If GridGroupingControl1.Table.Records.Count > 0 Then
            If GridGroupingControl1.Table.SelectedRecords.Count > 0 Then


                RegistrarItemsAsignados()


            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If GridGroupingControl1.Table.Records.Count > 0 Then



            RegistrarItemsAsignadosAll()


        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        EnvioDeCosteo()


        If GridGroupingControl1.Table.Records.Count > 0 Then
            If GridGroupingControl1.Table.SelectedRecords.Count > 0 Then

                Dim idAlmacen As Integer = GridGroupingControl1.Table.CurrentRecord.GetValue("idAlmacen")
                Dim idItem As Integer = GridGroupingControl1.Table.CurrentRecord.GetValue("idItem")
                Dim cantidad As Decimal = GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv")


                Dim f As New frmOtrasSalidasDeProduccion

                ' f.RecursoEnvio = RecursoEnvio
                'f.listaAsientoEnvio = listaAsientoEnvio
                f.CargarDetalleAutomatico(idAlmacen, idItem, cantidad)
                f.lblPerido.Text = txtPeriodo.Text
                f.GroupBox2.Visible = True
                f.cboOperacion.SelectedValue = "10.01"
                '.rbCosto.Checked = True
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()


                ' GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)
                If txtTipoCosteo.Text = "HC" Then
                    GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)

                ElseIf txtTipoCosteo.Text = "HG" Then
                    GastosInventarioxEntregable(txtidEntregable.Text)
                End If




            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub GridGroupingControl1_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles GridGroupingControl1.TableControlCurrentCellChanging
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then
        '        Select Case ColIndex
        '                'Case 11
        '            Case 25


        '                If Not GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") <= GridGroupingControl1.Table.CurrentRecord.GetValue("monto1") Then
        '                    GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)

        '                End If

        '                'Select Case GridGroupingControl1.Table.CurrentRecord.GetValue("cboMov")
        '                '    Case "1"


        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If

        '                '    Case "2", "4"
        '                '        GridGroupingControl1.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Case "3"
        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If
        '                'End Select
        '        End Select
        '    End If

        'Catch ex As Exception
        '    'lblEstado.Text = ex.Message
        '    'PanelError.Visible = True
        '    'Timer1.Enabled = True
        '    'TiempoEjecutar(10)
        'End Try

    End Sub

    Private Sub GridGroupingControl1_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridGroupingControl1.TableControlCurrentCellChanged

        Dim cc As GridCurrentCell = GridGroupingControl1.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 25 Then
                        ''''''''
                        If Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") > CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("monto1")) Then



                            'Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            'Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue


                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)


                        ElseIf Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") < 0 Then
                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try


        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then
        '        Select Case ColIndex
        '                'Case 11
        '            Case 25


        '                If Not GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") <= GridGroupingControl1.Table.CurrentRecord.GetValue("monto1") Then
        '                    GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)

        '                End If

        '                'Select Case GridGroupingControl1.Table.CurrentRecord.GetValue("cboMov")
        '                '    Case "1"


        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If

        '                '    Case "2", "4"
        '                '        GridGroupingControl1.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Case "3"
        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If
        '                'End Select
        '        End Select
        '    End If

        'Catch ex As Exception
        '    'lblEstado.Text = ex.Message
        '    'PanelError.Visible = True
        '    'Timer1.Enabled = True
        '    'TiempoEjecutar(10)
        'End Try
    End Sub

    Private Sub GridGroupingControl1_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridGroupingControl1.TableControlKeyDown

        Dim cc As GridCurrentCell = GridGroupingControl1.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 25 Then
                        ''''''''
                        If Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") > CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("monto1")) Then



                            'Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            'Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue


                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)


                        ElseIf Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") < 0 Then
                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try


        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then
        '        Select Case ColIndex
        '                'Case 11
        '            Case 25


        '                If Not GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") <= GridGroupingControl1.Table.CurrentRecord.GetValue("monto1") Then
        '                    GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)

        '                End If

        '                'Select Case GridGroupingControl1.Table.CurrentRecord.GetValue("cboMov")
        '                '    Case "1"


        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If

        '                '    Case "2", "4"
        '                '        GridGroupingControl1.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Case "3"
        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If
        '                'End Select
        '        End Select
        '    End If

        'Catch ex As Exception
        '    'lblEstado.Text = ex.Message
        '    'PanelError.Visible = True
        '    'Timer1.Enabled = True
        '    'TiempoEjecutar(10)
        'End Try
    End Sub

    Private Sub GridGroupingControl1_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles GridGroupingControl1.TableControlKeyPress

        Dim cc As GridCurrentCell = GridGroupingControl1.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 25 Then
                        ''''''''
                        If Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") > CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("monto1")) Then



                            'Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            'Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue


                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)


                        ElseIf Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") < 0 Then
                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try


        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then
        '        Select Case ColIndex
        '                'Case 11
        '            Case 25


        '                If Not GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") <= GridGroupingControl1.Table.CurrentRecord.GetValue("monto1") Then
        '                    GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)

        '                End If

        '                'Select Case GridGroupingControl1.Table.CurrentRecord.GetValue("cboMov")
        '                '    Case "1"


        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If

        '                '    Case "2", "4"
        '                '        GridGroupingControl1.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Case "3"
        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If
        '                'End Select
        '        End Select
        '    End If

        'Catch ex As Exception
        '    'lblEstado.Text = ex.Message
        '    'PanelError.Visible = True
        '    'Timer1.Enabled = True
        '    'TiempoEjecutar(10)
        'End Try
    End Sub

    Private Sub GridGroupingControl1_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles GridGroupingControl1.TableControlKeyUp
        Dim cc As GridCurrentCell = GridGroupingControl1.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then


                    'If Me.dgvMov.Table.CurrentRecord.GetValue("Correccion") = "3" Then
                    '''''''''''

                    If cc.ColIndex = 25 Then
                        ''''''''
                        If Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") > CInt(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("monto1")) Then



                            'Dim colCantidadDisponible As Decimal = Me.dgvMov.Table.CurrentRecord.GetValue("cantDisponible")
                            'Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue


                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)


                        ElseIf Me.GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") < 0 Then
                            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try


        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then
        '        Select Case ColIndex
        '                'Case 11
        '            Case 25


        '                If Not GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv") <= GridGroupingControl1.Table.CurrentRecord.GetValue("monto1") Then
        '                    GridGroupingControl1.Table.CurrentRecord.SetValue("cantEnv", 0)

        '                End If

        '                'Select Case GridGroupingControl1.Table.CurrentRecord.GetValue("cboMov")
        '                '    Case "1"


        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If

        '                '    Case "2", "4"
        '                '        GridGroupingControl1.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Case "3"
        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            GridGroupingControl1.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If
        '                'End Select
        '        End Select
        '    End If

        'Catch ex As Exception
        '    'lblEstado.Text = ex.Message
        '    'PanelError.Visible = True
        '    'Timer1.Enabled = True
        '    'TiempoEjecutar(10)
        'End Try
    End Sub

    Private Sub GridGroupingControl1_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles GridGroupingControl1.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        EnvioDeCosteo()


        If GridGroupingControl1.Table.Records.Count > 0 Then
            If GridGroupingControl1.Table.SelectedRecords.Count > 0 Then

                Dim idAlmacen As Integer = GridGroupingControl1.Table.CurrentRecord.GetValue("idAlmacen")
                Dim idItem As Integer = GridGroupingControl1.Table.CurrentRecord.GetValue("idItem")
                Dim cantidad As Decimal = GridGroupingControl1.Table.CurrentRecord.GetValue("cantEnv")


                'Dim f As New frmTransferenciaDevProd

                'f.RecursoEnvio = RecursoEnvio
                ''f.listaAsientoEnvio = listaAsientoEnvio
                'f.CargarDetalleAutomatico(idAlmacen, idItem, cantidad)
                'f.lblPerido.Text = PeriodoGeneral
                'f.lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()


                'GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)
                If txtTipoCosteo.Text = "HC" Then
                    GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)

                ElseIf txtTipoCosteo.Text = "HG" Then
                    GastosInventarioxEntregable(txtidEntregable.Text)
                End If


            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class