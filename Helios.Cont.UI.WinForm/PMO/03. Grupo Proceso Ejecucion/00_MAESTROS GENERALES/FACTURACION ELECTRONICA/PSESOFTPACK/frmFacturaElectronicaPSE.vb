Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos


Public Class frmFacturaElectronicaPSE

#Region "CONSTRUCTOR"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(GridGroupingControl1, False, False)
        ' Add any initialization after the InitializeComponent() call.
        txtPeriodo.Value = DateTime.Now
    End Sub
#End Region

#Region "METODOS"

    'Public Sub usuariopse(idempresa As String)

    '    Try

    '        Dim Empresa As New Fact.Sunat.Business.Entity.empresa

    '        Empresa.ruc = idempresa


    '        Dim CodigoCliente = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.empresaSA.empresaSelxID(Empresa)

    '        If CodigoCliente Is Nothing Then
    '            'MessageBox.Show("Contactese con el PSE")
    '        Else
    '            lblIdPse.Text = CodigoCliente.idEmpresa
    '        End If

    '    Catch ex As Exception

    '        'MessageBox.Show("ERROR")

    '    End Try

    'End Sub

    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateFacturasXEstado(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub


    Public Sub BuscarNotasBoletasPeriodo(fecha As DateTime, tipoDoc As String)
        Dim docSA As New documentoVentaAbarrotesSA
        GridGroupingControl1.Table.Records.DeleteAll()
        Dim consulta = docSA.BuscarNotasBoletasPeriodo(fecha, tipoDoc, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipodoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("enviosunat", i.EnvioSunat)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("fecha", i.fechaDoc)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()


            Next
        End If

    End Sub

    Public Sub BuscarDocsFechaPeriodo(fecha As DateTime, tipoDoc As String)
        Dim docSA As New documentoVentaAbarrotesSA
        GridGroupingControl1.Table.Records.DeleteAll()
        Dim consulta = docSA.BuscarFacturanoEnviadasPeriodo(fecha, tipoDoc, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipodoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("enviosunat", i.EnvioSunat)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("fecha", i.fechaDoc)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()


            Next
        End If

    End Sub


    Public Sub BuscarDocsFecha(fecha As DateTime, tipoDoc As String)

        Dim docSA As New documentoVentaAbarrotesSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.BuscarFacturanoEnviadas(fecha, tipoDoc, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipodoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("enviosunat", i.EnvioSunat)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("fecha", i.fechaDoc)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If

    End Sub

    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("importe")
        dt.Columns.Add("enviosunat")
        dt.Columns.Add("fecha")
        GridGroupingControl1.DataSource = dt
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




    Public Sub EnviarNotaCreditoElectronico(idDocumento As Integer, Tipo As String, estado As String)
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

            For Each i In comprobanteDetalle

                Dim prod = articuloSA.GetUbicaProductoID(i.idItem)
                Dim cantidadEquivalencia = i.monto1 '* prod.detalleitem_equivalencias.FirstOrDefault.fraccionUnidad.GetValueOrDefault

                conteo += 1

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo

                If comprobante.notaCredito = "05" Then
                    DetalleFactura.Cantidad = i.monto1
                Else
                    DetalleFactura.Cantidad = cantidadEquivalencia ' 1 'i.monto1
                End If

                DetalleFactura.CodigoItem = i.idItem
                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1

                If comprobante.moneda = "1" Then
                    DetalleFactura.PrecioReferencial = i.precioUnitario
                    DetalleFactura.Impuesto = i.montoIgv
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = i.precioUnitario
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
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"

                If i.tasaIcbper > 0 Then
                    DetalleFactura.ImpuestoIcbper = i.tasaIcbper
                    DetalleFactura.TotalIcbper = i.montoIcbper
                    DetalleFactura.CantidadBolsa = cantidadEquivalencia
                Else
                    DetalleFactura.ImpuestoIcbper = 0
                    DetalleFactura.TotalIcbper = 0
                    DetalleFactura.CantidadBolsa = 0
                End If

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

            ButtonAdv2.Enabled = True

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




    'Public Sub ReEnviarNotaCreditoElectronico(idDocumento As Integer, IdPse As String, estado As String)
    '    Try

    '        Dim documentoVenta As New documentoVentaAbarrotesSA
    '        documentoVenta.ReEnviarNotaCreditoElectronico(idDocumento, IdPse, estado)

    '    Catch ex As Exception
    '        MessageBox.Show("No se Pudo enviar el comprobante")
    '        ButtonAdv2.Enabled = True
    '    End Try


    'End Sub


    'Public Sub ReEnviarFacturaElectronica(idDocumento As Integer, IdPse As String, estado As String)
    '    Try

    '        Dim documentoVenta As New documentoVentaAbarrotesSA
    '        documentoVenta.ReEnviarFacturaElectronica(idDocumento, IdPse, estado)

    '    Catch ex As Exception
    '        MessageBox.Show("No se Pudo enviar el comprobante")
    '        ButtonAdv2.Enabled = True
    '    End Try


    'End Sub



    Public Sub EnviarFacturaElectronica(idDocumento As Integer, Tipo As String, estado As String)

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
                        cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
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


#End Region


    Private Sub frmFacturaElectronicaPSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'usuariopse(Gempresas.IdEmpresaRuc)
    End Sub







    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Try
            Select Case ComboBox1.Text
                Case "FACTURA"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
                Case "BOLETAS"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "03")
                Case "NOTAS DE CREDITO"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
                Case "NOTA DE DEBITO"
                    ' BuscarDocsFecha(dtpFechaDocs.Value, "08")
                Case "NOTAS DE CREDITO BOLETAS"
                    BuscarNotasBoletasPeriodo(txtPeriodo.Value, "07")

            End Select
        Catch ex As Exception

        End Try


    End Sub




    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click

        Me.Cursor = Cursors.WaitCursor
        ButtonAdv2.Enabled = False
        'Dim r As Record

        If Not Gempresas.ubigeo > 0 Then
            MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
            ButtonAdv2.Enabled = True
            Exit Sub
        End If

        '//nuevo
        Try

            For Each i In GridGroupingControl1.Table.Records

                If i.GetValue("idDocumento") > 0 Then
                    Select Case i.GetValue("tipodoc")
                        Case "01", "03"
                            Dim clas = (i.GetValue("enviosunat"))
                            If clas.ToString.Trim.Length > 0 Then
                                If i.GetValue("enviosunat") = "NE" Then
                                    EnviarFacturaElectronica(CInt(i.GetValue("idDocumento")), "FACTURA", "PE")
                                End If
                            Else
                                EnviarFacturaElectronica(CInt(i.GetValue("idDocumento")), "FACTURA", "SI")
                            End If
                        Case "07"
                            EnviarNotaCreditoElectronico(CInt(i.GetValue("idDocumento")), "NOTAS DE CREDITO", "")
                        Case "08"
                    End Select

                Else
                    MessageBox.Show("Seleccione un Documento para Enviar")
                    ButtonAdv2.Enabled = True
                    Me.Cursor = Cursors.Default
                End If



            Next

            Select Case ComboBox1.Text
                Case "FACTURA"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
                Case "BOLETAS"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
                Case "NOTAS DE CREDITO"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
                Case "NOTA DE DEBITO"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "08")
                Case "NOTAS DE CREDITO BOLETAS"
                    BuscarNotasBoletasPeriodo(txtPeriodo.Value, "07")
            End Select
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
        'enddd






        'Try
        '    r = GridGroupingControl1.Table.CurrentRecord

        '    If r.GetValue("idDocumento") > 0 Then
        '        Select Case r.GetValue("tipodoc")
        '            Case "01", "03"
        '                Dim clas = (r.GetValue("enviosunat"))
        '                If clas.ToString.Trim.Length > 0 Then
        '                    If r.GetValue("enviosunat") = "NE" Then
        '                        EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "PE")
        '                    End If
        '                Else
        '                    EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "SI")
        '                End If
        '            Case "07"
        '                EnviarNotaCreditoElectronico(CInt(r.GetValue("idDocumento")), "NOTAS DE CREDITO", "")
        '            Case "08"
        '        End Select


        '        Select Case ComboBox1.Text
        '            Case "FACTURA"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
        '            Case "BOLETAS"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
        '            Case "NOTAS DE CREDITO"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
        '            Case "NOTA DE DEBITO"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "08")
        '        End Select
        '    Else
        '        MessageBox.Show("Seleccione un Documento para Enviar")
        '        ButtonAdv2.Enabled = True
        '    End If
        '    ButtonAdv2.Enabled = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    ButtonAdv2.Enabled = True
        'End Try







        'Me.Cursor = Cursors.WaitCursor
        'ButtonAdv2.Enabled = False
        'Dim x As Record
        'x = GridGroupingControl1.Table.CurrentRecord

        'If Gempresas.ubigeo > 0 Then
        '    If My.Computer.Network.IsAvailable = True Then
        '        If My.Computer.Network.Ping("148.102.27.231") Then

        '            If x.GetValue("idDocumento") > 0 Then
        '                Select Case x.GetValue("tipodoc")
        '                    Case "01", "03"
        '                        Dim clas = (x.GetValue("enviosunat"))
        '                        If clas.ToString.Trim.Length > 0 Then
        '                            If x.GetValue("enviosunat") = "NE" Then
        '                                ReEnviarFacturaElectronica(CInt(x.GetValue("idDocumento")), Gempresas.ubigeo, "PE")
        '                                BuscarDocsFechaPeriodo(txtPeriodo.Value, x.GetValue("tipodoc"))
        '                            End If
        '                        Else
        '                            ReEnviarFacturaElectronica(CInt(x.GetValue("idDocumento")), Gempresas.ubigeo, "SI")
        '                            BuscarDocsFechaPeriodo(txtPeriodo.Value, x.GetValue("tipodoc"))
        '                        End If
        '                    Case "07"
        '                        ReEnviarNotaCreditoElectronico(CInt(x.GetValue("idDocumento")), Gempresas.ubigeo, "")
        '                        BuscarDocsFechaPeriodo(txtPeriodo.Value, x.GetValue("tipodoc"))
        '                    Case "08"
        '                End Select

        '            Else
        '                MessageBox.Show("Seleccione un Documento para Enviar")
        '                ButtonAdv2.Enabled = True
        '            End If

        '        End If
        '    End If
        'End If
        'ButtonAdv2.Enabled = True
        'Me.Cursor = Cursors.Default

    End Sub


End Class