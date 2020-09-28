Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class hojaCostoBL
    Inherits BaseBL

    Public Function Insert(ByVal hojaCostoBE As hojaCosto) As Integer
        Using ts As New TransactionScope
            HeliosData.hojaCosto.Add(hojaCostoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return hojaCostoBE.idEvento
        End Using
    End Function

    Public Sub Update(ByVal hojaCostoBE As hojaCosto)
        Using ts As New TransactionScope
            Dim hojaCosto As hojaCosto = HeliosData.hojaCosto.Where(Function(o) _
                                            o.idEvento = hojaCostoBE.idEvento _
                                            And o.idEmpresa = hojaCostoBE.idEmpresa _
                                            And o.idEstablecimiento = hojaCostoBE.idEstablecimiento).First()

            hojaCosto.descripcion = hojaCostoBE.descripcion
            hojaCosto.estadoCosto = hojaCostoBE.estadoCosto
            hojaCosto.codigoCuenta = hojaCostoBE.codigoCuenta
            hojaCosto.usuarioModificacion = hojaCostoBE.usuarioModificacion
            hojaCosto.fechaModificacion = hojaCostoBE.fechaModificacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(hojaCosto).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal hojaCostoBE As hojaCosto)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(hojaCostoBE)
    End Sub

    Public Function GetListar_hojaCosto() As List(Of hojaCosto)
        Return (From a In HeliosData.hojaCosto Select a).ToList
    End Function

    Public Function GetUbicar_hojaCostoPorID(idEvento As String) As hojaCosto
        Return (From a In HeliosData.hojaCosto
                 Where a.idEvento = idEvento Select a).First
    End Function
End Class
