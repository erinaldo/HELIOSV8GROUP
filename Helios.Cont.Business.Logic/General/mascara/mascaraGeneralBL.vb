Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class mascaraGeneralBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraGeneralBE As mascaraGeneral) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraGeneral.Add(mascaraGeneralBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraGeneralBE.IDMascara
        End Using
    End Function

    Public Sub Update(ByVal mascaraGeneralBE As mascaraGeneral)
        Using ts As New TransactionScope
            Dim maskGeneral As mascaraGeneral = HeliosData.mascaraGeneral.Where(Function(o) _
                                            o.IDMascara = mascaraGeneralBE.IDMascara).First()

            maskGeneral.cuentaCompra = mascaraGeneralBE.cuentaCompra
            maskGeneral.descripcionCompra = mascaraGeneralBE.descripcionCompra
            maskGeneral.asientoCompra = mascaraGeneralBE.asientoCompra
            maskGeneral.destinoCompra = mascaraGeneralBE.destinoCompra
            maskGeneral.descripcionDestino = mascaraGeneralBE.descripcionDestino
            maskGeneral.asientoDestino = mascaraGeneralBE.asientoDestino
            maskGeneral.destinoCompra2 = mascaraGeneralBE.destinoCompra2
            maskGeneral.descripcionDestino2 = mascaraGeneralBE.descripcionDestino2
            maskGeneral.asientoDestino2 = mascaraGeneralBE.asientoDestino2
            maskGeneral.cuentaDestinoKardex = mascaraGeneralBE.cuentaDestinoKardex
            maskGeneral.nameDestinoKardex = mascaraGeneralBE.nameDestinoKardex
            maskGeneral.asientoDestinoKardex = mascaraGeneralBE.asientoDestinoKardex
            maskGeneral.cuentaDestinoKardex2 = mascaraGeneralBE.cuentaDestinoKardex2
            maskGeneral.nameDestinoKardex2 = mascaraGeneralBE.nameDestinoKardex2
            maskGeneral.asientoDestinoKardex2 = mascaraGeneralBE.asientoDestinoKardex2
            maskGeneral.cuentaVenta = mascaraGeneralBE.cuentaVenta
            maskGeneral.descripcionVenta = mascaraGeneralBE.descripcionVenta
            maskGeneral.asientoVenta = mascaraGeneralBE.asientoVenta
            maskGeneral.cuentaKardex = mascaraGeneralBE.cuentaKardex
            maskGeneral.descripcionKardex = mascaraGeneralBE.descripcionKardex
            maskGeneral.asientoKardex = mascaraGeneralBE.asientoKardex
            maskGeneral.cuentaKardex2 = mascaraGeneralBE.cuentaKardex2
            maskGeneral.descripcionKardex2 = mascaraGeneralBE.descripcionKardex2
            maskGeneral.asientoKardex2 = mascaraGeneralBE.asientoKardex2

            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskGeneral).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraGeneralBE As mascaraGeneral)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraGeneralBE)
    End Sub

    Public Function GetListar_mascaraGeneral() As List(Of mascaraGeneral)
        Return (From a In HeliosData.mascaraGeneral Select a).ToList
    End Function

    Public Function GetUbicar_mascaraGeneralPorID(IDMascara As Integer) As mascaraGeneral
        Return (From a In HeliosData.mascaraGeneral
                 Where a.IDMascara = IDMascara Select a).First
    End Function
End Class
