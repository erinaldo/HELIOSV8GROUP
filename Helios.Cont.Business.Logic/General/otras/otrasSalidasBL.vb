Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class otrasSalidasBL
    Inherits BaseBL

    Public Function Insert(ByVal otrasSalidasBE As otrasSalidas) As Integer
        Using ts As New TransactionScope
            HeliosData.otrasSalidas.Add(otrasSalidasBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return otrasSalidasBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal otrasSalidasBE As otrasSalidas)
        Using ts As New TransactionScope
            Dim otrasSal As otrasSalidas = HeliosData.otrasSalidas.Where(Function(o) _
                                            o.idDocumento = otrasSalidasBE.idDocumento).First()

            otrasSal.codigoLibro = otrasSalidasBE.codigoLibro
            otrasSal.idEmpresa = otrasSalidasBE.idEmpresa
            otrasSal.idCentroCosto = otrasSalidasBE.idCentroCosto
            otrasSal.fechaDoc = otrasSalidasBE.fechaDoc
            otrasSal.fechaVcto = otrasSalidasBE.fechaVcto
            otrasSal.fechaContable = otrasSalidasBE.fechaContable
            otrasSal.tipoDoc = otrasSalidasBE.tipoDoc
            otrasSal.serie = otrasSalidasBE.serie
            otrasSal.numeroDoc = otrasSalidasBE.numeroDoc
            otrasSal.idCliente = otrasSalidasBE.idCliente
            otrasSal.monedaDoc = otrasSalidasBE.monedaDoc
            otrasSal.tasaIgv = otrasSalidasBE.tasaIgv
            otrasSal.tcDolLoc = otrasSalidasBE.tcDolLoc
            otrasSal.tipoRecaudo = otrasSalidasBE.tipoRecaudo
            otrasSal.regimen = otrasSalidasBE.regimen
            otrasSal.tasaRegimen = otrasSalidasBE.tasaRegimen
            otrasSal.nroRegimen = otrasSalidasBE.nroRegimen
            otrasSal.bi01 = otrasSalidasBE.bi01
            otrasSal.bi02 = otrasSalidasBE.bi02
            otrasSal.isc01 = otrasSalidasBE.isc01
            otrasSal.isc02 = otrasSalidasBE.isc02
            otrasSal.igv01 = otrasSalidasBE.igv01
            otrasSal.igv02 = otrasSalidasBE.igv02
            otrasSal.otc01 = otrasSalidasBE.otc01
            otrasSal.otc02 = otrasSalidasBE.otc02
            otrasSal.bi01us = otrasSalidasBE.bi01us
            otrasSal.bi02us = otrasSalidasBE.bi02us
            otrasSal.isc01us = otrasSalidasBE.isc01us
            otrasSal.isc02us = otrasSalidasBE.isc02us
            otrasSal.igv01us = otrasSalidasBE.igv01us
            otrasSal.igv02us = otrasSalidasBE.igv02us
            otrasSal.otc01us = otrasSalidasBE.otc01us
            otrasSal.otc02us = otrasSalidasBE.otc02us
            otrasSal.importeTotal = otrasSalidasBE.importeTotal
            otrasSal.importeUS = otrasSalidasBE.importeUS
            otrasSal.destino = otrasSalidasBE.destino
            otrasSal.idDocumentoRef = otrasSalidasBE.idDocumentoRef
            otrasSal.estadoCobro = otrasSalidasBE.estadoCobro
            otrasSal.glosa = otrasSalidasBE.glosa
            otrasSal.usuarioActualizacion = otrasSalidasBE.usuarioActualizacion
            otrasSal.fechaActualizacion = otrasSalidasBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(otrasSal).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal otrasSalidasBE As otrasSalidas)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(otrasSalidasBE)
    End Sub

    Public Function GetListar_otrasSalidas() As List(Of otrasSalidas)
        Return (From a In HeliosData.otrasSalidas Select a).ToList
    End Function

    Public Function GetUbicar_otrasSalidasPorID(idDocumento As Integer) As otrasSalidas
        Return (From a In HeliosData.otrasSalidas
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
