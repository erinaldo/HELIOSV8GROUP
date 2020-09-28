Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoNotasBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoNotasBE As documentoNotas) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoNotas.Add(documentoNotasBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoNotasBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoNotasBE As documentoNotas)
        Using ts As New TransactionScope
            Dim docNotas As documentoNotas = HeliosData.documentoNotas.Where(Function(o) _
                                            o.idDocumento = documentoNotasBE.idDocumento).First()

            docNotas.movimiento = documentoNotasBE.movimiento
            docNotas.codigoLibro = documentoNotasBE.codigoLibro
            docNotas.idEmpresa = documentoNotasBE.idEmpresa
            docNotas.idCentroCosto = documentoNotasBE.idCentroCosto
            docNotas.fechaDoc = documentoNotasBE.fechaDoc
            docNotas.fechaVcto = documentoNotasBE.fechaVcto
            docNotas.fechaContable = documentoNotasBE.fechaContable
            docNotas.serie = documentoNotasBE.serie
            docNotas.numeroDoc = documentoNotasBE.numeroDoc
            docNotas.idProveedor = documentoNotasBE.idProveedor
            docNotas.monedaDoc = documentoNotasBE.monedaDoc
            docNotas.tasaIgv = documentoNotasBE.tasaIgv
            docNotas.tcDolLoc = documentoNotasBE.tcDolLoc
            docNotas.tipoRecaudo = documentoNotasBE.tipoRecaudo
            docNotas.regimen = documentoNotasBE.tipoRecaudo
            docNotas.tasaRegimen = documentoNotasBE.tasaRegimen
            docNotas.nroRegimen = documentoNotasBE.tasaRegimen
            docNotas.bi01 = documentoNotasBE.bi01
            docNotas.bi02 = documentoNotasBE.bi02
            docNotas.bi03 = documentoNotasBE.bi03
            docNotas.bi04 = documentoNotasBE.bi04
            docNotas.isc01 = documentoNotasBE.isc01
            docNotas.isc02 = documentoNotasBE.isc01
            docNotas.isc03 = documentoNotasBE.isc03
            docNotas.igv01 = documentoNotasBE.igv01
            docNotas.igv02 = documentoNotasBE.igv02
            docNotas.igv03 = documentoNotasBE.igv03
            docNotas.otc01 = documentoNotasBE.otc01
            docNotas.otc02 = documentoNotasBE.otc02
            docNotas.otc03 = documentoNotasBE.otc03
            docNotas.otc04 = documentoNotasBE.otc04
            docNotas.bi01us = documentoNotasBE.bi01us
            docNotas.bi02us = documentoNotasBE.bi02us
            docNotas.bi03us = documentoNotasBE.bi03us
            docNotas.bi04us = documentoNotasBE.bi04us
            docNotas.isc01us = documentoNotasBE.isc01us
            docNotas.isc02us = documentoNotasBE.isc02us
            docNotas.isc03us = documentoNotasBE.isc03us
            docNotas.igv01us = documentoNotasBE.igv01us
            docNotas.igv02us = documentoNotasBE.igv02us
            docNotas.igv03us = documentoNotasBE.igv03us
            docNotas.otc01us = documentoNotasBE.otc01us
            docNotas.otc02us = documentoNotasBE.otc02us
            docNotas.otc03us = documentoNotasBE.otc02us
            docNotas.otc04us = documentoNotasBE.otc04us
            docNotas.importeTotal = documentoNotasBE.otc02us
            docNotas.importeUS = documentoNotasBE.importeUS
            docNotas.destino = documentoNotasBE.destino
            docNotas.estadoPago = documentoNotasBE.estadoPago
            docNotas.glosa = documentoNotasBE.glosa
            docNotas.referenciaDestino = documentoNotasBE.referenciaDestino
            docNotas.usuarioActualizacion = documentoNotasBE.usuarioActualizacion
            docNotas.fechaActualizacion = documentoNotasBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docNotas).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoNotasBE As documentoNotas)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoNotasBE)
    End Sub

    Public Function GetListar_documentoNotas() As List(Of documentoNotas)
        Return (From a In HeliosData.documentoNotas Select a).ToList
    End Function

    Public Function GetUbicar_documentoNotasPorID(idDocumento As Integer) As documentoNotas
        Return (From a In HeliosData.documentoNotas
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
