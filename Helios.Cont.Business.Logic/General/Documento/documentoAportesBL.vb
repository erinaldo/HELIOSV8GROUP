Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoAportesBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoAportesBE As documentoAportes) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoAportes.Add(documentoAportesBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoAportesBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoAportesBE As documentoAportes)
        Using ts As New TransactionScope
            Dim docAportes As documentoAportes = HeliosData.documentoAportes.Where(Function(o) _
                                            o.idDocumento = documentoAportesBE.idDocumento).First()

            docAportes.codigoLibro = documentoAportesBE.codigoLibro
            docAportes.idEmpresa = documentoAportesBE.idEmpresa
            docAportes.idEstablecimiento = documentoAportesBE.idEstablecimiento
            docAportes.tipoDocumento = documentoAportesBE.tipoDocumento
            docAportes.fechaDoc = documentoAportesBE.fechaDoc
            docAportes.fechaPeriodo = documentoAportesBE.fechaPeriodo
            docAportes.numeroDoc = documentoAportesBE.numeroDoc
            docAportes.idAccionista = documentoAportesBE.idAccionista
            docAportes.tasaIgv = documentoAportesBE.tasaIgv
            docAportes.bi01 = documentoAportesBE.bi01
            docAportes.bi02 = documentoAportesBE.bi02
            docAportes.bi03 = documentoAportesBE.bi03
            docAportes.bi04 = documentoAportesBE.bi04
            docAportes.isc01 = documentoAportesBE.isc01
            docAportes.isc02 = documentoAportesBE.isc02
            docAportes.isc03 = documentoAportesBE.isc03
            docAportes.igv01 = documentoAportesBE.igv01
            docAportes.igv02 = documentoAportesBE.igv02
            docAportes.igv03 = documentoAportesBE.igv03
            docAportes.otc01 = documentoAportesBE.otc01
            docAportes.otc02 = documentoAportesBE.otc02
            docAportes.otc03 = documentoAportesBE.otc03
            docAportes.otc04 = documentoAportesBE.otc04
            docAportes.bi01us = documentoAportesBE.bi01us
            docAportes.bi02us = documentoAportesBE.bi02us
            docAportes.bi03us = documentoAportesBE.bi03us
            docAportes.bi04us = documentoAportesBE.bi04us
            docAportes.isc01us = documentoAportesBE.isc01us
            docAportes.isc02us = documentoAportesBE.isc02us
            docAportes.isc03us = documentoAportesBE.isc03us
            docAportes.igv01us = documentoAportesBE.igv01us
            docAportes.igv02us = documentoAportesBE.igv02us
            docAportes.igv03us = documentoAportesBE.igv03us
            docAportes.otc01us = documentoAportesBE.otc01us
            docAportes.otc02us = documentoAportesBE.otc02us
            docAportes.otc03us = documentoAportesBE.otc03us
            docAportes.otc04us = documentoAportesBE.otc04us
            docAportes.ImporteNacional = documentoAportesBE.ImporteNacional
            docAportes.ImporteExtranjero = documentoAportesBE.ImporteExtranjero
            docAportes.destino = documentoAportesBE.destino
            docAportes.estadoPago = documentoAportesBE.estadoPago
            docAportes.glosa = documentoAportesBE.glosa
            docAportes.usuarioActualizacion = documentoAportesBE.usuarioActualizacion
            docAportes.fechaActualizacion = documentoAportesBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(docAportes).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoAportesBE As documentoAportes)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoAportesBE)
    End Sub

    Public Function GetListar_documentoAportes() As List(Of documentoAportes)
        Return (From a In HeliosData.documentoAportes Select a).ToList
    End Function

    Public Function GetUbicar_documentoAportesPorID(idDocumento As Integer) As documentoAportes
        Return (From a In HeliosData.documentoAportes
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
