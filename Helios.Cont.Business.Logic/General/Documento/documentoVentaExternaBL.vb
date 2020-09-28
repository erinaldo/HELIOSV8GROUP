Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoVentaExternaBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoVentaExternaBE As documentoVentaExterna) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoVentaExterna.Add(documentoVentaExternaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoVentaExternaBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoVentaExternaBE As documentoVentaExterna)
        Using ts As New TransactionScope
            Dim docVentaExterna As documentoVentaExterna = HeliosData.documentoVentaExterna.Where(Function(o) _
                                            o.idDocumento = documentoVentaExternaBE.idDocumento).First()

            docVentaExterna.codigoLibro = documentoVentaExternaBE.codigoLibro
            docVentaExterna.idEmpresa = documentoVentaExternaBE.idEmpresa
            docVentaExterna.idCentroCosto = documentoVentaExternaBE.idCentroCosto
            docVentaExterna.fechaDoc = documentoVentaExternaBE.fechaDoc
            docVentaExterna.fechaVcto = documentoVentaExternaBE.fechaVcto
            docVentaExterna.fechaContable = documentoVentaExternaBE.fechaContable
            docVentaExterna.serie = documentoVentaExternaBE.serie
            docVentaExterna.numeroDoc = documentoVentaExternaBE.numeroDoc
            docVentaExterna.idCliente = documentoVentaExternaBE.idCliente
            docVentaExterna.monedaDoc = documentoVentaExternaBE.monedaDoc
            docVentaExterna.tasaIgv = documentoVentaExternaBE.tasaIgv
            docVentaExterna.tcDolLoc = documentoVentaExternaBE.tcDolLoc
            docVentaExterna.tipoRecaudo = documentoVentaExternaBE.tipoRecaudo
            docVentaExterna.regimen = documentoVentaExternaBE.regimen
            docVentaExterna.tasaRegimen = documentoVentaExternaBE.tasaRegimen
            docVentaExterna.nroRegimen = documentoVentaExternaBE.nroRegimen
            docVentaExterna.bi01 = documentoVentaExternaBE.bi01
            docVentaExterna.bi02 = documentoVentaExternaBE.bi02
            docVentaExterna.isc01 = documentoVentaExternaBE.isc01
            docVentaExterna.isc02 = documentoVentaExternaBE.isc02
            docVentaExterna.igv01 = documentoVentaExternaBE.igv01
            docVentaExterna.igv02 = documentoVentaExternaBE.igv02
            docVentaExterna.otc01 = documentoVentaExternaBE.otc01
            docVentaExterna.otc02 = documentoVentaExternaBE.otc02
            docVentaExterna.bi01us = documentoVentaExternaBE.bi01us
            docVentaExterna.bi02us = documentoVentaExternaBE.bi02us
            docVentaExterna.isc01us = documentoVentaExternaBE.isc01us
            docVentaExterna.isc02us = documentoVentaExternaBE.isc02us
            docVentaExterna.igv01us = documentoVentaExternaBE.igv01us
            docVentaExterna.igv02us = documentoVentaExternaBE.igv02us
            docVentaExterna.otc01us = documentoVentaExternaBE.otc01us
            docVentaExterna.otc02us = documentoVentaExternaBE.otc02us
            docVentaExterna.importeTotal = documentoVentaExternaBE.importeTotal
            docVentaExterna.importeUS = documentoVentaExternaBE.importeUS
            docVentaExterna.destino = documentoVentaExternaBE.destino
            docVentaExterna.idDocumentoRef = documentoVentaExternaBE.idDocumentoRef
            docVentaExterna.estadoCobro = documentoVentaExternaBE.estadoCobro
            docVentaExterna.glosa = documentoVentaExternaBE.glosa
            docVentaExterna.usuarioActualizacion = documentoVentaExternaBE.usuarioActualizacion
            docVentaExterna.fechaActualizacion = documentoVentaExternaBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentaExterna).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoVentaExternaBE As documentoVentaExterna)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoVentaExternaBE)
    End Sub

    Public Function GetListar_documentoVentaExterna() As List(Of documentoVentaExterna)
        Return (From a In HeliosData.documentoVentaExterna Select a).ToList
    End Function

    Public Function GetUbicar_documentoVentaExternaPorID(idDocumento As Integer) As documentoVentaExterna
        Return (From a In HeliosData.documentoVentaExterna
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
