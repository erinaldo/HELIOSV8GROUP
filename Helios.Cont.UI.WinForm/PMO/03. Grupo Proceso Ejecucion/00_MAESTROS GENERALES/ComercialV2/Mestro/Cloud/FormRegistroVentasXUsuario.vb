Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses

Public Class FormRegistroVentasXUsuario

    Property CierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
        txtFecha.Value = Date.Now.Date
        'FormatoGrid(dgPedidos)
        FormatoGridPequeño(dgPedidos, True)
        'ProgressBar1.Visible = True
        'ProgressBar1.Style = ProgressBarStyle.Marquee

        'Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorDia(Date.Now.Date)))
        'thread.Start()
    End Sub



    Private Sub FormRegistroVentasXUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub GetListaVentasPorPeriodo(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVEntaBE As New documentoventaAbarrotes
        Dim UsuarioCaja As New UsuarioSA
        Dim usuarioBE As New Usuario
        Dim objUsuario As New Usuario
        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cobranza", GetType(String)))

        documentoVEntaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoVEntaBE.fechaPeriodo = period
        documentoVEntaBE.usuarioActualizacion = usuario.IDUsuario

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, period)
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodoXUsuario(documentoVEntaBE)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If
            usuarioBE = New Usuario
            usuarioBE.IDUsuario = i.CajaSeleccionada
            If (usuarioBE.IDUsuario <> 0) Then
                objUsuario = UsuarioCaja.UbicarUsuarioXid(usuarioBE)
                If (Not IsNothing(objUsuario)) Then
                    dr(17) = objUsuario.Nombres & " " & objUsuario.ApellidoPaterno & " " & objUsuario.ApellidoMaterno
                End If
            End If
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorPeriodoUsuario(period As String, be As Usuario)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVEntaBE As New documentoventaAbarrotes
        Dim UsuarioCajaSA As New UsuarioSA
        Dim usuarioBE As New Usuario
        'Dim objUsuario As New Usuario
        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cobranza", GetType(String)))

        documentoVEntaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoVEntaBE.fechaPeriodo = period
        documentoVEntaBE.usuarioActualizacion = be.IDUsuario

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, period)
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodoXUsuario(documentoVEntaBE)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            If i.CajaSeleccionada > 0 Then
                Dim UsuarioCaja = UsuarioCajaSA.UbicarUsuarioXid(New Seguridad.Business.Entity.Usuario With
                                                             {
                                                             .IDUsuario = i.CajaSeleccionada
                                                             })

                If UsuarioCaja IsNot Nothing Then
                    dr(17) = UsuarioCaja.Full_Name
                End If
            Else
                dr(17) = "-"
            End If


            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub



    Private Sub GetListaVentasPorDia(fecha As Date)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVEntaBE As New documentoventaAbarrotes
        Dim UsuarioCaja As New UsuarioSA
        Dim usuarioBE As New Usuario
        Dim objUsuario As New Usuario
        Dim dt As New DataTable("Ventas de - " & fecha)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cobranza", GetType(String)))
        documentoVEntaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoVEntaBE.fechaDoc = fecha
        documentoVEntaBE.usuarioActualizacion = usuario.IDUsuario

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, period)
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasDiaXUsuario(documentoVEntaBE)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case "VNP"
                    dr(5) = i.serieVenta
                    dr(6) = i.numeroDoc
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If
            usuarioBE = New Usuario
            usuarioBE.IDUsuario = i.CajaSeleccionada
            If (usuarioBE.IDUsuario <> 0) Then
                objUsuario = UsuarioCaja.UbicarUsuarioXid(usuarioBE)
                If (Not IsNothing(objUsuario)) Then
                    dr(17) = objUsuario.Nombres & " " & objUsuario.ApellidoPaterno & " " & objUsuario.ApellidoMaterno
                End If
            End If

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDiaUsuario(fecha As Date, be As Usuario)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVEntaBE As New documentoventaAbarrotes
        Dim UsuarioCajaSA As New UsuarioSA

        Dim dt As New DataTable("Ventas de - " & fecha)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cobranza", GetType(String)))
        documentoVEntaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoVEntaBE.fechaDoc = fecha
        documentoVEntaBE.usuarioActualizacion = be.IDUsuario

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, period)
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasDiaXUsuario(documentoVEntaBE)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case "VNP"
                    dr(5) = i.serieVenta
                    dr(6) = i.numeroDoc
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            If i.CajaSeleccionada > 0 Then
                Dim UsuarioCaja = UsuarioCajaSA.UbicarUsuarioXid(New Seguridad.Business.Entity.Usuario With
                                                             {
                                                             .IDUsuario = i.CajaSeleccionada
                                                             })

                If UsuarioCaja IsNot Nothing Then
                    dr(17) = UsuarioCaja.Full_Name
                End If
            Else
                dr(17) = "-"
            End If

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

