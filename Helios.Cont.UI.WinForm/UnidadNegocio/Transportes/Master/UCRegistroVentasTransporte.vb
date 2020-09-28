Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Gma.QrCodeNet.Encoding.Windows.Forms
Imports Syncfusion.GroupingGridExcelConverter

Public Class UCRegistroVentasTransporte

#Region "Attributes"
    Dim ventaSA As New DocumentoventaTransporteSA
    Public Property FormUcEncomiendas As UCEncomiendas
    Public QR As String
    Public HASH As String
    Public CERTIFICADO As String
    Private Const FormatoFecha As String = "yyyy-MM-dd"
    Public objDatosGenrales As New datosGenerales
    Dim listaDatos As New List(Of datosGenerales)
#End Region

#Region "Methods"

    Public Sub EnviarAnulacionDocumento(objeto As documentoventaTransporte)
        Try
            Dim documentoventasa As New DocumentoventaTransporteSA

            Dim objetoBaja As New Helios.Fact.Sunat.Business.Entity.RecepcionComunicacionBaja

            objetoBaja.IdDocumento = objeto.serie & "-" & String.Format("{0:00000000}", CInt(objeto.numero))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.idEmpresa = Gempresas.ubigeo
            objetoBaja.FechaEmision = objeto.fechadoc
            objetoBaja.EnvioSunat = "NO"
            objetoBaja.estadoEnvio = "PE"
            objetoBaja.Contribuyente_id = Gempresas.IdEmpresaRuc

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.RecepcionComunicacionBajaSA.RecepcionComunicacionBajaSave(objetoBaja, Nothing)

            If codigo.idAnulacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)
                documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, codigo.idAnulacion, 0)

                MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

        End Try
    End Sub



    Public Sub EnviarComunicacionBaja(objeto As documentoventaTransporte)

        Try
            'GetNumeracion("BAJA", Gempresas.IdEmpresaRuc)
            Dim numeracionsa As New NumeracionBoletaSA
            Dim documentoventasa As New DocumentoventaTransporteSA
            'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)
            Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "BAJA", "01")
            Dim objetoBaja As Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle

            'CABEZERA
            Dim comunicacion As New Helios.Fact.Sunat.Business.Entity.ComunicacionBaja
            comunicacion.Action = 0
            comunicacion.idEmpresa = Gempresas.ubigeo 'lblIdPse.Text
            comunicacion.IdDocumento = String.Format("RA-{0:yyyyMMdd}-" & numerobaja, DateTime.Today)
            comunicacion.FechaEmision = DateTime.Now
            comunicacion.FechaReferencia = objeto.fechadoc  'dtpFechaDocs.Value
            comunicacion.FechaRecepcion = DateTime.Now
            comunicacion.EnvioSunat = "NO"
            comunicacion.Contribuyente_id = Gempresas.IdEmpresaRuc
            'DETALLE
            objetoBaja = New Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
            objetoBaja.Id = 1
            objetoBaja.Serie = objeto.serie ' i.GetValue("serie")
            objetoBaja.Correlativo = String.Format("{0:00000000}", CInt(objeto.numero))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.MotivoBaja = "ANULACION DE LA FACTURA"
            comunicacion.ComunicacionBajaDetalle.Add(objetoBaja)

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.ComunicacionBajaSA.ComunicacionBajaSaveValidado(comunicacion, Nothing)

            If codigo.idComunicacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)
                documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, numerobaja, 0)

                MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
            End If
        Catch ex As Exception
            MessageBox.Show("No se Pudo Enviar")
        End Try

    End Sub


    'Public Sub EnviarnBoletaAnulada(item As documentoventaTransporte)

    '    Dim numeracionsa As New NumeracionBoletaSA
    '    Dim DocumentoSA As New DocumentoventaTransporteSA
    '    Dim entidadSA As New entidadSA
    '    Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "RSD", "03")
    '    'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)

    '    Dim comprobante = DocumentoSA.DocumentoTransporteSelID(item)

    '    Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.razonSocial)
    '    Dim numer As String = String.Format("{0:00000}", CInt(numerobaja))
    '    Dim numerobol = String.Format("{0:00000000}", CInt(comprobante.numero))
    '    Dim objeto As Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
    '    Dim Resumen = New Helios.Fact.Sunat.Business.Entity.DocumentoResumen

    '    Try

    '        Resumen.Action = 0
    '            Resumen.idEmpresa = Gempresas.ubigeo
    '            Resumen.Contribuyente_id = Gempresas.IdEmpresaRuc
    '            Resumen.IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today)
    '            Resumen.FechaEmision = DateTime.Now
    '        Resumen.FechaReferencia = item.fechadoc
    '        Resumen.FechaRecepcion = DateTime.Now
    '            Resumen.EnvioSunat = "NO"
    '            Resumen.Grupo = "NO"

    '        Resumen.TipoResumen = "AN"


    '        objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle

    '                objeto.idSecuencia = 1
    '        objeto.TipoDocumento = comprobante.tipoDocumento
    '        objeto.IdDocumento = comprobante.serie & "-" & numerobol
    '        objeto.NroDocumentoReceptor = receptor.tipoDocumento
    '        objeto.TipoDocumentoReceptor = r.GetValue("tipoDocCliente")
    '                objeto.CodigoEstadoItem = CInt(r.GetValue("estado"))
    '                objeto.Moneda = r.GetValue("moneda")
    '                objeto.TotalVenta = CDec(r.GetValue("importe"))
    '                objeto.TotalIgv = CDec(r.GetValue("igv"))
    '                objeto.Gravadas = CDec(r.GetValue("gravado"))
    '                objeto.Exoneradas = CDec(r.GetValue("exonerado"))

    '                Resumen.DocumentoResumenDetalle.Add(objeto)



    '        'Enviando al PSE
    '        Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoResumenSA.DocumentoResumenSave(Resumen, Nothing)

    '            If codigo.idResumen > 0 Then
    '                DocumentoSA.UpdateAnulacionEnviada(r.GetValue("idDocumento"), numerobaja, 0)
    '                MessageBox.Show("El Resumen se Envio Correctamente al PSE")

    '        End If

    '    Catch ex As Exception

    '        MessageBox.Show("No se Pudo Enviar")

    '    End Try
    'End Sub



    Public Sub EnviarBoletaEliminada(item As documentoventaTransporte)
        Try
            'GetNumeracion("RSD", Gempresas.IdEmpresaRuc)

            Dim numeracionsa As New NumeracionBoletaSA
            Dim entidadSA As New entidadSA
            Dim documentoSA As New DocumentoventaTransporteSA
            'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)
            Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "RSD", "03")
            Dim numer As String = String.Format("{0:00000}", CInt(numerobaja))

            Dim comprobante = documentoSA.DocumentoTransporteSelID(item)

            Dim numerobol = String.Format("{0:00000000}", CInt(comprobante.numero))
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.razonSocial)

            Dim objeto As Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            Dim Resumen = New Helios.Fact.Sunat.Business.Entity.DocumentoResumen
            'CABEZERA
            Resumen.Action = 0
            Resumen.idEmpresa = Gempresas.ubigeo
            Resumen.Contribuyente_id = Gempresas.IdEmpresaRuc
            Resumen.IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today)
            Resumen.FechaEmision = DateTime.Now
            Resumen.FechaReferencia = comprobante.fechadoc
            Resumen.FechaRecepcion = DateTime.Now
            Resumen.EnvioSunat = "NO"
            Resumen.TipoResumen = "AN"
            Resumen.Grupo = "NO"
            'DETALLE
            objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            objeto.idSecuencia = 1
            objeto.TipoDocumento = comprobante.tipoDocumento
            objeto.IdDocumento = comprobante.serie & "-" & numerobol
            objeto.NroDocumentoReceptor = receptor.nrodoc
            objeto.TipoDocumentoReceptor = receptor.tipoDoc
            objeto.CodigoEstadoItem = CInt(3) 'CInt(i.GetValue("estado"))
            'If comprobante.moneda = "1" Then
            objeto.Moneda = "PEN"
            'ElseIf comprobante.moneda = "2" Then
            'objeto.Moneda = "USD"
            'End If
            objeto.TotalVenta = comprobante.total
            objeto.TotalIgv = comprobante.igv1
            objeto.Gravadas = comprobante.baseImponible1
            objeto.Exoneradas = CDec(0) 'comprobante.bi02

            Resumen.DocumentoResumenDetalle.Add(objeto)

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoResumenSA.DocumentoResumenSaveValidado(Resumen, Nothing)

            If codigo.idResumen > 0 Then

                'ActualizarBoletas(listaActEstado, IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante), "0")

                documentoSA.UpdateAnulacionEnviada(comprobante.idDocumento, numerobaja, 0)

                MessageBox.Show("El Resumen se Envio Correctamente al PSE")

            End If

        Catch ex As Exception

            MessageBox.Show("No se Pudo Enviar")

        End Try
    End Sub

    Private Sub GetAgencias()
        Dim agenciaSA As New establecimientoSA
        Dim listaAgencias = Transporte.ListaAgencias ' agenciaSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList

        Dim listaAgenciasOrigen = listaAgencias.Where(Function(o) o.TipoEstab = "UN").ToList

        ComboAgenciaOrigen.DataSource = listaAgenciasOrigen
        ComboAgenciaOrigen.DisplayMember = "nombre"
        ComboAgenciaOrigen.ValueMember = "idCentroCosto"
        ComboAgenciaOrigen.Text = GEstableciento.NombreEstablecimiento
    End Sub

    Private Sub GetEncomiendasDelDia(now As Date)
        Dim estado As String = String.Empty
        Dim tipoventaTrans As String = String.Empty
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("fecharecepcion")
        dt.Columns.Add("origen")
        dt.Columns.Add("Emisor")
        dt.Columns.Add("destino")
        dt.Columns.Add("receptor")
        dt.Columns.Add("items")
        dt.Columns.Add("total")
        dt.Columns.Add("estadopago")
        dt.Columns.Add("estado")
        dt.Columns.Add("enviosunat")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("tipoVenta")
        dt.Columns.Add("asientoID")
        Dim comprador As String = String.Empty
        For Each i In ventaSA.GetConsultaTransporteFecha(New Business.Entity.documentoventaTransporte With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
                                                          .fechadoc = now
                                                          }).OrderByDescending(Function(o) o.fechadoc).ToList

            Select Case i.estado
                Case Transporte.EncomiendaEstado.PendienteDeEntrega
                    estado = "Pendiente"
                Case Transporte.EncomiendaEstado.Entregado
                    estado = "Entregado"
                Case Transporte.EncomiendaEstado.Abandonado
                    estado = "Abandonado"
                Case Transporte.EncomiendaEstado.Vencido
                    estado = "Vencido"
                Case Transporte.EncomiendaEstado.Otros
                    estado = "otros"
                Case Transporte.EncomiendaEstado.Anulado
                    estado = "Anulado"
            End Select

            If i.Consignado IsNot Nothing Then
                comprador = i.Consignado
            Else
                comprador = i.comprador
            End If


            If (i.tipoVenta = "ENDAS") Then
                tipoventaTrans = "ENCOMIENDA"
            ElseIf (i.tipoVenta = "VPSJ") Then
                tipoventaTrans = "BOLETAJE"
            End If

            dt.Rows.Add(
                i.idDocumento,
                i.fechadoc,
                i.ciudadOrigen,
                i.Remitente,
                i.ciudadDestino,
               comprador,
                i.itemsEnviados,
                i.total,
               If(i.estadoCobro = "DC", "COBRADO", "ANULADO"),
                estado,
                i.EnvioSunat,
                i.tipoDocumento,
                i.serie,
                i.numero,
tipoventaTrans,
i.idDistribucion)

        Next
        GridEncomiendas.DataSource = dt
    End Sub

    Private Sub GetEncomiendasMes(fecha As Date)
        Try
            Dim tipoventaTrans As String = String.Empty
            Dim estado As String = String.Empty
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("fecharecepcion")
            dt.Columns.Add("origen")
            dt.Columns.Add("Emisor")
            dt.Columns.Add("destino")
            dt.Columns.Add("receptor")
            dt.Columns.Add("items")
            dt.Columns.Add("total")
            dt.Columns.Add("estadopago")
            dt.Columns.Add("estado")
            dt.Columns.Add("enviosunat")
            dt.Columns.Add("tipoDoc")
            dt.Columns.Add("serie")
            dt.Columns.Add("numero")
            dt.Columns.Add("tipoVenta")
            dt.Columns.Add("asientoID")
            Dim comprador As String = String.Empty
            For Each i In ventaSA.GetConsultaTransporteSelMes(New Business.Entity.documentoventaTransporte With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
                                                              .fechadoc = fecha
                                                              }).OrderByDescending(Function(o) o.fechadoc).ToList

                Select Case i.estado
                    Case Transporte.EncomiendaEstado.PendienteDeEntrega
                        estado = "Pendiente"
                    Case Transporte.EncomiendaEstado.Entregado
                        estado = "Entregado"
                    Case Transporte.EncomiendaEstado.Abandonado
                        estado = "Abandonado"
                    Case Transporte.EncomiendaEstado.Vencido
                        estado = "Vencido"
                    Case Transporte.EncomiendaEstado.Otros
                        estado = "otros"
                    Case Transporte.EncomiendaEstado.Anulado
                        estado = "Anulado"
                End Select

                If i.Consignado IsNot Nothing Then
                    comprador = i.Consignado
                Else
                    comprador = i.comprador
                End If

                If (i.tipoVenta = "ENDAS") Then
                    tipoventaTrans = "ENCOMIENDA"
                ElseIf (i.tipoVenta = "VPSJ") Then
                    tipoventaTrans = "BOLETAJE"
                End If

                dt.Rows.Add(
                    i.idDocumento,
                    i.fechadoc,
                    i.ciudadOrigen,
                    i.Remitente,
                    i.ciudadDestino,
                   comprador,
                    i.itemsEnviados,
                    i.total,
                   If(i.estadoCobro = "DC", "COBRADO", "ANULADO"),
                    estado,
                    i.EnvioSunat,
                    i.tipoDocumento,
                    i.serie,
                    i.numero,
   tipoventaTrans,
    i.idDistribucion)

            Next
            GridEncomiendas.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Constructors"
    Public Sub New(Form As UCEncomiendas)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEncomiendas, True, False, 10.0F)
        FormUcEncomiendas = Form
        ' GetEncomiendasDelDia()
        GetAgencias()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEncomiendas, True, False, 10.0F)

        ' GetEncomiendasDelDia()
        GetAgencias()

    End Sub
