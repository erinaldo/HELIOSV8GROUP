Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentocompra_scBL
    Inherits BaseBL

    Public Function Insert(ByVal documentocompra_scBE As documentocompra_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.documentocompra_sc.Add(documentocompra_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentocompra_scBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentocompra_scBE As documentocompra_sc)
        Using ts As New TransactionScope
            Dim docCompra_sc As documentocompra_sc = HeliosData.documentocompra_sc.Where(Function(o) _
                                            o.idDocumento = documentocompra_scBE.idDocumento).First()

            docCompra_sc.codigoLibro = documentocompra_scBE.codigoLibro
            docCompra_sc.idEmpresa = documentocompra_scBE.idEmpresa
            docCompra_sc.idCentroCosto = documentocompra_scBE.idCentroCosto
            docCompra_sc.fechaDoc = documentocompra_scBE.fechaDoc
            docCompra_sc.fechaVcto = documentocompra_scBE.fechaVcto
            docCompra_sc.fechaContable = documentocompra_scBE.fechaContable
            docCompra_sc.origenCompra = documentocompra_scBE.origenCompra
            docCompra_sc.tipoDoc = documentocompra_scBE.tipoDoc
            docCompra_sc.serie = documentocompra_scBE.serie
            docCompra_sc.numeroDoc = documentocompra_scBE.numeroDoc
            docCompra_sc.idProveedor = documentocompra_scBE.idProveedor
            docCompra_sc.monedaDoc = documentocompra_scBE.monedaDoc
            docCompra_sc.tasaIgv = documentocompra_scBE.tasaIgv
            docCompra_sc.tcDolLoc = documentocompra_scBE.tcDolLoc
            docCompra_sc.tipoRecaudo = documentocompra_scBE.tipoRecaudo
            docCompra_sc.regimen = documentocompra_scBE.regimen
            docCompra_sc.tasaRegimen = documentocompra_scBE.tasaRegimen
            docCompra_sc.nroRegimen = documentocompra_scBE.nroRegimen
            docCompra_sc.bi01 = documentocompra_scBE.bi01
            docCompra_sc.bi01 = documentocompra_scBE.bi01
            docCompra_sc.bi03 = documentocompra_scBE.bi03
            docCompra_sc.bi04 = documentocompra_scBE.bi04
            docCompra_sc.isc01 = documentocompra_scBE.isc01
            docCompra_sc.isc02 = documentocompra_scBE.isc02
            docCompra_sc.isc03 = documentocompra_scBE.isc03
            docCompra_sc.igv01 = documentocompra_scBE.igv01
            docCompra_sc.igv02 = documentocompra_scBE.igv02
            docCompra_sc.igv03 = documentocompra_scBE.igv03
            docCompra_sc.otc01 = documentocompra_scBE.otc01
            docCompra_sc.otc02 = documentocompra_scBE.otc02
            docCompra_sc.otc03 = documentocompra_scBE.otc03
            docCompra_sc.otc04 = documentocompra_scBE.otc04
            docCompra_sc.bi01us = documentocompra_scBE.bi01us
            docCompra_sc.bi02us = documentocompra_scBE.bi02us
            docCompra_sc.bi03us = documentocompra_scBE.bi03us
            docCompra_sc.bi04us = documentocompra_scBE.bi04us
            docCompra_sc.isc01us = documentocompra_scBE.isc01us
            docCompra_sc.isc02us = documentocompra_scBE.isc02us
            docCompra_sc.isc03us = documentocompra_scBE.isc03us
            docCompra_sc.igv01us = documentocompra_scBE.igv01us
            docCompra_sc.igv02us = documentocompra_scBE.igv02us
            docCompra_sc.igv03us = documentocompra_scBE.igv03us
            docCompra_sc.otc01us = documentocompra_scBE.otc01us
            docCompra_sc.otc02us = documentocompra_scBE.otc02us
            docCompra_sc.otc03us = documentocompra_scBE.otc03us
            docCompra_sc.otc04us = documentocompra_scBE.otc04us
            docCompra_sc.importeTotal = documentocompra_scBE.importeTotal
            docCompra_sc.importeUS = documentocompra_scBE.importeUS
            docCompra_sc.estadoPago = documentocompra_scBE.estadoPago
            docCompra_sc.glosa = documentocompra_scBE.glosa
            docCompra_sc.saldoMontoNota = documentocompra_scBE.saldoMontoNota
            docCompra_sc.saldoMontoNotaUSD = documentocompra_scBE.saldoMontoNotaUSD
            docCompra_sc.usuarioActualizacion = documentocompra_scBE.usuarioActualizacion
            docCompra_sc.fechaActualizacion = documentocompra_scBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(docCompra_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentocompra_scBE As documentocompra_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentocompra_scBE)
    End Sub

    Public Function GetListar_documentocompra_sc() As List(Of documentocompra_sc)
        Return (From a In HeliosData.documentocompra_sc Select a).ToList
    End Function

    Public Function GetUbicar_documentocompra_scPorID(idDocumento As Integer) As documentocompra_sc
        Return (From a In HeliosData.documentocompra_sc
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
