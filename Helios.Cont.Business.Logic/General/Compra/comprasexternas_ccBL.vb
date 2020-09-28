Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class comprasexternas_ccBL
    Inherits BaseBL

    Public Function Insert(ByVal comprasexternas_ccBE As comprasexternas_cc) As Integer
        Using ts As New TransactionScope
            HeliosData.comprasexternas_cc.Add(comprasexternas_ccBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return comprasexternas_ccBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal comprasexternas_ccBE As comprasexternas_cc)
        Using ts As New TransactionScope
            Dim comprasext_cc As comprasexternas_cc = HeliosData.comprasexternas_cc.Where(Function(o) _
                                            o.idDocumento = comprasexternas_ccBE.idDocumento).First()

            comprasext_cc.codigoLibro = comprasexternas_ccBE.codigoLibro
            comprasext_cc.idEmpresa = comprasexternas_ccBE.idEmpresa
            comprasext_cc.idCentroCosto = comprasexternas_ccBE.idCentroCosto
            comprasext_cc.origenCompra = comprasexternas_ccBE.origenCompra
            comprasext_cc.fechaContable = comprasexternas_ccBE.fechaContable
            comprasext_cc.tipoDoc = comprasexternas_ccBE.tipoDoc
            comprasext_cc.fechaPagoEmision = comprasexternas_ccBE.fechaPagoEmision
            comprasext_cc.aduana = comprasexternas_ccBE.aduana
            comprasext_cc.anioEmision = comprasexternas_ccBE.anioEmision
            comprasext_cc.numeroDoc = comprasexternas_ccBE.numeroDoc
            comprasext_cc.idProveedor = comprasexternas_ccBE.idProveedor
            comprasext_cc.monedaDoc = comprasexternas_ccBE.monedaDoc
            comprasext_cc.tasaIgv = comprasexternas_ccBE.tasaIgv
            comprasext_cc.tcDolLoc = comprasexternas_ccBE.tcDolLoc
            comprasext_cc.bi01 = comprasexternas_ccBE.bi01
            comprasext_cc.bi02 = comprasexternas_ccBE.bi02
            comprasext_cc.bi03 = comprasexternas_ccBE.bi03
            comprasext_cc.bi04 = comprasexternas_ccBE.bi04
            comprasext_cc.isc01 = comprasexternas_ccBE.isc01
            comprasext_cc.isc02 = comprasexternas_ccBE.isc02
            comprasext_cc.isc03 = comprasexternas_ccBE.isc03
            comprasext_cc.igv01 = comprasexternas_ccBE.igv01
            comprasext_cc.igv02 = comprasexternas_ccBE.igv02
            comprasext_cc.igv03 = comprasexternas_ccBE.igv03
            comprasext_cc.otc01 = comprasexternas_ccBE.otc01
            comprasext_cc.otc02 = comprasexternas_ccBE.otc02
            comprasext_cc.otc03 = comprasexternas_ccBE.otc03
            comprasext_cc.otc04 = comprasexternas_ccBE.otc04
            comprasext_cc.bi01us = comprasexternas_ccBE.bi01us
            comprasext_cc.bi02us = comprasexternas_ccBE.bi02us
            comprasext_cc.bi03us = comprasexternas_ccBE.bi03us
            comprasext_cc.bi04us = comprasexternas_ccBE.bi04us
            comprasext_cc.isc01us = comprasexternas_ccBE.isc01us
            comprasext_cc.isc02us = comprasexternas_ccBE.isc02us
            comprasext_cc.isc03us = comprasexternas_ccBE.isc03us
            comprasext_cc.igv01us = comprasexternas_ccBE.igv01us
            comprasext_cc.igv02us = comprasexternas_ccBE.igv02us
            comprasext_cc.igv03us = comprasexternas_ccBE.igv03us
            comprasext_cc.otc01us = comprasexternas_ccBE.otc01us
            comprasext_cc.otc02us = comprasexternas_ccBE.otc02us
            comprasext_cc.otc03us = comprasexternas_ccBE.otc03us
            comprasext_cc.otc04us = comprasexternas_ccBE.otc04us
            comprasext_cc.importeSoles = comprasexternas_ccBE.importeSoles
            comprasext_cc.importeDolares = comprasexternas_ccBE.importeDolares
            comprasext_cc.estadoPago = comprasexternas_ccBE.estadoPago
            comprasext_cc.glosa = comprasexternas_ccBE.glosa
            comprasext_cc.usuarioActualizacion = comprasexternas_ccBE.usuarioActualizacion
            comprasext_cc.fechaActualizacion = comprasexternas_ccBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(comprasext_cc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal comprasexternas_ccBE As comprasexternas_cc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(comprasexternas_ccBE)
    End Sub

    Public Function GetListar_actividadSeguimiento() As List(Of comprasexternas_cc)
        Return (From a In HeliosData.comprasexternas_cc Select a).ToList
    End Function

    Public Function GetUbicar_actividadSeguimientoPorID(idDocumento As Integer) As comprasexternas_cc
        Return (From a In HeliosData.comprasexternas_cc
                Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
