Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF


Public Class InventarioTotalBL
    Inherits BaseBL

    Public Function Insert(ByVal InventarioTotalBE As InventarioTotal) As Integer
        Using ts As New TransactionScope
            HeliosData.InventarioTotal.Add(InventarioTotalBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return InventarioTotalBE.idItem
        End Using
    End Function

    Public Sub Update(ByVal InventarioTotalBE As InventarioTotal)
        Using ts As New TransactionScope
            Dim InvTotal As InventarioTotal = HeliosData.InventarioTotal.Where(Function(o) _
                                            o.idEmpresa = InventarioTotalBE.idEmpresa _
                                            And o.idAlmacen = InventarioTotalBE.idAlmacen _
                                            And o.tipoProducto = InventarioTotalBE.tipoProducto _
                                            And o.idItem = InventarioTotalBE.idItem).First()

            InvTotal.cantidad = InventarioTotalBE.cantidad
            InvTotal.unidad = InventarioTotalBE.unidad
            InvTotal.monto = InventarioTotalBE.monto
            InvTotal.precioUnitario = InventarioTotalBE.precioUnitario
            InvTotal.usuarioActualizacion = InventarioTotalBE.usuarioActualizacion
            InvTotal.fechaActualizacion = InventarioTotalBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(InvTotal).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal InventarioTotalBE As InventarioTotal)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(InventarioTotalBE)
    End Sub

    Public Function GetListar_InventarioTotal() As List(Of InventarioTotal)
        Return (From a In HeliosData.InventarioTotal Select a).ToList
    End Function

    Public Function GetUbicar_InventarioTotalPorID(idItem As String) As InventarioTotal
        Return (From a In HeliosData.InventarioTotal
                 Where a.idItem = idItem Select a).First
    End Function
End Class
