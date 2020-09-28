Imports Helios.Cont.Business.Entity
Imports System.Data.Entity.Migrations
Imports System.Transactions
Public Class recursoCostoLoteTallaBL
    Inherits BaseBL

    Public Sub recursoCostoLoteTallaSave(be As recursoCostoLoteTalla)
        Using ts As New TransactionScope
            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    HeliosData.recursoCostoLoteTalla.Add(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.recursoCostoLoteTalla.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE
                    HeliosData.recursoCostoLoteTalla.AddOrUpdate(be)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub recursoCostoLoteTallaSaveList(be As List(Of recursoCostoLoteTalla))
        Using ts As New TransactionScope
            HeliosData.recursoCostoLoteTalla.AddRange(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub RegistrarItems(be As recursoCostoLote)
        Using ts As New TransactionScope
            Dim item = HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = be.codigoLote).SingleOrDefault
            item.verificado = True
            recursoCostoLoteTallaSaveList(be.CustomRecursoCostoLoteTallaList)
            GetRegistroInventarioTallas(be.CustomRecursoCostoLoteTallaList)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub GetRegistroInventarioTallas(customRecursoCostoLoteTallaList As List(Of recursoCostoLoteTalla))
        ' Dim item As totalesAlmacenOthers
        Using ts As New TransactionScope
            For Each i In customRecursoCostoLoteTallaList
                Dim idProd = i.CustomTotalesAlmacenOthers.idProducto
                Dim idEquival = i.CustomTotalesAlmacenOthers.id_equivalencia
                HeliosData.totalesAlmacenOthers.Add(i.CustomTotalesAlmacenOthers)
                'Dim existeTalla = HeliosData.totalesAlmacenOthers.Any(Function(o) o.idProducto = idProd And o.id_equivalencia = idEquival)
                'If Not existeTalla Then
                '    HeliosData.totalesAlmacenOthers.Add(i.CustomTotalesAlmacenOthers)
                'Else

                '    Dim itemExistente = HeliosData.totalesAlmacenOthers.Where(Function(o) o.idProducto = idProd And o.id_equivalencia = idEquival).SingleOrDefault
                '    If itemExistente IsNot Nothing Then
                '        Dim stockActual = HeliosData.totalesAlmacenOthers.Where(Function(o) o.idProducto = idProd And o.id_equivalencia = idEquival).Sum(Function(o) o.cantidad).GetValueOrDefault
                '        itemExistente.cantidad += stockActual
                '    End If
                'End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
