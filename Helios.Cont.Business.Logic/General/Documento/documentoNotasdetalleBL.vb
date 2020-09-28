Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoNotasdetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoNotasdetalleBE As documentoNotasdetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoNotasdetalle.Add(documentoNotasdetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoNotasdetalleBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoNotasdetalleBE As documentoNotasdetalle)
        Using ts As New TransactionScope
            Dim docNotasdetalle As documentoNotasdetalle = HeliosData.documentoNotasdetalle.Where(Function(o) _
                                            o.idDocumento = documentoNotasdetalleBE.idDocumento _
                                            And o.secuencia = documentoNotasdetalleBE.secuencia).First()

            docNotasdetalle.DocumentoReferencia = documentoNotasdetalleBE.DocumentoReferencia
            docNotasdetalle.tipoMovimiento = documentoNotasdetalleBE.tipoMovimiento
            docNotasdetalle.idItem = documentoNotasdetalleBE.idItem
            docNotasdetalle.descripcionConcepto = documentoNotasdetalleBE.descripcionConcepto
            docNotasdetalle.tipoExistencia = documentoNotasdetalleBE.tipoExistencia
            docNotasdetalle.destino = documentoNotasdetalleBE.destino
            docNotasdetalle.unidad1 = documentoNotasdetalleBE.unidad1
            docNotasdetalle.monto1 = documentoNotasdetalleBE.monto1
            docNotasdetalle.unidad2 = documentoNotasdetalleBE.unidad2
            docNotasdetalle.monto2 = documentoNotasdetalleBE.monto2
            docNotasdetalle.precioUnitario = documentoNotasdetalleBE.precioUnitario
            docNotasdetalle.precioUnitarioUS = documentoNotasdetalleBE.precioUnitarioUS
            docNotasdetalle.importe = documentoNotasdetalleBE.importe
            docNotasdetalle.importeUS = documentoNotasdetalleBE.importeUS
            docNotasdetalle.montokardex = documentoNotasdetalleBE.montokardex
            docNotasdetalle.montoIsc = documentoNotasdetalleBE.montoIsc
            docNotasdetalle.montoIgv = documentoNotasdetalleBE.montoIgv
            docNotasdetalle.otrosTributos = documentoNotasdetalleBE.otrosTributos
            docNotasdetalle.montokardexUS = documentoNotasdetalleBE.montokardexUS
            docNotasdetalle.montoIscUS = documentoNotasdetalleBE.montoIscUS
            docNotasdetalle.montoIgvUS = documentoNotasdetalleBE.montoIgvUS
            docNotasdetalle.otrosTributosUS = documentoNotasdetalleBE.otrosTributosUS
            docNotasdetalle.preEvento = documentoNotasdetalleBE.preEvento
            docNotasdetalle.usuarioModificacion = documentoNotasdetalleBE.usuarioModificacion
            docNotasdetalle.fechaModificacion = documentoNotasdetalleBE.fechaModificacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(docNotasdetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoNotasdetalleBE As documentoNotasdetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoNotasdetalleBE)
    End Sub

    Public Function GetListar_documentoNotasdetalle() As List(Of documentoNotasdetalle)
        Return (From a In HeliosData.documentoNotasdetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoNotasdetallePorID(Secuencia As Integer) As documentoNotasdetalle
        Return (From a In HeliosData.documentoNotasdetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class
