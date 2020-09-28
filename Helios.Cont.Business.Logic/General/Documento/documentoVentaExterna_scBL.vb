Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoVentaExterna_scBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoVentaExterna_scBE As documentoVentaExterna_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoVentaExterna_sc.Add(documentoVentaExterna_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoVentaExterna_scBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoVentaExterna_scBE As documentoVentaExterna_sc)
        Using ts As New TransactionScope
            Dim docVentaExterna_sc As documentoVentaExterna_sc = HeliosData.documentoVentaExterna_sc.Where(Function(o) _
                                            o.idDocumento = documentoVentaExterna_scBE.idDocumento).First()

            docVentaExterna_sc.codigoLibro = documentoVentaExterna_scBE.codigoLibro
            docVentaExterna_sc.idEmpresa = documentoVentaExterna_scBE.idEmpresa
            docVentaExterna_sc.idEstablecimiento = documentoVentaExterna_scBE.idEstablecimiento
            docVentaExterna_sc.fechaDoc = documentoVentaExterna_scBE.fechaDoc
            docVentaExterna_sc.fechaVcto = documentoVentaExterna_scBE.fechaVcto
            docVentaExterna_sc.fechaContable = documentoVentaExterna_scBE.fechaContable
            docVentaExterna_sc.origenVenta = documentoVentaExterna_scBE.origenVenta
            docVentaExterna_sc.serie = documentoVentaExterna_scBE.serie
            docVentaExterna_sc.numeroDoc = documentoVentaExterna_scBE.numeroDoc
            docVentaExterna_sc.idCliente = documentoVentaExterna_scBE.idCliente
            docVentaExterna_sc.monedaDoc = documentoVentaExterna_scBE.monedaDoc
            docVentaExterna_sc.tasaIgv = documentoVentaExterna_scBE.tasaIgv
            docVentaExterna_sc.tcDolLoc = documentoVentaExterna_scBE.tcDolLoc
            docVentaExterna_sc.tipoRecaudo = documentoVentaExterna_scBE.tipoRecaudo
            docVentaExterna_sc.regimen = documentoVentaExterna_scBE.regimen
            docVentaExterna_sc.tasaRegimen = documentoVentaExterna_scBE.tasaRegimen
            docVentaExterna_sc.nroRegimen = documentoVentaExterna_scBE.nroRegimen
            docVentaExterna_sc.bi01 = documentoVentaExterna_scBE.bi01
            docVentaExterna_sc.bi02 = documentoVentaExterna_scBE.bi02
            docVentaExterna_sc.isc01 = documentoVentaExterna_scBE.isc01
            docVentaExterna_sc.isc02 = documentoVentaExterna_scBE.isc02
            docVentaExterna_sc.igv01 = documentoVentaExterna_scBE.igv01
            docVentaExterna_sc.igv02 = documentoVentaExterna_scBE.igv02
            docVentaExterna_sc.otc01 = documentoVentaExterna_scBE.otc01
            docVentaExterna_sc.otc02 = documentoVentaExterna_scBE.otc02
            docVentaExterna_sc.bi01us = documentoVentaExterna_scBE.bi01us
            docVentaExterna_sc.bi02us = documentoVentaExterna_scBE.bi02us
            docVentaExterna_sc.isc01us = documentoVentaExterna_scBE.isc01us
            docVentaExterna_sc.isc02us = documentoVentaExterna_scBE.isc02us
            docVentaExterna_sc.igv01us = documentoVentaExterna_scBE.igv01us
            docVentaExterna_sc.igv02us = documentoVentaExterna_scBE.igv02us
            docVentaExterna_sc.otc01us = documentoVentaExterna_scBE.otc01us
            docVentaExterna_sc.otc02us = documentoVentaExterna_scBE.otc02us
            docVentaExterna_sc.importeTotal = documentoVentaExterna_scBE.importeTotal
            docVentaExterna_sc.importeUS = documentoVentaExterna_scBE.importeUS
            docVentaExterna_sc.estadoCobro = documentoVentaExterna_scBE.estadoCobro
            docVentaExterna_sc.glosa = documentoVentaExterna_scBE.glosa
            docVentaExterna_sc.usuarioActualizacion = documentoVentaExterna_scBE.usuarioActualizacion
            docVentaExterna_sc.fechaActualizacion = documentoVentaExterna_scBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentaExterna_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoVentaExterna_scBE As documentoVentaExterna_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoVentaExterna_scBE)
    End Sub

    Public Function GetListar_documentoVentaExterna_sc() As List(Of documentoVentaExterna_sc)
        Return (From a In HeliosData.documentoVentaExterna_sc Select a).ToList
    End Function

    Public Function GetUbicar_documentoVentaExterna_scPorID(idDocumento As Integer) As documentoVentaExterna_sc
        Return (From a In HeliosData.documentoVentaExterna_sc
                 Where a.idDocumento = idDocumento Select a).First
    End Function

End Class