#Region "Methdos"


    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        Dim listaEmpresa As New List(Of empresaPeriodo)
        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        listaEmpresa = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = listaEmpresa
        cboAnio.Text = DateTime.Now.Year

    End Sub
#End Region


    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub rbDia_CheckedChanged(sender As Object, e As EventArgs) Handles rbDia.CheckedChanged
        If rbDia.Checked = True Then
            dgPedidos.Table.Records.DeleteAll()
            txtFecha.Visible = True
            cboMesPedido.Visible = False
            cboAnio.Visible = False
            'rbDia.Checked = True
            'rbMes.Checked = False
            'pnFiltro.Visible = False
            'pnXDia.Visible = True
            'ProgressBar1.Visible = True

        End If
    End Sub

    Private Sub rbMes_CheckedChanged(sender As Object, e As EventArgs) Handles rbMes.CheckedChanged
        If rbMes.Checked = True Then
            dgPedidos.Table.Records.DeleteAll()
            txtFecha.Visible = False
            cboMesPedido.Visible = True
            cboAnio.Visible = True
            'rbDia.Checked = True
            'rbMes.Checked = False
            'pnFiltro.Visible = False
            'pnXDia.Visible = True
            'ProgressBar1.Visible = True

        End If
    End Sub

    'Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click

    '    ProgressBar1.Visible = True
    '    ProgressBar1.Style = ProgressBarStyle.Marquee
    '    Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
    '    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(periodo & "/" & cboAnio.Text)))
    '    thread.Start()
    'End Sub

    'Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
    '    ProgressBar1.Style = ProgressBarStyle.Marquee
    '    Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
    '    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorDia(txtFecha.Value.Date)))
    '    thread.Start()
    'End Sub

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        dgPedidos.Table.Records.DeleteAll()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            If (dgPedidos.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_VENTA.VENTA_NOTA_PEDIDO) Then
                Dim f As New FormVentaNuevoPosV2(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.btGrabar.Enabled = True
                f.Show(Me)
                'Dim f As New FormVentaNuevoPosV2(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                'f.ShowDialog()
            Else
                MessageBox.Show("Ya se realizo el cobro del pedido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            Dim f As New FormVendedorConStock(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.btGrabar.Enabled = False
            'f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.Show(Me)

        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles TextUsuario.TextChanged

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        GetVentasByUsuario()
    End Sub

    Private Sub GetVentasByUsuario()
        Dim usuario = UsuariosList.Where(Function(o) o.CustomAutenticacionUsuario.Alias = TextUsuario.Text.Trim AndAlso
                                             o.codigo = PasswordTextBox.Text.Trim).FirstOrDefault

        If rbMes.Checked = True Then
            If usuario IsNot Nothing Then
                ProgressBar1.Visible = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodoUsuario(periodo & "/" & cboAnio.Text, usuario)))
                thread.Start()
            Else
                MessageBox.Show("Usuario no ubicado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgPedidos.Table.Records.DeleteAll()
            End If
        ElseIf rbDia.Checked = True Then
            If usuario IsNot Nothing Then
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorDiaUsuario(txtFecha.Value.Date, usuario)))
                thread.Start()
            Else
                MessageBox.Show("Usuario no ubicado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgPedidos.Table.Records.DeleteAll()
            End If
        End If

    End Sub
End Class