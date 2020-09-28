Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms

Public Class frmContabilidadAsientoApertura

#Region "Attributes"
    Public Property ListadoProveedores As List(Of entidad)
    Public Property ListadoClientes As List(Of entidad)
    Public Property tablaSA As New tablaDetalleSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCuentaApertura, True, False)
        FormatoGridAvanzado(dgvpagos, True, False)
        FormatoGridAvanzado(dgvCobros, True, False)
        FormatoGridAvanzado(dgvEntidadFinanciera, True, False)
        FormatoGridAvanzado(GridGroupingControl3, True, False)
        CMBproveedores()
        CMBClientes()
        GetCuentaManuales()
        LoadCombos()
        '   GetSumaCuentasByTipo()
    End Sub


#End Region

#Region "methods"
    Public Sub GrabarVentasApertura()
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim documentoBE As New documento
        Dim obj As New documentoventaAbarrotes
        Dim objDetalle As New documentoventaAbarrotesDet
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim listaCompras As New List(Of documento)

        Try
            documentoBE = New documento
            obj = New documentoventaAbarrotes
            objDetalle = New documentoventaAbarrotesDet
            listaCompras = New List(Of documento)
            ListaDetalle = New List(Of documentoventaAbarrotesDet)



            ListaDetalle = New List(Of documentoventaAbarrotesDet)

            documentoBE = New documento With {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idCentroCosto = GEstableciento.IdEstablecimiento,
                    .idEntidad = usuario.IDUsuario,
                    .entidad = usuario.CustomUsuario.Full_Name,
                    .tipoEntidad = "US",
                    .nrodocEntidad = usuario.CustomUsuario.NroDocumento,
                    .tipoDoc = cboComprobanteCobro.SelectedValue,
                    .fechaProceso = txtFechaCobro.Value,
                    .nroDoc = txtSerieCobro.Text & "-" & txtNroCobro.Text,
                    .tipoOperacion = "01",
                    .usuarioActualizacion = usuario.IDUsuario,
                    .fechaActualizacion = DateTime.Now
                }

            obj = New documentoventaAbarrotes
            obj.fechaDoc = txtFechaCobro.Value
            obj.tipoDocumento = cboComprobanteCobro.SelectedValue
            obj.codigoLibro = "5"
            obj.idEmpresa = Gempresas.IdEmpresaRuc
            obj.idEstablecimiento = GEstableciento.IdEstablecimiento
            obj.fechaPeriodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
            obj.serie = txtSerieCobro.Text
            obj.numeroDoc = txtNroCobro.Text
            obj.moneda = cboMonedaCobro.SelectedValue
            obj.tipoCambio = TxtTipocambioCobro.DoubleValue
            obj.idCliente = txtCliente.Tag
            obj.NombreEntidad = txtCliente.Text
            obj.ImporteNacional = txtImporteCobro.DoubleValue
            obj.ImporteExtranjero = txtImporteCobro.DoubleValue / TxtTipocambioCobro.DoubleValue
            obj.tipoVenta = "APT"
            obj.glosa = "Cuentas por pagara de apertura"
            obj.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.usuarioActualizacion = usuario.IDUsuario
            obj.fechaActualizacion = DateTime.Now
            documentoBE.documentoventaAbarrotes = obj

            objDetalle = New documentoventaAbarrotesDet With
                             {
                                 .idItem = 0,
                                 .nombreItem = "Saldos",
                                 .DetalleItem = "Saldos",
                                 .importeMN = txtImporteCobro.DoubleValue,
                                 .importeME = txtImporteCobro.DoubleValue / TxtTipocambioCobro.DoubleValue,
                                 .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
                                 .usuarioModificacion = usuario.IDUsuario,
                                 .fechaModificacion = DateTime.Now
                                 }


            ListaDetalle.Add(objDetalle)
            'documentoBE.asiento = listaAsiento
            documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
            listaCompras.Add(documentoBE)


            compraSA.GrabarCuetasPorCobrarApertura(listaCompras)
            MessageBox.Show("Elementos registrados!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadCombos()
        Dim listaTbla = tablaSA.GetListaTablaDetalle(10, "1")
        Dim listMonedas = tablaSA.GetListaTablaDetalle(4, "1")

        cboComprobantePago.DataSource = listaTbla
        cboComprobantePago.DisplayMember = "descripcion"
        cboComprobantePago.ValueMember = "codigoDetalle"

        cboComprobanteCobro.DataSource = listaTbla
        cboComprobanteCobro.DisplayMember = "descripcion"
        cboComprobanteCobro.ValueMember = "codigoDetalle"

        cboMonedaCobro.DataSource = listMonedas
        cboMonedaCobro.DisplayMember = "descripcion"
        cboMonedaCobro.ValueMember = "codigoDetalle"

        cboMonedaPago.DataSource = listMonedas
        cboMonedaPago.DisplayMember = "descripcion"
        cboMonedaPago.ValueMember = "codigoDetalle"

    End Sub

    Private Sub CMBproveedores()
        Dim entidadSA As New entidadSA

        ListadoProveedores = New List(Of entidad)
        ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

    Private Sub CMBClientes()
        Dim entidadSA As New entidadSA

        ListadoClientes = New List(Of entidad)
        ListadoClientes = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

    Sub ObtenerEF()
        Dim estadosSA As New EstadosFinancierosSA
        Dim dt As New DataTable()

        dt.Columns.Add("entidad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("numero")
        dt.Columns.Add("moneda")
        dt.Columns.Add("balance")

        For Each i In estadosSA.GetCuentasByTipoDeAporteInicio(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.descripcion
            Select Case i.tipo
                Case CuentaFinanciera.Efectivo
                    dr(1) = "Efectivo"
                Case CuentaFinanciera.Banco
                    dr(1) = "Banco"
                Case CuentaFinanciera.Tarjeta_Credito
                    dr(1) = "Tarjeta de crédito"
                Case CuentaFinanciera.Tarjeta_Debito
                    dr(1) = "Tarjeta de débito"
            End Select

            dr(2) = i.nroCtaCorriente
            dr(3) = i.codigo
            dr(4) = i.importeBalanceMN
            dt.Rows.Add(dr)
        Next
        dgvEntidadFinanciera.DataSource = dt

    End Sub

    Public Structure CuentaFinanciera
        Const Efectivo = "EF"
        Const Banco = "BC"
        Const Tarjeta_Credito = "TC"
        Const Tarjeta_Debito = "TD"
    End Structure

    Private Sub GetSumaCuentasByTipo()
        Dim cuentasSA As New EstadosFinancierosSA
        Dim cuentas As New List(Of estadosFinancieros)
        Dim compraSA As New DocumentoCompraSA
        Dim compra As New documentocompra

        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim venta As New documentoventaAbarrotes

        Dim libroSA As New documentoLibroDiarioSA
        Dim libro As New documentoLibroDiario

        cuentas = cuentasSA.GetSumaCuentasByTipo(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc})

        For Each i In cuentas
            Select Case i.tipo
                Case CuentaFinanciera.Efectivo
                    lblEfectivo.Text = CDec(i.importeBalanceMN.GetValueOrDefault).ToString("N2")
                Case CuentaFinanciera.Banco
                    lblBanco.Text = CDec(i.importeBalanceMN.GetValueOrDefault).ToString("N2")
                Case CuentaFinanciera.Tarjeta_Credito
                    lblTarjetaCredito.Text = CDec(i.importeBalanceMN.GetValueOrDefault).ToString("N2")
                Case CuentaFinanciera.Tarjeta_Debito

            End Select
        Next

        compra = compraSA.GetCuentasPorPagarInicio(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc})
        lblCuentasPorPagar.Text = CDec(compra.importeTotal.GetValueOrDefault).ToString("N2")

        venta = VentaSA.GetCuentasPorCobrarInicio(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc})
        lblCuentasporCobrar.Text = CDec(venta.ImporteNacional.GetValueOrDefault).ToString("N2")

        libro = libroSA.GetSumaInicioExistencias(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc})
        lblExistencias.Text = CDec(libro.importeMN.GetValueOrDefault).ToString("N2")


    End Sub

    Private Sub GetCuentaManuales()
        Dim libroSA As New documentoLibroDiarioSA

        Try
            Dim dt As New DataTable()
            dt.Columns.Add("codigo")
            dt.Columns.Add("cuenta")
            dt.Columns.Add("descripcion")
            dt.Columns.Add("debe")
            dt.Columns.Add("haber")

            For Each i In libroSA.GetCuentasAperturaEmpresa(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc})
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.secuencia
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                Select Case i.tipoAsiento
                    Case "D"
                        dr(3) = CDec(i.importeMN).ToString("N2")
                        dr(4) = "0.00"
                    Case Else
                        dr(3) = "0.00"
                        dr(4) = CDec(i.importeMN).ToString("N2")
                End Select
                dt.Rows.Add(dr)
            Next
            dgvCuentaApertura.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GetCobros()
        Dim dt As New DataTable
        Dim ventaSA As New documentoVentaAbarrotesSA

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("razon")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        For Each i In ventaSA.GetventasDeApertura(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDocumento
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.NombreEntidad
            dr(6) = i.ImporteNacional
            dr(7) = i.ImporteExtranjero
            dt.Rows.Add(dr)
        Next
        dgvCobros.DataSource = dt
    End Sub

    Private Sub GetPagos()
        Dim dt As New DataTable
        Dim compraSA As New DocumentoCompraSA

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("razon")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        For Each i In compraSA.GetComprasDeApertura(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDoc
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.nombreProveedor
            dr(6) = i.importeTotal
            dr(7) = i.importeUS
            dt.Rows.Add(dr)
        Next
        dgvpagos.DataSource = dt
    End Sub

    Private Sub GetExistenciasInicio()
        Dim dt As New DataTable
        Dim libroSA As New documentoLibroDiarioSA

        dt.Columns.Add("codigo")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")

        For Each i In libroSA.GetExistenciasInicio(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.idItem
            dr(2) = i.descripcion
            dr(3) = i.importeMN
            dr(4) = i.importeME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl3.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub Panel31_Click(sender As Object, e As EventArgs) Handles Panel31.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerEF()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel32_Click(sender As Object, e As EventArgs) Handles Panel32.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerEF()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel33_Click(sender As Object, e As EventArgs) Handles Panel33.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerEF()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel34_Click(sender As Object, e As EventArgs) Handles Panel34.Click
        Me.Cursor = Cursors.WaitCursor
        GetPagos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel35_Click(sender As Object, e As EventArgs) Handles Panel35.Click
        Me.Cursor = Cursors.WaitCursor
        GetCobros()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel36_Click(sender As Object, e As EventArgs) Handles Panel36.Click
        Me.Cursor = Cursors.WaitCursor
        GetExistenciasInicio()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs)
        Dim f As New frmInicioTrabajoEmpresa(Gempresas.IdEmpresaRuc)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        GetCuentaManuales()
        GetCobros()
        GetPagos()
        GetExistenciasInicio()
        ObtenerEF()
        '   GetSumaCuentasByTipo()
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstProveedor.SelectedItems.Count > 0 Then
                txtProveedor.Text = lstProveedor.Text
                txtProveedor.Tag = lstProveedor.SelectedValue
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstProveedor.MouseDoubleClick
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcProveedor.Font = New Font("Segoe UI", 8)
            Me.pcProveedor.Size = New Size(301, 148)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListadoProveedores
                            Where n.nombreCompleto.StartsWith(txtProveedor.Text)).ToList

            lstProveedor.DataSource = consulta
            lstProveedor.DisplayMember = "nombreCompleto"
            lstProveedor.ValueMember = "idEntidad"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcProveedor.Font = New Font("Segoe UI", 8)
            Me.pcProveedor.Size = New Size(301, 148)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            lstProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcProveedor.IsShowing() Then
                Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub pcClientes_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcClientes.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstClientes.SelectedItems.Count > 0 Then
                txtCliente.Text = lstClientes.Text
                txtCliente.Tag = lstClientes.SelectedValue
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClientes.SelectedIndexChanged

    End Sub

    Private Sub lstClientes_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstClientes.MouseDoubleClick
        Me.pcClientes.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcClientes.Font = New Font("Segoe UI", 8)
            Me.pcClientes.Size = New Size(301, 148)
            Me.pcClientes.ParentControl = Me.txtCliente
            Me.pcClientes.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListadoClientes
                            Where n.nombreCompleto.StartsWith(txtCliente.Text)).ToList

            lstClientes.DataSource = consulta
            lstClientes.DisplayMember = "nombreCompleto"
            lstClientes.ValueMember = "idEntidad"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcClientes.Font = New Font("Segoe UI", 8)
            Me.pcClientes.Size = New Size(301, 148)
            Me.pcClientes.ParentControl = Me.txtCliente
            Me.pcClientes.ShowPopup(Point.Empty)
            lstClientes.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcClientes.IsShowing() Then
                Me.pcClientes.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        GrabarVentasApertura()
    End Sub

    Private Sub ButtonAdv2_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv2.Click

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click

    End Sub
#End Region

End Class