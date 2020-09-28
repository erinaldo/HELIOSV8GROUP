Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class FormConfirmaDesembolsoComision
    Private listaActivas As List(Of cajaUsuario)
    Public Property CuentasHabilitadas As List(Of estadosFinancierosConfiguracionPagos)
    Public ReadOnly Property _Usuario As Seguridad.Business.Entity.Usuario
    Public ReadOnly Property _ListaComision As List(Of registrocomision_autorizacion)

    Public Property _ListaComisionEnviadas As List(Of registrocomision_autorizacion)

    Public Sub New(usuario As Seguridad.Business.Entity.Usuario, listaComision As List(Of registrocomision_autorizacion))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCuentas, False, False)
        GetCajasActivas()
        _Usuario = usuario
        _ListaComision = listaComision

        txtTotalPagar.DecimalValue = _ListaComision.Sum(Function(o) o.importeAutorizado).GetValueOrDefault
        DateConsulta.Value = DateTime.Now
        BtActivar.Visible = True
        TextProveedor.Text = _Usuario.Full_Name
    End Sub
    Sub GetCajasActivas()
        Dim UsuarioBE = New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        UsuarioBE.idEmpresa = Gempresas.IdEmpresaRuc
        UsuarioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        UsuarioBE.estadoCaja = "A"

        listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)

        ComboCaja.DataSource = listaActivas
        ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
        ComboCaja.DisplayMember = "NombrePersona"

    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles bunifuFlatButton6.Click
        Cursor = Cursors.WaitCursor
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetInicioCuentas(Integer.Parse(ComboCaja.SelectedValue))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function MappingPagos(envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim ListaPagos = ListaPagosCajas(envio)
        Return ListaPagos
    End Function

    Private Function ListaPagosCajas(envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)


        For Each i In dgvCuentas.Table.Records
            If Decimal.Parse(i.GetValue("abonado")) > 0 Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = 0 'CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.fechaProceso = DateTime.Now
                nDocumentoCaja.tipoDoc = "9903" ' cbotipoDocPago.SelectedValue
                nDocumentoCaja.nroDoc = "0"
                nDocumentoCaja.idOrden = Nothing
                nDocumentoCaja.moneda = i.GetValue("moneda")
                'If TextProveedor.Text.Trim.Length > 0 Then
                nDocumentoCaja.idEntidad = VarClienteGeneral.idEntidad
                nDocumentoCaja.entidad = VarClienteGeneral.nombreCompleto
                nDocumentoCaja.nrodocEntidad = "-"
                'Else
                'nDocumentoCaja.entidad = TextProveedor.Text
                '    nDocumentoCaja.nrodocEntidad = 0
                ' nDocumentoCaja.idEntidad = Val(0)
                'End If
                nDocumentoCaja.tipoEntidad = "US"
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.PAGO_COMISIONES
                nDocumentoCaja.usuarioActualizacion = envio.IDCaja ' documentoventa.usuarioActualizacion ' usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now


                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = GetPeriodo(DateTime.Now, True)
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = DateTime.Now
                objCaja.fechaCobro = DateTime.Now
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                'If TextProveedor.Text.Trim.Length > 0 Then
                objCaja.codigoProveedor = _Usuario.IDUsuario
                objCaja.IdProveedor = _Usuario.IDUsuario
                objCaja.idPersonal = _Usuario.IDUsuario
                'End If
                objCaja.TipoDocumentoPago = "9903" 'cbotipoDocPago.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = "9903"
                objCaja.formapago = i.GetValue("idforma") ' "9903"
                objCaja.formaPagoName = i.GetValue("formaPago")
                objCaja.NumeroDocumento = "-"
                ' Dim numeroop = i.GetValue("nrooperacion")


                Dim numeroop = i.GetValue("nrooperacion")

                If numeroop.ToString.Trim.Length > 0 Then
                    objCaja.numeroOperacion = i.GetValue("nrooperacion")
                End If


                If i.GetValue("idforma") = "006" Or i.GetValue("idforma") = "007" Then
                    objCaja.estadopago = 1

                End If
                objCaja.movimientoCaja = StatusTipoOperacion.PAGO_COMISIONES

                objCaja.montoSoles = Decimal.Parse(i.GetValue("abonado"))

                objCaja.moneda = i.GetValue("moneda")
                objCaja.tipoCambio = Decimal.Parse(i.GetValue("tipocambio"))
                objCaja.montoUsd = Decimal.Parse(i.GetValue("abonadoME")) 'Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

                objCaja.estado = "1"
                objCaja.estadopago = 0
                objCaja.glosa = "Pago de comisiones: " & _Usuario.Full_Name
                objCaja.entregado = "SI"

                objCaja.idCajaUsuario = envio.IDCaja ' GFichaUsuarios.IdCajaUsuario
                objCaja.entidadFinanciera = i.GetValue("identidad")
                objCaja.NombreEntidad = i.GetValue("entidad")
                objCaja.usuarioModificacion = envio.IDCaja 'documentoventa.usuarioActualizacion ' usuario.IDUsuario
                objCaja.fechaModificacion = DateTime.Now
                nDocumentoCaja.documentoCaja = objCaja
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja)
                'asientoDocumento(nDocumentoCaja.documentoCaja)
                ListaDoc.Add(nDocumentoCaja)
            End If
        Next

        'If TextValoranticipo.DecimalValue > 0 Then
        '    listaAnticipoDetalle = New List(Of documentoAnticipoConciliacion)
        '    listaAnticipoDetalle = GetDetallePagoAnticipoV2(TextValoranticipo.DecimalValue, ventaDetalle)
        'End If

        'If PanelCupon.Visible Then
        '    If TextCuponImporte.DecimalValue > 0 Then
        '        ListaDoc.Add(AddPagoCuponCaja(venta, ventaDetalle))
        '    End If
        'End If

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja)
        Dim obj As registrocomision_autorizacion

        Dim montoPago = objCaja.montoSoles
        ' Dim montoPagoME = objCaja.montoUsd
        GetDetallePago = New List(Of documentoCajaDetalle)
        _ListaComisionEnviadas = New List(Of registrocomision_autorizacion)
        For Each i In _ListaComision
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estado = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estado = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estado = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),
                    Dim montoUsd As Decimal = 0
                    If (objCaja.moneda = "1") Then
                        montoUsd = 0
                    Else
                        montoUsd = Math.Round(i.MontoPago / objCaja.tipoCambio.GetValueOrDefault, 2)
                    End If

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .fecha = Date.Now,
                                   .codigoLote = 0,
                                   .otroMN = 0,
                                   .idItem = i.customProducto.codigodetalle,
                                   .DetalleItem = i.customProducto.descripcionItem,
                                   .montoSoles = i.MontoPago,
                                   .montoUsd = montoUsd,
                                   .diferTipoCambio = objCaja.tipoCambio,
                                   .tipoCambioTransacc = objCaja.tipoCambio,
                                   .entregado = "SI",
                                   .idCajaUsuario = objCaja.idCajaUsuario, ' GFichaUsuarios.IdCajaUsuario,
                                   .usuarioModificacion = i.customRegistrocomision_usuarios_detalle.IdUsuario, ' usuario.IDUsuario,
                                   .documentoAfectado = i.idseguimiento,
                                   .documentoAfectadodetalle = i.idseguimientoDetalle,
                                   .EstadoCobro = i.estado.ToString(),
                                   .fechaModificacion = DateTime.Now
                                   })
                    i.estado = i.estado


                    obj = New registrocomision_autorizacion
                    obj.idAutorizacion = i.idAutorizacion
                    obj.idseguimiento = i.idseguimiento
                    obj.idseguimientoDetalle = i.idseguimientoDetalle
                    obj.idDocumentoRef = i.customDocumentoVenta.idDocumento
                    obj.fechaAprobacion = DateConsulta.Value
                    obj.desembolsoAutorizado = True
                    obj.usuarioDesembolsoAutorizado = objCaja.idCajaUsuario
                    _ListaComisionEnviadas.Add(obj)
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
        Return GetDetallePago
    End Function

    Private Sub GetInicioCuentas(idCajaUsuario As Integer)
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        Dim usuariocaja = listaActivas.Where(Function(o) o.idcajaUsuario = idCajaUsuario).FirstOrDefault

        Dim dt As New DataTable

        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
            .Columns.Add("moneda")
            .Columns.Add("abonadoME")
        End With

        If usuariocaja IsNot Nothing Then
            CuentasHabilitadas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                {
                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                .IDCaja = usuariocaja.idcajaUsuario
                                                })

            For Each i In CuentasHabilitadas.Where(Function(o) o.tipo <> "EE").ToList ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList

                'If i.FormaPago = "EFECTIVO" And txtTotalPagar.DecimalValue > 0 Then
                '    dt.Rows.Add(String.Empty, i.identidad, i.entidad, txtTotalPagar.DecimalValue, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-", i.moneda)
                'Else
                dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-", i.moneda, 0)
                ' End If
            Next
            dgvCuentas.DataSource = dt
        End If

    End Sub

    Private Sub BtActivar_Click(sender As Object, e As EventArgs) Handles BtActivar.Click
        RealizarDesembolso()
    End Sub

    Private Sub realizarDesembolso()
        Dim be As New documento
        Dim comisionSA As New registrocomision_autorizacionSA
        Dim usuarioSel = listaActivas.Where(Function(o) o.idcajaUsuario = Integer.Parse(ComboCaja.SelectedValue)).SingleOrDefault
        If usuarioSel Is Nothing Then
            '  btOperacion.Enabled = True
            MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim envio = GetConfiguracionUsuario(usuario.CustomUsuario, usuarioSel)

        Dim listaPagos = MappingPagos(envio)
        be.ListaCustomDocumento = listaPagos
        be.CustomComisionAutorizacion = _ListaComisionEnviadas
        comisionSA.RegistrarPagosComnision(be)
        MessageBox.Show("Comisiones pagadas!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Function GetConfiguracionUsuario(usuarioSel As Seguridad.Business.Entity.Usuario, cajaUsuario As cajaUsuario) As EnvioImpresionVendedorPernos
        Dim envio As EnvioImpresionVendedorPernos
        envio = New EnvioImpresionVendedorPernos With
            {
            .CodigoVendedor = usuarioSel.codigo,
            .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
            .IDVendedor = usuarioSel.IDUsuario,
            .print = True,
            .Nombreprint = String.Empty,
            .NombreCajero = usuarioSel.Full_Name,
            .EntidadFinanciera = 0,'ef.idestado,
            .EntidadFinancieraName = String.Empty
        }
        Return envio
    End Function
End Class