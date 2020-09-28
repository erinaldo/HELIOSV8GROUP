Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoventaBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoventaBE As documentoventa) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoventa.Add(documentoventaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoventaBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoventaBE As documentoventa)
        Using ts As New TransactionScope
            Dim docVenta As documentoventa = HeliosData.documentoventa.Where(Function(o) _
                                            o.idDocumento = documentoventaBE.idDocumento).First()

            docVenta.codigoLibro = documentoventaBE.codigoLibro
            docVenta.idEmpresa = documentoventaBE.idEmpresa
            docVenta.idCentroCosto = documentoventaBE.idCentroCosto
            docVenta.fechaDoc = documentoventaBE.fechaDoc
            docVenta.fechaVcto = documentoventaBE.fechaVcto
            docVenta.fechaContable = documentoventaBE.fechaContable
            docVenta.tipoDoc = documentoventaBE.tipoDoc
            docVenta.serie = documentoventaBE.serie
            docVenta.numeroDoc = documentoventaBE.numeroDoc
            docVenta.idCliente = documentoventaBE.idCliente
            docVenta.monedaDoc = documentoventaBE.monedaDoc
            docVenta.tasaIgv = documentoventaBE.tasaIgv
            docVenta.tcDolLoc = documentoventaBE.tcDolLoc
            docVenta.tipoRecaudo = documentoventaBE.tipoRecaudo
            docVenta.regimen = documentoventaBE.regimen
            docVenta.tasaRegimen = documentoventaBE.tasaRegimen
            docVenta.nroRegimen = documentoventaBE.nroRegimen
            docVenta.bi01 = documentoventaBE.bi01
            docVenta.bi02 = documentoventaBE.bi02
            docVenta.isc01 = documentoventaBE.isc01
            docVenta.isc02 = documentoventaBE.isc02
            docVenta.igv01 = documentoventaBE.igv01
            docVenta.igv02 = documentoventaBE.igv02
            docVenta.otc01 = documentoventaBE.otc01
            docVenta.otc02 = documentoventaBE.otc02
            docVenta.bi01us = documentoventaBE.bi01us
            docVenta.bi02us = documentoventaBE.bi02us
            docVenta.isc01us = documentoventaBE.isc01us
            docVenta.isc02us = documentoventaBE.isc02us
            docVenta.igv01us = documentoventaBE.igv01us
            docVenta.igv02us = documentoventaBE.igv02us
            docVenta.otc01us = documentoventaBE.otc01us
            docVenta.otc02us = documentoventaBE.otc02us
            docVenta.importeTotal = documentoventaBE.importeTotal
            docVenta.importeUS = documentoventaBE.importeUS
            docVenta.importeCostoMN = documentoventaBE.importeCostoMN
            docVenta.importeCostoME = documentoventaBE.importeCostoME
            docVenta.destino = documentoventaBE.destino
            docVenta.idDocumentoRef = documentoventaBE.idDocumentoRef
            docVenta.estadoCobro = documentoventaBE.estadoCobro
            docVenta.notaCredito = documentoventaBE.notaCredito
            docVenta.glosa = documentoventaBE.glosa
            docVenta.usuarioActualizacion = documentoventaBE.usuarioActualizacion
            docVenta.fechaActualizacion = documentoventaBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVenta).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoventaBE As documentoventa)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoventaBE)
    End Sub

    Public Function GetListar_documentoventa() As List(Of documentoventa)
        Return (From a In HeliosData.documentoventa Select a).ToList
    End Function

    Public Function GetUbicar_documentoventaPorID(idDocumento As Integer) As documentoventa
        Return (From a In HeliosData.documentoventa
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