#End Region

#Region "Events"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F1
                If ListaCajasActivas IsNot Nothing Then
                    If ListaCajasActivas.Count > 0 Then
                        Dim f As New FormCrearEncomiendaV2(FormUcEncomiendas)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog(Me)
                        GetEncomiendasDelDia(Date.Now)
                    Else
                        MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Case Keys.F4

                Dim f As New frmMasterPSETransporte
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog(Me)
                GetEncomiendasDelDia(Date.Now)

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs)
        If ListaCajasActivas IsNot Nothing Then
            If ListaCajasActivas.Count > 0 Then
                Dim f As New FormCrearEncomiendaV2(FormUcEncomiendas)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                GetEncomiendasDelDia(Date.Now)
            Else
                MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        Cursor = Cursors.WaitCursor
        Try
            GetEncomiendasDelDia(Date.Now)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        GridEncomiendas.TopLevelGroupOptions.ShowFilterBar = True
        GridEncomiendas.NestedTableGroupOptions.ShowFilterBar = True
        GridEncomiendas.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In GridEncomiendas.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        GridEncomiendas.OptimizeFilterPerformance = True
        GridEncomiendas.ShowNavigationBar = True
        filter.WireGrid(GridEncomiendas)

    End Sub



    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        Try

            Dim productoBE As New documentoventaAbarrotes
            Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
            Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios
            Dim documentoventaSA As New VehiculoAsiento_PreciosSA


            Dim r As Record = GridEncomiendas.Table.CurrentRecord
            If r IsNot Nothing Then
                If MessageBox.Show("Desea anular el documento seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                    Dim objeto As New documentoventaTransporte
                    objeto.idDocumento = CInt(r.GetValue("id"))
                    objeto.tipoDocumento = r.GetValue("tipoDoc")
                    objeto.serie = r.GetValue("serie")
                    objeto.numero = CInt(r.GetValue("numero"))
                    objeto.fechadoc = CDate(r.GetValue("fecharecepcion"))
                    ' objeto.EnvioSunat = r.GetValue("enviosunat")


                    If r.GetValue("enviosunat") IsNot Nothing Then
                        Dim envio = r.GetValue("enviosunat")
                        If envio.ToString.Trim.Length > 0 Then
                            objeto.EnvioSunat = envio

                        End If
                    End If


                    If r.GetValue("tipoDoc") = "03" Then

                        Try

                            'EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                            AnularEncomienda(Integer.Parse(r.GetValue("id")), r, objeto)


                            'If Gempresas.ubigeo > 0 Then
                            '    If My.Computer.Network.IsAvailable = True Then
                            '        If My.Computer.Network.Ping("148.102.27.231") Then
                            '            EnviarBoletaEliminada(objeto)

                            '        End If
                            '    End If
                            'End If
                            ToolStripButton4.Enabled = True

                            If (r.GetValue("tipoVenta") = "VPSJ") Then
                                distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                                distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                                distribucionInfraestructuraBE.precio_id = r.GetValue("AsientoID")
                                distribucionInfraestructuraBE.estado = "A"

                                documentoventaSA.updateAsientoTransportexID(distribucionInfraestructuraBE)
                            End If


                        Catch ex As Exception
                            ToolStripButton4.Enabled = True
                        End Try



                    ElseIf r.GetValue("tipoDoc") = "01" Then
                        Try

                            'EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                            AnularEncomienda(Integer.Parse(r.GetValue("id")), r, objeto)


                            'If Gempresas.ubigeo > 0 Then
                            '    If My.Computer.Network.IsAvailable = True Then
                            '        If My.Computer.Network.Ping("148.102.27.231") Then
                            '            EnviarComunicacionBaja(objeto)

                            '        End If
                            '    End If
                            'End If

                            If (r.GetValue("tipoVenta") = "VPSJ") Then
                                distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                                distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                                distribucionInfraestructuraBE.precio_id = r.GetValue("AsientoID")
                                distribucionInfraestructuraBE.estado = "A"

                                documentoventaSA.updateAsientoTransportexID(distribucionInfraestructuraBE)
                            End If

                            ToolStripButton4.Enabled = True
                        Catch ex As Exception
                            ToolStripButton4.Enabled = True
                        End Try

                    End If

                    '//////////////////////

                    'AnularEncomienda(Integer.Parse(r.GetValue("id")), r)


                    'If r.GetValue("tipoDoc") = "03" Then


                    '    Dim clas = (r.GetValue("enviosunat"))

                    '    If clas.ToString.Trim.Length > 0 Then
                    '        If r.GetValue("enviosunat") = "SI" Then

                    '            AnularEncomienda(Integer.Parse(r.GetValue("id")), r)
                    '        Else
                    '            MessageBox.Show("verifique el ticket de envio de la boleta para poder eliminar!", "Atención")
                    '        End If
                    '    Else
                    '        MessageBox.Show("La Boleta debe ser enviado a sunat para poder eliminar!", "Atención")
                    '    End If
                    'Else
                    'AnularEncomienda(Integer.Parse(r.GetValue("id")), r)
                    'End If
                    GetEncomiendasDelDia(Date.Now)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnularEncomienda(idDocumento As Integer, r As Record, objeto As documentoventaTransporte)
        Try
            ventaSA.EliminarVentaEncomienda(New Business.Entity.documento With {.idDocumento = idDocumento,
                                            .idPse = Gempresas.ubigeo})
            MessageBox.Show("Documento anulado con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            r.SetValue("estadopago", "-")
            r.SetValue("estado", "Anulado")
            GridEncomiendas.Refresh()


            If Gempresas.ubigeo > 0 Then
                If My.Computer.Network.IsAvailable = True Then
                    If My.Computer.Network.Ping("138.128.171.106") Then

                        'If objeto.tipoDocumento = "01" Then
                        '    EnviarComunicacionBaja(objeto)
                        'ElseIf objeto.tipoDocumento = "03" Then
                        '    EnviarBoletaEliminada(objeto)

                        'End If


                        If objeto.EnvioSunat IsNot Nothing Then
                            Dim envio = objeto.EnvioSunat
                            If envio.ToString.Trim.Length > 0 Then

                                If envio = "SI" Then
                                    EnviarAnulacionDocumento(objeto)
                                End If
                            End If
                        End If




                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim entidadSA As New entidadSA
        Dim documentoSA As New DocumentoventaTransporteSA
        Try
            Dim r As Record = GridEncomiendas.Table.CurrentRecord
            If r IsNot Nothing Then
                'ImprimirTicketA4(ComboPrint.Text, Integer.Parse(r.GetValue("id")))
                '//CORRECION

                Dim comprobante = documentoSA.DocumentoTransporteSelIDVer2(New documentoventaTransporte With {.idDocumento = Integer.Parse(r.GetValue("id"))})

                Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.razonSocial).FirstOrDefault


                If (r.GetValue("tipoVenta") = "BOLETAJE") Then
                    ImprimirTicketTransportes("TICKET", Integer.Parse(r.GetValue("id")), "", entidad, comprobante)

                ElseIf (r.GetValue("tipoVenta") = "ENCOMIENDA") Then
                    ImprimirTicketEncomienda("TICKET", Integer.Parse(r.GetValue("id")), comprobante, entidad)
                End If


            Else

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Sub ImprimirTicketTransportes(imprimir As String, intIdDocumento As Integer, formato As String, LLAMARENTIDAD As entidad, LLAMARTRANSPORTE As documentoventaTransporte)

        Dim a As TicketTransporteVer2 = New TicketTransporteVer2
        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim precioUnit As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Dim nombreCliente As String
        Dim rucCliente As String = String.Empty


        If (objDatosGenrales.logo.Length > 0) Then
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        If (objDatosGenrales.nombreImpresion = "C") Then
            a.tipoImagen = False
        ElseIf (objDatosGenrales.nombreImpresion = "R") Then
            a.tipoImagen = True
        End If

        'Direccion de La empresa general
        If (objDatosGenrales.tipoImpresion = "S") Then
            a.tipoEncabezado = True
            a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
            a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        ElseIf (objDatosGenrales.tipoImpresion = "N") Then
            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        End If

        If (objDatosGenrales.publicidad.Length > 0) Then
            a.tipoPublicidad = True
            a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        Else
            a.tipoPublicidad = False
        End If

        'ruc
        a.TextoIzquierda("R.U.C.: " & objDatosGenrales.idEmpresa)
        'direccion de la empresa
        a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
        a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        If (objDatosGenrales.telefono3.Length > 0) Then
            a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
        ElseIf (objDatosGenrales.telefono2.Length > 0) Then
            a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        Else
            a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
        End If

        Dim DIRECCIONclIENTE As String = String.Empty
        Dim NBoletaElectronica As String = String.Empty

        Dim entidadTrans = LLAMARENTIDAD
        Dim DOCUMENTOTransBE = LLAMARTRANSPORTE


        NBoletaElectronica = entidadTrans.nombreCompleto
        DIRECCIONclIENTE = entidadTrans.DireccionSeleccionada ' entidad.direccion
        nombreCliente = (NBoletaElectronica)

        '//ruc razon social
        If (Not IsNothing(entidadTrans.nrodoc)) Then
            rucCliente = entidadTrans.nrodoc
        End If


        'Codigo qr

        If (Not IsNothing(HASH)) Then
            If HASH.Trim.Length > 0 Then
                QR = (Gempresas.IdEmpresaRuc & "|" & DOCUMENTOTransBE.tipoDocumento.ToString & "|" & DOCUMENTOTransBE.serie & "|" & DOCUMENTOTransBE.numero & "|" & Format(DOCUMENTOTransBE.igv1, 2) &
                      "|" & DOCUMENTOTransBE.total & "|" & CDate(DOCUMENTOTransBE.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadTrans.tipoDoc & "|" & entidadTrans.nrodoc &
                      "|" & HASH & "|")

                QrCodeImgControl1.Text = QR
            Else
                QR = (Gempresas.IdEmpresaRuc & "|" & DOCUMENTOTransBE.tipoDocumento.ToString & "|" & DOCUMENTOTransBE.serie & "|" & DOCUMENTOTransBE.numero & "|" & Format(DOCUMENTOTransBE.igv1, 2) &
                      "|" & DOCUMENTOTransBE.total & "|" & CDate(DOCUMENTOTransBE.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadTrans.tipoDoc & "|" & entidadTrans.nrodoc)

                QrCodeImgControl1.Text = QR
            End If
        End If

        QR = (Gempresas.IdEmpresaRuc & "|" & DOCUMENTOTransBE.tipoDocumento.ToString & "|" & DOCUMENTOTransBE.serie & "|" & DOCUMENTOTransBE.numero & "|" & Format(DOCUMENTOTransBE.igv1, 2) &
                      "|" & DOCUMENTOTransBE.total & "|" & CDate(DOCUMENTOTransBE.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadTrans.tipoDoc & "|" & entidadTrans.nrodoc)

        QrCodeImgControl1.Text = QR


        Select Case DOCUMENTOTransBE.tipoDocumento
                            'BOLETA DE VENTA ELECTRONICA   N° " & DOCUMENTOTransBE.serie & "-" & DOCUMENTOTransBE.numero
            Case "03"

                If (DOCUMENTOTransBE.CustomPerson.idPersona = LLAMARENTIDAD.nrodoc) Then
                    'a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                    'CDate(DOCUMENTOTransBE.fechadoc.Value).Date,
                    'GEstableciento.NombreEstablecimiento,
                    'CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                    'GEstableciento.NombreEstablecimiento,
                    'DOCUMENTOTransBE.UbigeoCiudadOrigen & "-" & DOCUMENTOTransBE.UbigeoCiudadDestino,
                    'DOCUMENTOTransBE.UbigeoCiudadOrigen,
                    'DOCUMENTOTransBE.comprador,
                    '"--",
                    '"--",
                    'rucCliente,
                    '"9",
                    '"992",
                    'LLAMARENTIDAD.nombreCompleto,
                    'LLAMARENTIDAD.nrodoc,
                    '"13",
                    '"14",
                    '"15")

                    a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                       DOCUMENTOTransBE.ciudadOrigen,
                      "GENERAL",
                      CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                      DOCUMENTOTransBE.numeroAsiento,
                      "1",
                      "2",
                       DOCUMENTOTransBE.comprador,
                      "CAR.CHUNAN NRO. 15 CPME. PICHUS (S70050250 A 200 METROS I.E. N30478) JUNIN - JAUJA - SAN PEDRO DE CHUNAN",
                      DOCUMENTOTransBE.ciudadDestino,
                      rucCliente,
                      "NAC",
                      "DEVOLUCION DEL DINERO",
                      "3",
                      "4",
                      "5",
                      "6",
                      "7")


                    a.DIRECIONEMBAR = "DNI"

                Else

                    'a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                    '    CDate(DOCUMENTOTransBE.fechadoc.Value).Date,
                    '    GEstableciento.NombreEstablecimiento,
                    '    CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                    '    "SER",
                    '    DOCUMENTOTransBE.UbigeoCiudadOrigen & "-" & DOCUMENTOTransBE.UbigeoCiudadDestino,
                    '    DOCUMENTOTransBE.UbigeoCiudadOrigen,
                    '    DOCUMENTOTransBE.CustomPerson.nombreCompleto,
                    '    LLAMARENTIDAD.nrodoc,
                    '    LLAMARENTIDAD.nombreCompleto,
                    '    DOCUMENTOTransBE.CustomPerson.idPersona,
                    '      "9",
                    '      "992",
                    '      LLAMARENTIDAD.nombreCompleto,
                    '      LLAMARENTIDAD.nrodoc,
                    '      "13",
                    '      "14",
                    '      "15")



                    a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                       DOCUMENTOTransBE.ciudadOrigen,
                      "GENERAL",
                      CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                      DOCUMENTOTransBE.numeroAsiento,
                      "1",
                      "2",
                       DOCUMENTOTransBE.comprador,
                     LLAMARENTIDAD.nombreCompleto,
                      DOCUMENTOTransBE.ciudadDestino,
                      rucCliente,
                      "NAC",
                     LLAMARENTIDAD.nrodoc,
                      "3",
                      "4",
                      "5",
                      "6",
                      "7")

                    a.DIRECIONEMBAR = "RUC"
                End If

                a.tipoComprobante = 2
                a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                a.AnadirLineaComprobante(DOCUMENTOTransBE.serie & "-" & CStr(DOCUMENTOTransBE.numero).PadLeft(8, "0"c))


                a.AnadirLineasDatosFinales("FECHA DE EMISION: " & DateTime.Now)

                Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = DOCUMENTOTransBE.usuarioActualizacion).FirstOrDefault

                If Not IsNothing(consultaNombre) Then
                    a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                Else
                    a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                End If



            Case "01"



                a.AnadirLineaCaracteresDatosGEnerales(CDate(DOCUMENTOTransBE.fechaProgramada.Value).Date,
                        DOCUMENTOTransBE.ciudadOrigen,
                        "GENERAL",
                        CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                        DOCUMENTOTransBE.numeroAsiento,
                        DOCUMENTOTransBE.UbigeoCiudadOrigen & "-" & DOCUMENTOTransBE.UbigeoCiudadDestino,
                        DOCUMENTOTransBE.UbigeoCiudadOrigen,
                        DOCUMENTOTransBE.comprador,
                        LLAMARENTIDAD.nrodoc,
                        DOCUMENTOTransBE.ciudadDestino,
                        DOCUMENTOTransBE.CustomPerson.idPersona,
                        LLAMARENTIDAD.nombreCompleto,
                        "992",
                        LLAMARENTIDAD.nombreCompleto,
                        LLAMARENTIDAD.nrodoc,
                        "13",
                        "14",
                        "15")


                'a.AnadirLineaCaracteresDatosGEnerales(CStr(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " & documentoBE.documentoventaAbarrotes.serieVenta & "-" & documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, nombremesa, CStr(CDate(FechaPedido)))
                a.tipoComprobante = 2
                a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                a.AnadirLineaComprobante(DOCUMENTOTransBE.serie & "-" & CStr(DOCUMENTOTransBE.numero).PadLeft(8, "0"c))


                a.DIRECIONEMBAR = "RUC"

                a.AnadirLineasDatosFinales("FECHA DE EMISION: " & DateTime.Now)

                Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = DOCUMENTOTransBE.usuarioActualizacion).FirstOrDefault

                If Not IsNothing(consultaNombre) Then
                    a.AnadirLineasDatosFinales("VENDEDOR: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)
                Else
                    a.AnadirLineasDatosFinales("VENDEDOR: " & "VARIOS")
                End If


        End Select

        'a.AnadirLineaComprobanteExtra("ASIENTO N° " & DOCUMENTOTransBE.numeroAsiento)

        precioUnit = DOCUMENTOTransBE.total
        PrecioTotal = DOCUMENTOTransBE.total


        a.AnadirLineaElementosFactura(1, $"{"SERVICIO DE TRANSPORTE EN LA"}", "UND", String.Format("{0:0.00}", DOCUMENTOTransBE.total), String.Format("{0:0.00}", 0.0), String.Format("{0:0.00}", DOCUMENTOTransBE.total))

        If (DOCUMENTOTransBE.documentoventaTransporteDetalle.FirstOrDefault.destino = "1") Then
            a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.baseImponible1)
            a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.igv1)
            a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", DOCUMENTOTransBE.total))
            a.DESTINO = 1
        ElseIf (DOCUMENTOTransBE.documentoventaTransporteDetalle.FirstOrDefault.destino = "2") Then
            a.AnadirDatosGenerales("S/", DOCUMENTOTransBE.total)
            a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", DOCUMENTOTransBE.total))
            a.DESTINO = 2
        End If

        a.AnadirLineasDatosDescripcionTotal(DOCUMENTOTransBE.total)

        a.AnadirLineasDatosFinales("")
        a.AnadirLineasDatosFinales("TERMINOS Y CONDICIONES")
        a.AnadirLineasDatosFinales("1. Postergaciones con 4 horas de anticipo")
        a.AnadirLineasDatosFinales("2. Niños mayores de (5) años pagan pasaje y ocupan")
        a.AnadirLineasDatosFinales("su asiento. Asi mismo no se venderan a menores de")
        a.AnadirLineasDatosFinales("edad que no sean identificados con su DNI y")
        a.AnadirLineasDatosFinales("autorización notarial de sus padres cuando corresponda")
        a.AnadirLineasDatosFinales("3. La empresa no se responsabiliza por la perdida de")
        a.AnadirLineasDatosFinales("equipaje en el salon. Su cuidado es exclusiva")
        a.AnadirLineasDatosFinales("responsabilidad del pasajero, Asi mismo no se")
        a.AnadirLineasDatosFinales("responsabiliza por bultos no declarados")
        a.AnadirLineasDatosFinales("4. El pasajero debe presentarse 1 hora antes de la hora")
        a.AnadirLineasDatosFinales("de viaje")
        a.AnadirLineasDatosFinales("5. El equipaje consta de maletas, maletines, mochilas y")
        a.AnadirLineasDatosFinales("bolsa de mano de uso personal")
        a.AnadirLineasDatosFinales("Autorizado mendiante resolución de SUNAT")
        a.AnadirLineasDatosFinales("Representación impresa puede ser consultado")
        a.AnadirLineasDatosFinales("http://www.spk.com.pe/")


        a.headerImagenQR = QrCodeImgControl1.Image

        a.AnadirLineaDatos("COMP.: " & DOCUMENTOTransBE.serie & "-" & CStr(DOCUMENTOTransBE.numero).PadLeft(8, "0"c),
                           "FECHA: " & CDate(DOCUMENTOTransBE.fechadoc.Value).Date,
                          "HORA: " & CDate(DOCUMENTOTransBE.fechaProgramada.Value).ToLongTimeString,
                      "ORIGEN: " & DOCUMENTOTransBE.ciudadOrigen,
                        "DESTINO: " & DOCUMENTOTransBE.ciudadDestino,
                      "ASIENTO: " & DOCUMENTOTransBE.numeroAsiento,
                      "IMPORTE: " & DOCUMENTOTransBE.total,
                      "PISO: " & "1")

        'a.RUTA = DOCUMENTOTransBE.ciudadOrigen & " - " & DOCUMENTOTransBE.ciudadDestino

        'a.DIRECIONEMBAR = DOCUMENTOTransBE.ciudadDestino

        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket(imprimir, 1)

    End Sub


    Sub ImprimirTicketEncomienda(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidadBE As entidad)
        Dim a As TicketEncomienda = New TicketEncomienda
        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim precioUnit As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Dim entidadSA As New entidadSA
        '    Dim nombreCliente As String
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim tipoComprobante As String = String.Empty
        Dim nombreComprabante As String

        listaDatos = CustomListaDatosGenerales

        objDatosGenrales = listaDatos.Where(Function(o) o.NombreFormato = "TK").SingleOrDefault


        If (objDatosGenrales.logo.Length > 0) Then
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        End If

        If (objDatosGenrales.nombreImpresion = "C") Then
            a.tipoImagen = False
        ElseIf (objDatosGenrales.nombreImpresion = "R") Then
            a.tipoImagen = True
        End If

        'Direccion de La empresa general
        If (objDatosGenrales.tipoImpresion = "S") Then
            a.tipoEncabezado = True
            a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
            a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        ElseIf (objDatosGenrales.tipoImpresion = "N") Then
            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        End If

        If (objDatosGenrales.publicidad.Length > 0) Then
            a.tipoPublicidad = True
            a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        Else
            a.tipoPublicidad = False
        End If

        'ruc
        a.TextoIzquierda("R.U.C.: " & objDatosGenrales.idEmpresa)
        'direccion de la empresa
        a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
        a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        If (objDatosGenrales.telefono3.Length > 0) Then
            a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
        ElseIf (objDatosGenrales.telefono2.Length > 0) Then
            a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        Else
            a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
        End If


        Select Case comprobante.tipoDocumento
                'Case "12.1"
                '    'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                '    'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    nombreComprabante = "BOLETA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                '    tipoComprobante = "1"
                'Case "12.2"
                '    '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                '    nombreComprabante = "FACTURA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                '    tipoComprobante = "1"
            Case "03"
                a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                a.AnadirLineaComprobante(comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c))
                'a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA DE VENTA ELECTRONICA")
                nombreComprabante = "BOLETA DE VENTA ELECTRONICA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                tipoComprobante = "2"

            Case "01"
                a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                a.AnadirLineaComprobante(comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c))
                'a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                nombreComprabante = "FACTURA ELECTRONICA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                tipoComprobante = "2"

                'Case "9901"
                '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                '    nombreComprabante = "PROFORMA"
                '    tipoComprobante = "1"
                'Case Else

                '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                '    nombreComprabante = "NOTA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                '    tipoComprobante = "1"
        End Select



        If comprobante.Consignado IsNot Nothing Then

            Dim NBoletaElectronica As String = entidadBE.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)
            If entidadBE.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidadBE.nrodoc
            ElseIf entidadBE.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidadBE.nrodoc
            Else
                nBoletaNumero = entidadBE.nrodoc
            End If
            'Fecha de Factura
            'LUGAR DE DESTINO
            'Nombre del REMITENTE
            'Nombre del CONSIGNADO
            'DNI CONSIGNADO
            'DNI REMITENTE
            'tipo moneda de la empresa
            'LUGAR DE ORIGEN


            If (comprobante.comprador.Length = 0) Then
                a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                               comprobante.ciudadOrigen,
                                              "GENERAL",
                                              "7:00",
                                              "14",
                                              "1",
                                              "2",
                                              comprobante.Remitente,
                                                comprobante.CustomPerson.idPersona,
                                               comprobante.ciudadDestino,
                                                entidadBE.nrodoc,
                                              "NAC",
                                                 comprobante.CustomPerson.nombreCompleto,
                                              "3",
                                              "4",
                                              "5",
                                              "6",
                                              "7")
            Else
                a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                                   comprobante.ciudadOrigen,
                                                                  "GENERAL",
                                                                  "7:00",
                                                                  "14",
                                                                  "1",
                                                                  "2",
                                                                  comprobante.Remitente,
                                                                    comprobante.CustomPerson.idPersona,
                                                                   comprobante.ciudadDestino,
                                                                    entidadBE.nrodoc,
                                                                  "NAC",
                                                                     comprobante.comprador,
                                                                  "3",
                                                                  "4",
                                                                  "5",
                                                                  "6",
                                                                  "7")
            End If


            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                              "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadBE.tipoDoc & "|" & entidadBE.nrodoc &
                              "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                             "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date & "|" & entidadBE.tipoDoc & "|" & entidadBE.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            End If

            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                           "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadBE.tipoDoc & "|" & entidadBE.nrodoc)

        Else
            Dim NBoletaElectronica As String = comprobante.comprador
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa


            'a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
            '                                  nombreComprabante,
            '                                  comprobante.Remitente,
            '                                   comprobante.comprador,
            '                                   comprobante.ciudadOrigen,
            '                                  entidad.nrodoc,
            '                                  "PEN",
            '                                     comprobante.ciudadDestino)



            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                               comprobante.ciudadOrigen,
                                              "GENERAL",
                                              "7:00",
                                              "14",
                                              "1",
                                              "2",
                                              comprobante.Remitente,
                                                comprobante.CustomPerson.idPersona,
                                               comprobante.ciudadDestino,
                                                entidadBE.nrodoc,
                                              "NAC",
                                                 comprobante.comprador,
                                              "3",
                                              "4",
                                              "5",
                                              "6",
                                              "7")

            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                        "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            QrCodeImgControl1.Text = QR
        End If


        Dim NOMBRETIPO As String = String.Empty
        For Each i In comprobante.documentoventaTransporteDetalle.ToList

            'Select Case i.destino
            '    Case OperacionGravada.Grabado
            'gravMN += CDec(i.B)
            'gravME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Exonerado
            '        ExoMN += CDec(i.montokardex)
            '        ExoME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Inafecto
            '        InaMN += CDec(i.montokardex)
            '        InaME += CDec(i.montokardexUS)
            'End Select

            precioUnit = (Math.Round(CDbl(i.importe / i.cantidad), 2))
            PrecioTotal = i.importe

            Select Case i.tipo
                Case "CO"
                    a.AnadirLineaElementosFactura(i.cantidad, $"{"COSTAL"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)
                Case "P"
                    a.AnadirLineaElementosFactura(i.cantidad, $"{"PAQUETE"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)

                Case "S"
                    a.AnadirLineaElementosFactura(i.cantidad, $"{"SOBRE"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)

                Case "C"
                    a.AnadirLineaElementosFactura(i.cantidad, $"{"CAJA"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)

                Case "O"
                    a.AnadirLineaElementosFactura(i.cantidad, $"{"OTROS"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)
                Case Else
                    a.AnadirLineaElementosFactura(i.cantidad, $"{i.detalle}", "UND", "", precioUnit, PrecioTotal)
            End Select



            'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
            'a.AnadirNombreElemento(i.nombreItem)
        Next


        'a.AnadirDatosGenerales("S/", ExoMN)
        'a.AnadirDatosGenerales("S/", InaMN)
        a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
        a.AnadirDatosGenerales("S/", comprobante.igv1)
        a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", comprobante.total))

        a.headerImagenQR = QrCodeImgControl1.Image

        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = usuario.IDUsuario).FirstOrDefault

        'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.softpack.com.pe")


        a.AnadirLineasDatosFinales("FECHA DE EMISION: " & DateTime.Now)
        a.AnadirLineasDatosFinales("CAJERO: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)

        a.AnadirLineasDatosFinales("")
        a.AnadirLineasDatosFinales("CONDICIONES DE TRANSPORTE DE ENCOMIENDA")
        a.AnadirLineasDatosFinales("1. La empresa no se responsabiliza por deterioro o")
        a.AnadirLineasDatosFinales("mermas por mal enbalaje o desconposiciòn de viveres")
        a.AnadirLineasDatosFinales("frutas (D.S. 24-83-TC)")
        a.AnadirLineasDatosFinales("2. La empresa no se hace responsable de objetos y/o")
        a.AnadirLineasDatosFinales("articulos no declarados.")
        a.AnadirLineasDatosFinales("3. El pago por la perdida de un bulto se hara de")
        a.AnadirLineasDatosFinales("acuerdo a la ley de ferrocarriles Art. 8 10 veces el")
        a.AnadirLineasDatosFinales("valor del flete pagado.")
        a.AnadirLineasDatosFinales("Autorizado mendiante resolución de SUNAT")
        a.AnadirLineasDatosFinales("Representación impresa puede ser consultado")
        a.AnadirLineasDatosFinales("http://www.spk.com.pe/")

        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket(imprimir, "1")

    End Sub



    Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidad As entidad)
        Dim a As TickeTransporte = New TickeTransporte
        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim precioUnit As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Dim entidadSA As New entidadSA
        '    Dim nombreCliente As String
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim tipoComprobante As String = String.Empty
        Dim nombreComprabante As String

        a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        'ruc
        a.TextoIzquierda("R.U.C.: " & Gempresas.IdEmpresaRuc)
        'direccion de la empresa
        a.TextoIzquierda("Domicilio Fiscal: " & "Av. Ferrocarril N° 1587")
        a.TextoIzquierda("Sucursal: " & "Av. Marginal S/N")
        a.TextoIzquierda("Pichanaqui - Pichanaqui - Junin")
        'Telefono de la empresa
        'If (objDatosGenrales.telefono3.Length > 0) Then
        '    a.TextoIzquierda("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
        'ElseIf (objDatosGenrales.telefono2.Length > 0) Then
        '    a.TextoIzquierda("TELF: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
        'Else
        a.TextoIzquierda("TELF: " & "945307578 - 949499171")
        'End If


        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                tipoComprobante = "1"
            Case "03"

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                nombreComprabante = "FACTURA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                tipoComprobante = "2"

            Case "01"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                nombreComprabante = "FACTURA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                tipoComprobante = "2"

            Case "9901"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA"
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                tipoComprobante = "1"
        End Select



        If comprobante.Consignado IsNot Nothing Then

            Dim NBoletaElectronica As String = entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidad.nrodoc
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidad.nrodoc
            Else
                nBoletaNumero = entidad.nrodoc
            End If
            'Fecha de Factura
            'LUGAR DE DESTINO
            'Nombre del REMITENTE
            'Nombre del CONSIGNADO
            'DNI CONSIGNADO
            'DNI REMITENTE
            'tipo moneda de la empresa
            'LUGAR DE ORIGEN

            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                              nombreComprabante,
                                              comprobante.Remitente,
                                               comprobante.Consignado,
                                               comprobante.ciudadOrigen,
                                              entidad.nrodoc,
                                              "PEN",
                                                 comprobante.ciudadDestino)

            If (Not IsNothing(HASH)) Then
                If HASH.Trim.Length > 0 Then
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                          "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
                          "|" & HASH & "|" & CERTIFICADO)

                    QrCodeImgControl1.Text = QR
                Else
                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                         "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

                    QrCodeImgControl1.Text = QR
                End If
            End If

            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                       "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

        Else
            Dim NBoletaElectronica As String = comprobante.comprador
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            'a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
            '                                      comprobante.ciudadDestino,
            '                                      comprobante.Remitente,
            '                                      comprobante.comprador,
            '                                      entidad.direccion,
            '                                      entidad.nrodoc,
            '                                      "PEN",
            '                                      comprobante.ciudadOrigen)

            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                              nombreComprabante,
                                              comprobante.Remitente,
                                               comprobante.comprador,
                                               comprobante.ciudadOrigen,
                                              entidad.nrodoc,
                                              "PEN",
                                                 comprobante.ciudadDestino)

            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                    "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            QrCodeImgControl1.Text = QR
        End If



        For Each i In comprobante.documentoventaTransporteDetalle.ToList

            'Select Case i.destino
            '    Case OperacionGravada.Grabado
            'gravMN += CDec(i.B)
            'gravME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Exonerado
            '        ExoMN += CDec(i.montokardex)
            '        ExoME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Inafecto
            '        InaMN += CDec(i.montokardex)
            '        InaME += CDec(i.montokardexUS)
            'End Select

            precioUnit = (Math.Round(CDbl(i.importe / i.cantidad), 2))
            PrecioTotal = i.importe

            a.AnadirLineaElementosFactura(i.cantidad, i.detalle, i.unidadMedida, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal))

            'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
            'a.AnadirNombreElemento(i.nombreItem)
        Next


        a.AnadirDatosGenerales("S/", ExoMN)
        a.AnadirDatosGenerales("S/", InaMN)
        a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
        a.AnadirDatosGenerales("S/", comprobante.igv1)
        a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", comprobante.total))

        a.headerImagenQR = QrCodeImgControl1.Image

        Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = usuario.IDUsuario).FirstOrDefault

        a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.softpack.com.pe")

        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket(imprimir)

    End Sub


    Sub ImprimirTicketA4(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidad As entidad)
        'Dim a As TicketFormatoA5TransporteV2 = New TicketFormatoA5TransporteV2
        Dim a As TicketFormatoA5Transporte = New TicketFormatoA5Transporte
        ' Logo de la Empresa
        a.HeaderImage = Image.FromFile("C:\LogoEmpresa\SELVATOURS.jpg")
        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()
        Dim nombreComprabante As String
        ''  Dim r As Record = dgPedidos.Table.CurrentRecord
        'Dim entidadSA As New entidadSA
        'Dim documentoSA As New DocumentoventaTransporteSA
        ''Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim comprobante = documentoSA.DocumentoTransporteSelID(New documentoventaTransporte With {.idDocumento = intIdDocumento})
        ''  Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipoComprobante As String = String.Empty


        'Dim tipoComprobante As String

        'If comprobante.tipoDocumento = "01" And comprobante.tipoVenta = "VELC" Then
        '    XmlFactura(comprobante, comprobanteDetalle)
        'End If

        'Dim nombreCliente As String
        'Dim rucCliente As String
        'If (objDatosGenrales.logo.Length > 0) Then
        '    ' Logo de la Empresa
        '    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        'End If

        'Select Case objDatosGenrales.logo.Length
        '    Case > 0
        '        If (objDatosGenrales.posicionLogo = "CT") Then
        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "CR"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "CR"
        '            End If
        '        ElseIf (objDatosGenrales.posicionLogo = "IZ") Then

        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "IZ"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "IZ"
        '            End If
        '        End If
        '    Case <= 0
        '        a.tipoLogo = "SL"
        'End Select



        ''Direccion de La empresa general
        'If (objDatosGenrales.tipoImpresion = "S") Then
        '    a.tipoEncabezado = True
        '    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
        '    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        'ElseIf (objDatosGenrales.tipoImpresion = "N") Then
        a.tipoEncabezado = False
        a.AnadirLineaEmpresa(Gempresas.NomEmpresa)

        'End If

        'If (objDatosGenrales.publicidad.Length > 0) Then
        '    a.tipoPublicidad = True
        '    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        'Else
        '    a.tipoPublicidad = False
        'End If


        'Direccion de La empresa general




        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("De: " & objDatosGenrales.nombreCorto)
        'End If
        'direccion de la empresa
        a.TextoIzquierda("Domicilio Fiscal: " & "AV. FERROCARRIL N° 1587 HUANCAYO - HUANCAYO - JUNIN")
        'a.TextoIzquierda("Establ. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & "-")
        a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "03"

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "01"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "9901"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

        If comprobante.Consignado IsNot Nothing Then

            Dim NBoletaElectronica As String = entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidad.nrodoc
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidad.nrodoc
            Else
                nBoletaNumero = entidad.nrodoc
            End If
            'Fecha de Factura
            'LUGAR DE DESTINO
            'Nombre del REMITENTE
            'Nombre del CONSIGNADO
            'DNI CONSIGNADO
            'DNI REMITENTE
            'tipo moneda de la empresa
            'LUGAR DE ORIGEN


            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.Consignado,
                                                 entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            'If (Not IsNothing(HASH)) Then
            '    If HASH.Trim.Length > 0 Then
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '              "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
            '              "|" & HASH & "|" & CERTIFICADO)

            '        QrCodeImgControl1.Text = QR
            '    Else
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '             "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '        QrCodeImgControl1.Text = QR
            '    End If
            'Else
            '    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '         "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '    QrCodeImgControl1.Text = QR
            'End If


        Else
            Dim NBoletaElectronica As String = comprobante.comprador
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.comprador,
                                                  entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            ''Codigo qr
            'QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '          "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            'QrCodeImgControl1.Text = QR
        End If

        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL
        Dim baseImponible = 0
        Dim igv = 0
        Dim tipo As String = String.Empty
        For Each i In comprobante.documentoventaTransporteDetalle.ToList

            'baseImponible = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
            'igv = Math.Round(CDec(i.importe - baseImponible), 2)
            Select Case i.tipo
                Case "P"
                    tipo = "PAQUETE"
                Case "C"
                    tipo = "CAJA"
                Case "S"
                    tipo = "SOBRE"
                Case "CO"
                    tipo = "COSTAL"
                Case "O"
                    tipo = "OTRO"
            End Select

            a.AnadirLineaElementosFactura(
                tipo,
                i.detalle,
                i.cantidad,
                i.unidadMedida, 0,
                "0.00", 0, "0.00", 0, i.importe / i.cantidad, i.importe)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next

        '********************************** RESUMEN GENERAL DE LA FACTURA **************************
        'GRATUITAS
        a.AnadirDatosGenerales("S/", "0.00")
        'EXONERADAS
        a.AnadirDatosGenerales("S/", "0.00")
        'INAFECTA
        a.AnadirDatosGenerales("S/", "0.00")
        'GRAVADA
        a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
        'TOTAL DESCUENTO
        a.AnadirDatosGenerales("S/", "0.00")
        'I.S.C.
        a.AnadirDatosGenerales("S/", "0.00")
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.igv1)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", comprobante.total)
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        'a.AnadirLineaTotalFactura(comprobante.total)
        'IMPRIMIR LA FACTUIRA


        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
            Case "2"
                a.tipoComprobante = "2"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
        End Select

    End Sub
    Sub ImprimirTicketA4v2(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidad As entidad)

        'Dim a As TicketFormatoA5TransporteV2 = New TicketFormatoA5TransporteV2
        Dim a As TicketFormatoA5Transporte = New TicketFormatoA5Transporte
        ' Logo de la Empresa
        a.HeaderImage = Image.FromFile("C:\LogoEmpresa\SELVATOURS_NEGRO.jpg")
        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()
        Dim nombreComprabante As String
        ''  Dim r As Record = dgPedidos.Table.CurrentRecord
        'Dim entidadSA As New entidadSA
        'Dim documentoSA As New DocumentoventaTransporteSA
        ''Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim comprobante = documentoSA.DocumentoTransporteSelID(New documentoventaTransporte With {.idDocumento = intIdDocumento})
        ''  Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipoComprobante As String = String.Empty


        'Dim tipoComprobante As String

        'If comprobante.tipoDocumento = "01" And comprobante.tipoVenta = "VELC" Then
        '    XmlFactura(comprobante, comprobanteDetalle)
        'End If

        'Dim nombreCliente As String
        'Dim rucCliente As String
        'If (objDatosGenrales.logo.Length > 0) Then
        '    ' Logo de la Empresa
        '    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        'End If

        'Select Case objDatosGenrales.logo.Length
        '    Case > 0
        '        If (objDatosGenrales.posicionLogo = "CT") Then
        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "CR"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "CR"
        '            End If
        '        ElseIf (objDatosGenrales.posicionLogo = "IZ") Then

        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "IZ"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "IZ"
        '            End If
        '        End If
        '    Case <= 0
        '        a.tipoLogo = "SL"
        'End Select



        ''Direccion de La empresa general
        'If (objDatosGenrales.tipoImpresion = "S") Then
        '    a.tipoEncabezado = True
        '    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
        '    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        'ElseIf (objDatosGenrales.tipoImpresion = "N") Then
        a.tipoEncabezado = False
        a.AnadirLineaEmpresa(Gempresas.NomEmpresa)

        'End If

        'If (objDatosGenrales.publicidad.Length > 0) Then
        '    a.tipoPublicidad = True
        '    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        'Else
        '    a.tipoPublicidad = False
        'End If


        'Direccion de La empresa general




        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("De: " & objDatosGenrales.nombreCorto)
        'End If
        'direccion de la empresa
        a.TextoIzquierda("Domicilio Fiscal: " & "AV. FERROCARRIL N° 1587 HUANCAYO - HUANCAYO - JUNIN")
        'a.TextoIzquierda("Establ. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & "-")
        a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "03"

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "01"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "9901"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

        If comprobante.Consignado IsNot Nothing Then

            Dim NBoletaElectronica As String = entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidad.nrodoc
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidad.nrodoc
            Else
                nBoletaNumero = entidad.nrodoc
            End If
            'Fecha de Factura
            'LUGAR DE DESTINO
            'Nombre del REMITENTE
            'Nombre del CONSIGNADO
            'DNI CONSIGNADO
            'DNI REMITENTE
            'tipo moneda de la empresa
            'LUGAR DE ORIGEN


            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.Consignado,
                                                 entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            'If (Not IsNothing(HASH)) Then
            '    If HASH.Trim.Length > 0 Then
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '              "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
            '              "|" & HASH & "|" & CERTIFICADO)

            '        QrCodeImgControl1.Text = QR
            '    Else
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '             "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '        QrCodeImgControl1.Text = QR
            '    End If
            'Else
            '    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '         "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '    QrCodeImgControl1.Text = QR
            'End If


        Else
            Dim NBoletaElectronica As String = comprobante.comprador
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.comprador,
                                                  entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            ''Codigo qr
            'QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '          "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            'QrCodeImgControl1.Text = QR
        End If

        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL
        Dim baseImponible = 0
        Dim igv = 0
        Dim tipo As String = String.Empty
        For Each i In comprobante.documentoventaTransporteDetalle.ToList

            'baseImponible = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
            'igv = Math.Round(CDec(i.importe - baseImponible), 2)
            Select Case i.tipo
                Case "P"
                    tipo = "PAQUETE"
                Case "C"
                    tipo = "CAJA"
                Case "S"
                    tipo = "SOBRE"
                Case "CO"
                    tipo = "COSTAL"
                Case "O"
                    tipo = "OTRO"
            End Select

            a.AnadirLineaElementosFactura(
                tipo,
                i.detalle,
                i.cantidad,
                i.unidadMedida, 0,
                "0.00", 0, "0.00", 0, i.importe / i.cantidad, i.importe)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next

        '********************************** RESUMEN GENERAL DE LA FACTURA **************************
        'GRATUITAS
        a.AnadirDatosGenerales("S/", "0.00")
        'EXONERADAS
        a.AnadirDatosGenerales("S/", "0.00")
        'INAFECTA
        a.AnadirDatosGenerales("S/", "0.00")
        'GRAVADA
        a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
        'TOTAL DESCUENTO
        a.AnadirDatosGenerales("S/", "0.00")
        'I.S.C.
        a.AnadirDatosGenerales("S/", "0.00")
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.igv1)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", comprobante.total)
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        'a.AnadirLineaTotalFactura(comprobante.total)
        'IMPRIMIR LA FACTUIRA


        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
            Case "2"
                a.tipoComprobante = "2"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
        End Select

    End Sub
    Private Sub UCRecepcionEncomiendas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim instance As New Printing.PrinterSettings
        instance.DefaultPageSettings.Landscape = False
        Dim impresosaPredt As String = instance.PrinterName
        For Each item As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboPrint.Items.Add(item.ToString)
        Next
        If ComboPrint.Items.Count > 0 Then
            ComboPrint.SelectedText = impresosaPredt
        End If

        'BunifuThinButton21.Select()
        'BunifuThinButton21.Focus()
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Dim f As New FormFiltroAvanzadoPeriodo()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim periodoSel = CType(f.Tag, DateTime?)
            GetEncomiendasMes(periodoSel)
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)
        Dim r As Record = GridEncomiendas.Table.CurrentRecord
        Try
            If r IsNot Nothing Then
                Dim f As New FormCambiarDestino(Integer.Parse(r.GetValue("id")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, documentoventaTransporte)
                    r.SetValue("destino", c.ciudadDestino)
                End If
                GridEncomiendas.Refresh()
            Else
                MessageBox.Show("Debe seleccionar un documento válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub UCRecepcionEncomiendas_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.GridEncomiendas, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Default)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Desea abrir el archivo ahora?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        'Dim f As New FormResumenVentas(Me)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridEncomiendas.Table.CurrentRecord
        Try
            If r IsNot Nothing Then
                Dim f As New FormResumenClienteXDoc(Integer.Parse(r.GetValue("id")))
                'Dim f As New FormResumenClienteXDoc()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            Else
                MessageBox.Show("Debe seleccionar un documento válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub
#End Region


End Class
