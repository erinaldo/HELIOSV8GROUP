Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoVenta_scBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoVenta_scBE As documentoVenta_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoVenta_sc.Add(documentoVenta_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoVenta_scBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoVenta_scBE As documentoVenta_sc)
        Using ts As New TransactionScope
            Dim docVenta_sc As documentoVenta_sc = HeliosData.documentoVenta_sc.Where(Function(o) _
                                            o.idDocumento = documentoVenta_scBE.idDocumento).First()

            docVenta_sc.codigoLibro = documentoVenta_scBE.codigoLibro
            docVenta_sc.idEmpresa = documentoVenta_scBE.idEmpresa
            docVenta_sc.idEstablecimiento = documentoVenta_scBE.idEstablecimiento
            docVenta_sc.fechaDoc = documentoVenta_scBE.fechaDoc
            docVenta_sc.fechaVcto = documentoVenta_scBE.fechaVcto
            docVenta_sc.fechaContable = documentoVenta_scBE.fechaContable
            docVenta_sc.origenVenta = documentoVenta_scBE.origenVenta
            docVenta_sc.serie = documentoVenta_scBE.serie
            docVenta_sc.numeroDoc = documentoVenta_scBE.numeroDoc
            docVenta_sc.idCliente = documentoVenta_scBE.idCliente
            docVenta_sc.monedaDoc = documentoVenta_scBE.monedaDoc
            docVenta_sc.tasaIgv = documentoVenta_scBE.tasaIgv
            docVenta_sc.tcDolLoc = documentoVenta_scBE.tcDolLoc
            docVenta_sc.tipoRecaudo = documentoVenta_scBE.tipoRecaudo
            docVenta_sc.regimen = documentoVenta_scBE.regimen
            docVenta_sc.tasaRegimen = documentoVenta_scBE.tasaRegimen
            docVenta_sc.nroRegimen = documentoVenta_scBE.nroRegimen
            docVenta_sc.bi01 = documentoVenta_scBE.bi01
            docVenta_sc.bi02 = documentoVenta_scBE.bi02
            docVenta_sc.isc01 = documentoVenta_scBE.isc01
            docVenta_sc.isc02 = documentoVenta_scBE.isc02
            docVenta_sc.igv01 = documentoVenta_scBE.igv01
            docVenta_sc.igv02 = documentoVenta_scBE.igv02
            docVenta_sc.otc01 = documentoVenta_scBE.otc01
            docVenta_sc.otc02 = documentoVenta_scBE.otc02
            docVenta_sc.bi01us = documentoVenta_scBE.bi01us
            docVenta_sc.bi02us = documentoVenta_scBE.bi02us
            docVenta_sc.isc01us = documentoVenta_scBE.isc01us
            docVenta_sc.isc02us = documentoVenta_scBE.isc02us
            docVenta_sc.igv01us = documentoVenta_scBE.igv01us
            docVenta_sc.igv02us = documentoVenta_scBE.igv02us
            docVenta_sc.otc01us = documentoVenta_scBE.otc01us
            docVenta_sc.otc02us = documentoVenta_scBE.otc02us
            docVenta_sc.importeTotal = documentoVenta_scBE.importeTotal
            docVenta_sc.importeUS = documentoVenta_scBE.importeUS
            docVenta_sc.estadoCobro = documentoVenta_scBE.estadoCobro
            docVenta_sc.glosa = documentoVenta_scBE.glosa
            docVenta_sc.usuarioActualizacion = documentoVenta_scBE.usuarioActualizacion
            docVenta_sc.fechaActualizacion = documentoVenta_scBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVenta_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoVenta_scBE As documentoVenta_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoVenta_scBE)
    End Sub

    Public Function GetListar_documentoVenta_sc() As List(Of documentoVenta_sc)
        Return (From a In HeliosData.documentoVenta_sc Select a).ToList
    End Function

    Public Function GetUbicar_documentoVenta_scPorID(idDocumento As Integer) As documentoVenta_sc
        Return (From a In HeliosData.documentoVenta_sc
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
