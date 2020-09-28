Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports JNetFx.Framework.General

Public Class LoteDetalleBL
    Inherits BaseBL


    Public Function CantidadDetalle(idLote As Integer) As Integer

        Dim consulta = (From i In HeliosData.LoteDetalle
                        Where i.codigoLote = idLote).Count

        Return consulta
    End Function

    Public Sub GuardarLoteDetalle(be As recursoCostoLote, lista As List(Of LoteDetalle))
        Using ts As New TransactionScope
            For Each i In lista
                Me.Insert(i)
            Next

            updateLoteCaracteristicas(be)


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub updateLoteCaracteristicas(be As recursoCostoLote)


        Using ts As New TransactionScope

            Dim lote = HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = be.codigoLote).Single

            lote.idCaracteristica = be.idCaracteristica

            HeliosData.SaveChanges()
            ts.Complete()
        End Using


    End Sub




    Public Sub Insert(be As LoteDetalle)
        Using ts As New TransactionScope
            HeliosData.LoteDetalle.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
