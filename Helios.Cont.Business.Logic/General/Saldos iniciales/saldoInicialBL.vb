Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class saldoInicialBL
    Inherits BaseBL

    Public Function SaldosXpagarXproveedor(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdProveedor As Integer) As List(Of saldoInicio)
        Dim saldoInicioBE As New saldoInicio
        Dim lista As New List(Of saldoInicio)
        Try
            Dim con = (From n In HeliosData.saldoInicio _
                           Join det In HeliosData.saldoInicioDetalle _
                           On n.idDocumento Equals det.idDocumento _
                           Where det.modulo = "PR" _
                           And n.idEmpresa = strEmpresa And n.idCentroCosto = intIdEstablecimiento And
                           n.periodo = strPeriodo And det.idModulo = intIdProveedor).ToList

            For Each i In con
                saldoInicioBE = New saldoInicio
                saldoInicioBE.idDocumento = i.n.idDocumento
                saldoInicioBE.fechaDoc = i.n.fechaDoc
                saldoInicioBE.tipoDoc = i.n.tipoDoc
                saldoInicioBE.numeroDoc = i.n.numeroDoc
                saldoInicioBE.NomEntidad = i.det.idModulo
                saldoInicioBE.importeTotal = i.det.importe
                saldoInicioBE.importeUS = i.det.importeUS
                saldoInicioBE.periodo = i.n.periodo
                lista.Add(saldoInicioBE)
            Next

        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function

    Public Function Insert(saldoBE As saldoInicio, intIdDocumento As Integer) As Integer
        Dim saldo As New saldoInicio
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer
        Using ts As New TransactionScope()
            cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(saldoBE.IdNumeracion))
            With saldo
                .idDocumento = intIdDocumento
                .codigoLibro = saldoBE.codigoLibro
                .idEmpresa = saldoBE.idEmpresa
                .idCentroCosto = saldoBE.idCentroCosto
                .fechaDoc = saldoBE.fechaDoc
                .fechaVcto = saldoBE.fechaVcto
                .periodo = saldoBE.periodo
                .tipoDoc = saldoBE.tipoDoc
                .serie = saldoBE.serie
                .numeroDoc = cval
                .idPersona = saldoBE.idPersona
                .tipoPersona = saldoBE.tipoPersona
                .monedaDoc = saldoBE.monedaDoc
                .tasaIgv = saldoBE.tasaIgv
                .tcDolLoc = saldoBE.tcDolLoc
                .importeTotal = saldoBE.importeTotal
                .importeUS = saldoBE.importeUS
                .destino = saldoBE.destino
                .estadoPago = saldoBE.estadoPago
                .glosa = saldoBE.glosa
                .tipoCompra = saldoBE.tipoCompra
                .idPadre = saldoBE.idPadre
                .usuarioActualizacion = saldoBE.usuarioActualizacion
                .fechaActualizacion = saldoBE.fechaActualizacion
            End With
            HeliosData.saldoInicio.Add(saldo)
            HeliosData.SaveChanges()
            ts.Complete()
            saldoBE.serie = saldoBE.serie
            saldoBE.numeroDoc = cval
            Return saldo.idDocumento
        End Using
    End Function

    Public Function InsertarAporteInicio(documentoBE As documento, listaProductosAlmacen As List(Of totalesAlmacen)) As Integer
        Dim documentoBL As New documentoBL
        Dim asientoBL As New AsientoBL
        Dim saldoInicioDetalleBL As New saldoInicioDetalleBL
        Dim totalesBL As New totalesAlmacenBL
        Using ts As New TransactionScope
            documentoBL.Insert(documentoBE)
            Insert(documentoBE.saldoInicio, documentoBE.idDocumento)
            saldoInicioDetalleBL.Insert(documentoBE, documentoBE.idDocumento)
            totalesBL.SaveTotalesListaCompraPagada(listaProductosAlmacen, 0)
            asientoBL.SavebyGroupDoc(documentoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        Return documentoBE.idDocumento
    End Function


    Public Function InsertarSaldos(documentoBE As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim asientoBL As New AsientoBL
        Dim saldoInicioDetalleBL As New saldoInicioDetalleBL
        Dim totalesBL As New totalesAlmacenBL
        Using ts As New TransactionScope
            documentoBL.Insert(documentoBE)
            Insert(documentoBE.saldoInicio, documentoBE.idDocumento)
            saldoInicioDetalleBL.Insert(documentoBE, documentoBE.idDocumento)
            asientoBL.SavebyGroupDoc(documentoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        Return documentoBE.idDocumento
    End Function

    Public Function ListadoSaldosXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of saldoInicio)
        Return (From n In HeliosData.saldoInicio Where n.idEmpresa = strEmpresa And n.idCentroCosto = intIdEstablecimiento _
                And n.periodo = strPeriodo).ToList
    End Function

    Public Sub EliminarSaldoAporte(objDocumento As documento, ListaItemsAeliminar As List(Of totalesAlmacen))
        Dim documentoBL As New documentoBL
        Using ts As New TransactionScope
            documentoBL.DeleteSaldoAporte(objDocumento, ListaItemsAeliminar)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarSaldoXidDocumento(intIdDocumento As Integer) As saldoInicio
        Return (From n In HeliosData.saldoInicio Where n.idDocumento = intIdDocumento).FirstOrDefault
    End Function

End Class
