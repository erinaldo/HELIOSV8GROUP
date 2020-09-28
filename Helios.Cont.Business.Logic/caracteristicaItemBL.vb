Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports JNetFx.Framework.General

Public Class caracteristicaItemBL
    Inherits BaseBL


    Public Function listaCamposModelo(be As caracteristicaItem) As List(Of caracteristicaItem)

        Dim consulta = (From i In HeliosData.caracteristicaItem
                        Where i.tipo = be.tipo And i.idSubClasificacion = be.idSubClasificacion And i.idPadre = be.idPadre).ToList

        Return consulta

    End Function

    Public Function listaModelos(be As caracteristicaItem) As List(Of caracteristicaItem)

        Dim consulta = (From i In HeliosData.caracteristicaItem
                        Where i.tipo = be.tipo And i.idSubClasificacion = be.idSubClasificacion).ToList

        Return consulta

    End Function


    Public Function InsertCabezera(be As caracteristicaItem) As caracteristicaItem
        Using ts As New TransactionScope
            HeliosData.caracteristicaItem.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        Return be
    End Function

    Public Sub GuardarcaracteristicaItem(lista As List(Of caracteristicaItem))
        Using ts As New TransactionScope
            For Each i In lista
                Me.Insert(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



    Public Sub Insert(be As caracteristicaItem)
        Using ts As New TransactionScope
            HeliosData.caracteristicaItem.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
