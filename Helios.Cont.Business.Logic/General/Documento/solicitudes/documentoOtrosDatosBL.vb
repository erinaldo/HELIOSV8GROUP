Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoOtrosDatosBL
    Inherits BaseBL

    Public Sub UpdateOtrosServicios(ByVal documentoOtrosDatosBE As documentoOtrosDatos)

        Using ts As New TransactionScope
            Dim doc As documentoOtrosDatos = HeliosData.documentoOtrosDatos.Where(Function(o) _
                                            o.idReferencia = documentoOtrosDatosBE.idReferencia).First()

            doc.fechaInicio = documentoOtrosDatosBE.fechaInicio
            doc.fechaFin = documentoOtrosDatosBE.fechaFin
            doc.FechaIniGarantia = documentoOtrosDatosBE.FechaIniGarantia
            doc.FechaFinGarantia = documentoOtrosDatosBE.FechaFinGarantia
            doc.notas = documentoOtrosDatosBE.notas
            doc.indicaciones = documentoOtrosDatosBE.indicaciones
            doc.idEmpresa = documentoOtrosDatosBE.idEmpresa
            doc.condicionPago = documentoOtrosDatosBE.condicionPago
            doc.Vcto = documentoOtrosDatosBE.Vcto
            doc.Modalidad = documentoOtrosDatosBE.Modalidad
            doc.ctaDeposito = documentoOtrosDatosBE.ctaDeposito
            doc.institucionFinanciera = documentoOtrosDatosBE.institucionFinanciera
            doc.estado = documentoOtrosDatosBE.estado
            doc.fechaActualizacion = documentoOtrosDatosBE.fechaActualizacion
            doc.usuarioActualizacion = documentoOtrosDatosBE.usuarioActualizacion
            doc.CentroCostos = documentoOtrosDatosBE.CentroCostos
            doc.idAlmacen = documentoOtrosDatosBE.idAlmacen
            doc.moneda = documentoOtrosDatosBE.moneda
            doc.objetoContratacion = documentoOtrosDatosBE.objetoContratacion
            doc.periodoValorizacion = documentoOtrosDatosBE.periodoValorizacion
            doc.penalidades = documentoOtrosDatosBE.penalidades
            doc.importeContratacionMN = documentoOtrosDatosBE.importeContratacionMN
            doc.adelantoMN = documentoOtrosDatosBE.adelantoMN
            doc.detraccionesMN = documentoOtrosDatosBE.detraccionesMN
            doc.fondoGarantiaMN = documentoOtrosDatosBE.fondoGarantiaMN
            doc.importeContratacionME = documentoOtrosDatosBE.importeContratacionME
            doc.adelantoME = documentoOtrosDatosBE.adelantoME
            doc.detraccionesME = documentoOtrosDatosBE.detraccionesME
            doc.fondoGarantiaME = documentoOtrosDatosBE.fondoGarantiaME
            doc.cantidad = documentoOtrosDatosBE.cantidad
            'HeliosData.ObjectStateManager.GetObjectStateEntry(doc).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub UpdateOtros(ByVal documentoOtrosDatosBE As documentoOtrosDatos)

        Using ts As New TransactionScope
            Dim doc As documentoOtrosDatos = HeliosData.documentoOtrosDatos.Where(Function(o) _
                                            o.idReferencia = documentoOtrosDatosBE.idReferencia).First()

            doc.fechaInicio = documentoOtrosDatosBE.fechaInicio
            doc.fechaFin = documentoOtrosDatosBE.fechaFin
            doc.FechaIniGarantia = documentoOtrosDatosBE.FechaIniGarantia
            doc.FechaFinGarantia = documentoOtrosDatosBE.FechaFinGarantia
            doc.notas = documentoOtrosDatosBE.notas
            doc.indicaciones = documentoOtrosDatosBE.indicaciones
            doc.idEmpresa = documentoOtrosDatosBE.idEmpresa
            doc.condicionPago = documentoOtrosDatosBE.condicionPago
            doc.Vcto = documentoOtrosDatosBE.Vcto
            doc.Modalidad = documentoOtrosDatosBE.Modalidad
            doc.ctaDeposito = documentoOtrosDatosBE.ctaDeposito
            doc.institucionFinanciera = documentoOtrosDatosBE.institucionFinanciera
            doc.estado = documentoOtrosDatosBE.estado
            doc.fechaActualizacion = documentoOtrosDatosBE.fechaActualizacion
            doc.usuarioActualizacion = documentoOtrosDatosBE.usuarioActualizacion
            doc.CentroCostos = documentoOtrosDatosBE.CentroCostos
            doc.idAlmacen = documentoOtrosDatosBE.idAlmacen
            doc.moneda = documentoOtrosDatosBE.moneda
            doc.objetoContratacion = documentoOtrosDatosBE.objetoContratacion
            doc.periodoValorizacion = documentoOtrosDatosBE.periodoValorizacion
            doc.penalidades = documentoOtrosDatosBE.penalidades
            doc.importeContratacionMN = documentoOtrosDatosBE.importeContratacionMN
            doc.adelantoMN = documentoOtrosDatosBE.adelantoMN
            doc.detraccionesMN = documentoOtrosDatosBE.detraccionesMN
            doc.fondoGarantiaMN = documentoOtrosDatosBE.fondoGarantiaMN
            doc.importeContratacionME = documentoOtrosDatosBE.importeContratacionME
            doc.adelantoME = documentoOtrosDatosBE.adelantoME
            doc.detraccionesME = documentoOtrosDatosBE.detraccionesME
            doc.fondoGarantiaME = documentoOtrosDatosBE.fondoGarantiaME
            doc.cantidad = documentoOtrosDatosBE.cantidad
            'HeliosData.ObjectStateManager.GetObjectStateEntry(doc).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub InsertOrdenDetalle(ByVal documentoOtrosDatosBE As documentoOtrosDatos, ByVal documentoCompraDeatlle As documentocompradetalle)
        Dim docCompra As New documentoOtrosDatos
        Dim docCompraDetalle As New documentocompradetalleBL

        Using ts As New TransactionScope

            docCompra.idDocumento = documentoOtrosDatosBE.idDocumento
            docCompra.fechaInicio = documentoOtrosDatosBE.fechaInicio
            docCompra.fechaFin = documentoOtrosDatosBE.fechaFin
            docCompra.FechaIniGarantia = documentoOtrosDatosBE.FechaIniGarantia
            docCompra.FechaFinGarantia = documentoOtrosDatosBE.FechaFinGarantia
            docCompra.notas = documentoOtrosDatosBE.notas
            docCompra.idEmpresa = documentoOtrosDatosBE.idEmpresa
            docCompra.indicaciones = documentoOtrosDatosBE.indicaciones
            docCompra.condicionPago = documentoOtrosDatosBE.condicionPago
            docCompra.Vcto = documentoOtrosDatosBE.Vcto
            docCompra.Modalidad = documentoOtrosDatosBE.Modalidad
            docCompra.ctaDeposito = documentoOtrosDatosBE.ctaDeposito
            docCompra.institucionFinanciera = documentoOtrosDatosBE.institucionFinanciera
            docCompra.estado = documentoOtrosDatosBE.estado
            docCompra.fechaActualizacion = documentoOtrosDatosBE.fechaActualizacion
            docCompra.usuarioActualizacion = documentoOtrosDatosBE.usuarioActualizacion
            docCompra.CentroCostos = documentoOtrosDatosBE.CentroCostos
            docCompra.idAlmacen = documentoOtrosDatosBE.idAlmacen
            docCompra.moneda = documentoOtrosDatosBE.moneda
            docCompra.objetoContratacion = documentoOtrosDatosBE.objetoContratacion
            docCompra.periodoValorizacion = documentoOtrosDatosBE.periodoValorizacion
            docCompra.penalidades = documentoOtrosDatosBE.penalidades
            docCompra.importeContratacionMN = documentoOtrosDatosBE.importeContratacionMN
            docCompra.importeContratacionME = documentoOtrosDatosBE.importeContratacionME
            docCompra.adelantoMN = documentoOtrosDatosBE.adelantoMN
            docCompra.adelantoME = documentoOtrosDatosBE.adelantoME
            docCompra.detraccionesMN = documentoOtrosDatosBE.detraccionesMN
            docCompra.detraccionesME = documentoOtrosDatosBE.detraccionesME
            docCompra.fondoGarantiaMN = documentoOtrosDatosBE.fondoGarantiaMN
            docCompra.fondoGarantiaME = documentoOtrosDatosBE.fondoGarantiaME
            docCompra.idReferencia = documentoOtrosDatosBE.idReferencia
            docCompra.idItem = documentoOtrosDatosBE.idItem
            docCompra.cantidad = documentoOtrosDatosBE.cantidad
            docCompraDetalle.UpdateSingleDocOrden(documentoCompraDeatlle)

            HeliosData.documentoOtrosDatos.Add(docCompra)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

  Public Sub Insert(ByVal documentoOtrosDatosBE As documentoOtrosDatos, intIdDocumento As Integer)
        Dim docCompra As New documentoOtrosDatos
        Dim docCompraDetalle As New documentocompradetalleBL
        Using ts As New TransactionScope


            docCompra = New documentoOtrosDatos
            docCompra.idDocumento = intIdDocumento
            docCompra.fechaInicio = documentoOtrosDatosBE.fechaInicio
            docCompra.fechaFin = documentoOtrosDatosBE.fechaFin
            docCompra.idEmpresa = documentoOtrosDatosBE.idEmpresa
            docCompra.FechaIniGarantia = documentoOtrosDatosBE.FechaIniGarantia
            docCompra.FechaFinGarantia = documentoOtrosDatosBE.FechaFinGarantia
            docCompra.notas = documentoOtrosDatosBE.notas
            docCompra.indicaciones = documentoOtrosDatosBE.indicaciones
            docCompra.condicionPago = documentoOtrosDatosBE.condicionPago
            docCompra.Vcto = documentoOtrosDatosBE.Vcto
            docCompra.Modalidad = documentoOtrosDatosBE.Modalidad
            docCompra.ctaDeposito = documentoOtrosDatosBE.ctaDeposito
            docCompra.institucionFinanciera = documentoOtrosDatosBE.institucionFinanciera
            docCompra.estado = documentoOtrosDatosBE.estado
            docCompra.fechaActualizacion = documentoOtrosDatosBE.fechaActualizacion
            docCompra.usuarioActualizacion = documentoOtrosDatosBE.usuarioActualizacion
            docCompra.CentroCostos = documentoOtrosDatosBE.CentroCostos
            docCompra.idAlmacen = documentoOtrosDatosBE.idAlmacen
            docCompra.moneda = documentoOtrosDatosBE.moneda
            docCompra.objetoContratacion = documentoOtrosDatosBE.objetoContratacion
            docCompra.periodoValorizacion = documentoOtrosDatosBE.periodoValorizacion
            docCompra.penalidades = documentoOtrosDatosBE.penalidades
            docCompra.idReferencia = documentoOtrosDatosBE.idReferencia
            docCompra.importeContratacionMN = documentoOtrosDatosBE.importeContratacionMN
            docCompra.adelantoMN = documentoOtrosDatosBE.adelantoMN
            docCompra.detraccionesMN = documentoOtrosDatosBE.detraccionesMN
            docCompra.fondoGarantiaMN = documentoOtrosDatosBE.fondoGarantiaMN
            docCompra.importeContratacionME = documentoOtrosDatosBE.importeContratacionME
            docCompra.adelantoME = documentoOtrosDatosBE.adelantoME
            docCompra.detraccionesME = documentoOtrosDatosBE.detraccionesME
            docCompra.fondoGarantiaME = documentoOtrosDatosBE.fondoGarantiaME
            docCompra.idItem = documentoOtrosDatosBE.idItem
            docCompra.cantidad = documentoOtrosDatosBE.cantidad
            HeliosData.documentoOtrosDatos.Add(docCompra)

            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Function GetUbicar_documentocompraPorIDReferencia(idDocumento As Integer) As documentoOtrosDatos
        Return (From a In HeliosData.documentoOtrosDatos
                 Where a.idReferencia = idDocumento).FirstOrDefault
    End Function

    Public Function GetUbicar_documentocompraID(idDocumento As Integer) As documentoOtrosDatos
        Return (From a In HeliosData.documentoOtrosDatos
                 Where a.idDocumento = idDocumento).FirstOrDefault
    End Function

    Public Sub InsertServicio(ByVal documentoOtrosDatosBE As documentoOtrosDatos, intIdDocumento As Integer, intIdDocumentoRef As Integer)
        Dim docCompra As New documentoOtrosDatos

        Using ts As New TransactionScope


            docCompra.idDocumento = intIdDocumento
            docCompra.fechaInicio = documentoOtrosDatosBE.fechaInicio
            docCompra.fechaFin = documentoOtrosDatosBE.fechaFin
            docCompra.FechaIniGarantia = documentoOtrosDatosBE.FechaIniGarantia
            docCompra.FechaFinGarantia = documentoOtrosDatosBE.FechaFinGarantia
            docCompra.notas = documentoOtrosDatosBE.notas
            docCompra.indicaciones = documentoOtrosDatosBE.indicaciones
            docCompra.condicionPago = documentoOtrosDatosBE.condicionPago
            docCompra.Vcto = documentoOtrosDatosBE.Vcto
            docCompra.Modalidad = documentoOtrosDatosBE.Modalidad
            docCompra.ctaDeposito = documentoOtrosDatosBE.ctaDeposito
            docCompra.institucionFinanciera = documentoOtrosDatosBE.institucionFinanciera
            docCompra.estado = documentoOtrosDatosBE.estado
            docCompra.fechaActualizacion = documentoOtrosDatosBE.fechaActualizacion
            docCompra.usuarioActualizacion = documentoOtrosDatosBE.usuarioActualizacion
            docCompra.CentroCostos = documentoOtrosDatosBE.CentroCostos
            docCompra.idAlmacen = documentoOtrosDatosBE.idAlmacen
            docCompra.moneda = documentoOtrosDatosBE.moneda
            docCompra.objetoContratacion = documentoOtrosDatosBE.objetoContratacion
            docCompra.periodoValorizacion = documentoOtrosDatosBE.periodoValorizacion
            docCompra.penalidades = documentoOtrosDatosBE.penalidades
            docCompra.idReferencia = documentoOtrosDatosBE.idReferencia
            docCompra.importeContratacionMN = documentoOtrosDatosBE.importeContratacionMN
            docCompra.adelantoMN = documentoOtrosDatosBE.adelantoMN
            docCompra.detraccionesMN = documentoOtrosDatosBE.detraccionesMN
            docCompra.fondoGarantiaMN = documentoOtrosDatosBE.fondoGarantiaMN
            docCompra.importeContratacionME = documentoOtrosDatosBE.importeContratacionME
            docCompra.adelantoME = documentoOtrosDatosBE.adelantoME
            docCompra.detraccionesME = documentoOtrosDatosBE.detraccionesME
            docCompra.fondoGarantiaME = documentoOtrosDatosBE.fondoGarantiaME
            docCompra.idItem = documentoOtrosDatosBE.idItem
            docCompra.cantidad = documentoOtrosDatosBE.cantidad
            HeliosData.documentoOtrosDatos.Add(docCompra)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Sub GrabarDatosEntregaOrdenesFull(ByVal documentoOtrosDatosBE As List(Of documentoOtrosDatos), intIdDocumento As Integer)
        Dim docCompra As New documentoOtrosDatos
        Dim docCompraDetalle As New documentocompradetalleBL

        Using ts As New TransactionScope

            For Each i In documentoOtrosDatosBE


                Dim consulta = (From compra In HeliosData.documentocompradetalle _
                        Group Join cab In HeliosData.documentoOtrosDatos _
                       On compra.secuencia Equals cab.idReferencia _
                       Into ords = Group _
                      From e In ords.DefaultIfEmpty _
                       Where compra.secuencia = i.idReferencia _
                              Group e By _
                              compra.secuencia
                              Into g = Group _
                              Select New With {
                                 g, .cantidad = g.Sum(Function(cab) cab.cantidad)}).FirstOrDefault

                docCompra = New documentoOtrosDatos
                If (IsNothing(consulta.cantidad)) Then
                    docCompra.cantidad = CInt(i.cantidad)
                Else
                    docCompra.cantidad = CInt(i.cantidad - consulta.cantidad)
                End If
                If (docCompra.cantidad > 0) Then
                    docCompra.idDocumento = i.idDocumento
                    docCompra.fechaInicio = i.fechaInicio
                    docCompra.fechaFin = i.fechaFin
                    docCompra.FechaIniGarantia = i.FechaIniGarantia
                    docCompra.FechaFinGarantia = i.FechaFinGarantia
                    docCompra.notas = i.notas
                    docCompra.indicaciones = i.indicaciones
                    docCompra.condicionPago = i.condicionPago
                    docCompra.Vcto = i.Vcto
                    docCompra.Modalidad = i.Modalidad
                    docCompra.ctaDeposito = i.ctaDeposito
                    docCompra.institucionFinanciera = i.institucionFinanciera
                    docCompra.estado = i.estado
                    docCompra.fechaActualizacion = i.fechaActualizacion
                    docCompra.usuarioActualizacion = i.usuarioActualizacion
                    docCompra.CentroCostos = i.CentroCostos
                    docCompra.idAlmacen = i.idAlmacen
                    docCompra.moneda = i.moneda
                    docCompra.objetoContratacion = i.objetoContratacion
                    docCompra.importeContratacionMN = i.importeContratacionMN
                    docCompra.adelantoMN = i.adelantoMN
                    docCompra.detraccionesMN = i.detraccionesMN
                    docCompra.fondoGarantiaMN = i.fondoGarantiaMN
                    docCompra.importeContratacionME = i.importeContratacionME
                    docCompra.adelantoME = i.adelantoME
                    docCompra.detraccionesME = i.detraccionesME
                    docCompra.fondoGarantiaME = i.fondoGarantiaME
                    docCompra.periodoValorizacion = i.periodoValorizacion
                    docCompra.penalidades = i.penalidades
                    docCompra.idReferencia = i.idReferencia
                    docCompra.idItem = i.idItem

                    docCompra.idItem = i.idEmpresa
                    HeliosData.documentoOtrosDatos.Add(docCompra)

                    docCompraDetalle.UpdateFullDocOrden(i.idReferencia, TIPO_COMPRA.ORDEN_APROBADO)
                End If

            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function DeleteSingleOC(idDocumento As Integer) As Boolean
        Dim docCompraDetalle As New documentocompradetalleBL
        Dim consulta = (From a In HeliosData.documentoOtrosDatos
                 Where a.secuencia = idDocumento).First
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
        docCompraDetalle.UpdateFullDocOrden(consulta.idReferencia, TIPO_COMPRA.ORDEN_COMPRA)
        HeliosData.SaveChanges()
        Return True
    End Function


    Public Function UbicarDocumentoOtrosHistorialEntrega(idDocumento As Integer) As List(Of documentoOtrosDatos)
        Dim c As New documentoOtrosDatos
        Dim listaCompra As New List(Of documentoOtrosDatos)

        Dim consulta = (From n In HeliosData.documentoOtrosDatos
                Join alm In HeliosData.almacen
                On n.idAlmacen Equals alm.idAlmacen
                 Where n.idReferencia = idDocumento).ToList

        For Each i In consulta
            c = New documentoOtrosDatos
            c.idDocumento = i.n.idDocumento
            c.secuencia = i.n.secuencia
            c.idAlmacen = i.alm.idAlmacen
            c.nombreAlmacen = i.alm.descripcionAlmacen
            c.direccionAlmacen = i.alm.direccionAlmacen
            c.fechaInicio = i.n.fechaInicio
            c.fechaFin = i.n.fechaFin
            c.FechaIniGarantia = i.n.FechaIniGarantia
            c.FechaFinGarantia = i.n.FechaFinGarantia
            c.cantidad = i.n.cantidad
            c.idItem = i.n.idItem
            c.FechaFinGarantia = i.n.FechaFinGarantia
            c.indicaciones = i.n.indicaciones
            c.notas = i.n.notas
            listaCompra.Add(c)

        Next
        Return listaCompra
    End Function

    Public Function DeleteFullOrdenCompra(idDocumento As Integer) As Boolean
        Dim consulta = (From a In HeliosData.documentoOtrosDatos
                 Where a.idDocumento = idDocumento).ToList
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
        HeliosData.SaveChanges()
        Return True
    End Function

End Class
