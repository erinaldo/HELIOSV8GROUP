Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmInformacionGeneral
    Inherits frmMaster

#Region "Attributes"
    Dim ListacajausuarioXCuentasXcompra As New documentocompra
    Dim ListacajausuarioXCuentasXcompraDetalle As New List(Of documentocompradetalle)
    Dim ListacajausuarioXCuentasXcompraTransito As New List(Of documentocompra)
    Dim ListacajausuarioXCuentasXcompraRecepcion As New List(Of documentocompra)
    Dim ListaVenta As New documentoventaAbarrotes
    Dim ListacajausuarioXEntidadFinanciera As New documentoCaja
    Dim listaMeses As New List(Of MesesAnio)
    Dim listaUsuario As New List(Of Usuario)
    Dim listaID As List(Of String)
    Dim conteo As Integer = 0
    Dim salidaAlmacen As Decimal
    Dim ingresoAlmacen As Decimal
    Dim tipoConsulta As String
    Dim ingresoFinanzas As Decimal
    Dim SalidaFinanzas As Decimal
    Public Property ListaEstadoFinancierosMaster() As New List(Of estadosFinancieros)
    Dim idAlmacenVirtual As Integer
#End Region

#Region "Constructors"
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ToolStripLabel2.Text = Gempresas.NomEmpresa
        ToolStripLabel4.Text = GEstableciento.NombreEstablecimiento
        dtFechaInicio.Value = Date.Now
        dtFechaFin.Value = Date.Now
        FormatoGrid(dgvAlmacen)
        'FormatoGrid(dgvResumen)
        FormatoGrid(dgvDetalleCajas)
        Meses()
        txtAnioCompra.Text = AnioGeneral
        pnPeriodo.Enabled = False
        pnDia.Enabled = False

    End Sub
#End Region

