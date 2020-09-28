Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoObligacionTributariaBL
    Inherits BaseBL

    Public Function UbicarDocumentoObligacion(intIdDocumento As Integer) As documentoObligacionTributaria
        Return (From n In HeliosData.documentoObligacionTributaria _
                Where n.idDocumento = intIdDocumento).First
    End Function

    Public Sub Insert(ByVal documentocompraBE As documentoObligacionTributaria, intIdDocumento As Integer, intIdDocumentoOrigen As Integer)
        Dim docCompra As New documentoObligacionTributaria
        Using ts As New TransactionScope
            docCompra.idDocumento = intIdDocumento
            docCompra.idDocumentoOrigen = intIdDocumentoOrigen
            docCompra.codigoLibro = documentocompraBE.codigoLibro
            docCompra.idEmpresa = documentocompraBE.idEmpresa
            docCompra.idCentroCosto = documentocompraBE.idCentroCosto
            docCompra.fechaDoc = documentocompraBE.fechaDoc
            docCompra.periodo = documentocompraBE.periodo
            docCompra.tipoTributo = documentocompraBE.tipoTributo
            docCompra.tipoDoc = documentocompraBE.tipoDoc
            docCompra.serieDoc = documentocompraBE.serieDoc
            docCompra.numeroDoc = documentocompraBE.numeroDoc
            docCompra.idEntidad = documentocompraBE.idEntidad
            docCompra.tipoOperacion = documentocompraBE.tipoOperacion
            docCompra.idEntidadFinanciera = documentocompraBE.idEntidadFinanciera
            docCompra.tipoDesposito = documentocompraBE.tipoDesposito
            docCompra.moneda = documentocompraBE.moneda
            docCompra.porcTributario = documentocompraBE.porcTributario
            docCompra.tipoCambio = documentocompraBE.tipoCambio
            docCompra.importeTotal = documentocompraBE.importeTotal
            docCompra.importeUS = documentocompraBE.importeUS
            docCompra.glosa = documentocompraBE.glosa
            docCompra.usuarioActualizacion = documentocompraBE.usuarioActualizacion
            docCompra.fechaActualizacion = documentocompraBE.fechaActualizacion

            HeliosData.documentoObligacionTributaria.Add(docCompra)
            HeliosData.SaveChanges()
            ts.Complete()
            '   documentocompraBE.idDocumento = docCompra.idDocumento
        End Using
    End Sub

    Public Function SaveObligacion(objDocumento As documento, intIdDocumentoOrigen As Integer) As Integer
        Dim DocumentoBL As New documentoBL
        Dim compraDetalleBL As New documentoObligacionTributariaDetalleBL
        Dim inventario As New InventarioMovimientoBL
        Dim asientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                DocumentoBL.Insert(objDocumento)
                Me.Insert(objDocumento.documentoObligacionTributaria, objDocumento.idDocumento, intIdDocumentoOrigen)
                For Each i In objDocumento.documentoObligacionTributaria.documentoObligacionDetalle
                    compraDetalleBL.InsertSingle(i, objDocumento.idDocumento)
                Next

                Dim compra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = intIdDocumentoOrigen).FirstOrDefault
                compra.periodoTributo = objDocumento.documentoObligacionTributaria.periodo

                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveObligacionDefaultCompra(objDocumento As documento, intIdDocumentoOrigen As Integer) As Integer
        Dim DocumentoBL As New documentoBL
        Dim compraDetalleBL As New documentoObligacionTributariaDetalleBL
        Dim inventario As New InventarioMovimientoBL
        Dim asientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope()
                DocumentoBL.Insert(objDocumento)
                Me.Insert(objDocumento.documentoObligacionTributaria, objDocumento.idDocumento, intIdDocumentoOrigen)
                For Each i In objDocumento.documentoObligacionTributaria.documentoObligacionDetalle
                    compraDetalleBL.InsertSingleDefault(i, objDocumento.idDocumento, intIdDocumentoOrigen)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateTributo(objDocumento As documento, intIdDocumentoOrigen As Integer)
        Try
            Using ts As New TransactionScope()
                EliminarObligacion(objDocumento.idDocumento)
                SaveObligacion(objDocumento, intIdDocumentoOrigen)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListadoTributoPorIdDocumentoOrigen(intIdDocumentoOrigen As Integer) As List(Of documentoObligacionTributaria)
        Dim ListaObligacion As New List(Of documentoObligacionTributaria)
        Dim documentoObligacionBL As New documentoObligacionTributaria

        'Dim consulta = (From n In HeliosData.documentoObligacionTributaria _
        '                Join e In HeliosData.entidad _
        '                On e.idEntidad Equals n.idEntidad _
        '                Join doc In HeliosData.documento _
        '                On doc.idDocumento Equals n.idDocumentoOrigen _
        '                Where n.idDocumentoOrigen = intIdDocumentoOrigen).ToList

        Dim consultaDetalle = (From n In HeliosData.documentoObligacionDetalle _
                              Where n.idDocumentoOrigen = intIdDocumentoOrigen _
                              Join doc In HeliosData.documentoObligacionTributaria _
                              On doc.idDocumento Equals n.idDocumento _
                              Join e In HeliosData.entidad _
                        On e.idEntidad Equals doc.idEntidad).ToList

        For Each i In consultaDetalle
            documentoObligacionBL = New documentoObligacionTributaria
            documentoObligacionBL.idDocumento = i.doc.idDocumento
            documentoObligacionBL.fechaDoc = i.doc.fechaDoc
            documentoObligacionBL.tipoDoc = i.doc.tipoDoc
            documentoObligacionBL.serieDoc = i.doc.serieDoc
            documentoObligacionBL.numeroDoc = i.doc.numeroDoc
            documentoObligacionBL.idEntidad = i.doc.idEntidad
            documentoObligacionBL.NomProveedor = i.e.nombreCompleto
            documentoObligacionBL.moneda = i.doc.moneda
            documentoObligacionBL.tipoTributo = i.doc.tipoTributo
            documentoObligacionBL.porcTributario = i.doc.porcTributario
            documentoObligacionBL.importeTotal = i.doc.importeTotal
            documentoObligacionBL.importeUS = i.doc.importeUS
            ListaObligacion.Add(documentoObligacionBL)
        Next



        'For Each i In consulta
        '    documentoObligacionBL = New documentoObligacionTributaria
        '    documentoObligacionBL.idDocumento = i.n.idDocumento
        '    documentoObligacionBL.fechaDoc = i.n.fechaDoc
        '    documentoObligacionBL.tipoDoc = i.n.tipoDoc
        '    documentoObligacionBL.serieDoc = i.n.serieDoc
        '    documentoObligacionBL.numeroDoc = i.n.numeroDoc
        '    documentoObligacionBL.idEntidad = i.e.idEntidad
        '    documentoObligacionBL.NomProveedor = i.e.nombreCompleto
        '    documentoObligacionBL.moneda = i.n.moneda
        '    documentoObligacionBL.tipoTributo = i.n.tipoTributo
        '    documentoObligacionBL.porcTributario = i.n.porcTributario
        '    documentoObligacionBL.importeTotal = i.n.importeTotal
        '    documentoObligacionBL.importeUS = i.n.importeUS
        '    ListaObligacion.Add(documentoObligacionBL)
        'Next

        Return ListaObligacion
    End Function

    Public Function UbicarTributoPorIdDocumento(intIdDocumento As Integer) As documentoObligacionTributaria
        Return (From n In HeliosData.documentoObligacionTributaria _
                Where n.idDocumento = intIdDocumento).FirstOrDefault
    End Function

    Public Function UbicarTributoPorIdDocumentoCompra(intIdDocumento As Integer) As documentoObligacionTributaria
        Return (From n In HeliosData.documentoObligacionTributaria _
                Where n.idDocumentoOrigen = intIdDocumento).FirstOrDefault
    End Function

    Public Sub EliminarObligacion(intIdDocumento As Integer)
        Dim docTributo As documentoObligacionTributaria = HeliosData.documentoObligacionTributaria.Where(Function(o) o.idDocumento = intIdDocumento).FirstOrDefault
        Dim docCompra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = docTributo.idDocumentoOrigen).FirstOrDefault
        docCompra.periodoTributo = Nothing

        Dim documento As documento = HeliosData.documento.Where(Function(o) o.idDocumento = intIdDocumento).First
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documento)
        HeliosData.SaveChanges()
    End Sub

End Class
