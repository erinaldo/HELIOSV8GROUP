Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter

Public Class UCEnviosCpe

    Public Property Form As FormEnviosPendientesPse

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Public Sub New(FormEnviosPendientesPse As FormEnviosPendientesPse)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGridBlack(DgvDocumentos, True)
        GetTableGrid()

        Form = FormEnviosPendientesPse

        txtPeriodo.Value = DateTime.Now
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


#Region "Metodos"

    Public Sub UpdateEnvioSunatEstadoGui(idDoc As Integer, estado As String)
        Try

            Dim docSA As New DocumentoGuiaSA
            docSA.UpdateGuiaXEstado(idDoc, estado)
        Catch ex As Exception
        End Try



    End Sub

    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateFacturasXEstado(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    Public Sub UpdateEnvioSunat(idDoc As Integer)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateEnvioSunat(idDoc)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    Public Sub EnviarNotaCreditoElectronico(idDocumento As Integer)
        Dim articuloSA As New detalleitemsSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Try

            Dim comprobante = documentoSA.GetUbicar_NotaXID(idDocumento)
            Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0
            Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)
            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = Gempresas.ubigeo
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = comprobante.serieVenta & "-" & numerovent
            Factura.FechaEmision = comprobante.fechaDoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            'Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")

            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"
                Factura.TotalIgv = comprobante.igv01
                Factura.TotalVenta = comprobante.ImporteNacional
                Factura.Gravadas = comprobante.bi01
                Factura.Exoneradas = comprobante.bi02
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
                Factura.TotalIgv = comprobante.igv01us
                Factura.TotalVenta = comprobante.ImporteExtranjero
                Factura.Gravadas = comprobante.bi01us
                Factura.Exoneradas = comprobante.bi02us
            End If

            Factura.TipoDocumento = tipoDoc
            Factura.TipoOperacion = "0101"
            Factura.TotalIcbper = comprobante.icbper
            'Cargando el Detalle de la Factura

            'For Each i In comprobanteDetalle

            '    Dim prod = articuloSA.GetUbicaProductoID(i.idItem)
            '    Dim cantidadEquivalencia = i.monto1 '* prod.detalleitem_equivalencias.FirstOrDefault.fraccionUnidad.GetValueOrDefault

            '    conteo += 1

            '    DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
            '    DetalleFactura.Id = conteo

            '    If comprobante.notaCredito = "05" Then
            '        DetalleFactura.Cantidad = i.monto1
            '    Else
            '        DetalleFactura.Cantidad = cantidadEquivalencia ' 1 'i.monto1
            '    End If

            '    DetalleFactura.CodigoItem = i.idItem
            '    DetalleFactura.Descripcion = i.nombreItem
            '    DetalleFactura.UnidadMedida = i.unidad1

            '    If comprobante.moneda = "1" Then
            '        DetalleFactura.PrecioReferencial = i.precioUnitario
            '        DetalleFactura.Impuesto = i.montoIgv
            '        If i.destino = "1" Then
            '            DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
            '            DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
            '            DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
            '        ElseIf i.destino = "2" Then
            '            DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
            '            DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
            '            DetalleFactura.PrecioUnitario = i.precioUnitario
            '        End If
            '        DetalleFactura.TotalVenta = i.montokardex
            '    ElseIf comprobante.moneda = "2" Then
            '        DetalleFactura.PrecioReferencial = i.precioUnitarioUS
            '        DetalleFactura.Impuesto = i.montoIgvUS
            '        If i.destino = "1" Then
            '            DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
            '            DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
            '            DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
            '        ElseIf i.destino = "2" Then
            '            DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
            '            DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
            '            DetalleFactura.PrecioUnitario = i.precioUnitarioUS
            '        End If
            '        DetalleFactura.TotalVenta = i.montokardexUS
            '    End If
            '    'DetalleItems .Descuento = "falta"
            '    'DetalleItems .ImpuestoSelectivo = "falta"
            '    'DetalleItems.OtroImpuesto = "falta"
            '    'DetalleItems.PlacaVehiculo = "falta"

            '    If i.tasaIcbper > 0 Then
            '        DetalleFactura.ImpuestoIcbper = i.tasaIcbper
            '        DetalleFactura.TotalIcbper = i.montoIcbper
            '        DetalleFactura.CantidadBolsa = cantidadEquivalencia
            '    Else
            '        DetalleFactura.ImpuestoIcbper = 0
            '        DetalleFactura.TotalIcbper = 0
            '        DetalleFactura.CantidadBolsa = 0
            '    End If

            '    Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            'Next

            For Each i In comprobanteDetalle

                'Dim cantidadEquivalencia As Decimal = 0

                'If comprobante.notaCredito = "05" Then

                '    cantidadEquivalencia = 1
                'Else

                '    If i.tipoExistencia = "GS" Then

                '        cantidadEquivalencia = i.monto1
                '    Else

                '        Dim prod = articuloSA.GetUbicaProductoID(i.idItem)

                '        Dim equivalencia = (From z In prod.detalleitem_equivalencias
                '                            Where z.equivalencia_id = i.equivalencia_id).FirstOrDefault


                '        cantidadEquivalencia = i.monto1 '* equivalencia.contenido_neto.GetValueOrDefault
                '    End If


                'End If




                Dim Preciounit = i.importeMN / i.monto1
                Dim PreciounitSinIva = i.montokardex / i.monto1

                conteo += 1

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo


                If comprobante.notaCredito = "05" Then
                    DetalleFactura.Cantidad = 1 'i.monto1
                Else
                    DetalleFactura.Cantidad = i.monto1
                End If


                DetalleFactura.CodigoItem = i.idItem
                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1

                If comprobante.moneda = "1" Then
                    DetalleFactura.PrecioReferencial = Preciounit  'i.precioUnitario
                    DetalleFactura.Impuesto = i.montoIgv
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = PreciounitSinIva 'CalculoBaseImponible(Preciounit, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = Preciounit
                    End If
                    DetalleFactura.TotalVenta = i.montokardex
                ElseIf comprobante.moneda = "2" Then
                    DetalleFactura.PrecioReferencial = i.precioUnitarioUS
                    DetalleFactura.Impuesto = i.montoIgvUS
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = i.precioUnitarioUS
                    End If
                    DetalleFactura.TotalVenta = i.montokardexUS
                End If

                If i.tasaIcbper > 0 Then
                    DetalleFactura.ImpuestoIcbper = i.tasaIcbper
                    DetalleFactura.TotalIcbper = i.montoIcbper
                    DetalleFactura.CantidadBolsa = i.monto1 'cantidadEquivalencia
                Else
                    DetalleFactura.ImpuestoIcbper = 0
                    DetalleFactura.TotalIcbper = 0
                    DetalleFactura.CantidadBolsa = 0
                End If
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next

            'Datos Adicionales 
            Dim DocRel = New Fact.Sunat.Business.Entity.DocumentoRelacionado()
            DocRel.TipoDocumento = comprobante.TipoDocNota
            DocRel.NroDocumento = comprobante.serie & "-" & numeroafect
            Factura.DocumentoRelacionado.Add(DocRel)

            Dim DocDiscrep = New Fact.Sunat.Business.Entity.Discrepancia()
            DocDiscrep.NroReferencia = comprobante.serie & "-" & numeroafect 'comprobante.numeroDoc
            DocDiscrep.Tipo = comprobante.notaCredito

            If comprobante.notaCredito = "01" Then
                DocDiscrep.Descripcion = "ANULACION DE LA OPERACION"  '"POR ANULACION"
            ElseIf comprobante.notaCredito = "05" Then
                DocDiscrep.Descripcion = "DESCUENTO POR ITEM"
            ElseIf comprobante.notaCredito = "07" Then
                DocDiscrep.Descripcion = "DEVOLUCION POR ITEM"
            End If

            'DocDiscrep.Descripcion = comprobante.glosa '"POR ANULACION"
            Factura.Discrepancia.Add(DocDiscrep)



            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunat(comprobante.idDocumento)
                'MessageBox.Show("La Nota de Credito se Envio Correctamente al PSE")

                'ButtonAdv2.Enabled = True

            End If

        Catch ex As Exception

            MessageBox.Show("No se Pudo Enviar")

            btnEnviar.Enabled = True

        End Try

        'Try

        '    Dim Empresa As New Fact.Sunat.Business.Entity.empresa

        '    Empresa.ruc = "23423423"


        '    Dim CodigoCliente = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.empresaSA.empresaSelxID(Empresa)

        '    If CodigoCliente Is Nothing Then
        '        MessageBox.Show("El cliente no existe")
        '    End If




        '    Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

        '    Factura.Action = 0
        '    Factura.NroDocumentoRec = "20100039207"
        '    Factura.TipoDocumentoRec = "6"
        '    Factura.NombreLegalRec = "RANSA COMERCIAL S.A."
        '    Factura.Contribuyente_id = "20601672309"
        '    Factura.EnvioSunat = "NO"
        '    Factura.idEmpresa = 2

        '    Factura.IdDocumento = "FF11-00009910"
        '    Factura.FechaEmision = DateTime.Now
        '    Factura.FechaEnvio = DateTime.Now
        '    Factura.FechaRecepcion = DateTime.Now
        '    Factura.FechaVencimiento = DateTime.Now
        '    Factura.HoraEmision = DateTime.Now.ToString("HH:mm:ss")
        '    Factura.Moneda = "PEN"
        '    Factura.TipoDocumento = "01"
        '    Factura.TotalIgv = 18
        '    Factura.TotalVenta = 118
        '    Factura.Gravadas = 100
        '    Factura.Exoneradas = 0

        '    Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

        '    If codigo.idDocumentoElectronico > 0 Then
        '        MessageBox.Show("Se envio Correctamente al PSE")

        '    End If
        'Catch ex As Exception

        '    MessageBox.Show("No se Pudo Enviar")

        'End Try
    End Sub


    Public Sub EnviarGuiaElectronica(idDocumento As Integer, estado As String)

        Dim docguiasa As New DocumentoGuiaSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleGuia As Fact.Sunat.Business.Entity.DocumentoGuiaRemisionDetalle
        Try
            Dim obj As New documento
            obj.idDocumento = idDocumento
            Dim be = docguiasa.GetVentaIDGuia(obj)
            Dim comprobante = be

            Dim receptor = comprobante.CustomEntidad
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroDoc)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDoc)
            Dim conteo As Integer = 0
            '//Enviando el documento
            Dim Guia As New Fact.Sunat.Business.Entity.DocumentoGuiaRemision
            'Datos del Cliente 
            Guia.Action = 0
            Guia.idEmpresa = Gempresas.ubigeo 'lblIdPse.Text
            Guia.Contribuyente_id = Gempresas.IdEmpresaRuc
            Guia.EnvioSunat = "NO"
            'Remitente de la guia
            Guia.NroDocumentoRem = receptor.nrodoc
            Guia.TipoDocumentoRem = receptor.tipoDoc
            Guia.NombreLegalRem = receptor.nombreCompleto
            'Destinatario de la guia
            Guia.NroDocumentoDest = comprobante.DocDestinatario
            Guia.TipoDocumentoDest = comprobante.TipoDocDestinatario
            Guia.NombreLegalDest = comprobante.nombreDestinatario
            'Datos Generales De La guia
            Guia.IdDocumento = comprobante.serie & "-" & numerovent
            Guia.FechaEmision = comprobante.fechaDoc
            Guia.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Guia.Moneda = "1"
            Guia.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            Guia.TipoDocumento = tipoDoc
            Guia.TipoOperacion = "0101"
            Guia.glosa = comprobante.glosa

            Guia.ShipmentId = 1 '"001"
            Guia.CodigoMotivoTraslado = "01"
            Guia.DescripcionMotivo = comprobante.motivoTraslado
            Guia.Transbordo = 0
            Guia.PesoBrutoTotal = comprobante.PesoBruTotal
            Guia.NroPallets = 0
            Guia.ModalidadTraslado = "01"
            Guia.FechaInicioTraslado = DateTime.Now

            Guia.RucTransportista = comprobante.RucTrasporte
            Guia.RazonSocialTransportista = comprobante.razonSocialTrasportista
            Guia.NroPlacaVehiculo = comprobante.placaVehiculo
            Guia.NroDocumentoConductor = comprobante.NroDocumentoConductor


            Guia.UbigeoPartida = comprobante.puntoPartida
            Guia.DireccionCompletaPartida = comprobante.direccionPartida

            Guia.UbigeoLlegada = comprobante.puntoLlegada
            Guia.DireccionCompletaLlegada = comprobante.DireccionLlegada
            Guia.NumeroContenedor = String.Empty
            Guia.CodigoPuerto = String.Empty

            Guia.FechaRecepcion = DateTime.Now
            Guia.EnvioSunat = "NO"




            For Each i In comprobante.documentoguiaDetalle
                DetalleGuia = New Fact.Sunat.Business.Entity.DocumentoGuiaRemisionDetalle


                DetalleGuia.Id = conteo
                DetalleGuia.CodigoItem = i.idItem
                DetalleGuia.Descripcion = i.descripcionItem
                DetalleGuia.UnidadMedida = i.unidadMedida
                DetalleGuia.Cantidad = i.cantidad
                DetalleGuia.LineaReferencia = 1

                Guia.DocumentoGuiaRemisionDetalle.Add(DetalleGuia)
            Next
            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoGuiaRemisionSA.DocumentoGuiaElectronicoSaveValidado(Guia, Nothing)

            If codigo.idGuia > 0 Then
                UpdateEnvioSunatEstadoGui(comprobante.idDocumento, estado)
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")

        End Try

        'Dim documentoSA As New documentoVentaAbarrotesSA
        'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim entidadSA As New entidadSA
        'Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        'Try

        '    'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
        '    Dim comprobante = documentoSA.GetVentaID(New documento With {.idDocumento = idDocumento})
        '    'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
        '    Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
        '    Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
        '    Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
        '    Dim conteo As Integer = 0

        '    '//Enviando el documento

        '    Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

        '    'Datos del Cliente 
        '    Factura.Action = 0
        '    Factura.idEmpresa = Gempresas.ubigeo
        '    Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
        '    Factura.EnvioSunat = "NO"
        '    'Receptor de la Factura
        '    Factura.NroDocumentoRec = receptor.nrodoc
        '    Factura.TipoDocumentoRec = receptor.tipoDoc
        '    Factura.NombreLegalRec = receptor.nombreCompleto
        '    'Datos Generales De La Factura
        '    Factura.IdDocumento = comprobante.serieVenta & "-" & numerovent
        '    Factura.FechaEmision = comprobante.fechaDoc
        '    Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
        '    Factura.FechaVencimiento = DateTime.Now
        '    Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
        '    Factura.TipoOperacion = "0101"
        '    Factura.TipoDocumento = tipoDoc



        '    If comprobante.moneda = "1" Then
        '        Factura.Moneda = "PEN"
        '        Factura.TotalIgv = comprobante.igv01
        '        Factura.TotalVenta = comprobante.ImporteNacional
        '        Factura.Gravadas = comprobante.bi01
        '        Factura.Exoneradas = comprobante.bi02
        '    ElseIf comprobante.moneda = "2" Then
        '        Factura.Moneda = "USD"
        '        Factura.TotalIgv = comprobante.igv01us
        '        Factura.TotalVenta = comprobante.ImporteExtranjero
        '        Factura.Gravadas = comprobante.bi01us
        '        Factura.Exoneradas = comprobante.bi02us
        '    End If

        '    Factura.TotalIcbper = comprobante.icbper.GetValueOrDefault

        '    If comprobante.importeCostoMN > 0 Then

        '        Factura.DescuentoGlobal = comprobante.importeCostoMN

        '    End If

        '    'Cargando el Detalle de la Factura
        '    Dim precioSinIva As Decimal = 0
        '    Dim precioConIva As Decimal = 0
        '    Dim cantEquiva As Decimal = 0

        '    For Each i In comprobante.documentoventaAbarrotesDet
        '        DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
        '        Select Case i.tipoExistencia
        '            Case TipoExistencia.ServicioGasto
        '                cantEquiva = i.monto1
        '                DetalleFactura.CodigoItem = 1
        '            Case Else
        '                cantEquiva = i.monto1 * i.CustomEquivalencia.contenido_neto.GetValueOrDefault
        '                DetalleFactura.CodigoItem = i.idItem
        '        End Select

        '        ' cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
        '        precioSinIva = i.montokardex / cantEquiva
        '        precioConIva = i.importeMN / cantEquiva

        '        conteo += 1

        '        DetalleFactura.Id = conteo
        '        DetalleFactura.Cantidad = cantEquiva 'i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault 'i.monto1
        '        DetalleFactura.Descripcion = i.nombreItem
        '        DetalleFactura.UnidadMedida = i.unidad1

        '        If comprobante.moneda = "1" Then
        '            DetalleFactura.PrecioReferencial = precioConIva 'i.precioUnitario
        '            DetalleFactura.Impuesto = i.montoIgv
        '            DetalleFactura.TotalVenta = i.montokardex
        '            If i.destino = "1" Then
        '                DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
        '                DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
        '                DetalleFactura.PrecioUnitario = precioSinIva ' CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
        '            ElseIf i.destino = "2" Then
        '                DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
        '                DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
        '                DetalleFactura.PrecioUnitario = precioConIva ' i.precioUnitario
        '            End If
        '        ElseIf comprobante.moneda = "2" Then
        '            'DetalleFactura.PrecioReferencial = i.precioUnitarioUS
        '            'DetalleFactura.Impuesto = i.montoIgvUS
        '            'DetalleFactura.TotalVenta = i.montokardexUS
        '            'If i.destino = "1" Then
        '            '    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
        '            '    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
        '            '    DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
        '            'ElseIf i.destino = "2" Then
        '            '    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
        '            '    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
        '            '    DetalleFactura.PrecioUnitario = i.precioUnitarioUS
        '            'End If
        '        End If
        '        'DetalleItems .Descuento = "falta"
        '        'DetalleItems .ImpuestoSelectivo = "falta"
        '        'DetalleItems.OtroImpuesto = "falta"
        '        'DetalleItems.PlacaVehiculo = "falta"

        '        If i.tasaIcbper.GetValueOrDefault > 0 Then
        '            DetalleFactura.TotalIcbper = i.montoIcbper.GetValueOrDefault
        '            DetalleFactura.ImpuestoIcbper = i.tasaIcbper.GetValueOrDefault
        '            DetalleFactura.CantidadBolsa = cantEquiva
        '        Else
        '            DetalleFactura.TotalIcbper = 0
        '            DetalleFactura.ImpuestoIcbper = 0
        '            DetalleFactura.CantidadBolsa = 0
        '        End If

        '        Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
        '    Next

        '    'Enviando al PSE
        '    Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

        '    If codigo.idDocumentoElectronico > 0 Then

        '        UpdateEnvioSunatEstado(comprobante.idDocumento, estado)
        '        'MessageBox.Show("La Factura se Envio Correctamente al PSE")
        '        'ButtonAdv2.Enabled = True
        '    End If

        'Catch ex As Exception

        '    'MessageBox.Show("No se Pudo Enviar")
        '    'ButtonAdv2.Enabled = True

        'End Try


    End Sub

    Public Sub EnviarFacturaElectronica(idDocumento As Integer, estado As String)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Try

            'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
            Dim comprobante = documentoSA.GetVentaID(New documento With {.idDocumento = idDocumento})
            'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0

            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = Gempresas.ubigeo
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = comprobante.serieVenta & "-" & numerovent
            Factura.FechaEmision = comprobante.fechaDoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            Factura.TipoOperacion = "0101"
            Factura.TipoDocumento = tipoDoc



            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"
                Factura.TotalIgv = comprobante.igv01
                Factura.TotalVenta = comprobante.ImporteNacional
                Factura.Gravadas = comprobante.bi01
                Factura.Exoneradas = comprobante.bi02
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
                Factura.TotalIgv = comprobante.igv01us
                Factura.TotalVenta = comprobante.ImporteExtranjero
                Factura.Gravadas = comprobante.bi01us
                Factura.Exoneradas = comprobante.bi02us
            End If

            Factura.TotalIcbper = comprobante.icbper.GetValueOrDefault

            If comprobante.importeCostoMN > 0 Then

                Factura.DescuentoGlobal = comprobante.importeCostoMN

            End If

            'Cargando el Detalle de la Factura
            Dim precioSinIva As Decimal = 0
            Dim precioConIva As Decimal = 0
            Dim cantEquiva As Decimal = 0

            For Each i In comprobante.documentoventaAbarrotesDet
                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                Select Case i.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        cantEquiva = i.monto1
                        DetalleFactura.CodigoItem = 1
                    Case Else
                        cantEquiva = i.monto1 * i.CustomEquivalencia.contenido_neto.GetValueOrDefault
                        DetalleFactura.CodigoItem = i.idItem
                End Select

                ' cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                precioSinIva = i.montokardex / cantEquiva
                precioConIva = i.importeMN / cantEquiva

                conteo += 1

                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = cantEquiva 'i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault 'i.monto1
                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1

                If comprobante.moneda = "1" Then
                    DetalleFactura.PrecioReferencial = precioConIva 'i.precioUnitario
                    DetalleFactura.Impuesto = i.montoIgv
                    DetalleFactura.TotalVenta = i.montokardex
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioSinIva ' CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioConIva ' i.precioUnitario
                    End If
                ElseIf comprobante.moneda = "2" Then
                    'DetalleFactura.PrecioReferencial = i.precioUnitarioUS
                    'DetalleFactura.Impuesto = i.montoIgvUS
                    'DetalleFactura.TotalVenta = i.montokardexUS
                    'If i.destino = "1" Then
                    '    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    'ElseIf i.destino = "2" Then
                    '    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = i.precioUnitarioUS
                    'End If
                End If
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"

                If i.tasaIcbper.GetValueOrDefault > 0 Then
                    DetalleFactura.TotalIcbper = i.montoIcbper.GetValueOrDefault
                    DetalleFactura.ImpuestoIcbper = i.tasaIcbper.GetValueOrDefault
                    DetalleFactura.CantidadBolsa = cantEquiva
                Else
                    DetalleFactura.TotalIcbper = 0
                    DetalleFactura.ImpuestoIcbper = 0
                    DetalleFactura.CantidadBolsa = 0
                End If

                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next

            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunatEstado(comprobante.idDocumento, estado)
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
                'ButtonAdv2.Enabled = True
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")
            'ButtonAdv2.Enabled = True

        End Try


    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("FechaEmision")
        dt.Columns.Add("TipoDocumento")
        dt.Columns.Add("IdDocumento")
        dt.Columns.Add("Importe")
        dt.Columns.Add("EnvioSunat")
        DgvDocumentos.DataSource = dt
    End Sub


    Public Sub ListaCpePendientesDeEnvio(fecha As DateTime)
        Dim docSA As New documentoVentaAbarrotesSA
        DgvDocumentos.Table.Records.DeleteAll()
        'Dim consulta = docSA.ListaCpePendientesDeEnvio(fecha, Gempresas.IdEmpresaRuc)

        Dim consulta = docSA.ListaCpePendientes(fecha, Gempresas.IdEmpresaRuc)


        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            For Each i In consulta
                Me.DgvDocumentos.Table.AddNewRecord.SetCurrent()
                Me.DgvDocumentos.Table.AddNewRecord.BeginEdit()
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("id", i.idDocumento)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("FechaEmision", i.fechaDoc)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("TipoDocumento", i.tipoDocumento)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("IdDocumento", i.serieVenta & i.numeroVenta)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("Importe", i.ImporteNacional)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("EnvioSunat", i.EnvioSunat)
                Me.DgvDocumentos.Table.AddNewRecord.EndEdit()


            Next
        End If

    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        ListaCpePendientesDeEnvio(txtPeriodo.Value)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Me.Cursor = Cursors.WaitCursor
        btnEnviar.Enabled = False
        'Dim r As Record

        If Not Gempresas.ubigeo > 0 Then
            MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
            btnEnviar.Enabled = True
            Exit Sub
        End If

        '//nuevo
        Try

            For Each i In DgvDocumentos.Table.Records

                If i.GetValue("id") > 0 Then
                    Select Case i.GetValue("TipoDocumento")
                        Case "01", "03"
                            Dim clas = (i.GetValue("EnvioSunat"))
                            If clas.ToString.Trim.Length > 0 Then
                                If i.GetValue("EnvioSunat") = "NE" Then
                                    EnviarFacturaElectronica(CInt(i.GetValue("id")), "PE")
                                End If
                            Else
                                EnviarFacturaElectronica(CInt(i.GetValue("id")), "SI")
                            End If
                        Case "07"
                            EnviarNotaCreditoElectronico(CInt(i.GetValue("id")))
                        Case "08"

                        Case "09"
                            Dim clas = (i.GetValue("EnvioSunat"))
                            If clas.ToString.Trim.Length > 0 Then
                                If i.GetValue("EnvioSunat") = "NE" Then
                                    EnviarGuiaElectronica(CInt(i.GetValue("id")), "PE")
                                End If
                            Else
                                EnviarGuiaElectronica(CInt(i.GetValue("id")), "SI")
                            End If
                    End Select

                Else
                    MessageBox.Show("Seleccione un Documento para Enviar")
                    btnEnviar.Enabled = True
                    Me.Cursor = Cursors.Default
                End If



            Next

            ListaCpePendientesDeEnvio(txtPeriodo.Value)
            btnEnviar.Enabled = True

            Form.AlertaEnvioPSE()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            btnEnviar.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
        'enddd
    End Sub





#End Region

End Class
