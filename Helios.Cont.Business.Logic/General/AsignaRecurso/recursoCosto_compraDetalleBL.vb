Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class recursoCosto_compraDetalleBL
    Inherits BaseBL

    Public Sub Grabar(be As recursoCosto_compraDetalle)
        Dim obj As New recursoCosto_compraDetalle
        Using TS As New TransactionScope

            obj = New recursoCosto_compraDetalle
            obj.idDocumento = be.idDocumento
            obj.idCosto = be.idCosto
            obj.secuenciaCompra = be.secuenciaCompra
            obj.secuenciacosto = be.secuenciacosto
            obj.cantidad = be.cantidad

            HeliosData.recursoCosto_compraDetalle.Add(obj)
            HeliosData.SaveChanges()
            TS.Complete()
        End Using
    End Sub

End Class
