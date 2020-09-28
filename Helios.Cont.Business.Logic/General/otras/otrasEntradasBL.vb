Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class otrasEntradasBL
    Inherits BaseBL

    Public Function Insert(ByVal otrasEntradasBE As otrasEntradas) As Integer
        Using ts As New TransactionScope
            HeliosData.otrasEntradas.Add(otrasEntradasBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return otrasEntradasBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal otrasEntradasBE As otrasEntradas)
        Using ts As New TransactionScope
            Dim otrasEnt As otrasEntradas = HeliosData.otrasEntradas.Where(Function(o) _
                                            o.idDocumento = otrasEntradasBE.idDocumento).First()

            otrasEnt.codigoLibro = otrasEntradasBE.codigoLibro
            otrasEnt.idEmpresa = otrasEntradasBE.idEmpresa
            otrasEnt.idCentroCosto = otrasEntradasBE.idCentroCosto
            otrasEnt.fechaDoc = otrasEntradasBE.fechaDoc
            otrasEnt.fechaVcto = otrasEntradasBE.fechaVcto
            otrasEnt.tipoDoc = otrasEntradasBE.tipoDoc
            otrasEnt.fechaContable = otrasEntradasBE.fechaContable
            otrasEnt.serie = otrasEntradasBE.serie
            otrasEnt.numeroDoc = otrasEntradasBE.numeroDoc
            otrasEnt.idProveedor = otrasEntradasBE.idProveedor
            otrasEnt.monedaDoc = otrasEntradasBE.monedaDoc
            otrasEnt.tasaIgv = otrasEntradasBE.tasaIgv
            otrasEnt.tcDolLoc = otrasEntradasBE.tcDolLoc
            otrasEnt.tipoRecaudo = otrasEntradasBE.tipoRecaudo
            otrasEnt.regimen = otrasEntradasBE.regimen
            otrasEnt.tasaRegimen = otrasEntradasBE.tasaRegimen
            otrasEnt.nroRegimen = otrasEntradasBE.nroRegimen
            otrasEnt.bi01 = otrasEntradasBE.bi01
            otrasEnt.bi02 = otrasEntradasBE.bi02
            otrasEnt.bi03 = otrasEntradasBE.bi03
            otrasEnt.bi04 = otrasEntradasBE.bi04
            otrasEnt.isc01 = otrasEntradasBE.isc01
            otrasEnt.isc02 = otrasEntradasBE.isc02
            otrasEnt.isc03 = otrasEntradasBE.isc03
            otrasEnt.igv01 = otrasEntradasBE.igv01
            otrasEnt.igv02 = otrasEntradasBE.igv02
            otrasEnt.igv03 = otrasEntradasBE.igv03
            otrasEnt.otc01 = otrasEntradasBE.otc01
            otrasEnt.otc02 = otrasEntradasBE.otc02
            otrasEnt.otc03 = otrasEntradasBE.otc03
            otrasEnt.otc04 = otrasEntradasBE.otc04
            otrasEnt.bi01us = otrasEntradasBE.bi01us
            otrasEnt.bi02us = otrasEntradasBE.bi02us
            otrasEnt.bi03us = otrasEntradasBE.bi03us
            otrasEnt.bi04us = otrasEntradasBE.bi04us
            otrasEnt.isc01us = otrasEntradasBE.isc01us
            otrasEnt.isc02us = otrasEntradasBE.isc02us
            otrasEnt.isc03us = otrasEntradasBE.isc03us
            otrasEnt.igv01us = otrasEntradasBE.igv01us
            otrasEnt.igv02us = otrasEntradasBE.igv02us
            otrasEnt.igv03us = otrasEntradasBE.igv03us
            otrasEnt.otc01us = otrasEntradasBE.otc01us
            otrasEnt.otc02us = otrasEntradasBE.otc02us
            otrasEnt.otc03us = otrasEntradasBE.otc03us
            otrasEnt.otc04us = otrasEntradasBE.otc04us
            otrasEnt.importeSoles = otrasEntradasBE.importeSoles
            otrasEnt.importeUS = otrasEntradasBE.importeUS
            otrasEnt.destino = otrasEntradasBE.destino
            otrasEnt.estadoPago = otrasEntradasBE.estadoPago
            otrasEnt.glosa = otrasEntradasBE.glosa
            otrasEnt.referenciaDestino = otrasEntradasBE.referenciaDestino
            otrasEnt.usuarioActualizacion = otrasEntradasBE.usuarioActualizacion
            otrasEnt.fechaActualizacion = otrasEntradasBE.fechaActualizacion
 
            'HeliosData.ObjectStateManager.GetObjectStateEntry(otrasEnt).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal otrasEntradasBE As otrasEntradas)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(otrasEntradasBE)
    End Sub

    Public Function GetListar_otrasEntradas() As List(Of otrasEntradas)
        Return (From a In HeliosData.otrasEntradas Select a).ToList
    End Function

    Public Function GetUbicar_otrasEntradasPorID(idDocumento As Integer) As otrasEntradas
        Return (From a In HeliosData.otrasEntradas
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
