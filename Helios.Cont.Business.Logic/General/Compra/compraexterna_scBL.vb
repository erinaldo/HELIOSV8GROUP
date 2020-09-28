Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class compraexterna_scBL
    Inherits BaseBL

    Public Function Insert(ByVal compraexterna_scBE As compraexterna_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.compraexterna_sc.Add(compraexterna_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return compraexterna_scBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal compraexterna_scBE As compraexterna_sc)
        Using ts As New TransactionScope
            Dim compraext_sc As compraexterna_sc = HeliosData.compraexterna_sc.Where(Function(o) _
                                            o.idDocumento = compraexterna_scBE.idDocumento).First()

            compraext_sc.codigoLibro = compraexterna_scBE.codigoLibro
            compraext_sc.idEmpresa = compraexterna_scBE.idEmpresa
            compraext_sc.idCentroCosto = compraexterna_scBE.idCentroCosto
            compraext_sc.origenCompra = compraexterna_scBE.origenCompra
            compraext_sc.fechaContable = compraexterna_scBE.fechaContable
            compraext_sc.tipoDoc = compraexterna_scBE.tipoDoc
            compraext_sc.fechaPagoEmision = compraexterna_scBE.fechaPagoEmision
            compraext_sc.aduana = compraexterna_scBE.aduana
            compraext_sc.anioEmision = compraexterna_scBE.anioEmision
            compraext_sc.numeroDoc = compraexterna_scBE.numeroDoc
            compraext_sc.idProveedor = compraexterna_scBE.idProveedor
            compraext_sc.monedaDoc = compraexterna_scBE.monedaDoc
            compraext_sc.tasaIgv = compraexterna_scBE.tasaIgv
            compraext_sc.tcDolLoc = compraexterna_scBE.tcDolLoc
            compraext_sc.bi01 = compraexterna_scBE.bi01
            compraext_sc.bi02 = compraexterna_scBE.bi02
            compraext_sc.bi03 = compraexterna_scBE.bi03
            compraext_sc.bi04 = compraexterna_scBE.bi04
            compraext_sc.isc01 = compraexterna_scBE.isc01
            compraext_sc.isc02 = compraexterna_scBE.isc02
            compraext_sc.isc03 = compraexterna_scBE.isc03
            compraext_sc.igv01 = compraexterna_scBE.igv01
            compraext_sc.igv02 = compraexterna_scBE.igv02
            compraext_sc.igv03 = compraexterna_scBE.igv03
            compraext_sc.igv02 = compraexterna_scBE.igv02
            compraext_sc.otc02 = compraexterna_scBE.otc02
            compraext_sc.otc03 = compraexterna_scBE.otc03
            compraext_sc.otc04 = compraexterna_scBE.otc04
            compraext_sc.bi01us = compraexterna_scBE.bi01us
            compraext_sc.bi02us = compraexterna_scBE.bi02us
            compraext_sc.bi03us = compraexterna_scBE.bi03us
            compraext_sc.bi04us = compraexterna_scBE.bi04us
            compraext_sc.isc01us = compraexterna_scBE.isc01us
            compraext_sc.isc02us = compraexterna_scBE.isc02us
            compraext_sc.isc03us = compraexterna_scBE.isc03us
            compraext_sc.igv01us = compraexterna_scBE.igv01us
            compraext_sc.igv02us = compraexterna_scBE.igv02us
            compraext_sc.igv03us = compraexterna_scBE.igv03us
            compraext_sc.otc01us = compraexterna_scBE.otc01us
            compraext_sc.otc02us = compraexterna_scBE.otc02us
            compraext_sc.otc03us = compraexterna_scBE.otc03us
            compraext_sc.otc04us = compraexterna_scBE.otc04us
            compraext_sc.importeSoles = compraexterna_scBE.importeSoles
            compraext_sc.importeDolares = compraexterna_scBE.importeDolares
            compraext_sc.estadoPago = compraexterna_scBE.estadoPago
            compraext_sc.glosa = compraexterna_scBE.glosa
            compraext_sc.usuarioActualizacion = compraexterna_scBE.usuarioActualizacion
            compraext_sc.fechaActualizacion = compraexterna_scBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(compraext_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal compraexterna_scBE As compraexterna_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(compraexterna_scBE)
    End Sub

    Public Function GetListar_compraexterna_sc() As List(Of compraexterna_sc)
        Return (From a In HeliosData.compraexterna_sc Select a).ToList
    End Function

    Public Function GetUbicar_compraexterna_scPorID(idDocumento As Integer) As compraexterna_sc
        Return (From a In HeliosData.compraexterna_sc
                Where a.idDocumento = idDocumento Select a).First
    End Function

End Class