#Region "Methods"

    Private Sub Meses()
        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Sub Consulta(listaPersonas As List(Of String), tipo As String, fechaIncio As DateTime, fechaFin As DateTime, strAnio As Integer, strMes As Integer, strDia As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim compraSA As New DocumentoCompraSA
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New List(Of documentoCaja)
        Dim efsa As New EstadosFinancierosSA

        'DETALLE DE CAJAS
        Dim dtCajas As New DataTable()
        dtCajas.Columns.Add("ef")
        dtCajas.Columns.Add("moneda")
        dtCajas.Columns.Add("tipo")
        dtCajas.Columns.Add("ingreso")
        dtCajas.Columns.Add("salida")
        dtCajas.Columns.Add("saldo")
        dtCajas.Columns.Add("empresa")
        dtCajas.Columns.Add("idEf")

        Dim listaEF As New List(Of estadosFinancieros)
        'If CheckBox1.Checked = True Then
        '    listaEF = efsa.GetEstadoCajasTodosDetalleByDiaAllEmpresa(New documentoCaja With {.fechaProceso = txtFecha.Value})
        'Else
        listaEF = efsa.GetEstadoCajasInformacionGeneral(Nothing, listaPersonas, tipo, fechaIncio, fechaFin, strAnio, strMes, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strDia)

        For Each i In listaEF
            Dim dr As DataRow = dtCajas.NewRow
            dr(0) = i.descripcion
            dr(1) = i.codigo
            Select Case i.tipo
                Case CuentaFinanciera.Banco
                    dr(2) = "Banco"
                Case CuentaFinanciera.Efectivo
                    dr(2) = "Efectivo"
                Case CuentaFinanciera.Tarjeta_Credito
                    dr(2) = "Tarj. crédito"
                Case CuentaFinanciera.Tarjeta_Debito
                    dr(2) = "Tarj. Débito"
            End Select

            dr(3) = i.Ingresos.GetValueOrDefault
            dr(4) = i.Salidas.GetValueOrDefault
            dr(5) = i.SaldoCaja.GetValueOrDefault
            dr(6) = i.NomCortoEmpresa
            dr(7) = i.idestado
            dtCajas.Rows.Add(dr)
        Next
        dgvDetalleCajas.DataSource = dtCajas
        dgvDetalleCajas.TableDescriptor.GroupedColumns.Clear()
        dgvDetalleCajas.TableDescriptor.GroupedColumns.Add("empresa")

        Me.Cursor = Cursors.Arrow
    End Sub

    Sub limpiar()
        dgvDetalleCajas.Table.Records.DeleteAll()
        dgvAlmacen.Table.Records.DeleteAll()
        lblCompraCredito.Text = "0.00"
        lblcompraTransito.Text = "0.00"
        lblMontoRecepcionTransito.Text = "0.00"
        lblTransferenciaAlmacen.Text = "0.00"
        lblTransferenciaRecepcion.Text = "0.00"
        lblOtrosIngresoAlmacen.Text = "0.00"
        lblOtrasSalidasAlmacen.Text = "0.00"
        Label11.Text = "0.00"
        Label23.Text = "0.00"
        lblAnticoposXventa.Text = "0.00"
        lblCajaCentrlizada.Text = "0.00"
        lblVentaContadoPOS.Text = "0.00"
        lblVentaContadoGeneral.Text = "0.00"
        lblVentaCreditoPOS.Text = "0.00"
        lblAntOtorgado.Text = "0.00"
        lblAporte.Text = "0.00"
        lblVentaCreditoGeneral.Text = "0.00"
        lblVentaGeneral.Text = "0.00"
        lblIngresoVentas.Text = "0.00"
        lblAnticiposRecibidos.Text = "0.00"
        lblOtrasEntradas.Text = "0.00"
        lblOtrasSalidas.Text = "0.00"
        lblCuentasXPagar.Text = "0.00"
        lblIngresosXcobrar.Text = "0.00"
        Label8.Text = "0.00"
    End Sub

    Sub Consultakardex(listaPersonas As List(Of String), tipo As String, fechaIncio As DateTime, fechaFin As DateTime, intMes As Integer, intAnio As Integer, intDia As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim compraSA As New DocumentoCompraSA
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New List(Of documentoCaja)
        Dim efsa As New almacenSA

        'DETALLE DE CAJAS
        Dim dtCajas As New DataTable()
        dtCajas.Columns.Add("almacen")
        dtCajas.Columns.Add("idAlmacen")
        dtCajas.Columns.Add("tipo")
        dtCajas.Columns.Add("ingreso")
        dtCajas.Columns.Add("salida")
        dtCajas.Columns.Add("saldo")
        dtCajas.Columns.Add("empresa")

        Dim listaEF As New List(Of almacen)
        'If CheckBox1.Checked = True Then
        '    listaEF = efsa.GetEstadoCajasTodosDetalleByDiaAllEmpresa(New documentoCaja With {.fechaProceso = txtFecha.Value})
        'Else
        listaEF = efsa.GetListar_almacenPorUsuario(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, listaPersonas, intAnio, intMes, fechaIncio, fechaFin, tipo, intDia)

        For Each i In listaEF
            Dim dr As DataRow = dtCajas.NewRow
            dr(0) = i.descripcionAlmacen
            dr(1) = i.idAlmacen
            dr(2) = i.tipo
            dr(3) = i.montoMN
            dr(4) = -1 * (i.montoME)
            dr(5) = CDec(i.montoMN - (-1 * i.montoME))
            dr(6) = Nothing
            dtCajas.Rows.Add(dr)
        Next
        dgvAlmacen.DataSource = dtCajas
        dgvAlmacen.TableDescriptor.GroupedColumns.Clear()
        dgvAlmacen.TableDescriptor.GroupedColumns.Add("tipo")

        Me.Cursor = Cursors.Arrow
    End Sub

    'Sub ConsultaResumenDinero(listaPersonas As List(Of String))
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim compraSA As New DocumentoCompraSA
    '    Dim ventaSA As New documentoVentaAbarrotesSA
    '    Dim cajaSA As New DocumentoCajaSA
    '    Dim caja As New List(Of documentoCaja)
    '    Dim efsa As New EstadosFinancierosSA

    '    DETALLE DE CAJAS
    '    Dim dtResumen As New DataTable()
    '    dtResumen.Columns.Add("ef")
    '    dtResumen.Columns.Add("ingreso")
    '    dtResumen.Columns.Add("salida")
    '    dtResumen.Columns.Add("saldo")
    '    dtResumen.Columns.Add("empresa")
    '    dtResumen.Columns.Add("tipo")

    '    Dim listaEF As New List(Of estadosFinancieros)
    '    If CheckBox1.Checked = True Then
    '        listaEF = efsa.GetEstadoCajasTodosDetalleByDiaAllEmpresa(New documentoCaja With {.fechaProceso = txtFecha.Value})
    '    Else
    '        listaEF = efsa.GetEstadoCajasInformacionGeneral(New documentoCaja With {.usuarioModificacion = txtPersona.Tag}, listaPersonas)
    '    End If

    '    For Each i In listaEF
    '        Dim dr As DataRow = dtResumen.NewRow
    '        dr(0) = "RESUMEN DE ALMACEN"
    '        dr(1) = ingresoAlmacen
    '        dr(2) = salidaAlmacen
    '        dr(3) = Nothing
    '        dr(4) = Nothing
    '        dr(5) = "RA"
    '        dtResumen.Rows.Add(dr)


    '        Dim dr2 As DataRow = dtResumen.NewRow
    '        dr2(0) = "RESUMEN DE FINANZAS"
    '        dr2(1) = ingresoFinanzas
    '        dr2(2) = SalidaFinanzas
    '        dr2(3) = Nothing
    '        dr2(4) = Nothing
    '        dr2(5) = "RF"
    '        dtResumen.Rows.Add(dr2)
    '    Next
    '    dgvResumen.DataSource = dtResumen
    '    dgvResumen.TableDescriptor.GroupedColumns.Clear()
    '    dgvResumen.TableDescriptor.GroupedColumns.Add("empresa")

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Public Sub Inicio(listaidPersona As List(Of String), fechaInicio As DateTime, fechafin As DateTime, periodo As String, tipo As String, intanio As Integer, intMes As Integer, intDia As Integer)

        Dim documentoVentaAbarrotesSA As New documentoVentaAbarrotesSA
        ListaVenta = documentoVentaAbarrotesSA.ListaTotalXVenta(listaidPersona, fechaInicio, fechafin, intMes, tipo, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intanio, intMes, intDia)

        If (Not IsNothing(ListaVenta)) Then
            lblVentaContadoPOS.Text = CDec(ListaVenta.ventaPosContado)
            lblVentaContadoGeneral.Text = CDec(ListaVenta.ventaVtaggContado)
            lblVentaCreditoPOS.Text = CDec(ListaVenta.ventaPos)
            lblVentaCreditoGeneral.Text = CDec(ListaVenta.ventaVtag)
            lblAnticoposXventa.Text = CDec(ListaVenta.preVenta)
            lblCuentasXPagar.Text = CDec(ListaVenta.cuentasXCobrar)
        End If

        'End If

        ''compras al contado y lista dfe las compras
        Dim documentoCompraSA As New DocumentoCompraSA
        'Dim documentoCompraDeatalleSA As New DocumentoCompraDetalleSA


        ListacajausuarioXCuentasXcompra = documentoCompraSA.ListaTotalXCompraAll(listaidPersona, fechaInicio, fechafin, periodo, tipo, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intanio, intMes, intDia)

        If (Not IsNothing(ListacajausuarioXCuentasXcompra)) Then
            lblCompraCredito.Text = CDec(ListacajausuarioXCuentasXcompra.comprasCredito.GetValueOrDefault)
            lblTransferenciaAlmacen.Text = CDec(ListacajausuarioXCuentasXcompra.transferenciaAlmacen.GetValueOrDefault)
            lblOtrosIngresoAlmacen.Text = CDec(ListacajausuarioXCuentasXcompra.entrdasAlmacen.GetValueOrDefault)
            lblOtrasSalidasAlmacen.Text = CDec(ListacajausuarioXCuentasXcompra.salidaAlmacen.GetValueOrDefault)

            lblcompraTransito.Text = CDec(ListacajausuarioXCuentasXcompra.compraTransito.GetValueOrDefault)
            lblMontoRecepcionTransito.Text = CDec(ListacajausuarioXCuentasXcompra.CompraTransitoRecepcion.GetValueOrDefault)
            lblTransferenciaRecepcion.Text = CDec(ListacajausuarioXCuentasXcompra.transferenciaRecepcion.GetValueOrDefault)
        End If

        Dim DocCajaSA As New DocumentoCajaSA

        ListacajausuarioXEntidadFinanciera = DocCajaSA.ListaTotalXCaja(listaidPersona, fechaInicio, fechafin, PeriodoGeneral, tipo, Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intanio, intMes, intDia)

        If (Not IsNothing(ListacajausuarioXEntidadFinanciera)) Then

            If (Not IsNothing(ListacajausuarioXEntidadFinanciera)) Then
                lblOtrasEntradas.Text = ListacajausuarioXEntidadFinanciera.otrasEntradas
                lblOtrasSalidas.Text = ListacajausuarioXEntidadFinanciera.otrasSalidas
                lblAnticiposRecibidos.Text = ListacajausuarioXEntidadFinanciera.anticiposRecibidos
                lblCajaCentrlizada.Text = ListacajausuarioXEntidadFinanciera.ticket
                lblIngresoVentas.Text = CDec(ListacajausuarioXEntidadFinanciera.ventaContado) + CDec(ListacajausuarioXEntidadFinanciera.ventaPost) + CDec(ListacajausuarioXEntidadFinanciera.ticket)
                lblIngresosXcobrar.Text = ListacajausuarioXEntidadFinanciera.cuentasXPagar
                lblAntOtorgado.Text = ListacajausuarioXEntidadFinanciera.anticiposOtorgados
                lblAporte.Text = ListacajausuarioXEntidadFinanciera.Aporte
            End If

        End If

        lblVentaGeneral.Text = CDec(CDec(lblVentaContadoPOS.Text) + CDec(lblVentaContadoGeneral.Text) + CDec(lblVentaCreditoPOS.Text) + CDec(lblVentaCreditoGeneral.Text) + CDec(lblCajaCentrlizada.Text))

    End Sub

#End Region

#Region "Events"

#End Region

    Private Sub frmHistorialCajaCierre_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If (conteo > 0) Then
            If (rbPorDia.Checked = True) Then
                Consulta(listaID, "XDia", dtFechaInicio.Value, dtFechaFin.Value, 0, 0, 0)
                Consultakardex(listaID, "XDia", dtFechaInicio.Value, dtFechaFin.Value, 0, 0, 0)
                Inicio(listaID, dtFechaInicio.Value, dtFechaFin.Value, Nothing, "XDia", 0, 0, 0)
                tipoConsulta = "XDia"
            ElseIf (Periodo.Checked = True) Then
                Consulta(listaID, "XPeriodo", Nothing, Nothing, txtAnioCompra.Text, cboMesCompra.SelectedValue, 0)
                Consultakardex(listaID, "XPeriodo", Nothing, Nothing, cboMesCompra.SelectedValue, txtAnioCompra.Text, 0)
                Inicio(listaID, Nothing, Nothing, cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, "XPeriodo", txtAnioCompra.Text, cboMesCompra.SelectedValue, 0)
                tipoConsulta = "XPeriodo"
            ElseIf (rbTodo.Checked = True) Then
                Consulta(listaID, "XTodo", Nothing, Nothing, AnioGeneral, 0, 0)
                Consultakardex(listaID, "XTodo", Nothing, Nothing, MesGeneral, AnioGeneral, 0)
                Inicio(listaID, Nothing, Nothing, lblPerido.Text, "XTodo", AnioGeneral, 0, 0)
                tipoConsulta = "XTodo"
            ElseIf (rbDia.Checked = True) Then
                If (rbDia.Tag = 1) Then
                    Consulta(listaID, "XHora", dtHoraInicio.Value, dtHoraFin.Value, CInt(dtFechaActual.Value.Year), CInt(dtFechaActual.Value.Month), CInt(dtFechaActual.Value.Day))
                    Consultakardex(listaID, "XHora", dtHoraInicio.Value, dtHoraFin.Value, CInt(dtFechaActual.Value.Month), CInt(dtFechaActual.Value.Year), CInt(dtFechaActual.Value.Day))
                    Inicio(listaID, dtHoraInicio.Value, dtHoraFin.Value, Nothing, "XHora", dtFechaActual.Value.Year, dtFechaActual.Value.Month, dtFechaActual.Value.Day)
                    tipoConsulta = "XHora"
                ElseIf (rbDia.Tag = 0) Then
                    dtHoraInicio.Value = New Date(CInt(dtFechaActual.Value.Year), CInt(dtFechaActual.Value.Month), CInt(dtFechaActual.Value.Day), CInt(0), CInt(0), CInt(0))
                    dtHoraFin.Value = New Date(CInt(dtFechaActual.Value.Year), CInt(dtFechaActual.Value.Month), CInt(dtFechaActual.Value.Day), CInt(23), CInt(59), CInt(59))
                    Consulta(listaID, "XHora", dtHoraInicio.Value, dtHoraFin.Value, CInt(dtFechaActual.Value.Year), CInt(dtFechaActual.Value.Month), CInt(dtFechaActual.Value.Day))
                    Consultakardex(listaID, "XHora", dtHoraInicio.Value, dtHoraFin.Value, CInt(dtFechaActual.Value.Month), CInt(dtFechaActual.Value.Year), CInt(dtFechaActual.Value.Day))
                    Inicio(listaID, dtHoraInicio.Value, dtHoraFin.Value, Nothing, "XHora", dtFechaActual.Value.Year, dtFechaActual.Value.Month, dtFechaActual.Value.Day)
                    tipoConsulta = "XHora"
                End If

            End If
        Else
            MessageBox.Show("Debe seleccionar un usuario!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub lblVentaCreditoGeneral_Click(sender As Object, e As EventArgs) Handles lblVentaCreditoGeneral.Click
       Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetListaVentasPorPeriodo(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_VENTA.VENTA_GENERAL, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario, "CREDITO")
        f.ToolStripButton4.Visible = True
        f.idPersonas = listaID
        f.periodo = lblPerido.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblVentaContadoGeneral_Click(sender As Object, e As EventArgs) Handles lblVentaContadoGeneral.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetListaVentasPorPeriodo(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_VENTA.VENTA_GENERAL, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario, "CONTADO")
        f.ToolStripButton4.Visible = True
        f.idPersonas = listaID
        f.periodo = lblPerido.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblVentaCreditoPOS_Click(sender As Object, e As EventArgs) Handles lblVentaCreditoPOS.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetListaVentasPorPeriodo(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_VENTA.VENTA_POS_DIRECTA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario, "CREDITO")
        f.ToolStripButton4.Visible = True
        f.idPersonas = listaID
        f.periodo = lblPerido.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblVentaContadoPOS_Click(sender As Object, e As EventArgs) Handles lblVentaContadoPOS.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetListaVentasPorPeriodo(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_VENTA.VENTA_POS_DIRECTA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario, "CONTADO")
        f.ToolStripButton4.Visible = True
        f.idPersonas = listaID
        f.periodo = lblPerido.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default

    End Sub

    Private Sub lblCompraCredito_Click(sender As Object, e As EventArgs) Handles lblCompraCredito.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.getTableComprasPorPeriodoContado(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_COMPRA.COMPRA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.tsbCompras.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblRegistroHonorarioContado_Click(sender As Object, e As EventArgs) Handles lblTransferenciaAlmacen.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovPorPeriodoTransferencia(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_COMPRA.COMPRA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.tsbOtrosMovimiento.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub lblOtrosIngresoAlmacen_Click(sender As Object, e As EventArgs) Handles lblOtrosIngresoAlmacen.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovPorPeriodoOtrasEntradas(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_COMPRA.COMPRA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.tsbOtrosMovimiento.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblOtrasSalidasAlmacen_Click(sender As Object, e As EventArgs) Handles lblOtrasSalidasAlmacen.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovPorPeriodoOtrasSalidas(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_COMPRA.COMPRA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.tsbOtrosMovimiento.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub lblCompraContado_Click(sender As Object, e As EventArgs) Handles lblTransferenciaRecepcion.Click
        Cursor = Cursors.WaitCursor

        Dim f As New frmInformacionGeneralDetalle
        f.GetMovPorPeriodoTransferenciaRecep(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_COMPRA.COMPRA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.tsbOtrosMovimiento.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        'ButtonAdv6_Click(sender, e)

        Cursor = Cursors.Default
    End Sub

    Private Sub lblOtrasEntradas_Click(sender As Object, e As EventArgs) Handles lblOtrasEntradas.Click
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovimientosPeriodo(txtAnioCompra.Text, cboMesCompra.SelectedValue, "OEC", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.ToolStripButton5.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblOtrasSalidas_Click(sender As Object, e As EventArgs) Handles lblOtrasSalidas.Click
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovimientosPeriodo(txtAnioCompra.Text, cboMesCompra.SelectedValue, "OSC", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.ToolStripButton5.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblAnticiposRecibidos_Click(sender As Object, e As EventArgs) Handles lblAnticiposRecibidos.Click
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovimientosPeriodo(txtAnioCompra.Text, cboMesCompra.SelectedValue, "AR", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.ToolStripButton5.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub rbPorPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles Periodo.CheckedChanged
        If (Periodo.Checked = True) Then
            pnPeriodo.Enabled = True
            pnDia.Enabled = False
            pnHora.Enabled = False
            pnDia.Visible = False
            pnHora.Visible = False
            pnPeriodo.Visible = True
            btnAceptar.Location = New Point(179, 325)
            limpiar()
        End If
    End Sub

    Private Sub rbPorDia_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorDia.CheckedChanged
        If (rbPorDia.Checked = True) Then
            pnPeriodo.Enabled = False
            pnDia.Enabled = True
            pnHora.Enabled = False
            pnPeriodo.Visible = False
            pnHora.Visible = False
            pnDia.Visible = True
            pnDia.Location = New Point(6, 254)
            btnAceptar.Location = New Point(176, 378)
            limpiar()

        End If

    End Sub

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        If (rbTodo.Checked = True) Then
            pnPeriodo.Enabled = False
            pnDia.Enabled = False
            pnHora.Enabled = False
            pnDia.Visible = False
            pnPeriodo.Visible = False
            pnHora.Visible = False
            btnAceptar.Location = New Point(180, 258)
            limpiar()
        End If
    End Sub

    Private Sub lblCajaCentrlizada_Click(sender As Object, e As EventArgs) Handles lblCajaCentrlizada.Click
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovimientosPeriodo(txtAnioCompra.Text, cboMesCompra.SelectedValue, "IPV", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.ToolStripButton5.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblAnticoposXventa_Click(sender As Object, e As EventArgs) Handles lblAnticoposXventa.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetListaVentasPorPeriodo(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, "VTK", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario, Nothing)
        f.ToolStripButton4.Visible = True
        f.idPersonas = listaID
        f.periodo = lblPerido.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmInformacionGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ListadoProveedores As New List(Of Usuario)
        Dim UsuarioSA As New UsuarioSA
        ListadoProveedores = New List(Of Usuario)
        ListadoProveedores = UsuarioSA.GetListaUsuarios()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaPersona()
        f.CaptionLabels(0).Text = "Personas"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        listaID = New List(Of String)
        listaUsuario = f.lista

        If (listaUsuario.Count > 0) Then
            lsvListadoItems.Items.Clear()
            lsvListadoItems.Columns.Clear()
            lsvListadoItems.Columns.Add("ID", 0, HorizontalAlignment.Left)
            lsvListadoItems.Columns.Add("DNI", 70, HorizontalAlignment.Left)
            lsvListadoItems.Columns.Add("Nombre completo", 150, HorizontalAlignment.Left)
            lsvListadoItems.Columns(0).DisplayIndex = lsvListadoItems.Columns.Count - 1

            For Each i In listaUsuario
                Dim n As New ListViewItem(i.IDUsuario)
                n.SubItems.Add(i.NroDocumento)
                n.SubItems.Add(i.Nombres + " " + i.ApellidoPaterno + " " + i.ApellidoMaterno)
                'n.SubItems.Add("Seleccion")
                lsvListadoItems.Items.Add(n)
                listaID.Add(i.IDUsuario)
                conteo += 1
            Next
            limpiar()
        Else
            MessageBoxAdv.Show("No existe persona", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub lblcompraTransito_Click(sender As Object, e As EventArgs) Handles lblcompraTransito.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovPorPeriodoTransito(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_COMPRA.COMPRA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.tsbOtrosMovimiento.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblMontoRecepcionTransito_Click(sender As Object, e As EventArgs) Handles lblMontoRecepcionTransito.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovPorPeriodoTransitoRecep(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, TIPO_COMPRA.COMPRA, tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.tsbOtrosMovimiento.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblIngresoVentas_Click(sender As Object, e As EventArgs) Handles lblIngresoVentas.Click
        'Dim f As New frmInformacionGeneralDetalle
        'f.GetMovimientosPeriodo("ALL", GEstableciento.IdEstablecimiento, ListacajausuarioXEntidadFinanciera, listaUsuario)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.WindowState = FormWindowState.Maximized
        'f.ShowDialog()
        'Cursor = Cursors.Default
    End Sub

    Private Sub lblVentaGeneral_Click(sender As Object, e As EventArgs) Handles lblVentaGeneral.Click
        'Cursor = Cursors.WaitCursor
        'Dim f As New frmInformacionGeneralDetalle
        'f.GetListaVentasPorPeriodo("ALL", "PN", ListacajausuarioDetalleTE, listaUsuario)
        'f.ToolStripButton4.Visible = True
        'f.idPersonas = listaID
        'f.periodo = lblPerido.Text
        'f.StartPosition = FormStartPosition.CenterParent
        'f.WindowState = FormWindowState.Maximized
        'f.ShowDialog()
        'Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        f.idPersonas = listaID
        f.txtPeriodo.Value = lblPerido.Text
        f.periodo = lblPerido.Text
        f.GetKardexByAnio("ALL", listaID, "XTodo", lblPerido.Text, dtFechaInicio.Value, dtFechaFin.Value, Nothing)
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    'Private Sub dgvResumen_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs)
    '    LoadingAnimator.Wire(dgvResumen.TableControl)
    '    If dgvResumen.Table.Records.Count > 0 Then
    '        If Not IsNothing(dgvResumen.Table.CurrentRecord) Then
    '            If Me.dgvResumen.Table.CurrentRecord.GetValue("tipo") = "RA" Then
    '                Cursor = Cursors.WaitCursor
    '                Dim f As New frmInformacionGeneralDetalle
    '                f.idPersonas = listaID
    '                f.txtPeriodo.Value = lblPerido.Text
    '                f.periodo = lblPerido.Text
    '                f.tipo = tipo
    '                f.kardex()
    '                'f.GetKardexByAnio("ALL", listaID, tipo, lblPerido.Text, dtFechaInicio.Value, dtFechaFin.Value)
    '                f.StartPosition = FormStartPosition.CenterParent
    '                f.WindowState = FormWindowState.Maximized
    '                f.ShowDialog()
    '                Cursor = Cursors.Default
    '            ElseIf Me.dgvResumen.Table.CurrentRecord.GetValue("tipo") = "RF" Then
    '                Cursor = Cursors.WaitCursor
    '                Dim f As New frmInformacionGeneralDetalle
    '                f.idPersonas = listaID
    '                f.txtPeriodo.Value = lblPerido.Text
    '                f.periodo = lblPerido.Text
    '                f.tipo = tipo
    '                f.listausuario = listaUsuario
    '                f.movimientoMN()
    '                'f.GetKardexByAnio("ALL", listaID, tipo, lblPerido.Text, dtFechaInicio.Value, dtFechaFin.Value)
    '                f.StartPosition = FormStartPosition.CenterParent
    '                f.WindowState = FormWindowState.Maximized
    '                f.ShowDialog()
    '                Cursor = Cursors.Default

    '            End If
    '        Else
    '            MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    End If
    '    LoadingAnimator.UnWire(dgvResumen.TableControl)
    'End Sub

    Private Sub dgvAlmacen_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAlmacen.TableControlCellClick
        Dim listaOperacionA As List(Of String)
        listaOperacionA = New List(Of String)
        listaOperacionA.Add("02")
        listaOperacionA.Add("03.01")
        listaOperacionA.Add("07.01")
        listaOperacionA.Add("08.01")
        listaOperacionA.Add("09.01")
        listaOperacionA.Add("10.03")
        listaOperacionA.Add("9904")
        listaOperacionA.Add("10.07")
        listaOperacionA.Add("05")
        listaOperacionA.Add("0000")
        listaOperacionA.Add("04.01")
        listaOperacionA.Add("08.02")
        listaOperacionA.Add("09.02")
        listaOperacionA.Add("12")
        listaOperacionA.Add("13")
        listaOperacionA.Add("14")
        listaOperacionA.Add("15")
        listaOperacionA.Add("06")
        listaOperacionA.Add("0001")
        listaOperacionA.Add("11")
        listaOperacionA.Add("01")


        If dgvAlmacen.Table.Records.Count > 0 Then
            If Not IsNothing(dgvAlmacen.Table.CurrentRecord) Then
                Cursor = Cursors.WaitCursor
                Dim f As New frmInformacionGeneralDetalle
                f.idPersonas = listaID
                f.txtPeriodo.Value = lblPerido.Text
                f.periodo = lblPerido.Text
                f.tipo = tipoConsulta
                f.IntAnioGeneral = AnioGeneral
                f.kardex()
                f.CargarCajasTipoOperqacion(listaOperacionA)
                f.GetKardexByAnio("ALMACENID", listaID, tipoConsulta, lblPerido.Text, dtFechaInicio.Value, dtFechaFin.Value, dgvAlmacen.Table.CurrentRecord.GetValue("idAlmacen"))
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Maximized
                f.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If


    End Sub

    Private Sub dgvDetalleCajas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDetalleCajas.TableControlCellClick
        Dim lista As List(Of String)
        lista = New List(Of String)
        lista.Add("9909")
        lista.Add("9910")
        lista.Add("103")
        lista.Add("9908")

        If dgvDetalleCajas.Table.Records.Count > 0 Then
            If Not IsNothing(dgvDetalleCajas.Table.CurrentRecord) Then
                Cursor = Cursors.WaitCursor
                Dim f As New frmInformacionGeneralDetalle
                f.idPersonas = listaID
                f.txtPeriodo.Value = lblPerido.Text
                f.periodo = lblPerido.Text
                f.tipo = tipoConsulta
                f.IntAnioGeneral = AnioGeneral
                f.listausuario = listaUsuario
                f.movimientoMN()
                f.pnFiltroOperacion.Visible = True
                f.CargarCajasTipoOperqacionMovimiento(lista)
                f.GetTableXMovimientoXInformeGeneral(cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, listaUsuario, dgvDetalleCajas.Table.CurrentRecord.GetValue("idEf"), "XTodo", dtFechaInicio.Value, dtFechaFin.Value, AnioGeneral)
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Maximized
                f.ShowDialog()
                Cursor = Cursors.Default
            Else
                MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub lblCuentasXPagar_Click(sender As Object, e As EventArgs) Handles lblCuentasXPagar.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmInformacionGeneralDetalle
        'f.GetListaVentasPorPeriodo("XCOBRAR", "PN", ListacajausuarioDetalleTE, listaUsuario)
        f.ToolStripButton4.Visible = True
        f.idPersonas = listaID
        f.periodo = lblPerido.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblAporte_Click(sender As Object, e As EventArgs) Handles lblAporte.Click
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovimientosPeriodo(txtAnioCompra.Text, cboMesCompra.SelectedValue, "AP", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.ToolStripButton5.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lblAntOtorgado_Click(sender As Object, e As EventArgs) Handles lblAntOtorgado.Click
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovimientosPeriodo(txtAnioCompra.Text, cboMesCompra.SelectedValue, "AO", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.ToolStripButton5.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub lblIngresosXcobrar_Click(sender As Object, e As EventArgs) Handles lblIngresosXcobrar.Click
        Dim f As New frmInformacionGeneralDetalle
        f.GetMovimientosPeriodo(txtAnioCompra.Text, cboMesCompra.SelectedValue, "CRC", tipoConsulta, listaID, dtFechaInicio.Value, dtFechaFin.Value, listaUsuario)
        f.ToolStripButton5.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ckbHora_CheckedChanged(sender As Object, e As EventArgs) Handles ckbHora.CheckedChanged
        If (ckbHora.Checked = True) Then
            Panel10.Enabled = True
            Panel10.Visible = True
            rbDia.Tag = 1
            dtHoraInicio.Value = dtFechaActual.Value
            dtHoraFin.Value = dtFechaActual.Value
        Else
            Panel10.Enabled = False
            Panel10.Visible = False
            rbDia.Tag = 0
        End If
    End Sub

    Private Sub rbDia_CheckedChanged(sender As Object, e As EventArgs) Handles rbDia.CheckedChanged
        If (rbDia.Checked = True) Then
            pnDia.Enabled = False
            pnPeriodo.Enabled = False
            pnHora.Enabled = True
            pnHora.Visible = True
            pnPeriodo.Visible = False
            pnDia.Visible = False
            btnAceptar.Location = New Point(179, 420)
            limpiar()
            dtFechaActual.Value = DateTime.Now
            dtHoraInicio.Value = dtFechaActual.Value
            dtHoraFin.Value = dtFechaActual.Value
        End If
    End Sub

    Private Sub dtFechaActual_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaActual.ValueChanged
        dtHoraInicio.Value = dtFechaActual.Value
        dtHoraFin.Value = dtFechaActual.Value
    End Sub

    Private Sub dtFechaActual_TabIndexChanged(sender As Object, e As EventArgs) Handles dtFechaActual.TabIndexChanged
        dtHoraInicio.Value = dtFechaActual.Value
        dtHoraFin.Value = dtFechaActual.Value
    End Sub
End Class