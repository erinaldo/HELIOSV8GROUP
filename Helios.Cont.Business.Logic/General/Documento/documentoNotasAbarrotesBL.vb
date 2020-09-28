Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoNotasAbarrotesBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoNotasAbarrotesBE As documentoNotasAbarrotes) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoNotasAbarrotes.Add(documentoNotasAbarrotesBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoNotasAbarrotesBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoNotasAbarrotesBE As documentoNotasAbarrotes)
        Using ts As New TransactionScope
            Dim docNotasAbarrotes As documentoNotasAbarrotes = HeliosData.documentoNotasAbarrotes.Where(Function(o) _
                                            o.idDocumento = documentoNotasAbarrotesBE.idDocumento).First()

            docNotasAbarrotes.idEmpresa = documentoNotasAbarrotesBE.idEmpresa
            docNotasAbarrotes.idEstablecimiento = documentoNotasAbarrotesBE.idEstablecimiento
            docNotasAbarrotes.tipoNota = documentoNotasAbarrotesBE.tipoNota
            docNotasAbarrotes.detalle = documentoNotasAbarrotesBE.detalle
            docNotasAbarrotes.tipoDoc = documentoNotasAbarrotesBE.tipoDoc
            docNotasAbarrotes.periodo = documentoNotasAbarrotesBE.periodo
            docNotasAbarrotes.fechaProceso = documentoNotasAbarrotesBE.fechaProceso
            docNotasAbarrotes.serie = documentoNotasAbarrotesBE.serie
            docNotasAbarrotes.numero = documentoNotasAbarrotesBE.serie
            docNotasAbarrotes.tipoCambio = documentoNotasAbarrotesBE.tipoCambio
            docNotasAbarrotes.importeNacional = documentoNotasAbarrotesBE.importeNacional
            docNotasAbarrotes.importeExtranjero = documentoNotasAbarrotesBE.importeExtranjero
            docNotasAbarrotes.moneda = documentoNotasAbarrotesBE.moneda
            docNotasAbarrotes.documentoAfectado = documentoNotasAbarrotesBE.documentoAfectado
            docNotasAbarrotes.usuarioActualizacion = documentoNotasAbarrotesBE.usuarioActualizacion
            docNotasAbarrotes.fechaActualizacion = documentoNotasAbarrotesBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docNotasAbarrotes).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoNotasAbarrotesBE As documentoNotasAbarrotes)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoNotasAbarrotesBE)
    End Sub

    Public Function GetListar_documentoNotasAbarrotes() As List(Of documentoNotasAbarrotes)
        Return (From a In HeliosData.documentoNotasAbarrotes Select a).ToList
    End Function

    Public Function GetUbicar_documentoNotasAbarrotesPorID(idDocumento As Integer) As documentoNotasAbarrotes
        Return (From a In HeliosData.documentoNotasAbarrotes
                 Where a.idDocumento = idDocumento Select a).First
    End Function

End Class
