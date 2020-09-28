Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Public Class UCOtrasSalidas

#Region "Attributes"
    Public Property CompraSA As New DocumentoCompraSA
    Public Property TablaSA As New tablaDetalleSA
    Private listaOperacion As List(Of tabladetalle)
    Dim Alert As Alert
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Methods"

    Public Sub CargarComplementos()
        listaOperacion = TablaSA.GetListaTablaDetalle(12, "1")
        FormatoGridAvanzado(dgvCompras, True, False, 9.0F, SelectionMode.MultiExtended)
        OrdenamientoGrid(dgvCompras, False)
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVenta(objDocumento)
            'documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgvCompras.Table.CurrentRecord.Delete()
            MessageBox.Show("venta anulada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'lblEstado.Text = "Pedido eliminado!"
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EliminarEntrada()
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            CompraSA.AnularSalidaInv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            'compraSA.EliminarEntradainv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            Alert = New Alert("Entrada anulada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            r.Delete()
            dgvCompras.Refresh()
        End If
    End Sub

    Private Sub GetMovDia(fechaLab As Date, idEstable As Integer)

        Dim dt As New DataTable("Movimientos")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("tieneAsiento", GetType(String)))

        Dim str As String
        For Each i As documentocompra In CompraSA.GetListarMvimientosAlmacenPorDia(idEstable, TIPO_COMPRA.OTRAS_SALIDAS, fechaLab, StatusTipoConsulta.XUNIDAD_ORGANICA).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = listaOperacion.Where(Function(o) o.codigoDetalle = i.tipoOperacion).Select(Function(o) o.descripcion).FirstOrDefault

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc

            If i.estadoPago = TIPO_COMPRA.COMPRA_ANULADA Then
                dr(14) = "ANULADA"
            Else
                dr(14) = i.estadoPago
            End If
            dr(15) = If(i.aprobado = "S", "-SI-", "-NO-")
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        PictureLoad.Visible = False
        BunifuFlatButton5.Enabled = True
    End Sub

    Private Sub GetMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)

        Dim dt As New DataTable("Movimientos")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("tieneAsiento", GetType(String)))

        Dim str As String
        For Each i As documentocompra In CompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_SALIDAS, StatusTipoConsulta.XUNIDAD_ORGANICA).Where(Function(o) o.tipoCompra = TIPO_COMPRA.OTRAS_SALIDAS).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = listaOperacion.Where(Function(o) o.codigoDetalle = i.tipoOperacion).Select(Function(o) o.descripcion).FirstOrDefault

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc

            If i.estadoPago = TIPO_COMPRA.COMPRA_ANULADA Then
                dr(14) = "ANULADA"
            Else
                dr(14) = i.estadoPago
            End If
            dr(15) = If(i.aprobado = "S", "-SI-", "-NO-")
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        PictureLoad.Visible = False
        BunifuFlatButton5.Enabled = True
    End Sub


    Private Sub GetListaVentasPorTipo(period As String, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Otras sálidas: - " & period)
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
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, period, tipo, StatusTipoConsulta.XUNIDAD_ORGANICA)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            dr(6) = i.numeroVenta

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
            dr(14) = "-"
            dr(15) = "Entregada"
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dr(17) = i.EnvioSunat

            dr(18) = i.fechaDoc

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDia(fechaLaboral As Date, idEstable As Integer, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Salidas del día - " & fechaLaboral)
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
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPorDiaEstablecimiento(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral, .tipoVenta = tipo})
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            dr(6) = i.numeroVenta
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
            dr(14) = "-"
            dr(15) = "Entregada"
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If
            dr(17) = i.EnvioSunat
            dr(18) = i.fechaDoc

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompras.DataSource = table
            PictureLoad.Visible = False
            BunifuFlatButton5.Enabled = True
            BunifuFlatButton3.Enabled = True
        End If
    End Sub

#End Region

#Region "Events"
    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try


            Dim f As New FormFiltroAvanzadoPeriodo()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim periodoSel = CType(f.Tag, DateTime?)
                PictureLoad.Visible = True
                BunifuFlatButton5.Enabled = False
                'GetMovPorPeriodo(GEstableciento.IdEstablecimiento, GetPeriodo(periodoSel, True))
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipo(GetPeriodo(periodoSel, True), TIPO_COMPRA.OTRAS_SALIDAS)))
                thread.Start()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            Dim FechaSel = CType(f.Tag, DateTime?)
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorDia(FechaSel, GEstableciento.IdEstablecimiento, TIPO_COMPRA.OTRAS_SALIDAS)))
            thread.Start()


            'GetMovDia(FechaSel, GEstableciento.IdEstablecimiento)
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        'LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Try
            ' If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ANULAR_ENTRADA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then

                If MessageBox.Show("Desea anular el registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'EliminarEntrada()
                    EliminarPV(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                End If

            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
            End If
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Catch ex As Exception
            Alert = New Alert(ex.Message, alertType.warning)
            Alert.TopMost = True
            Alert.Show()
        End Try

        'LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            UbicarDocumentoVenta(CInt(r.GetValue("idDocumento")))
        End If
    End Sub

    Private Sub UbicarDocumentoVenta(idDocumento As Integer)

        Dim ventaSA As New documentoVentaAbarrotesSA
        ClipBoardDocumento = New documento
        ClipBoardDocumento.documentoventaAbarrotes = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
        MessageBox.Show("Formato copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try


            PictureLoad.Visible = True
            Dim r As Record = Me.dgvCompras.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim f As New FormVentaNueva(Integer.Parse(r.GetValue("idDocumento")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End If
            PictureLoad.Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNuevaVenta_Click(sender As Object, e As EventArgs) Handles btnNuevaVenta.Click
        If validarPermisos(PermisosDelSistema.SALIDA_DE_INVENTARIO_, AutorizacionRolList) = 1 Then
            Dim f As New FormVentaNueva("OTRA SALIDA DE ALMACEN", "1")
            f.ComboComprobante.Text = "OTRA SALIDA DE ALMACEN"
            f.ComboComprobante.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
#End Region

End Class
