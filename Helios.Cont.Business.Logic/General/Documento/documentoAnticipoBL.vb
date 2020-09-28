Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports Helios.General

Public Class documentoAnticipoBL
    Inherits BaseBL

    Public Function ObtenerSaldoReclamacion(idanticipo As Integer) As documentoAnticipo
        Dim objMostrarEncaja As New documentoAnticipo
        Dim ListaDetalle As New documentoAnticipo

        Dim consulta2 = (From compradet In HeliosData.documentoventaAbarrotes
                         Group Join nota In HeliosData.documentoventaAbarrotes
                         On nota.idPadre Equals compradet.idDocumento
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where compradet.idDocumento = idanticipo
                         Group c By
                      compradet.idDocumento, compradet.numeroDoc, compradet.fechaDoc, compradet.tipoDocumento, compradet.tipoOperacion,
                       compradet.idCliente, compradet.tipoCambio, compradet.tipoVenta,
                      compradet.ImporteNacional, compradet.ImporteExtranjero
                      Into g = Group
                         Select New With {.iddocumento = idDocumento,
                                       .numerodoc = numeroDoc,
                                       .fechadoc = fechaDoc,
                                       .tipodoc = tipoDocumento,
                                       .tipoperacion = tipoOperacion,
                             g, .TotalImportePagadoSoles = g.Sum(Function(c) c.ImporteNacional),
                             .TotalImportePagadoDolares = g.Sum(Function(c) c.ImporteExtranjero),
                             .importemn = ImporteNacional,
                             .importeme = ImporteExtranjero,
                             .tipoVenta = tipoVenta,
                             .identidad = idCliente,
                             .tipocambio = tipoCambio
                                   }
                               ).FirstOrDefault
        'For Each obj In consulta2

        objMostrarEncaja = New documentoAnticipo() With
                           {
                               .idDocumento = consulta2.iddocumento,
                            .numeroDoc = consulta2.numerodoc,
                               .fechaDoc = consulta2.fechadoc,
                               .tipoDocumento = consulta2.tipodoc,
                               .tipoOperacion = consulta2.tipoperacion,
                            .tipoAnticipo = IIf(IsDBNull(consulta2.tipoVenta), Nothing, consulta2.tipoVenta),
                            .importeMN = IIf(IsDBNull(consulta2.importemn), 0, consulta2.importemn),
                            .importeME = IIf(IsDBNull(consulta2.importeme), 0, consulta2.importeme),
                            .MontoPagadoSoles = IIf(IsDBNull(consulta2.TotalImportePagadoSoles), 0, consulta2.TotalImportePagadoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(consulta2.TotalImportePagadoDolares), 0, consulta2.TotalImportePagadoDolares),
                            .razonSocial = consulta2.identidad,
                               .TipoCambio = consulta2.tipocambio
                            }
        'ListaDetalle.Add(objMostrarEncaja)
        'Next
        Return objMostrarEncaja
    End Function

    Public Function GetReclamacionesStatusCompras(be As documentocompra) As List(Of documentoAnticipo)
        GetReclamacionesStatusCompras = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentocompra
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idProveedor
                        Group Join nota In HeliosData.documentoAnticipoConciliacionCompra
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idCentroCosto = be.idCentroCosto And
                            doc.tipoCompra = be.tipoCompra And doc.estadoPago = be.estadoPago
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.importeTotal,
                            doc.importeUS,
                            doc.estadoPago
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            importeTotal,
                            importeUS,
                            estadoPago,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDoc}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.importeTotal
            obj.importeME = i.importeUS
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoPago
            GetReclamacionesStatusCompras.Add(obj)
        Next
    End Function

    Public Function GetReclamacionesStatusVenta(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetReclamacionesStatusVenta = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And doc.estadoCobro = be.estadoCobro
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetReclamacionesStatusVenta.Add(obj)
        Next
    End Function

    Public Function ObtenerSaldoReclamacionCobro(idanticipo As Integer) As documentoAnticipo
        Dim objMostrarEncaja As New documentoAnticipo
        Dim ListaDetalle As New documentoAnticipo

        Dim consulta2 = (From compradet In HeliosData.documentocompra
                         Group Join nota In HeliosData.documentocompra
                         On nota.idPadre Equals compradet.idDocumento
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where compradet.idDocumento = idanticipo
                         Group c By
                      compradet.idDocumento, compradet.numeroDoc, compradet.fechaDoc, compradet.tipoDoc,
                       compradet.idProveedor, compradet.tcDolLoc, compradet.tipoCompra,
                      compradet.importeTotal, compradet.importeUS
                      Into g = Group
                         Select New With {.iddocumento = idDocumento,
                                       .numerodoc = numeroDoc,
                                       .fechadoc = fechaDoc,
                                       .tipodoc = tipoDoc,
                             g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeTotal),
                             .TotalImportePagadoDolares = g.Sum(Function(c) c.importeUS),
                             .importemn = importeTotal,
                             .importeme = importeUS,
                             .tipoVenta = tipoCompra,
                             .identidad = idProveedor,
                             .tipocambio = tcDolLoc
                                   }
                               ).FirstOrDefault
        'For Each obj In consulta2

        objMostrarEncaja = New documentoAnticipo() With
                           {
                               .idDocumento = consulta2.iddocumento,
                            .numeroDoc = consulta2.numerodoc,
                               .fechaDoc = consulta2.fechadoc,
                               .tipoDocumento = consulta2.tipodoc,
                            .tipoAnticipo = IIf(IsDBNull(consulta2.tipoVenta), Nothing, consulta2.tipoVenta),
                            .importeMN = IIf(IsDBNull(consulta2.importemn), 0, consulta2.importemn),
                            .importeME = IIf(IsDBNull(consulta2.importeme), 0, consulta2.importeme),
                            .MontoPagadoSoles = IIf(IsDBNull(consulta2.TotalImportePagadoSoles), 0, consulta2.TotalImportePagadoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(consulta2.TotalImportePagadoDolares), 0, consulta2.TotalImportePagadoDolares),
                            .razonSocial = consulta2.identidad,
                               .TipoCambio = consulta2.tipocambio
                            }
        'ListaDetalle.Add(objMostrarEncaja)
        'Next
        Return objMostrarEncaja
    End Function

    Public Function GetCompromisoXDocumento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetCompromisoXDocumento = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And
                            doc.idPadre = be.idDocumento And doc.tipoVenta = "VRC"
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetCompromisoXDocumento.Add(obj)
        Next
    End Function

    Public Function ObtenerSaldoAnticipoV2Compra(idanticipo As Integer) As documentoAnticipo
        Dim objMostrarEncaja As New documentoAnticipo
        Dim ListaDetalle As New documentoAnticipo

        Dim consulta2 = (From compradet In HeliosData.documentoAnticipo
                         Group Join nota In HeliosData.documentocompra
                         On nota.idPadre Equals compradet.idDocumento
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where compradet.idDocumento = idanticipo
                         Group c By
                      compradet.idDocumento, compradet.numeroDoc, compradet.fechaDoc, compradet.tipoDocumento, compradet.tipoOperacion,
                      compradet.tipoAnticipo, compradet.razonSocial, compradet.TipoCambio,
                      compradet.importeMN, compradet.importeME
                      Into g = Group
                         Select New With {.iddocumento = idDocumento,
                                       .numerodoc = numeroDoc,
                                       .fechadoc = fechaDoc,
                                       .tipodoc = tipoDocumento,
                                       .tipoperacion = tipoOperacion,
                             g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeTotal),
                             .TotalImportePagadoDolares = g.Sum(Function(c) c.importeUS),
                             .importemn = importeMN,
                             .importeme = importeME,
                             .tipoanticipo = tipoAnticipo,
                             .identidad = razonSocial,
                             .tipocambio = TipoCambio
                                   }
                               ).FirstOrDefault
        'For Each obj In consulta2

        objMostrarEncaja = New documentoAnticipo() With
                           {
                               .idDocumento = consulta2.iddocumento,
                            .numeroDoc = consulta2.numerodoc,
                               .fechaDoc = consulta2.fechadoc,
                               .tipoDocumento = consulta2.tipodoc,
                               .tipoOperacion = consulta2.tipoperacion,
                            .tipoAnticipo = IIf(IsDBNull(consulta2.tipoanticipo), Nothing, consulta2.tipoanticipo),
                            .importeMN = IIf(IsDBNull(consulta2.importemn), 0, consulta2.importemn),
                            .importeME = IIf(IsDBNull(consulta2.importeme), 0, consulta2.importeme),
                            .MontoPagadoSoles = IIf(IsDBNull(consulta2.TotalImportePagadoSoles), 0, consulta2.TotalImportePagadoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(consulta2.TotalImportePagadoDolares), 0, consulta2.TotalImportePagadoDolares),
                            .razonSocial = consulta2.identidad,
                               .TipoCambio = consulta2.tipocambio
                            }
        'ListaDetalle.Add(objMostrarEncaja)
        'Next
        Return objMostrarEncaja
    End Function


    Public Function GetAnticiposOtorgadosStatusAll(be As documentocompra) As List(Of documentoAnticipo)
        GetAnticiposOtorgadosStatusAll = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentocompra
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idProveedor
                        Group Join nota In HeliosData.documentoAnticipoConciliacionCompra
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idCentroCosto = be.idCentroCosto And
                            doc.tipoCompra = be.tipoCompra And doc.estadoPago = be.estadoPago
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.importeTotal,
                            doc.importeUS,
                            doc.estadoPago
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            importeTotal,
                            importeUS,
                            estadoPago,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDoc}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.importeTotal
            obj.importeME = i.importeUS
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoPago
            GetAnticiposOtorgadosStatusAll.Add(obj)
        Next
    End Function

    Public Function GetAnticipoRecibidosStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetAnticipoRecibidosStatusAll = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And doc.estadoCobro = be.estadoCobro
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetAnticipoRecibidosStatusAll.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesStatusCompra(be As documentoAnticipo) As List(Of documentoAnticipo)
        GetANTReclamacionesStatusCompra = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals doc.idDocumento
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.razonSocial
                        Group Join nota In HeliosData.documentocompra
                            On nota.idPadre Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoAnticipo = be.tipoAnticipo And
                            doc.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                            doc.estado = be.estado
                        Group c By
                                doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.tipoAnticipo,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            det.documentoCaja.formapago,
                            doc.importeMN,
                            doc.importeME
                            Into g = Group
                        Select New With
                            {
                            idDocumento,
                            numeroDoc,
                            fechaDoc,
                            tipoAnticipo,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            formapago,
                            importeMN,
                            importeME,
                            g, .sumaNotas = g.Sum(Function(c) c.importeTotal),
                            .ConteoNotas = g.Count()
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.ConteoNota = i.ConteoNotas
            GetANTReclamacionesStatusCompra.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesPeriodoCompra(be As documentoAnticipo) As List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(Anticipo.Estado.NotaCredito)
        lista.Add(Anticipo.Estado.NotaCreditoParcial)

        GetANTReclamacionesPeriodoCompra = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals doc.idDocumento
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.razonSocial
                        Group Join nota In HeliosData.documentocompra
                            On nota.idPadre Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoAnticipo = be.tipoAnticipo And
                            doc.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                            doc.fechaDoc.Value.Month = be.fechaDoc.Value.Month And
                             lista.Contains(doc.estado)
                        Group c By
                                doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.tipoAnticipo,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            det.documentoCaja.formapago,
                            doc.importeMN,
                            doc.importeME
                            Into g = Group
                        Select New With
                            {
                            idDocumento,
                            numeroDoc,
                            fechaDoc,
                            tipoAnticipo,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            formapago,
                            importeMN,
                            importeME,
                            g, .sumaNotas = g.Sum(Function(c) c.importeTotal),
                            .ConteoNotas = g.Count()
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.ConteoNota = i.ConteoNotas
            GetANTReclamacionesPeriodoCompra.Add(obj)
        Next
    End Function

    Public Function GetDevolucionAntSeguimientoCompra(be As documentocompra) As List(Of documentoAnticipo)
        GetDevolucionAntSeguimientoCompra = New List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial)
        'lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto)




        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentocompra
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idProveedor
                        Group Join caja In HeliosData.documentoCajaDetalle
                            On caja.documentoAfectado Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idCentroCosto = be.idCentroCosto And
                            doc.tipoCompra = be.tipoCompra And lista.Contains(doc.estadoPago)
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.importeTotal,
                            doc.importeUS,
                            doc.estadoPago
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            importeTotal,
                            importeUS,
                            estadoPago,
                            g, .sumaDevoluciones = g.Sum(Function(c) c.montoSoles)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDoc }"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.importeTotal
            obj.importeME = i.importeUS
            obj.TotalNotas = i.sumaDevoluciones.GetValueOrDefault
            obj.estado = i.estadoPago
            GetDevolucionAntSeguimientoCompra.Add(obj)
        Next
    End Function

    Public Function GetDevolucionesByDocumentoNotaCompra(be As documentocompra) As List(Of documentoAnticipo)
        GetDevolucionesByDocumentoNotaCompra = New List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto)

        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentocompra
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idProveedor
                        Group Join caja In HeliosData.documentoCajaDetalle
                            On caja.documentoAfectado Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idDocumento = be.idDocumento And
                            lista.Contains(doc.estadoPago)
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.importeTotal,
                            doc.importeUS,
                            doc.estadoPago
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            importeTotal,
                            importeUS,
                            estadoPago,
                            g, .sumaDevoluciones = g.Sum(Function(c) c.montoSoles)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDoc }"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.importeTotal
            obj.importeME = i.importeUS
            obj.TotalNotas = i.sumaDevoluciones.GetValueOrDefault
            obj.estado = i.estadoPago
            GetDevolucionesByDocumentoNotaCompra.Add(obj)
        Next
    End Function

    Public Function GetDevolucionVentaSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetDevolucionVentaSeguimiento = New List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial)
        'lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto)

        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join caja In HeliosData.documentoCajaDetalle
                            On caja.documentoAfectado Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And lista.Contains(doc.estadoCobro)
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaDevoluciones = g.Sum(Function(c) c.montoSoles)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaDevoluciones.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetDevolucionVentaSeguimiento.Add(obj)
        Next
    End Function

    Public Function GetDevolucionCompraSeguimiento(be As documentocompra) As List(Of documentoAnticipo)
        GetDevolucionCompraSeguimiento = New List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial)
        'lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto)


        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentocompra
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idProveedor
                        Group Join caja In HeliosData.documentoCajaDetalle
                            On caja.documentoAfectado Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idCentroCosto = be.idCentroCosto And
                            doc.tipoCompra = be.tipoCompra And lista.Contains(doc.estadoPago)
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.importeTotal,
                            doc.importeUS,
                            doc.estadoPago
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            importeTotal,
                            importeUS,
                            estadoPago,
                            g, .sumaDevoluciones = g.Sum(Function(c) c.montoSoles)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDoc }"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.importeTotal
            obj.importeME = i.importeUS
            obj.TotalNotas = i.sumaDevoluciones.GetValueOrDefault
            obj.estado = i.estadoPago
            GetDevolucionCompraSeguimiento.Add(obj)
        Next
    End Function

    Public Function GetAntReclamacionesProveedor(be As documentocompra) As List(Of documentoAnticipo)
        Dim lista As New List(Of String)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.Parcial)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.Pendiente)

        GetAntReclamacionesProveedor = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentocompra
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idProveedor
                        Group Join nota In HeliosData.documentoAnticipoConciliacionCompra
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idCentroCosto = be.idCentroCosto And
                            doc.tipoCompra = be.tipoCompra And
                            lista.Contains(doc.estadoPago) And ' = be.estado And
                            doc.idProveedor = be.idProveedor
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.importeTotal,
                            doc.importeUS,
                            doc.estadoPago
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            importeTotal,
                            importeUS,
                            estadoPago,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            'obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc

            obj.numeroDoc = $"{i.serie}-{i.numeroDoc }"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.importeTotal
            obj.importeME = i.importeUS
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoPago
            GetAntReclamacionesProveedor.Add(obj)
        Next
    End Function


    Public Function GetANTReclamacionesXDocumentoCompra(be As documentocompra) As documentoAnticipo
        GetANTReclamacionesXDocumentoCompra = New documentoAnticipo
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentocompra
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idProveedor
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idDocumento = be.idDocumento
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.tipoCompra,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.importeTotal,
                            doc.importeUS
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                             serie,
                            tipoCompra,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            importeTotal,
                            importeUS,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).FirstOrDefault

        obj = New documentoAnticipo
        If consulta IsNot Nothing Then

            obj.idDocumento = consulta.idDocumento
            obj.numeroDoc = consulta.numeroDoc
            obj.fechaDoc = consulta.fechaDoc
            obj.tipoOperacion = consulta.tipoCompra
            obj.numeroDoc = $"{consulta.serie }-{consulta.numeroDoc}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = consulta.idEntidad,
                    .tipoEntidad = consulta.tipoEntidad,
                    .nombreCompleto = consulta.nombreCompleto,
                    .nrodoc = consulta.nrodoc
                    }
            obj.importeMN = consulta.importeTotal
            obj.importeME = consulta.importeUS
            obj.TotalNotas = consulta.sumaNotas.GetValueOrDefault
        End If

        Return obj
    End Function

    Public Function GetDevolucionAntSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetDevolucionAntSeguimiento = New List(Of documentoAnticipo)

        'Dim lista As New List(Of String)
        'lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente)
        'lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial)
        'lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto)

        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join caja In HeliosData.documentoCajaDetalle
                            On caja.documentoAfectado Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And
                            doc.estadoCobro = be.estadoCobro
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaDevoluciones = g.Sum(Function(c) c.montoSoles)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaDevoluciones.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetDevolucionAntSeguimiento.Add(obj)
        Next
    End Function

    Public Function GetDevolucionesByDocumentoNota(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetDevolucionesByDocumentoNota = New List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto)

        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join caja In HeliosData.documentoCajaDetalle
                            On caja.documentoAfectado Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idDocumento = be.idDocumento And
                            lista.Contains(doc.estadoCobro)
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaDevoluciones = g.Sum(Function(c) c.montoSoles)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaDevoluciones.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetDevolucionesByDocumentoNota.Add(obj)
        Next
    End Function

    Public Sub GetChangeEstadoAnticipo(be As documentoAnticipo)
        Dim anticipo = HeliosData.documentoAnticipo.Where(Function(o) o.idDocumento = be.idDocumento).Single
        anticipo.estado = be.estado
        HeliosData.SaveChanges()
    End Sub

    Public Function GetStatusAprobacionAnticipos(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim query = HeliosData.documentoAnticipo.Where(Function(o) _
                                                         o.idEmpresa = be.idEmpresa And
                                                         o.idEstablecimiento = be.idEstablecimiento And
                                                         o.tipoAnticipo = be.tipoAnticipo And o.estado <> "ANU").GroupBy(Function(g) New With
                                                         {
                                                         Key g.estado,
                                                         Key g.tipoAnticipo
                                                                                                                             }).
           Select(Function(group) New With
           {
           .tipoAnticipo = group.Key.tipoAnticipo,
           .estado = group.Key.estado,
           .TotalCount = group.Count()
                      }).ToList()

        GetStatusAprobacionAnticipos = New List(Of documentoAnticipo)
        For Each i In query
            GetStatusAprobacionAnticipos.Add(New documentoAnticipo With
                                    {
                                    .tipoAnticipo = i.tipoAnticipo,
                                    .estado = i.estado,
                                    .conteoCuotas = i.TotalCount
                                    })
        Next
    End Function

    Public Function GetStatusAprobacionAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta30 = (From doc In HeliosData.documentoAnticipo
                          Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals doc.idDocumento
                          Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.razonSocial
                          Where
                              doc.idEmpresa = be.idEmpresa And
                              doc.idEstablecimiento = be.idEstablecimiento And
                              doc.tipoAnticipo = be.tipoAnticipo And
                              doc.estado = be.estado
                          Select New With
                              {
                              doc.idDocumento,
                              doc.numeroDoc,
                              doc.fechaDoc,
                              doc.tipoAnticipo,
                              ent.idEntidad,
                              ent.tipoEntidad,
                              ent.nombreCompleto,
                              ent.nrodoc,
                              det.documentoCaja.formapago,
                              doc.importeMN,
                              doc.importeME
                              }).ToList

        GetStatusAprobacionAnticiposList = New List(Of documentoAnticipo)
        For Each i In consulta30
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
            {
            .idEntidad = i.idEntidad,
            .tipoEntidad = i.tipoEntidad,
            .nombreCompleto = i.nombreCompleto,
            .nrodoc = i.nrodoc
            }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME

            GetStatusAprobacionAnticiposList.Add(obj)
        Next


    End Function


    Public Function GetEscaneadasAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo)
        'Dim FechInicio = New DateTime(be.fechaDoc.Value.Year, be.fechaDoc.Value.Month, be.fechaDoc.Value.Day, 0, 0, 0)
        Dim fechaFinal = New DateTime(DateTime.Now.Year, 12, 31, 0, 0, 0)
        Dim addDay60 As DateTime
        Dim s As New DateTime(DateTime.Now.Year, 1, 1)
        Dim addDay As DateTime = s.AddDays(CInt(30))

        GetEscaneadasAnticiposList = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Select Case be.tipoOperacion
            Case "30"
                Dim consulta30 = (From doc In HeliosData.documentoAnticipo
                                  Join det In HeliosData.documentoCajaDetalle
                                      On det.documentoAfectado Equals doc.idDocumento
                                  Join ent In HeliosData.entidad
                                      On ent.idEntidad Equals doc.razonSocial
                                  Where
                                      doc.idEmpresa = be.idEmpresa And
                                      doc.idEstablecimiento = be.idEstablecimiento And
                                      doc.tipoAnticipo = be.tipoAnticipo And
                                      doc.fechaDoc = s And
                                      doc.fechaDoc <= addDay
                                  Select New With
                                      {
                                      doc.idDocumento,
                                      doc.numeroDoc,
                                      doc.fechaDoc,
                                      doc.tipoAnticipo,
                                      ent.idEntidad,
                                      ent.tipoEntidad,
                                      ent.nombreCompleto,
                                      ent.nrodoc,
                                      det.documentoCaja.formapago,
                                      doc.importeMN,
                                      doc.importeME
                                      }).ToList

                For Each i In consulta30
                    obj = New documentoAnticipo
                    obj.idDocumento = i.idDocumento
                    obj.numeroDoc = i.numeroDoc
                    obj.fechaDoc = i.fechaDoc
                    obj.tipoAnticipo = i.tipoAnticipo
                    obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
                    obj.formaPago = i.formapago
                    obj.importeMN = i.importeMN
                    obj.importeME = i.importeME

                    GetEscaneadasAnticiposList.Add(obj)
                Next
            Case "60"
                '--------------------------------- 60 ------------------------------------------
                addDay = addDay.AddDays(1)
                Dim s60 As New DateTime(DateTime.Now.Year, addDay.Date.Month, addDay.Date.Day)
                addDay60 = s60.AddDays(CInt(30))
                Dim consulta60 = (From doc In HeliosData.documentoAnticipo
                                  Join det In HeliosData.documentoCajaDetalle
                                      On det.documentoAfectado Equals doc.idDocumento
                                  Join ent In HeliosData.entidad
                                      On ent.idEntidad Equals doc.razonSocial
                                  Where
                                      doc.idEmpresa = be.idEmpresa And
                                      doc.idEstablecimiento = be.idEstablecimiento And
                                      doc.tipoAnticipo = be.tipoAnticipo And
                                            doc.fechaDoc >= s60 And
                                            doc.fechaDoc <= addDay60
                                  Select New With
                                            {
                                              doc.idDocumento,
                                              doc.numeroDoc,
                                              doc.fechaDoc,
                                              doc.tipoAnticipo,
                                              ent.idEntidad,
                                              ent.tipoEntidad,
                                              ent.nombreCompleto,
                                              ent.nrodoc,
                                              det.documentoCaja.formapago,
                                              doc.importeMN,
                                              doc.importeME
                                            }).ToList

                For Each i In consulta60
                    obj = New documentoAnticipo
                    obj.idDocumento = i.idDocumento
                    obj.numeroDoc = i.numeroDoc
                    obj.fechaDoc = i.fechaDoc
                    obj.tipoAnticipo = i.tipoAnticipo
                    obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
                    obj.formaPago = i.formapago
                    obj.importeMN = i.importeMN
                    obj.importeME = i.importeME

                    GetEscaneadasAnticiposList.Add(obj)
                Next


            Case "61"
                '****************************************** 61 a mas***********************************************
                addDay60 = addDay60.AddDays(1)
                Dim s90 As New DateTime(DateTime.Now.Year, addDay60.Date.Month, addDay60.Date.Day)
                '  Dim dias90 = DateDiff(DateInterval.Day, s, DateTime.Now.Date)
                Dim addDay90 As DateTime = s90.AddDays(CInt(30))
                Dim consulta90 = (From doc In HeliosData.documentoAnticipo
                                  Join det In HeliosData.documentoCajaDetalle
                                      On det.documentoAfectado Equals doc.idDocumento
                                  Join ent In HeliosData.entidad
                                      On ent.idEntidad Equals doc.razonSocial
                                  Where
                                      doc.idEmpresa = be.idEmpresa And
                                      doc.idEstablecimiento = be.idEstablecimiento And
                                      doc.tipoAnticipo = be.tipoAnticipo And
                                      doc.fechaDoc >= s90 And
                                      doc.fechaDoc <= fechaFinal'addDay90
                                  Select New With
                                      {
                                      doc.idDocumento,
                                      doc.numeroDoc,
                                      doc.fechaDoc,
                                      doc.tipoAnticipo,
                                      ent.idEntidad,
                                      ent.tipoEntidad,
                                      ent.nombreCompleto,
                                      ent.nrodoc,
                                      det.documentoCaja.formapago,
                                      doc.importeMN,
                                      doc.importeME
                                      }).ToList

                For Each i In consulta90
                    obj = New documentoAnticipo
                    obj.idDocumento = i.idDocumento
                    obj.numeroDoc = i.numeroDoc
                    obj.fechaDoc = i.fechaDoc
                    obj.tipoAnticipo = i.tipoAnticipo
                    obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
                    obj.formaPago = i.formapago
                    obj.importeMN = i.importeMN
                    obj.importeME = i.importeME

                    GetEscaneadasAnticiposList.Add(obj)
                Next
        End Select

    End Function

    Public Function GetAnticiposPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo)
        GetAnticiposPeriodo = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals doc.idDocumento
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.razonSocial
                        Where
                              doc.idEmpresa = be.idEmpresa And
                              doc.idEstablecimiento = be.idEstablecimiento And
                              doc.tipoAnticipo = be.tipoAnticipo And
                              doc.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                              doc.fechaDoc.Value.Month = be.fechaDoc.Value.Month
                        Select New With
                              {
                              doc.idDocumento,
                              doc.numeroDoc,
                              doc.fechaDoc,
                              doc.tipoAnticipo,
                              ent.idEntidad,
                              ent.tipoEntidad,
                              ent.nombreCompleto,
                              ent.nrodoc,
                              det.documentoCaja.formapago,
                              doc.importeMN,
                              doc.importeME
                              }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME

            GetAnticiposPeriodo.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(Anticipo.Estado.NotaCredito)
        lista.Add(Anticipo.Estado.NotaCreditoParcial)



        GetANTReclamacionesPeriodo = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals doc.idDocumento
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.razonSocial
                        Group Join nota In HeliosData.documentoventaAbarrotes
                            On nota.idPadre Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoAnticipo = be.tipoAnticipo And
                            doc.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                            doc.fechaDoc.Value.Month = be.fechaDoc.Value.Month And
                            lista.Contains(doc.estado)
                        Group c By
                                doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.tipoAnticipo,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            det.documentoCaja.formapago,
                            doc.importeMN,
                            doc.importeME
                            Into g = Group
                        Select New With
                            {
                            idDocumento,
                            numeroDoc,
                            fechaDoc,
                            tipoAnticipo,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            formapago,
                            importeMN,
                            importeME,
                            g, .sumaNotas = g.Sum(Function(c) c.ImporteNacional),
                            .ConteoNotas = g.Count()
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.ConteoNota = i.ConteoNotas
            GetANTReclamacionesPeriodo.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesStatus(be As documentoAnticipo) As List(Of documentoAnticipo)
        GetANTReclamacionesStatus = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals doc.idDocumento
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.razonSocial
                        Group Join nota In HeliosData.documentoventaAbarrotes
                            On nota.idPadre Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoAnticipo = be.tipoAnticipo And
                            doc.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                            doc.estado = be.estado
                        Group c By
                                doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.tipoAnticipo,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            det.documentoCaja.formapago,
                            doc.importeMN,
                            doc.importeME
                            Into g = Group
                        Select New With
                            {
                            idDocumento,
                            numeroDoc,
                            fechaDoc,
                            tipoAnticipo,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            formapago,
                            importeMN,
                            importeME,
                            g, .sumaNotas = g.Sum(Function(c) c.ImporteNacional),
                            .ConteoNotas = g.Count()
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.ConteoNota = i.ConteoNotas
            GetANTReclamacionesStatus.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesPersona(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim lista As New List(Of String)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.Parcial)
        lista.Add(General.Anticipo.EstadoCobroNotaCredito.Pendiente)

        GetANTReclamacionesPersona = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And
                            lista.Contains(doc.estadoCobro) And ' = be.estado And
                            doc.idCliente = be.idCliente
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetANTReclamacionesPersona.Add(obj)
        Next
    End Function

    Public Function GetStatusNotaCreditoCount(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim query = HeliosData.documentoventaAbarrotes.Where(Function(o) _
                                                         o.idEmpresa = be.idEmpresa And
                                                         o.idEstablecimiento = be.idEstablecimiento And
                                                         o.tipoVenta = be.tipoVenta And
                                                         o.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                                                         o.estadoCobro <> "ANU").GroupBy(Function(g) New With
                                                         {
                                                         Key g.estadoCobro,
                                                         Key g.tipoVenta
                                                                                                                             }).
           Select(Function(group) New With
           {
           .tipoAnticipo = group.Key.tipoVenta,
           .estado = group.Key.estadoCobro,
           .TotalCount = group.Count()
                      }).ToList()

        GetStatusNotaCreditoCount = New List(Of documentoAnticipo)
        For Each i In query
            GetStatusNotaCreditoCount.Add(New documentoAnticipo With
                                    {
                                    .tipoAnticipo = i.tipoAnticipo,
                                    .estado = i.estado,
                                    .conteoCuotas = i.TotalCount
                                    })
        Next
    End Function

    Public Function GetANTReclamacionesPersonaAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetANTReclamacionesPersonaAll = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And
                            doc.idCliente = be.idCliente
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetANTReclamacionesPersonaAll.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetANTReclamacionesStatusAll = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And
                            doc.estadoCobro = be.estadoCobro
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetANTReclamacionesStatusAll.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesStatusCount(be As documentoventaAbarrotes) As Integer
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And
                            doc.estadoCobro = be.estadoCobro
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).Count

        GetANTReclamacionesStatusCount = consulta
    End Function

    Public Function GetANTReclamacionesXDocumento(be As documentoventaAbarrotes) As documentoAnticipo
        GetANTReclamacionesXDocumento = New documentoAnticipo
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idDocumento = be.idDocumento
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                             serieVenta,
                            numeroVenta,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).FirstOrDefault

        obj = New documentoAnticipo
        If consulta IsNot Nothing Then

            obj.idDocumento = consulta.idDocumento
            obj.numeroDoc = consulta.numeroDoc
            obj.fechaDoc = consulta.fechaDoc
            obj.numeroDoc = $"{consulta.serieVenta}-{consulta.numeroVenta}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = consulta.idEntidad,
                    .tipoEntidad = consulta.tipoEntidad,
                    .nombreCompleto = consulta.nombreCompleto,
                    .nrodoc = consulta.nrodoc
                    }
            obj.importeMN = consulta.ImporteNacional
            obj.importeME = consulta.ImporteExtranjero
            obj.TotalNotas = consulta.sumaNotas.GetValueOrDefault
        End If

        Return obj
    End Function

    Public Function SaveDevolucionAnticipo(objDocumento As documento, objDocumentoCaja As documento) As Integer
        Dim DocumentoBL As New documentoBL


        Dim asientoBL As New AsientoBL

        Dim cajaDetalleBL As New documentoAnticipoDetalleBL
        Dim idDocumentoRecuperado As Integer
        Dim anticipobl As New documentoAnticipoBL
        Try
            Using ts As New TransactionScope()

                DocumentoBL.Insert(objDocumento)


                ' Me.InsertSingleAnticipo(objDocumento.documentoAnticipo, objDocumento.idDocumento)
                idDocumentoRecuperado = anticipobl.InsertAntDesc(objDocumento.documentoAnticipo, objDocumento.idDocumento)
                cajaDetalleBL.InsertDevolucionDetalle(objDocumento, idDocumentoRecuperado)


                'For Each i In objDocumento.documentoAnticipo.documentoAnticipoDetalle
                '    compraDetalleBL.InsertSingleAnticipo(i, objDocumento.idDocumento)
                'Next
                asientoBL.SavebyGroupDoc(objDocumento)
                SaveCajaME(objDocumentoCaja, objDocumento.idDocumento)

                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumento.idDocumento

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerSaldoAnticipo(idanticipo As Integer)
        Dim objMostrarEncaja As New documentoAnticipo
        Dim ListaDetalle As New documentoAnticipo

        Dim consulta2 = (From compradet In HeliosData.documentoAnticipo
                         Group Join caja In HeliosData.documentoAnticipoDetalle
                         On compradet.idDocumento Equals caja.idAnticipo
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where compradet.idDocumento = idanticipo
                         Group c By
                      compradet.idDocumento, compradet.numeroDoc, compradet.fechaDoc, compradet.tipoDocumento, compradet.tipoOperacion,
                      compradet.tipoAnticipo, compradet.razonSocial, compradet.TipoCambio,
                      compradet.importeMN, compradet.importeME
                      Into g = Group
                         Select New With {.iddocumento = idDocumento,
                                       .numerodoc = numeroDoc,
                                       .fechadoc = fechaDoc,
                                       .tipodoc = tipoDocumento,
                                       .tipoperacion = tipoOperacion,
        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeMN),
        .TotalImportePagadoDolares = g.Sum(Function(c) c.importeME),
       .importemn = importeMN,
       .importeme = importeME,
       .tipoanticipo = tipoAnticipo,
       .identidad = razonSocial,
       .tipocambio = TipoCambio
                                   }
                               ).FirstOrDefault
        'For Each obj In consulta2

        objMostrarEncaja = New documentoAnticipo() With
                           {
                               .idDocumento = consulta2.iddocumento,
                            .numeroDoc = consulta2.numerodoc,
                               .fechaDoc = consulta2.fechadoc,
                               .tipoDocumento = consulta2.tipodoc,
                               .tipoOperacion = consulta2.tipoperacion,
                            .tipoAnticipo = IIf(IsDBNull(consulta2.tipoanticipo), Nothing, consulta2.tipoanticipo),
                            .importeMN = IIf(IsDBNull(consulta2.importemn), 0, consulta2.importemn),
                            .importeME = IIf(IsDBNull(consulta2.importeme), 0, consulta2.importeme),
                            .MontoPagadoSoles = IIf(IsDBNull(consulta2.TotalImportePagadoSoles), 0, consulta2.TotalImportePagadoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(consulta2.TotalImportePagadoDolares), 0, consulta2.TotalImportePagadoDolares),
                            .razonSocial = consulta2.identidad,
                               .TipoCambio = consulta2.tipocambio
                            }
        'ListaDetalle.Add(objMostrarEncaja)
        'Next
        Return objMostrarEncaja
    End Function

    Public Function ObtenerSaldoAnticipoV2(idanticipo As Integer) As documentoAnticipo
        Dim objMostrarEncaja As New documentoAnticipo
        Dim ListaDetalle As New documentoAnticipo

        Dim consulta2 = (From compradet In HeliosData.documentoAnticipo
                         Group Join nota In HeliosData.documentoventaAbarrotes
                         On nota.idPadre Equals compradet.idDocumento
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where compradet.idDocumento = idanticipo
                         Group c By
                      compradet.idDocumento, compradet.numeroDoc, compradet.fechaDoc, compradet.tipoDocumento, compradet.tipoOperacion,
                      compradet.tipoAnticipo, compradet.razonSocial, compradet.TipoCambio,
                      compradet.importeMN, compradet.importeME
                      Into g = Group
                         Select New With {.iddocumento = idDocumento,
                                       .numerodoc = numeroDoc,
                                       .fechadoc = fechaDoc,
                                       .tipodoc = tipoDocumento,
                                       .tipoperacion = tipoOperacion,
                             g, .TotalImportePagadoSoles = g.Sum(Function(c) c.ImporteNacional),
                             .TotalImportePagadoDolares = g.Sum(Function(c) c.ImporteExtranjero),
                             .importemn = importeMN,
                             .importeme = importeME,
                             .tipoanticipo = tipoAnticipo,
                             .identidad = razonSocial,
                             .tipocambio = TipoCambio
                                   }
                               ).FirstOrDefault
        'For Each obj In consulta2

        objMostrarEncaja = New documentoAnticipo() With
                           {
                               .idDocumento = consulta2.iddocumento,
                            .numeroDoc = consulta2.numerodoc,
                               .fechaDoc = consulta2.fechadoc,
                               .tipoDocumento = consulta2.tipodoc,
                               .tipoOperacion = consulta2.tipoperacion,
                            .tipoAnticipo = IIf(IsDBNull(consulta2.tipoanticipo), Nothing, consulta2.tipoanticipo),
                            .importeMN = IIf(IsDBNull(consulta2.importemn), 0, consulta2.importemn),
                            .importeME = IIf(IsDBNull(consulta2.importeme), 0, consulta2.importeme),
                            .MontoPagadoSoles = IIf(IsDBNull(consulta2.TotalImportePagadoSoles), 0, consulta2.TotalImportePagadoSoles),
                            .MontoPagadoUSD = IIf(IsDBNull(consulta2.TotalImportePagadoDolares), 0, consulta2.TotalImportePagadoDolares),
                            .razonSocial = consulta2.identidad,
                               .TipoCambio = consulta2.tipocambio
                            }
        'ListaDetalle.Add(objMostrarEncaja)
        'Next
        Return objMostrarEncaja
    End Function


    Public Function ObtenerSaldoAnticipoPersona(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim obj As New documentoAnticipo

        Dim consulta = (From compradet In HeliosData.documentoAnticipo
                        Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals compradet.idDocumento
                        Join ent In HeliosData.entidad
                                 On ent.idEntidad Equals compradet.razonSocial
                        Group Join caja In HeliosData.documentoAnticipoDetalle
                             On compradet.idDocumento Equals caja.idAnticipo
                             Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                             compradet.idEmpresa = be.idEmpresa And
                             compradet.idEstablecimiento = be.idEstablecimiento And
                             compradet.tipoAnticipo = be.tipoAnticipo And
                             compradet.razonSocial = be.razonSocial
                        Group c By
                             compradet.idDocumento,
                              compradet.numeroDoc,
                              compradet.fechaDoc,
                              compradet.tipoAnticipo,
                              ent.idEntidad,
                              ent.tipoEntidad,
                              ent.nombreCompleto,
                              ent.nrodoc,
                              det.documentoCaja.formapago,
                              compradet.importeMN,
                              compradet.importeME
                      Into g = Group
                        Select New With
                             {
                             .iddocumento = idDocumento,
                             .numerodoc = numeroDoc,
                             .fechadoc = fechaDoc,
                             .tipoAnticipo = tipoAnticipo,
                             .idEntidad = idEntidad,
                             .tipoEntidad = tipoEntidad,
                             .nombreCompleto = nombreCompleto,
                             .nrodoc = nrodoc,
                             .formapago = formapago,
                             .importeMN = importeMN,
                             .importeME = importeME,
                             g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeMN),
                             .TotalImportePagadoDolares = g.Sum(Function(c) c.importeME)
                             }
                             ).ToList

        ObtenerSaldoAnticipoPersona = New List(Of documentoAnticipo)
        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.iddocumento
            obj.numeroDoc = i.numerodoc
            obj.fechaDoc = i.fechadoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.MontoPagadoSoles = i.TotalImportePagadoSoles.GetValueOrDefault
            obj.MontoPagadoUSD = i.TotalImportePagadoDolares.GetValueOrDefault
            ObtenerSaldoAnticipoPersona.Add(obj)
        Next
    End Function



    Public Function getTableAnticiposPorTipoProveedor(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String, idprovedor As Integer) As List(Of documentoAnticipo)
        Dim docAnticipo As New documentoAnticipo
        Dim Lista As New List(Of documentoAnticipo)
        Dim anticipodet As New documentoAnticipoDetalleBL

        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join compra In HeliosData.estadosFinancieros
                      On doc.idEntidadFinanciera Equals compra.idestado
                        Join entidad In HeliosData.entidad
                      On doc.razonSocial Equals entidad.idEntidad
                        Where doc.idEmpresa = strIdEmpresa And
                      doc.razonSocial = idprovedor And
                      doc.tipoAnticipo = tipo And
                      doc.idEstablecimiento = intIdEstablecimiento _
                     And doc.fechaPeriodo = strPeriodo).ToList

        For Each obj In consulta
            docAnticipo = New documentoAnticipo
            docAnticipo.idDocumento = obj.doc.idDocumento
            docAnticipo.idEmpresa = obj.doc.idEmpresa
            docAnticipo.idEstablecimiento = obj.doc.idEstablecimiento
            docAnticipo.tipoDocumento = obj.doc.tipoDocumento
            docAnticipo.numeroDoc = obj.doc.numeroDoc
            docAnticipo.fechaDoc = obj.doc.fechaDoc
            docAnticipo.fechaPeriodo = obj.doc.fechaPeriodo
            docAnticipo.tipoOperacion = obj.doc.tipoOperacion
            docAnticipo.tipoAnticipo = obj.doc.tipoAnticipo
            docAnticipo.NombreEntidad = obj.entidad.nombreCompleto
            docAnticipo.TipoCambio = obj.doc.TipoCambio
            docAnticipo.Moneda = obj.doc.Moneda

            ' anticipodet.getTableAnticipoActualPorTipoProveedor(obj.doc.idDocumento)
            docAnticipo.importeMN = obj.doc.importeMN
            docAnticipo.importeME = obj.doc.importeME

            docAnticipo.NombreEstadoFinanciero = obj.compra.descripcion
            docAnticipo.usuarioModificacion = obj.doc.usuarioModificacion
            docAnticipo.fechaActualizacion = obj.doc.fechaActualizacion
            Lista.Add(docAnticipo)
        Next
        Return Lista
    End Function



    Public Function ListadoComprobateAnticipoXidPadre(iNtPadre As Integer) As List(Of documentoAnticipo)
        Dim lista As New List(Of documentoAnticipo)
        Dim a As New documentoAnticipo

        Dim cc = (From c In HeliosData.documentoAnticipo
                  Join det In HeliosData.documentoAnticipoDetalle
                 On c.idDocumento Equals det.idDocumento
                  Where det.documentoAfectado = iNtPadre
                  Group det By
                       c.idDocumento, c.fechaDoc, c.tipoDocumento, c.numeroDoc, c.TipoCambio, c.Moneda, c.codigoLibro
                          Into g = Group
                  Select New With {.idDoc = idDocumento,
                                          .fecha = fechaDoc,
                                           .TipoDoc = tipoDocumento,
                                           .NumeroDoc = numeroDoc,
                                            .moNeda = Moneda,
                                            .tipocambio = TipoCambio,
                                            .codigoLibro = codigoLibro,
                                           g, .importeMN = g.Sum(Function(c) c.importeMN),
                                           .importeME = g.Sum(Function(c) c.importeME)
                                       }
                                   ).ToList


        For Each i In cc
            a = New documentoAnticipo
            a.idDocumento = i.idDoc
            a.fechaDoc = i.fecha
            a.tipoDocumento = i.TipoDoc
            a.numeroDoc = i.NumeroDoc
            'a.numeroOperacion = i.NumeroOper
            a.Moneda = i.moNeda
            a.TipoCambio = i.tipocambio
            a.codigoLibro = i.codigoLibro
            a.importeMN = i.importeMN
            a.importeME = i.importeME
            lista.Add(a)
        Next

        Return lista
    End Function


    Public Function InsertAntDesc(ByVal documentoCajaBE As documentoAnticipo, intDocumento As Integer) As Integer
        Dim nDocumentoCaja As New documentoAnticipo
        Using ts As New TransactionScope

            With nDocumentoCaja
                .codigoLibro = documentoCajaBE.codigoLibro
                .idDocumento = intDocumento
                .idEmpresa = documentoCajaBE.idEmpresa
                .idEstablecimiento = documentoCajaBE.idEstablecimiento
                .tipoMovimiento = documentoCajaBE.tipoMovimiento
                .codigoProveedor = documentoCajaBE.codigoProveedor
                .fechaPeriodo = documentoCajaBE.fechaPeriodo
                .fechaDoc = documentoCajaBE.fechaDoc
                '.fechaCobro = documentoCajaBE.fechaCobro
                .tipoDocumento = documentoCajaBE.tipoDocumento
                .numeroDoc = documentoCajaBE.numeroDoc
                '.monedaObligacion = documentoCajaBE.monedaObligacion
                .Moneda = documentoCajaBE.Moneda
                '.entidadFinanciera = documentoCajaBE.entidadFinanciera
                '.entidadFinancieraDestino = documentoCajaBE.entidadFinancieraDestino
                .movimiento = documentoCajaBE.movimiento
                '.numeroOperacion = documentoCajaBE.numeroOperacion
                '.bancoEntidad = documentoCajaBE.bancoEntidad
                '.ctaCorrienteDeposito = documentoCajaBE.ctaCorrienteDeposito
                .TipoCambio = documentoCajaBE.TipoCambio
                .importeMN = documentoCajaBE.importeMN
                .importeME = documentoCajaBE.importeME
                '.montoItf = documentoCajaBE.montoItf
                '.montoItfusd = documentoCajaBE.montoItfusd
                '.glosa = documentoCajaBE.glosa
                '.entregado = documentoCajaBE.entregado
                .usuarioModificacion = documentoCajaBE.usuarioModificacion
                .fechaActualizacion = documentoCajaBE.fechaActualizacion
            End With
            HeliosData.documentoAnticipo.Add(nDocumentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoCajaBE.idDocumento = nDocumentoCaja.idDocumento
            Return nDocumentoCaja.idDocumento
        End Using
    End Function


    Public Function ObtenerAnticiposMontoActual(idproveedor As Integer, tipo As String) As List(Of documentoAnticipo)
        Dim objMostrarEncaja As New documentoAnticipo
        Dim ListaDetalle As New List(Of documentoAnticipo)

        Dim consulta2 = (From compradet In HeliosData.documentoAnticipo
                         Group Join caja In HeliosData.documentoAnticipoDetalle
                         On compradet.idDocumento Equals caja.idAnticipo
                         Into ords = Group
                         From c In ords.DefaultIfEmpty
                         Where compradet.razonSocial = idproveedor And compradet.tipoAnticipo = tipo
                         Group c By
                      compradet.idDocumento, compradet.numeroDoc, compradet.fechaDoc, compradet.tipoDocumento, compradet.tipoOperacion,
                      compradet.tipoAnticipo, compradet.razonSocial, compradet.TipoCambio,
                      compradet.importeMN, compradet.importeME
                      Into g = Group
                         Select New With {.iddocumento = idDocumento,
                                       .numerodoc = numeroDoc,
                                       .fechadoc = fechaDoc,
                                       .tipodoc = tipoDocumento,
                                       .tipoperacion = tipoOperacion,
        g, .TotalImportePagadoSoles = g.Sum(Function(c) c.importeMN),
        .TotalImportePagadoDolares = g.Sum(Function(c) c.importeME),
       .importemn = importeMN,
       .importeme = importeME,
       .tipoanticipo = tipoAnticipo,
       .identidad = razonSocial,
       .tipocambio = TipoCambio
                                   }
                               ).ToList
        For Each obj In consulta2

            objMostrarEncaja = New documentoAnticipo() With
                               {
                                   .idDocumento = obj.iddocumento,
                                .numeroDoc = obj.numerodoc,
                                   .fechaDoc = obj.fechadoc,
                                   .tipoDocumento = obj.tipodoc,
                                   .tipoOperacion = obj.tipoperacion,
                                .tipoAnticipo = IIf(IsDBNull(obj.tipoanticipo), Nothing, obj.tipoanticipo),
                                .MontoDeudaSoles = IIf(IsDBNull(obj.importemn), 0, obj.importemn),
                                .MontoDeudaUSD = IIf(IsDBNull(obj.importeme), 0, obj.importeme),
                                .MontoPagadoSoles = IIf(IsDBNull(obj.TotalImportePagadoSoles), 0, obj.TotalImportePagadoSoles),
                                .MontoPagadoUSD = IIf(IsDBNull(obj.TotalImportePagadoDolares), 0, obj.TotalImportePagadoDolares),
                                .razonSocial = obj.identidad,
                                   .TipoCambio = obj.tipocambio
                                }
            ListaDetalle.Add(objMostrarEncaja)
        Next
        Return ListaDetalle
    End Function


    Public Function getTableAnticiposPorPeriodoTipo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoAnticipo)
        Dim docAnticipo As New documentoAnticipo
        Dim Lista As New List(Of documentoAnticipo)

        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join compra In HeliosData.estadosFinancieros
                      On doc.idEntidadFinanciera Equals compra.idestado
                        Join entidad In HeliosData.entidad
                      On doc.razonSocial Equals entidad.idEntidad
                        Where doc.idEmpresa = strIdEmpresa And
                      doc.tipoAnticipo = tipo And
                      doc.idEstablecimiento = intIdEstablecimiento _
                     And doc.fechaPeriodo = strPeriodo).ToList

        For Each obj In consulta
            docAnticipo = New documentoAnticipo

            docAnticipo.idDocumento = obj.doc.idDocumento
            docAnticipo.idEmpresa = obj.doc.idEmpresa
            docAnticipo.idEstablecimiento = obj.doc.idEstablecimiento
            docAnticipo.tipoDocumento = obj.doc.tipoDocumento
            docAnticipo.numeroDoc = obj.doc.numeroDoc
            docAnticipo.fechaDoc = obj.doc.fechaDoc
            docAnticipo.fechaPeriodo = obj.doc.fechaPeriodo
            docAnticipo.tipoOperacion = obj.doc.tipoOperacion
            docAnticipo.tipoAnticipo = obj.doc.tipoAnticipo
            docAnticipo.NombreEntidad = obj.entidad.nombreCompleto
            docAnticipo.TipoCambio = obj.doc.TipoCambio
            docAnticipo.Moneda = obj.doc.Moneda
            docAnticipo.importeMN = obj.doc.importeMN
            docAnticipo.importeME = obj.doc.importeME
            docAnticipo.NombreEstadoFinanciero = obj.compra.descripcion
            docAnticipo.usuarioModificacion = obj.doc.usuarioModificacion
            docAnticipo.fechaActualizacion = obj.doc.fechaActualizacion
            Lista.Add(docAnticipo)
        Next
        Return Lista
    End Function

    Public Function UbicarAnticipoPorProveedorNroVoucher(intIdProveedor As Integer) As documentoAnticipo

        Dim objdocumentoAnticipo As New documentoAnticipo
        Dim totals3 = Aggregate p In HeliosData.documentoAnticipo
                             Where p.razonSocial = intIdProveedor
             Into ncn = Sum(p.importeMN),
                  nce = Sum(p.importeME)

        Dim totalCajaProveedor = Aggregate p In HeliosData.documentoAnticipoDetalle
                             Where p.codigoOperacion = "103" _
                             And p.idDocumento = intIdProveedor
                Into totalMN = Sum(p.importeMN),
                         totalME = Sum(p.importeME)

        If (Not IsNothing(totalCajaProveedor.totalMN)) Then
            With objdocumentoAnticipo
                .importeMN = totals3.ncn - totalCajaProveedor.totalMN
                .importeME = totals3.nce - totalCajaProveedor.totalME
            End With
        Else
            With objdocumentoAnticipo
                .importeMN = totals3.ncn
                .importeME = totals3.nce
            End With
        End If

        Return objdocumentoAnticipo
    End Function

    Public Function Insert(ByVal documentoAnticipoBE As documentoAnticipo) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoAnticipo.Add(documentoAnticipoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoAnticipoBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoAnticipoBE As documentoAnticipo)
        Using ts As New TransactionScope
            Dim docAnticipo As documentoAnticipo = HeliosData.documentoAnticipo.Where(Function(o) _
                                            o.idDocumento = documentoAnticipoBE.idDocumento).First()

            docAnticipo.idEmpresa = documentoAnticipoBE.idEmpresa
            docAnticipo.idEstablecimiento = documentoAnticipoBE.idEstablecimiento
            docAnticipo.tipoDocumento = documentoAnticipoBE.tipoDocumento
            docAnticipo.numeroDoc = documentoAnticipoBE.numeroDoc
            docAnticipo.fechaDoc = documentoAnticipoBE.fechaDoc
            docAnticipo.fechaPeriodo = documentoAnticipoBE.fechaPeriodo
            docAnticipo.tipoOperacion = documentoAnticipoBE.tipoOperacion
            docAnticipo.tipoAnticipo = documentoAnticipoBE.tipoAnticipo
            docAnticipo.razonSocial = documentoAnticipoBE.razonSocial
            docAnticipo.TipoCambio = documentoAnticipoBE.TipoCambio
            docAnticipo.Moneda = documentoAnticipoBE.Moneda
            docAnticipo.importeMN = documentoAnticipoBE.importeMN
            docAnticipo.importeME = documentoAnticipoBE.importeME
            docAnticipo.idEntidadFinanciera = documentoAnticipoBE.idEntidadFinanciera
            docAnticipo.usuarioModificacion = documentoAnticipoBE.usuarioModificacion
            docAnticipo.fechaActualizacion = documentoAnticipoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docAnticipo).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertSingleAnticipo(ByVal documentoAnticipoBE As documentoAnticipo, intIdDocumento As Integer)
        Dim docAnticipo As New documentoAnticipo
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer
        Using ts As New TransactionScope
            docAnticipo.idDocumento = intIdDocumento
            docAnticipo.idEmpresa = documentoAnticipoBE.idEmpresa
            docAnticipo.idEstablecimiento = documentoAnticipoBE.idEstablecimiento
            docAnticipo.tipoDocumento = documentoAnticipoBE.tipoDocumento
            cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentoAnticipoBE.IdNumeracion))
            docAnticipo.numeroDoc = cval
            docAnticipo.fechaDoc = documentoAnticipoBE.fechaDoc
            docAnticipo.fechaPeriodo = documentoAnticipoBE.fechaPeriodo
            docAnticipo.tipoOperacion = documentoAnticipoBE.tipoOperacion
            docAnticipo.tipoAnticipo = documentoAnticipoBE.tipoAnticipo
            docAnticipo.razonSocial = documentoAnticipoBE.razonSocial
            docAnticipo.TipoCambio = documentoAnticipoBE.TipoCambio
            docAnticipo.Moneda = documentoAnticipoBE.Moneda
            docAnticipo.baseImponible = documentoAnticipoBE.baseImponible
            docAnticipo.iva = documentoAnticipoBE.iva
            docAnticipo.importeMN = documentoAnticipoBE.importeMN
            docAnticipo.importeME = documentoAnticipoBE.importeME
            docAnticipo.idEntidadFinanciera = documentoAnticipoBE.idEntidadFinanciera
            docAnticipo.estado = documentoAnticipoBE.estado
            docAnticipo.usuarioModificacion = documentoAnticipoBE.usuarioModificacion
            docAnticipo.fechaActualizacion = documentoAnticipoBE.fechaActualizacion

            HeliosData.documentoAnticipo.Add(docAnticipo)
            HeliosData.SaveChanges()
            ts.Complete()
            '   documentocompraBE.idDocumento = docCompra.idDocumento
        End Using
    End Sub

    Public Sub UpdateSingleAnticipo(ByVal documentoAnticipoBE As documentoAnticipo, ByVal idDocumento As Integer)
        Using ts As New TransactionScope
            Dim docAnticipo As documentoAnticipo = HeliosData.documentoAnticipo.Where(Function(o) _
                                            o.idDocumento = idDocumento).First()

            docAnticipo.idEmpresa = documentoAnticipoBE.idEmpresa
            docAnticipo.idEstablecimiento = documentoAnticipoBE.idEstablecimiento
            docAnticipo.tipoDocumento = documentoAnticipoBE.tipoDocumento
            'docAnticipo.numeroDoc = documentoAnticipoBE.numeroDoc
            docAnticipo.fechaDoc = documentoAnticipoBE.fechaDoc
            docAnticipo.fechaPeriodo = documentoAnticipoBE.fechaPeriodo
            docAnticipo.tipoOperacion = documentoAnticipoBE.tipoOperacion
            docAnticipo.tipoAnticipo = documentoAnticipoBE.tipoAnticipo
            docAnticipo.razonSocial = documentoAnticipoBE.razonSocial
            docAnticipo.TipoCambio = documentoAnticipoBE.TipoCambio
            docAnticipo.Moneda = documentoAnticipoBE.Moneda
            docAnticipo.importeMN = documentoAnticipoBE.importeMN
            docAnticipo.importeME = documentoAnticipoBE.importeME
            docAnticipo.idEntidadFinanciera = documentoAnticipoBE.idEntidadFinanciera
            docAnticipo.usuarioModificacion = documentoAnticipoBE.usuarioModificacion
            docAnticipo.fechaActualizacion = documentoAnticipoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docAnticipo).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
    Public Sub Delete(ByVal documentoAnticipoBE As documentoAnticipo)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoAnticipoBE)
    End Sub

    Public Function getTableAnticiposPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoAnticipo)
        Dim docAnticipo As New documentoAnticipo
        Dim Lista As New List(Of documentoAnticipo)

        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join compra In HeliosData.estadosFinancieros
                      On doc.idEntidadFinanciera Equals compra.idestado
                        Join entidad In HeliosData.entidad
                      On doc.razonSocial Equals entidad.idEntidad
                        Where doc.idEmpresa = strIdEmpresa And
                      doc.idEstablecimiento = intIdEstablecimiento _
                     And doc.fechaPeriodo = strPeriodo).ToList

        For Each obj In consulta
            docAnticipo = New documentoAnticipo

            docAnticipo.idDocumento = obj.doc.idDocumento
            docAnticipo.idEmpresa = obj.doc.idEmpresa
            docAnticipo.idEstablecimiento = obj.doc.idEstablecimiento
            docAnticipo.tipoDocumento = obj.doc.tipoDocumento
            docAnticipo.numeroDoc = obj.doc.numeroDoc
            docAnticipo.fechaDoc = obj.doc.fechaDoc
            docAnticipo.fechaPeriodo = obj.doc.fechaPeriodo
            docAnticipo.tipoOperacion = obj.doc.tipoOperacion
            docAnticipo.tipoAnticipo = obj.doc.tipoAnticipo
            docAnticipo.NombreEntidad = obj.entidad.nombreCompleto
            docAnticipo.TipoCambio = obj.doc.TipoCambio
            docAnticipo.Moneda = obj.doc.Moneda
            docAnticipo.importeMN = obj.doc.importeMN
            docAnticipo.importeME = obj.doc.importeME
            docAnticipo.NombreEstadoFinanciero = obj.compra.descripcion
            docAnticipo.usuarioModificacion = obj.doc.usuarioModificacion
            docAnticipo.fechaActualizacion = obj.doc.fechaActualizacion
            Lista.Add(docAnticipo)
        Next
        Return Lista
    End Function

    Public Function GetUbicar_documentoAnticipoPorID(idDocumento As Integer) As documentoAnticipo
        Return (From a In HeliosData.documentoAnticipo
                Where a.idDocumento = idDocumento Select a).First
    End Function


    Public Function SaveAnticipoSL(objDocumento As documento, objDocumentoCaja As documento) As Integer
        Dim DocumentoBL As New documentoBL
        Dim compraDetalleBL As New documentoAnticipoDetalleBL
        Dim asientoBL As New AsientoBL
        Dim CajaUsuarioBL As New CajaUsuarioBL

        Try
            Using ts As New TransactionScope()

                DocumentoBL.Insert(objDocumento)

                Select Case objDocumento.documentoAnticipo.TipoConfiguracion
                    Case "M"
                        Me.InsertSingleAnticipo(objDocumento.documentoAnticipo, objDocumento.idDocumento)
                    Case "P"
                        Me.InsertSingleAnticipo(objDocumento.documentoAnticipo, objDocumento.idDocumento)
                End Select

                'For Each i In objDocumento.documentoAnticipo.documentoAnticipoDetalle
                '    compraDetalleBL.InsertSingleAnticipo(i, objDocumento.idDocumento)
                'Next
                asientoBL.SavebyGroupDoc(objDocumento)
                SaveCajaME(objDocumentoCaja, objDocumento.idDocumento)

                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumento.idDocumento

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveAnticipo(be As documento) As documentoAnticipo
        Dim DocumentoBL As New documentoBL
        Dim compraDetalleBL As New documentoAnticipoDetalleBL
        Dim asientoBL As New AsientoBL
        Dim CajaUsuarioBL As New CajaUsuarioBL

        Try
            Using ts As New TransactionScope()
                DocumentoBL.Insert(be)
                Select Case be.documentoAnticipo.TipoConfiguracion
                    Case "M"
                        Me.InsertSingleAnticipo(be.documentoAnticipo, be.idDocumento)
                    Case "P"
                        Me.InsertSingleAnticipo(be.documentoAnticipo, be.idDocumento)
                End Select
                asientoBL.SavebyGroupDoc(be)
                SaveCaja(be.CustomDocumentoCaja, be.idDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
                Return be.documentoAnticipo
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateAnticipoSL(objDocumento As documento, objDocumentoCaja As documento)
        Dim DocumentoBL As New documentoBL
        Dim compraDetalleBL As New documentoAnticipoDetalleBL
        Dim inventario As New InventarioMovimientoBL
        Dim asientoBL As New AsientoBL
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL

        Try
            Using ts As New TransactionScope()

                Dim nID = (From n In HeliosData.documentoAnticipo
                           Where n.idDocumento = objDocumento.idDocumento).First

                DocumentoBL.Update(objDocumento)
                Me.UpdateSingleAnticipo(objDocumento.documentoAnticipo, objDocumento.idDocumento)

                asientoBL.DeleteGroup(objDocumento.idDocumento)


                'For Each i In objDocumento.documentoAnticipo.documentoAnticipoDetalle
                '    compraDetalleBL.UpdateSingleAnticipo(i, objDocumento.idDocumento)
                'Next
                DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(objDocumento.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
                asientoBL.SavebyGroupDoc(objDocumento)
                SaveCaja(objDocumentoCaja, objDocumento.idDocumento)

                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveCaja(nCaja As documento, intIdCompra As Integer)
        Dim DocumentoBL As New documentoBL
        Dim documentoCajaBL As New documentoCajaBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        DocumentoBL.Insert(nCaja)
        documentoCajaBL.Insert(nCaja.documentoCaja, nCaja.idDocumento)
        documentoCajaDetalleBL.Insert(nCaja, nCaja.idDocumento, intIdCompra)
    End Sub

    Private Sub SaveCajaME(nCaja As documento, intIdCompra As Integer)
        Dim DocumentoBL As New documentoBL
        Dim documentoCajaBL As New documentoCajaBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        DocumentoBL.Insert(nCaja)
        documentoCajaBL.Insert(nCaja.documentoCaja, nCaja.idDocumento)
        'documentoCajaDetalleBL.Insert(nCaja, nCaja.idDocumento, intIdCompra)
        documentoCajaDetalleBL.InsertCajaME(nCaja, nCaja.idDocumento, nCaja.documentoCaja.entidadFinanciera)
    End Sub

    Public Function UbicarDocumentoAnticipo(intidDocumento As Integer) As documentoAnticipo
        Return (From a In HeliosData.documentoAnticipo
                Where a.idDocumento = intidDocumento Select a).FirstOrDefault
    End Function

    Public Function ObtenerOtrosAportesXFinanzas(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipoAnticipo As String) As List(Of documentoAnticipo)
        Dim objMostrarEncaja As documentoAnticipo
        Dim ListaAnticipo As New List(Of documentoAnticipo)

        Dim listaTipo As New List(Of String)
        listaTipo.Add("AR")


        Dim consulta = (From c In HeliosData.documentoAnticipo
                        Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.idEntidadFinanciera
                        Where c.idEmpresa = strEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                        And c.razonSocial = strRuc _
                        And c.fechaPeriodo = strPeriodo _
                        And c.tipoAnticipo = tipoAnticipo).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoAnticipo
            objMostrarEncaja.idDocumento = obj.c.idDocumento
            objMostrarEncaja.idEntidadFinanciera = obj.tipo.idestado
            objMostrarEncaja.fechaDoc = obj.c.fechaDoc
            objMostrarEncaja.tipoMovimiento = obj.c.tipoAnticipo
            objMostrarEncaja.importeMN = obj.c.importeMN
            objMostrarEncaja.fechaDoc = obj.c.fechaDoc
            objMostrarEncaja.TipoCambio = obj.c.TipoCambio
            objMostrarEncaja.tipoDocumento = obj.c.tipoDocumento
            objMostrarEncaja.numeroDoc = obj.c.numeroDoc
            objMostrarEncaja.tipoAnticipo = obj.c.tipoAnticipo
            objMostrarEncaja.importeMN = obj.c.importeMN
            objMostrarEncaja.importeMN = obj.c.importeMN.GetValueOrDefault
            objMostrarEncaja.importeME = obj.c.importeME.GetValueOrDefault
            objMostrarEncaja.importeME = obj.c.importeME
            objMostrarEncaja.NombreEntidad = obj.tipo.descripcion
            objMostrarEncaja.usuarioModificacion = obj.tipo.tipo
            'If IsNothing(obj.caja.idPadre) Then

            ListaAnticipo.Add(objMostrarEncaja)
        Next
        Return ListaAnticipo
    End Function

    Public Function ObtenerOtrosAportesXFinanzasFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipoAnticipo As String) As List(Of documentoAnticipo)
        Dim objMostrarEncaja As documentoAnticipo
        Dim ListaAnticipo As New List(Of documentoAnticipo)

        Dim listaTipo As New List(Of String)
        listaTipo.Add("AR")


        Dim consulta = (From c In HeliosData.documentoAnticipo
                        Join tipo In HeliosData.estadosFinancieros
                        On tipo.idestado Equals c.idEntidadFinanciera
                        Where c.idEmpresa = strEmpresa _
                        And c.idEstablecimiento = intIdEstablecimiento _
                          And c.fechaPeriodo = strPeriodo _
                        And c.tipoAnticipo = tipoAnticipo).ToList

        For Each obj In consulta
            objMostrarEncaja = New documentoAnticipo
            objMostrarEncaja.idDocumento = obj.c.idDocumento
            objMostrarEncaja.idEntidadFinanciera = obj.tipo.idestado
            objMostrarEncaja.fechaDoc = obj.c.fechaDoc
            objMostrarEncaja.tipoMovimiento = obj.c.tipoAnticipo
            objMostrarEncaja.importeMN = obj.c.importeMN
            objMostrarEncaja.fechaDoc = obj.c.fechaDoc
            objMostrarEncaja.TipoCambio = obj.c.TipoCambio
            objMostrarEncaja.Moneda = obj.c.Moneda
            objMostrarEncaja.tipoDocumento = obj.c.tipoDocumento
            objMostrarEncaja.numeroDoc = obj.c.numeroDoc
            objMostrarEncaja.tipoAnticipo = obj.c.tipoAnticipo
            objMostrarEncaja.importeMN = obj.c.importeMN
            objMostrarEncaja.importeMN = obj.c.importeMN.GetValueOrDefault
            objMostrarEncaja.importeME = obj.c.importeME.GetValueOrDefault
            objMostrarEncaja.importeME = obj.c.importeME
            objMostrarEncaja.NombreEntidad = obj.tipo.descripcion
            objMostrarEncaja.usuarioModificacion = obj.tipo.tipo
            'If IsNothing(obj.caja.idPadre) Then

            ListaAnticipo.Add(objMostrarEncaja)
        Next
        Return ListaAnticipo
    End Function

#Region "REstaurant"
    Public Function GetAnticipoRecibidosStatusAllXCliente(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        GetAnticipoRecibidosStatusAllXCliente = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoventaAbarrotes
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.idCliente
                        Group Join nota In HeliosData.documentoAnticipoConciliacion
                            On nota.idDocumento Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoVenta = be.tipoVenta And doc.estadoCobro = be.estadoCobro And
                            doc.idCliente = be.idCliente
                        Group c By
                            doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.serie,
                            doc.numeroDocNormal,
                            doc.serieVenta,
                            doc.numeroVenta,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            doc.ImporteNacional,
                            doc.ImporteExtranjero,
                            doc.estadoCobro
                            Into g = Group
                        Select New With
                            {
                             idDocumento,
                             numeroDoc,
                             fechaDoc,
                            serie,
                             serieVenta,
                            numeroVenta,
                            numeroDocNormal,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            ImporteNacional,
                            ImporteExtranjero,
                            estadoCobro,
                            g, .sumaNotas = g.Sum(Function(c) c.importe)
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.numeroDoc = $"{i.serie}-{i.numeroDocNormal}"
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.importeMN = i.ImporteNacional
            obj.importeME = i.ImporteExtranjero
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.estado = i.estadoCobro
            GetAnticipoRecibidosStatusAllXCliente.Add(obj)
        Next
    End Function

    Public Function GetANTReclamacionesPeriodoXCliente(be As documentoAnticipo) As List(Of documentoAnticipo)

        Dim lista As New List(Of String)
        lista.Add(Anticipo.Estado.NotaCredito)
        lista.Add(Anticipo.Estado.NotaCreditoParcial)

        GetANTReclamacionesPeriodoXCliente = New List(Of documentoAnticipo)
        Dim obj As documentoAnticipo
        Dim consulta = (From doc In HeliosData.documentoAnticipo
                        Join det In HeliosData.documentoCajaDetalle
                              On det.documentoAfectado Equals doc.idDocumento
                        Join ent In HeliosData.entidad
                              On ent.idEntidad Equals doc.razonSocial
                        Group Join nota In HeliosData.documentocompra
                            On nota.idPadre Equals doc.idDocumento
                            Into ords = Group
                        From c In ords.DefaultIfEmpty
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            doc.idEstablecimiento = be.idEstablecimiento And
                            doc.tipoAnticipo = be.tipoAnticipo And
                            doc.fechaDoc.Value.Year = be.fechaDoc.Value.Year And
                            doc.fechaDoc.Value.Month = be.fechaDoc.Value.Month And
                             lista.Contains(doc.estado) And
                            doc.razonSocial = be.razonSocial
                        Group c By
                                doc.idDocumento,
                            doc.numeroDoc,
                            doc.fechaDoc,
                            doc.tipoAnticipo,
                            ent.idEntidad,
                            ent.tipoEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            det.documentoCaja.formapago,
                            doc.importeMN,
                            doc.importeME
                            Into g = Group
                        Select New With
                            {
                            idDocumento,
                            numeroDoc,
                            fechaDoc,
                            tipoAnticipo,
                            idEntidad,
                            tipoEntidad,
                            nombreCompleto,
                            nrodoc,
                            formapago,
                            importeMN,
                            importeME,
                            g, .sumaNotas = g.Sum(Function(c) c.importeTotal),
                            .ConteoNotas = g.Count()
                            }).ToList

        For Each i In consulta
            obj = New documentoAnticipo
            obj.idDocumento = i.idDocumento
            obj.numeroDoc = i.numeroDoc
            obj.fechaDoc = i.fechaDoc
            obj.tipoAnticipo = i.tipoAnticipo
            obj.CustomEntidad = New entidad With
                    {
                    .idEntidad = i.idEntidad,
                    .tipoEntidad = i.tipoEntidad,
                    .nombreCompleto = i.nombreCompleto,
                    .nrodoc = i.nrodoc
                    }
            obj.formaPago = i.formapago
            obj.importeMN = i.importeMN
            obj.importeME = i.importeME
            obj.TotalNotas = i.sumaNotas.GetValueOrDefault
            obj.ConteoNota = i.ConteoNotas
            GetANTReclamacionesPeriodoXCliente.Add(obj)
        Next
    End Function


#End Region

End Class
