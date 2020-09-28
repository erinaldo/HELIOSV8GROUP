Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class compraexternadetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal compraexternadetalleBE As compraexternadetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.compraexternadetalle.Add(compraexternadetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return compraexternadetalleBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal compraexternadetalleBE As compraexternadetalle)
        Using ts As New TransactionScope
            Dim compraexternadet As compraexternadetalle = HeliosData.compraexternadetalle.Where(Function(o) _
                                            o.idDocumento = compraexternadetalleBE.idDocumento _
                                            And o.secuencia = compraexternadetalleBE.secuencia).First()

            compraexternadet.idItem = compraexternadetalleBE.idItem
            compraexternadet.descripcionItem = compraexternadetalleBE.descripcionItem
            compraexternadet.tipoExistencia = compraexternadetalleBE.tipoExistencia
            compraexternadet.destino = compraexternadetalleBE.destino
            compraexternadet.unidad1 = compraexternadetalleBE.unidad1
            compraexternadet.monto1 = compraexternadetalleBE.monto1
            compraexternadet.unidad2 = compraexternadetalleBE.unidad2
            compraexternadet.monto2 = compraexternadetalleBE.monto2
            compraexternadet.precioUnitario = compraexternadetalleBE.precioUnitario
            compraexternadet.precioUnitarioUS = compraexternadetalleBE.precioUnitarioUS
            compraexternadet.importe = compraexternadetalleBE.importe
            compraexternadet.importeUS = compraexternadetalleBE.importeUS
            compraexternadet.montokardex = compraexternadetalleBE.montokardex
            compraexternadet.montoIsc = compraexternadetalleBE.montoIsc
            compraexternadet.montoIgv = compraexternadetalleBE.montoIgv
            compraexternadet.otrosTributos = compraexternadetalleBE.otrosTributos
            compraexternadet.montokardexUS = compraexternadetalleBE.montokardexUS
            compraexternadet.montoIscUS = compraexternadetalleBE.montoIscUS
            compraexternadet.montoIgvUS = compraexternadetalleBE.montoIgvUS
            compraexternadet.otrosTributosUS = compraexternadetalleBE.otrosTributosUS
            compraexternadet.preEvento = compraexternadetalleBE.preEvento
            compraexternadet.bonificacion = compraexternadetalleBE.bonificacion
            compraexternadet.usuarioModificacion = compraexternadetalleBE.usuarioModificacion
            compraexternadet.fechaModificacion = compraexternadetalleBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(compraexternadet).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal compraexternadetalleBE As compraexternadetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(compraexternadetalleBE)
    End Sub

    Public Function GetListar_compraexternadetalle() As List(Of compraexternadetalle)
        Return (From a In HeliosData.compraexternadetalle Select a).ToList
    End Function

    Public Function GetUbicar_compraexternadetallePorID(idDocumento As Integer) As compraexternadetalle
        Return (From a In HeliosData.compraexternadetalle
                Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
