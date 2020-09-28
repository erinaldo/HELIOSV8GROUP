Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class inventarioBL
    Inherits BaseBL

    Public Function Insert(ByVal inventarioBE As inventario) As Integer
        Using ts As New TransactionScope
            HeliosData.inventario.Add(inventarioBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return inventarioBE.idInventario
        End Using
    End Function

    Public Sub Update(ByVal inventarioBE As inventario)
        Using ts As New TransactionScope
            Dim inventario As inventario = HeliosData.inventario.Where(Function(o) _
                                            o.idInventario = inventarioBE.idInventario _
                                            And o.idDocumento = inventarioBE.idDocumento).First()

            inventario.idEmpresa = inventarioBE.idEmpresa
            inventario.idCentroCosto = inventarioBE.idCentroCosto
            inventario.idAlmacen = inventarioBE.idAlmacen
            inventario.idItem = inventarioBE.idItem
            inventario.ingresoID = inventarioBE.ingresoID
            inventario.idEvento = inventarioBE.idEvento
            inventario.origen = inventarioBE.origen
            inventario.secuencia = inventarioBE.secuencia
            inventario.fecha = inventarioBE.fecha
            inventario.tipo = inventarioBE.tipo
            inventario.cantidad = inventarioBE.cantidad
            inventario.costoUnitario = inventarioBE.costoUnitario
            inventario.costoTotal = inventarioBE.costoTotal
            inventario.usuarioActualizacion = inventarioBE.usuarioActualizacion
            inventario.fechaActualizacion = inventarioBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(inventario).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal inventarioBE As inventario)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(inventarioBE)
    End Sub

    Public Function GetListar_inventario() As List(Of inventario)
        Return (From a In HeliosData.inventario Select a).ToList
    End Function

    Public Function GetUbicar_inventarioPorID(idInventario As String) As inventario
        Return (From a In HeliosData.inventario
                 Where a.idInventario = idInventario Select a).First
    End Function
End Class
