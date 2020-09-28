Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class totalinventarioBL
    Inherits BaseBL

    Public Function Insert(ByVal totalinventarioBE As totalinventario) As Integer
        Using ts As New TransactionScope
            HeliosData.totalinventario.Add(totalinventarioBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return totalinventarioBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal totalinventarioBE As totalinventario)
        Using ts As New TransactionScope
            Dim totinv As totalinventario = HeliosData.totalinventario.Where(Function(o) _
                                            o.idEmpresa = totalinventarioBE.idEmpresa _
                                            And o.idCentroCosto = totalinventarioBE.idCentroCosto _
                                            And o.idAlmacen = totalinventarioBE.idAlmacen _
                                            And o.idItem = totalinventarioBE.idItem _
                                            And o.secuencia = totalinventarioBE.secuencia).First()

            totinv.ingresoID = totalinventarioBE.ingresoID
            totinv.cantidad = totalinventarioBE.cantidad
            totinv.costoUnitario = totalinventarioBE.costoUnitario
            totinv.idInventario = totalinventarioBE.idInventario
            totinv.tipoCosteo = totalinventarioBE.tipoCosteo
            totinv.usuarioModificacion = totalinventarioBE.usuarioModificacion
            totinv.fechaModificacion = totalinventarioBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(totinv).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal totalinventarioBE As totalinventario)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(totalinventarioBE)
    End Sub

    Public Function GetListar_totalinventario() As List(Of totalinventario)
        Return (From a In HeliosData.totalinventario Select a).ToList
    End Function

    Public Function GetUbicar_totalinventarioPorID(Secuencia As Integer) As totalinventario
        Return (From a In HeliosData.totalinventario
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class
