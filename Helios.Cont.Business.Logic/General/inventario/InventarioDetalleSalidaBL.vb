Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class InventarioDetalleSalidaBL
    Inherits BaseBL

    Public Function Insert(ByVal InventarioDetalleSalidaBE As InventarioDetalleSalida) As Integer
        Using ts As New TransactionScope
            HeliosData.InventarioDetalleSalida.Add(InventarioDetalleSalidaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return InventarioDetalleSalidaBE.idInventario
        End Using
    End Function

    Public Sub Update(ByVal InventarioDetalleSalidaBE As InventarioDetalleSalida)
        Using ts As New TransactionScope
            Dim InvDetalleSalida As InventarioDetalleSalida = HeliosData.InventarioDetalleSalida.Where(Function(o) _
                                            o.idInventario = InventarioDetalleSalidaBE.idInventario _
                                            And o.idSecuencia = InventarioDetalleSalidaBE.idSecuencia).First()

            InvDetalleSalida.idInventarioRef = InventarioDetalleSalidaBE.idInventarioRef
            InvDetalleSalida.cantidad = InventarioDetalleSalidaBE.cantidad
            InvDetalleSalida.cantidad2 = InventarioDetalleSalidaBE.cantidad2
            InvDetalleSalida.monto = InventarioDetalleSalidaBE.monto
            InvDetalleSalida.montoUSD = InventarioDetalleSalidaBE.montoUSD
            InvDetalleSalida.montoOther = InventarioDetalleSalidaBE.montoOther

            'HeliosData.ObjectStateManager.GetObjectStateEntry(InvDetalleSalida).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal InventarioDetalleSalidaBE As InventarioDetalleSalida)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(InventarioDetalleSalidaBE)
    End Sub

    Public Function GetListar_InventarioDetalleSalida() As List(Of InventarioDetalleSalida)
        Return (From a In HeliosData.InventarioDetalleSalida Select a).ToList
    End Function

    Public Function GetUbicar_InventarioDetalleSalidaPorID(idInventario As Integer) As InventarioDetalleSalida
        Return (From a In HeliosData.InventarioDetalleSalida
                 Where a.idInventario = idInventario Select a).First
    End Function
End Class
